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
            public static v128 bextr_epi8(v128 a, v128 index, v128 length, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi8(1);

                    return and_si128(srlv_epi8(a, index, inRange: true, elements: elements), sub_epi8(sllv_epi8(ONE, length, elements: elements), ONE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bextr_epi16(v128 a, v128 index, v128 length, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(1);

                    return and_si128(srlv_epi16(a, index, inRange: true, elements: elements), sub_epi16(sllv_epi16(ONE, length, elements: elements), ONE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bextr_epi32(v128 a, v128 index, v128 length, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi32(1);

                    return and_si128(srlv_epi32(a, index, inRange: true, elements: elements), sub_epi32(sllv_epi32(ONE, length, elements: elements), ONE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bextr_epi64(v128 a, v128 index, v128 length)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi64x(1);

                    return and_si128(srlv_epi64(a, index, inRange: true), sub_epi64(sllv_epi64(ONE, length), ONE));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bextr_epi8(v256 a, v256 index, v256 length)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi8(1);

                    return Avx2.mm256_and_si256(mm256_srlv_epi8(a, index), Avx2.mm256_sub_epi8(mm256_sllv_epi8(ONE, length), ONE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bextr_epi16(v256 a, v256 index, v256 length)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi16(1);

                    return Avx2.mm256_and_si256(mm256_srlv_epi16(a, index), Avx2.mm256_sub_epi16(mm256_sllv_epi16(ONE, length), ONE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bextr_epi32(v256 a, v256 index, v256 length)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi32(1);

                    return Avx2.mm256_and_si256(Avx2.mm256_srlv_epi32(a, index), Avx2.mm256_sub_epi32(Avx2.mm256_sllv_epi32(ONE, length), ONE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bextr_epi64(v256 a, v256 index, v256 length)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi64x(1);

                    return Avx2.mm256_and_si256(Avx2.mm256_srlv_epi64(a, index), Avx2.mm256_sub_epi64(Avx2.mm256_sllv_epi64(ONE, length), ONE));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="Int128"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extract(Int128 x, int index, int length)
        {
            return (Int128)bits_extract((UInt128)x, index, length);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="UInt128"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extract(UInt128 x, int index, int length)
        {
            return (x >> index) & (UInt128)bitmask128(length);
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extract(byte x, int index, int length)
        {
            return (byte)bits_extract((uint)x, index, length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extract(byte2 x, byte2 index, byte2 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi8(x, index, length, 2);
            }
            else
            {
                return new byte2(bits_extract(x.x, index.x, length.x), bits_extract(x.y, index.y, length.y));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_extract(byte3 x, byte3 index, byte3 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi8(x, index, length, 3);
            }
            else
            {
                return new byte3(bits_extract(x.x, index.x, length.x), bits_extract(x.y, index.y, length.y), bits_extract(x.z, index.z, length.z));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_extract(byte4 x, byte4 index, byte4 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi8(x, index, length, 4);
            }
            else
            {
                return new byte4(bits_extract(x.x, index.x, length.x), bits_extract(x.y, index.y, length.y), bits_extract(x.z, index.z, length.z), bits_extract(x.w, index.w, length.w));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_extract(byte8 x, byte8 index, byte8 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi8(x, index, length, 8);
            }
            else
            {
                return new byte8(bits_extract(x.x0, index.x0, length.x0), bits_extract(x.x1, index.x1, length.x1), bits_extract(x.x2, index.x2, length.x2), bits_extract(x.x3, index.x3, length.x3), bits_extract(x.x4, index.x4, length.x4), bits_extract(x.x5, index.x5, length.x5), bits_extract(x.x6, index.x6, length.x6), bits_extract(x.x7, index.x7, length.x7));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_extract(byte16 x, byte16 index, byte16 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi8(x, index, length, 16);
            }
            else
            {
                return new byte16(bits_extract(x.x0, index.x0, length.x0), bits_extract(x.x1, index.x1, length.x1), bits_extract(x.x2, index.x2, length.x2), bits_extract(x.x3, index.x3, length.x3), bits_extract(x.x4, index.x4, length.x4), bits_extract(x.x5, index.x5, length.x5), bits_extract(x.x6, index.x6, length.x6), bits_extract(x.x7, index.x7, length.x7), bits_extract(x.x8, index.x8, length.x8), bits_extract(x.x9, index.x9, length.x9), bits_extract(x.x10, index.x10, length.x10), bits_extract(x.x11, index.x11, length.x11), bits_extract(x.x12, index.x12, length.x12), bits_extract(x.x13, index.x13, length.x13), bits_extract(x.x14, index.x14, length.x14), bits_extract(x.x15, index.x15, length.x15));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_extract(byte32 x, byte32 index, byte32 length)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bextr_epi8(x, index, length);
            }
            else
            {
                return new byte32(bits_extract(x.v16_0, index.v16_0, length.v16_0), bits_extract(x.v16_16, index.v16_16, length.v16_16));
            }
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extract(sbyte x, int index, int length)
        {
            return (sbyte)bits_extract((byte)x, index, length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_extract(sbyte2 x, sbyte2 index, sbyte2 length)
        {
            return (sbyte2)bits_extract((byte2)x, (byte2)index, (byte2)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_extract(sbyte3 x, sbyte3 index, sbyte3 length)
        {
            return (sbyte3)bits_extract((byte3)x, (byte3)index, (byte3)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_extract(sbyte4 x, sbyte4 index, sbyte4 length)
        {
            return (sbyte4)bits_extract((byte4)x, (byte4)index, (byte4)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_extract(sbyte8 x, sbyte8 index, sbyte8 length)
        {
            return (sbyte8)bits_extract((byte8)x, (byte8)index, (byte8)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_extract(sbyte16 x, sbyte16 index, sbyte16 length)
        {
            return (sbyte16)bits_extract((byte16)x, (byte16)index, (byte16)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_extract(sbyte32 x, sbyte32 index, sbyte32 length)
        {
            return (sbyte32)bits_extract((byte32)x, (byte32)index, (byte32)length);
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extract(ushort x, int index, int length)
        {
            return (ushort)bits_extract((uint)x, index, length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_extract(ushort2 x, ushort2 index, ushort2 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi16(x, index, length, 2);
            }
            else
            {
                return new ushort2(bits_extract(x.x, index.x, length.x), bits_extract(x.y, index.y, length.y));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_extract(ushort3 x, ushort3 index, ushort3 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi16(x, index, length, 3);
            }
            else
            {
                return new ushort3(bits_extract(x.x, index.x, length.x), bits_extract(x.y, index.y, length.y), bits_extract(x.z, index.z, length.z));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_extract(ushort4 x, ushort4 index, ushort4 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi16(x, index, length, 4);
            }
            else
            {
                return new ushort4(bits_extract(x.x, index.x, length.x), bits_extract(x.y, index.y, length.y), bits_extract(x.z, index.z, length.z), bits_extract(x.w, index.w, length.w));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_extract(ushort8 x, ushort8 index, ushort8 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi16(x, index, length, 8);
            }
            else
            {
                return new ushort8(bits_extract(x.x0, index.x0, length.x0), bits_extract(x.x1, index.x1, length.x1), bits_extract(x.x2, index.x2, length.x2), bits_extract(x.x3, index.x3, length.x3), bits_extract(x.x4, index.x4, length.x4), bits_extract(x.x5, index.x5, length.x5), bits_extract(x.x6, index.x6, length.x6), bits_extract(x.x7, index.x7, length.x7));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_extract(ushort16 x, ushort16 index, ushort16 length)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bextr_epi16(x, index, length);
            }
            else
            {
                return new ushort16(bits_extract(x.v8_0, index.v8_0, length.v8_0), bits_extract(x.v8_8, index.v8_8, length.v8_8));
            }
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extract(short x, int index, int length)
        {
            return (short)bits_extract((ushort)x, index, length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_extract(short2 x, short2 index, short2 length)
        {
            return (short2)bits_extract((ushort2)x, (ushort2)index, (ushort2)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_extract(short3 x, short3 index, short3 length)
        {
            return (short3)bits_extract((ushort3)x, (ushort3)index, (ushort3)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_extract(short4 x, short4 index, short4 length)
        {
            return (short4)bits_extract((ushort4)x, (ushort4)index, (ushort4)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_extract(short8 x, short8 index, short8 length)
        {
            return (short8)bits_extract((ushort8)x, (ushort8)index, (ushort8)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_extract(short16 x, short16 index, short16 length)
        {
            return (short16)bits_extract((ushort16)x, (ushort16)index, (ushort16)length);
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="uint"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extract(uint x, int index, int length)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.bextr_u32(x, (uint)index, (uint)length);
            }
            else
            {
                return (x >> index) & (uint)bitmask32(length);
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="uint"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_extract(uint2 x, uint2 index, uint2 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.bextr_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(index), RegisterConversion.ToV128(length), 2));
            }
            else
            {
                return new uint2(bits_extract(x.x, (int)index.x, (int)length.x), bits_extract(x.y, (int)index.y, (int)length.y));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="uint"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_extract(uint3 x, uint3 index, uint3 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.bextr_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(index), RegisterConversion.ToV128(length), 3));
            }
            else
            {
                return new uint3(bits_extract(x.x, (int)index.x, (int)length.x), bits_extract(x.y, (int)index.y, (int)length.y), bits_extract(x.z, (int)index.z, (int)length.z));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="uint"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_extract(uint4 x, uint4 index, uint4 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.bextr_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(index), RegisterConversion.ToV128(length), 4));
            }
            else
            {
                return new uint4(bits_extract(x.x, (int)index.x, (int)length.x), bits_extract(x.y, (int)index.y,(int) length.y), bits_extract(x.z, (int)index.z, (int)length.z), bits_extract(x.w, (int)index.w, (int)length.w));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="uint"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_extract(uint8 x, uint8 index, uint8 length)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bextr_epi32(x, index, length);
            }
            else
            {
                return new uint8(bits_extract(x.v4_0, index.v4_0, length.v4_0), bits_extract(x.v4_4, index.v4_4, length.v4_4));
            }
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="int"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extract(int x, int index, int length)
        {
            return (int)bits_extract((uint)x, index, length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="int"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_extract(int2 x, int2 index, int2 length)
        {
            return (int2)bits_extract((uint2)x, (uint2)index, (uint2)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="int"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_extract(int3 x, int3 index, int3 length)
        {
            return (int3)bits_extract((uint3)x, (uint3)index, (uint3)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="int"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_extract(int4 x, int4 index, int4 length)
        {
            return (int4)bits_extract((uint4)x, (uint4)index, (uint4)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of an <see cref="int"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_extract(int8 x, int8 index, int8 length)
        {
            return (int8)bits_extract((uint8)x, (uint8)index, (uint8)length);
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="ulong"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extract(ulong x, int index, int length)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.bextr_u64(x, (uint)index, (uint)length);
            }
            else
            {
                return (x >> index) & (ulong)bitmask64(length);
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ulong"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_extract(ulong2 x, ulong2 index, ulong2 length)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bextr_epi64(x, index, length);
            }
            else
            {
                return new ulong2(bits_extract(x.x, (int)index.x, (int)length.x), bits_extract(x.y, (int)index.y, (int)length.y));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ulong"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_extract(ulong3 x, ulong3 index, ulong3 length)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bextr_epi64(x, index, length);
            }
            else
            {
                return new ulong3(bits_extract(x.xy, index.xy, length.xy), bits_extract(x.z, (int)index.z, (int)length.z));
            }
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="ulong"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_extract(ulong4 x, ulong4 index, ulong4 length)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bextr_epi64(x, index, length);
            }
            else
            {
                return new ulong4(bits_extract(x.xy, index.xy, length.xy), bits_extract(x.zw, index.zw, length.zw));
            }
        }


        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="long"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extract(long x, int index, int length)
        {
            return (long)bits_extract((ulong)x, index, length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="long"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_extract(long2 x, long2 index, long2 length)
        {
            return (long2)bits_extract((ulong2)x, (ulong2)index, (ulong2)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="long"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_extract(long3 x, long3 index, long3 length)
        {
            return (long3)bits_extract((ulong3)x, (ulong3)index, (ulong3)length);
        }

        /// <summary>       Shifts a bitfield in each <paramref name="x"/> component of the corresponding length <paramref name="length"/> and starting at the corresponding bit <paramref name="index"/> to the least significant bit of a <see cref="long"/> and sets each remaining bit in that component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_extract(long4 x, long4 index, long4 length)
        {
            return (long4)bits_extract((ulong4)x, (ulong4)index, (ulong4)length);
        }
    }
}