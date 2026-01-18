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
            public static v128 t1msk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(inc_epi8(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1msk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(inc_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1msk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(inc_epi32(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1msk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(inc_epi64(a), a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_inc_epi8(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_inc_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_inc_epi32(a), a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1msk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_inc_epi64(a), a);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 t1mask(UInt128 x)
        {
            return andnot(x, x + 1);
        }

        /// <summary>       Sets all the trailing ones in the binary representation of an <see cref="Int128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 t1mask(Int128 x)
        {
            return (Int128)t1mask((UInt128)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="byte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1mask(byte x)
        {
            return andnot(x, (byte)(x + 1));
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 t1mask(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 t1mask(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte3(t1mask(x.x), t1mask(x.y), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 t1mask(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte4(t1mask(x.x), t1mask(x.y), t1mask(x.z), t1mask(x.w));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 t1mask(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte8(t1mask(x.x0), t1mask(x.x1), t1mask(x.x2), t1mask(x.x3), t1mask(x.x4), t1mask(x.x5), t1mask(x.x6), t1mask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 t1mask(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi8(x);
            }
            else
            {
                return new byte16(t1mask(x.x0), t1mask(x.x1), t1mask(x.x2), t1mask(x.x3), t1mask(x.x4), t1mask(x.x5), t1mask(x.x6), t1mask(x.x7), t1mask(x.x8), t1mask(x.x9), t1mask(x.x10), t1mask(x.x11), t1mask(x.x12), t1mask(x.x13), t1mask(x.x14), t1mask(x.x15));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.byte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 t1mask(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi8(x);
            }
            else
            {
                return new byte32(t1mask(x.v16_0), t1mask(x.v16_16));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of an <see cref="sbyte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte t1mask(sbyte x)
        {
            return (sbyte)t1mask((byte)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 t1mask(sbyte2 x)
        {
            return (sbyte2)t1mask((byte2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.sbyte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 t1mask(sbyte3 x)
        {
            return (sbyte3)t1mask((byte3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 t1mask(sbyte4 x)
        {
            return (sbyte4)t1mask((byte4)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 t1mask(sbyte8 x)
        {
            return (sbyte8)t1mask((byte8)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 t1mask(sbyte16 x)
        {
            return (sbyte16)t1mask((byte16)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 t1mask(sbyte32 x)
        {
            return (sbyte32)t1mask((byte32)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort t1mask(ushort x)
        {
            return andnot(x, (ushort)(x + 1));
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 t1mask(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 t1mask(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort3(t1mask(x.x), t1mask(x.y), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 t1mask(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort4(t1mask(x.x), t1mask(x.y), t1mask(x.z), t1mask(x.w));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 t1mask(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi16(x);
            }
            else
            {
                return new ushort8(t1mask(x.x0), t1mask(x.x1), t1mask(x.x2), t1mask(x.x3), t1mask(x.x4), t1mask(x.x5), t1mask(x.x6), t1mask(x.x7));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ushort16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 t1mask(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi16(x);
            }
            else
            {
                return new ushort16(t1mask(x.v8_0), t1mask(x.v8_8));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="short"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short t1mask(short x)
        {
            return (short)t1mask((ushort)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 t1mask(short2 x)
        {
            return (short2)t1mask((ushort2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 t1mask(short3 x)
        {
            return (short3)t1mask((ushort3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 t1mask(short4 x)
        {
            return (short4)t1mask((ushort4)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 t1mask(short8 x)
        {
            return (short8)t1mask((ushort8)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 t1mask(short16 x)
        {
            return (short16)t1mask((ushort16)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint t1mask(uint x)
        {
            return andnot(x, x + 1);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 t1mask(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.t1msk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 t1mask(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.t1msk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(t1mask(x.x), t1mask(x.y), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="uint4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 t1mask(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.t1msk_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(t1mask(x.x), t1mask(x.y), t1mask(x.z), t1mask(x.w));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.uint8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 t1mask(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi32(x);
            }
            else
            {
                return new uint8(t1mask(x.v4_0), t1mask(x.v4_4));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of an <see cref="int"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int t1mask(int x)
        {
            return (int)t1mask((uint)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 t1mask(int2 x)
        {
            return (int2)t1mask((uint2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 t1mask(int3 x)
        {
            return (int3)t1mask((uint3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="int4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 t1mask(int4 x)
        {
            return (int4)t1mask((uint4)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 t1mask(int8 x)
        {
            return (int8)t1mask((uint8)x);
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong t1mask(ulong x)
        {
            return andnot(x, x + 1);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 t1mask(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1msk_epi64(x);
            }
            else
            {
                return new ulong2(t1mask(x.x), t1mask(x.y));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ulong3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 t1mask(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi64(x);
            }
            else
            {
                return new ulong3(t1mask(x.xy), t1mask(x.z));
            }
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.ulong4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 t1mask(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1msk_epi64(x);
            }
            else
            {
                return new ulong4(t1mask(x.xy), t1mask(x.zw));
            }
        }


        /// <summary>       Sets all the trailing ones in the binary representation of a <see cref="long"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long t1mask(long x)
        {
            return (long)t1mask((ulong)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 t1mask(long2 x)
        {
            return (long2)t1mask((ulong2)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 t1mask(long3 x)
        {
            return (long3)t1mask((ulong3)x);
        }

        /// <summary>       Sets all the trailing ones in the binary representations of each <see cref="MaxMath.long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 t1mask(long4 x)
        {
            return (long4)t1mask((ulong4)x);
        }
    }
}
