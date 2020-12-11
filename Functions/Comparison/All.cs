using System.Runtime.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if all components of the input bool2x2 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x2 x)
        {
            return math.all(*(bool4*)&x);
        }

        /// <summary>       Returns true if all components of the input bool2x3 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x3 x)
        {
            return all(*(bool3x2*)&x);
        }

        /// <summary>       Returns true if all components of the input bool2x4 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x4 x)
        {
            return *(long*)&x == 0x0101_0101_0101_0101;
        }

        /// <summary>       Returns true if all components of the input bool3x2 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns true if all components of the input bool3x3 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns true if all components of the input bool3x4 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x4 x)
        {
            return all(*(bool4x3*)&x);
        }

        /// <summary>       Returns true if all components of the input bool4x2 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x2 x)
        {
            return *(long*)&x == 0x0101_0101_0101_0101;
        }

        /// <summary>       Returns true if all components of the input bool4x3 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns true if all components of the input bool4x4 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x4 x)
        {
            return all((bool16)x);
        }

        /// <summary>       Returns true if all components of the input bool8 vector are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool8 x)
        {
            return x.cast_long == 0x0101_0101_0101_0101;
        }

        /// <summary>       Returns true if all components of the input bool16 vector are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool16 x)
        {
            return maxmath.bitmask32(16) == Sse2.movemask_epi8(x);
        }

        /// <summary>       Returns true if all components of the input bool32 vector are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool32 x)
        {
            return maxmath.bitmask32(32) == Avx2.mm256_movemask_epi8(x);
        }
    }
}