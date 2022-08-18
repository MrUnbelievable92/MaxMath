using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

// Wojciech Mula's algorithm
namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 popcnt_epi8(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    v128 LOOKUP = new v128(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);
                    v128 MASK = Sse2.set1_epi8(0x0F);
    
                    v128 countLo = Ssse3.shuffle_epi8(LOOKUP, Sse2.and_si128(MASK, a));
                    v128 countHi = Ssse3.shuffle_epi8(LOOKUP, Sse2.and_si128(MASK, Sse2.srli_epi16(a, 4)));
    
                    return Sse2.add_epi8(countLo, countHi);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4,
                                           0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);
    
                    v256 MASK = Avx.mm256_set1_epi8(0x0F);
    
                    v256 countLo = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_and_si256(MASK, a));
                    v256 countHi = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_and_si256(MASK, Avx2.mm256_srli_epi16(a, 4)));
    
                    return Avx2.mm256_add_epi8(countLo, countHi);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 popcnt_epi16(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    v128 byteBits = popcnt_epi8(a);
    
                    v128 lo = Sse2.and_si128(byteBits, Sse2.set1_epi16(0x00FF));
                    v128 hi = Sse2.srli_epi16(byteBits, 8);
    
                    return Sse2.add_epi16(lo, hi);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 byteBits = mm256_popcnt_epi8(a);
                    v256 lo = Avx2.mm256_and_si256(byteBits, Avx.mm256_set1_epi16(0x00FF));
                    v256 hi = Avx2.mm256_srli_epi16(byteBits, 8);
    
                    return Avx2.mm256_add_epi16(lo, hi);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 popcnt_epi32(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    v128 byteBits = popcnt_epi16(a);
    
                    v128 lo = Sse2.and_si128(byteBits, Sse2.set1_epi32(0x0000_FFFF));
                    v128 hi = Sse2.srli_epi32(byteBits, 16);
    
                    return Sse2.add_epi32(lo, hi);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 shortBits = mm256_popcnt_epi16(a);
                    v256 lo = Avx2.mm256_and_si256(shortBits, Avx.mm256_set1_epi32(0x0000_FFFF));
                    v256 hi = Avx2.mm256_srli_epi32(shortBits, 16);
    
                    return Avx2.mm256_add_epi32(lo, hi);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 byteBits = mm256_popcnt_epi8(a);
    
                    return Avx2.mm256_sad_epu8(byteBits, Avx.mm256_setzero_si256());
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="UInt128"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int countbits(UInt128 x)
        {
            return math.countbits(x.lo64) + math.countbits(x.hi64);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="Int128"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int countbits(Int128 x)
        {
            return math.countbits(x.lo64) + math.countbits(x.hi64);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte32"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 countbits(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi8(x);
            }
            else
            {
                return new byte32(countbits(x.v16_0), countbits(x.v16_16));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 countbits(byte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte16((byte)math.countbits((uint)x.x0), (byte)math.countbits((uint)x.x1), (byte)math.countbits((uint)x.x2), (byte)math.countbits((uint)x.x3), (byte)math.countbits((uint)x.x4), (byte)math.countbits((uint)x.x5), (byte)math.countbits((uint)x.x6), (byte)math.countbits((uint)x.x7), (byte)math.countbits((uint)x.x8), (byte)math.countbits((uint)x.x9), (byte)math.countbits((uint)x.x10), (byte)math.countbits((uint)x.x11), (byte)math.countbits((uint)x.x12), (byte)math.countbits((uint)x.x13), (byte)math.countbits((uint)x.x14), (byte)math.countbits((uint)x.x15));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 countbits(byte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte8((byte)math.countbits((uint)x.x0), (byte)math.countbits((uint)x.x1), (byte)math.countbits((uint)x.x2), (byte)math.countbits((uint)x.x3), (byte)math.countbits((uint)x.x4), (byte)math.countbits((uint)x.x5), (byte)math.countbits((uint)x.x6), (byte)math.countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 countbits(byte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte4((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y), (byte)math.countbits((uint)x.z), (byte)math.countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 countbits(byte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte3((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y), (byte)math.countbits((uint)x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 countbits(byte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte2((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y));
            }
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="byte"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 8L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int countbits(byte x)
        {
            return math.countbits((uint)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte32"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 countbits(sbyte32 x)
        {
            return (sbyte32)countbits((byte32)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 countbits(sbyte16 x)
        {
            return (sbyte16)countbits((byte16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 countbits(sbyte8 x)
        {
            return (sbyte8)countbits((byte8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 countbits(sbyte4 x)
        {
            return (sbyte4)countbits((byte4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 countbits(sbyte3 x)
        {
            return (sbyte3)countbits((byte3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 countbits(sbyte2 x)
        {
            return (sbyte2)countbits((byte2)x);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="sbyte"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 8L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int countbits(sbyte x)
        {
            return math.countbits((uint)(byte)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 countbits(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi16(x);
            }
            else
            {
                return new ushort16(countbits(x.v8_0), countbits(x.v8_8));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 countbits(ushort8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort8((ushort)math.countbits((uint)x.x0), (ushort)math.countbits((uint)x.x1), (ushort)math.countbits((uint)x.x2), (ushort)math.countbits((uint)x.x3), (ushort)math.countbits((uint)x.x4), (ushort)math.countbits((uint)x.x5), (ushort)math.countbits((uint)x.x6), (ushort)math.countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 countbits(ushort4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort4((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y), (ushort)math.countbits((uint)x.z), (ushort)math.countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 countbits(ushort3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort3((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y), (ushort)math.countbits((uint)x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 countbits(ushort2 x)
        {
            return new ushort2((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y));
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="ushort"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 16L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int countbits(ushort x)
        {
            return math.countbits((uint)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 countbits(short16 x)
        {
            return (short16)countbits((ushort16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 countbits(short8 x)
        {
            return (short8)countbits((short8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 countbits(short4 x)
        {
            return (short4)countbits((short4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 countbits(short3 x)
        {
            return (short3)countbits((short3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 countbits(short2 x)
        {
            return (short2)countbits((short2)x);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="short"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 16L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int countbits(short x)
        {
            return math.countbits((uint)(ushort)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.uint8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 countbits(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi32(x);
            }
            else
            {
                return new uint8((uint4)math.countbits(x.v4_0), (uint4)math.countbits(x.v4_4));
            }
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.int8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countbits(int8 x)
        {
            return (int8)countbits((uint8)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ulong2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 countbits(ulong2 x)
        {
            return new ulong2((uint)math.countbits(x.x), (uint)math.countbits(x.y));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ulong3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 countbits(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new ulong3((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ulong4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 countbits(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new ulong4((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z), (uint)math.countbits(x.w));
            }
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.long2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 countbits(long2 x)
        {
            return new long2((uint)math.countbits(x.x), (uint)math.countbits(x.y));
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.long3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 countbits(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new long3((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.long4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 countbits(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new long4((uint)math.countbits(x.x), (uint)math.countbits(x.y), (uint)math.countbits(x.z), (uint)math.countbits(x.w));
            }
        }
    }
}