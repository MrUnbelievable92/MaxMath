using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ///<summary>        Returns a bitmask representation of a <see cref="bool2"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [return: AssumeRange(0, 0b0000_0011)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(x), 1, 2);

                return 0b0000_0011 & Xse.movemask_epi8(Xse.neg_epi8(RegisterConversion.ToV128(x)));
            }
            else
            {
                return tobyte(x.x) | (tobyte(x.y) << 1);
            }
        }

        ///<summary>        Returns a bitmask representation of a <see cref="bool3"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [return: AssumeRange(0, 0b0000_0111)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(x), 1, 3);

                return 0b0000_0111 & Xse.movemask_epi8(Xse.neg_epi8(RegisterConversion.ToV128(x)));
            }
            else
            {
                return (tobyte(x.x) | (tobyte(x.y) << 1)) + (tobyte(x.z) << 2);
            }
        }

        ///<summary>        Returns a bitmask representation of a <see cref="MaxMath.bool8"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [return: AssumeRange(0, byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(x), 1, 8);

                return (byte)Xse.movemask_epi8(Xse.neg_epi8(x));
            }
            else
            {
                return ((tobyte(x.x0) | (tobyte(x.x1) << 1)) + ((tobyte(x.x2) << 2) | (tobyte(x.x3) << 3))) + (((tobyte(x.x4) << 4) | (tobyte(x.x5) << 5)) + ((tobyte(x.x6) << 6) | (tobyte(x.x7) << 7)));
            }
        }

        ///<summary>        Returns a bitmask representation of a <see cref="MaxMath.bool16"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [return: AssumeRange(0, ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(x), 1, 16);

                return Xse.movemask_epi8(Xse.neg_epi8(x));
            }
            else
            {
                return (((tobyte(x.x0) | (tobyte(x.x1) << 1)) + ((tobyte(x.x2) << 2) | (tobyte(x.x3) << 3))) + (((tobyte(x.x4) << 4) | (tobyte(x.x5) << 5)) + ((tobyte(x.x6) << 6) | (tobyte(x.x7) << 7)))) + ((((tobyte(x.x8) << 8) | (tobyte(x.x9) << 9)) + ((tobyte(x.x10) << 10) | (tobyte(x.x11) << 11))) + (((tobyte(x.x12) << 12) | (tobyte(x.x13) << 13)) + ((tobyte(x.x14) << 14) | (tobyte(x.x15) << 15))));
            }
        }

        ///<summary>        Returns a bitmask representation of a <see cref="MaxMath.bool32"/>. Storing one 1 bit per component in LSB order, from lower to higher bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(x), 1, 32);

                return Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x));
            }
            else
            {
                return bitmask(x.v16_0) | (bitmask(x.v16_16) << 16);
            }
        }
    }
}