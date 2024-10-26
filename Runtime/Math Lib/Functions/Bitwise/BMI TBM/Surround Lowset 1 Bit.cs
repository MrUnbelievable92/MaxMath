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
            public static v128 blsic_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(a, dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsic_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(a, dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsic_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(a, dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsic_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return ornot_si128(a, dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsic_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(a, mm256_dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsic_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(a, mm256_dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsic_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(a, mm256_dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsic_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_ornot_si256(a, mm256_dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_surroundlowest(UInt128 x)
        {
            return ~x | (x - 1);
        }

        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_surroundlowest(Int128 x)
        {
            return (Int128)bits_surroundlowest((UInt128)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_surroundlowest(byte x)
        {
            return (byte)bits_surroundlowest((uint)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_surroundlowest(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi8(x);
            }
            else
            {
                return new byte2(bits_surroundlowest(x.x), bits_surroundlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_surroundlowest(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi8(x);
            }
            else
            {
                return new byte3(bits_surroundlowest(x.x), bits_surroundlowest(x.y), bits_surroundlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_surroundlowest(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi8(x);
            }
            else
            {
                return new byte4(bits_surroundlowest(x.x), bits_surroundlowest(x.y), bits_surroundlowest(x.z), bits_surroundlowest(x.w));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_surroundlowest(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi8(x);
            }
            else
            {
                return new byte8(bits_surroundlowest(x.x0),
                                 bits_surroundlowest(x.x1),
                                 bits_surroundlowest(x.x2),
                                 bits_surroundlowest(x.x3),
                                 bits_surroundlowest(x.x4),
                                 bits_surroundlowest(x.x5),
                                 bits_surroundlowest(x.x6),
                                 bits_surroundlowest(x.x7));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_surroundlowest(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi8(x);
            }
            else
            {
                return new byte16(bits_surroundlowest(x. x0),
                                  bits_surroundlowest(x. x1),
                                  bits_surroundlowest(x. x2),
                                  bits_surroundlowest(x. x3),
                                  bits_surroundlowest(x. x4),
                                  bits_surroundlowest(x. x5),
                                  bits_surroundlowest(x. x6),
                                  bits_surroundlowest(x. x7),
                                  bits_surroundlowest(x. x8),
                                  bits_surroundlowest(x. x9),
                                  bits_surroundlowest(x.x10),
                                  bits_surroundlowest(x.x11),
                                  bits_surroundlowest(x.x12),
                                  bits_surroundlowest(x.x13),
                                  bits_surroundlowest(x.x14),
                                  bits_surroundlowest(x.x15));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_surroundlowest(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsic_epi8(x);
            }
            else
            {
                return new byte32(bits_surroundlowest(x.v16_0), bits_surroundlowest(x.v16_16));
            }
        }

        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_surroundlowest(sbyte x)
        {
            return (sbyte)bits_surroundlowest((byte)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_surroundlowest(sbyte2 x)
        {
            return (sbyte2)bits_surroundlowest((byte2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_surroundlowest(sbyte3 x)
        {
            return (sbyte3)bits_surroundlowest((byte3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_surroundlowest(sbyte4 x)
        {
            return (sbyte4)bits_surroundlowest((byte4)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_surroundlowest(sbyte8 x)
        {
            return (sbyte8)bits_surroundlowest((byte8)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_surroundlowest(sbyte16 x)
        {
            return (sbyte16)bits_surroundlowest((byte16)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_surroundlowest(sbyte32 x)
        {
            return (sbyte32)bits_surroundlowest((byte32)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_surroundlowest(ushort x)
        {
            return (ushort)bits_surroundlowest((uint)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_surroundlowest(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi16(x);
            }
            else
            {
                return new ushort2(bits_surroundlowest(x.x), bits_surroundlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_surroundlowest(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi16(x);
            }
            else
            {
                return new ushort3(bits_surroundlowest(x.x), bits_surroundlowest(x.y), bits_surroundlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_surroundlowest(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi16(x);
            }
            else
            {
                return new ushort4(bits_surroundlowest(x.x), bits_surroundlowest(x.y), bits_surroundlowest(x.z), bits_surroundlowest(x.w));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_surroundlowest(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi16(x);
            }
            else
            {
                return new ushort8(bits_surroundlowest(x.x0),
                                   bits_surroundlowest(x.x1),
                                   bits_surroundlowest(x.x2),
                                   bits_surroundlowest(x.x3),
                                   bits_surroundlowest(x.x4),
                                   bits_surroundlowest(x.x5),
                                   bits_surroundlowest(x.x6),
                                   bits_surroundlowest(x.x7));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_surroundlowest(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsic_epi16(x);
            }
            else
            {
                return new ushort16(bits_surroundlowest(x.v8_0), bits_surroundlowest(x.v8_8));
            }
        }

        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_surroundlowest(short x)
        {
            return (short)bits_surroundlowest((ushort)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_surroundlowest(short2 x)
        {
            return (short2)bits_surroundlowest((ushort2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_surroundlowest(short3 x)
        {
            return (short3)bits_surroundlowest((ushort3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_surroundlowest(short4 x)
        {
            return (short4)bits_surroundlowest((ushort4)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_surroundlowest(short8 x)
        {
            return (short8)bits_surroundlowest((ushort8)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_surroundlowest(short16 x)
        {
            return (short16)bits_surroundlowest((ushort16)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_surroundlowest(uint x)
        {
            return ~x | (x - 1);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_surroundlowest(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blsic_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_surroundlowest(x.x), bits_surroundlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_surroundlowest(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blsic_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_surroundlowest(x.x), bits_surroundlowest(x.y), bits_surroundlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_surroundlowest(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blsic_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_surroundlowest(x.x), bits_surroundlowest(x.y), bits_surroundlowest(x.z), bits_surroundlowest(x.w));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_surroundlowest(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsic_epi32(x);
            }
            else
            {
                return new uint8(bits_surroundlowest(x.v4_0), bits_surroundlowest(x.v4_4));
            }
        }

        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_surroundlowest(int x)
        {
            return (int)bits_surroundlowest((uint)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_surroundlowest(int2 x)
        {
            return (int2)bits_surroundlowest((uint2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_surroundlowest(int3 x)
        {
            return (int3)bits_surroundlowest((uint3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_surroundlowest(int4 x)
        {
            return (int4)bits_surroundlowest((uint4)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_surroundlowest(int8 x)
        {
            return (int8)bits_surroundlowest((uint8)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_surroundlowest(ulong x)
        {
            return ~x | (x - 1);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_surroundlowest(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsic_epi64(x);
            }
            else
            {
                return new ulong2(bits_surroundlowest(x.x), bits_surroundlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_surroundlowest(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsic_epi64(x);
            }
            else
            {
                return new ulong3(bits_surroundlowest(x.xy), bits_surroundlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_surroundlowest(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsic_epi64(x);
            }
            else
            {
                return new ulong4(bits_surroundlowest(x.xy), bits_surroundlowest(x.zw));
            }
        }

        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 0 and all other bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_surroundlowest(long x)
        {
            return (long)bits_surroundlowest((ulong)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_surroundlowest(long2 x)
        {
            return (long2)bits_surroundlowest((ulong2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_surroundlowest(long3 x)
        {
            return (long3)bits_surroundlowest((ulong3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 0 and all other respective bits to 1.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_surroundlowest(long4 x)
        {
            return (long4)bits_surroundlowest((ulong4)x);
        }
    }
}
