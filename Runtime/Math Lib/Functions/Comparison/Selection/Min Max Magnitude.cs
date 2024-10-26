using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi8(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = adds_epi8(a, b);
                    minmax_epi8(a, b, out v128 min, out v128 max, elements);

                    minmag = blendv_epi8(min, max, cmp);
                    maxmag = blendv_epi8(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi16(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = adds_epi16(a, b);
                    minmax_epi16(a, b, out v128 min, out v128 max);

                    cmp = srai_epi16(cmp, 15);

                    minmag = blendv_si128(min, max, cmp);
                    maxmag = blendv_si128(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi32(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    minmax_epi32(a, b, out v128 min, out v128 max);

                    v128 cmp;
                    if (promiseNoOverflow)
                    {
                        cmp = add_epi32(a, b);
                    }
                    else if (Arm.Neon.IsNeonSupported)
                    {
                        cmp = adds_epi32(a, b);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 minAbs = abs_epi32(min, elements);
                            v128 maxAbs = abs_epi32(max, elements);
                            cmp = cmpgt_epi32(maxAbs, minAbs);

                            minmag = blendv_si128(max, min, cmp);
                            maxmag = blendv_si128(min, max, cmp);

                            return;
                        }
                        else
                        {
                            if (elements == 2)
                            {
                                cmp = add_epi64(cvtepi32_epi64(a), cvtepi32_epi64(b));
                                cmp = shuffle_epi32(cmp, Sse.SHUFFLE(0, 0, 3, 1));
                            }
                            else
                            {
                                v128 a64Lo = cvt2x2epi32_epi64(a, out v128 a64Hi);
                                v128 b64Lo = cvt2x2epi32_epi64(b, out v128 b64Hi);

                                v128 cmp64Lo = add_epi64(a64Lo, b64Lo);
                                v128 cmp64Hi = add_epi64(a64Hi, b64Hi);

                                cmp = shuffle_ps(cmp64Lo, cmp64Hi, Sse.SHUFFLE(3, 1, 3, 1));
                            }
                        }
                    }

                    minmag = blendv_ps(min, max, cmp);
                    maxmag = blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi64(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag, bool promiseNoOverflow = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = promiseNoOverflow ? add_epi64(a, b) : adds_epi64(a, b);
                    minmax_epi64(a, b, out v128 min, out v128 max);

                    minmag = blendv_pd(min, max, cmp);
                    maxmag = blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_ps(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = add_ps(a, b);
                    minmax_ps(a, b, out v128 min, out v128 max);

                    minmag = blendv_ps(min, max, cmp);
                    maxmag = blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_pd(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cmp = add_pd(a, b);
                    minmax_pd(a, b, out v128 min, out v128 max);

                    minmag = blendv_pd(min, max, cmp);
                    maxmag = blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi8(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_adds_epi8(a, b);
                    mm256_minmax_epi8(a, b, out v256 min, out v256 max);

                    minmag = Avx2.mm256_blendv_epi8(min, max, cmp);
                    maxmag = Avx2.mm256_blendv_epi8(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi16(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_adds_epi16(a, b);
                    mm256_minmax_epi16(a, b, out v256 min, out v256 max);
                    cmp = Avx2.mm256_srai_epi16(cmp, 15);

                    minmag = mm256_blendv_si256(min, max, cmp);
                    maxmag = mm256_blendv_si256(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi32(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epi32(a, b, out v256 min, out v256 max);

                    if (promiseNoOverflow)
                    {
                        v256 cmp = Avx2.mm256_add_epi32(a, b);

                        minmag = Avx.mm256_blendv_ps(min, max, cmp);
                        maxmag = Avx.mm256_blendv_ps(max, min, cmp);
                    }
                    else
                    {
                        v256 minAbs = mm256_abs_epi32(min);
                        v256 maxAbs = mm256_abs_epi32(max);

                        v256 cmp = Avx2.mm256_cmpgt_epi32(maxAbs, minAbs);

                        minmag = mm256_blendv_si256(max, min, cmp);
                        maxmag = mm256_blendv_si256(min, max, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi64(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = promiseNoOverflow ? Avx2.mm256_add_epi64(a, b) : mm256_adds_epi64(a, b, elements);
                    mm256_minmax_epi64(a, b, out v256 min, out v256 max, elements);

                    minmag = Avx.mm256_blendv_pd(min, max, cmp);
                    maxmag = Avx.mm256_blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_ps(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 cmp = Avx.mm256_add_ps(a, b);
                    mm256_minmax_ps(a, b, out v256 min, out v256 max);

                    minmag = Avx.mm256_blendv_ps(min, max, cmp);
                    maxmag = Avx.mm256_blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_pd(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 cmp = Avx.mm256_add_pd(a, b);
                    mm256_minmax_pd(a, b, out v256 min, out v256 max);

                    minmag = Avx.mm256_blendv_pd(min, max, cmp);
                    maxmag = Avx.mm256_blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="Int128"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(Int128 a, Int128 b, [NoAlias] out Int128 minmag, [NoAlias] out Int128 maxmag)
        {
            bool aMax = abs(a) > abs(b);

            minmag = aMax ? b : a;
            maxmag = aMax ? a : b;
        }


        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="sbyte"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte a, sbyte b, [NoAlias] out sbyte minmag, [NoAlias] out sbyte maxmag)
        {
            bool aMax = abs(a) > abs(b);

            minmag = aMax ? b : a;
            maxmag = aMax ? a : b;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte2 a, sbyte2 b, [NoAlias] out sbyte2 minmag, [NoAlias] out sbyte2 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 2);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte3 a, sbyte3 b, [NoAlias] out sbyte3 minmag, [NoAlias] out sbyte3 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 3);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte4 a, sbyte4 b, [NoAlias] out sbyte4 minmag, [NoAlias] out sbyte4 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 4);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
                maxmath.minmaxmag(a.w, b.w, out minmag.w, out maxmag.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte8 a, sbyte8 b, [NoAlias] out sbyte8 minmag, [NoAlias] out sbyte8 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 8);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x0, b.x0, out minmag.x0, out maxmag.x0);
                maxmath.minmaxmag(a.x1, b.x1, out minmag.x1, out maxmag.x1);
                maxmath.minmaxmag(a.x2, b.x2, out minmag.x2, out maxmag.x2);
                maxmath.minmaxmag(a.x3, b.x3, out minmag.x3, out maxmag.x3);
                maxmath.minmaxmag(a.x4, b.x4, out minmag.x4, out maxmag.x4);
                maxmath.minmaxmag(a.x5, b.x5, out minmag.x5, out maxmag.x5);
                maxmath.minmaxmag(a.x6, b.x6, out minmag.x6, out maxmag.x6);
                maxmath.minmaxmag(a.x7, b.x7, out minmag.x7, out maxmag.x7);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte16 a, sbyte16 b, [NoAlias] out sbyte16 minmag, [NoAlias] out sbyte16 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 16);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x0,  b.x0,  out minmag.x0,  out maxmag.x0);
                maxmath.minmaxmag(a.x1,  b.x1,  out minmag.x1,  out maxmag.x1);
                maxmath.minmaxmag(a.x2,  b.x2,  out minmag.x2,  out maxmag.x2);
                maxmath.minmaxmag(a.x3,  b.x3,  out minmag.x3,  out maxmag.x3);
                maxmath.minmaxmag(a.x4,  b.x4,  out minmag.x4,  out maxmag.x4);
                maxmath.minmaxmag(a.x5,  b.x5,  out minmag.x5,  out maxmag.x5);
                maxmath.minmaxmag(a.x6,  b.x6,  out minmag.x6,  out maxmag.x6);
                maxmath.minmaxmag(a.x7,  b.x7,  out minmag.x7,  out maxmag.x7);
                maxmath.minmaxmag(a.x8,  b.x8,  out minmag.x8,  out maxmag.x8);
                maxmath.minmaxmag(a.x9,  b.x9,  out minmag.x9,  out maxmag.x9);
                maxmath.minmaxmag(a.x10, b.x10, out minmag.x10, out maxmag.x10);
                maxmath.minmaxmag(a.x11, b.x11, out minmag.x11, out maxmag.x11);
                maxmath.minmaxmag(a.x12, b.x12, out minmag.x12, out maxmag.x12);
                maxmath.minmaxmag(a.x13, b.x13, out minmag.x13, out maxmag.x13);
                maxmath.minmaxmag(a.x14, b.x14, out minmag.x14, out maxmag.x14);
                maxmath.minmaxmag(a.x15, b.x15, out minmag.x15, out maxmag.x15);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte32"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte32 a, sbyte32 b, [NoAlias] out sbyte32 minmag, [NoAlias] out sbyte32 maxmag)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi8(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v16_0,  b.v16_0,  out sbyte16 minLo, out sbyte16 maxLo);
                minmaxmag(a.v16_16, b.v16_16, out sbyte16 minHi, out sbyte16 maxHi);

                minmag = new sbyte32(minLo, minHi);
                maxmag = new sbyte32(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="short"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short a, short b, [NoAlias] out short minmag, [NoAlias] out short maxmag)
        {
            bool aMax = abs(a) > abs(b);

            minmag = aMax ? b : a;
            maxmag = aMax ? a : b;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short2 a, short2 b, [NoAlias] out short2 minmag, [NoAlias] out short2 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short3 a, short3 b, [NoAlias] out short3 minmag, [NoAlias] out short3 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short4 a, short4 b, [NoAlias] out short4 minmag, [NoAlias] out short4 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
                maxmath.minmaxmag(a.w, b.w, out minmag.w, out maxmag.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short8 a, short8 b, [NoAlias] out short8 minmag, [NoAlias] out short8 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x0, b.x0, out minmag.x0, out maxmag.x0);
                maxmath.minmaxmag(a.x1, b.x1, out minmag.x1, out maxmag.x1);
                maxmath.minmaxmag(a.x2, b.x2, out minmag.x2, out maxmag.x2);
                maxmath.minmaxmag(a.x3, b.x3, out minmag.x3, out maxmag.x3);
                maxmath.minmaxmag(a.x4, b.x4, out minmag.x4, out maxmag.x4);
                maxmath.minmaxmag(a.x5, b.x5, out minmag.x5, out maxmag.x5);
                maxmath.minmaxmag(a.x6, b.x6, out minmag.x6, out maxmag.x6);
                maxmath.minmaxmag(a.x7, b.x7, out minmag.x7, out maxmag.x7);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short16 a, short16 b, [NoAlias] out short16 minmag, [NoAlias] out short16 maxmag)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi16(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v8_0, b.v8_0, out short8 minLo, out short8 maxLo);
                minmaxmag(a.v8_8, b.v8_8, out short8 minHi, out short8 maxHi);

                minmag = new short16(minLo, minHi);
                maxmag = new short16(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="int"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int a, int b, [NoAlias] out int minmag, [NoAlias] out int maxmag)
        {
            bool aMax = math.abs(a) > math.abs(b);

            minmag = aMax ? b : a;
            maxmag = aMax ? a : b;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="int2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int2 a, int2 b, [NoAlias] out int2 minmag, [NoAlias] out int2 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow), 2);

                minmag = RegisterConversion.ToInt2(min);
                maxmag = RegisterConversion.ToInt2(max);
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="int3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int3 a, int3 b, [NoAlias] out int3 minmag, [NoAlias] out int3 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow), 3);

                minmag = RegisterConversion.ToInt3(min);
                maxmag = RegisterConversion.ToInt3(max);
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="int4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int4 a, int4 b, [NoAlias] out int4 minmag, [NoAlias] out int4 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow), 4);

                minmag = RegisterConversion.ToInt4(min);
                maxmag = RegisterConversion.ToInt4(max);
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
                maxmath.minmaxmag(a.w, b.w, out minmag.w, out maxmag.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.int8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int8 a, int8 b, [NoAlias] out int8 minmag, [NoAlias] out int8 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi32(a, b, out v256 min, out v256 max, noOverFlow.Promises(Promise.NoOverflow));

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v4_0, b.v4_0, out int4 minLo, out int4 maxLo, noOverFlow);
                minmaxmag(a.v4_4, b.v4_4, out int4 minHi, out int4 maxHi, noOverFlow);

                minmag = new int8(minLo, minHi);
                maxmag = new int8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="long"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long a, long b, [NoAlias] out long minmag, [NoAlias] out long maxmag)
        {
            bool aMax = math.abs(a) > math.abs(b);

            minmag = aMax ? b : a;
            maxmag = aMax ? a : b;
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.long2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long2 a, long2 b, [NoAlias] out long2 minmag, [NoAlias] out long2 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_epi64(a, b, out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow));

                minmag = min;
                maxmag = max;
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.long3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long3 a, long3 b, [NoAlias] out long3 minmag, [NoAlias] out long3 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi64(a, b, out v256 min, out v256 max, noOverFlow.Promises(Promise.NoOverflow), 3);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.xy, b.xy, out long2 minLo, out long2 maxLo, noOverFlow);
                minmaxmag(a.z, b.z, out long minZLo, out long maxZLo);

                minmag = new long3(minLo, minZLo);
                maxmag = new long3(maxLo, maxZLo);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.long4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long4 a, long4 b, [NoAlias] out long4 minmag, [NoAlias] out long4 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi64(a, b, out v256 min, out v256 max, noOverFlow.Promises(Promise.NoOverflow));

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.xy, b.xy, out long2 minLo, out long2 maxLo, noOverFlow);
                minmaxmag(a.zw, b.zw, out long2 minHi, out long2 maxHi, noOverFlow);

                minmag = new long4(minLo, minHi);
                maxmag = new long4(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="float"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float a, float b, [NoAlias] out float minmag, [NoAlias] out float maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToFloat(min);
                maxmag = RegisterConversion.ToFloat(max);
            }
            else
            {
                bool aMax = math.abs(a) > math.abs(b);

                minmag = aMax ? b : a;
                maxmag = aMax ? a : b;
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="float2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float2 a, float2 b, [NoAlias] out float2 minmag, [NoAlias] out float2 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToFloat2(min);
                maxmag = RegisterConversion.ToFloat2(max);
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="float3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float3 a, float3 b, [NoAlias] out float3 minmag, [NoAlias] out float3 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToFloat3(min);
                maxmag = RegisterConversion.ToFloat3(max);
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="float4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float4 a, float4 b, [NoAlias] out float4 minmag, [NoAlias] out float4 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToFloat4(min);
                maxmag = RegisterConversion.ToFloat4(max);
            }
            else
            {
                maxmath.minmaxmag(a.x, b.x, out minmag.x, out maxmag.x);
                maxmath.minmaxmag(a.y, b.y, out minmag.y, out maxmag.y);
                maxmath.minmaxmag(a.z, b.z, out minmag.z, out maxmag.z);
                maxmath.minmaxmag(a.w, b.w, out minmag.w, out maxmag.w);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.float8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float8 a, float8 b, [NoAlias] out float8 minmag, [NoAlias] out float8 maxmag)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmaxmag_ps(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v4_0, b.v4_0, out float4 minLo, out float4 maxLo);
                minmaxmag(a.v4_4, b.v4_4, out float4 minHi, out float4 maxHi);

                minmag = new float8(minLo, minHi);
                maxmag = new float8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="double"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return values are undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double a, double b, [NoAlias] out double minmag, [NoAlias] out double maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToDouble(min);
                maxmag = RegisterConversion.ToDouble(max);
            }
            else
            {
                bool aMax = math.abs(a) > math.abs(b);

                minmag = aMax ? b : a;
                maxmag = aMax ? a : b;
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="double2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double2 a, double2 b, [NoAlias] out double2 minmag, [NoAlias] out double2 maxmag)
        {
            if (Architecture.IsSIMDSupported)
            {
                Xse.minmaxmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToDouble2(min);
                maxmag = RegisterConversion.ToDouble2(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="double3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double3 a, double3 b, [NoAlias] out double3 minmag, [NoAlias] out double3 maxmag)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmaxmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), out v256 min, out v256 max);

                minmag = RegisterConversion.ToDouble3(min);
                maxmag = RegisterConversion.ToDouble3(max);
            }
            else
            {
                minmaxmag(a.xy, b.xy, out double2 minLo, out double2 maxLo);
                minmaxmag(a.z, b.z, out double minZLo, out double maxZLo);

                minmag = new double3(minLo, minZLo);
                maxmag = new double3(maxLo, maxZLo);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="double4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double4 a, double4 b, [NoAlias] out double4 minmag, [NoAlias] out double4 maxmag)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmaxmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), out v256 min, out v256 max);

                minmag = RegisterConversion.ToDouble4(min);
                maxmag = RegisterConversion.ToDouble4(max);
            }
            else
            {
                minmaxmag(a.xy, b.xy, out double2 minLo, out double2 maxLo);
                minmaxmag(a.zw, b.zw, out double2 minHi, out double2 maxHi);

                minmag = new double4(minLo, minHi);
                maxmag = new double4(maxLo, maxHi);
            }
        }
    }
}