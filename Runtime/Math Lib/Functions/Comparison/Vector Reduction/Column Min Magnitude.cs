using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal minimum of an <see cref="MaxMath.sbyte2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cminmag(sbyte2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 2);

                return Xse.minmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of an <see cref="MaxMath.sbyte3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cminmag(sbyte3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 3);

                return Xse.minmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of an <see cref="MaxMath.sbyte4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cminmag(sbyte4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 4);

                return Xse.minmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of an <see cref="MaxMath.sbyte8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cminmag(sbyte8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 8);

                return Xse.minmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of an <see cref="MaxMath.sbyte16"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cminmag(sbyte16 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(c, out v128 min, out v128 max, 16);

                return Xse.minmag_epi8(min, max).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of an <see cref="MaxMath.sbyte32"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cminmag(sbyte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi8(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi8(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1)); 
                v128 max128 = Xse.max_epi8(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1)); 

                return Xse.minmag_epi8(min128, max128, 2).SByte0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 min = Xse.vmin_epi8(Xse.min_epi8(c.v16_0, c.v16_16), 16);
                v128 max = Xse.vmax_epi8(Xse.max_epi8(c.v16_0, c.v16_16), 16);

                return Xse.minmag_epi8(min, max, 2).SByte0;
            }
            else
            {
                cminmax(c, out sbyte min, out sbyte max);

                return minmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.short2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cminmag(short2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 2);

                return Xse.minmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.short3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cminmag(short3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 3);

                return Xse.minmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.short4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cminmag(short4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 4);

                return Xse.minmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.short8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cminmag(short8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(c, out v128 min, out v128 max, 8);

                return Xse.minmag_epi16(min, max, 1).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.short16"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cminmag(short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi16(c, out v256 min, out v256 max);

                v128 min128 = Sse2.min_epi16(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1)); 
                v128 max128 = Sse2.max_epi16(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1)); 

                return Xse.minmag_epi16(min128, max128).SShort0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 min = Xse.vmin_epi16(Sse2.min_epi16(c.v8_0, c.v8_8), 8);
                v128 max = Xse.vmax_epi16(Sse2.max_epi16(c.v8_0, c.v8_8), 8);

                return Xse.minmag_epi16(min, max).SShort0;
            }
            else
            {
                cminmax(c, out short min, out short max);

                return minmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.int2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminmag(int2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 2);
                
                return Xse.minmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0; 
            }
            else
            {
                cminmax(c, out int min, out int max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.int3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminmag(int3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 3);
                
                return Xse.minmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0; 
            }
            else
            {
                cminmax(c, out int min, out int max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.int4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminmag(int4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(c), out v128 min, out v128 max, 4);
                
                return Xse.minmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0; 
            }
            else
            {
                cminmax(c, out int min, out int max);

                return minmag(min, max);
            }
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.int8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any cmin(<paramref name="c"/>) + cmax(<paramref name="c"/>) that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminmag(int8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi32(c, out v256 min, out v256 max);

                v128 min128 = Xse.min_epi32(Avx.mm256_castsi256_si128(min), Avx2.mm256_extracti128_si256(min, 1)); 
                v128 max128 = Xse.max_epi32(Avx.mm256_castsi256_si128(max), Avx2.mm256_extracti128_si256(max, 1)); 
                
                return Xse.minmag_epi32(min128, max128, noOverflow.Promises(Promise.NoOverflow), 2).SInt0; 
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 min = Xse.vmin_epi32(Xse.min_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), 4);
                v128 max = Xse.vmax_epi32(Xse.max_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), 4);
                
                return Xse.minmag_epi32(min, max, noOverflow.Promises(Promise.NoOverflow), 2).SInt0; 
            }
            else
            {
                cminmax(c, out int min, out int max);

                return minmag(min, max);
            }
        }


        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.long2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cminmag(long2 c)
        {
            cminmax(c, out long min, out long max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.long3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cminmag(long3 c)
        {
            cminmax(c, out long min, out long max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.long4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cminmag(long4 c)
        {
            cminmax(c, out long min, out long max);
            
            return minmag(min, max);
        }


        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.float2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cminmag(float2 c)
        {
            cminmax(c, out float min, out float max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.float3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cminmag(float3 c)
        {
            cminmax(c, out float min, out float max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.float4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cminmag(float4 c)
        {
            cminmax(c, out float min, out float max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.float8"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cminmag(float8 c)
        {
            cminmax(c, out float min, out float max);
            
            return minmag(min, max);
        }


        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.double2"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cminmag(double2 c)
        {
            cminmax(c, out double min, out double max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.double3"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cminmag(double3 c)
        {
            cminmax(c, out double min, out double max);
            
            return minmag(min, max);
        }

        /// <summary>       Returns the horizontal minimum of a <see cref="MaxMath.double4"/> with regard to magnitude. If abs(cmin(<paramref name="c"/>)) is equal to abs(cmax(<paramref name="c"/>)), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cminmag(double4 c)
        {
            cminmax(c, out double min, out double max);
            
            return minmag(min, max);
        }
    }
}
