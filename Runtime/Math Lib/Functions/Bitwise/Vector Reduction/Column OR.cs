using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vor_epi8(v128 v, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 16:
                        {
                            v = or_si128(v, bsrli_si128(v, 8 * sizeof(byte)));

                            goto case 8;
                        }
                        case 8:
                        {
                            v = or_si128(v, bsrli_si128(v, 4 * sizeof(byte)));

                            goto case 4;
                        }
                        case 4:
                        {
                            v = or_si128(v, bsrli_si128(v, 2 * sizeof(byte)));

                            goto case 2;
                        }
                        case 3:
                        {
                            v128 __v = v;
                            v = or_si128(v, bsrli_si128(__v, 2 * sizeof(byte)));
                            v = or_si128(v, bsrli_si128(__v, 1 * sizeof(byte)));

                            return v;
                        }
                        case 2:
                        {
                            v = or_si128(v, bsrli_si128(v, 1 * sizeof(byte)));

                            return v;
                        }

                        default: return v;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vor_epi16(v128 v, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 8:
                        {
                            v = or_si128(v, bsrli_si128(v, 4 * sizeof(short)));

                            goto case 4;
                        }
                        case 4:
                        {
                            v = or_si128(v, bsrli_si128(v, 2 * sizeof(short)));

                            goto case 2;
                        }
                        case 3:
                        {
                            v128 __v = v;
                            v = or_si128(v, bsrli_si128(__v, 2 * sizeof(short)));
                            v = or_si128(v, bsrli_si128(__v, 1 * sizeof(short)));

                            return v;
                        }
                        case 2:
                        {
                            v = or_si128(v, bsrli_si128(v, 1 * sizeof(short)));

                            return v;
                        }

                        default: return v;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vor_epi32(v128 v, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            v = or_si128(v, bsrli_si128(v, 2 * sizeof(int)));

                            goto case 2;
                        }
                        case 3:
                        {
                            v128 __v = v;
                            v = or_si128(v, bsrli_si128(__v, 2 * sizeof(int)));
                            v = or_si128(v, bsrli_si128(__v, 1 * sizeof(int)));

                            return v;
                        }
                        case 2:
                        {
                            v = or_si128(v, bsrli_si128(v, 1 * sizeof(int)));

                            return v;
                        }

                        default: return v;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vor_epi64(v128 v)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return or_si128(v, bsrli_si128(v, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vor_epi8(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 8 * sizeof(sbyte)));
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(sbyte)));
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(sbyte)));
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(sbyte)));

                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vor_epi16(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(short)));
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(short)));
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(short)));

                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vor_epi32(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(int)));
                    v = Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(int)));

                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vor_epi64(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_or_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cor(byte2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi8(c, 2).Byte0;
            }
            else
            {
                return (byte)(c.x | c.y);
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cor(byte3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi8(c, 3).Byte0;
            }
            else
            {
                return (byte)(c.x | c.y | c.z);
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cor(byte4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi8(c, 4).Byte0;
            }
            else
            {
                return (byte)((c.x | c.y) | (c.z | c.w));
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.byte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cor(byte8 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi8(c, 8).Byte0;
            }
            else
            {
                return (byte)(((c.x0 | c.x1) | (c.x2 | c.x3)) | ((c.x4 | c.x5) | (c.x6 | c.x7)));
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.byte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cor(byte16 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi8(c, 16).Byte0;
            }
            else
            {
                return (byte)((((c.x0 | c.x1) | (c.x2 | c.x3)) | ((c.x4 | c.x5) | (c.x6 | c.x7))) | (((c.x8 | c.x9) | (c.x10 | c.x11)) | ((c.x12 | c.x13) | (c.x14 | c.x15))));
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.byte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cor(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vor_epi8(c);

                return Xse.or_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).Byte0;
            }
            else
            {
                return (byte)cor(c.v16_0 | c.v16_16);
            }
        }


        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cor(sbyte2 c)
        {
            return (sbyte)cor((byte2)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cor(sbyte3 c)
        {
            return (sbyte)cor((byte3)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cor(sbyte4 c)
        {
            return (sbyte)cor((byte4)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.sbyte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cor(sbyte8 c)
        {
            return (sbyte)cor((byte8)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.sbyte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cor(sbyte16 c)
        {
            return (sbyte)cor((byte16)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.sbyte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cor(sbyte32 c)
        {
            return (sbyte)cor((byte32)c);
        }


        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cor(ushort2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi16(c, 2).UShort0;
            }
            else
            {
                return (ushort)(c.x | c.y);
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cor(ushort3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi16(c, 3).UShort0;
            }
            else
            {
                return (ushort)(c.x | c.y | c.z);
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cor(ushort4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi16(c, 4).UShort0;
            }
            else
            {
                return (ushort)((c.x | c.y) | (c.z | c.w));
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ushort8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cor(ushort8 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi16(c, 8).UShort0;
            }
            else
            {
                return (ushort)(((c.x0 | c.x1) | (c.x2 | c.x3)) | ((c.x4 | c.x5) | (c.x6 | c.x7)));
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ushort16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cor(ushort16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vor_epi16(c);

                return Xse.or_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).UShort0;
            }
            else
            {
                return (ushort)cor(c.v8_0 | c.v8_8);
            }
        }


        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cor(short2 c)
        {
            return (short)cor((ushort2)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cor(short3 c)
        {
            return (short)cor((ushort3)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cor(short4 c)
        {
            return (short)cor((ushort4)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.short8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cor(short8 c)
        {
            return (short)cor((ushort8)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.short16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cor(short16 c)
        {
            return (short)cor((ushort16)c);
        }


        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="int2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cor(int2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi32(RegisterConversion.ToV128(c), 2).SInt0;
            }
            else
            {
                return c.x | c.y;
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cor(int3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi32(RegisterConversion.ToV128(c), 3).SInt0;
            }
            else
            {
                return (c.x | c.y) | c.z;
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cor(int4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi32(RegisterConversion.ToV128(c), 4).SInt0;
            }
            else
            {
                return (c.x | c.y) | (c.z | c.w);
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of an <see cref="MaxMath.int8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cor(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vor_epi32(c);

                return Xse.or_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SInt0;
            }
            else
            {
                return cor(c.v4_0 | c.v4_4);
            }
        }



        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="uint2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cor(uint2 c)
        {
            return (uint)cor((int2)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cor(uint3 c)
        {
            return (uint)cor((int3)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cor(uint4 c)
        {
            return (uint)cor((int4)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.uint8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cor(uint8 c)
        {
            return (uint)cor((int8)c);
        }


        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cor(long2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vor_epi64(c).SLong0;
            }
            else
            {
                return c.x | c.y;
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cor(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 sum = Xse.or_si128(lo, Xse.bsrli_si128(lo, 1 * sizeof(ulong)));
                sum = Xse.or_si128(sum, hi);

                return sum.SLong0;
            }
            else
            {
                return cor(c.xy) | c.z;
            }
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cor(long4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vor_epi64(c);

                return Xse.or_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SLong0;
            }
            else
            {
                return cor(c.xy | c.zw);
            }
        }


        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cor(ulong2 c)
        {
            return (ulong)cor((long2)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cor(ulong3 c)
        {
            return (ulong)cor((long3)c);
        }

        /// <summary>       Returns the horizontal bitwise OR reduction of components of a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cor(ulong4 c)
        {
            return (ulong)cor((long4)c);
        }
    }
}