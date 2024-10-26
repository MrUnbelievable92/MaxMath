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
                if (Architecture.IsMinMaxSupported)
                {
                    min = min_epi8(b, a);
                    max = max_epi8(b, a);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements))
                    {
                        min = min_epu8(a, b);
                        max = max_epu8(a, b);
                    }
                    else
                    {
                        v128 cmp = cmpgt_epi8(b, a);
                        min = blendv_si128(b, a, cmp);
                        max = blendv_si128(a, b, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi16(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Architecture.IsSIMDSupported)
                {
                    min = min_epi16(b, a);
                    max = max_epi16(b, a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi32(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Architecture.IsMinMaxSupported)
                {
                    min = min_epi32(b, a);
                    max = max_epi32(b, a);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = cmpgt_epi32(b, a);
                    min = blendv_si128(b, a, cmp);
                    max = blendv_si128(a, b, cmp);
                }
                else throw new IllegalInstructionException();
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epi64(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Architecture.IsSIMDSupported)
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
                if (Architecture.IsSIMDSupported)
                {
                    min = min_epu8(b, a);
                    max = max_epu8(b, a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_epu16(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max, byte elements = 8)
            {
                if (Architecture.IsMinMaxSupported)
                {
                    min = min_epu16(b, a);
                    max = max_epu16(b, a);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                    {
                        min = min_epi16(a, b);
                        max = max_epi16(a, b);
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
                if (Architecture.IsMinMaxSupported)
                {
                    min = min_epu32(b, a);
                    max = max_epu32(b, a);
                }
                else if (Architecture.IsSIMDSupported)
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
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = cmpgt_epu64(b, a);
                    min = blendv_si128(b, a, cmp);
                    max = blendv_si128(a, b, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_pq(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max, bool noNaNs = false, bool noZeros = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = cmplt_pq(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros, elements: elements);
                    min = blendv_si128(b, a, cmp);
                    max = blendv_si128(a, b, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_ph(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max, bool noNaNs = false, bool noZeros = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = cmplt_ph(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros, elements: elements);
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
                if (Architecture.IsSIMDSupported)
                {
                    min = min_ps(b, a);
                    max = max_ps(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmax_pd(v128 a, v128 b, [NoAlias] out v128 min, [NoAlias] out v128 max)
            {
                if (Architecture.IsSIMDSupported)
                {
                    min = min_pd(b, a);
                    max = max_pd(a, b);
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
        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(UInt128 a, UInt128 b, [NoAlias] out UInt128 min, [NoAlias] out UInt128 max)
        {
            bool aLTb = a < b;

            min = select(b, a, aLTb);
            max = select(a, b, aLTb);
        }

        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(Int128 a, Int128 b, [NoAlias] out Int128 min, [NoAlias] out Int128 max)
        {
            bool aLTb = a < b;

            min = select(b, a, aLTb);
            max = select(a, b, aLTb);
        }


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte a, byte b, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte2 a, byte2 b, [NoAlias] out byte2 min, [NoAlias] out byte2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte3 a, byte3 b, [NoAlias] out byte3 min, [NoAlias] out byte3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte4 a, byte4 b, [NoAlias] out byte4 min, [NoAlias] out byte4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte8 a, byte8 b, [NoAlias] out byte8 min, [NoAlias] out byte8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0, b.x0, out min.x0, out max.x0);
                minmax(a.x1, b.x1, out min.x1, out max.x1);
                minmax(a.x2, b.x2, out min.x2, out max.x2);
                minmax(a.x3, b.x3, out min.x3, out max.x3);
                minmax(a.x4, b.x4, out min.x4, out max.x4);
                minmax(a.x5, b.x5, out min.x5, out max.x5);
                minmax(a.x6, b.x6, out min.x6, out max.x6);
                minmax(a.x7, b.x7, out min.x7, out max.x7);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(byte16 a, byte16 b, [NoAlias] out byte16 min, [NoAlias] out byte16 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0,  b.x0,  out min.x0,  out max.x0);
                minmax(a.x1,  b.x1,  out min.x1,  out max.x1);
                minmax(a.x2,  b.x2,  out min.x2,  out max.x2);
                minmax(a.x3,  b.x3,  out min.x3,  out max.x3);
                minmax(a.x4,  b.x4,  out min.x4,  out max.x4);
                minmax(a.x5,  b.x5,  out min.x5,  out max.x5);
                minmax(a.x6,  b.x6,  out min.x6,  out max.x6);
                minmax(a.x7,  b.x7,  out min.x7,  out max.x7);
                minmax(a.x8,  b.x8,  out min.x8,  out max.x8);
                minmax(a.x9,  b.x9,  out min.x9,  out max.x9);
                minmax(a.x10, b.x10, out min.x10, out max.x10);
                minmax(a.x11, b.x11, out min.x11, out max.x11);
                minmax(a.x12, b.x12, out min.x12, out max.x12);
                minmax(a.x13, b.x13, out min.x13, out max.x13);
                minmax(a.x14, b.x14, out min.x14, out max.x14);
                minmax(a.x15, b.x15, out min.x15, out max.x15);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte a, sbyte b, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte2 a, sbyte2 b, [NoAlias] out sbyte2 min, [NoAlias] out sbyte2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte3 a, sbyte3 b, [NoAlias] out sbyte3 min, [NoAlias] out sbyte3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte4 a, sbyte4 b, [NoAlias] out sbyte4 min, [NoAlias] out sbyte4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte8 a, sbyte8 b, [NoAlias] out sbyte8 min, [NoAlias] out sbyte8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0, b.x0, out min.x0, out max.x0);
                minmax(a.x1, b.x1, out min.x1, out max.x1);
                minmax(a.x2, b.x2, out min.x2, out max.x2);
                minmax(a.x3, b.x3, out min.x3, out max.x3);
                minmax(a.x4, b.x4, out min.x4, out max.x4);
                minmax(a.x5, b.x5, out min.x5, out max.x5);
                minmax(a.x6, b.x6, out min.x6, out max.x6);
                minmax(a.x7, b.x7, out min.x7, out max.x7);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(sbyte16 a, sbyte16 b, [NoAlias] out sbyte16 min, [NoAlias] out sbyte16 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi8(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0,  b.x0,  out min.x0,  out max.x0);
                minmax(a.x1,  b.x1,  out min.x1,  out max.x1);
                minmax(a.x2,  b.x2,  out min.x2,  out max.x2);
                minmax(a.x3,  b.x3,  out min.x3,  out max.x3);
                minmax(a.x4,  b.x4,  out min.x4,  out max.x4);
                minmax(a.x5,  b.x5,  out min.x5,  out max.x5);
                minmax(a.x6,  b.x6,  out min.x6,  out max.x6);
                minmax(a.x7,  b.x7,  out min.x7,  out max.x7);
                minmax(a.x8,  b.x8,  out min.x8,  out max.x8);
                minmax(a.x9,  b.x9,  out min.x9,  out max.x9);
                minmax(a.x10, b.x10, out min.x10, out max.x10);
                minmax(a.x11, b.x11, out min.x11, out max.x11);
                minmax(a.x12, b.x12, out min.x12, out max.x12);
                minmax(a.x13, b.x13, out min.x13, out max.x13);
                minmax(a.x14, b.x14, out min.x14, out max.x14);
                minmax(a.x15, b.x15, out min.x15, out max.x15);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort a, ushort b, [NoAlias] out ushort min, [NoAlias] out ushort max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort2 a, ushort2 b, [NoAlias] out ushort2 min, [NoAlias] out ushort2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 2);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort3 a, ushort3 b, [NoAlias] out ushort3 min, [NoAlias] out ushort3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 3);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort4 a, ushort4 b, [NoAlias] out ushort4 min, [NoAlias] out ushort4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 4);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ushort8 a, ushort8 b, [NoAlias] out ushort8 min, [NoAlias] out ushort8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu16(a, b, out v128 _min, out v128 _max, 8);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0, b.x0, out min.x0, out max.x0);
                minmax(a.x1, b.x1, out min.x1, out max.x1);
                minmax(a.x2, b.x2, out min.x2, out max.x2);
                minmax(a.x3, b.x3, out min.x3, out max.x3);
                minmax(a.x4, b.x4, out min.x4, out max.x4);
                minmax(a.x5, b.x5, out min.x5, out max.x5);
                minmax(a.x6, b.x6, out min.x6, out max.x6);
                minmax(a.x7, b.x7, out min.x7, out max.x7);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short a, short b, [NoAlias] out short min, [NoAlias] out short max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short2 a, short2 b, [NoAlias] out short2 min, [NoAlias] out short2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short3 a, short3 b, [NoAlias] out short3 min, [NoAlias] out short3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short4 a, short4 b, [NoAlias] out short4 min, [NoAlias] out short4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(short8 a, short8 b, [NoAlias] out short8 min, [NoAlias] out short8 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi16(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0, b.x0, out min.x0, out max.x0);
                minmax(a.x1, b.x1, out min.x1, out max.x1);
                minmax(a.x2, b.x2, out min.x2, out max.x2);
                minmax(a.x3, b.x3, out min.x3, out max.x3);
                minmax(a.x4, b.x4, out min.x4, out max.x4);
                minmax(a.x5, b.x5, out min.x5, out max.x5);
                minmax(a.x6, b.x6, out min.x6, out max.x6);
                minmax(a.x7, b.x7, out min.x7, out max.x7);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int a, int b, [NoAlias] out int min, [NoAlias] out int max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int2 a, int2 b, [NoAlias] out int2 min, [NoAlias] out int2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToInt2(_min);
                max = RegisterConversion.ToInt2(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int3 a, int3 b, [NoAlias] out int3 min, [NoAlias] out int3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToInt3(_min);
                max = RegisterConversion.ToInt3(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(int4 a, int4 b, [NoAlias] out int4 min, [NoAlias] out int4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToInt4(_min);
                max = RegisterConversion.ToInt4(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint a, uint b, [NoAlias] out uint min, [NoAlias] out uint max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint2 a, uint2 b, [NoAlias] out uint2 min, [NoAlias] out uint2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToUInt2(_min);
                max = RegisterConversion.ToUInt2(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint3 a, uint3 b, [NoAlias] out uint3 min, [NoAlias] out uint3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToUInt3(_min);
                max = RegisterConversion.ToUInt3(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(uint4 a, uint4 b, [NoAlias] out uint4 min, [NoAlias] out uint4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToUInt4(_min);
                max = RegisterConversion.ToUInt4(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="ulong"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ulong a, ulong b, [NoAlias] out ulong min, [NoAlias] out ulong max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(ulong2 a, ulong2 b, [NoAlias] out ulong2 min, [NoAlias] out ulong2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epu64(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
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
                minmax(a.z, b.z, out ulong minz, out ulong maxz);
                min = new ulong3(minxy, minz);
                max = new ulong3(maxxy, maxz);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="ulong"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(long a, long b, [NoAlias] out long min, [NoAlias] out long max)
        {
            bool aLTb = a < b;

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(long2 a, long2 b, [NoAlias] out long2 min, [NoAlias] out long2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_epi64(a, b, out v128 _min, out v128 _max);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
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
                minmax(a.z, b.z, out long minz, out long maxz);
                min = new long3(minxy, minz);
                max = new long3(maxxy, maxz);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float a, float b, [NoAlias] out float min, [NoAlias] out float max)
        {
            if (Architecture.IsSIMDSupported)
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
            else
            {
                bool aLTb = a < b;

                min = aLTb ? a : b;
                max = aLTb ? b : a;
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float2 a, float2 b, [NoAlias] out float2 min, [NoAlias] out float2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToFloat2(_min);
                max = RegisterConversion.ToFloat2(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float3 a, float3 b, [NoAlias] out float3 min, [NoAlias] out float3 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToFloat3(_min);
                max = RegisterConversion.ToFloat3(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(float4 a, float4 b, [NoAlias] out float4 min, [NoAlias] out float4 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToFloat4(_min);
                max = RegisterConversion.ToFloat4(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="double"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(double a, double b, [NoAlias] out double min, [NoAlias] out double max)
        {
            if (Architecture.IsSIMDSupported)
            {
                min = math.min(a, b);
                max = math.max(a, b);
            }
            else
            {
                bool aLTb = a < b;

                min = aLTb ? a : b;
                max = aLTb ? b : a;
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(double2 a, double2 b, [NoAlias] out double2 min, [NoAlias] out double2 max)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max);
                min = RegisterConversion.ToDouble2(_min);
                max = RegisterConversion.ToDouble2(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
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
                minmax(a.z, b.z, out double minz, out double maxz);
                min = new double3(minxy, minz);
                max = new double3(maxxy, maxz);
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


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="quarter"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(quarter a, quarter b, [NoAlias] out quarter min, [NoAlias] out quarter max, Promise promises = Promise.Nothing)
        {
            bool aLTb = a.IsLessThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero));

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.quarter2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(quarter2 a, quarter2 b, [NoAlias] out quarter2 min, [NoAlias] out quarter2 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_pq(a, b, out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 2);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.quarter3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(quarter3 a, quarter3 b, [NoAlias] out quarter3 min, [NoAlias] out quarter3 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_pq(a, b, out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 3);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.quarter4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(quarter4 a, quarter4 b, [NoAlias] out quarter4 min, [NoAlias] out quarter4 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_pq(a, b, out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 4);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.quarter8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(quarter8 a, quarter8 b, [NoAlias] out quarter8 min, [NoAlias] out quarter8 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_pq(a, b, out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 8);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0, b.x0, out min.x0, out max.x0);
                minmax(a.x1, b.x1, out min.x1, out max.x1);
                minmax(a.x2, b.x2, out min.x2, out max.x2);
                minmax(a.x3, b.x3, out min.x3, out max.x3);
                minmax(a.x4, b.x4, out min.x4, out max.x4);
                minmax(a.x5, b.x5, out min.x5, out max.x5);
                minmax(a.x6, b.x6, out min.x6, out max.x6);
                minmax(a.x7, b.x7, out min.x7, out max.x7);
            }
        }


        /// <summary>       Returns the minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="half"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(half a, half b, [NoAlias] out half min, [NoAlias] out half max, Promise promises = Promise.Nothing)
        {
            bool aLTb = a.IsLessThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero));

            min = aLTb ? a : b;
            max = aLTb ? b : a;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="half2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(half2 a, half2 b, [NoAlias] out half2 min, [NoAlias] out half2 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ph(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 2);
                min = RegisterConversion.ToHalf2(_min);
                max = RegisterConversion.ToHalf2(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="half3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(half3 a, half3 b, [NoAlias] out half3 min, [NoAlias] out half3 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ph(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 3);
                min = RegisterConversion.ToHalf3(_min);
                max = RegisterConversion.ToHalf3(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="half4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(half4 a, half4 b, [NoAlias] out half4 min, [NoAlias] out half4 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ph(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 4);
                min = RegisterConversion.ToHalf4(_min);
                max = RegisterConversion.ToHalf4(_max);
            }
            else
            {
                minmax(a.x, b.x, out min.x, out max.x);
                minmax(a.y, b.y, out min.y, out max.y);
                minmax(a.z, b.z, out min.z, out max.z);
                minmax(a.w, b.w, out min.w, out max.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.half8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmax(half8 a, half8 b, [NoAlias] out half8 min, [NoAlias] out half8 max, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmax_ph(a, b, out v128 _min, out v128 _max, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 8);
                min = _min;
                max = _max;
            }
            else
            {
                minmax(a.x0, b.x0, out min.x0, out max.x0);
                minmax(a.x1, b.x1, out min.x1, out max.x1);
                minmax(a.x2, b.x2, out min.x2, out max.x2);
                minmax(a.x3, b.x3, out min.x3, out max.x3);
                minmax(a.x4, b.x4, out min.x4, out max.x4);
                minmax(a.x5, b.x5, out min.x5, out max.x5);
                minmax(a.x6, b.x6, out min.x6, out max.x6);
                minmax(a.x7, b.x7, out min.x7, out max.x7);
            }
        }
    }
}