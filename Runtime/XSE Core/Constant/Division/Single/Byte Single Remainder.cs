using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 rem_epu8(v128 vector, byte divisor, byte elements = 16)
			{
                if (Sse2.IsSse2Supported)
                {
                    if (divisor > 0b1000_0000)
                    {
						v128 DIV = Sse2.set1_epi8((sbyte)divisor);
						v128 resultQuestionMark = Sse2.sub_epi8(vector, DIV);

						return blendv_si128(vector, resultQuestionMark, cmpge_epu8(vector, DIV));
                    }
                }


				return new v128((byte)(vector.Byte0 % divisor), (byte)(vector.Byte1 % divisor), (byte)(vector.Byte2 % divisor), (byte)(vector.Byte3 % divisor), (byte)(vector.Byte4 % divisor), (byte)(vector.Byte5 % divisor), (byte)(vector.Byte6 % divisor), (byte)(vector.Byte7 % divisor), (byte)(vector.Byte8 % divisor), (byte)(vector.Byte9 % divisor), (byte)(vector.Byte10 % divisor), (byte)(vector.Byte11 % divisor), (byte)(vector.Byte12 % divisor), (byte)(vector.Byte13 % divisor), (byte)(vector.Byte14 % divisor), (byte)(vector.Byte15 % divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_rem_epu8(v256 vector, byte divisor)
			{
                if (Avx2.IsAvx2Supported)
                {
                    if (divisor > 0b1000_0000)
                    {
						v256 DIV = Avx.mm256_set1_epi8((byte)divisor);
						v256 resultQuestionMark = Avx2.mm256_sub_epi8(vector, DIV);

						return Avx2.mm256_blendv_epi8(vector, resultQuestionMark, mm256_cmpge_epu8(vector, DIV));
                    }
                }


				return new v256((byte)(vector.Byte0 % divisor), (byte)(vector.Byte1 % divisor), (byte)(vector.Byte2 % divisor), (byte)(vector.Byte3 % divisor), (byte)(vector.Byte4 % divisor), (byte)(vector.Byte5 % divisor), (byte)(vector.Byte6 % divisor), (byte)(vector.Byte7 % divisor), (byte)(vector.Byte8 % divisor), (byte)(vector.Byte9 % divisor), (byte)(vector.Byte10 % divisor), (byte)(vector.Byte11 % divisor), (byte)(vector.Byte12 % divisor), (byte)(vector.Byte13 % divisor), (byte)(vector.Byte14 % divisor), (byte)(vector.Byte15 % divisor), (byte)(vector.Byte16 % divisor), (byte)(vector.Byte17 % divisor), (byte)(vector.Byte18 % divisor), (byte)(vector.Byte19 % divisor), (byte)(vector.Byte20 % divisor), (byte)(vector.Byte21 % divisor), (byte)(vector.Byte22 % divisor), (byte)(vector.Byte23 % divisor), (byte)(vector.Byte24 % divisor), (byte)(vector.Byte25 % divisor), (byte)(vector.Byte26 % divisor), (byte)(vector.Byte27 % divisor), (byte)(vector.Byte28 % divisor), (byte)(vector.Byte29 % divisor), (byte)(vector.Byte30 % divisor), (byte)(vector.Byte31 % divisor));
			}
		}
	}
}
