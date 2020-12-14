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

                case 10: return rem_byte_10(dividend);
                case 100: return rem_byte_100(dividend);

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

                case 10: return rem_byte_10(dividend);
                case 100: return rem_byte_100(dividend);


                default: return dividend % new byte32(divisor);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte16 rem_byte_10(byte16 x)
        {
            ushort16 temp = new ushort16(205) * (ushort16)x;
            temp >>= 10;
            temp &= (ushort)maxmath.bitmask32(31, 1);

            return x - (byte16)(temp + (temp << 2));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte32 rem_byte_10(byte32 x)
        {
            ushort16 magic = 205;
            ushort16 mask = (ushort)maxmath.bitmask32(31, 1);


            ushort16 lo = magic * (ushort16)x.v16_0;
            ushort16 hi = magic * (ushort16)x.v16_16;

            lo >>= 10;
            hi >>= 10;

            lo &= mask;
            hi &= mask;

            lo += lo << 2;
            hi += hi << 2;

            return x - X86.Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(lo, hi),
                                                        Sse.SHUFFLE(3, 1, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte16 rem_byte_100(byte16 x)
        {
            ushort16 cast = (ushort16)x;

            ushort16 intermediate = cast + (cast << 2);
            intermediate = cast + (intermediate << 3);
            intermediate = 100 * (intermediate >> 12);

            return x - (byte16)intermediate;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte32 rem_byte_100(byte32 x)
        {
            ushort16 lo = (ushort16)x.v16_0;
            ushort16 hi = (ushort16)x.v16_16;

            ushort16 intermediate_Lo = lo + (lo << 2);
            ushort16 intermediate_Hi = lo + (lo << 2);

            intermediate_Lo = lo + (intermediate_Lo << 3);
            intermediate_Hi = hi + (intermediate_Hi << 3);

            intermediate_Lo = 100 * (intermediate_Lo >> 12);
            intermediate_Hi = 100 * (intermediate_Hi >> 12);

            return x - X86.Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(intermediate_Lo, intermediate_Hi),
                                                        Sse.SHUFFLE(3, 1, 2, 0));
        }
    }
}