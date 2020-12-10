using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint8 rem(uint8 dividend, uint divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0u: throw new DivideByZeroException();
#endif
                case 1u: return 0;
                case uint.MaxValue: return Avx2.mm256_blendv_epi8(dividend, default(uint8), Avx2.mm256_cmpeq_epi32(dividend, new uint8(uint.MaxValue)));

                case 1u << 1:  return dividend & maxmath.bitmask32(1);
                case 1u << 2:  return dividend & maxmath.bitmask32(2);
                case 1u << 3:  return dividend & maxmath.bitmask32(3);
                case 1u << 4:  return dividend & maxmath.bitmask32(4);
                case 1u << 5:  return dividend & maxmath.bitmask32(5);
                case 1u << 6:  return dividend & maxmath.bitmask32(6);
                case 1u << 7:  return dividend & maxmath.bitmask32(7);
                case 1u << 8:  return dividend & maxmath.bitmask32(8);
                case 1u << 9:  return dividend & maxmath.bitmask32(9);
                case 1u << 10: return dividend & maxmath.bitmask32(10);
                case 1u << 11: return dividend & maxmath.bitmask32(11);
                case 1u << 12: return dividend & maxmath.bitmask32(12);
                case 1u << 13: return dividend & maxmath.bitmask32(13);
                case 1u << 14: return dividend & maxmath.bitmask32(14);
                case 1u << 15: return dividend & maxmath.bitmask32(15);
                case 1u << 16: return dividend & maxmath.bitmask32(16);
                case 1u << 17: return dividend & maxmath.bitmask32(17);
                case 1u << 18: return dividend & maxmath.bitmask32(18);
                case 1u << 19: return dividend & maxmath.bitmask32(19);
                case 1u << 20: return dividend & maxmath.bitmask32(20);
                case 1u << 21: return dividend & maxmath.bitmask32(21);
                case 1u << 22: return dividend & maxmath.bitmask32(22);
                case 1u << 23: return dividend & maxmath.bitmask32(23);
                case 1u << 24: return dividend & maxmath.bitmask32(24);
                case 1u << 25: return dividend & maxmath.bitmask32(25);
                case 1u << 26: return dividend & maxmath.bitmask32(26);
                case 1u << 27: return dividend & maxmath.bitmask32(27);
                case 1u << 28: return dividend & maxmath.bitmask32(28);
                case 1u << 29: return dividend & maxmath.bitmask32(29);
                case 1u << 30: return dividend & maxmath.bitmask32(30);
                case 1u << 31: return dividend & maxmath.bitmask32(31);

                default: return new uint8(dividend.x0 % divisor, 
                                          dividend.x1 % divisor, 
                                          dividend.x2 % divisor, 
                                          dividend.x3 % divisor, 
                                          dividend.x4 % divisor, 
                                          dividend.x5 % divisor, 
                                          dividend.x6 % divisor, 
                                          dividend.x7 % divisor);
            }
        }
    }
}