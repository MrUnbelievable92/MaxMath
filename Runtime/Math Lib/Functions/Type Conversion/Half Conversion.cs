using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the floating point representation of a half-precision floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float f16tof32(ushort x)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return Unity.Mathematics.math.f16tof32(x);
            }
            else
            {
                return (float)ashalf(x);
            }
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 f16tof32(ushort2 x)
        {
            return (float2)ashalf(x);
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 f16tof32(ushort3 x)
        {
            return (float3)ashalf(x);
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 f16tof32(ushort4 x)
        {
            return (float4)ashalf(x);
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 f16tof32(ushort8 x)
        {
            return (float8)ashalf(x);
        }


        /// <summary>       Returns the floating point representation of a half-precision floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float f16tof32(short x) => f16tof32((ushort)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 f16tof32(short2 x) => f16tof32((ushort2)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 f16tof32(short3 x) => f16tof32((ushort3)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 f16tof32(short4 x) => f16tof32((ushort4)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 f16tof32(short8 x) => f16tof32((ushort8)x);


        /// <summary>       Returns the floating point representation of a half-precision floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float f16tof32(uint x)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return Unity.Mathematics.math.f16tof32(x);
            }
            else
            {
                return (float)ashalf((ushort)x);
            }
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 f16tof32(uint2 x)
        {
            return (float2)ashalf((ushort2)x);
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 f16tof32(uint3 x)
        {
            return (float3)ashalf((ushort3)x);
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 f16tof32(uint4 x)
        {
            return (float4)ashalf((ushort4)x);
        }

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 f16tof32(uint8 x)
        {
            return (float8)ashalf((ushort8)x);
        }


        /// <summary>       Returns the floating point representation of a half-precision floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float f16tof32(int x) => f16tof32((uint)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 f16tof32(int2 x) => f16tof32((uint2)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 f16tof32(int3 x) => f16tof32((uint3)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 f16tof32(int4 x) => f16tof32((uint4)x);

        /// <summary>       Returns the floating point representation of a half-precision floating point vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 f16tof32(int8 x) => f16tof32((uint8)x);

        
        /// <summary>       Returns the result converting a floating point value to its nearest half-precision floating point representation.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort f32tof16(float x)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (ushort)Unity.Mathematics.math.f32tof16(x);
            }
            else
            {
                return asushort((half)x);
            }
        }
        
        /// <summary>       Returns the result of a componentwise conversion of a floating point vector to its nearest half-precision floating point representation.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 f32tof16(float2 x)
        {
            return asushort((half2)x);
        }
        
        /// <summary>       Returns the result of a componentwise conversion of a floating point vector to its nearest half-precision floating point representation.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 f32tof16(float3 x)
        {
            return asushort((half3)x);
        }
        
        /// <summary>       Returns the result of a componentwise conversion of a floating point vector to its nearest half-precision floating point representation.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 f32tof16(float4 x)
        {
            return asushort((half4)x);
        }
        
        /// <summary>       Returns the result of a componentwise conversion of a floating point vector to its nearest half-precision floating point representation.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 f32tof16(float8 x)
        {
            return asushort((half8)x);
        }
    }
}
