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
            public static v128 maxmag_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPI8(a, 0, elements) && constexpr.ALL_LE_EPI8(b, 0, elements))
                    {
                        return min_epi8(a, b);
                    }
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements))
                    {
                        return max_epi8(a, b);
                    }


                    v128 cmp = adds_epi8(a, b);
                    minmax_epi8(a, b, out v128 min, out v128 max, elements);

                    return blendv_epi8(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 maxmag_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPI16(a, 0, elements) && constexpr.ALL_LE_EPI16(b, 0, elements))
                    {
                        return min_epi16(a, b);
                    }
                    if (constexpr.ALL_GE_EPI16(a, 0, elements) && constexpr.ALL_GE_EPI16(b, 0, elements))
                    {
                        return max_epi16(a, b);
                    }


                    v128 cmp = adds_epi16(a, b);
                    minmax_epi16(a, b, out v128 min, out v128 max);

                    return blendv_si128(max, min, srai_epi16(cmp, 15));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 maxmag_epi32(v128 a, v128 b, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPI32(a, 0, elements) && constexpr.ALL_LE_EPI32(b, 0, elements))
                    {
                        return min_epi32(a, b);
                    }
                    if (constexpr.ALL_GE_EPI32(a, 0, elements) && constexpr.ALL_GE_EPI32(b, 0, elements))
                    {
                        return max_epi32(a, b);
                    }


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

                            return blendv_si128(min, max, andnot_si128(srai_epi32(minAbs, 31), cmpgt_epi32(maxAbs, minAbs)));
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

                    return blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 maxmag_epi64(v128 a, v128 b, bool promiseNoOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPI64(a, 0) && constexpr.ALL_LE_EPI64(b, 0))
                    {
                        return min_epi64(a, b);
                    }
                    if (constexpr.ALL_GE_EPI64(a, 0) && constexpr.ALL_GE_EPI64(b, 0))
                    {
                        return max_epi64(a, b);
                    }


                    v128 cmp = promiseNoOverflow ? add_epi64(a, b) : adds_epi64(a, b);
                    minmax_epi64(a, b, out v128 min, out v128 max);

                    return blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 maxmag_ps(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_PS(a, 0, elements) && constexpr.ALL_LE_PS(b, 0, elements))
                    {
                        return min_ps(a, b);
                    }
                    if (constexpr.ALL_GE_PS(a, 0, elements) && constexpr.ALL_GE_PS(b, 0, elements))
                    {
                        return max_ps(a, b);
                    }


                    v128 cmp = add_ps(a, b);
                    minmax_ps(a, b, out v128 min, out v128 max);

                    return blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 maxmag_pd(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_PD(a, 0) && constexpr.ALL_LE_PD(b, 0))
                    {
                        return min_pd(a, b);
                    }
                    if (constexpr.ALL_GE_PD(a, 0) && constexpr.ALL_GE_PD(b, 0))
                    {
                        return max_pd(a, b);
                    }


                    v128 cmp = add_pd(a, b);
                    minmax_pd(a, b, out v128 min, out v128 max);

                    return blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_maxmag_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI8(a, 0) && constexpr.ALL_LE_EPI8(b, 0))
                    {
                        return Avx2.mm256_min_epi8(a, b);
                    }
                    if (constexpr.ALL_GE_EPI8(a, 0) && constexpr.ALL_GE_EPI8(b, 0))
                    {
                        return Avx2.mm256_max_epi8(a, b);
                    }


                    v256 cmp = Avx2.mm256_adds_epi8(a, b);
                    mm256_minmax_epi8(a, b, out v256 min, out v256 max);

                    return Avx2.mm256_blendv_epi8(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_maxmag_epi16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI16(a, 0) && constexpr.ALL_LE_EPI16(b, 0))
                    {
                        return Avx2.mm256_min_epi16(a, b);
                    }
                    if (constexpr.ALL_GE_EPI16(a, 0) && constexpr.ALL_GE_EPI16(b, 0))
                    {
                        return Avx2.mm256_max_epi16(a, b);
                    }


                    v256 cmp = Avx2.mm256_adds_epi16(a, b);
                    mm256_minmax_epi16(a, b, out v256 min, out v256 max);

                    return Avx2.mm256_blendv_epi8(max, min, Avx2.mm256_srai_epi16(cmp, 15));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_maxmag_epi32(v256 a, v256 b, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI32(a, 0) && constexpr.ALL_LE_EPI32(b, 0))
                    {
                        return Avx2.mm256_min_epi32(a, b);
                    }
                    if (constexpr.ALL_GE_EPI32(a, 0) && constexpr.ALL_GE_EPI32(b, 0))
                    {
                        return Avx2.mm256_max_epi32(a, b);
                    }


                    mm256_minmax_epi32(a, b, out v256 min, out v256 max);

                    if (promiseNoOverflow)
                    {
                        v256 cmp = Avx2.mm256_add_epi32(a, b);

                        return Avx.mm256_blendv_ps(max, min, cmp);
                    }
                    else
                    {
                        v256 minAbs = mm256_abs_epi32(min);
                        v256 maxAbs = mm256_abs_epi32(max);

                        return mm256_blendv_si256(min, max, Avx2.mm256_andnot_si256(Avx2.mm256_srai_epi32(minAbs, 31), Avx2.mm256_cmpgt_epi32(maxAbs, minAbs)));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_maxmag_epi64(v256 a, v256 b, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI64(a, 0, elements) && constexpr.ALL_LE_EPI64(b, 0, elements))
                    {
                        return mm256_min_epi64(a, b);
                    }
                    if (constexpr.ALL_GE_EPI64(a, 0, elements) && constexpr.ALL_GE_EPI64(b, 0, elements))
                    {
                        return mm256_max_epi64(a, b);
                    }


                    v256 cmp = promiseNoOverflow ? Avx2.mm256_add_epi64(a, b) : mm256_adds_epi64(a, b, elements);

                    mm256_minmax_epi64(a, b, out v256 min, out v256 max, elements);

                    return Avx.mm256_blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_maxmag_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    if (constexpr.ALL_LE_PS(a, 0) && constexpr.ALL_LE_PS(b, 0))
                    {
                        return Avx.mm256_min_ps(a, b);
                    }
                    if (constexpr.ALL_GE_PS(a, 0) && constexpr.ALL_GE_PS(b, 0))
                    {
                        return Avx.mm256_max_ps(a, b);
                    }


                    v256 cmp = Avx.mm256_add_ps(a, b);
                    mm256_minmax_ps(a, b, out v256 min, out v256 max);

                    return Avx.mm256_blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_maxmag_pd(v256 a, v256 b, byte elements = 4)
            {
                if (Avx.IsAvxSupported)
                {
                    if (constexpr.ALL_LE_PD(a, 0, elements) && constexpr.ALL_LE_PD(b, 0, elements))
                    {
                        return Avx.mm256_min_pd(a, b);
                    }
                    if (constexpr.ALL_GE_PD(a, 0, elements) && constexpr.ALL_GE_PD(b, 0, elements))
                    {
                        return Avx.mm256_max_pd(a, b);
                    }


                    v256 cmp = Avx.mm256_add_pd(a, b);
                    mm256_minmax_pd(a, b, out v256 min, out v256 max);

                    return Avx.mm256_blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the maximum of two <see cref="Int128"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 maxmag(Int128 a, Int128 b)
        {
            minmax(a, b, out Int128 min, out Int128 max);

            return ((long)abs(min).hi64 >= 0) & (abs(max) >= abs(min)) ? max : min;
        }


        /// <summary>       Returns the maximum of two <see cref="sbyte"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte maxmag(sbyte a, sbyte b)
        {
            return math.abs((int)a) > math.abs((int)b) ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 maxmag(sbyte2 a, sbyte2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi8(a, b, 2);
            }
            else
            {
                return new sbyte2(maxmag(a.x, b.x), maxmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 maxmag(sbyte3 a, sbyte3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi8(a, b, 3);
            }
            else
            {
                return new sbyte3(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 maxmag(sbyte4 a, sbyte4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi8(a, b, 4);
            }
            else
            {
                return new sbyte4(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z), maxmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 maxmag(sbyte8 a, sbyte8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi8(a, b, 8);
            }
            else
            {
                return new sbyte8(maxmag(a.x0, b.x0), maxmag(a.x1, b.x1), maxmag(a.x2, b.x2), maxmag(a.x3, b.x3), maxmag(a.x4, b.x4), maxmag(a.x5, b.x5), maxmag(a.x6, b.x6), maxmag(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 maxmag(sbyte16 a, sbyte16 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi8(a, b, 16);
            }
            else
            {
                return new sbyte16(maxmag(a.x0, b.x0), maxmag(a.x1, b.x1), maxmag(a.x2, b.x2), maxmag(a.x3, b.x3), maxmag(a.x4, b.x4), maxmag(a.x5, b.x5), maxmag(a.x6, b.x6), maxmag(a.x7, b.x7), maxmag(a.x8, b.x8), maxmag(a.x9, b.x9), maxmag(a.x10, b.x10), maxmag(a.x11, b.x11), maxmag(a.x12, b.x12), maxmag(a.x13, b.x13), maxmag(a.x14, b.x14), maxmag(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte32"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 maxmag(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_maxmag_epi8(a, b);
            }
            else
            {
                return new sbyte32(maxmag(a.v16_0, b.v16_0), maxmag(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="short"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short maxmag(short a, short b)
        {
            return math.abs((int)a) > math.abs((int)b) ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 maxmag(short2 a, short2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi16(a, b, 2);
            }
            else
            {
                return new short2(maxmag(a.x, b.x), maxmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 maxmag(short3 a, short3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi16(a, b, 3);
            }
            else
            {
                return new short3(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 maxmag(short4 a, short4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi16(a, b, 4);
            }
            else
            {
                return new short4(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z), maxmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 maxmag(short8 a, short8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi16(a, b, 8);
            }
            else
            {
                return new short8(maxmag(a.x0, b.x0), maxmag(a.x1, b.x1), maxmag(a.x2, b.x2), maxmag(a.x3, b.x3), maxmag(a.x4, b.x4), maxmag(a.x5, b.x5), maxmag(a.x6, b.x6), maxmag(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 maxmag(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_maxmag_epi16(a, b);
            }
            else
            {
                return new short16(maxmag(a.v8_0, b.v8_0), maxmag(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="int"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int maxmag(int a, int b)
        {
            if (constexpr.IS_TRUE(a > int.MaxValue && b > int.MaxValue))
            {
                return math.abs(a) > math.abs(b) ? a : b;
            }
            else
            {
                return math.abs((long)a) > math.abs((long)b) ? a : b;
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="int2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 maxmag(int2 a, int2 b, Promise noOverFlow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.maxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noOverFlow.Promises(Promise.NoOverflow), 2));
            }
            else
            {
                return new int2(maxmag(a.x, b.x), maxmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="int3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 maxmag(int3 a, int3 b, Promise noOverFlow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.maxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new int3(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="int4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 maxmag(int4 a, int4 b, Promise noOverFlow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.maxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noOverFlow.Promises(Promise.NoOverflow), 4));
            }
            else
            {
                return new int4(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z), maxmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.int8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 maxmag(int8 a, int8 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_maxmag_epi32(a, b, noOverFlow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(maxmag(a.v4_0, b.v4_0), maxmag(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="long"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long maxmag(long a, long b)
        {
            minmax(a, b, out long min, out long max);

            return (math.abs(min) >= 0) & (math.abs(max) >= math.abs(min)) ? max : min;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 maxmag(long2 a, long2 b, Promise noOverFlow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_epi64(a, b, noOverFlow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(maxmag(a.x, b.x), maxmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 maxmag(long3 a, long3 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_maxmag_epi64(a, b, noOverFlow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new long3(maxmag(a.xy, b.xy), maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 maxmag(long4 a, long4 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_maxmag_epi64(a, b, noOverFlow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new long4(maxmag(a.xy, b.xy), maxmag(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="float"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float maxmag(float a, float b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 2).Float0;
            }
            else
            {
                return math.abs(a) > math.abs(b) ? a : b;
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="float2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 maxmag(float2 a, float2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.maxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new float2(maxmag(a.x, b.x), maxmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="float3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 maxmag(float3 a, float3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.maxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new float3(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="float4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 maxmag(float4 a, float4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.maxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new float4(maxmag(a.x, b.x), maxmag(a.y, b.y), maxmag(a.z, b.z), maxmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.float8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 maxmag(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_maxmag_ps(a, b);
            }
            else
            {
                return new float8(maxmag(a.v4_0, b.v4_0), maxmag(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="double"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double maxmag(double a, double b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.maxmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)).Double0;
            }
            else
            {
                return math.abs(a) > math.abs(b) ? a : b;
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="double2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 maxmag(double2 a, double2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.maxmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new double2(maxmag(a.x, b.x), maxmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="double3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 maxmag(double3 a, double3 b)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_maxmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), 3));
            }
            else
            {
                return new double3(maxmag(a.xy, b.xy), maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="double4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 maxmag(double4 a, double4 b)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_maxmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), 4));
            }
            else
            {
                return new double4(maxmag(a.xy, b.xy), maxmag(a.zw, b.zw));
            }
        }
    }
}