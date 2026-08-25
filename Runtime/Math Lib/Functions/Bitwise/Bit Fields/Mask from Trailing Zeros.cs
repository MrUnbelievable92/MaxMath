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
            public static v128 tzmsk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(a, dec_epi8(a));

                    Assume.tzmask(result.Byte0,  a.Byte0);
                    Assume.tzmask(result.Byte1,  a.Byte1);
                    Assume.tzmask(result.Byte2,  a.Byte2);
                    Assume.tzmask(result.Byte3,  a.Byte3);
                    Assume.tzmask(result.Byte4,  a.Byte4);
                    Assume.tzmask(result.Byte5,  a.Byte5);
                    Assume.tzmask(result.Byte6,  a.Byte6);
                    Assume.tzmask(result.Byte7,  a.Byte7);
                    Assume.tzmask(result.Byte8,  a.Byte8);
                    Assume.tzmask(result.Byte9,  a.Byte9);
                    Assume.tzmask(result.Byte10, a.Byte10);
                    Assume.tzmask(result.Byte11, a.Byte11);
                    Assume.tzmask(result.Byte12, a.Byte12);
                    Assume.tzmask(result.Byte13, a.Byte13);
                    Assume.tzmask(result.Byte14, a.Byte14);
                    Assume.tzmask(result.Byte15, a.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzmsk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(a, dec_epi16(a));

                    Assume.tzmask(result.UShort0, a.UShort0);
                    Assume.tzmask(result.UShort1, a.UShort1);
                    Assume.tzmask(result.UShort2, a.UShort2);
                    Assume.tzmask(result.UShort3, a.UShort3);
                    Assume.tzmask(result.UShort4, a.UShort4);
                    Assume.tzmask(result.UShort5, a.UShort5);
                    Assume.tzmask(result.UShort6, a.UShort6);
                    Assume.tzmask(result.UShort7, a.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzmsk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(a, dec_epi32(a));

                    Assume.tzmask(result.UInt0, a.UInt0);
                    Assume.tzmask(result.UInt1, a.UInt1);
                    Assume.tzmask(result.UInt2, a.UInt2);
                    Assume.tzmask(result.UInt3, a.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzmsk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(a, dec_epi64(a));

                    Assume.tzmask(result.ULong0, a.ULong0);
                    Assume.tzmask(result.ULong1, a.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(a, mm256_dec_epi8(a));

                    Assume.tzmask(result.Byte0,  a.Byte0);
                    Assume.tzmask(result.Byte1,  a.Byte1);
                    Assume.tzmask(result.Byte2,  a.Byte2);
                    Assume.tzmask(result.Byte3,  a.Byte3);
                    Assume.tzmask(result.Byte4,  a.Byte4);
                    Assume.tzmask(result.Byte5,  a.Byte5);
                    Assume.tzmask(result.Byte6,  a.Byte6);
                    Assume.tzmask(result.Byte7,  a.Byte7);
                    Assume.tzmask(result.Byte8,  a.Byte8);
                    Assume.tzmask(result.Byte9,  a.Byte9);
                    Assume.tzmask(result.Byte10, a.Byte10);
                    Assume.tzmask(result.Byte11, a.Byte11);
                    Assume.tzmask(result.Byte12, a.Byte12);
                    Assume.tzmask(result.Byte13, a.Byte13);
                    Assume.tzmask(result.Byte14, a.Byte14);
                    Assume.tzmask(result.Byte15, a.Byte15);
                    Assume.tzmask(result.Byte16, a.Byte16);
                    Assume.tzmask(result.Byte17, a.Byte17);
                    Assume.tzmask(result.Byte18, a.Byte18);
                    Assume.tzmask(result.Byte19, a.Byte19);
                    Assume.tzmask(result.Byte20, a.Byte20);
                    Assume.tzmask(result.Byte21, a.Byte21);
                    Assume.tzmask(result.Byte22, a.Byte22);
                    Assume.tzmask(result.Byte23, a.Byte23);
                    Assume.tzmask(result.Byte24, a.Byte24);
                    Assume.tzmask(result.Byte25, a.Byte25);
                    Assume.tzmask(result.Byte26, a.Byte26);
                    Assume.tzmask(result.Byte27, a.Byte27);
                    Assume.tzmask(result.Byte28, a.Byte28);
                    Assume.tzmask(result.Byte29, a.Byte29);
                    Assume.tzmask(result.Byte30, a.Byte30);
                    Assume.tzmask(result.Byte31, a.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(a, mm256_dec_epi16(a));

                    Assume.tzmask(result.UShort0,  a.UShort0);
                    Assume.tzmask(result.UShort1,  a.UShort1);
                    Assume.tzmask(result.UShort2,  a.UShort2);
                    Assume.tzmask(result.UShort3,  a.UShort3);
                    Assume.tzmask(result.UShort4,  a.UShort4);
                    Assume.tzmask(result.UShort5,  a.UShort5);
                    Assume.tzmask(result.UShort6,  a.UShort6);
                    Assume.tzmask(result.UShort7,  a.UShort7);
                    Assume.tzmask(result.UShort8,  a.UShort8);
                    Assume.tzmask(result.UShort9,  a.UShort9);
                    Assume.tzmask(result.UShort10, a.UShort10);
                    Assume.tzmask(result.UShort11, a.UShort11);
                    Assume.tzmask(result.UShort12, a.UShort12);
                    Assume.tzmask(result.UShort13, a.UShort13);
                    Assume.tzmask(result.UShort14, a.UShort14);
                    Assume.tzmask(result.UShort15, a.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(a, mm256_dec_epi32(a));

                    Assume.tzmask(result.UInt0, a.UInt0);
                    Assume.tzmask(result.UInt1, a.UInt1);
                    Assume.tzmask(result.UInt2, a.UInt2);
                    Assume.tzmask(result.UInt3, a.UInt3);
                    Assume.tzmask(result.UInt4, a.UInt4);
                    Assume.tzmask(result.UInt5, a.UInt5);
                    Assume.tzmask(result.UInt6, a.UInt6);
                    Assume.tzmask(result.UInt7, a.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(a, mm256_dec_epi64(a));

                    Assume.tzmask(result.ULong0, a.ULong0);
                    Assume.tzmask(result.ULong1, a.ULong1);
                    Assume.tzmask(result.ULong2, a.ULong2);
                    Assume.tzmask(result.ULong3, a.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void tzmask(byte result, byte x)
        {
            constexpr.ASSUME((result & x) == 0);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(x));
            constexpr.ASSUME(x == 0 || result < x);
            constexpr.ASSUME(x == 0 || result == (byte)((x & (byte)-(sbyte)x) - 1));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void tzmask(ushort result, ushort x)
        {
            constexpr.ASSUME((result & x) == 0);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(x));
            constexpr.ASSUME(x == 0 || result < x);
            constexpr.ASSUME(x == 0 || result == (ushort)((x & (ushort)-(short)x) - 1));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void tzmask(uint result, uint x)
        {
            constexpr.ASSUME((result & x) == 0);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(x));
            constexpr.ASSUME(x == 0 || result < x);
            constexpr.ASSUME(x == 0 || result == (x & (uint)-(int)x) - 1);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void tzmask(ulong result, ulong x)
        {
            constexpr.ASSUME((result & x) == 0);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(x));
            constexpr.ASSUME(x == 0 || result < x);
            constexpr.ASSUME(x == 0 || result == (x & (ulong)-(long)x) - 1);
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 tzmask(UInt128 x)
        {
            UInt128 result = andnot(x - 1, x);

            constexpr.ASSUME((result & x) == 0);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(x));
            constexpr.ASSUME(x == 0 || result < x);
            constexpr.ASSUME(x == 0 || result == (x & (UInt128)(-(Int128)x)) - 1);

            return result;
        }

        /// <summary>       Sets all the trailing zeros in the binary representation of an <see cref="Int128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 tzmask(Int128 x)
        {
            return (Int128)tzmask((UInt128)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="byte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzmask(byte x)
        {
            byte result = andnot((byte)(x - 1), x);

            Assume.tzmask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzmask(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzmask(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte3(tzmask(x.x), tzmask(x.y), tzmask(x.z));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzmask(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte4(tzmask(x.x), tzmask(x.y), tzmask(x.z), tzmask(x.w));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzmask(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte8(tzmask(x.x0), tzmask(x.x1), tzmask(x.x2), tzmask(x.x3), tzmask(x.x4), tzmask(x.x5), tzmask(x.x6), tzmask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzmask(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte16(tzmask(x.x0), tzmask(x.x1), tzmask(x.x2), tzmask(x.x3), tzmask(x.x4), tzmask(x.x5), tzmask(x.x6), tzmask(x.x7), tzmask(x.x8), tzmask(x.x9), tzmask(x.x10), tzmask(x.x11), tzmask(x.x12), tzmask(x.x13), tzmask(x.x14), tzmask(x.x15));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="byte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tzmask(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzmsk_epi8(x);
            }
            else
            {
                return new byte32(tzmask(x.v16_0), tzmask(x.v16_16));
            }
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of an <see cref="sbyte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tzmask(sbyte x)
        {
            return (sbyte)tzmask((byte)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzmask(sbyte2 x)
        {
            return (sbyte2)tzmask((byte2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="sbyte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzmask(sbyte3 x)
        {
            return (sbyte3)tzmask((byte3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzmask(sbyte4 x)
        {
            return (sbyte4)tzmask((byte4)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzmask(sbyte8 x)
        {
            return (sbyte8)tzmask((byte8)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzmask(sbyte16 x)
        {
            return (sbyte16)tzmask((byte16)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzmask(sbyte32 x)
        {
            return (sbyte32)tzmask((byte32)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort tzmask(ushort x)
        {
            ushort result = andnot((ushort)(x - 1), x);

            Assume.tzmask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzmask(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzmask(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort3(tzmask(x.x), tzmask(x.y), tzmask(x.z));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzmask(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort4(tzmask(x.x), tzmask(x.y), tzmask(x.z), tzmask(x.w));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzmask(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort8(tzmask(x.x0), tzmask(x.x1), tzmask(x.x2), tzmask(x.x3), tzmask(x.x4), tzmask(x.x5), tzmask(x.x6), tzmask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ushort16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 tzmask(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzmsk_epi16(x);
            }
            else
            {
                return new ushort16(tzmask(x.v8_0), tzmask(x.v8_8));
            }
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="short"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short tzmask(short x)
        {
            return (short)tzmask((ushort)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzmask(short2 x)
        {
            return (short2)tzmask((ushort2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzmask(short3 x)
        {
            return (short3)tzmask((ushort3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzmask(short4 x)
        {
            return (short4)tzmask((ushort4)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzmask(short8 x)
        {
            return (short8)tzmask((ushort8)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzmask(short16 x)
        {
            return (short16)tzmask((ushort16)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint tzmask(uint x)
        {
            uint result = andnot(x - 1, x);

            Assume.tzmask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 tzmask(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi32(x);
            }
            else
            {
                return new uint2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="uint3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 tzmask(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi32(x);
            }
            else
            {
                return new uint3(tzmask(x.x), tzmask(x.y), tzmask(x.z));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="uint4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 tzmask(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi32(x);
            }
            else
            {
                return new uint4(tzmask(x.x), tzmask(x.y), tzmask(x.z), tzmask(x.w));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="uint8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 tzmask(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzmsk_epi32(x);
            }
            else
            {
                return new uint8(tzmask(x.v4_0), tzmask(x.v4_4));
            }
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of an <see cref="int"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tzmask(int x)
        {
            return (int)tzmask((uint)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="int2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tzmask(int2 x)
        {
            return (int2)tzmask((uint2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="int3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tzmask(int3 x)
        {
            return (int3)tzmask((uint3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="int4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tzmask(int4 x)
        {
            return (int4)tzmask((uint4)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzmask(int8 x)
        {
            return (int8)tzmask((uint8)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong tzmask(ulong x)
        {
            ulong result = andnot(x - 1, x);

            Assume.tzmask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzmask(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi64(x);
            }
            else
            {
                return new ulong2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ulong3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 tzmask(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzmsk_epi64(x);
            }
            else
            {
                return new ulong3(tzmask(x.xy), tzmask(x.z));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="ulong4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 tzmask(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzmsk_epi64(x);
            }
            else
            {
                return new ulong4(tzmask(x.xy), tzmask(x.zw));
            }
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="long"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tzmask(long x)
        {
            return (long)tzmask((ulong)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzmask(long2 x)
        {
            return (long2)tzmask((ulong2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzmask(long3 x)
        {
            return (long3)tzmask((ulong3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzmask(long4 x)
        {
            return (long4)tzmask((ulong4)x);
        }
    }
}
