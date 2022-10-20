using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sllv_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (constexpr.ALL_LE_EPI8(b, 0, elements) || constexpr.ALL_GE_EPI8(b, 8, elements))
                {
                    return a;
                }

                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return slli_epi8(a, b.Byte0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        return cvtepi32_epi8(Avx2.sllv_epi32(Sse4_1.cvtepu8_epi32(a), Sse4_1.cvtepu8_epi32(b)));
                    }
                }
                
                if (Constant.IsConstantExpression(b))
                {
                    return mullo_epi8(a, new v128((byte)(1 << b.Byte0), (byte)(1 << b.Byte1), (byte)(1 << b.Byte2), (byte)(1 << b.Byte3), (byte)(1 << b.Byte4), (byte)(1 << b.Byte5), (byte)(1 << b.Byte6), (byte)(1 << b.Byte7), (byte)(1 << b.Byte8), (byte)(1 << b.Byte9), (byte)(1 << b.Byte10), (byte)(1 << b.Byte11), (byte)(1 << b.Byte12), (byte)(1 << b.Byte13), (byte)(1 << b.Byte14), (byte)(1 << b.Byte15)), elements);
                }

                if (Ssse3.IsSsse3Supported)
                {
                    if (Constant.IsConstantExpression(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0);
                    
                        return Ssse3.shuffle_epi8(LOOKUP, b);
                    }

                    v128 POW2_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,     1, 1, 1, 1, 1, 1, 1, 1);
                    v128 mulValues = Ssse3.shuffle_epi8(POW2_MASK, b);
                    
                    return mullo_epi8(a, mulValues, elements);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result0 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.setzero_si128(), b));
                    a = slli_epi8(a, 1);
                    v128 result1 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(1), b));
                    a = slli_epi8(a, 1);
                    v128 result2 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(2), b));
                    a = slli_epi8(a, 1);
                    v128 result3 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(3), b));
                    a = slli_epi8(a, 1);
                    v128 result4 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(4), b));
                    a = slli_epi8(a, 1);
                    v128 result5 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(5), b));
                    a = slli_epi8(a, 1);
                    v128 result6 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(6), b));
                    a = slli_epi8(a, 1);
                    v128 result7 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(7), b));
    
                    v128 result01 = Sse2.or_si128(result0, result1);
                    v128 result23 = Sse2.or_si128(result2, result3);
                    v128 result45 = Sse2.or_si128(result4, result5);
                    v128 result67 = Sse2.or_si128(result6, result7);
    
                    return Sse2.or_si128(Sse2.or_si128(result01, result23), Sse2.or_si128(result45, result67));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sllv_epi8(v256 a, v256 b)
            {
                if (constexpr.ALL_LE_EPI8(b, 0) || constexpr.ALL_GE_EPI8(b, 8))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_slli_epi8(a, b.Byte0);
                }

                if (Constant.IsConstantExpression(b))
                {
                    return mm256_mullo_epi8(a, new v256((byte)(1 << b.Byte0), (byte)(1 << b.Byte1), (byte)(1 << b.Byte2), (byte)(1 << b.Byte3), (byte)(1 << b.Byte4), (byte)(1 << b.Byte5), (byte)(1 << b.Byte6), (byte)(1 << b.Byte7), (byte)(1 << b.Byte8), (byte)(1 << b.Byte9), (byte)(1 << b.Byte10), (byte)(1 << b.Byte11), (byte)(1 << b.Byte12), (byte)(1 << b.Byte13), (byte)(1 << b.Byte14), (byte)(1 << b.Byte15), (byte)(1 << b.Byte16), (byte)(1 << b.Byte17), (byte)(1 << b.Byte18), (byte)(1 << b.Byte19), (byte)(1 << b.Byte20), (byte)(1 << b.Byte21), (byte)(1 << b.Byte22), (byte)(1 << b.Byte23), (byte)(1 << b.Byte24), (byte)(1 << b.Byte25), (byte)(1 << b.Byte26), (byte)(1 << b.Byte27), (byte)(1 << b.Byte28), (byte)(1 << b.Byte29), (byte)(1 << b.Byte30), (byte)(1 << b.Byte31)));
                }
    
                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                    {
                        v256 LOOKUP = new v256((byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                               (byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0);
                    
                        return Avx2.mm256_shuffle_epi8(LOOKUP, b);
                    }


                    v256 POW2_MASK = new v256(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,     1, 1, 1, 1, 1, 1, 1, 1,
                                              1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,     1, 1, 1, 1, 1, 1, 1, 1);
    
                    v256 mulValues = Avx2.mm256_shuffle_epi8(POW2_MASK, b);
                    
                    return mm256_mullo_epi8(a, mulValues);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sllv_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (constexpr.ALL_LE_EPI16(b, 0, elements) || constexpr.ALL_GE_EPI16(b, 16, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return slli_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        return mm256_cvtepi32_epi16(Avx2.mm256_sllv_epi32(Avx2.mm256_cvtepu16_epi32(a), Avx2.mm256_cvtepu16_epi32(b)));
                    }
                    else
                    {
                        return cvtepi32_epi16(Avx2.sllv_epi32(Sse4_1.cvtepu16_epi32(a), Sse4_1.cvtepu16_epi32(b)), elements);
                    }
                }
                
                if (Constant.IsConstantExpression(b))
                {
                    return Sse2.mullo_epi16(a, new v128((short)(1 << b.SShort0), (short)(1 << b.SShort1), (short)(1 << b.SShort2), (short)(1 << b.SShort3), (short)(1 << b.SShort4), (short)(1 << b.SShort5), (short)(1 << b.SShort6), (short)(1 << b.SShort7)));
                }

                if (Sse4_1.IsSse41Supported)
                {
                    if (elements <= 3)
                    {
                        v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
    
                        v128 _x = Sse2.sll_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 2, 0);
                        v128 _y = Sse2.sll_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _xy = Sse4_1.blend_epi16(_x, _y, 0b0000_0010);

                        if (elements == 2)
                        {
                            return _xy;
                        }

                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 4, 0);
                        v128 _z = Sse2.sll_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
    
                        return Sse4_1.blend_epi16(_xy, _z, 0b0000_0100);
                    }
                }
                
                if (Ssse3.IsSsse3Supported)
                {
                    v128 POW2_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,       0, 0, 0, 0, 0, 0, 0, 0);
                    
                    v128 mulValues = Sse2.packus_epi16(b, b);
    
                    v128 pow8to15 = Sse2.sub_epi8(mulValues, Sse2.set1_epi8(8));
                    pow8to15 = Ssse3.shuffle_epi8(POW2_MASK, pow8to15);
    
                    v128 mulLo = Ssse3.shuffle_epi8(POW2_MASK, mulValues);
    
                    mulValues = Sse2.unpacklo_epi8(mulLo, pow8to15);
                    
                    if (constexpr.ALL_EQ_EPI16(a, 1))
                    {
                        return mulValues;
                    }
                    else
                    {
                        return Sse2.mullo_epi16(a, mulValues);
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 EPI16_MASK = new v128(15, 0, 0, 0);
    
                    v128 elementMask = new v128(ushort.MaxValue, 0, 0, 0);
    
                    v128 result0 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                    result0 = Sse2.and_si128(result0, elementMask);
                    elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                    b = Sse2.bsrli_si128(b, sizeof(short));
                    v128 result1 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                    result1 = Sse2.and_si128(result1, elementMask);
                    elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                    result0 = Sse2.or_si128(result0, result1);
    
                    if (elements > 2)
                    {
                        b = Sse2.bsrli_si128(b, sizeof(short));
                        result1 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                        result1 = Sse2.and_si128(result1, elementMask);
                        elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                        result0 = Sse2.or_si128(result0, result1);
    
                        if (elements > 3)
                        {
                            b = Sse2.bsrli_si128(b, sizeof(short));
                            result1 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                            result1 = Sse2.and_si128(result1, elementMask);
                            elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                            result0 = Sse2.or_si128(result0, result1);
                            
                            if (elements > 4)
                            {
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sll_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sll_epi16(a, b);
                                result1 = Sse2.and_si128(result1, elementMask);
                                result0 = Sse2.or_si128(result0, result1);
                            }
                        }
                    }
    
                    return result0;
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sllv_epi16(v256 a, v256 b)
            {
                if (constexpr.ALL_LE_EPI16(b, 0) || constexpr.ALL_GE_EPI16(b, 16))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_slli_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Avx2.mm256_mullo_epi16(a, new v256((short)(1 << b.SShort0), (short)(1 << b.SShort1), (short)(1 << b.SShort2), (short)(1 << b.SShort3), (short)(1 << b.SShort4), (short)(1 << b.SShort5), (short)(1 << b.SShort6), (short)(1 << b.SShort7), (short)(1 << b.SShort8), (short)(1 << b.SShort9), (short)(1 << b.SShort10), (short)(1 << b.SShort11), (short)(1 << b.SShort12), (short)(1 << b.SShort13), (short)(1 << b.SShort14), (short)(1 << b.SShort15)));
                    }
                    
                    v256 aLo = mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                    v256 bLo = mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                    aLo = Avx2.mm256_sllv_epi32(aLo, bLo);
                    aHi = Avx2.mm256_sllv_epi32(aHi, bHi);

                    // no pack - shl easily overflows
                    return mm256_cvt2x2epi32_epi16(aLo, aHi);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sllv_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPI32(b, 0, elements) || constexpr.ALL_GE_EPI32(b, 32, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return slli_epi32(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.sllv_epi32(a, b);
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        if (Constant.IsConstantExpression(b))
                        {
                            return Sse4_1.mullo_epi32(a, new v128(1 << b.SInt0, 1 << b.SInt1, 1 << b.SInt2, 1 << b.SInt3));
                        }
    
                        v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                        v128 _x = Sse2.sll_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 4, 0);
                        v128 _y = Sse2.sll_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _xy = Sse4_1.blend_epi16(_x, _y, 0b0000_1100);
    
                        if (elements == 2)
                        {
                            return _xy;
                        }

                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                        v128 _z = Sse2.sll_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                        if (elements == 3)
                        {
                            return Sse4_1.blend_epi16(_xy, _z, 0b0011_0000);
                        }
    
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 12, 0);
                        v128 _w = Sse2.sll_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _zw = Sse4_1.blend_epi16(_z, _w, 0b1100_0000);
    
                        return Sse4_1.blend_epi16(_xy, _zw, 0b1111_0000);
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(b) && elements > 3)
                        {
                            return mullo_epi32(a, new v128(1 << b.SInt0, 1 << b.SInt1, 1 << b.SInt2, 1 << b.SInt3));
                        }
    
                        v128 MASK = Sse2.cvtsi32_si128(byte.MaxValue);
    
                        v128 _x = Sse2.sll_epi32(a,                                    Sse2.and_si128(MASK, b));
                        v128 _y = Sse2.sll_epi32(Sse2.bsrli_si128(a, 1 * sizeof(int)), Sse2.and_si128(MASK, Sse2.bsrli_si128(b, 1 * sizeof(int))));
    
                        if (elements == 2)
                        {
                            return Sse2.unpacklo_epi32(_x, _y);
                        }
                        
                        v128 lo = Sse2.unpacklo_epi32(_x, _y);
                        v128 _z = Sse2.sll_epi32(Sse2.bsrli_si128(a, 2 * sizeof(int)), Sse2.and_si128(MASK, Sse2.bsrli_si128(b, 2 * sizeof(int))));
    
                        if (elements == 3)
                        {
                            return Sse2.unpacklo_epi64(lo, _z);
                        }
    
                        v128 _w = Sse2.sll_epi32(Sse2.bsrli_si128(a, 3 * sizeof(int)), Sse2.bsrli_si128(b, 3 * sizeof(int)));
    
                        v128 hi = Sse2.unpacklo_epi32(_z, _w);
    
                        return Sse2.unpacklo_epi64(lo, hi);
                    }
                    else throw new IllegalInstructionException();
                }
            }
    

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sllv_epi64(v128 a, v128 b)
            {
                if (constexpr.ALL_LE_EPI64(b, 0) || constexpr.ALL_GE_EPI64(b, 64))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return slli_epi64(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.sllv_epi64(a, b);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = Sse2.sll_epi64(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                    v128 _y = Sse2.sll_epi64(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                    return Sse4_1.blend_epi16(_x, _y, 0b1111_0000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 MASK = Sse2.cvtsi32_si128(255);
    
                    v128 _x = Sse2.sll_epi64(a,                                      Sse2.and_si128(MASK, b));
                    v128 _y = Sse2.sll_epi64(Sse2.bsrli_si128(a, 1 * sizeof(ulong)), Sse2.bsrli_si128(b, 1 * sizeof(ulong)));
    
                    return Sse2.unpacklo_epi64(_x, _y);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srlv_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (constexpr.ALL_LE_EPI8(b, 0, elements) || constexpr.ALL_GE_EPI8(b, 8, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return srli_epi8(a, b.Byte0);
                }

                if (Ssse3.IsSsse3Supported && Constant.IsConstantExpression(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                {
                    v128 LOOKUP = new v128((byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    return Ssse3.shuffle_epi8(LOOKUP, b);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 8)
                    {
                        v128 a16Hi = Sse2.unpackhi_epi8(a, Sse2.setzero_si128());
                        v128 b16Hi = Sse2.unpackhi_epi8(b, Sse2.setzero_si128());

                        v128 a32LoLo = Sse4_1.cvtepu8_epi32(a);
                        v128 a32LoHi = Sse4_1.cvtepu8_epi32(Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 3, 2, 1)));
                        v128 a32HiLo = Sse2.unpacklo_epi16(a16Hi, Sse2.setzero_si128());
                        v128 a32HiHi = Sse2.unpackhi_epi16(a16Hi, Sse2.setzero_si128());
                        v128 b32LoLo = Sse4_1.cvtepu8_epi32(b);
                        v128 b32LoHi = Sse4_1.cvtepu8_epi32(Sse2.shuffle_epi32(b, Sse.SHUFFLE(0, 3, 2, 1)));
                        v128 b32HiLo = Sse2.unpacklo_epi16(b16Hi, Sse2.setzero_si128());
                        v128 b32HiHi = Sse2.unpackhi_epi16(b16Hi, Sse2.setzero_si128());

                        a32LoLo = Avx2.srlv_epi32(a32LoLo, b32LoLo);
                        a32LoHi = Avx2.srlv_epi32(a32LoHi, b32LoHi);
                        a32HiLo = Avx2.srlv_epi32(a32HiLo, b32HiLo);
                        a32HiHi = Avx2.srlv_epi32(a32HiHi, b32HiHi);

                        return Sse2.packus_epi16(Sse4_1.packus_epi32(a32LoLo, a32LoHi), Sse4_1.packus_epi32(a32HiLo, a32HiHi));
                    }
                    else if (elements > 4)
                    {
                        return mm256_cvtepi32_epi8(Avx2.mm256_srlv_epi32(Avx2.mm256_cvtepu8_epi32(a), Avx2.mm256_cvtepu8_epi32(b)));
                    }
                    else
                    {
                        return cvtepi32_epi8(Avx2.srlv_epi32(Sse4_1.cvtepu8_epi32(a), Sse4_1.cvtepu8_epi32(b)));
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result0 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.setzero_si128(), b));
                    a = srli_epi8(a, 1);
                    v128 result1 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(1), b));
                    a = srli_epi8(a, 1);
                    v128 result2 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(2), b));
                    a = srli_epi8(a, 1);
                    v128 result3 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(3), b));
                    a = srli_epi8(a, 1);
                    v128 result4 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(4), b));
                    a = srli_epi8(a, 1);
                    v128 result5 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(5), b));
                    a = srli_epi8(a, 1);
                    v128 result6 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(6), b));
                    a = srli_epi8(a, 1);
                    v128 result7 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(7), b));
    
                    v128 result01 = Sse2.or_si128(result0, result1);
                    v128 result23 = Sse2.or_si128(result2, result3);
                    v128 result45 = Sse2.or_si128(result4, result5);
                    v128 result67 = Sse2.or_si128(result6, result7);
    
                    return Sse2.or_si128(Sse2.or_si128(result01, result23), Sse2.or_si128(result45, result67));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_srlv_epi8(v256 a, v256 b)
            {
                if (constexpr.ALL_LE_EPI8(b, 0) || constexpr.ALL_GE_EPI8(b, 8))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_srli_epi8(a, b.Byte0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                    {
                        v256 LOOKUP = new v256((byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                               (byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);
                    
                        return Avx2.mm256_shuffle_epi8(LOOKUP, b);
                    }


                    v256 shortsLoA = mm256_cvt2x2epu8_epi16(a, out v256 shortsHiA);
                    v256 shortsLoB = mm256_cvt2x2epu8_epi16(b, out v256 shortsHiB);

                    v256 intsLoALo = mm256_cvt2x2epu16_epi32(shortsLoA, out v256 intsLoAHi);
                    v256 intsHiALo = mm256_cvt2x2epu16_epi32(shortsHiA, out v256 intsHiAHi);
                    v256 intsLoBLo = mm256_cvt2x2epu16_epi32(shortsLoB, out v256 intsLoBHi);
                    v256 intsHiBLo = mm256_cvt2x2epu16_epi32(shortsHiB, out v256 intsHiBHi);
    
                    intsLoALo = Avx2.mm256_srlv_epi32(intsLoALo, intsLoBLo);
                    intsLoAHi = Avx2.mm256_srlv_epi32(intsLoAHi, intsLoBHi);
                    intsHiALo = Avx2.mm256_srlv_epi32(intsHiALo, intsHiBLo);
                    intsHiAHi = Avx2.mm256_srlv_epi32(intsHiAHi, intsHiBHi);
                    
                    shortsLoA = Avx2.mm256_packus_epi32(intsLoALo, intsLoAHi);
                    shortsLoB = Avx2.mm256_packus_epi32(intsHiALo, intsHiAHi);
                    
                    return Avx2.mm256_packus_epi16(shortsLoA, shortsLoB);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srlv_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (constexpr.ALL_LE_EPI16(b, 0, elements) || constexpr.ALL_GE_EPI16(b, 16, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return srli_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 a32Lo = cvt2x2epu16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epu16_epi32(b, out v128 b32Hi);

                        v128 lo = Avx2.srlv_epi32(a32Lo, b32Lo);
                        v128 hi = Avx2.srlv_epi32(a32Hi, b32Hi);

                        return Sse4_1.packus_epi32(lo, hi);
                    }
                    else
                    {
                        return cvtepi32_epi16(Avx2.srlv_epi32(Sse4_1.cvtepu16_epi32(a), Sse4_1.cvtepu16_epi32(b)), elements);
                    }
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                     
                    v128 _x = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 2, 0);
                    v128 _y = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    v128 _xy = Sse4_1.blend_epi16(_x, _y, 0b0000_0010);
    
                    if (elements == 2)
                    {
                        return _xy;
                    }
                    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 4, 0);
                    v128 _z = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                    if (elements == 3)
                    {
                        return Sse4_1.blend_epi16(_xy, _z, 0b0000_0100);
                    }
                    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 6, 0);
                    v128 _w = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                    v128 _zw = Sse4_1.blend_epi16(_z, _w, 0b0000_1000);
                    
                    v128 result = Sse4_1.blend_epi16(_xy, _zw, 0b0000_1100);
    
                    if (elements == 4)
                    {
                        return result;
                    }
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                    v128 shift = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b0001_0000);
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 10, 0);
                    shift = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b0010_0000);
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 12, 0);
                    shift = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b0100_0000);
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 14, 0);
                    shift = Sse2.srl_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b1000_0000);
    
    
                    return result;
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 EPI16_MASK = new v128(15, 0, 0, 0);
    
                    v128 elementMask = new v128(ushort.MaxValue, 0, 0, 0);
    
                    v128 result0 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                    result0 = Sse2.and_si128(result0, elementMask);
                    elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                    b = Sse2.bsrli_si128(b, sizeof(short));
                    v128 result1 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                    result1 = Sse2.and_si128(result1, elementMask);
                    elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                    result0 = Sse2.or_si128(result0, result1);
    
                    if (elements > 2)
                    {
                        b = Sse2.bsrli_si128(b, sizeof(short));
                        result1 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                        result1 = Sse2.and_si128(result1, elementMask);
                        elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                        result0 = Sse2.or_si128(result0, result1);
    
                        if (elements > 3)
                        {
                            b = Sse2.bsrli_si128(b, sizeof(short));
                            result1 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                            result1 = Sse2.and_si128(result1, elementMask);
                            elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                            result0 = Sse2.or_si128(result0, result1);
                            
                            if (elements > 4)
                            {
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.srl_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.srl_epi16(a, b);
                                result1 = Sse2.and_si128(result1, elementMask);
                                result0 = Sse2.or_si128(result0, result1);
                            }
                        }
                    }
    
                    return result0;
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_srlv_epi16(v256 a, v256 b)
            {
                if (constexpr.ALL_LE_EPI16(b, 0) || constexpr.ALL_GE_EPI16(b, 16))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_srli_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    v256 aLo = mm256_cvt2x2epu16_epi32(a, out v256 aHi);
                    v256 bLo = mm256_cvt2x2epu16_epi32(b, out v256 bHi);

                    aLo = Avx2.mm256_srlv_epi32(aLo, bLo);
                    aHi = Avx2.mm256_srlv_epi32(aHi, bHi);

                    return Avx2.mm256_packus_epi32(aLo, aHi);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srlv_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPI32(b, 0, elements) || constexpr.ALL_GE_EPI32(b, 32, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return srli_epi32(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srlv_epi32(a, b);
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                        v128 _x = Sse2.srl_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 4, 0);
                        v128 _y = Sse2.srl_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _xy = Sse4_1.blend_epi16(_x, _y, 0b0000_1100);
    
                        if (elements == 2)
                        {
                            return _xy;
                        }
    
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                        v128 _z = Sse2.srl_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                        if (elements == 3)
                        {
                            return Sse4_1.blend_epi16(_xy, _z, 0b0011_0000);
                        }
    
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 12, 0);
                        v128 _w = Sse2.srl_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _zw = Sse4_1.blend_epi16(_z, _w, 0b1100_0000);
    
                        return Sse4_1.blend_epi16(_xy, _zw, 0b1111_0000);
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        v128 MASK = Sse2.cvtsi32_si128(byte.MaxValue);
    
                        v128 _x = Sse2.srl_epi32(a,                                    Sse2.and_si128(MASK, b));
                        v128 _y = Sse2.srl_epi32(Sse2.bsrli_si128(a, 1 * sizeof(int)), Sse2.and_si128(MASK, Sse2.bsrli_si128(b, 1 * sizeof(int))));
    
                        if (elements == 2)
                        {
                            return Sse2.unpacklo_epi32(_x, _y);
                        }
                        
                        v128 lo = Sse2.unpacklo_epi32(_x, _y);
                        v128 _z = Sse2.srl_epi32(Sse2.bsrli_si128(a, 2 * sizeof(int)), Sse2.and_si128(MASK, Sse2.bsrli_si128(b, 2 * sizeof(int))));
    
                        if (elements == 3)
                        {
                            return Sse2.unpacklo_epi64(lo, _z);
                        }
    
                        v128 _w = Sse2.srl_epi32(Sse2.bsrli_si128(a, 3 * sizeof(int)), Sse2.bsrli_si128(b, 3 * sizeof(int)));
    
                        v128 hi = Sse2.unpacklo_epi32(_z, _w);
    
                        return Sse2.unpacklo_epi64(lo, hi);
                    }
                    else throw new IllegalInstructionException();
                }
            }
    

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srlv_epi64(v128 a, v128 b)
            {
                if (constexpr.ALL_LE_EPI64(b, 0) || constexpr.ALL_GE_EPI64(b, 64))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return srli_epi64(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srlv_epi64(a, b);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = Sse2.srl_epi64(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                    v128 _y = Sse2.srl_epi64(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                    return Sse4_1.blend_epi16(_x, _y, 0b1111_0000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 MASK = Sse2.cvtsi32_si128(255);
    
                    v128 _x = Sse2.srl_epi64(a,                                      Sse2.and_si128(MASK, b));
                    v128 _y = Sse2.srl_epi64(Sse2.bsrli_si128(a, 1 * sizeof(ulong)), Sse2.bsrli_si128(b, sizeof(ulong)));
    
                    return Sse2.unpacklo_epi64(_x, _y);
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srav_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (constexpr.ALL_LE_EPI8(b, 0, elements) || constexpr.ALL_GE_EPI8(b, 8, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return srai_epi8(a, b.Byte0, elements);
                }
                
                if (Ssse3.IsSsse3Supported && Constant.IsConstantExpression(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                {
                    v128 LOOKUP = new v128((sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    return Ssse3.shuffle_epi8(LOOKUP, b);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 8)
                    {
                        v256 lo = Avx2.mm256_srav_epi32(Avx2.mm256_cvtepi8_epi32(a), Avx2.mm256_cvtepu8_epi32(b));
                        v256 hi = Avx2.mm256_srav_epi32(Avx2.mm256_cvtepi8_epi32(Sse2.bsrli_si128(a, 8 * sizeof(byte))), Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(b, 8 * sizeof(byte))));
    
                        v256 shorts = Avx2.mm256_packs_epi32(lo, hi);
                        v256 bytes = Avx2.mm256_packs_epi16(shorts, Avx.mm256_setzero_si256());
    
                        return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(bytes, Avx.mm256_castsi128_si256(new v128(0, 4, 1, 5))));
                    }
                    else if (elements > 4)
                    {
                        return mm256_cvtepi32_epi8(Avx2.mm256_srav_epi32(Avx2.mm256_cvtepi8_epi32(a), Avx2.mm256_cvtepu8_epi32(b)));
                    }
                    else
                    {
                        return cvtepi32_epi8(Avx2.srav_epi32(Sse4_1.cvtepi8_epi32(a), Sse4_1.cvtepu8_epi32(b)));
                    }
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result0 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.setzero_si128(), b));
                    a = srai_epi8(a, 1);
                    v128 result1 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(1), b));
                    a = srai_epi8(a, 1);
                    v128 result2 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(2), b));
                    a = srai_epi8(a, 1);
                    v128 result3 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(3), b));
                    a = srai_epi8(a, 1);
                    v128 result4 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(4), b));
                    a = srai_epi8(a, 1);
                    v128 result5 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(5), b));
                    a = srai_epi8(a, 1);
                    v128 result6 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(6), b));
                    a = srai_epi8(a, 1);
                    v128 result7 = Sse2.and_si128(a, Sse2.cmpeq_epi8(Sse2.set1_epi8(7), b));
    
                    v128 result01 = Sse2.or_si128(result0, result1);
                    v128 result23 = Sse2.or_si128(result2, result3);
                    v128 result45 = Sse2.or_si128(result4, result5);
                    v128 result67 = Sse2.or_si128(result6, result7);
    
                    return Sse2.or_si128(Sse2.or_si128(result01, result23), Sse2.or_si128(result45, result67));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_srav_epi8(v256 a, v256 b)
            {
                if (constexpr.ALL_LE_EPI8(b, 0) || constexpr.ALL_GE_EPI8(b, 8))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_srai_epi8(a, b.Byte0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (Constant.IsConstantExpression(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                    {
                        v256 LOOKUP = new v256((sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                               (sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);
                    
                        return Avx2.mm256_shuffle_epi8(LOOKUP, b);
                    }


                    v256 shortsLoA = mm256_cvt2x2epi8_epi16(a, out v256 shortsHiA);
                    v256 shortsLoB = mm256_cvt2x2epi8_epi16(b, out v256 shortsHiB);

                    v256 intsLoALo = mm256_cvt2x2epi16_epi32(shortsLoA, out v256 intsLoAHi);
                    v256 intsHiALo = mm256_cvt2x2epi16_epi32(shortsHiA, out v256 intsHiAHi);
                    v256 intsLoBLo = mm256_cvt2x2epi16_epi32(shortsLoB, out v256 intsLoBHi);
                    v256 intsHiBLo = mm256_cvt2x2epi16_epi32(shortsHiB, out v256 intsHiBHi);
    
                    intsLoALo = Avx2.mm256_srav_epi32(intsLoALo, intsLoBLo);
                    intsLoAHi = Avx2.mm256_srav_epi32(intsLoAHi, intsLoBHi);
                    intsHiALo = Avx2.mm256_srav_epi32(intsHiALo, intsHiBLo);
                    intsHiAHi = Avx2.mm256_srav_epi32(intsHiAHi, intsHiBHi);
                    
                    shortsLoA = Avx2.mm256_packs_epi32(intsLoALo, intsLoAHi);
                    shortsLoB = Avx2.mm256_packs_epi32(intsHiALo, intsHiAHi);
                    
                    return Avx2.mm256_packs_epi16(shortsLoA, shortsLoB);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srav_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (constexpr.ALL_LE_EPI16(b, 0, elements) || constexpr.ALL_GE_EPI16(b, 16, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return srai_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 a32Lo = cvt2x2epi16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epi16_epi32(b, out v128 b32Hi);

                        v128 lo = Avx2.srav_epi32(a32Lo, b32Lo);
                        v128 hi = Avx2.srav_epi32(a32Hi, b32Hi);

                        return Sse2.packs_epi32(lo, hi);
                    }
                    else
                    {
                        return cvtepi32_epi16(Avx2.srav_epi32(Sse4_1.cvtepi16_epi32(a), Sse4_1.cvtepu16_epi32(b)), elements);
                    }
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                     
                    v128 _x = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 2, 0);
                    v128 _y = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    v128 _xy = Sse4_1.blend_epi16(_x, _y, 0b0000_0010);
    
                    if (elements == 2)
                    {
                        return _xy;
                    }
                    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 4, 0);
                    v128 _z = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                    if (elements == 3)
                    {
                        return Sse4_1.blend_epi16(_xy, _z, 0b0000_0100);
                    }
                    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 6, 0);
                    v128 _w = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                    v128 _zw = Sse4_1.blend_epi16(_z, _w, 0b0000_1000);
                    
                    v128 result = Sse4_1.blend_epi16(_xy, _zw, 0b0000_1100);
    
                    if (elements == 4)
                    {
                        return result;
                    }
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                    v128 shift = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b0001_0000);
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 10, 0);
                    shift = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b0010_0000);
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 12, 0);
                    shift = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b0100_0000);
    
                    shuffleMask = Sse4_1.insert_epi8(shuffleMask, 14, 0);
                    shift = Sse2.sra_epi16(a, Ssse3.shuffle_epi8(b, shuffleMask));
                    result = Sse4_1.blend_epi16(result, shift, 0b1000_0000);
    
    
                    return result;
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 EPI16_MASK = new v128(15, 0, 0, 0);
    
                    v128 elementMask = new v128(ushort.MaxValue, 0, 0, 0);
    
                    v128 result0 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                    result0 = Sse2.and_si128(result0, elementMask);
                    elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                    b = Sse2.bsrli_si128(b, sizeof(short));
                    v128 result1 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                    result1 = Sse2.and_si128(result1, elementMask);
                    elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                    result0 = Sse2.or_si128(result0, result1);
    
                    if (elements > 2)
                    {
                        b = Sse2.bsrli_si128(b, sizeof(short));
                        result1 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                        result1 = Sse2.and_si128(result1, elementMask);
                        elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                        result0 = Sse2.or_si128(result0, result1);
    
                        if (elements > 3)
                        {
                            b = Sse2.bsrli_si128(b, sizeof(short));
                            result1 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                            result1 = Sse2.and_si128(result1, elementMask);
                            elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                            result0 = Sse2.or_si128(result0, result1);
                            
                            if (elements > 4)
                            {
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sra_epi16(a, Sse2.and_si128(b, EPI16_MASK));
                                result1 = Sse2.and_si128(result1, elementMask);
                                elementMask = Sse2.bslli_si128(elementMask, sizeof(short));
                                result0 = Sse2.or_si128(result0, result1);
                                b = Sse2.bsrli_si128(b, sizeof(short));
                                result1 = Sse2.sra_epi16(a, b);
                                result1 = Sse2.and_si128(result1, elementMask);
                                result0 = Sse2.or_si128(result0, result1);
                            }
                        }
                    }
    
                    return result0;
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_srav_epi16(v256 a, v256 b)
            {
                if (constexpr.ALL_LE_EPI16(b, 0) || constexpr.ALL_GE_EPI16(b, 16))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_srai_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    v256 aLo = mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                    v256 bLo = mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                    aLo = Avx2.mm256_srav_epi32(aLo, bLo);
                    aHi = Avx2.mm256_srav_epi32(aHi, bHi);
    
                    return Avx2.mm256_packs_epi32(aLo, aHi);
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srav_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (constexpr.ALL_LE_EPI32(b, 0, elements) || constexpr.ALL_GE_EPI32(b, 32, elements))
                {
                    return a;
                }
    
                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return srai_epi32(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srav_epi32(a, b);
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                        v128 _x = Sse2.sra_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 4, 0);
                        v128 _y = Sse2.sra_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _xy = Sse4_1.blend_epi16(_x, _y, 0b0000_1100);
    
                        if (elements == 2)
                        {
                            return _xy;
                        }
    
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 8, 0);
                        v128 _z = Sse2.sra_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
    
                        if (elements == 3)
                        {
                            return Sse4_1.blend_epi16(_xy, _z, 0b0011_0000);
                        }
    
                        shuffleMask = Sse4_1.insert_epi8(shuffleMask, 12, 0);
                        v128 _w = Sse2.sra_epi32(a, Ssse3.shuffle_epi8(b, shuffleMask));
                        v128 _zw = Sse4_1.blend_epi16(_z, _w, 0b1100_0000);
    
                        return Sse4_1.blend_epi16(_xy, _zw, 0b1111_0000);
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        v128 MASK = Sse2.cvtsi32_si128(byte.MaxValue);
    
                        v128 _x = Sse2.sra_epi32(a,                                    Sse2.and_si128(MASK, b));
                        v128 _y = Sse2.sra_epi32(Sse2.bsrli_si128(a, 1 * sizeof(int)), Sse2.and_si128(MASK, Sse2.bsrli_si128(b, 1 * sizeof(int))));
    
                        if (elements == 2)
                        {
                            return Sse2.unpacklo_epi32(_x, _y);
                        }
                        
                        v128 lo = Sse2.unpacklo_epi32(_x, _y);
                        v128 _z = Sse2.sra_epi32(Sse2.bsrli_si128(a, 2 * sizeof(int)), Sse2.and_si128(MASK, Sse2.bsrli_si128(b, 2 * sizeof(int))));
    
                        if (elements == 3)
                        {
                            return Sse2.unpacklo_epi64(lo, _z);
                        }
    
                        v128 _w = Sse2.sra_epi32(Sse2.bsrli_si128(a, 3 * sizeof(int)), Sse2.bsrli_si128(b, 3 * sizeof(int)));
    
                        v128 hi = Sse2.unpacklo_epi32(_z, _w);
    
                        return Sse2.unpacklo_epi64(lo, hi);
                    }
                    else throw new IllegalInstructionException();
                }
            }
    
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 srav_epi64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPI64(b, 0) || constexpr.ALL_GE_EPI64(b, 64))
                    {
                        return a;
                    }
                    if (constexpr.ALL_SAME_EPU64(b))
                    {
                        return srai_epi64(a, b.SInt0);
                    }
                    if (constexpr.ALL_GE_EPI64(a, 0))
                    {
                        return srlv_epi64(a, b);
                    }

                    if (Avx2.IsAvx2Supported)
                    {
                        if (constexpr.ALL_LT_EPI64(b, 32))
                        {
                            v128 shiftLo = Avx2.srlv_epi64(a, b);
                            v128 shiftHi = Avx2.srav_epi32(a, Sse2.shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0)));
    
                            return Avx2.blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                        }
                        else if (constexpr.ALL_GT_EPI64(b, 31))
                        {
                            v128 shiftHi = Sse2.srai_epi32(a, 31);
                            v128 shiftLo = Avx2.srav_epi32(Sse2.shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), Sse2.sub_epi64(b, Sse2.set1_epi64x(32)));
                        
                            return Avx2.blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                        } 
    
                        v128 sign = srai_epi64(a, 63);
                        v128 shiftedSign = Avx2.sllv_epi64(sign, Sse2.sub_epi64(new v128(64L), b));
    
                        return Sse2.or_si128(shiftedSign, Avx2.srlv_epi64(a, b));
                    }
                    else
                    {
                        return new v128(a.SLong0 >> b.SInt0, a.SLong1 >> b.SInt2);
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_srav_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI64(b, 0, elements) || constexpr.ALL_GE_EPI64(b, 64, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_SAME_EPU64(b))
                    {
                        return mm256_srai_epi64(a, b.SInt0);
                    }
                    
                    if (constexpr.ALL_GE_EPI64(a, 0, elements))
                    {
                        return Avx2.mm256_srlv_epi64(a, b);
                    }
                    if (constexpr.ALL_LT_EPI64(b, 32, elements))
                    {
                        v256 shiftLo = Avx2.mm256_srlv_epi64(a, b);
                        v256 shiftHi = Avx2.mm256_srav_epi32(a, Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0)));
                    
                        return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                    }
                    else if (constexpr.ALL_GT_EPI64(b, 31, elements))
                    {
                        v256 shiftHi = Avx2.mm256_srai_epi32(a, 31);
                        v256 shiftLo = Avx2.mm256_srav_epi32(Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), Avx2.mm256_sub_epi64(b, Avx.mm256_set1_epi64x(32)));
                        
                        return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                    }
    
                    v256 sign = mm256_srai_epi64(a, 63);
                    v256 shiftedSign = Avx2.mm256_sllv_epi64(sign, Avx2.mm256_sub_epi64(new v256(64L), b));
    
                    return Avx2.mm256_or_si256(shiftedSign, Avx2.mm256_srlv_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shl(byte2 x, byte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi8(x, n, 2);
            }
            else
            {
                return new byte2((byte)(x.x << n.x), (byte)(x.y << n.y));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shl(byte3 x, byte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi8(x, n, 3);
            }
            else
            {
                return new byte3((byte)(x.x << n.x), (byte)(x.y << n.y), (byte)(x.z << n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shl(byte4 x, byte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi8(x, n, 4);
            }
            else
            {
                return new byte4((byte)(x.x << n.x), (byte)(x.y << n.y), (byte)(x.z << n.z), (byte)(x.w << n.w));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 shl(byte8 x, byte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi8(x, n, 8);
            }
            else
            {
                return new byte8((byte)(x.x0 << n.x0), (byte)(x.x1 << n.x1), (byte)(x.x2 << n.x2), (byte)(x.x3 << n.x3), (byte)(x.x4 << n.x4), (byte)(x.x5 << n.x5), (byte)(x.x6 << n.x6), (byte)(x.x7 << n.x7));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 shl(byte16 x, byte16 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi8(x, n, 16);
            }
            else
            {
                return new byte16(shl(x.v8_0, n.v8_0), shl(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 shl(byte32 x, byte32 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sllv_epi8(x, n);
            }
            else
            {
                return new byte32(shl(x.v16_0, n.v16_0), shl(x.v16_16, n.v16_16));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shl(byte2 x, sbyte2 n)
        {
            return shl(x, (byte2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shl(byte3 x, sbyte3 n)
        {
            return shl(x, (byte3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shl(byte4 x, sbyte4 n)
        {
            return shl(x, (byte4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 shl(byte8 x, sbyte8 n)
        {
            return shl(x, (byte8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 shl(byte16 x, sbyte16 n)
        {
            return shl(x, (byte16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 shl(byte32 x, sbyte32 n)
        {
            return shl(x, (byte32)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shl(sbyte2 x, sbyte2 n)
        {
            return (sbyte2)shl((byte2)x, (byte2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shl(sbyte3 x, sbyte3 n)
        {
            return (sbyte3)shl((byte3)x, (byte3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shl(sbyte4 x, sbyte4 n)
        {
            return (sbyte4)shl((byte4)x, (byte4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 shl(sbyte8 x, sbyte8 n)
        {
            return (sbyte8)shl((byte8)x, (byte8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 shl(sbyte16 x, sbyte16 n)
        {
            return (sbyte16)shl((byte16)x, (byte16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 shl(sbyte32 x, sbyte32 n)
        {
            return (sbyte32)shl((byte32)x, (byte32)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shl(short2 x, short2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi16(x, n, 2);
            }
            else
            {
                return new short2((short)(x.x << n.x), (short)(x.y << n.y));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shl(short3 x, short3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi16(x, n, 3);
            }
            else
            {
                return new short3((short)(x.x << n.x), (short)(x.y << n.y), (short)(x.z << n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shl(short4 x, short4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi16(x, n, 4);
            }
            else
            {
                return new short4((short)(x.x << n.x), (short)(x.y << n.y), (short)(x.z << n.z), (short)(x.w << n.w));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 shl(short8 x, short8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi16(x, n, 8);
            }
            else
            {
                return new short8((short)(x.x0 << n.x0), (short)(x.x1 << n.x1), (short)(x.x2 << n.x2), (short)(x.x3 << n.x3), (short)(x.x4 << n.x4), (short)(x.x5 << n.x5), (short)(x.x6 << n.x6), (short)(x.x7 << n.x7));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 shl(short16 x, short16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sllv_epi16(x, n);
            }
            else
            {
                return new short16(shl(x.v8_0, n.v8_0), shl(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 shl(ushort2 x, ushort2 n)
        {
            return (ushort2)shl((short2)x, (short2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shl(ushort3 x, ushort3 n)
        {
            return (ushort3)shl((short3)x, (short3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shl(ushort4 x, ushort4 n)
        {
            return (ushort4)shl((short4)x, (short4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 shl(ushort8 x, ushort8 n)
        {
            return (ushort8)shl((short8)x, (short8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 shl(ushort16 x, ushort16 n)
        {
            return (ushort16)shl((short16)x, (short16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 shl(ushort2 x, short2 n)
        {
            return shl(x, (ushort2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shl(ushort3 x, short3 n)
        {
            return shl(x, (ushort3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shl(ushort4 x, short4 n)
        {
            return shl(x, (ushort4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 shl(ushort8 x, short8 n)
        {
            return shl(x, (ushort8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 shl(ushort16 x, short16 n)
        {
            return shl(x, (ushort16)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shl(int2 x, int2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.sllv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n)));
            }
            else
            {
                return new int2(x.x << n.x, x.y << n.y);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shl(int3 x, int3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.sllv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n)));
            }
            else
            {
                return new int3(x.x << n.x, x.y << n.y, x.z << n.z);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shl(int4 x, int4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.sllv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n)));
            }
            else
            {
                return new int4(x.x << n.x, x.y << n.y, x.z << n.z, x.w << n.w);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shl(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi32(x, n);
            }
            else
            {
                return new int8(shl(x.v4_0, n.v4_0), shl(x.v4_4, n.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shl(uint2 x, uint2 n)
        {
            return (uint2)shl((int2)x, (int2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shl(uint3 x, uint3 n)
        {
            return (uint3)shl((int3)x, (int3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shl(uint4 x, uint4 n)
        {
            return (uint4)shl((int4)x, (int4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shl(uint8 x, uint8 n)
        {
            return (uint8)shl((int8)x, (int8)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shl(uint2 x, int2 n)
        {
            return shl(x, (uint2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shl(uint3 x, int3 n)
        {
            return shl(x, (uint3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shl(uint4 x, int4 n)
        {
            return shl(x, (uint4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shl(uint8 x, int8 n)
        {
            return shl(x, (uint8)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shl(long2 x, long2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sllv_epi64(x, n);
            }
            else
            {
                return new long2(x.x << (int)n.x, x.y << (int)n.y);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shl(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi64(x, n);
            }
            else
            {
                return new long3(shl(x._xy, n._xy), (x.z << (int)n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shl(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sllv_epi64(x, n);
            }
            else
            {
                return new long4(shl(x._xy, n._xy), shl(x._zw, n._zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shl(ulong2 x, ulong2 n)
        {
            return (ulong2)shl((long2)x, (long2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shl(ulong3 x, ulong3 n)
        {
            return (ulong3)shl((long3)x, (long3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shl(ulong4 x, ulong4 n)
        {
            return (ulong4)shl((long4)x, (long4)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shl(ulong2 x, long2 n)
        {
            return shl(x, (ulong2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shl(ulong3 x, long3 n)
        {
            return shl(x, (ulong3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&lt;&lt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shl(ulong4 x, long4 n)
        {
            return shl(x, (ulong4)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shrl(sbyte2 x, sbyte2 n)
        {
            return (sbyte2)shrl((byte2)x, (byte2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shrl(sbyte3 x, sbyte3 n)
        {
            return (sbyte3)shrl((byte3)x, (byte3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the byteerval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shrl(sbyte4 x, sbyte4 n)
        {
            return (sbyte4)shrl((byte4)x, (byte4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the byteerval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 shrl(sbyte8 x, sbyte8 n)
        {
            return (sbyte8)shrl((byte8)x, (byte8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 shrl(sbyte16 x, sbyte16 n)
        {
            return (sbyte16)shrl((byte16)x, (byte16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 shrl(sbyte32 x, sbyte32 n)
        {
            return (sbyte32)shrl((byte32)x, (byte32)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shrl(byte2 x, byte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi8(x, n, 2);
            }
            else
            {
                return new byte2((byte)(x.x >> n.x), (byte)(x.y >> n.y));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shrl(byte3 x, byte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi8(x, n, 3);
            }
            else
            {
                return new byte3((byte)(x.x >> n.x), (byte)(x.y >> n.y), (byte)(x.z >> n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shrl(byte4 x, byte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi8(x, n, 4);
            }
            else
            {
                return new byte4((byte)(x.x >> n.x), (byte)(x.y >> n.y), (byte)(x.z >> n.z), (byte)(x.w >> n.w));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 shrl(byte8 x, byte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi8(x, n, 8);
            }
            else
            {
                return new byte8((byte)(x.x0 >> n.x0), (byte)(x.x1 >> n.x1), (byte)(x.x2 >> n.x2), (byte)(x.x3 >> n.x3), (byte)(x.x4 >> n.x4), (byte)(x.x5 >> n.x5), (byte)(x.x6 >> n.x6), (byte)(x.x7 >> n.x7));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 shrl(byte16 x, byte16 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi8(x, n, 16);
            }
            else
            {
                return new byte16(shrl(x.v8_0, n.v8_0), shrl(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 shrl(byte32 x, byte32 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srlv_epi8(x, n);
            }
            else
            {
                return new byte32(shrl(x.v16_0, n.v16_0), shrl(x.v16_16, n.v16_16));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shrl(byte2 x, sbyte2 n)
        {
            return shrl(x, (byte2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shrl(byte3 x, sbyte3 n)
        {
            return shrl(x, (byte3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shrl(byte4 x, sbyte4 n)
        {
            return shrl(x, (byte4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 shrl(byte8 x, sbyte8 n)
        {
            return shrl(x, (byte8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 shrl(byte16 x, sbyte16 n)
        {
            return shrl(x, (byte16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 shrl(byte32 x, sbyte32 n)
        {
            return shrl(x, (byte32)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shrl(short2 x, short2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi16(x, n, 2);
            }
            else
            {
                return new short2((short)((ushort)x.x >> n.x), (short)((ushort)x.y >> n.y));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shrl(short3 x, short3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi16(x, n, 3);
            }
            else
            {
                return new short3((short)((ushort)x.x >> n.x), (short)((ushort)x.y >> n.y), (short)((ushort)x.z >> n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shrl(short4 x, short4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi16(x, n, 4);
            }
            else
            {
                return new short4((short)((ushort)x.x >> n.x), (short)((ushort)x.y >> n.y), (short)((ushort)x.z >> n.z), (short)((ushort)x.w >> n.w));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 shrl(short8 x, short8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi16(x, n, 8);
            }
            else
            {
                return new short8((short)((ushort)x.x0 >> n.x0), (short)((ushort)x.x1 >> n.x1), (short)((ushort)x.x2 >> n.x2), (short)((ushort)x.x3 >> n.x3), (short)((ushort)x.x4 >> n.x4), (short)((ushort)x.x5 >> n.x5), (short)((ushort)x.x6 >> n.x6), (short)((ushort)x.x7 >> n.x7));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 shrl(short16 x, short16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srlv_epi16(x, n);
            }
            else
            {
                return new short16(shrl(x.v8_0, n.v8_0), shrl(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 shrl(ushort2 x, ushort2 n)
        {
            return (ushort2)shrl((short2)x, (short2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shrl(ushort3 x, ushort3 n)
        {
            return (ushort3)shrl((short3)x, (short3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shrl(ushort4 x, ushort4 n)
        {
            return (ushort4)shrl((short4)x, (short4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 shrl(ushort8 x, ushort8 n)
        {
            return (ushort8)shrl((short8)x, (short8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the uinterval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 shrl(ushort16 x, ushort16 n)
        {
            return (ushort16)shrl((short16)x, (short16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shrl(ushort3 x, short3 n)
        {
            return shrl(x, (ushort3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shrl(ushort4 x, short4 n)
        {
            return shrl(x, (ushort4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 shrl(ushort8 x, short8 n)
        {
            return shrl(x, (ushort8)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 shrl(ushort16 x, short16 n)
        {
            return shrl(x, (ushort16)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shrl(int2 x, int2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.srlv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n)));
            }
            else
            {
                return (int2)new uint2((uint)x.x >> n.x, (uint)x.y >> n.y);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shrl(int3 x, int3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.srlv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n)));
            }
            else
            {
                return (int3)new uint3((uint)x.x >> n.x, (uint)x.y >> n.y, (uint)x.z >> n.z);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shrl(int4 x, int4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.srlv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n)));
            }
            else
            {
                return (int4)new uint4((uint)x.x >> n.x, (uint)x.y >> n.y, (uint)x.z >> n.z, (uint)x.w >> n.w);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shrl(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi32(x, n);
            }
            else
            {
                return new int8(shrl(x.v4_0, n.v4_0), shrl(x.v4_4, n.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shrl(uint2 x, uint2 n)
        {
            return (uint2)shrl((int2)x, (int2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shrl(uint3 x, uint3 n)
        {
            return (uint3)shrl((int3)x, (int3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shrl(uint4 x, uint4 n)
        {
            return (uint4)shrl((int4)x, (int4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shrl(uint8 x, uint8 n)
        {
            return (uint8)shrl((int8)x, (int8)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shrl(uint2 x, int2 n)
        {
            return shrl(x, (uint2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shrl(uint3 x, int3 n)
        {
            return shrl(x, (uint3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shrl(uint4 x, int4 n)
        {
            return shrl(x, (uint4)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shrl(uint8 x, int8 n)
        {
            return shrl(x, (uint8)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shrl(long2 x, long2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srlv_epi64(x, n);
            }
            else
            {
                return (long2)new ulong2((ulong)x.x >> (int)n.x, (ulong)x.y >> (int)n.y);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shrl(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return new long3(shrl(x._xy, n._xy), (long)((ulong)x.z >> (int)n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shrl(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srlv_epi64(x, n);
            }
            else
            {
                return new long4(shrl(x._xy, n._xy), shrl(x._zw, n._zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shrl(ulong2 x, ulong2 n)
        {
            return (ulong2)shrl((long2)x, (long2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shrl(ulong3 x, ulong3 n)
        {
            return (ulong3)shrl((long3)x, (long3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shrl(ulong4 x, ulong4 n)
        {
            return (ulong4)shrl((long4)x, (long4)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shrl(ulong2 x, long2 n)
        {
            return shrl(x, (ulong2)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shrl(ulong3 x, long3 n)
        {
            return shrl(x, (ulong3)n);
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (unsigned) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shrl(ulong4 x, long4 n)
        {
            return shrl(x, (ulong4)n);
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shra(sbyte2 x, sbyte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi8(x, n, 2);
            }
            else
            {
                return new sbyte2((sbyte)(x.x >> n.x), (sbyte)(x.y >> n.y));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shra(sbyte3 x, sbyte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi8(x, n, 3);
            }
            else
            {
                return new sbyte3((sbyte)(x.x >> n.x), (sbyte)(x.y >> n.y), (sbyte)(x.z >> n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shra(sbyte4 x, sbyte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi8(x, n, 4);
            }
            else
            {
                return new sbyte4((sbyte)(x.x >> n.x), (sbyte)(x.y >> n.y), (sbyte)(x.z >> n.z), (sbyte)(x.w >> n.w));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 shra(sbyte8 x, sbyte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi8(x, n, 8);
            }
            else
            {
                return new sbyte8((sbyte)(x.x0 >> n.x0), (sbyte)(x.x1 >> n.x1), (sbyte)(x.x2 >> n.x2), (sbyte)(x.x3 >> n.x3), (sbyte)(x.x4 >> n.x4), (sbyte)(x.x5 >> n.x5), (sbyte)(x.x6 >> n.x6), (sbyte)(x.x7 >> n.x7));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 shra(sbyte16 x, sbyte16 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi8(x, n, 16);
            }
            else
            {
                return new sbyte16(shra(x.v8_0, n.v8_0), shra(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 7] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 shra(sbyte32 x, sbyte32 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srav_epi8(x, n);
            }
            else
            {
                return new sbyte32(shra(x.v16_0, n.v16_0), shra(x.v16_16, n.v16_16));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shra(short2 x, short2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi16(x, n, 2);
            }
            else
            {
                return new short2((short)(x.x >> n.x), (short)(x.y >> n.y));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shra(short3 x, short3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi16(x, n, 3);
            }
            else
            {
                return new short3((short)(x.x >> n.x), (short)(x.y >> n.y), (short)(x.z >> n.z));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shra(short4 x, short4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi16(x, n, 4);
            }
            else
            {
                return new short4((short)(x.x >> n.x), (short)(x.y >> n.y), (short)(x.z >> n.z), (short)(x.w >> n.w));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 shra(short8 x, short8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi16(x, n, 8);
            }
            else
            {
                return new short8((short)(x.x0 >> n.x0), (short)(x.x1 >> n.x1), (short)(x.x2 >> n.x2), (short)(x.x3 >> n.x3), (short)(x.x4 >> n.x4), (short)(x.x5 >> n.x5), (short)(x.x6 >> n.x6), (short)(x.x7 >> n.x7));
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 15] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 shra(short16 x, short16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srav_epi16(x, n);
            }
            else
            {
                return new short16(shra(x.v8_0, n.v8_0), shra(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shra(int2 x, int2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.srav_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2));
            }
            else
            {
                return new int2(x.x >> n.x, x.y >> n.y);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shra(int3 x, int3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.srav_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3));
            }
            else
            {
                return new int3(x.x >> n.x, x.y >> n.y, x.z >> n.z);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shra(int4 x, int4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.srav_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4));
            }
            else
            {
                return new int4(x.x >> n.x, x.y >> n.y, x.z >> n.z, x.w >> n.w);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 31] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shra(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srav_epi32(x, n);
            }
            else
            {
                return new int8(shra(x.v4_0, n.v4_0), shra(x.v4_4, n.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shra(long2 x, long2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srav_epi64(x, n);
            }
            else
            {
                return new long2(x.x >> (int)n.x, x.y >> (int)n.y);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shra(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srav_epi64(x, n, 3);
            }
            else
            {
                return new long3(shra(x.xy, n.xy), x.z >> (int)n.z);
            }
        }

        /// <summary>       Returns <paramref name="x"/> <see langword="&gt;&gt;" /> <paramref name="n"/> (signed) for each corresponding component. Shifting by a value outside of the interval [0, 63] is undefined behavior.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shra(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srav_epi64(x, n, 4);
            }
            else
            {
                return new long4(shra(x.xy, n.xy), shra(x.zw, n.zw));
            }
        }
    }
}