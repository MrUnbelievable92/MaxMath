using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1cnt_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 8);
                        v128 SHUFFLE_MASK_HI = new v128(0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 8);

                        result = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                          shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        result = lzcnt_epi8(not_si128(a));
                    }
                        
                    constexpr.ASSUME_LE_EPU8(result, 8);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1cnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 8,
                                                    4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 8);
                    v256 SHUFFLE_MASK_HI = new v256(0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 8,
                                                    0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 8);

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                    
                    constexpr.ASSUME_LE_EPU8(result, 8);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1cnt_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;
                    
                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 16);
                        v128 SHUFFLE_MASK_HI = new v128(0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 16);

                        v128 l1cnt_bytes = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                                    shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                        result = min_epu8(add_epi8(l1cnt_bytes, set1_epi16(8)),
                                          srli_epi16(l1cnt_bytes, 8));
                    }
                    else
                    {
                        result = lzcnt_epi16(not_si128(a));
                    }
                        
                    constexpr.ASSUME_LE_EPU16(result, 16);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1cnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 16,
                                                    4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 7, 16);
                    v256 SHUFFLE_MASK_HI = new v256(0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 16,
                                                    0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 16);

                    v256 l1cnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_add_epi8(l1cnt_bytes, mm256_set1_epi16(8)),
                                                      Avx2.mm256_srli_epi16(l1cnt_bytes, 8));

                    constexpr.ASSUME_LE_EPU16(result, 16);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1cnt_epi32(v128 a, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return lzcnt_epi32(not_si128(a), elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1cnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_lzcnt_epi32(mm256_not_si256(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1cnt_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return lzcnt_epi64(not_si128(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1cnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_lzcnt_epi64(mm256_not_si256(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="UInt128"/>.    </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1cnt(UInt128 x)
        {
            if (x.hi64 == ulong.MaxValue)
            {
                return 64 + l1cnt(x.lo64);
            }
            else
            {
                return l1cnt(x.hi64);
            }
        }

        /// <summary>       Returns number of leading ones in the binary representation of an <see cref="Int128"/>.    </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1cnt(Int128 x)
        {
            return l1cnt(x.value);
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte l1cnt(byte x)
        {
            return lzcnt((byte)~x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 l1cnt(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi8(x);
            }
            else
            {
                return new byte2(l1cnt(x.x), l1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 l1cnt(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi8(x);
            }
            else
            {
                return new byte3(l1cnt(x.x), l1cnt(x.y), l1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 l1cnt(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi8(x);
            }
            else
            {
                return new byte4(l1cnt(x.x), l1cnt(x.y), l1cnt(x.z), l1cnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 l1cnt(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi8(x);
            }
            else
            {
                return new byte8(l1cnt(x.x0), l1cnt(x.x1), l1cnt(x.x2), l1cnt(x.x3), l1cnt(x.x4), l1cnt(x.x5), l1cnt(x.x6), l1cnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 l1cnt(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi8(x);
            }
            else
            {
                return new byte16(l1cnt(x.x0), l1cnt(x.x1), l1cnt(x.x2), l1cnt(x.x3), l1cnt(x.x4), l1cnt(x.x5), l1cnt(x.x6), l1cnt(x.x7), l1cnt(x.x8), l1cnt(x.x9), l1cnt(x.x10), l1cnt(x.x11), l1cnt(x.x12), l1cnt(x.x13), l1cnt(x.x14), l1cnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 l1cnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1cnt_epi8(x);
            }
            else
            {
                return new byte32(l1cnt(x.v16_0), l1cnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of leading ones in the binary representation of an <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte l1cnt(sbyte x)
        {
            return (sbyte)l1cnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 l1cnt(sbyte2 x)
        {
            return (sbyte2)l1cnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 l1cnt(sbyte3 x)
        {
            return (sbyte3)l1cnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 l1cnt(sbyte4 x)
        {
            return (sbyte4)l1cnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 l1cnt(sbyte8 x)
        {
            return (sbyte8)l1cnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 l1cnt(sbyte16 x)
        {
            return (sbyte16)l1cnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 l1cnt(sbyte32 x)
        {
            return (sbyte32)l1cnt((byte32)x);
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort l1cnt(ushort x)
        {
            return lzcnt((ushort)~x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 l1cnt(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi16(x);
            }
            else
            {
                return new ushort2(l1cnt(x.x), l1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 l1cnt(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi16(x);
            }
            else
            {
                return new ushort3(l1cnt(x.x), l1cnt(x.y), l1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 l1cnt(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi16(x);
            }
            else
            {
                return new ushort4(l1cnt(x.x), l1cnt(x.y), l1cnt(x.z), l1cnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 l1cnt(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi16(x);
            }
            else
            {
                return new ushort8(l1cnt(x.x0), l1cnt(x.x1), l1cnt(x.x2), l1cnt(x.x3), l1cnt(x.x4), l1cnt(x.x5), l1cnt(x.x6), l1cnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 l1cnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1cnt_epi16(x);
            }
            else
            {
                return new ushort16(l1cnt(x.v8_0), l1cnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="short"/>.    </summary>
        [return: AssumeRange(0, 16)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short l1cnt(short x)
        {
            return (short)l1cnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 l1cnt(short2 x)
        {
            return (short2)l1cnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 l1cnt(short3 x)
        {
            return (short3)l1cnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 l1cnt(short4 x)
        {
            return (short4)l1cnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 l1cnt(short8 x)
        {
            return (short8)l1cnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 l1cnt(short16 x)
        {
            return (short16)l1cnt((ushort16)x);
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="uint"/>.    </summary>
        [return: AssumeRange(0L, 32L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1cnt(uint x)
        {
            return math.lzcnt(~x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 l1cnt(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.l1cnt_epi32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return new int2(l1cnt(x.x), l1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 l1cnt(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.l1cnt_epi32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return new int3(l1cnt(x.x), l1cnt(x.y), l1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 l1cnt(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.l1cnt_epi32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return new int4(l1cnt(x.x), l1cnt(x.y), l1cnt(x.z), l1cnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 l1cnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1cnt_epi32(x);
            }
            else
            {
                return new int8(l1cnt(x.v4_0), l1cnt(x.v4_4));
            }
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="int"/>.    </summary>
        [return: AssumeRange(0, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1cnt(int x)
        {
            return l1cnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 l1cnt(int2 x)
        {
            return l1cnt((uint2)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 l1cnt(int3 x)
        {
            return l1cnt((uint3)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 l1cnt(int4 x)
        {
            return l1cnt((uint4)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 l1cnt(int8 x)
        {
            return l1cnt((uint8)x);
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="ulong"/>.    </summary>
        [return: AssumeRange(0, 64)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1cnt(ulong x)
        {
            return math.lzcnt(~x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 l1cnt(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.l1cnt_epi64(x);
            }
            else
            {
                return new ulong2((ulong)l1cnt(x.x), (ulong)l1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 l1cnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1cnt_epi64(x);
            }
            else
            {
                return new ulong3(l1cnt(x.xy), (ulong)l1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 l1cnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1cnt_epi64(x);
            }
            else
            {
                return new ulong4(l1cnt(x.xy), l1cnt(x.zw));
            }
        }


        /// <summary>       Returns number of leading ones in the binary representation of a <see cref="long"/>.    </summary>
        [return: AssumeRange(0, 64)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1cnt(long x)
        {
            return l1cnt((ulong)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 l1cnt(long2 x)
        {
            return (long2)l1cnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 l1cnt(long3 x)
        {
            return (long3)l1cnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of leading ones in the binary representations of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 l1cnt(long4 x)
        {
            return (long4)l1cnt((ulong4)x);
        }
    }
}