using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal maximum of an <see cref="MaxMath.sbyte2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmaxmag(sbyte2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 2);

                return Xse.maxmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of an <see cref="MaxMath.sbyte3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmaxmag(sbyte3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 3);

                return Xse.maxmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of an <see cref="MaxMath.sbyte4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmaxmag(sbyte4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 4);

                return Xse.maxmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of an <see cref="MaxMath.sbyte8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmaxmag(sbyte8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 8);

                return Xse.maxmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of an <see cref="MaxMath.sbyte16"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmaxmag(sbyte16 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 16);

                return Xse.maxmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of an <see cref="MaxMath.sbyte32"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmaxmag(sbyte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi8(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi8(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1));
                v128 max128 = Xse.max_epi8(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1));

                return Xse.maxmag_epi8(min128, max128, 2).SByte0;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 min = Xse.vmin_epi8(Xse.min_epi8(c.v16_0, c.v16_16), 16);
                v128 max = Xse.vmax_epi8(Xse.max_epi8(c.v16_0, c.v16_16), 16);

                return Xse.maxmag_epi8(min, max, 2).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return maxmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.short2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmaxmag(short2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 2);

                return Xse.maxmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.short3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmaxmag(short3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 3);

                return Xse.maxmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.short4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmaxmag(short4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 4);

                return Xse.maxmag_epi16(min, max, 2).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.short8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmaxmag(short8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 8);

                return Xse.maxmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.short16"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmaxmag(short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi16(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi16(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1));
                v128 max128 = Xse.max_epi16(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1));

                return Xse.maxmag_epi16(min128, max128, 1).SShort0;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 min = Xse.vmin_epi16(Xse.min_epi16(c.v8_0, c.v8_8), 8);
                v128 max = Xse.vmax_epi16(Xse.max_epi16(c.v8_0, c.v8_8), 8);

                return Xse.maxmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return maxmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal maximum of a <see cref="int2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmaxmag(int2 c, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 2);

                return Xse.maxmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="int3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmaxmag(int3 c, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 3);

                return Xse.maxmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="int4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmaxmag(int4 c, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 4);

                return Xse.maxmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.int8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmaxmag(int8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi32(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi32(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1));
                v128 max128 = Xse.max_epi32(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1));

                return Xse.maxmag_epi32(min128, max128, noOverflow.Promises(Promise.NoOverflow), 2).SInt0;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 min = Xse.vmin_epi32(Xse.min_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), 4);
                v128 max = Xse.vmax_epi32(Xse.max_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), 4);

                return Xse.maxmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                return maxmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.long2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmaxmag(long2 c)
        {
            cminmax(c, out long min, out long max);

            return maxmag(min, max);
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.long3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmaxmag(long3 c)
        {
            cminmax(c, out long min, out long max);

            return maxmag(min, max);
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.long4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmaxmag(long4 c)
        {
            cminmax(c, out long min, out long max);

            return maxmag(min, max);
        }


        /// <summary>       Returns the horizontal maximum of a <see cref="float2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmaxmag(float2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(c), out v128 min, out v128 max, 2);

                return Xse.maxmag_ps(min, max).Float0;
            }
            else
            {
                cminmax(c, out float min, out float max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="float3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmaxmag(float3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(c), out v128 min, out v128 max, 3);

                return Xse.maxmag_ps(min, max).Float0;
            }
            else
            {
                cminmax(c, out float min, out float max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="float4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmaxmag(float4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(c), out v128 min, out v128 max, 4);

                return Xse.maxmag_ps(min, max).Float0;
            }
            else
            {
                cminmax(c, out float min, out float max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="MaxMath.float8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmaxmag(float8 c)
        {
            cminmax(c, out float min, out float max);

            return maxmag(min, max);
        }


        /// <summary>       Returns the horizontal maximum of a <see cref="double2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cmaxmag(double2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.vminmax_pd(RegisterConversion.ToV128(c), out v128 min, out v128 max);

                return Xse.maxmag_pd(min, max).Double0;
            }
            else
            {
                cminmax(c, out double min, out double max);

                return maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="double3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cmaxmag(double3 c)
        {
            cminmax(c, out double min, out double max);

            return maxmag(min, max);
        }

        /// <summary>       Returns the horizontal maximum of a <see cref="double4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cmaxmag(double4 c)
        {
            cminmax(c, out double min, out double max);

            return maxmag(min, max);
        }
    }
}
