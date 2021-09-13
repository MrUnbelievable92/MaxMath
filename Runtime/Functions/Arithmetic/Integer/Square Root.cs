using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="UInt128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(UInt128 x)
        {
            UInt128 result = 0;
            UInt128 mask = (UInt128)1 << 126;

            int lzcntX = lzcnt(x);
            mask >>= lzcntX - (lzcntX & 1);
            if (Hint.Likely(mask > x))
            {                
                mask >>= 2;
            }

            if (Hint.Likely((mask.lo | mask.hi) != 0))
            {
                if (x >= mask)
                {
                    x -= mask;
                }

                result = mask;
                mask >>= 2;
                
                while (Hint.Likely((mask.lo | mask.hi) != 0))
                {
                    UInt128 resultShifted = result >> 1;
                    UInt128 resultAdded = result + mask;

                    if (x >= resultAdded)
                    {
                        x -= resultAdded;
                        result = resultShifted + mask;
                    }
                    else
                    {
                        result = resultShifted;
                    }

                    mask >>= 2;
                }
            }

            return result.lo;
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intsqrt(Int128 x)
        {
Assert.IsNotSmaller(x, 0);

            return (long)intsqrt((UInt128)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 15ul)]
        private static byte bytesqrt(byte x, bool unsigned)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mov = Sse2.cvtsi32_si128(x);
                v128 sqrt = Sse.rcp_ss(Sse.rsqrt_ss(Sse2.cvtepi32_ps(mov)));
                v128 toInt = Sse2.cvttps_epi32(sqrt);

                if (unsigned)
                {
                    return (byte)(Sse2.cvtsi128_si32(toInt) + tobyte(x == 225));
                }
                else
                {
                    return (byte)(Sse2.cvtsi128_si32(toInt));
                }
            }
            else
            {
                return (byte)math.sqrt(x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 byte2sqrt(v128 x, bool unsigned)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 toFloat = Sse2.cvtepi32_ps(Cast.ByteToInt(x));
                v128 sqrt = Sse.rcp_ps(Sse.rsqrt_ps(toFloat));
                v128 toInt = Sse2.cvttps_epi32(sqrt);
                v128 toByte;

                if (Ssse3.IsSsse3Supported)
                {
                    toByte = Cast.Int4ToByte4(toInt);
                }
                else
                {
                    toByte = Cast.Int2To_S_Byte2_SSE2(toInt);
                }

                if (unsigned)
                {
                    toByte = Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte2(225))); 
                }

                return toByte;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 byte3sqrt(v128 x, bool unsigned)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 toFloat = Sse2.cvtepi32_ps(Cast.ByteToInt(x));
                v128 sqrt = Sse.rcp_ps(Sse.rsqrt_ps(toFloat));
                v128 toInt = Sse2.cvttps_epi32(sqrt);
                v128 toByte = Cast.Int4ToByte4(toInt);
                
                if (unsigned)
                {
                    toByte = Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte4(225))); 
                }

                return toByte;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 byte4sqrt(v128 x, bool unsigned)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 toFloat = Sse2.cvtepi32_ps(Cast.ByteToInt(x));
                v128 sqrt = Sse.rcp_ps(Sse.rsqrt_ps(toFloat));
                v128 toInt = Sse2.cvttps_epi32(sqrt);
                v128 toByte = Cast.Int4ToByte4(toInt);
                
                if (unsigned)
                {
                    toByte = Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte4(225))); 
                }

                return toByte;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 byte8sqrt(v128 x, bool unsigned)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 toFloat = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(x));
                v256 sqrt = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat));
                v256 toInt = Avx.mm256_cvttps_epi32(sqrt);
                v128 shorts = Sse2.packs_epi32(Avx.mm256_castsi256_si128(toInt), Avx2.mm256_extracti128_si256(toInt, 1));
                v128 toByte = Sse2.packus_epi16(shorts, shorts);
                
                if (unsigned)
                {
                    toByte = Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte8(225))); 
                }

                return toByte;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 toFloat_lo = Sse2.cvtepi32_ps(Cast.ByteToInt(x));
                v128 toFloat_hi = Sse2.cvtepi32_ps(Cast.ByteToInt(Sse2.bsrli_si128(x, 4 * sizeof(byte))));
                v128 sqrt_lo = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_lo));
                v128 sqrt_hi = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_hi));
                v128 toInt_lo = Sse2.cvttps_epi32(sqrt_lo);
                v128 toInt_hi = Sse2.cvttps_epi32(sqrt_hi);
                v128 shorts = Sse2.packs_epi32(toInt_lo, toInt_hi);
                v128 toByte = Sse2.packus_epi16(shorts, shorts);
                
                if (unsigned)
                {
                    toByte = Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte8(225))); 
                }

                return toByte;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 byte16sqrt(v128 x, bool unsigned)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 toFloat_lo = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(x));
                v256 toFloat_hi = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(x, 8 * sizeof(byte))));
                v256 sqrt_lo = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat_lo));
                v256 sqrt_hi = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat_hi));
                v256 toInt_lo = Avx.mm256_cvttps_epi32(sqrt_lo);
                v256 toInt_hi = Avx.mm256_cvttps_epi32(sqrt_hi);
                v256 shorts = Avx2.mm256_packs_epi32(toInt_lo, toInt_hi);
                v128 toByte = Sse2.packus_epi16(Avx.mm256_castsi256_si128(shorts), Avx2.mm256_extracti128_si256(shorts, 1));
                toByte = Sse2.shuffle_epi32(toByte, Sse.SHUFFLE(3, 1, 2, 0)); 

                return Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte16(225)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 toFloat_0 = Sse2.cvtepi32_ps(Cast.ByteToInt(x));
                v128 toFloat_1 = Sse2.cvtepi32_ps(Cast.ByteToInt(Sse2.bsrli_si128(x, 4  * sizeof(byte))));
                v128 toFloat_2 = Sse2.cvtepi32_ps(Cast.ByteToInt(Sse2.bsrli_si128(x, 8  * sizeof(byte))));
                v128 toFloat_3 = Sse2.cvtepi32_ps(Cast.ByteToInt(Sse2.bsrli_si128(x, 12 * sizeof(byte))));
                v128 sqrt_0 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_0));
                v128 sqrt_1 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_1));
                v128 sqrt_2 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_2));
                v128 sqrt_3 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_3));
                v128 toInt_0 = Sse2.cvttps_epi32(sqrt_0);
                v128 toInt_1 = Sse2.cvttps_epi32(sqrt_1);
                v128 toInt_2 = Sse2.cvttps_epi32(sqrt_2);
                v128 toInt_3 = Sse2.cvttps_epi32(sqrt_3);
                v128 shorts_lo = Sse2.packs_epi32(toInt_0, toInt_1);
                v128 shorts_hi = Sse2.packs_epi32(toInt_2, toInt_3);
                v128 toByte = Sse2.packus_epi16(shorts_lo, shorts_hi);
                
                if (unsigned)
                {
                    toByte = Sse2.sub_epi8(toByte, Sse2.cmpeq_epi8(x, new byte16(225))); 
                }

                return toByte;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 byte32sqrt(v256 x, bool unsigned)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 hi = Avx2.mm256_extracti128_si256(x, 1);

                v256 toFloat_lo = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(Avx.mm256_castsi256_si128(x)));
                v256 toFloat_hi = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(x), 8 * sizeof(byte))));
                v256 toFloat_lo2 = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(hi));
                v256 toFloat_hi2 = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(hi, 8 * sizeof(byte))));

                v256 sqrt_lo = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat_lo));
                v256 sqrt_hi = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat_hi));
                v256 sqrt_lo2 = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat_lo2));
                v256 sqrt_hi2 = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(toFloat_hi2));

                v256 toInt_lo = Avx.mm256_cvttps_epi32(sqrt_lo);
                v256 toInt_hi = Avx.mm256_cvttps_epi32(sqrt_hi);
                v256 toInt_lo2 = Avx.mm256_cvttps_epi32(sqrt_lo2);
                v256 toInt_hi2 = Avx.mm256_cvttps_epi32(sqrt_hi2);

                v256 shorts_lo = Avx2.mm256_packs_epi32(toInt_lo, toInt_hi);
                v256 shorts_hi = Avx2.mm256_packs_epi32(toInt_lo2, toInt_hi2);
                v256 toByte = Avx2.mm256_packus_epi16(shorts_lo, shorts_hi);
                toByte = Avx2.mm256_permutevar8x32_epi32(toByte, new v256(0, 4, 1, 5, 2, 6, 3, 7));

                if (unsigned)
                {
                    toByte = Avx2.mm256_sub_epi8(toByte, Avx2.mm256_cmpeq_epi8(x, Avx.mm256_set1_epi8(225)));
                }

                return toByte;
            }
            else throw new CPUFeatureCheckException();
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 15ul)]
        public static byte intsqrt(byte x)
        {
            return bytesqrt(x, unsigned: true);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intsqrt(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return byte2sqrt(x, unsigned: true);
            }
            else
            {
                return (byte2)math.sqrt(x);
            }
        } 

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intsqrt(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return byte3sqrt(x, unsigned: true);
            }
            else
            {
                return (byte3)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intsqrt(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return byte4sqrt(x, unsigned: true);
            }
            else
            {
                return (byte4)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intsqrt(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return byte8sqrt(x, unsigned: true);
            }
            else
            {
                return (byte8)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intsqrt(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return byte16sqrt(x, unsigned: true);
            }
            else
            {
                return new byte16((byte8)sqrt(x.v8_0), (byte8)sqrt(x.v8_8));  
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intsqrt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return byte32sqrt(x, unsigned: true);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new byte32(byte16sqrt(x.v16_0, unsigned: true), byte16sqrt(x.v16_16, unsigned: true));
            }
            else
            {
                return new byte32((byte8)sqrt(x.v8_0), (byte8)sqrt(x.v8_8), (byte8)sqrt(x.v8_16), (byte8)sqrt(x.v8_24));  
            }
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 11)]
        public static sbyte intsqrt(sbyte x)
        {
Assert.IsNonNegative(x);
            
            return (sbyte)bytesqrt((byte)x, unsigned: false);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intsqrt(sbyte2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
            
            if (Sse2.IsSse2Supported)
            {
                return byte2sqrt(x, unsigned: false);
            }
            else
            {
                return (sbyte2)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intsqrt(sbyte3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
            
            if (Sse2.IsSse2Supported)
            {
                return byte3sqrt(x, unsigned: false);
            }
            else
            {
                return (sbyte3)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intsqrt(sbyte4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);
            
            if (Sse2.IsSse2Supported)
            {
                return byte4sqrt(x, unsigned: false);
            }
            else
            {
                return (sbyte4)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intsqrt(sbyte8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
            
            if (Sse2.IsSse2Supported)
            {
                return byte8sqrt(x, unsigned: false);
            }
            else
            {
                return (sbyte8)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intsqrt(sbyte16 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);
            
            if (Sse2.IsSse2Supported)
            {
                return byte16sqrt(x, unsigned: false);
            }
            else
            {
                return new sbyte16((sbyte8)sqrt(x.v8_0), (sbyte8)sqrt(x.v8_8));  
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intsqrt(sbyte32 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);
Assert.IsNonNegative(x.x16);
Assert.IsNonNegative(x.x17);
Assert.IsNonNegative(x.x18);
Assert.IsNonNegative(x.x19);
Assert.IsNonNegative(x.x20);
Assert.IsNonNegative(x.x21);
Assert.IsNonNegative(x.x22);
Assert.IsNonNegative(x.x23);
Assert.IsNonNegative(x.x24);
Assert.IsNonNegative(x.x25);
Assert.IsNonNegative(x.x26);
Assert.IsNonNegative(x.x27);
Assert.IsNonNegative(x.x28);
Assert.IsNonNegative(x.x29);
Assert.IsNonNegative(x.x30);
Assert.IsNonNegative(x.x31);
            
            if (Avx2.IsAvx2Supported)
            {
                return byte32sqrt(x, unsigned: false);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new sbyte32(byte16sqrt(x.v16_0, unsigned: false), byte16sqrt(x.v16_16, unsigned: false));
            }
            else
            {
                return new sbyte32((sbyte8)sqrt(x.v8_0), (sbyte8)sqrt(x.v8_8), (sbyte8)sqrt(x.v8_16), (sbyte8)sqrt(x.v8_24));  
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, (ulong)byte.MaxValue)]
        public static ushort intsqrt(ushort x)
        {
            return (ushort)math.sqrt(x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intsqrt(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 sqrt = Sse.sqrt_ps(Sse2.cvtepi32_ps(Cast.UShortToInt(x)));
                v128 ints = Sse2.cvttps_epi32(sqrt);

                return Sse2.packs_epi32(ints, ints);
            }
            else
            {
                return (ushort2)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intsqrt(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 sqrt = Sse.sqrt_ps(Sse2.cvtepi32_ps(Cast.UShortToInt(x)));
                v128 ints = Sse2.cvttps_epi32(sqrt);

                return Sse2.packs_epi32(ints, ints);
            }
            else
            {
                return (ushort3)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intsqrt(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 sqrt = Sse.sqrt_ps(Sse2.cvtepi32_ps(Cast.UShortToInt(x)));
                v128 ints = Sse2.cvttps_epi32(sqrt);

                return Sse2.packs_epi32(ints, ints);
            }
            else
            {
                return (ushort4)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intsqrt(ushort8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 sqrt = Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu16_epi32(x)));
                v256 ints = Avx.mm256_cvttps_epi32(sqrt);

                return Sse4_1.packus_epi32(Avx.mm256_castsi256_si128(ints), Avx2.mm256_extracti128_si256(ints, 1));
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 sqrt_lo = Sse.sqrt_ps(Sse2.cvtepi32_ps(Sse4_1.cvtepu16_epi32(x)));
                v128 sqrt_hi = Sse.sqrt_ps(Sse2.cvtepi32_ps(Sse4_1.cvtepu16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(ushort)))));
                v128 ints_lo = Sse2.cvttps_epi32(sqrt_lo);
                v128 ints_hi = Sse2.cvttps_epi32(sqrt_hi);
                
                return Sse4_1.packus_epi32(ints_lo, ints_hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();

                v128 sqrt_lo = Sse.sqrt_ps(Sse2.cvtepi32_ps(Sse2.unpacklo_epi16(x, ZERO)));
                v128 sqrt_hi = Sse.sqrt_ps(Sse2.cvtepi32_ps(Sse2.unpackhi_epi16(x, ZERO)));
                v128 ints_lo = Sse2.cvttps_epi32(sqrt_lo);
                v128 ints_hi = Sse2.cvttps_epi32(sqrt_hi);

                return Sse2.packs_epi32(ints_lo, ints_hi);
            }
            else
            {
                return (ushort8)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intsqrt(ushort16 x)
        {
            return new ushort16(intsqrt(x.v8_0), intsqrt(x.v8_8));
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 181)]
        public static short intsqrt(short x)
        {
Assert.IsNonNegative(x);

            return (short)intsqrt((ushort)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intsqrt(short2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (short2)intsqrt((ushort2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intsqrt(short3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (short3)intsqrt((ushort3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intsqrt(short4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (short4)intsqrt((ushort4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intsqrt(short8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);

            return (short8)intsqrt((ushort8)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intsqrt(short16 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);

            return (short16)intsqrt((ushort16)x);
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, (ulong)ushort.MaxValue)]
        public static uint intsqrt(uint x)
        {
            return (uint)math.sqrt((double)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intsqrt(uint2 x)
        {
            return (uint2)math.sqrt((double2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intsqrt(uint3 x)
        {
            return (uint3)math.sqrt((double3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intsqrt(uint4 x)
        {
            return (uint4)math.sqrt((double4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intsqrt(uint8 x)
        {
            return new uint8(intsqrt(x.v4_0), intsqrt(x.v4_4));
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 46_340)]
        public static int intsqrt(int x)
        {
Assert.IsNonNegative(x);

            return (int)intsqrt((uint)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intsqrt(int2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (int2)intsqrt((uint2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intsqrt(int3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (int3)intsqrt((uint3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intsqrt(int4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (int4)intsqrt((uint4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intsqrt(int8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);

            return (int8)intsqrt((uint8)x);
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ulong"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, (ulong)uint.MaxValue)]
        public static ulong intsqrt(ulong x)
        {
            ulong result = 0;
            ulong mask = 1ul << 62;

            int lzcntX = math.lzcnt(x);
            mask >>= lzcntX - (lzcntX & 1);
            if (Hint.Likely(mask > x))
            {                
                mask >>= 2;
            }

            if (Hint.Likely(mask != 0))
            {
                if (x >= mask)
                {
                    x -= mask;
                }

                result = mask;
                mask >>= 2;
                
                while (Hint.Likely(mask != 0))
                {
                    ulong resultShifted = result >> 1;
                    ulong resultAdded = result + mask;

                    if (x >= resultAdded)
                    {
                        x -= resultAdded;
                        result = resultShifted + mask;
                    }
                    else
                    {
                        result = resultShifted;
                    }

                    mask >>= 2;
                }
            }

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intsqrt(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 result = ZERO;
                v128 mask = new v128(1ul << 62);
                v128 doneMask;
                

                v128 lzcntX = lzcnt(x);
                v128 shiftMask = Sse2.sub_epi64(ZERO, ALL_ONES);
                mask = shrl(mask, (ulong2)Sse2.sub_epi64(lzcntX, Sse2.and_si128(lzcntX, shiftMask)));
                shiftMask = Sse2.add_epi64(shiftMask, shiftMask);
                mask = shrl(mask, (ulong2)Sse2.and_si128(Operator.greater_mask_ulong(mask, x), shiftMask));

                doneMask = Operator.equals_mask_long(mask, ZERO);

                if (Hint.Likely(bitmask32(2 * sizeof(ulong)) != Sse2.movemask_epi8(doneMask)))
                {
                    v128 subFromX = Sse2.andnot_si128(Operator.greater_mask_ulong(mask, x), mask);
                    x = Sse2.sub_epi64(x, subFromX);
                    
                    result = mask;
                    mask = Sse2.srli_epi64(mask, 2);

                    doneMask = Operator.equals_mask_long(mask, ZERO);
                    
                    while (Hint.Likely(bitmask32(2 * sizeof(ulong)) != Sse2.movemask_epi8(doneMask)))
                    {
                        v128 result_shifted = Sse2.srli_epi64(result, 1);
                        v128 result_added = Sse2.add_epi64(result, mask);
                        v128 blendMask = Operator.greater_mask_ulong(result_added, x);
                    
                        x = Sse2.sub_epi64(x, Sse2.andnot_si128(blendMask, result_added));
                        result = Sse2.add_epi64(Mask.BlendV(result_shifted, result, doneMask), 
                                                Sse2.and_si128(mask, Sse2.andnot_si128(doneMask, Sse2.xor_si128(ALL_ONES, blendMask))));
                    
                        mask = Sse2.srli_epi64(mask, 2);
                    
                        doneMask = Operator.equals_mask_long(mask, ZERO);
                    }
                }


                return result;
            }
            else
            {
                return new ulong2(intsqrt(x.x), intsqrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intsqrt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 result = ZERO;
                v256 mask = new v256(1ul << 62);
                v256 doneMask;
                

                v256 lzcntX = lzcnt(x);
                v256 shiftMask = Avx2.mm256_sub_epi64(ZERO, ALL_ONES);
                mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_sub_epi64(lzcntX, Avx2.mm256_and_si256(lzcntX, shiftMask)));
                shiftMask = Avx2.mm256_add_epi64(shiftMask, shiftMask);
                mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_and_si256(Operator.greater_mask_ulong(mask, x), shiftMask));

                doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);

                if (Hint.Likely(bitmask32(3 * sizeof(ulong)) != (bitmask32(3 * sizeof(ulong)) & Avx2.mm256_movemask_epi8(doneMask))))
                {
                    v256 subFromX = Avx2.mm256_andnot_si256(Operator.greater_mask_ulong(mask, x), mask);
                    x = Avx2.mm256_sub_epi64(x, subFromX);
                    
                    result = mask;
                    mask = Avx2.mm256_srli_epi64(mask, 2);

                    doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                    
                    while (Hint.Likely(bitmask32(3 * sizeof(ulong)) != (bitmask32(3 * sizeof(ulong)) & Avx2.mm256_movemask_epi8(doneMask))))
                    {
                        v256 result_shifted = Avx2.mm256_srli_epi64(result, 1);
                        v256 result_added = Avx2.mm256_add_epi64(result, mask);
                        v256 blendMask = Operator.greater_mask_ulong(result_added, x);
                    
                        x = Avx2.mm256_sub_epi64(x, Avx2.mm256_andnot_si256(blendMask, result_added));
                        result = Avx2.mm256_add_epi64(Avx2.mm256_blendv_epi8(result_shifted, result, doneMask), 
                                                Avx2.mm256_and_si256(mask, Avx2.mm256_andnot_si256(doneMask, Avx2.mm256_xor_si256(ALL_ONES, blendMask))));
                    
                        mask = Avx2.mm256_srli_epi64(mask, 2);
                    
                        doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                    }
                }


                return result;
            }
            else
            {
                return new ulong3(intsqrt(x.xy), intsqrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intsqrt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 result = ZERO;
                v256 mask = new v256(1ul << 62);
                v256 doneMask;

                
                v256 lzcntX = lzcnt(x);
                v256 shiftMask = Avx2.mm256_sub_epi64(ZERO, ALL_ONES);
                mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_sub_epi64(lzcntX, Avx2.mm256_and_si256(lzcntX, shiftMask)));
                shiftMask = Avx2.mm256_add_epi64(shiftMask, shiftMask);
                mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_and_si256(Operator.greater_mask_ulong(mask, x), shiftMask));

                doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);

                if (Hint.Likely(-1 != Avx2.mm256_movemask_epi8(doneMask)))
                {
                    v256 subFromX = Avx2.mm256_andnot_si256(Operator.greater_mask_ulong(mask, x), mask);
                    x = Avx2.mm256_sub_epi64(x, subFromX);
                    
                    result = mask;
                    mask = Avx2.mm256_srli_epi64(mask, 2);

                    doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                    
                    while (Hint.Likely(-1 != Avx2.mm256_movemask_epi8(doneMask)))
                    {
                        v256 result_shifted = Avx2.mm256_srli_epi64(result, 1);
                        v256 result_added = Avx2.mm256_add_epi64(result, mask);
                        v256 blendMask = Operator.greater_mask_ulong(result_added, x);

                        x = Avx2.mm256_sub_epi64(x, Avx2.mm256_andnot_si256(blendMask, result_added));
                        result = Avx2.mm256_add_epi64(Avx2.mm256_blendv_epi8(result_shifted, result, doneMask), 
                                                      Avx2.mm256_and_si256(mask, Avx2.mm256_andnot_si256(doneMask, Avx2.mm256_xor_si256(ALL_ONES, blendMask))));
                    
                        mask = Avx2.mm256_srli_epi64(mask, 2);
                    
                        doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                    }
                }


                return result;
            }
            else
            {
                return new ulong4(intsqrt(x.xy), intsqrt(x.zw));
            }
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="long"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 3_037_000_499)]
        public static long intsqrt(long x)
        {
Assert.IsNonNegative(x);

            return (long)intsqrt((ulong)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intsqrt(long2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (long2)intsqrt((ulong2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intsqrt(long3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (long3)intsqrt((ulong3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intsqrt(long4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (long4)intsqrt((ulong4)x);
        }
    }
}