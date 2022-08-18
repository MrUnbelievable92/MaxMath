using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of an <see cref="MaxMath.sbyte2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(sbyte2 c, [NoAlias] out sbyte cminmag, [NoAlias] out sbyte cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 2);
                Xse.minmaxmag_epi8(min, max, out min, out max, 2);

                cminmag = min.SByte0;
                cmaxmag = max.SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of an <see cref="MaxMath.sbyte3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(sbyte3 c, [NoAlias] out sbyte cminmag, [NoAlias] out sbyte cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 3);
                Xse.minmaxmag_epi8(min, max, out min, out max, 2);

                cminmag = min.SByte0;
                cmaxmag = max.SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of an <see cref="MaxMath.sbyte4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(sbyte4 c, [NoAlias] out sbyte cminmag, [NoAlias] out sbyte cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 4);
                Xse.minmaxmag_epi8(min, max, out min, out max, 2);

                cminmag = min.SByte0;
                cmaxmag = max.SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of an <see cref="MaxMath.sbyte8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(sbyte8 c, [NoAlias] out sbyte cminmag, [NoAlias] out sbyte cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 8);
                Xse.minmaxmag_epi8(min, max, out min, out max, 2);

                cminmag = min.SByte0;
                cmaxmag = max.SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of an <see cref="MaxMath.sbyte16"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(sbyte16 c, [NoAlias] out sbyte cminmag, [NoAlias] out sbyte cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 16);
                Xse.minmaxmag_epi8(min, max, out min, out max, 2);

                cminmag = min.SByte0;
                cmaxmag = max.SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of an <see cref="MaxMath.sbyte32"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(sbyte32 c, [NoAlias] out sbyte cminmag, [NoAlias] out sbyte cmaxmag)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi8(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi8(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1)); 
                v128 max128 = Xse.max_epi8(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1)); 
                
                Xse.minmaxmag_epi8(min128, max128, out min128, out max128, 2);

                cminmag = min128.SByte0;
                cmaxmag = max128.SByte0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 min = Xse.vmin_epi8(Xse.min_epi8(c.v16_0, c.v16_16), 16);
                v128 max = Xse.vmax_epi8(Xse.max_epi8(c.v16_0, c.v16_16), 16);

                Xse.minmaxmag_epi8(min, max, out min, out max, 2);

                cminmag = min.SByte0;
                cmaxmag = max.SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.short2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(short2 c, [NoAlias] out short cminmag, [NoAlias] out short cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 2);
                Xse.minmaxmag_epi16(min, max, out min, out max);

                cminmag = min.SShort0;
                cmaxmag = max.SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.short3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(short3 c, [NoAlias] out short cminmag, [NoAlias] out short cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 3);
                Xse.minmaxmag_epi16(min, max, out min, out max);

                cminmag = min.SShort0;
                cmaxmag = max.SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.short4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(short4 c, [NoAlias] out short cminmag, [NoAlias] out short cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 4);
                Xse.minmaxmag_epi16(min, max, out min, out max);

                cminmag = min.SShort0;
                cmaxmag = max.SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.short8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(short8 c, [NoAlias] out short cminmag, [NoAlias] out short cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 8);
                Xse.minmaxmag_epi16(min, max, out min, out max);

                cminmag = min.SShort0;
                cmaxmag = max.SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.short16"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(short16 c, [NoAlias] out short cminmag, [NoAlias] out short cmaxmag)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi16(c, out v256 min, out v256 max);

                v128 min128 = Sse2.min_epi16(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1)); 
                v128 max128 = Sse2.max_epi16(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1)); 
                
                Xse.minmaxmag_epi16(min128, max128, out min128, out max128);

                cminmag = min128.SShort0;
                cmaxmag = max128.SShort0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 min = Xse.vmin_epi16(Sse2.min_epi16(c.v8_0, c.v8_8), 8);
                v128 max = Xse.vmax_epi16(Sse2.max_epi16(c.v8_0, c.v8_8), 8);
                Xse.minmaxmag_epi16(min, max, out min, out max);

                cminmag = min.SShort0;
                cmaxmag = max.SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.int2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(int2 c, [NoAlias] out int cminmag, [NoAlias] out int cmaxmag, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 2);
                Xse.minmaxmag_epi32(min, max, out min, out max, noOverflow.Promises(Promise.NoOverflow), 2);

                cminmag = min.SInt0;
                cmaxmag = max.SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.int3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(int3 c, [NoAlias] out int cminmag, [NoAlias] out int cmaxmag, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 3);
                Xse.minmaxmag_epi32(min, max, out min, out max, noOverflow.Promises(Promise.NoOverflow), 2);

                cminmag = min.SInt0;
                cmaxmag = max.SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.int4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(int4 c, [NoAlias] out int cminmag, [NoAlias] out int cmaxmag, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 4);
                Xse.minmaxmag_epi32(min, max, out min, out max, noOverflow.Promises(Promise.NoOverflow), 2);

                cminmag = min.SInt0;
                cmaxmag = max.SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.int8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(int8 c, [NoAlias] out int cminmag, [NoAlias] out int cmaxmag, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi32(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi32(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1)); 
                v128 max128 = Xse.max_epi32(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1)); 
                Xse.minmaxmag_epi32(min128, max128, out min128, out max128, noOverflow.Promises(Promise.NoOverflow), 2);

                cminmag = min128.SInt0;
                cmaxmag = max128.SInt0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 min = Xse.vmin_epi32(Xse.min_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), 4);
                v128 max = Xse.vmax_epi32(Xse.max_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), 4);
                Xse.minmaxmag_epi32(min, max, out min, out max, noOverflow.Promises(Promise.NoOverflow), 2);

                cminmag = min.SInt0;
                cmaxmag = max.SInt0;
            }
            else
            {
                cminmax(c, out int min, out int max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.long2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(long2 c, [NoAlias] out long cminmag, [NoAlias] out long cmaxmag)
        {
            cminmax(c, out long min, out long max);
            
            cminmag = minmag(min, max);
            cmaxmag = maxmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.long3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(long3 c, [NoAlias] out long cminmag, [NoAlias] out long cmaxmag)
        {
            cminmax(c, out long min, out long max);
            
            cminmag = minmag(min, max);
            cmaxmag = maxmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.long4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(long4 c, [NoAlias] out long cminmag, [NoAlias] out long cmaxmag)
        {
            cminmax(c, out long min, out long max);
            
            cminmag = minmag(min, max);
            cmaxmag = maxmag(min, max);
        }


        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.float2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(float2 c, [NoAlias] out float cminmag, [NoAlias] out float cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(c), out v128 min, out v128 max, 2);
                Xse.minmaxmag_ps(min, max, out min, out max);

                cminmag = min.Float0;
                cmaxmag = max.Float0;
            }
            else
            {
                cminmax(c, out float min, out float max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.float3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(float3 c, [NoAlias] out float cminmag, [NoAlias] out float cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(c), out v128 min, out v128 max, 3);
                Xse.minmaxmag_ps(min, max, out min, out max);

                cminmag = min.Float0;
                cmaxmag = max.Float0;
            }
            else
            {
                cminmax(c, out float min, out float max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.float4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(float4 c, [NoAlias] out float cminmag, [NoAlias] out float cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(c), out v128 min, out v128 max, 4);
                Xse.minmaxmag_ps(min, max, out min, out max);

                cminmag = min.Float0;
                cmaxmag = max.Float0;
            }
            else
            {
                cminmax(c, out float min, out float max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.float8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(float8 c, [NoAlias] out float cminmag, [NoAlias] out float cmaxmag)
        {
            cminmax(c, out float min, out float max);
            
            cminmag = minmag(min, max);
            cmaxmag = maxmag(min, max);
        }


        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.double2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(double2 c, [NoAlias] out double cminmag, [NoAlias] out double cmaxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_pd(RegisterConversion.ToV128(c), out v128 min, out v128 max);
                Xse.minmaxmag_pd(min, max, out min, out max);

                cminmag = min.Double0;
                cmaxmag = max.Double0;
            }
            else
            {
                cminmax(c, out double min, out double max);

                cminmag = minmag(min, max);
                cmaxmag = maxmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.double3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(double3 c, [NoAlias] out double cminmag, [NoAlias] out double cmaxmag)
        {
            cminmax(c, out double min, out double max);
            
            cminmag = minmag(min, max);
            cmaxmag = maxmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum <paramref name="cminmag"/> and the horizontal maximum <paramref name="cmaxmag"/> of a <see cref="MaxMath.double4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the cmaxmag = value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmaxmag(double4 c, [NoAlias] out double cminmag, [NoAlias] out double cmaxmag)
        {
            cminmax(c, out double min, out double max);
            
            cminmag = minmag(min, max);
            cmaxmag = maxmag(min, max);
        }
    }
}
