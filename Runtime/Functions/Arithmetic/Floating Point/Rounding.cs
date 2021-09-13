using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise truncation of a <see cref="MaxMath.float8"/> to an integral <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 trunc(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_ps(x, (int)X86.RoundingMode.FROUND_TRUNC_NOEXC);
            }
            else
            {
                return new float8(math.trunc(x.v4_0), math.trunc(x.v4_4));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> to the nearest numerical value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 round(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_ps(x, (int)X86.RoundingMode.FROUND_NINT_NOEXC);
            }
            else
            {
                return new float8(math.round(x.v4_0), math.round(x.v4_4));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> down to the nearest value less or equal to the original value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floor(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_floor_ps(x);
            }
            else
            {
                return new float8(math.floor(x.v4_0), math.floor(x.v4_4));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> up to the nearest value greater or equal to the original value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceil(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_ceil_ps(x);
            }
            else
            {
                return new float8(math.ceil(x.v4_0), math.ceil(x.v4_4));
            }
        }
    }
}