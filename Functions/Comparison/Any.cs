using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if any component of the input bool2x2 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x2 x)
        {
            return math.any(*(bool4*)&x);
        }

        /// <summary>       Returns true if any component of the input bool2x3 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x3 x)
        {
            return any(*(bool3x2*)&x);
        }

        /// <summary>       Returns true if any component of the input bool2x4 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x4 x)
        {
            return *(long*)&x != 0L;
        }

        /// <summary>       Returns true if any component of the input bool3x2 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x2 x)
        {
            return math.any(x.c0 | x.c1);
        }

        /// <summary>       Returns true if any component of the input bool3x3 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns true if any component of the input bool3x4 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x4 x)
        {
            return any(*(bool4x3*)&x);
        }

        /// <summary>       Returns true if any component of the input bool4x2 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x2 x)
        {
            return *(long*)&x != 0L;
        }

        /// <summary>       Returns true if any component of the input bool4x3 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns true if any component of the input bool4x4 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x4 x)
        {
            return any(*(bool16*)&x);
        }

        /// <summary>       Returns true if any component of the input bool8 vector is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool8 x)
        {
            return x.cast_long != 0L;
        }

        /// <summary>       Returns true if any component of the input bool16 vector is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool16 x)
        {
            return Sse2.movemask_epi8(x) != 0;
        }

        /// <summary>       Returns true if any component of the input bool32 vector is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool32 x)
        {
            return Avx2.mm256_movemask_epi8(x) != 0;
        }
    }
}