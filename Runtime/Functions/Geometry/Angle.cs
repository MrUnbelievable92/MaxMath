using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float2"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float2 a, float2 b)
        {
            // acos vs atan2: acos wins when it comes to code size (~25% less), branches (75% less) and execution speed (?% less)
            //if (Constant.IsConstantExpression(a))
            //{
            //    if (a.x == 0f && a.y >= 0f)
            //    {
            //        return math.atan2(b.x, b.y);
            //    }
            //    else if (a.x >= 0f && a.y == 0f)
            //    {
            //        return math.atan2(b.y, b.x);
            //    }
            //
            //}
            //else if (Constant.IsConstantExpression(b))
            //{
            //    if (b.x == 0f && b.y >= 0f)
            //    {
            //        return math.atan2(a.x, a.y);
            //    }
            //    else if (b.x >= 0f && b.y == 0f)
            //    {
            //        return math.atan2(a.y, a.x);
            //    }
            //}

            float4 temp = new float4(a, b);
            temp *= temp;
            temp += temp.yyww; // Sse3.movehdup_ps( temp )
            temp *= temp.zwzw; // Sse.movehl_ps( temp ,  temp )

            return math.acos(math.dot(b, a) * math.rsqrt(temp.x));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float3"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float3 a, float3 b)
        {
            return math.acos(math.dot(b, a) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }


        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double2"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double2 a, double2 b)
        {
            double4 temp = new double4(a, b);
            temp *= temp;
            temp += temp.yyww;
            temp *= temp.zwzw;

            return math.acos(math.dot(b, a) / math.sqrt(temp.x));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double3"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double3 a, double3 b)
        {
            // acos vs atan2: acos wins when it comes to code size (~25% less), branches (75% less) and execution speed (?% less)
            //if (Constant.IsConstantExpression(a))
            //{
            //    if (a.x == 0d && a.y >= 0d)
            //    {
            //        return math.atan2(b.x, b.y);
            //    }
            //    else if (a.x >= 0d && a.y == 0d)
            //    {
            //        return math.atan2(b.y, b.x);
            //    }
            //
            //}
            //else if (Constant.IsConstantExpression(b))
            //{
            //    if (b.x == 0d && b.y >= 0d)
            //    {
            //        return math.atan2(a.x, a.y);
            //    }
            //    else if (b.x >= 0d && b.y == 0d)
            //    {
            //        return math.atan2(a.y, a.x);
            //    }
            //}

            return math.acos(math.dot(b, a) / math.sqrt(math.lengthsq(b) * math.lengthsq(a)));
        }
    }
}