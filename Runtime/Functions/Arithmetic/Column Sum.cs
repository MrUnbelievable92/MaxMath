using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal sum of components of a float8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csum(float8 x)
        {
            v128 result = Sse.add_ps(Avx.mm256_castsi256_si128(x),
                                     Avx2.mm256_extracti128_si256(x, 1));

            result = Sse.add_ps(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse.mul_ss(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 0, 0, 1))).Float0;
        }


        /// <summary>       Returns the horizontal sum of components of a byte2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte2 x)
        {
            return (uint)(x.x + x.y);
        }

        /// <summary>       Returns the horizontal sum of components of a byte3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte3 x)
        {
            return sad(x, default(byte3));
        }

        /// <summary>       Returns the horizontal sum of components of a byte4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte4 x)
        {
            return sad(x, default(byte4));
        }

        /// <summary>       Returns the horizontal sum of components of a byte8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte8 x)
        {
            return sad(x, default(byte8));
        }

        /// <summary>       Returns the horizontal sum of components of a byte16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte16 x)
        {
            return sad(x, default(byte16));
        }

        /// <summary>       Returns the horizontal sum of components of a byte32 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte32 x)
        {
            return sad(x, default(byte32));
        }


        /// <summary>       Returns the horizontal sum of components of an sbyte2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * sbyte.MinValue, 2 * sbyte.MaxValue)]
        public static int csum(sbyte2 x)
        {
            return x.x + x.y;
        }

        /// <summary>       Returns the horizontal sum of components of an sbyte3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(3 * sbyte.MinValue, 3 * sbyte.MaxValue)]
        public static int csum(sbyte3 x)
        {
            return (x.x + x.y) + x.z;
        }

        /// <summary>       Returns the horizontal sum of components of an sbyte4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(4 * sbyte.MinValue, 4 * sbyte.MaxValue)]
        public static int csum(sbyte4 x)
        {
            short4 cast = x;                                        
                                                                    
            cast += cast.zwzw;                                   
                                                                    
            return (short)Sse2.extract_epi16(cast, 0) + (short)Sse2.extract_epi16(cast, 1);
        }

        /// <summary>       Returns the horizontal sum of components of an sbyte8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(8 * sbyte.MinValue, 8 * sbyte.MaxValue)]
        public static int csum(sbyte8 x)                            
        {                                                           
            short8 cast = x;                                        
                                                                    
            cast += Sse2.unpackhi_epi64(cast, cast);            
            cast += Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 3));

            return Sse2.add_epi16(cast, Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
        }

        /// <summary>       Returns the horizontal sum of components of an sbyte16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(16 * sbyte.MinValue, 16 * sbyte.MaxValue)]
        public static int csum(sbyte16 x)
        {
            short8 cast = (short8)x.v8_0 + (short8)x.v8_8;                                                     
                                                                                 
            cast += Sse2.unpackhi_epi64(cast, cast);
            cast += Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 1, 2, 3));

            return Sse2.add_epi16(cast, Sse2.shufflelo_epi16(cast, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
        }

        /// <summary>       Returns the horizontal sum of components of an sbyte32 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(32 * sbyte.MinValue, 32 * sbyte.MaxValue)]
        public static int csum(sbyte32 x)
        {
            short16 cast = (short16)x.v16_0 + (short16)x.v16_16;
            short8 more = cast.v8_0 + cast.v8_8;

            more += Sse2.unpackhi_epi64(more, more);
            more += Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 1, 2, 3));

            return Sse2.add_epi16(more, Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 0, 0, 1))).SShort0;
        }


        /// <summary>       Returns the horizontal sum of components of a short2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * short.MinValue, 2 * short.MaxValue)]
        public static int csum(short2 x)
        {
            return x.x + x.y;
        }

        /// <summary>       Returns the horizontal sum of components of a short3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(3 * short.MinValue, 3 * short.MaxValue)]
        public static int csum(short3 x)
        {
            return (x.x + x.y) + x.z;
        }

        /// <summary>       Returns the horizontal sum of components of a short4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(4 * short.MinValue, 4 * short.MaxValue)]
        public static int csum(short4 x)
        {
            x = Sse2.add_epi32(Sse4_1.cvtepi16_epi32(x), Sse4_1.cvtepi16_epi32(x.zw));

            return Sse2.add_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }

        /// <summary>       Returns the horizontal sum of components of a short8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(8 * short.MinValue, 8 * short.MaxValue)]
        public static int csum(short8 x)
        {
            x = Sse2.add_epi32(Sse4_1.cvtepi16_epi32(x), Sse4_1.cvtepi16_epi32(x.v4_4));

            x = Sse2.add_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse2.add_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }

        /// <summary>       Returns the horizontal sum of components of a short16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(16 * short.MinValue, 16 * short.MaxValue)]
        public static int csum(short16 x)
        {
            v128 lo = x.v8_0;

            lo = Avx.mm256_castsi256_si128(((int8)(short8)lo + (int8)(short8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                            +
                                            ((int8)x.v8_8 + (int8)(short8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

            lo = Sse2.add_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse2.add_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }


        /// <summary>       Returns the horizontal sum of components of a ushort2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort2 x)
        {
            return (uint)(x.x + x.y);
        }

        /// <summary>       Returns the horizontal sum of components of a ushort3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort3 x)
        {
            return (uint)((x.x + x.y) + x.z);
        }

        /// <summary>       Returns the horizontal sum of components of a ushort4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort4 x)
        {
            x = Sse2.add_epi32(Sse4_1.cvtepu16_epi32(x), Sse4_1.cvtepu16_epi32(x.zw));

            return Sse2.add_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 0, 1))).UInt0;
        }

        /// <summary>       Returns the horizontal sum of components of a ushort8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort8 x)
        {
            x = Sse2.add_epi32(Sse4_1.cvtepu16_epi32(x), Sse4_1.cvtepu16_epi32(x.v4_4));

            x = Sse2.add_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse2.add_epi32(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 0, 1))).UInt0;
        }

        /// <summary>       Returns the horizontal sum of components of a ushort16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort16 x)
        {
            v128 lo = x.v8_0;

            lo = Avx.mm256_castsi256_si128(((uint8)(ushort8)lo + (uint8)(ushort8)Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)))
                                            +
                                            ((uint8)x.v8_8 + (uint8)(ushort8)Sse2.shuffle_epi32(x.v8_8, Sse.SHUFFLE(0, 1, 2, 3))));

            lo = Sse2.add_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse2.add_epi32(lo, Sse2.shuffle_epi32(lo, Sse.SHUFFLE(0, 0, 0, 1))).UInt0;
        }


        /// <summary>       Returns the horizontal sum of components of an int8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(int8 x)
        {
            v128 int4 = Sse2.add_epi32(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse2.add_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse2.add_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }


        /// <summary>       Returns the horizontal sum of components of a uint8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(uint8 x)
        {
            return (uint)csum((int8)x);
        }


        /// <summary>       Returns the horizontal sum of components of a long2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long2 x)
        {
            return x.x + x.y;
        }

        /// <summary>       Returns the horizontal sum of components of a long3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long3 x)
        {
            return (x.x + x.y) + x.z;
        }

        /// <summary>       Returns the horizontal sum of components of a long4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long4 x)
        {
            long2 result = Sse2.add_epi64(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            return Sse2.add_epi64(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 0, 3, 2))).SLong0;
        }


        /// <summary>       Returns the horizontal sum of components of a ulong2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong2 x)
        {
            return x.x + x.y;
        }

        /// <summary>       Returns the horizontal sum of components of a ulong3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong3 x)
        {
            return (x.x + x.y) + x.z;
        }

        /// <summary>       Returns the horizontal sum of components of a ulong4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong4 x)
        {
            ulong2 result = Sse2.add_epi64(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            return Sse2.add_epi64(result, Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 0, 3, 2))).ULong0;
        }
    }
}