using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.quarter"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(quarter q)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF
                && (q.value & 0b0111_1111) == 0b0111_0000;
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.quarter"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(quarter q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF
                || (q.value & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.quarter"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(quarter q)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN
                && (q.value & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isinf(quarter2 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isfinite(quarter2 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isnan(quarter2 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isinf(quarter3 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isfinite(quarter3 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isnan(quarter3 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isinf(quarter4 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isfinite(quarter4 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isnan(quarter4 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isinf(quarter8 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isfinite(quarter8 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isnan(quarter8 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.quarter16"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isinf(quarter16 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.quarter16"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isfinite(quarter16 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.quarter16"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isnan(quarter16 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool32"/> indicating for each component of a <see cref="MaxMath.quarter32"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isinf(quarter32 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool32"/> indicating for each component of a <see cref="MaxMath.quarter32"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isfinite(quarter32 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool32"/> indicating for each component of a <see cref="MaxMath.quarter32"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isnan(quarter32 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.half"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(half h)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF
                && (h.value & 0x7FFF) == 0x7C00;
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.half"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(half h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF
                || (h.value & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.half"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(half h)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN
                && (h.value & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.half2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isinf(half2 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.half2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isfinite(half2 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.half2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isnan(half2 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.half3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isinf(half3 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.half3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isfinite(half3 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.half3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isnan(half3 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.half4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isinf(half4 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.half4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isfinite(half4 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.half4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isnan(half4 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.half8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isinf(half8 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.half8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isfinite(half8 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.half8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isnan(half8 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.half16"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isinf(half16 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.half16"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isfinite(half16 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool16"/> indicating for each component of a <see cref="MaxMath.half16"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isnan(half16 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.float"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(float f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF && Unity.Mathematics.math.isinf(f);
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.float"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(float f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF || Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.float"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(float f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN && Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.float2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isinf(float2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.float2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isfinite(float2 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.float2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isnan(float2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.float3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isinf(float3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.float3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isfinite(float3 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.float3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isnan(float3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.float4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isinf(float4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.float4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isfinite(float4 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.float4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isnan(float4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isinf(float8 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asint(f) << 1) == (asint(float.PositiveInfinity) << 1);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isfinite(float8 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : abs(f) < float.PositiveInfinity;
        }

        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isnan(float8 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asint(f) & bitmask32(31)) > 0x7F80_0000;
        }

        
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.double"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(double f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF && Unity.Mathematics.math.isinf(f);
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.double"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(double f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF || Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="MaxMath.double"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(double f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN && Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.double2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isinf(double2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.double2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isfinite(double2 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool2"/> indicating for each component of a <see cref="MaxMath.double2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isnan(double2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.double3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isinf(double3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.double3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isfinite(double3 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool3"/> indicating for each component of a <see cref="MaxMath.double3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isnan(double3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.double4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isinf(double4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.double4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isfinite(double4 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="MaxMath.bool4"/> indicating for each component of a <see cref="MaxMath.double4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isnan(double4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }
    }
}