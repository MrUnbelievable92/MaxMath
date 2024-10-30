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
            public static v128 vand_epi8(v128 v, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 16:
                        {
                            v = and_si128(v, bsrli_si128(v, 8 * sizeof(byte)));

                            goto case 8;
                        }
                        case 8:
                        {
                            v = and_si128(v, bsrli_si128(v, 4 * sizeof(byte)));

                            goto case 4;
                        }
                        case 4:
                        {
                            v = and_si128(v, bsrli_si128(v, 2 * sizeof(byte)));

                            goto case 2;
                        }
                        case 3:
                        {
                            v128 __v = v;
                            v = and_si128(v, bsrli_si128(__v, 2 * sizeof(byte)));
                            v = and_si128(v, bsrli_si128(__v, 1 * sizeof(byte)));

                            return v;
                        }
                        case 2:
                        {
                            v = and_si128(v, bsrli_si128(v, 1 * sizeof(byte)));

                            return v;
                        }

                        default: return v;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vand_epi16(v128 v, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 8:
                        {
                            v = and_si128(v, bsrli_si128(v, 4 * sizeof(short)));

                            goto case 4;
                        }
                        case 4:
                        {
                            v = and_si128(v, bsrli_si128(v, 2 * sizeof(short)));

                            goto case 2;
                        }
                        case 3:
                        {
                            v128 __v = v;
                            v = and_si128(v, bsrli_si128(__v, 2 * sizeof(short)));
                            v = and_si128(v, bsrli_si128(__v, 1 * sizeof(short)));

                            return v;
                        }
                        case 2:
                        {
                            v = and_si128(v, bsrli_si128(v, 1 * sizeof(short)));

                            return v;
                        }

                        default: return v;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vand_epi32(v128 v, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            v = and_si128(v, bsrli_si128(v, 2 * sizeof(int)));

                            goto case 2;
                        }
                        case 3:
                        {
                            v128 __v = v;
                            v = and_si128(v, bsrli_si128(__v, 2 * sizeof(int)));
                            v = and_si128(v, bsrli_si128(__v, 1 * sizeof(int)));

                            return v;
                        }
                        case 2:
                        {
                            v = and_si128(v, bsrli_si128(v, 1 * sizeof(int)));

                            return v;
                        }

                        default: return v;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vand_epi64(v128 v)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return and_si128(v, bsrli_si128(v, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vand_epi8(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 8 * sizeof(sbyte)));
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(sbyte)));
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(sbyte)));
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(sbyte)));

                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vand_epi16(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(short)));
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(short)));
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(short)));

                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vand_epi32(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(int)));
                    v = Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(int)));

                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vand_epi64(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_and_si256(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cand(byte2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi8(c, 2).Byte0;
            }
            else
            {
                return (byte)(c.x & c.y);
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cand(byte3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi8(c, 3).Byte0;
            }
            else
            {
                return (byte)(c.x & c.y & c.z);
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cand(byte4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi8(c, 4).Byte0;
            }
            else
            {
                return (byte)((c.x & c.y) & (c.z & c.w));
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.byte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cand(byte8 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi8(c, 8).Byte0;
            }
            else
            {
                return (byte)(((c.x0 & c.x1) & (c.x2 & c.x3)) & ((c.x4 & c.x5) & (c.x6 & c.x7)));
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.byte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cand(byte16 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi8(c, 16).Byte0;
            }
            else
            {
                return (byte)((((c.x0 & c.x1) & (c.x2 & c.x3)) & ((c.x4 & c.x5) & (c.x6 & c.x7))) & (((c.x8 & c.x9) & (c.x10 & c.x11)) & ((c.x12 & c.x13) & (c.x14 & c.x15))));
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.byte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cand(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vand_epi8(c);

                return Xse.and_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).Byte0;
            }
            else
            {
                return (byte)cand(c.v16_0 & c.v16_16);
            }
        }


        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cand(sbyte2 c)
        {
            return (sbyte)cand((byte2)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cand(sbyte3 c)
        {
            return (sbyte)cand((byte3)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cand(sbyte4 c)
        {
            return (sbyte)cand((byte4)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.sbyte8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cand(sbyte8 c)
        {
            return (sbyte)cand((byte8)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.sbyte16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cand(sbyte16 c)
        {
            return (sbyte)cand((byte16)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.sbyte32"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cand(sbyte32 c)
        {
            return (sbyte)cand((byte32)c);
        }


        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cand(ushort2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi16(c, 2).UShort0;
            }
            else
            {
                return (ushort)(c.x & c.y);
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cand(ushort3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi16(c, 3).UShort0;
            }
            else
            {
                return (ushort)(c.x & c.y & c.z);
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cand(ushort4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi16(c, 4).UShort0;
            }
            else
            {
                return (ushort)((c.x & c.y) & (c.z & c.w));
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ushort8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cand(ushort8 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi16(c, 8).UShort0;
            }
            else
            {
                return (ushort)(((c.x0 & c.x1) & (c.x2 & c.x3)) & ((c.x4 & c.x5) & (c.x6 & c.x7)));
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ushort16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cand(ushort16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vand_epi16(c);

                return Xse.and_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).UShort0;
            }
            else
            {
                return (ushort)cand(c.v8_0 & c.v8_8);
            }
        }


        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cand(short2 c)
        {
            return (short)cand((ushort2)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cand(short3 c)
        {
            return (short)cand((ushort3)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cand(short4 c)
        {
            return (short)cand((ushort4)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.short8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cand(short8 c)
        {
            return (short)cand((ushort8)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.short16"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cand(short16 c)
        {
            return (short)cand((ushort16)c);
        }


        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="int2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cand(int2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi32(RegisterConversion.ToV128(c), 2).SInt0;
            }
            else
            {
                return c.x & c.y;
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cand(int3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi32(RegisterConversion.ToV128(c), 3).SInt0;
            }
            else
            {
                return (c.x & c.y) & c.z;
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cand(int4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi32(RegisterConversion.ToV128(c), 4).SInt0;
            }
            else
            {
                return (c.x & c.y) & (c.z & c.w);
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of an <see cref="MaxMath.int8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cand(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vand_epi32(c);

                return Xse.and_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SInt0;
            }
            else
            {
                return cand(c.v4_0 & c.v4_4);
            }
        }



        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="uint2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cand(uint2 c)
        {
            return (uint)cand((int2)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cand(uint3 c)
        {
            return (uint)cand((int3)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cand(uint4 c)
        {
            return (uint)cand((int4)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.uint8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cand(uint8 c)
        {
            return (uint)cand((int8)c);
        }


        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cand(long2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vand_epi64(c).SLong0;
            }
            else
            {
                return c.x & c.y;
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cand(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 sum = Xse.and_si128(lo, Xse.bsrli_si128(lo, 1 * sizeof(ulong)));
                sum = Xse.and_si128(sum, hi);

                return sum.SLong0;
            }
            else
            {
                return cand(c.xy) & c.z;
            }
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cand(long4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vand_epi64(c);

                return Xse.and_si128(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SLong0;
            }
            else
            {
                return cand(c.xy & c.zw);
            }
        }


        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cand(ulong2 c)
        {
            return (ulong)cand((long2)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cand(ulong3 c)
        {
            return (ulong)cand((long3)c);
        }

        /// <summary>       Returns the horizontal bitwise AND reduction of components of a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cand(ulong4 c)
        {
            return (ulong)cand((long4)c);
        }
    }
}