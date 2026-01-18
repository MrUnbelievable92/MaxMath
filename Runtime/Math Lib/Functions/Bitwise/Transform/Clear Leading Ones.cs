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
            public static v128 bl1fill_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(l1msk_epi8(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bl1fill_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(l1msk_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bl1fill_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(l1msk_epi32(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bl1fill_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(l1msk_epi64(a), a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bl1fill_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_l1msk_epi8(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bl1fill_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_l1msk_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bl1fill_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_l1msk_epi32(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bl1fill_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_l1msk_epi64(a), a);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 l1clear(UInt128 x)
        {
            int __l1cnt = l1cnt(x);

            return (__l1cnt == 128) ? 0 : x & (UInt128.MaxValue >> __l1cnt);
        }

        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 l1clear(Int128 x)
        {
            return (Int128)l1clear((UInt128)x);
        }


        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte l1clear(byte x)
        {
            return (byte)l1clear((int)(sbyte)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 l1clear(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi8(x);
            }
            else
            {
                return new byte2(l1clear(x.x), l1clear(x.y));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 l1clear(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi8(x);
            }
            else
            {
                return new byte3(l1clear(x.x), l1clear(x.y), l1clear(x.z));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 l1clear(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi8(x);
            }
            else
            {
                return new byte4(l1clear(x.x), l1clear(x.y), l1clear(x.z), l1clear(x.w));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 l1clear(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi8(x);
            }
            else
            {
                return new byte8(l1clear(x.x0),
                                 l1clear(x.x1),
                                 l1clear(x.x2),
                                 l1clear(x.x3),
                                 l1clear(x.x4),
                                 l1clear(x.x5),
                                 l1clear(x.x6),
                                 l1clear(x.x7));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 l1clear(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi8(x);
            }
            else
            {
                return new byte16(l1clear(x. x0),
                                  l1clear(x. x1),
                                  l1clear(x. x2),
                                  l1clear(x. x3),
                                  l1clear(x. x4),
                                  l1clear(x. x5),
                                  l1clear(x. x6),
                                  l1clear(x. x7),
                                  l1clear(x. x8),
                                  l1clear(x. x9),
                                  l1clear(x.x10),
                                  l1clear(x.x11),
                                  l1clear(x.x12),
                                  l1clear(x.x13),
                                  l1clear(x.x14),
                                  l1clear(x.x15));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 l1clear(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bl1fill_epi8(x);
            }
            else
            {
                return new byte32(l1clear(x.v16_0), l1clear(x.v16_16));
            }
        }

        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte l1clear(sbyte x)
        {
            return (sbyte)l1clear((byte)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 l1clear(sbyte2 x)
        {
            return (sbyte2)l1clear((byte2)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 l1clear(sbyte3 x)
        {
            return (sbyte3)l1clear((byte3)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 l1clear(sbyte4 x)
        {
            return (sbyte4)l1clear((byte4)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 l1clear(sbyte8 x)
        {
            return (sbyte8)l1clear((byte8)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 l1clear(sbyte16 x)
        {
            return (sbyte16)l1clear((byte16)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 l1clear(sbyte32 x)
        {
            return (sbyte32)l1clear((byte32)x);
        }


        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort l1clear(ushort x)
        {
            return (ushort)l1clear((int)(short)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 l1clear(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi16(x);
            }
            else
            {
                return new ushort2(l1clear(x.x), l1clear(x.y));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 l1clear(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi16(x);
            }
            else
            {
                return new ushort3(l1clear(x.x), l1clear(x.y), l1clear(x.z));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 l1clear(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi16(x);
            }
            else
            {
                return new ushort4(l1clear(x.x), l1clear(x.y), l1clear(x.z), l1clear(x.w));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 l1clear(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi16(x);
            }
            else
            {
                return new ushort8(l1clear(x.x0),
                                   l1clear(x.x1),
                                   l1clear(x.x2),
                                   l1clear(x.x3),
                                   l1clear(x.x4),
                                   l1clear(x.x5),
                                   l1clear(x.x6),
                                   l1clear(x.x7));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 l1clear(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bl1fill_epi16(x);
            }
            else
            {
                return new ushort16(l1clear(x.v8_0), l1clear(x.v8_8));
            }
        }

        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short l1clear(short x)
        {
            return (short)l1clear((ushort)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 l1clear(short2 x)
        {
            return (short2)l1clear((ushort2)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 l1clear(short3 x)
        {
            return (short3)l1clear((ushort3)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 l1clear(short4 x)
        {
            return (short4)l1clear((ushort4)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 l1clear(short8 x)
        {
            return (short8)l1clear((ushort8)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 l1clear(short16 x)
        {
            return (short16)l1clear((ushort16)x);
        }


        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint l1clear(uint x)
        {
            return (uint)((ulong)x & ((ulong)uint.MaxValue >> l1cnt(x)));
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 l1clear(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.bl1fill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(l1clear(x.x), l1clear(x.y));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 l1clear(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.bl1fill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(l1clear(x.x), l1clear(x.y), l1clear(x.z));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 l1clear(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.bl1fill_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(l1clear(x.x), l1clear(x.y), l1clear(x.z), l1clear(x.w));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 l1clear(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bl1fill_epi32(x);
            }
            else
            {
                return new uint8(l1clear(x.v4_0), l1clear(x.v4_4));
            }
        }

        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1clear(int x)
        {
            return (int)l1clear((uint)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 l1clear(int2 x)
        {
            return (int2)l1clear((uint2)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 l1clear(int3 x)
        {
            return (int3)l1clear((uint3)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 l1clear(int4 x)
        {
            return (int4)l1clear((uint4)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 l1clear(int8 x)
        {
            return (int8)l1clear((uint8)x);
        }


        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong l1clear(ulong x)
        {
            // double register shift > branch
            return x & ((UInt128)ulong.MaxValue >> l1cnt(x)).lo64;
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 l1clear(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bl1fill_epi64(x);
            }
            else
            {
                return new ulong2(l1clear(x.x), l1clear(x.y));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 l1clear(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bl1fill_epi64(x);
            }
            else
            {
                return new ulong3(l1clear(x.xy), l1clear(x.z));
            }
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 l1clear(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bl1fill_epi64(x);
            }
            else
            {
                return new ulong4(l1clear(x.xy), l1clear(x.zw));
            }
        }

        /// <summary>       Zeros out all leading ones in <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long l1clear(long x)
        {
            return (long)l1clear((ulong)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 l1clear(long2 x)
        {
            return (long2)l1clear((ulong2)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 l1clear(long3 x)
        {
            return (long3)l1clear((ulong3)x);
        }

        /// <summary>       Zeros out all leading ones in each <paramref name="x"/> component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 l1clear(long4 x)
        {
            return (long4)l1clear((ulong4)x);
        }
    }
}
