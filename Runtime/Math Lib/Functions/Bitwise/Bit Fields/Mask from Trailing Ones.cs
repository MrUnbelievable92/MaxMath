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
            public static v128 t1msk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(inc_epi8(a), a);

                    Assume.t1mask(result.Byte0,  a.Byte0);
                    Assume.t1mask(result.Byte1,  a.Byte1);
                    Assume.t1mask(result.Byte2,  a.Byte2);
                    Assume.t1mask(result.Byte3,  a.Byte3);
                    Assume.t1mask(result.Byte4,  a.Byte4);
                    Assume.t1mask(result.Byte5,  a.Byte5);
                    Assume.t1mask(result.Byte6,  a.Byte6);
                    Assume.t1mask(result.Byte7,  a.Byte7);
                    Assume.t1mask(result.Byte8,  a.Byte8);
                    Assume.t1mask(result.Byte9,  a.Byte9);
                    Assume.t1mask(result.Byte10, a.Byte10);
                    Assume.t1mask(result.Byte11, a.Byte11);
                    Assume.t1mask(result.Byte12, a.Byte12);
                    Assume.t1mask(result.Byte13, a.Byte13);
                    Assume.t1mask(result.Byte14, a.Byte14);
                    Assume.t1mask(result.Byte15, a.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1msk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(inc_epi16(a), a);

                    Assume.t1mask(result.UShort0, a.UShort0);
                    Assume.t1mask(result.UShort1, a.UShort1);
                    Assume.t1mask(result.UShort2, a.UShort2);
                    Assume.t1mask(result.UShort3, a.UShort3);
                    Assume.t1mask(result.UShort4, a.UShort4);
                    Assume.t1mask(result.UShort5, a.UShort5);
                    Assume.t1mask(result.UShort6, a.UShort6);
                    Assume.t1mask(result.UShort7, a.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1msk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(inc_epi32(a), a);

                    Assume.t1mask(result.UInt0, a.UInt0);
                    Assume.t1mask(result.UInt1, a.UInt1);
                    Assume.t1mask(result.UInt2, a.UInt2);
                    Assume.t1mask(result.UInt3, a.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1msk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = andnot_si128(inc_epi64(a), a);

                    Assume.t1mask(result.ULong0, a.ULong0);
                    Assume.t1mask(result.ULong1, a.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(mm256_inc_epi8(a), a);

                    Assume.t1mask(result.Byte0,  a.Byte0);
                    Assume.t1mask(result.Byte1,  a.Byte1);
                    Assume.t1mask(result.Byte2,  a.Byte2);
                    Assume.t1mask(result.Byte3,  a.Byte3);
                    Assume.t1mask(result.Byte4,  a.Byte4);
                    Assume.t1mask(result.Byte5,  a.Byte5);
                    Assume.t1mask(result.Byte6,  a.Byte6);
                    Assume.t1mask(result.Byte7,  a.Byte7);
                    Assume.t1mask(result.Byte8,  a.Byte8);
                    Assume.t1mask(result.Byte9,  a.Byte9);
                    Assume.t1mask(result.Byte10, a.Byte10);
                    Assume.t1mask(result.Byte11, a.Byte11);
                    Assume.t1mask(result.Byte12, a.Byte12);
                    Assume.t1mask(result.Byte13, a.Byte13);
                    Assume.t1mask(result.Byte14, a.Byte14);
                    Assume.t1mask(result.Byte15, a.Byte15);
                    Assume.t1mask(result.Byte16, a.Byte16);
                    Assume.t1mask(result.Byte17, a.Byte17);
                    Assume.t1mask(result.Byte18, a.Byte18);
                    Assume.t1mask(result.Byte19, a.Byte19);
                    Assume.t1mask(result.Byte20, a.Byte20);
                    Assume.t1mask(result.Byte21, a.Byte21);
                    Assume.t1mask(result.Byte22, a.Byte22);
                    Assume.t1mask(result.Byte23, a.Byte23);
                    Assume.t1mask(result.Byte24, a.Byte24);
                    Assume.t1mask(result.Byte25, a.Byte25);
                    Assume.t1mask(result.Byte26, a.Byte26);
                    Assume.t1mask(result.Byte27, a.Byte27);
                    Assume.t1mask(result.Byte28, a.Byte28);
                    Assume.t1mask(result.Byte29, a.Byte29);
                    Assume.t1mask(result.Byte30, a.Byte30);
                    Assume.t1mask(result.Byte31, a.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(mm256_inc_epi16(a), a);

                    Assume.t1mask(result.UShort0,  a.UShort0);
                    Assume.t1mask(result.UShort1,  a.UShort1);
                    Assume.t1mask(result.UShort2,  a.UShort2);
                    Assume.t1mask(result.UShort3,  a.UShort3);
                    Assume.t1mask(result.UShort4,  a.UShort4);
                    Assume.t1mask(result.UShort5,  a.UShort5);
                    Assume.t1mask(result.UShort6,  a.UShort6);
                    Assume.t1mask(result.UShort7,  a.UShort7);
                    Assume.t1mask(result.UShort8,  a.UShort8);
                    Assume.t1mask(result.UShort9,  a.UShort9);
                    Assume.t1mask(result.UShort10, a.UShort10);
                    Assume.t1mask(result.UShort11, a.UShort11);
                    Assume.t1mask(result.UShort12, a.UShort12);
                    Assume.t1mask(result.UShort13, a.UShort13);
                    Assume.t1mask(result.UShort14, a.UShort14);
                    Assume.t1mask(result.UShort15, a.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(mm256_inc_epi32(a), a);

                    Assume.t1mask(result.UInt0, a.UInt0);
                    Assume.t1mask(result.UInt1, a.UInt1);
                    Assume.t1mask(result.UInt2, a.UInt2);
                    Assume.t1mask(result.UInt3, a.UInt3);
                    Assume.t1mask(result.UInt4, a.UInt4);
                    Assume.t1mask(result.UInt5, a.UInt5);
                    Assume.t1mask(result.UInt6, a.UInt6);
                    Assume.t1mask(result.UInt7, a.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_andnot_si256(mm256_inc_epi64(a), a);

                    Assume.t1mask(result.ULong0, a.ULong0);
                    Assume.t1mask(result.ULong1, a.ULong1);
                    Assume.t1mask(result.ULong2, a.ULong2);
                    Assume.t1mask(result.ULong3, a.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void t1mask(byte result, byte x)
        {
            constexpr.ASSUME((result & x) == result);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt((byte)~x));
            constexpr.ASSUME(result == math.tzmask((byte)~x));
            constexpr.ASSUME(result == (byte)(((x + 1) & (byte)~x) - 1));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void t1mask(ushort result, ushort x)
        {
            constexpr.ASSUME((result & x) == result);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt((ushort)~x));
            constexpr.ASSUME(result == math.tzmask((ushort)~x));
            constexpr.ASSUME(result == (ushort)(((x + 1) & (ushort)~x) - 1));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void t1mask(uint result, uint x)
        {
            constexpr.ASSUME((result & x) == result);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(~x));
            constexpr.ASSUME(result == math.tzmask(~x));
            constexpr.ASSUME(result == ((x + 1) & ~x) - 1);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void t1mask(ulong result, ulong x)
        {
            constexpr.ASSUME((result & x) == result);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(~x));
            constexpr.ASSUME(result == math.tzmask(~x));
            constexpr.ASSUME(result == ((x + 1) & ~x) - 1);
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 t1mask(UInt128 x)
        {
            UInt128 result = andnot(x, x + 1);
            
            constexpr.ASSUME((result & x) == result);
            constexpr.ASSUME((result & (result + 1)) == 0);
            constexpr.ASSUME(math.countbits(result) == math.tzcnt(~x));
            constexpr.ASSUME(result == math.tzmask(~x));
            constexpr.ASSUME(result == ((x + 1) & ~x) - 1);

            return result;
        }

        /// <summary>       Sets all the trailing ones in the binary representation of an <see cref="Int128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 t1mask(Int128 x)
        {
            return (Int128)t1mask((UInt128)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="byte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1mask(byte x)
        {
            byte result = andnot(x, (byte)(x + 1));

            Assume.t1mask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 t1mask(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 t1mask(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte3(t1mask(x.x), t1mask(x.y), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 t1mask(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte4(t1mask(x.x), t1mask(x.y), t1mask(x.z), t1mask(x.w));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 t1mask(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte8(t1mask(x.x0), t1mask(x.x1), t1mask(x.x2), t1mask(x.x3), t1mask(x.x4), t1mask(x.x5), t1mask(x.x6), t1mask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 t1mask(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte16(t1mask(x.x0), t1mask(x.x1), t1mask(x.x2), t1mask(x.x3), t1mask(x.x4), t1mask(x.x5), t1mask(x.x6), t1mask(x.x7), t1mask(x.x8), t1mask(x.x9), t1mask(x.x10), t1mask(x.x11), t1mask(x.x12), t1mask(x.x13), t1mask(x.x14), t1mask(x.x15));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="byte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 t1mask(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi8(x);
            }
            else
            {
                return new byte32(t1mask(x.v16_0), t1mask(x.v16_16));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of an <see cref="sbyte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte t1mask(sbyte x)
        {
            return (sbyte)t1mask((byte)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 t1mask(sbyte2 x)
        {
            return (sbyte2)t1mask((byte2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="sbyte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 t1mask(sbyte3 x)
        {
            return (sbyte3)t1mask((byte3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 t1mask(sbyte4 x)
        {
            return (sbyte4)t1mask((byte4)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 t1mask(sbyte8 x)
        {
            return (sbyte8)t1mask((byte8)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 t1mask(sbyte16 x)
        {
            return (sbyte16)t1mask((byte16)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 t1mask(sbyte32 x)
        {
            return (sbyte32)t1mask((byte32)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort t1mask(ushort x)
        {
            ushort result = andnot(x, (ushort)(x + 1));

            Assume.t1mask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 t1mask(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 t1mask(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort3(t1mask(x.x), t1mask(x.y), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 t1mask(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort4(t1mask(x.x), t1mask(x.y), t1mask(x.z), t1mask(x.w));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 t1mask(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort8(t1mask(x.x0), t1mask(x.x1), t1mask(x.x2), t1mask(x.x3), t1mask(x.x4), t1mask(x.x5), t1mask(x.x6), t1mask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ushort16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 t1mask(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi16(x);
            }
            else
            {
                return new ushort16(t1mask(x.v8_0), t1mask(x.v8_8));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="short"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short t1mask(short x)
        {
            return (short)t1mask((ushort)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 t1mask(short2 x)
        {
            return (short2)t1mask((ushort2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 t1mask(short3 x)
        {
            return (short3)t1mask((ushort3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 t1mask(short4 x)
        {
            return (short4)t1mask((ushort4)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 t1mask(short8 x)
        {
            return (short8)t1mask((ushort8)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 t1mask(short16 x)
        {
            return (short16)t1mask((ushort16)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint t1mask(uint x)
        {
            uint result = andnot(x, x + 1);

            Assume.t1mask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 t1mask(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi32(x);
            }
            else
            {
                return new uint2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 t1mask(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi32(x);
            }
            else
            {
                return new uint3(t1mask(x.x), t1mask(x.y), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 t1mask(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi32(x);
            }
            else
            {
                return new uint4(t1mask(x.x), t1mask(x.y), t1mask(x.z), t1mask(x.w));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 t1mask(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi32(x);
            }
            else
            {
                return new uint8(t1mask(x.v4_0), t1mask(x.v4_4));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of an <see cref="int"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int t1mask(int x)
        {
            return (int)t1mask((uint)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 t1mask(int2 x)
        {
            return (int2)t1mask((uint2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 t1mask(int3 x)
        {
            return (int3)t1mask((uint3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 t1mask(int4 x)
        {
            return (int4)t1mask((uint4)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 t1mask(int8 x)
        {
            return (int8)t1mask((uint8)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong t1mask(ulong x)
        {
            ulong result = andnot(x, x + 1);

            Assume.t1mask(result, x);

            return result;
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 t1mask(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi64(x);
            }
            else
            {
                return new ulong2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ulong3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 t1mask(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi64(x);
            }
            else
            {
                return new ulong3(t1mask(x.xy), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="ulong4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 t1mask(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi64(x);
            }
            else
            {
                return new ulong4(t1mask(x.xy), t1mask(x.zw));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="long"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long t1mask(long x)
        {
            return (long)t1mask((ulong)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 t1mask(long2 x)
        {
            return (long2)t1mask((ulong2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 t1mask(long3 x)
        {
            return (long3)t1mask((ulong3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 t1mask(long4 x)
        {
            return (long4)t1mask((ulong4)x);
        }
    }
}
