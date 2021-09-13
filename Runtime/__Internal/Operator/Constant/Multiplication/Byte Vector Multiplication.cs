using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
	unsafe internal static partial class Operator
	{
		internal static partial class Constant
		{
			internal static v128 vmul_byte(v128 vector, byte factor)
			{
                switch (factor)
                {
					case 0: return Sse2.setzero_si128();
					case 1: return vector;
					case 2: return Sse2.add_epi8(vector, vector);
					
					case 3:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						return Sse2.add_epi8(vector, _2);
					}
					case 4:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						return Sse2.add_epi8(_2, _2);
					}
					case 5:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						return Sse2.add_epi8(_4, vector);
					}
					case 6:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						return Sse2.add_epi8(_2, _4);
					}
					case 7:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _3 = Sse2.add_epi8(_2, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						return Sse2.add_epi8(_3, _4);
					}
					case 8:
					{
						return shl_byte(vector, 3);
					}
					case 9:
					{
						v128 _8 = shl_byte(vector, 3);
						return Sse2.add_epi8(_8, vector);
					}
					case 10:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _8 = shl_byte(vector, 3);
						return Sse2.add_epi8(_8, _2);
					}
					case 11:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _3 = Sse2.add_epi8(_2, vector);
						v128 _8 = shl_byte(vector, 3);
						return Sse2.add_epi8(_8, _3);
					}
					case 12:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						v128 _8 = shl_byte(vector, 3);
						return Sse2.add_epi8(_8, _4);
					}
					case 13:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						v128 _5 = Sse2.add_epi8(_4, vector);
						v128 _8 = shl_byte(vector, 3);
						return Sse2.add_epi8(_8, _5);
					}
					case 14:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						v128 _6 = Sse2.add_epi8(_4, _2);
						v128 _8 = shl_byte(vector, 3);
						return Sse2.add_epi8(_8, _6);
					}
					case 15:
					{
						v128 _2 = Sse2.add_epi8(vector, vector);
						v128 _4 = Sse2.add_epi8(_2, _2);
						v128 _6 = Sse2.add_epi8(_4, _2);
						v128 _8 = shl_byte(vector, 3);
						v128 _9 = Sse2.add_epi8(_8, vector);
						return Sse2.add_epi8(_9, _6);
					}
					case 16:
					{
						return shl_byte(vector, 4);
					}

					case 255: return Sse2.sub_epi8(Sse2.setzero_si128(), vector); 

					default: return default;
                }
            }

			internal static v256 vmul_byte(v256 vector, byte factor)
			{
				return default;
			}
		}
	}
}