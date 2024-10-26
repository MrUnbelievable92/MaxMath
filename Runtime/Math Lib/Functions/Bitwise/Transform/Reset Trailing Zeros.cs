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
            public static v128 blsfill_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsfill_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsfill_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blsfill_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsfill_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_dec_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsfill_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_dec_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsfill_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_dec_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blsfill_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_dec_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 tzfill(UInt128 x)
        {
            return x | (x - 1);
        }

        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 tzfill(Int128 x)
        {
            return (Int128)tzfill((UInt128)x);
        }


        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzfill(byte x)
        {
            return (byte)tzfill((uint)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzfill(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi8(x);
            }
            else
            {
                return new byte2(tzfill(x.x), tzfill(x.y));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzfill(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi8(x);
            }
            else
            {
                return new byte3(tzfill(x.x), tzfill(x.y), tzfill(x.z));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzfill(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi8(x);
            }
            else
            {
                return new byte4(tzfill(x.x), tzfill(x.y), tzfill(x.z), tzfill(x.w));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzfill(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi8(x);
            }
            else
            {
                return new byte8(tzfill(x.x0),
                                 tzfill(x.x1),
                                 tzfill(x.x2),
                                 tzfill(x.x3),
                                 tzfill(x.x4),
                                 tzfill(x.x5),
                                 tzfill(x.x6),
                                 tzfill(x.x7));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzfill(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi8(x);
            }
            else
            {
                return new byte16(tzfill(x. x0),
                                  tzfill(x. x1),
                                  tzfill(x. x2),
                                  tzfill(x. x3),
                                  tzfill(x. x4),
                                  tzfill(x. x5),
                                  tzfill(x. x6),
                                  tzfill(x. x7),
                                  tzfill(x. x8),
                                  tzfill(x. x9),
                                  tzfill(x.x10),
                                  tzfill(x.x11),
                                  tzfill(x.x12),
                                  tzfill(x.x13),
                                  tzfill(x.x14),
                                  tzfill(x.x15));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tzfill(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsfill_epi8(x);
            }
            else
            {
                return new byte32(tzfill(x.v16_0), tzfill(x.v16_16));
            }
        }

        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tzfill(sbyte x)
        {
            return (sbyte)tzfill((byte)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzfill(sbyte2 x)
        {
            return (sbyte2)tzfill((byte2)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzfill(sbyte3 x)
        {
            return (sbyte3)tzfill((byte3)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzfill(sbyte4 x)
        {
            return (sbyte4)tzfill((byte4)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzfill(sbyte8 x)
        {
            return (sbyte8)tzfill((byte8)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzfill(sbyte16 x)
        {
            return (sbyte16)tzfill((byte16)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzfill(sbyte32 x)
        {
            return (sbyte32)tzfill((byte32)x);
        }


        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort tzfill(ushort x)
        {
            return (ushort)tzfill((uint)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzfill(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi16(x);
            }
            else
            {
                return new ushort2(tzfill(x.x), tzfill(x.y));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzfill(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi16(x);
            }
            else
            {
                return new ushort3(tzfill(x.x), tzfill(x.y), tzfill(x.z));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzfill(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi16(x);
            }
            else
            {
                return new ushort4(tzfill(x.x), tzfill(x.y), tzfill(x.z), tzfill(x.w));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzfill(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi16(x);
            }
            else
            {
                return new ushort8(tzfill(x.x0),
                                   tzfill(x.x1),
                                   tzfill(x.x2),
                                   tzfill(x.x3),
                                   tzfill(x.x4),
                                   tzfill(x.x5),
                                   tzfill(x.x6),
                                   tzfill(x.x7));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 tzfill(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsfill_epi16(x);
            }
            else
            {
                return new ushort16(tzfill(x.v8_0), tzfill(x.v8_8));
            }
        }

        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short tzfill(short x)
        {
            return (short)tzfill((ushort)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzfill(short2 x)
        {
            return (short2)tzfill((ushort2)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzfill(short3 x)
        {
            return (short3)tzfill((ushort3)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzfill(short4 x)
        {
            return (short4)tzfill((ushort4)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzfill(short8 x)
        {
            return (short8)tzfill((ushort8)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzfill(short16 x)
        {
            return (short16)tzfill((ushort16)x);
        }


        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint tzfill(uint x)
        {
            return x | (x - 1);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 tzfill(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blsfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(tzfill(x.x), tzfill(x.y));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 tzfill(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blsfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(tzfill(x.x), tzfill(x.y), tzfill(x.z));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 tzfill(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blsfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(tzfill(x.x), tzfill(x.y), tzfill(x.z), tzfill(x.w));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 tzfill(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsfill_epi32(x);
            }
            else
            {
                return new uint8(tzfill(x.v4_0), tzfill(x.v4_4));
            }
        }

        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tzfill(int x)
        {
            return (int)tzfill((uint)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tzfill(int2 x)
        {
            return (int2)tzfill((uint2)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tzfill(int3 x)
        {
            return (int3)tzfill((uint3)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tzfill(int4 x)
        {
            return (int4)tzfill((uint4)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzfill(int8 x)
        {
            return (int8)tzfill((uint8)x);
        }


        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong tzfill(ulong x)
        {
            return x | (x - 1);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzfill(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.blsfill_epi64(x);
            }
            else
            {
                return new ulong2(tzfill(x.x), tzfill(x.y));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 tzfill(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsfill_epi64(x);
            }
            else
            {
                return new ulong3(tzfill(x.xy), tzfill(x.z));
            }
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 tzfill(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blsfill_epi64(x);
            }
            else
            {
                return new ulong4(tzfill(x.xy), tzfill(x.zw));
            }
        }

        /// <summary>       Sets all trailing zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tzfill(long x)
        {
            return (long)tzfill((ulong)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzfill(long2 x)
        {
            return (long2)tzfill((ulong2)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzfill(long3 x)
        {
            return (long3)tzfill((ulong3)x);
        }

        /// <summary>       Sets all trailing zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzfill(long4 x)
        {
            return (long4)tzfill((ulong4)x);
        }
    }
}
