using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csum(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Sse.add_ps(Avx.mm256_castps256_ps128(x),
                                         Avx.mm256_extractf128_ps(x, 1));

                result = Sse.add_ps(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse.add_ss(result, Sse2.shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 3, 2))).Float0;
            }
            else
            {
                return math.csum(x.v4_0 + x.v4_4);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * byte.MaxValue)]
        public static uint csum(byte2 x)
        {
            return (uint)x.x + (uint)x.y;
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * byte.MaxValue)]
        public static uint csum(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return sad(x, Sse2.setzero_si128());
            }
            else
            {
                return (uint)(x.x + x.y + x.z);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 4ul * byte.MaxValue)]
        public static uint csum(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return sad(x, Sse2.setzero_si128());
            }
            else
            {
                return (uint)((x.x + x.y) + (x.z + x.w));
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul * byte.MaxValue)]
        public static uint csum(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return sad(x, Sse2.setzero_si128());
            }
            else
            {
                return (uint)(((x.x0 + x.x1) + (x.x2 + x.x3)) + ((x.x4 + x.x5) + (x.x6 + x.x7)));
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul * byte.MaxValue)]
        public static uint csum(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return sad(x, Sse2.setzero_si128());
            }
            else
            {
                return (uint)((((x.x0 + x.x1) + (x.x2 + x.x3)) + ((x.x4 + x.x5) + (x.x6 + x.x7))) + (((x.x8 + x.x9) + (x.x10 + x.x11)) + ((x.x12 + x.x13) + (x.x14 + x.x15))));
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 32ul * byte.MaxValue)]
        public static uint csum(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return sad(x, Avx.mm256_setzero_si256());
            }
            else
            {
                return csum(x.v16_0) + csum(x.v16_16);
            }
        }


        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * sbyte.MinValue, 2 * sbyte.MaxValue)]
        public static int csum(sbyte2 x)
        {
            return x.x + x.y;
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(3 * sbyte.MinValue, 3 * sbyte.MaxValue)]
        public static int csum(sbyte3 x)
        {
            return (x.x + x.y) + x.z;
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(4 * sbyte.MinValue, 4 * sbyte.MaxValue)]
        public static int csum(sbyte4 x)
        {
            short4 cast = x;

            cast += cast.zwzw;
            cast += cast.yyyy;

            return cast.x;
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(8 * sbyte.MinValue, 8 * sbyte.MaxValue)]
        public static int csum(sbyte8 x)                            
        {       
            if (Sse2.IsSse2Supported)
            {
                short8 cast = x;

                cast += Sse2.unpackhi_epi64(cast, cast);
                cast += Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 3));

                return Sse2.add_epi16(cast, Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
            }
            else
            {
                return ((x.x0 + x.x1) + (x.x2 + x.x3)) + ((x.x4 + x.x5) + (x.x6 + x.x7));
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(16 * sbyte.MinValue, 16 * sbyte.MaxValue)]
        public static int csum(sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                short8 cast = (short8)x.v8_0 + (short8)x.v8_8;

                cast += Sse2.unpackhi_epi64(cast, cast);
                cast += Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 3));

                return Sse2.add_epi16(cast, Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
            }
            else
            {
                return (((x.x0 + x.x1) + (x.x2 + x.x3)) + ((x.x4 + x.x5) + (x.x6 + x.x7))) + (((x.x8 + x.x9) + (x.x10 + x.x11)) + ((x.x12 + x.x13) + (x.x14 + x.x15)));
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(32 * sbyte.MinValue, 32 * sbyte.MaxValue)]
        public static int csum(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                short16 cast = (short16)x.v16_0 + (short16)x.v16_16;
                short8 more = cast.v8_0 + cast.v8_8;

                more += Sse2.unpackhi_epi64(more, more);
                more += Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 1, 2, 3));

                return Sse2.add_epi16(more, Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
            }
            else if (Sse2.IsSse2Supported)
            {
                short8 cast = ((short8)x.v8_0 + (short8)x.v8_8) + ((short8)x.v8_16 + (short8)x.v8_24);

                cast += Sse2.unpackhi_epi64(cast, cast);
                cast += Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 3));

                return Sse2.add_epi16(cast, Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
            }
            else
            {
                return ((((x.x0 + x.x1) + (x.x2 + x.x3)) + ((x.x4 + x.x5) + (x.x6 + x.x7))) + (((x.x8 + x.x9) + (x.x10 + x.x11)) + ((x.x12 + x.x13) + (x.x14 + x.x15)))) + ((((x.x16 + x.x17) + (x.x18 + x.x19)) + ((x.x20 + x.x21) + (x.x22 + x.x23))) + (((x.x24 + x.x25) + (x.x26 + x.x27)) + ((x.x28 + x.x29) + (x.x30 + x.x31))));
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * short.MinValue, 2 * short.MaxValue)]
        public static int csum(short2 x)
        {
            return math.csum((int2)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(3 * short.MinValue, 3 * short.MaxValue)]
        public static int csum(short3 x)
        {
            return math.csum((int3)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(4 * short.MinValue, 4 * short.MaxValue)]
        public static int csum(short4 x)
        {
            return math.csum((int4)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(8 * short.MinValue, 8 * short.MaxValue)]
        public static int csum(short8 x)
        {
            return math.csum((int4)x.v4_0 + (int4)x.v4_4);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(16 * short.MinValue, 16 * short.MaxValue)]
        public static int csum(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = x.v8_0;

                lo = Avx.mm256_castsi256_si128(((int8)(short8)lo + (int8)(short8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                                +
                                                ((int8)x.v8_8 + (int8)(short8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

                lo = Sse2.add_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse2.add_epi32(lo, Sse2.shufflelo_epi16(lo, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return math.csum(((int4)x.v4_0 + (int4)x.v4_4) + ((int4)x.v4_8 + (int4)x.v4_12));
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * ushort.MaxValue)]
        public static uint csum(ushort2 x)
        {
            return math.csum((uint2)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * ushort.MaxValue)]
        public static uint csum(ushort3 x)
        {
            return math.csum((uint3)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 4ul * ushort.MaxValue)]
        public static uint csum(ushort4 x)
        {
            return math.csum((uint4)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul * ushort.MaxValue)]
        public static uint csum(ushort8 x)
        {
            return math.csum((uint4)x.v4_0 + (uint4)x.v4_4);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul * ushort.MaxValue)]
        public static uint csum(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = x.v8_0;

                lo = Avx.mm256_castsi256_si128(((uint8)(ushort8)lo + (uint8)(ushort8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                                +
                                                ((uint8)x.v8_8 + (uint8)(ushort8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

                lo = Sse2.add_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse2.add_epi32(lo, Sse2.shufflelo_epi16(lo, Sse.SHUFFLE(0, 0, 3, 2))).UInt0;
            }
            else
            {
                return math.csum(((uint4)x.v4_0 + (uint4)x.v4_4) + ((uint4)x.v4_8 + (uint4)x.v4_12));
            }
        }


        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.int8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 int4 = Sse2.add_epi32(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

                int4 = Sse2.add_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse2.add_epi32(int4, Sse2.shufflelo_epi16(int4, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return math.csum(x.v4_0 + x.v4_4);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.uint8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(uint8 x)
        {
            return (uint)csum((int8)x);
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi64(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 3, 2))).SLong0;
            }
            else
            {
                return x.x + x.y;
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                long2 result = Sse2.add_epi64(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

                return Sse2.add_epi64(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 0, 3, 2))).SLong0;
            }
            else
            {
                return x.x + x.y + x.z;
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return csum(x.xy + x.zw);
            }
            else
            {
                return (x.x + x.y) + (x.z + x.w);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong2 x)
        {
            return (ulong)csum((long2)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong3 x)
        {
            return (ulong)csum((long3)x);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong4 x)
        {
            return (ulong)csum((long4)x);
        }
    }
}