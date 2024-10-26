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
            public static v128 l1msk_epi8(v128 a)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    v128 SHUFFLE_MASK_LO = new v128(0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1100, 0b1111_1100, 0b1111_1110, 0b1111_1111);
                    v128 SHUFFLE_MASK_HI = new v128(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1100_0000, 0b1100_0000, 0b1110_0000, 0b1111_1111);

                    return min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                    shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    return sllv_epi8(setall_si128(), sub_epi8(set1_epi8(8), l1cnt_epi8(a)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1msk_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 BLEND_MASK = set1_epi16(0xFF00);
                    v128 byteMasks = l1msk_epi8(a);
                    v128 low = and_si128(byteMasks, srli_epi16(cmpeq_epi8(byteMasks, BLEND_MASK), 8));

                    if (Architecture.IsBlendSupported)
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
            public static v128 l1msk_epi32(v128 a)
            {
                if (Architecture.IsVectorShiftSupported)
                {
                    return sllv_epi32(setall_si128(), sub_epi32(set1_epi32(32), l1cnt_epi32(a)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 BLEND_MASK = set1_epi32(0xFFFF_0000);
                    v128 shortMasks = l1msk_epi16(a);
                    v128 low = and_si128(shortMasks, srli_epi32(cmpeq_epi16(shortMasks, BLEND_MASK), 16));

                    if (Architecture.IsBlendSupported)
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
            public static v128 l1msk_epi64(v128 a)
            {
                if (Architecture.IsVectorShiftSupported)
                {
                    return sllv_epi64(setall_si128(), sub_epi64(set1_epi64x(64), l1cnt_epi64(a)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    long lo = maxmath.l1mask(cvtsi128_si64x(a));
                    long hi = maxmath.l1mask(cvtsi128_si64x(bsrli_si128(a, sizeof(long))));

                    return unpacklo_epi64(cvtsi64x_si128(lo), cvtsi64x_si128(hi));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1100, 0b1111_1100, 0b1111_1110, 0b1111_1111,
                                                    0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1100, 0b1111_1100, 0b1111_1110, 0b1111_1111);
                    v256 SHUFFLE_MASK_HI = new v256(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1100_0000, 0b1100_0000, 0b1110_0000, 0b1111_1111,
                                                    0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1100_0000, 0b1100_0000, 0b1110_0000, 0b1111_1111);

                    return Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                               Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 BLEND_MASK = mm256_set1_epi16(0xFF00);
                    v256 byteMasks = mm256_l1msk_epi8(a);
                    v256 low = Avx2.mm256_and_si256(byteMasks, Avx2.mm256_srli_epi16(Avx2.mm256_cmpeq_epi8(byteMasks, BLEND_MASK), 8));

                    return mm256_blendv_si256(low, byteMasks, BLEND_MASK);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_sllv_epi32(mm256_setall_si256(), Avx2.mm256_sub_epi32(mm256_set1_epi32(32), mm256_l1cnt_epi32(a)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_sllv_epi64(mm256_setall_si256(), Avx2.mm256_sub_epi64(mm256_set1_epi64x(64), mm256_l1cnt_epi64(a)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 l1mask(UInt128 x)
        {
            int __l1cnt = l1cnt(x);

            return __l1cnt == 0 ? 0 : UInt128.MaxValue << (128 - __l1cnt);
        }

        /// <summary>       Sets all the leading ones in the binary representation of an <see cref="Int128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 l1mask(Int128 x)
        {
            return (Int128)l1mask((UInt128)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="byte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte l1mask(byte x)
        {
            return (byte)(byte.MaxValue << (8 - l1cnt(x)));
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 l1mask(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 l1mask(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte3(l1mask(x.x), l1mask(x.y), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 l1mask(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte4(l1mask(x.x), l1mask(x.y), l1mask(x.z), l1mask(x.w));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 l1mask(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte8(l1mask(x.x0), l1mask(x.x1), l1mask(x.x2), l1mask(x.x3), l1mask(x.x4), l1mask(x.x5), l1mask(x.x6), l1mask(x.x7));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 l1mask(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte16(l1mask(x.x0), l1mask(x.x1), l1mask(x.x2), l1mask(x.x3), l1mask(x.x4), l1mask(x.x5), l1mask(x.x6), l1mask(x.x7), l1mask(x.x8), l1mask(x.x9), l1mask(x.x10), l1mask(x.x11), l1mask(x.x12), l1mask(x.x13), l1mask(x.x14), l1mask(x.x15));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.byte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 l1mask(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi8(x);
            }
            else
            {
                return new byte32(l1mask(x.v16_0), l1mask(x.v16_16));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of an <see cref="sbyte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte l1mask(sbyte x)
        {
            return (sbyte)l1mask((byte)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 l1mask(sbyte2 x)
        {
            return (sbyte2)l1mask((byte2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.sbyte3"/ component> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 l1mask(sbyte3 x)
        {
            return (sbyte3)l1mask((byte3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 l1mask(sbyte4 x)
        {
            return (sbyte4)l1mask((byte4)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 l1mask(sbyte8 x)
        {
            return (sbyte8)l1mask((byte8)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 l1mask(sbyte16 x)
        {
            return (sbyte16)l1mask((byte16)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 l1mask(sbyte32 x)
        {
            return (sbyte32)l1mask((byte32)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort l1mask(ushort x)
        {
            return (ushort)(ushort.MaxValue << (16 - l1cnt(x)));
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 l1mask(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 l1mask(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort3(l1mask(x.x), l1mask(x.y), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 l1mask(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort4(l1mask(x.x), l1mask(x.y), l1mask(x.z), l1mask(x.w));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 l1mask(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort8(l1mask(x.x0), l1mask(x.x1), l1mask(x.x2), l1mask(x.x3), l1mask(x.x4), l1mask(x.x5), l1mask(x.x6), l1mask(x.x7));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ushort16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 l1mask(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi16(x);
            }
            else
            {
                return new ushort16(l1mask(x.v8_0), l1mask(x.v8_8));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="short"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short l1mask(short x)
        {
            return (short)l1mask((ushort)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 l1mask(short2 x)
        {
            return (short2)l1mask((ushort2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 l1mask(short3 x)
        {
            return (short3)l1mask((ushort3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 l1mask(short4 x)
        {
            return (short4)l1mask((ushort4)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 l1mask(short8 x)
        {
            return (short8)l1mask((ushort8)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 l1mask(short16 x)
        {
            return (short16)l1mask((ushort16)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint l1mask(uint x)
        {
            return (uint)((ulong)uint.MaxValue << (32 - l1cnt(x)));
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 l1mask(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.l1msk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 l1mask(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.l1msk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(l1mask(x.x), l1mask(x.y), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 l1mask(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.l1msk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(l1mask(x.x), l1mask(x.y), l1mask(x.z), l1mask(x.w));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.uint8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 l1mask(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi32(x);
            }
            else
            {
                return new uint8(l1mask(x.v4_0), l1mask(x.v4_4));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of an <see cref="int"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1mask(int x)
        {
            return (int)l1mask((uint)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 l1mask(int2 x)
        {
            return (int2)l1mask((uint2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 l1mask(int3 x)
        {
            return (int3)l1mask((uint3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 l1mask(int4 x)
        {
            return (int4)l1mask((uint4)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 l1mask(int8 x)
        {
            return (int8)l1mask((uint8)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong l1mask(ulong x)
        {
            return (ulong)((UInt128)ulong.MaxValue << (64 - l1cnt(x)));
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 l1mask(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi64(x);
            }
            else
            {
                return new ulong2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ulong3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 l1mask(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi64(x);
            }
            else
            {
                return new ulong3(l1mask(x.xy), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.ulong4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 l1mask(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi64(x);
            }
            else
            {
                return new ulong4(l1mask(x.xy), l1mask(x.zw));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="long"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long l1mask(long x)
        {
            return (long)l1mask((ulong)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 l1mask(long2 x)
        {
            return (long2)l1mask((ulong2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 l1mask(long3 x)
        {
            return (long3)l1mask((ulong3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="MaxMath.long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 l1mask(long4 x)
        {
            return (long4)l1mask((ulong4)x);
        }
    }
}
