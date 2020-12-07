using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

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
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0: throw new DivideByZeroException();
#endif
                case 1: return dividend;
                case byte.MaxValue: return X86.Sse4_1.blendv_epi8(default(byte16), new byte16(1), X86.Sse2.cmpeq_epi8(dividend, new byte16(byte.MaxValue)));

                case 1 << 1:  return dividend >> 1;
                case 1 << 2:  return dividend >> 2;
                case 1 << 3:  return dividend >> 3;
                case 1 << 4:  return dividend >> 4;
                case 1 << 5:  return dividend >> 5;
                case 1 << 6:  return dividend >> 6;
                case 1 << 7:  return dividend >> 7;
                
                default: return dividend / (byte16)divisor;
            }
        }

        // NOPE! Gets inlined if divisor is a constant, else its a function call (otherwise code size is going to be enormous)
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte32 div(byte32 dividend, byte divisor)
        {
            switch (divisor)
            {
#if UNITY_EDITOR
                case 0: throw new DivideByZeroException();
#endif
                case 1: return dividend;
                case byte.MaxValue: return X86.Avx2.mm256_blendv_epi8(default(byte32), new byte32(1), X86.Avx2.mm256_cmpeq_epi8(dividend, new byte32(byte.MaxValue)));

                case 1 << 1:  return dividend >> 1;
                case 1 << 2:  return dividend >> 2;
                case 1 << 3:  return dividend >> 3;
                case 1 << 4:  return dividend >> 4;
                case 1 << 5:  return dividend >> 5;
                case 1 << 6:  return dividend >> 6;
                case 1 << 7:  return dividend >> 7;

                default: return dividend / (byte32)divisor;
            }
        }
    }
}