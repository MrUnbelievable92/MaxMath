using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 rem_epu8(v128 vector, v128 divisor, byte elements = 16)
			{
                if (Sse2.IsSse2Supported)
                {
					if (constexpr.ALL_SAME_EPU8(divisor, elements))
					{
						return rem_epu8(vector, divisor.Byte0);
					}

						divisor = blendv_si128(divisor, Sse2.set1_epi8(1), Sse2.cmpeq_epi8(divisor, Sse2.setzero_si128()));

					return new v128((byte)(vector.Byte0 % divisor.Byte0), (byte)(vector.Byte1 % divisor.Byte1), (byte)(vector.Byte2 % divisor.Byte2), (byte)(vector.Byte3 % divisor.Byte3), (byte)(vector.Byte4 % divisor.Byte4), (byte)(vector.Byte5 % divisor.Byte5), (byte)(vector.Byte6 % divisor.Byte6), (byte)(vector.Byte7 % divisor.Byte7), (byte)(vector.Byte8 % divisor.Byte8), (byte)(vector.Byte9 % divisor.Byte9), (byte)(vector.Byte10 % divisor.Byte10), (byte)(vector.Byte11 % divisor.Byte11), (byte)(vector.Byte12 % divisor.Byte12), (byte)(vector.Byte13 % divisor.Byte13), (byte)(vector.Byte14 % divisor.Byte14), (byte)(vector.Byte15 % divisor.Byte15));
                }
				else throw new IllegalInstructionException();
			}

			internal static v256 mm256_rem_epu8(v256 vector, v256 divisor)
			{
				if (constexpr.ALL_SAME_EPU8(divisor))
				{
					return mm256_rem_epu8(vector, divisor.Byte0);
				}

				return new v256((byte)(vector.Byte0 % divisor.Byte0), (byte)(vector.Byte1 % divisor.Byte1), (byte)(vector.Byte2 % divisor.Byte2), (byte)(vector.Byte3 % divisor.Byte3), (byte)(vector.Byte4 % divisor.Byte4), (byte)(vector.Byte5 % divisor.Byte5), (byte)(vector.Byte6 % divisor.Byte6), (byte)(vector.Byte7 % divisor.Byte7), (byte)(vector.Byte8 % divisor.Byte8), (byte)(vector.Byte9 % divisor.Byte9), (byte)(vector.Byte10 % divisor.Byte10), (byte)(vector.Byte11 % divisor.Byte11), (byte)(vector.Byte12 % divisor.Byte12), (byte)(vector.Byte13 % divisor.Byte13), (byte)(vector.Byte14 % divisor.Byte14), (byte)(vector.Byte15 % divisor.Byte15), (byte)(vector.Byte16 % divisor.Byte16), (byte)(vector.Byte17 % divisor.Byte17), (byte)(vector.Byte18 % divisor.Byte18), (byte)(vector.Byte19 % divisor.Byte19), (byte)(vector.Byte20 % divisor.Byte20), (byte)(vector.Byte21 % divisor.Byte21), (byte)(vector.Byte22 % divisor.Byte22), (byte)(vector.Byte23 % divisor.Byte23), (byte)(vector.Byte24 % divisor.Byte24), (byte)(vector.Byte25 % divisor.Byte25), (byte)(vector.Byte26 % divisor.Byte26), (byte)(vector.Byte27 % divisor.Byte27), (byte)(vector.Byte28 % divisor.Byte28), (byte)(vector.Byte29 % divisor.Byte29), (byte)(vector.Byte30 % divisor.Byte30), (byte)(vector.Byte31 % divisor.Byte31));
			}
		}
	}
}
