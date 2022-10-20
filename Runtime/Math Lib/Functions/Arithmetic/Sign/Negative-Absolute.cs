using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 nabs_epi8(v128 a, byte elements = 16)
            {
                if (constexpr.ALL_LE_EPI8(a, 0, elements))
                {
                    return a;
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return neg_epi8(abs_epi8(a));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(neg_epi8(a), a, Sse2.cmpgt_epi8(Sse2.setzero_si128(), a));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_nabs_epi8(v256 a)
            {
                if (constexpr.ALL_LE_EPI8(a, 0))
                {
                    return a;
                }
                else if (Avx2.IsAvx2Supported)
                {
                    return mm256_neg_epi8(mm256_abs_epi8(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 nabs_epi16(v128 a, byte elements = 8)
            {
                if (constexpr.ALL_LE_EPI16(a, 0, elements))
                {
                    return a;
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return neg_epi16(abs_epi16(a));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.min_epi16(neg_epi16(a), a);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_nabs_epi16(v256 a)
            {
                if (constexpr.ALL_LE_EPI16(a, 0))
                {
                    return a;
                }
                else if (Avx2.IsAvx2Supported)
                {
                    return mm256_neg_epi16(mm256_abs_epi16(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 nabs_epi32(v128 a, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPI32(a, 0, elements))
                {
                    return a;
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return neg_epi32(abs_epi32(a));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(neg_epi8(a), a, Sse2.srai_epi32(a, 31));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_nabs_epi32(v256 a)
            {
                if (constexpr.ALL_LE_EPI32(a, 0))
                {
                    return a;
                }
                else if (Avx2.IsAvx2Supported)
                {
                    return mm256_neg_epi32(mm256_abs_epi32(a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 nabs_epi64(v128 a)
            {
                if (constexpr.ALL_LE_EPI64(a, 0))
                {
                    return a;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(neg_epi64(a), a, srai_epi64(a, 63));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_nabs_epi64(v256 a, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPI64(a, 0, elements))
                {
                    return a;
                }
                else if (Avx2.IsAvx2Supported)
                {
                    return mm256_blendv_si256(mm256_neg_epi64(a), a, mm256_srai_epi64(a, 63));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 nabs_ps(v128 a, byte elements = 4)
            {
                if (constexpr.ALL_GE_EPU32(a, 1u << 31, elements))
                {
                    return a;
                }
                else if (Sse.IsSseSupported)
                {
                    return Sse.or_ps(a, new v128(1 << 31));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_nabs_ps(v256 a)
            {
                if (constexpr.ALL_GE_EPU32(a, 1u << 31))
                {
                    return a;
                }
                else if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_or_ps(a, new v256(1 << 31));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 nabs_pd(v128 a)
            {
                if (constexpr.ALL_GE_EPU64(a, 1ul << 63))
                {
                    return a;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.or_pd(a, new v128(1ul << 63));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_nabs_pd(v256 a, byte elements = 4)
            {
                if (constexpr.ALL_GE_EPU64(a, 1ul << 63, elements))
                {
                    return a;
                }
                else if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_or_pd(a, new v256(1ul << 63));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the negative absolute value of an <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 nabs(Int128 x)
        {
            if (Xse.constexpr.IS_TRUE(x <= 0))
            {
                return x;
            }
            else
            {
                ulong mask = ~(ulong)((long)x.hi64 >> 63);

                ulong lo = x.lo64 ^ mask;
                ulong hi = x.hi64 ^ mask;

                return new Int128(lo, hi) + ((ulong)-(long)mask);
            }
        }


        /// <summary>       Returns the negative absolute value of an <see cref="sbyte"/>.    </summary>
        [return: AssumeRange((long)sbyte.MinValue, 0L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static sbyte nabs(sbyte x)
        {
            return x >= 0 ? (sbyte)-x : x;
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 nabs(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi8(x, 2);
            }
            else
            {
                return new sbyte2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 nabs(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi8(x, 3);
            }
            else
            {
                return new sbyte3(nabs(x.x), nabs(x.y), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 nabs(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi8(x, 4);
            }
            else
            {
                return new sbyte4(nabs(x.x), nabs(x.y), nabs(x.z), nabs(x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 nabs(sbyte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi8(x, 8);
            }
            else
            {
                return new sbyte8(nabs(x.x0), nabs(x.x1), nabs(x.x2), nabs(x.x3), nabs(x.x4), nabs(x.x5), nabs(x.x6), nabs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 nabs(sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi8(x, 16);
            }
            else
            {
                return new sbyte16(nabs(x.x0), nabs(x.x1), nabs(x.x2), nabs(x.x3), nabs(x.x4), nabs(x.x5), nabs(x.x6), nabs(x.x7), nabs(x.x8), nabs(x.x9), nabs(x.x10), nabs(x.x11), nabs(x.x12), nabs(x.x13), nabs(x.x14), nabs(x.x15));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 nabs(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_nabs_epi8(x);
            }
            else
            {
                return new sbyte32(nabs(x.v16_0), nabs(x.v16_16));
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="short"/>.    </summary>
        [return: AssumeRange((long)short.MinValue, 0L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static short nabs(short x)
        {
            return x >= 0 ? (short)-x : x;
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 nabs(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi16(x, 2);
            }
            else
            {
                return new short2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 nabs(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi16(x, 3);
            }
            else
            {
                return new short3(nabs(x.x), nabs(x.y), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 nabs(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi16(x, 4);
            }
            else
            {
                return new short4(nabs(x.x), nabs(x.y), nabs(x.z), nabs(x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 nabs(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.nabs_epi16(x, 8);
            }
            else
            {
                return new short8(nabs(x.x0), nabs(x.x1), nabs(x.x2), nabs(x.x3), nabs(x.x4), nabs(x.x5), nabs(x.x6), nabs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 nabs(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_nabs_epi16(x);
            }
            else
            {
                return new short16(nabs(x.v8_0), nabs(x.v8_8));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.nabs_epi32(RegisterConversion.ToV128(x), 2));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.nabs_epi32(RegisterConversion.ToV128(x), 3));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.nabs_epi32(RegisterConversion.ToV128(x), 4));
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
                return Xse.mm256_nabs_epi32(x);
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
                return Xse.nabs_epi64(x);
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
                return Xse.mm256_nabs_epi64(x, 3);
            }
            else
            {
                return new long3(nabs(x.xy), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 nabs(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_nabs_epi64(x);
            }
            else
            {
                return new long4(nabs(x.xy), nabs(x.zw));
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter nabs(quarter x)
        {
            if (Xse.constexpr.IS_TRUE(x <= 0f))
            {
                return x;
            }
            else
            {
                return asquarter((byte)(asbyte(x) | 0b1000_0000));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 nabs(quarter2 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)x <= 0f)))
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) | 0b1000_0000);
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 nabs(quarter3 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)x <= 0f)))
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) | 0b1000_0000);
            }
        }
        
        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 nabs(quarter4 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)x <= 0f)))
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) | 0b1000_0000);
            }
        }
        
        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 nabs(quarter8 x)
        {
            if (Xse.constexpr.IS_TRUE(all((float8)x <= 0f)))
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) | 0b1000_0000);
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half nabs(half x)
        {
            if (Xse.constexpr.IS_TRUE(x <= 0f))
            {
                return x;
            }
            else
            {
                return new half { value = ((ushort)(x.value | 0x8000)) };
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 nabs(half2 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)x <= 0f)))
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) | 0x8000);
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 nabs(half3 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)x <= 0f)))
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) | 0x8000);
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 nabs(half4 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)x <= 0f)))
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) | 0x8000);
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 nabs(half8 x)
        {
            if (Xse.constexpr.IS_TRUE(all((float8)x <= 0f)))
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) | 0x8000);
            }
        }


        /// <summary>       Returns the negative absolute value of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float nabs(float x)
        {
            if (Xse.constexpr.IS_TRUE(x <= 0f))
            {
                return x;
            }
            else
            {
                return math.asfloat(math.asint(x) | (1 << 31));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 nabs(float2 x)
        {
            if (Sse.IsSseSupported)
            {
                return RegisterConversion.ToFloat2(Xse.nabs_ps(RegisterConversion.ToV128(x), 2));
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
                return RegisterConversion.ToFloat3(Xse.nabs_ps(RegisterConversion.ToV128(x), 3));
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
                return RegisterConversion.ToFloat4(Xse.nabs_ps(RegisterConversion.ToV128(x), 4));
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
                return Xse.mm256_nabs_ps(x);
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
            if (Xse.constexpr.IS_TRUE(x <= 0d))
            {
                return x;
            }
            else
            {
                return math.asdouble(math.aslong(x) | (1L << 63));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 nabs(double2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.nabs_pd(RegisterConversion.ToV128(x)));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble3( Xse.mm256_nabs_pd(RegisterConversion.ToV256(x), 3));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_nabs_pd(RegisterConversion.ToV256(x), 4));
            }
            else
            {
                return new double4(nabs(x.xy), nabs(x.zw));
            }
        }
    }
}