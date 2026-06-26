using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the fractional part of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float frac(float x)
        {
            return x - floor(x);
        }
        
        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 frac(float2 x)
        {
            return x - floor(x);
        }
        
        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.float3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 frac(float3 x)
        {
            return x - floor(x);
        }

        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 frac(float4 x)
        {
            return x - floor(x);
        }

        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 frac(float8 x)
        {
            return x - floor(x);
        }
        
        
        /// <summary>       Returns the fractional part of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double frac(double x)
        {
            return x - floor(x);
        }
        
        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 frac(double2 x)
        {
            return x - floor(x);
        }
        
        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.double3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 frac(double3 x)
        {
            return x - floor(x);
        }

        /// <summary>       Returns the componentwise fractional parts of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 frac(double4 x)
        {
            return x - floor(x);
        }


        /// <summary>       Performs a split of a <see cref="float"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float modf(float x, out float i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.float2"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 modf(float2 x, out float2 i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.float3"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 modf(float3 x, out float3 i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.float4"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 modf(float4 x, out float4 i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.float8"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 modf(float8 x, out float8 i)
        {
            return x - (i = trunc(x));
        }


        /// <summary>       Performs a split of a <see cref="double"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double modf(double x, out double i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.double2"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 modf(double2 x, out double2 i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.double3"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 modf(double3 x, out double3 i)
        {
            return x - (i = trunc(x));
        }

        /// <summary>       Performs a componentwise split of a <see cref="MaxMath.double4"/> into an integral part <paramref name="i"/> and a fractional part that gets returned. Both parts take the sign of the corresponding input component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 modf(double4 x, out double4 i)
        {
            return x - (i = trunc(x));
        }
    }
}