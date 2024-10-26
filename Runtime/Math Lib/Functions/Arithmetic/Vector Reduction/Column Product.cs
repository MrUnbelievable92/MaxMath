using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using UnityEngine.AI;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epu8(v128 a, bool promise = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ANY_EQ_EPI8(a, 0, elements))
                    {
                        return setzero_si128();
                    }

                    switch (elements)
                    {
                        case 16:
                        {
                            if (promise)
                            {
                                v128 castLo = cvt2x2epu8_epi16(a, out v128 castHi);

                                return vprod_epu16(mullo_epi16(castLo, castHi), true, 8);
                            }
                            else
                            {
                                v128 castLo16 = cvt2x2epu8_epi16(a, out v128 castHi16);
                                v128 prod16 = mullo_epi16(castLo16, castHi16);
                                v128 castLo = cvt2x2epu16_epi32(prod16, out v128 castHi);

                                if (Architecture.IsMul32Supported)
                                {
                                    return vprod_epu32(mullo_epi32(castLo, castHi), true, 4);
                                }
                                else
                                {
                                    v128 even = mul_epu32(castLo, castHi);
                                    v128 odd  = mul_epu32(bsrli_si128(castLo, sizeof(int)), bsrli_si128(castHi, sizeof(int)));

                                    v128 prod32 = mul_epu32(even, odd);
                                    prod32 = mul_epu32(prod32, bsrli_si128(prod32, 1 * sizeof(long)));

                                    return prod32;
                                }
                            }
                        }
                        case 8:
                        {
                            if (promise)
                            {
                                v128 castLo = cvtepu8_epi16(a);
                                v128 castHi;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(4, -1,    5, -1,    6, -1,    7, -1,    -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castHi = bsrli_si128(castLo, 4 * sizeof(short));
                                }

                                return vprod_epu16(mullo_epi16(castLo, castHi), true, 4);
                            }
                            else
                            {
                                v128 castLo = cvtepu8_epi32(a);
                                v128 castHi;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1));
                                }
                                else
                                {
                                    castHi = cvtepu8_epi32(bsrli_si128(a, 4 * sizeof(byte)));
                                }

                                if (Architecture.IsMul32Supported)
                                {
                                    return vprod_epu32(mullo_epi32(castLo, castHi), true, 4);
                                }
                                else
                                {
                                    v128 even = mul_epu32(castLo, castHi);
                                    v128 odd  = mul_epu32(bsrli_si128(castLo, sizeof(int)), bsrli_si128(castHi, sizeof(int)));

                                    v128 prod32 = mul_epu32(even, odd);
                                    prod32 = mul_epu32(prod32, bsrli_si128(prod32, 1 * sizeof(long)));

                                    return prod32;
                                }
                            }
                        }
                        case 4:
                        {
                            if (promise)
                            {
                                v128 castLo = cvtepu8_epi16(a);
                                v128 castHi;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(2, -1,    3, -1,     -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castHi = bsrli_si128(castLo, 2 * sizeof(short));
                                }

                                return vprod_epu16(mullo_epi16(castLo, castHi), true, 2);
                            }
                            else
                            {
                                v128 castXY = cvtepu8_epi32(a);
                                v128 castZW;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castZW = shuffle_epi8(a, new v128(1, -1, -1, -1,    -1, -1, -1, -1,    3, -1, -1, -1,    -1, -1, -1, -1));
                                }
                                else
                                {
                                    castZW = bsrli_si128(castXY, 1 * sizeof(int));
                                }

                                castXY = mul_epu32(castXY, castZW);

                                v128 result = mul_epu32(castXY, bsrli_si128(castXY, 1 * sizeof(long)));
                                constexpr.ASSUME_LE_EPU32(result, 255u * 255 * 255 * 255);
                                return result;
                            }
                        }
                        case 3:
                        {
                            if (promise)
                            {
                                v128 castLo = cvtepu8_epi16(a);
                                v128 castHi;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(1, -1,    2, -1,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castHi = bsrli_si128(castLo, 1 * sizeof(short));
                                }

                                castLo = mullo_epi16(castLo, castHi);
                                castHi = bsrli_si128(castHi, 1 * sizeof(short));

                                return mullo_epi16(castLo, castHi);
                            }
                            else
                            {
                                v128 castX = cvtepu8_epi32(a);
                                v128 castYZ;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castYZ = shuffle_epi8(a, new v128(1, -1, -1, -1,    2, -1, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castYZ = bsrli_si128(castX, 1 * sizeof(int));
                                }

                                castX = mul_epu32(castX, castYZ);

                                v128 result = mul_epu32(castX, bsrli_si128(castYZ, 1 * sizeof(int)));
                                constexpr.ASSUME_LE_EPU32(result, 255u * 255 * 255);
                                return result;
                            }
                        }
                        case 2:
                        {
                            if (promise)
                            {
                                return mullo_epi16(a, bsrli_si128(a, 1 * sizeof(byte)));
                            }
                            else
                            {
                                v128 castLo = cvtepu8_epi16(a);
                                v128 castHi;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(1, -1,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castHi = bsrli_si128(castLo, 1 * sizeof(short));
                                }

                                return mullo_epi16(castLo, castHi);
                            }
                        }
                        default:
                        {
                            return a;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epu8(v256 a, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ANY_EQ_EPI8(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (promise)
                    {
                        v256 castLo = mm256_cvt2x2epu8_epi16(a, out v256 castHi);

                        return mm256_vprod_epu16(Avx2.mm256_mullo_epi16(castLo, castHi), true);
                    }
                    else
                    {
                        v256 castLo16 = mm256_cvt2x2epu8_epi16(a, out v256 castHi16);
                        v256 prod16 = Avx2.mm256_mullo_epi16(castLo16, castHi16);
                        v256 castLo = mm256_cvt2x2epu16_epi32(prod16, out v256 castHi);

                        return mm256_vprod_epu32(Avx2.mm256_mullo_epi32(castLo, castHi), true);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epi8(v128 a, bool promise = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ANY_EQ_EPI8(a, 0, elements))
                    {
                        return setzero_si128();
                    }

                    switch (elements)
                    {
                        case 16:
                        {
                            if (promise)
                            {
                                v128 castLo = cvt2x2epi8_epi16(a, out v128 castHi);

                                return vprod_epu16(mullo_epi16(castLo, castHi), true, 8);
                            }
                            else
                            {
                                v128 castLo16 = cvt2x2epi8_epi16(a, out v128 castHi16);
                                v128 prod16 = mullo_epi16(castLo16, castHi16);
                                v128 castLo = cvt2x2epi16_epi32(prod16, out v128 castHi);

                                if (Architecture.IsMul32Supported)
                                {
                                    return vprod_epu32(mullo_epi32(castLo, castHi), true, 4);
                                }
                                else
                                {
                                    v128 even = mul_epu32(castLo, castHi);
                                    v128 odd  = mul_epu32(bsrli_si128(castLo, sizeof(int)), bsrli_si128(castHi, sizeof(int)));

                                    v128 prod32 = mul_epu32(even, odd);
                                    prod32 = mul_epu32(prod32, bsrli_si128(prod32, 1 * sizeof(long)));

                                    return prod32;
                                }
                            }
                        }
                        case 8:
                        {
                            if (promise)
                            {
                                return vprod_epu16(cvtepi8_epi16(a), true, 8);
                            }
                            else
                            {
                                v128 castLo = cvtepi8_epi32(a);
                                v128 castHi = cvtepi8_epi32(bsrli_si128(a, 4 * sizeof(byte)));

                                if (Architecture.IsMul32Supported)
                                {
                                    return vprod_epu32(mullo_epi32(castLo, castHi), true, 4);
                                }
                                else
                                {
                                    v128 even = mul_epu32(castLo, castHi);
                                    v128 odd  = mul_epu32(bsrli_si128(castLo, sizeof(int)), bsrli_si128(castHi, sizeof(int)));

                                    v128 prod32 = mul_epu32(even, odd);
                                    prod32 = mul_epu32(prod32, bsrli_si128(prod32, 1 * sizeof(long)));

                                    return prod32;
                                }
                            }
                        }
                        case 4:
                        case 3:
                        {
                            if (promise)
                            {
                                return vprod_epu16(cvtepi8_epi16(a), true, elements);
                            }
                            else
                            {
                                v128 result = vprod_epu32(cvtepi8_epi32(a), true, elements);
                                if (elements == 4)
                                {
                                    constexpr.ASSUME_RANGE_EPI32(result, -127 * 128 * 128 * 128,    128 * 128 * 128 * 128);
                                }
                                else
                                {
                                    constexpr.ASSUME_RANGE_EPI32(result, -128 * 128 * 128,    127 * 128 * 128);
                                }
                                
                                return result;
                            }
                        }
                        case 2:
                        {
                            if (promise)
                            {
                                return mullo_epi16(a, bsrli_si128(a, 1 * sizeof(byte)));
                            }
                            else
                            {
                                v128 result = vprod_epu16(cvtepi8_epi16(a), true, 2);
                                constexpr.ASSUME_RANGE_EPI16(result, -127 * 128,    128 * 128);
                                return result;
                            }
                        }
                        default:
                        {
                            return a;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epi8(v256 a, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ANY_EQ_EPI8(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (promise)
                    {
                        v256 castLo = mm256_cvt2x2epi8_epi16(a, out v256 castHi);

                        return mm256_vprod_epu16(Avx2.mm256_mullo_epi16(castLo, castHi), true);
                    }
                    else
                    {
                        v256 castLo16 = mm256_cvt2x2epi8_epi16(a, out v256 castHi16);
                        v256 prod16 = Avx2.mm256_mullo_epi16(castLo16, castHi16);
                        v256 castLo = mm256_cvt2x2epi16_epi32(prod16, out v256 castHi);

                        return mm256_vprod_epu32(Avx2.mm256_mullo_epi32(castLo, castHi), true);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epu16(v128 a, bool promise = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ANY_EQ_EPI16(a, 0, elements))
                    {
                        return setzero_si128();
                    }

                    switch (elements)
                    {
                        case 8:
                        {
                            if (promise)
                            {
                                a = mullo_epi16(a, bsrli_si128(a, 4 * sizeof(short)));

                                goto case 4;
                            }
                            else
                            {
                                v128 castLo = cvt2x2epu16_epi32(a, out v128 castHi);

                                return vprod_epu32(mullo_epi32(castLo, castHi, 4), true, 4);
                            }
                        }
                        case 4:
                        {
                            if (promise)
                            {
                                a = mullo_epi16(a, shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 3, 2)));

                                goto case 2;
                            }
                            else
                            {
                                v128 castLo = cvtepu16_epi32(a);
                                v128 castHi;

                                if (Architecture.IsMul32Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(4, 5, -1, -1,    6, 7, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1));

                                    return vprod_epu32(mullo_epi32(castLo, castHi), true, 2);
                                }
                                else
                                {
                                    if (Ssse3.IsSsse3Supported)
                                    {
                                        castHi = shuffle_epi8(a, new v128(2, 3, -1, -1,    -1, -1, -1, -1,    6, 7, -1, -1,    -1, -1, -1, -1));
                                    }
                                    else
                                    {
                                        castHi = bsrli_si128(castLo, 1 * sizeof(int));
                                    }

                                    return vprod_epi64(mul_epu32(castLo, castHi));
                                }
                            }
                        }
                        case 3:
                        {
                            if (promise)
                            {
                                v128 y = bsrli_si128(a, 1 * sizeof(short));
                                v128 z = bsrli_si128(a, 2 * sizeof(short));

                                return mullo_epi16(mullo_epi16(a, y), z);
                            }
                            else
                            {
                                v128 castX = cvtepu16_epi32(a);
                                v128 castYZ;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castYZ = shuffle_epi8(a, new v128(2, 3, -1, -1,    4, 5, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castYZ = bsrli_si128(castX, 1 * sizeof(int));
                                }

                                return mul_epu32(mul_epu32(castX, castYZ), bsrli_si128(castYZ, 1 * sizeof(int)));
                            }
                        }
                        case 2:
                        {
                            if (promise)
                            {
                                return mullo_epi16(a, bsrli_si128(a, 1 * sizeof(short)));
                            }
                            else
                            {
                                v128 castLo = cvtepu16_epi32(a);
                                v128 castHi;

                                if (Ssse3.IsSsse3Supported)
                                {
                                    castHi = shuffle_epi8(a, new v128(2, 3, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                                }
                                else
                                {
                                    castHi = bsrli_si128(castLo, 1 * sizeof(int));
                                }

                                return mul_epu32(castLo, castHi);
                            }
                        }
                        default:
                        {
                            return a;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epu16(v256 a, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ANY_EQ_EPI16(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (promise)
                    {
                        a = Avx2.mm256_mullo_epi16(a, Avx2.mm256_bsrli_epi128(a, 4 * sizeof(short)));
                        a = Avx2.mm256_mullo_epi16(a, Avx2.mm256_shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 3, 2)));
                        a = Avx2.mm256_mullo_epi16(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(short)));

                        return a;
                    }
                    else
                    {
                        v256 castLo = mm256_cvt2x2epu16_epi32(a, out v256 castHi);

                        return mm256_vprod_epu32(Avx2.mm256_mullo_epi32(castLo, castHi), true);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epi16(v128 a, bool promise = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ANY_EQ_EPI16(a, 0, elements))
                    {
                        return setzero_si128();
                    }

                    if (promise)
                    {
                        return vprod_epu16(a, true, elements);
                    }
                    else
                    {
                        if (elements == 8)
                        {
                            v128 castLo = cvt2x2epi16_epi32(a, out v128 castHi);

                            return vprod_epu32(mullo_epi32(castLo, castHi, 4), true, 4);
                        }
                        else
                        {
                            v128 result = vprod_epu32(cvtepi16_epi32(a), true, elements);

                            if (elements == 2)
                            {
                                constexpr.ASSUME_RANGE_EPI32(result, -32768 * 32767,    32768 * 32768);
                            }

                            return result;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epi16(v256 a, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ANY_EQ_EPI16(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (promise)
                    {
                        return mm256_vprod_epu16(a, true);
                    }
                    else
                    {
                        v256 castLo = mm256_cvt2x2epi16_epi32(a, out v256 castHi);

                        return mm256_vprod_epu32(Avx2.mm256_mullo_epi32(castLo, castHi), true);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epu32(v128 a, bool promise = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ANY_EQ_EPI32(a, 0, elements))
                    {
                        return setzero_si128();
                    }

                    switch (elements)
                    {
                        case 4:
                        {
                            a = mul_epu32(a, bsrli_si128(a, 1 * sizeof(int)));

                            if (promise)
                            {
                                return mul_epu32(a, bsrli_si128(a, 1 * sizeof(long)));
                            }
                            else
                            {
                                return vprod_epi64(a);
                            }
                        }
                        case 3:
                        {
                            v128 y = srli_epi64(a, 8 * sizeof(int));

                            if (promise)
                            {
                                v128 z = bsrli_si128(a, 2 * sizeof(int));

                                return mul_epu32(mul_epu32(a, y), z);
                            }
                            else
                            {
                                v128 z = bslli_si128(a, 1 * sizeof(int));
                                z = bsrli_si128(a, 3 * sizeof(int));

                                return mullo_epi64(mul_epu32(a, y), z);
                            }
                        }
                        case 2:
                        {
                            return mul_epu32(a, bsrli_si128(a, 1 * sizeof(int)));
                        }
                        default:
                        {
                            return a;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epu32(v256 a, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ANY_EQ_EPI32(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (promise)
                    {
                        a = Avx2.mm256_mullo_epi32(a, Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(0, 0, 3, 2)));
                        a = Avx2.mm256_mullo_epi32(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(int)));

                        return a;
                    }
                    else
                    {
                        v256 castLo = mm256_cvt2x2epu32_epi64(a, out v256 castHi);

                        return mm256_vprod_epi64(Avx2.mm256_mul_epu32(castLo, castHi), 4);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epi32(v128 a, bool promise = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return vprod_epu32(a, promise, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epi32(v256 a, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ANY_EQ_EPI32(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (promise)
                    {
                        a = Avx2.mm256_mullo_epi32(a, Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(0, 0, 3, 2)));
                        a = Avx2.mm256_mullo_epi32(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(int)));

                        return a;
                    }
                    else
                    {
                        v256 castLo = mm256_cvt2x2epi32_epi64(a, out v256 castHi);

                        return mm256_vprod_epi64(mm256_mullo_epi64(castLo, castHi, 4), 4);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vprod_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ANY_EQ_EPI64(a, 0))
                    {
                        return setzero_si128();
                    }

                    return mullo_epi64(a, bsrli_si128(a, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vprod_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ANY_EQ_EPI64(a, 0, elements))
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    if (elements == 4)
                    {
                        return mm256_mullo_epi64(a, Avx2.mm256_bsrli_epi128(a, 1 * sizeof(long)), elements);
                    }
                    else
                    {
                        v128 prodLo = mullo_epi64(Avx.mm256_castsi256_si128(a), bsrli_si128(Avx.mm256_castsi256_si128(a), 1 * sizeof(long)));

                        return Avx2.mm256_inserti128_si256(a, prodLo, 0);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal product of components of a <see cref="float2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float2 c)
        {
            return (c * c.yx).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="float3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float3 c)
        {
            return ((c * c.yyy) * c.zzz).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float4 c)
        {
            c *= c.wzyx;
            c *= c.yyyy;

            return c.x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cprod(float8 c)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Xse.mul_ps(Avx.mm256_castps256_ps128(c),
                                         Avx.mm256_extractf128_ps(c, 1));

                result = Xse.mul_ps(result, Xse.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

                return Xse.mul_ss(result, Xse.shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 3, 2))).Float0;
            }
            else
            {
                return cprod(c.v4_0 * c.v4_4);
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="double2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double2 c)
        {
            return (c * c.yx).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="double3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double3 c)
        {
            return ((c * c.yyy) * c.zzz).x;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cprod(double4 c)
        {
            c *= c.wzyx;
            c *= c.yyyy;

            return c.x;
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces an 8-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu8(c, true, 2).Byte0;
                }
                else
                {
                    return Xse.vprod_epu8(c, false, 2).UShort0;
                }
            }
            else
            {
                return (uint)c.x * (uint)c.y;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 255ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu8(c, true, 3).UShort0;
                }
                else
                {
                    return Xse.vprod_epu8(c, false, 3).UInt0;
                }
            }
            else
            {
                return ((uint)c.x * (uint)c.y) * (uint)c.z;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.     </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 255ul * 255ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu8(c, true, 4).UShort0;
                }
                else
                {
                    return Xse.vprod_epu8(c, false, 4).UInt0;
                }
            }
            else
            {
                return ((uint)c.x * (uint)c.y) * (uint)c.z * (uint)c.w;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu8(c, true, 8).UShort0;
                }
                else
                {
                    return Xse.vprod_epu8(c, false, 8).UInt0;
                }
            }
            else
            {
                return (((uint)c.x0 * (uint)c.x1) * ((uint)c.x2 * (uint)c.x3)) * (((uint)c.x4 * (uint)c.x5) * ((uint)c.x6 * (uint)c.x7));
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu8(c, true, 16).UShort0;
                }
                else
                {
                    return Xse.vprod_epu8(c, false, 16).UInt0;
                }
            }
            else
            {
                return (((uint)c.x0 * (uint)c.x1) * ((uint)c.x2 * (uint)c.x3)) * (((uint)c.x4 * (uint)c.x5) * ((uint)c.x6 * (uint)c.x7)) * (((uint)c.x8 * (uint)c.x9) * ((uint)c.x10 * (uint)c.x11)) * (((uint)c.x12 * (uint)c.x13) * ((uint)c.x14 * (uint)c.x15));
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.byte32"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(byte32 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 result = Xse.mm256_vprod_epu8(c, true);

                    return Xse.mullo_epi16(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UShort0;
                }
                else
                {
                    v256 result = Xse.mm256_vprod_epu8(c, false);

                    return Xse.mullo_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UInt0;
                }
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return cprod(c.v16_0 * c.v16_16, noOverflow);
                }
                else
                {
                    return cprod(c.v16_0, noOverflow) * cprod(c.v16_16, noOverflow);
                }
            }
        }


        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces an 8-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-127 * 128,    128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi8(c, true, 2).SByte0;
                }
                else
                {
                    return Xse.vprod_epi8(c, false, 2).SShort0;
                }
            }
            else
            {
                return c.x * c.y;
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-128 * 128 * 128,    127 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi8(c, true, 3).SShort0;
                }
                else
                {
                    return Xse.vprod_epi8(c, false, 3).SInt0;
                }
            }
            else
            {
                return (c.x * c.y) * c.z;
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-127 * 128 * 128 * 128,    128 * 128 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi8(c, true, 4).SShort0;
                }
                else
                {
                    return Xse.vprod_epi8(c, false, 4).SInt0;
                }
            }
            else
            {
                return (c.x * c.y) * (c.z * c.w);
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi8(c, true, 8).SShort0;
                }
                else
                {
                    return Xse.vprod_epi8(c, false, 8).SInt0;
                }
            }
            else
            {
                return ((c.x0 * c.x1) * (c.x2 * c.x3)) * ((c.x4 * c.x5) * (c.x6 * c.x7));
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi8(c, true, 16).SShort0;
                }
                else
                {
                    return Xse.vprod_epi8(c, false, 16).SInt0;
                }
            }
            else
            {
                return ((c.x0 * c.x1) * (c.x2 * c.x3)) * ((c.x4 * c.x5) * (c.x6 * c.x7)) * ((c.x8 * c.x9) * (c.x10 * c.x11)) * ((c.x12 * c.x13) * (c.x14 * c.x15));
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.sbyte32"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(sbyte32 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 result = Xse.mm256_vprod_epi8(c, true);

                    return Xse.mullo_epi16(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SShort0;
                }
                else
                {
                    v256 result = Xse.mm256_vprod_epi8(c, false);

                    return Xse.mullo_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SInt0;
                }
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return cprod(c.v16_0 * c.v16_16, noOverflow);
                }
                else
                {
                    return cprod(c.v16_0, noOverflow) * cprod(c.v16_16, noOverflow);
                }
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow.        </para>    
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-32768L * 32767L,    32768L * 32768L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi16(c, true, 2).SShort0;
                }
                else
                {
                    return Xse.vprod_epi16(c, false, 2).SInt0;
                }
            }
            else
            {
                return c.x * c.y;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi16(c, true, 3).SShort0;
                }
                else
                {
                    return Xse.vprod_epi16(c, false, 3).SInt0;
                }
            }
            else
            {
                return (c.x * c.y) * c.z;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short4"/>.
        /// <remarks>        
        ///     <para>     A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi16(c, true, 4).SShort0;
                }
                else
                {
                    return Xse.vprod_epi16(c, false, 4).SInt0;
                }
            }
            else
            {
                return (c.x * c.y) * (c.z * c.w);
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>    
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epi16(c, true, 8).SShort0;
                }
                else
                {
                    return Xse.vprod_epi16(c, false, 8).SInt0;
                }
            }
            else
            {
                return ((c.x0 * c.x1) * (c.x2 * c.x3)) * ((c.x4 * c.x5) * (c.x6 * c.x7));
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.short16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>     
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(short16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 result = Xse.mm256_vprod_epi16(c, true);

                    return Xse.mullo_epi16(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SShort0;
                }
                else
                {
                    v256 result = Xse.mm256_vprod_epi16(c, false);

                    return Xse.mullo_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SInt0;
                }
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return cprod(c.v8_0 * c.v8_8, noOverflow);
                }
                else
                {
                    return cprod(c.v8_0, noOverflow) * cprod(c.v8_8, noOverflow);
                }
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow.       </para>   
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul,    65535ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu16(c, true, 2).UShort0;
                }
                else
                {
                    return Xse.vprod_epu16(c, false, 2).UInt0;
                }
            }
            else
            {
                return (uint)c.x * (uint)c.y;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para> 
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu16(c, true, 3).UShort0;
                }
                else
                {
                    return Xse.vprod_epu16(c, false, 3).UInt0;
                }
            }
            else
            {
                return ((uint)c.x * (uint)c.y) * (uint)c.z;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para> 
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu16(c, true, 4).UShort0;
                }
                else
                {
                    return Xse.vprod_epu16(c, false, 4).UInt0;
                }
            }
            else
            {
                return ((uint)c.x * (uint)c.y) * ((uint)c.z * (uint)c.w);
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vprod_epu16(c, true, 8).UShort0;
                }
                else
                {
                    return Xse.vprod_epu16(c, false, 8).UInt0;
                }
            }
            else
            {
                return (((uint)c.x0 * (uint)c.x1) * ((uint)c.x2 * (uint)c.x3)) * (((uint)c.x4 * (uint)c.x5) * ((uint)c.x6 * (uint)c.x7));
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ushort16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column product of <paramref name="c"/> that produces a 16-bit overflow. It is only recommended to use this overload if each possible multiplication order of elements in <paramref name="c"/> is guaranteed not to produce a 16-bit overflow.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(ushort16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 result = Xse.mm256_vprod_epu16(c, true);

                    return Xse.mullo_epi16(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UShort0;
                }
                else
                {
                    v256 result = Xse.mm256_vprod_epu16(c, false);

                    return Xse.mullo_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UInt0;
                }
            }
            else
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return cprod(c.v8_0 * c.v8_8, noOverflow);
                }
                else
                {
                    return cprod(c.v8_0, noOverflow) * cprod(c.v8_8, noOverflow);
                }
            }
        }


        /// <summary>       Returns the horizontal product of components of an <see cref="int2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vprod_epi32(RegisterConversion.ToV128(c), true, 2).SInt0;
            }
            else
            {
                return c.x * c.y;
            }

        }

        /// <summary>       Returns the horizontal product of components of an <see cref="int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vprod_epi32(RegisterConversion.ToV128(c), true, 3).SInt0;
            }
            else
            {
                return (c.x * c.y) * c.z;
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vprod_epi32(RegisterConversion.ToV128(c), true, 4).SInt0;
            }
            else
            {
                return (c.x * c.y) * (c.z * c.w);
            }
        }

        /// <summary>       Returns the horizontal product of components of an <see cref="MaxMath.int8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cprod(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Xse.mm256_vprod_epi32(c, true);

                return Xse.mullo_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SInt0;
            }
            else
            {
                return cprod(c.v4_0 * c.v4_4);
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="uint2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vprod_epu32(RegisterConversion.ToV128(c), true, 2).UInt0;
            }
            else
            {
                return c.x * c.y;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint3 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vprod_epu32(RegisterConversion.ToV128(c), true, 3).UInt0;
            }
            else
            {
                return (c.x * c.y) * c.z;
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint4 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vprod_epu32(RegisterConversion.ToV128(c), true, 4).UInt0;
            }
            else
            {
                return (c.x * c.y) * (c.z * c.w);
            }
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.uint8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cprod(uint8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Xse.mm256_vprod_epu32(c, true);

                return Xse.mullo_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UInt0;
            }
            else
            {
                return cprod(c.v4_0 * c.v4_4);
            }
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long2 c)
        {
            return c.x * c.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long3 c)
        {
            return (c.x * c.y) * c.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cprod(long4 c)
        {
            return (c.x * c.y) * (c.z * c.w);
        }


        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong2 c)
        {
            return c.x * c.y;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong3 c)
        {
            return (c.x * c.y) * c.z;
        }

        /// <summary>       Returns the horizontal product of components of a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cprod(ulong4 c)
        {
            return (c.x * c.y) * (c.z * c.w);
        }
    }
}