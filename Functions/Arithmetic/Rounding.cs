using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise truncation of a float8 value to an integral float8 value.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 trunc(float8 x)
        {
            return Avx.mm256_round_ps(x, (int)X86.RoundingMode.FROUND_TRUNC);
        }

        /// <summary>       Returns the result of rounding each component of a float8 vector value to the nearest integral value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 round(float8 x)
        {
            return Avx.mm256_round_ps(x, (int)X86.RoundingMode.FROUND_NINT);
        }

        /// <summary>       Returns the result of rounding each component of a float8 vector value down to the nearest value less or equal to the original value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floor(float8 x)
        {
            return Avx.mm256_floor_ps(x);
        }

        /// <summary>       Returns the result of rounding each component of a float8 vector value up to the nearest value greater or equal to the original value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceil(float8 x)
        {
            return Avx.mm256_ceil_ps(x);
        }
    }
}