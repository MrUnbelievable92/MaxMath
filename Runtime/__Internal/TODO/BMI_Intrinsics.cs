using System.Runtime.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extractlowest(Int128 x)
        {
            return (Int128)bits_extractlowest((UInt128)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_resetlowest(Int128 x)
        {
            return (Int128)bits_resetlowest((UInt128)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_masktolowest(Int128 x)
        {
            return (Int128)bits_masktolowest((UInt128)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="Int128"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extract(Int128 x, int index, int length)
        {
            return (Int128)bits_extract((UInt128)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_zerohigh(Int128 x, int startIndex)
        { 
            return (Int128)bits_zerohigh((UInt128)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_depositparallel(Int128 x, Int128 mask)
        {
            return (Int128)bits_depositparallel((UInt128)x, (UInt128)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extractparallel(Int128 x, Int128 mask)
        {
            return (Int128)bits_extractparallel((UInt128)x, (UInt128)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractlowest(byte x)
        {
            return (byte)bits_extractlowest((uint)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_resetlowest(byte x)
        {
            return (byte)bits_resetlowest((uint)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_masktolowest(byte x)
        {
            return (byte)bits_masktolowest((uint)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="byte"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extract(byte x, int index, int length)
        {
            return (byte)bits_extract((uint)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_zerohigh(byte x, int startIndex)
        {
            return (byte)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_depositparallel(byte x, byte mask)
        {
            return (byte)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractparallel(byte x, byte mask)
        {
            return (byte)bits_extractparallel((uint)x, (uint)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extractlowest(sbyte x)
        {
            return (sbyte)bits_extractlowest((byte)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_resetlowest(sbyte x)
        {
            return (sbyte)bits_resetlowest((byte)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_masktolowest(sbyte x)
        {
            return (sbyte)bits_masktolowest((byte)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="sbyte"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extract(sbyte x, int index, int length)
        {
            return (sbyte)bits_extract((byte)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_zerohigh(sbyte x, int startIndex)
        {
            return (sbyte)bits_zerohigh((byte)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_depositparallel(sbyte x, sbyte mask)
        {
            return (sbyte)bits_depositparallel((byte)x, (byte)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extractparallel(sbyte x, sbyte mask)
        {
            return (sbyte)bits_extractparallel((byte)x, (byte)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extractlowest(short x)
        {
            return (short)bits_extractlowest((ushort)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_resetlowest(short x)
        {
            return (short)bits_resetlowest((ushort)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_masktolowest(short x)
        {
            return (short)bits_masktolowest((ushort)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="short"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extract(short x, int index, int length)
        {
            return (short)bits_extract((ushort)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_zerohigh(short x, int startIndex)
        {
            return (short)bits_zerohigh((ushort)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_depositparallel(short x, short mask)
        {
            return (short)bits_depositparallel((ushort)x, (ushort)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extractparallel(short x, short mask)
        {
            return (short)bits_extractparallel((ushort)x, (ushort)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extractlowest(ushort x)
        {
            return (ushort)bits_extractlowest((uint)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_resetlowest(ushort x)
        {
            return (ushort)bits_resetlowest((uint)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_masktolowest(ushort x)
        {
            return (ushort)bits_masktolowest((uint)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="ushort"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extract(ushort x, int index, int length)
        {
            return (ushort)bits_extract((uint)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_zerohigh(ushort x, int startIndex)
        {
            return (ushort)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_depositparallel(ushort x, ushort mask)
        {
            return (ushort)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extractparallel(ushort x, ushort mask)
        {
            return (ushort)bits_extractparallel((uint)x, (uint)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extractlowest(UInt128 x)
        {
            return x & (UInt128)(-(Int128)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_resetlowest(UInt128 x)
        {
            return x & (x - 1);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_masktolowest(UInt128 x)
        {
            return x ^ (x - 1);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="UInt128"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extract(UInt128 x, int index, int length)
        {
            return (x >> index) & (((UInt128)1u << length) - 1);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_zerohigh(UInt128 x, int startIndex)
        {
            return andnot(x, UInt128.MaxValue << startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_depositparallel(UInt128 x, UInt128 mask)
        {
            UInt128 result = 0;

            for (UInt128 i = 1; mask != 0; i += i)
            {
                if ((x & i) != 0)
                {
                    result |= bits_extractlowest(mask);
                }
                else { }

                mask = bits_resetlowest(mask);
            }

            return result;
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extractparallel(UInt128 x, UInt128 mask)
        {
            UInt128 result = 0;

            for (UInt128 i = 1; mask != 0; i += i)
            {
                if ((x & bits_extractlowest(mask)) != 0)
                {
                    result |= i;
                }
                else { }

                mask = bits_resetlowest(mask);
            }
            return result;
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractlowest(int x)
        {
            return (int)bits_extractlowest((uint)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_resetlowest(int x)
        {
            return (int)bits_resetlowest((uint)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_masktolowest(int x)
        {
            return (int)bits_masktolowest((uint)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of an <see cref="int"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extract(int x, int index, int length)
        {
            return (int)bits_extract((uint)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_zerohigh(int x, int startIndex)
        {
            return (int)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_depositparallel(int x, int mask)
        {
            return (int)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractparallel(int x, int mask)
        {
            return (int)bits_extractparallel((uint)x, (uint)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractlowest(long x)
        {
            return (long)bits_extractlowest((ulong)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_resetlowest(long x)
        {
            return (long)bits_resetlowest((ulong)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_masktolowest(long x)
        {
            return (long)bits_masktolowest((ulong)x);
        }

        /// <summary>       Shifts a bitfield in <paramref name="x"/> of length <paramref name="length"/> and starting at bit <paramref name="index"/> to the least significant bit of a <see cref="long"/> and sets each remaining bit to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extract(long x, int index, int length)
        {
            return (long)bits_extract((ulong)x, index, length);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_zerohigh(long x, int startIndex)
        {
            return (long)bits_zerohigh((ulong)x, startIndex);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_depositparallel(long x, long mask)
        {
            return (long)bits_depositparallel((ulong)x, (ulong)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractparallel(long x, long mask)
        {
            return (long)bits_extractparallel((ulong)x, (ulong)mask);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractlowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsi_u32(x);
            }
            else
            {
                return x & (uint)-(int)x;
            }
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_resetlowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsr_u32(x);
            }
            else
            {
                return x & (x - 1);
            }
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_masktolowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsmsk_u32(x);
            }
            else
            {
                return x ^ (x - 1);
            }
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
                return (x >> index) & ((1u << length) - 1);
            }
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_zerohigh(uint x, int startIndex)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.bzhi_u32(x, (uint)startIndex);
            }
            else
            {
                return andnot(x, uint.MaxValue << startIndex);
            }
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_depositparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u32(x, mask);
            }
            else
            {
                uint result = 0;

                for (uint i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u32(x, mask);
            }
            else
            {
                uint result = 0;

                for (uint i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    {
                        result |= i;
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }
                return result;
            }
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractlowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsi_u64(x);
            }
            else
            {
                return x & (ulong)-(long)x;
            }
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_resetlowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsr_u64(x);
            }
            else
            {
                return x & (x - 1);
            }
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_masktolowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsmsk_u64(x);
            }
            else
            {
                return x ^ (x - 1);
            }
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
                return (x >> index) & ((1ul << length) - 1);
            }
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_zerohigh(ulong x, int startIndex)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.bzhi_u64(x, (uint)startIndex);
            }
            else
            {
                return andnot(x, ulong.MaxValue << startIndex);
            }
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_depositparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u64(x, mask);
            }
            else
            {
                ulong result = 0;

                for (ulong i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u64(x, mask);
            }
            else
            {
                ulong result = 0;

                for (ulong i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    { 
                        result |= i;
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }
                return result;
            }
        }


































        /*
        /// <summary>       Isolates the lowest set bit in each component of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extractlowest(byte2 x)
        {
            return x & (byte2)(-(sbyte2)x);
        }

        /// <summary>       Sets the lowest set bit in each component of <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_resetlowest(byte2 x)
        {
            return x & (x - 1);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in each component of <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_masktolowest(byte2 x)
        {
            return x ^ (x - 1);
        }

        /// <summary>       Each bitfield in <paramref name="x"/> of the corresponding length <paramref name="length"/> and starting at the respective bit index in <paramref name="index"/> is shifted to the least significant bit of a <see cref="byte"/>, with each remaining bit being set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extract(byte2 x, byte2 index, byte2 length)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (byte2)(shrl((uint2)x, (uint2)index) & (shl(1, (uint2)length) - 1));
            }
            else
            {
                return shrl(x, index) & (shl(1, length) - 1);
            }
        }

        /// <summary>       Zeros out all the high order bits of all components in <paramref name="x"/> starting at the corresponding bit index in <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_zerohigh(byte2 x, byte2 startIndex)
        {
            return andnot(x, shl(byte.MaxValue, startIndex));
        }

        /// <summary>       For each 1-bit in each component in <paramref name="mask"/>, an equal amount of contiguous low bits in the corresponding component in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in the <paramref name="mask"/> component in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_depositparallel(byte2 x, byte2 mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u32(x, mask);
            }
            else
            {
                byte2 result = 0;

                for (byte2 i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each 1-bit in each component in <paramref name="mask"/>, the corresponding bit in the corresponding component in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result component, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extractparallel(byte2 x, byte2 mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u32(x, mask);
            }
            else
            {
                byte2 result = 0;

                for (byte2 i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    {
                        result |= i;
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }
                return result;
            }
        }*/
    }
}