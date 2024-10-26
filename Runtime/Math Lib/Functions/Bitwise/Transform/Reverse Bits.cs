using MaxMath.Intrinsics;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private static v128 BITSWAP_SHUFFLE_MASK_LO => new v128(0b0000_0000, 0b1000_0000, 0b0100_0000, 0b1100_0000, 0b0010_0000, 0b1010_0000, 0b0110_0000, 0b1110_0000, 0b0001_0000, 0b1001_0000, 0b0101_0000, 0b1101_0000, 0b0011_0000, 0b1011_0000, 0b0111_0000, 0b1111_0000);
            private static v128 BITSWAP_SHUFFLE_MASK_HI => new v128(0b0000_0000, 0b0000_1000, 0b0000_0100, 0b0000_1100, 0b0000_0010, 0b0000_1010, 0b0000_0110, 0b0000_1110, 0b0000_0001, 0b0000_1001, 0b0000_0101, 0b0000_1101, 0b0000_0011, 0b0000_1011, 0b0000_0111, 0b0000_1111);

            private static v256 MM256_BITSWAP_SHUFFLE_MASK_LO => new v256(BITSWAP_SHUFFLE_MASK_LO, BITSWAP_SHUFFLE_MASK_LO);
            private static v256 MM256_BITSWAP_SHUFFLE_MASK_HI => new v256(BITSWAP_SHUFFLE_MASK_HI, BITSWAP_SHUFFLE_MASK_HI);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitswap_epi8(v128 a)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    return or_si128(shuffle_epi8(BITSWAP_SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                    shuffle_epi8(BITSWAP_SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 MASK0 = set1_epi8(0x55);
                    v128 MASK1 = set1_epi8(0x33);

                    a = or_si128(and_si128(srli_epi16(a, 1), MASK0), slli_epi8(and_si128(a, MASK0), 1));
                    a = or_si128(and_si128(srli_epi16(a, 2), MASK1), slli_epi8(and_si128(a, MASK1), 2));

                    return ror_epi8(a, 4);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitswap_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return bitswap_epi8(bswap_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitswap_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return bitswap_epi8(bswap_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitswap_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return bitswap_epi8(bswap_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitswap_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(Avx2.mm256_shuffle_epi8(MM256_BITSWAP_SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                               Avx2.mm256_shuffle_epi8(MM256_BITSWAP_SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitswap_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_bitswap_epi8(mm256_bswap_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitswap_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_bitswap_epi8(mm256_bswap_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitswap_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_bitswap_epi8(mm256_bswap_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of performing a reversal of the bit pattern of a <see cref="UInt128"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 reversebits(UInt128 x)
        {
            ulong2 _x = reversebits(new ulong2(x.lo64, x.hi64)).yx;

            return new UInt128(_x.x, _x.y);
        }

        /// <summary>       Returns the result of performing a reversal of the bit pattern of an <see cref="Int128"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 reversebits(Int128 x)
        {
            return (Int128)reversebits((UInt128)x);
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of a <see cref="byte"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte reversebits(byte x)
        {
            x = (byte)(((x >> 1) & 0x55) | ((x & 0x55) << 1));
            x = (byte)(((x >> 2) & 0x33) | ((x & 0x33) << 2));

            return ror(x, 4);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.byte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 reversebits(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi8(x);
            }
            else
            {
                return new byte2(reversebits(x.x), reversebits(x.y));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.byte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 reversebits(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi8(x);
            }
            else
            {
                return new byte3(reversebits(x.x), reversebits(x.y), reversebits(x.z));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.byte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 reversebits(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi8(x);
            }
            else
            {
                return new byte4(reversebits(x.x), reversebits(x.y), reversebits(x.z), reversebits(x.w));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.byte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 reversebits(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi8(x);
            }
            else
            {
                return new byte8(reversebits(x.x0),
                                 reversebits(x.x1),
                                 reversebits(x.x2),
                                 reversebits(x.x3),
                                 reversebits(x.x4),
                                 reversebits(x.x5),
                                 reversebits(x.x6),
                                 reversebits(x.x7));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.byte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 reversebits(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi8(x);
            }
            else
            {
                return new byte16(reversebits(x. x0),
                                  reversebits(x. x1),
                                  reversebits(x. x2),
                                  reversebits(x. x3),
                                  reversebits(x. x4),
                                  reversebits(x. x5),
                                  reversebits(x. x6),
                                  reversebits(x. x7),
                                  reversebits(x. x8),
                                  reversebits(x. x9),
                                  reversebits(x.x10),
                                  reversebits(x.x11),
                                  reversebits(x.x12),
                                  reversebits(x.x13),
                                  reversebits(x.x14),
                                  reversebits(x.x15));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.byte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 reversebits(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitswap_epi8(x);
            }
            else
            {
                return new byte32(reversebits(x.v16_0), reversebits(x.v16_16));
            }
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of an <see cref="sbyte"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte reversebits(sbyte x)
        {
            return (sbyte)reversebits((byte)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.sbyte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 reversebits(sbyte2 x)
        {
            return (sbyte2)reversebits((byte2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.sbyte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 reversebits(sbyte3 x)
        {
            return (sbyte3)reversebits((byte3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.sbyte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 reversebits(sbyte4 x)
        {
            return (sbyte4)reversebits((byte4)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.sbyte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 reversebits(sbyte8 x)
        {
            return (sbyte8)reversebits((byte8)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.sbyte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 reversebits(sbyte16 x)
        {
            return (sbyte16)reversebits((byte16)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.sbyte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 reversebits(sbyte32 x)
        {
            return (sbyte32)reversebits((byte32)x);
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of a <see cref="ushort"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort reversebits(ushort x)
        {
            x = reversebytes(x);

            x = (ushort)(((x >> 1) & 0x5555u) | ((x & 0x5555u) << 1));
            x = (ushort)(((x >> 2) & 0x3333u) | ((x & 0x3333u) << 2));
            x = (ushort)(((x >> 4) & 0x0F0Fu) | ((x & 0x0F0Fu) << 4));

            return x;
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ushort2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 reversebits(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi16(x);
            }
            else
            {
                return new ushort2(reversebits(x.x), reversebits(x.y));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ushort3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 reversebits(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi16(x);
            }
            else
            {
                return new ushort3(reversebits(x.x), reversebits(x.y), reversebits(x.z));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ushort4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 reversebits(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi16(x);
            }
            else
            {
                return new ushort4(reversebits(x.x), reversebits(x.y), reversebits(x.z), reversebits(x.w));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 reversebits(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi16(x);
            }
            else
            {
                return new ushort8(reversebits(x.x0),
                                   reversebits(x.x1),
                                   reversebits(x.x2),
                                   reversebits(x.x3),
                                   reversebits(x.x4),
                                   reversebits(x.x5),
                                   reversebits(x.x6),
                                   reversebits(x.x7));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 reversebits(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitswap_epi16(x);
            }
            else
            {
                return new ushort16(reversebits(x.v8_0), reversebits(x.v8_8));
            }
        }


        /// <summary>       Returns the result of performing a reversal of the bit pattern of a <see cref="short"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short reversebits(short x)
        {
            return (short)reversebits((ushort)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.short2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 reversebits(short2 x)
        {
            return (short2)reversebits((ushort2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.short3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 reversebits(short3 x)
        {
            return (short3)reversebits((ushort3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.short4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 reversebits(short4 x)
        {
            return (short4)reversebits((ushort4)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.short8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 reversebits(short8 x)
        {
            return (short8)reversebits((ushort8)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.short16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 reversebits(short16 x)
        {
            return (short16)reversebits((ushort16)x);
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 reversebits(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitswap_epi32(x);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return new uint8(RegisterConversion.ToUInt4(Xse.bitswap_epi32(RegisterConversion.ToV128(x.v4_0))), RegisterConversion.ToUInt4(Xse.bitswap_epi32(RegisterConversion.ToV128(x.v4_4))));
            }
            else
            {
                return new uint8(math.reversebits(x.v4_0), math.reversebits(x.v4_4));
            }
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of an <see cref="MaxMath.int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 reversebits(int8 x)
        {
            return (int8)reversebits((uint8)x);
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 reversebits(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitswap_epi64(x);
            }
            else
            {
                return new ulong2(math.reversebits(x.x), math.reversebits(x.y));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 reversebits(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitswap_epi64(x);
            }
            else if (Architecture.IsSIMDSupported)
            {
                ulong __z = reversebytes(x.z);

                __z = ((__z >> 1)  & 0x5555_5555_5555_5555ul) | ((__z & 0x5555_5555_5555_5555ul) << 1);
                __z = ((__z >> 2)  & 0x3333_3333_3333_3333ul) | ((__z & 0x3333_3333_3333_3333ul) << 2);
                __z = ((__z >> 4)  & 0x0F0F_0F0F_0F0F_0F0Ful) | ((__z & 0x0F0F_0F0F_0F0F_0F0Ful) << 4);

                return new ulong3(Xse.bitswap_epi64(x.xy), __z);
            }
            else
            {
                return new ulong3(math.reversebits(x.x), math.reversebits(x.y), math.reversebits(x.z));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.ulong4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 reversebits(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitswap_epi64(x);
            }
            else
            {
                return new ulong4(math.reversebits(x.x), math.reversebits(x.y), math.reversebits(x.z), math.reversebits(x.w));
            }
        }


        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 reversebits(long2 x)
        {
            return (long2)reversebits((ulong2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 reversebits(long3 x)
        {
            return (long3)reversebits((ulong3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the bit pattern of a <see cref="MaxMath.long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 reversebits(long4 x)
        {
            return (long4)reversebits((ulong4)x);
        }
    }
}