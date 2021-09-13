using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="Int128.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divsaturated(Int128 x, Int128 y)
        {
            return (x == Int128.MinValue & ((y.intern.lo & y.intern.hi) == ulong.MaxValue)) ? Int128.MaxValue : x / y;
        }


        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte divsaturated(sbyte x, sbyte y)
        {
            return (sbyte)((x / y) - tosbyte(x == sbyte.MinValue & y == -1));
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divsaturated(sbyte2 x, sbyte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_sbyte(x, y, saturated: true);
            } 
            else
            {
                return new sbyte2(divsaturated(x.x, y.x),
                                  divsaturated(x.y, y.y));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divsaturated(sbyte3 x, sbyte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_sbyte(x, y, saturated: true);
            } 
            else
            {
                return new sbyte3(divsaturated(x.x, y.x),
                                  divsaturated(x.y, y.y),
                                  divsaturated(x.z, y.z));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divsaturated(sbyte4 x, sbyte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_sbyte(x, y, saturated: true);
            }
            else
            {
                return new sbyte4(divsaturated(x.x, y.x),
                                  divsaturated(x.y, y.y),
                                  divsaturated(x.z, y.z),
                                  divsaturated(x.w, y.w));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divsaturated(sbyte8 x, sbyte8 y)
        {
            if (Avx.IsAvxSupported)
            {
                return Operator.vdiv_sbyte(x, y, saturated: true);
            }
            else if (Sse2.IsSse2Supported)
            {
                sbyte8 quotients = x / y;

                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Operator.shl_byte(ALL_ONES, 7);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi8(x, MIN_VALUE), Sse2.cmpeq_epi8(y, ALL_ONES));

                return Sse2.add_epi8(quotients, overflow);
            } 
            else
            {
                return new sbyte8(divsaturated(x.x0, y.x0),
                                  divsaturated(x.x1, y.x1),
                                  divsaturated(x.x2, y.x2),
                                  divsaturated(x.x3, y.x3),
                                  divsaturated(x.x4, y.x4),
                                  divsaturated(x.x5, y.x5),
                                  divsaturated(x.x6, y.x6),
                                  divsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divsaturated(sbyte16 x, sbyte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte16 quotients = x / y;

                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Operator.shl_byte(ALL_ONES, 7);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi8(x, MIN_VALUE), Sse2.cmpeq_epi8(y, ALL_ONES));

                return Sse2.add_epi8(quotients, overflow);
            }
            else
            {
                return new sbyte16(divsaturated(x.x0, y.x0),
                                   divsaturated(x.x1, y.x1),
                                   divsaturated(x.x2, y.x2),
                                   divsaturated(x.x3, y.x3),
                                   divsaturated(x.x4, y.x4),
                                   divsaturated(x.x5, y.x5),
                                   divsaturated(x.x6, y.x6),
                                   divsaturated(x.x7, y.x7),
                                   divsaturated(x.x8, y.x8),
                                   divsaturated(x.x9, y.x9),
                                   divsaturated(x.x10, y.x10),
                                   divsaturated(x.x11, y.x11),
                                   divsaturated(x.x12, y.x12),
                                   divsaturated(x.x13, y.x13),
                                   divsaturated(x.x14, y.x14),
                                   divsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divsaturated(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte32 quotients = x / y;

                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));
                v256 MIN_VALUE = Operator.shl_byte(ALL_ONES, 7);
                
                v256 overflow = Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi8(x, MIN_VALUE), Avx2.mm256_cmpeq_epi8(y, ALL_ONES));

                return Avx2.mm256_add_epi8(quotients, overflow);
            } 
            else
            {
                return new sbyte32(divsaturated(x.v16_0, y.v16_0),
                                   divsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="short.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short divsaturated(short x, short y)
        {
            return (x == short.MinValue & y == -1) ? short.MaxValue : (short)(x / y);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divsaturated(short2 x, short2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_short(x, y, saturated: true);
            } 
            else
            {
                return new short2(divsaturated(x.x, y.x),
                                  divsaturated(x.y, y.y));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divsaturated(short3 x, short3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_short(x, y, saturated: true);
            } 
            else
            {
                return new short3(divsaturated(x.x, y.x),
                                  divsaturated(x.y, y.y),
                                  divsaturated(x.z, y.z));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divsaturated(short4 x, short4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_short(x, y, saturated: true);
            }
            else
            {
                return new short4(divsaturated(x.x, y.x),
                                  divsaturated(x.y, y.y),
                                  divsaturated(x.z, y.z),
                                  divsaturated(x.w, y.w));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divsaturated(short8 x, short8 y)
        {
            if (Avx.IsAvxSupported)
            {
                return Operator.vdiv_short(x, y, saturated: true);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new short8(Operator.vdiv_short(x.v4_0, y.v4_0, saturated: true),
                                  Operator.vdiv_short(x.v4_4, y.v4_4, saturated: true));
            }
            else
            {
                return new short8(divsaturated(x.x0, y.x0),
                                  divsaturated(x.x1, y.x1),
                                  divsaturated(x.x2, y.x2),
                                  divsaturated(x.x3, y.x3),
                                  divsaturated(x.x4, y.x4),
                                  divsaturated(x.x5, y.x5),
                                  divsaturated(x.x6, y.x6),
                                  divsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 divsaturated(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdiv_short(x, y, saturated: true);
            } 
            else
            {
                return new short16(divsaturated(x.v8_0, y.v8_0),
                                   divsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="int.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int divsaturated(int x, int y)
        {
            return (x == int.MinValue & y == -1) ? int.MaxValue : x / y;
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 divsaturated(int2 x, int2 y)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(y.x, 0);
Assert.AreNotEqual(y.y, 0);

                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);

                v128 quotientsDouble = Sse2.div_pd(Sse2.cvtepi32_pd(_x), Sse2.cvtepi32_pd(_y));
                
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Sse2.slli_epi32(ALL_ONES, 31);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi32(_x, MIN_VALUE), Sse2.cmpeq_epi32(_y, ALL_ONES));

                v128 result = Sse2.add_epi32(Sse2.cvttpd_epi32(quotientsDouble), overflow);

                return *(int2*)&result;
            } 
            else
            {
                return new int2(divsaturated(x.x, y.x),
                                divsaturated(x.y, y.y));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 divsaturated(int3 x, int3 y)
        {
            if (Avx.IsAvxSupported)
            {
Assert.AreNotEqual(y.x, 0);
Assert.AreNotEqual(y.y, 0);
Assert.AreNotEqual(y.z, 0);

                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);

                v256 quotientsDouble = Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(_x), Avx.mm256_cvtepi32_pd(_y));
                
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Sse2.slli_epi32(ALL_ONES, 31);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi32(_x, MIN_VALUE), Sse2.cmpeq_epi32(_y, ALL_ONES));

                v128 result = Sse2.add_epi32(Avx.mm256_cvttpd_epi32(quotientsDouble), overflow);

                return *(int3*)&result;
            } 
            else if (Sse2.IsSse2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);

                v128 quotientsDouble_lo = Sse2.div_pd(Sse2.cvtepi32_pd(_x), Sse2.cvtepi32_pd(_y));
                v128 quotientsDouble_hi = Sse2.div_sd(Sse2.cvtepi32_pd(Sse2.bsrli_si128(_x, 2 * sizeof(int))), Sse2.cvtepi32_pd(Sse2.shuffle_epi32(_y, Sse.SHUFFLE(0, 0, 3, 2))));
                
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Sse2.slli_epi32(ALL_ONES, 31);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi32(_x, MIN_VALUE), Sse2.cmpeq_epi32(_y, ALL_ONES));

                v128 quotients = Sse2.unpacklo_epi64(Sse2.cvttpd_epi32(quotientsDouble_lo), Sse2.cvttpd_epi32(quotientsDouble_hi));
                
                v128 result = Sse2.add_epi32(quotients, overflow);

                return *(int3*)&result;
            }
            else
            {
                return new int3(divsaturated(x.x, y.x),
                                divsaturated(x.y, y.y),
                                divsaturated(x.z, y.z));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 divsaturated(int4 x, int4 y)
        {
            if (Avx.IsAvxSupported)
            {
Assert.AreNotEqual(y.x, 0);
Assert.AreNotEqual(y.y, 0);
Assert.AreNotEqual(y.z, 0);
Assert.AreNotEqual(y.w, 0);

                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);

                v256 quotientsDouble = Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(_x), Avx.mm256_cvtepi32_pd(_y));
                
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Sse2.slli_epi32(ALL_ONES, 31);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi32(_x, MIN_VALUE), Sse2.cmpeq_epi32(_y, ALL_ONES));
                
                v128 result = Sse2.add_epi32(Avx.mm256_cvttpd_epi32(quotientsDouble), overflow);

                return *(int4*)&result;
            } 
            else if (Sse2.IsSse2Supported)
            {
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _y = UnityMathematicsLink.Tov128(y);

                v128 quotientsDouble_lo = Sse2.div_pd(Sse2.cvtepi32_pd(_x), Sse2.cvtepi32_pd(_y));
                v128 quotientsDouble_hi = Sse2.div_pd(Sse2.cvtepi32_pd(Sse2.bsrli_si128(_x, 2 * sizeof(int))), Sse2.cvtepi32_pd(Sse2.shuffle_epi32(_y, Sse.SHUFFLE(0, 0, 3, 2))));
                
                v128 ALL_ONES = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 MIN_VALUE = Sse2.slli_epi32(ALL_ONES, 31);
                
                v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi32(_x, MIN_VALUE), Sse2.cmpeq_epi32(_y, ALL_ONES));

                v128 quotients = Sse2.unpacklo_epi64(Sse2.cvttpd_epi32(quotientsDouble_lo), Sse2.cvttpd_epi32(quotientsDouble_hi));
                
                v128 result = Sse2.add_epi32(quotients, overflow);

                return *(int4*)&result;
            }
            else
            {
                return new int4(divsaturated(x.x, y.x),
                                divsaturated(x.y, y.y),
                                divsaturated(x.z, y.z),
                                divsaturated(x.w, y.w));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 divsaturated(int8 x, int8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(y.x0, 0);
Assert.AreNotEqual(y.x1, 0);
Assert.AreNotEqual(y.x2, 0);
Assert.AreNotEqual(y.x3, 0);
Assert.AreNotEqual(y.x4, 0);
Assert.AreNotEqual(y.x5, 0);
Assert.AreNotEqual(y.x6, 0);
Assert.AreNotEqual(y.x7, 0);

                v256 quotientsDouble_hi = Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(Avx2.mm256_extracti128_si256(x, 1)), Avx.mm256_cvtepi32_pd(Avx2.mm256_extracti128_si256(y, 1)));
                v256 quotientsDouble_lo = Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(Avx.mm256_castsi256_si128(x)), Avx.mm256_cvtepi32_pd(Avx.mm256_castsi256_si128(y)));
                
                v256 ALL_ONES = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));
                v256 MIN_VALUE = Avx2.mm256_slli_epi32(ALL_ONES, 31);
                
                v256 overflow = Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(x, MIN_VALUE), Avx2.mm256_cmpeq_epi32(y, ALL_ONES));

                v256 quotients = Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Avx.mm256_cvttpd_epi32(quotientsDouble_lo)), Avx.mm256_cvttpd_epi32(quotientsDouble_hi), 1);

                return Avx2.mm256_add_epi32(quotients, overflow);
            } 
            else
            {
                return new int8(divsaturated(x.v4_0, y.v4_0),
                                divsaturated(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="long.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long divsaturated(long x, long y)
        {
            return (x == long.MinValue & y == -1) ? long.MaxValue : x / y;
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divsaturated(long2 x, long2 y)
        {
            return new long2(divsaturated(x.x, y.x),
                             divsaturated(x.y, y.y));
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divsaturated(long3 x, long3 y)
        {
            return new long3(divsaturated(x.x, y.x),
                             divsaturated(x.y, y.y),
                             divsaturated(x.z, y.z));
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divsaturated(long4 x, long4 y)
        {
            return new long4(divsaturated(x.x, y.x),
                             divsaturated(x.y, y.y),
                             divsaturated(x.z, y.z),
                             divsaturated(x.w, y.w));
        }


        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float divsaturated(float x, float y)
        {
            return math.clamp(x / y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 divsaturated(float2 x, float2 y)
        {
            return math.clamp(x / y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 divsaturated(float3 x, float3 y)
        {
            return math.clamp(x / y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 divsaturated(float4 x, float4 y)
        {
            return math.clamp(x / y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 divsaturated(float8 x, float8 y)
        {
            return clamp(x / y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double divsaturated(double x, double y)
        {
            return math.clamp(x / y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 divsaturated(double2 x, double2 y)
        {
            return math.clamp(x / y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 divsaturated(double3 x, double3 y)
        {
            return math.clamp(x / y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Divides each component of <paramref name="x"/> by <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 divsaturated(double4 x, double4 y)
        {
            return math.clamp(x / y, double.MinValue, double.MaxValue);
        }
    }
}