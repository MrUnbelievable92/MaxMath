using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal product of components of a float2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float2 x)
        {
            return (x * x.yx).x;
        }

        /// <summary>       Returns the horizontal product of components of a float3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a float4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }

        /// <summary>       Returns the horizontal product of components of a float8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float8 x)
        {
            v128 result = Sse.mul_ps(Avx.mm256_castsi256_si128(x),
                                     Avx2.mm256_extracti128_si256(x, 1));

            result = Sse.mul_ps(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

            return result.Float0 * result.Float1;
        }


        /// <summary>       Returns the horizontal product of components of a double2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double2 x)
        {
            return (x * x.yx).x;
        }

        /// <summary>       Returns the horizontal product of components of a double3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a double4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }


        /// <summary>       Returns the horizontal product of components of a byte2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte2 x)
        {
            return (uint)(x.x * x.y);
        }

        /// <summary>       Returns the horizontal product of components of a byte3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte3 x)
        {
            return (uint)(x.x * x.y * x.z);
        }

        /// <summary>       Returns the horizontal product of components of a byte4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte4 x)
        {
            return (uint)((x.x * x.y) * (x.z * x.w));
        }

        /// <summary>       Returns the horizontal product of components of a byte8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte8 x)
        {
            return cprod((uint4)x.v4_0 * (uint4)x.v4_4);
        }

        /// <summary>       Returns the horizontal product of components of a byte16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte16 x)
        {
            return cprod((uint8)x.v8_0 * (uint8)x.v8_8);
        }

        /// <summary>       Returns the horizontal product of components of a byte32 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte32 x)
        {
            return cprod((ushort16)x.v16_0 * (ushort16)x.v16_16);
        }


        /// <summary>       Returns the horizontal product of components of an sbyte2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-127 * 128,    128 * 128)]
        public static int cprod(sbyte2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of an sbyte3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-128 * 128 * 128,    127 * 128 * 128)]
        public static int cprod(sbyte3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of an sbyte4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-127 * 128 * 128 * 128,    128 * 128 * 128 * 128)]
        public static int cprod(sbyte4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }

        /// <summary>       Returns the horizontal product of components of an sbyte8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte8 x)
        {
            return cprod((int4)x.v4_0 * (int4)x.v4_4);
        }

        /// <summary>       Returns the horizontal product of components of an sbyte16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte16 x)
        {
            return cprod((int8)x.v8_0 * (int8)x.v8_8);
        }

        /// <summary>       Returns the horizontal product of components of an sbyte32 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte32 x)
        {
            return cprod((short16)x.v16_0 * (short16)x.v16_16);
        }


        /// <summary>       Returns the horizontal product of components of a short2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a short3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a short4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }

        /// <summary>       Returns the horizontal product of components of a short8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short8 x)
        {
            x = Avx.mm256_castsi256_si128((int8)x * (int8)(short8)Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));
            x = Sse4_1.mullo_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse4_1.extract_epi32(x, 0) * Sse4_1.extract_epi32(x, 1);
        }

        /// <summary>       Returns the horizontal product of components of a short16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short16 x)
        {
            v128 lo = x.v8_0;

            lo = Avx.mm256_castsi256_si128(((int8)(short8)lo * (int8)(short8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                           *
                                           ((int8)x.v8_8 * (int8)(short8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

            lo = Sse4_1.mullo_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse4_1.extract_epi32(lo, 0) * Sse4_1.extract_epi32(lo, 1);
        }


        /// <summary>       Returns the horizontal product of components of a ushort2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort2 x)
        {
            return (uint)(x.x * x.y);
        }

        /// <summary>       Returns the horizontal product of components of a ushort3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort3 x)
        {
            return (uint)((x.x * x.y) * x.z);
        }

        /// <summary>       Returns the horizontal product of components of a ushort4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort4 x)
        {
            return (uint)((x.x * x.y) * (x.z * x.w));
        }

        /// <summary>       Returns the horizontal product of components of a ushort8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort8 x)
        {
            x = Avx.mm256_castsi256_si128((uint8)x * (uint8)(ushort8)Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));
            x = Sse4_1.mullo_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)Sse4_1.extract_epi32(x, 0) * (uint)Sse4_1.extract_epi32(x, 1);
        }

        /// <summary>       Returns the horizontal product of components of a ushort16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort16 x)
        {
            v128 lo = x.v8_0;

            lo = Avx.mm256_castsi256_si128(((uint8)(ushort8)lo * (uint8)(ushort8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                            *
                                            ((uint8)x.v8_8 * (uint8)(ushort8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

            lo = Sse4_1.mullo_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)Sse4_1.extract_epi32(lo, 0) * (uint)Sse4_1.extract_epi32(lo, 1);
        }


        /// <summary>       Returns the horizontal product of components of an int2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of an int3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of an int4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }

        /// <summary>       Returns the horizontal product of components of an int8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int8 x)
        {
            v128 result = Sse4_1.mullo_epi32(Avx.mm256_castsi256_si128(x),
                                             Avx2.mm256_extracti128_si256(x, 1));

            result = Sse4_1.mullo_epi32(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse4_1.extract_epi32(result, 0) * Sse4_1.extract_epi32(result, 1);
        }


        /// <summary>       Returns the horizontal product of components of a uint2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a uint3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a uint4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint4 x)
        {
            x *= x.wzyx;
            x *= x.yxxx;

            return x.x;
        }

        /// <summary>       Returns the horizontal product of components of a uint8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint8 x)
        {
            return (uint)cprod((int8)x);
        }


        /// <summary>       Returns the horizontal product of components of a long2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a long3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a long4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }


        /// <summary>       Returns the horizontal product of components of a ulong2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a ulong3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a ulong4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }
    }
}