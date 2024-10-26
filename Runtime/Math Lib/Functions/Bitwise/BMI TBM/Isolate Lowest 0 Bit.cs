using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcic_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcic_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcic_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcic_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return andnot_si128(a, inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcic_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcic_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcic_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcic_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(a, mm256_inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extractlowest0(UInt128 x)
        {
            return andnot(x + 1, x);
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extractlowest0(Int128 x)
        {
            return (Int128)bits_extractlowest0((UInt128)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractlowest0(byte x)
        {
            return (byte)bits_extractlowest0((uint)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extractlowest0(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi8(x);
            }
            else
            {
                return new byte2(bits_extractlowest0(x.x), bits_extractlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_extractlowest0(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi8(x);
            }
            else
            {
                return new byte3(bits_extractlowest0(x.x), bits_extractlowest0(x.y), bits_extractlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_extractlowest0(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi8(x);
            }
            else
            {
                return new byte4(bits_extractlowest0(x.x), bits_extractlowest0(x.y), bits_extractlowest0(x.z), bits_extractlowest0(x.w));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_extractlowest0(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi8(x);
            }
            else
            {
                return new byte8(bits_extractlowest0(x.x0),
                                 bits_extractlowest0(x.x1),
                                 bits_extractlowest0(x.x2),
                                 bits_extractlowest0(x.x3),
                                 bits_extractlowest0(x.x4),
                                 bits_extractlowest0(x.x5),
                                 bits_extractlowest0(x.x6),
                                 bits_extractlowest0(x.x7));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_extractlowest0(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi8(x);
            }
            else
            {
                return new byte16(bits_extractlowest0(x. x0),
                                  bits_extractlowest0(x. x1),
                                  bits_extractlowest0(x. x2),
                                  bits_extractlowest0(x. x3),
                                  bits_extractlowest0(x. x4),
                                  bits_extractlowest0(x. x5),
                                  bits_extractlowest0(x. x6),
                                  bits_extractlowest0(x. x7),
                                  bits_extractlowest0(x. x8),
                                  bits_extractlowest0(x. x9),
                                  bits_extractlowest0(x.x10),
                                  bits_extractlowest0(x.x11),
                                  bits_extractlowest0(x.x12),
                                  bits_extractlowest0(x.x13),
                                  bits_extractlowest0(x.x14),
                                  bits_extractlowest0(x.x15));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_extractlowest0(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcic_epi8(x);
            }
            else
            {
                return new byte32(bits_extractlowest0(x.v16_0), bits_extractlowest0(x.v16_16));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extractlowest0(sbyte x)
        {
            return (sbyte)bits_extractlowest0((byte)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_extractlowest0(sbyte2 x)
        {
            return (sbyte2)bits_extractlowest0((byte2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_extractlowest0(sbyte3 x)
        {
            return (sbyte3)bits_extractlowest0((byte3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_extractlowest0(sbyte4 x)
        {
            return (sbyte4)bits_extractlowest0((byte4)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_extractlowest0(sbyte8 x)
        {
            return (sbyte8)bits_extractlowest0((byte8)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_extractlowest0(sbyte16 x)
        {
            return (sbyte16)bits_extractlowest0((byte16)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_extractlowest0(sbyte32 x)
        {
            return (sbyte32)bits_extractlowest0((byte32)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extractlowest0(ushort x)
        {
            return (ushort)bits_extractlowest0((uint)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_extractlowest0(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi16(x);
            }
            else
            {
                return new ushort2(bits_extractlowest0(x.x), bits_extractlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_extractlowest0(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi16(x);
            }
            else
            {
                return new ushort3(bits_extractlowest0(x.x), bits_extractlowest0(x.y), bits_extractlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_extractlowest0(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi16(x);
            }
            else
            {
                return new ushort4(bits_extractlowest0(x.x), bits_extractlowest0(x.y), bits_extractlowest0(x.z), bits_extractlowest0(x.w));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_extractlowest0(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi16(x);
            }
            else
            {
                return new ushort8(bits_extractlowest0(x.x0),
                                   bits_extractlowest0(x.x1),
                                   bits_extractlowest0(x.x2),
                                   bits_extractlowest0(x.x3),
                                   bits_extractlowest0(x.x4),
                                   bits_extractlowest0(x.x5),
                                   bits_extractlowest0(x.x6),
                                   bits_extractlowest0(x.x7));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_extractlowest0(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcic_epi16(x);
            }
            else
            {
                return new ushort16(bits_extractlowest0(x.v8_0), bits_extractlowest0(x.v8_8));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extractlowest0(short x)
        {
            return (short)bits_extractlowest0((ushort)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_extractlowest0(short2 x)
        {
            return (short2)bits_extractlowest0((ushort2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_extractlowest0(short3 x)
        {
            return (short3)bits_extractlowest0((ushort3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_extractlowest0(short4 x)
        {
            return (short4)bits_extractlowest0((ushort4)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_extractlowest0(short8 x)
        {
            return (short8)bits_extractlowest0((ushort8)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_extractlowest0(short16 x)
        {
            return (short16)bits_extractlowest0((ushort16)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractlowest0(uint x)
        {
            return andnot(x + 1, x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_extractlowest0(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blcic_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_extractlowest0(x.x), bits_extractlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_extractlowest0(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blcic_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_extractlowest0(x.x), bits_extractlowest0(x.y), bits_extractlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_extractlowest0(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blcic_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_extractlowest0(x.x), bits_extractlowest0(x.y), bits_extractlowest0(x.z), bits_extractlowest0(x.w));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_extractlowest0(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcic_epi32(x);
            }
            else
            {
                return new uint8(bits_extractlowest0(x.v4_0), bits_extractlowest0(x.v4_4));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractlowest0(int x)
        {
            return (int)bits_extractlowest0((uint)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_extractlowest0(int2 x)
        {
            return (int2)bits_extractlowest0((uint2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_extractlowest0(int3 x)
        {
            return (int3)bits_extractlowest0((uint3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_extractlowest0(int4 x)
        {
            return (int4)bits_extractlowest0((uint4)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_extractlowest0(int8 x)
        {
            return (int8)bits_extractlowest0((uint8)x);
        }


        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractlowest0(ulong x)
        {
            return andnot(x + 1, x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_extractlowest0(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcic_epi64(x);
            }
            else
            {
                return new ulong2(bits_extractlowest0(x.x), bits_extractlowest0(x.y));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_extractlowest0(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcic_epi64(x);
            }
            else
            {
                return new ulong3(bits_extractlowest0(x.xy), bits_extractlowest0(x.z));
            }
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_extractlowest0(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcic_epi64(x);
            }
            else
            {
                return new ulong4(bits_extractlowest0(x.xy), bits_extractlowest0(x.zw));
            }
        }

        /// <summary>       Isolates the lowest clear bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractlowest0(long x)
        {
            return (long)bits_extractlowest0((ulong)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_extractlowest0(long2 x)
        {
            return (long2)bits_extractlowest0((ulong2)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_extractlowest0(long3 x)
        {
            return (long3)bits_extractlowest0((ulong3)x);
        }

        /// <summary>       Isolates the lowest clear bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_extractlowest0(long4 x)
        {
            return (long4)bits_extractlowest0((ulong4)x);
        }
    }
}
