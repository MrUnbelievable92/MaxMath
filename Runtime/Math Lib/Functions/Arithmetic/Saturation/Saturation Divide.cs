using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 divs_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ALL_ONES = setall_si128();
                    v128 MIN_VALUE = Sse2.slli_epi32(ALL_ONES, 31);
                    
                    v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi32(a, MIN_VALUE), Sse2.cmpeq_epi32(b, ALL_ONES));

                    return Sse2.add_epi32(div_epi32(a, b, elements), overflow);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_divs_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ALL_ONES = mm256_setall_si256();
                    v256 MIN_VALUE = Avx2.mm256_slli_epi32(ALL_ONES, 31);
                    
                    v256 overflow = Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi32(a, MIN_VALUE), Avx2.mm256_cmpeq_epi32(b, ALL_ONES));

                    return Avx2.mm256_add_epi32(mm256_div_epi32(a, b), overflow);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 divs_epi64(v128 a, v128 b, byte elements = 4)
            {
                return new v128((a.SLong0 == long.MinValue & b.SLong0 == -1) ? long.MaxValue : a.SLong0 / b.SLong0,
                                (a.SLong1 == long.MinValue & b.SLong1 == -1) ? long.MaxValue : a.SLong1 / b.SLong1);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_divs_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ALL_ONES = mm256_setall_si256();
                    v256 MIN_VALUE = Avx2.mm256_slli_epi64(ALL_ONES, 63);
                    
                    v256 overflow = Avx2.mm256_and_si256(Avx2.mm256_cmpeq_epi64(a, MIN_VALUE), Avx2.mm256_cmpeq_epi64(b, ALL_ONES));

                    return Avx2.mm256_add_epi64(mm256_div_epi64(a, b, /*MUST BE 4!!! overflow causes hardware exception*/ 4), overflow);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Divides <paramref name="x"/> by <paramref name="y"/> and returns the result, which is clamped to <see cref="Int128.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divsaturated(Int128 x, Int128 y)
        {
            return (x == Int128.MinValue & ((y.lo64 & y.hi64) == ulong.MaxValue)) ? Int128.MaxValue : x / y;
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
                return Xse.div_epi8(x, y, saturated: true, 2);
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
                return Xse.div_epi8(x, y, saturated: true, 3);
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
                return Xse.div_epi8(x, y, saturated: true, 4);
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epi8(x, y, saturated: true, 8);
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
                return Xse.div_epi8(x, y, saturated: true, 16);
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
                return Xse.mm256_div_epi8(x, y, saturated: true);
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
                return Xse.div_epi16(x, y, saturated: true, 2);
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
                return Xse.div_epi16(x, y, saturated: true, 3);
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
                return Xse.div_epi16(x, y, saturated: true, 4);
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epi16(x, y, saturated: true, 8);
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
                return Xse.mm256_div_epi16(x, y, saturated: true);
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
                return RegisterConversion.ToType<int2>(Xse.divs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int3>(Xse.divs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int4>(Xse.divs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
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
                return Xse.mm256_divs_epi32(x, y);
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.divs_epi64(x, y);
            }
            else
            {
                return new long2(divsaturated(x.x, y.x),
                                 divsaturated(x.y, y.y));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divsaturated(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_divs_epi64(x, y, 3);
            }
            else
            {
                return new long3(divsaturated(x.xy, y.xy),
                                 divsaturated(x.z, y.z));
            }
        }

        /// <summary>       Divides each component of <paramref name="x"/> by each component of <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divsaturated(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_divs_epi64(x, y, 4);
            }
            else
            {
                return new long4(divsaturated(x.xy, y.xy),
                                 divsaturated(x.zw, y.zw));
            }
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