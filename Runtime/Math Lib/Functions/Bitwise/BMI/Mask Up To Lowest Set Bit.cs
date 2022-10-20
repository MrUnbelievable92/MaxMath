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
            public static v128 blsmsk_epi8(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.xor_si128(a, dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsmsk_epi16(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.xor_si128(a, dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsmsk_epi32(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.xor_si128(a, dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsmsk_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.xor_si128(a, dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsmsk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsmsk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsmsk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsmsk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_xor_si256(a, mm256_dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_masktolowest(Int128 x)
        {
            return (Int128)bits_masktolowest((UInt128)x);
        }

        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_masktolowest(UInt128 x)
        {
            return x ^ (x - 1);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_masktolowest(byte x)
        {
            return (byte)bits_masktolowest((uint)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_masktolowest(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi8(x);
            }
            else
            {
                return new byte2(bits_masktolowest(x.x), bits_masktolowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_masktolowest(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi8(x);
            }
            else
            {
                return new byte3(bits_masktolowest(x.x), bits_masktolowest(x.y), bits_masktolowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_masktolowest(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi8(x);
            }
            else
            {
                return new byte4(bits_masktolowest(x.x), bits_masktolowest(x.y), bits_masktolowest(x.z), bits_masktolowest(x.w));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_masktolowest(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi8(x);
            }
            else
            {
                return new byte8(bits_masktolowest(x.x0), bits_masktolowest(x.x1), bits_masktolowest(x.x2), bits_masktolowest(x.x3), bits_masktolowest(x.x4), bits_masktolowest(x.x5), bits_masktolowest(x.x6), bits_masktolowest(x.x7));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_masktolowest(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi8(x);
            }
            else
            {
                return new byte16(bits_masktolowest(x.x0), bits_masktolowest(x.x1), bits_masktolowest(x.x2), bits_masktolowest(x.x3), bits_masktolowest(x.x4), bits_masktolowest(x.x5), bits_masktolowest(x.x6), bits_masktolowest(x.x7), bits_masktolowest(x.x8), bits_masktolowest(x.x9), bits_masktolowest(x.x10), bits_masktolowest(x.x11), bits_masktolowest(x.x12), bits_masktolowest(x.x13), bits_masktolowest(x.x14), bits_masktolowest(x.x15));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_masktolowest(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsmsk_epi8(x);
            }
            else
            {
                return new byte32(bits_masktolowest(x.v16_0), bits_masktolowest(x.v16_16));
            }
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_masktolowest(sbyte x)
        {
            return (sbyte)bits_masktolowest((byte)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_masktolowest(sbyte2 x)
        {
            return (sbyte2)bits_masktolowest((byte2)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_masktolowest(sbyte3 x)
        {
            return (sbyte3)bits_masktolowest((byte3)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_masktolowest(sbyte4 x)
        {
            return (sbyte4)bits_masktolowest((byte4)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_masktolowest(sbyte8 x)
        {
            return (sbyte8)bits_masktolowest((byte8)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_masktolowest(sbyte16 x)
        {
            return (sbyte16)bits_masktolowest((byte16)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_masktolowest(sbyte32 x)
        {
            return (sbyte32)bits_masktolowest((byte32)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_masktolowest(ushort x)
        {
            return (ushort)bits_masktolowest((uint)x);
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_masktolowest(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi16(x);
            }
            else
            {
                return new ushort2(bits_masktolowest(x.x), bits_masktolowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_masktolowest(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi16(x);
            }
            else
            {
                return new ushort3(bits_masktolowest(x.x), bits_masktolowest(x.y), bits_masktolowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_masktolowest(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi16(x);
            }
            else
            {
                return new ushort4(bits_masktolowest(x.x), bits_masktolowest(x.y), bits_masktolowest(x.z), bits_masktolowest(x.w));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_masktolowest(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi16(x);
            }
            else
            {
                return new ushort8(bits_masktolowest(x.x0), bits_masktolowest(x.x1), bits_masktolowest(x.x2), bits_masktolowest(x.x3), bits_masktolowest(x.x4), bits_masktolowest(x.x5), bits_masktolowest(x.x6), bits_masktolowest(x.x7));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_masktolowest(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsmsk_epi16(x);
            }
            else
            {
                return new ushort16(bits_masktolowest(x.v8_0), bits_masktolowest(x.v8_8));
            }
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_masktolowest(short x)
        {
            return (short)bits_masktolowest((ushort)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_masktolowest(short2 x)
        {
            return (short2)bits_masktolowest((ushort2)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_masktolowest(short3 x)
        {
            return (short3)bits_masktolowest((ushort3)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_masktolowest(short4 x)
        {
            return (short4)bits_masktolowest((ushort4)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_masktolowest(short8 x)
        {
            return (short8)bits_masktolowest((ushort8)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_masktolowest(short16 x)
        {
            return (short16)bits_masktolowest((ushort16)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_masktolowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsmsk_u32(x);
            }
            else
            {
                return x ^ (x - 1);
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_masktolowest(uint2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.blsmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(bits_masktolowest(x.x), bits_masktolowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_masktolowest(uint3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.blsmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(bits_masktolowest(x.x), bits_masktolowest(x.y), bits_masktolowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_masktolowest(uint4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.blsmsk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(bits_masktolowest(x.x), bits_masktolowest(x.y), bits_masktolowest(x.z), bits_masktolowest(x.w));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_masktolowest(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsmsk_epi32(x);
            }
            else
            {
                return new uint8(bits_masktolowest(x.v4_0), bits_masktolowest(x.v4_4));
            }
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_masktolowest(int x)
        {
            return (int)bits_masktolowest((uint)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_masktolowest(int2 x)
        {
            return (int2)bits_masktolowest((uint2)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_masktolowest(int3 x)
        {
            return (int3)bits_masktolowest((uint3)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_masktolowest(int4 x)
        {
            return (int4)bits_masktolowest((uint4)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_masktolowest(int8 x)
        {
            return (int8)bits_masktolowest((uint8)x);
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_masktolowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsmsk_u64(x);
            }
            else
            {
                return x ^ (x - 1);
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_masktolowest(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.blsmsk_epi64(x);
            }
            else
            {
                return new ulong2(bits_masktolowest(x.x), bits_masktolowest(x.y));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_masktolowest(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsmsk_epi64(x);
            }
            else
            {
                return new ulong3(bits_masktolowest(x.xy), bits_masktolowest(x.z));
            }
        }

        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_masktolowest(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsmsk_epi64(x);
            }
            else
            {
                return new ulong4(bits_masktolowest(x.xy), bits_masktolowest(x.zw));
            }
        }


        /// <summary>       Sets all the low order bits up to and including the lowest set bit in <paramref name="x"/> to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_masktolowest(long x)
        {
            return (long)bits_masktolowest((ulong)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_masktolowest(long2 x)
        {
            return (long2)bits_masktolowest((ulong2)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_masktolowest(long3 x)
        {
            return (long3)bits_masktolowest((ulong3)x);
        }
        
        /// <summary>       Sets all the componentwise low order bits up to and including the lowest set bits in each <paramref name="x"/> component to 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_masktolowest(long4 x)
        {
            return (long4)bits_masktolowest((ulong4)x);
        }
    }
}