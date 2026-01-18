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
            public static v128 blshmsk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return or_si128(a, neg_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return or_si128(a, neg_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return or_si128(a, neg_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blshmsk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return or_si128(a, neg_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_neg_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_neg_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_neg_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blshmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_neg_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the high order bits from the lowest set bit in <paramref name="x"/> to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_maskfromlowest(UInt128 x)
        {
            return x | (UInt128)(-((Int128)x));
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
            return x | (uint)-(int)x;
        }

        /// <summary>       Sets all the componentwise high order bits from the lowest set bits in each <paramref name="x"/> component to 1 and the remaining bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_maskfromlowest(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blshmsk_epi32(RegisterConversion.ToV128(x)));
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
                return RegisterConversion.ToUInt3(Xse.blshmsk_epi32(RegisterConversion.ToV128(x)));
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
                return RegisterConversion.ToUInt4(Xse.blshmsk_epi32(RegisterConversion.ToV128(x)));
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
            return x | (ulong)-(long)x;
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