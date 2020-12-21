using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Wojciech Mula's algorithm
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte32 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 countbits(byte32 x)
        {
            byte32 lookup = new byte32(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4, 
                                       0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);

            byte32 mask = new byte32(0x0F);
        
            byte32 countLo = Avx2.mm256_shuffle_epi8(lookup, x & mask);
            byte32 countHi = Avx2.mm256_shuffle_epi8(lookup, Avx2.mm256_srli_epi16(x, 4) & mask);
        
            return countLo + countHi;
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte16 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 countbits(byte16 x)
        {
            byte16 lookup = new byte16(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);
            byte16 mask = new byte16(0x0F);

            byte16 countLo = Ssse3.shuffle_epi8(lookup, x & mask);
            byte16 countHi = Ssse3.shuffle_epi8(lookup, Sse2.srli_epi16(x, 4) & mask);

            return countLo + countHi;
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 countbits(byte8 x)
        {
            return (v128)countbits((byte16)(v128)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 countbits(byte4 x)
        {
            return (v128)countbits((byte16)(v128)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 countbits(byte3 x)
        {
            return (v128)countbits((byte16)(v128)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte2 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 countbits(byte2 x)
        {
            return new byte2((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y));
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte32 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 countbits(sbyte32 x)
        {
            return (v256)countbits((byte32)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte16 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 countbits(sbyte16 x)
        {
            return (v128)countbits((byte16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 countbits(sbyte8 x)
        {
            return (v128)countbits((byte16)(v128)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 countbits(sbyte4 x)
        {
            return (v128)countbits((byte16)(v128)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 countbits(sbyte3 x)
        {
            return (v128)countbits((byte16)(v128)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte2 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 countbits(sbyte2 x)
        {
            return new sbyte2((sbyte)math.countbits((uint)(byte)x.x), (sbyte)math.countbits((uint)(byte)x.y));
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort16 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 countbits(ushort16 x)
        {
            ushort16 byteBits = (v256)countbits((byte32)(v256)x);

            return (byteBits & 0x00FF) + (byteBits >> 8);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 countbits(ushort8 x)
        {
            ushort8 byteBits = (v128)countbits((byte16)(v128)x);

            return (byteBits & 0x00FF) + (byteBits >> 8);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 countbits(ushort4 x)
        {
            ushort4 byteBits = (v128)countbits((byte16)(v128)x);

            return (byteBits & 0x00FF) + (byteBits >> 8);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 countbits(ushort3 x)
        {
            return new ushort3((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y), (ushort)math.countbits((uint)x.z));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort2 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 countbits(ushort2 x)
        {
            return new ushort2((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y));
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short16 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 countbits(short16 x)
        {
            short16 byteBits = (v256)countbits((byte32)(v256)x);

            return (byteBits & 0x00FF) + (byteBits >> 8);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 countbits(short8 x)
        {
            short8 byteBits = (v128)countbits((byte16)(v128)x);

            return (byteBits & 0x00FF) + (byteBits >> 8);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 countbits(short4 x)
        {
            short4 byteBits = (v128)countbits((byte16)(v128)x);

            return (byteBits & 0x00FF) + (byteBits >> 8);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 countbits(short3 x)
        {
            return new short3((short)math.countbits((uint)(ushort)x.x), (short)math.countbits((uint)(ushort)x.y), (short)math.countbits((uint)(ushort)x.z));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short2 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 countbits(short2 x)
        {
            return new short2((short)math.countbits((uint)(ushort)x.x), (short)math.countbits((uint)(ushort)x.y));
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a uint8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 countbits(uint8 x)
        {
            x -= (x >> 1) & 0x5555_5555;
            x = (x & 0x3333_3333) + ((x >> 2) & 0x3333_3333);
            return (((x + (x >> 4)) & 0x0F0F_0F0F) * 0x0101_0101) >> 24;
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an int8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countbits(int8 x)
        {
            return (int8)countbits((uint8)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ulong2 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 countbits(ulong2 x)
        {
            return new ulong2((uint)math.countbits(x.x), (uint)math.countbits(x.y));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ulong3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 countbits(ulong3 x)
        {
            return new ulong3((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ulong4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 countbits(ulong4 x)
        {
            return new ulong4((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z), (uint)math.countbits(x.w));
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a long2 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 countbits(long2 x)
        {
            return new long2((uint)math.countbits(x.x), (uint)math.countbits(x.y));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a long3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 countbits(long3 x)
        {
            return new long3((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a long4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 countbits(long4 x)
        {
            return new long4((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z), (uint)math.countbits(x.w));
        }
    }
}
