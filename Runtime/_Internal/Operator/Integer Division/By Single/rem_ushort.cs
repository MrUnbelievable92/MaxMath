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

                case 10: return (ushort8)rem_ushort8_10_base(dividend);
                case 100: return (ushort8)rem_ushort8_100_base(dividend);
                case 1000: return (ushort8)rem_ushort8_1000_base(dividend);
                case 10000: return (ushort8)rem_ushort8_10000_base(dividend);

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

                case 10: return rem_ushort16_10(dividend);
                case 100: return rem_ushort16_100(dividend);
                case 1000: return rem_ushort16_1000(dividend);
                case 10000: return rem_ushort16_10000(dividend);

                default: return dividend % (ushort16)divisor;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint8 rem_ushort8_10_base(ushort8 x)
        {
            uint8 cast = (uint8)x;

            uint8 temp = 52429 * cast;
            temp >>= 18;
            temp &= maxmath.bitmask32(31, 1);
            temp += temp << 2;

            return cast - temp;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 rem_ushort16_10(ushort16 x)
        {
            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi32(rem_ushort8_10_base(x.v8_0),
                                                                        rem_ushort8_10_base(x.v8_8)),
                                                Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint8 rem_ushort8_100_base(ushort8 x)
        {
            uint8 cast = (uint8)x;

            uint8 temp = 5243 * (cast >> 2);
            temp = 100 * (temp >> 17);

            return cast - temp;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 rem_ushort16_100(ushort16 x)
        {
            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi32(rem_ushort8_100_base(x.v8_0),
                                                                        rem_ushort8_100_base(x.v8_8)),
                                                Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint8 rem_ushort8_1000_base(ushort8 x)
        {
            uint8 cast = (uint8)x;

            uint8 temp = 8389 * (cast >> 3);
            temp = 1000 * (temp >> 20);

            return cast - temp;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 rem_ushort16_1000(ushort16 x)
        {
            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi32(rem_ushort8_1000_base(x.v8_0),
                                                                        rem_ushort8_1000_base(x.v8_8)),
                                                Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint8 rem_ushort8_10000_base(ushort8 x)
        {
            uint8 cast = (uint8)x;

            uint8 temp = 839 * (cast >> 4);
            temp = 10000 * (temp >> 19);

            return cast - temp;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 rem_ushort16_10000(ushort16 x)
        {
            return Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi32(rem_ushort8_10000_base(x.v8_0),
                                                                        rem_ushort8_10000_base(x.v8_8)),
                                                Sse.SHUFFLE(3, 1, 2, 0));
        }
    }
}