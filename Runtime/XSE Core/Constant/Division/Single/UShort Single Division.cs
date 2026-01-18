using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epu16(v128 vector, ushort divisor, byte elements = 8, bool __unsafe = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
				__unsafe |= constexpr.ALL_LT_EPU16(vector, 1 << 15, elements);

				switch (divisor)
				{
					case 3:
					{
						if (__unsafe)
						{
							return mulhi_epu16(vector, set1_epi16(21846));
						}
						else goto default;
					}
					case 6:
					{
						if (__unsafe)
						{
							return mulhi_epu16(vector, set1_epi16(10923));
						}
						else goto default;
					}

					default:
					{
						switch (elements)
						{
							case  2: return (ushort2)vector / new Divider<ushort>(divisor);
							case  3: return (ushort3)vector / new Divider<ushort>(divisor);
							case  4: return (ushort4)vector / new Divider<ushort>(divisor);
							default: return (ushort8)vector / new Divider<ushort>(divisor);
						}
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epu16(v256 vector, ushort divisor, bool __unsafe = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				__unsafe |= constexpr.ALL_LT_EPU16(vector, 1 << 15);

				switch (divisor)
				{
					case 3:
					{
						if (__unsafe)
						{
							return Avx2.mm256_mulhi_epu16(vector, mm256_set1_epi16(21846));
						}
						else goto default;
					}
					case 6:
					{
						if (__unsafe)
						{
							return Avx2.mm256_mulhi_epu16(vector, mm256_set1_epi16(10923));
						}
						else goto default;
					}

					default:
					{
						return (ushort16)vector / new Divider<ushort>(divisor);
					}
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}
