using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 div(byte2 dividend, byte divisor) => (v128)div((byte16)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 div(byte3 dividend, byte divisor) => (v128)div((byte16)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 div(byte4 dividend, byte divisor) => (v128)div((byte16)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 div(byte8 dividend, byte divisor) => (v128)div((byte16)(v128)dividend, divisor);

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 div(byte16 dividend, byte divisor)
        {
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return dividend;
                case byte.MaxValue: return Sse4_1.blendv_epi8(default(byte16), new byte16(1), Sse2.cmpeq_epi8(dividend, new byte16(byte.MaxValue)));

                case 1 << 1: return dividend >> 1;
                case 1 << 2: return dividend >> 2;
                case 1 << 3: return dividend >> 3;
                case 1 << 4: return dividend >> 4;
                case 1 << 5: return dividend >> 5;
                case 1 << 6: return dividend >> 6;
                case 1 << 7: return dividend >> 7;

                case 10: return (byte16)div_byte_10_base(dividend);
                case 100: return (byte16)div_byte_100_base(dividend);

                default: return dividend / (byte16)divisor;
            }
        }

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 div(byte32 dividend, byte divisor)
        {
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return dividend;
                case byte.MaxValue: return Avx2.mm256_blendv_epi8(default(byte32), new byte32(1), Avx2.mm256_cmpeq_epi8(dividend, new byte32(byte.MaxValue)));

                case 1 << 1: return dividend >> 1;
                case 1 << 2: return dividend >> 2;
                case 1 << 3: return dividend >> 3;
                case 1 << 4: return dividend >> 4;
                case 1 << 5: return dividend >> 5;
                case 1 << 6: return dividend >> 6;
                case 1 << 7: return dividend >> 7;

                case 10: return div_byte_10(dividend);
                case 100: return div_byte_100(dividend);

                default: return dividend / (byte32)divisor;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_byte_10_base(byte16 x)
        {
            ushort16 temp = new ushort16(205) * (ushort16)x;

            return temp >> 11;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte32 div_byte_10(byte32 x)
        {
            return X86.Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(div_byte_10_base(x.v16_0), 
                                                                            div_byte_10_base(x.v16_16)),
                                                    Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 div_byte_100_base(byte16 x)
        {
            ushort16 temp = x;

            ushort16 tempProd = temp + (temp << 2);
            tempProd = temp + (tempProd << 3);

            return tempProd >> 12;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte32 div_byte_100(byte32 x)
        {
            return X86.Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(div_byte_100_base(x.v16_0),
                                                                            div_byte_100_base(x.v16_16)),
                                                    Sse.SHUFFLE(3, 1, 2, 0));
        }
    }
}