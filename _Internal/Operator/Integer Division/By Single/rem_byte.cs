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
                

                default: return dividend % new byte32(divisor);
            }
        }
    }
}