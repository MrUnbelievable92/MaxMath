using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte2 rem(byte2 dividend, byte divisor) => (v128)rem((byte16)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte3 rem(byte3 dividend, byte divisor) => (v128)rem((byte16)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte4 rem(byte4 dividend, byte divisor) => (v128)rem((byte16)(v128)dividend, divisor);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 rem(byte8 dividend, byte divisor) => (v128)rem((byte16)(v128)dividend, divisor);

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte16 rem(byte16 dividend, byte divisor)
        {
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return 0;
                case byte.MaxValue: return Sse4_1.blendv_epi8(dividend, default(byte16), Sse2.cmpeq_epi8(dividend, new byte16(byte.MaxValue)));

                case 1 << 1: return dividend & (byte)maxmath.bitmask32(1);
                case 1 << 2: return dividend & (byte)maxmath.bitmask32(2);
                case 1 << 3: return dividend & (byte)maxmath.bitmask32(3);
                case 1 << 4: return dividend & (byte)maxmath.bitmask32(4);
                case 1 << 5: return dividend & (byte)maxmath.bitmask32(5);
                case 1 << 6: return dividend & (byte)maxmath.bitmask32(6);
                case 1 << 7: return dividend & (byte)maxmath.bitmask32(7);

                case 10: return dividend - (byte16)rem_byte_10_base(dividend);
                case 100: return dividend - (byte16)rem_byte_100_base(dividend);

                default: return dividend % new byte16(divisor);
            }
        }

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 rem(byte32 dividend, byte divisor)
        {
Assert.AreNotEqual(divisor, 0);

            switch (divisor)
            {
                case 1: return 0;
                case byte.MaxValue: return Avx2.mm256_blendv_epi8(dividend, default(byte32), Avx2.mm256_cmpeq_epi8(dividend, new byte32(byte.MaxValue)));

                case 1 << 1: return dividend & (byte)maxmath.bitmask32(1);
                case 1 << 2: return dividend & (byte)maxmath.bitmask32(2);
                case 1 << 3: return dividend & (byte)maxmath.bitmask32(3);
                case 1 << 4: return dividend & (byte)maxmath.bitmask32(4);
                case 1 << 5: return dividend & (byte)maxmath.bitmask32(5);
                case 1 << 6: return dividend & (byte)maxmath.bitmask32(6);
                case 1 << 7: return dividend & (byte)maxmath.bitmask32(7);

                case 10: return dividend - rem_byte_10(dividend);
                case 100: return dividend - rem_byte_100(dividend);

                default: return dividend % new byte32(divisor);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 rem_byte_10_base(byte16 x)
        {
            ushort16 temp = new ushort16(205) * (ushort16)x;
            temp >>= 10;
            temp &= (ushort)maxmath.bitmask32(31, 1);

            return temp + (temp << 2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte32 rem_byte_10(byte32 x)
        {
            return X86.Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(rem_byte_10_base(x.v16_0),
                                                                            rem_byte_10_base(x.v16_16)),
                                                        Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort16 rem_byte_100_base(byte16 x)
        {
            ushort16 cast = (ushort16)x;

            ushort16 intermediate = cast + (cast << 2);
            intermediate = cast + (intermediate << 3);
            intermediate = 100 * (intermediate >> 12);

            return intermediate;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte32 rem_byte_100(byte32 x)
        {
            return X86.Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(rem_byte_100_base(x.v16_0),
                                                                            rem_byte_100_base(x.v16_16)),
                                                    Sse.SHUFFLE(3, 1, 2, 0));
        }
    }
}