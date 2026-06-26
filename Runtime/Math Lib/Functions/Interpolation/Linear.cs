using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the result of linearly interpolating from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lerp(float x, float y, float s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 lerp(float2 x, float2 y, float2 s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 lerp(float3 x, float3 y, float3 s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 lerp(float4 x, float4 y, float4 s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 x, float8 y, float8 s)
        {
            return mad(s, y - x, x);
        }
        

        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 lerp(float2 x, float2 y, float s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 lerp(float3 x, float3 y, float s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 lerp(float4 x, float4 y, float s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lerp(float8 x, float8 y, float s)
        {
            return mad(s, y - x, x);
        }
        

        /// <summary>       Returns the result of linearly interpolating from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lerp(double x, double y, double s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 lerp(double2 x, double2 y, double2 s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 lerp(double3 x, double3 y, double3 s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the corresponding components of the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 lerp(double4 x, double4 y, double4 s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        

        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 lerp(double2 x, double2 y, double s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 lerp(double3 x, double3 y, double s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        
        /// <summary>       Returns the result of a componentwise linear interpolation from <paramref name="x"/> to <paramref name="y"/> using the interpolation parameter <paramref name="s"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 lerp(double4 x, double4 y, double s)
        {
            return Unity.Mathematics.math.lerp(x, y, s);
        }
        

        /// <summary>       Returns the result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float unlerp(float a, float b, float x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 unlerp(float2 a, float2 b, float2 x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 unlerp(float3 a, float3 b, float3 x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 unlerp(float4 a, float4 b, float4 x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 unlerp(float8 a, float8 b, float8 x)
        {
            return (x - a) / (b - a);
        }
        

        /// <summary>       Returns the result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double unlerp(double a, double b, double x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 unlerp(double2 a, double2 b, double2 x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 unlerp(double3 a, double3 b, double3 x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }

        /// <summary>       Returns the componentwise result of normalizing a floating point value <paramref name="x"/> to a range [<paramref name="a"/>, <paramref name="b"/>]. The opposite of <see cref="lerp"/>. Equivalent to <see langword="("/><paramref name="x"/> <see langword="-"/> <paramref name="a"/><see langword=")"/> <see langword="/"/> <see langword="("/><paramref name="b"/> <see langword="-"/> <paramref name="a"/><see langword=")"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 unlerp(double4 a, double4 b, double4 x)
        {
            return Unity.Mathematics.math.unlerp(a, b, x);
        }


        ///<summary>        Returns the result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float remap(float a, float b, float c, float d, float x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 remap(float2 a, float2 b, float2 c, float2 d, float2 x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 remap(float3 a, float3 b, float3 c, float3 d, float3 x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 remap(float4 a, float4 b, float4 c, float4 d, float4 x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 remap(float8 a, float8 b, float8 c, float8 d, float8 x)
        {
            return lerp(c, d, unlerp(a, b, x));
        }


        ///<summary>        Returns the result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double remap(double a, double b, double c, double d, double x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 remap(double2 a, double2 b, double2 c, double2 d, double2 x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 remap(double3 a, double3 b, double3 c, double3 d, double3 x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }

        ///<summary>        Returns the componentwise result of a non-clamping linear remapping of a value <paramref name="x"/> from [<paramref name="a"/>, <paramref name="b"/>] to [<paramref name="c"/>, <paramref name="d"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 remap(double4 a, double4 b, double4 c, double4 d, double4 x)
        {
            return Unity.Mathematics.math.remap(a, b, c, d, x);
        }
    }
}