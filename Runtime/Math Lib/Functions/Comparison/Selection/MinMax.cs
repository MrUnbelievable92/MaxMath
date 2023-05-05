using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi8(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max, byte elements = 16)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    min = Sse4_1.min_epi8(b, a);
                    max = Sse4_1.max_epi8(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements))
                    {
                        min = Sse2.min_epu8(a, b);
                        max = Sse2.max_epu8(a, b);
                    }
                    else
                    {
                        v128 cmp = Sse2.cmpgt_epi8(b, a);
                        min = blendv_si128(b, a, cmp); 
                        max = blendv_si128(a, b, cmp); 
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi16(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse2.IsSse2Supported)
                {
                    min = Sse2.min_epi16(b, a);
                    max = Sse2.max_epi16(b, a);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi32(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    min = Sse4_1.min_epi32(b, a);
                    max = Sse4_1.max_epi32(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 cmp = Sse2.cmpgt_epi32(b, a);
                    min = blendv_si128(b, a, cmp); 
                    max = blendv_si128(a, b, cmp); 
                }
                else throw new IllegalInstructionException();
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi64(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = cmpgt_epi64(b, a);
                    min = blendv_si128(b, a, cmp); 
                    max = blendv_si128(a, b, cmp); 
                }
                else throw new IllegalInstructionException();
            }
            
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epi8(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx2.IsAvx2Supported)
                {
                    min = Avx2.mm256_min_epi8(a, b);
                    max = Avx2.mm256_max_epi8(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epi16(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx2.IsAvx2Supported)
                {
                    min = Avx2.mm256_min_epi16(a, b);
                    max = Avx2.mm256_max_epi16(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epi32(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx2.IsAvx2Supported)
                {
                    min = Avx2.mm256_min_epi32(a, b);
                    max = Avx2.mm256_max_epi32(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epi64(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = mm256_cmpgt_epi64(b, a, elements);
                    min = mm256_blendv_si256(b, a, cmp); 
                    max = mm256_blendv_si256(a, b, cmp); 
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epu8(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse2.IsSse2Supported)
                {
                    min = Sse2.min_epu8(b, a);
                    max = Sse2.max_epu8(b, a);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epu16(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max, byte elements = 8)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    min = Sse4_1.min_epu16(b, a);
                    max = Sse4_1.max_epu16(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                    {
                        min = Sse2.min_epi16(a, b);
                        max = Sse2.max_epi16(a, b);
                    }
                    else
                    {
                        v128 cmp = cmpgt_epu16(b, a);
                        min = blendv_si128(b, a, cmp);
                        max = blendv_si128(a, b, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epu32(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max, byte elements = 4)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    min = Sse4_1.min_epu32(b, a);
                    max = Sse4_1.max_epu32(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 cmp = cmpgt_epu32(b, a);
                    min = blendv_si128(b, a, cmp);
                    max = blendv_si128(a, b, cmp);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epu64(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = cmpgt_epu64(b, a);
                    min = blendv_si128(b, a, cmp);
                    max = blendv_si128(a, b, cmp);
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epu8(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx2.IsAvx2Supported)
                {
                    min = Avx2.mm256_min_epu8(a, b);
                    max = Avx2.mm256_max_epu8(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epu16(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx2.IsAvx2Supported)
                {
                    min = Avx2.mm256_min_epu16(a, b);
                    max = Avx2.mm256_max_epu16(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epu32(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    min = Avx2.mm256_min_epu32(a, b);
                    max = Avx2.mm256_max_epu32(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_epu64(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = mm256_cmpgt_epu64(b, a, elements);
                    min = mm256_blendv_si256(b, a, cmp); 
                    max = mm256_blendv_si256(a, b, cmp); 
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_ps(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse.IsSseSupported)
                {
                    min = Sse.min_ps(b, a);
                    max = Sse.max_ps(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_pd(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Sse2.IsSse2Supported)
                {
                    min = Sse2.min_pd(b, a);
                    max = Sse2.max_pd(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_ps(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx.IsAvxSupported)
                {
                    min = Avx.mm256_min_ps(b, a);
                    max = Avx.mm256_max_ps(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmax_pd(v256 a, v256 b, [NoAlias] out v256 min, [NoAlias] out v256 max)
            {
                if (Avx.IsAvxSupported)
                {
                    min = Avx.mm256_min_pd(b, a);
                    max = Avx.mm256_max_pd(a, b);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte2 a, byte2 b, [NoAlias] out byte2 min, [NoAlias] out byte2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte3 a, byte3 b, [NoAlias] out byte3 min, [NoAlias] out byte3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte4 a, byte4 b, [NoAlias] out byte4 min, [NoAlias] out byte4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte8 a, byte8 b, [NoAlias] out byte8 min, [NoAlias] out byte8 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte16 a, byte16 b, [NoAlias] out byte16 min, [NoAlias] out byte16 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte32 a, byte32 b, [NoAlias] out byte32 min, [NoAlias] out byte32 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epu8(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v16_0,  b.v16_0,  out byte16 minLo, out byte16 maxLo);
                minmax(a.v16_16, b.v16_16, out byte16 minHi, out byte16 maxHi);

                min = new byte32(minLo, minHi);
                max = new byte32(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte2 a, sbyte2 b, [NoAlias] out sbyte2 min, [NoAlias] out sbyte2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte3 a, sbyte3 b, [NoAlias] out sbyte3 min, [NoAlias] out sbyte3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte4 a, sbyte4 b, [NoAlias] out sbyte4 min, [NoAlias] out sbyte4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte8 a, sbyte8 b, [NoAlias] out sbyte8 min, [NoAlias] out sbyte8 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte16 a, sbyte16 b, [NoAlias] out sbyte16 min, [NoAlias] out sbyte16 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte32 a, sbyte32 b, [NoAlias] out sbyte32 min, [NoAlias] out sbyte32 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epi8(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v16_0,  b.v16_0,  out sbyte16 minLo, out sbyte16 maxLo);
                minmax(a.v16_16, b.v16_16, out sbyte16 minHi, out sbyte16 maxHi);

                min = new sbyte32(minLo, minHi);
                max = new sbyte32(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort2 a, ushort2 b, [NoAlias] out ushort2 min, [NoAlias] out ushort2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 2);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort3 a, ushort3 b, [NoAlias] out ushort3 min, [NoAlias] out ushort3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 3);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort4 a, ushort4 b, [NoAlias] out ushort4 min, [NoAlias] out ushort4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 4);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort8 a, ushort8 b, [NoAlias] out ushort8 min, [NoAlias] out ushort8 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 8);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort16 a, ushort16 b, [NoAlias] out ushort16 min, [NoAlias] out ushort16 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epu16(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v8_0, b.v8_0, out ushort8 minLo, out ushort8 maxLo);
                minmax(a.v8_8, b.v8_8, out ushort8 minHi, out ushort8 maxHi);

                min = new ushort16(minLo, minHi);
                max = new ushort16(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short2 a, short2 b, [NoAlias] out short2 min, [NoAlias] out short2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short3 a, short3 b, [NoAlias] out short3 min, [NoAlias] out short3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short4 a, short4 b, [NoAlias] out short4 min, [NoAlias] out short4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short8 a, short8 b, [NoAlias] out short8 min, [NoAlias] out short8 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short16 a, short16 b, [NoAlias] out short16 min, [NoAlias] out short16 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epi16(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v8_0, b.v8_0, out short8 minLo, out short8 maxLo);
                minmax(a.v8_8, b.v8_8, out short8 minHi, out short8 maxHi);

                min = new short16(minLo, minHi);
                max = new short16(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int2 a, int2 b, [NoAlias] out int2 min, [NoAlias] out int2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToInt2(_min);
                max = RegisterConversion.ToInt2(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int3 a, int3 b, [NoAlias] out int3 min, [NoAlias] out int3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToInt3(_min);
                max = RegisterConversion.ToInt3(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int4 a, int4 b, [NoAlias] out int4 min, [NoAlias] out int4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToInt4(_min);
                max = RegisterConversion.ToInt4(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int8 a, int8 b, [NoAlias] out int8 min, [NoAlias] out int8 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epi32(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v4_0, b.v4_0, out int4 minLo, out int4 maxLo);
                minmax(a.v4_4, b.v4_4, out int4 minHi, out int4 maxHi);

                min = new int8(minLo, minHi);
                max = new int8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint2 a, uint2 b, [NoAlias] out uint2 min, [NoAlias] out uint2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToUInt2(_min);
                max = RegisterConversion.ToUInt2(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint3 a, uint3 b, [NoAlias] out uint3 min, [NoAlias] out uint3 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToUInt3(_min);
                max = RegisterConversion.ToUInt3(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint4 a, uint4 b, [NoAlias] out uint4 min, [NoAlias] out uint4 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToUInt4(_min);
                max = RegisterConversion.ToUInt4(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint8 a, uint8 b, [NoAlias] out uint8 min, [NoAlias] out uint8 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epu32(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v4_0, b.v4_0, out uint4 minLo, out uint4 maxLo);
                minmax(a.v4_4, b.v4_4, out uint4 minHi, out uint4 maxHi);

                min = new uint8(minLo, minHi);
                max = new uint8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ulong2 a, ulong2 b, [NoAlias] out ulong2 min, [NoAlias] out ulong2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epu64(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ulong3 a, ulong3 b, [NoAlias] out ulong3 min, [NoAlias] out ulong3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epu64(a, b, out v256 _min, out v256 _max, 3);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.xy, b.xy, out ulong2 minxy, out ulong2 maxxy);
                min = new ulong3(minxy, math.min(a.z, b.z));
                max = new ulong3(maxxy, math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ulong4 a, ulong4 b, [NoAlias] out ulong4 min, [NoAlias] out ulong4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epu64(a, b, out v256 _min, out v256 _max, 4);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.xy, b.xy, out ulong2 minxy, out ulong2 maxxy);
                minmax(a.zw, b.zw, out ulong2 minzw, out ulong2 maxzw);
                min = new ulong4(minxy, minzw);
                max = new ulong4(maxxy, maxzw);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(long2 a, long2 b, [NoAlias] out long2 min, [NoAlias] out long2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_epi64(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                min = maxmath.min(a, b);
                max = maxmath.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(long3 a, long3 b, [NoAlias] out long3 min, [NoAlias] out long3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epi64(a, b, out v256 _min, out v256 _max, 3);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.xy, b.xy, out long2 minxy, out long2 maxxy);
                min = new long3(minxy, math.min(a.z, b.z));
                max = new long3(maxxy, math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(long4 a, long4 b, [NoAlias] out long4 min, [NoAlias] out long4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmax_epi64(a, b, out v256 _min, out v256 _max, 4);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.xy, b.xy, out long2 minxy, out long2 maxxy);
                minmax(a.zw, b.zw, out long2 minzw, out long2 maxzw);
                min = new long4(minxy, minzw);
                max = new long4(maxxy, maxzw);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float2 a, float2 b, [NoAlias] out float2 min, [NoAlias] out float2 max)
        {
            if (Sse.IsSseSupported)
            {
                Xse.minmax_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToFloat2(_min);
                max = RegisterConversion.ToFloat2(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float3 a, float3 b, [NoAlias] out float3 min, [NoAlias] out float3 max)
        {
            if (Sse.IsSseSupported)
            {
                Xse.minmax_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToFloat3(_min);
                max = RegisterConversion.ToFloat3(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float4 a, float4 b, [NoAlias] out float4 min, [NoAlias] out float4 max)
        {
            if (Sse.IsSseSupported)
            {
                Xse.minmax_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToFloat4(_min);
                max = RegisterConversion.ToFloat4(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float8 a, float8 b, [NoAlias] out float8 min, [NoAlias] out float8 max)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmax_ps(a, b, out v256 _min, out v256 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.v4_0, b.v4_0, out float4 minLo, out float4 maxLo);
                minmax(a.v4_4, b.v4_4, out float4 minHi, out float4 maxHi);

                min = new float8(minLo, minHi);
                max = new float8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(double2 a, double2 b, [NoAlias] out double2 min, [NoAlias] out double2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmax_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToDouble2(_min);
                max = RegisterConversion.ToDouble2(_max);
            }
            else
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="double3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(double3 a, double3 b, [NoAlias] out double3 min, [NoAlias] out double3 max)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmax_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), out v256 _min, out v256 _max);
                min = RegisterConversion.ToDouble3(_min);
                max = RegisterConversion.ToDouble3(_max);
            }
            else
            {
                minmax(a.xy, b.xy, out double2 minxy, out double2 maxxy);
                min = new double3(minxy, math.min(a.z, b.z));
                max = new double3(maxxy, math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="double4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(double4 a, double4 b, [NoAlias] out double4 min, [NoAlias] out double4 max)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmax_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), out v256 _min, out v256 _max);
                min = RegisterConversion.ToDouble4(_min);
                max = RegisterConversion.ToDouble4(_max);
            }
            else
            {
                minmax(a.xy, b.xy, out double2 minxy, out double2 maxxy);
                minmax(a.zw, b.zw, out double2 minzw, out double2 maxzw);
                min = new double4(minxy, minzw);
                max = new double4(maxxy, maxzw);
            }
        }
    }
}