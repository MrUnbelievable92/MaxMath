using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of leading zeros in the binary representations of a byte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul)]
        public static byte lzcnt(byte x)
        {
            return (byte)math.max(math.lzcnt((uint)x) - 24, 0);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lzcnt(byte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                byte2 y;
                byte2 n = 8;
                byte2 mask;

                y = x >> 4;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi8(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new byte2(lzcnt(x.x), lzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lzcnt(byte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                byte3 y;
                byte3 n = 8;
                byte3 mask;

                y = x >> 4;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi8(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new byte3(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lzcnt(byte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                byte4 y;
                byte4 n = 8;
                byte4 mask;

                y = x >> 4;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi8(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new byte4(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z), lzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lzcnt(byte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                byte8 y;
                byte8 n = 8;
                byte8 mask;

                y = x >> 4;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi8(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new byte8(lzcnt(x.x0), lzcnt(x.x1), lzcnt(x.x2), lzcnt(x.x3), lzcnt(x.x4), lzcnt(x.x5), lzcnt(x.x6), lzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lzcnt(byte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                byte16 y;
                byte16 n = 8;
                byte16 mask;

                y = x >> 4;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi8(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi8(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new byte16(lzcnt(x.x0), lzcnt(x.x1), lzcnt(x.x2), lzcnt(x.x3), lzcnt(x.x4), lzcnt(x.x5), lzcnt(x.x6), lzcnt(x.x7), lzcnt(x.x8), lzcnt(x.x9), lzcnt(x.x10), lzcnt(x.x11), lzcnt(x.x12), lzcnt(x.x13), lzcnt(x.x14), lzcnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a byte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lzcnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 NIBBLE_MASK = new v256(0x0F0F_0F0F);
                v256 SHUFFLE_MASK_LO = new v256(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4,
                                                8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v256 SHUFFLE_MASK_HI = new v256(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                return Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(NIBBLE_MASK, x)),
                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(NIBBLE_MASK, Avx2.mm256_srli_epi16(x, 4))));
            }
            else
            {
                return new byte32(lzcnt(x.v16_0), lzcnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of leading zeros in the binary representations of an sbyte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)]
        public static sbyte lzcnt(sbyte x)
        {
            return (sbyte)lzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 lzcnt(sbyte2 x)
        {
            return (sbyte2)lzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 lzcnt(sbyte3 x)
        {
            return (sbyte3)lzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 lzcnt(sbyte4 x)
        {
            return (sbyte4)lzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 lzcnt(sbyte8 x)
        {
            return (sbyte8)lzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 lzcnt(sbyte16 x)
        {
            return (sbyte16)lzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an sbyte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 lzcnt(sbyte32 x)
        {
            return (sbyte32)lzcnt((byte32)x);
        }


        /// <summary>       Returns number of leading zeros in the binary representations of a ushort value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul)]
        public static ushort lzcnt(ushort x)
        {
            return (ushort)math.max(math.lzcnt((uint)x) - 16, 0);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lzcnt(ushort2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                v128 lzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(Sse2.add_epi8(lzcnt_bytes, Sse2.set1_epi16(8)),
                                     Sse2.srli_epi16(lzcnt_bytes, 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort2 y;
                ushort2 n = 16;
                ushort2 mask;

                y = x >> 8;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 8, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 4;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi16(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new ushort2(lzcnt(x.x), lzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lzcnt(ushort3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                v128 lzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(Sse2.add_epi8(lzcnt_bytes, Sse2.set1_epi16(8)),
                                     Sse2.srli_epi16(lzcnt_bytes, 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort3 y;
                ushort3 n = 16;
                ushort3 mask;

                y = x >> 8;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 8, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 4;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi16(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new ushort3(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lzcnt(ushort4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                v128 lzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(Sse2.add_epi8(lzcnt_bytes, Sse2.set1_epi16(8)),
                                     Sse2.srli_epi16(lzcnt_bytes, 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort4 y;
                ushort4 n = 16;
                ushort4 mask;

                y = x >> 8;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 8, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 4;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 2;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);

                y = x >> 1;
                mask = Sse2.cmpeq_epi16(y, default(v128));

                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new ushort4(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z), lzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lzcnt(ushort8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v128 SHUFFLE_MASK_HI = new v128(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                v128 lzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(Sse2.add_epi8(lzcnt_bytes, Sse2.set1_epi16(8)),
                                     Sse2.srli_epi16(lzcnt_bytes, 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                ushort8 y;
                ushort8 n = 16;
                ushort8 mask;
            
                y = x >> 8;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 8, n, mask);
                x = Mask.BlendV(y, x, mask);
            
                y = x >> 4;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 4, n, mask);
                x = Mask.BlendV(y, x, mask);
            
                y = x >> 2;
                mask = Sse2.cmpeq_epi16(y, default(v128));
                n = Mask.BlendV(n - 2, n, mask);
                x = Mask.BlendV(y, x, mask);
            
                y = x >> 1;
                mask = Sse2.cmpeq_epi16(y, default(v128));
            
                return Mask.BlendV(n - 2, n - x, mask);
            }
            else
            {
                return new ushort8(lzcnt(x.x0), lzcnt(x.x1), lzcnt(x.x2), lzcnt(x.x3), lzcnt(x.x4), lzcnt(x.x5), lzcnt(x.x6), lzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ushort16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lzcnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 NIBBLE_MASK = new v256(0x0F0F_0F0F);
                v256 SHUFFLE_MASK_LO = new v256(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4,
                                                16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v256 SHUFFLE_MASK_HI = new v256(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                v256 lzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(NIBBLE_MASK, x)),
                                                       Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(NIBBLE_MASK, Avx2.mm256_srli_epi16(x, 4))));

                return Avx2.mm256_min_epu8(Avx2.mm256_add_epi8(lzcnt_bytes, Avx.mm256_set1_epi16(8)),
                                           Avx2.mm256_srli_epi16(lzcnt_bytes, 8));
            }
            else
            {
                return new ushort16(lzcnt(x.v8_0), lzcnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of leading zeros in the binary representations of a short value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 16)]
        public static short lzcnt(short x)
        {
            return (short)lzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 lzcnt(short2 x)
        {
            return (short2)lzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 lzcnt(short3 x)
        {
            return (short3)lzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 lzcnt(short4 x)
        {
            return (short4)lzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 lzcnt(short8 x)
        {
            return (short8)lzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a short16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 lzcnt(short16 x)
        {
            return (short16)lzcnt((ushort16)x);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a uint8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lzcnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ymm0, ymm1, ymm2, ymm3, ymm4;

                v256 ZERO = default(v256);
                v256 MASK = new v256(0x0101_0101_0202_0304L, 0L, 0x0101_0101_0202_0304L, 0L);

                ymm2 = Avx2.mm256_shuffle_epi8  (MASK, x);
                ymm3 = Avx2.mm256_srli_epi16    (x, 4);
                ymm3 = Avx2.mm256_and_si256     (ymm3, new v256(0x0F0F_0F0F));
                ymm4 = Avx2.mm256_cmpeq_epi8    (ymm3, ZERO);
                ymm2 = Avx2.mm256_and_si256     (ymm2, ymm4);
                ymm1 = Avx2.mm256_shuffle_epi8  (MASK, ymm3);
                ymm1 = Avx2.mm256_add_epi8      (ymm2, ymm1);
                ymm2 = Avx2.mm256_cmpeq_epi8    (x, ZERO);
                ymm2 = Avx2.mm256_srli_epi16    (ymm2, 8);
                ymm2 = Avx2.mm256_and_si256     (ymm1, ymm2);
                ymm1 = Avx2.mm256_srli_epi16    (ymm1, 8);
                ymm1 = Avx2.mm256_add_epi8      (ymm1, ymm2);
                ymm0 = Avx2.mm256_cmpeq_epi16   (x, ZERO);
                ymm0 = Avx2.mm256_srli_epi32    (ymm0, 16);
                ymm0 = Avx2.mm256_and_si256     (ymm1, ymm0);
                ymm1 = Avx2.mm256_srli_epi32    (ymm1, 16);
                ymm0 = Avx2.mm256_add_epi32     (ymm1, ymm0);

                return ymm0;
            }
            else
            {
                return new uint8((uint4)math.lzcnt(x.v4_0), (uint4)math.lzcnt(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an int8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 lzcnt(int8 x)
        {
            return (int8)lzcnt((uint8)x);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ulong2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lzcnt(ulong2 x)
        {
            return new ulong2((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ulong3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lzcnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong3 y = x >> 32;
                ulong4 cmp = Avx2.mm256_cmpeq_epi64(y, default(v256));

                ulong4 bits = Avx2.mm256_blendv_epi8(y, 0x0000_0000_FFFF_FFFF & x, cmp);
                ulong4 offset = Avx2.mm256_blendv_epi8((ulong4)0x041E, (ulong4)0x043E, cmp);

                bits += 0x4330_0000_0000_0000ul;
                bits = Avx.mm256_sub_pd(bits, new v256(4503599627370496d));
                bits = offset - (bits >> 52);

                return Avx2.mm256_blendv_epi8(bits, new ulong4(64), Avx2.mm256_cmpeq_epi64(x, default(v256)));
            }
            else
            {
                return new ulong3((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a ulong4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lzcnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong4 y = x >> 32;
                ulong4 cmp = Avx2.mm256_cmpeq_epi64(y, default(v256));

                ulong4 bits = Avx2.mm256_blendv_epi8(y, 0x0000_0000_FFFF_FFFF & x, cmp);
                ulong4 offset = Avx2.mm256_blendv_epi8((ulong4)0x041E, (ulong4)0x043E, cmp);

                bits += 0x4330_0000_0000_0000ul;
                bits = Avx.mm256_sub_pd(bits, new v256(4503599627370496d));
                bits = offset - (bits >> 52);

                return Avx2.mm256_blendv_epi8(bits, new ulong4(64), Avx2.mm256_cmpeq_epi64(x, default(v256)));
            }
            else
            {
                return new ulong4((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z), (ulong)math.lzcnt(x.w));
            }
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a long2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 lzcnt(long2 x)
        {
            return (long2)lzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a long3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 lzcnt(long3 x)
        {
            return (long3)lzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a long4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 lzcnt(long4 x)
        {
            return (long4)lzcnt((ulong4)x);
        }
    }
}