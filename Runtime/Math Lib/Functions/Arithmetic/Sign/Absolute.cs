using System.Runtime.CompilerServices;
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
            public static v128 abs_epi8(v128 a, byte elements = 16)
            {
                if (constexpr.ALL_GE_EPI8(a, 0, elements))
                {
                    return a;
                }
    
                if (Sse2.IsSse2Supported)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Ssse3.abs_epi8(a);
                    }
                    else
                    {
                        v128 mask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), a);

                        return Sse2.xor_si128(mask, Sse2.add_epi8(a, mask));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi8(v256 a, byte elements = 4)
            {
                if (constexpr.ALL_GE_EPI8(a, 0))
                {
                    return a;
                }
    
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_abs_epi8(a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_epi16(v128 a, byte elements = 8)
            {
                if (constexpr.ALL_GE_EPI16(a, 0, elements))
                {
                    return a;
                }
    
                if (Sse2.IsSse2Supported)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Ssse3.abs_epi16(a);
                    }
                    else
                    {
                        return Sse2.max_epi16(Xse.neg_epi16(a), a);
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi16(v256 a)
            {
                if (constexpr.ALL_GE_EPI16(a, 0))
                {
                    return a;
                }
    
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_abs_epi16(a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_epi32(v128 a, byte elements = 4)
            {
                if (constexpr.ALL_GE_EPI32(a, 0, elements))
                {
                    return a;
                }
    
                if (Sse2.IsSse2Supported)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        return Ssse3.abs_epi32(a);
                    }
                    else
                    {
                        v128 mask = Sse2.cmpgt_epi32(Sse2.setzero_si128(), a);

                        return Sse2.xor_si128(mask, Sse2.add_epi32(a, mask));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi32(v256 a)
            {
                if (constexpr.ALL_GE_EPI32(a, 0))
                {
                    return a;
                }
    
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_abs_epi32(a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, 0)) 
                    {
                        return a;
                    }
                    else
                    {
                        v128 mask = Xse.srai_epi64(a, 63);
    
                        return Sse2.xor_si128(mask, Sse2.add_epi64(a, mask));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi64(v256 a, byte elements = 4)
            {
                if (constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    return a;
                }
    
                if (Avx2.IsAvx2Supported)
                {
                    v256 mask = mm256_srai_epi64(a, 63);
                    
                    return Avx2.mm256_xor_si256(mask, Avx2.mm256_add_epi64(a, mask));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_ps(v128 a, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPU32(a, 1u << 31, elements))
                {
                    return a;
                }
    
                if (Sse.IsSseSupported)
                {
                    return Sse.and_ps(a, new v128(0x7FFF_FFFF));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_ps(v256 a)
            {
                if (constexpr.ALL_LE_EPU32(a, 1u << 31))
                {
                    return a;
                }
    
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_and_ps(a, new v256(0x7FFF_FFFF));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, 1ul << 63)) 
                    {
                        return a;
                    }
                    else
                    {
                        return Sse2.and_pd(a, new v128(0x7FFF_FFFF_FFFF_FFFF));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_pd(v256 a, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPU64(a, 1ul << 63, elements))
                {
                    return a;
                }
    
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_and_pd(a, new v256(0x7FFF_FFFF_FFFF_FFFF));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the absolute value of an <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 abs(Int128 x)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0))
            {
                return x;
            }
            else
            {
                ulong mask = (ulong)((long)x.hi64 >> 63);

                ulong lo = x.lo64 ^ mask;
                ulong hi = x.hi64 ^ mask;

                return new Int128(lo, hi) - new Int128(mask, mask);
            }
        }


        /// <summary>       Returns the absolute value of an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte abs(sbyte x)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0))
            {
                return x;
            }
            else
            {
                return (sbyte)(x < 0 ? -x : x);
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 abs(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi8(x, 2);
            }
            else
            {
                return new sbyte2(abs(x.x), abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 abs(sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi8(x, 3);
            }
            else
            {
                return new sbyte3(abs(x.x), abs(x.y), abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 abs(sbyte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi8(x, 4);
            }
            else
            {
                return new sbyte4(abs(x.x), abs(x.y), abs(x.z), abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 abs(sbyte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi8(x, 8);
            }
            else
            {
                return new sbyte8(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 abs(sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi8(x, 16);
            }
            else
            {
                return new sbyte16(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7), abs(x.x8), abs(x.x9), abs(x.x10), abs(x.x11), abs(x.x12), abs(x.x13), abs(x.x14), abs(x.x15));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 abs(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi8(x);
            }
            else
            {
                return new sbyte32(abs(x.v16_0), abs(x.v16_16));
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short abs(short x)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0))
            {
                return x;
            }
            else
            {
                return (short)(x < 0 ? -x : x);
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 abs(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi16(x, 2);
            }
            else
            {
                return new short2(abs(x.x), abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 abs(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi16(x, 3);
            }
            else
            {
                return new short3(abs(x.x), abs(x.y), abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 abs(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi16(x, 4);
            }
            else
            {
                return new short4(abs(x.x), abs(x.y), abs(x.z), abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 abs(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi16(x, 8);
            }
            else
            {
                return new short8(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 abs(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi16(x);
            }
            else
            {
                return new short16(abs(x.v8_0), abs(x.v8_8));
            }
        }


        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 abs(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi32(x);
            }
            else
            {
                return new int8(math.abs(x.v4_0), math.abs(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 abs(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.abs_epi64(x);
            }
            else
            {
                return new long2(math.abs(x.x), math.abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 abs(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi64(x, 3);
            }
            else
            {
                return new long3(abs(x.xy), math.abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 abs(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi64(x, 4);
            }
            else
            {
                return new long4(abs(x.xy), abs(x.zw));
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter abs(quarter x)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0f))
            {
                return x;
            }
            else
            {
                return asquarter((byte)(asbyte(x) & 0b0111_1111));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 abs(quarter2 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)x >= 0f))) 
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) & 0b0111_1111);
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 abs(quarter3 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)x >= 0f))) 
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) & 0b0111_1111);
            }
        }
        
        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 abs(quarter4 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)x >= 0f))) 
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) & 0b0111_1111);
            }
        }
        
        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 abs(quarter8 x)
        {
            if (Xse.constexpr.IS_TRUE(all((float8)x >= 0f))) 
            {
                return x;
            }
            else
            {
                return asquarter(asbyte(x) & 0b0111_1111);
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half abs(half x)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0f))
            {
                return x;
            }
            else
            {
                return new half { value = ((ushort)(x.value & 0x7FFF)) };
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 abs(half2 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float2)x >= 0f))) 
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) & 0x7FFF);
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 abs(half3 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float3)x >= 0f))) 
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) & 0x7FFF);
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 abs(half4 x)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)x >= 0f)))
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) & 0x7FFF);
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 abs(half8 x)
        {
            if (Xse.constexpr.IS_TRUE(all((float8)x >= 0f)))
            {
                return x;
            }
            else
            {
                return ashalf(asushort(x) & 0x7FFF);
            }
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 abs(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_abs_ps(x);
            }
            else
            {
                return new float8(math.abs(x.v4_0), math.abs(x.v4_4));
            }
        }
    }
}