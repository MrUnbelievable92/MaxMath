//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        private const bool SHIFT128_IN_RANGE =
#if TESTING
            false;
#else
            true;
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void constshl_epu128(v128 aLo, v128 aHi, int n, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (n)
                {
                    case 1:   rLo = slli_epi64(aLo, 1);     rHi = or_si128(slli_epi64(aHi, 1),  srli_epi64(aLo, (64 - 1)));  return;
                    case 2:   rLo = slli_epi64(aLo, 2);     rHi = or_si128(slli_epi64(aHi, 2),  srli_epi64(aLo, (64 - 2)));  return;
                    case 3:   rLo = slli_epi64(aLo, 3);     rHi = or_si128(slli_epi64(aHi, 3),  srli_epi64(aLo, (64 - 3)));  return;
                    case 4:   rLo = slli_epi64(aLo, 4);     rHi = or_si128(slli_epi64(aHi, 4),  srli_epi64(aLo, (64 - 4)));  return;
                    case 5:   rLo = slli_epi64(aLo, 5);     rHi = or_si128(slli_epi64(aHi, 5),  srli_epi64(aLo, (64 - 5)));  return;
                    case 6:   rLo = slli_epi64(aLo, 6);     rHi = or_si128(slli_epi64(aHi, 6),  srli_epi64(aLo, (64 - 6)));  return;
                    case 7:   rLo = slli_epi64(aLo, 7);     rHi = or_si128(slli_epi64(aHi, 7),  srli_epi64(aLo, (64 - 7)));  return;
                    case 8:   rLo = slli_epi64(aLo, 8);     rHi = or_si128(slli_epi64(aHi, 8),  srli_epi64(aLo, (64 - 8)));  return;
                    case 9:   rLo = slli_epi64(aLo, 9);     rHi = or_si128(slli_epi64(aHi, 9),  srli_epi64(aLo, (64 - 9)));  return;
                    case 10:  rLo = slli_epi64(aLo, 10);    rHi = or_si128(slli_epi64(aHi, 10), srli_epi64(aLo, (64 - 10))); return;
                    case 11:  rLo = slli_epi64(aLo, 11);    rHi = or_si128(slli_epi64(aHi, 11), srli_epi64(aLo, (64 - 11))); return;
                    case 12:  rLo = slli_epi64(aLo, 12);    rHi = or_si128(slli_epi64(aHi, 12), srli_epi64(aLo, (64 - 12))); return;
                    case 13:  rLo = slli_epi64(aLo, 13);    rHi = or_si128(slli_epi64(aHi, 13), srli_epi64(aLo, (64 - 13))); return;
                    case 14:  rLo = slli_epi64(aLo, 14);    rHi = or_si128(slli_epi64(aHi, 14), srli_epi64(aLo, (64 - 14))); return;
                    case 15:  rLo = slli_epi64(aLo, 15);    rHi = or_si128(slli_epi64(aHi, 15), srli_epi64(aLo, (64 - 15))); return;
                    case 16:  rLo = slli_epi64(aLo, 16);    rHi = or_si128(slli_epi64(aHi, 16), srli_epi64(aLo, (64 - 16))); return;
                    case 17:  rLo = slli_epi64(aLo, 17);    rHi = or_si128(slli_epi64(aHi, 17), srli_epi64(aLo, (64 - 17))); return;
                    case 18:  rLo = slli_epi64(aLo, 18);    rHi = or_si128(slli_epi64(aHi, 18), srli_epi64(aLo, (64 - 18))); return;
                    case 19:  rLo = slli_epi64(aLo, 19);    rHi = or_si128(slli_epi64(aHi, 19), srli_epi64(aLo, (64 - 19))); return;
                    case 20:  rLo = slli_epi64(aLo, 20);    rHi = or_si128(slli_epi64(aHi, 20), srli_epi64(aLo, (64 - 20))); return;
                    case 21:  rLo = slli_epi64(aLo, 21);    rHi = or_si128(slli_epi64(aHi, 21), srli_epi64(aLo, (64 - 21))); return;
                    case 22:  rLo = slli_epi64(aLo, 22);    rHi = or_si128(slli_epi64(aHi, 22), srli_epi64(aLo, (64 - 22))); return;
                    case 23:  rLo = slli_epi64(aLo, 23);    rHi = or_si128(slli_epi64(aHi, 23), srli_epi64(aLo, (64 - 23))); return;
                    case 24:  rLo = slli_epi64(aLo, 24);    rHi = or_si128(slli_epi64(aHi, 24), srli_epi64(aLo, (64 - 24))); return;
                    case 25:  rLo = slli_epi64(aLo, 25);    rHi = or_si128(slli_epi64(aHi, 25), srli_epi64(aLo, (64 - 25))); return;
                    case 26:  rLo = slli_epi64(aLo, 26);    rHi = or_si128(slli_epi64(aHi, 26), srli_epi64(aLo, (64 - 26))); return;
                    case 27:  rLo = slli_epi64(aLo, 27);    rHi = or_si128(slli_epi64(aHi, 27), srli_epi64(aLo, (64 - 27))); return;
                    case 28:  rLo = slli_epi64(aLo, 28);    rHi = or_si128(slli_epi64(aHi, 28), srli_epi64(aLo, (64 - 28))); return;
                    case 29:  rLo = slli_epi64(aLo, 29);    rHi = or_si128(slli_epi64(aHi, 29), srli_epi64(aLo, (64 - 29))); return;
                    case 30:  rLo = slli_epi64(aLo, 30);    rHi = or_si128(slli_epi64(aHi, 30), srli_epi64(aLo, (64 - 30))); return;
                    case 31:  rLo = slli_epi64(aLo, 31);    rHi = or_si128(slli_epi64(aHi, 31), srli_epi64(aLo, (64 - 31))); return;
                    case 32:  rLo = slli_epi64(aLo, 32);    rHi = or_si128(slli_epi64(aHi, 32), srli_epi64(aLo, (64 - 32))); return;
                    case 33:  rLo = slli_epi64(aLo, 33);    rHi = or_si128(slli_epi64(aHi, 33), srli_epi64(aLo, (64 - 33))); return;
                    case 34:  rLo = slli_epi64(aLo, 34);    rHi = or_si128(slli_epi64(aHi, 34), srli_epi64(aLo, (64 - 34))); return;
                    case 35:  rLo = slli_epi64(aLo, 35);    rHi = or_si128(slli_epi64(aHi, 35), srli_epi64(aLo, (64 - 35))); return;
                    case 36:  rLo = slli_epi64(aLo, 36);    rHi = or_si128(slli_epi64(aHi, 36), srli_epi64(aLo, (64 - 36))); return;
                    case 37:  rLo = slli_epi64(aLo, 37);    rHi = or_si128(slli_epi64(aHi, 37), srli_epi64(aLo, (64 - 37))); return;
                    case 38:  rLo = slli_epi64(aLo, 38);    rHi = or_si128(slli_epi64(aHi, 38), srli_epi64(aLo, (64 - 38))); return;
                    case 39:  rLo = slli_epi64(aLo, 39);    rHi = or_si128(slli_epi64(aHi, 39), srli_epi64(aLo, (64 - 39))); return;
                    case 40:  rLo = slli_epi64(aLo, 40);    rHi = or_si128(slli_epi64(aHi, 40), srli_epi64(aLo, (64 - 40))); return;
                    case 41:  rLo = slli_epi64(aLo, 41);    rHi = or_si128(slli_epi64(aHi, 41), srli_epi64(aLo, (64 - 41))); return;
                    case 42:  rLo = slli_epi64(aLo, 42);    rHi = or_si128(slli_epi64(aHi, 42), srli_epi64(aLo, (64 - 42))); return;
                    case 43:  rLo = slli_epi64(aLo, 43);    rHi = or_si128(slli_epi64(aHi, 43), srli_epi64(aLo, (64 - 43))); return;
                    case 44:  rLo = slli_epi64(aLo, 44);    rHi = or_si128(slli_epi64(aHi, 44), srli_epi64(aLo, (64 - 44))); return;
                    case 45:  rLo = slli_epi64(aLo, 45);    rHi = or_si128(slli_epi64(aHi, 45), srli_epi64(aLo, (64 - 45))); return;
                    case 46:  rLo = slli_epi64(aLo, 46);    rHi = or_si128(slli_epi64(aHi, 46), srli_epi64(aLo, (64 - 46))); return;
                    case 47:  rLo = slli_epi64(aLo, 47);    rHi = or_si128(slli_epi64(aHi, 47), srli_epi64(aLo, (64 - 47))); return;
                    case 48:  rLo = slli_epi64(aLo, 48);    rHi = or_si128(slli_epi64(aHi, 48), srli_epi64(aLo, (64 - 48))); return;
                    case 49:  rLo = slli_epi64(aLo, 49);    rHi = or_si128(slli_epi64(aHi, 49), srli_epi64(aLo, (64 - 49))); return;
                    case 50:  rLo = slli_epi64(aLo, 50);    rHi = or_si128(slli_epi64(aHi, 50), srli_epi64(aLo, (64 - 50))); return;
                    case 51:  rLo = slli_epi64(aLo, 51);    rHi = or_si128(slli_epi64(aHi, 51), srli_epi64(aLo, (64 - 51))); return;
                    case 52:  rLo = slli_epi64(aLo, 52);    rHi = or_si128(slli_epi64(aHi, 52), srli_epi64(aLo, (64 - 52))); return;
                    case 53:  rLo = slli_epi64(aLo, 53);    rHi = or_si128(slli_epi64(aHi, 53), srli_epi64(aLo, (64 - 53))); return;
                    case 54:  rLo = slli_epi64(aLo, 54);    rHi = or_si128(slli_epi64(aHi, 54), srli_epi64(aLo, (64 - 54))); return;
                    case 55:  rLo = slli_epi64(aLo, 55);    rHi = or_si128(slli_epi64(aHi, 55), srli_epi64(aLo, (64 - 55))); return;
                    case 56:  rLo = slli_epi64(aLo, 56);    rHi = or_si128(slli_epi64(aHi, 56), srli_epi64(aLo, (64 - 56))); return;
                    case 57:  rLo = slli_epi64(aLo, 57);    rHi = or_si128(slli_epi64(aHi, 57), srli_epi64(aLo, (64 - 57))); return;
                    case 58:  rLo = slli_epi64(aLo, 58);    rHi = or_si128(slli_epi64(aHi, 58), srli_epi64(aLo, (64 - 58))); return;
                    case 59:  rLo = slli_epi64(aLo, 59);    rHi = or_si128(slli_epi64(aHi, 59), srli_epi64(aLo, (64 - 59))); return;
                    case 60:  rLo = slli_epi64(aLo, 60);    rHi = or_si128(slli_epi64(aHi, 60), srli_epi64(aLo, (64 - 60))); return;
                    case 61:  rLo = slli_epi64(aLo, 61);    rHi = or_si128(slli_epi64(aHi, 61), srli_epi64(aLo, (64 - 61))); return;
                    case 62:  rLo = slli_epi64(aLo, 62);    rHi = or_si128(slli_epi64(aHi, 62), srli_epi64(aLo, (64 - 62))); return;
                    case 63:  rLo = slli_epi64(aLo, 63);    rHi = or_si128(slli_epi64(aHi, 63), srli_epi64(aLo, (64 - 63))); return;
                    case 64:  rLo = setzero_si128();        rHi = aLo;                                                       return;
                    case 65:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 1);                                        return;
                    case 66:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 2);                                        return;
                    case 67:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 3);                                        return;
                    case 68:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 4);                                        return;
                    case 69:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 5);                                        return;
                    case 70:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 6);                                        return;
                    case 71:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 7);                                        return;
                    case 72:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 8);                                        return;
                    case 73:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 9);                                        return;
                    case 74:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 10);                                       return;
                    case 75:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 11);                                       return;
                    case 76:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 12);                                       return;
                    case 77:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 13);                                       return;
                    case 78:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 14);                                       return;
                    case 79:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 15);                                       return;
                    case 80:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 16);                                       return;
                    case 81:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 17);                                       return;
                    case 82:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 18);                                       return;
                    case 83:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 19);                                       return;
                    case 84:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 20);                                       return;
                    case 85:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 21);                                       return;
                    case 86:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 22);                                       return;
                    case 87:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 23);                                       return;
                    case 88:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 24);                                       return;
                    case 89:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 25);                                       return;
                    case 90:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 26);                                       return;
                    case 91:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 27);                                       return;
                    case 92:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 28);                                       return;
                    case 93:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 29);                                       return;
                    case 94:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 30);                                       return;
                    case 95:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 31);                                       return;
                    case 96:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 32);                                       return;
                    case 97:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 33);                                       return;
                    case 98:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 34);                                       return;
                    case 99:  rLo = setzero_si128();        rHi = slli_epi64(aLo, 35);                                       return;
                    case 100: rLo = setzero_si128();        rHi = slli_epi64(aLo, 36);                                       return;
                    case 101: rLo = setzero_si128();        rHi = slli_epi64(aLo, 37);                                       return;
                    case 102: rLo = setzero_si128();        rHi = slli_epi64(aLo, 38);                                       return;
                    case 103: rLo = setzero_si128();        rHi = slli_epi64(aLo, 39);                                       return;
                    case 104: rLo = setzero_si128();        rHi = slli_epi64(aLo, 40);                                       return;
                    case 105: rLo = setzero_si128();        rHi = slli_epi64(aLo, 41);                                       return;
                    case 106: rLo = setzero_si128();        rHi = slli_epi64(aLo, 42);                                       return;
                    case 107: rLo = setzero_si128();        rHi = slli_epi64(aLo, 43);                                       return;
                    case 108: rLo = setzero_si128();        rHi = slli_epi64(aLo, 44);                                       return;
                    case 109: rLo = setzero_si128();        rHi = slli_epi64(aLo, 45);                                       return;
                    case 110: rLo = setzero_si128();        rHi = slli_epi64(aLo, 46);                                       return;
                    case 111: rLo = setzero_si128();        rHi = slli_epi64(aLo, 47);                                       return;
                    case 112: rLo = setzero_si128();        rHi = slli_epi64(aLo, 48);                                       return;
                    case 113: rLo = setzero_si128();        rHi = slli_epi64(aLo, 49);                                       return;
                    case 114: rLo = setzero_si128();        rHi = slli_epi64(aLo, 50);                                       return;
                    case 115: rLo = setzero_si128();        rHi = slli_epi64(aLo, 51);                                       return;
                    case 116: rLo = setzero_si128();        rHi = slli_epi64(aLo, 52);                                       return;
                    case 117: rLo = setzero_si128();        rHi = slli_epi64(aLo, 53);                                       return;
                    case 118: rLo = setzero_si128();        rHi = slli_epi64(aLo, 54);                                       return;
                    case 119: rLo = setzero_si128();        rHi = slli_epi64(aLo, 55);                                       return;
                    case 120: rLo = setzero_si128();        rHi = slli_epi64(aLo, 56);                                       return;
                    case 121: rLo = setzero_si128();        rHi = slli_epi64(aLo, 57);                                       return;
                    case 122: rLo = setzero_si128();        rHi = slli_epi64(aLo, 58);                                       return;
                    case 123: rLo = setzero_si128();        rHi = slli_epi64(aLo, 59);                                       return;
                    case 124: rLo = setzero_si128();        rHi = slli_epi64(aLo, 60);                                       return;
                    case 125: rLo = setzero_si128();        rHi = slli_epi64(aLo, 61);                                       return;
                    case 126: rLo = setzero_si128();        rHi = slli_epi64(aLo, 62);                                       return;
                    case 127: rLo = setzero_si128();        rHi = slli_epi64(aLo, 63);                                       return;

                    default:  rLo = aLo;                    rHi = aHi;                                                       return;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void constshr_epu128(v128 aLo, v128 aHi, int n, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (n)
                {
                    case 1:    rLo = or_si128(srli_epi64(aLo, 1),  slli_epi64(aHi, (64 - 1)));     rHi = srli_epi64(aHi, 1);  return;
                    case 2:    rLo = or_si128(srli_epi64(aLo, 2),  slli_epi64(aHi, (64 - 2)));     rHi = srli_epi64(aHi, 2);  return;
                    case 3:    rLo = or_si128(srli_epi64(aLo, 3),  slli_epi64(aHi, (64 - 3)));     rHi = srli_epi64(aHi, 3);  return;
                    case 4:    rLo = or_si128(srli_epi64(aLo, 4),  slli_epi64(aHi, (64 - 4)));     rHi = srli_epi64(aHi, 4);  return;
                    case 5:    rLo = or_si128(srli_epi64(aLo, 5),  slli_epi64(aHi, (64 - 5)));     rHi = srli_epi64(aHi, 5);  return;
                    case 6:    rLo = or_si128(srli_epi64(aLo, 6),  slli_epi64(aHi, (64 - 6)));     rHi = srli_epi64(aHi, 6);  return;
                    case 7:    rLo = or_si128(srli_epi64(aLo, 7),  slli_epi64(aHi, (64 - 7)));     rHi = srli_epi64(aHi, 7);  return;
                    case 8:    rLo = or_si128(srli_epi64(aLo, 8),  slli_epi64(aHi, (64 - 8)));     rHi = srli_epi64(aHi, 8);  return;
                    case 9:    rLo = or_si128(srli_epi64(aLo, 9),  slli_epi64(aHi, (64 - 9)));     rHi = srli_epi64(aHi, 9);  return;
                    case 10:   rLo = or_si128(srli_epi64(aLo, 10), slli_epi64(aHi, (64 - 10)));    rHi = srli_epi64(aHi, 10); return;
                    case 11:   rLo = or_si128(srli_epi64(aLo, 11), slli_epi64(aHi, (64 - 11)));    rHi = srli_epi64(aHi, 11); return;
                    case 12:   rLo = or_si128(srli_epi64(aLo, 12), slli_epi64(aHi, (64 - 12)));    rHi = srli_epi64(aHi, 12); return;
                    case 13:   rLo = or_si128(srli_epi64(aLo, 13), slli_epi64(aHi, (64 - 13)));    rHi = srli_epi64(aHi, 13); return;
                    case 14:   rLo = or_si128(srli_epi64(aLo, 14), slli_epi64(aHi, (64 - 14)));    rHi = srli_epi64(aHi, 14); return;
                    case 15:   rLo = or_si128(srli_epi64(aLo, 15), slli_epi64(aHi, (64 - 15)));    rHi = srli_epi64(aHi, 15); return;
                    case 16:   rLo = or_si128(srli_epi64(aLo, 16), slli_epi64(aHi, (64 - 16)));    rHi = srli_epi64(aHi, 16); return;
                    case 17:   rLo = or_si128(srli_epi64(aLo, 17), slli_epi64(aHi, (64 - 17)));    rHi = srli_epi64(aHi, 17); return;
                    case 18:   rLo = or_si128(srli_epi64(aLo, 18), slli_epi64(aHi, (64 - 18)));    rHi = srli_epi64(aHi, 18); return;
                    case 19:   rLo = or_si128(srli_epi64(aLo, 19), slli_epi64(aHi, (64 - 19)));    rHi = srli_epi64(aHi, 19); return;
                    case 20:   rLo = or_si128(srli_epi64(aLo, 20), slli_epi64(aHi, (64 - 20)));    rHi = srli_epi64(aHi, 20); return;
                    case 21:   rLo = or_si128(srli_epi64(aLo, 21), slli_epi64(aHi, (64 - 21)));    rHi = srli_epi64(aHi, 21); return;
                    case 22:   rLo = or_si128(srli_epi64(aLo, 22), slli_epi64(aHi, (64 - 22)));    rHi = srli_epi64(aHi, 22); return;
                    case 23:   rLo = or_si128(srli_epi64(aLo, 23), slli_epi64(aHi, (64 - 23)));    rHi = srli_epi64(aHi, 23); return;
                    case 24:   rLo = or_si128(srli_epi64(aLo, 24), slli_epi64(aHi, (64 - 24)));    rHi = srli_epi64(aHi, 24); return;
                    case 25:   rLo = or_si128(srli_epi64(aLo, 25), slli_epi64(aHi, (64 - 25)));    rHi = srli_epi64(aHi, 25); return;
                    case 26:   rLo = or_si128(srli_epi64(aLo, 26), slli_epi64(aHi, (64 - 26)));    rHi = srli_epi64(aHi, 26); return;
                    case 27:   rLo = or_si128(srli_epi64(aLo, 27), slli_epi64(aHi, (64 - 27)));    rHi = srli_epi64(aHi, 27); return;
                    case 28:   rLo = or_si128(srli_epi64(aLo, 28), slli_epi64(aHi, (64 - 28)));    rHi = srli_epi64(aHi, 28); return;
                    case 29:   rLo = or_si128(srli_epi64(aLo, 29), slli_epi64(aHi, (64 - 29)));    rHi = srli_epi64(aHi, 29); return;
                    case 30:   rLo = or_si128(srli_epi64(aLo, 30), slli_epi64(aHi, (64 - 30)));    rHi = srli_epi64(aHi, 30); return;
                    case 31:   rLo = or_si128(srli_epi64(aLo, 31), slli_epi64(aHi, (64 - 31)));    rHi = srli_epi64(aHi, 31); return;
                    case 32:   rLo = or_si128(srli_epi64(aLo, 32), slli_epi64(aHi, (64 - 32)));    rHi = srli_epi64(aHi, 32); return;
                    case 33:   rLo = or_si128(srli_epi64(aLo, 33), slli_epi64(aHi, (64 - 33)));    rHi = srli_epi64(aHi, 33); return;
                    case 34:   rLo = or_si128(srli_epi64(aLo, 34), slli_epi64(aHi, (64 - 34)));    rHi = srli_epi64(aHi, 34); return;
                    case 35:   rLo = or_si128(srli_epi64(aLo, 35), slli_epi64(aHi, (64 - 35)));    rHi = srli_epi64(aHi, 35); return;
                    case 36:   rLo = or_si128(srli_epi64(aLo, 36), slli_epi64(aHi, (64 - 36)));    rHi = srli_epi64(aHi, 36); return;
                    case 37:   rLo = or_si128(srli_epi64(aLo, 37), slli_epi64(aHi, (64 - 37)));    rHi = srli_epi64(aHi, 37); return;
                    case 38:   rLo = or_si128(srli_epi64(aLo, 38), slli_epi64(aHi, (64 - 38)));    rHi = srli_epi64(aHi, 38); return;
                    case 39:   rLo = or_si128(srli_epi64(aLo, 39), slli_epi64(aHi, (64 - 39)));    rHi = srli_epi64(aHi, 39); return;
                    case 40:   rLo = or_si128(srli_epi64(aLo, 40), slli_epi64(aHi, (64 - 40)));    rHi = srli_epi64(aHi, 40); return;
                    case 41:   rLo = or_si128(srli_epi64(aLo, 41), slli_epi64(aHi, (64 - 41)));    rHi = srli_epi64(aHi, 41); return;
                    case 42:   rLo = or_si128(srli_epi64(aLo, 42), slli_epi64(aHi, (64 - 42)));    rHi = srli_epi64(aHi, 42); return;
                    case 43:   rLo = or_si128(srli_epi64(aLo, 43), slli_epi64(aHi, (64 - 43)));    rHi = srli_epi64(aHi, 43); return;
                    case 44:   rLo = or_si128(srli_epi64(aLo, 44), slli_epi64(aHi, (64 - 44)));    rHi = srli_epi64(aHi, 44); return;
                    case 45:   rLo = or_si128(srli_epi64(aLo, 45), slli_epi64(aHi, (64 - 45)));    rHi = srli_epi64(aHi, 45); return;
                    case 46:   rLo = or_si128(srli_epi64(aLo, 46), slli_epi64(aHi, (64 - 46)));    rHi = srli_epi64(aHi, 46); return;
                    case 47:   rLo = or_si128(srli_epi64(aLo, 47), slli_epi64(aHi, (64 - 47)));    rHi = srli_epi64(aHi, 47); return;
                    case 48:   rLo = or_si128(srli_epi64(aLo, 48), slli_epi64(aHi, (64 - 48)));    rHi = srli_epi64(aHi, 48); return;
                    case 49:   rLo = or_si128(srli_epi64(aLo, 49), slli_epi64(aHi, (64 - 49)));    rHi = srli_epi64(aHi, 49); return;
                    case 50:   rLo = or_si128(srli_epi64(aLo, 50), slli_epi64(aHi, (64 - 50)));    rHi = srli_epi64(aHi, 50); return;
                    case 51:   rLo = or_si128(srli_epi64(aLo, 51), slli_epi64(aHi, (64 - 51)));    rHi = srli_epi64(aHi, 51); return;
                    case 52:   rLo = or_si128(srli_epi64(aLo, 52), slli_epi64(aHi, (64 - 52)));    rHi = srli_epi64(aHi, 52); return;
                    case 53:   rLo = or_si128(srli_epi64(aLo, 53), slli_epi64(aHi, (64 - 53)));    rHi = srli_epi64(aHi, 53); return;
                    case 54:   rLo = or_si128(srli_epi64(aLo, 54), slli_epi64(aHi, (64 - 54)));    rHi = srli_epi64(aHi, 54); return;
                    case 55:   rLo = or_si128(srli_epi64(aLo, 55), slli_epi64(aHi, (64 - 55)));    rHi = srli_epi64(aHi, 55); return;
                    case 56:   rLo = or_si128(srli_epi64(aLo, 56), slli_epi64(aHi, (64 - 56)));    rHi = srli_epi64(aHi, 56); return;
                    case 57:   rLo = or_si128(srli_epi64(aLo, 57), slli_epi64(aHi, (64 - 57)));    rHi = srli_epi64(aHi, 57); return;
                    case 58:   rLo = or_si128(srli_epi64(aLo, 58), slli_epi64(aHi, (64 - 58)));    rHi = srli_epi64(aHi, 58); return;
                    case 59:   rLo = or_si128(srli_epi64(aLo, 59), slli_epi64(aHi, (64 - 59)));    rHi = srli_epi64(aHi, 59); return;
                    case 60:   rLo = or_si128(srli_epi64(aLo, 60), slli_epi64(aHi, (64 - 60)));    rHi = srli_epi64(aHi, 60); return;
                    case 61:   rLo = or_si128(srli_epi64(aLo, 61), slli_epi64(aHi, (64 - 61)));    rHi = srli_epi64(aHi, 61); return;
                    case 62:   rLo = or_si128(srli_epi64(aLo, 62), slli_epi64(aHi, (64 - 62)));    rHi = srli_epi64(aHi, 62); return;
                    case 63:   rLo = or_si128(srli_epi64(aLo, 63), slli_epi64(aHi, (64 - 63)));    rHi = srli_epi64(aHi, 63); return;
                    case 64:   rLo = aHi;                                                          rHi = setzero_si128();     return;
                    case 65:   rLo = srli_epi64(aHi, 1);                                           rHi = setzero_si128();     return;
                    case 66:   rLo = srli_epi64(aHi, 2);                                           rHi = setzero_si128();     return;
                    case 67:   rLo = srli_epi64(aHi, 3);                                           rHi = setzero_si128();     return;
                    case 68:   rLo = srli_epi64(aHi, 4);                                           rHi = setzero_si128();     return;
                    case 69:   rLo = srli_epi64(aHi, 5);                                           rHi = setzero_si128();     return;
                    case 70:   rLo = srli_epi64(aHi, 6);                                           rHi = setzero_si128();     return;
                    case 71:   rLo = srli_epi64(aHi, 7);                                           rHi = setzero_si128();     return;
                    case 72:   rLo = srli_epi64(aHi, 8);                                           rHi = setzero_si128();     return;
                    case 73:   rLo = srli_epi64(aHi, 9);                                           rHi = setzero_si128();     return;
                    case 74:   rLo = srli_epi64(aHi, 10);                                          rHi = setzero_si128();     return;
                    case 75:   rLo = srli_epi64(aHi, 11);                                          rHi = setzero_si128();     return;
                    case 76:   rLo = srli_epi64(aHi, 12);                                          rHi = setzero_si128();     return;
                    case 77:   rLo = srli_epi64(aHi, 13);                                          rHi = setzero_si128();     return;
                    case 78:   rLo = srli_epi64(aHi, 14);                                          rHi = setzero_si128();     return;
                    case 79:   rLo = srli_epi64(aHi, 15);                                          rHi = setzero_si128();     return;
                    case 80:   rLo = srli_epi64(aHi, 16);                                          rHi = setzero_si128();     return;
                    case 81:   rLo = srli_epi64(aHi, 17);                                          rHi = setzero_si128();     return;
                    case 82:   rLo = srli_epi64(aHi, 18);                                          rHi = setzero_si128();     return;
                    case 83:   rLo = srli_epi64(aHi, 19);                                          rHi = setzero_si128();     return;
                    case 84:   rLo = srli_epi64(aHi, 20);                                          rHi = setzero_si128();     return;
                    case 85:   rLo = srli_epi64(aHi, 21);                                          rHi = setzero_si128();     return;
                    case 86:   rLo = srli_epi64(aHi, 22);                                          rHi = setzero_si128();     return;
                    case 87:   rLo = srli_epi64(aHi, 23);                                          rHi = setzero_si128();     return;
                    case 88:   rLo = srli_epi64(aHi, 24);                                          rHi = setzero_si128();     return;
                    case 89:   rLo = srli_epi64(aHi, 25);                                          rHi = setzero_si128();     return;
                    case 90:   rLo = srli_epi64(aHi, 26);                                          rHi = setzero_si128();     return;
                    case 91:   rLo = srli_epi64(aHi, 27);                                          rHi = setzero_si128();     return;
                    case 92:   rLo = srli_epi64(aHi, 28);                                          rHi = setzero_si128();     return;
                    case 93:   rLo = srli_epi64(aHi, 29);                                          rHi = setzero_si128();     return;
                    case 94:   rLo = srli_epi64(aHi, 30);                                          rHi = setzero_si128();     return;
                    case 95:   rLo = srli_epi64(aHi, 31);                                          rHi = setzero_si128();     return;
                    case 96:   rLo = srli_epi64(aHi, 32);                                          rHi = setzero_si128();     return;
                    case 97:   rLo = srli_epi64(aHi, 33);                                          rHi = setzero_si128();     return;
                    case 98:   rLo = srli_epi64(aHi, 34);                                          rHi = setzero_si128();     return;
                    case 99:   rLo = srli_epi64(aHi, 35);                                          rHi = setzero_si128();     return;
                    case 100:  rLo = srli_epi64(aHi, 36);                                          rHi = setzero_si128();     return;
                    case 101:  rLo = srli_epi64(aHi, 37);                                          rHi = setzero_si128();     return;
                    case 102:  rLo = srli_epi64(aHi, 38);                                          rHi = setzero_si128();     return;
                    case 103:  rLo = srli_epi64(aHi, 39);                                          rHi = setzero_si128();     return;
                    case 104:  rLo = srli_epi64(aHi, 40);                                          rHi = setzero_si128();     return;
                    case 105:  rLo = srli_epi64(aHi, 41);                                          rHi = setzero_si128();     return;
                    case 106:  rLo = srli_epi64(aHi, 42);                                          rHi = setzero_si128();     return;
                    case 107:  rLo = srli_epi64(aHi, 43);                                          rHi = setzero_si128();     return;
                    case 108:  rLo = srli_epi64(aHi, 44);                                          rHi = setzero_si128();     return;
                    case 109:  rLo = srli_epi64(aHi, 45);                                          rHi = setzero_si128();     return;
                    case 110:  rLo = srli_epi64(aHi, 46);                                          rHi = setzero_si128();     return;
                    case 111:  rLo = srli_epi64(aHi, 47);                                          rHi = setzero_si128();     return;
                    case 112:  rLo = srli_epi64(aHi, 48);                                          rHi = setzero_si128();     return;
                    case 113:  rLo = srli_epi64(aHi, 49);                                          rHi = setzero_si128();     return;
                    case 114:  rLo = srli_epi64(aHi, 50);                                          rHi = setzero_si128();     return;
                    case 115:  rLo = srli_epi64(aHi, 51);                                          rHi = setzero_si128();     return;
                    case 116:  rLo = srli_epi64(aHi, 52);                                          rHi = setzero_si128();     return;
                    case 117:  rLo = srli_epi64(aHi, 53);                                          rHi = setzero_si128();     return;
                    case 118:  rLo = srli_epi64(aHi, 54);                                          rHi = setzero_si128();     return;
                    case 119:  rLo = srli_epi64(aHi, 55);                                          rHi = setzero_si128();     return;
                    case 120:  rLo = srli_epi64(aHi, 56);                                          rHi = setzero_si128();     return;
                    case 121:  rLo = srli_epi64(aHi, 57);                                          rHi = setzero_si128();     return;
                    case 122:  rLo = srli_epi64(aHi, 58);                                          rHi = setzero_si128();     return;
                    case 123:  rLo = srli_epi64(aHi, 59);                                          rHi = setzero_si128();     return;
                    case 124:  rLo = srli_epi64(aHi, 60);                                          rHi = setzero_si128();     return;
                    case 125:  rLo = srli_epi64(aHi, 61);                                          rHi = setzero_si128();     return;
                    case 126:  rLo = srli_epi64(aHi, 62);                                          rHi = setzero_si128();     return;
                    case 127:  rLo = srli_epi64(aHi, 63);                                          rHi = setzero_si128();     return;

                    default:  rLo = aLo;                                                           rHi = aHi;                 return;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void constsar_epu128(v128 aLo, v128 aHi, int n, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (n)
                {
                    case 1:   rLo = or_si128(srli_epi64(aLo, 1) , slli_epi64(aHi, (64 - 1)));     rHi = srai_epi64(aHi, 1);  return;
                    case 2:   rLo = or_si128(srli_epi64(aLo, 2) , slli_epi64(aHi, (64 - 2)));     rHi = srai_epi64(aHi, 2);  return;
                    case 3:   rLo = or_si128(srli_epi64(aLo, 3) , slli_epi64(aHi, (64 - 3)));     rHi = srai_epi64(aHi, 3);  return;
                    case 4:   rLo = or_si128(srli_epi64(aLo, 4) , slli_epi64(aHi, (64 - 4)));     rHi = srai_epi64(aHi, 4);  return;
                    case 5:   rLo = or_si128(srli_epi64(aLo, 5) , slli_epi64(aHi, (64 - 5)));     rHi = srai_epi64(aHi, 5);  return;
                    case 6:   rLo = or_si128(srli_epi64(aLo, 6) , slli_epi64(aHi, (64 - 6)));     rHi = srai_epi64(aHi, 6);  return;
                    case 7:   rLo = or_si128(srli_epi64(aLo, 7) , slli_epi64(aHi, (64 - 7)));     rHi = srai_epi64(aHi, 7);  return;
                    case 8:   rLo = or_si128(srli_epi64(aLo, 8) , slli_epi64(aHi, (64 - 8)));     rHi = srai_epi64(aHi, 8);  return;
                    case 9:   rLo = or_si128(srli_epi64(aLo, 9) , slli_epi64(aHi, (64 - 9)));     rHi = srai_epi64(aHi, 9);  return;
                    case 10:  rLo = or_si128(srli_epi64(aLo, 10), slli_epi64(aHi, (64 - 10)));    rHi = srai_epi64(aHi, 10); return;
                    case 11:  rLo = or_si128(srli_epi64(aLo, 11), slli_epi64(aHi, (64 - 11)));    rHi = srai_epi64(aHi, 11); return;
                    case 12:  rLo = or_si128(srli_epi64(aLo, 12), slli_epi64(aHi, (64 - 12)));    rHi = srai_epi64(aHi, 12); return;
                    case 13:  rLo = or_si128(srli_epi64(aLo, 13), slli_epi64(aHi, (64 - 13)));    rHi = srai_epi64(aHi, 13); return;
                    case 14:  rLo = or_si128(srli_epi64(aLo, 14), slli_epi64(aHi, (64 - 14)));    rHi = srai_epi64(aHi, 14); return;
                    case 15:  rLo = or_si128(srli_epi64(aLo, 15), slli_epi64(aHi, (64 - 15)));    rHi = srai_epi64(aHi, 15); return;
                    case 16:  rLo = or_si128(srli_epi64(aLo, 16), slli_epi64(aHi, (64 - 16)));    rHi = srai_epi64(aHi, 16); return;
                    case 17:  rLo = or_si128(srli_epi64(aLo, 17), slli_epi64(aHi, (64 - 17)));    rHi = srai_epi64(aHi, 17); return;
                    case 18:  rLo = or_si128(srli_epi64(aLo, 18), slli_epi64(aHi, (64 - 18)));    rHi = srai_epi64(aHi, 18); return;
                    case 19:  rLo = or_si128(srli_epi64(aLo, 19), slli_epi64(aHi, (64 - 19)));    rHi = srai_epi64(aHi, 19); return;
                    case 20:  rLo = or_si128(srli_epi64(aLo, 20), slli_epi64(aHi, (64 - 20)));    rHi = srai_epi64(aHi, 20); return;
                    case 21:  rLo = or_si128(srli_epi64(aLo, 21), slli_epi64(aHi, (64 - 21)));    rHi = srai_epi64(aHi, 21); return;
                    case 22:  rLo = or_si128(srli_epi64(aLo, 22), slli_epi64(aHi, (64 - 22)));    rHi = srai_epi64(aHi, 22); return;
                    case 23:  rLo = or_si128(srli_epi64(aLo, 23), slli_epi64(aHi, (64 - 23)));    rHi = srai_epi64(aHi, 23); return;
                    case 24:  rLo = or_si128(srli_epi64(aLo, 24), slli_epi64(aHi, (64 - 24)));    rHi = srai_epi64(aHi, 24); return;
                    case 25:  rLo = or_si128(srli_epi64(aLo, 25), slli_epi64(aHi, (64 - 25)));    rHi = srai_epi64(aHi, 25); return;
                    case 26:  rLo = or_si128(srli_epi64(aLo, 26), slli_epi64(aHi, (64 - 26)));    rHi = srai_epi64(aHi, 26); return;
                    case 27:  rLo = or_si128(srli_epi64(aLo, 27), slli_epi64(aHi, (64 - 27)));    rHi = srai_epi64(aHi, 27); return;
                    case 28:  rLo = or_si128(srli_epi64(aLo, 28), slli_epi64(aHi, (64 - 28)));    rHi = srai_epi64(aHi, 28); return;
                    case 29:  rLo = or_si128(srli_epi64(aLo, 29), slli_epi64(aHi, (64 - 29)));    rHi = srai_epi64(aHi, 29); return;
                    case 30:  rLo = or_si128(srli_epi64(aLo, 30), slli_epi64(aHi, (64 - 30)));    rHi = srai_epi64(aHi, 30); return;
                    case 31:  rLo = or_si128(srli_epi64(aLo, 31), slli_epi64(aHi, (64 - 31)));    rHi = srai_epi64(aHi, 31); return;
                    case 32:  rLo = or_si128(srli_epi64(aLo, 32), slli_epi64(aHi, (64 - 32)));    rHi = srai_epi64(aHi, 32); return;
                    case 33:  rLo = or_si128(srli_epi64(aLo, 33), slli_epi64(aHi, (64 - 33)));    rHi = srai_epi64(aHi, 33); return;
                    case 34:  rLo = or_si128(srli_epi64(aLo, 34), slli_epi64(aHi, (64 - 34)));    rHi = srai_epi64(aHi, 34); return;
                    case 35:  rLo = or_si128(srli_epi64(aLo, 35), slli_epi64(aHi, (64 - 35)));    rHi = srai_epi64(aHi, 35); return;
                    case 36:  rLo = or_si128(srli_epi64(aLo, 36), slli_epi64(aHi, (64 - 36)));    rHi = srai_epi64(aHi, 36); return;
                    case 37:  rLo = or_si128(srli_epi64(aLo, 37), slli_epi64(aHi, (64 - 37)));    rHi = srai_epi64(aHi, 37); return;
                    case 38:  rLo = or_si128(srli_epi64(aLo, 38), slli_epi64(aHi, (64 - 38)));    rHi = srai_epi64(aHi, 38); return;
                    case 39:  rLo = or_si128(srli_epi64(aLo, 39), slli_epi64(aHi, (64 - 39)));    rHi = srai_epi64(aHi, 39); return;
                    case 40:  rLo = or_si128(srli_epi64(aLo, 40), slli_epi64(aHi, (64 - 40)));    rHi = srai_epi64(aHi, 40); return;
                    case 41:  rLo = or_si128(srli_epi64(aLo, 41), slli_epi64(aHi, (64 - 41)));    rHi = srai_epi64(aHi, 41); return;
                    case 42:  rLo = or_si128(srli_epi64(aLo, 42), slli_epi64(aHi, (64 - 42)));    rHi = srai_epi64(aHi, 42); return;
                    case 43:  rLo = or_si128(srli_epi64(aLo, 43), slli_epi64(aHi, (64 - 43)));    rHi = srai_epi64(aHi, 43); return;
                    case 44:  rLo = or_si128(srli_epi64(aLo, 44), slli_epi64(aHi, (64 - 44)));    rHi = srai_epi64(aHi, 44); return;
                    case 45:  rLo = or_si128(srli_epi64(aLo, 45), slli_epi64(aHi, (64 - 45)));    rHi = srai_epi64(aHi, 45); return;
                    case 46:  rLo = or_si128(srli_epi64(aLo, 46), slli_epi64(aHi, (64 - 46)));    rHi = srai_epi64(aHi, 46); return;
                    case 47:  rLo = or_si128(srli_epi64(aLo, 47), slli_epi64(aHi, (64 - 47)));    rHi = srai_epi64(aHi, 47); return;
                    case 48:  rLo = or_si128(srli_epi64(aLo, 48), slli_epi64(aHi, (64 - 48)));    rHi = srai_epi64(aHi, 48); return;
                    case 49:  rLo = or_si128(srli_epi64(aLo, 49), slli_epi64(aHi, (64 - 49)));    rHi = srai_epi64(aHi, 49); return;
                    case 50:  rLo = or_si128(srli_epi64(aLo, 50), slli_epi64(aHi, (64 - 50)));    rHi = srai_epi64(aHi, 50); return;
                    case 51:  rLo = or_si128(srli_epi64(aLo, 51), slli_epi64(aHi, (64 - 51)));    rHi = srai_epi64(aHi, 51); return;
                    case 52:  rLo = or_si128(srli_epi64(aLo, 52), slli_epi64(aHi, (64 - 52)));    rHi = srai_epi64(aHi, 52); return;
                    case 53:  rLo = or_si128(srli_epi64(aLo, 53), slli_epi64(aHi, (64 - 53)));    rHi = srai_epi64(aHi, 53); return;
                    case 54:  rLo = or_si128(srli_epi64(aLo, 54), slli_epi64(aHi, (64 - 54)));    rHi = srai_epi64(aHi, 54); return;
                    case 55:  rLo = or_si128(srli_epi64(aLo, 55), slli_epi64(aHi, (64 - 55)));    rHi = srai_epi64(aHi, 55); return;
                    case 56:  rLo = or_si128(srli_epi64(aLo, 56), slli_epi64(aHi, (64 - 56)));    rHi = srai_epi64(aHi, 56); return;
                    case 57:  rLo = or_si128(srli_epi64(aLo, 57), slli_epi64(aHi, (64 - 57)));    rHi = srai_epi64(aHi, 57); return;
                    case 58:  rLo = or_si128(srli_epi64(aLo, 58), slli_epi64(aHi, (64 - 58)));    rHi = srai_epi64(aHi, 58); return;
                    case 59:  rLo = or_si128(srli_epi64(aLo, 59), slli_epi64(aHi, (64 - 59)));    rHi = srai_epi64(aHi, 59); return;
                    case 60:  rLo = or_si128(srli_epi64(aLo, 60), slli_epi64(aHi, (64 - 60)));    rHi = srai_epi64(aHi, 60); return;
                    case 61:  rLo = or_si128(srli_epi64(aLo, 61), slli_epi64(aHi, (64 - 61)));    rHi = srai_epi64(aHi, 61); return;
                    case 62:  rLo = or_si128(srli_epi64(aLo, 62), slli_epi64(aHi, (64 - 62)));    rHi = srai_epi64(aHi, 62); return;
                    case 63:  rLo = or_si128(srli_epi64(aLo, 63), slli_epi64(aHi, (64 - 63)));    rHi = srai_epi64(aHi, 63); return;
                    case 64:  rLo = aHi;                                                          rHi = srai_epi64(aHi, 63); return;
                    case 65:  rLo = srai_epi64(aHi, 1);                                           rHi = srai_epi64(aHi, 63); return;
                    case 66:  rLo = srai_epi64(aHi, 2);                                           rHi = srai_epi64(aHi, 63); return;
                    case 67:  rLo = srai_epi64(aHi, 3);                                           rHi = srai_epi64(aHi, 63); return;
                    case 68:  rLo = srai_epi64(aHi, 4);                                           rHi = srai_epi64(aHi, 63); return;
                    case 69:  rLo = srai_epi64(aHi, 5);                                           rHi = srai_epi64(aHi, 63); return;
                    case 70:  rLo = srai_epi64(aHi, 6);                                           rHi = srai_epi64(aHi, 63); return;
                    case 71:  rLo = srai_epi64(aHi, 7);                                           rHi = srai_epi64(aHi, 63); return;
                    case 72:  rLo = srai_epi64(aHi, 8);                                           rHi = srai_epi64(aHi, 63); return;
                    case 73:  rLo = srai_epi64(aHi, 9);                                           rHi = srai_epi64(aHi, 63); return;
                    case 74:  rLo = srai_epi64(aHi, 10);                                          rHi = srai_epi64(aHi, 63); return;
                    case 75:  rLo = srai_epi64(aHi, 11);                                          rHi = srai_epi64(aHi, 63); return;
                    case 76:  rLo = srai_epi64(aHi, 12);                                          rHi = srai_epi64(aHi, 63); return;
                    case 77:  rLo = srai_epi64(aHi, 13);                                          rHi = srai_epi64(aHi, 63); return;
                    case 78:  rLo = srai_epi64(aHi, 14);                                          rHi = srai_epi64(aHi, 63); return;
                    case 79:  rLo = srai_epi64(aHi, 15);                                          rHi = srai_epi64(aHi, 63); return;
                    case 80:  rLo = srai_epi64(aHi, 16);                                          rHi = srai_epi64(aHi, 63); return;
                    case 81:  rLo = srai_epi64(aHi, 17);                                          rHi = srai_epi64(aHi, 63); return;
                    case 82:  rLo = srai_epi64(aHi, 18);                                          rHi = srai_epi64(aHi, 63); return;
                    case 83:  rLo = srai_epi64(aHi, 19);                                          rHi = srai_epi64(aHi, 63); return;
                    case 84:  rLo = srai_epi64(aHi, 20);                                          rHi = srai_epi64(aHi, 63); return;
                    case 85:  rLo = srai_epi64(aHi, 21);                                          rHi = srai_epi64(aHi, 63); return;
                    case 86:  rLo = srai_epi64(aHi, 22);                                          rHi = srai_epi64(aHi, 63); return;
                    case 87:  rLo = srai_epi64(aHi, 23);                                          rHi = srai_epi64(aHi, 63); return;
                    case 88:  rLo = srai_epi64(aHi, 24);                                          rHi = srai_epi64(aHi, 63); return;
                    case 89:  rLo = srai_epi64(aHi, 25);                                          rHi = srai_epi64(aHi, 63); return;
                    case 90:  rLo = srai_epi64(aHi, 26);                                          rHi = srai_epi64(aHi, 63); return;
                    case 91:  rLo = srai_epi64(aHi, 27);                                          rHi = srai_epi64(aHi, 63); return;
                    case 92:  rLo = srai_epi64(aHi, 28);                                          rHi = srai_epi64(aHi, 63); return;
                    case 93:  rLo = srai_epi64(aHi, 29);                                          rHi = srai_epi64(aHi, 63); return;
                    case 94:  rLo = srai_epi64(aHi, 30);                                          rHi = srai_epi64(aHi, 63); return;
                    case 95:  rLo = srai_epi64(aHi, 31);                                          rHi = srai_epi64(aHi, 63); return;
                    case 96:  rLo = srai_epi64(aHi, 32);                                          rHi = srai_epi64(aHi, 63); return;
                    case 97:  rLo = srai_epi64(aHi, 33);                                          rHi = srai_epi64(aHi, 63); return;
                    case 98:  rLo = srai_epi64(aHi, 34);                                          rHi = srai_epi64(aHi, 63); return;
                    case 99:  rLo = srai_epi64(aHi, 35);                                          rHi = srai_epi64(aHi, 63); return;
                    case 100: rLo = srai_epi64(aHi, 36);                                          rHi = srai_epi64(aHi, 63); return;
                    case 101: rLo = srai_epi64(aHi, 37);                                          rHi = srai_epi64(aHi, 63); return;
                    case 102: rLo = srai_epi64(aHi, 38);                                          rHi = srai_epi64(aHi, 63); return;
                    case 103: rLo = srai_epi64(aHi, 39);                                          rHi = srai_epi64(aHi, 63); return;
                    case 104: rLo = srai_epi64(aHi, 40);                                          rHi = srai_epi64(aHi, 63); return;
                    case 105: rLo = srai_epi64(aHi, 41);                                          rHi = srai_epi64(aHi, 63); return;
                    case 106: rLo = srai_epi64(aHi, 42);                                          rHi = srai_epi64(aHi, 63); return;
                    case 107: rLo = srai_epi64(aHi, 43);                                          rHi = srai_epi64(aHi, 63); return;
                    case 108: rLo = srai_epi64(aHi, 44);                                          rHi = srai_epi64(aHi, 63); return;
                    case 109: rLo = srai_epi64(aHi, 45);                                          rHi = srai_epi64(aHi, 63); return;
                    case 110: rLo = srai_epi64(aHi, 46);                                          rHi = srai_epi64(aHi, 63); return;
                    case 111: rLo = srai_epi64(aHi, 47);                                          rHi = srai_epi64(aHi, 63); return;
                    case 112: rLo = srai_epi64(aHi, 48);                                          rHi = srai_epi64(aHi, 63); return;
                    case 113: rLo = srai_epi64(aHi, 49);                                          rHi = srai_epi64(aHi, 63); return;
                    case 114: rLo = srai_epi64(aHi, 50);                                          rHi = srai_epi64(aHi, 63); return;
                    case 115: rLo = srai_epi64(aHi, 51);                                          rHi = srai_epi64(aHi, 63); return;
                    case 116: rLo = srai_epi64(aHi, 52);                                          rHi = srai_epi64(aHi, 63); return;
                    case 117: rLo = srai_epi64(aHi, 53);                                          rHi = srai_epi64(aHi, 63); return;
                    case 118: rLo = srai_epi64(aHi, 54);                                          rHi = srai_epi64(aHi, 63); return;
                    case 119: rLo = srai_epi64(aHi, 55);                                          rHi = srai_epi64(aHi, 63); return;
                    case 120: rLo = srai_epi64(aHi, 56);                                          rHi = srai_epi64(aHi, 63); return;
                    case 121: rLo = srai_epi64(aHi, 57);                                          rHi = srai_epi64(aHi, 63); return;
                    case 122: rLo = srai_epi64(aHi, 58);                                          rHi = srai_epi64(aHi, 63); return;
                    case 123: rLo = srai_epi64(aHi, 59);                                          rHi = srai_epi64(aHi, 63); return;
                    case 124: rLo = srai_epi64(aHi, 60);                                          rHi = srai_epi64(aHi, 63); return;
                    case 125: rLo = srai_epi64(aHi, 61);                                          rHi = srai_epi64(aHi, 63); return;
                    case 126: rLo = srai_epi64(aHi, 62);                                          rHi = srai_epi64(aHi, 63); return;
                    case 127: rLo = srai_epi64(aHi, 63);                                          rHi = srai_epi64(aHi, 63); return;

                    default:  rLo = aLo;                                                          rHi = aHi;                 return;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_constshl_epu128(v256 aLo, v256 aHi, int n, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 1:   rLo = mm256_slli_epi64(aLo, 1);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 1),  mm256_srli_epi64(aLo, (64 - 1)));  return;
                    case 2:   rLo = mm256_slli_epi64(aLo, 2);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 2),  mm256_srli_epi64(aLo, (64 - 2)));  return;
                    case 3:   rLo = mm256_slli_epi64(aLo, 3);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 3),  mm256_srli_epi64(aLo, (64 - 3)));  return;
                    case 4:   rLo = mm256_slli_epi64(aLo, 4);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 4),  mm256_srli_epi64(aLo, (64 - 4)));  return;
                    case 5:   rLo = mm256_slli_epi64(aLo, 5);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 5),  mm256_srli_epi64(aLo, (64 - 5)));  return;
                    case 6:   rLo = mm256_slli_epi64(aLo, 6);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 6),  mm256_srli_epi64(aLo, (64 - 6)));  return;
                    case 7:   rLo = mm256_slli_epi64(aLo, 7);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 7),  mm256_srli_epi64(aLo, (64 - 7)));  return;
                    case 8:   rLo = mm256_slli_epi64(aLo, 8);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 8),  mm256_srli_epi64(aLo, (64 - 8)));  return;
                    case 9:   rLo = mm256_slli_epi64(aLo, 9);     rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 9),  mm256_srli_epi64(aLo, (64 - 9)));  return;
                    case 10:  rLo = mm256_slli_epi64(aLo, 10);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 10), mm256_srli_epi64(aLo, (64 - 10))); return;
                    case 11:  rLo = mm256_slli_epi64(aLo, 11);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 11), mm256_srli_epi64(aLo, (64 - 11))); return;
                    case 12:  rLo = mm256_slli_epi64(aLo, 12);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 12), mm256_srli_epi64(aLo, (64 - 12))); return;
                    case 13:  rLo = mm256_slli_epi64(aLo, 13);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 13), mm256_srli_epi64(aLo, (64 - 13))); return;
                    case 14:  rLo = mm256_slli_epi64(aLo, 14);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 14), mm256_srli_epi64(aLo, (64 - 14))); return;
                    case 15:  rLo = mm256_slli_epi64(aLo, 15);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 15), mm256_srli_epi64(aLo, (64 - 15))); return;
                    case 16:  rLo = mm256_slli_epi64(aLo, 16);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 16), mm256_srli_epi64(aLo, (64 - 16))); return;
                    case 17:  rLo = mm256_slli_epi64(aLo, 17);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 17), mm256_srli_epi64(aLo, (64 - 17))); return;
                    case 18:  rLo = mm256_slli_epi64(aLo, 18);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 18), mm256_srli_epi64(aLo, (64 - 18))); return;
                    case 19:  rLo = mm256_slli_epi64(aLo, 19);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 19), mm256_srli_epi64(aLo, (64 - 19))); return;
                    case 20:  rLo = mm256_slli_epi64(aLo, 20);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 20), mm256_srli_epi64(aLo, (64 - 20))); return;
                    case 21:  rLo = mm256_slli_epi64(aLo, 21);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 21), mm256_srli_epi64(aLo, (64 - 21))); return;
                    case 22:  rLo = mm256_slli_epi64(aLo, 22);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 22), mm256_srli_epi64(aLo, (64 - 22))); return;
                    case 23:  rLo = mm256_slli_epi64(aLo, 23);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 23), mm256_srli_epi64(aLo, (64 - 23))); return;
                    case 24:  rLo = mm256_slli_epi64(aLo, 24);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 24), mm256_srli_epi64(aLo, (64 - 24))); return;
                    case 25:  rLo = mm256_slli_epi64(aLo, 25);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 25), mm256_srli_epi64(aLo, (64 - 25))); return;
                    case 26:  rLo = mm256_slli_epi64(aLo, 26);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 26), mm256_srli_epi64(aLo, (64 - 26))); return;
                    case 27:  rLo = mm256_slli_epi64(aLo, 27);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 27), mm256_srli_epi64(aLo, (64 - 27))); return;
                    case 28:  rLo = mm256_slli_epi64(aLo, 28);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 28), mm256_srli_epi64(aLo, (64 - 28))); return;
                    case 29:  rLo = mm256_slli_epi64(aLo, 29);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 29), mm256_srli_epi64(aLo, (64 - 29))); return;
                    case 30:  rLo = mm256_slli_epi64(aLo, 30);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 30), mm256_srli_epi64(aLo, (64 - 30))); return;
                    case 31:  rLo = mm256_slli_epi64(aLo, 31);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 31), mm256_srli_epi64(aLo, (64 - 31))); return;
                    case 32:  rLo = mm256_slli_epi64(aLo, 32);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 32), mm256_srli_epi64(aLo, (64 - 32))); return;
                    case 33:  rLo = mm256_slli_epi64(aLo, 33);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 33), mm256_srli_epi64(aLo, (64 - 33))); return;
                    case 34:  rLo = mm256_slli_epi64(aLo, 34);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 34), mm256_srli_epi64(aLo, (64 - 34))); return;
                    case 35:  rLo = mm256_slli_epi64(aLo, 35);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 35), mm256_srli_epi64(aLo, (64 - 35))); return;
                    case 36:  rLo = mm256_slli_epi64(aLo, 36);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 36), mm256_srli_epi64(aLo, (64 - 36))); return;
                    case 37:  rLo = mm256_slli_epi64(aLo, 37);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 37), mm256_srli_epi64(aLo, (64 - 37))); return;
                    case 38:  rLo = mm256_slli_epi64(aLo, 38);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 38), mm256_srli_epi64(aLo, (64 - 38))); return;
                    case 39:  rLo = mm256_slli_epi64(aLo, 39);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 39), mm256_srli_epi64(aLo, (64 - 39))); return;
                    case 40:  rLo = mm256_slli_epi64(aLo, 40);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 40), mm256_srli_epi64(aLo, (64 - 40))); return;
                    case 41:  rLo = mm256_slli_epi64(aLo, 41);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 41), mm256_srli_epi64(aLo, (64 - 41))); return;
                    case 42:  rLo = mm256_slli_epi64(aLo, 42);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 42), mm256_srli_epi64(aLo, (64 - 42))); return;
                    case 43:  rLo = mm256_slli_epi64(aLo, 43);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 43), mm256_srli_epi64(aLo, (64 - 43))); return;
                    case 44:  rLo = mm256_slli_epi64(aLo, 44);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 44), mm256_srli_epi64(aLo, (64 - 44))); return;
                    case 45:  rLo = mm256_slli_epi64(aLo, 45);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 45), mm256_srli_epi64(aLo, (64 - 45))); return;
                    case 46:  rLo = mm256_slli_epi64(aLo, 46);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 46), mm256_srli_epi64(aLo, (64 - 46))); return;
                    case 47:  rLo = mm256_slli_epi64(aLo, 47);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 47), mm256_srli_epi64(aLo, (64 - 47))); return;
                    case 48:  rLo = mm256_slli_epi64(aLo, 48);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 48), mm256_srli_epi64(aLo, (64 - 48))); return;
                    case 49:  rLo = mm256_slli_epi64(aLo, 49);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 49), mm256_srli_epi64(aLo, (64 - 49))); return;
                    case 50:  rLo = mm256_slli_epi64(aLo, 50);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 50), mm256_srli_epi64(aLo, (64 - 50))); return;
                    case 51:  rLo = mm256_slli_epi64(aLo, 51);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 51), mm256_srli_epi64(aLo, (64 - 51))); return;
                    case 52:  rLo = mm256_slli_epi64(aLo, 52);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 52), mm256_srli_epi64(aLo, (64 - 52))); return;
                    case 53:  rLo = mm256_slli_epi64(aLo, 53);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 53), mm256_srli_epi64(aLo, (64 - 53))); return;
                    case 54:  rLo = mm256_slli_epi64(aLo, 54);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 54), mm256_srli_epi64(aLo, (64 - 54))); return;
                    case 55:  rLo = mm256_slli_epi64(aLo, 55);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 55), mm256_srli_epi64(aLo, (64 - 55))); return;
                    case 56:  rLo = mm256_slli_epi64(aLo, 56);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 56), mm256_srli_epi64(aLo, (64 - 56))); return;
                    case 57:  rLo = mm256_slli_epi64(aLo, 57);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 57), mm256_srli_epi64(aLo, (64 - 57))); return;
                    case 58:  rLo = mm256_slli_epi64(aLo, 58);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 58), mm256_srli_epi64(aLo, (64 - 58))); return;
                    case 59:  rLo = mm256_slli_epi64(aLo, 59);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 59), mm256_srli_epi64(aLo, (64 - 59))); return;
                    case 60:  rLo = mm256_slli_epi64(aLo, 60);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 60), mm256_srli_epi64(aLo, (64 - 60))); return;
                    case 61:  rLo = mm256_slli_epi64(aLo, 61);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 61), mm256_srli_epi64(aLo, (64 - 61))); return;
                    case 62:  rLo = mm256_slli_epi64(aLo, 62);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 62), mm256_srli_epi64(aLo, (64 - 62))); return;
                    case 63:  rLo = mm256_slli_epi64(aLo, 63);    rHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, 63), mm256_srli_epi64(aLo, (64 - 63))); return;
                    case 64:  rLo = Avx.mm256_setzero_si256();        rHi = aLo;                                                       return;
                    case 65:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 1);                                        return;
                    case 66:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 2);                                        return;
                    case 67:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 3);                                        return;
                    case 68:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 4);                                        return;
                    case 69:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 5);                                        return;
                    case 70:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 6);                                        return;
                    case 71:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 7);                                        return;
                    case 72:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 8);                                        return;
                    case 73:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 9);                                        return;
                    case 74:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 10);                                       return;
                    case 75:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 11);                                       return;
                    case 76:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 12);                                       return;
                    case 77:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 13);                                       return;
                    case 78:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 14);                                       return;
                    case 79:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 15);                                       return;
                    case 80:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 16);                                       return;
                    case 81:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 17);                                       return;
                    case 82:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 18);                                       return;
                    case 83:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 19);                                       return;
                    case 84:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 20);                                       return;
                    case 85:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 21);                                       return;
                    case 86:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 22);                                       return;
                    case 87:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 23);                                       return;
                    case 88:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 24);                                       return;
                    case 89:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 25);                                       return;
                    case 90:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 26);                                       return;
                    case 91:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 27);                                       return;
                    case 92:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 28);                                       return;
                    case 93:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 29);                                       return;
                    case 94:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 30);                                       return;
                    case 95:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 31);                                       return;
                    case 96:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 32);                                       return;
                    case 97:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 33);                                       return;
                    case 98:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 34);                                       return;
                    case 99:  rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 35);                                       return;
                    case 100: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 36);                                       return;
                    case 101: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 37);                                       return;
                    case 102: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 38);                                       return;
                    case 103: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 39);                                       return;
                    case 104: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 40);                                       return;
                    case 105: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 41);                                       return;
                    case 106: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 42);                                       return;
                    case 107: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 43);                                       return;
                    case 108: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 44);                                       return;
                    case 109: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 45);                                       return;
                    case 110: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 46);                                       return;
                    case 111: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 47);                                       return;
                    case 112: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 48);                                       return;
                    case 113: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 49);                                       return;
                    case 114: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 50);                                       return;
                    case 115: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 51);                                       return;
                    case 116: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 52);                                       return;
                    case 117: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 53);                                       return;
                    case 118: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 54);                                       return;
                    case 119: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 55);                                       return;
                    case 120: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 56);                                       return;
                    case 121: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 57);                                       return;
                    case 122: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 58);                                       return;
                    case 123: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 59);                                       return;
                    case 124: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 60);                                       return;
                    case 125: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 61);                                       return;
                    case 126: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 62);                                       return;
                    case 127: rLo = Avx.mm256_setzero_si256();        rHi = mm256_slli_epi64(aLo, 63);                                       return;

                    default:  rLo = aLo;                    rHi = aHi;                                                       return;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_constshr_epu128(v256 aLo, v256 aHi, int n, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 1:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 1),  mm256_slli_epi64(aHi, (64 - 1)));     rHi = mm256_srli_epi64(aHi, 1);  return;
                    case 2:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 2),  mm256_slli_epi64(aHi, (64 - 2)));     rHi = mm256_srli_epi64(aHi, 2);  return;
                    case 3:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 3),  mm256_slli_epi64(aHi, (64 - 3)));     rHi = mm256_srli_epi64(aHi, 3);  return;
                    case 4:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 4),  mm256_slli_epi64(aHi, (64 - 4)));     rHi = mm256_srli_epi64(aHi, 4);  return;
                    case 5:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 5),  mm256_slli_epi64(aHi, (64 - 5)));     rHi = mm256_srli_epi64(aHi, 5);  return;
                    case 6:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 6),  mm256_slli_epi64(aHi, (64 - 6)));     rHi = mm256_srli_epi64(aHi, 6);  return;
                    case 7:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 7),  mm256_slli_epi64(aHi, (64 - 7)));     rHi = mm256_srli_epi64(aHi, 7);  return;
                    case 8:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 8),  mm256_slli_epi64(aHi, (64 - 8)));     rHi = mm256_srli_epi64(aHi, 8);  return;
                    case 9:    rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 9),  mm256_slli_epi64(aHi, (64 - 9)));     rHi = mm256_srli_epi64(aHi, 9);  return;
                    case 10:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 10), mm256_slli_epi64(aHi, (64 - 10)));    rHi = mm256_srli_epi64(aHi, 10); return;
                    case 11:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 11), mm256_slli_epi64(aHi, (64 - 11)));    rHi = mm256_srli_epi64(aHi, 11); return;
                    case 12:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 12), mm256_slli_epi64(aHi, (64 - 12)));    rHi = mm256_srli_epi64(aHi, 12); return;
                    case 13:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 13), mm256_slli_epi64(aHi, (64 - 13)));    rHi = mm256_srli_epi64(aHi, 13); return;
                    case 14:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 14), mm256_slli_epi64(aHi, (64 - 14)));    rHi = mm256_srli_epi64(aHi, 14); return;
                    case 15:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 15), mm256_slli_epi64(aHi, (64 - 15)));    rHi = mm256_srli_epi64(aHi, 15); return;
                    case 16:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 16), mm256_slli_epi64(aHi, (64 - 16)));    rHi = mm256_srli_epi64(aHi, 16); return;
                    case 17:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 17), mm256_slli_epi64(aHi, (64 - 17)));    rHi = mm256_srli_epi64(aHi, 17); return;
                    case 18:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 18), mm256_slli_epi64(aHi, (64 - 18)));    rHi = mm256_srli_epi64(aHi, 18); return;
                    case 19:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 19), mm256_slli_epi64(aHi, (64 - 19)));    rHi = mm256_srli_epi64(aHi, 19); return;
                    case 20:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 20), mm256_slli_epi64(aHi, (64 - 20)));    rHi = mm256_srli_epi64(aHi, 20); return;
                    case 21:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 21), mm256_slli_epi64(aHi, (64 - 21)));    rHi = mm256_srli_epi64(aHi, 21); return;
                    case 22:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 22), mm256_slli_epi64(aHi, (64 - 22)));    rHi = mm256_srli_epi64(aHi, 22); return;
                    case 23:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 23), mm256_slli_epi64(aHi, (64 - 23)));    rHi = mm256_srli_epi64(aHi, 23); return;
                    case 24:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 24), mm256_slli_epi64(aHi, (64 - 24)));    rHi = mm256_srli_epi64(aHi, 24); return;
                    case 25:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 25), mm256_slli_epi64(aHi, (64 - 25)));    rHi = mm256_srli_epi64(aHi, 25); return;
                    case 26:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 26), mm256_slli_epi64(aHi, (64 - 26)));    rHi = mm256_srli_epi64(aHi, 26); return;
                    case 27:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 27), mm256_slli_epi64(aHi, (64 - 27)));    rHi = mm256_srli_epi64(aHi, 27); return;
                    case 28:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 28), mm256_slli_epi64(aHi, (64 - 28)));    rHi = mm256_srli_epi64(aHi, 28); return;
                    case 29:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 29), mm256_slli_epi64(aHi, (64 - 29)));    rHi = mm256_srli_epi64(aHi, 29); return;
                    case 30:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 30), mm256_slli_epi64(aHi, (64 - 30)));    rHi = mm256_srli_epi64(aHi, 30); return;
                    case 31:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 31), mm256_slli_epi64(aHi, (64 - 31)));    rHi = mm256_srli_epi64(aHi, 31); return;
                    case 32:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 32), mm256_slli_epi64(aHi, (64 - 32)));    rHi = mm256_srli_epi64(aHi, 32); return;
                    case 33:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 33), mm256_slli_epi64(aHi, (64 - 33)));    rHi = mm256_srli_epi64(aHi, 33); return;
                    case 34:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 34), mm256_slli_epi64(aHi, (64 - 34)));    rHi = mm256_srli_epi64(aHi, 34); return;
                    case 35:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 35), mm256_slli_epi64(aHi, (64 - 35)));    rHi = mm256_srli_epi64(aHi, 35); return;
                    case 36:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 36), mm256_slli_epi64(aHi, (64 - 36)));    rHi = mm256_srli_epi64(aHi, 36); return;
                    case 37:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 37), mm256_slli_epi64(aHi, (64 - 37)));    rHi = mm256_srli_epi64(aHi, 37); return;
                    case 38:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 38), mm256_slli_epi64(aHi, (64 - 38)));    rHi = mm256_srli_epi64(aHi, 38); return;
                    case 39:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 39), mm256_slli_epi64(aHi, (64 - 39)));    rHi = mm256_srli_epi64(aHi, 39); return;
                    case 40:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 40), mm256_slli_epi64(aHi, (64 - 40)));    rHi = mm256_srli_epi64(aHi, 40); return;
                    case 41:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 41), mm256_slli_epi64(aHi, (64 - 41)));    rHi = mm256_srli_epi64(aHi, 41); return;
                    case 42:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 42), mm256_slli_epi64(aHi, (64 - 42)));    rHi = mm256_srli_epi64(aHi, 42); return;
                    case 43:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 43), mm256_slli_epi64(aHi, (64 - 43)));    rHi = mm256_srli_epi64(aHi, 43); return;
                    case 44:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 44), mm256_slli_epi64(aHi, (64 - 44)));    rHi = mm256_srli_epi64(aHi, 44); return;
                    case 45:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 45), mm256_slli_epi64(aHi, (64 - 45)));    rHi = mm256_srli_epi64(aHi, 45); return;
                    case 46:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 46), mm256_slli_epi64(aHi, (64 - 46)));    rHi = mm256_srli_epi64(aHi, 46); return;
                    case 47:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 47), mm256_slli_epi64(aHi, (64 - 47)));    rHi = mm256_srli_epi64(aHi, 47); return;
                    case 48:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 48), mm256_slli_epi64(aHi, (64 - 48)));    rHi = mm256_srli_epi64(aHi, 48); return;
                    case 49:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 49), mm256_slli_epi64(aHi, (64 - 49)));    rHi = mm256_srli_epi64(aHi, 49); return;
                    case 50:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 50), mm256_slli_epi64(aHi, (64 - 50)));    rHi = mm256_srli_epi64(aHi, 50); return;
                    case 51:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 51), mm256_slli_epi64(aHi, (64 - 51)));    rHi = mm256_srli_epi64(aHi, 51); return;
                    case 52:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 52), mm256_slli_epi64(aHi, (64 - 52)));    rHi = mm256_srli_epi64(aHi, 52); return;
                    case 53:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 53), mm256_slli_epi64(aHi, (64 - 53)));    rHi = mm256_srli_epi64(aHi, 53); return;
                    case 54:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 54), mm256_slli_epi64(aHi, (64 - 54)));    rHi = mm256_srli_epi64(aHi, 54); return;
                    case 55:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 55), mm256_slli_epi64(aHi, (64 - 55)));    rHi = mm256_srli_epi64(aHi, 55); return;
                    case 56:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 56), mm256_slli_epi64(aHi, (64 - 56)));    rHi = mm256_srli_epi64(aHi, 56); return;
                    case 57:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 57), mm256_slli_epi64(aHi, (64 - 57)));    rHi = mm256_srli_epi64(aHi, 57); return;
                    case 58:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 58), mm256_slli_epi64(aHi, (64 - 58)));    rHi = mm256_srli_epi64(aHi, 58); return;
                    case 59:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 59), mm256_slli_epi64(aHi, (64 - 59)));    rHi = mm256_srli_epi64(aHi, 59); return;
                    case 60:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 60), mm256_slli_epi64(aHi, (64 - 60)));    rHi = mm256_srli_epi64(aHi, 60); return;
                    case 61:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 61), mm256_slli_epi64(aHi, (64 - 61)));    rHi = mm256_srli_epi64(aHi, 61); return;
                    case 62:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 62), mm256_slli_epi64(aHi, (64 - 62)));    rHi = mm256_srli_epi64(aHi, 62); return;
                    case 63:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 63), mm256_slli_epi64(aHi, (64 - 63)));    rHi = mm256_srli_epi64(aHi, 63); return;
                    case 64:   rLo = aHi;                                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 65:   rLo = mm256_srli_epi64(aHi, 1);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 66:   rLo = mm256_srli_epi64(aHi, 2);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 67:   rLo = mm256_srli_epi64(aHi, 3);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 68:   rLo = mm256_srli_epi64(aHi, 4);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 69:   rLo = mm256_srli_epi64(aHi, 5);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 70:   rLo = mm256_srli_epi64(aHi, 6);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 71:   rLo = mm256_srli_epi64(aHi, 7);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 72:   rLo = mm256_srli_epi64(aHi, 8);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 73:   rLo = mm256_srli_epi64(aHi, 9);                                           rHi = Avx.mm256_setzero_si256();     return;
                    case 74:   rLo = mm256_srli_epi64(aHi, 10);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 75:   rLo = mm256_srli_epi64(aHi, 11);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 76:   rLo = mm256_srli_epi64(aHi, 12);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 77:   rLo = mm256_srli_epi64(aHi, 13);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 78:   rLo = mm256_srli_epi64(aHi, 14);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 79:   rLo = mm256_srli_epi64(aHi, 15);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 80:   rLo = mm256_srli_epi64(aHi, 16);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 81:   rLo = mm256_srli_epi64(aHi, 17);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 82:   rLo = mm256_srli_epi64(aHi, 18);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 83:   rLo = mm256_srli_epi64(aHi, 19);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 84:   rLo = mm256_srli_epi64(aHi, 20);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 85:   rLo = mm256_srli_epi64(aHi, 21);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 86:   rLo = mm256_srli_epi64(aHi, 22);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 87:   rLo = mm256_srli_epi64(aHi, 23);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 88:   rLo = mm256_srli_epi64(aHi, 24);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 89:   rLo = mm256_srli_epi64(aHi, 25);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 90:   rLo = mm256_srli_epi64(aHi, 26);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 91:   rLo = mm256_srli_epi64(aHi, 27);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 92:   rLo = mm256_srli_epi64(aHi, 28);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 93:   rLo = mm256_srli_epi64(aHi, 29);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 94:   rLo = mm256_srli_epi64(aHi, 30);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 95:   rLo = mm256_srli_epi64(aHi, 31);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 96:   rLo = mm256_srli_epi64(aHi, 32);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 97:   rLo = mm256_srli_epi64(aHi, 33);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 98:   rLo = mm256_srli_epi64(aHi, 34);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 99:   rLo = mm256_srli_epi64(aHi, 35);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 100:  rLo = mm256_srli_epi64(aHi, 36);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 101:  rLo = mm256_srli_epi64(aHi, 37);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 102:  rLo = mm256_srli_epi64(aHi, 38);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 103:  rLo = mm256_srli_epi64(aHi, 39);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 104:  rLo = mm256_srli_epi64(aHi, 40);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 105:  rLo = mm256_srli_epi64(aHi, 41);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 106:  rLo = mm256_srli_epi64(aHi, 42);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 107:  rLo = mm256_srli_epi64(aHi, 43);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 108:  rLo = mm256_srli_epi64(aHi, 44);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 109:  rLo = mm256_srli_epi64(aHi, 45);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 110:  rLo = mm256_srli_epi64(aHi, 46);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 111:  rLo = mm256_srli_epi64(aHi, 47);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 112:  rLo = mm256_srli_epi64(aHi, 48);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 113:  rLo = mm256_srli_epi64(aHi, 49);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 114:  rLo = mm256_srli_epi64(aHi, 50);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 115:  rLo = mm256_srli_epi64(aHi, 51);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 116:  rLo = mm256_srli_epi64(aHi, 52);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 117:  rLo = mm256_srli_epi64(aHi, 53);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 118:  rLo = mm256_srli_epi64(aHi, 54);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 119:  rLo = mm256_srli_epi64(aHi, 55);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 120:  rLo = mm256_srli_epi64(aHi, 56);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 121:  rLo = mm256_srli_epi64(aHi, 57);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 122:  rLo = mm256_srli_epi64(aHi, 58);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 123:  rLo = mm256_srli_epi64(aHi, 59);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 124:  rLo = mm256_srli_epi64(aHi, 60);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 125:  rLo = mm256_srli_epi64(aHi, 61);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 126:  rLo = mm256_srli_epi64(aHi, 62);                                          rHi = Avx.mm256_setzero_si256();     return;
                    case 127:  rLo = mm256_srli_epi64(aHi, 63);                                          rHi = Avx.mm256_setzero_si256();     return;

                    default:  rLo = aLo;                                                           rHi = aHi;                 return;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void mm256_constsar_epu128(v256 aLo, v256 aHi, int n, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 1:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 1) , mm256_slli_epi64(aHi, (64 - 1)));     rHi = mm256_srai_epi64(aHi, 1);  return;
                    case 2:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 2) , mm256_slli_epi64(aHi, (64 - 2)));     rHi = mm256_srai_epi64(aHi, 2);  return;
                    case 3:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 3) , mm256_slli_epi64(aHi, (64 - 3)));     rHi = mm256_srai_epi64(aHi, 3);  return;
                    case 4:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 4) , mm256_slli_epi64(aHi, (64 - 4)));     rHi = mm256_srai_epi64(aHi, 4);  return;
                    case 5:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 5) , mm256_slli_epi64(aHi, (64 - 5)));     rHi = mm256_srai_epi64(aHi, 5);  return;
                    case 6:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 6) , mm256_slli_epi64(aHi, (64 - 6)));     rHi = mm256_srai_epi64(aHi, 6);  return;
                    case 7:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 7) , mm256_slli_epi64(aHi, (64 - 7)));     rHi = mm256_srai_epi64(aHi, 7);  return;
                    case 8:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 8) , mm256_slli_epi64(aHi, (64 - 8)));     rHi = mm256_srai_epi64(aHi, 8);  return;
                    case 9:   rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 9) , mm256_slli_epi64(aHi, (64 - 9)));     rHi = mm256_srai_epi64(aHi, 9);  return;
                    case 10:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 10), mm256_slli_epi64(aHi, (64 - 10)));    rHi = mm256_srai_epi64(aHi, 10); return;
                    case 11:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 11), mm256_slli_epi64(aHi, (64 - 11)));    rHi = mm256_srai_epi64(aHi, 11); return;
                    case 12:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 12), mm256_slli_epi64(aHi, (64 - 12)));    rHi = mm256_srai_epi64(aHi, 12); return;
                    case 13:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 13), mm256_slli_epi64(aHi, (64 - 13)));    rHi = mm256_srai_epi64(aHi, 13); return;
                    case 14:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 14), mm256_slli_epi64(aHi, (64 - 14)));    rHi = mm256_srai_epi64(aHi, 14); return;
                    case 15:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 15), mm256_slli_epi64(aHi, (64 - 15)));    rHi = mm256_srai_epi64(aHi, 15); return;
                    case 16:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 16), mm256_slli_epi64(aHi, (64 - 16)));    rHi = mm256_srai_epi64(aHi, 16); return;
                    case 17:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 17), mm256_slli_epi64(aHi, (64 - 17)));    rHi = mm256_srai_epi64(aHi, 17); return;
                    case 18:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 18), mm256_slli_epi64(aHi, (64 - 18)));    rHi = mm256_srai_epi64(aHi, 18); return;
                    case 19:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 19), mm256_slli_epi64(aHi, (64 - 19)));    rHi = mm256_srai_epi64(aHi, 19); return;
                    case 20:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 20), mm256_slli_epi64(aHi, (64 - 20)));    rHi = mm256_srai_epi64(aHi, 20); return;
                    case 21:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 21), mm256_slli_epi64(aHi, (64 - 21)));    rHi = mm256_srai_epi64(aHi, 21); return;
                    case 22:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 22), mm256_slli_epi64(aHi, (64 - 22)));    rHi = mm256_srai_epi64(aHi, 22); return;
                    case 23:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 23), mm256_slli_epi64(aHi, (64 - 23)));    rHi = mm256_srai_epi64(aHi, 23); return;
                    case 24:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 24), mm256_slli_epi64(aHi, (64 - 24)));    rHi = mm256_srai_epi64(aHi, 24); return;
                    case 25:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 25), mm256_slli_epi64(aHi, (64 - 25)));    rHi = mm256_srai_epi64(aHi, 25); return;
                    case 26:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 26), mm256_slli_epi64(aHi, (64 - 26)));    rHi = mm256_srai_epi64(aHi, 26); return;
                    case 27:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 27), mm256_slli_epi64(aHi, (64 - 27)));    rHi = mm256_srai_epi64(aHi, 27); return;
                    case 28:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 28), mm256_slli_epi64(aHi, (64 - 28)));    rHi = mm256_srai_epi64(aHi, 28); return;
                    case 29:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 29), mm256_slli_epi64(aHi, (64 - 29)));    rHi = mm256_srai_epi64(aHi, 29); return;
                    case 30:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 30), mm256_slli_epi64(aHi, (64 - 30)));    rHi = mm256_srai_epi64(aHi, 30); return;
                    case 31:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 31), mm256_slli_epi64(aHi, (64 - 31)));    rHi = mm256_srai_epi64(aHi, 31); return;
                    case 32:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 32), mm256_slli_epi64(aHi, (64 - 32)));    rHi = mm256_srai_epi64(aHi, 32); return;
                    case 33:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 33), mm256_slli_epi64(aHi, (64 - 33)));    rHi = mm256_srai_epi64(aHi, 33); return;
                    case 34:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 34), mm256_slli_epi64(aHi, (64 - 34)));    rHi = mm256_srai_epi64(aHi, 34); return;
                    case 35:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 35), mm256_slli_epi64(aHi, (64 - 35)));    rHi = mm256_srai_epi64(aHi, 35); return;
                    case 36:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 36), mm256_slli_epi64(aHi, (64 - 36)));    rHi = mm256_srai_epi64(aHi, 36); return;
                    case 37:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 37), mm256_slli_epi64(aHi, (64 - 37)));    rHi = mm256_srai_epi64(aHi, 37); return;
                    case 38:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 38), mm256_slli_epi64(aHi, (64 - 38)));    rHi = mm256_srai_epi64(aHi, 38); return;
                    case 39:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 39), mm256_slli_epi64(aHi, (64 - 39)));    rHi = mm256_srai_epi64(aHi, 39); return;
                    case 40:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 40), mm256_slli_epi64(aHi, (64 - 40)));    rHi = mm256_srai_epi64(aHi, 40); return;
                    case 41:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 41), mm256_slli_epi64(aHi, (64 - 41)));    rHi = mm256_srai_epi64(aHi, 41); return;
                    case 42:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 42), mm256_slli_epi64(aHi, (64 - 42)));    rHi = mm256_srai_epi64(aHi, 42); return;
                    case 43:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 43), mm256_slli_epi64(aHi, (64 - 43)));    rHi = mm256_srai_epi64(aHi, 43); return;
                    case 44:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 44), mm256_slli_epi64(aHi, (64 - 44)));    rHi = mm256_srai_epi64(aHi, 44); return;
                    case 45:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 45), mm256_slli_epi64(aHi, (64 - 45)));    rHi = mm256_srai_epi64(aHi, 45); return;
                    case 46:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 46), mm256_slli_epi64(aHi, (64 - 46)));    rHi = mm256_srai_epi64(aHi, 46); return;
                    case 47:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 47), mm256_slli_epi64(aHi, (64 - 47)));    rHi = mm256_srai_epi64(aHi, 47); return;
                    case 48:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 48), mm256_slli_epi64(aHi, (64 - 48)));    rHi = mm256_srai_epi64(aHi, 48); return;
                    case 49:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 49), mm256_slli_epi64(aHi, (64 - 49)));    rHi = mm256_srai_epi64(aHi, 49); return;
                    case 50:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 50), mm256_slli_epi64(aHi, (64 - 50)));    rHi = mm256_srai_epi64(aHi, 50); return;
                    case 51:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 51), mm256_slli_epi64(aHi, (64 - 51)));    rHi = mm256_srai_epi64(aHi, 51); return;
                    case 52:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 52), mm256_slli_epi64(aHi, (64 - 52)));    rHi = mm256_srai_epi64(aHi, 52); return;
                    case 53:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 53), mm256_slli_epi64(aHi, (64 - 53)));    rHi = mm256_srai_epi64(aHi, 53); return;
                    case 54:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 54), mm256_slli_epi64(aHi, (64 - 54)));    rHi = mm256_srai_epi64(aHi, 54); return;
                    case 55:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 55), mm256_slli_epi64(aHi, (64 - 55)));    rHi = mm256_srai_epi64(aHi, 55); return;
                    case 56:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 56), mm256_slli_epi64(aHi, (64 - 56)));    rHi = mm256_srai_epi64(aHi, 56); return;
                    case 57:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 57), mm256_slli_epi64(aHi, (64 - 57)));    rHi = mm256_srai_epi64(aHi, 57); return;
                    case 58:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 58), mm256_slli_epi64(aHi, (64 - 58)));    rHi = mm256_srai_epi64(aHi, 58); return;
                    case 59:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 59), mm256_slli_epi64(aHi, (64 - 59)));    rHi = mm256_srai_epi64(aHi, 59); return;
                    case 60:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 60), mm256_slli_epi64(aHi, (64 - 60)));    rHi = mm256_srai_epi64(aHi, 60); return;
                    case 61:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 61), mm256_slli_epi64(aHi, (64 - 61)));    rHi = mm256_srai_epi64(aHi, 61); return;
                    case 62:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 62), mm256_slli_epi64(aHi, (64 - 62)));    rHi = mm256_srai_epi64(aHi, 62); return;
                    case 63:  rLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, 63), mm256_slli_epi64(aHi, (64 - 63)));    rHi = mm256_srai_epi64(aHi, 63); return;
                    case 64:  rLo = aHi;                                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 65:  rLo = mm256_srai_epi64(aHi, 1);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 66:  rLo = mm256_srai_epi64(aHi, 2);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 67:  rLo = mm256_srai_epi64(aHi, 3);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 68:  rLo = mm256_srai_epi64(aHi, 4);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 69:  rLo = mm256_srai_epi64(aHi, 5);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 70:  rLo = mm256_srai_epi64(aHi, 6);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 71:  rLo = mm256_srai_epi64(aHi, 7);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 72:  rLo = mm256_srai_epi64(aHi, 8);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 73:  rLo = mm256_srai_epi64(aHi, 9);                                           rHi = mm256_srai_epi64(aHi, 63); return;
                    case 74:  rLo = mm256_srai_epi64(aHi, 10);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 75:  rLo = mm256_srai_epi64(aHi, 11);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 76:  rLo = mm256_srai_epi64(aHi, 12);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 77:  rLo = mm256_srai_epi64(aHi, 13);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 78:  rLo = mm256_srai_epi64(aHi, 14);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 79:  rLo = mm256_srai_epi64(aHi, 15);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 80:  rLo = mm256_srai_epi64(aHi, 16);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 81:  rLo = mm256_srai_epi64(aHi, 17);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 82:  rLo = mm256_srai_epi64(aHi, 18);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 83:  rLo = mm256_srai_epi64(aHi, 19);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 84:  rLo = mm256_srai_epi64(aHi, 20);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 85:  rLo = mm256_srai_epi64(aHi, 21);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 86:  rLo = mm256_srai_epi64(aHi, 22);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 87:  rLo = mm256_srai_epi64(aHi, 23);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 88:  rLo = mm256_srai_epi64(aHi, 24);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 89:  rLo = mm256_srai_epi64(aHi, 25);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 90:  rLo = mm256_srai_epi64(aHi, 26);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 91:  rLo = mm256_srai_epi64(aHi, 27);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 92:  rLo = mm256_srai_epi64(aHi, 28);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 93:  rLo = mm256_srai_epi64(aHi, 29);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 94:  rLo = mm256_srai_epi64(aHi, 30);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 95:  rLo = mm256_srai_epi64(aHi, 31);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 96:  rLo = mm256_srai_epi64(aHi, 32);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 97:  rLo = mm256_srai_epi64(aHi, 33);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 98:  rLo = mm256_srai_epi64(aHi, 34);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 99:  rLo = mm256_srai_epi64(aHi, 35);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 100: rLo = mm256_srai_epi64(aHi, 36);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 101: rLo = mm256_srai_epi64(aHi, 37);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 102: rLo = mm256_srai_epi64(aHi, 38);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 103: rLo = mm256_srai_epi64(aHi, 39);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 104: rLo = mm256_srai_epi64(aHi, 40);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 105: rLo = mm256_srai_epi64(aHi, 41);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 106: rLo = mm256_srai_epi64(aHi, 42);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 107: rLo = mm256_srai_epi64(aHi, 43);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 108: rLo = mm256_srai_epi64(aHi, 44);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 109: rLo = mm256_srai_epi64(aHi, 45);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 110: rLo = mm256_srai_epi64(aHi, 46);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 111: rLo = mm256_srai_epi64(aHi, 47);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 112: rLo = mm256_srai_epi64(aHi, 48);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 113: rLo = mm256_srai_epi64(aHi, 49);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 114: rLo = mm256_srai_epi64(aHi, 50);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 115: rLo = mm256_srai_epi64(aHi, 51);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 116: rLo = mm256_srai_epi64(aHi, 52);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 117: rLo = mm256_srai_epi64(aHi, 53);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 118: rLo = mm256_srai_epi64(aHi, 54);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 119: rLo = mm256_srai_epi64(aHi, 55);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 120: rLo = mm256_srai_epi64(aHi, 56);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 121: rLo = mm256_srai_epi64(aHi, 57);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 122: rLo = mm256_srai_epi64(aHi, 58);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 123: rLo = mm256_srai_epi64(aHi, 59);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 124: rLo = mm256_srai_epi64(aHi, 60);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 125: rLo = mm256_srai_epi64(aHi, 61);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 126: rLo = mm256_srai_epi64(aHi, 62);                                          rHi = mm256_srai_epi64(aHi, 63); return;
                    case 127: rLo = mm256_srai_epi64(aHi, 63);                                          rHi = mm256_srai_epi64(aHi, 63); return;

                    default:  rLo = aLo;                                                          rHi = aHi;                 return;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void slli_epi128(v128 aLo, v128 aHi, int n, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI64(aLo, 0))
                {
                    rLo = setzero_si128();
                    rHi = and_si128(slli_epi64(aHi, n, inRange: constexpr.IS_TRUE(n != 64)), set1_epi64x(-maxmath.tolong(n < 64)));

                    return;
                }
                if (constexpr.IS_CONST(n))
                {
                    constshl_epu128(aLo, aHi, n, out rLo, out rHi);

                    return;
                }

                v128 isZero = set1_epi64x(-maxmath.tolong(n == 0));
                v128 isSmall = set1_epi64x(-maxmath.tolong(n < 64));

                v128 smallLo = slli_epi64(aLo, n, inRange: SHIFT128_IN_RANGE);
                v128 smallHi = or_si128(slli_epi64(aHi, n, inRange: SHIFT128_IN_RANGE), srli_epi64(aLo, 64 - n, inRange: SHIFT128_IN_RANGE));

                v128 largeHi = slli_epi64(aLo, n - 64);

                rLo = and_si128(blendv_si128(smallLo, aLo, isZero), isSmall);
                rHi = blendv_si128(largeHi, blendv_si128(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_slli_epi128(v256 aLo, v256 aHi, int n, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(aLo, 0, elements))
                {
                    rLo = Avx.mm256_setzero_si256();
                    rHi = Avx2.mm256_and_si256(mm256_slli_epi64(aHi, n), mm256_set1_epi64x(-maxmath.tolong(n < 64)));

                    return;
                }
                if (constexpr.IS_CONST(n))
                {
                    mm256_constshl_epu128(aLo, aHi, n, out rLo, out rHi);

                    return;
                }

                v256 isZero = mm256_set1_epi64x(-maxmath.tolong(n == 0));
                v256 isSmall = mm256_set1_epi64x(-maxmath.tolong(n < 64));

                v256 smallLo = mm256_slli_epi64(aLo, n);
                v256 smallHi = Avx2.mm256_or_si256(mm256_slli_epi64(aHi, n), mm256_srli_epi64(aLo, 64 - n));

                v256 largeHi = mm256_slli_epi64(aLo, n - 64);

                rLo = Avx2.mm256_and_si256(mm256_blendv_si256(smallLo, aLo, isZero), isSmall);
                rHi = mm256_blendv_si256(largeHi, mm256_blendv_si256(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sllv_epi128(v128 aLo, v128 aHi, v128 n64, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI64(aLo, 0))
                {
                    rLo = setzero_si128();
                    rHi = and_si128(sllv_epi64(aHi, n64, inRange: constexpr.ALL_NEQ_EPI64(n64, 64)), cmpgt_epi64(set1_epi64x(64), n64));

                    return;
                }

                v128 isZero = cmpeq_epi64(setzero_si128(), n64);
                v128 isSmall = cmpgt_epi64(set1_epi64x(64), n64);

                v128 smallLo = sllv_epi64(aLo, n64, inRange: SHIFT128_IN_RANGE);
                v128 smallHi = or_si128(sllv_epi64(aHi, n64, inRange: SHIFT128_IN_RANGE), srlv_epi64(aLo, sub_epi64(set1_epi64x(64), n64), inRange: SHIFT128_IN_RANGE));

                v128 largeHi = sllv_epi64(aLo, sub_epi64(n64, set1_epi64x(64)));

                rLo = and_si128(blendv_si128(smallLo, aLo, isZero), isSmall);
                rHi = blendv_si128(largeHi, blendv_si128(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_sllv_epi128(v256 aLo, v256 aHi, v256 n64, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(aLo, 0, elements))
                {
                    rLo = Avx.mm256_setzero_si256();
                    rHi = Avx2.mm256_and_si256(Avx2.mm256_sllv_epi64(aHi, n64), mm256_cmpgt_epi64(mm256_set1_epi64x(64), n64, elements));

                    return;
                }

                v256 isZero = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), n64);
                v256 isSmall = mm256_cmpgt_epi64(mm256_set1_epi64x(64), n64, elements);

                v256 smallLo = Avx2.mm256_sllv_epi64(aLo, n64);
                v256 smallHi = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi64(aHi, n64), Avx2.mm256_srlv_epi64(aLo, Avx2.mm256_sub_epi64(mm256_set1_epi64x(64), n64)));

                v256 largeHi = Avx2.mm256_sllv_epi64(aLo, Avx2.mm256_sub_epi64(n64, mm256_set1_epi64x(64)));

                rLo = Avx2.mm256_and_si256(mm256_blendv_si256(smallLo, aLo, isZero), isSmall);
                rHi = mm256_blendv_si256(largeHi, mm256_blendv_si256(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void srli_epi128(v128 aLo, v128 aHi, int n, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI64(aHi, 0))
                {
                    rLo = and_si128(srli_epi64(aLo, n, inRange: constexpr.IS_TRUE(n != 64)), set1_epi64x(-maxmath.tolong(n < 64)));
                    rHi = setzero_si128();

                    return;
                }
                if (constexpr.IS_CONST(n))
                {
                    constshr_epu128(aLo, aHi, n, out rLo, out rHi);

                    return;
                }

                v128 isZero = set1_epi64x(-maxmath.tolong(n == 0));
                v128 isSmall = set1_epi64x(-maxmath.tolong(n < 64));

                v128 smallLo = or_si128(srli_epi64(aLo, n, inRange: SHIFT128_IN_RANGE), slli_epi64(aHi, 64 - n, inRange: SHIFT128_IN_RANGE));
                v128 smallHi = srli_epi64(aHi, n, inRange: SHIFT128_IN_RANGE);

                v128 largeLo = srli_epi64(aHi, n - 64, inRange: SHIFT128_IN_RANGE);

                rLo = blendv_si128(largeLo, blendv_si128(smallLo, aLo, isZero), isSmall);
                rHi = and_si128(blendv_si128(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_srli_epi128(v256 aLo, v256 aHi, int n, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(aHi, 0, elements))
                {
                    rLo = Avx2.mm256_and_si256(mm256_srli_epi64(aLo, n), mm256_set1_epi64x(-maxmath.tolong(n < 64)));
                    rHi = Avx.mm256_setzero_si256();

                    return;
                }
                if (constexpr.IS_CONST(n))
                {
                    mm256_constshr_epu128(aLo, aHi, n, out rLo, out rHi);

                    return;
                }

                v256 isZero = mm256_set1_epi64x(-maxmath.tolong(n == 0));
                v256 isSmall = mm256_set1_epi64x(-maxmath.tolong(n < 64));

                v256 smallLo = Avx2.mm256_or_si256(mm256_srli_epi64(aLo, n), mm256_slli_epi64(aHi, 64 - n));
                v256 smallHi = mm256_srli_epi64(aHi, n);

                v256 largeLo = mm256_srli_epi64(aHi, n - 64);

                rLo = mm256_blendv_si256(largeLo, mm256_blendv_si256(smallLo, aLo, isZero), isSmall);
                rHi = Avx2.mm256_and_si256(mm256_blendv_si256(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void srlv_epi128(v128 aLo, v128 aHi, v128 n64, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                inRange |= constexpr.ALL_GE_EPU64(n64, 0) && constexpr.ALL_LE_EPU64(n64, 127);

                if (constexpr.ALL_EQ_EPU64(aHi, 0))
                {
                    rLo = and_si128(srlv_epi64(aLo, n64, inRange: constexpr.ALL_NEQ_EPI64(n64, 64)), cmpgt_epi64(set1_epi64x(64), n64));
                    rHi = setzero_si128();

                    return;
                }

                v128 isZero = cmpeq_epi64(setzero_si128(), n64);
                v128 isSmall = cmpgt_epi64(set1_epi64x(64), n64);

                v128 smallLo = or_si128(srlv_epi64(aLo, n64, inRange: SHIFT128_IN_RANGE), sllv_epi64(aHi, sub_epi64(set1_epi64x(64), n64), inRange: SHIFT128_IN_RANGE));
                v128 smallHi = srlv_epi64(aHi, n64, inRange: SHIFT128_IN_RANGE);

                v128 largeLo = srlv_epi64(aHi, sub_epi64(n64, set1_epi64x(64)), inRange: SHIFT128_IN_RANGE);

                rLo = blendv_si128(largeLo, blendv_si128(smallLo, aLo, isZero), isSmall);
                rHi = and_si128(blendv_si128(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_srlv_epi128(v256 aLo, v256 aHi, v256 n64, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                {
                    rLo = Avx2.mm256_and_si256(Avx2.mm256_srlv_epi64(aLo, n64), mm256_cmpgt_epi64(mm256_set1_epi64x(64), n64));
                    rHi = Avx.mm256_setzero_si256();

                    return;
                }

                v256 isZero = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), n64);
                v256 isSmall = mm256_cmpgt_epi64(mm256_set1_epi64x(64), n64);

                v256 smallLo = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi64(aLo, n64), Avx2.mm256_sllv_epi64(aHi, Avx2.mm256_sub_epi64(mm256_set1_epi64x(64), n64)));
                v256 smallHi = Avx2.mm256_srlv_epi64(aHi, n64);

                v256 largeLo = Avx2.mm256_srlv_epi64(aHi, Avx2.mm256_sub_epi64(n64, mm256_set1_epi64x(64)));

                rLo = mm256_blendv_si256(largeLo, mm256_blendv_si256(smallLo, aLo, isZero), isSmall);
                rHi = Avx2.mm256_and_si256(mm256_blendv_si256(smallHi, aHi, isZero), isSmall);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpeq_epi128(v128 aLo, v128 aHi, v128 bLo, v128 bHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU64(aLo, 0)
                 && constexpr.ALL_EQ_EPU64(aHi, 0))
                {
                    return cmpeq_epi64(setzero_si128(), or_si128(bLo, bHi));
                }
                if (constexpr.ALL_EQ_EPU64(bLo, 0)
                 && constexpr.ALL_EQ_EPU64(bHi, 0))
                {
                    return cmpeq_epi64(setzero_si128(), or_si128(aLo, aHi));
                }

                return and_si128(cmpeq_epi64(aLo, bLo), cmpeq_epi64(aHi, bHi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpeq_epi128(v256 aLo, v256 aHi, v256 bLo, v256 bHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(aLo, 0, elements)
                 && constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                {
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_or_si256(bLo, bHi));
                }
                if (constexpr.ALL_EQ_EPU64(bLo, 0, elements)
                 && constexpr.ALL_EQ_EPU64(bHi, 0, elements))
                {
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_or_si256(aLo, aHi));
                }

                return Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi64(aLo, bLo), Avx2.mm256_cmpeq_epi64(aHi, bHi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu128xepu64(v128 a128Lo, v128 a128Hi, v128 b64)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_TRUE(constexpr.ALL_POW2_EPU128(a128Lo, a128Hi)))
                {
                    neg_epi128(a128Lo, a128Hi, out v128 neg128Lo, out _);
                    return cmpeq_epi64(setzero_si128(), and_si128(b64, neg128Lo));
                }

                return ornot_si128(cmpeq_epi64(a128Hi, setzero_si128()), cmpgt_epu64(a128Lo, b64));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu128xepu64(v256 a128Lo, v256 a128Hi, v256 b64, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(constexpr.ALL_POW2_EPU128(a128Lo, a128Hi, elements)))
                {
                    mm256_neg_epi128(a128Lo, a128Hi, out v256 neg128Lo, out _);
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(b64, neg128Lo));
                }

                return mm256_ornot_si256(Avx2.mm256_cmpeq_epi64(a128Hi, Avx.mm256_setzero_si256()), mm256_cmpgt_epu64(a128Lo, b64, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu64xepu128(v128 a64, v128 b128Lo, v128 b128Hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_POW2_EPU64(a64))
                {
                    neg_epi128(a64, setzero_si128(), out v128 negLo, out _);
                    return cmpeq_epi64(setzero_si128(), ternarylogic_si128(b128Lo, b128Hi, negLo, TernaryOperation.OxEC));
                }

                return and_si128(cmpeq_epi64(setzero_si128(), b128Hi), cmpgt_epu64(a64, b128Lo));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu64xepu128(v256 a64, v256 b128Lo, v256 b128Hi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_POW2_EPU64(a64, elements))
                {
                    mm256_neg_epi128(a64, Avx.mm256_setzero_si256(), out v256 negLo, out _);
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), mm256_ternarylogic_si256(b128Lo, b128Hi, negLo, TernaryOperation.OxEC));
                }

                return Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), b128Hi), mm256_cmpgt_epu64(a64, b128Lo, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu128(v128 aLo, v128 aHi, v128 bLo, v128 bHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI64(aHi, 0))
                {
                    return cmpgt_epu64xepu128(aLo, bLo, bHi);
                }
                else if (constexpr.ALL_EQ_EPI64(bHi, 0))
                {
                    return cmpgt_epu128xepu64(aLo, aHi, bLo);
                }
                if (constexpr.ALL_POW2_EPU128(aLo, aHi))
                {
                    neg_epi128(aLo, bLo, out v128 negLo, out v128 negHi);
                    return cmpeq_epi128(setzero_si128(), setzero_si128(), and_si128(negLo, bLo), and_si128(negHi, bHi));
                }

                return ternarylogic_si128(cmpgt_epu64(aHi, bHi), cmpeq_epi64(aHi, bHi), cmpgt_epu64(aLo, bLo), TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu128(v256 aLo, v256 aHi, v256 bLo, v256 bHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(aHi, 0, elements))
                {
                    return mm256_cmpgt_epu64xepu128(aLo, bLo, bHi);
                }
                else if (constexpr.ALL_EQ_EPI64(bHi, 0, elements))
                {
                    return mm256_cmpgt_epu128xepu64(aLo, aHi, bLo);
                }
                if (constexpr.ALL_POW2_EPU128(aLo, aHi, elements))
                {
                    mm256_neg_epi128(aLo, bLo, out v256 negLo, out v256 negHi);
                    return mm256_cmpeq_epi128(Avx.mm256_setzero_si256(), Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(negLo, bLo), Avx2.mm256_and_si256(negHi, bHi), elements);
                }

                return mm256_ternarylogic_si256(mm256_cmpgt_epu64(aHi, bHi, elements), Avx2.mm256_cmpeq_epi64(aHi, bHi), mm256_cmpgt_epu64(aLo, bLo, elements), TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epi128(v128 aLo, v128 aHi, v128 bLo, v128 bHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU64(aLo, 0) && constexpr.ALL_EQ_EPU64(aHi, 0))
                {
                    return cmpgt_epi64(setzero_si128(), bHi);
                }

                return ternarylogic_si128(cmpgt_epi64(aHi, bHi), cmpeq_epi64(aHi, bHi), cmpgt_epu64(aLo, bLo), TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epi128(v256 aLo, v256 aHi, v256 bLo, v256 bHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(aLo, 0, elements) && constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                {
                    return mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), bHi, elements);
                }

                return mm256_ternarylogic_si256(mm256_cmpgt_epi64(aHi, bHi, elements), Avx2.mm256_cmpeq_epi64(aHi, bHi), mm256_cmpgt_epu64(aLo, bLo, elements), TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void neg_epi128(v128 aLo, v128 aHi, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                rLo = neg_epi64(aLo);
                rHi = add_epi64(neg_epi64(aHi), not_si128(cmpeq_epi64(aLo, setzero_si128())));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_neg_epi128(v256 aLo, v256 aHi, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                rLo = mm256_neg_epi64(aLo);
                rHi = Avx2.mm256_add_epi64(mm256_neg_epi64(aHi), mm256_not_si256(Avx2.mm256_cmpeq_epi64(aLo, Avx.mm256_setzero_si256())));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void dec_epu128(v128 aLo, v128 aHi, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                rHi = add_epi64(aHi, cmpeq_epi64(aLo, setzero_si128()));
                rLo = dec_epi64(aLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_dec_epu128(v256 aLo, v256 aHi, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                rHi = Avx2.mm256_add_epi64(aHi, Avx2.mm256_cmpeq_epi64(aLo, Avx.mm256_setzero_si256()));
                rLo = mm256_dec_epi64(aLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void add_epi128(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                rLo = add_epi64(aLo, bLo);
                rHi = add_epi64(aHi, bHi);

                v128 carry = cmpgt_epu64(aLo, rLo);
                rHi = sub_epi64(rHi, carry);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_add_epi128(v256 aLo, v256 aHi, v256 bLo, v256 bHi, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                rLo = Avx2.mm256_add_epi64(aLo, bLo);
                rHi = Avx2.mm256_add_epi64(aHi, bHi);

                v256 carry = mm256_cmpgt_epu64(aLo, rLo, elements);
                rHi = Avx2.mm256_sub_epi64(rHi, carry);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sub_epi128(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                rLo = sub_epi64(aLo, bLo);
                rHi = sub_epi64(aHi, bHi);

                rHi = add_epi64(rHi, cmpgt_epu64(bLo, aLo));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_sub_epi128(v256 aLo, v256 aHi, v256 bLo, v256 bHi, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                rLo = Avx2.mm256_sub_epi64(aLo, bLo);
                rHi = Avx2.mm256_sub_epi64(aHi, bHi);

                rHi = Avx2.mm256_add_epi64(rHi, mm256_cmpgt_epu64(bLo, aLo, elements));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulloepu128_epu64(v128 aLo, v128 aHi, v128 b, [NoAlias] out v128 lo, [NoAlias] out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU64(aLo, 0) && constexpr.ALL_EQ_EPU64(aHi, 0))
                {
                    hi = setzero_si128();
                    lo = setzero_si128();

                    return;
                }
                if (constexpr.ALL_EQ_EPU64(aLo, 1) && constexpr.ALL_EQ_EPU64(aHi, 0))
                {
                    hi = setzero_si128();
                    lo = b;

                    return;
                }

                hi = mulhi_epu64(b, aLo, out lo);

                if (constexpr.ALL_EQ_EPU64(aHi, 0))
                {
                    ;
                }
                else if (constexpr.ALL_EQ_EPU64(aHi, ulong.MaxValue))
                {
                    hi = sub_epi64(hi, b);
                }
                else
                {
                    hi = add_epi64(hi, mullo_epi64(b, aHi));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_mulloepu128_epu64(v256 aLo, v256 aHi, v256 b, [NoAlias] out v256 lo, [NoAlias] out v256 hi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(aLo, 0, elements) && constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                {
                    hi = Avx.mm256_setzero_si256();
                    lo = Avx.mm256_setzero_si256();

                    return;
                }
                if (constexpr.ALL_EQ_EPU64(aLo, 1, elements) && constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                {
                    hi = Avx.mm256_setzero_si256();
                    lo = b;

                    return;
                }

                hi = mm256_mulhi_epu64(b, aLo, out lo, elements);

                if (constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                {
                    ;
                }
                else if (constexpr.ALL_EQ_EPU64(aHi, ulong.MaxValue, elements))
                {
                    hi = Avx2.mm256_sub_epi64(hi, b);
                }
                else
                {
                    hi = Avx2.mm256_add_epi64(hi, mm256_mullo_epi64(b, aHi, elements));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void square_epi128(v128 aLo, v128 aHi, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                rHi = add_epi64(squarehi_epu64(aLo, out rLo), slli_epi64(mullo_epi64(aLo, aHi), 1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_square_epi128(v256 aLo, v256 aHi, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                rHi = Avx2.mm256_add_epi64(mm256_squarehi_epu64(aLo, out rLo, elements), mm256_slli_epi64(mm256_mullo_epi64(aLo, aHi, elements), 1));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfdivremepu128hi_epu64(v128 aHi, v128 b, out v128 c, bool useFPU = false, bool unsafeRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
if (!unsafeRange)
{
    VectorAssert.IsSmaller<ulong2, ulong>(aHi, b, 2);
}
                v128 U32_MASK = set1_epi64x(0xFFFF_FFFFu);

                v128 shift = lzcnt_epi64(b);
                aHi = sllv_epi64(aHi, shift, inRange: true);
                b = sllv_epi64(b, shift, inRange: true);
                v128 bLo = and_si128(b, U32_MASK);
                v128 bHi = srli_epi64(b, 32);

                v128 qHi;
                v128 remdiv;
                if (useFPU)
                {
                    qHi = impl_divrem_epu64(aHi, bHi, out remdiv, useFPU: true, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, mullo_epi64(qHi, bLo, unsigned_B_lessequalU32Max: true));
                }
                else
                {
                    qHi = impl_divrem_epu64(aHi, bHi, out remdiv, useFPU: false, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, new v128(qHi.ULong0 * bLo.ULong0, qHi.ULong1 * bLo.ULong1));
                }
                v128 b1 = cmpgt_epu64(c, remdiv);
                v128 b2 = and_si128(b1, cmpgt_epu64(neg_epi64(c), b));
                qHi = add_epi64(qHi, b2);
                qHi = add_epi64(qHi, b1);
                c = add_epi64(c, and_si128(b1, b));
                c = add_epi64(c, and_si128(b2, b));

                v128 qLo;
                if (useFPU)
                {
                    qLo = impl_divrem_epu64(c, bHi, out remdiv, useFPU: true, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, mullo_epi64(qLo, bLo, unsigned_B_lessequalU32Max: true));
                }
                else
                {
                    qLo = impl_divrem_epu64(c, bHi, out remdiv, useFPU: false, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, new v128(qLo.ULong0 * bLo.ULong0, qLo.ULong1 * bLo.ULong1));
                }
                b1 = cmpgt_epu64(c, remdiv);
                b2 = and_si128(b1, cmpgt_epu64(neg_epi64(c), b));
                qLo = add_epi64(qLo, b2);
                qLo = add_epi64(qLo, b1);
                c = add_epi64(c, and_si128(b1, b));
                c = add_epi64(c, and_si128(b2, b));

                c = srlv_epi64(c, shift, inRange: true);
                constexpr.ASSUME_LT_EPU64(c, b);
                return ternarylogic_si128(slli_epi64(qHi, 32), qLo, U32_MASK, TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfdivremepu128hi_epu64(v256 aHi, v256 b, out v256 c, byte elements = 4, bool unsafeRange = false)
        {
            if (Avx2.IsAvx2Supported)
            {
if (!unsafeRange)
{
    VectorAssert.IsSmaller<ulong4, ulong>(aHi, b, elements);
}
                v256 U32_MASK = mm256_set1_epi64x(0xFFFF_FFFFu);

                v256 shift = mm256_lzcnt_epi64(b);
                aHi = Avx2.mm256_sllv_epi64(aHi, shift);
                b = Avx2.mm256_sllv_epi64(b, shift);
                v256 bLo = Avx2.mm256_and_si256(b, U32_MASK);
                v256 bHi = Avx2.mm256_srli_epi64(b, 32);

                v256 qHi = mm256_impl_divrem_epu64(aHi, bHi, out v256 remdiv, bLEu32max: true, elements: elements);
                remdiv = Avx2.mm256_slli_epi64(remdiv, 32);
                c = Avx2.mm256_sub_epi64(remdiv, mm256_mullo_epi64(qHi, bLo, elements, unsigned_B_lessequalU32Max: true));
                v256 b1 = mm256_cmpgt_epu64(c, remdiv, elements);
                v256 b2 = Avx2.mm256_and_si256(b1, mm256_cmpgt_epu64(mm256_neg_epi64(c), b, elements));
                qHi = Avx2.mm256_add_epi64(qHi, b2);
                qHi = Avx2.mm256_add_epi64(qHi, b1);
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b1, b));
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b2, b));

                v256 qLo = mm256_impl_divrem_epu64(c, bHi, out remdiv, bLEu32max: true, elements: elements);
                remdiv = Avx2.mm256_slli_epi64(remdiv, 32);
                c = Avx2.mm256_sub_epi64(remdiv, mm256_mullo_epi64(qLo, bLo, elements, unsigned_B_lessequalU32Max: true));
                b1 = mm256_cmpgt_epu64(c, remdiv, elements);
                b2 = Avx2.mm256_and_si256(b1, mm256_cmpgt_epu64(mm256_neg_epi64(c), b, elements));
                qLo = Avx2.mm256_add_epi64(qLo, b2);
                qLo = Avx2.mm256_add_epi64(qLo, b1);
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b1, b));
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b2, b));

                c = Avx2.mm256_srlv_epi64(c, shift);
                constexpr.ASSUME_LT_EPU64(c, b, elements);
                return mm256_ternarylogic_si256(Avx2.mm256_slli_epi64(qHi, 32), qLo, U32_MASK, TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfdivremepu128_epu64(v128 aLo, v128 aHi, v128 b, out v128 c, bool useFPU = false, bool bIsDbl = false, bool unsafeRange = false, bool clampbDblToMaxValue = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 bInt64 = bIsDbl ? cvttpd_epu64(b, nonZero: true) : b;
                bInt64 = clampbDblToMaxValue ? or_si128(bInt64, cmpge_pd(b, set1_pd(ulong.MaxValue))) : bInt64;

if (bIsDbl)
{
    // Caller is responsible
    VectorAssert.AreNotEqual<ulong2, ulong>(bInt64, 0, 2);
}
if (!unsafeRange)
{
    VectorAssert.IsSmaller<ulong2, ulong>(aHi, bInt64, 2);
}
                v128 U32_MASK = set1_epi64x(0xFFFF_FFFFu);

                v128 shift = lzcnt_epi64(bInt64);
                sllv_epi128(aLo, aHi, shift, out aLo, out aHi, inRange: true);
                bInt64 = sllv_epi64(bInt64, shift, inRange: true);
                v128 bLo = and_si128(bInt64, U32_MASK);
                v128 bHi = srli_epi64(bInt64, 32);

                v128 qHi;
                v128 remdiv;
                if (useFPU)
                {
                    qHi = divrem_epu64(aHi, bHi, out remdiv, useFPU: true, bLEu32max: true);
                    remdiv = or_si128(slli_epi64(remdiv, 32), srli_epi64(aLo, 32));
                    c = sub_epi64(remdiv, mullo_epi64(qHi, bLo, unsigned_B_lessequalU32Max: true));
                }
                else
                {
                    qHi = divrem_epu64(aHi, bHi, out remdiv, useFPU: false, bLEu32max: true);
                    remdiv = or_si128(slli_epi64(remdiv, 32), srli_epi64(aLo, 32));
                    c = sub_epi64(remdiv, new v128(qHi.ULong0 * bLo.ULong0, qHi.ULong1 * bLo.ULong1));
                }
                v128 b1 = cmpgt_epu64(c, remdiv);
                v128 b2 = and_si128(b1, cmpgt_epu64(neg_epi64(c), bInt64));
                qHi = add_epi64(qHi, b2);
                qHi = add_epi64(qHi, b1);
                c = add_epi64(c, and_si128(b1, bInt64));
                c = add_epi64(c, and_si128(b2, bInt64));

                v128 qLo;
                if (useFPU)
                {
                    qLo = divrem_epu64(c, bHi, out remdiv, useFPU: true, bLEu32max: true);
                    remdiv = ternarylogic_si128(slli_epi64(remdiv, 32), aLo, U32_MASK, TernaryOperation.OxF8);
                    c = sub_epi64(remdiv, mullo_epi64(qLo, bLo, unsigned_B_lessequalU32Max: true));
                }
                else
                {
                    qLo = divrem_epu64(c, bHi, out remdiv, useFPU: false, bLEu32max: true);
                    remdiv = ternarylogic_si128(slli_epi64(remdiv, 32), aLo, U32_MASK, TernaryOperation.OxF8);
                    c = sub_epi64(remdiv, new v128(qLo.ULong0 * bLo.ULong0, qLo.ULong1 * bLo.ULong1));
                }
                b1 = cmpgt_epu64(c, remdiv);
                b2 = and_si128(b1, cmpgt_epu64(neg_epi64(c), bInt64));
                qLo = add_epi64(qLo, b2);
                qLo = add_epi64(qLo, b1);
                c = add_epi64(c, and_si128(b1, bInt64));
                c = add_epi64(c, and_si128(b2, bInt64));

                c = srlv_epi64(c, shift, inRange: true);
                constexpr.ASSUME_LT_EPU64(c, bInt64);
                return ternarylogic_si128(slli_epi64(qHi, 32), qLo, U32_MASK, TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfdivremepu128_epu64(v256 aLo, v256 aHi, v256 b, out v256 c, byte elements = 4, bool bIsDbl = false, bool unsafeRange = false, bool clampbDblToMaxValue = false)
        {
            if (Avx2.IsAvx2Supported)
            {
if (bIsDbl)
{
    // Caller is responsible
    VectorAssert.AreNotEqual<ulong4, ulong>(mm256_cvttpd_epu64(b, elements, nonZero: true), 0, elements);
}
if (!unsafeRange)
{
    VectorAssert.IsSmaller<ulong4, ulong>(aHi, bIsDbl ? mm256_cvttpd_epu64(b, elements, nonZero: true) : b, elements);
}
                v256 U32_MASK = mm256_set1_epi64x(0xFFFF_FFFFu);

                v256 shift;
                v256 bIntLo;
                v256 bHi;
                if (bIsDbl)
                {
                    // lzcnt_pd but different and with extra steps
                    v256 EXP32 = mm256_set1_epi64x(32L << F64_MANTISSA_BITS);
                    v256 GREATER_THRESHOLD = mm256_set1_epi64x((31L - F64_EXPONENT_BIAS) << F64_MANTISSA_BITS);
                    v256 MANTISSA_MASK = mm256_set1_epi64x(maxmath.bitmask64((ulong)F64_MANTISSA_BITS));

                    v256 hi0 = Avx2.mm256_cmpgt_epi32(b, GREATER_THRESHOLD);

                    v256 bits = Avx.mm256_blendv_pd(Avx2.mm256_sub_epi64(b, EXP32), b, hi0);
                    v256 offset = Avx.mm256_blendv_pd(mm256_set1_epi64x(0x041Eul << F64_MANTISSA_BITS), mm256_set1_epi64x(0x043Eul << F64_MANTISSA_BITS), hi0);
                    bits = Avx2.mm256_sub_epi64(offset, Avx2.mm256_andnot_si256(MANTISSA_MASK, bits));
                    v256 lzcntShifted = Avx2.mm256_min_epu32(bits, mm256_set1_epi64x(64ul << F64_MANTISSA_BITS));
                    shift = mm256_srli_epi64(lzcntShifted, F64_MANTISSA_BITS);

                    bHi = Avx2.mm256_sub_epi64(b, EXP32);
                    bHi = Avx2.mm256_add_epi64(bHi, lzcntShifted);
                    b = Avx2.mm256_add_epi64(b, lzcntShifted);
                    v256 cvtt = mm256_cvttpd_epu64(b, elements, nonZero: true);
                    b = clampbDblToMaxValue ? Avx2.mm256_or_si256(cvtt, mm256_cmpge_pd(cvtt, mm256_set1_pd(ulong.MaxValue))) : cvtt;
                    bIntLo = Avx2.mm256_and_si256(b, U32_MASK);
                }
                else
                {
                    shift = mm256_lzcnt_epi64(b);
                    b = Avx2.mm256_sllv_epi64(b, shift);
                    bIntLo = Avx2.mm256_and_si256(b, U32_MASK);
                    bHi = Avx2.mm256_srli_epi64(b, 32);
                }

                mm256_sllv_epi128(aLo, aHi, shift, out aLo, out aHi);

                v256 qHi = mm256_impl_divrem_epu64(aHi, bHi, out v256 remdiv, bLEu32max: true, bIsDbl: bIsDbl, elements: elements);
                remdiv = Avx2.mm256_or_si256(mm256_slli_epi64(remdiv, 32), mm256_srli_epi64(aLo, 32));
                c = Avx2.mm256_sub_epi64(remdiv, mm256_mullo_epi64(qHi, bIntLo, elements, unsigned_B_lessequalU32Max: true));
                v256 b1 = mm256_cmpgt_epu64(c, remdiv, elements);
                v256 b2 = Avx2.mm256_and_si256(b1, mm256_cmpgt_epu64(mm256_neg_epi64(c), b, elements));
                qHi = Avx2.mm256_add_epi64(qHi, b2);
                qHi = Avx2.mm256_add_epi64(qHi, b1);
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b1, b));
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b2, b));

                v256 qLo = mm256_impl_divrem_epu64(c, bHi, out remdiv, bLEu32max: true, bIsDbl: bIsDbl, elements: elements);
                remdiv = mm256_ternarylogic_si256(mm256_slli_epi64(remdiv, 32), aLo, U32_MASK, TernaryOperation.OxF8);
                c = Avx2.mm256_sub_epi64(remdiv, mm256_mullo_epi64(qLo, bIntLo, elements, unsigned_B_lessequalU32Max: true));
                b1 = mm256_cmpgt_epu64(c, remdiv, elements);
                b2 = Avx2.mm256_and_si256(b1, mm256_cmpgt_epu64(mm256_neg_epi64(c), b, elements));
                qLo = Avx2.mm256_add_epi64(qLo, b2);
                qLo = Avx2.mm256_add_epi64(qLo, b1);
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b1, b));
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b2, b));

                c = Avx2.mm256_srlv_epi64(c, shift);
                constexpr.ASSUME_LT_EPU64(c, b, elements);
                return mm256_ternarylogic_si256(Avx2.mm256_slli_epi64(qHi, 32), qLo, U32_MASK, TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void divremepu128_epu64(v128 aLo, v128 aHi, v128 b, [NoAlias] out v128 rLo, [NoAlias] out v128 rHi, [NoAlias] out v128 c, bool useFPU = false, bool bIsDbl = false, bool clampbDblToMaxValue = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LT_EPU64(aHi, bIsDbl ? cvttpd_epu64(b, nonZero: true) : b))
                {
                    rLo = usfdivremepu128_epu64(aLo, aHi, b, out c, useFPU: useFPU, bIsDbl: bIsDbl, clampbDblToMaxValue: clampbDblToMaxValue);
                    rHi = setzero_si128();
                }
                else
                {
                    v128 qHi = divrem_epu64(aHi, b, out v128 dividendHi, useFPU : useFPU, bIsDbl: bIsDbl);
                    v128 cmp = bIsDbl ? cvttpd_epu64(b, nonZero: true) : b;
                    cmp = clampbDblToMaxValue ? or_si128(cmp, cmpge_pd(b, set1_pd(ulong.MaxValue))) : cmp;
                    v128 swapMask = cmplt_epu64(aHi, cmp);
                    aHi = blendv_si128(dividendHi, aHi, swapMask);

                    rLo = usfdivremepu128_epu64(aLo, aHi, b, out c, useFPU : useFPU, bIsDbl: bIsDbl, clampbDblToMaxValue: clampbDblToMaxValue);
                    rHi = andnot_si128(swapMask, qHi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_divremepu128_epu64(v256 aLo, v256 aHi, v256 b, [NoAlias] out v256 rLo, [NoAlias] out v256 rHi, [NoAlias] out v256 c, byte elements = 4, bool bIsDbl = false, bool clampbDblToMaxValue = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPU64(aHi, bIsDbl ? mm256_cvttpd_epu64(b, elements: elements, nonZero: true) : b, elements))
                {
                    rLo = mm256_usfdivremepu128_epu64(aLo, aHi, b, out c, elements: elements, bIsDbl: bIsDbl, clampbDblToMaxValue: clampbDblToMaxValue);
                    rHi = Avx.mm256_setzero_si256();
                }
                else
                {
                    v256 qHi = mm256_divrem_epu64(aHi, b, out v256 dividendHi, elements: elements, bIsDbl: bIsDbl);
                    v256 cmp = bIsDbl ? mm256_cvttpd_epu64(b, elements: elements, nonZero: true) : b;
                    cmp = clampbDblToMaxValue ? Avx2.mm256_or_si256(cmp, mm256_cmpge_pd(b, mm256_set1_pd(ulong.MaxValue))) : cmp;
                    v256 swapMask = mm256_cmplt_epu64(aHi, cmp, elements: elements);
                    aHi = mm256_blendv_si256(dividendHi, aHi, swapMask);

                    rLo = mm256_usfdivremepu128_epu64(aLo, aHi, b, out c, elements: elements, bIsDbl: bIsDbl, clampbDblToMaxValue: clampbDblToMaxValue);
                    rHi = Avx2.mm256_andnot_si256(swapMask, qHi);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu128_pd(v128 aLo, v128 aHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 cvtLo = cvtepu64_pd(aLo);
                v128 cvtHi = cvtepu64_pd(aHi);

                v128 hi0 = cmpeq_epi64(aHi, setzero_si128());
                v128 hi = andnot_si128(hi0, set1_pd(ulong.MaxValue));
                v128 lo = blendv_si128(cvtHi, new v128(1d), hi0);

                return fmadd_pd(lo, hi, cvtLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu128_pd(v256 aLo, v256 aHi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 cvtLo = mm256_cvtepu64_pd(aLo, elements);
                v256 cvtHi = mm256_cvtepu64_pd(aHi, elements);

                v256 hi0 = Avx2.mm256_cmpeq_epi64(aHi, Avx.mm256_setzero_si256());
                v256 hi = Avx2.mm256_andnot_si256(hi0, mm256_set1_pd(ulong.MaxValue));
                v256 lo = mm256_blendv_si256(cvtHi, new v256(1d), hi0);

                return mm256_fmadd_pd(lo, hi, cvtLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvttpd_epu128(v128 a, [NoAlias] out v128 rlo, [NoAlias] out v128 rhi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                BASE_cvtpd_ep128(a, out rlo, out rhi, signed: false, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvttpd_epu128(v256 a, [NoAlias] out v256 rlo, [NoAlias] out v256 rhi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                BASE__mm256_cvtpd_ep128(a, out rlo, out rhi, signed: false, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvtpd_epu128(v128 a, [NoAlias] out v128 rlo, [NoAlias] out v128 rhi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                BASE_cvtpd_ep128(a, out rlo, out rhi, signed: false, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvtpd_epu128(v256 a, [NoAlias] out v256 rlo, [NoAlias] out v256 rhi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                BASE__mm256_cvtpd_ep128(a, out rlo, out rhi, signed: false, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvttpd_epi128(v128 a, [NoAlias] out v128 rlo, [NoAlias] out v128 rhi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                BASE_cvtpd_ep128(a, out rlo, out rhi, signed: true, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvttpd_epi128(v256 a, [NoAlias] out v256 rlo, [NoAlias] out v256 rhi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                BASE__mm256_cvtpd_ep128(a, out rlo, out rhi, signed: true, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvtpd_epi128(v128 a, [NoAlias] out v128 rlo, [NoAlias] out v128 rhi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                BASE_cvtpd_ep128(a, out rlo, out rhi, signed: true, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvtpd_epi128(v256 a, [NoAlias] out v256 rlo, [NoAlias] out v256 rhi, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                BASE__mm256_cvtpd_ep128(a, out rlo, out rhi, signed: true, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BASE_cvtpd_ep128(v128 a, [NoAlias] out v128 rlo, [NoAlias] out v128 rhi, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false, bool adjustSign = true)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                nonZero |= constexpr.ALL_NEQ_PD(a, 0, 2);
                positive |= constexpr.ALL_GT_PD(a, 0, 2);

                v128 IMPLICIT_ONE = set1_epi64x(1L << F64_MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi64x(maxmath.bitmask64((long)F64_MANTISSA_BITS));
                v128 EXP = set1_epi64x(math.abs(F64_EXPONENT_BIAS) + F64_MANTISSA_BITS);

                v128 biasedExponent;
                if (positive || (!signed && nonZero) || (!signed && !COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO) | constexpr.ALL_LT_EPU64(a, 1ul << 63) || constexpr.ALL_GT_PD(a, 0d))
                {
                    biasedExponent = srli_epi64(a, F64_MANTISSA_BITS);
                }
                else
                {
                    biasedExponent = srli_epi64(slli_epi64(a, 1), F64_MANTISSA_BITS + 1);
                }

                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);

                sllv_epi128(mantissa, setzero_si128(), shift_int, out rlo, out rhi);

                if (!trunc)
                {
                    v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                    sllv_epi128(ifRound, setzero_si128(), dec_epi64(shift_mnt), out v128 roundLo, out v128 roundHi);

                    if (evenOnTie)
                    {
                        sub_epi128(roundLo, roundHi, andnot_si128(srlv_epi64(mantissa, shift_mnt), ifRound), ifRound, out roundLo, out roundHi);
                    }

                    add_epi128(rlo, rhi, roundLo, roundHi, out rlo, out rhi);
                }

                srlv_epi128(rlo, rhi, shift_mnt, out rlo, out rhi);

                if (adjustSign && signed && !positive)
                {
                    if (!constexpr.ALL_GE_PD(a, 0d))
                    {
                        v128 signMask = cmpgt_pd(setzero_si128(), a);

                        rlo = xor_si128(rlo, signMask);
                        rhi = xor_si128(rhi, signMask);
                        sub_epi128(rlo, rhi, signMask, signMask, out rlo, out rhi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void BASE__mm256_cvtpd_ep128(v256 a, [NoAlias] out v256 rlo, [NoAlias] out v256 rhi, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false, bool adjustSign = true, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= constexpr.ALL_NEQ_PD(a, 0, 2);
                positive |= constexpr.ALL_GT_PD(a, 0, 2);

                v256 IMPLICIT_ONE = mm256_set1_epi64x(1L << F64_MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi64x(maxmath.bitmask64((long)F64_MANTISSA_BITS));
                v256 EXP = mm256_set1_epi64x(math.abs(F64_EXPONENT_BIAS) + F64_MANTISSA_BITS);

                v256 biasedExponent;
                if (positive || (!signed && nonZero) || (!signed && !COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO) | constexpr.ALL_LT_EPU64(a, 1ul << 63, elements) || constexpr.ALL_GT_PD(a, 0d, elements))
                {
                    biasedExponent = mm256_srli_epi64(a, F64_MANTISSA_BITS);
                }
                else
                {
                    biasedExponent = mm256_srli_epi64(mm256_slli_epi64(a, 1), F64_MANTISSA_BITS + 1);
                }

                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                mm256_sllv_epi128(mantissa, Avx.mm256_setzero_si256(), shift_int, out rlo, out rhi, elements);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    mm256_sllv_epi128(ifRound, Avx.mm256_setzero_si256(), mm256_dec_epi64(shift_mnt), out v256 roundLo, out v256 roundHi, elements);

                    if (evenOnTie)
                    {
                        mm256_sub_epi128(roundLo, roundHi, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi64(mantissa, shift_mnt), ifRound), ifRound, out roundLo, out roundHi, elements);
                    }

                    mm256_add_epi128(rlo, rhi, roundLo, roundHi, out rlo, out rhi, elements);
                }

                mm256_srlv_epi128(rlo, rhi, shift_mnt, out rlo, out rhi, elements);

                if (adjustSign && signed && !positive)
                {
                    if (!constexpr.ALL_GE_PD(a, 0d))
                    {
                        v256 signMask = mm256_cmpgt_pd(Avx.mm256_setzero_si256(), a);

                        rlo = Avx2.mm256_xor_si256(rlo, signMask);
                        rhi = Avx2.mm256_xor_si256(rhi, signMask);
                        mm256_sub_epi128(rlo, rhi, signMask, signMask, out rlo, out rhi, elements);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 lzcnt_epi128(v128 aLo, v128 aHi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lzcntLo = lzcnt_epi64(aLo);
                v128 lzcntHi = lzcnt_epi64(aHi);

                v128 hiZero = cmpeq_epi64(aHi, setzero_si128());

                return blendv_si128(lzcntHi, add_epi64(set1_epi64x(64), lzcntLo), hiZero);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_lzcnt_epi128(v256 aLo, v256 aHi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lzcntLo = mm256_lzcnt_epi64(aLo);
                v256 lzcntHi = mm256_lzcnt_epi64(aHi);

                v256 hiZero = Avx2.mm256_cmpeq_epi64(aHi, Avx.mm256_setzero_si256());

                return mm256_blendv_si256(lzcntHi, Avx2.mm256_add_epi64(mm256_set1_epi64x(64), lzcntLo), hiZero);
            }
            else throw new IllegalInstructionException();
        }
    }
}
