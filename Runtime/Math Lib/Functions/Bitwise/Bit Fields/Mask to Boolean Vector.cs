using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a <see cref="bool2"/> from the first two bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool2(int mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(Xse.broadcastmask_epi8(mask, MaskType.One, 2));
            }
            else
            {
                mask &= 0b0011;

                int result = 0x0101 & (mask | (mask << 7));

                return *(bool2*)&result;
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> from the first 3 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool3(int mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(Xse.broadcastmask_epi8(mask, MaskType.One, 3));
            }
            else
            {
                return tobool(1 & new byte3((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2)));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> from the first 4 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool4(int mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(Xse.broadcastmask_epi8(mask, MaskType.One, 4));
            }
            else
            {
                return tobool(1 & new byte4((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3)));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> from the first 8 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool8(int mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.broadcastmask_epi8(mask, MaskType.One, 8);
            }
            else
            {
                return tobool(1 & new byte8((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7)));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> from the first 16 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool16(int mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.broadcastmask_epi8(mask, MaskType.One, 16);
            }
            else
            {
                return tobool(1 & new byte16((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7), (byte)(mask >> 8), (byte)(mask >> 9), (byte)(mask >> 10), (byte)(mask >> 11), (byte)(mask >> 12), (byte)(mask >> 13), (byte)(mask >> 14), (byte)(mask >> 15)));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> from the bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool32(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_broadcastmask_epi8(mask, MaskType.One);
            }
            else
            {
                return new bool32(tobool16(mask), tobool16((int)(uint)(mask >> 16)));
            }
        }
    }
}