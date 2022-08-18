using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ///<summary>        Returns a bitmask representation of a <see cref="MaxMath.bool8"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [return: AssumeRange(0, byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int bitmask(bool8 x)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

                return (byte)Sse2.movemask_epi8(Xse.neg_epi8(x));
            }
            else
            {
                return ((toint(x.x0) | (tosbyte(x.x1) << 1)) + ((tosbyte(x.x2) << 2) | (tosbyte(x.x3) << 3))) + (((tosbyte(x.x4) << 4) | (tosbyte(x.x5) << 5)) + ((tosbyte(x.x6) << 6) | (tosbyte(x.x7) << 7)));
            }
        }

        ///<summary>        Returns a bitmask representation of a <see cref="MaxMath.bool16"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [return: AssumeRange(0, ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static int bitmask(bool16 x)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

                return Sse2.movemask_epi8(Xse.neg_epi8(x));
            }
            else
            {
                return (((toint(x.x0) | (tosbyte(x.x1) << 1)) + ((tosbyte(x.x2) << 2) | (tosbyte(x.x3) << 3))) + (((tosbyte(x.x4) << 4) | (tosbyte(x.x5) << 5)) + ((tosbyte(x.x6) << 6) | (tosbyte(x.x7) << 7)))) + ((((tosbyte(x.x8) << 8) | (tosbyte(x.x9) << 9)) + ((tosbyte(x.x10) << 10) | (tosbyte(x.x11) << 11))) + (((tosbyte(x.x12) << 12) | (tosbyte(x.x13) << 13)) + ((tosbyte(x.x14) << 14) | (tosbyte(x.x15) << 15))));
            }
        }

        ///<summary>        Returns a bitmask representation of a <see cref="MaxMath.bool32"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);
Assert.IsSafeBoolean(x.x16);
Assert.IsSafeBoolean(x.x17);
Assert.IsSafeBoolean(x.x18);
Assert.IsSafeBoolean(x.x19);
Assert.IsSafeBoolean(x.x20);
Assert.IsSafeBoolean(x.x21);
Assert.IsSafeBoolean(x.x22);
Assert.IsSafeBoolean(x.x23);
Assert.IsSafeBoolean(x.x24);
Assert.IsSafeBoolean(x.x25);
Assert.IsSafeBoolean(x.x26);
Assert.IsSafeBoolean(x.x27);
Assert.IsSafeBoolean(x.x28);
Assert.IsSafeBoolean(x.x29);
Assert.IsSafeBoolean(x.x31);
Assert.IsSafeBoolean(x.x30);

                return Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x));
            }
            else
            {
                return bitmask(x.v16_0) | (bitmask(x.v16_16) << 16);
            }
        }
    }
}