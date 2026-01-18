using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constmullo_epu8(v128 a, byte b, byte elements = 16)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				switch (b)
				{
					case 0: return setzero_si128();
					case 1: return a;
					case 2: return add_epi8(a, a);

					case 3:
					{
						v128 _2 = add_epi8(a, a);
						return add_epi8(a, _2);
					}
					case 4:
					{
						v128 _2 = add_epi8(a, a);
						return add_epi8(_2, _2);
					}
					case 5:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						return add_epi8(_4, a);
					}
					case 6:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						return add_epi8(_2, _4);
					}
					case 7:
					{
						v128 _8 = slli_epi8(a, 3);
						return sub_epi8(_8, a);
					}
					case 8:
					{
						return slli_epi8(a, 3);
					}
					case 9:
					{
						v128 _8 = slli_epi8(a, 3);
						return add_epi8(_8, a);
					}
					case 10:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3);
						return add_epi8(_8, _2);
					}
					case 11:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _8 = slli_epi8(a, 3);
						return add_epi8(_8, _3);
					}
					case 12:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _8 = slli_epi8(a, 3);
						return add_epi8(_8, _4);
					}
					case 13:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4);
						return sub_epi8(_16, _3);
					}
					case 14:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4);
						return sub_epi8(_16, _2);
					}
					case 15:
					{
						v128 _16 = slli_epi8(a, 4);
						return sub_epi8(_16, a);
					}
					case 16:
					{
						return slli_epi8(a, 4);
					}
					case 17:
					{
						v128 _16 = slli_epi8(a, 4);
						return add_epi8(_16, a);
					}
					case 18:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4);
						return add_epi8(_16, _2);
					}
					case 19:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4);
						return add_epi8(_16, _3);
					}
					case 20:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4);
						return add_epi8(_16, _4);
					}
					case 21:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4);
						v128 _20 = add_epi8(_16, _4);
						return add_epi8(_20, a);
					}
					case 22:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4);
						v128 _20 = add_epi8(_16, _4);
						return add_epi8(_20, _2);
					}
					case 23:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _16 = slli_epi8(a, 4, maskBefore: false);
						v128 _24 = add_epi8(_16, _8);
						return sub_epi8(_24, a);
					}
					case 24:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _16 = slli_epi8(a, 4, maskBefore: false);
						return add_epi8(_16, _8);
					}
					case 25:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _16 = slli_epi8(a, 4, maskBefore: false);
						v128 _24 = add_epi8(_16, _8);
						return add_epi8(_24, a);
					}
					case 26:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _10 = add_epi8(_2, _8);
						v128 _16 = slli_epi8(a, 4, maskBefore: false);
						return add_epi8(_16, _10);
					}
					case 27:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _32 = slli_epi8(a, 5);
						return sub_epi8(_32, _5);
					}
					case 28:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _32 = slli_epi8(a, 5);
						return sub_epi8(_32, _4);
					}
					case 29:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _32 = slli_epi8(a, 5);
						return sub_epi8(_32, _3);
					}
					case 30:
					{
						v128 _2 = add_epi8(a, a);
						v128 _32 = slli_epi8(a, 5);
						return sub_epi8(_32, _2);
					}
					case 31:
					{
						v128 _32 = slli_epi8(a, 5);
						return sub_epi8(_32, a);
					}
					case 32:
					{
						return slli_epi8(a, 5);
					}
					case 33:
					{
						v128 _32 = slli_epi8(a, 5);
						return add_epi8(_32, a);
					}
					case 34:
					{
						v128 _2 = add_epi8(a, a);
						v128 _32 = slli_epi8(a, 5);
						return add_epi8(_32, _2);
					}
					case 35:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _32 = slli_epi8(a, 5);
						return add_epi8(_32, _3);
					}
					case 36:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _32 = slli_epi8(a, 5);
						return add_epi8(_32, _4);
					}
					case 37:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _32 = slli_epi8(a, 5);
						return add_epi8(_32, _5);
					}
					case 38:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _6 = add_epi8(_4, _2);
						v128 _32 = slli_epi8(a, 5);
						return add_epi8(_32, _6);
					}
					case 39:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _40 = add_epi8(_32, _8);
						return sub_epi8(_40, a);
					}
					case 40:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						return add_epi8(_32, _8);
					}
					case 41:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _40 = add_epi8(_32, _8);
						return add_epi8(_40, a);
					}
					case 42:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _40 = add_epi8(_32, _8);
						return add_epi8(_40, _2);
					}
					case 43:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _40 = add_epi8(_32, _8);
						return add_epi8(_40, _3);
					}
					case 44:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _40 = add_epi8(_32, _8);
						return add_epi8(_40, _4);
					}
					case 45:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _48 = add_epi8(_32, _16);
						return sub_epi8(_48, _3);
					}
					case 46:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _48 = add_epi8(_32, _16);
						return sub_epi8(_48, _2);
					}
					case 47:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _48 = add_epi8(_32, _16);
						return sub_epi8(_48, a);
					}
					case 48:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						return add_epi8(_32, _16);
					}
					case 49:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _48 = add_epi8(_32, _16);
						return add_epi8(_48, a);
					}
					case 50:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _48 = add_epi8(_32, _16);
						return add_epi8(_48, _2);
					}
					case 51:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5);
						v128 _48 = add_epi8(_32, _16);
						return add_epi8(_48, _3);
					}
					case 52:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: false);
						v128 _48 = add_epi8(_32, _16);
						return add_epi8(_48, _4);
					}
					case 53:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _10 = add_epi8(_8, _2);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _63 = sub_epi8(_64, a);
						return sub_epi8(_63, _10);
					}
					case 54:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _10 = add_epi8(_8, _2);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return sub_epi8(_64, _10);
					}
					case 55:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _9 = add_epi8(_8, a);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return sub_epi8(_64, _9);
					}
					case 56:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return sub_epi8(_64, _8);
					}
					case 57:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _7 = sub_epi8(_8, a);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return sub_epi8(_64, _7);
					}
					case 58:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _6 = add_epi8(_4, _2);
						v128 _64 = slli_epi8(a, 6);
						return sub_epi8(_64, _6);
					}
					case 59:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _64 = slli_epi8(a, 6);
						return sub_epi8(_64, _5);
					}
					case 60:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _64 = slli_epi8(a, 6);
						return sub_epi8(_64, _4);
					}
					case 61:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _64 = slli_epi8(a, 6);
						return sub_epi8(_64, _3);
					}
					case 62:
					{
						v128 _2 = add_epi8(a, a);
						v128 _64 = slli_epi8(a, 6);
						return sub_epi8(_64, _2);
					}
					case 63:
					{
						v128 _64 = slli_epi8(a, 6);
						return sub_epi8(_64, a);
					}
					case 64:
					{
						return slli_epi8(a, 6);
					}
					case 65:
					{
						v128 _64 = slli_epi8(a, 6);
						return add_epi8(_64, a);
					}
					case 66:
					{
						v128 _2 = add_epi8(a, a);
						v128 _64 = slli_epi8(a, 6);
						return add_epi8(_64, _2);
					}
					case 67:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _64 = slli_epi8(a, 6);
						return add_epi8(_64, _3);
					}
					case 68:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _64 = slli_epi8(a, 6);
						return add_epi8(_64, _4);
					}
					case 69:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _64 = slli_epi8(a, 6);
						return add_epi8(_64, _5);
					}
					case 70:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _6 = add_epi8(_4, _2);
						v128 _64 = slli_epi8(a, 6);
						return add_epi8(_64, _6);
					}
					case 71:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _72 = add_epi8(_64, _8);
						return sub_epi8(_72, a);
					}
					case 72:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _8);
					}
					case 73:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _72 = add_epi8(_64, _8);
						return add_epi8(_72, a);
					}
					case 74:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _10 = add_epi8(_2, _8);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _10);
					}
					case 75:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _10 = add_epi8(_2, _8);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _65 = add_epi8(a, _64);
						return add_epi8(_65, _10);
					}
					case 76:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _12 = add_epi8(_4, _8);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _12);
					}
					case 77:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _12 = add_epi8(_4, _8);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _65 = add_epi8(a, _64);
						return add_epi8(_65, _12);
					}
					case 78:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _12 = add_epi8(_4, _8);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _66 = add_epi8(_2, _64);
						return add_epi8(_66, _12);
					}
					case 79:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _15 = sub_epi8(_16, a);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _15);
					}
					case 80:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _16);
					}
					case 81:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _17 = add_epi8(_16, a);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _17);
					}
					case 82:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _18 = add_epi8(_16, _2);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _18);
					}
					case 83:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _19 = add_epi8(_16, _3);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _19);
					}
					case 84:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _20 = add_epi8(_16, _4);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _20);
					}
					case 85:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _20 = add_epi8(_16, _4);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _65 = add_epi8(_64, a);
						return add_epi8(_65, _20);
					}
					case 86:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _20 = add_epi8(_16, _4);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _66 = add_epi8(_64, _2);
						return add_epi8(_66, _20);
					}
					case 87:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _20 = add_epi8(_16, _4);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _67 = add_epi8(_64, _3);
						return add_epi8(_67, _20);
					}
					case 88:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _80 = add_epi8(_64, _16);
						return add_epi8(_80, _8);
					}
					case 89:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _9 = add_epi8(_8, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _80 = add_epi8(_64, _16);
						return add_epi8(_80, _9);
					}
					case 90:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _6 = add_epi8(_4, _2);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return sub_epi8(_96, _6);
					}
					case 91:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return sub_epi8(_96, _5);
					}
					case 92:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return sub_epi8(_96, _4);
					}
					case 93:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return sub_epi8(_96, _3);
					}
					case 94:
					{
						v128 _2 = add_epi8(a, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return sub_epi8(_96, _2);
					}
					case 95:
					{
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return sub_epi8(_96, a);
					}
					case 96:
					{
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						return add_epi8(_64, _32);
					}
					case 97:
					{
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, a);
					}
					case 98:
					{
						v128 _2 = add_epi8(a, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _2);
					}
					case 99:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _3);
					}
					case 100:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _4);
					}
					case 101:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _5);
					}
					case 102:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _6 = add_epi8(_4, _2);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _6);
					}
					case 103:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _7 = sub_epi8(_8, a);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _7);
					}
					case 104:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _32 = slli_epi8(a, 5, maskBefore: true);
						v128 _64 = slli_epi8(a, 6, maskBefore: false);
						v128 _96 = add_epi8(_64, _32);
						return add_epi8(_96, _8);
					}
					case 105:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _7 = add_epi8(_4, _3);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, _7);
					}
					case 106:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _6 = add_epi8(_4, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, _6);
					}
					case 107:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _5 = add_epi8(_4, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, _5);
					}
					case 108:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, _4);
					}
					case 109:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, _3);
					}
					case 110:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, _2);
					}
					case 111:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return sub_epi8(_112, a);
					}
					case 112:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						return sub_epi8(_128, _16);
					}
					case 113:
					{
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return add_epi8(_112, a);
					}
					case 114:
					{
						v128 _2 = add_epi8(a, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return add_epi8(_112, _2);
					}
					case 115:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _16 = slli_epi8(a, 4, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _112 = sub_epi8(_128, _16);
						return add_epi8(_112, _3);
					}
					case 116:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _12 = add_epi8(_8, _4);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						return sub_epi8(_128, _12);
					}
					case 117:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _11 = add_epi8(_8, _3);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						return sub_epi8(_128, _11);
					}
					case 118:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _10 = add_epi8(_8, _2);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						return sub_epi8(_128, _10);
					}
					case 119:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _9 = add_epi8(_8, a);
						v128 _128 = slli_epi8(a, 7);
						return sub_epi8(_128, _9);
					}
					case 120:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						return sub_epi8(_128, _8);
					}
					case 121:
					{
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _120 = sub_epi8(_128, _8);
						return add_epi8(_120, a);
					}
					case 122:
					{
						v128 _2 = add_epi8(a, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _120 = sub_epi8(_128, _8);
						return add_epi8(_120, _2);
					}
					case 123:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _8 = slli_epi8(a, 3, maskBefore: true);
						v128 _128 = slli_epi8(a, 7, maskBefore: false);
						v128 _120 = sub_epi8(_128, _8);
						return add_epi8(_120, _3);
					}
					case 124:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _128 = slli_epi8(a, 7);
						return sub_epi8(_128, _4);
					}
					case 125:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _128 = slli_epi8(a, 7);
						return sub_epi8(_128, _3);
					}
					case 126:
					{
						v128 _2 = add_epi8(a, a);
						v128 _128 = slli_epi8(a, 7);
						return sub_epi8(_128, _2);
					}
					case 127:
					{
						v128 _128 = slli_epi8(a, 7);
						return sub_epi8(_128, a);
					}
					case 128:
					{
						return slli_epi8(a, 7);
					}
					case 129:
					{
						v128 _128 = slli_epi8(a, 7);
						return add_epi8(_128, a);
					}
					case 130:
					{
						v128 _2 = add_epi8(a, a);
						v128 _128 = slli_epi8(a, 7);
						return add_epi8(_128, _2);
					}
					case 131:
					{
						v128 _2 = add_epi8(a, a);
						v128 _3 = add_epi8(_2, a);
						v128 _128 = slli_epi8(a, 7);
						return add_epi8(_128, _3);
					}
					case 132:
					{
						v128 _2 = add_epi8(a, a);
						v128 _4 = add_epi8(_2, _2);
						v128 _128 = slli_epi8(a, 7);
						return add_epi8(_128, _4);
					}

					case 255:
					{
						return neg_epi8(a);
					}

					default:
					{
						if (Sse2.IsSse2Supported)
						{
							v128 B = set1_epi16(b);

							if (elements == 16)
							{
								v128 lo = cvt2x2epu8_epi16(a, out v128 hi);

								lo = mullo_epi16(lo, B);
								hi = mullo_epi16(hi, B);

								return cvt2x2epi16_epi8(lo, hi);
							}
							else
							{
								return cvtepi16_epi8(mullo_epi16(cvtepu8_epi16(a), B));
							}
						}
						else
						{
							return mullo_epi8(a, set1_epi8(b));
						}
					}
				}
			}
			else throw new IllegalInstructionException();
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constmullo_epu8(v256 a, byte b)
		{
            if (Avx2.IsAvx2Supported)
            {
				switch (b)
				{
					case 0: return Avx.mm256_setzero_si256();
					case 1: return a;
					case 2: return Avx2.mm256_add_epi8(a, a);

					case 3:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						return Avx2.mm256_add_epi8(a, _2);
					}
					case 4:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						return Avx2.mm256_add_epi8(_2, _2);
					}
					case 5:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						return Avx2.mm256_add_epi8(_4, a);
					}
					case 6:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						return Avx2.mm256_add_epi8(_2, _4);
					}
					case 7:
					{
						v256 _8 = mm256_slli_epi8(a, 3);
						return Avx2.mm256_sub_epi8(_8, a);
					}
					case 8:
					{
						return mm256_slli_epi8(a, 3);
					}
					case 9:
					{
						v256 _8 = mm256_slli_epi8(a, 3);
						return Avx2.mm256_add_epi8(_8, a);
					}
					case 10:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3);
						return Avx2.mm256_add_epi8(_8, _2);
					}
					case 11:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _8 = mm256_slli_epi8(a, 3);
						return Avx2.mm256_add_epi8(_8, _3);
					}
					case 12:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _8 = mm256_slli_epi8(a, 3);
						return Avx2.mm256_add_epi8(_8, _4);
					}
					case 13:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_sub_epi8(_16, _3);
					}
					case 14:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_sub_epi8(_16, _2);
					}
					case 15:
					{
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_sub_epi8(_16, a);
					}
					case 16:
					{
						return mm256_slli_epi8(a, 4);
					}
					case 17:
					{
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_add_epi8(_16, a);
					}
					case 18:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_add_epi8(_16, _2);
					}
					case 19:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_add_epi8(_16, _3);
					}
					case 20:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4);
						return Avx2.mm256_add_epi8(_16, _4);
					}
					case 21:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4);
						v256 _20 = Avx2.mm256_add_epi8(_16, _4);
						return Avx2.mm256_add_epi8(_20, a);
					}
					case 22:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4);
						v256 _20 = Avx2.mm256_add_epi8(_16, _4);
						return Avx2.mm256_add_epi8(_20, _2);
					}
					case 23:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: false);
						v256 _24 = Avx2.mm256_add_epi8(_16, _8);
						return Avx2.mm256_sub_epi8(_24, a);
					}
					case 24:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: false);
						return Avx2.mm256_add_epi8(_16, _8);
					}
					case 25:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: false);
						v256 _24 = Avx2.mm256_add_epi8(_16, _8);
						return Avx2.mm256_add_epi8(_24, a);
					}
					case 26:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _10 = Avx2.mm256_add_epi8(_2, _8);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: false);
						return Avx2.mm256_add_epi8(_16, _10);
					}
					case 27:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_sub_epi8(_32, _5);
					}
					case 28:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_sub_epi8(_32, _4);
					}
					case 29:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_sub_epi8(_32, _3);
					}
					case 30:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_sub_epi8(_32, _2);
					}
					case 31:
					{
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_sub_epi8(_32, a);
					}
					case 32:
					{
						return mm256_slli_epi8(a, 5);
					}
					case 33:
					{
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_add_epi8(_32, a);
					}
					case 34:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_add_epi8(_32, _2);
					}
					case 35:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_add_epi8(_32, _3);
					}
					case 36:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_add_epi8(_32, _4);
					}
					case 37:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_add_epi8(_32, _5);
					}
					case 38:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _6 = Avx2.mm256_add_epi8(_4, _2);
						v256 _32 = mm256_slli_epi8(a, 5);
						return Avx2.mm256_add_epi8(_32, _6);
					}
					case 39:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _40 = Avx2.mm256_add_epi8(_32, _8);
						return Avx2.mm256_sub_epi8(_40, a);
					}
					case 40:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						return Avx2.mm256_add_epi8(_32, _8);
					}
					case 41:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _40 = Avx2.mm256_add_epi8(_32, _8);
						return Avx2.mm256_add_epi8(_40, a);
					}
					case 42:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _40 = Avx2.mm256_add_epi8(_32, _8);
						return Avx2.mm256_add_epi8(_40, _2);
					}
					case 43:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _40 = Avx2.mm256_add_epi8(_32, _8);
						return Avx2.mm256_add_epi8(_40, _3);
					}
					case 44:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _40 = Avx2.mm256_add_epi8(_32, _8);
						return Avx2.mm256_add_epi8(_40, _4);
					}
					case 45:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_sub_epi8(_48, _3);
					}
					case 46:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_sub_epi8(_48, _2);
					}
					case 47:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_sub_epi8(_48, a);
					}
					case 48:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						return Avx2.mm256_add_epi8(_32, _16);
					}
					case 49:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_add_epi8(_48, a);
					}
					case 50:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_add_epi8(_48, _2);
					}
					case 51:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_add_epi8(_48, _3);
					}
					case 52:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: false);
						v256 _48 = Avx2.mm256_add_epi8(_32, _16);
						return Avx2.mm256_add_epi8(_48, _4);
					}
					case 53:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _10 = Avx2.mm256_add_epi8(_8, _2);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _63 = Avx2.mm256_sub_epi8(_64, a);
						return Avx2.mm256_sub_epi8(_63, _10);
					}
					case 54:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _10 = Avx2.mm256_add_epi8(_8, _2);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_sub_epi8(_64, _10);
					}
					case 55:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _9 = Avx2.mm256_add_epi8(_8, a);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_sub_epi8(_64, _9);
					}
					case 56:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_sub_epi8(_64, _8);
					}
					case 57:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _7 = Avx2.mm256_sub_epi8(_8, a);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_sub_epi8(_64, _7);
					}
					case 58:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _6 = Avx2.mm256_add_epi8(_4, _2);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_sub_epi8(_64, _6);
					}
					case 59:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_sub_epi8(_64, _5);
					}
					case 60:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_sub_epi8(_64, _4);
					}
					case 61:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_sub_epi8(_64, _3);
					}
					case 62:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_sub_epi8(_64, _2);
					}
					case 63:
					{
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_sub_epi8(_64, a);
					}
					case 64:
					{
						return mm256_slli_epi8(a, 6);
					}
					case 65:
					{
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_add_epi8(_64, a);
					}
					case 66:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_add_epi8(_64, _2);
					}
					case 67:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_add_epi8(_64, _3);
					}
					case 68:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_add_epi8(_64, _4);
					}
					case 69:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_add_epi8(_64, _5);
					}
					case 70:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _6 = Avx2.mm256_add_epi8(_4, _2);
						v256 _64 = mm256_slli_epi8(a, 6);
						return Avx2.mm256_add_epi8(_64, _6);
					}
					case 71:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _72 = Avx2.mm256_add_epi8(_64, _8);
						return Avx2.mm256_sub_epi8(_72, a);
					}
					case 72:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _8);
					}
					case 73:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _72 = Avx2.mm256_add_epi8(_64, _8);
						return Avx2.mm256_add_epi8(_72, a);
					}
					case 74:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _10 = Avx2.mm256_add_epi8(_2, _8);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _10);
					}
					case 75:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _10 = Avx2.mm256_add_epi8(_2, _8);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _65 = Avx2.mm256_add_epi8(a, _64);
						return Avx2.mm256_add_epi8(_65, _10);
					}
					case 76:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _12 = Avx2.mm256_add_epi8(_4, _8);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _12);
					}
					case 77:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _12 = Avx2.mm256_add_epi8(_4, _8);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _65 = Avx2.mm256_add_epi8(a, _64);
						return Avx2.mm256_add_epi8(_65, _12);
					}
					case 78:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _12 = Avx2.mm256_add_epi8(_4, _8);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _66 = Avx2.mm256_add_epi8(_2, _64);
						return Avx2.mm256_add_epi8(_66, _12);
					}
					case 79:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _15 = Avx2.mm256_sub_epi8(_16, a);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _15);
					}
					case 80:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _16);
					}
					case 81:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _17 = Avx2.mm256_add_epi8(_16, a);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _17);
					}
					case 82:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _18 = Avx2.mm256_add_epi8(_16, _2);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _18);
					}
					case 83:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _19 = Avx2.mm256_add_epi8(_16, _3);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _19);
					}
					case 84:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _20 = Avx2.mm256_add_epi8(_16, _4);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _20);
					}
					case 85:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _20 = Avx2.mm256_add_epi8(_16, _4);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _65 = Avx2.mm256_add_epi8(_64, a);
						return Avx2.mm256_add_epi8(_65, _20);
					}
					case 86:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _20 = Avx2.mm256_add_epi8(_16, _4);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _66 = Avx2.mm256_add_epi8(_64, _2);
						return Avx2.mm256_add_epi8(_66, _20);
					}
					case 87:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _20 = Avx2.mm256_add_epi8(_16, _4);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _67 = Avx2.mm256_add_epi8(_64, _3);
						return Avx2.mm256_add_epi8(_67, _20);
					}
					case 88:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _80 = Avx2.mm256_add_epi8(_64, _16);
						return Avx2.mm256_add_epi8(_80, _8);
					}
					case 89:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _9 = Avx2.mm256_add_epi8(_8, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _80 = Avx2.mm256_add_epi8(_64, _16);
						return Avx2.mm256_add_epi8(_80, _9);
					}
					case 90:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _6 = Avx2.mm256_add_epi8(_4, _2);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_sub_epi8(_96, _6);
					}
					case 91:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_sub_epi8(_96, _5);
					}
					case 92:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_sub_epi8(_96, _4);
					}
					case 93:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_sub_epi8(_96, _3);
					}
					case 94:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_sub_epi8(_96, _2);
					}
					case 95:
					{
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_sub_epi8(_96, a);
					}
					case 96:
					{
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						return Avx2.mm256_add_epi8(_64, _32);
					}
					case 97:
					{
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, a);
					}
					case 98:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _2);
					}
					case 99:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _3);
					}
					case 100:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _4);
					}
					case 101:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _5);
					}
					case 102:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _6 = Avx2.mm256_add_epi8(_4, _2);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _6);
					}
					case 103:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _7 = Avx2.mm256_sub_epi8(_8, a);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _7);
					}
					case 104:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _32 = mm256_slli_epi8(a, 5, maskBefore: true);
						v256 _64 = mm256_slli_epi8(a, 6, maskBefore: false);
						v256 _96 = Avx2.mm256_add_epi8(_64, _32);
						return Avx2.mm256_add_epi8(_96, _8);
					}
					case 105:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _7 = Avx2.mm256_add_epi8(_4, _3);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, _7);
					}
					case 106:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _6 = Avx2.mm256_add_epi8(_4, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, _6);
					}
					case 107:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _5 = Avx2.mm256_add_epi8(_4, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, _5);
					}
					case 108:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, _4);
					}
					case 109:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, _3);
					}
					case 110:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, _2);
					}
					case 111:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_sub_epi8(_112, a);
					}
					case 112:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						return Avx2.mm256_sub_epi8(_128, _16);
					}
					case 113:
					{
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_add_epi8(_112, a);
					}
					case 114:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_add_epi8(_112, _2);
					}
					case 115:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _16 = mm256_slli_epi8(a, 4, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _112 = Avx2.mm256_sub_epi8(_128, _16);
						return Avx2.mm256_add_epi8(_112, _3);
					}
					case 116:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _12 = Avx2.mm256_add_epi8(_8, _4);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						return Avx2.mm256_sub_epi8(_128, _12);
					}
					case 117:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _11 = Avx2.mm256_add_epi8(_8, _3);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						return Avx2.mm256_sub_epi8(_128, _11);
					}
					case 118:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _10 = Avx2.mm256_add_epi8(_8, _2);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						return Avx2.mm256_sub_epi8(_128, _10);
					}
					case 119:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _9 = Avx2.mm256_add_epi8(_8, a);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_sub_epi8(_128, _9);
					}
					case 120:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						return Avx2.mm256_sub_epi8(_128, _8);
					}
					case 121:
					{
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _120 = Avx2.mm256_sub_epi8(_128, _8);
						return Avx2.mm256_add_epi8(_120, a);
					}
					case 122:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _120 = Avx2.mm256_sub_epi8(_128, _8);
						return Avx2.mm256_add_epi8(_120, _2);
					}
					case 123:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _8 = mm256_slli_epi8(a, 3, maskBefore: true);
						v256 _128 = mm256_slli_epi8(a, 7, maskBefore: false);
						v256 _120 = Avx2.mm256_sub_epi8(_128, _8);
						return Avx2.mm256_add_epi8(_120, _3);
					}
					case 124:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_sub_epi8(_128, _4);
					}
					case 125:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_sub_epi8(_128, _3);
					}
					case 126:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_sub_epi8(_128, _2);
					}
					case 127:
					{
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_sub_epi8(_128, a);
					}
					case 128:
					{
						return mm256_slli_epi8(a, 7);
					}
					case 129:
					{
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_add_epi8(_128, a);
					}
					case 130:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_add_epi8(_128, _2);
					}
					case 131:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _3 = Avx2.mm256_add_epi8(_2, a);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_add_epi8(_128, _3);
					}
					case 132:
					{
						v256 _2 = Avx2.mm256_add_epi8(a, a);
						v256 _4 = Avx2.mm256_add_epi8(_2, _2);
						v256 _128 = mm256_slli_epi8(a, 7);
						return Avx2.mm256_add_epi8(_128, _4);
					}

					case 255:
					{
						return mm256_neg_epi8(a);
					}

					default:
					{
						v256 B = mm256_set1_epi16(b);

						v256 lo = mm256_cvt2x2epu8_epi16(a, out v256 hi);

						lo = Avx2.mm256_mullo_epi16(lo, B);
						hi = Avx2.mm256_mullo_epi16(hi, B);

						return mm256_cvt2x2epi16_epi8(lo, hi);
					}
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}
