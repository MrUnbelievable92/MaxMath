using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong2 rem(ulong2 dividend, ulong divisor)
        {
Assert.AreNotEqual(divisor, 0ul);

            switch (divisor)
            {
                case 1ul: return 0;
                case ulong.MaxValue: return Sse4_1.blendv_epi8(dividend, default(ulong2), Sse4_1.cmpeq_epi64(dividend, new ulong2(ulong.MaxValue)));

                case 1ul << 1:  return dividend & maxmath.bitmask64(1);
                case 1ul << 2:  return dividend & maxmath.bitmask64(2);
                case 1ul << 3:  return dividend & maxmath.bitmask64(3);
                case 1ul << 4:  return dividend & maxmath.bitmask64(4);
                case 1ul << 5:  return dividend & maxmath.bitmask64(5);
                case 1ul << 6:  return dividend & maxmath.bitmask64(6);
                case 1ul << 7:  return dividend & maxmath.bitmask64(7);
                case 1ul << 8:  return dividend & maxmath.bitmask64(8);
                case 1ul << 9:  return dividend & maxmath.bitmask64(9);
                case 1ul << 10: return dividend & maxmath.bitmask64(10);
                case 1ul << 11: return dividend & maxmath.bitmask64(11);
                case 1ul << 12: return dividend & maxmath.bitmask64(12);
                case 1ul << 13: return dividend & maxmath.bitmask64(13);
                case 1ul << 14: return dividend & maxmath.bitmask64(14);
                case 1ul << 15: return dividend & maxmath.bitmask64(15);
                case 1ul << 16: return dividend & maxmath.bitmask64(16);
                case 1ul << 17: return dividend & maxmath.bitmask64(17);
                case 1ul << 18: return dividend & maxmath.bitmask64(18);
                case 1ul << 19: return dividend & maxmath.bitmask64(19);
                case 1ul << 20: return dividend & maxmath.bitmask64(20);
                case 1ul << 21: return dividend & maxmath.bitmask64(21);
                case 1ul << 22: return dividend & maxmath.bitmask64(22);
                case 1ul << 23: return dividend & maxmath.bitmask64(23);
                case 1ul << 24: return dividend & maxmath.bitmask64(24);
                case 1ul << 25: return dividend & maxmath.bitmask64(25);
                case 1ul << 26: return dividend & maxmath.bitmask64(26);
                case 1ul << 27: return dividend & maxmath.bitmask64(27);
                case 1ul << 28: return dividend & maxmath.bitmask64(28);
                case 1ul << 29: return dividend & maxmath.bitmask64(29);
                case 1ul << 30: return dividend & maxmath.bitmask64(30);
                case 1ul << 31: return dividend & maxmath.bitmask64(31);
                case 1ul << 32: return dividend & maxmath.bitmask64(32);
                case 1ul << 33: return dividend & maxmath.bitmask64(33);
                case 1ul << 34: return dividend & maxmath.bitmask64(34);
                case 1ul << 35: return dividend & maxmath.bitmask64(35);
                case 1ul << 36: return dividend & maxmath.bitmask64(36);
                case 1ul << 37: return dividend & maxmath.bitmask64(37);
                case 1ul << 38: return dividend & maxmath.bitmask64(38);
                case 1ul << 39: return dividend & maxmath.bitmask64(39);
                case 1ul << 40: return dividend & maxmath.bitmask64(40);
                case 1ul << 41: return dividend & maxmath.bitmask64(41);
                case 1ul << 42: return dividend & maxmath.bitmask64(42);
                case 1ul << 43: return dividend & maxmath.bitmask64(43);
                case 1ul << 44: return dividend & maxmath.bitmask64(44);
                case 1ul << 45: return dividend & maxmath.bitmask64(45);
                case 1ul << 46: return dividend & maxmath.bitmask64(46);
                case 1ul << 47: return dividend & maxmath.bitmask64(47);
                case 1ul << 48: return dividend & maxmath.bitmask64(48);
                case 1ul << 49: return dividend & maxmath.bitmask64(49);
                case 1ul << 50: return dividend & maxmath.bitmask64(50);
                case 1ul << 51: return dividend & maxmath.bitmask64(51);
                case 1ul << 52: return dividend & maxmath.bitmask64(52);
                case 1ul << 53: return dividend & maxmath.bitmask64(53);
                case 1ul << 54: return dividend & maxmath.bitmask64(54);
                case 1ul << 55: return dividend & maxmath.bitmask64(55);
                case 1ul << 56: return dividend & maxmath.bitmask64(56);
                case 1ul << 57: return dividend & maxmath.bitmask64(57);
                case 1ul << 58: return dividend & maxmath.bitmask64(58);
                case 1ul << 59: return dividend & maxmath.bitmask64(59);
                case 1ul << 60: return dividend & maxmath.bitmask64(60);
                case 1ul << 61: return dividend & maxmath.bitmask64(61);
                case 1ul << 62: return dividend & maxmath.bitmask64(62);
                case 1ul << 63: return dividend & maxmath.bitmask64(63);

                default: return new ulong2(dividend.x % divisor, 
                                           dividend.y % divisor);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong3 rem(ulong3 dividend, ulong divisor) => (v256)rem((ulong4)(v256)dividend, divisor);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong4 rem(ulong4 dividend, ulong divisor)
        {
Assert.AreNotEqual(divisor, 0ul);

            switch (divisor)
            {
                case 1ul: return 0;
                case ulong.MaxValue: return Avx2.mm256_blendv_epi8(dividend, default(ulong4), Avx2.mm256_cmpeq_epi64(dividend, new ulong4(ulong.MaxValue)));

                case 1ul << 1:  return dividend & maxmath.bitmask64(1);
                case 1ul << 2:  return dividend & maxmath.bitmask64(2);
                case 1ul << 3:  return dividend & maxmath.bitmask64(3);
                case 1ul << 4:  return dividend & maxmath.bitmask64(4);
                case 1ul << 5:  return dividend & maxmath.bitmask64(5);
                case 1ul << 6:  return dividend & maxmath.bitmask64(6);
                case 1ul << 7:  return dividend & maxmath.bitmask64(7);
                case 1ul << 8:  return dividend & maxmath.bitmask64(8);
                case 1ul << 9:  return dividend & maxmath.bitmask64(9);
                case 1ul << 10: return dividend & maxmath.bitmask64(10);
                case 1ul << 11: return dividend & maxmath.bitmask64(11);
                case 1ul << 12: return dividend & maxmath.bitmask64(12);
                case 1ul << 13: return dividend & maxmath.bitmask64(13);
                case 1ul << 14: return dividend & maxmath.bitmask64(14);
                case 1ul << 15: return dividend & maxmath.bitmask64(15);
                case 1ul << 16: return dividend & maxmath.bitmask64(16);
                case 1ul << 17: return dividend & maxmath.bitmask64(17);
                case 1ul << 18: return dividend & maxmath.bitmask64(18);
                case 1ul << 19: return dividend & maxmath.bitmask64(19);
                case 1ul << 20: return dividend & maxmath.bitmask64(20);
                case 1ul << 21: return dividend & maxmath.bitmask64(21);
                case 1ul << 22: return dividend & maxmath.bitmask64(22);
                case 1ul << 23: return dividend & maxmath.bitmask64(23);
                case 1ul << 24: return dividend & maxmath.bitmask64(24);
                case 1ul << 25: return dividend & maxmath.bitmask64(25);
                case 1ul << 26: return dividend & maxmath.bitmask64(26);
                case 1ul << 27: return dividend & maxmath.bitmask64(27);
                case 1ul << 28: return dividend & maxmath.bitmask64(28);
                case 1ul << 29: return dividend & maxmath.bitmask64(29);
                case 1ul << 30: return dividend & maxmath.bitmask64(30);
                case 1ul << 31: return dividend & maxmath.bitmask64(31);
                case 1ul << 32: return dividend & maxmath.bitmask64(32);
                case 1ul << 33: return dividend & maxmath.bitmask64(33);
                case 1ul << 34: return dividend & maxmath.bitmask64(34);
                case 1ul << 35: return dividend & maxmath.bitmask64(35);
                case 1ul << 36: return dividend & maxmath.bitmask64(36);
                case 1ul << 37: return dividend & maxmath.bitmask64(37);
                case 1ul << 38: return dividend & maxmath.bitmask64(38);
                case 1ul << 39: return dividend & maxmath.bitmask64(39);
                case 1ul << 40: return dividend & maxmath.bitmask64(40);
                case 1ul << 41: return dividend & maxmath.bitmask64(41);
                case 1ul << 42: return dividend & maxmath.bitmask64(42);
                case 1ul << 43: return dividend & maxmath.bitmask64(43);
                case 1ul << 44: return dividend & maxmath.bitmask64(44);
                case 1ul << 45: return dividend & maxmath.bitmask64(45);
                case 1ul << 46: return dividend & maxmath.bitmask64(46);
                case 1ul << 47: return dividend & maxmath.bitmask64(47);
                case 1ul << 48: return dividend & maxmath.bitmask64(48);
                case 1ul << 49: return dividend & maxmath.bitmask64(49);
                case 1ul << 50: return dividend & maxmath.bitmask64(50);
                case 1ul << 51: return dividend & maxmath.bitmask64(51);
                case 1ul << 52: return dividend & maxmath.bitmask64(52);
                case 1ul << 53: return dividend & maxmath.bitmask64(53);
                case 1ul << 54: return dividend & maxmath.bitmask64(54);
                case 1ul << 55: return dividend & maxmath.bitmask64(55);
                case 1ul << 56: return dividend & maxmath.bitmask64(56);
                case 1ul << 57: return dividend & maxmath.bitmask64(57);
                case 1ul << 58: return dividend & maxmath.bitmask64(58);
                case 1ul << 59: return dividend & maxmath.bitmask64(59);
                case 1ul << 60: return dividend & maxmath.bitmask64(60);
                case 1ul << 61: return dividend & maxmath.bitmask64(61);
                case 1ul << 62: return dividend & maxmath.bitmask64(62);
                case 1ul << 63: return dividend & maxmath.bitmask64(63);

                default: return new ulong4(dividend.x % divisor, 
                                           dividend.y % divisor, 
                                           dividend.z % divisor, 
                                           dividend.w % divisor);
            }
        }
    }
}