using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi8(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                    v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                    v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);
    
                    return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, a)),
                                         Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(a, 4))));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 compareMask = blsi_epi8(a);
    
                    v128 first  = Sse2.and_si128(Sse2.set1_epi8(4), Sse2.cmpeq_epi8(Sse2.and_si128(compareMask, Sse2.set1_epi8(0x0F)), Sse2.setzero_si128()));
                    v128 second = Sse2.and_si128(Sse2.set1_epi8(2), Sse2.cmpeq_epi8(Sse2.and_si128(compareMask, Sse2.set1_epi8(0x33)), Sse2.setzero_si128()));
                    v128 third  = Sse2.and_si128(Sse2.set1_epi8(1), Sse2.cmpeq_epi8(Sse2.and_si128(compareMask, Sse2.set1_epi8(0x55)), Sse2.setzero_si128()));
                    
                    v128 count = Sse2.add_epi8(Sse2.add_epi8(first, second), third);
                    return Sse2.sub_epi8(count, Sse2.cmpeq_epi8(compareMask, Sse2.setzero_si128()));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 NIBBLE_MASK = new v256(0x0F0F_0F0F);
                    v256 SHUFFLE_MASK_LO = new v256(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
                                                    8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                    v256 SHUFFLE_MASK_HI = new v256(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4,
                                                    8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);
    
                    return Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(NIBBLE_MASK, a)),
                                               Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi16(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                    v128 SHUFFLE_MASK_LO = new v128(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                    v128 SHUFFLE_MASK_HI = new v128(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);
    
                    v128 tzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, a)),
                                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(a, 4))));
    
                    return Sse2.min_epu8(tzcnt_bytes, Sse2.srli_epi16(Sse2.add_epi8(tzcnt_bytes, Sse2.set1_epi8(8)), 8));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 compareMask = blsi_epi16(a);
    
                    v128 first  = Sse2.and_si128(Sse2.set1_epi16(8), Sse2.cmpeq_epi16(Sse2.and_si128(compareMask, Sse2.set1_epi16(0x00FF)), Sse2.setzero_si128()));
                    v128 second = Sse2.and_si128(Sse2.set1_epi16(4), Sse2.cmpeq_epi16(Sse2.and_si128(compareMask, Sse2.set1_epi16(0x0F0F)), Sse2.setzero_si128()));
                    v128 third  = Sse2.and_si128(Sse2.set1_epi16(2), Sse2.cmpeq_epi16(Sse2.and_si128(compareMask, Sse2.set1_epi16(0x3333)), Sse2.setzero_si128()));
                    v128 fourth = Sse2.and_si128(Sse2.set1_epi16(1), Sse2.cmpeq_epi16(Sse2.and_si128(compareMask, Sse2.set1_epi16(0x5555)), Sse2.setzero_si128()));
                    
                    v128 count = Sse2.add_epi16(Sse2.add_epi16(first, second), Sse2.add_epi16(third, fourth));
                    return Sse2.sub_epi16(count, Sse2.cmpeq_epi16(compareMask, Sse2.setzero_si128()));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 NIBBLE_MASK = new v256(0x0F0F_0F0F);
                    v256 SHUFFLE_MASK_LO = new v256(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
                                                    16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                    v256 SHUFFLE_MASK_HI = new v256(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4,
                                                    16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);
    
                    v256 tzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(NIBBLE_MASK, a)),
                                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
    
                    return Avx2.mm256_min_epu8(tzcnt_bytes, Avx2.mm256_srli_epi16(Avx2.mm256_add_epi8(tzcnt_bytes, Avx.mm256_set1_epi8(8)), 8));
                }                    
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;
                    if (elements > 2)
                    {
                        v128 loA = cvt2x2epu32_epi64(blsi_epi32(a), out v128 hiA);
                        loA = Sse2.add_epi64(loA, Sse2.set1_epi64x(4_841_369_599_423_283_200L));
                        hiA = Sse2.add_epi64(hiA, Sse2.set1_epi64x(4_841_369_599_423_283_200L));
                        loA = Sse2.sub_pd(loA, Sse2.set1_pd(LIMIT_PRECISE_U64_F64));
                        hiA = Sse2.sub_pd(hiA, Sse2.set1_pd(LIMIT_PRECISE_U64_F64));
                        result = Sse.shuffle_ps(loA, hiA, Sse.SHUFFLE(3, 1, 3, 1)); 
                    }
                    else
                    {
                        result = cvtepu32_epi64(blsi_epi32(a));
                        result = Sse2.add_epi64(result, Sse2.set1_epi64x(4_841_369_599_423_283_200L));
                        result = Sse2.sub_pd(result, Sse2.set1_pd(LIMIT_PRECISE_U64_F64));
                        result = Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 0, 3, 1)); 
                    }

                    result = Sse2.srai_epi32(result, 52 - 32);
                    result = Sse2.sub_epi32(result, Sse2.set1_epi32(1023));

                    v128 aZero = Sse2.cmpeq_epi32(a, Sse2.setzero_si128());

                    return blendv_si128(result, Sse2.set1_epi32(32), aZero);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 loA = mm256_cvt2x2epu32_epi64(mm256_blsi_epi32(a), out v256 hiA);
                    loA = Avx2.mm256_add_epi64(loA, Avx.mm256_set1_epi64x(4_841_369_599_423_283_200L));
                    hiA = Avx2.mm256_add_epi64(hiA, Avx.mm256_set1_epi64x(4_841_369_599_423_283_200L));
                    loA = Avx.mm256_sub_pd(loA, Avx.mm256_set1_pd(LIMIT_PRECISE_U64_F64));
                    hiA = Avx.mm256_sub_pd(hiA, Avx.mm256_set1_pd(LIMIT_PRECISE_U64_F64));
                    v256 result = Avx.mm256_shuffle_ps(loA, hiA, Sse.SHUFFLE(3, 1, 3, 1)); 

                    result = Avx2.mm256_srai_epi32(result, 52 - 32);
                    result = Avx2.mm256_sub_epi32(result, Avx.mm256_set1_epi32(1023));

                    v256 aZero = Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256());

                    return mm256_blendv_si256(result, Avx.mm256_set1_epi32(32), aZero);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    int lo = math.tzcnt(Sse2.cvtsi128_si64x(a));
                    int hi = math.tzcnt(Sse2.cvtsi128_si64x(Sse2.bsrli_si128(a, sizeof(long))));

                    return Sse2.unpacklo_epi64(Sse2.cvtsi64x_si128((uint)lo), Sse2.cvtsi64x_si128((uint)hi)); 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
    
                    v256 blsi = mm256_blsi_epi64(a);
    
                    v256 y = Avx2.mm256_blend_epi32(ZERO, blsi, 0b0101_0101);
                    v256 cmp = Avx2.mm256_cmpeq_epi64(y, ZERO);
    
                    v256 bits = mm256_blendv_si256(y, Avx2.mm256_srli_epi64(blsi, 32), cmp);
                    v256 offset = mm256_blendv_si256(new v256(0x03FFul), new v256(0x03DFul), cmp);
    
                    bits = Avx2.mm256_add_epi64(bits, new v256(LIMIT_PRECISE_U64_F64));
                    bits = Avx.mm256_sub_pd(bits, new v256(LIMIT_PRECISE_U64_F64));
                    bits = Avx2.mm256_sub_epi64(Avx2.mm256_srli_epi64(bits, 52), offset);
    
                    v256 aZero = Avx2.mm256_cmpeq_epi64(a, ZERO);

                    return mm256_blendv_si256(bits, new v256(64ul), aZero);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="UInt128"/>.    </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int tzcnt(UInt128 x)
        {
            if (x.lo64 == 0)
            {
                return 64 + math.tzcnt(x.hi64); 
            }
            else
            {
                return math.tzcnt(x.lo64);
            }
        }

        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="Int128"/>.    </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int tzcnt(Int128 x)
        {
            return tzcnt(x.intern);
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static byte tzcnt(byte x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 8) adds another branch (for whatever reason)

            return (x == 0) ? (byte)8 : (byte)math.tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzcnt(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte2(tzcnt(x.x), tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzcnt(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzcnt(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzcnt(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzcnt(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte16(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7), tzcnt(x.x8), tzcnt(x.x9), tzcnt(x.x10), tzcnt(x.x11), tzcnt(x.x12), tzcnt(x.x13), tzcnt(x.x14), tzcnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tzcnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi8(x);
            }
            else
            {
                return new byte32(tzcnt(x.v16_0), tzcnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static sbyte tzcnt(sbyte x)
        {
            return (sbyte)tzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzcnt(sbyte2 x)
        {
            return (sbyte2)tzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzcnt(sbyte3 x)
        {
            return (sbyte3)tzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzcnt(sbyte4 x)
        {
            return (sbyte4)tzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzcnt(sbyte8 x)
        {
            return (sbyte8)tzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzcnt(sbyte16 x)
        {
            return (sbyte16)tzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzcnt(sbyte32 x)
        {
            return (sbyte32)tzcnt((byte32)x);
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static ushort tzcnt(ushort x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 16) adds another branch (for whatever reason)

            return (x == 0) ? (ushort)16 : (ushort)math.tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzcnt(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort2(tzcnt(x.x), tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzcnt(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzcnt(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzcnt(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 tzcnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi16(x);
            }
            else
            {
                return new ushort16(tzcnt(x.v8_0), tzcnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="short"/>.    </summary>
        [return: AssumeRange(0, 16)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static short tzcnt(short x)
        {
            return (short)tzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzcnt(short2 x)
        {
            return (short2)tzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzcnt(short3 x)
        {
            return (short3)tzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzcnt(short4 x)
        {
            return (short4)tzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzcnt(short8 x)
        {
            return (short8)tzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzcnt(short16 x)
        {
            return (short16)tzcnt((ushort16)x);
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 tzcnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi32(x);
            }
            else
            {
                return new uint8((uint4)math.tzcnt(x.v4_0), (uint4)math.tzcnt(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzcnt(int8 x)
        {
            return (int8)tzcnt((uint8)x);
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzcnt(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.tzcnt_epi64(x);
            }
            else
            {
                return new ulong2((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 tzcnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi64(x);
            }
            else
            {
                return new ulong3(tzcnt(x.xy), (ulong)math.tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 tzcnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi64(x);
            }
            else
            {
                return new ulong4(tzcnt(x.xy), tzcnt(x.zw));
            }
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzcnt(long2 x)
        {
            return (long2)tzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzcnt(long3 x)
        {
            return (long3)tzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzcnt(long4 x)
        {
            return (long4)tzcnt((ulong4)x);
        }
    }
}