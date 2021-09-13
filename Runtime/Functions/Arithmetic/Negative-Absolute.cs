using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the negative absolute value of an <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 nabs(Int128 x)
        {
            ulong mask = ~(ulong)((long)x.intern.hi >> 63);

            ulong lo = x.intern.lo ^ mask;
            ulong hi = x.intern.hi ^ mask;

            return new Int128(lo, hi) + ((ulong)-(long)mask);
        }


        /// <summary>       Returns the negative absolute value of an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange((long)sbyte.MinValue, 0L)]
        public static sbyte nabs(sbyte x)
        {
            return x >= 0 ? (sbyte)-x : x;
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 nabs(sbyte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(Sse2.setzero_si128(), x));
            }
            else
            {
                return new sbyte2((sbyte)nabs((int)x.x), (sbyte)nabs((int)x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 nabs(sbyte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(Sse2.setzero_si128(), x));
            }
            else
            {
                return new sbyte3((sbyte)nabs((int)x.x), (sbyte)nabs((int)x.y), (sbyte)nabs((int)x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 nabs(sbyte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(Sse2.setzero_si128(), x));
            }
            else
            {
                return new sbyte4((sbyte)nabs((int)x.x), (sbyte)nabs((int)x.y), (sbyte)nabs((int)x.z), (sbyte)nabs((int)x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 nabs(sbyte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(Sse2.setzero_si128(), x));
            }
            else
            {
                return new sbyte8((sbyte)nabs((int)x.x0), (sbyte)nabs((int)x.x1), (sbyte)nabs((int)x.x2), (sbyte)nabs((int)x.x3), (sbyte)nabs((int)x.x4), (sbyte)nabs((int)x.x5), (sbyte)nabs((int)x.x6), (sbyte)nabs((int)x.x7));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 nabs(sbyte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(Sse2.setzero_si128(), x));
            }
            else
            {
                return new sbyte16((sbyte)nabs((int)x.x0), (sbyte)nabs((int)x.x1), (sbyte)nabs((int)x.x2), (sbyte)nabs((int)x.x3), (sbyte)nabs((int)x.x4), (sbyte)nabs((int)x.x5), (sbyte)nabs((int)x.x6), (sbyte)nabs((int)x.x7), (sbyte)nabs((int)x.x8), (sbyte)nabs((int)x.x9), (sbyte)nabs((int)x.x10), (sbyte)nabs((int)x.x11), (sbyte)nabs((int)x.x12), (sbyte)nabs((int)x.x13), (sbyte)nabs((int)x.x14), (sbyte)nabs((int)x.x15));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 nabs(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(Avx.mm256_setzero_si256(), Avx2.mm256_abs_epi8(x));
            }
            else
            {
                return new sbyte32(abs(x.v16_0), nabs(x.v16_16));
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange((long)short.MinValue, 0L)]
        public static short nabs(short x)
        {
            return x >= 0 ? (short)-x : x;
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 nabs(short2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(Sse2.setzero_si128(), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short2((short)nabs((int)x.x), (short)nabs((int)x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 nabs(short3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(Sse2.setzero_si128(), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short3((short)nabs((int)x.x), (short)nabs((int)x.y), (short)nabs((int)x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 nabs(short4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(Sse2.setzero_si128(), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short4((short)nabs((int)x.x), (short)nabs((int)x.y), (short)nabs((int)x.z), (short)nabs((int)x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 nabs(short8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(Sse2.setzero_si128(), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short8((short)nabs((int)x.x0), (short)nabs((int)x.x1), (short)nabs((int)x.x2), (short)nabs((int)x.x3), (short)nabs((int)x.x4), (short)nabs((int)x.x5), (short)nabs((int)x.x6), (short)nabs((int)x.x7));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 nabs(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(Avx.mm256_setzero_si256(), Avx2.mm256_abs_epi16(x));
            }
            else
            {
                return new short16(abs(x.v8_0), nabs(x.v8_8));
            }
        }


        /// <summary>       Returns the negative absolute value of an <see cref="int"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int nabs(int x)
        {
            return x >= 0 ? -x : x;
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 nabs(int2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 _nabs = Sse2.sub_epi32(Sse2.setzero_si128(), Ssse3.abs_epi32(UnityMathematicsLink.Tov128(x)));

                return *(int2*)&_nabs;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Mask.BlendV(Sse2.sub_epi32(Sse2.setzero_si128(), UnityMathematicsLink.Tov128(x)), UnityMathematicsLink.Tov128(x), Sse2.cmpgt_epi32(Sse2.setzero_si128(), UnityMathematicsLink.Tov128(x)));

                return *(int2*)&_nabs;
            }
            else
            {
                return new int2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 nabs(int3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 _nabs = Sse2.sub_epi32(Sse2.setzero_si128(), Ssse3.abs_epi32(UnityMathematicsLink.Tov128(x)));

                return *(int3*)&_nabs;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Mask.BlendV(Sse2.sub_epi32(Sse2.setzero_si128(), UnityMathematicsLink.Tov128(x)), UnityMathematicsLink.Tov128(x), Sse2.cmpgt_epi32(Sse2.setzero_si128(), UnityMathematicsLink.Tov128(x)));

                return *(int3*)&_nabs;
            }
            else
            {
                return new int3(nabs(x.x), nabs(x.y), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 nabs(int4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 _nabs = Sse2.sub_epi32(Sse2.setzero_si128(), Ssse3.abs_epi32(UnityMathematicsLink.Tov128(x)));

                return *(int4*)&_nabs;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Mask.BlendV(Sse2.sub_epi32(Sse2.setzero_si128(), UnityMathematicsLink.Tov128(x)), UnityMathematicsLink.Tov128(x), Sse2.cmpgt_epi32(Sse2.setzero_si128(), UnityMathematicsLink.Tov128(x)));

                return *(int4*)&_nabs;
            }
            else
            {
                return new int4(nabs(x.x), nabs(x.y), nabs(x.z), nabs(x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 nabs(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(Avx.mm256_setzero_si256(), Avx2.mm256_abs_epi32(x));
            }
            else
            {
                return new int8(nabs(x.v4_0), nabs(x.v4_4));
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="long"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long nabs(long x)
        {
            return x >= 0 ? -x : x;
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 nabs(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Operator.greater_mask_long(Sse2.setzero_si128(), x));
            }
            else
            {
                return new long2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 nabs(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(-x, x, Avx2.mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), x));
            }
            else
            {
                return new long3(abs(x.xy), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 nabs(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(-x, x, Avx2.mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), x));
            }
            else
            {
                return new long4(abs(x.xy), nabs(x.zw));
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter nabs(quarter x)
        {
            return asquarter((byte)(asbyte(x) | 0b1000_0000));
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 nabs(quarter2 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 nabs(quarter3 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }
        
        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 nabs(quarter4 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }
        
        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 nabs(quarter8 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }


        /// <summary>       Returns the negative absolute value of a <see cref="half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half nabs(half x)
        {
            return new half { value = ((ushort)(x.value | 0x8000)) };
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 nabs(half2 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 nabs(half3 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 nabs(half4 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 nabs(half8 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }


        /// <summary>       Returns the negative absolute value of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float nabs(float x)
        {
            return math.asfloat(math.asint(x) | (1 << 31));
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 nabs(float2 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 _nabs = Sse.or_ps(UnityMathematicsLink.Tov128(x), new v128(1 << 31));

                return *(float2*)&_nabs;
            }
            else
            {
                return new float2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 nabs(float3 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 _nabs = Sse.or_ps(UnityMathematicsLink.Tov128(x), new v128(1 << 31));

                return *(float3*)&_nabs;
            }
            else
            {
                return new float3(nabs(x.x), nabs(x.y), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 nabs(float4 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 _nabs = Sse.or_ps(UnityMathematicsLink.Tov128(x), new v128(1 << 31));

                return *(float4*)&_nabs;
            }
            else
            {
                return new float4(nabs(x.x), nabs(x.y), nabs(x.z), nabs(x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 nabs(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_or_ps(x, new v256(1 << 31));
            }
            else
            {
                return new float8(nabs(x.v4_0), nabs(x.v4_4));
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double nabs(double x)
        {
            return math.asdouble(math.aslong(x) | (1L << 63));
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 nabs(double2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Sse2.or_pd(UnityMathematicsLink.Tov128(x), new v128(1L << 63));

                return *(double2*)&_nabs;
            }
            else
            {
                return new double2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 nabs(double3 x)
        {
            if (Avx.IsAvxSupported)
            {
                v256 _nabs = Avx.mm256_or_pd(UnityMathematicsLink.Tov256(x), new v256(1L << 63));

                return *(double3*)&_nabs;
            }
            else
            {
                return new double3(nabs(x.xy), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 nabs(double4 x)
        {
            if (Avx.IsAvxSupported)
            {
                v256 _nabs = Avx.mm256_or_pd(UnityMathematicsLink.Tov256(x), new v256(1L << 63));

                return *(double4*)&_nabs;
            }
            else
            {
                return new double4(nabs(x.xy), nabs(x.zw));
            }
        }
    }
}