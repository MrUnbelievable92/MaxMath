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
            public static v128 blcfill_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcfill_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcfill_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 blcfill_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return and_si128(a, inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcfill_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_inc_epi8(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcfill_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_inc_epi16(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcfill_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_inc_epi32(a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_blcfill_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(a, mm256_inc_epi64(a));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 t1clear(UInt128 x)
        {
            return x & (x + 1);
        }

        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 t1clear(Int128 x)
        {
            return (Int128)t1clear((UInt128)x);
        }


        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1clear(byte x)
        {
            return (byte)t1clear((uint)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 t1clear(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi8(x);
            }
            else
            {
                return new byte2(t1clear(x.x), t1clear(x.y));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 t1clear(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi8(x);
            }
            else
            {
                return new byte3(t1clear(x.x), t1clear(x.y), t1clear(x.z));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 t1clear(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi8(x);
            }
            else
            {
                return new byte4(t1clear(x.x), t1clear(x.y), t1clear(x.z), t1clear(x.w));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 t1clear(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi8(x);
            }
            else
            {
                return new byte8(t1clear(x.x0),
                                 t1clear(x.x1),
                                 t1clear(x.x2),
                                 t1clear(x.x3),
                                 t1clear(x.x4),
                                 t1clear(x.x5),
                                 t1clear(x.x6),
                                 t1clear(x.x7));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 t1clear(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi8(x);
            }
            else
            {
                return new byte16(t1clear(x. x0),
                                  t1clear(x. x1),
                                  t1clear(x. x2),
                                  t1clear(x. x3),
                                  t1clear(x. x4),
                                  t1clear(x. x5),
                                  t1clear(x. x6),
                                  t1clear(x. x7),
                                  t1clear(x. x8),
                                  t1clear(x. x9),
                                  t1clear(x.x10),
                                  t1clear(x.x11),
                                  t1clear(x.x12),
                                  t1clear(x.x13),
                                  t1clear(x.x14),
                                  t1clear(x.x15));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 t1clear(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcfill_epi8(x);
            }
            else
            {
                return new byte32(t1clear(x.v16_0), t1clear(x.v16_16));
            }
        }

        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte t1clear(sbyte x)
        {
            return (sbyte)t1clear((byte)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 t1clear(sbyte2 x)
        {
            return (sbyte2)t1clear((byte2)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 t1clear(sbyte3 x)
        {
            return (sbyte3)t1clear((byte3)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 t1clear(sbyte4 x)
        {
            return (sbyte4)t1clear((byte4)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 t1clear(sbyte8 x)
        {
            return (sbyte8)t1clear((byte8)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 t1clear(sbyte16 x)
        {
            return (sbyte16)t1clear((byte16)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 t1clear(sbyte32 x)
        {
            return (sbyte32)t1clear((byte32)x);
        }


        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort t1clear(ushort x)
        {
            return (ushort)t1clear((uint)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 t1clear(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi16(x);
            }
            else
            {
                return new ushort2(t1clear(x.x), t1clear(x.y));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 t1clear(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi16(x);
            }
            else
            {
                return new ushort3(t1clear(x.x), t1clear(x.y), t1clear(x.z));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 t1clear(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi16(x);
            }
            else
            {
                return new ushort4(t1clear(x.x), t1clear(x.y), t1clear(x.z), t1clear(x.w));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 t1clear(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi16(x);
            }
            else
            {
                return new ushort8(t1clear(x.x0),
                                   t1clear(x.x1),
                                   t1clear(x.x2),
                                   t1clear(x.x3),
                                   t1clear(x.x4),
                                   t1clear(x.x5),
                                   t1clear(x.x6),
                                   t1clear(x.x7));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 t1clear(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcfill_epi16(x);
            }
            else
            {
                return new ushort16(t1clear(x.v8_0), t1clear(x.v8_8));
            }
        }

        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short t1clear(short x)
        {
            return (short)t1clear((ushort)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 t1clear(short2 x)
        {
            return (short2)t1clear((ushort2)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 t1clear(short3 x)
        {
            return (short3)t1clear((ushort3)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 t1clear(short4 x)
        {
            return (short4)t1clear((ushort4)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 t1clear(short8 x)
        {
            return (short8)t1clear((ushort8)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 t1clear(short16 x)
        {
            return (short16)t1clear((ushort16)x);
        }


        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint t1clear(uint x)
        {
            return x & (x + 1);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 t1clear(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.blcfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(t1clear(x.x), t1clear(x.y));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 t1clear(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.blcfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(t1clear(x.x), t1clear(x.y), t1clear(x.z));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 t1clear(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.blcfill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(t1clear(x.x), t1clear(x.y), t1clear(x.z), t1clear(x.w));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 t1clear(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcfill_epi32(x);
            }
            else
            {
                return new uint8(t1clear(x.v4_0), t1clear(x.v4_4));
            }
        }

        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int t1clear(int x)
        {
            return (int)t1clear((uint)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 t1clear(int2 x)
        {
            return (int2)t1clear((uint2)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 t1clear(int3 x)
        {
            return (int3)t1clear((uint3)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 t1clear(int4 x)
        {
            return (int4)t1clear((uint4)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 t1clear(int8 x)
        {
            return (int8)t1clear((uint8)x);
        }


        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong t1clear(ulong x)
        {
            return x & (x + 1);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 t1clear(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.blcfill_epi64(x);
            }
            else
            {
                return new ulong2(t1clear(x.x), t1clear(x.y));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 t1clear(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcfill_epi64(x);
            }
            else
            {
                return new ulong3(t1clear(x.xy), t1clear(x.z));
            }
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 t1clear(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_blcfill_epi64(x);
            }
            else
            {
                return new ulong4(t1clear(x.xy), t1clear(x.zw));
            }
        }

        /// <summary>       Zeros out all trailing ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long t1clear(long x)
        {
            return (long)t1clear((ulong)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 t1clear(long2 x)
        {
            return (long2)t1clear((ulong2)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 t1clear(long3 x)
        {
            return (long3)t1clear((ulong3)x);
        }

        /// <summary>       Zeros out all trailing ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 t1clear(long4 x)
        {
            return (long4)t1clear((ulong4)x);
        }
    }
}
