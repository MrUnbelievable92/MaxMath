using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = or_si128(a, neg_epi8(a));

                    Assume.bits_maskfromlowest(result.Byte0,  a.Byte0);
                    Assume.bits_maskfromlowest(result.Byte1,  a.Byte1);
                    Assume.bits_maskfromlowest(result.Byte2,  a.Byte2);
                    Assume.bits_maskfromlowest(result.Byte3,  a.Byte3);
                    Assume.bits_maskfromlowest(result.Byte4,  a.Byte4);
                    Assume.bits_maskfromlowest(result.Byte5,  a.Byte5);
                    Assume.bits_maskfromlowest(result.Byte6,  a.Byte6);
                    Assume.bits_maskfromlowest(result.Byte7,  a.Byte7);
                    Assume.bits_maskfromlowest(result.Byte8,  a.Byte8);
                    Assume.bits_maskfromlowest(result.Byte9,  a.Byte9);
                    Assume.bits_maskfromlowest(result.Byte10, a.Byte10);
                    Assume.bits_maskfromlowest(result.Byte11, a.Byte11);
                    Assume.bits_maskfromlowest(result.Byte12, a.Byte12);
                    Assume.bits_maskfromlowest(result.Byte13, a.Byte13);
                    Assume.bits_maskfromlowest(result.Byte14, a.Byte14);
                    Assume.bits_maskfromlowest(result.Byte15, a.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = or_si128(a, neg_epi16(a));

                    Assume.bits_maskfromlowest(result.UShort0, a.UShort0);
                    Assume.bits_maskfromlowest(result.UShort1, a.UShort1);
                    Assume.bits_maskfromlowest(result.UShort2, a.UShort2);
                    Assume.bits_maskfromlowest(result.UShort3, a.UShort3);
                    Assume.bits_maskfromlowest(result.UShort4, a.UShort4);
                    Assume.bits_maskfromlowest(result.UShort5, a.UShort5);
                    Assume.bits_maskfromlowest(result.UShort6, a.UShort6);
                    Assume.bits_maskfromlowest(result.UShort7, a.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = or_si128(a, neg_epi32(a));

                    Assume.bits_maskfromlowest(result.UInt0, a.UInt0);
                    Assume.bits_maskfromlowest(result.UInt1, a.UInt1);
                    Assume.bits_maskfromlowest(result.UInt2, a.UInt2);
                    Assume.bits_maskfromlowest(result.UInt3, a.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = or_si128(a, neg_epi64(a));

                    Assume.bits_maskfromlowest(result.ULong0, a.ULong0);
                    Assume.bits_maskfromlowest(result.ULong1, a.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_or_si256(a, mm256_neg_epi8(a));

                    Assume.bits_maskfromlowest(result.Byte0,  a.Byte0);
                    Assume.bits_maskfromlowest(result.Byte1,  a.Byte1);
                    Assume.bits_maskfromlowest(result.Byte2,  a.Byte2);
                    Assume.bits_maskfromlowest(result.Byte3,  a.Byte3);
                    Assume.bits_maskfromlowest(result.Byte4,  a.Byte4);
                    Assume.bits_maskfromlowest(result.Byte5,  a.Byte5);
                    Assume.bits_maskfromlowest(result.Byte6,  a.Byte6);
                    Assume.bits_maskfromlowest(result.Byte7,  a.Byte7);
                    Assume.bits_maskfromlowest(result.Byte8,  a.Byte8);
                    Assume.bits_maskfromlowest(result.Byte9,  a.Byte9);
                    Assume.bits_maskfromlowest(result.Byte10, a.Byte10);
                    Assume.bits_maskfromlowest(result.Byte11, a.Byte11);
                    Assume.bits_maskfromlowest(result.Byte12, a.Byte12);
                    Assume.bits_maskfromlowest(result.Byte13, a.Byte13);
                    Assume.bits_maskfromlowest(result.Byte14, a.Byte14);
                    Assume.bits_maskfromlowest(result.Byte15, a.Byte15);
                    Assume.bits_maskfromlowest(result.Byte16, a.Byte16);
                    Assume.bits_maskfromlowest(result.Byte17, a.Byte17);
                    Assume.bits_maskfromlowest(result.Byte18, a.Byte18);
                    Assume.bits_maskfromlowest(result.Byte19, a.Byte19);
                    Assume.bits_maskfromlowest(result.Byte20, a.Byte20);
                    Assume.bits_maskfromlowest(result.Byte21, a.Byte21);
                    Assume.bits_maskfromlowest(result.Byte22, a.Byte22);
                    Assume.bits_maskfromlowest(result.Byte23, a.Byte23);
                    Assume.bits_maskfromlowest(result.Byte24, a.Byte24);
                    Assume.bits_maskfromlowest(result.Byte25, a.Byte25);
                    Assume.bits_maskfromlowest(result.Byte26, a.Byte26);
                    Assume.bits_maskfromlowest(result.Byte27, a.Byte27);
                    Assume.bits_maskfromlowest(result.Byte28, a.Byte28);
                    Assume.bits_maskfromlowest(result.Byte29, a.Byte29);
                    Assume.bits_maskfromlowest(result.Byte30, a.Byte30);
                    Assume.bits_maskfromlowest(result.Byte31, a.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_or_si256(a, mm256_neg_epi16(a));

                    Assume.bits_maskfromlowest(result.UShort0,  a.UShort0);
                    Assume.bits_maskfromlowest(result.UShort1,  a.UShort1);
                    Assume.bits_maskfromlowest(result.UShort2,  a.UShort2);
                    Assume.bits_maskfromlowest(result.UShort3,  a.UShort3);
                    Assume.bits_maskfromlowest(result.UShort4,  a.UShort4);
                    Assume.bits_maskfromlowest(result.UShort5,  a.UShort5);
                    Assume.bits_maskfromlowest(result.UShort6,  a.UShort6);
                    Assume.bits_maskfromlowest(result.UShort7,  a.UShort7);
                    Assume.bits_maskfromlowest(result.UShort8,  a.UShort8);
                    Assume.bits_maskfromlowest(result.UShort9,  a.UShort9);
                    Assume.bits_maskfromlowest(result.UShort10, a.UShort10);
                    Assume.bits_maskfromlowest(result.UShort11, a.UShort11);
                    Assume.bits_maskfromlowest(result.UShort12, a.UShort12);
                    Assume.bits_maskfromlowest(result.UShort13, a.UShort13);
                    Assume.bits_maskfromlowest(result.UShort14, a.UShort14);
                    Assume.bits_maskfromlowest(result.UShort15, a.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_or_si256(a, mm256_neg_epi32(a));

                    Assume.bits_maskfromlowest(result.UInt0, a.UInt0);
                    Assume.bits_maskfromlowest(result.UInt1, a.UInt1);
                    Assume.bits_maskfromlowest(result.UInt2, a.UInt2);
                    Assume.bits_maskfromlowest(result.UInt3, a.UInt3);
                    Assume.bits_maskfromlowest(result.UInt4, a.UInt4);
                    Assume.bits_maskfromlowest(result.UInt5, a.UInt5);
                    Assume.bits_maskfromlowest(result.UInt6, a.UInt6);
                    Assume.bits_maskfromlowest(result.UInt7, a.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_or_si256(a, mm256_neg_epi64(a));

                    Assume.bits_maskfromlowest(result.ULong0, a.ULong0);
                    Assume.bits_maskfromlowest(result.ULong1, a.ULong1);
                    Assume.bits_maskfromlowest(result.ULong2, a.ULong2);
                    Assume.bits_maskfromlowest(result.ULong3, a.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_maskfromlowest(byte result, byte x)
        {
            constexpr.ASSUME(result == (byte)~math.tzmask(x));
            constexpr.ASSUME((result & x) == x);
            constexpr.ASSUME((result ^ math.tzmask(x)) == byte.MaxValue);
            constexpr.ASSUME((result & math.tzmask(x)) == 0);
            constexpr.ASSUME(math.countbits(result) == 8 - math.tzcnt(x));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_maskfromlowest(ushort result, ushort x)
        {
            constexpr.ASSUME(result == (ushort)~math.tzmask(x));
            constexpr.ASSUME((result & x) == x);
            constexpr.ASSUME((result ^ math.tzmask(x)) == ushort.MaxValue);
            constexpr.ASSUME((result & math.tzmask(x)) == 0);
            constexpr.ASSUME(math.countbits(result) == 16 - math.tzcnt(x));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_maskfromlowest(uint result, uint x)
        {
            constexpr.ASSUME(result == ~math.tzmask(x));
            constexpr.ASSUME((result & x) == x);
            constexpr.ASSUME((result ^ math.tzmask(x)) == uint.MaxValue);
            constexpr.ASSUME((result & math.tzmask(x)) == 0);
            constexpr.ASSUME(math.countbits(result) == 32 - math.tzcnt(x));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_maskfromlowest(ulong result, ulong x)
        {
            constexpr.ASSUME(result == ~math.tzmask(x));
            constexpr.ASSUME((result & x) == x);
            constexpr.ASSUME((result ^ math.tzmask(x)) == ulong.MaxValue);
            constexpr.ASSUME((result & math.tzmask(x)) == 0);
            constexpr.ASSUME(math.countbits(result) == 64 - math.tzcnt(x));
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_maskfromlowest(UInt128 x)
        {
            UInt128 result = x | (UInt128)(-((Int128)x));
            
            constexpr.ASSUME(result == ~math.tzmask(x));
            constexpr.ASSUME((result & x) == x);
            constexpr.ASSUME((result ^ math.tzmask(x)) == UInt128.MaxValue);
            constexpr.ASSUME((result & math.tzmask(x)) == 0);
            constexpr.ASSUME(math.countbits(result) == 128 - math.tzcnt(x));

            return result;
        }

        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_maskfromlowest(Int128 x)
        {
            return (Int128)bits_maskfromlowest((UInt128)x);
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_maskfromlowest(byte x)
        {
            return (byte)bits_maskfromlowest((uint)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_maskfromlowest(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi8(x);
            }
            else
            {
                return new byte2(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_maskfromlowest(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi8(x);
            }
            else
            {
                return new byte3(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y), bits_maskfromlowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_maskfromlowest(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi8(x);
            }
            else
            {
                return new byte4(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y), bits_maskfromlowest(x.z), bits_maskfromlowest(x.w));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_maskfromlowest(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi8(x);
            }
            else
            {
                return new byte8(bits_maskfromlowest(x.x0), bits_maskfromlowest(x.x1), bits_maskfromlowest(x.x2), bits_maskfromlowest(x.x3), bits_maskfromlowest(x.x4), bits_maskfromlowest(x.x5), bits_maskfromlowest(x.x6), bits_maskfromlowest(x.x7));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_maskfromlowest(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi8(x);
            }
            else
            {
                return new byte16(bits_maskfromlowest(x.x0), bits_maskfromlowest(x.x1), bits_maskfromlowest(x.x2), bits_maskfromlowest(x.x3), bits_maskfromlowest(x.x4), bits_maskfromlowest(x.x5), bits_maskfromlowest(x.x6), bits_maskfromlowest(x.x7), bits_maskfromlowest(x.x8), bits_maskfromlowest(x.x9), bits_maskfromlowest(x.x10), bits_maskfromlowest(x.x11), bits_maskfromlowest(x.x12), bits_maskfromlowest(x.x13), bits_maskfromlowest(x.x14), bits_maskfromlowest(x.x15));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_maskfromlowest(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blshmsk_epi8(x);
            }
            else
            {
                return new byte32(bits_maskfromlowest(x.v16_0), bits_maskfromlowest(x.v16_16));
            }
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_maskfromlowest(sbyte x)
        {
            return (sbyte)bits_maskfromlowest((byte)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_maskfromlowest(sbyte2 x)
        {
            return (sbyte2)bits_maskfromlowest((byte2)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_maskfromlowest(sbyte3 x)
        {
            return (sbyte3)bits_maskfromlowest((byte3)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_maskfromlowest(sbyte4 x)
        {
            return (sbyte4)bits_maskfromlowest((byte4)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_maskfromlowest(sbyte8 x)
        {
            return (sbyte8)bits_maskfromlowest((byte8)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_maskfromlowest(sbyte16 x)
        {
            return (sbyte16)bits_maskfromlowest((byte16)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_maskfromlowest(sbyte32 x)
        {
            return (sbyte32)bits_maskfromlowest((byte32)x);
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_maskfromlowest(ushort x)
        {
            return (ushort)bits_maskfromlowest((uint)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_maskfromlowest(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi16(x);
            }
            else
            {
                return new ushort2(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_maskfromlowest(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi16(x);
            }
            else
            {
                return new ushort3(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y), bits_maskfromlowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_maskfromlowest(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi16(x);
            }
            else
            {
                return new ushort4(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y), bits_maskfromlowest(x.z), bits_maskfromlowest(x.w));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_maskfromlowest(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi16(x);
            }
            else
            {
                return new ushort8(bits_maskfromlowest(x.x0), bits_maskfromlowest(x.x1), bits_maskfromlowest(x.x2), bits_maskfromlowest(x.x3), bits_maskfromlowest(x.x4), bits_maskfromlowest(x.x5), bits_maskfromlowest(x.x6), bits_maskfromlowest(x.x7));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_maskfromlowest(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blshmsk_epi16(x);
            }
            else
            {
                return new ushort16(bits_maskfromlowest(x.v8_0), bits_maskfromlowest(x.v8_8));
            }
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_maskfromlowest(short x)
        {
            return (short)bits_maskfromlowest((ushort)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_maskfromlowest(short2 x)
        {
            return (short2)bits_maskfromlowest((ushort2)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_maskfromlowest(short3 x)
        {
            return (short3)bits_maskfromlowest((ushort3)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_maskfromlowest(short4 x)
        {
            return (short4)bits_maskfromlowest((ushort4)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_maskfromlowest(short8 x)
        {
            return (short8)bits_maskfromlowest((ushort8)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_maskfromlowest(short16 x)
        {
            return (short16)bits_maskfromlowest((ushort16)x);
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_maskfromlowest(uint x)
        {
            uint result = x | (uint)-(int)x;

            Assume.bits_maskfromlowest(result, x);

            return result;
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_maskfromlowest(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi32(x);
            }
            else
            {
                return new uint2(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_maskfromlowest(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi32(x);
            }
            else
            {
                return new uint3(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y), bits_maskfromlowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_maskfromlowest(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi32(x);
            }
            else
            {
                return new uint4(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y), bits_maskfromlowest(x.z), bits_maskfromlowest(x.w));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_maskfromlowest(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blshmsk_epi32(x);
            }
            else
            {
                return new uint8(bits_maskfromlowest(x.v4_0), bits_maskfromlowest(x.v4_4));
            }
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_maskfromlowest(int x)
        {
            return (int)bits_maskfromlowest((uint)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_maskfromlowest(int2 x)
        {
            return (int2)bits_maskfromlowest((uint2)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_maskfromlowest(int3 x)
        {
            return (int3)bits_maskfromlowest((uint3)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_maskfromlowest(int4 x)
        {
            return (int4)bits_maskfromlowest((uint4)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_maskfromlowest(int8 x)
        {
            return (int8)bits_maskfromlowest((uint8)x);
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_maskfromlowest(ulong x)
        {
            ulong result = x | (ulong)-(long)x;

            Assume.bits_maskfromlowest(result, x);

            return result;
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_maskfromlowest(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blshmsk_epi64(x);
            }
            else
            {
                return new ulong2(bits_maskfromlowest(x.x), bits_maskfromlowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_maskfromlowest(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blshmsk_epi64(x);
            }
            else
            {
                return new ulong3(bits_maskfromlowest(x.xy), bits_maskfromlowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_maskfromlowest(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blshmsk_epi64(x);
            }
            else
            {
                return new ulong4(bits_maskfromlowest(x.xy), bits_maskfromlowest(x.zw));
            }
        }


        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_maskfromlowest(long x)
        {
            return (long)bits_maskfromlowest((ulong)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_maskfromlowest(long2 x)
        {
            return (long2)bits_maskfromlowest((ulong2)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_maskfromlowest(long3 x)
        {
            return (long3)bits_maskfromlowest((ulong3)x);
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_maskfromlowest(long4 x)
        {
            return (long4)bits_maskfromlowest((ulong4)x);
        }
    }
}