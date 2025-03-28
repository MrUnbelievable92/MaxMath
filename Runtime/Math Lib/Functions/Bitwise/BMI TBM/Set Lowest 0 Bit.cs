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
            public static v128 blcs_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcs_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcs_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcs_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcs_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcs_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcs_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcs_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_setlowest(Int128 x)
        {
            return (Int128)bits_setlowest((UInt128)x);
        }

        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_setlowest(UInt128 x)
        {
            return x | (x + 1);
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_setlowest(byte x)
        {
            return (byte)bits_setlowest((uint)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_setlowest(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi8(x);
            }
            else
            {
                return new byte2(bits_setlowest(x.x), bits_setlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_setlowest(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi8(x);
            }
            else
            {
                return new byte3(bits_setlowest(x.x), bits_setlowest(x.y), bits_setlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_setlowest(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi8(x);
            }
            else
            {
                return new byte4(bits_setlowest(x.x), bits_setlowest(x.y), bits_setlowest(x.z), bits_setlowest(x.w));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_setlowest(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi8(x);
            }
            else
            {
                return new byte8(bits_setlowest(x.x0), bits_setlowest(x.x1), bits_setlowest(x.x2), bits_setlowest(x.x3), bits_setlowest(x.x4), bits_setlowest(x.x5), bits_setlowest(x.x6), bits_setlowest(x.x7));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_setlowest(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi8(x);
            }
            else
            {
                return new byte16(bits_setlowest(x.x0), bits_setlowest(x.x1), bits_setlowest(x.x2), bits_setlowest(x.x3), bits_setlowest(x.x4), bits_setlowest(x.x5), bits_setlowest(x.x6), bits_setlowest(x.x7), bits_setlowest(x.x8), bits_setlowest(x.x9), bits_setlowest(x.x10), bits_setlowest(x.x11), bits_setlowest(x.x12), bits_setlowest(x.x13), bits_setlowest(x.x14), bits_setlowest(x.x15));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_setlowest(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcs_epi8(x);
            }
            else
            {
                return new byte32(bits_setlowest(x.v16_0), bits_setlowest(x.v16_16));
            }
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_setlowest(sbyte x)
        {
            return (sbyte)bits_setlowest((byte)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_setlowest(sbyte2 x)
        {
            return (sbyte2)bits_setlowest((byte2)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_setlowest(sbyte3 x)
        {
            return (sbyte3)bits_setlowest((byte3)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_setlowest(sbyte4 x)
        {
            return (sbyte4)bits_setlowest((byte4)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_setlowest(sbyte8 x)
        {
            return (sbyte8)bits_setlowest((byte8)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_setlowest(sbyte16 x)
        {
            return (sbyte16)bits_setlowest((byte16)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_setlowest(sbyte32 x)
        {
            return (sbyte32)bits_setlowest((byte32)x);
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_setlowest(ushort x)
        {
            return (ushort)bits_setlowest((uint)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_setlowest(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi16(x);
            }
            else
            {
                return new ushort2(bits_setlowest(x.x), bits_setlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_setlowest(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi16(x);
            }
            else
            {
                return new ushort3(bits_setlowest(x.x), bits_setlowest(x.y), bits_setlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_setlowest(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi16(x);
            }
            else
            {
                return new ushort4(bits_setlowest(x.x), bits_setlowest(x.y), bits_setlowest(x.z), bits_setlowest(x.w));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_setlowest(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi16(x);
            }
            else
            {
                return new ushort8(bits_setlowest(x.x0), bits_setlowest(x.x1), bits_setlowest(x.x2), bits_setlowest(x.x3), bits_setlowest(x.x4), bits_setlowest(x.x5), bits_setlowest(x.x6), bits_setlowest(x.x7));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_setlowest(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcs_epi16(x);
            }
            else
            {
                return new ushort16(bits_setlowest(x.v8_0), bits_setlowest(x.v8_8));
            }
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_setlowest(short x)
        {
            return (short)bits_setlowest((ushort)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_setlowest(short2 x)
        {
            return (short2)bits_setlowest((ushort2)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_setlowest(short3 x)
        {
            return (short3)bits_setlowest((ushort3)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_setlowest(short4 x)
        {
            return (short4)bits_setlowest((ushort4)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_setlowest(short8 x)
        {
            return (short8)bits_setlowest((ushort8)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_setlowest(short16 x)
        {
            return (short16)bits_setlowest((ushort16)x);
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_setlowest(uint x)
        {
            return x | (x + 1);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_setlowest(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blcs_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_setlowest(x.x), bits_setlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_setlowest(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blcs_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_setlowest(x.x), bits_setlowest(x.y), bits_setlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_setlowest(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blcs_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_setlowest(x.x), bits_setlowest(x.y), bits_setlowest(x.z), bits_setlowest(x.w));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_setlowest(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcs_epi32(x);
            }
            else
            {
                return new uint8(bits_setlowest(x.v4_0), bits_setlowest(x.v4_4));
            }
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_setlowest(int x)
        {
            return (int)bits_setlowest((uint)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_setlowest(int2 x)
        {
            return (int2)bits_setlowest((uint2)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_setlowest(int3 x)
        {
            return (int3)bits_setlowest((uint3)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_setlowest(int4 x)
        {
            return (int4)bits_setlowest((uint4)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_setlowest(int8 x)
        {
            return (int8)bits_setlowest((uint8)x);
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_setlowest(ulong x)
        {
            return x | (x + 1);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_setlowest(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blcs_epi64(x);
            }
            else
            {
                return new ulong2(bits_setlowest(x.x), bits_setlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_setlowest(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcs_epi64(x);
            }
            else
            {
                return new ulong3(bits_setlowest(x.xy), bits_setlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_setlowest(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcs_epi64(x);
            }
            else
            {
                return new ulong4(bits_setlowest(x.xy), bits_setlowest(x.zw));
            }
        }


        /// <summary>       Sets the lowest 0 bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_setlowest(long x)
        {
            return (long)bits_setlowest((ulong)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_setlowest(long2 x)
        {
            return (long2)bits_setlowest((ulong2)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_setlowest(long3 x)
        {
            return (long3)bits_setlowest((ulong3)x);
        }

        /// <summary>       Sets the lowest 0 bit in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_setlowest(long4 x)
        {
            return (long4)bits_setlowest((ulong4)x);
        }
    }
}