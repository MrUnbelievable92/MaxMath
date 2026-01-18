using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        b = dec_epi8(b);

                        return andnot_si128(b, add_epi8(a, b));
                    }
                    else
                    {
                        return floormult_epu8(add_epi8(a, dec_epi8(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        b = dec_epi16(b);

                        return andnot_si128(b, add_epi16(a, b));
                    }
                    else
                    {
                        return floormult_epu16(add_epi16(a, dec_epi16(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        b = dec_epi32(b);

                        return andnot_si128(b, add_epi32(a, b));
                    }
                    else
                    {
                        return floormult_epu32(add_epi32(a, dec_epi32(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu64(v128 a, v128 b, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        b = dec_epi64(b);

                        return andnot_si128(b, add_epi64(a, b));
                    }
                    else
                    {
                        return floormult_epu64(add_epi64(a, dec_epi64(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        b = dec_epi8(b);

                        return andnot_si128(b, add_epi8(a, b));
                    }
                    else
                    {
                        return floormult_epi8(add_epi8(a, dec_epi8(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        b = dec_epi16(b);

                        return andnot_si128(b, add_epi16(a, b));
                    }
                    else
                    {
                        return floormult_epi16(add_epi16(a, dec_epi16(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        b = dec_epi32(b);

                        return andnot_si128(b, add_epi32(a, b));
                    }
                    else
                    {
                        return floormult_epi32(add_epi32(a, dec_epi32(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi64(v128 a, v128 b, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        b = dec_epi64(b);

                        return andnot_si128(b, add_epi64(a, b));
                    }
                    else
                    {
                        return floormult_epi64(add_epi64(a, dec_epi64(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        b = mm256_dec_epi8(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi8(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epu8(Avx2.mm256_add_epi8(a, mm256_dec_epi8(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        b = mm256_dec_epi16(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi16(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epu16(Avx2.mm256_add_epi16(a, mm256_dec_epi16(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        b = mm256_dec_epi32(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi32(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epu32(Avx2.mm256_add_epi32(a, mm256_dec_epi32(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        b = mm256_dec_epi64(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi64(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epu64(Avx2.mm256_add_epi64(a, mm256_dec_epi64(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        b = mm256_dec_epi8(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi8(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epi8(Avx2.mm256_add_epi8(a, mm256_dec_epi8(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        b = mm256_dec_epi16(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi16(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epi16(Avx2.mm256_add_epi16(a, mm256_dec_epi16(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        b = mm256_dec_epi32(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi32(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epi32(Avx2.mm256_add_epi32(a, mm256_dec_epi32(b)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        b = mm256_dec_epi64(b);

                        return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi64(a, b));
                    }
                    else
                    {
                        return mm256_floormult_epi64(Avx2.mm256_add_epi64(a, mm256_dec_epi64(b)), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_ps(b, ceil_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_ceil_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_pd(b, ceil_pd(div_pd(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_ceil_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceilmultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
                {
                    n--;

                    return andnot(x + n, n);
                }
            }

            return floormultiple(x + (n - 1), n, promises);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceilmultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
                {
                    n--;

                    return andnot(x + (Int128)n, (Int128)n);
                }
            }

            return floormultiple(x + (Int128)(n - 1), n, promises & Promise.Unsafe0);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceilmultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
                {
                    n--;

                    return andnot(x + n, n);
                }
            }

            return floormultiple(x + (n - 1), n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceilmultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu64(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceilmultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu64(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong3(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceilmultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu64(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong4(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceilmultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
                {
                    n--;

                    return andnot(x + (long)n, (long)n);
                }
            }

            return floormultiple(x + (long)(n - 1), n, promises & Promise.Unsafe0);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceilmultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi64(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new long2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceilmultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new long3(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceilmultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new long4(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceilmultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.ispow2(n)))
                {
                    n--;

                    return andnot(x + n, n);
                }
            }

            return floormultiple(x + (n - 1), n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceilmultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.ceilmult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceilmultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.ceilmult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceilmultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.ceilmult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceilmultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu32(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint8(ceilmultiple(x.v4_0, n.v4_0, promises), ceilmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceilmultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.ispow2(n)))
                {
                    n--;

                    return andnot(x + (int)n, (int)n);
                }
            }

            return floormultiple(x + (int)(n - 1), n, promises & Promise.Unsafe0);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceilmultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.ceilmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new int2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceilmultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.ceilmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new int3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceilmultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.ceilmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new int4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceilmultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi32(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new int8(ceilmultiple(x.v4_0, n.v4_0, promises), ceilmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceilmultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return (ushort)ceilmultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceilmultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceilmultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceilmultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceilmultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort8(ceilmultiple(x.x0, n.x0, promises),
                                   ceilmultiple(x.x1, n.x1, promises),
                                   ceilmultiple(x.x2, n.x2, promises),
                                   ceilmultiple(x.x3, n.x3, promises),
                                   ceilmultiple(x.x4, n.x4, promises),
                                   ceilmultiple(x.x5, n.x5, promises),
                                   ceilmultiple(x.x6, n.x6, promises),
                                   ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceilmultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu16(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort16(ceilmultiple(x.v8_0, n.v8_0, promises), ceilmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceilmultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)ceilmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceilmultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceilmultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceilmultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceilmultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short8(ceilmultiple(x.x0, n.x0, promises),
                                  ceilmultiple(x.x1, n.x1, promises),
                                  ceilmultiple(x.x2, n.x2, promises),
                                  ceilmultiple(x.x3, n.x3, promises),
                                  ceilmultiple(x.x4, n.x4, promises),
                                  ceilmultiple(x.x5, n.x5, promises),
                                  ceilmultiple(x.x6, n.x6, promises),
                                  ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceilmultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi16(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short16(ceilmultiple(x.v8_0, n.v8_0, promises), ceilmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceilmultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return (byte)ceilmultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceilmultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceilmultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceilmultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceilmultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte8(ceilmultiple(x.x0, n.x0, promises),
                                 ceilmultiple(x.x1, n.x1, promises),
                                 ceilmultiple(x.x2, n.x2, promises),
                                 ceilmultiple(x.x3, n.x3, promises),
                                 ceilmultiple(x.x4, n.x4, promises),
                                 ceilmultiple(x.x5, n.x5, promises),
                                 ceilmultiple(x.x6, n.x6, promises),
                                 ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceilmultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 16, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte16(ceilmultiple(x.x0,  n.x0,  promises),
                                  ceilmultiple(x.x1,  n.x1,  promises),
                                  ceilmultiple(x.x2,  n.x2,  promises),
                                  ceilmultiple(x.x3,  n.x3,  promises),
                                  ceilmultiple(x.x4,  n.x4,  promises),
                                  ceilmultiple(x.x5,  n.x5,  promises),
                                  ceilmultiple(x.x6,  n.x6,  promises),
                                  ceilmultiple(x.x7,  n.x7,  promises),
                                  ceilmultiple(x.x8,  n.x8,  promises),
                                  ceilmultiple(x.x9,  n.x9,  promises),
                                  ceilmultiple(x.x10, n.x10, promises),
                                  ceilmultiple(x.x11, n.x11, promises),
                                  ceilmultiple(x.x12, n.x12, promises),
                                  ceilmultiple(x.x13, n.x13, promises),
                                  ceilmultiple(x.x14, n.x14, promises),
                                  ceilmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceilmultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu8(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte32(ceilmultiple(x.v16_0, n.v16_0, promises), ceilmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceilmultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)ceilmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceilmultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new sbyte2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceilmultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new sbyte3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceilmultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new sbyte4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceilmultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new sbyte8(ceilmultiple(x.x0, n.x0, promises),
                                  ceilmultiple(x.x1, n.x1, promises),
                                  ceilmultiple(x.x2, n.x2, promises),
                                  ceilmultiple(x.x3, n.x3, promises),
                                  ceilmultiple(x.x4, n.x4, promises),
                                  ceilmultiple(x.x5, n.x5, promises),
                                  ceilmultiple(x.x6, n.x6, promises),
                                  ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceilmultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new sbyte16(ceilmultiple(x.x0,  n.x0,  promises),
                                   ceilmultiple(x.x1,  n.x1,  promises),
                                   ceilmultiple(x.x2,  n.x2,  promises),
                                   ceilmultiple(x.x3,  n.x3,  promises),
                                   ceilmultiple(x.x4,  n.x4,  promises),
                                   ceilmultiple(x.x5,  n.x5,  promises),
                                   ceilmultiple(x.x6,  n.x6,  promises),
                                   ceilmultiple(x.x7,  n.x7,  promises),
                                   ceilmultiple(x.x8,  n.x8,  promises),
                                   ceilmultiple(x.x9,  n.x9,  promises),
                                   ceilmultiple(x.x10, n.x10, promises),
                                   ceilmultiple(x.x11, n.x11, promises),
                                   ceilmultiple(x.x12, n.x12, promises),
                                   ceilmultiple(x.x13, n.x13, promises),
                                   ceilmultiple(x.x14, n.x14, promises),
                                   ceilmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceilmultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi8(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new sbyte32(ceilmultiple(x.v16_0, n.v16_0, promises), ceilmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ceilmultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * math.ceil(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ceilmultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.ceilmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new float2(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ceilmultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.ceilmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 3));
            }
            else
            {
                return new float3(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y), ceilmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ceilmultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.ceilmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 4));
            }
            else
            {
                return new float4(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y), ceilmultiple(x.z, m.z), ceilmultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceilmultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceilmult_ps(x, m);
            }
            else
            {
                return new float8(ceilmultiple(x.v4_0, m.v4_0), ceilmultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ceilmultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * math.ceil(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ceilmultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.ceilmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new double2(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ceilmultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_ceilmult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double3(ceilmultiple(x.xy, m.xy), ceilmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ceilmultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);

            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_ceilmult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double4(ceilmultiple(x.xy, m.xy), ceilmultiple(x.zw, m.zw));
            }
        }
    }
}