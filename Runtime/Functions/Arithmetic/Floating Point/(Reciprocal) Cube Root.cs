using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    // https://www.mdpi.com/1996-1073/14/4/1058/htm

    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the cube root of a <see cref="float"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cbrt(float x, bool handleNegativeInput = false)
        {
            uint sign = 0;
            uint bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            float y = math.asfloat(0x548C_2B4B - bits / 3);
            float c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            float d = x * y * y;
            c = 1.0f - d * y;
            y = d * (1.0f + (1f / 3f) * c);

            // additional NR
            y = ((2f / 3f) * y) + (((1f / 3f) * x) / (y * y));

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cbrt(float2 x, bool handleNegativeInput = false)
        {
            uint2 sign = 0;
            uint2 bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint2 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            float2 y = math.asfloat(0x548C_2B4B - bits / 3);
            float2 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            float2 d = x * y * y;
            c = 1.0f - d * y;
            y = d * (1.0f + (1f / 3f) * c);

            // additional NR
            y = ((2f / 3f) * y) + (((1f / 3f) * x) / (y * y));

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cbrt(float3 x, bool handleNegativeInput = false)
        {
            uint3 sign = 0;
            uint3 bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint3 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            float3 y = math.asfloat(0x548C_2B4B - bits / 3);
            float3 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            float3 d = x * y * y;
            c = 1.0f - d * y;
            y = d * (1.0f + (1f / 3f) * c);

            // additional NR
            y = ((2f / 3f) * y) + (((1f / 3f) * x) / (y * y));

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cbrt(float4 x, bool handleNegativeInput = false)
        {
            uint4 sign = 0;
            uint4 bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint4 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            float4 y = math.asfloat(0x548C_2B4B - bits / 3);
            float4 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            float4 d = x * y * y;
            c = 1.0f - d * y;
            y = d * (1.0f + (1f / 3f) * c);

            // additional NR
            y = ((2f / 3f) * y) + (((1f / 3f) * x) / (y * y));

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="MaxMath.float8"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cbrt(float8 x, bool handleNegativeInput = false)
        {
            uint8 sign = 0;
            uint8 bits = asuint(x);
        
            if (handleNegativeInput)
            {
                uint8 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asfloat(bits);
            }
        
            float8 y = asfloat(0x548C_2B4B - bits / 3);
            float8 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            float8 d = x * y * y;
            c = 1.0f - d * y;
            y = d * (1.0f + (1f / 3f) * c);

            // additional NR
            y = ((2f / 3f) * y) + (((1f / 3f) * x) / (y * y));

            if (handleNegativeInput)
            {
                y = asfloat(sign | asuint(y));
            }
        
            return y;
        }


        /// <summary>       Returns the reciprocal cube root of a <see cref="float"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float rcbrt(float x, bool handleNegativeInput = false)
        {
            uint sign = 0;
            uint bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            // this function is faster yet less precise
        
            //float y = math.asfloat(0x548C_39CB - math.asint(x) / 3);
            //y *= 1.5015480449f - 0.534850249f * (x * y) * (y * y);
            //y *= 1.333333985f - 0.33333333f * (x * y) * (y * y);
        
            float y = math.asfloat(0x548C_2B4B - bits / 3);
            float c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            c = 1.0f - (x * y) * (y * y);
            y *= 1.0f + 0.3333333333f * c;

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 rcbrt(float2 x, bool handleNegativeInput = false)
        {
            uint2 sign = 0;
            uint2 bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint2 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            // this function is faster yet less precise
        
            //float y = math.asfloat(0x548C_39CB - math.asint(x) / 3);
            //y *= 1.5015480449f - 0.534850249f * (x * y) * (y * y);
            //y *= 1.333333985f - 0.33333333f * (x * y) * (y * y);
        
            float2 y = math.asfloat(0x548C_2B4B - bits / 3);
            float2 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            c = 1.0f - (x * y) * (y * y);
            y *= 1.0f + 0.3333333333f * c;

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rcbrt(float3 x, bool handleNegativeInput = false)
        {
            uint3 sign = 0;
            uint3 bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint3 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            // this function is faster yet less precise
        
            //float3 y = math.asfloat(0x548C_39CB - math.asint(x) / 3);
            //y *= 1.5015480449f - 0.534850249f * (x * y) * (y * y);
            //y *= 1.333333985f - 0.33333333f * (x * y) * (y * y);
        
            float3 y = math.asfloat(0x548C_2B4B - bits / 3);
            float3 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            c = 1.0f - (x * y) * (y * y);
            y *= 1.0f + 0.3333333333f * c;

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rcbrt(float4 x, bool handleNegativeInput = false)
        {
            uint4 sign = 0;
            uint4 bits = math.asuint(x);
        
            if (handleNegativeInput)
            {
                uint4 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asfloat(bits);
            }
        
            // this function is faster yet less precise
        
            //float4 y = math.asfloat(0x548C_39CB - math.asint(x) / 3);
            //y *= 1.5015480449f - 0.534850249f * (x * y) * (y * y);
            //y *= 1.333333985f - 0.33333333f * (x * y) * (y * y);
        
            float4 y = math.asfloat(0x548C_2B4B - bits / 3);
            float4 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            c = 1.0f - (x * y) * (y * y);
            y *= 1.0f + 0.3333333333f * c;

            if (handleNegativeInput)
            {
                y = math.asfloat(sign | math.asuint(y));
            }
        
            return y;
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="MaxMath.float8"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcbrt(float8 x, bool handleNegativeInput = false)
        {
            uint8 sign = 0;
            uint8 bits = asuint(x);
        
            if (handleNegativeInput)
            {
                uint8 SIGN_MASK = 0x8000_0000; 
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asfloat(bits);
            }
        
            // this function is faster yet less precise
        
            //float y = math.asfloat(0x548C_39CB - math.asint(x) / 3);
            //y *= 1.5015480449f - 0.534850249f * (x * y) * (y * y);
            //y *= 1.333333985f - 0.33333333f * (x * y) * (y * y);
        
            float8 y = asfloat(0x548C_2B4B - bits / 3);
            float8 c = (x * y) * (y * y);
            y *= 1.752319676f - c * (1.2509524245f - 0.5093818292f * c);
            c = 1.0f - (x * y) * (y * y);
            y *= 1.0f + 0.3333333333f * c;

            if (handleNegativeInput)
            {
                y = asfloat(sign | asuint(y));
            }
        
            return y;
        }


        /// <summary>       Returns the cube root of a <see cref="double"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cbrt(double x, bool handleNegativeInput = false)
        {
            ulong sign = 0;
        
            if (handleNegativeInput)
            {
                ulong SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong bits = math.asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asdouble(bits);
            }

            double _cbrt = math.pow(x, 1d / 3d);

            if (handleNegativeInput)
            {
                _cbrt = math.asdouble(sign | math.asulong(_cbrt));
            }
        
            return _cbrt;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cbrt(double2 x, bool handleNegativeInput = false)
        {
            ulong2 sign = 0;
        
            if (handleNegativeInput)
            {
                ulong2 SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong2 bits = asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asdouble(bits);
            }

            double2 _cbrt = math.pow(x, 1d / 3d);

            if (handleNegativeInput)
            {
                _cbrt = asdouble(sign | asulong(_cbrt));
            }
        
            return _cbrt;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cbrt(double3 x, bool handleNegativeInput = false)
        {
            ulong3 sign = 0;
        
            if (handleNegativeInput)
            {
                ulong3 SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong3 bits = asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asdouble(bits);
            }

            double3 _cbrt = math.pow(x, 1d / 3d);

            if (handleNegativeInput)
            {
                _cbrt = asdouble(sign | asulong(_cbrt));
            }
        
            return _cbrt;
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cbrt(double4 x, bool handleNegativeInput = false)
        {
            ulong4 sign = 0;
        
            if (handleNegativeInput)
            {
                ulong4 SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong4 bits = asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asdouble(bits);
            }

            double4 _cbrt = math.pow(x, 1d / 3d);

            if (handleNegativeInput)
            {
                _cbrt = asdouble(sign | asulong(_cbrt));
            }
        
            return _cbrt;
        }

        
        /// <summary>       Returns the reciprocal cube root of a <see cref="double"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double rcbrt(double x, bool handleNegativeInput = false)
        {
            ulong sign = 0;
        
            if (handleNegativeInput)
            {
                ulong SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong bits = math.asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = math.asdouble(bits);
            }

            double _rcbrt = math.pow(x, -1d / 3d);

            if (handleNegativeInput)
            {
                _rcbrt = math.asdouble(sign | math.asulong(_rcbrt));
            }
        
            return _rcbrt;
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double2"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 rcbrt(double2 x, bool handleNegativeInput = false)
        {
            ulong2 sign = 0;
        
            if (handleNegativeInput)
            {
                ulong2 SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong2 bits = asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asdouble(bits);
            }

            double2 _rcbrt = math.pow(x, -1d / 3d);

            if (handleNegativeInput)
            {
                _rcbrt = asdouble(sign | asulong(_rcbrt));
            }
        
            return _rcbrt;
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double3"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 rcbrt(double3 x, bool handleNegativeInput = false)
        {
            ulong3 sign = 0;
        
            if (handleNegativeInput)
            {
                ulong3 SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong3 bits = asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asdouble(bits);
            }

            double3 _rcbrt = math.pow(x, -1d / 3d);

            if (handleNegativeInput)
            {
                _rcbrt = asdouble(sign | asulong(_rcbrt));
            }
        
            return _rcbrt;
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double4"/>. If <paramref name="handleNegativeInput"/> is set to <see langword="true" />, the result is correct for negative input values.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 rcbrt(double4 x, bool handleNegativeInput = false)
        {
            ulong4 sign = 0;
        
            if (handleNegativeInput)
            {
                ulong4 SIGN_MASK = 0x8000_0000_0000_0000; 
                ulong4 bits = asulong(x);
                sign = bits & SIGN_MASK;
                bits = andnot(bits, SIGN_MASK);
                x = asdouble(bits);
            }

            double4 _rcbrt = math.pow(x, -1d / 3d);

            if (handleNegativeInput)
            {
                _rcbrt = asdouble(sign | asulong(_rcbrt));
            }
        
            return _rcbrt;
        }
    }
}