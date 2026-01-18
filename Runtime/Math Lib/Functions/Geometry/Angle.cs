using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float PRE_angle(float2 a, float2 b)
        {
            a *= a;
            b *= b;
            a.x += a.y;
            b.x += b.y;

            return a.x * b.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double PRE_angle(double2 a, double2 b)
        {
            a *= a;
            b *= b;
            a.x += a.y;
            b.x += b.y;

            return a.x * b.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float2 dot2(float2x2 a, float2x2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                float2 ax = math.shuffle(a.c0, a.c1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX);
                float2 bx = math.shuffle(b.c0, b.c1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX);
                float2 ay = math.shuffle(a.c0, a.c1, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                float2 by = math.shuffle(b.c0, b.c1, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);

                return RegisterConversion.ToFloat2(Xse.fmadd_ps(RegisterConversion.ToV128(ay), RegisterConversion.ToV128(by), RegisterConversion.ToV128(ax * bx)));
            }
            else
            {
                a *= b;

                return new float2(math.csum(a.c0), math.csum(a.c1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double2 dot2(double2x2 a, double2x2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                double2 ax = math.shuffle(a.c0, a.c1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX);
                double2 bx = math.shuffle(b.c0, b.c1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX);
                double2 ay = math.shuffle(a.c0, a.c1, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                double2 by = math.shuffle(b.c0, b.c1, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);

                return RegisterConversion.ToDouble2(Xse.fmadd_pd(RegisterConversion.ToV128(ay), RegisterConversion.ToV128(by), RegisterConversion.ToV128(ax * bx)));
            }
            else
            {
                a *= b;

                return new double2(math.csum(a.c0), math.csum(a.c1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float4 dot4(float2x4 a, float2x4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                float4 axy0 = math.shuffle(a.c0, a.c1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                float4 axy1 = math.shuffle(a.c2, a.c3, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                float4 ax = math.shuffle(axy0, axy1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX);

                float4 bxy1 = math.shuffle(b.c2, b.c3, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                float4 bxy0 = math.shuffle(b.c0, b.c1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                float4 bx = math.shuffle(bxy0, bxy1, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX, math.ShuffleComponent.LeftX, math.ShuffleComponent.RightX);

                float4 abx = ax * bx;

                float4 ay = math.shuffle(axy0, axy1, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);
                float4 by = math.shuffle(bxy0, bxy1, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY, math.ShuffleComponent.LeftY, math.ShuffleComponent.RightY);

                return RegisterConversion.ToFloat4(Xse.fmadd_ps(RegisterConversion.ToV128(ay), RegisterConversion.ToV128(by), RegisterConversion.ToV128(abx)));
            }
            else
            {
                a *= b;

                return new float4(math.csum(a.c0), math.csum(a.c1), math.csum(a.c2), math.csum(a.c3));
            }
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float2"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float2 a, float2 b)
        {
            // acos vs atan2: acos wins when it comes to code size (~25% less), branches (75% less) and execution speed (?% less)
            //if (constexpr.IS_CONST(a))
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
            //else if (constexpr.IS_CONST(b))
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

            return math.acos(math.dot(a, b) * math.rsqrt(PRE_angle(a, b)));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float2"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 angle(float2x2 a, float2x2 b)
        {
            float4 a4 = math.square(new float4(a.c0, a.c1));
            float4 b4 = math.square(new float4(b.c0, b.c1));
            a4 += a4.yyww; // Sse3.movehdup_ps(a4)
            b4 += b4.yyww; // Sse3.movehdup_ps(b4)
            a4 *= b4.xzxz; // Sse3.moveldup_ps(b4)

            return math.acos(dot2(a, b) * math.rsqrt(a4.xy));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float2"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 angle(float2x3 a, float2x3 b)
        {
            return new float3(angle(new float2x2(a.c0, a.c1), new float2x2(b.c0, b.c1)),
                              angle(a.c2, b.c2));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float2"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 angle(float2x4 a, float2x4 b)
        {
            if (Avx.IsAvxSupported)
            {
                float8 a8 = square(new float8(a.c0, a.c1, a.c2, a.c3));
                float8 b8 = square(new float8(b.c0, b.c1, b.c2, b.c3));

                a8 = Avx.mm256_add_ps(a8, Avx.mm256_movehdup_ps(a8));
                b8 = Avx.mm256_add_ps(b8, Avx.mm256_movehdup_ps(b8));
                a8 = Avx.mm256_mul_ps(a8, Avx.mm256_moveldup_ps(b8));

                return math.acos(dot4(a, b) * math.rsqrt(RegisterConversion.ToFloat4(Avx.mm256_permutevar_ps(a8, Avx.mm256_castsi128_si256(new v128(0, 1, 4, 5))).Lo128)));
            }
            else
            {
                return new float4(angle(new float2x2(a.c0, a.c1), new float2x2(b.c0, b.c1)),
                                  angle(new float2x2(a.c2, a.c3), new float2x2(b.c2, b.c3)));
            }
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float3"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float angle(float3 a, float3 b)
        {
            return math.acos(math.dot(a, b) * math.rsqrt(math.lengthsq(b) * math.lengthsq(a)));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float3"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 angle(float3x2 a, float3x2 b)
        {
            return new float2(angle(a.c0, b.c0), angle(a.c1, b.c1));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float3"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 angle(float3x3 a, float3x3 b)
        {
            return new float3(angle(new float3x2(a.c0, a.c1), new float3x2(b.c0, b.c1)),
                              angle(a.c2, b.c2));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="float3"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 angle(float3x4 a, float3x4 b)
        {
            return new float4(angle(new float3x2(a.c0, a.c1), new float3x2(b.c0, b.c1)),
                              angle(new float3x2(a.c2, a.c3), new float3x2(b.c2, b.c3)));
        }


        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double2"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double2 a, double2 b)
        {
            double4 temp = new double4(a, b);
            temp *= temp;
            temp += temp.yyww;
            temp *= temp.zwzw;

            return math.acos(math.dot(a, b) / math.sqrt(temp.x));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double2"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 angle(double2x2 a, double2x2 b)
        {
            double4 a4 = math.square(new double4(a.c0, a.c1));
            double4 b4 = math.square(new double4(b.c0, b.c1));
            a4 += a4.yyww;
            b4 += b4.yyww;
            a4 *= b4.xzxz;

            return math.acos(dot2(a, b) * math.rsqrt(a4.xy));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double2"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 angle(double2x3 a, double2x3 b)
        {
            return new double3(angle(new double2x2(a.c0, a.c1), new double2x2(b.c0, b.c1)),
                               angle(a.c2, b.c2));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double2"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 angle(double2x4 a, double2x4 b)
        {
            return new double4(angle(new double2x2(a.c0, a.c1), new double2x2(b.c0, b.c1)),
                               angle(new double2x2(a.c2, a.c3), new double2x2(b.c2, b.c3)));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double3"/> (origin) vectors in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double angle(double3 a, double3 b)
        {
            // acos vs atan2: acos wins when it comes to code size (~25% less), branches (75% less) and execution speed (?% less)
            //if (constexpr.IS_CONST(a))
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
            //else if (constexpr.IS_CONST(b))
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

            return math.acos(math.dot(a, b) / math.sqrt(math.lengthsq(b) * math.lengthsq(a)));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double3"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 angle(double3x2 a, double3x2 b)
        {
            return new double2(angle(a.c0, b.c0), angle(a.c1, b.c1));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double3"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 angle(double3x3 a, double3x3 b)
        {
            return new double3(angle(new double3x2(a.c0, a.c1), new double3x2(b.c0, b.c1)),
                               angle(a.c2, b.c2));
        }

        /// <summary>       Returns the unsigned angle between two non-normalized <see cref="double3"/> (origin) vector pairs in radians.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 angle(double3x4 a, double3x4 b)
        {
            return new double4(angle(new double3x2(a.c0, a.c1), new double3x2(b.c0, b.c1)),
                               angle(new double3x2(a.c2, a.c3), new double3x2(b.c2, b.c3)));
        }
    }
}