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
            public static v128 bmsfill_epi8(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, lzmsk_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bmsfill_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, lzmsk_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bmsfill_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, lzmsk_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bmsfill_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(a, lzmsk_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bmsfill_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_lzmsk_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bmsfill_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_lzmsk_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bmsfill_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_lzmsk_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bmsfill_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(a, mm256_lzmsk_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lzfill(UInt128 x)
        {
            return x | lzmask(x);
        }

        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 lzfill(Int128 x)
        {
            return (Int128)lzfill((UInt128)x);
        }


        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte lzfill(byte x)
        {
            return (byte)(x | lzmask(x));
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lzfill(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi8(x);
            }
            else
            {
                return new byte2(lzfill(x.x), lzfill(x.y));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lzfill(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi8(x);
            }
            else
            {
                return new byte3(lzfill(x.x), lzfill(x.y), lzfill(x.z));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lzfill(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi8(x);
            }
            else
            {
                return new byte4(lzfill(x.x), lzfill(x.y), lzfill(x.z), lzfill(x.w));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lzfill(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi8(x);
            }
            else
            {
                return new byte8(lzfill(x.x0),
                                 lzfill(x.x1),
                                 lzfill(x.x2),
                                 lzfill(x.x3),
                                 lzfill(x.x4),
                                 lzfill(x.x5),
                                 lzfill(x.x6),
                                 lzfill(x.x7));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lzfill(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi8(x);
            }
            else
            {
                return new byte16(lzfill(x. x0),
                                  lzfill(x. x1),
                                  lzfill(x. x2),
                                  lzfill(x. x3),
                                  lzfill(x. x4),
                                  lzfill(x. x5),
                                  lzfill(x. x6),
                                  lzfill(x. x7),
                                  lzfill(x. x8),
                                  lzfill(x. x9),
                                  lzfill(x.x10),
                                  lzfill(x.x11),
                                  lzfill(x.x12),
                                  lzfill(x.x13),
                                  lzfill(x.x14),
                                  lzfill(x.x15));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lzfill(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bmsfill_epi8(x);
            }
            else
            {
                return new byte32(lzfill(x.v16_0), lzfill(x.v16_16));
            }
        }

        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte lzfill(sbyte x)
        {
            return (sbyte)lzfill((byte)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 lzfill(sbyte2 x)
        {
            return (sbyte2)lzfill((byte2)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 lzfill(sbyte3 x)
        {
            return (sbyte3)lzfill((byte3)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 lzfill(sbyte4 x)
        {
            return (sbyte4)lzfill((byte4)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 lzfill(sbyte8 x)
        {
            return (sbyte8)lzfill((byte8)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 lzfill(sbyte16 x)
        {
            return (sbyte16)lzfill((byte16)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 lzfill(sbyte32 x)
        {
            return (sbyte32)lzfill((byte32)x);
        }


        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort lzfill(ushort x)
        {
            return (ushort)(x | lzmask(x));
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lzfill(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi16(x);
            }
            else
            {
                return new ushort2(lzfill(x.x), lzfill(x.y));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lzfill(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi16(x);
            }
            else
            {
                return new ushort3(lzfill(x.x), lzfill(x.y), lzfill(x.z));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lzfill(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi16(x);
            }
            else
            {
                return new ushort4(lzfill(x.x), lzfill(x.y), lzfill(x.z), lzfill(x.w));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lzfill(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi16(x);
            }
            else
            {
                return new ushort8(lzfill(x.x0),
                                   lzfill(x.x1),
                                   lzfill(x.x2),
                                   lzfill(x.x3),
                                   lzfill(x.x4),
                                   lzfill(x.x5),
                                   lzfill(x.x6),
                                   lzfill(x.x7));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lzfill(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bmsfill_epi16(x);
            }
            else
            {
                return new ushort16(lzfill(x.v8_0), lzfill(x.v8_8));
            }
        }

        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short lzfill(short x)
        {
            return (short)lzfill((ushort)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 lzfill(short2 x)
        {
            return (short2)lzfill((ushort2)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 lzfill(short3 x)
        {
            return (short3)lzfill((ushort3)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 lzfill(short4 x)
        {
            return (short4)lzfill((ushort4)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 lzfill(short8 x)
        {
            return (short8)lzfill((ushort8)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 lzfill(short16 x)
        {
            return (short16)lzfill((ushort16)x);
        }


        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lzfill(uint x)
        {
            return x | lzmask(x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lzfill(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.bmsfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(lzfill(x.x), lzfill(x.y));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lzfill(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.bmsfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(lzfill(x.x), lzfill(x.y), lzfill(x.z));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lzfill(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.bmsfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(lzfill(x.x), lzfill(x.y), lzfill(x.z), lzfill(x.w));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lzfill(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bmsfill_epi32(x);
            }
            else
            {
                return new uint8(lzfill(x.v4_0), lzfill(x.v4_4));
            }
        }

        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lzfill(int x)
        {
            return (int)lzfill((uint)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 lzfill(int2 x)
        {
            return (int2)lzfill((uint2)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 lzfill(int3 x)
        {
            return (int3)lzfill((uint3)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 lzfill(int4 x)
        {
            return (int4)lzfill((uint4)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 lzfill(int8 x)
        {
            return (int8)lzfill((uint8)x);
        }


        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lzfill(ulong x)
        {
            return x | lzmask(x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lzfill(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bmsfill_epi64(x);
            }
            else
            {
                return new ulong2(lzfill(x.x), lzfill(x.y));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lzfill(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bmsfill_epi64(x);
            }
            else
            {
                return new ulong3(lzfill(x.xy), lzfill(x.z));
            }
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lzfill(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bmsfill_epi64(x);
            }
            else
            {
                return new ulong4(lzfill(x.xy), lzfill(x.zw));
            }
        }

        /// <summary>       Sets all leading zero bits in <paramref name="x"/> to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long lzfill(long x)
        {
            return (long)lzfill((ulong)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 lzfill(long2 x)
        {
            return (long2)lzfill((ulong2)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 lzfill(long3 x)
        {
            return (long3)lzfill((ulong3)x);
        }

        /// <summary>       Sets all leading zero bits in each <paramref name="x"/> component to 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 lzfill(long4 x)
        {
            return (long4)lzfill((ulong4)x);
        }
    }
}
