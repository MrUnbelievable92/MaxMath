using System.Runtime.CompilerServices;
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
            public static v128 vmin_epu8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 16:
                        {
                            a = min_epu8(a, bsrli_si128(a, 8 * sizeof(byte)));

                            goto case 8;
                        }
                        case 8:
                        {
                            a = min_epu8(a, bsrli_si128(a, 4 * sizeof(byte)));

                            goto case 4;
                        }
                        case 4:
                        {
                            a = min_epu8(a, bsrli_si128(a, 2 * sizeof(byte)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_epu8(min_epu8(a,
                                                     bsrli_si128(a, 1 * sizeof(byte))),
                                                     bsrli_si128(a, 2 * sizeof(byte)));
                        }
                        case 2:
                        {
                            return min_epu8(a, bsrli_si128(a, 1 * sizeof(byte)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epu8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_min_epu8(a, Avx2.mm256_bsrli_epi128(a, 8 * sizeof(byte)));
                    a = Avx2.mm256_min_epu8(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(byte)));
                    a = Avx2.mm256_min_epu8(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(byte)));

                    return Avx2.mm256_min_epu8(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(byte)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epu16(v128 a, byte elements = 8)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    a = fillmissing_epi16(a, elements);

                    return minpos_epu16(a);
                }
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 8:
                        {
                            a = min_epu16(a, bsrli_si128(a, 4 * sizeof(ushort)), elements);
                            
                            goto case 4;
                        }
                        case 4:
                        {
                            a = min_epu16(a, bsrli_si128(a, 2 * sizeof(ushort)), elements);

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_epu16(min_epu16(a,
                                                       bsrli_si128(a, 1 * sizeof(ushort)), elements),
                                                       bsrli_si128(a, 2 * sizeof(ushort)), elements);
                        }
                        case 2:
                        {
                            return min_epu16(a, bsrli_si128(a, 1 * sizeof(ushort)), elements);
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_min_epu16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(ushort)));
                    a = Avx2.mm256_min_epu16(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(ushort)));

                    return Avx2.mm256_min_epu16(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(ushort)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epu32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            a = min_epu32(a, bsrli_si128(a, 2 * sizeof(uint)), elements);

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_epu32(min_epu32(a,
                                                       bsrli_si128(a, 1 * sizeof(uint)), elements),
                                                       bsrli_si128(a, 2 * sizeof(uint)), elements);
                        }
                        case 2:
                        {
                            return min_epu32(a, bsrli_si128(a, 1 * sizeof(uint)), elements);
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epu32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_min_epu32(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(uint)));

                    return Avx2.mm256_min_epu32(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(uint)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epu64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return min_epu64(a, bsrli_si128(a, 1 * sizeof(ulong)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epu64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_min_epu64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(ulong)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epi8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 16:
                        {
                            a = min_epi8(a, bsrli_si128(a, 8 * sizeof(sbyte)), elements);

                            goto case 8;
                        }
                        case 8:
                        {
                            a = min_epi8(a, bsrli_si128(a, 4 * sizeof(sbyte)), elements);

                            goto case 4;
                        }
                        case 4:
                        {
                            a = min_epi8(a, bsrli_si128(a, 2 * sizeof(sbyte)), elements);

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_epi8(min_epi8(a,
                                                     bsrli_si128(a, 1 * sizeof(sbyte)), elements),
                                                     bsrli_si128(a, 2 * sizeof(sbyte)), elements);
                        }
                        case 2:
                        {
                            return min_epi8(a, bsrli_si128(a, 1 * sizeof(sbyte)), elements);
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_min_epi8(a, Avx2.mm256_bsrli_epi128(a, 8 * sizeof(sbyte)));
                    a = Avx2.mm256_min_epi8(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(sbyte)));
                    a = Avx2.mm256_min_epi8(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(sbyte)));

                    return Avx2.mm256_min_epi8(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(sbyte)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epi16(v128 a, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 8:
                        {
                            a = min_epi16(a, bsrli_si128(a, 4 * sizeof(short)));

                            goto case 4;
                        }
                        case 4:
                        {
                            a = min_epi16(a, bsrli_si128(a, 2 * sizeof(short)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_epi16(min_epi16(a,
                                                       bsrli_si128(a, 1 * sizeof(short))),
                                                       bsrli_si128(a, 2 * sizeof(short)));
                        }
                        case 2:
                        {
                            return min_epi16(a, bsrli_si128(a, 1 * sizeof(short)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_min_epi16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(short)));
                    a = Avx2.mm256_min_epi16(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(short)));

                    return Avx2.mm256_min_epi16(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(short)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            a = min_epi32(a, bsrli_si128(a, 2 * sizeof(uint)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_epi32(min_epi32(a,
                                                       bsrli_si128(a, 1 * sizeof(uint))),
                                                       bsrli_si128(a, 2 * sizeof(uint)));
                        }
                        case 2:
                        {
                            return min_epi32(a, bsrli_si128(a, 1 * sizeof(uint)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_min_epi32(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(uint)));

                    return Avx2.mm256_min_epi32(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(uint)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return min_epi64(a, bsrli_si128(a, 1 * sizeof(ulong)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_min_epi64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(ulong)), elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_ps(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    switch (elements)
                    {
                        case 4:
                        {
                            a = min_ps(a, bsrli_si128(a, 2 * sizeof(uint)));

                            goto case 2;
                        }
                        case 3:
                        {
                            return min_ps(min_ps(a,
                                                 bsrli_si128(a, 1 * sizeof(uint))),
                                                 bsrli_si128(a, 2 * sizeof(uint)));
                        }
                        case 2:
                        {
                            return min_ps(a, bsrli_si128(a, 1 * sizeof(uint)));
                        }
                        default: return a;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_ps(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx.mm256_min_ps(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(float)));

                    return Avx.mm256_min_ps(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(float)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vmin_pd(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return min_pd(a, bsrli_si128(a, 1 * sizeof(double)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vmin_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_min_pd(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(double)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu8(c, 2).Byte0;
            }
            else
            {
                return (byte)min((uint)c.x, (uint)c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu8(c, 3).Byte0;
            }
            else
            {
                return (byte)min((uint)c.x, min((uint)c.y, (uint)c.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu8(c, 4).Byte0;
            }
            else
            {
                return (byte)min((uint)c.x, min((uint)c.y, min((uint)c.z, (uint)c.w)));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu8(c, 8).Byte0;
            }
            else
            {
                return cmin(min(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte16 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu8(c, 16).Byte0;
            }
            else
            {
                return cmin(min(c.v8_0, c.v8_8));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.byte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte32 c)
        {
            return cmin(min(c.v16_0, c.v16_16));
        }


        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi8(c, 2).SByte0;
            }
            else
            {
                return (sbyte)min((int)c.x, (int)c.y);
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi8(c, 3).SByte0;
            }
            else
            {
                return (sbyte)min((int)c.x, min((int)c.y, (int)c.z));
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi8(c, 4).SByte0;
            }
            else
            {
                return (sbyte)min((int)c.x, min((int)c.y, min((int)c.z, (int)c.w)));
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi8(c, 8).SByte0;
            }
            else
            {
                return cmin(min(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte16 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi8(c, 16).SByte0;
            }
            else
            {
                return cmin(min(c.v8_0, c.v8_8));
            }
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.sbyte32"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte32 c)
        {
            return cmin(min(c.v16_0, c.v16_16));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi16(c, 2).SShort0;
            }
            else
            {
                return (short)min((int)c.x, (int)c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi16(c, 3).SShort0;
            }
            else
            {
                return (short)min((int)c.x, min((int)c.y, (int)c.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi16(c, 4).SShort0;
            }
            else
            {
                return (short)min((int)c.x, min((int)c.y, min((int)c.z, (int)c.w)));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epi16(c, 8).SShort0;
            }
            else
            {
                return cmin(min(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.short16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short16 c)
        {
            return cmin(min(c.v8_0, c.v8_8));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu16(c, 2).UShort0;
            }
            else
            {
                return (ushort)min((uint)c.x, (uint)c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu16(c, 3).UShort0;
            }
            else
            {
                return (ushort)min((uint)c.x, min((uint)c.y, (uint)c.z));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu16(c, 4).UShort0;
            }
            else
            {
                return (ushort)min((uint)c.x, min((uint)c.y, min((uint)c.z, (uint)c.w)));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vmin_epu16(c, 8).UShort0;
            }
            else
            {
                return cmin(min(c.v4_0, c.v4_4));
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort16 c)
        {
            return cmin(min(c.v8_0, c.v8_8));
        }

        
        /// <summary>       Returns the minimum component of an <see cref="MaxMath.int2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int2 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.int3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int3 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.int4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int4 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of an <see cref="MaxMath.int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int8 c)
        {
            return cmin(min(c.v4_0, c.v4_4));
        }

        
        /// <summary>       Returns the minimum component of a <see cref="MaxMath.uint2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint2 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.uint3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint3 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.uint4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint4 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint8 c)
        {
            return cmin(min(c.v4_0, c.v4_4));
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long2 c)
        {
            if (BurstArchitecture.IsCMP64Supported)
            {
                return Xse.vmin_epi64(c).SLong0;
            }
            else
            {
                return min(c.x, c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 min = Xse.min_epi64(lo, Xse.bsrli_si128(lo, 1 * sizeof(long)));
                min = Xse.min_epi64(min, hi);

                return min.SLong0;
            }
            else
            {
                return min(min(c.x, c.z), c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long4 c)
        {
            if (BurstArchitecture.IsCMP64Supported)
            {
                long2 temp = min(c.xy, c.zw);

                return min(temp, temp.yy).x;
            }
            else
            {
                return min(c.x, min(c.y, min(c.z, c.w)));
            }
        }


        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong2 c)
        {
            if (BurstArchitecture.IsCMP64Supported)
            {
                return min(c, c.yy).x;
            }
            else
            {
                return min(c.x, c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 min = Xse.min_epu64(lo, Xse.bsrli_si128(lo, 1 * sizeof(ulong)));
                min = Xse.min_epu64(min, hi);

                return min.ULong0;
            }
            else
            {
                return min(min(c.x, c.z), c.y);
            }
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.ulong4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong4 c)
        {
            if (BurstArchitecture.IsCMP64Supported)
            {
                ulong2 temp = min(c.xy, c.zw);

                return min(temp, temp.yy).x;
            }
            else
            {
                return min(c.x, min(c.y, min(c.z, c.w)));
            }
        }

        
        /// <summary>       Returns the minimum component of a <see cref="MaxMath.float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float2 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float3 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float4 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float8 c)
        {
            return cmin(min(c.v4_0, c.v4_4));
        }

        
        /// <summary>       Returns the minimum component of a <see cref="MaxMath.double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cmin(double2 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cmin(double3 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }

        /// <summary>       Returns the minimum component of a <see cref="MaxMath.double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cmin(double4 c)
        {
            return Unity.Mathematics.math.cmin(c);
        }
    }
}