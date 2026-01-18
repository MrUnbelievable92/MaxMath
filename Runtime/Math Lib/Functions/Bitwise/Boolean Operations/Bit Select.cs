using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a bitwise selection between two <see cref="UInt128"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_select(UInt128 a, UInt128 b, UInt128 c)
        {
            return andnot(a, c) | (b & c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="Int128"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_select(Int128 a, Int128 b, Int128 c)
        {
            return (Int128)bits_select((UInt128)a, (UInt128)b, (UInt128)c);
        }


        /// <summary>       Returns a bitwise selection between two <see cref="byte"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_select(byte a, byte b, byte c)
        {
            return (byte)bits_select((uint)a, (uint)b, (uint)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.byte2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_select(byte2 a, byte2 b, byte2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new byte2(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.byte3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_select(byte3 a, byte3 b, byte3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new byte3(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y), bits_select(a.z, b.z, c.z));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.byte4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_select(byte4 a, byte4 b, byte4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new byte4(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y), bits_select(a.z, b.z, c.z), bits_select(a.w, b.w, c.w));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.byte8"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_select(byte8 a, byte8 b, byte8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new byte8(bits_select(a.x0, b.x0, c.x0),
                                 bits_select(a.x1, b.x1, c.x1),
                                 bits_select(a.x2, b.x2, c.x2),
                                 bits_select(a.x3, b.x3, c.x3),
                                 bits_select(a.x4, b.x4, c.x4),
                                 bits_select(a.x5, b.x5, c.x5),
                                 bits_select(a.x6, b.x6, c.x6),
                                 bits_select(a.x7, b.x7, c.x7));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.byte16"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_select(byte16 a, byte16 b, byte16 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new byte16(bits_select(a.x0,  b.x0,  c.x0),
                                  bits_select(a.x1,  b.x1,  c.x1),
                                  bits_select(a.x2,  b.x2,  c.x2),
                                  bits_select(a.x3,  b.x3,  c.x3),
                                  bits_select(a.x4,  b.x4,  c.x4),
                                  bits_select(a.x5,  b.x5,  c.x5),
                                  bits_select(a.x6,  b.x6,  c.x6),
                                  bits_select(a.x7,  b.x7,  c.x7),
                                  bits_select(a.x8,  b.x8,  c.x8),
                                  bits_select(a.x9,  b.x9,  c.x9),
                                  bits_select(a.x10, b.x10, c.x10),
                                  bits_select(a.x11, b.x11, c.x11),
                                  bits_select(a.x12, b.x12, c.x12),
                                  bits_select(a.x13, b.x13, c.x13),
                                  bits_select(a.x14, b.x14, c.x14),
                                  bits_select(a.x15, b.x15, c.x15));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.byte32"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_select(byte32 a, byte32 b, byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blendb_si256(a, b, c);
            }
            else
            {
                return new byte32(bits_select(a.v16_0, b.v16_0, c.v16_0), bits_select(a.v16_16, b.v16_16, c.v16_16));
            }
        }


        /// <summary>       Returns a bitwise selection between two <see cref="sbyte"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_select(sbyte a, sbyte b, sbyte c)
        {
            return (sbyte)bits_select((byte)a, (byte)b, (byte)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.sbyte2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_select(sbyte2 a, sbyte2 b, sbyte2 c)
        {
            return (sbyte2)bits_select((byte2)a, (byte2)b, (byte2)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.sbyte3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_select(sbyte3 a, sbyte3 b, sbyte3 c)
        {
            return (sbyte3)bits_select((byte3)a, (byte3)b, (byte3)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.sbyte4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_select(sbyte4 a, sbyte4 b, sbyte4 c)
        {
            return (sbyte4)bits_select((byte4)a, (byte4)b, (byte4)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.sbyte8"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_select(sbyte8 a, sbyte8 b, sbyte8 c)
        {
            return (sbyte8)bits_select((byte8)a, (byte8)b, (byte8)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.sbyte16"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_select(sbyte16 a, sbyte16 b, sbyte16 c)
        {
            return (sbyte16)bits_select((byte16)a, (byte16)b, (byte16)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.sbyte32"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_select(sbyte32 a, sbyte32 b, sbyte32 c)
        {
            return (sbyte32)bits_select((byte32)a, (byte32)b, (byte32)c);
        }


        /// <summary>       Returns a bitwise selection between two <see cref="ushort"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_select(ushort a, ushort b, ushort c)
        {
            return (ushort)bits_select((uint)a, (uint)b, (uint)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ushort2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_select(ushort2 a, ushort2 b, ushort2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new ushort2(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ushort3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_select(ushort3 a, ushort3 b, ushort3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new ushort3(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y), bits_select(a.z, b.z, c.z));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ushort4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_select(ushort4 a, ushort4 b, ushort4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new ushort4(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y), bits_select(a.z, b.z, c.z), bits_select(a.w, b.w, c.w));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ushort8"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_select(ushort8 a, ushort8 b, ushort8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new ushort8(bits_select(a.x0, b.x0, c.x0),
                                   bits_select(a.x1, b.x1, c.x1),
                                   bits_select(a.x2, b.x2, c.x2),
                                   bits_select(a.x3, b.x3, c.x3),
                                   bits_select(a.x4, b.x4, c.x4),
                                   bits_select(a.x5, b.x5, c.x5),
                                   bits_select(a.x6, b.x6, c.x6),
                                   bits_select(a.x7, b.x7, c.x7));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ushort16"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_select(ushort16 a, ushort16 b, ushort16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blendb_si256(a, b, c);
            }
            else
            {
                return new ushort16(bits_select(a.v8_0, b.v8_0, c.v8_0), bits_select(a.v8_8, b.v8_8, c.v8_8));
            }
        }


        /// <summary>       Returns a bitwise selection between two <see cref="short"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_select(short a, short b, short c)
        {
            return (short)bits_select((ushort)a, (ushort)b, (ushort)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.short2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_select(short2 a, short2 b, short2 c)
        {
            return (short2)bits_select((ushort2)a, (ushort2)b, (ushort2)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.short3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_select(short3 a, short3 b, short3 c)
        {
            return (short3)bits_select((ushort3)a, (ushort3)b, (ushort3)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.short4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_select(short4 a, short4 b, short4 c)
        {
            return (short4)bits_select((ushort4)a, (ushort4)b, (ushort4)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.short8"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_select(short8 a, short8 b, short8 c)
        {
            return (short8)bits_select((ushort8)a, (ushort8)b, (ushort8)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.short16"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_select(short16 a, short16 b, short16 c)
        {
            return (short16)bits_select((ushort16)a, (ushort16)b, (ushort16)c);
        }


        /// <summary>       Returns a bitwise selection between two <see cref="uint"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_select(uint a, uint b, uint c)
        {
            return andnot(a, c) | (b & c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="uint2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_select(uint2 a, uint2 b, uint2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blendb_si128(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return new uint2(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="uint3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_select(uint3 a, uint3 b, uint3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blendb_si128(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return new uint3(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y), bits_select(a.z, b.z, c.z));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="uint4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_select(uint4 a, uint4 b, uint4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blendb_si128(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return new uint4(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y), bits_select(a.z, b.z, c.z), bits_select(a.w, b.w, c.w));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.uint8"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_select(uint8 a, uint8 b, uint8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blendb_si256(a, b, c);
            }
            else
            {
                return new uint8(bits_select(a.v4_0, b.v4_0, c.v4_0), bits_select(a.v4_4, b.v4_4, c.v4_4));
            }
        }


        /// <summary>       Returns a bitwise selection between two <see cref="int"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_select(int a, int b, int c)
        {
            return (int)bits_select((uint)a, (uint)b, (uint)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="int2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_select(int2 a, int2 b, int2 c)
        {
            return (int2)bits_select((uint2)a, (uint2)b, (uint2)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="int3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_select(int3 a, int3 b, int3 c)
        {
            return (int3)bits_select((uint3)a, (uint3)b, (uint3)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="int4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_select(int4 a, int4 b, int4 c)
        {
            return (int4)bits_select((uint4)a, (uint4)b, (uint4)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.int8"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_select(int8 a, int8 b, int8 c)
        {
            return (int8)bits_select((uint8)a, (uint8)b, (uint8)c);
        }


        /// <summary>       Returns a bitwise selection between two <see cref="ulong"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_select(ulong a, ulong b, ulong c)
        {
            return andnot(a, c) | (b & c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ulong2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_select(ulong2 a, ulong2 b, ulong2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blendb_si128(a, b, c);
            }
            else
            {
                return new ulong2(bits_select(a.x, b.x, c.x), bits_select(a.y, b.y, c.y));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ulong3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_select(ulong3 a, ulong3 b, ulong3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blendb_si256(a, b, c);
            }
            else
            {
                return new ulong3(bits_select(a.xy, b.xy, c.xy), bits_select(a.z, b.z, c.z));
            }
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.ulong4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_select(ulong4 a, ulong4 b, ulong4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blendb_si256(a, b, c);
            }
            else
            {
                return new ulong4(bits_select(a.xy, b.xy, c.xy), bits_select(a.zw, b.zw, c.zw));
            }
        }


        /// <summary>       Returns a bitwise selection between two <see cref="long"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_select(long a, long b, long c)
        {
            return (long)bits_select((ulong)a, (ulong)b, (ulong)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.long2"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_select(long2 a, long2 b, long2 c)
        {
            return (long2)bits_select((ulong2)a, (ulong2)b, (ulong2)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.long3"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_select(long3 a, long3 b, long3 c)
        {
            return (long3)bits_select((ulong3)a, (ulong3)b, (ulong3)c);
        }

        /// <summary>       Returns a bitwise selection between two <see cref="MaxMath.long4"/>s <paramref name="a"/> and <paramref name="b"/> based on a bitmask <paramref name="c"/>. For each bit, the bit from <paramref name="b"/> is selected when the corresponding LSB order bit in <paramref name="c"/> is 1, otherwise the bit from <paramref name="a"/> is selected.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_select(long4 a, long4 b, long4 c)
        {
            return (long4)bits_select((ulong4)a, (ulong4)b, (ulong4)c);
        }
    }
}