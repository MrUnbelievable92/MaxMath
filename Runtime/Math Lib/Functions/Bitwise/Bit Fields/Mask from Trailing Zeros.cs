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
            public static v128 tzmsk_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzmsk_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzmsk_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzmsk_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 tzmask(UInt128 x)
        {
            return andnot(x - 1, x);
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
            return andnot((byte)(x - 1), x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzmask(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzmask(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte3(tzmask(x.x), tzmask(x.y), tzmask(x.z));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzmask(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte4(tzmask(x.x), tzmask(x.y), tzmask(x.z), tzmask(x.w));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzmask(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte8(tzmask(x.x0), tzmask(x.x1), tzmask(x.x2), tzmask(x.x3), tzmask(x.x4), tzmask(x.x5), tzmask(x.x6), tzmask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzmask(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi8(x);
            }
            else
            {
                return new byte16(tzmask(x.x0), tzmask(x.x1), tzmask(x.x2), tzmask(x.x3), tzmask(x.x4), tzmask(x.x5), tzmask(x.x6), tzmask(x.x7), tzmask(x.x8), tzmask(x.x9), tzmask(x.x10), tzmask(x.x11), tzmask(x.x12), tzmask(x.x13), tzmask(x.x14), tzmask(x.x15));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.byte32"/> component to 1 and the remaining bits to 0.    </summary>
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

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzmask(sbyte2 x)
        {
            return (sbyte2)tzmask((byte2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.sbyte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzmask(sbyte3 x)
        {
            return (sbyte3)tzmask((byte3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzmask(sbyte4 x)
        {
            return (sbyte4)tzmask((byte4)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzmask(sbyte8 x)
        {
            return (sbyte8)tzmask((byte8)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzmask(sbyte16 x)
        {
            return (sbyte16)tzmask((byte16)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzmask(sbyte32 x)
        {
            return (sbyte32)tzmask((byte32)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort tzmask(ushort x)
        {
            return andnot((ushort)(x - 1), x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzmask(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzmask(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort3(tzmask(x.x), tzmask(x.y), tzmask(x.z));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzmask(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort4(tzmask(x.x), tzmask(x.y), tzmask(x.z), tzmask(x.w));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzmask(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi16(x);
            }
            else
            {
                return new ushort8(tzmask(x.x0), tzmask(x.x1), tzmask(x.x2), tzmask(x.x3), tzmask(x.x4), tzmask(x.x5), tzmask(x.x6), tzmask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ushort16"/> component to 1 and the remaining bits to 0.    </summary>
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

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzmask(short2 x)
        {
            return (short2)tzmask((ushort2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzmask(short3 x)
        {
            return (short3)tzmask((ushort3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzmask(short4 x)
        {
            return (short4)tzmask((ushort4)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzmask(short8 x)
        {
            return (short8)tzmask((ushort8)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzmask(short16 x)
        {
            return (short16)tzmask((ushort16)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint tzmask(uint x)
        {
            return andnot(x - 1, x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 tzmask(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.tzmsk_epi32(RegisterConversion.ToV128(x)));
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
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.tzmsk_epi32(RegisterConversion.ToV128(x)));
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
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.tzmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(tzmask(x.x), tzmask(x.y), tzmask(x.z), tzmask(x.w));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.uint8"/> component to 1 and the remaining bits to 0.    </summary>
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

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzmask(int8 x)
        {
            return (int8)tzmask((uint8)x);
        }


        /// <summary>       Sets all the trailing zeros in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong tzmask(ulong x)
        {
            return andnot(x - 1, x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzmask(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.tzmsk_epi64(x);
            }
            else
            {
                return new ulong2(tzmask(x.x), tzmask(x.y));
            }
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ulong3"/> component to 1 and the remaining bits to 0.    </summary>
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

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.ulong4"/> component to 1 and the remaining bits to 0.    </summary>
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

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzmask(long2 x)
        {
            return (long2)tzmask((ulong2)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzmask(long3 x)
        {
            return (long3)tzmask((ulong3)x);
        }

        /// <summary>       Sets all the trailing zeros in the binary representations of each <see cref="MaxMath.long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzmask(long4 x)
        {
            return (long4)tzmask((ulong4)x);
        }
    }
}
