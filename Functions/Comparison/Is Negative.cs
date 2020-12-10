using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if a half value is negative.       </summary>        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isneg(half x)
        {
            // keep x in XMM
            ushort2 result = *(ushort2*)&x >> 15;

            return *(bool*)&result;
        }

        /// <summary>       Returns a bool2 indicating for each component of a half2 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isneg(half2 x)
        {
            ushort result = Sse2.extract_epi16((byte2)(*(ushort2*)&x >> 15), 0);

            return *(bool2*)&result;
        }

        /// <summary>       Returns a bool3 indicating for each component of a half3 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isneg(half3 x)
        {
            int result = Sse4_1.extract_epi32((byte3)(*(ushort3*)&x >> 15), 0);

            return *(bool3*)&result;
        }

        /// <summary>       Returns a bool4 indicating for each component of a half4 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isneg(half4 x)
        {
            int result = Sse4_1.extract_epi32((byte4)(*(ushort4*)&x >> 15), 0);

            return *(bool4*)&result;
        }


        /// <summary>       Returns true if a float value is negative.       </summary> 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isneg(float x)
        {
            uint result = math.asuint(x) >> 31;

            return *(bool*)&result;
        }

        /// <summary>       Returns a bool2 indicating for each component of a float2 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isneg(float2 x)
        {
            ushort result = Sse2.extract_epi16((byte2)(math.asuint(x) >> 31), 0);

            return *(bool2*)&result;
        }

        /// <summary>       Returns a bool3 indicating for each component of a float3 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isneg(float3 x)
        {
            int result = Sse4_1.extract_epi32((byte3)(math.asuint(x) >> 31), 0);

            return *(bool3*)&result;
        }

        /// <summary>       Returns a bool4 indicating for each component of a float4 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isneg(float4 x)
        {
            int result = Sse4_1.extract_epi32((byte4)(math.asuint(x) >> 31), 0);

            return *(bool4*)&result;
        }

        /// <summary>       Returns a bool8 indicating for each component of a float8 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isneg(float8 x)
        {
            return (bool8)((byte8)(((int8)(v256)x) >> 31));
        }


        /// <summary>       Returns true if a double value is negative.       </summary> 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isneg(double x)
        {
            ulong result = math.asulong(x) >> 63;

            return *(bool*)&result;
        }

        /// <summary>       Returns a bool2 indicating for each component of a double2 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isneg(double2 x)
        {
            ushort result = Sse2.extract_epi16((byte2)(*(ulong2*)&x >> 63), 0);

            return *(bool2*)&result;
        }

        /// <summary>       Returns a bool3 indicating for each component of a double3 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isneg(double3 x)
        {
            int result = Sse4_1.extract_epi32((byte3)(*(ulong3*)&x >> 63), 0);

            return *(bool3*)&result;
        }

        /// <summary>       Returns a bool4 indicating for each component of a double4 whether it is a negative value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isneg(double4 x)
        {
            int result = Sse4_1.extract_epi32((byte4)(*(ulong4*)&x >> 63), 0);

            return *(bool4*)&result;
        }
    }
}