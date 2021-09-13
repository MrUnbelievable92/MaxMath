using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal product of components of a <see cref="float2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float2 x)
        {
            return (x * x.yx).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="float3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float3 x)
        {
            return ((x * x.yyy) * x.zzz).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float4 x)
        {
            x *= x.wzyx;
            x *= x.yyyy;

            return x.x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Sse.mul_ps(Avx.mm256_castps256_ps128(x),
                                         Avx.mm256_extractf128_ps(x, 1));
            
                result = Sse.mul_ps(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));
            
                return Sse.mul_ss(result, Sse2.shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 3, 2))).Float0;
            }
            else
            {
                return cprod(x.v4_0 * x.v4_4);
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="double2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double2 x)
        {
            return (x * x.yx).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="double3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double3 x)
        {
            return ((x * x.yyy) * x.zzz).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double4 x)
        {
            x *= x.wzyx;
            x *= x.yyyy;

            return x.x;
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 255ul * 255ul)]
        public static uint cprod(byte2 x)
        {
            return (uint)x.x * (uint)x.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 255ul * 255ul * 255ul)]
        public static uint cprod(byte3 x)
        {
            return ((uint)x.x * (uint)x.y) * (uint)x.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 255ul * 255ul * 255ul * 255ul)]
        public static uint cprod(byte4 x)
        {
            uint4 cast = x;

            cast *= cast.zwzw;
            cast *= cast.yyyy;

            return cast.x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte8 x)
        {
            return cprod((uint4)x.v4_0 * (uint4)x.v4_4);
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte16 x)
        {
            return cprod((uint8)x.v8_0 * (uint8)x.v8_8);
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte32 x)
        {
            return cprod((ushort16)x.v16_0 * (ushort16)x.v16_16);
        }


        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-127 * 128,    128 * 128)]
        public static int cprod(sbyte2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-128 * 128 * 128,    127 * 128 * 128)]
        public static int cprod(sbyte3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-127 * 128 * 128 * 128,    128 * 128 * 128 * 128)]
        public static int cprod(sbyte4 x)
        {
            int4 cast = x;

            cast *= cast.zwzw;
            cast *= cast.yyyy;

            return cast.x;
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte8 x)
        {
            return cprod((int4)x.v4_0 * (int4)x.v4_4);
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte16 x)
        {
            return cprod((int8)x.v8_0 * (int8)x.v8_8);
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte32 x)
        {
            return cprod((short16)x.v16_0 * (short16)x.v16_16);
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-32768L * 32767L,    32767L * 32767L)]
        public static int cprod(short2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short4 x)
        {
            int4 cast = x;

            cast *= cast.zwzw;
            cast *= cast.yyyy;

            return cast.x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 prod = Avx.mm256_castsi256_si128((int8)x * (int8)(short8)Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));
                prod = Sse4_1.mullo_epi32(prod, Sse2.shuffle_epi32(prod, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse4_1.mullo_epi32(prod, Sse2.shufflelo_epi16(prod, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return cprod((int4)x.v4_0 * (int4)x.v4_4);
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = x.v8_0;

                lo = Avx.mm256_castsi256_si128(((int8)(short8)lo * (int8)(short8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                               *
                                               ((int8)x.v8_8 * (int8)(short8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

                lo = Sse4_1.mullo_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse4_1.mullo_epi32(lo, Sse2.shufflelo_epi16(lo, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return cprod((int8)x.v8_0 * (int8)x.v8_8);
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul,    65535ul * 65535ul)]
        public static uint cprod(ushort2 x)
        {
            return (uint)x.x * (uint)x.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort3 x)
        {
            return ((uint)x.x * (uint)x.y) * (uint)x.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort4 x)
        {
            uint4 cast = x;

            cast *= cast.zwzw;
            cast *= cast.yyyy;

            return cast.x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 prod = Avx.mm256_castsi256_si128((uint8)x * (uint8)(ushort8)Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));
                prod = Sse4_1.mullo_epi32(prod, Sse2.shuffle_epi32(prod, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse4_1.mullo_epi32(prod, Sse2.shufflelo_epi16(prod, Sse.SHUFFLE(0, 0, 3, 2))).UInt0;
            }
            else
            {
                return cprod((uint4)x.v4_0 * (uint4)x.v4_4);
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = x.v8_0;

                lo = Avx.mm256_castsi256_si128(((uint8)(ushort8)lo * (uint8)(ushort8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                                *
                                                ((uint8)x.v8_8 * (uint8)(ushort8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

                lo = Sse4_1.mullo_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse4_1.mullo_epi32(lo, Sse2.shufflelo_epi16(lo, Sse.SHUFFLE(0, 0, 3, 2))).UInt0;
            }
            else
            {
                return cprod((uint8)x.v8_0 * (uint8)x.v8_8);
            }
        }


        /// <summary>       Returns the horizontal product of components of an <see cref="int2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int2 x)
        {
            return (x * x.yy).x;
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int3 x)
        {
            return ((x * x.yyy) * x.zzz).x;
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int4 x)
        {
            x *= x.wzyx;
            x *= x.yyyy;

            return x.x;
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.int8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = Sse4_1.mullo_epi32(Avx.mm256_castsi256_si128(x),
                                             Avx2.mm256_extracti128_si256(x, 1));

                result = Sse4_1.mullo_epi32(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse4_1.mullo_epi32(result, Sse2.shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return cprod(x.v4_0 * x.v4_4);
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="uint2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint2 x)
        {
            return (x * x.yy).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint3 x)
        {
            return ((x * x.yyy) * x.zzz).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint4 x)
        {
            x *= x.wzyx;
            x *= x.yyyy;

            return x.x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.uint8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint8 x)
        {
            return (uint)cprod((int8)x);
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong2 x)
        {
            return x.x * x.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong3 x)
        {
            return (x.x * x.y) * x.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong4 x)
        {
            return (x.x * x.y) * (x.z * x.w);
        }
    }
}