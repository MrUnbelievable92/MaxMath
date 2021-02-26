using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Wojciech Mula's algorithm
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the number of 1-bits in the binary representation of a contiguous block of memory from the memory address ptr to ptr + bytes.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong countbits(void* ptr, ulong bytes)
        {
Assert.IsNotNull(ptr);

            if (Avx2.IsAvx2Supported)
            {
                // cannot enforce aligned loads :( doesn't matter in case Avx2 is supported, anyway
                
                ulong bits = 0;
                byte32 sum;


                while (bytes >= 31 * 32)
                {
                    sum = countbits(*(byte32*)ptr);

                    ptr = (byte32*)ptr + 1;


                    // floor(255 / 8) = 31 (maximum byte value divided by maximum set bits in a byte)
                    // => 31 is the maximum amount of additions of byte vectors before the column sum has to be calculated
                    for (int i = 1; i < 31; i++)
                    {
                        sum += countbits(*(byte32*)ptr);

                        ptr = (byte32*)ptr + 1;
                    }
                
                    bits += csum(sum);
                    bytes -= 31 * 32;
                }


                sum = byte32.zero;

                while (bytes >= 32)
                {
                    sum += countbits(*(byte32*)ptr);

                    ptr = (byte32*)ptr + 1;
                    bytes -= 32;
                }

                bits += csum(sum);


                while(bytes >= 8)
                {
                    bits += (ulong)math.countbits(*(ulong*)ptr);

                    ptr = (ulong*)ptr + 1;
                    bytes -= 8;
                }


                while(bytes != 0)
                {
                    bits += (ulong)math.countbits((uint)*((byte*)ptr));

                    ptr = (byte*)ptr + 1;
                    bytes--;
                }


                return bits;
            }
            else if (Ssse3.IsSsse3Supported)
            {
                // cannot enforce aligned loads :(

                ulong bits = 0;
                byte16 sum;


                while (bytes >= 31 * 16)
                {
                    sum = countbits(*(byte16*)ptr);

                    ptr = (byte16*)ptr + 1;


                    // floor(255 / 8) = 31 (maximum byte value divided by maximum set bits in a byte)
                    // => 31 is the maximum amount of additions of byte vectors before the column sum has to be calculated
                    for (int i = 1; i < 31; i++)
                    {
                        sum += countbits(*(byte16*)ptr);

                        ptr = (byte16*)ptr + 1;
                    }

                    bits += csum(sum);
                    bytes -= 31 * 16;
                }


                sum = byte16.zero;

                while (bytes >= 16)
                {
                    sum += countbits(*(byte16*)ptr);

                    ptr = (byte16*)ptr + 1;
                    bytes -= 16;
                }

                bits += csum(sum);


                while (bytes >= 8)
                {
                    bits += (ulong)math.countbits(*(ulong*)ptr);

                    ptr = (ulong*)ptr + 1;
                    bytes -= 8;
                }


                while (bytes != 0)
                {
                    bits += (ulong)math.countbits((uint)*((byte*)ptr));

                    ptr = (byte*)ptr + 1;
                    bytes--;
                }


                return bits;
            }
            else
            {
                ulong longs = divrem(bytes, 8, out ulong residuals);

                ulong bits = 0;


                for (ulong i = 0; i < longs; i++)
                {
                    bits += (ulong)math.countbits(*((ulong*)ptr + i));
                }

                ptr = (ulong*)ptr + longs;

                while (residuals != 0)
                {
                    bits += (ulong)math.countbits((uint)(*(byte*)ptr));

                    ptr = (byte*)ptr + 1;
                    residuals--;
                }

                return bits;
            }
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte32 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 countbits(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 lookup = new byte32(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4,
                                           0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);

                byte32 mask = new byte32(0x0F);

                byte32 countLo = Avx2.mm256_shuffle_epi8(lookup, x & mask);
                byte32 countHi = Avx2.mm256_shuffle_epi8(lookup, Avx2.mm256_srli_epi16(x, 4) & mask);

                return countLo + countHi;
            }
            else
            {
                return new byte32(countbits(x.v16_0), countbits(x.v16_16));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte16 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 countbits(byte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                byte16 lookup = new byte16(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);
                byte16 mask = new byte16(0x0F);

                byte16 countLo = Ssse3.shuffle_epi8(lookup, x & mask);
                byte16 countHi = Ssse3.shuffle_epi8(lookup, Sse2.srli_epi16(x, 4) & mask);

                return countLo + countHi;
            }
            else
            {
                return new byte16((byte)math.countbits((uint)x.x0), (byte)math.countbits((uint)x.x1), (byte)math.countbits((uint)x.x2), (byte)math.countbits((uint)x.x3), (byte)math.countbits((uint)x.x4), (byte)math.countbits((uint)x.x5), (byte)math.countbits((uint)x.x6), (byte)math.countbits((uint)x.x7), (byte)math.countbits((uint)x.x8), (byte)math.countbits((uint)x.x9), (byte)math.countbits((uint)x.x10), (byte)math.countbits((uint)x.x11), (byte)math.countbits((uint)x.x12), (byte)math.countbits((uint)x.x13), (byte)math.countbits((uint)x.x14), (byte)math.countbits((uint)x.x15));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 countbits(byte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return (v128)countbits((byte16)(v128)x);
            }
            else
            {
                return new byte8((byte)math.countbits((uint)x.x0), (byte)math.countbits((uint)x.x1), (byte)math.countbits((uint)x.x2), (byte)math.countbits((uint)x.x3), (byte)math.countbits((uint)x.x4), (byte)math.countbits((uint)x.x5), (byte)math.countbits((uint)x.x6), (byte)math.countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 countbits(byte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return (v128)countbits((byte16)(v128)x);
            }
            else
            {
                return new byte4((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y), (byte)math.countbits((uint)x.z), (byte)math.countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a byte3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 countbits(byte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return (v128)countbits((byte16)(v128)x);
            }
            else
            {
                return new byte3((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y), (byte)math.countbits((uint)x.z));
            }
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
            return (sbyte32)countbits((byte32)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte16 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 countbits(sbyte16 x)
        {
            return (sbyte16)countbits((byte16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 countbits(sbyte8 x)
        {
            return (sbyte8)countbits((byte8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 countbits(sbyte4 x)
        {
            return (sbyte4)countbits((byte4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an sbyte3 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 countbits(sbyte3 x)
        {
            return (sbyte3)countbits((byte3)x);
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
            if (Avx2.IsAvx2Supported)
            {
                ushort16 byteBits = (v256)countbits((byte32)(v256)x);

                return (byteBits & 0x00FF) + (byteBits >> 8);
            }
            else
            {
                return new ushort16(countbits(x.v8_0), countbits(x.v8_8));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 countbits(ushort8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                ushort8 byteBits = (v128)countbits((byte16)(v128)x);

                return (byteBits & 0x00FF) + (byteBits >> 8);
            }
            else
            {
                return new ushort8((ushort)math.countbits((uint)x.x0), (ushort)math.countbits((uint)x.x1), (ushort)math.countbits((uint)x.x2), (ushort)math.countbits((uint)x.x3), (ushort)math.countbits((uint)x.x4), (ushort)math.countbits((uint)x.x5), (ushort)math.countbits((uint)x.x6), (ushort)math.countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a ushort4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 countbits(ushort4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                ushort4 byteBits = (v128)countbits((byte16)(v128)x);

                return (byteBits & 0x00FF) + (byteBits >> 8);
            }
            else
            {
                return new ushort4((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y), (ushort)math.countbits((uint)x.z), (ushort)math.countbits((uint)x.w));
            }
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
            return (short16)countbits((ushort16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short8 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 countbits(short8 x)
        {
            return (short8)countbits((short8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a short4 vector. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 countbits(short4 x)
        {
            return (short4)countbits((short4)x);
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
