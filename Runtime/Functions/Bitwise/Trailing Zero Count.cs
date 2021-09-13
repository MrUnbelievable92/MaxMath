using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="UInt128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0L, 128L)]
        public static int tzcnt(UInt128 x)
        {
            if (x.lo == 0)
            {
                return 64 + math.tzcnt(x.hi); 
            }
            else
            {
                return math.tzcnt(x.lo);
            }
        }

        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0L, 128L)]
        public static int tzcnt(Int128 x)
        {
            return tzcnt(x.intern);
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="byte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul)]
        public static byte tzcnt(byte x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 8) adds another branch (for whatever reason)

            return (x == 0) ? (byte)8 : (byte)math.tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzcnt(byte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte2)(-(sbyte2)x);

                byte2 second = Sse2.and_si128(new byte4(4), Sse2.cmpeq_epi8(compareMask & (byte4)0x0F, default(v128)));
                byte2 third  = Sse2.and_si128(new byte4(2), Sse2.cmpeq_epi8(compareMask & (byte4)0x33, default(v128)));
                byte2 fourth = Sse2.and_si128(new byte4(1), Sse2.cmpeq_epi8(compareMask & (byte4)0x55, default(v128)));
                
                return ((second + third) + fourth) - Sse2.cmpeq_epi8(compareMask, default(v128));
            }
            else
            {
                return new byte2(tzcnt(x.x), tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzcnt(byte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte3)(-(sbyte3)x);

                byte3 second = Sse2.and_si128(new byte4(4), Sse2.cmpeq_epi8(compareMask & (byte4)0x0F, default(v128)));
                byte3 third  = Sse2.and_si128(new byte4(2), Sse2.cmpeq_epi8(compareMask & (byte4)0x33, default(v128)));
                byte3 fourth = Sse2.and_si128(new byte4(1), Sse2.cmpeq_epi8(compareMask & (byte4)0x55, default(v128)));
                
                return ((second + third) + fourth) - Sse2.cmpeq_epi8(compareMask, default(v128));
            }
            else
            {
                return new byte3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzcnt(byte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte4)(-(sbyte4)x);

                byte4 second = Sse2.and_si128(new byte4(4), Sse2.cmpeq_epi8(compareMask & (byte4)0x0F, default(v128)));
                byte4 third  = Sse2.and_si128(new byte4(2), Sse2.cmpeq_epi8(compareMask & (byte4)0x33, default(v128)));
                byte4 fourth = Sse2.and_si128(new byte4(1), Sse2.cmpeq_epi8(compareMask & (byte4)0x55, default(v128)));
                
                return ((second + third) + fourth) - Sse2.cmpeq_epi8(compareMask, default(v128));
            }
            else
            {
                return new byte4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzcnt(byte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte8)(-(sbyte8)x);

                byte8 second = Sse2.and_si128(new byte8(4), Sse2.cmpeq_epi8(compareMask & (byte8)0x0F, default(v128)));
                byte8 third  = Sse2.and_si128(new byte8(2), Sse2.cmpeq_epi8(compareMask & (byte8)0x33, default(v128)));
                byte8 fourth = Sse2.and_si128(new byte8(1), Sse2.cmpeq_epi8(compareMask & (byte8)0x55, default(v128)));
                
                return ((second + third) + fourth) - Sse2.cmpeq_epi8(compareMask, default(v128));
            }
            else
            {
                return new byte8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzcnt(byte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                return Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                     Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (byte16)(-(sbyte16)x);
            
                byte16 second = Sse2.and_si128(new byte16(4), Sse2.cmpeq_epi8(compareMask & (byte16)0x0F, default(v128)));
                byte16 third  = Sse2.and_si128(new byte16(2), Sse2.cmpeq_epi8(compareMask & (byte16)0x33, default(v128)));
                byte16 fourth = Sse2.and_si128(new byte16(1), Sse2.cmpeq_epi8(compareMask & (byte16)0x55, default(v128)));
                
                return ((second + third) + fourth) - Sse2.cmpeq_epi8(compareMask, default(v128));
            }
            else
            {
                return new byte16(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7), tzcnt(x.x8), tzcnt(x.x9), tzcnt(x.x10), tzcnt(x.x11), tzcnt(x.x12), tzcnt(x.x13), tzcnt(x.x14), tzcnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tzcnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 NIBBLE_MASK = new v256(0x0F0F_0F0F);
                v256 SHUFFLE_MASK_LO = new v256(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
                                                8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v256 SHUFFLE_MASK_HI = new v256(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4,
                                                8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                return Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(NIBBLE_MASK, x)),
                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(NIBBLE_MASK, Avx2.mm256_srli_epi16(x, 4))));
            }
            else
            {
                return new byte32(tzcnt(x.v16_0), tzcnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)]
        public static sbyte tzcnt(sbyte x)
        {
            return (sbyte)tzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzcnt(sbyte2 x)
        {
            return (sbyte2)tzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzcnt(sbyte3 x)
        {
            return (sbyte3)tzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzcnt(sbyte4 x)
        {
            return (sbyte4)tzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzcnt(sbyte8 x)
        {
            return (sbyte8)tzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzcnt(sbyte16 x)
        {
            return (sbyte16)tzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzcnt(sbyte32 x)
        {
            return (sbyte32)tzcnt((byte32)x);
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="ushort"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul)]
        public static ushort tzcnt(ushort x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 16) adds another branch (for whatever reason)

            return (x == 0) ? (ushort)16 : (ushort)math.tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzcnt(ushort2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                v128 tzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(tzcnt_bytes,
                                     Sse2.srli_epi16(Sse2.add_epi8(tzcnt_bytes, Sse2.set1_epi8(8)), 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (ushort2)(-((short2)x));

                ushort2 second = Sse2.and_si128(new ushort2(8),  Sse2.cmpeq_epi16(compareMask & (ushort2)0x00FF, default(v128)));
                ushort2 third  = Sse2.and_si128(new ushort2(4),  Sse2.cmpeq_epi16(compareMask & (ushort2)0x0F0F, default(v128)));
                ushort2 fourth = Sse2.and_si128(new ushort2(2),  Sse2.cmpeq_epi16(compareMask & (ushort2)0x3333, default(v128)));
                ushort2 fifth  = Sse2.and_si128(new ushort2(1),  Sse2.cmpeq_epi16(compareMask & (ushort2)0x5555, default(v128)));
                
                return ((second + third) + (fourth + fifth)) - Sse2.cmpeq_epi16(compareMask, default(v128));
            }
            else
            {
                return new ushort2(tzcnt(x.x), tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzcnt(ushort3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                v128 tzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(tzcnt_bytes,
                                     Sse2.srli_epi16(Sse2.add_epi8(tzcnt_bytes, Sse2.set1_epi8(8)), 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (ushort3)(-((short3)x));

                ushort3 second = Sse2.and_si128(new ushort4(8),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x00FF, default(v128)));
                ushort3 third  = Sse2.and_si128(new ushort4(4),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x0F0F, default(v128)));
                ushort3 fourth = Sse2.and_si128(new ushort4(2),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x3333, default(v128)));
                ushort3 fifth  = Sse2.and_si128(new ushort4(1),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x5555, default(v128)));
                
                return ((second + third) + (fourth + fifth)) - Sse2.cmpeq_epi16(compareMask, default(v128));
            }
            else
            {
                return new ushort3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzcnt(ushort4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                v128 tzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(tzcnt_bytes,
                                     Sse2.srli_epi16(Sse2.add_epi8(tzcnt_bytes, Sse2.set1_epi8(8)), 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (ushort4)(-((short4)x));

                ushort4 second = Sse2.and_si128(new ushort4(8),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x00FF, default(v128)));
                ushort4 third  = Sse2.and_si128(new ushort4(4),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x0F0F, default(v128)));
                ushort4 fourth = Sse2.and_si128(new ushort4(2),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x3333, default(v128)));
                ushort4 fifth  = Sse2.and_si128(new ushort4(1),  Sse2.cmpeq_epi16(compareMask & (ushort4)0x5555, default(v128)));
                
                return ((second + third) + (fourth + fifth)) - Sse2.cmpeq_epi16(compareMask, default(v128));
            }
            else
            {
                return new ushort4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzcnt(ushort8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 NIBBLE_MASK = new v128(0x0F0F_0F0F);
                v128 SHUFFLE_MASK_LO = new v128(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v128 SHUFFLE_MASK_HI = new v128(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                v128 tzcnt_bytes = Sse2.min_epu8(Ssse3.shuffle_epi8(SHUFFLE_MASK_LO, Sse2.and_si128(NIBBLE_MASK, x)),
                                                 Ssse3.shuffle_epi8(SHUFFLE_MASK_HI, Sse2.and_si128(NIBBLE_MASK, Sse2.srli_epi16(x, 4))));

                return Sse2.min_epu8(tzcnt_bytes,
                                     Sse2.srli_epi16(Sse2.add_epi8(tzcnt_bytes, Sse2.set1_epi8(8)), 8));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 compareMask = x & (ushort8)(-((short8)x));
            
                ushort8 second = Sse2.and_si128(new ushort8(8),  Sse2.cmpeq_epi16(compareMask & (ushort8)0x00FF, default(v128)));
                ushort8 third  = Sse2.and_si128(new ushort8(4),  Sse2.cmpeq_epi16(compareMask & (ushort8)0x0F0F, default(v128)));
                ushort8 fourth = Sse2.and_si128(new ushort8(2),  Sse2.cmpeq_epi16(compareMask & (ushort8)0x3333, default(v128)));
                ushort8 fifth  = Sse2.and_si128(new ushort8(1),  Sse2.cmpeq_epi16(compareMask & (ushort8)0x5555, default(v128)));
            
                return ((second + third) + (fourth + fifth)) - Sse2.cmpeq_epi16(compareMask, default(v128));
            }
            else
            {
                return new ushort8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 tzcnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 NIBBLE_MASK = new v256(0x0F0F_0F0F);
                v256 SHUFFLE_MASK_LO = new v256(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
                                                16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                v256 SHUFFLE_MASK_HI = new v256(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4,
                                                16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                v256 tzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(NIBBLE_MASK, x)),
                                                       Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(NIBBLE_MASK, Avx2.mm256_srli_epi16(x, 4))));

                return Avx2.mm256_min_epu8(tzcnt_bytes,
                                           Avx2.mm256_srli_epi16(Avx2.mm256_add_epi8(tzcnt_bytes, new byte32(8)), 8));
            }
            else
            {
                return new ushort16(tzcnt(x.v8_0), tzcnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 16)]
        public static short tzcnt(short x)
        {
            return (short)tzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzcnt(short2 x)
        {
            return (short2)tzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzcnt(short3 x)
        {
            return (short3)tzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzcnt(short4 x)
        {
            return (short4)tzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzcnt(short8 x)
        {
            return (short8)tzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzcnt(short16 x)
        {
            return (short16)tzcnt((ushort16)x);
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 tzcnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ymm0, ymm1, ymm2;

                v256 ZERO = default;
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(ZERO, ZERO);
                v256 MASK = new v256(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4,
                                     0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);

                ymm1 = Avx2.mm256_add_epi32         (x,    ALL_ONES);
                ymm0 = Avx2.mm256_andnot_si256      (x,    ymm1);
                ymm2 = Avx2.mm256_and_si256         (ymm0, new v256(0x0F0F_0F0F));
                ymm2 = Avx2.mm256_shuffle_epi8      (MASK, ymm2);
                ymm0 = Avx2.mm256_srli_epi16        (ymm0, 4);
                ymm0 = Avx2.mm256_and_si256         (ymm0, ymm1);
                ymm0 = Avx2.mm256_shuffle_epi8      (MASK, ymm0);
                ymm0 = Avx2.mm256_add_epi8          (ymm0, ymm2);
                ymm2 = Avx2.mm256_unpackhi_epi32    (ymm0, ZERO);
                ymm2 = Avx2.mm256_sad_epu8          (ymm2, ZERO);
                ymm0 = Avx2.mm256_unpacklo_epi32    (ymm0, ZERO);
                ymm0 = Avx2.mm256_sad_epu8          (ymm0, ZERO);
                ymm0 = Avx2.mm256_packus_epi16      (ymm0, ymm2);

                return ymm0;
            }
            else
            {
                return new uint8((uint4)math.tzcnt(x.v4_0), (uint4)math.tzcnt(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzcnt(int8 x)
        {
            return (int8)tzcnt((uint8)x);
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzcnt(ulong2 x)
        {
            return new ulong2((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y));
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 tzcnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();

                v256 isZero = Avx2.mm256_cmpeq_epi64(x, ZERO);
                x = Avx2.mm256_and_si256(x, Avx2.mm256_sub_epi64(ZERO, x));

                v256 y = Avx2.mm256_blend_epi32(ZERO, x, 0b0101_0101);
                v256 cmp = Avx2.mm256_cmpeq_epi64(y, ZERO);

                v256 bits = Avx2.mm256_blendv_epi8(y, Avx2.mm256_srli_epi64(x, 32), cmp);
                v256 offset = Avx2.mm256_blendv_epi8(new v256(0x03FFul), new v256(0x03DFul), cmp);

                bits = Avx2.mm256_add_epi64(bits, new v256(0x4330_0000_0000_0000ul));
                bits = Avx.mm256_sub_pd(bits, new v256(4_503_599_627_370_496d));
                bits = Avx2.mm256_sub_epi64(Avx2.mm256_srli_epi64(bits, 52), offset);

                return Avx2.mm256_blendv_epi8(bits, new v256(64ul), isZero);
            }
            else
            {
                return new ulong3((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 tzcnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();

                v256 isZero = Avx2.mm256_cmpeq_epi64(x, ZERO);
                x = Avx2.mm256_and_si256(x, Avx2.mm256_sub_epi64(ZERO, x));

                v256 y = Avx2.mm256_blend_epi32(ZERO, x, 0b0101_0101);
                v256 cmp = Avx2.mm256_cmpeq_epi64(y, ZERO);

                v256 bits = Avx2.mm256_blendv_epi8(y, Avx2.mm256_srli_epi64(x, 32), cmp);
                v256 offset = Avx2.mm256_blendv_epi8(new v256(0x03FFul), new v256(0x03DFul), cmp);

                bits = Avx2.mm256_add_epi64(bits, new v256(0x4330_0000_0000_0000ul));
                bits = Avx.mm256_sub_pd(bits, new v256(4_503_599_627_370_496d));
                bits = Avx2.mm256_sub_epi64(Avx2.mm256_srli_epi64(bits, 52), offset);

                return bits;
            }
            else
            {
                return new ulong4((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z), (ulong)math.tzcnt(x.w));
            }
        }


        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzcnt(long2 x)
        {
            return (long2)tzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzcnt(long3 x)
        {
            return (long3)tzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzcnt(long4 x)
        {
            return (long4)tzcnt((ulong4)x);
        }
    }
}