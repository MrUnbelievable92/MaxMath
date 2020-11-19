using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csum(float8 x)
        {
            v128 result = X86.Sse.add_ps(X86.Avx.mm256_castsi256_si128(x),
                                         X86.Avx2.mm256_extracti128_si256(x, 1));

            result = X86.Sse.add_ps(result, X86.Sse2.shuffle_epi32(result, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return result.Float0 + result.Float1;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte2 x)
        {
            return (uint)(x.x + x.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte3 x)
        {
            return sad(x, default(byte3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte4 x)
        {
            return sad(x, default(byte4));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte8 x)
        {
            return sad(x, default(byte8));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte16 x)
        {
            return sad(x, default(byte16));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte32 x)
        {
            return sad(x, default(byte32));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * sbyte.MinValue, 2 * sbyte.MaxValue)]
        public static int csum(sbyte2 x)
        {
            return x.x + x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(3 * sbyte.MinValue, 3 * sbyte.MaxValue)]
        public static int csum(sbyte3 x)
        {
            return (x.x + x.y) + x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(4 * sbyte.MinValue, 4 * sbyte.MaxValue)]
        public static int csum(sbyte4 x)
        {
            short4 cast = x;                                        
                                                                    
            cast += cast.zwzw;                                   
                                                                    
            return (short)X86.Sse2.extract_epi16(cast, 0) + (short)X86.Sse2.extract_epi16(cast, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(8 * sbyte.MinValue, 8 * sbyte.MaxValue)]
        public static int csum(sbyte8 x)                            
        {                                                           
            short8 cast = x;                                        
                                                                    
            cast += X86.Sse2.unpackhi_epi64(cast, cast);            
            cast += X86.Sse2.shufflelo_epi16(cast, X86.Sse.SHUFFLE(0, 1, 2, 3)); 

            return (short)X86.Sse2.extract_epi16(cast, 0) + (short)X86.Sse2.extract_epi16(cast, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(16 * sbyte.MinValue, 16 * sbyte.MaxValue)]
        public static int csum(sbyte16 x)
        {
            short8 cast = (short8)x.v8_0 + (short8)x.v8_8;                                                     
                                                                                 
            cast += X86.Sse2.unpackhi_epi64(cast, cast);
            cast += X86.Sse2.shufflelo_epi16(cast, X86.Sse.SHUFFLE(0, 1, 2, 3));

            return (short)X86.Sse2.extract_epi16(cast, 0) + (short)X86.Sse2.extract_epi16(cast, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(32 * sbyte.MinValue, 32 * sbyte.MaxValue)]
        public static int csum(sbyte32 x)
        {
            short16 cast = (short16)x.v16_0 + (short16)x.v16_16;
            short8 more = cast.v8_0 + cast.v8_8;

            more += X86.Sse2.unpackhi_epi64(more, more);
            more += X86.Sse2.shufflelo_epi16(more, X86.Sse.SHUFFLE(0, 1, 2, 3));

            return (short)X86.Sse2.extract_epi16(more, 0) + (short)X86.Sse2.extract_epi16(more, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * short.MinValue, 2 * short.MaxValue)]
        public static int csum(short2 x)
        {
            return x.x + x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(3 * short.MinValue, 3 * short.MaxValue)]
        public static int csum(short3 x)
        {
            return (x.x + x.y) + x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(4 * short.MinValue, 4 * short.MaxValue)]
        public static int csum(short4 x)
        {
            x = X86.Sse2.add_epi32(X86.Sse4_1.cvtepi16_epi32(x), X86.Sse4_1.cvtepi16_epi32(x.zw));

            return X86.Sse4_1.extract_epi32(x, 0) + X86.Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(8 * short.MinValue, 8 * short.MaxValue)]
        public static int csum(short8 x)
        {
            x = X86.Sse2.add_epi32(X86.Sse4_1.cvtepi16_epi32(x), X86.Sse4_1.cvtepi16_epi32(x.v4_4));

            x = X86.Sse2.add_epi32(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(x, 0) + X86.Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(16 * short.MinValue, 16 * short.MaxValue)]
        public static int csum(short16 x)
        {
            v128 lo = x.v8_0;

            lo = X86.Avx.mm256_castsi256_si128(((int8)(short8)lo + (int8)(short8)X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)))
                                               +
                                               ((int8)x.v8_8 + (int8)(short8)X86.Sse2.shuffle_epi32(x.v8_8, X86.Sse.SHUFFLE(0, 1, 2, 3))));

            lo = X86.Sse2.add_epi32(lo, X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(lo, 0) + X86.Sse4_1.extract_epi32(lo, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort2 x)
        {
            return (uint)(x.x + x.y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort3 x)
        {
            return (uint)((x.x + x.y) + x.z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort4 x)
        {
            x = X86.Sse2.add_epi32(X86.Sse4_1.cvtepu16_epi32(x), X86.Sse4_1.cvtepu16_epi32(x.zw));

            return (uint)X86.Sse4_1.extract_epi32(x, 0) + (uint)X86.Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort8 x)
        {
            x = X86.Sse2.add_epi32(X86.Sse4_1.cvtepu16_epi32(x), X86.Sse4_1.cvtepu16_epi32(x.v4_4));

            x = X86.Sse2.add_epi32(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)X86.Sse4_1.extract_epi32(x, 0) + (uint)X86.Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort16 x)
        {
            v128 lo = x.v8_0;

            lo = X86.Avx.mm256_castsi256_si128(((uint8)(ushort8)lo + (uint8)(ushort8)X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)))
                                               +
                                               ((uint8)x.v8_8 + (uint8)(ushort8)X86.Sse2.shuffle_epi32(x.v8_8, X86.Sse.SHUFFLE(0, 1, 2, 3))));

            lo = X86.Sse2.add_epi32(lo, X86.Sse2.shuffle_epi32(lo, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)X86.Sse4_1.extract_epi32(lo, 0) + (uint)X86.Sse4_1.extract_epi32(lo, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(int8 x)
        {
            v128 int4 = X86.Sse2.add_epi32(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse2.add_epi32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(int4, 0) + X86.Sse4_1.extract_epi32(int4, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(uint8 x)
        {
            return (uint)csum((int8)x);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long2 x)
        {
            return x.x + x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long3 x)
        {
            return (x.x + x.y) + x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long4 x)
        {
            long2 result = X86.Sse2.add_epi64(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            return X86.Sse4_1.extract_epi64(result, 0) + X86.Sse4_1.extract_epi64(result, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong2 x)
        {
            return x.x + x.y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong3 x)
        {
            return (x.x + x.y) + x.z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong4 x)
        {
            ulong2 result = X86.Sse2.add_epi64(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            return (ulong)(X86.Sse4_1.extract_epi64(result, 0) + X86.Sse4_1.extract_epi64(result, 1));
        }
    }
}