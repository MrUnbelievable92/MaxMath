using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float2 x)
        {
            return (x * x.yx).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float8 x)
        {
            v128 result = X86.Sse.mul_ps(X86.Avx.mm256_castsi256_si128(x),
                                         X86.Avx2.mm256_extracti128_si256(x, 1));

            result = X86.Sse.mul_ps(result, X86.Sse2.shuffle_epi32(result, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return result.Float0 * result.Float1;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double2 x)
        {
            return (x * x.yx).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte2 x)
        {
            return (uint)(x.x * x.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte3 x)
        {
            return (uint)(x.x * x.y * x.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte4 x)
        {
            return (uint)((x.x * x.y) * (x.z * x.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte8 x)
        {
            return cprod((uint4)x.v4_0 * (uint4)x.v4_4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte16 x)
        {
            return cprod((uint8)x.v8_0 * (uint8)x.v8_8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte32 x)
        {
            return cprod((ushort16)x.v16_0 * (ushort16)x.v16_16);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-127 * 128,    128 * 128)]
        public static int cprod(sbyte2 x)
        {
            return x.x * x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-128 * 128 * 128,    127 * 128 * 128)]
        public static int cprod(sbyte3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-127 * 128 * 128 * 128,    128 * 128 * 128 * 128)]
        public static int cprod(sbyte4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte8 x)
        {
            return cprod((int4)x.v4_0 * (int4)x.v4_4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte16 x)
        {
            return cprod((int8)x.v8_0 * (int8)x.v8_8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte32 x)
        {
            return cprod((short16)x.v16_0 * (short16)x.v16_16);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short2 x)
        {
            return x.x * x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short8 x)
        {
            x = X86.Avx.mm256_castsi256_si128((int8)x * (int8)(short8)X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3)));
            x = X86.Sse4_1.mullo_epi32(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(x, 0) * X86.Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short16 x)
        {
            v128 lo = x.v8_0;

            lo = X86.Avx.mm256_castsi256_si128(((int8)(short8)lo * (int8)(short8)X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)))
                                               *
                                               ((int8)x.v8_8 * (int8)(short8)X86.Sse2.shuffle_epi32(x.v8_8, X86.Sse.SHUFFLE(0, 1, 2, 3))));

            lo = X86.Sse4_1.mullo_epi32(lo, X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(lo, 0) * X86.Sse4_1.extract_epi32(lo, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort2 x)
        {
            return (uint)(x.x * x.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort3 x)
        {
            return (uint)((x.x * x.y) * x.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort4 x)
        {
            return (uint)((x.x * x.y) * (x.z * x.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort8 x)
        {
            x = X86.Avx.mm256_castsi256_si128((uint8)x * (uint8)(ushort8)X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3)));
            x = X86.Sse4_1.mullo_epi32(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)X86.Sse4_1.extract_epi32(x, 0) * (uint)X86.Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort16 x)
        {
            v128 lo = x.v8_0;

            lo = X86.Avx.mm256_castsi256_si128(((uint8)(ushort8)lo * (uint8)(ushort8)X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)))
                                               *
                                               ((uint8)x.v8_8 * (uint8)(ushort8)X86.Sse2.shuffle_epi32(x.v8_8, X86.Sse.SHUFFLE(0, 1, 2, 3))));

            lo = X86.Sse4_1.mullo_epi32(lo, X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)X86.Sse4_1.extract_epi32(lo, 0) * (uint)X86.Sse4_1.extract_epi32(lo, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int2 x)
        {
            return x.x * x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int8 x)
        {
            v128 result = X86.Sse4_1.mullo_epi32(X86.Avx.mm256_castsi256_si128(x),
                                                 X86.Avx2.mm256_extracti128_si256(x, 1));

            result = X86.Sse4_1.mullo_epi32(result, X86.Sse2.shuffle_epi32(result, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(result, 0) * X86.Sse4_1.extract_epi32(result, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint2 x)
        {
            return x.x * x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint8 x)
        {
            return (uint)cprod((int8)x);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long2 x)
        {
            return x.x * x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong2 x)
        {
            return x.x * x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong3 x)
        {
            return (x.x * x.y) * x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }
    }
}