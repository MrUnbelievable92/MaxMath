using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

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
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return dividend;
                case ushort.MaxValue: return Sse4_1.blendv_epi8(default(ushort8), new ushort8(1), Sse2.cmpeq_epi16(dividend, new ushort8(ushort.MaxValue)));

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

                case 10: return div_ushort_10(dividend);
                case 100: return div_ushort_100(dividend);
                case 1000: return div_ushort_1000(dividend);
                case 10000: return div_ushort_10000(dividend);

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
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return dividend;
                case ushort.MaxValue: return Avx2.mm256_blendv_epi8(default(ushort16), new ushort16(1), Avx2.mm256_cmpeq_epi16(dividend, new ushort16(ushort.MaxValue)));

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

                case 10: return div_ushort_10(dividend);
                case 100: return div_ushort_100(dividend);
                case 1000: return div_ushort_1000(dividend);
                case 10000: return div_ushort_10000(dividend);

                default: return dividend / (ushort16)divisor;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 div_ushort_3(ushort8 x)
        {
            return Sse2.srli_epi16(Sse2.mulhi_epu16(x, new ushort8(43691)), 1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_ushort_3(ushort16 x)
        {
            return Avx2.mm256_srli_epi16(Avx2.mm256_mulhi_epu16(x, new ushort16(43691)), 1);
        }


        #region POWERS OF TEN
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 div_ushort_10(ushort8 x)
        {
            return Sse2.srli_epi16(Sse2.mulhi_epu16(x, new ushort8(52429)), 3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_ushort_10(ushort16 x)
        {
            return Avx2.mm256_srli_epi16(Avx2.mm256_mulhi_epu16(x, new ushort16(52429)), 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 div_ushort_100(ushort8 x)
        {
            x = Sse2.srli_epi16(x, 2);

            return Sse2.srli_epi16(Sse2.mulhi_epu16(x, new ushort8(5243)), 1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_ushort_100(ushort16 x)
        {
            x = Avx2.mm256_srli_epi16(x, 2);

            return Avx2.mm256_srli_epi16(Avx2.mm256_mulhi_epu16(x, new ushort16(5243)), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 div_ushort_1000(ushort8 x)
        {
            x = Sse2.srli_epi16(x, 3);

            return Sse2.srli_epi16(Sse2.mulhi_epu16(x, new ushort8(8389)), 4);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_ushort_1000(ushort16 x)
        {
            x = Avx2.mm256_srli_epi16(x, 3);

            return Avx2.mm256_srli_epi16(Avx2.mm256_mulhi_epu16(x, new ushort16(8389)), 4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort8 div_ushort_10000(ushort8 x)
        {
            x = Sse2.srli_epi16(x, 4);

            return Sse2.srli_epi16(Sse2.mulhi_epu16(x, new ushort8(839)), 3);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_ushort_10000(ushort16 x)
        {
            x = Avx2.mm256_srli_epi16(x, 4);

            return Avx2.mm256_srli_epi16(Avx2.mm256_mulhi_epu16(x, new ushort16(839)), 3);
        }
        #endregion
    }
}