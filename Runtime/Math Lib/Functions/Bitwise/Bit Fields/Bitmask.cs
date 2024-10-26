using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi8(v128 a, v128 b = default(v128), byte elements = 16, bool promiseLT8 = false)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    v128 LOOKUP = new v128(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0, 0, 0, 0, 0, 0, 0);

                    return sllv_epi8(shuffle_epi8(LOOKUP, a), b, elements: elements);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    b = sllv_epi8(setall_si128(), b, elements: elements);

                    if (promiseLT8 || constexpr.ALL_LT_EPU8(a, 8, elements))
                    {
                        return andnot_si128(sllv_epi8(b, a, elements: elements), b);
                    }
                    else
                    {
                        v128 isMaxBitsMask = cmpeq_epi8(a, set1_epi8(8));

                        return ternarylogic_si128(isMaxBitsMask, b, sllv_epi8(b, a), TernaryOperation.OxF4);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi8(v256 a, v256 b = default(v256))
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0, 0, 0, 0, 0, 0, 0,
                                           0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0, 0, 0, 0, 0, 0, 0);

                    return mm256_sllv_epi8(Avx2.mm256_shuffle_epi8(LOOKUP, a), b);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi16(v128 a, v128 b = default(v128), byte elements = 8, bool promiseLT16 = false)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    v128 LOOKUP = new v128(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111,
                                           0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                    v128 lo = shuffle_epi8(LOOKUP, promiseLT16 ? a : add_epi16(a, cmpeq_epi16(a, set1_epi16(16))));
                    v128 hi = shuffle_epi8(LOOKUP, subs_epu16(a, set1_epi16(8)));

                    return sllv_epi16(or_si128(lo, slli_epi16(hi, 8)), b, elements: elements);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    b = sllv_epi16(setall_si128(), b, elements: elements);

                    if (promiseLT16 || constexpr.ALL_LT_EPU16(a, 16, elements))
                    {
                        return andnot_si128(sllv_epi16(b, a, elements: elements), b);
                    }
                    else
                    {
                        v128 isMaxBitsMask = cmpeq_epi16(a, set1_epi16(16));

                        return ternarylogic_si128(isMaxBitsMask, b, sllv_epi16(b, a), TernaryOperation.OxF4);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi16(v256 a, v256 b = default(v256), bool promiseLT16 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111,
                                           0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111,
                                           0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111,
                                           0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                    v256 lo = Avx2.mm256_shuffle_epi8(LOOKUP, promiseLT16 ? a : Avx2.mm256_add_epi16(a, Avx2.mm256_cmpeq_epi16(a, mm256_set1_epi16(16))));
                    v256 hi = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_subs_epu16(a, mm256_set1_epi16(8)));

                    return mm256_sllv_epi16(Avx2.mm256_or_si256(lo, mm256_slli_epi16(hi, 8)), b);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi32(v128 a, v128 b = default(v128), byte elements = 4, bool promiseLT32 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    b = sllv_epi32(setall_si128(), b, elements: elements);

                    if (promiseLT32 || constexpr.ALL_LT_EPU32(a, 32, elements))
                    {
                        return andnot_si128(sllv_epi32(b, a, elements: elements), b);
                    }
                    else
                    {
                        v128 isMaxBitsMask = cmpeq_epi32(a, set1_epi32(32));

                        return ternarylogic_si128(isMaxBitsMask, b, sllv_epi32(b, a), TernaryOperation.OxF4);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi32(v256 a, v256 b = default(v256), bool promiseLT32 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    b = Avx2.mm256_sllv_epi32(mm256_setall_si256(), b);

                    if (promiseLT32 || constexpr.ALL_LT_EPU32(a, 32))
                    {
                        return Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi32(b, a) , b);
                    }
                    else
                    {
                        v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(32));

                        return mm256_ternarylogic_si256(isMaxBitsMask, b, Avx2.mm256_sllv_epi32(b, a), TernaryOperation.OxF4);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi64(v128 a, v128 b = default(v128), bool promiseLT64 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    b = sllv_epi64(setall_si128(), b);

                    if (promiseLT64 || constexpr.ALL_LT_EPU64(a, 64))
                    {
                        return andnot_si128(sllv_epi64(b, a), b);
                    }
                    else
                    {
                        v128 isMaxBitsMask = cmpeq_epi64(a, set1_epi64x(64));

                        return ternarylogic_si128(isMaxBitsMask, b, sllv_epi64(b, a), TernaryOperation.OxF4);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi64(v256 a, v256 b = default(v256), bool promiseLT64 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    b = Avx2.mm256_sllv_epi64(mm256_setall_si256(), b);

                    if (promiseLT64 || constexpr.ALL_LT_EPU64(a, 64))
                    {
                        return Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi64(b, a), b);
                    }
                    else
                    {
                        v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi64(a, mm256_set1_epi64x(64));

                        return mm256_ternarylogic_si256(isMaxBitsMask, b, Avx2.mm256_sllv_epi64(b, a), TernaryOperation.OxF4);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a 128-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitmask128(ulong numBits, ulong index = 0)
        {
Assert.IsBetween(index, 0u, 127u);
Assert.IsBetween(numBits, 0u, 128ul - index);

            if (constexpr.IS_TRUE(numBits != 0))
            {
                return bits_masktolowest((UInt128)1 << ((int)numBits - 1)) << (int)index;
            }
            else
            {
                return ((((UInt128)1 << (int)numBits) - 1) << (int)index) | ((UInt128)0 - tobyte(numBits == 128));
            }
        }

        /// <summary>       Returns a 128-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bitmask128(long numBits, long index = 0) => (Int128)bitmask128((ulong)numBits, (ulong)index);


        /// <summary>       Returns an 8-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bitmask8(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 7u);
Assert.IsBetween(numBits, 0u, 8u - index);

            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return (byte)(bits_masktolowest(1u << ((int)numBits - 1)) << (int)index);
                }
            }

            return (byte)(((1 << (int)numBits) - 1) << (int)index);
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bitmask8(byte2 numBits, byte2 index = default(byte2))
        {
VectorAssert.IsBetween<byte2, byte>(index, 0, 7, 2);
VectorAssert.IsBetween<byte2, byte>(numBits, 0, 8 - index, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 2);
            }
            else
            {
                return new byte2(bitmask8((uint)numBits.x, index.x),
                                 bitmask8((uint)numBits.y, index.y));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bitmask8(byte3 numBits, byte3 index = default(byte3))
        {
VectorAssert.IsBetween<byte3, byte>(index, 0, 7, 3);
VectorAssert.IsBetween<byte3, byte>(numBits, 0, 8 - index, 3);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 3);
            }
            else
            {
                return new byte3(bitmask8((uint)numBits.x, index.x),
                                 bitmask8((uint)numBits.y, index.y),
                                 bitmask8((uint)numBits.z, index.z));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bitmask8(byte4 numBits, byte4 index = default(byte4))
        {
VectorAssert.IsBetween<byte4, byte>(index, 0, 7, 4);
VectorAssert.IsBetween<byte4, byte>(numBits, 0, 8 - index, 4);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 4);
            }
            else
            {
                return new byte4(bitmask8((uint)numBits.x, index.x),
                                 bitmask8((uint)numBits.y, index.y),
                                 bitmask8((uint)numBits.z, index.z),
                                 bitmask8((uint)numBits.w, index.w));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bitmask8(byte8 numBits, byte8 index = default(byte8))
        {
VectorAssert.IsBetween<byte8, byte>(index, 0, 7, 8);
VectorAssert.IsBetween<byte8, byte>(numBits, 0, 8 - index, 8);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 8);
            }
            else
            {
                return new byte8(bitmask8((uint)numBits.x0, index.x0),
                                 bitmask8((uint)numBits.x1, index.x1),
                                 bitmask8((uint)numBits.x2, index.x2),
                                 bitmask8((uint)numBits.x3, index.x3),
                                 bitmask8((uint)numBits.x4, index.x4),
                                 bitmask8((uint)numBits.x5, index.x5),
                                 bitmask8((uint)numBits.x6, index.x6),
                                 bitmask8((uint)numBits.x7, index.x7));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bitmask8(byte16 numBits, byte16 index = default(byte16))
        {
VectorAssert.IsBetween<byte16, byte>(index, 0, 7, 16);
VectorAssert.IsBetween<byte16, byte>(numBits, 0, 8 - index, 16);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 16);
            }
            else
            {
                return new byte16(bitmask8((uint)numBits.x0,  index.x0),
                                  bitmask8((uint)numBits.x1,  index.x1),
                                  bitmask8((uint)numBits.x2,  index.x2),
                                  bitmask8((uint)numBits.x3,  index.x3),
                                  bitmask8((uint)numBits.x4,  index.x4),
                                  bitmask8((uint)numBits.x5,  index.x5),
                                  bitmask8((uint)numBits.x6,  index.x6),
                                  bitmask8((uint)numBits.x7,  index.x7),
                                  bitmask8((uint)numBits.x8,  index.x8),
                                  bitmask8((uint)numBits.x9,  index.x9),
                                  bitmask8((uint)numBits.x10, index.x10),
                                  bitmask8((uint)numBits.x11, index.x11),
                                  bitmask8((uint)numBits.x12, index.x12),
                                  bitmask8((uint)numBits.x13, index.x13),
                                  bitmask8((uint)numBits.x14, index.x14),
                                  bitmask8((uint)numBits.x15, index.x15));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bitmask8(byte32 numBits, byte32 index = default(byte32))
        {
VectorAssert.IsBetween<byte32, byte>(index, 0, 7, 32);
VectorAssert.IsBetween<byte32, byte>(numBits, 0, 8 - index, 32);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi8(numBits, index);
            }
            else
            {
                return new byte32(bitmask8(numBits.v16_0, index.v16_0), bitmask8(numBits.v16_16, index.v16_16));
            }
        }


        /// <summary>       Returns a 16-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bitmask16(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 15u);
Assert.IsBetween(numBits, 0u, 16u - index);

            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return (ushort)(bits_masktolowest(1u << ((int)numBits - 1)) << (int)index);
                }
            }

            return (ushort)(((1 << (int)numBits) - 1) << (int)index);
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bitmask16(ushort2 numBits, ushort2 index = default(ushort2))
        {
VectorAssert.IsBetween<ushort2, ushort>(index, 0, 15, 2);
VectorAssert.IsBetween<ushort2, ushort>(numBits, 0, 16 - index, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 2);
            }
            else
            {
                return new ushort2(bitmask16((uint)numBits.x, index.x),
                                   bitmask16((uint)numBits.y, index.y));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bitmask16(ushort3 numBits, ushort3 index = default(ushort3))
        {
VectorAssert.IsBetween<ushort3, ushort>(index, 0, 15, 3);
VectorAssert.IsBetween<ushort3, ushort>(numBits, 0, 16 - index, 3);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 3);
            }
            else
            {
                return new ushort3(bitmask16((uint)numBits.x, index.x),
                                   bitmask16((uint)numBits.y, index.y),
                                   bitmask16((uint)numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bitmask16(ushort4 numBits, ushort4 index = default(ushort4))
        {
VectorAssert.IsBetween<ushort4, ushort>(index, 0, 15, 4);
VectorAssert.IsBetween<ushort4, ushort>(numBits, 0, 16 - index, 4);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 4);
            }
            else
            {
                return new ushort4(bitmask16((uint)numBits.x, index.x),
                                   bitmask16((uint)numBits.y, index.y),
                                   bitmask16((uint)numBits.z, index.z),
                                   bitmask16((uint)numBits.w, index.w));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bitmask16(ushort8 numBits, ushort8 index = default(ushort8))
        {
VectorAssert.IsBetween<ushort8, ushort>(index, 0, 15, 8);
VectorAssert.IsBetween<ushort8, ushort>(numBits, 0, 16 - index, 8);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 8);
            }
            else
            {
                return new ushort8(bitmask16((uint)numBits.x0, index.x0),
                                   bitmask16((uint)numBits.x1, index.x1),
                                   bitmask16((uint)numBits.x2, index.x2),
                                   bitmask16((uint)numBits.x3, index.x3),
                                   bitmask16((uint)numBits.x4, index.x4),
                                   bitmask16((uint)numBits.x5, index.x5),
                                   bitmask16((uint)numBits.x6, index.x6),
                                   bitmask16((uint)numBits.x7, index.x7));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.ushort8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bitmask16(ushort16 numBits, ushort16 index = default(ushort16))
        {
VectorAssert.IsBetween<ushort16, ushort>(index, 0, 15, 16);
VectorAssert.IsBetween<ushort16, ushort>(numBits, 0, 16 - index, 16);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi16(numBits, index);
            }
            else
            {
                return new ushort16(bitmask16(numBits.v8_0, index.v8_0), bitmask16(numBits.v8_8, index.v8_8));
            }
        }


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitmask32(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 31u);
Assert.IsBetween(numBits, 0u, 32u - index);

            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return bits_masktolowest(1u << ((int)numBits - 1)) << (int)index;
                }
            }

            return (uint)(((1ul << (int)numBits) - 1) << (int)index);
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(uint2 numBits, uint2 index = default(uint2))
        {
VectorAssert.IsBetween<uint2, uint>(index, 0, 31, 2);
VectorAssert.IsBetween<uint2, uint>(numBits, 0, 32 - index, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.bitmask_epi32(RegisterConversion.ToV128(numBits), RegisterConversion.ToV128(index), 2));
            }
            else
            {
                return new uint2(bitmask32(numBits.x, index.x),
                                 bitmask32(numBits.y, index.y));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(uint3 numBits, uint3 index = default(uint3))
        {
VectorAssert.IsBetween<uint3, uint>(index, 0, 31, 3);
VectorAssert.IsBetween<uint3, uint>(numBits, 0, 32 - index, 3);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.bitmask_epi32(RegisterConversion.ToV128(numBits), RegisterConversion.ToV128(index), 3));
            }
            else
            {
                return new uint3(bitmask32(numBits.x, index.x),
                                 bitmask32(numBits.y, index.y),
                                 bitmask32(numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(uint4 numBits, uint4 index = default(uint4))
        {
VectorAssert.IsBetween<uint4, uint>(index, 0, 31, 4);
VectorAssert.IsBetween<uint4, uint>(numBits, 0, 32 - index, 4);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.bitmask_epi32(RegisterConversion.ToV128(numBits), RegisterConversion.ToV128(index), 4));
            }
            else
            {
                return new uint4(bitmask32(numBits.x, index.x),
                                 bitmask32(numBits.y, index.y),
                                 bitmask32(numBits.z, index.z),
                                 bitmask32(numBits.w, index.w));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="MaxMath.uint8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(uint8 numBits, uint8 index = default(uint8))
        {
VectorAssert.IsBetween<uint8, uint>(index, 0, 31, 8);
VectorAssert.IsBetween<uint8, uint>(numBits, 0, 32 - index, 8);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi32(numBits, index);
            }
            else
            {
                return new uint8(bitmask32(numBits.v4_0, index.v4_0), bitmask32(numBits.v4_4, index.v4_4));
            }
        }


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64(ulong numBits, ulong index = 0)
        {
Assert.IsBetween(index, 0ul, 63ul);
Assert.IsBetween(numBits, 0ul, 64ul - index);

            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return bits_masktolowest(1ul << ((int)numBits - 1)) << (int)index;
                }
            }

            return (((1ul << (int)numBits) - 1) << (int)index) | (0 - toulong(numBits == 64));
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.ulong2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(ulong2 numBits, ulong2 index = default(ulong2))
        {
VectorAssert.IsBetween<ulong2, ulong>(index, 0, 63, 2);
VectorAssert.IsBetween<ulong2, ulong>(numBits, 0, 64 - index, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi64(numBits, index);
            }
            else
            {
                return new ulong2(bitmask64(numBits.x, index.x),
                                  bitmask64(numBits.y, index.y));
            }
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.ulong3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(ulong3 numBits, ulong3 index = default(ulong3))
        {
VectorAssert.IsBetween<ulong3, ulong>(index, 0, 63, 3);
VectorAssert.IsBetween<ulong3, ulong>(numBits, 0, 64 - index, 3);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi64(numBits, index);
            }
            else
            {
                return new ulong3(bitmask64(numBits._xy, index._xy), bitmask64(numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.ulong4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(ulong4 numBits, ulong4 index = default(ulong4))
        {
VectorAssert.IsBetween<ulong4, ulong>(index, 0, 63, 4);
VectorAssert.IsBetween<ulong4, ulong>(numBits, 0, 64 - index, 4);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi64(numBits, index);
            }
            else
            {
                return new ulong4(bitmask64(numBits._xy, index._xy), bitmask64(numBits._zw, index._zw));
            }
        }


        /// <summary>       Returns an 8-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bitmask8(int numBits, int index = 0) => (sbyte)bitmask8((uint)numBits, (uint)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bitmask8(sbyte2 numBits, sbyte2 index = default(sbyte2)) => (sbyte2)bitmask8((byte2)numBits, (byte2)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bitmask8(sbyte3 numBits, sbyte3 index = default(sbyte3)) => (sbyte3)bitmask8((byte3)numBits, (byte3)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bitmask8(sbyte4 numBits, sbyte4 index = default(sbyte4)) => (sbyte4)bitmask8((byte4)numBits, (byte4)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bitmask8(sbyte8 numBits, sbyte8 index = default(sbyte8)) => (sbyte8)bitmask8((byte8)numBits, (byte8)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bitmask8(sbyte16 numBits, sbyte16 index = default(sbyte16)) => (sbyte16)bitmask8((byte16)numBits, (byte16)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="MaxMath.sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bitmask8(sbyte32 numBits, sbyte32 index = default(sbyte32)) => (sbyte32)bitmask8((byte32)numBits, (byte32)index);


        /// <summary>       Returns a 16-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bitmask16(int numBits, int index = 0) => (short)bitmask16((uint)numBits, (uint)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bitmask16(short2 numBits, short2 index = default(short2)) => (short2)bitmask16((ushort2)numBits, (ushort2)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bitmask16(short3 numBits, short3 index = default(short3)) => (short3)bitmask16((ushort3)numBits, (ushort3)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bitmask16(short4 numBits, short4 index = default(short4)) => (short4)bitmask16((ushort4)numBits, (ushort4)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bitmask16(short8 numBits, short8 index = default(short8)) => (short8)bitmask16((ushort8)numBits, (ushort8)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="MaxMath.short8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bitmask16(short16 numBits, short16 index = default(short16)) => (short16)bitmask16((ushort16)numBits, (ushort16)index);


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask32(int numBits, int index = 0) => (int)bitmask32((uint)numBits, (uint)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bitmask32(int2 numBits, int2 index = default(int2)) => (int2)bitmask32((uint2)numBits, (uint2)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bitmask32(int3 numBits, int3 index = default(int3)) => (int3)bitmask32((uint3)numBits, (uint3)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bitmask32(int4 numBits, int4 index = default(int4)) => (int4)bitmask32((uint4)numBits, (uint4)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="MaxMath.int8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bitmask32(int8 numBits, int8 index = default(int8)) => (int8)bitmask32((uint8)numBits, (uint8)index);


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bitmask64(long numBits, long index = 0) => (long)bitmask64((ulong)numBits, (ulong)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.long2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bitmask64(long2 numBits, long2 index = default(long2)) => (long2)bitmask64((ulong2)numBits, (ulong2)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.long3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bitmask64(long3 numBits, long3 index = default(long3)) => (long3)bitmask64((ulong3)numBits, (ulong3)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="MaxMath.long4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bitmask64(long4 numBits, long4 index = new long4()) => (long4)bitmask64((ulong4)numBits, (ulong4)index);
    }
}