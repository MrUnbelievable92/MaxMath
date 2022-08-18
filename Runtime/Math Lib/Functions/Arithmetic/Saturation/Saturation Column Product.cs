using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.byte2"/>, so that the product is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cprodsaturated(byte2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Sse4_1.cvtepu8_epi16(x);
                ints = Sse2.mullo_epi16(ints, Sse2.shufflelo_epi16(ints, Sse.SHUFFLE(0, 0, 0, 1)));
                ints = Sse4_1.min_epu16(ints, Sse2.cvtsi32_si128(byte.MaxValue));

                return ints.Byte0;
            }
            else
            {
                return mulsaturated(x.x, x.y);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.byte3"/>, so that the product is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cprodsaturated(byte3 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.cvtsi32_si128(byte.MaxValue);

                v128 ints = Sse4_1.cvtepu8_epi32(x);

                v128 _y = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 1));
                v128 _z = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 2));

                v128 _xy = Sse4_1.mullo_epi32(ints, _y);
                v128 _xyz = Sse4_1.mullo_epi32(_xy, _z);
                _xyz = Sse4_1.min_epu32(_xyz, MAX_VALUE);

                return _xyz.Byte0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, x.x * x.y * x.z);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.byte4"/>, so that the product is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cprodsaturated(byte4 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.cvtsi32_si128(byte.MaxValue);

                v128 ints = Sse4_1.cvtepu8_epi32(x);
                v128 product;
                
                product = Sse4_1.mullo_epi32(ints, Sse2.bsrli_si128(ints, 2 * sizeof(uint)));
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (byte)product.SInt0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, ((uint)x.x * x.y) * ((uint)x.z * x.w));
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.byte8"/>, so that the product is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cprodsaturated(byte8 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 24);

                v128 ints_lo = Sse4_1.cvtepu8_epi32(x);
                v128 ints_hi = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x, 4 * sizeof(byte)));
                v128 product;
                
                product = Sse4_1.mullo_epi32(ints_lo, ints_hi);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                
                return (byte)product.SInt0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, (((ulong)x.x0 * x.x1) * ((ulong)x.x2 * x.x3)) * (((ulong)x.x4 * x.x5) * ((ulong)x.x6 * x.x7)));
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.byte16"/>, so that the product is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cprodsaturated(byte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 24);

                v256 ints_lo = Avx2.mm256_cvtepu8_epi32(x);
                v256 ints_hi = Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(x, 8 * sizeof(byte)));

                v256 product = Avx2.mm256_mullo_epi32(ints_lo, ints_hi);
                v128 product128 = Sse4_1.mullo_epi32(Avx.mm256_castsi256_si128(product), Avx2.mm256_extracti128_si256(product, 1));
                product128 = Sse4_1.min_epu32(product128, MAX_VALUE);
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 2 * sizeof(uint)));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 1 * sizeof(uint)));
                product128 = Sse4_1.min_epu32(product128, MAX_VALUE);

                return (byte)product128.SInt0;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 24);

                v128 ints1 = Sse4_1.cvtepu8_epi32(x);
                v128 ints2 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x,  4 * sizeof(byte)));
                v128 ints3 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x,  8 * sizeof(byte)));
                v128 ints4 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x, 12 * sizeof(byte)));
                v128 product;
                
                product = Sse4_1.mullo_epi32(Sse4_1.mullo_epi32(ints1, ints2), Sse4_1.mullo_epi32(ints3, ints4));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(uint)));
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (byte)product.SInt0;

            }
            else
            {
                return (byte)math.min(byte.MaxValue, cprodsaturated(x.v8_0) * cprodsaturated(x.v8_8));
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.byte32"/>, so that the product is clamped to <see cref="byte.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cprodsaturated(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_VALUE = Avx2.mm256_srli_epi32(Xse.mm256_setall_si256(), 24);

                v256 shorts = Xse.mm256_cvt2x2epu8_epi16(x, out v256 shorts_hi);
                shorts = Avx2.mm256_mullo_epi16(shorts, shorts_hi);
                v256 ints_lo = Xse.mm256_cvt2x2epu16_epi32(shorts, out v256 ints_hi);

                v256 product = Avx2.mm256_mullo_epi32(ints_lo, ints_hi);
                product = Avx2.mm256_min_epu32(product, MAX_VALUE);
                v128 product128 = Sse4_1.mullo_epi32(Avx.mm256_castsi256_si128(product), Avx2.mm256_extracti128_si256(product, 1));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 2 * sizeof(uint)));
                product128 = Sse4_1.min_epu32(product128, Avx.mm256_castsi256_si128(MAX_VALUE));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 1 * sizeof(uint)));
                product128 = Sse4_1.min_epu32(product128, Avx.mm256_castsi256_si128(MAX_VALUE));

                return (byte)product128.SInt0;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 24);

                v128 ints1 = Sse4_1.cvtepu8_epi32(x._v16_0);
                v128 ints2 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x._v16_0,  4 * sizeof(byte)));
                v128 ints3 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x._v16_0,  8 * sizeof(byte)));
                v128 ints4 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x._v16_0, 12 * sizeof(byte)));
                v128 ints5 = Sse4_1.cvtepu8_epi32(x._v16_16);
                v128 ints6 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x._v16_16,  4 * sizeof(byte)));
                v128 ints7 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x._v16_16,  8 * sizeof(byte)));
                v128 ints8 = Sse4_1.cvtepu8_epi32(Sse2.bsrli_si128(x._v16_16, 12 * sizeof(byte)));
                v128 product;
                
                v128 product1 = Sse4_1.mullo_epi32(Sse4_1.mullo_epi32(ints1, ints5), Sse4_1.mullo_epi32(ints3, ints4));
                product1 = Sse4_1.min_epu32(product1, MAX_VALUE);
                v128 product2 = Sse4_1.mullo_epi32(Sse4_1.mullo_epi32(ints2, ints6), Sse4_1.mullo_epi32(ints7, ints8));
                product2 = Sse4_1.min_epu32(product2, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product1, product2);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (byte)product.SInt0;
            }
            else
            {
                return (byte)math.min(byte.MaxValue, cprodsaturated(x.v16_0) * cprodsaturated(x.v16_16));
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.sbyte2"/>, so that the product is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cprodsaturated(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 shorts = Xse.cvtepi8_epi16(x);
                v128 product;
                
                product = Sse2.mullo_epi16(shorts, Sse2.bsrli_si128(shorts, 1 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else
            {
                return mulsaturated(x.x, x.y);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.sbyte3"/>, so that the product is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cprodsaturated(sbyte3 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Sse4_1.cvtepi8_epi32(x);

                v128 _y = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 1));
                v128 _z = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 2));

                v128 _xy = Sse4_1.mullo_epi32(ints, _y);
                v128 _xyz = Sse4_1.mullo_epi32(_xy, _z);

                v128 shorts = Sse2.packs_epi32(_xyz, _xyz);

                return Sse2.packs_epi16(shorts, shorts).SByte0;
            }
            else
            {
                return (sbyte)math.clamp(x.x * x.y * x.z, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.sbyte4"/>, so that the product is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cprodsaturated(sbyte4 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Sse4_1.cvtepi8_epi32(x);
                v128 product;
                
                product = Sse4_1.mullo_epi32(ints,    Sse2.bsrli_si128(ints,    2 * sizeof(int)));
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ALL_ONES = Xse.setall_si128();
                v128 MIN_VALUE = Sse2.slli_epi16(ALL_ONES, 7);
                v128 MAX_VALUE = Sse2.srli_epi16(ALL_ONES, 9);

                v128 shorts = Xse.cvtepi8_epi16(x);
                v128 product;
                
                product = Sse2.mullo_epi16(shorts, Sse2.bsrli_si128(shorts, 2 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 1 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else
            {
                return (sbyte)math.clamp((x.x * x.y) * (x.z * x.w), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.sbyte8"/>, so that the product is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cprodsaturated(sbyte8 x)                            
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints_lo = Sse4_1.cvtepi8_epi32(x);
                v128 ints_hi = Sse4_1.cvtepi8_epi32(Sse2.bsrli_si128(x, 4 * sizeof(sbyte)));
                v128 product;

                product = Sse4_1.mullo_epi32(ints_lo, ints_hi);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse4_1.cvtepi16_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ALL_ONES = Xse.setall_si128();
                v128 MIN_VALUE = Sse2.slli_epi16(ALL_ONES, 7);
                v128 MAX_VALUE = Sse2.srli_epi16(ALL_ONES, 9);

                v128 shorts = Xse.cvtepi8_epi16(x);
                v128 product;

                product = Sse2.mullo_epi16(shorts, Sse2.bsrli_si128(shorts, 4 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 2 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 1 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else
            {
                return (sbyte)math.clamp((((long)x.x0 * x.x1) * ((long)x.x2 * x.x3)) * (((long)x.x4 * x.x5) * ((long)x.x6 * x.x7)), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.sbyte16"/>, so that the product is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cprodsaturated(sbyte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ints_lo = Avx2.mm256_cvtepi8_epi32(x);
                v256 ints_hi = Avx2.mm256_cvtepi8_epi32(Sse2.bsrli_si128(x, 8 * sizeof(sbyte)));

                v256 product = Avx2.mm256_mullo_epi32(ints_lo, ints_hi);
                v128 product128 = Sse4_1.mullo_epi32(Avx.mm256_castsi256_si128(product), Avx2.mm256_extracti128_si256(product, 1));
                product128 = Sse2.packs_epi32(product128, product128);
                product128 = Sse2.packs_epi16(product128, product128);
                product128 = Sse4_1.cvtepi8_epi32(product128);
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 2 * sizeof(int)));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 1 * sizeof(int)));
                product128 = Sse2.packs_epi32(product128, product128);
                product128 = Sse2.packs_epi16(product128, product128);

                return product128.SByte0;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 shorts_lo = Sse4_1.cvtepi8_epi16(x);
                v128 shorts_hi = Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(x, 8 * sizeof(sbyte)));
                v128 product;

                product = Sse2.mullo_epi16(shorts_lo, shorts_hi);
                product = Sse2.packs_epi16(product, product);
                product = Sse4_1.cvtepi8_epi16(product);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 4 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);
                product = Sse4_1.cvtepi8_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(int)));
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ALL_ONES = Xse.setall_si128();
                v128 MIN_VALUE = Sse2.slli_epi16(ALL_ONES, 7);
                v128 MAX_VALUE = Sse2.srli_epi16(ALL_ONES, 9);

                v128 IsNegativeMask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);
                v128 shorts_lo = Sse2.unpacklo_epi8(x, IsNegativeMask);
                v128 shorts_hi = Sse2.unpackhi_epi8(x, IsNegativeMask);
                v128 product;

                product = Sse2.mullo_epi16(shorts_lo, shorts_hi);
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 4 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 2 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 1 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else
            {
                return (sbyte)math.clamp(cprodsaturated(x.v8_0) * cprodsaturated(x.v8_8), sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.sbyte32"/>, so that the product is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cprodsaturated(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shorts1 = Xse.mm256_cvt2x2epi8_epi16(x, out v256 shorts2);

                v256 product = Avx2.mm256_mullo_epi16(shorts1, shorts2);
                v128 product128 = Sse2.packs_epi16(Avx.mm256_castsi256_si128(product), Avx2.mm256_extracti128_si256(product, 1));
                product128 = Sse2.mullo_epi16(Sse4_1.cvtepi8_epi16(product128), Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(product128, 8 * sizeof(sbyte))));
                product128 = Sse2.packs_epi16(product128, product128);
                product128 = Sse4_1.cvtepi8_epi16(product128);
                product128 = Sse2.mullo_epi16(product128, Sse2.bsrli_si128(product128, 4 * sizeof(short)));
                product128 = Sse2.packs_epi16(product128, product128);
                product128 = Sse4_1.cvtepi8_epi32(product128);
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 2 * sizeof(int)));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 1 * sizeof(int)));
                product128 = Sse2.packs_epi32(product128, product128);
                product128 = Sse2.packs_epi16(product128, product128);

                return product128.SByte0;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = x._v16_0;
                v128 hi = x._v16_16;
                v128 shorts1 = Sse4_1.cvtepi8_epi16(lo);
                v128 shorts2 = Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(lo, 8 * sizeof(sbyte)));
                v128 shorts3 = Sse4_1.cvtepi8_epi16(hi);
                v128 shorts4 = Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(hi, 8 * sizeof(sbyte)));
                v128 product;

                v128 product1 = Sse2.mullo_epi16(shorts1, shorts2);
                v128 product2 = Sse2.mullo_epi16(shorts3, shorts4);
                product = Sse2.packs_epi16(product1, product2);
                product1 = Sse4_1.cvtepi8_epi16(product);
                product2 = Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(product, 8 * sizeof(sbyte)));
                product = Sse2.mullo_epi16(product1, product2);
                product = Sse2.packs_epi16(product, product);
                product = Sse4_1.cvtepi8_epi16(product);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 4 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);
                product = Sse4_1.cvtepi8_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(int)));
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 ALL_ONES = Xse.setall_si128();
                v128 MIN_VALUE = Sse2.slli_epi16(ALL_ONES, 7);
                v128 MAX_VALUE = Sse2.srli_epi16(ALL_ONES, 9);

                v128 lo = x._v16_0;
                v128 hi = x._v16_16;
                v128 xNegativeMask_lo = Sse2.cmpgt_epi8(ZERO, lo);
                v128 xNegativeMask_hi = Sse2.cmpgt_epi8(ZERO, hi);
                v128 shorts1 = Sse2.unpacklo_epi8(lo, xNegativeMask_lo);
                v128 shorts2 = Sse2.unpackhi_epi8(lo, xNegativeMask_lo);
                v128 shorts3 = Sse2.unpacklo_epi8(hi, xNegativeMask_hi);
                v128 shorts4 = Sse2.unpackhi_epi8(hi, xNegativeMask_hi);
                v128 product;

                v128 product1 = Sse2.mullo_epi16(shorts1, shorts2);
                product1 = Sse2.max_epi16(product1, MIN_VALUE);
                product1 = Sse2.min_epi16(product1, MAX_VALUE);
                v128 product2 = Sse2.mullo_epi16(shorts3, shorts4);
                product2 = Sse2.max_epi16(product2, MIN_VALUE);
                product2 = Sse2.min_epi16(product2, MAX_VALUE);
                product = Sse2.mullo_epi16(product1, product2);
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 4 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 2 * sizeof(short)));
                product = Sse2.max_epi16(product, MIN_VALUE);
                product = Sse2.min_epi16(product, MAX_VALUE);
                product = Sse2.mullo_epi16(product, Sse2.bsrli_si128(product, 1 * sizeof(short)));
                product = Sse2.packs_epi16(product, product);

                return product.SByte0;
            }
            else
            {
                return (sbyte)math.clamp(cprodsaturated(x.v8_0) * cprodsaturated(x.v8_8) * cprodsaturated(x.v8_16) * cprodsaturated(x.v8_24), sbyte.MinValue, sbyte.MaxValue);
            }
        }


        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.short2"/>, so that the product is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cprodsaturated(short2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Sse4_1.cvtepi16_epi32(x);
                
                v128 product = Sse4_1.mullo_epi32(ints, Sse2.bsrli_si128(ints, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);

                return product.SShort0;
            }
            else
            {
                return mulsaturated(x.x, x.y);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.short3"/>, so that the product is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cprodsaturated(short3 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Sse4_1.cvtepi16_epi32(x);

                v128 _y = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 1));
                v128 _z = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 2));

                v128 _xy = Sse4_1.mullo_epi32(ints, _y);
                _xy = Sse4_1.cvtepi16_epi32(Sse2.packs_epi32(_xy, _xy));
                v128 _xyz = Sse4_1.mullo_epi32(_xy, _z);

                return Sse2.packs_epi32(_xyz, _xyz).SShort0;
            }
            else
            {
                return (short)math.clamp((long)x.x * x.y * x.z, short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.short4"/>, so that the product is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cprodsaturated(short4 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Sse4_1.cvtepi16_epi32(x);
                v128 product;

                product = Sse4_1.mullo_epi32(ints, Sse2.bsrli_si128(ints, 2 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse4_1.cvtepi16_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);

                return product.SShort0;
            }
            else
            {
                return (short)math.clamp(((long)x.x * x.y) * ((long)x.z * x.w), short.MinValue, short.MaxValue); 
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.short8"/>, so that the product is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cprodsaturated(short8 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 ints1 = Sse4_1.cvtepi16_epi32(x);
                v128 ints2 = Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(short)));
                v128 product;

                product = Sse4_1.mullo_epi32(ints1, ints2);
                product = Sse2.packs_epi32(product, product);
                product = Sse4_1.cvtepi16_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse4_1.cvtepi16_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);

                return product.SShort0;
            }
            else
            {
                return (short)math.clamp(cprodsaturated(x.v4_0) * cprodsaturated(x.v4_4), short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.short16"/>, so that the product is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cprodsaturated(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ints1 = Xse.mm256_cvt2x2epi16_epi32(x, out v256 ints2);
                
                v256 product = Avx2.mm256_mullo_epi32(ints1, ints2);
                v128 product128 = Sse2.packs_epi32(Avx.mm256_castsi256_si128(product), Avx2.mm256_extracti128_si256(product, 1));
                product128 = Sse4_1.mullo_epi32(Sse4_1.cvtepi16_epi32(product128), Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(product128, 4 * sizeof(short))));
                product128 = Sse2.packs_epi32(product128, product128);
                product128 = Sse4_1.cvtepi16_epi32(product128);
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 2 * sizeof(int)));
                product128 = Sse2.packs_epi32(product128, product128);
                product128 = Sse4_1.cvtepi16_epi32(product128);
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 1 * sizeof(int)));
                product128 = Sse2.packs_epi32(product128, product128);

                return product128.SShort0;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = x._v8_0;
                v128 hi = x._v8_8;
                v128 ints1 = Sse4_1.cvtepi16_epi32(lo);
                v128 ints2 = Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(lo, 4 * sizeof(short)));
                v128 ints3 = Sse4_1.cvtepi16_epi32(hi);
                v128 ints4 = Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(hi, 4 * sizeof(short)));

                v128 product_lo = Sse4_1.mullo_epi32(ints1, ints3);
                v128 product_hi = Sse4_1.mullo_epi32(ints2, ints4);
                v128 product = Sse2.packs_epi32(product_lo, product_hi);
                product_lo = Sse4_1.cvtepi16_epi32(product);
                product_hi = Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(product, 4 * sizeof(short)));
                product = Sse4_1.mullo_epi32(product_lo, product_hi);
                product = Sse2.packs_epi32(product, product);
                product = Sse4_1.cvtepi16_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);
                product = Sse4_1.cvtepi16_epi32(product);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(int)));
                product = Sse2.packs_epi32(product, product);

                return product.SShort0;
            }
            else
            {
                return (short)math.clamp((long)cprodsaturated(x.v4_0) * cprodsaturated(x.v4_4) * cprodsaturated(x.v4_8) * cprodsaturated(x.v4_12), short.MinValue, short.MaxValue);
            }
        }


        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ushort2"/>, so that the product is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cprodsaturated(ushort2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 16);

                v128 ints = Sse4_1.cvtepu16_epi32(x);

                v128 product = Sse4_1.mullo_epi32(ints, Sse2.bsrli_si128(ints, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (ushort)product.SInt0;
            }
            else
            {
                return mulsaturated(x.x, x.y);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ushort3"/>, so that the product is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cprodsaturated(ushort3 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 16);

                v128 ints = Sse4_1.cvtepu16_epi32(x);

                v128 _y = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 1));
                v128 _z = Sse2.shuffle_epi32(ints, Sse.SHUFFLE(0, 0, 0, 2));

                v128 _xy = Sse4_1.mullo_epi32(ints, _y);
                _xy = Sse4_1.min_epu32(_xy, MAX_VALUE);
                v128 _xyz = Sse4_1.mullo_epi32(_xy, _z);
                _xyz = Sse4_1.min_epu32(_xyz, MAX_VALUE);

                return _xyz.UShort0;
            }
            else
            {
                return (ushort)math.min((ulong)x.x * x.y * x.z, ushort.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ushort4"/>, so that the product is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cprodsaturated(ushort4 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 16);

                v128 ints = Sse4_1.cvtepu16_epi32(x);

                v128 product = Sse4_1.mullo_epi32(ints, Sse2.bsrli_si128(ints, 2 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (ushort)product.SInt0;
            }
            else
            {
                return (ushort)math.min(((ulong)x.x * x.y) * ((ulong)x.z * x.w), ushort.MaxValue);
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ushort8"/>, so that the product is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cprodsaturated(ushort8 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 16);

                v128 ints1 = Sse4_1.cvtepu16_epi32(x);
                v128 ints2 = Sse4_1.cvtepu16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(ushort)));

                v128 product = Sse4_1.mullo_epi32(ints1, ints2);
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (ushort)product.SInt0;
            }
            else
            {
                return (ushort)math.min((ulong)cprodsaturated(x.v4_0) * cprodsaturated(x.v4_4), ushort.MaxValue); 
            }
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ushort16"/>, so that the product is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cprodsaturated(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_VALUE = Avx2.mm256_srli_epi32(Xse.mm256_setall_si256(), 16);
                
                v256 ints1 = Xse.mm256_cvt2x2epu16_epi32(x, out v256 ints2);

                v256 product = Avx2.mm256_mullo_epi32(ints1, ints2);
                product = Avx2.mm256_min_epu32(product, MAX_VALUE);
                v128 product128 = Sse4_1.mullo_epi32(Avx.mm256_castsi256_si128(product), Avx2.mm256_extracti128_si256(product, 1));
                product128 = Sse4_1.min_epu32(product128, Avx.mm256_castsi256_si128(MAX_VALUE));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 2 * sizeof(uint)));
                product128 = Sse4_1.min_epu32(product128, Avx.mm256_castsi256_si128(MAX_VALUE));
                product128 = Sse4_1.mullo_epi32(product128, Sse2.bsrli_si128(product128, 1 * sizeof(uint)));
                product128 = Sse4_1.min_epu32(product128, Avx.mm256_castsi256_si128(MAX_VALUE));

                return (ushort)product128.SInt0;
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.srli_epi32(Xse.setall_si128(), 16);

                v128 lo = x._v8_0;
                v128 hi = x._v8_8;
                v128 ints1 = Sse4_1.cvtepu16_epi32(lo);
                v128 ints2 = Sse4_1.cvtepu16_epi32(Sse2.bsrli_si128(lo, 4 * sizeof(ushort)));
                v128 ints3 = Sse4_1.cvtepu16_epi32(hi);
                v128 ints4 = Sse4_1.cvtepu16_epi32(Sse2.bsrli_si128(hi, 4 * sizeof(ushort)));

                v128 product_lo = Sse4_1.mullo_epi32(ints1, ints3);
                product_lo = Sse4_1.min_epu32(product_lo, MAX_VALUE);
                v128 product_hi = Sse4_1.mullo_epi32(ints2, ints4);
                product_hi = Sse4_1.min_epu32(product_hi, MAX_VALUE);
                v128 product = Sse4_1.mullo_epi32(product_lo, product_hi);
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 2 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);
                product = Sse4_1.mullo_epi32(product, Sse2.bsrli_si128(product, 1 * sizeof(uint)));
                product = Sse4_1.min_epu32(product, MAX_VALUE);

                return (ushort)product.SInt0;
            }
            else
            {
                return (ushort)math.min(((ulong)cprodsaturated(x.v4_0) * cprodsaturated(x.v4_4)) * ((ulong)cprodsaturated(x.v4_8) * cprodsaturated(x.v4_12)), ushort.MaxValue); 
            }
        }


        /// <summary>       Returns the saturated horizontal product of components of an <see cref="int2"/>, so that the product is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprodsaturated(int2 x)
        {
            return mulsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="int3"/>, so that the product is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprodsaturated(int3 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), x.z);
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="int4"/>, so that the product is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprodsaturated(int4 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), mulsaturated(x.z, x.w));
        }

        /// <summary>       Returns the saturated horizontal product of components of an <see cref="MaxMath.int8"/>, so that the product is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprodsaturated(int8 x)
        {
            return mulsaturated(mulsaturated(mulsaturated(x.x0, x.x1), mulsaturated(x.x2, x.x3)), mulsaturated(mulsaturated(x.x4, x.x5), mulsaturated(x.x6, x.x7)));
        }


        /// <summary>       Returns the saturated horizontal product of components of a <see cref="uint2"/>, so that the product is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprodsaturated(uint2 x)
        {
            return mulsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="uint3"/>, so that the product is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprodsaturated(uint3 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), x.z);
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="uint4"/>, so that the product is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprodsaturated(uint4 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), mulsaturated(x.z, x.w));
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.uint8"/>, so that the product is clamped to <see cref="uint.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprodsaturated(uint8 x)
        {
            return mulsaturated(mulsaturated(mulsaturated(x.x0, x.x1), mulsaturated(x.x2, x.x3)), mulsaturated(mulsaturated(x.x4, x.x5), mulsaturated(x.x6, x.x7)));
        }


        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.long2"/>, so that the product is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprodsaturated(long2 x)
        {
            return mulsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.long3"/>, so that the product is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprodsaturated(long3 x)
        {
            return mulsaturated(mulsaturated(x.x, x.z), x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.long4"/>, so that the product is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprodsaturated(long4 x)
        {
            return mulsaturated(mulsaturated(x.x, x.z), mulsaturated(x.y, x.w));
        }


        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ulong2"/>, so that the product is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprodsaturated(ulong2 x)
        {
            return mulsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ulong3"/>, so that the product is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprodsaturated(ulong3 x)
        {
            return mulsaturated(mulsaturated(x.x, x.z), x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components of a <see cref="MaxMath.ulong4"/>, so that the product is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprodsaturated(ulong4 x)
        {
            return mulsaturated(mulsaturated(x.x, x.z), mulsaturated(x.y, x.w));
        }


        /// <summary>       Returns the saturated horizontal product of components ofa<see cref="float2"/>, so that the product is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprodsaturated(float2 x)
        {
            return mulsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components ofa<see cref="float3"/>, so that the product is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprodsaturated(float3 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), x.z);
        }

        /// <summary>       Returns the saturated horizontal product of components ofa<see cref="float4"/>, so that the product is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprodsaturated(float4 x)
        {
            double2 _0 = (double2)x.xy * (double2)x.zw;

            return (float)math.clamp(_0.x * _0.y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Returns the saturated horizontal productof components ofa<see cref="MaxMath.float8"/>, so that the productis clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprodsaturated(float8 x)
        {
            double4 _0 = (double4)x.v4_0 * (double4)x.v4_4;
            double2 _1 = _0.xy * _0.zw;

            return (float)math.clamp(_1.x * _1.y, float.MinValue, float.MaxValue);
        }


        //// <summary>       Returns the saturated horizontal product of components ofa<see cref="double2"/>, so that the product is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprodsaturated(double2 x)
        {
            return mulsaturated(x.x, x.y);
        }

        /// <summary>       Returns the saturated horizontal product of components ofa<see cref="double3"/>, so that the product is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprodsaturated(double3 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), x.z);
        }

        /// <summary>       Returns the saturated horizontal product of components ofa<see cref="double4"/>, so that the product is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprodsaturated(double4 x)
        {
            return mulsaturated(mulsaturated(x.x, x.y), mulsaturated(x.z, x.w));
        }
    }
}