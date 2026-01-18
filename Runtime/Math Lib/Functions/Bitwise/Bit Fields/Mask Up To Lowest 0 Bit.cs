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
            public static v128 blcmsk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return xor_si128(a, inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcmsk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return xor_si128(a, inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcmsk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return xor_si128(a, inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcmsk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return xor_si128(a, inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_masktolowest0(UInt128 x)
        {
            return x ^ (x + 1);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_masktolowest0(Int128 x)
        {
            return (Int128)bits_masktolowest0((UInt128)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_masktolowest0(byte x)
        {
            return (byte)bits_masktolowest0((uint)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_masktolowest0(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi8(x);
            }
            else
            {
                return new byte2(bits_masktolowest0(x.x), bits_masktolowest0(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_masktolowest0(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi8(x);
            }
            else
            {
                return new byte3(bits_masktolowest0(x.x), bits_masktolowest0(x.y), bits_masktolowest0(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_masktolowest0(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi8(x);
            }
            else
            {
                return new byte4(bits_masktolowest0(x.x), bits_masktolowest0(x.y), bits_masktolowest0(x.z), bits_masktolowest0(x.w));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_masktolowest0(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi8(x);
            }
            else
            {
                return new byte8(bits_masktolowest0(x.x0),
                                 bits_masktolowest0(x.x1),
                                 bits_masktolowest0(x.x2),
                                 bits_masktolowest0(x.x3),
                                 bits_masktolowest0(x.x4),
                                 bits_masktolowest0(x.x5),
                                 bits_masktolowest0(x.x6),
                                 bits_masktolowest0(x.x7));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_masktolowest0(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi8(x);
            }
            else
            {
                return new byte16(bits_masktolowest0(x. x0),
                                  bits_masktolowest0(x. x1),
                                  bits_masktolowest0(x. x2),
                                  bits_masktolowest0(x. x3),
                                  bits_masktolowest0(x. x4),
                                  bits_masktolowest0(x. x5),
                                  bits_masktolowest0(x. x6),
                                  bits_masktolowest0(x. x7),
                                  bits_masktolowest0(x. x8),
                                  bits_masktolowest0(x. x9),
                                  bits_masktolowest0(x.x10),
                                  bits_masktolowest0(x.x11),
                                  bits_masktolowest0(x.x12),
                                  bits_masktolowest0(x.x13),
                                  bits_masktolowest0(x.x14),
                                  bits_masktolowest0(x.x15));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_masktolowest0(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcmsk_epi8(x);
            }
            else
            {
                return new byte32(bits_masktolowest0(x.v16_0), bits_masktolowest0(x.v16_16));
            }
        }

        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_masktolowest0(sbyte x)
        {
            return (sbyte)bits_masktolowest0((byte)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_masktolowest0(sbyte2 x)
        {
            return (sbyte2)bits_masktolowest0((byte2)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_masktolowest0(sbyte3 x)
        {
            return (sbyte3)bits_masktolowest0((byte3)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_masktolowest0(sbyte4 x)
        {
            return (sbyte4)bits_masktolowest0((byte4)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_masktolowest0(sbyte8 x)
        {
            return (sbyte8)bits_masktolowest0((byte8)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_masktolowest0(sbyte16 x)
        {
            return (sbyte16)bits_masktolowest0((byte16)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_masktolowest0(sbyte32 x)
        {
            return (sbyte32)bits_masktolowest0((byte32)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_masktolowest0(ushort x)
        {
            return (ushort)bits_masktolowest0((uint)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_masktolowest0(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi16(x);
            }
            else
            {
                return new ushort2(bits_masktolowest0(x.x), bits_masktolowest0(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_masktolowest0(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi16(x);
            }
            else
            {
                return new ushort3(bits_masktolowest0(x.x), bits_masktolowest0(x.y), bits_masktolowest0(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_masktolowest0(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi16(x);
            }
            else
            {
                return new ushort4(bits_masktolowest0(x.x), bits_masktolowest0(x.y), bits_masktolowest0(x.z), bits_masktolowest0(x.w));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_masktolowest0(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi16(x);
            }
            else
            {
                return new ushort8(bits_masktolowest0(x.x0),
                                   bits_masktolowest0(x.x1),
                                   bits_masktolowest0(x.x2),
                                   bits_masktolowest0(x.x3),
                                   bits_masktolowest0(x.x4),
                                   bits_masktolowest0(x.x5),
                                   bits_masktolowest0(x.x6),
                                   bits_masktolowest0(x.x7));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_masktolowest0(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcmsk_epi16(x);
            }
            else
            {
                return new ushort16(bits_masktolowest0(x.v8_0), bits_masktolowest0(x.v8_8));
            }
        }

        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_masktolowest0(short x)
        {
            return (short)bits_masktolowest0((ushort)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_masktolowest0(short2 x)
        {
            return (short2)bits_masktolowest0((ushort2)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_masktolowest0(short3 x)
        {
            return (short3)bits_masktolowest0((ushort3)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_masktolowest0(short4 x)
        {
            return (short4)bits_masktolowest0((ushort4)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_masktolowest0(short8 x)
        {
            return (short8)bits_masktolowest0((ushort8)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_masktolowest0(short16 x)
        {
            return (short16)bits_masktolowest0((ushort16)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_masktolowest0(uint x)
        {
            return x ^ (x + 1);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_masktolowest0(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blcmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_masktolowest0(x.x), bits_masktolowest0(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_masktolowest0(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blcmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_masktolowest0(x.x), bits_masktolowest0(x.y), bits_masktolowest0(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_masktolowest0(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blcmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_masktolowest0(x.x), bits_masktolowest0(x.y), bits_masktolowest0(x.z), bits_masktolowest0(x.w));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_masktolowest0(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcmsk_epi32(x);
            }
            else
            {
                return new uint8(bits_masktolowest0(x.v4_0), bits_masktolowest0(x.v4_4));
            }
        }

        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_masktolowest0(int x)
        {
            return (int)bits_masktolowest0((uint)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_masktolowest0(int2 x)
        {
            return (int2)bits_masktolowest0((uint2)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_masktolowest0(int3 x)
        {
            return (int3)bits_masktolowest0((uint3)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_masktolowest0(int4 x)
        {
            return (int4)bits_masktolowest0((uint4)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_masktolowest0(int8 x)
        {
            return (int8)bits_masktolowest0((uint8)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_masktolowest0(ulong x)
        {
            return x ^ (x + 1);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_masktolowest0(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcmsk_epi64(x);
            }
            else
            {
                return new ulong2(bits_masktolowest0(x.x), bits_masktolowest0(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_masktolowest0(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcmsk_epi64(x);
            }
            else
            {
                return new ulong3(bits_masktolowest0(x.xy), bits_masktolowest0(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_masktolowest0(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcmsk_epi64(x);
            }
            else
            {
                return new ulong4(bits_masktolowest0(x.xy), bits_masktolowest0(x.zw));
            }
        }

        /// <summary>       Sets all the low order bits up to and including the lowest clear bit in <paramref name="x"/> to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_masktolowest0(long x)
        {
            return (long)bits_masktolowest0((ulong)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_masktolowest0(long2 x)
        {
            return (long2)bits_masktolowest0((ulong2)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_masktolowest0(long3 x)
        {
            return (long3)bits_masktolowest0((ulong3)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest clear bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_masktolowest0(long4 x)
        {
            return (long4)bits_masktolowest0((ulong4)x);
        }
    }
}
