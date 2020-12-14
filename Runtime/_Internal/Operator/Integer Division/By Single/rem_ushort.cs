using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort2 rem(ushort2 dividend, ushort divisor) => (v128)rem((ushort8)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort3 rem(ushort3 dividend, ushort divisor) => (v128)rem((ushort8)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort4 rem(ushort4 dividend, ushort divisor) => (v128)rem((ushort8)(v128)dividend, divisor);

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort8 rem(ushort8 dividend, ushort divisor)
        {
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return 0;
                case ushort.MaxValue: return Sse4_1.blendv_epi8(dividend, default(ushort8), Sse2.cmpeq_epi16(dividend, new ushort8(ushort.MaxValue)));

                case 1 << 1:  return dividend & (ushort)maxmath.bitmask32(1);
                case 1 << 2:  return dividend & (ushort)maxmath.bitmask32(2);
                case 1 << 3:  return dividend & (ushort)maxmath.bitmask32(3);
                case 1 << 4:  return dividend & (ushort)maxmath.bitmask32(4);
                case 1 << 5:  return dividend & (ushort)maxmath.bitmask32(5);
                case 1 << 6:  return dividend & (ushort)maxmath.bitmask32(6);
                case 1 << 7:  return dividend & (ushort)maxmath.bitmask32(7);
                case 1 << 8:  return dividend & (ushort)maxmath.bitmask32(8);
                case 1 << 9:  return dividend & (ushort)maxmath.bitmask32(9);
                case 1 << 10: return dividend & (ushort)maxmath.bitmask32(10);
                case 1 << 11: return dividend & (ushort)maxmath.bitmask32(11);
                case 1 << 12: return dividend & (ushort)maxmath.bitmask32(12);
                case 1 << 13: return dividend & (ushort)maxmath.bitmask32(13);
                case 1 << 14: return dividend & (ushort)maxmath.bitmask32(14);
                case 1 << 15: return dividend & (ushort)maxmath.bitmask32(15);

                default: return new ushort8((ushort)(dividend.x0 % divisor), 
                                            (ushort)(dividend.x1 % divisor), 
                                            (ushort)(dividend.x2 % divisor), 
                                            (ushort)(dividend.x3 % divisor),
                                            (ushort)(dividend.x4 % divisor),
                                            (ushort)(dividend.x5 % divisor),
                                            (ushort)(dividend.x6 % divisor),
                                            (ushort)(dividend.x7 % divisor));
            }
        }

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ushort16 rem(ushort16 dividend, ushort divisor)
        {
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return 0;
                case ushort.MaxValue: return Avx2.mm256_blendv_epi8(dividend, default(ushort16), Avx2.mm256_cmpeq_epi16(dividend, new ushort16(ushort.MaxValue)));

                case 1 << 1:  return dividend & (ushort)maxmath.bitmask32(1);
                case 1 << 2:  return dividend & (ushort)maxmath.bitmask32(2);
                case 1 << 3:  return dividend & (ushort)maxmath.bitmask32(3);
                case 1 << 4:  return dividend & (ushort)maxmath.bitmask32(4);
                case 1 << 5:  return dividend & (ushort)maxmath.bitmask32(5);
                case 1 << 6:  return dividend & (ushort)maxmath.bitmask32(6);
                case 1 << 7:  return dividend & (ushort)maxmath.bitmask32(7);
                case 1 << 8:  return dividend & (ushort)maxmath.bitmask32(8);
                case 1 << 9:  return dividend & (ushort)maxmath.bitmask32(9);
                case 1 << 10: return dividend & (ushort)maxmath.bitmask32(10);
                case 1 << 11: return dividend & (ushort)maxmath.bitmask32(11);
                case 1 << 12: return dividend & (ushort)maxmath.bitmask32(12);
                case 1 << 13: return dividend & (ushort)maxmath.bitmask32(13);
                case 1 << 14: return dividend & (ushort)maxmath.bitmask32(14);
                case 1 << 15: return dividend & (ushort)maxmath.bitmask32(15);

                default: return new ushort16((ushort)(dividend.x0  % divisor), 
                                             (ushort)(dividend.x1  % divisor), 
                                             (ushort)(dividend.x2  % divisor), 
                                             (ushort)(dividend.x3  % divisor),
                                             (ushort)(dividend.x4  % divisor),
                                             (ushort)(dividend.x5  % divisor),
                                             (ushort)(dividend.x6  % divisor),
                                             (ushort)(dividend.x7  % divisor),
                                             (ushort)(dividend.x8  % divisor),
                                             (ushort)(dividend.x9  % divisor),
                                             (ushort)(dividend.x10 % divisor),
                                             (ushort)(dividend.x11 % divisor),
                                             (ushort)(dividend.x12 % divisor),
                                             (ushort)(dividend.x13 % divisor),
                                             (ushort)(dividend.x14 % divisor),
                                             (ushort)(dividend.x15 % divisor));
            }
        }
    }
}