using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    // Move to types => operator / % f.i. (uint8 lhs, (ushort)(uint rhs)
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort8 idiv(ushort8 dividend, ushort divisor)
        {
            switch (divisor)
            {
                case 0: throw new DivideByZeroException();
                case 1: return dividend;
                case 1 << 1:  return dividend >> 1;
                case 1 << 2:  return dividend >> 2;
                case 1 << 3:  return dividend >> 3;
                case 1 << 4:  return dividend >> 4;
                case 1 << 5:  return dividend >> 5;
                case 1 << 6:  return dividend >> 6;
                case 1 << 7:  return dividend >> 7;
                case 1 << 8:  return dividend >> 8;
                case 1 << 9:  return dividend >> 9;
                case 1 << 10: return dividend >> 10;
                case 1 << 11: return dividend >> 11;
                case 1 << 12: return dividend >> 12;
                case 1 << 13: return dividend >> 13;
                case 1 << 14: return dividend >> 14;
                case 1 << 15: return dividend >> 15;
                case ushort.MaxValue: return X86.Sse4_1.blendv_epi8(default(v128), new v128(1), X86.Sse2.cmpeq_epi16(dividend, new v128(ushort.MaxValue)));

                case 3: return ushort3(dividend);

                default: return new ushort8((ushort)(dividend.x0 / divisor), 
                                            (ushort)(dividend.x1 / divisor), 
                                            (ushort)(dividend.x2 / divisor), 
                                            (ushort)(dividend.x3 / divisor),
                                            (ushort)(dividend.x4 / divisor),
                                            (ushort)(dividend.x5 / divisor),
                                            (ushort)(dividend.x6 / divisor),
                                            (ushort)(dividend.x7 / divisor));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 ushort3(ushort8 x)
        {
            
            return X86.Sse2.srli_epi16(X86.Sse2.mulhi_epu16(x, new ushort8(43691)), 1);
        }
    }
}