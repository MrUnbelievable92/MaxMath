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
            public static v128 adds_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU32(b, 1, elements))
                    {
                        v128 ALL_ONES = setall_si128();
                        v128 isMaxValue = Sse2.cmpeq_epi32(a, ALL_ONES);

                        return Sse2.sub_epi32(a, Sse2.andnot_si128(isMaxValue, ALL_ONES));
                    }

                    v128 sum = Sse2.add_epi32(a, b);
                    v128 overflowMask = cmpgt_epu32(b, sum, elements);
    
                    return Sse2.or_si128(sum, overflowMask);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_adds_epu32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU32(b, 1))
                    {
                        v256 ALL_ONES = mm256_setall_si256();
                        v256 isMaxValue = Avx2.mm256_cmpeq_epi32(a, ALL_ONES);

                        return Avx2.mm256_sub_epi32(a, Avx2.mm256_andnot_si256(isMaxValue, ALL_ONES));
                    }

                    v256 sum = Avx2.mm256_add_epi32(a, b);
                    v256 overflowMask = mm256_cmpgt_epu32(b, sum);
    
                    return Avx2.mm256_or_si256(sum, overflowMask);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 adds_epu64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(b, 1))
                    {
                        v128 ALL_ONES = setall_si128();
                        v128 isMaxValue = cmpeq_epi64(a, ALL_ONES);

                        return Sse2.sub_epi64(a, Sse2.andnot_si128(isMaxValue, ALL_ONES));
                    }

                    v128 sum = Sse2.add_epi64(a, b);
                    v128 overflowMask = cmpgt_epu64(b, sum);
                    
                    return Sse2.or_si128(sum, overflowMask);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_adds_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(b, 1, elements))
                    {
                        v256 ALL_ONES = mm256_setall_si256();
                        v256 isMaxValue = Avx2.mm256_cmpeq_epi64(a, ALL_ONES);

                        return Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(isMaxValue, ALL_ONES));
                    }

                    v256 sum = Avx2.mm256_add_epi64(a, b);
                    v256 overflowMask = mm256_cmpgt_epu64(a, sum);
    
                    return Avx2.mm256_or_si256(sum, overflowMask);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 adds_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MAX_VALUE = new v128(int.MaxValue);


                    if (constexpr.ALL_EQ_EPI32(b, -1, elements))
                    {
                        return Sse2.add_epi32(a, Sse2.cmpgt_epi32(a, Sse2.set1_epi32(int.MinValue)));
                    }
                    if (constexpr.ALL_EQ_EPI32(b, 1, elements))
                    {
                        return Sse2.sub_epi32(a, Sse2.cmpgt_epi32(MAX_VALUE, a));
                    }

    
                    v128 result = Sse2.add_epi32(a, b);
                    v128 overflow = Sse2.add_epi32(MAX_VALUE, Sse2.srli_epi32(a, 31));
                    v128 selectResult = ternarylogic_si128(overflow, b, result, TernaryOperation.OxBD);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_ps(overflow, result, selectResult);
                    }
                    else
                    {
                        return blendv_si128(overflow, result, Sse2.srai_epi32(selectResult, 31));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_adds_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MAX_VALUE = new v256(int.MaxValue);


                    if (constexpr.ALL_EQ_EPI32(b, -1))
                    {
                        return Avx2.mm256_add_epi32(a, Avx2.mm256_cmpgt_epi32(a, Avx.mm256_set1_epi32(int.MinValue)));
                    }
                    if (constexpr.ALL_EQ_EPI32(b, 1))
                    {
                        return Avx2.mm256_sub_epi32(a, Avx2.mm256_cmpgt_epi32(MAX_VALUE, a));
                    }

    
                    v256 result = Avx2.mm256_add_epi32(a, b);
                    v256 overflow = Avx2.mm256_add_epi32(MAX_VALUE, Avx2.mm256_srli_epi32(a, 31));
                    v256 selectResult = mm256_ternarylogic_si256(overflow, b, result, TernaryOperation.OxBD);

                    return Avx.mm256_blendv_ps(overflow, result, selectResult);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 adds_epi64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MAX_VALUE = new v128(long.MaxValue);


                    if (constexpr.ALL_EQ_EPI64(b, -1))
                    {
                        return Sse2.add_epi64(a, cmpgt_epi64(a, Sse2.set1_epi64x(long.MinValue)));
                    }
                    if (constexpr.ALL_EQ_EPI64(b, 1))
                    {
                        return Sse2.sub_epi64(a, cmpgt_epi64(MAX_VALUE, a));
                    }

    
                    v128 result = Sse2.add_epi64(a, b);
                    v128 overflow = Sse2.add_epi64(MAX_VALUE, Sse2.srli_epi64(a, 63));
                    v128 selectResult = ternarylogic_si128(overflow, b, result, TernaryOperation.OxBD);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_pd(overflow, result, selectResult);
                    }
                    else
                    {
                        return blendv_si128(overflow, result, srai_epi64(selectResult, 63));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_adds_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MAX_VALUE = new v256(long.MaxValue);
    

                    if (constexpr.ALL_EQ_EPI64(b, -1, elements))
                    {
                        return Avx2.mm256_add_epi64(a, Avx2.mm256_cmpgt_epi64(a, Avx.mm256_set1_epi64x(long.MinValue)));
                    }
                    if (constexpr.ALL_EQ_EPI64(b, 1, elements))
                    {
                        return Avx2.mm256_sub_epi64(a, Avx2.mm256_cmpgt_epi64(MAX_VALUE, a));
                    }
    

                    v256 result = Avx2.mm256_add_epi64(a, b);
                    v256 overflow = Avx2.mm256_add_epi64(MAX_VALUE, Avx2.mm256_srli_epi64(a, 63));
                    v256 selectResult = mm256_ternarylogic_si256(overflow, b, result, TernaryOperation.OxBD);

                    return Avx.mm256_blendv_pd(overflow, result, selectResult);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="UInt128.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 addsaturated(UInt128 x, UInt128 y)
        {
            if (Xse.constexpr.IS_TRUE(x <= UInt128.MaxValue / 2 && y <= UInt128.MaxValue / 2))
            {
                return x + y;
            }
            if (Xse.constexpr.IS_TRUE(x == 1))
            {
                return nextgreater(y);
            }
            if (Xse.constexpr.IS_TRUE(y == 1))
            {
                return nextgreater(x);
            }

            UInt128 res = x + y;
            bool overflow = res < x;

            return new UInt128(overflow ? ulong.MaxValue : res.lo64, overflow ? ulong.MaxValue : res.hi64); 
        }

        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="Int128.MaxValue"/> if overflow occurs or <see cref="Int128.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 addsaturated(Int128 x, Int128 y)
        {
	        Int128 result = x + y;
	        Int128 overflow = (x.hi64 >> 63) + Int128.MaxValue;
	        
	        if ((long)((overflow ^ y) | ~(y ^ result)).hi64 >= 0)
	        {
	        	result = overflow;
	        }
            
            return result;
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte addsaturated(byte x, byte y)
        {
            if (Xse.constexpr.IS_TRUE(x <= byte.MaxValue / 2 && y <= byte.MaxValue / 2))
            {
                return (byte)(x + y);
            }
            if (Xse.constexpr.IS_TRUE(x == 1))
            {
                return nextgreater(y);
            }
            if (Xse.constexpr.IS_TRUE(y == 1))
            {
                return nextgreater(x);
            }

            byte temp = (byte)(x + y);

            return temp < x ? byte.MaxValue : temp;
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 addsaturated(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(x, y);
            }
            else
            {
                return new byte2(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 addsaturated(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(x, y);
            }
            else
            {
                return new byte3(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y), 
                                 addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 addsaturated(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(x, y);
            }
            else
            {
                return new byte4(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y), 
                                 addsaturated(x.z, y.z), 
                                 addsaturated(x.w, y.w));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 addsaturated(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(x, y);
            }
            else
            {
                return new byte8(addsaturated(x.x0, y.x0), 
                                 addsaturated(x.x1, y.x1), 
                                 addsaturated(x.x2, y.x2), 
                                 addsaturated(x.x3, y.x3), 
                                 addsaturated(x.x4, y.x4), 
                                 addsaturated(x.x5, y.x5), 
                                 addsaturated(x.x6, y.x6), 
                                 addsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 addsaturated(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(x, y);
            }
            else
            {
                return new byte16(addsaturated(x.x0,  y.x0), 
                                  addsaturated(x.x1,  y.x1), 
                                  addsaturated(x.x2,  y.x2), 
                                  addsaturated(x.x3,  y.x3), 
                                  addsaturated(x.x4,  y.x4), 
                                  addsaturated(x.x5,  y.x5), 
                                  addsaturated(x.x6,  y.x6), 
                                  addsaturated(x.x7,  y.x7),
                                  addsaturated(x.x8,  y.x8), 
                                  addsaturated(x.x9,  y.x9), 
                                  addsaturated(x.x10, y.x10), 
                                  addsaturated(x.x11, y.x11), 
                                  addsaturated(x.x12, y.x12), 
                                  addsaturated(x.x13, y.x13), 
                                  addsaturated(x.x14, y.x14), 
                                  addsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 addsaturated(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epu8(x, y);
            }
            else
            {
                return new byte32(addsaturated(x.v16_0,  y.v16_0), 
                                  addsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort addsaturated(ushort x, ushort y)
        {
            if (Xse.constexpr.IS_TRUE(x <= ushort.MaxValue / 2 && y <= ushort.MaxValue / 2))
            {
                return (ushort)(x + y);
            }
            if (Xse.constexpr.IS_TRUE(x == 1))
            {
                return nextgreater(y);
            }
            if (Xse.constexpr.IS_TRUE(y == 1))
            {
                return nextgreater(x);
            }
            
            ushort temp = (ushort)(x + y);

            return temp < x ? ushort.MaxValue : temp;
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 addsaturated(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu16(x, y);
            }
            else
            {
                return new ushort2(addsaturated(x.x, y.x), 
                                   addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 addsaturated(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu16(x, y);
            }
            else
            {
                return new ushort3(addsaturated(x.x, y.x), 
                                   addsaturated(x.y, y.y), 
                                   addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 addsaturated(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu16(x, y);
            }
            else
            {
                return new ushort4(addsaturated(x.x, y.x), 
                                   addsaturated(x.y, y.y), 
                                   addsaturated(x.z, y.z), 
                                   addsaturated(x.w, y.w));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 addsaturated(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu16(x, y);
            }
            else
            {
                return new ushort8(addsaturated(x.x0, y.x0), 
                                   addsaturated(x.x1, y.x1), 
                                   addsaturated(x.x2, y.x2), 
                                   addsaturated(x.x3, y.x3), 
                                   addsaturated(x.x4, y.x4), 
                                   addsaturated(x.x5, y.x5), 
                                   addsaturated(x.x6, y.x6), 
                                   addsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 addsaturated(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epu16(x, y);
            }
            else
            {
                return new ushort16(addsaturated(x.v8_0, y.v8_0), 
                                    addsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint addsaturated(uint x, uint y)
        {
            if (Xse.constexpr.IS_TRUE(x <= uint.MaxValue / 2 && y <= uint.MaxValue / 2))
            {
                return x + y;
            }
            if (Xse.constexpr.IS_TRUE(x == 1))
            {
                return nextgreater(y);
            }
            if (Xse.constexpr.IS_TRUE(y == 1))
            {
                return nextgreater(x);
            }
            
            uint temp = x + y;

            return temp < x ? uint.MaxValue : temp;
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 addsaturated(uint2 x, uint2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.adds_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new uint2(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 addsaturated(uint3 x, uint3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.adds_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new uint3(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y), 
                                 addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 addsaturated(uint4 x, uint4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.adds_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new uint4(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y), 
                                 addsaturated(x.z, y.z), 
                                 addsaturated(x.w, y.w));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 addsaturated(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_adds_epu32(x, y);
            }
            else
            {
                return new uint8(addsaturated(x.v4_0, y.v4_0), 
                                 addsaturated(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong addsaturated(ulong x, ulong y)
        {
            if (Xse.constexpr.IS_TRUE(x <= ulong.MaxValue / 2 && y <= ulong.MaxValue / 2))
            {
                return x + y;
            }
            if (Xse.constexpr.IS_TRUE(x == 1))
            {
                return nextgreater(y);
            }
            if (Xse.constexpr.IS_TRUE(y == 1))
            {
                return nextgreater(x);
            }
            
            ulong temp = x + y;

            return temp < x ? ulong.MaxValue : temp;
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 addsaturated(ulong2 x, ulong2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.adds_epu64(x, y);
            }
            else
            {
                return new ulong2(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 addsaturated(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_adds_epu64(x, y, 3);
            }
            else
            {
                return new ulong3(addsaturated(x.xy, y.xy), 
                                  addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 addsaturated(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_adds_epu64(x, y, 4);
            }
            else
            {
                return new ulong4(addsaturated(x.xy, y.xy),
                                  addsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte addsaturated(sbyte x, sbyte y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Sse2.cvtsi32_si128((byte)x);
                v128 _y = Sse2.cvtsi32_si128((byte)y);

                v128 sum = Sse2.adds_epi8(_x, _y);

                return (sbyte)Sse2.cvtsi128_si32(sum);
            }
            else
            {
                return (sbyte)math.clamp(x + y, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 addsaturated(sbyte2 x, sbyte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(x, y);
            }
            else
            {
                return new sbyte2(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 addsaturated(sbyte3 x, sbyte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(x, y);
            }
            else
            {
                return new sbyte3(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y), 
                                  addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 addsaturated(sbyte4 x, sbyte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(x, y);
            }
            else
            {
                return new sbyte4(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y), 
                                  addsaturated(x.z, y.z), 
                                  addsaturated(x.w, y.w));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 addsaturated(sbyte8 x, sbyte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(x, y);
            }
            else
            {
                return new sbyte8(addsaturated(x.x0, y.x0), 
                                  addsaturated(x.x1, y.x1), 
                                  addsaturated(x.x2, y.x2), 
                                  addsaturated(x.x3, y.x3), 
                                  addsaturated(x.x4, y.x4), 
                                  addsaturated(x.x5, y.x5), 
                                  addsaturated(x.x6, y.x6), 
                                  addsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 addsaturated(sbyte16 x, sbyte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(x, y);
            }
            else
            {
                return new sbyte16(addsaturated(x.x0,  y.x0), 
                                   addsaturated(x.x1,  y.x1), 
                                   addsaturated(x.x2,  y.x2), 
                                   addsaturated(x.x3,  y.x3), 
                                   addsaturated(x.x4,  y.x4), 
                                   addsaturated(x.x5,  y.x5), 
                                   addsaturated(x.x6,  y.x6), 
                                   addsaturated(x.x7,  y.x7),
                                   addsaturated(x.x8,  y.x8), 
                                   addsaturated(x.x9,  y.x9), 
                                   addsaturated(x.x10, y.x10), 
                                   addsaturated(x.x11, y.x11), 
                                   addsaturated(x.x12, y.x12), 
                                   addsaturated(x.x13, y.x13), 
                                   addsaturated(x.x14, y.x14), 
                                   addsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 addsaturated(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epi8(x, y);
            }
            else
            {
                return new sbyte32(addsaturated(x.v16_0,  y.v16_0), 
                                   addsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short addsaturated(short x, short y)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _x = Sse2.cvtsi32_si128((ushort)x);
                v128 _y = Sse2.cvtsi32_si128((ushort)y);

                v128 sum = Sse2.adds_epi16(_x, _y);

                return (short)Sse2.cvtsi128_si32(sum);
            }
            else
            {
                return (short)math.clamp(x + y, short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 addsaturated(short2 x, short2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi16(x, y);
            }
            else
            {
                return new short2(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 addsaturated(short3 x, short3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi16(x, y);
            }
            else
            {
                return new short3(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y), 
                                  addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 addsaturated(short4 x, short4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi16(x, y);
            }
            else
            {
                return new short4(addsaturated(x.x, y.x), 
                                  addsaturated(x.y, y.y), 
                                  addsaturated(x.z, y.z), 
                                  addsaturated(x.w, y.w));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 addsaturated(short8 x, short8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi16(x, y);
            }
            else
            {
                return new short8(addsaturated(x.x0, y.x0), 
                                  addsaturated(x.x1, y.x1), 
                                  addsaturated(x.x2, y.x2), 
                                  addsaturated(x.x3, y.x3), 
                                  addsaturated(x.x4, y.x4), 
                                  addsaturated(x.x5, y.x5), 
                                  addsaturated(x.x6, y.x6), 
                                  addsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 addsaturated(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epi16(x, y);
            }
            else
            {
                return new short16(addsaturated(x.v8_0, y.v8_0), 
                                   addsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int addsaturated(int x, int y)
        {
            return (int)math.clamp((long)x + (long)y, int.MinValue, int.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 addsaturated(int2 x, int2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.adds_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new int2(addsaturated(x.x, y.x), 
                                addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 addsaturated(int3 x, int3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.adds_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new int3(addsaturated(x.x, y.x), 
                                addsaturated(x.y, y.y), 
                                addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 addsaturated(int4 x, int4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.adds_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new int4(addsaturated(x.x, y.x), 
                                addsaturated(x.y, y.y), 
                                addsaturated(x.z, y.z), 
                                addsaturated(x.w, y.w));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 addsaturated(int8 x, int8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_adds_epi32(x, y);
            }
            else
            {
                return new int8(addsaturated(x.v4_0, y.v4_0), 
                                addsaturated(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long addsaturated(long x, long y)
        {
	        long result = x + y;
	        long overflow = (long)((ulong)x >> 63) + long.MaxValue;
	        
	        if ((long)((overflow ^ y) | ~(y ^ result)) >= 0)
	        {
	        	result = overflow;
	        }
            
            return result;
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 addsaturated(long2 x, long2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.adds_epi64(x, y);
            }
            else
            {
                return new long2(addsaturated(x.x, y.x), 
                                 addsaturated(x.y, y.y));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 addsaturated(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_adds_epi64(x, y, 3);
            }
            else
            {
                return new long3(addsaturated(x.xy, y.xy), 
                                 addsaturated(x.z, y.z));
            }
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 addsaturated(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_adds_epi64(x, y, 4);
            }
            else
            {
                return new long4(addsaturated(x.xy, y.xy),
                                 addsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float addsaturated(float x, float y)
        {
            return math.clamp(x + y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 addsaturated(float2 x, float2 y)
        {
            return math.clamp(x + y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 addsaturated(float3 x, float3 y)
        {
            return math.clamp(x + y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 addsaturated(float4 x, float4 y)
        {
            return math.clamp(x + y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 addsaturated(float8 x, float8 y)
        {
            return clamp(x + y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Adds <paramref name="x"/> and <paramref name="y"/> and returns the result, which is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double addsaturated(double x, double y)
        {
            return math.clamp(x + y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 addsaturated(double2 x, double2 y)
        {
            return math.clamp(x + y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 addsaturated(double3 x, double3 y)
        {
            return math.clamp(x + y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Adds each component of <paramref name="x"/> and <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 addsaturated(double4 x, double4 y)
        {
            return math.clamp(x + y, double.MinValue, double.MaxValue);
        }
    }
}