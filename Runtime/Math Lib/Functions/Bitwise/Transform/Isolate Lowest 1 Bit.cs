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
            public static v128 blsi_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, neg_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsi_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, neg_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsi_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, neg_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsi_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, neg_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsi_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_neg_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsi_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_neg_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsi_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_neg_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsi_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_neg_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extractlowest(Int128 x)
        {
            return (Int128)bits_extractlowest((UInt128)x);
        }

        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extractlowest(UInt128 x)
        {
            return x & (UInt128)(-(Int128)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractlowest(byte x)
        {
            return (byte)bits_extractlowest((uint)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extractlowest(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi8(x);
            }
            else
            {
                return new byte2(bits_extractlowest(x.x), bits_extractlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_extractlowest(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi8(x);
            }
            else
            {
                return new byte3(bits_extractlowest(x.x), bits_extractlowest(x.y), bits_extractlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_extractlowest(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi8(x);
            }
            else
            {
                return new byte4(bits_extractlowest(x.x), bits_extractlowest(x.y), bits_extractlowest(x.z), bits_extractlowest(x.w));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_extractlowest(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi8(x);
            }
            else
            {
                return new byte8(bits_extractlowest(x.x0), bits_extractlowest(x.x1), bits_extractlowest(x.x2), bits_extractlowest(x.x3), bits_extractlowest(x.x4), bits_extractlowest(x.x5), bits_extractlowest(x.x6), bits_extractlowest(x.x7));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_extractlowest(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi8(x);
            }
            else
            {
                return new byte16(bits_extractlowest(x.x0), bits_extractlowest(x.x1), bits_extractlowest(x.x2), bits_extractlowest(x.x3), bits_extractlowest(x.x4), bits_extractlowest(x.x5), bits_extractlowest(x.x6), bits_extractlowest(x.x7), bits_extractlowest(x.x8), bits_extractlowest(x.x9), bits_extractlowest(x.x10), bits_extractlowest(x.x11), bits_extractlowest(x.x12), bits_extractlowest(x.x13), bits_extractlowest(x.x14), bits_extractlowest(x.x15));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_extractlowest(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsi_epi8(x);
            }
            else
            {
                return new byte32(bits_extractlowest(x.v16_0), bits_extractlowest(x.v16_16));
            }
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extractlowest(sbyte x)
        {
            return (sbyte)bits_extractlowest((byte)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_extractlowest(sbyte2 x)
        {
            return (sbyte2)bits_extractlowest((byte2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_extractlowest(sbyte3 x)
        {
            return (sbyte3)bits_extractlowest((byte3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_extractlowest(sbyte4 x)
        {
            return (sbyte4)bits_extractlowest((byte4)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_extractlowest(sbyte8 x)
        {
            return (sbyte8)bits_extractlowest((byte8)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_extractlowest(sbyte16 x)
        {
            return (sbyte16)bits_extractlowest((byte16)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_extractlowest(sbyte32 x)
        {
            return (sbyte32)bits_extractlowest((byte32)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extractlowest(ushort x)
        {
            return (ushort)bits_extractlowest((uint)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_extractlowest(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi16(x);
            }
            else
            {
                return new ushort2(bits_extractlowest(x.x), bits_extractlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_extractlowest(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi16(x);
            }
            else
            {
                return new ushort3(bits_extractlowest(x.x), bits_extractlowest(x.y), bits_extractlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_extractlowest(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi16(x);
            }
            else
            {
                return new ushort4(bits_extractlowest(x.x), bits_extractlowest(x.y), bits_extractlowest(x.z), bits_extractlowest(x.w));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_extractlowest(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi16(x);
            }
            else
            {
                return new ushort8(bits_extractlowest(x.x0), bits_extractlowest(x.x1), bits_extractlowest(x.x2), bits_extractlowest(x.x3), bits_extractlowest(x.x4), bits_extractlowest(x.x5), bits_extractlowest(x.x6), bits_extractlowest(x.x7));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_extractlowest(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsi_epi16(x);
            }
            else
            {
                return new ushort16(bits_extractlowest(x.v8_0), bits_extractlowest(x.v8_8));
            }
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extractlowest(short x)
        {
            return (short)bits_extractlowest((ushort)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_extractlowest(short2 x)
        {
            return (short2)bits_extractlowest((ushort2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_extractlowest(short3 x)
        {
            return (short3)bits_extractlowest((ushort3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_extractlowest(short4 x)
        {
            return (short4)bits_extractlowest((ushort4)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_extractlowest(short8 x)
        {
            return (short8)bits_extractlowest((ushort8)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_extractlowest(short16 x)
        {
            return (short16)bits_extractlowest((ushort16)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractlowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsi_u32(x);
            }
            else
            {
                return x & (uint)-(int)x;
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_extractlowest(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blsi_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_extractlowest(x.x), bits_extractlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_extractlowest(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blsi_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_extractlowest(x.x), bits_extractlowest(x.y), bits_extractlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_extractlowest(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blsi_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_extractlowest(x.x), bits_extractlowest(x.y), bits_extractlowest(x.z), bits_extractlowest(x.w));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_extractlowest(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsi_epi32(x);
            }
            else
            {
                return new uint8(bits_extractlowest(x.v4_0), bits_extractlowest(x.v4_4));
            }
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractlowest(int x)
        {
            return (int)bits_extractlowest((uint)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_extractlowest(int2 x)
        {
            return (int2)bits_extractlowest((uint2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_extractlowest(int3 x)
        {
            return (int3)bits_extractlowest((uint3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_extractlowest(int4 x)
        {
            return (int4)bits_extractlowest((uint4)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_extractlowest(int8 x)
        {
            return (int8)bits_extractlowest((uint8)x);
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractlowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsi_u64(x);
            }
            else
            {
                return x & (ulong)-(long)x;
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_extractlowest(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blsi_epi64(x);
            }
            else
            {
                return new ulong2(bits_extractlowest(x.x), bits_extractlowest(x.y));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_extractlowest(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsi_epi64(x);
            }
            else
            {
                return new ulong3(bits_extractlowest(x.xy), bits_extractlowest(x.z));
            }
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_extractlowest(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsi_epi64(x);
            }
            else
            {
                return new ulong4(bits_extractlowest(x.xy), bits_extractlowest(x.zw));
            }
        }


        /// <summary>       Isolates the lowest set bit in <paramref name="x"/>, setting it to 1 and all other bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractlowest(long x)
        {
            return (long)bits_extractlowest((ulong)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_extractlowest(long2 x)
        {
            return (long2)bits_extractlowest((ulong2)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_extractlowest(long3 x)
        {
            return (long3)bits_extractlowest((ulong3)x);
        }

        /// <summary>       Isolates the lowest set bit in each <paramref name="x"/> component, setting the respective bit to 1 and all other respective bits to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_extractlowest(long4 x)
        {
            return (long4)bits_extractlowest((ulong4)x);
        }
    }
}