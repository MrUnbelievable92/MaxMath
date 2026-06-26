using System.Runtime.CompilerServices;

namespace MaxMath
{
    public static class svd
    {
        public const float k_EpsilonDeterminant = Unity.Mathematics.svd.k_EpsilonDeterminant;
        public const float k_EpsilonRCP = Unity.Mathematics.svd.k_EpsilonRCP;
        public const float k_EpsilonNormalSqrt = Unity.Mathematics.svd.k_EpsilonNormalSqrt;
        public const float k_EpsilonNormal = Unity.Mathematics.svd.k_EpsilonNormal;

        public const double k_EpsilonDeterminant_DBL = k_EpsilonDeterminant / 536870912d;
        public const double k_EpsilonRCP_DBL = k_EpsilonRCP / 536870912d;
        public const double k_EpsilonNormalSqrt_DBL = k_EpsilonNormalSqrt / 536870912d;
        public const double k_EpsilonNormal_DBL = k_EpsilonNormal / 536870912d;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double4 mul_quaternion_DBL(double4 a, double4 b)
        {
            return a.wwww * b + (a.xyzx * b.wwwx + a.yzxy * b.zxyy) * new double4(1d, 1d, 1d, -1d) - a.zxyz * b.yzxz;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double4 conjugate_quaternion_DBL(double4 q)
        {
            return new double4(math.asdouble(math.asulong(q) ^ new ulong4(1ul << 63, 1ul << 63, 1ul << 63, 0)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double3x3 from_quaternion_DBL(double4 q)
        {
            double3x3 r = default;
            double4 v2 = q + q;

            ulong3 npn = new ulong3(1ul << 63,         0, 1ul << 63);
            ulong3 nnp = new ulong3(1ul << 63, 1ul << 63,         0);
            ulong3 pnn = new ulong3(        0, 1ul << 63, 1ul << 63);
            r.c0 = v2.y * math.asdouble(math.asulong(q.yxw) ^ npn) - v2.z * math.asdouble(math.asulong(q.zwx) ^ pnn) + new double3(1, 0, 0);
            r.c1 = v2.z * math.asdouble(math.asulong(q.wzy) ^ nnp) - v2.x * math.asdouble(math.asulong(q.yxw) ^ npn) + new double3(0, 1, 0);
            r.c2 = v2.x * math.asdouble(math.asulong(q.zwx) ^ pnn) - v2.y * math.asdouble(math.asulong(q.wzy) ^ nnp) + new double3(0, 0, 1);

            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void condSwap(bool c, ref double x, ref double y)
        {
            double tmp = x;
            x = math.select(x, y, c);
            y = math.select(y, tmp, c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void condNegSwap(bool c, ref double3 x, ref double3 y)
        {
            double3 tmp = -x;
            x = math.select(x, y, c);
            y = math.select(y, tmp, c);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double4 condNegSwapQuat(bool c, double4 q, double4 mask)
        {
            const double halfSqrt2 = 0.7071067811865475244008443621048490392848359376884740365883398689d;
            return mul_quaternion_DBL(q, math.select(quaternion.identity.value, mask * halfSqrt2, c));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void sortSingularValues(ref double3x3 b, ref double4 v)
        {
            double l0 = math.lengthsq(b.c0);
            double l1 = math.lengthsq(b.c1);
            double l2 = math.lengthsq(b.c2);

            bool c = l0 < l1;
            condNegSwap(c, ref b.c0, ref b.c1);
            v = condNegSwapQuat(c, v, new double4(0d, 0d, 1d, 1d));
            condSwap(c, ref l0, ref l1);

            c = l0 < l2;
            condNegSwap(c, ref b.c0, ref b.c2);
            v = condNegSwapQuat(c, v, new double4(0d, -1d, 0d, 1d));
            condSwap(c, ref l0, ref l2);

            c = l1 < l2;
            condNegSwap(c, ref b.c1, ref b.c2);
            v = condNegSwapQuat(c, v, new double4(1d, 0d, 0d, 1d));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double4 approxGivensQuat(double3 pq, double4 mask)
        {
            const double c8 = 0.9238795325112867561281831893967882868224166258636424861150977312d;
            const double s8 = 0.3826834323650897717284599840303988667613445624856270414338006356d;
            const double g = 5.8284271247461900976033774484193961571393437507538961463533594759d;

            double ch = 2d * (pq.x - pq.y);
            double sh = pq.z;
            double4 r = math.select(new double4(s8, s8, s8, c8), new double4(sh, sh, sh, ch), g * sh * sh < ch * ch) * mask;
            return math.normalize(r);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double4 qrGivensQuat(double2 pq, double4 mask)
        {
            double l = math.sqrt(pq.x * pq.x + pq.y * pq.y);
            double sh = math.select(0d, pq.y, l > k_EpsilonNormalSqrt_DBL);
            double ch = math.abs(pq.x) + math.max(l, k_EpsilonNormalSqrt_DBL);
            condSwap(pq.x < 0d, ref sh, ref ch);

            return math.normalize(new double4(sh, sh, sh, ch) * mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double4 givensQRFactorization(double3x3 b, out double3x3 r)
        {
            double4 u = qrGivensQuat(new double2(b.c0.x, b.c0.y), new double4(0d, 0d, 1d, 1d));
            double3x3 qmt = from_quaternion_DBL(conjugate_quaternion_DBL(u));
            r = math.mul(qmt, b);

            double4 q = qrGivensQuat(new double2(r.c0.x, r.c0.z), new double4(0d, -1d, 0d, 1d));
            u = mul_quaternion_DBL(u, q);
            qmt = from_quaternion_DBL(conjugate_quaternion_DBL(q));
            r = math.mul(qmt, r);

            q = qrGivensQuat(new double2(r.c1.y, r.c1.z), new double4(1d, 0d, 0d, 1d));
            u = mul_quaternion_DBL(u, q);
            qmt = from_quaternion_DBL(conjugate_quaternion_DBL(q));
            r = math.mul(qmt, r);

            return u;
        }

        private static double4 jacobiIteration(ref double3x3 s, int iterations = 5)
        {
            double3x3 qm;
            double4 q;
            double4 v = quaternion.identity.value;

            for (int i = 0; i < iterations; ++i)
            {
                q = approxGivensQuat(new double3(s.c0.x, s.c1.y, s.c0.y), new double4(0d, 0d, 1d, 1d));
                v = mul_quaternion_DBL(v, q);
                qm = from_quaternion_DBL(q);
                s = math.mul(math.mul(math.transpose(qm), s), qm);

                q = approxGivensQuat(new double3(s.c1.y, s.c2.z, s.c1.z), new double4(1d, 0d, 0d, 1d));
                v = mul_quaternion_DBL(v, q);
                qm = from_quaternion_DBL(q);
                s = math.mul(math.mul(math.transpose(qm), s), qm);

                q = approxGivensQuat(new double3(s.c2.z, s.c0.x, s.c2.x), new double4(0d, 1d, 0d, 1d));
                v = mul_quaternion_DBL(v, q);
                qm = from_quaternion_DBL(q);
                s = math.mul(math.mul(math.transpose(qm), s), qm);
            }

            return v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double3 singularValuesDecomposition(double3x3 a, out double4 u, out double4 v)
        {
            u = quaternion.identity.value;
            v = quaternion.identity.value;

            double3x3 s = math.mul(math.transpose(a), a);
            v = jacobiIteration(ref s);
            double3x3 b = from_quaternion_DBL(v);
            b = math.mul(a, b);
            sortSingularValues(ref b, ref v);
            u = givensQRFactorization(b, out double3x3 e);

            return new double3(e.c0.x, e.c1.y, e.c2.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double3 rcpsafe(double3 x, double epsilon = k_EpsilonRCP_DBL) => math.select(math.rcp(x), double3.zero, math.abs(x) < epsilon);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 svdInverse(double3x3 a)
        {
            double3 e = singularValuesDecomposition(a, out double4 u, out double4 v);
            double3x3 um = from_quaternion_DBL(u);
            double3x3 vm = from_quaternion_DBL(v);

            return math.mul(vm, math.scaleMul(rcpsafe(e, k_EpsilonDeterminant_DBL), math.transpose(um)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion svdRotation(double3x3 a)
        {
            singularValuesDecomposition(a, out double4 u, out double4 v);
            return (float4)mul_quaternion_DBL(u, conjugate_quaternion_DBL(v));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 svdInverse(float3x3 a) => Unity.Mathematics.svd.svdInverse(a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion svdRotation(float3x3 a) => Unity.Mathematics.svd.svdRotation(a);
    }
}