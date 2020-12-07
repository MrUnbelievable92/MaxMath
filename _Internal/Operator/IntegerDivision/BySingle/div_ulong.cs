using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong2 div(ulong2 dividend, ulong divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0ul: throw new DivideByZeroException();
#endif          
                case 1ul: return dividend;
                case ulong.MaxValue: return X86.Sse4_1.blendv_epi8(default(ulong2), new ulong2(1ul), X86.Sse4_1.cmpeq_epi64(dividend, new ulong2(ulong.MaxValue)));

                case 1ul << 1:  return dividend >> 1;
                case 1ul << 2:  return dividend >> 2;
                case 1ul << 3:  return dividend >> 3;
                case 1ul << 4:  return dividend >> 4;
                case 1ul << 5:  return dividend >> 5;
                case 1ul << 6:  return dividend >> 6;
                case 1ul << 7:  return dividend >> 7;
                case 1ul << 8:  return dividend >> 8;
                case 1ul << 9:  return dividend >> 9;
                case 1ul << 10: return dividend >> 10;
                case 1ul << 11: return dividend >> 11;
                case 1ul << 12: return dividend >> 12;
                case 1ul << 13: return dividend >> 13;
                case 1ul << 14: return dividend >> 14;
                case 1ul << 15: return dividend >> 15;
                case 1ul << 16: return dividend >> 16;
                case 1ul << 17: return dividend >> 17;
                case 1ul << 18: return dividend >> 18;
                case 1ul << 19: return dividend >> 19;
                case 1ul << 20: return dividend >> 20;
                case 1ul << 21: return dividend >> 21;
                case 1ul << 22: return dividend >> 22;
                case 1ul << 23: return dividend >> 23;
                case 1ul << 24: return dividend >> 24;
                case 1ul << 25: return dividend >> 25;
                case 1ul << 26: return dividend >> 26;
                case 1ul << 27: return dividend >> 27;
                case 1ul << 28: return dividend >> 28;
                case 1ul << 29: return dividend >> 29;
                case 1ul << 30: return dividend >> 30;
                case 1ul << 31: return dividend >> 31;
                case 1ul << 32: return dividend >> 32;
                case 1ul << 33: return dividend >> 33;
                case 1ul << 34: return dividend >> 34;
                case 1ul << 35: return dividend >> 35;
                case 1ul << 36: return dividend >> 36;
                case 1ul << 37: return dividend >> 37;
                case 1ul << 38: return dividend >> 38;
                case 1ul << 39: return dividend >> 39;
                case 1ul << 40: return dividend >> 40;
                case 1ul << 41: return dividend >> 41;
                case 1ul << 42: return dividend >> 42;
                case 1ul << 43: return dividend >> 43;
                case 1ul << 44: return dividend >> 44;
                case 1ul << 45: return dividend >> 45;
                case 1ul << 46: return dividend >> 46;
                case 1ul << 47: return dividend >> 47;
                case 1ul << 48: return dividend >> 48;
                case 1ul << 49: return dividend >> 49;
                case 1ul << 50: return dividend >> 50;
                case 1ul << 51: return dividend >> 51;
                case 1ul << 52: return dividend >> 52;
                case 1ul << 53: return dividend >> 53;
                case 1ul << 54: return dividend >> 54;
                case 1ul << 55: return dividend >> 55;
                case 1ul << 56: return dividend >> 56;
                case 1ul << 57: return dividend >> 57;
                case 1ul << 58: return dividend >> 58;
                case 1ul << 59: return dividend >> 59;
                case 1ul << 60: return dividend >> 60;
                case 1ul << 61: return dividend >> 61;
                case 1ul << 62: return dividend >> 62;
                case 1ul << 63: return dividend >> 63;

                default: return new ulong2(dividend.x / divisor, 
                                           dividend.y / divisor);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong3 div(ulong3 dividend, ulong divisor) => (v256)div((ulong4)(v256)dividend, divisor);

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong4 div(ulong4 dividend, ulong divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0ul: throw new DivideByZeroException();
#endif
                case 1ul: return dividend;
                case ulong.MaxValue: return X86.Avx2.mm256_blendv_epi8(default(ulong4), new ulong4(1ul), X86.Avx2.mm256_cmpeq_epi32(dividend, new ulong4(ulong.MaxValue)));

                case 1ul << 1:  return dividend >> 1;
                case 1ul << 2:  return dividend >> 2;
                case 1ul << 3:  return dividend >> 3;
                case 1ul << 4:  return dividend >> 4;
                case 1ul << 5:  return dividend >> 5;
                case 1ul << 6:  return dividend >> 6;
                case 1ul << 7:  return dividend >> 7;
                case 1ul << 8:  return dividend >> 8;
                case 1ul << 9:  return dividend >> 9;
                case 1ul << 10: return dividend >> 10;
                case 1ul << 11: return dividend >> 11;
                case 1ul << 12: return dividend >> 12;
                case 1ul << 13: return dividend >> 13;
                case 1ul << 14: return dividend >> 14;
                case 1ul << 15: return dividend >> 15;
                case 1ul << 16: return dividend >> 16;
                case 1ul << 17: return dividend >> 17;
                case 1ul << 18: return dividend >> 18;
                case 1ul << 19: return dividend >> 19;
                case 1ul << 20: return dividend >> 20;
                case 1ul << 21: return dividend >> 21;
                case 1ul << 22: return dividend >> 22;
                case 1ul << 23: return dividend >> 23;
                case 1ul << 24: return dividend >> 24;
                case 1ul << 25: return dividend >> 25;
                case 1ul << 26: return dividend >> 26;
                case 1ul << 27: return dividend >> 27;
                case 1ul << 28: return dividend >> 28;
                case 1ul << 29: return dividend >> 29;
                case 1ul << 30: return dividend >> 30;
                case 1ul << 31: return dividend >> 31;
                case 1ul << 32: return dividend >> 32;
                case 1ul << 33: return dividend >> 33;
                case 1ul << 34: return dividend >> 34;
                case 1ul << 35: return dividend >> 35;
                case 1ul << 36: return dividend >> 36;
                case 1ul << 37: return dividend >> 37;
                case 1ul << 38: return dividend >> 38;
                case 1ul << 39: return dividend >> 39;
                case 1ul << 40: return dividend >> 40;
                case 1ul << 41: return dividend >> 41;
                case 1ul << 42: return dividend >> 42;
                case 1ul << 43: return dividend >> 43;
                case 1ul << 44: return dividend >> 44;
                case 1ul << 45: return dividend >> 45;
                case 1ul << 46: return dividend >> 46;
                case 1ul << 47: return dividend >> 47;
                case 1ul << 48: return dividend >> 48;
                case 1ul << 49: return dividend >> 49;
                case 1ul << 50: return dividend >> 50;
                case 1ul << 51: return dividend >> 51;
                case 1ul << 52: return dividend >> 52;
                case 1ul << 53: return dividend >> 53;
                case 1ul << 54: return dividend >> 54;
                case 1ul << 55: return dividend >> 55;
                case 1ul << 56: return dividend >> 56;
                case 1ul << 57: return dividend >> 57;
                case 1ul << 58: return dividend >> 58;
                case 1ul << 59: return dividend >> 59;
                case 1ul << 60: return dividend >> 60;
                case 1ul << 61: return dividend >> 61;
                case 1ul << 62: return dividend >> 62;
                case 1ul << 63: return dividend >> 63;

                default: return new ulong4(dividend.x / divisor, 
                                           dividend.y / divisor, 
                                           dividend.z / divisor, 
                                           dividend.w / divisor);
            }
        }
    }
}