using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
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
            public static v128 usfcvtpd_epu64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = new v128(LIMIT_PRECISE_I32_F64);

                    return Sse2.xor_pd(Sse2.add_pd(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 usfcvttpd_epu64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return usfcvtpd_epu64(RegisterConversion.ToV128(math.trunc(RegisterConversion.ToType<double2>(a))));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_usfcvtpd_epu64(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(LIMIT_PRECISE_I32_F64);

                    return Avx.mm256_xor_pd(Avx.mm256_add_pd(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_usfcvttpd_epu64(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_usfcvtpd_epu64(Avx.mm256_round_pd(a, (int)RoundingMode.FROUND_TRUNC_NOEXC));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 usfcvtpd_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = new v128(0x4338_0000_0000_0000);

                    return Sse2.sub_epi64(Sse2.add_pd(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 usfcvttpd_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return usfcvtpd_epi64(RegisterConversion.ToV128(math.trunc(RegisterConversion.ToType<double2>(a))));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_usfcvtpd_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = new v256(0x4338_0000_0000_0000);

                    return Avx2.mm256_sub_epi64(Avx.mm256_add_pd(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_usfcvttpd_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_usfcvtpd_epi64(Avx.mm256_round_pd(a, (int)RoundingMode.FROUND_TRUNC_NOEXC));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 usfcvtepu64_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = new v128(LIMIT_PRECISE_I32_F64);
    
                    return Sse2.sub_pd(Sse2.or_si128(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_usfcvtepu64_pd(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(LIMIT_PRECISE_I32_F64);
    
                    return Avx.mm256_sub_pd(Avx.mm256_or_pd(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 usfcvtepi64_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = new v128(0x4338_0000_0000_0000);
    
                    return Sse2.sub_pd(Sse2.add_epi64(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_usfcvtepi64_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = new v256(0x4338_0000_0000_0000);
    
                    return Avx.mm256_sub_pd(Avx2.mm256_add_epi64(a, MASK), MASK);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Converts each value in a <see cref="double2"/> to its respective <see cref="ulong"/> representation.       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulongunsafe(double2 x, Promise promise = Promise.Unsafe0)
        {
            if (Sse2.IsSse2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return Xse.usfcvttpd_epu64(RegisterConversion.ToV128(x));
                }
                else
                {
                    return (ulong2)x;
                }
            }
            else
            {
                return (ulong2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its respective <see cref="ulong"/> representation.       </summary>
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="ulong.MinValue"/>, <see cref="long.MaxValue"/>]       </para>                    
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>             
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulongunsafe(double3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe1))
                {
                    return Xse.mm256_usfcvttpd_epu64(RegisterConversion.ToV256(x));
                }
                else
                {
                    return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(x), 3, promise.Promises(Promise.Unsafe0));
                }
            }
            else
            {
                return new ulong3(toulongunsafe(x.xy, promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing), (ulong)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its respective <see cref="ulong"/> representation.       </summary>
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="ulong.MinValue"/>, <see cref="long.MaxValue"/>]       </para>                    
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </para>                    
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulongunsafe(double4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe1))
                {
                    return Xse.mm256_usfcvttpd_epu64(RegisterConversion.ToV256(x));
                }
                else
                {
                    return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(x), 4, promise.Promises(Promise.Unsafe0));
                }
            }
            else
            {
                Promise downCast = promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing;

                return new ulong4(toulongunsafe(x.xy, downCast), toulongunsafe(x.zw, downCast));
            }
        }


        /// <summary>       Converts each value in a <see cref="double2"/> to its respective <see cref="long"/> representation       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolongunsafe(double2 x, Promise promise = Promise.Unsafe0)
        {
            if (Sse2.IsSse2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return Xse.usfcvttpd_epi64(RegisterConversion.ToV128(x));
                }
                else
                {
                    return (long2)x;
                }
            }
            else
            {
                return (long2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its respective <see cref="long"/> representation.       </summary>
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>]       </para>                    
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>                       
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolongunsafe(double3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe1))
                {
                    return Xse.mm256_usfcvttpd_epi64(RegisterConversion.ToV256(x));
                }
                else
                {
                    return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(x), 3, promise.Promises(Promise.Unsafe0));
                }
            }
            else
            {
                return new long3(tolongunsafe(x.xy, promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing), (long)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="double4"/> to its respective <see cref="long"/> representation.       </summary>
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [<see cref="long.MinValue"/>, <see cref="long.MaxValue"/>]       </para>                    
        ///     <para>      A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </para>                    
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolongunsafe(double4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe1))
                {
                    return Xse.mm256_usfcvttpd_epi64(RegisterConversion.ToV256(x));
                }
                else
                {
                    return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(x), 4, promise.Promises(Promise.Unsafe0));
                }
            }
            else
            {
                Promise downCast = promise.Promises(Promise.Unsafe1) ? Promise.Unsafe0 : Promise.Nothing;

                return new long4(tolongunsafe(x.xy, downCast), tolongunsafe(x.zw, downCast));
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its respective <see cref="double"/> representation.       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoubleunsafe(ulong2 x, Promise promise = Promise.Unsafe0)
        {
            if (Sse2.IsSse2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToType<double2>(Xse.usfcvtepu64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return (double2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its respective <see cref="double"/> representation.       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoubleunsafe(ulong3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToType<double3>(Xse.mm256_usfcvtepu64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), (double)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its respective <see cref="double"/> representation.       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 2⁵²)       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoubleunsafe(ulong4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToType<double4>(Xse.mm256_usfcvtepu64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }


        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its respective <see cref="double"/> representation       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todoubleunsafe(long2 x, Promise promise = Promise.Unsafe0)
        {
            if (Sse2.IsSse2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToType<double2>(Xse.usfcvtepi64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return (double2)x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its respective <see cref="double"/> representation.       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todoubleunsafe(long3 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToType<double3>(Xse.mm256_usfcvtepi64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double3(todoubleunsafe(x.xy, promise), (double)x.z);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its respective <see cref="double"/> representation.       </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="promise"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [-2⁵¹, 2⁵¹]       </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todoubleunsafe(long4 x, Promise promise = Promise.Unsafe0)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (promise.Promises(Promise.Unsafe0))
                {
                    return RegisterConversion.ToType<double4>(Xse.mm256_usfcvtepi64_pd(x));
                }
                else
                {
                    return x;
                }
            }
            else
            {
                return new double4(todoubleunsafe(x.xy, promise), todoubleunsafe(x.zw, promise));
            }
        }
    }
}
