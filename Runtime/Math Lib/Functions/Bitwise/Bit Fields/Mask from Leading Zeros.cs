using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzmsk_epi8(v128 a)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    v128 SHUFFLE_MASK_LO = new v128(0b1111_1111, 0b1111_1110, 0b1111_1100, 0b1111_1100, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000);
                    v128 SHUFFLE_MASK_HI = new v128(0b1111_1111, 0b1110_0000, 0b1100_0000, 0b1100_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000);

                    return min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                    shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return sllv_epi8(setall_si128(), sub_epi8(set1_epi8(8), lzcnt_epi8(a)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzmsk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 BLEND_MASK = set1_epi16(0xFF00);
                    v128 byteMasks = lzmsk_epi8(a);
                    v128 low = and_si128(byteMasks, srli_epi16(cmpeq_epi8(byteMasks, BLEND_MASK), 8));

                    if (BurstArchitecture.IsBlendSupported)
                    {
                        return blendv_si128(low, byteMasks, BLEND_MASK);
                    }
                    else
                    {
                        return or_si128(low, and_si128(BLEND_MASK, byteMasks));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzmsk_epi32(v128 a)
            {
                if (BurstArchitecture.IsVectorShiftSupported)
                {
                    return sllv_epi32(setall_si128(), sub_epi32(set1_epi32(32), lzcnt_epi32(a)));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 BLEND_MASK = set1_epi32(0xFFFF_0000);
                    v128 shortMasks = lzmsk_epi16(a);
                    v128 low = and_si128(shortMasks, srli_epi32(cmpeq_epi16(shortMasks, BLEND_MASK), 16));

                    if (BurstArchitecture.IsBlendSupported)
                    {
                        return blend_epi16(low, shortMasks, 0b1010_1010);
                    }
                    else
                    {
                        return or_si128(low, and_si128(BLEND_MASK, shortMasks));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzmsk_epi64(v128 a)
            {
                if (BurstArchitecture.IsVectorShiftSupported)
                {
                    return sllv_epi64(setall_si128(), sub_epi64(set1_epi64x(64), lzcnt_epi64(a)));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    long lo = maxmath.lzmask(cvtsi128_si64x(a));
                    long hi = maxmath.lzmask(cvtsi128_si64x(bsrli_si128(a, sizeof(long))));

                    return unpacklo_epi64(cvtsi64x_si128(lo), cvtsi64x_si128(hi));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(0b1111_1111, 0b1111_1110, 0b1111_1100, 0b1111_1100, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000,
                                                    0b1111_1111, 0b1111_1110, 0b1111_1100, 0b1111_1100, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000);
                    v256 SHUFFLE_MASK_HI = new v256(0b1111_1111, 0b1110_0000, 0b1100_0000, 0b1100_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000,
                                                    0b1111_1111, 0b1110_0000, 0b1100_0000, 0b1100_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000);

                    return Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                               Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 BLEND_MASK = mm256_set1_epi16(0xFF00);
                    v256 byteMasks = mm256_lzmsk_epi8(a);
                    v256 low = Avx2.mm256_and_si256(byteMasks, Avx2.mm256_srli_epi16(Avx2.mm256_cmpeq_epi8(byteMasks, BLEND_MASK), 8));

                    return mm256_blendv_si256(low, byteMasks, BLEND_MASK);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_sllv_epi32(mm256_setall_si256(), Avx2.mm256_sub_epi32(mm256_set1_epi32(32), mm256_lzcnt_epi32(a)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_sllv_epi64(mm256_setall_si256(), Avx2.mm256_sub_epi64(mm256_set1_epi64x(64), mm256_lzcnt_epi64(a)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lzmask(UInt128 x)
        {
            int __lzcnt = lzcnt(x);

            return __lzcnt == 0 ? 0 : UInt128.MaxValue << (128 - __lzcnt);
        }

        /// <summary>       Sets all the leading zeros in the binary representation of an <see cref="Int128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 lzmask(Int128 x)
        {
            return (Int128)lzmask((UInt128)x);
        }


        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="byte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte lzmask(byte x)
        {
            return (byte)(byte.MaxValue << (8 - lzcnt(x)));
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lzmask(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi8(x);
            }
            else
            {
                return new byte2(lzmask(x.x), lzmask(x.y));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lzmask(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi8(x);
            }
            else
            {
                return new byte3(lzmask(x.x), lzmask(x.y), lzmask(x.z));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lzmask(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi8(x);
            }
            else
            {
                return new byte4(lzmask(x.x), lzmask(x.y), lzmask(x.z), lzmask(x.w));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lzmask(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi8(x);
            }
            else
            {
                return new byte8(lzmask(x.x0), lzmask(x.x1), lzmask(x.x2), lzmask(x.x3), lzmask(x.x4), lzmask(x.x5), lzmask(x.x6), lzmask(x.x7));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lzmask(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi8(x);
            }
            else
            {
                return new byte16(lzmask(x.x0), lzmask(x.x1), lzmask(x.x2), lzmask(x.x3), lzmask(x.x4), lzmask(x.x5), lzmask(x.x6), lzmask(x.x7), lzmask(x.x8), lzmask(x.x9), lzmask(x.x10), lzmask(x.x11), lzmask(x.x12), lzmask(x.x13), lzmask(x.x14), lzmask(x.x15));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.byte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lzmask(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzmsk_epi8(x);
            }
            else
            {
                return new byte32(lzmask(x.v16_0), lzmask(x.v16_16));
            }
        }


        /// <summary>       Sets all the leading zeros in the binary representation of an <see cref="sbyte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte lzmask(sbyte x)
        {
            return (sbyte)lzmask((byte)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 lzmask(sbyte2 x)
        {
            return (sbyte2)lzmask((byte2)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.sbyte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 lzmask(sbyte3 x)
        {
            return (sbyte3)lzmask((byte3)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 lzmask(sbyte4 x)
        {
            return (sbyte4)lzmask((byte4)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 lzmask(sbyte8 x)
        {
            return (sbyte8)lzmask((byte8)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 lzmask(sbyte16 x)
        {
            return (sbyte16)lzmask((byte16)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 lzmask(sbyte32 x)
        {
            return (sbyte32)lzmask((byte32)x);
        }


        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort lzmask(ushort x)
        {
            return (ushort)(ushort.MaxValue << (16 - lzcnt(x)));
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lzmask(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi16(x);
            }
            else
            {
                return new ushort2(lzmask(x.x), lzmask(x.y));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lzmask(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi16(x);
            }
            else
            {
                return new ushort3(lzmask(x.x), lzmask(x.y), lzmask(x.z));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lzmask(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi16(x);
            }
            else
            {
                return new ushort4(lzmask(x.x), lzmask(x.y), lzmask(x.z), lzmask(x.w));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lzmask(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi16(x);
            }
            else
            {
                return new ushort8(lzmask(x.x0), lzmask(x.x1), lzmask(x.x2), lzmask(x.x3), lzmask(x.x4), lzmask(x.x5), lzmask(x.x6), lzmask(x.x7));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ushort16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lzmask(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzmsk_epi16(x);
            }
            else
            {
                return new ushort16(lzmask(x.v8_0), lzmask(x.v8_8));
            }
        }


        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="short"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short lzmask(short x)
        {
            return (short)lzmask((ushort)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 lzmask(short2 x)
        {
            return (short2)lzmask((ushort2)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 lzmask(short3 x)
        {
            return (short3)lzmask((ushort3)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 lzmask(short4 x)
        {
            return (short4)lzmask((ushort4)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 lzmask(short8 x)
        {
            return (short8)lzmask((ushort8)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 lzmask(short16 x)
        {
            return (short16)lzmask((ushort16)x);
        }


        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lzmask(uint x)
        {
            return (uint)((ulong)uint.MaxValue << (32 - math.lzcnt(x)));
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lzmask(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.lzmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(lzmask(x.x), lzmask(x.y));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="uint3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lzmask(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.lzmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(lzmask(x.x), lzmask(x.y), lzmask(x.z));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="uint4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lzmask(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.lzmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(lzmask(x.x), lzmask(x.y), lzmask(x.z), lzmask(x.w));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.uint8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lzmask(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzmsk_epi32(x);
            }
            else
            {
                return new uint8(lzmask(x.v4_0), lzmask(x.v4_4));
            }
        }


        /// <summary>       Sets all the leading zeros in the binary representation of an <see cref="int"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lzmask(int x)
        {
            return (int)lzmask((uint)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="int2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 lzmask(int2 x)
        {
            return (int2)lzmask((uint2)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="int3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 lzmask(int3 x)
        {
            return (int3)lzmask((uint3)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="int4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 lzmask(int4 x)
        {
            return (int4)lzmask((uint4)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 lzmask(int8 x)
        {
            return (int8)lzmask((uint8)x);
        }


        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lzmask(ulong x)
        {
            return (ulong)((UInt128)ulong.MaxValue << (64 - math.lzcnt(x)));
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lzmask(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzmsk_epi64(x);
            }
            else
            {
                return new ulong2(lzmask(x.x), lzmask(x.y));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ulong3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lzmask(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzmsk_epi64(x);
            }
            else
            {
                return new ulong3(lzmask(x.xy), lzmask(x.z));
            }
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.ulong4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lzmask(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzmsk_epi64(x);
            }
            else
            {
                return new ulong4(lzmask(x.xy), lzmask(x.zw));
            }
        }


        /// <summary>       Sets all the leading zeros in the binary representation of a <see cref="long"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long lzmask(long x)
        {
            return (long)lzmask((ulong)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 lzmask(long2 x)
        {
            return (long2)lzmask((ulong2)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 lzmask(long3 x)
        {
            return (long3)lzmask((ulong3)x);
        }

        /// <summary>       Sets all the leading zeros in the binary representations of each <see cref="MaxMath.long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 lzmask(long4 x)
        {
            return (long4)lzmask((ulong4)x);
        }
    }
}
