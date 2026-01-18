using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epu64(v128 vector, ulong divisor)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
				switch (divisor)
				{
					case 3:
					{
						v128 MAGIC = set1_epi64x(-6_148_914_691_236_517_205);

						return srli_epi64(mulhi_epu64(vector, MAGIC), 1);
					}
					default:
					{
						return (ulong2)vector / new Divider<ulong>(divisor);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epu64(v256 vector, ulong divisor, byte elements = 4)
		{
			if (Avx2.IsAvx2Supported)
			{
				switch (divisor)
				{
					case 3:
					{
						v256 MAGIC = mm256_set1_epi64x(-6_148_914_691_236_517_205);

						return Avx2.mm256_srli_epi64(mm256_mulhi_epu64(vector, MAGIC, elements), 1);
					}
					default:
					{
						if (elements == 4)
						{
							return (ulong4)vector / new Divider<ulong>(divisor);
						}
						else
						{
							return (ulong3)vector / new Divider<ulong>(divisor);
						}
					}
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}
