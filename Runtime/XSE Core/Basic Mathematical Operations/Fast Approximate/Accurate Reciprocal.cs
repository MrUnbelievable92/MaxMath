using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rcp23_ps(v128 a)
		{
            if (Architecture.IsFMASupported)
            {
                v128 ONE = set1_ps(1f);
                v128 r = rcp_ps(a);

                return fnmadd_ps(fmsub_ps(r, a, ONE), r, r);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return div_ps(set1_ps(1f), a);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_rcp23_ps(v256 a)
		{
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = mm256_set1_ps(1f);
                v256 r = Avx.mm256_rcp_ps(a);

                return mm256_fnmadd_ps(mm256_fmsub_ps(r, a, ONE), r, r);
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_div_ps(mm256_set1_ps(1f), a);
            }
            else throw new IllegalInstructionException();
		}
	}
}