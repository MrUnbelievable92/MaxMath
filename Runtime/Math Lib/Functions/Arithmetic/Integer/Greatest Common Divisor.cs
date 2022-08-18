using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
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
            public static v128 gcd_epu8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 result = ZERO;

                    v128 x_is_zero = Sse2.cmpeq_epi8(a, ZERO);
                    v128 y_is_zero = Sse2.cmpeq_epi8(b, ZERO);
                    v128 any_zero = Sse2.or_si128(x_is_zero, y_is_zero);
                    v128 doneMask = any_zero;
                    
                    v128 result_if_zero_any = Sse2.and_si128(b, x_is_zero);
                    result_if_zero_any = blendv_si128(result_if_zero_any, a, y_is_zero);

                    v128 tzcntA = tzcnt_epi8(a);
                    v128 tzcntB = tzcnt_epi8(b);
                    v128 shift = Sse2.min_epu8(tzcntA, tzcntB);
                    
                    a = srlv_epi8(a, tzcntA, elements);

                    while (true)
                    {
                        b = srlv_epi8(b, tzcntB, elements);

                        v128 tempX = a;
                        a = Sse2.min_epu8(a, b);
                        b = Sse2.max_epu8(b, tempX);

                        b = Sse2.sub_epi8(b, a);
                        
                        v128 loopCheck = Sse2.cmpeq_epi8(b, ZERO);
                        result = blendv_si128(result, a, Sse2.andnot_si128(doneMask, loopCheck));
                        doneMask = Sse2.or_si128(doneMask, loopCheck);

                        if (alltrue_epi128<byte>(doneMask, elements))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = tzcnt_epi8(b);
                        }
                    } 

                    result = sllv_epi8(result, shift, elements);
                    result = blendv_si128(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;

                    v256 x_is_zero = Avx2.mm256_cmpeq_epi8(a, ZERO);
                    v256 y_is_zero = Avx2.mm256_cmpeq_epi8(b, ZERO);
                    v256 any_zero = Avx2.mm256_or_si256(x_is_zero, y_is_zero);
                    v256 doneMask = any_zero;
                    
                    v256 result_if_zero_any = Avx2.mm256_and_si256(b, x_is_zero);
                    result_if_zero_any = mm256_blendv_si256(result_if_zero_any, a, y_is_zero);
                    
                    v256 tzcntA = mm256_tzcnt_epi8(a);
                    v256 tzcntB = mm256_tzcnt_epi8(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    a = mm256_srlv_epi8(a, tzcntA);

                    while (true)
                    {
                        b = mm256_srlv_epi8(b, tzcntB);

                        v256 tempX = a;
                        a = Avx2.mm256_min_epu8(a, b);
                        b = Avx2.mm256_max_epu8(b, tempX);

                        b = Avx2.mm256_sub_epi8(b, a);

                        v256 loopCheck = Avx2.mm256_cmpeq_epi8(b, ZERO);
                        result = mm256_blendv_si256(result, a, Avx2.mm256_andnot_si256(doneMask, loopCheck));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        
                        if (mm256_alltrue_epi256<byte>(doneMask, 32))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi8(b);
                        }
                    } 

                    result = mm256_sllv_epi8(result, shift);
                    result = mm256_blendv_si256(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 result = ZERO;

                    v128 x_is_zero = Sse2.cmpeq_epi16(a, ZERO);
                    v128 y_is_zero = Sse2.cmpeq_epi16(b, ZERO);
                    v128 any_zero = Sse2.or_si128(x_is_zero, y_is_zero);
                    v128 doneMask = any_zero;
                    
                    v128 result_if_zero_any = Sse2.and_si128(b, x_is_zero);
                    result_if_zero_any = blendv_si128(result_if_zero_any, a, y_is_zero);

                    v128 tzcntA = tzcnt_epi16(a);
                    v128 tzcntB = tzcnt_epi16(b);
                    v128 shift = Sse2.min_epu8(tzcntA, tzcntB);
                    
                    a = srlv_epi16(a, tzcntA, elements);

                    while (true)
                    {
                        b = srlv_epi16(b, tzcntB, elements);

                        v128 tempX = a;
                        a = min_epu16(a, b, elements);
                        b = max_epu16(b, tempX, elements);

                        b = Sse2.sub_epi16(b, a);
                        
                        v128 loopCheck = Sse2.cmpeq_epi16(b, ZERO);
                        result = blendv_si128(result, a, Sse2.andnot_si128(doneMask, loopCheck));
                        doneMask = Sse2.or_si128(doneMask, loopCheck);
                        
                        if (alltrue_epi128<ushort>(doneMask, elements))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = tzcnt_epi16(b);
                        }
                    } 

                    result = sllv_epi16(result, shift, elements);
                    result = blendv_si128(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;

                    v256 x_is_zero = Avx2.mm256_cmpeq_epi16(a, ZERO);
                    v256 y_is_zero = Avx2.mm256_cmpeq_epi16(b, ZERO);
                    v256 any_zero = Avx2.mm256_or_si256(x_is_zero, y_is_zero);
                    v256 doneMask = any_zero;
                    
                    v256 result_if_zero_any = Avx2.mm256_and_si256(b, x_is_zero);
                    result_if_zero_any = mm256_blendv_si256(result_if_zero_any, a, y_is_zero);
                    
                    v256 tzcntA = mm256_tzcnt_epi16(a);
                    v256 tzcntB = mm256_tzcnt_epi16(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    a = mm256_srlv_epi16(a, tzcntA);

                    while (true)
                    {
                        b = mm256_srlv_epi16(b, tzcntB);

                        v256 tempX = a;
                        a = Avx2.mm256_min_epu16(a, b);
                        b = Avx2.mm256_max_epu16(b, tempX);

                        b = Avx2.mm256_sub_epi16(b, a);

                        v256 loopCheck = Avx2.mm256_cmpeq_epi16(b, ZERO);
                        result = mm256_blendv_si256(result, a, Avx2.mm256_andnot_si256(doneMask, loopCheck));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        
                        if (mm256_alltrue_epi256<ushort>(doneMask, 16))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi16(b);
                        }
                    } 

                    result = mm256_sllv_epi16(result, shift);
                    result = mm256_blendv_si256(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 result = ZERO;

                    v128 x_is_zero = Sse2.cmpeq_epi32(a, ZERO);
                    v128 y_is_zero = Sse2.cmpeq_epi32(b, ZERO);
                    v128 any_zero = Sse2.or_si128(x_is_zero, y_is_zero);
                    v128 doneMask = any_zero;
                    
                    v128 result_if_zero_any = Sse2.and_si128(b, x_is_zero);
                    result_if_zero_any = blendv_si128(result_if_zero_any, a, y_is_zero);

                    v128 tzcntA = tzcnt_epi32(a, elements);
                    v128 tzcntB = tzcnt_epi32(b, elements);
                    v128 shift = Sse2.min_epu8(tzcntA, tzcntB);
                    
                    a = srlv_epi32(a, tzcntA, elements);

                    while (true)
                    {
                        b = srlv_epi32(b, tzcntB, elements);

                        v128 tempX = a;
                        if (Sse4_1.IsSse41Supported)
                        {
                            a = Sse4_1.min_epu32(a, b);
                            b = Sse4_1.max_epu32(b, tempX);
                        }
                        else
                        {
                            v128 x_greater_y = cmpgt_epu32(a, b, elements);

                            a = blendv_si128(a, b, x_greater_y);
                            b = blendv_si128(b, tempX, x_greater_y);
                        }

                        b = Sse2.sub_epi32(b, a);
                        
                        v128 loopCheck = Sse2.cmpeq_epi32(b, ZERO);
                        result = blendv_si128(result, a, Sse2.andnot_si128(doneMask, loopCheck));
                        doneMask = Sse2.or_si128(doneMask, loopCheck);
                        
                        if (alltrue_epi128<uint>(doneMask, elements))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = tzcnt_epi32(b, elements);
                        }
                    } 

                    result = sllv_epi32(result, shift, elements);
                    result = blendv_si128(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;

                    v256 x_is_zero = Avx2.mm256_cmpeq_epi32(a, ZERO);
                    v256 y_is_zero = Avx2.mm256_cmpeq_epi32(b, ZERO);
                    v256 any_zero = Avx2.mm256_or_si256(x_is_zero, y_is_zero);
                    v256 doneMask = any_zero;
                    
                    v256 result_if_zero_any = Avx2.mm256_and_si256(b, x_is_zero);
                    result_if_zero_any = mm256_blendv_si256(result_if_zero_any, a, y_is_zero);
                    
                    v256 tzcntA = mm256_tzcnt_epi32(a);
                    v256 tzcntB = mm256_tzcnt_epi32(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    a = Avx2.mm256_srlv_epi32(a, tzcntA);

                    while (true)
                    {
                        b = Avx2.mm256_srlv_epi32(b, tzcntB);

                        v256 tempX = a;
                        a = Avx2.mm256_min_epu32(a, b);
                        b = Avx2.mm256_max_epu32(b, tempX);

                        b = Avx2.mm256_sub_epi32(b, a);

                        v256 loopCheck = Avx2.mm256_cmpeq_epi32(b, ZERO);
                        result = mm256_blendv_si256(result, a, Avx2.mm256_andnot_si256(doneMask, loopCheck));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        
                        if (mm256_alltrue_epi256<uint>(doneMask, 8))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi32(b);
                        }
                    } 

                    result = Avx2.mm256_sllv_epi32(result, shift);
                    result = mm256_blendv_si256(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 ZERO = Sse2.setzero_si128();

                    v128 result = ZERO;

                    v128 x_is_zero = cmpeq_epi64(a, ZERO);
                    v128 y_is_zero = cmpeq_epi64(b, ZERO);
                    v128 any_zero = Sse2.or_si128(x_is_zero, y_is_zero);
                    v128 doneMask = any_zero;

                    v128 result_if_zero_any = Sse2.and_si128(b, x_is_zero);
                    result_if_zero_any = blendv_si128(result_if_zero_any, a, y_is_zero);
                    
                    v128 tzcntA = tzcnt_epi64(a);
                    v128 tzcntB = tzcnt_epi64(b);
                    v128 shift = Sse2.min_epu8(tzcntA, tzcntB);
                    
                    a = srlv_epi64(a, tzcntA);

                    while (true)
                    {
                        b = srlv_epi64(b, tzcntB);

                        v128 tempX = a;
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    a = min_epu64(a, b);
                        //    b = max_epu64(b, tempX);
                        //}
                        //else
                        //{
                              v128 x_greater_y = cmpgt_epu64(a, b);
                              
                              a = blendv_si128(a, b, x_greater_y);
                              b = blendv_si128(b, tempX, x_greater_y);
                        //}

                        b = Sse2.sub_epi64(b, a);

                        v128 loopCheck = cmpeq_epi64(b, ZERO);
                        result = blendv_si128(result, a, Sse2.andnot_si128(doneMask, loopCheck));
                        doneMask = Sse2.or_si128(doneMask, loopCheck);
                        
                        if (alltrue_epi128<ulong>(doneMask, 2))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = tzcnt_epi64(b);
                        }
                    } 

                    result = sllv_epi64(result, shift);
                    result = blendv_si128(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;

                    v256 x_is_zero = Avx2.mm256_cmpeq_epi64(a, ZERO);
                    v256 y_is_zero = Avx2.mm256_cmpeq_epi64(b, ZERO);
                    v256 any_zero = Avx2.mm256_or_si256(x_is_zero, y_is_zero);
                    v256 doneMask = any_zero;
                    
                    v256 result_if_zero_any = Avx2.mm256_and_si256(b, x_is_zero);
                    result_if_zero_any = mm256_blendv_si256(result_if_zero_any, a, y_is_zero);
                    
                    v256 tzcntA = mm256_tzcnt_epi64(a);
                    v256 tzcntB = mm256_tzcnt_epi64(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    a = Avx2.mm256_srlv_epi64(a, tzcntA);

                    while (true)
                    {
                        b = Avx2.mm256_srlv_epi64(b, tzcntB);

                        v256 tempX = a;
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    a = mm256_min_epu64(a, b);
                        //    b = mm256_max_epu64(b, tempX);
                        //}
                        //else
                        //{
                              v256 x_greater_y = mm256_cmpgt_epu64(a, b);
                              
                              a = mm256_blendv_si256(a, b, x_greater_y);
                              b = mm256_blendv_si256(b, tempX, x_greater_y);
                        //}

                        b = Avx2.mm256_sub_epi64(b, a);

                        v256 loopCheck = Avx2.mm256_cmpeq_epi64(b, ZERO);
                        result = mm256_blendv_si256(result, a, Avx2.mm256_andnot_si256(doneMask, loopCheck));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        
                        if (mm256_alltrue_epi256<ulong>(doneMask, elements))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi64(b);
                        }
                    } 

                    result = Avx2.mm256_sllv_epi64(result, shift);
                    result = mm256_blendv_si256(result, result_if_zero_any, any_zero);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the greatest common divisor of two <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 gcd(UInt128 x, UInt128 y)
        {
            if (Hint.Unlikely(x.IsZero)) return y;
            if (Hint.Unlikely(y.IsZero)) return x;

            int tzcntX = tzcnt(x);
            int tzcntY = tzcnt(y);
            int shift = math.min(tzcntX, tzcntY);
            x >>= tzcntX;

            while (true)
            {
                y >>= tzcntY;

                if (x > y)
                {
                    UInt128 t = y;
                    y = x;
                    x = t;
                }

                y -= x;
                
                if (y == 0)
                {
                    break;
                }
                else
                {
                    tzcntY = tzcnt(y);
                }
            } 

            return x << shift;
        }

        /// <summary>       Returns the greatest common divisor of two <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 gcd(Int128 x, Int128 y)
        {
            return gcd((UInt128)abs(x), (UInt128)abs(y));
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="long"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong gcd(long x, long y)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0))
            {
                if (Xse.constexpr.IS_TRUE(y >= 0))
                {
                    return gcd((ulong)x, (ulong)y);
                }
                else
                {
                    return gcd((ulong)x, (ulong)math.abs(y));
                }
            }
            else if (Xse.constexpr.IS_TRUE(y >= 0))
            {
                return gcd((ulong)math.abs(x), (ulong)y);
            }
            else
            {
                return gcd((ulong)math.abs(x), (ulong)math.abs(y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 gcd(long2 x, long2 y)
        {
            return gcd((ulong2)abs(x), (ulong2)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 gcd(long3 x, long3 y)
        {
            return gcd((ulong3)abs(x), (ulong3)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 gcd(long4 x, long4 y)
        {
            return gcd((ulong4)abs(x), (ulong4)abs(y));
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="ulong"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong gcd(ulong x, ulong y)
        {
            if (x == 0) return y;
            if (y == 0) return x;

            int tzcntX = math.tzcnt(x);
            int tzcntY = math.tzcnt(y);
            int shift = math.min(tzcntX, tzcntY);
            x >>= tzcntX;

            while (true)
            {
                y >>= tzcntY;

                if (x > y)
                {
                    ulong t = y;
                    y = x;
                    x = t;
                }

                y -= x;
                
                if (y == 0)
                {
                    break;
                }
                else
                {
                    tzcntY = math.tzcnt(y);
                }
            } 

            return x << shift;
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 gcd(ulong2 x, ulong2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu64(x, y);
            }
            else
            {
                return new ulong2(gcd(x.x, y.x), gcd(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 gcd(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu64(x, y, 3);
            }
            else
            {
                return new ulong3(gcd(x._xy, y._xy), gcd(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 gcd(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu64(x, y, 4);
            }
            else
            {
                return new ulong4(gcd(x._xy, y._xy), gcd(x._zw, y._zw));
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="int"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint gcd(int x, int y)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0))
            {
                if (Xse.constexpr.IS_TRUE(y >= 0))
                {
                    return gcd((uint)x, (uint)y);
                }
                else
                {
                    return gcd((uint)x, (uint)math.abs(y));
                }
            }
            else if (Xse.constexpr.IS_TRUE(y >= 0))
            {
                return gcd((uint)math.abs(x), (uint)y);
            }
            else
            {
                return gcd((uint)math.abs(x), (uint)math.abs(y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 gcd(int2 x, int2 y)
        {
            if (Xse.constexpr.IS_TRUE(math.all(x >= 0)))
            {
                if (Xse.constexpr.IS_TRUE(math.all(y >= 0)))
                {
                    return gcd((uint2)x, (uint2)y);
                }
                else
                {
                    return gcd((uint2)x, (uint2)math.abs(y));
                }
            }
            else if (Xse.constexpr.IS_TRUE(math.all(y >= 0)))
            {
                return gcd((uint2)math.abs(x), (uint2)y);
            }
            else
            {
                return gcd((uint2)math.abs(x), (uint2)math.abs(y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 gcd(int3 x, int3 y)
        {
            if (Xse.constexpr.IS_TRUE(math.all(x >= 0)))
            {
                if (Xse.constexpr.IS_TRUE(math.all(y >= 0)))
                {
                    return gcd((uint3)x, (uint3)y);
                }
                else
                {
                    return gcd((uint3)x, (uint3)math.abs(y));
                }
            }
            else if (Xse.constexpr.IS_TRUE(math.all(y >= 0)))
            {
                return gcd((uint3)math.abs(x), (uint3)y);
            }
            else
            {
                return gcd((uint3)math.abs(x), (uint3)math.abs(y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 gcd(int4 x, int4 y)
        {
            if (Xse.constexpr.IS_TRUE(math.all(x >= 0)))
            {
                if (Xse.constexpr.IS_TRUE(math.all(y >= 0)))
                {
                    return gcd((uint4)x, (uint4)y);
                }
                else
                {
                    return gcd((uint4)x, (uint4)math.abs(y));
                }
            }
            else if (Xse.constexpr.IS_TRUE(math.all(y >= 0)))
            {
                return gcd((uint4)math.abs(x), (uint4)y);
            }
            else
            {
                return gcd((uint4)math.abs(x), (uint4)math.abs(y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 gcd(int8 x, int8 y)
        {
            if (Xse.constexpr.IS_TRUE(all(x >= 0)))
            {
                if (Xse.constexpr.IS_TRUE(all(y >= 0)))
                {
                    return gcd((uint8)x, (uint8)y);
                }
                else
                {
                    return gcd((uint8)x, (uint8)abs(y));
                }
            }
            else if (Xse.constexpr.IS_TRUE(all(y >= 0)))
            {
                return gcd((uint8)abs(x), (uint8)y);
            }
            else
            {
                return gcd((uint8)abs(x), (uint8)abs(y));
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="uint"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint gcd(uint x, uint y)
        {
            if (x == 0) return y;
            if (y == 0) return x;

            int tzcntX = math.tzcnt(x);
            int tzcntY = math.tzcnt(y);
            int shift = math.min(tzcntX, tzcntY);
            x >>= tzcntX;

            while (true)
            {
                y >>= tzcntY;

                if (x > y)
                {
                    uint t = y;
                    y = x;
                    x = t;
                }

                y -= x;
                
                if (y == 0)
                {
                    break;
                }
                else
                {
                    tzcntY = math.tzcnt(y);
                }
            } 

            return x << shift;
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 gcd(uint2 x, uint2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.gcd_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new uint2(gcd(x.x, y.x), gcd(x.y, y.y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 gcd(uint3 x, uint3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.gcd_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new uint3(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 gcd(uint4 x, uint4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.gcd_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new uint4(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z), gcd(x.w, y.w));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 gcd(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu32(x, y);
            }
            else
            {
                return new uint8(gcd(x.v4_0, y.v4_0), gcd(x.v4_4, y.v4_4));
            }
        }

        /// <summary>       Returns the greatest common divisor of two <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort gcd(short x, short y)
        {
            return (ushort)gcd((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 gcd(short2 x, short2 y)
        {
            return gcd((ushort2)abs(x), (ushort2)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 gcd(short3 x, short3 y)
        {
            return gcd((ushort3)abs(x), (ushort3)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 gcd(short4 x, short4 y)
        {
            return gcd((ushort4)abs(x), (ushort4)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 gcd(short8 x, short8 y)
        {
            return gcd((ushort8)abs(x), (ushort8)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 gcd(short16 x, short16 y)
        {
            return gcd((ushort16)abs(x), (ushort16)abs(y));
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort gcd(ushort x, ushort y)
        {
            return (ushort)gcd((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 gcd(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu16(x, y, 2);
            }
            else
            {
                return new ushort2((ushort)gcd((uint)x.x, (uint)y.x), (ushort)gcd((uint)x.y, (uint)y.y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 gcd(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu16(x, y, 3);
            }
            else
            {
                return new ushort3((ushort)gcd((uint)x.x, (uint)y.x), (ushort)gcd((uint)x.y, (uint)y.y), (ushort)gcd((uint)x.z, (uint)y.z));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 gcd(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu16(x, y, 4);
            }
            else
            {
                return new ushort4((ushort)gcd((uint)x.x, (uint)y.x), (ushort)gcd((uint)x.y, (uint)y.y), (ushort)gcd((uint)x.z, (uint)y.z), (ushort)gcd((uint)x.w, (uint)y.w));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 gcd(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu16(x, y, 8);
            }
            else
            {
                return new ushort8((ushort)gcd((uint)x.x0,  (uint)y.x0),
                                   (ushort)gcd((uint)x.x1,  (uint)y.x1),
                                   (ushort)gcd((uint)x.x2,  (uint)y.x2),
                                   (ushort)gcd((uint)x.x3,  (uint)y.x3),
                                   (ushort)gcd((uint)x.x4,  (uint)y.x4),
                                   (ushort)gcd((uint)x.x5,  (uint)y.x5),
                                   (ushort)gcd((uint)x.x6,  (uint)y.x6),
                                   (ushort)gcd((uint)x.x7,  (uint)y.x7));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 gcd(ushort16 x, ushort16 y)
        { 
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu16(x, y);
            }
            else
            {
                return new ushort16(gcd(x.v8_0, y.v8_0), gcd(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte gcd(sbyte x, sbyte y)
        {
            return (byte)gcd((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 gcd(sbyte2 x, sbyte2 y)
        {
            return gcd((byte2)abs(x), (byte2)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 gcd(sbyte3 x, sbyte3 y)
        {
            return gcd((byte3)abs(x), (byte3)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 gcd(sbyte4 x, sbyte4 y)
        {
            return gcd((byte4)abs(x), (byte4)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 gcd(sbyte8 x, sbyte8 y)
        {
            return gcd((byte8)abs(x), (byte8)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 gcd(sbyte16 x, sbyte16 y)
        {
            return gcd((byte16)abs(x), (byte16)abs(y));
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 gcd(sbyte32 x, sbyte32 y)
        {
            return gcd((byte32)abs(x), (byte32)abs(y));
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte gcd(byte x, byte y)
        {
            return (byte)gcd((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 gcd(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu8(x, y, 2);
            }
            else
            {
                return new byte2((byte)gcd((uint)x.x, (uint)y.x), (byte)gcd((uint)x.y, (uint)y.y));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 gcd(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu8(x, y, 3);
            }
            else
            {
                return new byte3((byte)gcd((uint)x.x, (uint)y.x), (byte)gcd((uint)x.y, (uint)y.y), (byte)gcd((uint)x.z, (uint)y.z));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 gcd(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu8(x, y, 4);
            }
            else
            {
                return new byte4((byte)gcd((uint)x.x, (uint)y.x), (byte)gcd((uint)x.y, (uint)y.y), (byte)gcd((uint)x.z, (uint)y.z), (byte)gcd((uint)x.w, (uint)y.w));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 gcd(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu8(x, y, 8);
            }
            else
            {
                return new byte8((byte)gcd((uint)x.x0,  (uint)y.x0),
                                 (byte)gcd((uint)x.x1,  (uint)y.x1),
                                 (byte)gcd((uint)x.x2,  (uint)y.x2),
                                 (byte)gcd((uint)x.x3,  (uint)y.x3),
                                 (byte)gcd((uint)x.x4,  (uint)y.x4),
                                 (byte)gcd((uint)x.x5,  (uint)y.x5),
                                 (byte)gcd((uint)x.x6,  (uint)y.x6),
                                 (byte)gcd((uint)x.x7,  (uint)y.x7));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 gcd(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gcd_epu8(x, y, 16);
            }
            else
            {
                return new byte16((byte)gcd((uint)x.x0,  (uint)y.x0),
                                  (byte)gcd((uint)x.x1,  (uint)y.x1),
                                  (byte)gcd((uint)x.x2,  (uint)y.x2),
                                  (byte)gcd((uint)x.x3,  (uint)y.x3),
                                  (byte)gcd((uint)x.x4,  (uint)y.x4),
                                  (byte)gcd((uint)x.x5,  (uint)y.x5),
                                  (byte)gcd((uint)x.x6,  (uint)y.x6),
                                  (byte)gcd((uint)x.x7,  (uint)y.x7),
                                  (byte)gcd((uint)x.x8,  (uint)y.x8),
                                  (byte)gcd((uint)x.x9,  (uint)y.x9),
                                  (byte)gcd((uint)x.x10, (uint)y.x10),
                                  (byte)gcd((uint)x.x11, (uint)y.x11),
                                  (byte)gcd((uint)x.x12, (uint)y.x12),
                                  (byte)gcd((uint)x.x13, (uint)y.x13),
                                  (byte)gcd((uint)x.x14, (uint)y.x14),
                                  (byte)gcd((uint)x.x15, (uint)y.x15));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 gcd(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu8(x, y);
            }
            else
            {
                return new byte32(gcd(x.v16_0, y.v16_0), gcd(x.v16_16, y.v16_16));
            }
        }
    }
}