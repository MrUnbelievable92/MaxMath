using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
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
            public static void vminmax_epi8(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epi8(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(byte)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 16:
                        {
                            vmin = min_epi8(vmin, Sse2.bsrli_si128(vmin, 4 * sizeof(byte)));
                            vmax = max_epi8(vmax, Sse2.bsrli_si128(vmax, 4 * sizeof(byte)));
                            vmin = min_epi8(vmin, Sse2.bsrli_si128(vmin, 2 * sizeof(byte)));
                            vmax = max_epi8(vmax, Sse2.bsrli_si128(vmax, 2 * sizeof(byte)));
                            vmin = min_epi8(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(byte)));
                            vmax = max_epi8(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(byte)));

                            return;
                        }
                        case 8:
                        {
                            vmin = min_epi8(vmin, Sse2.bsrli_si128(vmin, 2 * sizeof(byte)));
                            vmax = max_epi8(vmax, Sse2.bsrli_si128(vmax, 2 * sizeof(byte)));
                            vmin = min_epi8(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(byte)));
                            vmax = max_epi8(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(byte)));

                            return;
                        }
                        case 4:
                        {
                            vmin = min_epi8(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(byte)));
                            vmax = max_epi8(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(byte)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(byte));
                            vmin = min_epi8(vmin, a);
                            vmax = max_epi8(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epi16(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epi16(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(short)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 8:
                        {
                            vmin = Sse2.min_epi16(vmin, Sse2.bsrli_si128(vmin, 2 * sizeof(short)));
                            vmax = Sse2.max_epi16(vmax, Sse2.bsrli_si128(vmax, 2 * sizeof(short)));
                            vmin = Sse2.min_epi16(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(short)));
                            vmax = Sse2.max_epi16(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(short)));

                            return;
                        }
                        case 4:
                        {
                            vmin = Sse2.min_epi16(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(short)));
                            vmax = Sse2.max_epi16(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(short)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(short));
                            vmin = Sse2.min_epi16(vmin, a);
                            vmax = Sse2.max_epi16(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epi32(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epi32(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(int)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 4:
                        {
                            vmin = min_epi32(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(int)));
                            vmax = max_epi32(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(int)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(int));
                            vmin = min_epi32(vmin, a);
                            vmax = max_epi32(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epi64(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epi64(a, Sse2.bsrli_si128(a, 1 * sizeof(long)), out vmin, out vmax);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epu8(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epu8(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(byte)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 16:
                        {
                            vmin = Sse2.min_epu8(vmin, Sse2.bsrli_si128(vmin, 4 * sizeof(byte)));
                            vmax = Sse2.max_epu8(vmax, Sse2.bsrli_si128(vmax, 4 * sizeof(byte)));
                            vmin = Sse2.min_epu8(vmin, Sse2.bsrli_si128(vmin, 2 * sizeof(byte)));
                            vmax = Sse2.max_epu8(vmax, Sse2.bsrli_si128(vmax, 2 * sizeof(byte)));
                            vmin = Sse2.min_epu8(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(byte)));
                            vmax = Sse2.max_epu8(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(byte)));

                            return;
                        }
                        case 8:
                        {
                            vmin = Sse2.min_epu8(vmin, Sse2.bsrli_si128(vmin, 2 * sizeof(byte)));
                            vmax = Sse2.max_epu8(vmax, Sse2.bsrli_si128(vmax, 2 * sizeof(byte)));
                            vmin = Sse2.min_epu8(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(byte)));
                            vmax = Sse2.max_epu8(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(byte)));

                            return;
                        }
                        case 4:
                        {
                            vmin = Sse2.min_epu8(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(byte)));
                            vmax = Sse2.max_epu8(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(byte)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(byte));
                            vmin = Sse2.min_epu8(vmin, a);
                            vmax = Sse2.max_epu8(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epu16(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epu16(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(short)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 8:
                        {
                            vmin = min_epu16(vmin, Sse2.bsrli_si128(vmin, 2 * sizeof(short)));
                            vmax = max_epu16(vmax, Sse2.bsrli_si128(vmax, 2 * sizeof(short)));
                            vmin = min_epu16(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(short)));
                            vmax = max_epu16(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(short)));

                            return;
                        }
                        case 4:
                        {
                            vmin = min_epu16(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(short)));
                            vmax = max_epu16(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(short)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(short));
                            vmin = min_epu16(vmin, a);
                            vmax = max_epu16(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epu32(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epu32(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(int)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 4:
                        {
                            vmin = min_epu32(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(int)));
                            vmax = max_epu32(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(int)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(int));
                            vmin = min_epu32(vmin, a);
                            vmax = max_epu32(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_epu64(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_epu64(a, Sse2.bsrli_si128(a, 1 * sizeof(long)), out vmin, out vmax);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_ps(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_ps(a, Sse2.bsrli_si128(a, (elements / 2) * sizeof(float)), out vmin, out vmax);

                    switch (elements)
                    {
                        case 4:
                        {
                            vmin = Sse.min_ps(vmin, Sse2.bsrli_si128(vmin, 1 * sizeof(float)));
                            vmax = Sse.max_ps(vmax, Sse2.bsrli_si128(vmax, 1 * sizeof(float)));

                            return;
                        }
                        case 3:
                        {
                            a = Sse2.bsrli_si128(a, 2 * sizeof(float));
                            vmin = Sse.min_ps(vmin, a);
                            vmax = Sse.max_ps(vmax, a);

                            return;
                        }
                        default: return;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void vminmax_pd(v128 a, [NoAlias] out v128 vmin, [NoAlias] out v128 vmax)
            {
                if (Sse2.IsSse2Supported)
                {
                    minmax_pd(a, Sse2.bsrli_si128(a, 1 * sizeof(double)), out vmin, out vmax);
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epi8(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epi8(a, Avx2.mm256_bsrli_epi128(a, 8 * sizeof(byte)), out vmin, out vmax);
                    vmin = Avx2.mm256_min_epi8(vmin, Avx2.mm256_bsrli_epi128(vmin, 4 * sizeof(byte)));
                    vmax = Avx2.mm256_max_epi8(vmax, Avx2.mm256_bsrli_epi128(vmax, 4 * sizeof(byte)));
                    vmin = Avx2.mm256_min_epi8(vmin, Avx2.mm256_bsrli_epi128(vmin, 2 * sizeof(byte)));
                    vmax = Avx2.mm256_max_epi8(vmax, Avx2.mm256_bsrli_epi128(vmax, 2 * sizeof(byte)));
                    vmin = Avx2.mm256_min_epi8(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(byte)));
                    vmax = Avx2.mm256_max_epi8(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(byte)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epi16(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epi16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(short)), out vmin, out vmax);
                    vmin = Avx2.mm256_min_epi16(vmin, Avx2.mm256_bsrli_epi128(vmin, 2 * sizeof(short)));
                    vmax = Avx2.mm256_max_epi16(vmax, Avx2.mm256_bsrli_epi128(vmax, 2 * sizeof(short)));
                    vmin = Avx2.mm256_min_epi16(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(short)));
                    vmax = Avx2.mm256_max_epi16(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(short)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epi32(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epi32(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(int)), out vmin, out vmax);
                    vmin = Avx2.mm256_min_epi32(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(int)));
                    vmax = Avx2.mm256_max_epi32(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(int)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epi64(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epi64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(long)), out vmin, out vmax, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epu8(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epu8(a, Avx2.mm256_bsrli_epi128(a, 8 * sizeof(byte)), out vmin, out vmax);
                    vmin = Avx2.mm256_min_epu8(vmin, Avx2.mm256_bsrli_epi128(vmin, 4 * sizeof(byte)));
                    vmax = Avx2.mm256_max_epu8(vmax, Avx2.mm256_bsrli_epi128(vmax, 4 * sizeof(byte)));
                    vmin = Avx2.mm256_min_epu8(vmin, Avx2.mm256_bsrli_epi128(vmin, 2 * sizeof(byte)));
                    vmax = Avx2.mm256_max_epu8(vmax, Avx2.mm256_bsrli_epi128(vmax, 2 * sizeof(byte)));
                    vmin = Avx2.mm256_min_epu8(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(byte)));
                    vmax = Avx2.mm256_max_epu8(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(byte)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epu16(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epu16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(short)), out vmin, out vmax);
                    vmin = Avx2.mm256_min_epu16(vmin, Avx2.mm256_bsrli_epi128(vmin, 2 * sizeof(short)));
                    vmax = Avx2.mm256_max_epu16(vmax, Avx2.mm256_bsrli_epi128(vmax, 2 * sizeof(short)));
                    vmin = Avx2.mm256_min_epu16(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(short)));
                    vmax = Avx2.mm256_max_epu16(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(short)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epu32(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epu32(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(int)), out vmin, out vmax);
                    vmin = Avx2.mm256_min_epu32(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(int)));
                    vmax = Avx2.mm256_max_epu32(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(int)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_epu64(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epu64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(long)), out vmin, out vmax, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_ps(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_ps(a, Avx2.mm256_bsrli_epi128(a, 2 * sizeof(float)), out vmin, out vmax);
                    vmin = Avx.mm256_min_ps(vmin, Avx2.mm256_bsrli_epi128(vmin, 1 * sizeof(float)));
                    vmax = Avx.mm256_max_ps(vmax, Avx2.mm256_bsrli_epi128(vmax, 1 * sizeof(float)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_vminmax_pd(v256 a, [NoAlias] out v256 vmin, [NoAlias] out v256 vmax)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_pd(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(double)), out vmin, out vmax);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(byte2 a, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu8(a, out v128 _min, out v128 _max, 2);
                min = _min.Byte0;
                max = _max.Byte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(byte3 a, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu8(a, out v128 _min, out v128 _max, 3);
                min = _min.Byte0;
                max = _max.Byte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(byte4 a, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu8(a, out v128 _min, out v128 _max, 4);
                min = _min.Byte0;
                max = _max.Byte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(byte8 a, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu8(a, out v128 _min, out v128 _max, 8);
                min = _min.Byte0;
                max = _max.Byte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(byte16 a, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu8(a, out v128 _min, out v128 _max, 16);
                min = _min.Byte0;
                max = _max.Byte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(byte32 a, [NoAlias] out byte min, [NoAlias] out byte max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epu8(a, out v256 _min, out v256 _max);
                min = Sse2.min_epu8(_min.Lo128, _min.Hi128).Byte0;
                max = Sse2.max_epu8(_max.Lo128, _max.Hi128).Byte0;
            }
            else
            {
                cminmax(a.v16_0,  out byte minLo, out byte maxLo);
                cminmax(a.v16_16, out byte minHi, out byte maxHi);

                min = maxmath.min(minLo, minHi);
                max = maxmath.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(sbyte2 a, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(a, out v128 _min, out v128 _max, 2);
                min = _min.SByte0;
                max = _max.SByte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(sbyte3 a, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(a, out v128 _min, out v128 _max, 3);
                min = _min.SByte0;
                max = _max.SByte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(sbyte4 a, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(a, out v128 _min, out v128 _max, 4);
                min = _min.SByte0;
                max = _max.SByte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(sbyte8 a, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(a, out v128 _min, out v128 _max, 8);
                min = _min.SByte0;
                max = _max.SByte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(sbyte16 a, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi8(a, out v128 _min, out v128 _max, 16);
                min = _min.SByte0;
                max = _max.SByte0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(sbyte32 a, [NoAlias] out sbyte min, [NoAlias] out sbyte max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi8(a, out v256 _min, out v256 _max);
                min = Sse4_1.min_epi8(_min.Lo128, _min.Hi128).SByte0;
                max = Sse4_1.max_epi8(_max.Lo128, _max.Hi128).SByte0;
            }
            else
            {
                cminmax(a.v16_0,  out sbyte minLo, out sbyte maxLo);
                cminmax(a.v16_16, out sbyte minHi, out sbyte maxHi);

                min = maxmath.min(minLo, minHi);
                max = maxmath.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ushort2 a, [NoAlias] out ushort min, [NoAlias] out ushort max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu16(a, out v128 _min, out v128 _max, 2);
                min = _min.UShort0;
                max = _max.UShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ushort3 a, [NoAlias] out ushort min, [NoAlias] out ushort max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu16(a, out v128 _min, out v128 _max, 3);
                min = _min.UShort0;
                max = _max.UShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ushort4 a, [NoAlias] out ushort min, [NoAlias] out ushort max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu16(a, out v128 _min, out v128 _max, 4);
                min = _min.UShort0;
                max = _max.UShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ushort8 a, [NoAlias] out ushort min, [NoAlias] out ushort max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu16(a, out v128 _min, out v128 _max, 8);
                min = _min.UShort0;
                max = _max.UShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ushort16 a, [NoAlias] out ushort min, [NoAlias] out ushort max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epu16(a, out v256 _min, out v256 _max);
                min = Sse4_1.min_epu16(_min.Lo128, _min.Hi128).UShort0;
                max = Sse4_1.max_epu16(_max.Lo128, _max.Hi128).UShort0;
            }
            else
            {
                cminmax(a.v8_0, out ushort minLo, out ushort maxLo);
                cminmax(a.v8_8, out ushort minHi, out ushort maxHi);

                min = maxmath.min(minLo, minHi);
                max = maxmath.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(short2 a, [NoAlias] out short min, [NoAlias] out short max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(a, out v128 _min, out v128 _max, 2);
                min = _min.SShort0;
                max = _max.SShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(short3 a, [NoAlias] out short min, [NoAlias] out short max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(a, out v128 _min, out v128 _max, 3);
                min = _min.SShort0;
                max = _max.SShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(short4 a, [NoAlias] out short min, [NoAlias] out short max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(a, out v128 _min, out v128 _max, 4);
                min = _min.SShort0;
                max = _max.SShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(short8 a, [NoAlias] out short min, [NoAlias] out short max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi16(a, out v128 _min, out v128 _max, 8);
                min = _min.SShort0;
                max = _max.SShort0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(short16 a, [NoAlias] out short min, [NoAlias] out short max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi16(a, out v256 _min, out v256 _max);
                min = Sse2.min_epi16(_min.Lo128, _min.Hi128).SShort0;
                max = Sse2.max_epi16(_max.Lo128, _max.Hi128).SShort0;
            }
            else
            {
                cminmax(a.v8_0, out short minLo, out short maxLo);
                cminmax(a.v8_8, out short minHi, out short maxHi);

                min = maxmath.min(minLo, minHi);
                max = maxmath.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(int2 a, [NoAlias] out int min, [NoAlias] out int max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 2);
                min = _min.SInt0;
                max = _max.SInt0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(int3 a, [NoAlias] out int min, [NoAlias] out int max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 3);
                min = _min.SInt0;
                max = _max.SInt0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="int4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(int4 a, [NoAlias] out int min, [NoAlias] out int max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi32(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 4);
                min = _min.SInt0;
                max = _max.SInt0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(int8 a, [NoAlias] out int min, [NoAlias] out int max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi32(a, out v256 _min, out v256 _max);
                min = Sse4_1.min_epi32(_min.Lo128, _min.Hi128).SInt0;
                max = Sse4_1.max_epi32(_max.Lo128, _max.Hi128).SInt0;
            }
            else
            {
                cminmax(a.v4_0, out int minLo, out int maxLo);
                cminmax(a.v4_4, out int minHi, out int maxHi);

                min = math.min(minLo, minHi);
                max = math.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(uint2 a, [NoAlias] out uint min, [NoAlias] out uint max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu32(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 2);
                min = _min.UInt0;
                max = _max.UInt0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(uint3 a, [NoAlias] out uint min, [NoAlias] out uint max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu32(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 3);
                min = _min.UInt0;
                max = _max.UInt0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="uint4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(uint4 a, [NoAlias] out uint min, [NoAlias] out uint max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu32(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 4);
                min = _min.UInt0;
                max = _max.UInt0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(uint8 a, [NoAlias] out uint min, [NoAlias] out uint max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epu32(a, out v256 _min, out v256 _max);
                min = Sse4_1.min_epu32(_min.Lo128, _min.Hi128).UInt0;
                max = Sse4_1.max_epu32(_max.Lo128, _max.Hi128).UInt0;
            }
            else
            {
                cminmax(a.v4_0, out uint minLo, out uint maxLo);
                cminmax(a.v4_4, out uint minHi, out uint maxHi);

                min = math.min(minLo, minHi);
                max = math.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ulong2 a, [NoAlias] out ulong min, [NoAlias] out ulong max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epu64(a, out v128 _min, out v128 _max);
                min = _min.ULong0;
                max = _max.ULong0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ulong3 a, [NoAlias] out ulong min, [NoAlias] out ulong max)
        {
            cminmax(a.xy, out ulong minLo, out ulong maxLo);

            min = math.min(minLo, a.z);
            max = math.max(maxLo, a.z);
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(ulong4 a, [NoAlias] out ulong min, [NoAlias] out ulong max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epu64(a, out v256 _min, out v256 _max, 4);
                min = Xse.min_epu64(_min.Lo128, _min.Hi128).ULong0;
                max = Xse.max_epu64(_max.Lo128, _max.Hi128).ULong0;
            }
            else
            {
                cminmax(a.xy, out ulong minLo, out ulong maxLo);
                cminmax(a.zw, out ulong minHi, out ulong maxHi);

                min = math.min(minLo, minHi);
                max = math.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(long2 a, [NoAlias] out long min, [NoAlias] out long max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_epi64(a, out v128 _min, out v128 _max);
                min = _min.SLong0;
                max = _max.SLong0;
            }
            else
            {
                min = cmin(a);
                max = cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(long3 a, [NoAlias] out long min, [NoAlias] out long max)
        {
            cminmax(a.xy, out long minLo, out long maxLo);

            min = math.min(minLo, a.z);
            max = math.max(maxLo, a.z);
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(long4 a, [NoAlias] out long min, [NoAlias] out long max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_epi64(a, out v256 _min, out v256 _max, 4);
                min = Xse.min_epi64(_min.Lo128, _min.Hi128).SLong0;
                max = Xse.max_epi64(_max.Lo128, _max.Hi128).SLong0;
            }
            else
            {
                cminmax(a.xy, out long minLo, out long maxLo);
                cminmax(a.zw, out long minHi, out long maxHi);

                min = math.min(minLo, minHi);
                max = math.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(float2 a, [NoAlias] out float min, [NoAlias] out float max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 2);
                min = _min.Float0;
                max = _max.Float0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(float3 a, [NoAlias] out float min, [NoAlias] out float max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 3);
                min = _min.Float0;
                max = _max.Float0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(float4 a, [NoAlias] out float min, [NoAlias] out float max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_ps(RegisterConversion.ToV128(a), out v128 _min, out v128 _max, 4);
                min = _min.Float0;
                max = _max.Float0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(float8 a, [NoAlias] out float min, [NoAlias] out float max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_ps(a, out v256 _min, out v256 _max);
                min = Sse.min_ps(_min.Lo128, _min.Hi128).Float0;
                max = Sse.max_ps(_max.Lo128, _max.Hi128).Float0;
            }
            else
            {
                cminmax(a.v4_0, out float minLo, out float maxLo);
                cminmax(a.v4_4, out float minHi, out float maxHi);

                min = math.min(minLo, minHi);
                max = math.max(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(double2 a, [NoAlias] out double min, [NoAlias] out double max)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.vminmax_pd(RegisterConversion.ToV128(a), out v128 _min, out v128 _max);
                min = _min.Double0;
                max = _max.Double0;
            }
            else
            {
                min = math.cmin(a);
                max = math.cmax(a);
            }
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.double3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(double3 a, [NoAlias] out double min, [NoAlias] out double max)
        {
            cminmax(a.xy, out double minLo, out double maxLo);

            min = math.min(minLo, a.z);
            max = math.max(maxLo, a.z);
        }

        /// <summary>       Returns the horizontal minimum '<paramref name="min"/>' and maximum '<paramref name="max"/>' of two <see cref="MaxMath.double4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cminmax(double4 a, [NoAlias] out double min, [NoAlias] out double max)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_vminmax_pd(RegisterConversion.ToV256(a), out v256 _min, out v256 _max);
                min = Sse2.min_pd(_min.Lo128, _min.Hi128).Double0;
                max = Sse2.max_pd(_max.Lo128, _max.Hi128).Double0;
            }
            else
            {
                cminmax(a.xy, out double minLo, out double maxLo);
                cminmax(a.zw, out double minHi, out double maxHi);

                min = math.min(minLo, minHi);
                max = math.max(maxLo, maxHi);
            }
        }
    }
}