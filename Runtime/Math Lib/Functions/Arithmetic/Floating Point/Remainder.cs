using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fmod(float x, float y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
        
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fmod(float2 x, float2 y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
        
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fmod(float3 x, float3 y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
        
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fmod(float4 x, float4 y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }

        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fmod(float8 x, float8 y)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = fmod(*((float*)&x + i), *((float*)&y + i));
                }

                return r;
            }
            else
            {
                return new float8(fmod(x.v4_0, y.v4_0), fmod(x.v4_4, y.v4_4));
            }
        }

        
        /// <summary>       Returns the floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double fmod(double x, double y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
        
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fmod(double2 x, double2 y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
        
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fmod(double3 x, double3 y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
        
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/><see langword="/"/><paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fmod(double4 x, double4 y)
        {
            return Unity.Mathematics.math.fmod(x, y);
        }
    }
}