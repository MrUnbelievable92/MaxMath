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
            public static v128 vmax_epu8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 16:
                        {
                            a = Sse2.max_epu8(a, Sse2.bsrli_si128(a, 8 * sizeof(byte)));

                            goto case 8;
                        }
                        case 8:
                        {
                            a = Sse2.max_epu8(a, Sse2.bsrli_si128(a, 4 * sizeof(byte)));

                            goto case 4;
                        }
                        case 4:
                        {
                            a = Sse2.max_epu8(a, Sse2.bsrli_si128(a, 2 * sizeof(byte)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return Sse2.max_epu8(Sse2.max_epu8(a, 
                                                               Sse2.bsrli_si128(a, 1 * sizeof(byte))),
                                                               Sse2.bsrli_si128(a, 2 * sizeof(byte)));
                        }
                        case 2:
                        {
                            return Sse2.max_epu8(a, Sse2.bsrli_si128(a, 1 * sizeof(byte)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epu8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_max_epu8(a, Avx2.mm256_bsrli_epi128(a, 8 * sizeof(byte)));
                    a = Avx2.mm256_max_epu8(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(byte)));
                    a = Avx2.mm256_max_epu8(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(byte)));

                    return Avx2.mm256_max_epu8(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(byte)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epu16(v128 a, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 8:
                        {
                            a = max_epu16(a, Sse2.bsrli_si128(a, 4 * sizeof(ushort)), elements);

                            goto case 4;
                        }
                        case 4:
                        {
                            a = max_epu16(a, Sse2.bsrli_si128(a, 2 * sizeof(ushort)), elements);

                            goto case 2;
                        }
                        case 3:
                        {
                            return max_epu16(max_epu16(a, 
                                                       Sse2.bsrli_si128(a, 1 * sizeof(ushort)), elements),
                                                       Sse2.bsrli_si128(a, 2 * sizeof(ushort)), elements);
                        }
                        case 2:
                        {
                            return max_epu16(a, Sse2.bsrli_si128(a, 1 * sizeof(ushort)), elements);
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_max_epu16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(ushort)));
                    a = Avx2.mm256_max_epu16(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(ushort)));

                    return Avx2.mm256_max_epu16(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(ushort)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epu32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            a = max_epu32(a, Sse2.bsrli_si128(a, 2 * sizeof(uint)), elements);

                            goto case 2;
                        }
                        case 3:
                        {
                            return max_epu32(max_epu32(a, 
                                                       Sse2.bsrli_si128(a, 1 * sizeof(uint)), elements),
                                                       Sse2.bsrli_si128(a, 2 * sizeof(uint)), elements);
                        }
                        case 2:
                        {
                            return max_epu32(a, Sse2.bsrli_si128(a, 1 * sizeof(uint)), elements);
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epu32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_max_epu32(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(uint)));

                    return Avx2.mm256_max_epu32(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(uint)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epu64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return max_epu64(a, Sse2.bsrli_si128(a, 1 * sizeof(ulong)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epu64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_max_epu64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(ulong)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epi8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 16:
                        {
                            a = max_epi8(a, Sse2.bsrli_si128(a, 8 * sizeof(sbyte)), elements);

                            goto case 8;
                        }
                        case 8:
                        {
                            a = max_epi8(a, Sse2.bsrli_si128(a, 4 * sizeof(sbyte)), elements);

                            goto case 4;
                        }
                        case 4:
                        {
                            a = max_epi8(a, Sse2.bsrli_si128(a, 2 * sizeof(sbyte)), elements);

                            goto case 2;
                        }
                        case 3:
                        {
                            return max_epi8(max_epi8(a, 
                                                     Sse2.bsrli_si128(a, 1 * sizeof(sbyte)), elements),
                                                     Sse2.bsrli_si128(a, 2 * sizeof(sbyte)), elements);
                        }
                        case 2:
                        {
                            return max_epi8(a, Sse2.bsrli_si128(a, 1 * sizeof(sbyte)), elements);
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_max_epi8(a, Avx2.mm256_bsrli_epi128(a, 8 * sizeof(sbyte)));
                    a = Avx2.mm256_max_epi8(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(sbyte)));
                    a = Avx2.mm256_max_epi8(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(sbyte)));

                    return Avx2.mm256_max_epi8(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(sbyte)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epi16(v128 a, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 8:
                        {
                            a = Sse2.max_epi16(a, Sse2.bsrli_si128(a, 4 * sizeof(short)));

                            goto case 4;
                        }
                        case 4:
                        {
                            a = Sse2.max_epi16(a, Sse2.bsrli_si128(a, 2 * sizeof(short)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return Sse2.max_epi16(Sse2.max_epi16(a, 
                                                                 Sse2.bsrli_si128(a, 1 * sizeof(short))),
                                                                 Sse2.bsrli_si128(a, 2 * sizeof(short)));
                        }
                        case 2:
                        {
                            return Sse2.max_epi16(a, Sse2.bsrli_si128(a, 1 * sizeof(short)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_max_epi16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(short)));
                    a = Avx2.mm256_max_epi16(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(short)));

                    return Avx2.mm256_max_epi16(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(short)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epi32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            a = max_epi32(a, Sse2.bsrli_si128(a, 2 * sizeof(uint)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return max_epi32(max_epi32(a, 
                                                       Sse2.bsrli_si128(a, 1 * sizeof(uint))),
                                                       Sse2.bsrli_si128(a, 2 * sizeof(uint)));
                        }
                        case 2:
                        {
                            return max_epi32(a, Sse2.bsrli_si128(a, 1 * sizeof(uint)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_max_epi32(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(uint)));

                    return Avx2.mm256_max_epi32(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(uint)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return max_epi64(a, Sse2.bsrli_si128(a, 1 * sizeof(ulong)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_max_epi64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(ulong)), elements);
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_ps(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            a = Sse.max_ps(a, Sse2.bsrli_si128(a, 2 * sizeof(uint)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return Sse.max_ps(Sse.max_ps(a, 
                                                         Sse2.bsrli_si128(a, 1 * sizeof(uint))),
                                                         Sse2.bsrli_si128(a, 2 * sizeof(uint)));
                        }
                        case 2:
                        {
                            return Sse.max_ps(a, Sse2.bsrli_si128(a, 1 * sizeof(uint)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_ps(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx.mm256_max_ps(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(float)));

                    return Avx.mm256_max_ps(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(float)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmax_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.max_pd(a, Sse2.bsrli_si128(a, 1 * sizeof(double)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmax_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_max_pd(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(double)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu8(c, 2).Byte0;
            }
            else
            {
                return (byte)math.max((uint)c.x, (uint)c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu8(c, 3).Byte0;
            }
            else
            {
                return (byte)math.max((uint)c.x, math.max((uint)c.y, (uint)c.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu8(c, 4).Byte0;
            }
            else
            {
                return (byte)math.max((uint)c.x, math.max((uint)c.y, math.max((uint)c.z, (uint)c.w)));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu8(c, 8).Byte0;
            }
            else
            {
                return cmax(max(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte16 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu8(c, 16).Byte0;
            }
            else
            {
                return cmax(max(c.v8_0, c.v8_8));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.byte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte32 c)
        {
            return cmax(max(c.v16_0, c.v16_16));
        }


        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi8(c, 2).SByte0;
            }
            else
            {
                return (sbyte)math.max((int)c.x, (int)c.y);
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi8(c, 3).SByte0;
            }
            else
            {
                return (sbyte)math.max((int)c.x, math.max((int)c.y, (int)c.z));
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi8(c, 4).SByte0;
            }
            else
            {
                return (sbyte)math.max((int)c.x, math.max((int)c.y, math.max((int)c.z, (int)c.w)));
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi8(c, 8).SByte0;
            }
            else
            {
                return cmax(max(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte16 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi8(c, 16).SByte0;
            }
            else
            {
                return cmax(max(c.v8_0, c.v8_8));
            }
        }

        /// <summary>       Returns the maximum component of an <see cref="MaxMath.sbyte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte32 c)
        {
            return cmax(max(c.v16_0, c.v16_16));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi16(c, 2).SShort0;
            }
            else
            {
                return (short)math.max((int)c.x, (int)c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi16(c, 3).SShort0;
            }
            else
            {
                return (short)math.max((int)c.x, math.max((int)c.y, (int)c.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi16(c, 4).SShort0;
            }
            else
            {
                return (short)math.max((int)c.x, math.max((int)c.y, math.max((int)c.z, (int)c.w)));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epi16(c, 8).SShort0;
            }
            else
            {
                return cmax(max(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.short16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short16 c)
        {
            return cmax(max(c.v8_0, c.v8_8));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu16(c, 2).UShort0;
            }
            else
            {
                return (ushort)math.max((uint)c.x, (uint)c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu16(c, 3).UShort0;
            }
            else
            {
                return (ushort)math.max((uint)c.x, math.max((uint)c.y, (uint)c.z));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu16(c, 4).UShort0;
            }
            else
            {
                return (ushort)math.max((uint)c.x, math.max((uint)c.y, math.max((uint)c.z, (uint)c.w)));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vmax_epu16(c, 8).UShort0;
            }
            else
            {
                return cmax(max(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort16 c)
        {
            return cmax(max(c.v8_0, c.v8_8));
        }


        /// <summary>       Returns the maximum component of an <see cref="MaxMath.int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmax(int8 c)
        {
            return math.cmax(math.max(c.v4_0, c.v4_4));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmax(uint8 c)
        {
            return math.cmax(math.max(c.v4_0, c.v4_4));
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long2 c)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return Xse.vmax_epi64(c).SLong0;
            }
            else
            {
                return math.max(c.x, c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            { 
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 max = Xse.max_epi64(lo, Sse2.bsrli_si128(lo, 1 * sizeof(long)));
                max = Xse.max_epi64(max, hi);

                return max.SLong0;
            }
            else
            {
                return math.max(math.max(c.x, c.z), c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long4 c)
        {
            if (Sse4_2.IsSse42Supported)
            {
                long2 temp = max(c.xy, c.zw);

                return max(temp, temp.yy).x;
            }
            else
            {
                return math.max(c.x, math.max(c.y, math.max(c.z, c.w)));
            }
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong2 c)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return max(c, c.yy).x;
            }
            else
            {
                return math.max(c.x, c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong3 c)
        {
            if (Avx2.IsAvx2Supported)
            { 
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 max = Xse.max_epu64(lo, Sse2.bsrli_si128(lo, 1 * sizeof(ulong)));
                max = Xse.max_epu64(max, hi);

                return max.ULong0;
            }
            else
            {
                return math.max(math.max(c.x, c.z), c.y);
            }
        }

        /// <summary>       Returns the maximum component of a <see cref="MaxMath.ulong4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong4 c)
        {
            if (Sse4_2.IsSse42Supported)
            {
                ulong2 temp = max(c.xy, c.zw);

                return max(temp, temp.yy).x;
            }
            else
            {
                return math.max(c.x, math.max(c.y, math.max(c.z, c.w)));
            }
        }


        /// <summary>       Returns the maximum component of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmax(float8 c)
        {
            return math.cmax(math.max(c.v4_0, c.v4_4));
        }
    }
}