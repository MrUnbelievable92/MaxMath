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
            public static v128 roundmult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu8(add_epi8(a, srli_epi8(b, 1)), b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu16(add_epi16(a, srli_epi16(b, 1)), b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu32(add_epi32(a, srli_epi32(b, 1)), b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epu64(v128 a, v128 b, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu64(add_epi64(a, srli_epi64(b, 1)), b, pow2);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epi8(add_epi8(a, srli_epi8(b, 1)), b, elements, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epi16(add_epi16(a, srli_epi16(b, 1)), b, elements, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epi32(add_epi32(a, srli_epi32(b, 1)), b, elements, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi64(v128 a, v128 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epi64(add_epi64(a, srli_epi64(b, 1)), b, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu8(Avx2.mm256_add_epi8(a, mm256_srli_epi8(b, 1)), b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu16(Avx2.mm256_add_epi16(a, mm256_srli_epi16(b, 1)), b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu32(Avx2.mm256_add_epi32(a, mm256_srli_epi32(b, 1)), b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu64(Avx2.mm256_add_epi64(a, mm256_srli_epi64(b, 1)), b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi8(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epi8(Avx2.mm256_add_epi8(a, mm256_srli_epi8(b, 1)), b, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi16(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epi16(Avx2.mm256_add_epi16(a, mm256_srli_epi16(b, 1)), b, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi32(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epi32(Avx2.mm256_add_epi32(a, mm256_srli_epi32(b, 1)), b, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epi64(Avx2.mm256_add_epi64(a, mm256_srli_epi64(b, 1)), b, elements, pow2, nonNegative);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return mul_ps(b, round_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_round_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return mul_pd(b, round_pd(div_pd(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_round_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundmultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x + (n >> 1), n, promises);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundmultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x + (Int128)(n >> 1), n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundmultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x + (n >> 1), n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 roundmultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu64(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 roundmultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu64(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong3(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 roundmultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu64(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong4(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundmultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x + (long)(n >> 1), n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 roundmultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 roundmultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 roundmultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundmultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x + (n >> 1), n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 roundmultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.roundmult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 roundmultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.roundmult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 roundmultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.roundmult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 roundmultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu32(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint8(roundmultiple(x.v4_0, n.v4_0, promises), roundmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundmultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x + (int)(n >> 1), n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 roundmultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.roundmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 roundmultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.roundmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 roundmultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.roundmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 roundmultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(roundmultiple(x.v4_0, n.v4_0, promises), roundmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundmultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return (ushort)roundmultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 roundmultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 roundmultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 roundmultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 roundmultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort8(roundmultiple(x.x0, n.x0, promises),
                                   roundmultiple(x.x1, n.x1, promises),
                                   roundmultiple(x.x2, n.x2, promises),
                                   roundmultiple(x.x3, n.x3, promises),
                                   roundmultiple(x.x4, n.x4, promises),
                                   roundmultiple(x.x5, n.x5, promises),
                                   roundmultiple(x.x6, n.x6, promises),
                                   roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 roundmultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu16(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort16(roundmultiple(x.v8_0, n.v8_0, promises), roundmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundmultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)roundmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 roundmultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 roundmultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 roundmultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 roundmultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short8(roundmultiple(x.x0, n.x0, promises),
                                  roundmultiple(x.x1, n.x1, promises),
                                  roundmultiple(x.x2, n.x2, promises),
                                  roundmultiple(x.x3, n.x3, promises),
                                  roundmultiple(x.x4, n.x4, promises),
                                  roundmultiple(x.x5, n.x5, promises),
                                  roundmultiple(x.x6, n.x6, promises),
                                  roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 roundmultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(roundmultiple(x.v8_0, n.v8_0, promises), roundmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundmultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return (byte)roundmultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 roundmultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 roundmultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 roundmultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 roundmultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte8(roundmultiple(x.x0, n.x0, promises),
                                 roundmultiple(x.x1, n.x1, promises),
                                 roundmultiple(x.x2, n.x2, promises),
                                 roundmultiple(x.x3, n.x3, promises),
                                 roundmultiple(x.x4, n.x4, promises),
                                 roundmultiple(x.x5, n.x5, promises),
                                 roundmultiple(x.x6, n.x6, promises),
                                 roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 roundmultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 16, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte16(roundmultiple(x.x0,  n.x0,  promises),
                                  roundmultiple(x.x1,  n.x1,  promises),
                                  roundmultiple(x.x2,  n.x2,  promises),
                                  roundmultiple(x.x3,  n.x3,  promises),
                                  roundmultiple(x.x4,  n.x4,  promises),
                                  roundmultiple(x.x5,  n.x5,  promises),
                                  roundmultiple(x.x6,  n.x6,  promises),
                                  roundmultiple(x.x7,  n.x7,  promises),
                                  roundmultiple(x.x8,  n.x8,  promises),
                                  roundmultiple(x.x9,  n.x9,  promises),
                                  roundmultiple(x.x10, n.x10, promises),
                                  roundmultiple(x.x11, n.x11, promises),
                                  roundmultiple(x.x12, n.x12, promises),
                                  roundmultiple(x.x13, n.x13, promises),
                                  roundmultiple(x.x14, n.x14, promises),
                                  roundmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 roundmultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu8(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte32(roundmultiple(x.v16_0, n.v16_0, promises), roundmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundmultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)roundmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 roundmultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 roundmultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 roundmultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 roundmultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte8(roundmultiple(x.x0, n.x0, promises),
                                  roundmultiple(x.x1, n.x1, promises),
                                  roundmultiple(x.x2, n.x2, promises),
                                  roundmultiple(x.x3, n.x3, promises),
                                  roundmultiple(x.x4, n.x4, promises),
                                  roundmultiple(x.x5, n.x5, promises),
                                  roundmultiple(x.x6, n.x6, promises),
                                  roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 roundmultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte16(roundmultiple(x.x0,  n.x0,  promises),
                                   roundmultiple(x.x1,  n.x1,  promises),
                                   roundmultiple(x.x2,  n.x2,  promises),
                                   roundmultiple(x.x3,  n.x3,  promises),
                                   roundmultiple(x.x4,  n.x4,  promises),
                                   roundmultiple(x.x5,  n.x5,  promises),
                                   roundmultiple(x.x6,  n.x6,  promises),
                                   roundmultiple(x.x7,  n.x7,  promises),
                                   roundmultiple(x.x8,  n.x8,  promises),
                                   roundmultiple(x.x9,  n.x9,  promises),
                                   roundmultiple(x.x10, n.x10, promises),
                                   roundmultiple(x.x11, n.x11, promises),
                                   roundmultiple(x.x12, n.x12, promises),
                                   roundmultiple(x.x13, n.x13, promises),
                                   roundmultiple(x.x14, n.x14, promises),
                                   roundmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 roundmultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(roundmultiple(x.v16_0, n.v16_0, promises), roundmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float roundmultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * math.round(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 roundmultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.roundmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new float2(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 roundmultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.roundmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 3));
            }
            else
            {
                return new float3(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y), roundmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 roundmultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.roundmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 4));
            }
            else
            {
                return new float4(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y), roundmultiple(x.z, m.z), roundmultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 roundmultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_roundmult_ps(x, m);
            }
            else
            {
                return new float8(roundmultiple(x.v4_0, m.v4_0), roundmultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double roundmultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * math.round(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 roundmultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.roundmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new double2(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 roundmultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_roundmult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double3(roundmultiple(x.xy, m.xy), roundmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 roundmultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);
            
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_roundmult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double4(roundmultiple(x.xy, m.xy), roundmultiple(x.zw, m.zw));
            }
        }
    }
}