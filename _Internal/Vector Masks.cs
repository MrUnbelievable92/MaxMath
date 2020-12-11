using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    internal static class Mask
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte2 V2FromInt(int imm8)
        {
            return new sbyte2((sbyte)((imm8 << 31) >> 31), (sbyte)((imm8 << 30) >> 31));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte3 V3FromInt(int imm8)
        {
            return maxmath.signextend((sbyte3)maxmath.shr_l(new int3(imm8), new int3(0, 1, 2)), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte4 V4FromInt(int imm8)
        {
            return maxmath.signextend((sbyte4)maxmath.shr_l(new int4(imm8), new int4(0, 1, 2, 3)), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 V8FromInt(int imm8)
        {
            return maxmath.signextend((sbyte8)maxmath.shr_l(new int8(imm8), new int8(0, 1, 2, 3, 4, 5, 6, 7)), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 V16FromInt(int imm8)
        {
            int8 broadcast = imm8;

            sbyte8 maskLo = (sbyte8)maxmath.shr_l(broadcast, new int8(0, 1, 2,  3,  4,  5,  6,  7));
            sbyte8 maskHi = (sbyte8)maxmath.shr_l(broadcast, new int8(8, 9, 10, 11, 12, 13, 14, 15));

            return maxmath.signextend(new sbyte16(maskLo, maskHi), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 V32FromInt(int imm8)
        {
            int8 broadcast = imm8;

            sbyte16 maskLo = new sbyte16((sbyte8)maxmath.shr_l(broadcast, new int8(0,  1,  2,  3,  4,  5,  6,  7)),
                                         (sbyte8)maxmath.shr_l(broadcast, new int8(8,  9,  10, 11, 12, 13, 14, 15)));
            sbyte16 maskHi = new sbyte16((sbyte8)maxmath.shr_l(broadcast, new int8(16, 17, 18, 19, 20, 21, 22, 23)),
                                         (sbyte8)maxmath.shr_l(broadcast, new int8(24, 25, 26, 27, 28, 29, 30, 31)));

            return maxmath.signextend(new sbyte32(maskLo, maskHi), 1);
        }










        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 FromBool(bool2 v)
        {
            return maxmath.signextend(maxmath.cvt_int16(v), 1);
        }
    }
}
