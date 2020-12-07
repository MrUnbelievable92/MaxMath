using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort2 div(ushort2 dividend, ushort divisor) => (v128)div((ushort8)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort3 div(ushort3 dividend, ushort divisor) => (v128)div((ushort8)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort4 div(ushort4 dividend, ushort divisor) => (v128)div((ushort8)(v128)dividend, divisor);

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort8 div(ushort8 dividend, ushort divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0: throw new DivideByZeroException();
#endif
                case 1: return dividend;
                case ushort.MaxValue: return X86.Sse4_1.blendv_epi8(default(ushort8), new ushort8(1), X86.Sse2.cmpeq_epi16(dividend, new ushort8(ushort.MaxValue)));

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

                case 3: return div_ushort_3(dividend);

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

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort16 div(ushort16 dividend, ushort divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0: throw new DivideByZeroException();
#endif
                case 1: return dividend;
                case ushort.MaxValue: return X86.Avx2.mm256_blendv_epi8(default(ushort16), new ushort16(1), X86.Avx2.mm256_cmpeq_epi16(dividend, new ushort16(ushort.MaxValue)));

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

                default: return new ushort16((ushort)(dividend.x0  / divisor), 
                                             (ushort)(dividend.x1  / divisor), 
                                             (ushort)(dividend.x2  / divisor), 
                                             (ushort)(dividend.x3  / divisor),
                                             (ushort)(dividend.x4  / divisor),
                                             (ushort)(dividend.x5  / divisor),
                                             (ushort)(dividend.x6  / divisor),
                                             (ushort)(dividend.x7  / divisor),
                                             (ushort)(dividend.x8  / divisor),
                                             (ushort)(dividend.x9  / divisor),
                                             (ushort)(dividend.x10 / divisor),
                                             (ushort)(dividend.x11 / divisor),
                                             (ushort)(dividend.x12 / divisor),
                                             (ushort)(dividend.x13 / divisor),
                                             (ushort)(dividend.x14 / divisor),
                                             (ushort)(dividend.x15 / divisor));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 div_ushort_3(ushort8 x)
        {
            return X86.Sse2.srli_epi16(X86.Sse2.mulhi_epu16(x, new ushort8(43691)), 1);
        }
    }
}