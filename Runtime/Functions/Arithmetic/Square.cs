using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ////////////////////////////////////////////////////////////
        ///               M A K E   P U B L I C                  ///
        ////////////////////////////////////////////////////////////
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 square(UInt128 x)
        {
            ulong lo = Common.umul128(x.lo, x.lo, out ulong hi);
            hi += (x.lo * x.hi) << 1;

            return new UInt128(lo, hi);
        }

        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 square(Int128 x)
        {
            ulong lo = Common.umul128(x.intern.lo, x.intern.lo, out ulong hi);
            hi += (x.intern.lo * x.intern.hi) << 1;

            return new Int128(lo, hi);
        }
        

        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float8 square(float8 x) => x * x;


        ////////////////////////////////////////////////////////////
        ///                    D E L E T E                       ///
        ////////////////////////////////////////////////////////////
        
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float square(float x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Unity.Mathematics.float2 square(Unity.Mathematics.float2 x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Unity.Mathematics.float3 square(Unity.Mathematics.float3 x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Unity.Mathematics.float4 square(Unity.Mathematics.float4 x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]

        internal static double square(double x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Unity.Mathematics.double2 square(Unity.Mathematics.double2 x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Unity.Mathematics.double3 square(Unity.Mathematics.double3 x) => x * x;
        /// <summary>       .      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Unity.Mathematics.double4 square(Unity.Mathematics.double4 x) => x * x;
    }
}