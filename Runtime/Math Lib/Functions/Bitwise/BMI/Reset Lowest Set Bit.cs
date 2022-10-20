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
            public static v128 blsr_epi8(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.and_si128(a, dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsr_epi16(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.and_si128(a, dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsr_epi32(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.and_si128(a, dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsr_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.and_si128(a, dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsr_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsr_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsr_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsr_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_resetlowest(Int128 x)
        {
            return (Int128)bits_resetlowest((UInt128)x);
        }

        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_resetlowest(UInt128 x)
        {
            return x & (x - 1);
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_resetlowest(byte x)
        {
            return (byte)bits_resetlowest((uint)x);
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_resetlowest(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi8(x);
            }
            else
            {
                return new byte2(bits_resetlowest(x.x), bits_resetlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_resetlowest(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi8(x);
            }
            else
            {
                return new byte3(bits_resetlowest(x.x), bits_resetlowest(x.y), bits_resetlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_resetlowest(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi8(x);
            }
            else
            {
                return new byte4(bits_resetlowest(x.x), bits_resetlowest(x.y), bits_resetlowest(x.z), bits_resetlowest(x.w));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_resetlowest(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi8(x);
            }
            else
            {
                return new byte8(bits_resetlowest(x.x0), bits_resetlowest(x.x1), bits_resetlowest(x.x2), bits_resetlowest(x.x3), bits_resetlowest(x.x4), bits_resetlowest(x.x5), bits_resetlowest(x.x6), bits_resetlowest(x.x7));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_resetlowest(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi8(x);
            }
            else
            {
                return new byte16(bits_resetlowest(x.x0), bits_resetlowest(x.x1), bits_resetlowest(x.x2), bits_resetlowest(x.x3), bits_resetlowest(x.x4), bits_resetlowest(x.x5), bits_resetlowest(x.x6), bits_resetlowest(x.x7), bits_resetlowest(x.x8), bits_resetlowest(x.x9), bits_resetlowest(x.x10), bits_resetlowest(x.x11), bits_resetlowest(x.x12), bits_resetlowest(x.x13), bits_resetlowest(x.x14), bits_resetlowest(x.x15));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_resetlowest(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsr_epi8(x);
            }
            else
            {
                return new byte32(bits_resetlowest(x.v16_0), bits_resetlowest(x.v16_16));
            }
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_resetlowest(sbyte x)
        {
            return (sbyte)bits_resetlowest((byte)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_resetlowest(sbyte2 x)
        {
            return (sbyte2)bits_resetlowest((byte2)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_resetlowest(sbyte3 x)
        {
            return (sbyte3)bits_resetlowest((byte3)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_resetlowest(sbyte4 x)
        {
            return (sbyte4)bits_resetlowest((byte4)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_resetlowest(sbyte8 x)
        {
            return (sbyte8)bits_resetlowest((byte8)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_resetlowest(sbyte16 x)
        {
            return (sbyte16)bits_resetlowest((byte16)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_resetlowest(sbyte32 x)
        {
            return (sbyte32)bits_resetlowest((byte32)x);
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_resetlowest(ushort x)
        {
            return (ushort)bits_resetlowest((uint)x);
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_resetlowest(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi16(x);
            }
            else
            {
                return new ushort2(bits_resetlowest(x.x), bits_resetlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_resetlowest(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi16(x);
            }
            else
            {
                return new ushort3(bits_resetlowest(x.x), bits_resetlowest(x.y), bits_resetlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_resetlowest(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi16(x);
            }
            else
            {
                return new ushort4(bits_resetlowest(x.x), bits_resetlowest(x.y), bits_resetlowest(x.z), bits_resetlowest(x.w));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_resetlowest(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi16(x);
            }
            else
            {
                return new ushort8(bits_resetlowest(x.x0), bits_resetlowest(x.x1), bits_resetlowest(x.x2), bits_resetlowest(x.x3), bits_resetlowest(x.x4), bits_resetlowest(x.x5), bits_resetlowest(x.x6), bits_resetlowest(x.x7));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_resetlowest(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsr_epi16(x);
            }
            else
            {
                return new ushort16(bits_resetlowest(x.v8_0), bits_resetlowest(x.v8_8));
            }
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_resetlowest(short x)
        {
            return (short)bits_resetlowest((ushort)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_resetlowest(short2 x)
        {
            return (short2)bits_resetlowest((ushort2)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_resetlowest(short3 x)
        {
            return (short3)bits_resetlowest((ushort3)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_resetlowest(short4 x)
        {
            return (short4)bits_resetlowest((ushort4)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_resetlowest(short8 x)
        {
            return (short8)bits_resetlowest((ushort8)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_resetlowest(short16 x)
        {
            return (short16)bits_resetlowest((ushort16)x);
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_resetlowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsr_u32(x);
            }
            else
            {
                return x & (x - 1);
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_resetlowest(uint2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.blsr_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_resetlowest(x.x), bits_resetlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_resetlowest(uint3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.blsr_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_resetlowest(x.x), bits_resetlowest(x.y), bits_resetlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_resetlowest(uint4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.blsr_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_resetlowest(x.x), bits_resetlowest(x.y), bits_resetlowest(x.z), bits_resetlowest(x.w));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_resetlowest(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsr_epi32(x);
            }
            else
            {
                return new uint8(bits_resetlowest(x.v4_0), bits_resetlowest(x.v4_4));
            }
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_resetlowest(int x)
        {
            return (int)bits_resetlowest((uint)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_resetlowest(int2 x)
        {
            return (int2)bits_resetlowest((uint2)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_resetlowest(int3 x)
        {
            return (int3)bits_resetlowest((uint3)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_resetlowest(int4 x)
        {
            return (int4)bits_resetlowest((uint4)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_resetlowest(int8 x)
        {
            return (int8)bits_resetlowest((uint8)x);
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_resetlowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsr_u64(x);
            }
            else
            {
                return x & (x - 1);
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_resetlowest(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsr_epi64(x);
            }
            else
            {
                return new ulong2(bits_resetlowest(x.x), bits_resetlowest(x.y));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_resetlowest(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsr_epi64(x);
            }
            else
            {
                return new ulong3(bits_resetlowest(x.xy), bits_resetlowest(x.z));
            }
        }

        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_resetlowest(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsr_epi64(x);
            }
            else
            {
                return new ulong4(bits_resetlowest(x.xy), bits_resetlowest(x.zw));
            }
        }


        /// <summary>       Sets the lowest set bit in <paramref name="x"/> to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_resetlowest(long x)
        {
            return (long)bits_resetlowest((ulong)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_resetlowest(long2 x)
        {
            return (long2)bits_resetlowest((ulong2)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_resetlowest(long3 x)
        {
            return (long3)bits_resetlowest((ulong3)x);
        }
        
        /// <summary>       Sets the lowest set bit in each <paramref name="x"/> component to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_resetlowest(long4 x)
        {
            return (long4)bits_resetlowest((ulong4)x);
        }
    }
}