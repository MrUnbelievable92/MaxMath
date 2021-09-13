using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="UInt128.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 mulsaturated(UInt128 x, UInt128 y)
        {
            UInt128 product = Operator.umul256(x, y, out UInt128 hi);

            return select(product, UInt128.MaxValue, hi != 0);
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="Int128.MaxValue"/> if overflow occurs or <see cref="Int128.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 mulsaturated(Int128 x, Int128 y)
        {
            //static long Positive(Int128 x, Int128 y)
            //{
            //    UInt128 lo = Operator.umul256(x.intern, y.intern, out Uint128 hi);
            //
            //    return ((hi.lo | hi.hi | (lo.hi >> 63)) == 0) ? (Int128)lo : long.MaxValue;
            //}
            //
            //static long Negative(Int128 x, Int128 y)
            //{
            //    UInt128 lo = Operator.umul256(x.intern, y.intern, out Uint128 hi);
            //
            //    return ((hi.lo | hi.hi | (lo.hi >> 63)) == 0) ? -(Int128)lo : long.MinValue;
            //}
            //
            //
            //if (x < 0)
            //{
            //    x = -x;
            //
            //    if (y < 0)
            //    {
            //        y = -y;
            //
            //        return Positive(x, y);
            //    }
            //    else
            //    {
            //        return Negative(x, y);
            //    }
            //}
            //else if (y < 0)
            //{
            //    y = -y;
            //    
            //    return Negative(x, y);
            //}
            //else
            //{
            //    return Positive(x, y);
            //}

            
            ulong xNegative = x.intern.hi >> 63;
            ulong yNegative = y.intern.hi >> 63;
            Int128 xNegativeMinus = x >> 127;
            Int128 yNegativeMinus = y >> 127;
            
            x = (x ^ xNegativeMinus) + xNegative;
            y = (y ^ yNegativeMinus) + yNegative;

            UInt128 lo = Operator.umul256(x.intern, y.intern, out UInt128 hi);

            return ((hi.lo | hi.hi | (lo.hi >> 63)) == 0) ? (Int128)lo : (xNegativeMinus ^ yNegativeMinus) ^ Int128.MaxValue;
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte mulsaturated(byte x, byte y)
        {
            return (byte)math.min(byte.MaxValue, x * y);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mulsaturated(byte2 x, byte2 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 product = Sse4_1.mullo_epi32(Sse4_1.cvtepu8_epi32(x), Sse4_1.cvtepu8_epi32(y));
                
                v128 shorts = Sse2.packs_epi32(product, product);

                return Sse2.packus_epi16(shorts, shorts);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi16(Sse2.cmpeq_epi32(default(v128), default(v128)), 1);

                v128 product = Sse2.mullo_epi16(Cast.ByteToShort(x), Cast.ByteToShort(y));
                v128 overflow16 = Sse2.srai_epi16(product, 15);
                product = Mask.BlendV(product, MAX_VALUE, overflow16);
                
                return Sse2.packus_epi16(product, product);
            }
            else
            {
                return new byte2(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mulsaturated(byte3 x, byte3 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 product = Sse4_1.mullo_epi32(Sse4_1.cvtepu8_epi32(x), Sse4_1.cvtepu8_epi32(y));
                
                v128 shorts = Sse2.packs_epi32(product, product);

                return Sse2.packus_epi16(shorts, shorts);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi16(Sse2.cmpeq_epi32(default(v128), default(v128)), 1);

                v128 product = Sse2.mullo_epi16(Cast.ByteToShort(x), Cast.ByteToShort(y));
                v128 overflow16 = Sse2.srai_epi16(product, 15);
                product = Mask.BlendV(product, MAX_VALUE, overflow16);

                return Sse2.packus_epi16(product, product);
            }
            else
            {
                return new byte3(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y), 
                                 mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mulsaturated(byte4 x, byte4 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 product = Sse4_1.mullo_epi32(Sse4_1.cvtepu8_epi32(x), Sse4_1.cvtepu8_epi32(y));
                
                v128 shorts = Sse2.packs_epi32(product, product);

                return Sse2.packus_epi16(shorts, shorts);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi16(Sse2.cmpeq_epi32(default(v128), default(v128)), 1);

                v128 product = Sse2.mullo_epi16(Cast.ByteToShort(x), Cast.ByteToShort(y));
                v128 overflow16 = Sse2.srai_epi16(product, 15);
                product = Mask.BlendV(product, MAX_VALUE, overflow16);

                return Sse2.packus_epi16(product, product);
            }
            else
            {
                return new byte4(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y), 
                                 mulsaturated(x.z, y.z), 
                                 mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 mulsaturated(byte8 x, byte8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 product = Avx2.mm256_mullo_epi32(Avx2.mm256_cvtepu8_epi32(x), Avx2.mm256_cvtepu8_epi32(y));
                
                v256 shorts = Avx2.mm256_packs_epi32(product, product);
                v128 orderedShorts = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(shorts, Sse.SHUFFLE(0, 0, 2, 0))); 
                v128 bytes = Sse2.packus_epi16(orderedShorts, orderedShorts);
                
                return bytes;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi16(Sse2.cmpeq_epi32(default(v128), default(v128)), 1);

                v128 product = Sse2.mullo_epi16(Cast.ByteToShort(x), Cast.ByteToShort(y));
                v128 overflow16 = Sse2.srai_epi16(product, 15);
                product = Mask.BlendV(product, MAX_VALUE, overflow16);

                return Sse2.packus_epi16(product, product);
            }
            else
            {
                return new byte8(mulsaturated(x.x0, y.x0), 
                                 mulsaturated(x.x1, y.x1), 
                                 mulsaturated(x.x2, y.x2), 
                                 mulsaturated(x.x3, y.x3), 
                                 mulsaturated(x.x4, y.x4), 
                                 mulsaturated(x.x5, y.x5), 
                                 mulsaturated(x.x6, y.x6), 
                                 mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 mulsaturated(byte16 x, byte16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_VALUE = Avx2.mm256_srli_epi16(Avx2.mm256_cmpeq_epi32(default(v256), default(v256)), 1);

                v256 product = Avx2.mm256_mullo_epi16(Avx2.mm256_cvtepu8_epi16(x), Avx2.mm256_cvtepu8_epi16(y));
                v256 overflow16 = Avx2.mm256_srai_epi16(product, 15);
                product = Avx2.mm256_blendv_epi8(product, MAX_VALUE, overflow16);

                v256 bytes = Avx2.mm256_packus_epi16(product, product);
                v256 ordered = Avx2.mm256_permute4x64_epi64(bytes, Sse.SHUFFLE(0, 0, 2, 0));

                return Avx.mm256_castsi256_si128(ordered);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 MAX_VALUE = Sse2.srli_epi16(Sse2.cmpeq_epi32(default(v128), default(v128)), 1);

                v128 product_lo = Sse2.mullo_epi16(Sse2.unpacklo_epi8(x, ZERO), Sse2.unpacklo_epi8(y, ZERO));
                v128 product_hi = Sse2.mullo_epi16(Sse2.unpackhi_epi8(x, ZERO), Sse2.unpackhi_epi8(y, ZERO));
                v128 overflow16_lo = Sse2.srai_epi16(product_lo, 15);
                v128 overflow16_hi = Sse2.srai_epi16(product_hi, 15);
                product_lo = Mask.BlendV(product_lo, MAX_VALUE, overflow16_lo);
                product_hi = Mask.BlendV(product_hi, MAX_VALUE, overflow16_hi);

                return Sse2.packus_epi16(product_lo, product_hi);
            }
            else
            {
                return new byte16(mulsaturated(x.x0,  y.x0), 
                                  mulsaturated(x.x1,  y.x1), 
                                  mulsaturated(x.x2,  y.x2), 
                                  mulsaturated(x.x3,  y.x3), 
                                  mulsaturated(x.x4,  y.x4), 
                                  mulsaturated(x.x5,  y.x5), 
                                  mulsaturated(x.x6,  y.x6), 
                                  mulsaturated(x.x7,  y.x7),
                                  mulsaturated(x.x8,  y.x8), 
                                  mulsaturated(x.x9,  y.x9), 
                                  mulsaturated(x.x10, y.x10), 
                                  mulsaturated(x.x11, y.x11), 
                                  mulsaturated(x.x12, y.x12), 
                                  mulsaturated(x.x13, y.x13), 
                                  mulsaturated(x.x14, y.x14), 
                                  mulsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 mulsaturated(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 MAX_VALUE = Avx2.mm256_srli_epi16(Avx2.mm256_cmpeq_epi32(default(v256), default(v256)), 1);

                v256 x16_lo = Avx2.mm256_unpacklo_epi8(x, ZERO);
                v256 y16_lo = Avx2.mm256_unpacklo_epi8(y, ZERO);
                v256 x16_hi = Avx2.mm256_unpackhi_epi8(x, ZERO);
                v256 y16_hi = Avx2.mm256_unpackhi_epi8(y, ZERO);

                v256 product_lo = Avx2.mm256_mullo_epi16(x16_lo, y16_lo);
                v256 product_hi = Avx2.mm256_mullo_epi16(x16_hi, y16_hi);
                v256 overflow16_lo = Avx2.mm256_srai_epi16(product_lo, 15);
                v256 overflow16_hi = Avx2.mm256_srai_epi16(product_hi, 15);
                product_lo = Avx2.mm256_blendv_epi8(product_lo, MAX_VALUE, overflow16_lo);
                product_hi = Avx2.mm256_blendv_epi8(product_hi, MAX_VALUE, overflow16_hi);

                return Avx2.mm256_packus_epi16(product_lo, product_hi);
            }
            else
            {
                return new byte32(mulsaturated(x.v16_0,  y.v16_0), 
                                  mulsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort mulsaturated(ushort x, ushort y)
        {
            return (ushort)math.min(ushort.MaxValue, (uint)x * (uint)y);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mulsaturated(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 MAX_VALUE = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 product_loBits = Sse2.mullo_epi16(x, y);
                v128 product_hiBits = Sse2.mulhi_epu16(x, y);

                v128 _NOT_OverflowMask = Sse2.cmpeq_epi16(ZERO, product_hiBits);

                return Mask.BlendV(MAX_VALUE, product_loBits, _NOT_OverflowMask);
            }
            else
            {
                return new ushort2(mulsaturated(x.x, y.x), 
                                   mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mulsaturated(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 MAX_VALUE = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 product_loBits = Sse2.mullo_epi16(x, y);
                v128 product_hiBits = Sse2.mulhi_epu16(x, y);

                v128 _NOT_OverflowMask = Sse2.cmpeq_epi16(ZERO, product_hiBits);

                return Mask.BlendV(MAX_VALUE, product_loBits, _NOT_OverflowMask);
            }
            else
            {
                return new ushort3(mulsaturated(x.x, y.x), 
                                   mulsaturated(x.y, y.y), 
                                   mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mulsaturated(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 MAX_VALUE = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 product_loBits = Sse2.mullo_epi16(x, y);
                v128 product_hiBits = Sse2.mulhi_epu16(x, y);

                v128 _NOT_OverflowMask = Sse2.cmpeq_epi16(ZERO, product_hiBits);

                return Mask.BlendV(MAX_VALUE, product_loBits, _NOT_OverflowMask);
            }
            else
            {
                return new ushort4(mulsaturated(x.x, y.x), 
                                   mulsaturated(x.y, y.y), 
                                   mulsaturated(x.z, y.z), 
                                   mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 mulsaturated(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 MAX_VALUE = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 product_loBits = Sse2.mullo_epi16(x, y);
                v128 product_hiBits = Sse2.mulhi_epu16(x, y);

                v128 _NOT_OverflowMask = Sse2.cmpeq_epi16(ZERO, product_hiBits);

                return Mask.BlendV(MAX_VALUE, product_loBits, _NOT_OverflowMask);
            }
            else
            {
                return new ushort8(mulsaturated(x.x0, y.x0), 
                                   mulsaturated(x.x1, y.x1), 
                                   mulsaturated(x.x2, y.x2), 
                                   mulsaturated(x.x3, y.x3), 
                                   mulsaturated(x.x4, y.x4), 
                                   mulsaturated(x.x5, y.x5), 
                                   mulsaturated(x.x6, y.x6), 
                                   mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 mulsaturated(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 MAX_VALUE = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 product_loBits = Avx2.mm256_mullo_epi16(x, y);
                v256 product_hiBits = Avx2.mm256_mulhi_epu16(x, y);

                v256 _NOT_OverflowMask = Avx2.mm256_cmpeq_epi16(ZERO, product_hiBits);

                return Avx2.mm256_blendv_epi8(MAX_VALUE, product_loBits, _NOT_OverflowMask);
            }
            else
            {
                return new ushort16(mulsaturated(x.v8_0, y.v8_0), 
                                    mulsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mulsaturated(uint x, uint y)
        {
            return (uint)math.min(uint.MaxValue, (ulong)x * (ulong)y);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mulsaturated(uint2 x, uint2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);
                
                v128 product64 = Sse2.mul_epu32(Sse2.shuffle_epi32(_x, Sse.SHUFFLE(0, 1, 0, 0)),
                                                Sse2.shuffle_epi32(_y, Sse.SHUFFLE(0, 1, 0, 0)));

                v128 _NOT_OverflowMask = Sse2.cmpeq_epi32(ZERO, product64);
                _NOT_OverflowMask = Sse2.shuffle_epi32(_NOT_OverflowMask, Sse.SHUFFLE(0, 0, 3, 1));
                v128 product32 = Sse2.shuffle_epi32(product64, Sse.SHUFFLE(0, 0, 2, 0));
                product32 = Sse2.or_si128(product32, Sse2.xor_si128(ALL_ONES, _NOT_OverflowMask));

                return *(uint2*)&product32;
            }
            else
            {
                return new uint2(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mulsaturated(uint3 x, uint3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 SHUFFLE_MASK = new v128(0, 2, 4, 6);
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                v256 x64 = Avx2.mm256_cvtepu32_epi64(UnityMathematicsLink.Tov128(x));
                v256 y64 = Avx2.mm256_cvtepu32_epi64(UnityMathematicsLink.Tov128(y));

                v256 product64 = Avx2.mm256_mul_epu32(x64, y64);

                v128 product32 = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(product64, Avx.mm256_castsi128_si256(SHUFFLE_MASK)));
                SHUFFLE_MASK = Sse2.sub_epi32(SHUFFLE_MASK, ALL_ONES); // SHUFFLE_MASK = (0, 2, 4, 6) + 1 = (1, 3, 5, 7)
                v128 _NOT_OverflowMask = Sse2.cmpeq_epi32(ZERO, Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(product64, Avx.mm256_castsi128_si256(SHUFFLE_MASK))));
                product32 = Sse4_1.blendv_epi8(ALL_ONES, product32, _NOT_OverflowMask);

                return *(uint3*)&product32;
            }
            else
            {
                return new uint3(mulsaturated(x.xy, y.xy), 
                                 mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mulsaturated(uint4 x, uint4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 SHUFFLE_MASK = new v128(0, 2, 4, 6);
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                v256 x64 = Avx2.mm256_cvtepu32_epi64(UnityMathematicsLink.Tov128(x));
                v256 y64 = Avx2.mm256_cvtepu32_epi64(UnityMathematicsLink.Tov128(y));

                v256 product64 = Avx2.mm256_mul_epu32(x64, y64);

                v128 product32 = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(product64, Avx.mm256_castsi128_si256(SHUFFLE_MASK)));
                SHUFFLE_MASK = Sse2.sub_epi32(SHUFFLE_MASK, ALL_ONES); // SHUFFLE_MASK = (0, 2, 4, 6) + 1 = (1, 3, 5, 7)
                v128 _NOT_OverflowMask = Sse2.cmpeq_epi32(ZERO, Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(product64, Avx.mm256_castsi128_si256(SHUFFLE_MASK))));
                product32 = Sse4_1.blendv_epi8(ALL_ONES, product32, _NOT_OverflowMask);

                return *(uint4*)&product32;
            }
            else
            {
                return new uint4(mulsaturated(x.xy, y.xy), 
                                 mulsaturated(x.zw, y.zw));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 mulsaturated(uint8 x, uint8 y)
        {
            return new uint8(mulsaturated(x.v4_0, y.v4_0), mulsaturated(x.v4_4, y.v4_4));
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mulsaturated(ulong x, ulong y)
        {
            ulong product = Common.umul128(x, y, out ulong hi);

            return product | (ulong)(-(long)tobyte(hi != 0));
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mulsaturated(ulong2 x, ulong2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));

                ulong loX = Common.umul128(x.x, y.x, out ulong hiX);
                ulong loY = Common.umul128(x.y, y.y, out ulong hiY);

                v128 mask = Operator.equals_mask_long(ZERO, new v128(hiX, hiY));

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.blendv_epi8(ALL_ONES, new v128(loX, loY), mask);
                }
                else
                {
                    return Sse2.or_si128(new v128(loX, loY), Sse2.xor_si128(ALL_ONES, mask));
                }
            }
            else
            {
                return new ulong2(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mulsaturated(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 lo = Operator.umul128(x, y, out v256 hi);
                
                return Avx2.mm256_blendv_epi8(ALL_ONES, lo, Avx2.mm256_cmpeq_epi64(ZERO, hi));
            }
            else
            {
                return new ulong3(mulsaturated(x.xy, y.xy),
                                  mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mulsaturated(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));

                v256 lo = Operator.umul128(x, y, out v256 hi);
                
                return Avx2.mm256_blendv_epi8(ALL_ONES, lo, Avx2.mm256_cmpeq_epi64(ZERO, hi));
            }
            else
            {
                return new ulong4(mulsaturated(x.xy, y.xy),
                                  mulsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte mulsaturated(sbyte x, sbyte y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Sse2.cvtsi32_si128(x);
                v128 _y = Sse2.cvtsi32_si128(y);

                v128 product = Sse2.mullo_epi16(_x, _y);

                return Sse2.packs_epi16(product, product).SByte0;
            }
            else
            {
                return (sbyte)math.clamp(x * y, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mulsaturated(sbyte2 x, sbyte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 product = Sse2.mullo_epi16(Cast.SByteToShort(x), Cast.SByteToShort(y));

                return Sse2.packs_epi16(product, product);
            }
            else
            {
                return new sbyte2(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mulsaturated(sbyte3 x, sbyte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 product = Sse2.mullo_epi16(Cast.SByteToShort(x), Cast.SByteToShort(y));

                return Sse2.packs_epi16(product, product);
            }
            else
            {
                return new sbyte3(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mulsaturated(sbyte4 x, sbyte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 product = Sse2.mullo_epi16(Cast.SByteToShort(x), Cast.SByteToShort(y));

                return Sse2.packs_epi16(product, product);
            }
            else
            {
                return new sbyte4(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z), 
                                  mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 mulsaturated(sbyte8 x, sbyte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 product = Sse2.mullo_epi16(Cast.SByteToShort(x), Cast.SByteToShort(y));

                return Sse2.packs_epi16(product, product);
            }
            else
            {
                return new sbyte8(mulsaturated(x.x0, y.x0), 
                                  mulsaturated(x.x1, y.x1), 
                                  mulsaturated(x.x2, y.x2), 
                                  mulsaturated(x.x3, y.x3), 
                                  mulsaturated(x.x4, y.x4), 
                                  mulsaturated(x.x5, y.x5), 
                                  mulsaturated(x.x6, y.x6), 
                                  mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 mulsaturated(sbyte16 x, sbyte16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 product = Avx2.mm256_mullo_epi16(Avx2.mm256_cvtepi8_epi16(x), Avx2.mm256_cvtepi8_epi16(y));
                v256 bytes = Avx2.mm256_packs_epi16(product, product);
                v256 ordered = Avx2.mm256_permute4x64_epi64(bytes, Sse.SHUFFLE(0, 0, 2, 0));

                return Avx.mm256_castsi256_si128(ordered);

            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 xNegative = Sse2.cmpgt_epi8(ZERO, x);
                v128 yNegative = Sse2.cmpgt_epi8(ZERO, y);
                v128 product_lo = Sse2.mullo_epi16(Sse2.unpacklo_epi8(x, xNegative), Sse2.unpacklo_epi8(y, yNegative));
                v128 product_hi = Sse2.mullo_epi16(Sse2.unpackhi_epi8(x, xNegative), Sse2.unpackhi_epi8(y, yNegative));

                return Sse2.packs_epi16(product_lo, product_hi);
            }
            else
            {
                return new sbyte16(mulsaturated(x.x0,  y.x0), 
                                   mulsaturated(x.x1,  y.x1), 
                                   mulsaturated(x.x2,  y.x2), 
                                   mulsaturated(x.x3,  y.x3), 
                                   mulsaturated(x.x4,  y.x4), 
                                   mulsaturated(x.x5,  y.x5), 
                                   mulsaturated(x.x6,  y.x6), 
                                   mulsaturated(x.x7,  y.x7),
                                   mulsaturated(x.x8,  y.x8), 
                                   mulsaturated(x.x9,  y.x9), 
                                   mulsaturated(x.x10, y.x10), 
                                   mulsaturated(x.x11, y.x11), 
                                   mulsaturated(x.x12, y.x12), 
                                   mulsaturated(x.x13, y.x13), 
                                   mulsaturated(x.x14, y.x14), 
                                   mulsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 mulsaturated(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 xNegative = Avx2.mm256_cmpgt_epi8(ZERO, x);
                v256 yNegative = Avx2.mm256_cmpgt_epi8(ZERO, y);
                v256 product_lo = Avx2.mm256_mullo_epi16(Avx2.mm256_unpacklo_epi8(x, xNegative), Avx2.mm256_unpacklo_epi8(y, yNegative));
                v256 product_hi = Avx2.mm256_mullo_epi16(Avx2.mm256_unpackhi_epi8(x, xNegative), Avx2.mm256_unpackhi_epi8(y, yNegative));

                return Avx2.mm256_packs_epi16(product_lo, product_hi);
            }
            else
            {
                return new sbyte32(mulsaturated(x.v16_0,  y.v16_0), 
                                   mulsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short mulsaturated(short x, short y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 _x = Sse2.cvtsi32_si128(x);
                v128 _y = Sse2.cvtsi32_si128(y);

                v128 product = Sse4_1.mullo_epi32(_x, _y);

                return Sse2.packs_epi32(product, product).SShort0;
            }
            else
            {
                return (short)math.clamp(x * y, short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mulsaturated(short2 x, short2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 x32 = Cast.ShortToInt(x);
                v128 y32 = Cast.ShortToInt(y);

                v128 product = Operator.mul_int(x32, y32);

                return Sse2.packs_epi32(product, product);
            }
            else
            {
                return new short2(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mulsaturated(short3 x, short3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 x32 = Cast.ShortToInt(x);
                v128 y32 = Cast.ShortToInt(y);

                v128 product = Operator.mul_int(x32, y32);

                return Sse2.packs_epi32(product, product);
            }
            else
            {
                return new short3(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mulsaturated(short4 x, short4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 x32 = Cast.ShortToInt(x);
                v128 y32 = Cast.ShortToInt(y);

                v128 product = Operator.mul_int(x32, y32);

                return Sse2.packs_epi32(product, product);
            }
            else
            {
                return new short4(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z), 
                                  mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 mulsaturated(short8 x, short8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();

                v128 xNegativeMask = Sse2.cmpgt_epi16(ZERO, x);
                v128 yNegativeMask = Sse2.cmpgt_epi16(ZERO, y);
                
                v128 x32_lo = Sse2.unpacklo_epi16(x, xNegativeMask);
                v128 y32_lo = Sse2.unpacklo_epi16(y, yNegativeMask);
                v128 x32_hi = Sse2.unpackhi_epi16(x, xNegativeMask);
                v128 y32_hi = Sse2.unpackhi_epi16(y, yNegativeMask);

                v128 product_lo = Operator.mul_int(x32_lo, y32_lo);
                v128 product_hi = Operator.mul_int(x32_hi, y32_hi);

                return Sse2.packs_epi32(product_lo, product_hi);
            }
            else
            {
                return new short8(mulsaturated(x.x0, y.x0), 
                                  mulsaturated(x.x1, y.x1), 
                                  mulsaturated(x.x2, y.x2), 
                                  mulsaturated(x.x3, y.x3), 
                                  mulsaturated(x.x4, y.x4), 
                                  mulsaturated(x.x5, y.x5), 
                                  mulsaturated(x.x6, y.x6), 
                                  mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 mulsaturated(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();

                v256 xNegativeMask = Avx2.mm256_cmpgt_epi16(ZERO, x);
                v256 yNegativeMask = Avx2.mm256_cmpgt_epi16(ZERO, y);

                v256 x32_lo = Avx2.mm256_unpacklo_epi16(x, xNegativeMask);
                v256 y32_lo = Avx2.mm256_unpacklo_epi16(y, yNegativeMask);
                v256 x32_hi = Avx2.mm256_unpackhi_epi16(x, xNegativeMask);
                v256 y32_hi = Avx2.mm256_unpackhi_epi16(y, yNegativeMask);

                v256 product_lo = Avx2.mm256_mullo_epi32(x32_lo, y32_lo);
                v256 product_hi = Avx2.mm256_mullo_epi32(x32_hi, y32_hi);

                return Avx2.mm256_packs_epi32(product_lo, product_hi);
            }
            else
            {
                return new short16(mulsaturated(x.v8_0, y.v8_0), 
                                   mulsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mulsaturated(int x, int y)
        {
            return (int)math.clamp((long)x * (long)y, int.MinValue, int.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mulsaturated(int2 x, int2 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MIN_VALUE = new long2(int.MinValue);
                v128 MAX_VALUE = new long2(int.MaxValue);

                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);
                v128 product32;
                v128 product64;
                
                product64 = Sse4_1.mul_epi32(Sse2.shuffle_epi32(_x, Sse.SHUFFLE(0, 1, 0, 0)),
                                             Sse2.shuffle_epi32(_y, Sse.SHUFFLE(0, 1, 0, 0)));

                v128 underflowMask = Operator.greater_mask_long(MIN_VALUE, product64);
                v128 overflowMask = Operator.greater_mask_long(product64, MAX_VALUE);

                product64 = Sse4_1.blendv_epi8(product64, MIN_VALUE, underflowMask);
                product64 = Sse4_1.blendv_epi8(product64, MAX_VALUE, overflowMask);

                product32 = Sse2.shuffle_epi32(product64, Sse.SHUFFLE(0, 0, 2, 0));

                return *(int2*)&product32;
            }
            else
            {
                return new int2(mulsaturated(x.x, y.x), 
                                mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mulsaturated(int3 x, int3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);
                v128 product32;

                v256 MIN_VALUE = new long4(int.MinValue);
                v256 MAX_VALUE = new long4(int.MaxValue);

                v256 product64 = Avx2.mm256_mul_epi32(Avx2.mm256_cvtepi32_epi64(_x),
                                                      Avx2.mm256_cvtepi32_epi64(_y));

                v256 underflowMask = Avx2.mm256_cmpgt_epi64(MIN_VALUE, product64);
                v256 overflowMask = Avx2.mm256_cmpgt_epi64(product64, MAX_VALUE);

                product64 = Avx2.mm256_blendv_epi8(product64, MIN_VALUE, underflowMask);
                product64 = Avx2.mm256_blendv_epi8(product64, MAX_VALUE, overflowMask);

                product32 = Cast.Long4ToInt4(product64);


                return *(int3*)&product32;
            }
            else
            {
                return new int3(mulsaturated(x.xy, y.xy), 
                                mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mulsaturated(int4 x, int4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);
                v128 product32;

                v256 MIN_VALUE = new long4(int.MinValue);
                v256 MAX_VALUE = new long4(int.MaxValue);

                v256 product64 = Avx2.mm256_mul_epi32(Avx2.mm256_cvtepi32_epi64(_x),
                                                      Avx2.mm256_cvtepi32_epi64(_y));

                v256 underflowMask = Avx2.mm256_cmpgt_epi64(MIN_VALUE, product64);
                v256 overflowMask = Avx2.mm256_cmpgt_epi64(product64, MAX_VALUE);

                product64 = Avx2.mm256_blendv_epi8(product64, MIN_VALUE, underflowMask);
                product64 = Avx2.mm256_blendv_epi8(product64, MAX_VALUE, overflowMask);

                product32 = Cast.Long4ToInt4(product64);


                return *(int4*)&product32;
            }
            else
            {
                return new int4(mulsaturated(x.xy, y.xy), 
                                mulsaturated(x.zw, y.zw));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 mulsaturated(int8 x, int8 y)
        {
            return new int8(mulsaturated(x.v4_0, y.v4_0), mulsaturated(x.v4_4, y.v4_4));
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mulsaturated(long x, long y)
        {
            long lo = Operator.imul128(x, y, out long hi);
            
            return hi < -1 ? long.MinValue : hi != 0 ? long.MaxValue : lo;
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mulsaturated(long2 x, long2 y)
        {
            if (Sse4_2.IsSse42Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 MAX_VALUE = Sse2.srli_epi64(Sse2.cmpeq_epi32(default(v128), default(v128)), 1);
                
                ulong loX = Common.umul128((ulong)x.x, (ulong)y.x, out ulong hiX);
                ulong loY = Common.umul128((ulong)x.y, (ulong)y.y, out ulong hiY);
                v128 xNegative = Sse4_2.cmpgt_epi64(ZERO, x);
                v128 yNegative = Sse4_2.cmpgt_epi64(ZERO, y);
                v128 mask = Sse2.sub_epi64(MAX_VALUE, Sse2.xor_si128(xNegative, yNegative));
                v128 lo = new v128(loX, loY);
                v128 hi = new v128(hiX, hiY);
                
                return Sse4_1.blendv_epi8(mask, lo, Sse4_1.cmpeq_epi64(hi, Sse4_2.cmpgt_epi64(ZERO, lo)));
            }
            else
            {
                return new long2(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mulsaturated(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 MAX_VALUE = Avx2.mm256_srli_epi64(Avx2.mm256_cmpeq_epi32(default(v256), default(v256)), 1);
                
                v256 lo = Operator.umul128(x, y, out v256 hi);
                
                v256 xNegative = Avx2.mm256_cmpgt_epi64(ZERO, x);
                v256 yNegative = Avx2.mm256_cmpgt_epi64(ZERO, y);
                v256 mask = Avx2.mm256_sub_epi64(MAX_VALUE, Avx2.mm256_xor_si256(xNegative, yNegative));

                return Avx2.mm256_blendv_epi8(mask, lo, Avx2.mm256_cmpeq_epi64(hi, Avx2.mm256_cmpgt_epi64(ZERO, lo)));
            }
            else
            {
                return new long3(mulsaturated(x.xy, y.xy), 
                                 mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mulsaturated(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();
                v256 MAX_VALUE = Avx2.mm256_srli_epi64(Avx2.mm256_cmpeq_epi32(default(v256), default(v256)), 1);
                
                v256 lo = Operator.umul128(x, y, out v256 hi);
                
                v256 xNegative = Avx2.mm256_cmpgt_epi64(ZERO, x);
                v256 yNegative = Avx2.mm256_cmpgt_epi64(ZERO, y);
                v256 mask = Avx2.mm256_sub_epi64(MAX_VALUE, Avx2.mm256_xor_si256(xNegative, yNegative));

                return Avx2.mm256_blendv_epi8(mask, lo, Avx2.mm256_cmpeq_epi64(hi, Avx2.mm256_cmpgt_epi64(ZERO, lo)));
            }
            else
            {
                return new long4(mulsaturated(x.xy, y.xy), 
                                 mulsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mulsaturated(float x, float y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mulsaturated(float2 x, float2 y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mulsaturated(float3 x, float3 y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mulsaturated(float4 x, float4 y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 mulsaturated(float8 x, float8 y)
        {
            return clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mulsaturated(double x, double y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mulsaturated(double2 x, double2 y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mulsaturated(double3 x, double3 y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mulsaturated(double4 x, double4 y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }
    }
}