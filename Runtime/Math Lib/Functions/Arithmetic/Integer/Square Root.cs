//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;
using DevTools;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_sqrthi4correction_epi8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
VectorAssert.IsNotSmaller<sbyte16, sbyte>(a, 0, elements);
constexpr.ASSUME_GE_EPI8(a, 0, elements);
                    
                    v128 hi4 = srli_epi8(a, 4);
                    
                    v128 r0 = shuffle_epi8(new v128(  0,    4,   4,   4,    8,   8,   8,   8,   8,   12,  12,  12,  12,  12,  12,  12), hi4);
                    v128 T1 = shuffle_epi8(new v128(0x80,0x98,0x98,0x98, 0xD0,0xD0,0xD0,0xD0,0xD0, 0x28,0x28,0x28,0x28,0x28,0x28,0x28), hi4);
                    v128 T2 = shuffle_epi8(new v128(0x83,0xA3,0xA3,0xA3, 0xE3,0xE3,0xE3,0xE3,0xE3, 0x43,0x43,0x43,0x43,0x43,0x43,0x43), hi4);
                    v128 T3 = shuffle_epi8(new v128(0x88,0xB0,0xB0,0xB0, 0xF8,0xF8,0xF8,0xF8,0xF8, 0x60,0x60,0x60,0x60,0x60,0x60,0x60), hi4);
                    
                    v128 ucmpa = xor_si128(a, set1_epi8(1 << 7));
                    v128 cmp1 = cmpgt_epi8(ucmpa, T1);
                    v128 cmp2 = cmpgt_epi8(ucmpa, T2);
                    v128 cmp3 = cmpgt_epi8(ucmpa, T3);
                    
                    v128 result = sub_epi8(sub_epi8(r0, cmp3), 
                                           add_epi8(cmp1, cmp2));

                    constexpr.ASSUME_LE_EPU8(result, 11);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a, elements);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 <= a.Byte15);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_f32rcprsqrt_epi8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
VectorAssert.IsNotSmaller<sbyte16, sbyte>(a, 0, elements);
constexpr.ASSUME_GE_EPI8(a, 0, elements);

                    v128 result;

                    if (elements <= 4)
                    {
                        v128 toFloat = cvtepu8_ps(a);
                        v128 sqrt = rcp_ps(rsqrt_ps(toFloat));
                        v128 toInt = cvttps_epi32(sqrt);

                        result = cvtepi32_epi8(toInt, elements);
                    }
                    else if (elements <= 8)
                    {
                        v128 toFloat_lo = cvtepu8_ps(a);
                        v128 toFloat_hi = cvtepu8_ps(bsrli_si128(a, 4 * sizeof(byte)));
                        v128 sqrt_lo = rcp_ps(rsqrt_ps(toFloat_lo));
                        v128 sqrt_hi = rcp_ps(rsqrt_ps(toFloat_hi));

                        v128 shorts = packs_epi32(cvttps_epi32(sqrt_lo), cvttps_epi32(sqrt_hi));

                        result = packus_epi16(shorts, shorts);
                    }
                    else
                    {
                        v128 shortsLo = cvt2x2epu8_epi16(a, out v128 shortsHi);
                        v128 toFloat_0 = cvt2x2epu16_ps(shortsLo, out v128 toFloat_1);
                        v128 toFloat_2 = cvt2x2epu16_ps(shortsHi, out v128 toFloat_3);

                        v128 sqrt_0 = rcp_ps(rsqrt_ps(toFloat_0));
                        v128 sqrt_1 = rcp_ps(rsqrt_ps(toFloat_1));
                        v128 sqrt_2 = rcp_ps(rsqrt_ps(toFloat_2));
                        v128 sqrt_3 = rcp_ps(rsqrt_ps(toFloat_3));

                        shortsLo = packs_epi32(cvttps_epi32(sqrt_0), cvttps_epi32(sqrt_1));
                        shortsHi = packs_epi32(cvttps_epi32(sqrt_2), cvttps_epi32(sqrt_3));

                        result = packus_epi16(shortsLo, shortsHi);
                    }

                    constexpr.ASSUME_LE_EPU8(a, 11);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a, elements);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 <= a.Byte15);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_sqrthi4correction_epu8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    v128 hi4 = srli_epi8(a, 4);
                    
                    v128 r0 = shuffle_epi8(new v128(  0,    4,   4,   4,    8,   8,   8,   8,   8,   12,  12,  12,  12,  12,  12,  12), hi4);
                    v128 T1 = shuffle_epi8(new v128(0x80,0x98,0x98,0x98, 0xD0,0xD0,0xD0,0xD0,0xD0, 0x28,0x28,0x28,0x28,0x28,0x28,0x28), hi4);
                    v128 T2 = shuffle_epi8(new v128(0x83,0xA3,0xA3,0xA3, 0xE3,0xE3,0xE3,0xE3,0xE3, 0x43,0x43,0x43,0x43,0x43,0x43,0x43), hi4);
                    v128 T3 = shuffle_epi8(new v128(0x88,0xB0,0xB0,0xB0, 0xF8,0xF8,0xF8,0xF8,0xF8, 0x60,0x60,0x60,0x60,0x60,0x60,0x60), hi4);
                    
                    v128 ucmpa = xor_si128(a, set1_epi8(1 << 7));
                    v128 cmp1 = cmpgt_epi8(ucmpa, T1);
                    v128 cmp2 = cmpgt_epi8(ucmpa, T2);
                    v128 cmp3 = cmpgt_epi8(ucmpa, T3);
                    
                    v128 result = sub_epi8(sub_epi8(r0, cmp3), 
                                           add_epi8(cmp1, cmp2));

                    constexpr.ASSUME_LE_EPU8(result, 15);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a, elements);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 <= a.Byte15);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_f32rcprsqrt_epu8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result = sqrt_epi8(a, elements);

                    if (!(constexpr.ALL_NEQ_EPU8(a, 225, elements) || constexpr.ALL_LT_EPU8(a, 225, elements) || constexpr.ALL_GT_EPU8(a, 225, elements)))
                    {
                        result = sub_epi8(result, cmpeq_epi8(a, set1_epi8(225)));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 15);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a, elements);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 <= a.Byte15);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi8(v128 a, byte elements = 16)
            {
VectorAssert.IsNotSmaller<sbyte16, sbyte>(a, 0, elements);
constexpr.ASSUME_GE_EPI8(a, 0, elements);

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        if (Arm.Neon.IsNeonSupported)
                        {
                            return sqrt_sqrthi4correction_epi8(a, elements);
                        }
                        else
                        {
                            if (elements <= 8)
                            {
                                return sqrt_f32rcprsqrt_epi8(a, elements);
                            }
                        }
                    }

                    return sqrt_sqrthi4correction_epi8(a, elements);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return sqrt_f32rcprsqrt_epi8(a, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi8(v256 a)
            {
VectorAssert.IsNotSmaller<sbyte32, sbyte>(a, 0, 32);
constexpr.ASSUME_GE_EPI8(a, 0, 32);

                if (Avx2.IsAvx2Supported)
                {
                    v256 hi4 = mm256_srli_epi8(a, 4);
                    
                    v256 r0 = Avx2.mm256_shuffle_epi8(new v256(  0,    4,   4,   4,    8,   8,   8,   8,   8,   12,  12,  12,  12,  12,  12,  12,
                                                                 0,    4,   4,   4,    8,   8,   8,   8,   8,   12,  12,  12,  12,  12,  12,  12), hi4);
                    v256 T1 = Avx2.mm256_shuffle_epi8(new v256(0x80,0x98,0x98,0x98, 0xD0,0xD0,0xD0,0xD0,0xD0, 0x28,0x28,0x28,0x28,0x28,0x28,0x28,
                                                               0x80,0x98,0x98,0x98, 0xD0,0xD0,0xD0,0xD0,0xD0, 0x28,0x28,0x28,0x28,0x28,0x28,0x28), hi4);
                    v256 T2 = Avx2.mm256_shuffle_epi8(new v256(0x83,0xA3,0xA3,0xA3, 0xE3,0xE3,0xE3,0xE3,0xE3, 0x43,0x43,0x43,0x43,0x43,0x43,0x43,
                                                               0x83,0xA3,0xA3,0xA3, 0xE3,0xE3,0xE3,0xE3,0xE3, 0x43,0x43,0x43,0x43,0x43,0x43,0x43), hi4);
                    v256 T3 = Avx2.mm256_shuffle_epi8(new v256(0x88,0xB0,0xB0,0xB0, 0xF8,0xF8,0xF8,0xF8,0xF8, 0x60,0x60,0x60,0x60,0x60,0x60,0x60,
                                                               0x88,0xB0,0xB0,0xB0, 0xF8,0xF8,0xF8,0xF8,0xF8, 0x60,0x60,0x60,0x60,0x60,0x60,0x60), hi4);
                    
                    v256 ucmpa = Avx2.mm256_xor_si256(a, mm256_set1_epi8(1 << 7));
                    v256 cmp1 = Avx2.mm256_cmpgt_epi8(ucmpa, T1);
                    v256 cmp2 = Avx2.mm256_cmpgt_epi8(ucmpa, T2);
                    v256 cmp3 = Avx2.mm256_cmpgt_epi8(ucmpa, T3);
                    
                    v256 result = Avx2.mm256_sub_epi8(Avx2.mm256_sub_epi8(r0, cmp3), 
                                                      Avx2.mm256_add_epi8(cmp1, cmp2));

                    constexpr.ASSUME_LE_EPU8(result, 11);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 <= a.Byte15);
                    constexpr.ASSUME(result.Byte16 * result.Byte16 <= a.Byte16);
                    constexpr.ASSUME(result.Byte17 * result.Byte17 <= a.Byte17);
                    constexpr.ASSUME(result.Byte18 * result.Byte18 <= a.Byte18);
                    constexpr.ASSUME(result.Byte19 * result.Byte19 <= a.Byte19);
                    constexpr.ASSUME(result.Byte20 * result.Byte20 <= a.Byte20);
                    constexpr.ASSUME(result.Byte21 * result.Byte21 <= a.Byte21);
                    constexpr.ASSUME(result.Byte22 * result.Byte22 <= a.Byte22);
                    constexpr.ASSUME(result.Byte23 * result.Byte23 <= a.Byte23);
                    constexpr.ASSUME(result.Byte24 * result.Byte24 <= a.Byte24);
                    constexpr.ASSUME(result.Byte25 * result.Byte25 <= a.Byte25);
                    constexpr.ASSUME(result.Byte26 * result.Byte26 <= a.Byte26);
                    constexpr.ASSUME(result.Byte27 * result.Byte27 <= a.Byte27);
                    constexpr.ASSUME(result.Byte28 * result.Byte28 <= a.Byte28);
                    constexpr.ASSUME(result.Byte29 * result.Byte29 <= a.Byte29);
                    constexpr.ASSUME(result.Byte30 * result.Byte30 <= a.Byte30);
                    constexpr.ASSUME(result.Byte31 * result.Byte31 <= a.Byte31);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    constexpr.ASSUME((result.Byte16 + 1) * (result.Byte16 + 1) > a.Byte16);
                    constexpr.ASSUME((result.Byte17 + 1) * (result.Byte17 + 1) > a.Byte17);
                    constexpr.ASSUME((result.Byte18 + 1) * (result.Byte18 + 1) > a.Byte18);
                    constexpr.ASSUME((result.Byte19 + 1) * (result.Byte19 + 1) > a.Byte19);
                    constexpr.ASSUME((result.Byte20 + 1) * (result.Byte20 + 1) > a.Byte20);
                    constexpr.ASSUME((result.Byte21 + 1) * (result.Byte21 + 1) > a.Byte21);
                    constexpr.ASSUME((result.Byte22 + 1) * (result.Byte22 + 1) > a.Byte22);
                    constexpr.ASSUME((result.Byte23 + 1) * (result.Byte23 + 1) > a.Byte23);
                    constexpr.ASSUME((result.Byte24 + 1) * (result.Byte24 + 1) > a.Byte24);
                    constexpr.ASSUME((result.Byte25 + 1) * (result.Byte25 + 1) > a.Byte25);
                    constexpr.ASSUME((result.Byte26 + 1) * (result.Byte26 + 1) > a.Byte26);
                    constexpr.ASSUME((result.Byte27 + 1) * (result.Byte27 + 1) > a.Byte27);
                    constexpr.ASSUME((result.Byte28 + 1) * (result.Byte28 + 1) > a.Byte28);
                    constexpr.ASSUME((result.Byte29 + 1) * (result.Byte29 + 1) > a.Byte29);
                    constexpr.ASSUME((result.Byte30 + 1) * (result.Byte30 + 1) > a.Byte30);
                    constexpr.ASSUME((result.Byte31 + 1) * (result.Byte31 + 1) > a.Byte31);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    constexpr.ASSUME((a.Byte16 <= 1) == (result.Byte16 == a.Byte16));
                    constexpr.ASSUME((a.Byte17 <= 1) == (result.Byte17 == a.Byte17));
                    constexpr.ASSUME((a.Byte18 <= 1) == (result.Byte18 == a.Byte18));
                    constexpr.ASSUME((a.Byte19 <= 1) == (result.Byte19 == a.Byte19));
                    constexpr.ASSUME((a.Byte20 <= 1) == (result.Byte20 == a.Byte20));
                    constexpr.ASSUME((a.Byte21 <= 1) == (result.Byte21 == a.Byte21));
                    constexpr.ASSUME((a.Byte22 <= 1) == (result.Byte22 == a.Byte22));
                    constexpr.ASSUME((a.Byte23 <= 1) == (result.Byte23 == a.Byte23));
                    constexpr.ASSUME((a.Byte24 <= 1) == (result.Byte24 == a.Byte24));
                    constexpr.ASSUME((a.Byte25 <= 1) == (result.Byte25 == a.Byte25));
                    constexpr.ASSUME((a.Byte26 <= 1) == (result.Byte26 == a.Byte26));
                    constexpr.ASSUME((a.Byte27 <= 1) == (result.Byte27 == a.Byte27));
                    constexpr.ASSUME((a.Byte28 <= 1) == (result.Byte28 == a.Byte28));
                    constexpr.ASSUME((a.Byte29 <= 1) == (result.Byte29 == a.Byte29));
                    constexpr.ASSUME((a.Byte30 <= 1) == (result.Byte30 == a.Byte30));
                    constexpr.ASSUME((a.Byte31 <= 1) == (result.Byte31 == a.Byte31));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));
                    constexpr.ASSUME((a.Byte16 != 0) == (result.Byte16 > 0));
                    constexpr.ASSUME((a.Byte17 != 0) == (result.Byte17 > 0));
                    constexpr.ASSUME((a.Byte18 != 0) == (result.Byte18 > 0));
                    constexpr.ASSUME((a.Byte19 != 0) == (result.Byte19 > 0));
                    constexpr.ASSUME((a.Byte20 != 0) == (result.Byte20 > 0));
                    constexpr.ASSUME((a.Byte21 != 0) == (result.Byte21 > 0));
                    constexpr.ASSUME((a.Byte22 != 0) == (result.Byte22 > 0));
                    constexpr.ASSUME((a.Byte23 != 0) == (result.Byte23 > 0));
                    constexpr.ASSUME((a.Byte24 != 0) == (result.Byte24 > 0));
                    constexpr.ASSUME((a.Byte25 != 0) == (result.Byte25 > 0));
                    constexpr.ASSUME((a.Byte26 != 0) == (result.Byte26 > 0));
                    constexpr.ASSUME((a.Byte27 != 0) == (result.Byte27 > 0));
                    constexpr.ASSUME((a.Byte28 != 0) == (result.Byte28 > 0));
                    constexpr.ASSUME((a.Byte29 != 0) == (result.Byte29 > 0));
                    constexpr.ASSUME((a.Byte30 != 0) == (result.Byte30 > 0));
                    constexpr.ASSUME((a.Byte31 != 0) == (result.Byte31 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        if (Arm.Neon.IsNeonSupported)
                        {
                            return sqrt_sqrthi4correction_epu8(a, elements);
                        }
                        else
                        {
                            if (elements <= 8)
                            {
                                return sqrt_f32rcprsqrt_epu8(a, elements);
                            }
                        }
                    }

                    return sqrt_sqrthi4correction_epu8(a, elements);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return sqrt_f32rcprsqrt_epu8(a, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 hi4 = mm256_srli_epi8(a, 4);
                    
                    v256 r0 = Avx2.mm256_shuffle_epi8(new v256(  0,    4,   4,   4,    8,   8,   8,   8,   8,   12,  12,  12,  12,  12,  12,  12,
                                                                 0,    4,   4,   4,    8,   8,   8,   8,   8,   12,  12,  12,  12,  12,  12,  12), hi4);
                    v256 T1 = Avx2.mm256_shuffle_epi8(new v256(0x80,0x98,0x98,0x98, 0xD0,0xD0,0xD0,0xD0,0xD0, 0x28,0x28,0x28,0x28,0x28,0x28,0x28,
                                                               0x80,0x98,0x98,0x98, 0xD0,0xD0,0xD0,0xD0,0xD0, 0x28,0x28,0x28,0x28,0x28,0x28,0x28), hi4);
                    v256 T2 = Avx2.mm256_shuffle_epi8(new v256(0x83,0xA3,0xA3,0xA3, 0xE3,0xE3,0xE3,0xE3,0xE3, 0x43,0x43,0x43,0x43,0x43,0x43,0x43,
                                                               0x83,0xA3,0xA3,0xA3, 0xE3,0xE3,0xE3,0xE3,0xE3, 0x43,0x43,0x43,0x43,0x43,0x43,0x43), hi4);
                    v256 T3 = Avx2.mm256_shuffle_epi8(new v256(0x88,0xB0,0xB0,0xB0, 0xF8,0xF8,0xF8,0xF8,0xF8, 0x60,0x60,0x60,0x60,0x60,0x60,0x60,
                                                               0x88,0xB0,0xB0,0xB0, 0xF8,0xF8,0xF8,0xF8,0xF8, 0x60,0x60,0x60,0x60,0x60,0x60,0x60), hi4);
                    
                    v256 ucmpa = Avx2.mm256_xor_si256(a, mm256_set1_epi8(1 << 7));
                    v256 cmp1 = Avx2.mm256_cmpgt_epi8(ucmpa, T1);
                    v256 cmp2 = Avx2.mm256_cmpgt_epi8(ucmpa, T2);
                    v256 cmp3 = Avx2.mm256_cmpgt_epi8(ucmpa, T3);
                    
                    v256 result = Avx2.mm256_sub_epi8(Avx2.mm256_sub_epi8(r0, cmp3), 
                                                      Avx2.mm256_add_epi8(cmp1, cmp2));

                    constexpr.ASSUME_LE_EPU8(result, 15);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 <= a.Byte15);
                    constexpr.ASSUME(result.Byte16 * result.Byte16 <= a.Byte16);
                    constexpr.ASSUME(result.Byte17 * result.Byte17 <= a.Byte17);
                    constexpr.ASSUME(result.Byte18 * result.Byte18 <= a.Byte18);
                    constexpr.ASSUME(result.Byte19 * result.Byte19 <= a.Byte19);
                    constexpr.ASSUME(result.Byte20 * result.Byte20 <= a.Byte20);
                    constexpr.ASSUME(result.Byte21 * result.Byte21 <= a.Byte21);
                    constexpr.ASSUME(result.Byte22 * result.Byte22 <= a.Byte22);
                    constexpr.ASSUME(result.Byte23 * result.Byte23 <= a.Byte23);
                    constexpr.ASSUME(result.Byte24 * result.Byte24 <= a.Byte24);
                    constexpr.ASSUME(result.Byte25 * result.Byte25 <= a.Byte25);
                    constexpr.ASSUME(result.Byte26 * result.Byte26 <= a.Byte26);
                    constexpr.ASSUME(result.Byte27 * result.Byte27 <= a.Byte27);
                    constexpr.ASSUME(result.Byte28 * result.Byte28 <= a.Byte28);
                    constexpr.ASSUME(result.Byte29 * result.Byte29 <= a.Byte29);
                    constexpr.ASSUME(result.Byte30 * result.Byte30 <= a.Byte30);
                    constexpr.ASSUME(result.Byte31 * result.Byte31 <= a.Byte31);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    constexpr.ASSUME((result.Byte16 + 1) * (result.Byte16 + 1) > a.Byte16);
                    constexpr.ASSUME((result.Byte17 + 1) * (result.Byte17 + 1) > a.Byte17);
                    constexpr.ASSUME((result.Byte18 + 1) * (result.Byte18 + 1) > a.Byte18);
                    constexpr.ASSUME((result.Byte19 + 1) * (result.Byte19 + 1) > a.Byte19);
                    constexpr.ASSUME((result.Byte20 + 1) * (result.Byte20 + 1) > a.Byte20);
                    constexpr.ASSUME((result.Byte21 + 1) * (result.Byte21 + 1) > a.Byte21);
                    constexpr.ASSUME((result.Byte22 + 1) * (result.Byte22 + 1) > a.Byte22);
                    constexpr.ASSUME((result.Byte23 + 1) * (result.Byte23 + 1) > a.Byte23);
                    constexpr.ASSUME((result.Byte24 + 1) * (result.Byte24 + 1) > a.Byte24);
                    constexpr.ASSUME((result.Byte25 + 1) * (result.Byte25 + 1) > a.Byte25);
                    constexpr.ASSUME((result.Byte26 + 1) * (result.Byte26 + 1) > a.Byte26);
                    constexpr.ASSUME((result.Byte27 + 1) * (result.Byte27 + 1) > a.Byte27);
                    constexpr.ASSUME((result.Byte28 + 1) * (result.Byte28 + 1) > a.Byte28);
                    constexpr.ASSUME((result.Byte29 + 1) * (result.Byte29 + 1) > a.Byte29);
                    constexpr.ASSUME((result.Byte30 + 1) * (result.Byte30 + 1) > a.Byte30);
                    constexpr.ASSUME((result.Byte31 + 1) * (result.Byte31 + 1) > a.Byte31);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    constexpr.ASSUME((a.Byte16 <= 1) == (result.Byte16 == a.Byte16));
                    constexpr.ASSUME((a.Byte17 <= 1) == (result.Byte17 == a.Byte17));
                    constexpr.ASSUME((a.Byte18 <= 1) == (result.Byte18 == a.Byte18));
                    constexpr.ASSUME((a.Byte19 <= 1) == (result.Byte19 == a.Byte19));
                    constexpr.ASSUME((a.Byte20 <= 1) == (result.Byte20 == a.Byte20));
                    constexpr.ASSUME((a.Byte21 <= 1) == (result.Byte21 == a.Byte21));
                    constexpr.ASSUME((a.Byte22 <= 1) == (result.Byte22 == a.Byte22));
                    constexpr.ASSUME((a.Byte23 <= 1) == (result.Byte23 == a.Byte23));
                    constexpr.ASSUME((a.Byte24 <= 1) == (result.Byte24 == a.Byte24));
                    constexpr.ASSUME((a.Byte25 <= 1) == (result.Byte25 == a.Byte25));
                    constexpr.ASSUME((a.Byte26 <= 1) == (result.Byte26 == a.Byte26));
                    constexpr.ASSUME((a.Byte27 <= 1) == (result.Byte27 == a.Byte27));
                    constexpr.ASSUME((a.Byte28 <= 1) == (result.Byte28 == a.Byte28));
                    constexpr.ASSUME((a.Byte29 <= 1) == (result.Byte29 == a.Byte29));
                    constexpr.ASSUME((a.Byte30 <= 1) == (result.Byte30 == a.Byte30));
                    constexpr.ASSUME((a.Byte31 <= 1) == (result.Byte31 == a.Byte31));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));
                    constexpr.ASSUME((a.Byte16 != 0) == (result.Byte16 > 0));
                    constexpr.ASSUME((a.Byte17 != 0) == (result.Byte17 > 0));
                    constexpr.ASSUME((a.Byte18 != 0) == (result.Byte18 > 0));
                    constexpr.ASSUME((a.Byte19 != 0) == (result.Byte19 > 0));
                    constexpr.ASSUME((a.Byte20 != 0) == (result.Byte20 > 0));
                    constexpr.ASSUME((a.Byte21 != 0) == (result.Byte21 > 0));
                    constexpr.ASSUME((a.Byte22 != 0) == (result.Byte22 > 0));
                    constexpr.ASSUME((a.Byte23 != 0) == (result.Byte23 > 0));
                    constexpr.ASSUME((a.Byte24 != 0) == (result.Byte24 > 0));
                    constexpr.ASSUME((a.Byte25 != 0) == (result.Byte25 > 0));
                    constexpr.ASSUME((a.Byte26 != 0) == (result.Byte26 > 0));
                    constexpr.ASSUME((a.Byte27 != 0) == (result.Byte27 > 0));
                    constexpr.ASSUME((a.Byte28 != 0) == (result.Byte28 > 0));
                    constexpr.ASSUME((a.Byte29 != 0) == (result.Byte29 > 0));
                    constexpr.ASSUME((a.Byte30 != 0) == (result.Byte30 > 0));
                    constexpr.ASSUME((a.Byte31 != 0) == (result.Byte31 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi16(v128 a, byte elements = 8, bool signed = true)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
if (signed)
{
    VectorAssert.IsNotSmaller<short8, short>(a, 0, elements);
    constexpr.ASSUME_GE_EPI16(a, 0, elements);
}

                    v128 result;

                    if (elements <= 4)
                    {
                        v128 sqrt;
                        v128 ints;

                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                            {
                                sqrt = rcp_ps(rsqrt_ps(cvtepu16_ps(a)));
                                ints = cvttps_epi32(sqrt);
                                result = packs_epi32(ints, ints);

                                if (!(constexpr.ALL_NEQ_EPU16(a, 225, elements) || constexpr.ALL_LT_EPU16(a, 225, elements) || constexpr.ALL_GT_EPU16(a, 225, elements)))
                                {
                                    result = sub_epi16(result, cmpeq_epi16(a, set1_epi16(225)));
                                }

                                constexpr.ASSUME_LE_EPU16(result, 15);

                                goto RET;
                            }
                        }

                        sqrt = sqrt_ps(cvtepu16_ps(a));
                        ints = cvttps_epi32(sqrt);
                        result = packs_epi32(ints, ints);

                        constexpr.ASSUME_LE_EPU16(result, signed ? (byte)181 : byte.MaxValue);
                    }
                    else
                    {
                        v128 sqrt_lo;
                        v128 sqrt_hi;
                        v128 lo = cvt2x2epu16_ps(a, out v128 hi);

                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                            {
                                sqrt_lo = rcp_ps(rsqrt_ps(lo));
                                sqrt_hi = rcp_ps(rsqrt_ps(hi));
                                result = packs_epi32(cvttps_epi32(sqrt_lo), cvttps_epi32(sqrt_hi));

                                if (!(constexpr.ALL_NEQ_EPU16(a, 225, elements) || constexpr.ALL_LT_EPU16(a, 225, elements) || constexpr.ALL_GT_EPU16(a, 225, elements)))
                                {
                                    result = sub_epi16(result, cmpeq_epi16(a, set1_epi16(225)));
                                }

                                constexpr.ASSUME_LE_EPU16(result, 15);

                                goto RET;
                            }
                        }

                        sqrt_lo = sqrt_ps(lo);
                        sqrt_hi = sqrt_ps(hi);
                        result = packs_epi32(cvttps_epi32(sqrt_lo), cvttps_epi32(sqrt_hi));

                        constexpr.ASSUME_LE_EPU16(result, signed ? (byte)181 : byte.MaxValue);
                    }

                RET:

                    constexpr.ASSUME_LE_EPU16(result, a, elements);
                    if (constexpr.ALL_GT_EPU16(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a, elements);
                    }

                    constexpr.ASSUME(result.UShort0 * result.UShort0 <= a.UShort0);
                    constexpr.ASSUME(result.UShort1 * result.UShort1 <= a.UShort1);
                    constexpr.ASSUME(result.UShort2 * result.UShort2 <= a.UShort2);
                    constexpr.ASSUME(result.UShort3 * result.UShort3 <= a.UShort3);
                    
                    constexpr.ASSUME((uint)(result.UShort0 + 1) * (uint)(result.UShort0 + 1) > a.UShort0);
                    constexpr.ASSUME((uint)(result.UShort1 + 1) * (uint)(result.UShort1 + 1) > a.UShort1);
                    constexpr.ASSUME((uint)(result.UShort2 + 1) * (uint)(result.UShort2 + 1) > a.UShort2);
                    constexpr.ASSUME((uint)(result.UShort3 + 1) * (uint)(result.UShort3 + 1) > a.UShort3);
                    
                    constexpr.ASSUME((a.UShort0 <= 1) == (result.UShort0 == a.UShort0));
                    constexpr.ASSUME((a.UShort1 <= 1) == (result.UShort1 == a.UShort1));
                    constexpr.ASSUME((a.UShort2 <= 1) == (result.UShort2 == a.UShort2));
                    constexpr.ASSUME((a.UShort3 <= 1) == (result.UShort3 == a.UShort3));
                    
                    constexpr.ASSUME((a.UShort0 != 0) == (result.UShort0 > 0));
                    constexpr.ASSUME((a.UShort1 != 0) == (result.UShort1 > 0));
                    constexpr.ASSUME((a.UShort2 != 0) == (result.UShort2 > 0));
                    constexpr.ASSUME((a.UShort3 != 0) == (result.UShort3 > 0));

                    if (elements > 4)
                    {
                        constexpr.ASSUME(result.UShort4 * result.UShort4 <= a.UShort4);
                        constexpr.ASSUME(result.UShort5 * result.UShort5 <= a.UShort5);
                        constexpr.ASSUME(result.UShort6 * result.UShort6 <= a.UShort6);
                        constexpr.ASSUME(result.UShort7 * result.UShort7 <= a.UShort7);
                        
                        constexpr.ASSUME((uint)(result.UShort4 + 1) * (uint)(result.UShort4 + 1) > a.UShort4);
                        constexpr.ASSUME((uint)(result.UShort5 + 1) * (uint)(result.UShort5 + 1) > a.UShort5);
                        constexpr.ASSUME((uint)(result.UShort6 + 1) * (uint)(result.UShort6 + 1) > a.UShort6);
                        constexpr.ASSUME((uint)(result.UShort7 + 1) * (uint)(result.UShort7 + 1) > a.UShort7);
                        
                        constexpr.ASSUME((a.UShort4 <= 1) == (result.UShort4 == a.UShort4));
                        constexpr.ASSUME((a.UShort5 <= 1) == (result.UShort5 == a.UShort5));
                        constexpr.ASSUME((a.UShort6 <= 1) == (result.UShort6 == a.UShort6));
                        constexpr.ASSUME((a.UShort7 <= 1) == (result.UShort7 == a.UShort7));
                        
                        constexpr.ASSUME((a.UShort4 != 0) == (result.UShort4 > 0));
                        constexpr.ASSUME((a.UShort5 != 0) == (result.UShort5 > 0));
                        constexpr.ASSUME((a.UShort6 != 0) == (result.UShort6 > 0));
                        constexpr.ASSUME((a.UShort7 != 0) == (result.UShort7 > 0));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi16(v256 a, bool signed = true)
            {
                if (Avx2.IsAvx2Supported)
                {
if (signed)
{
    VectorAssert.IsNotSmaller<short16, short>(a, 0, 16);
    constexpr.ASSUME_GE_EPI16(a, 0, 16);
}

                    v256 intsLo = mm256_cvt2x2epu16_ps(a, out v256 intsHi);
                    v256 result;

                    if (constexpr.ALL_LE_EPU16(a, byte.MaxValue))
                    {
                        v256 sqrtLo = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(intsLo));
                        v256 sqrtHi = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(intsHi));
                        result = mm256_cvtt2x2ps_epu16(sqrtLo, sqrtHi);

                        if (!(constexpr.ALL_NEQ_EPU16(a, 225) || constexpr.ALL_LT_EPU16(a, 225) || constexpr.ALL_GT_EPU16(a, 225)))
                        {
                            result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpeq_epi16(a, mm256_set1_epi16(225)));
                        }

                        constexpr.ASSUME_LE_EPU16(result, 15);
                    }
                    else
                    {
                        v256 sqrtLo = Avx.mm256_sqrt_ps(intsLo);
                        v256 sqrtHi = Avx.mm256_sqrt_ps(intsHi);
                        result = Avx2.mm256_packus_epi32(Avx.mm256_cvttps_epi32(sqrtLo), Avx.mm256_cvttps_epi32(sqrtHi));

                        constexpr.ASSUME_LE_EPU16(result, signed ? (byte)181 : byte.MaxValue);
                    }

                    constexpr.ASSUME_LE_EPU16(result, a);
                    if (constexpr.ALL_GT_EPU16(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a);
                    }

                    constexpr.ASSUME(result.UShort0  * result.UShort0  <= a.UShort0 );
                    constexpr.ASSUME(result.UShort1  * result.UShort1  <= a.UShort1 );
                    constexpr.ASSUME(result.UShort2  * result.UShort2  <= a.UShort2 );
                    constexpr.ASSUME(result.UShort3  * result.UShort3  <= a.UShort3 );
                    constexpr.ASSUME(result.UShort4  * result.UShort4  <= a.UShort4 );
                    constexpr.ASSUME(result.UShort5  * result.UShort5  <= a.UShort5 );
                    constexpr.ASSUME(result.UShort6  * result.UShort6  <= a.UShort6 );
                    constexpr.ASSUME(result.UShort7  * result.UShort7  <= a.UShort7 );
                    constexpr.ASSUME(result.UShort8  * result.UShort8  <= a.UShort8 );
                    constexpr.ASSUME(result.UShort9  * result.UShort9  <= a.UShort9 );
                    constexpr.ASSUME(result.UShort10 * result.UShort10 <= a.UShort10);
                    constexpr.ASSUME(result.UShort11 * result.UShort11 <= a.UShort11);
                    constexpr.ASSUME(result.UShort12 * result.UShort12 <= a.UShort12);
                    constexpr.ASSUME(result.UShort13 * result.UShort13 <= a.UShort13);
                    constexpr.ASSUME(result.UShort14 * result.UShort14 <= a.UShort14);
                    constexpr.ASSUME(result.UShort15 * result.UShort15 <= a.UShort15);
                    
                    constexpr.ASSUME((uint)(result.UShort0  + 1) * (uint)(result.UShort0  + 1) > a.UShort0 );
                    constexpr.ASSUME((uint)(result.UShort1  + 1) * (uint)(result.UShort1  + 1) > a.UShort1 );
                    constexpr.ASSUME((uint)(result.UShort2  + 1) * (uint)(result.UShort2  + 1) > a.UShort2 );
                    constexpr.ASSUME((uint)(result.UShort3  + 1) * (uint)(result.UShort3  + 1) > a.UShort3 );
                    constexpr.ASSUME((uint)(result.UShort4  + 1) * (uint)(result.UShort4  + 1) > a.UShort4 );
                    constexpr.ASSUME((uint)(result.UShort5  + 1) * (uint)(result.UShort5  + 1) > a.UShort5 );
                    constexpr.ASSUME((uint)(result.UShort6  + 1) * (uint)(result.UShort6  + 1) > a.UShort6 );
                    constexpr.ASSUME((uint)(result.UShort7  + 1) * (uint)(result.UShort7  + 1) > a.UShort7 );
                    constexpr.ASSUME((uint)(result.UShort8  + 1) * (uint)(result.UShort8  + 1) > a.UShort8 );
                    constexpr.ASSUME((uint)(result.UShort9  + 1) * (uint)(result.UShort9  + 1) > a.UShort9 );
                    constexpr.ASSUME((uint)(result.UShort10 + 1) * (uint)(result.UShort10 + 1) > a.UShort10);
                    constexpr.ASSUME((uint)(result.UShort11 + 1) * (uint)(result.UShort11 + 1) > a.UShort11);
                    constexpr.ASSUME((uint)(result.UShort12 + 1) * (uint)(result.UShort12 + 1) > a.UShort12);
                    constexpr.ASSUME((uint)(result.UShort13 + 1) * (uint)(result.UShort13 + 1) > a.UShort13);
                    constexpr.ASSUME((uint)(result.UShort14 + 1) * (uint)(result.UShort14 + 1) > a.UShort14);
                    constexpr.ASSUME((uint)(result.UShort15 + 1) * (uint)(result.UShort15 + 1) > a.UShort15);
                    
                    constexpr.ASSUME((a.UShort0  <= 1) == (result.UShort0  == a.UShort0 ));
                    constexpr.ASSUME((a.UShort1  <= 1) == (result.UShort1  == a.UShort1 ));
                    constexpr.ASSUME((a.UShort2  <= 1) == (result.UShort2  == a.UShort2 ));
                    constexpr.ASSUME((a.UShort3  <= 1) == (result.UShort3  == a.UShort3 ));
                    constexpr.ASSUME((a.UShort4  <= 1) == (result.UShort4  == a.UShort4 ));
                    constexpr.ASSUME((a.UShort5  <= 1) == (result.UShort5  == a.UShort5 ));
                    constexpr.ASSUME((a.UShort6  <= 1) == (result.UShort6  == a.UShort6 ));
                    constexpr.ASSUME((a.UShort7  <= 1) == (result.UShort7  == a.UShort7 ));
                    constexpr.ASSUME((a.UShort8  <= 1) == (result.UShort8  == a.UShort8 ));
                    constexpr.ASSUME((a.UShort9  <= 1) == (result.UShort9  == a.UShort9 ));
                    constexpr.ASSUME((a.UShort10 <= 1) == (result.UShort10 == a.UShort10));
                    constexpr.ASSUME((a.UShort11 <= 1) == (result.UShort11 == a.UShort11));
                    constexpr.ASSUME((a.UShort12 <= 1) == (result.UShort12 == a.UShort12));
                    constexpr.ASSUME((a.UShort13 <= 1) == (result.UShort13 == a.UShort13));
                    constexpr.ASSUME((a.UShort14 <= 1) == (result.UShort14 == a.UShort14));
                    constexpr.ASSUME((a.UShort15 <= 1) == (result.UShort15 == a.UShort15));
                    
                    constexpr.ASSUME((a.UShort0  != 0) == (result.UShort0  > 0));
                    constexpr.ASSUME((a.UShort1  != 0) == (result.UShort1  > 0));
                    constexpr.ASSUME((a.UShort2  != 0) == (result.UShort2  > 0));
                    constexpr.ASSUME((a.UShort3  != 0) == (result.UShort3  > 0));
                    constexpr.ASSUME((a.UShort4  != 0) == (result.UShort4  > 0));
                    constexpr.ASSUME((a.UShort5  != 0) == (result.UShort5  > 0));
                    constexpr.ASSUME((a.UShort6  != 0) == (result.UShort6  > 0));
                    constexpr.ASSUME((a.UShort7  != 0) == (result.UShort7  > 0));
                    constexpr.ASSUME((a.UShort8  != 0) == (result.UShort8  > 0));
                    constexpr.ASSUME((a.UShort9  != 0) == (result.UShort9  > 0));
                    constexpr.ASSUME((a.UShort10 != 0) == (result.UShort10 > 0));
                    constexpr.ASSUME((a.UShort11 != 0) == (result.UShort11 > 0));
                    constexpr.ASSUME((a.UShort12 != 0) == (result.UShort12 > 0));
                    constexpr.ASSUME((a.UShort13 != 0) == (result.UShort13 > 0));
                    constexpr.ASSUME((a.UShort14 != 0) == (result.UShort14 > 0));
                    constexpr.ASSUME((a.UShort15 != 0) == (result.UShort15 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu16(v128 a, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return sqrt_epi16(a, elements, false);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_epi16(a, false);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<int4, int>(a, 0, elements);
constexpr.ASSUME_GE_EPI32(a, 0, elements);
                    
                    v128 result;

                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32, elements))
                    {
                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                            {
                                result = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU32(a, 225, elements) || constexpr.ALL_LT_EPU32(a, 225, elements) || constexpr.ALL_GT_EPU32(a, 225, elements)))
                                {
                                    result = sub_epi32(result, cmpeq_epi32(a, set1_epi32(225)));
                                }

                                constexpr.ASSUME_LE_EPU32(result, 15);
                                
                                goto RET;
                            }
                        }

                        result = cvttps_epi32(sqrt_ps(cvtepi32_ps(a)));
                        constexpr.ASSUME_LE_EPU32(result, constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            result = cvttpd_epi32(sqrt_pd(cvtepi32_pd(a)));
                        }
                        else
                        {
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                if (Avx.IsAvxSupported)
                                {
                                    result = Avx.mm256_cvttpd_epi32(Avx.mm256_sqrt_pd(Avx.mm256_cvtepi32_pd(a)));

                                    constexpr.ASSUME_LE_EPU32(result, 46_340);

                                    goto RET;
                                }
                            }

                            v128 sqrtLo = cvt2x2epi32_pd(a, out v128 sqrtHi);

                            sqrtLo = cvttpd_epi32(sqrt_pd(sqrtLo));
                            sqrtHi = cvttpd_epi32(sqrt_pd(sqrtHi));

                            result = unpacklo_epi64(sqrtLo, sqrtHi);
                        }

                        constexpr.ASSUME_LE_EPU32(result, 46_340);
                    }

                RET:

                    constexpr.ASSUME_LE_EPU32(result, a);
                    if (constexpr.ALL_GT_EPU32(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU32(result, a, elements);
                    }
                    
                    constexpr.ASSUME(result.UInt0 * result.UInt0 <= a.UInt0);
                    constexpr.ASSUME(result.UInt1 * result.UInt1 <= a.UInt1);
                    constexpr.ASSUME(result.UInt2 * result.UInt2 <= a.UInt2);
                    constexpr.ASSUME(result.UInt3 * result.UInt3 <= a.UInt3);
                    
                    constexpr.ASSUME(((ulong)result.UInt0 + 1) *((ulong)result.UInt0 + 1) > a.UInt0);
                    constexpr.ASSUME(((ulong)result.UInt1 + 1) *((ulong)result.UInt1 + 1) > a.UInt1);
                    constexpr.ASSUME(((ulong)result.UInt2 + 1) *((ulong)result.UInt2 + 1) > a.UInt2);
                    constexpr.ASSUME(((ulong)result.UInt3 + 1) *((ulong)result.UInt3 + 1) > a.UInt3);
                    
                    constexpr.ASSUME((a.UInt0 <= 1) == (result.UInt0 == a.UInt0));
                    constexpr.ASSUME((a.UInt1 <= 1) == (result.UInt1 == a.UInt1));
                    constexpr.ASSUME((a.UInt2 <= 1) == (result.UInt2 == a.UInt2));
                    constexpr.ASSUME((a.UInt3 <= 1) == (result.UInt3 == a.UInt3));
                    
                    constexpr.ASSUME((a.UInt0 != 0) == (result.UInt0 > 0));
                    constexpr.ASSUME((a.UInt1 != 0) == (result.UInt1 > 0));
                    constexpr.ASSUME((a.UInt2 != 0) == (result.UInt2 > 0));
                    constexpr.ASSUME((a.UInt3 != 0) == (result.UInt3 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<int8, int>(a, 0, 8);
constexpr.ASSUME_GE_EPI32(a, 0, 8);

                    v256 result;

                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            result = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225) || constexpr.ALL_LT_EPU32(a, 225) || constexpr.ALL_GT_EPU32(a, 225)))
                            {
                                result = Avx2.mm256_sub_epi32(result, Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(225)));
                            }

                            constexpr.ASSUME_LE_EPU32(result, 15);
                        }
                        else
                        {
                            result = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(result, constexpr.ALL_LE_EPU32(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                        }
                    }
                    else
                    {
                        v256 doublesLo = mm256_cvt2x2epu32_pd(a, out v256 doublesHi);

                        v256 sqrtLo = Avx.mm256_sqrt_pd(doublesLo);
                        v256 sqrtHi = Avx.mm256_sqrt_pd(doublesHi);

                        result = mm256_cvtt2x2pd_epu32(sqrtLo, sqrtHi, positive: true, nonZero: constexpr.ALL_NEQ_EPI32(a, 0));

                        constexpr.ASSUME_LE_EPU32(result, 46_340);
                    }

                    constexpr.ASSUME_LE_EPU32(result, a);
                    if (constexpr.ALL_GT_EPU32(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU32(result, a);
                    }

                    constexpr.ASSUME(result.UInt0 * result.UInt0 <= a.UInt0);
                    constexpr.ASSUME(result.UInt1 * result.UInt1 <= a.UInt1);
                    constexpr.ASSUME(result.UInt2 * result.UInt2 <= a.UInt2);
                    constexpr.ASSUME(result.UInt3 * result.UInt3 <= a.UInt3);
                    constexpr.ASSUME(result.UInt4 * result.UInt4 <= a.UInt4);
                    constexpr.ASSUME(result.UInt5 * result.UInt5 <= a.UInt5);
                    constexpr.ASSUME(result.UInt6 * result.UInt6 <= a.UInt6);
                    constexpr.ASSUME(result.UInt7 * result.UInt7 <= a.UInt7);
                    
                    constexpr.ASSUME(((ulong)result.UInt0 + 1) *((ulong)result.UInt0 + 1) > a.UInt0);
                    constexpr.ASSUME(((ulong)result.UInt1 + 1) *((ulong)result.UInt1 + 1) > a.UInt1);
                    constexpr.ASSUME(((ulong)result.UInt2 + 1) *((ulong)result.UInt2 + 1) > a.UInt2);
                    constexpr.ASSUME(((ulong)result.UInt3 + 1) *((ulong)result.UInt3 + 1) > a.UInt3);
                    constexpr.ASSUME(((ulong)result.UInt4 + 1) *((ulong)result.UInt4 + 1) > a.UInt4);
                    constexpr.ASSUME(((ulong)result.UInt5 + 1) *((ulong)result.UInt5 + 1) > a.UInt5);
                    constexpr.ASSUME(((ulong)result.UInt6 + 1) *((ulong)result.UInt6 + 1) > a.UInt6);
                    constexpr.ASSUME(((ulong)result.UInt7 + 1) *((ulong)result.UInt7 + 1) > a.UInt7);
                    
                    constexpr.ASSUME((a.UInt0 <= 1) == (result.UInt0 == a.UInt0));
                    constexpr.ASSUME((a.UInt1 <= 1) == (result.UInt1 == a.UInt1));
                    constexpr.ASSUME((a.UInt2 <= 1) == (result.UInt2 == a.UInt2));
                    constexpr.ASSUME((a.UInt3 <= 1) == (result.UInt3 == a.UInt3));
                    constexpr.ASSUME((a.UInt4 <= 1) == (result.UInt4 == a.UInt4));
                    constexpr.ASSUME((a.UInt5 <= 1) == (result.UInt5 == a.UInt5));
                    constexpr.ASSUME((a.UInt6 <= 1) == (result.UInt6 == a.UInt6));
                    constexpr.ASSUME((a.UInt7 <= 1) == (result.UInt7 == a.UInt7));
                    
                    constexpr.ASSUME((a.UInt0 != 0) == (result.UInt0 > 0));
                    constexpr.ASSUME((a.UInt1 != 0) == (result.UInt1 > 0));
                    constexpr.ASSUME((a.UInt2 != 0) == (result.UInt2 > 0));
                    constexpr.ASSUME((a.UInt3 != 0) == (result.UInt3 > 0));
                    constexpr.ASSUME((a.UInt4 != 0) == (result.UInt4 > 0));
                    constexpr.ASSUME((a.UInt5 != 0) == (result.UInt5 > 0));
                    constexpr.ASSUME((a.UInt6 != 0) == (result.UInt6 > 0));
                    constexpr.ASSUME((a.UInt7 != 0) == (result.UInt7 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32, elements))
                    {
                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                            {
                                result = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU32(a, 225, elements) || constexpr.ALL_LT_EPU32(a, 225, elements) || constexpr.ALL_GT_EPU32(a, 225, elements)))
                                {
                                    result = sub_epi32(result, cmpeq_epi32(a, set1_epi32(225)));
                                }

                                constexpr.ASSUME_LE_EPU32(result, 15);

                                goto RET;
                            }
                        }

                        result = cvttps_epi32(sqrt_ps(cvtepi32_ps(a)));
                        constexpr.ASSUME_LE_EPU32(result, constexpr.ALL_LE_EPU32(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            result = cvttpd_epi32(sqrt_pd(cvtepu32_pd(a)));
                        }
                        else
                        {
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                if (Avx.IsAvxSupported)
                                {
                                    result = Avx.mm256_cvttpd_epi32(Avx.mm256_sqrt_pd(mm256_cvtepu32_pd(a)));

                                    constexpr.ASSUME_LE_EPU32(result, ushort.MaxValue);

                                    goto RET;
                                }
                            }

                            v128 sqrtLo = cvt2x2epu32_pd(a, out v128 sqrtHi);

                            sqrtLo = cvttpd_epi32(sqrt_pd(sqrtLo));
                            sqrtHi = cvttpd_epi32(sqrt_pd(sqrtHi));

                            result = unpacklo_epi64(sqrtLo, sqrtHi);
                        }

                        constexpr.ASSUME_LE_EPU32(result, ushort.MaxValue);
                    }

                RET:

                    constexpr.ASSUME_LE_EPU32(result, a);
                    if (constexpr.ALL_GT_EPU32(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU32(result, a, elements);
                    }
                    
                    constexpr.ASSUME(result.UInt0 * result.UInt0 <= a.UInt0);
                    constexpr.ASSUME(result.UInt1 * result.UInt1 <= a.UInt1);
                    constexpr.ASSUME(result.UInt2 * result.UInt2 <= a.UInt2);
                    constexpr.ASSUME(result.UInt3 * result.UInt3 <= a.UInt3);
                    
                    constexpr.ASSUME(((ulong)result.UInt0 + 1) *((ulong)result.UInt0 + 1) > a.UInt0);
                    constexpr.ASSUME(((ulong)result.UInt1 + 1) *((ulong)result.UInt1 + 1) > a.UInt1);
                    constexpr.ASSUME(((ulong)result.UInt2 + 1) *((ulong)result.UInt2 + 1) > a.UInt2);
                    constexpr.ASSUME(((ulong)result.UInt3 + 1) *((ulong)result.UInt3 + 1) > a.UInt3);
                    
                    constexpr.ASSUME((a.UInt0 <= 1) == (result.UInt0 == a.UInt0));
                    constexpr.ASSUME((a.UInt1 <= 1) == (result.UInt1 == a.UInt1));
                    constexpr.ASSUME((a.UInt2 <= 1) == (result.UInt2 == a.UInt2));
                    constexpr.ASSUME((a.UInt3 <= 1) == (result.UInt3 == a.UInt3));
                    
                    constexpr.ASSUME((a.UInt0 != 0) == (result.UInt0 > 0));
                    constexpr.ASSUME((a.UInt1 != 0) == (result.UInt1 > 0));
                    constexpr.ASSUME((a.UInt2 != 0) == (result.UInt2 > 0));
                    constexpr.ASSUME((a.UInt3 != 0) == (result.UInt3 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            result = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225) || constexpr.ALL_LT_EPU32(a, 225) || constexpr.ALL_GT_EPU32(a, 225)))
                            {
                                result = Avx2.mm256_sub_epi32(result, Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(225)));
                            }

                            constexpr.ASSUME_LE_EPU32(result, 15);
                        }
                        else
                        {
                            result = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(result, constexpr.ALL_LE_EPU32(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                        }
                    }
                    else
                    {
                        v256 doublesLo = mm256_cvt2x2epu32_pd(a, out v256 doublesHi);

                        v256 sqrtLo = Avx.mm256_sqrt_pd(doublesLo);
                        v256 sqrtHi = Avx.mm256_sqrt_pd(doublesHi);
                        result =  mm256_cvtt2x2pd_epu32(sqrtLo, sqrtHi);

                        constexpr.ASSUME_LE_EPU32(result, ushort.MaxValue);
                    }

                    constexpr.ASSUME_LE_EPU32(result, a);
                    if (constexpr.ALL_GT_EPU32(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU32(result, a);
                    }

                    constexpr.ASSUME(result.UInt0 * result.UInt0 <= a.UInt0);
                    constexpr.ASSUME(result.UInt1 * result.UInt1 <= a.UInt1);
                    constexpr.ASSUME(result.UInt2 * result.UInt2 <= a.UInt2);
                    constexpr.ASSUME(result.UInt3 * result.UInt3 <= a.UInt3);
                    constexpr.ASSUME(result.UInt4 * result.UInt4 <= a.UInt4);
                    constexpr.ASSUME(result.UInt5 * result.UInt5 <= a.UInt5);
                    constexpr.ASSUME(result.UInt6 * result.UInt6 <= a.UInt6);
                    constexpr.ASSUME(result.UInt7 * result.UInt7 <= a.UInt7);
                    
                    constexpr.ASSUME(((ulong)result.UInt0 + 1) *((ulong)result.UInt0 + 1) > a.UInt0);
                    constexpr.ASSUME(((ulong)result.UInt1 + 1) *((ulong)result.UInt1 + 1) > a.UInt1);
                    constexpr.ASSUME(((ulong)result.UInt2 + 1) *((ulong)result.UInt2 + 1) > a.UInt2);
                    constexpr.ASSUME(((ulong)result.UInt3 + 1) *((ulong)result.UInt3 + 1) > a.UInt3);
                    constexpr.ASSUME(((ulong)result.UInt4 + 1) *((ulong)result.UInt4 + 1) > a.UInt4);
                    constexpr.ASSUME(((ulong)result.UInt5 + 1) *((ulong)result.UInt5 + 1) > a.UInt5);
                    constexpr.ASSUME(((ulong)result.UInt6 + 1) *((ulong)result.UInt6 + 1) > a.UInt6);
                    constexpr.ASSUME(((ulong)result.UInt7 + 1) *((ulong)result.UInt7 + 1) > a.UInt7);
                    
                    constexpr.ASSUME((a.UInt0 <= 1) == (result.UInt0 == a.UInt0));
                    constexpr.ASSUME((a.UInt1 <= 1) == (result.UInt1 == a.UInt1));
                    constexpr.ASSUME((a.UInt2 <= 1) == (result.UInt2 == a.UInt2));
                    constexpr.ASSUME((a.UInt3 <= 1) == (result.UInt3 == a.UInt3));
                    constexpr.ASSUME((a.UInt4 <= 1) == (result.UInt4 == a.UInt4));
                    constexpr.ASSUME((a.UInt5 <= 1) == (result.UInt5 == a.UInt5));
                    constexpr.ASSUME((a.UInt6 <= 1) == (result.UInt6 == a.UInt6));
                    constexpr.ASSUME((a.UInt7 <= 1) == (result.UInt7 == a.UInt7));
                    
                    constexpr.ASSUME((a.UInt0 != 0) == (result.UInt0 > 0));
                    constexpr.ASSUME((a.UInt1 != 0) == (result.UInt1 > 0));
                    constexpr.ASSUME((a.UInt2 != 0) == (result.UInt2 > 0));
                    constexpr.ASSUME((a.UInt3 != 0) == (result.UInt3 > 0));
                    constexpr.ASSUME((a.UInt4 != 0) == (result.UInt4 > 0));
                    constexpr.ASSUME((a.UInt5 != 0) == (result.UInt5 > 0));
                    constexpr.ASSUME((a.UInt6 != 0) == (result.UInt6 > 0));
                    constexpr.ASSUME((a.UInt7 != 0) == (result.UInt7 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi64(v128 a, bool promiseDBLrange = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<long2, long>(a, 0, 2);
constexpr.ASSUME_GE_EPI64(a, 0, 2);

                    if (Avx2.IsAvx2Supported)
                    {
                        return sqrt_ep64(a, signed: true, useFPU: true, promiseDBLrange: promiseDBLrange);
                    }
                    else
                    {
                        return sqrt_ep64(a, signed: true, useFPU: false, promiseDBLrange: promiseDBLrange);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu64(v128 a, bool promiseDBLrange = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return sqrt_ep64(a, signed: false, useFPU: true, promiseDBLrange: promiseDBLrange);
                    }
                    else
                    {
                        return sqrt_ep64(a, signed: false, useFPU: false, promiseDBLrange: promiseDBLrange);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epi64x2(v128 a0, v128 a1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseDBLrange = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<long2, long>(a0, 0, 2);
VectorAssert.IsNotSmaller<long2, long>(a1, 0, 2);
constexpr.ASSUME_GE_EPI64(a0, 0, 2);
constexpr.ASSUME_GE_EPI64(a1, 0, 2);

                    sqrt_ep64x2(a0, a1, out r0, out r1, signed: true, promiseDBLrange: promiseDBLrange);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epu64x2(v128 a0, v128 a1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseDBLrange = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    sqrt_ep64x2(a0, a1, out r0, out r1, signed: false, promiseDBLrange: promiseDBLrange);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epi64x4(v128 a0, v128 a1, v128 a2, v128 a3, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<long2, long>(a0, 0, 2);
VectorAssert.IsNotSmaller<long2, long>(a1, 0, 2);
VectorAssert.IsNotSmaller<long2, long>(a2, 0, 2);
VectorAssert.IsNotSmaller<long2, long>(a3, 0, 2);
constexpr.ASSUME_GE_EPI64(a1, 0, 2);
constexpr.ASSUME_GE_EPI64(a2, 0, 2);
constexpr.ASSUME_GE_EPI64(a3, 0, 2);

                    sqrt_ep64x4(a0, a1, a2, a3, out r0, out r1, out r2, out r3, signed: true);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epu64x4(v128 a0, v128 a1, v128 a2, v128 a3, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    sqrt_ep64x4(a0, a1, a2, a3, out r0, out r1, out r2, out r3, signed: false);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi64(v256 a, byte elements = 4, bool promiseDBLrange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<long4, long>(a, 0, elements);
constexpr.ASSUME_GE_EPI64(a, 0, elements);

                    return mm256_sqrt_ep64(a, signed: true, elements, promiseDBLrange: promiseDBLrange);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu64(v256 a, byte elements = 4, bool promiseDBLrange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep64(a, signed: false, elements, promiseDBLrange: promiseDBLrange);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_sqrt_epi64x2(v256 a0, v256 a1, [NoAlias] out v256 r0, [NoAlias] out v256 r1, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<long4, long>(a0, 0, elements);
constexpr.ASSUME_GE_EPI64(a0, 0, elements);
VectorAssert.IsNotSmaller<long4, long>(a1, 0, elements);
constexpr.ASSUME_GE_EPI64(a1, 0, elements);

                    mm256_sqrt_ep64x2(a0, a1, out r0, out r1, signed: true, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_sqrt_epu64x2(v256 a0, v256 a1, [NoAlias] out v256 r0, [NoAlias] out v256 r1, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_sqrt_ep64x2(a0, a1, out r0, out r1, signed: false, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep64([NoAlias] ref v128 a, [NoAlias] out v128 mask, [NoAlias] out v128 result, bool signed)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1L);
                    v128 TWO = set1_epi64x(2L);

                    mask = new v128(1ul << 62);
                    mask = srlv_epi64(mask, andnot_si128(ONE, lzcnt_epi64(a)), inRange: constexpr.ALL_GT_EPU64(a, 0));
                    mask = srlv_epi64(mask, and_si128(TWO, signed ? cmpgt_epi64(mask, a) : cmpgt_epu64(mask, a)), inRange: true);

                    result = mask;
                    a = sub_epi64(a, andnot_si128(signed ? cmpgt_epi64(mask, a) : cmpgt_epu64(mask, a), mask));
                    mask = srli_epi64(mask, 2);

                    v128 doneMask;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (Arm.Neon.IsNeonSupported)
                    {
                        ;
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                        {
                            doneMask = cmpeq_epi64(mask, ZERO);

                            v128 resultAdded = or_si128(result, mask);
                            v128 tempResult = srli_epi64(result, 1);
                            v128 cmp = cmpgt_epu64(resultAdded, a);

                            a = sub_epi64(a, andnot_si128(cmp, resultAdded));
                            tempResult = ternarylogic_si128(cmp, mask, tempResult, TernaryOperation.OxAE);
                            result = blendv_si128(tempResult, result, doneMask);

                            mask = srli_epi64(mask, 2);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep64([NoAlias] ref v128 a, [NoAlias] ref v128 result, [NoAlias] ref v128 mask, v128 doneMask, bool signed)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 resultAdded = or_si128(result, mask);
                    v128 cmp;
                    if (signed)
                    {
                        cmp = cmpgt_epi64(resultAdded, a);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = cmpgt_epu64(resultAdded, a);
                        //}
                        //else
                        if (Arm.Neon.IsNeonSupported)
                        {
                            cmp = cmpgt_epu64(resultAdded, a);
                        }
                        else
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                                ? cmpgt_epu64(resultAdded, a)
                                : cmpgt_epi64(resultAdded, a);
                        }
                    }

                    if (BurstArchitecture.IsVectorShiftSupported)
                    {
                        result = srlv_epi64(result, andnot_si128(doneMask, set1_epi64x(1L)), inRange: true);
                    }
                    else
                    {
                        result = blendv_si128(srli_epi64(result, 1), result, doneMask);
                    }

                    a = sub_epi64(a, andnot_si128(cmp, resultAdded));
                    result = ternarylogic_si128(cmp, mask, result, TernaryOperation.OxAE);
                    mask = srli_epi64(mask, 2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 sqrt_ep64(v128 a, bool signed, bool useFPU = false, bool promiseDBLrange = false)
            {
                static bool ContinueLoop(v128 doneMask, v128 mask)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    signed |= constexpr.ALL_LT_EPU64(a, 1ul << 63);
                    
                    v128 result;

                    if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F64)
                     || promiseDBLrange)
                    {
                        if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (Sse2.IsSse2Supported)
                            {
                                if (constexpr.ALL_LE_EPU64(a, byte.MaxValue))
                                {
                                    result = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a))));

                                    if (!(constexpr.ALL_NEQ_EPU64(a, 225) || constexpr.ALL_LT_EPU64(a, 225) || constexpr.ALL_GT_EPU64(a, 225)))
                                    {
                                        result = sub_epi64(result, cmpeq_epi64(a, set1_epi64x(225)));
                                    }

                                    constexpr.ASSUME_LE_EPU64(result, 15);

                                    goto RET;
                                }
                            }

                            result = cvttps_epi32(sqrt_ps(cvtepi32_ps(a)));
                            constexpr.ASSUME_LE_EPU64(result, constexpr.ALL_LE_EPU64(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            
                            goto RET;
                        }
                        else
                        {
                            result = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a)));
                            constexpr.ASSUME_LE_EPU64(result, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            
                            goto RET;
                        }
                    }

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        v128 sqrtDbl = sqrt_pd(cvtepu64_pd(a));
                        v128 cvtt = cvttpd_epu64(sqrtDbl);

                        // 64bit division by itself is worse than a pipeline flush
                        // branch evaluation runs in parallel to cvt + sqrt + cvtt (~28 cycles), minimizing branch misprediction penalty
                        if (allfalse_epi128<ulong>(signed ? cmpgt_epi64(a, set1_epi64x(MAX_ACCURATE_INT_SQRT_F64)) : cmpgt_epu64(a, set1_epi64x(MAX_ACCURATE_INT_SQRT_F64)), 2))
                        {
                            return cvtt;
                        }

                        result = srli_epi64(add_epi64(cvtt, div_epu64(a, useFPU ? trunc_pd(sqrtDbl) : cvtt, useFPU: useFPU, bIsDbl: useFPU)), 1);
                        result = add_epi64(result, signed ? cmpgt_epi64(square_epi64(result), a) : cmpgt_epu64(square_epi64(result), a));
                    }
                    else
                    {
                        v128 __a = a;
                        PRELOOP_sqrt_ep64(ref __a, out v128 mask, out result, signed);
                        v128 doneMask;

                        while (ContinueLoop(doneMask = cmpeq_epi64(mask, setzero_si128()), mask))
                        {
                            LOOP_sqrt_ep64(ref __a, ref result, ref mask, doneMask, signed);
                        }
                    }

                    constexpr.ASSUME_LE_EPU64(result, signed ? 3_037_000_499 : uint.MaxValue);

                RET:

                    constexpr.ASSUME_LE_EPU64(result, a);
                    if (constexpr.ALL_GT_EPU64(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(result, a);
                    }

                    constexpr.ASSUME(result.ULong0 * result.ULong0 <= a.ULong0);
                    constexpr.ASSUME(result.ULong1 * result.ULong1 <= a.ULong1);
                    
                    constexpr.ASSUME((UInt128)(result.ULong0 + 1) * (UInt128)(result.ULong0 + 1) > a.ULong0);
                    constexpr.ASSUME((UInt128)(result.ULong1 + 1) * (UInt128)(result.ULong1 + 1) > a.ULong1);
                    
                    constexpr.ASSUME((a.ULong0 <= 1) == (result.ULong0 == a.ULong0));
                    constexpr.ASSUME((a.ULong1 <= 1) == (result.ULong1 == a.ULong1));
                    
                    constexpr.ASSUME((a.ULong0 != 0) == (result.ULong0 > 0));
                    constexpr.ASSUME((a.ULong1 != 0) == (result.ULong1 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void sqrt_ep64x2(v128 a0, v128 a1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, bool promiseDBLrange = false)
            {
                static bool ContinueLoop(v128 doneMask0, v128 doneMask1, v128 mask0, v128 mask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(doneMask0, doneMask1);

                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    if ((constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F64))
                     || promiseDBLrange)
                    {
                        if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (Sse2.IsSse2Supported)
                            {
                                if (constexpr.ALL_LE_EPU64(a0, byte.MaxValue) && constexpr.ALL_LE_EPU64(a1, byte.MaxValue))
                                {
                                    r0 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a0))));
                                    r1 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a1))));

                                    if (!(constexpr.ALL_NEQ_EPU64(a0, 225) || constexpr.ALL_LT_EPU64(a0, 225) || constexpr.ALL_GT_EPU64(a0, 225)))
                                    {
                                        r0 = sub_epi64(r0, cmpeq_epi64(a0, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a1, 225) || constexpr.ALL_LT_EPU64(a1, 225) || constexpr.ALL_GT_EPU64(a1, 225)))
                                    {
                                        r1 = sub_epi64(r1, cmpeq_epi64(a1, set1_epi64x(225)));
                                    }

                                    constexpr.ASSUME_LE_EPU64(r0, 15);
                                    constexpr.ASSUME_LE_EPU64(r1, 15);
                                    
                                    goto RET;
                                }
                            }

                            r0 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a0)));
                            r1 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a1)));
                            constexpr.ASSUME_LE_EPU64(r0, constexpr.ALL_LE_EPU64(a0, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r1, constexpr.ALL_LE_EPU64(a1, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            
                            goto RET;
                        }
                        else
                        {
                            r0 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a0)));
                            r1 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a1)));
                            constexpr.ASSUME_LE_EPU64(r0, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r1, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));

                            goto RET;
                        }
                    }

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        r0 = sqrt_ep64(a0, signed, true);
                        r1 = sqrt_ep64(a1, signed, false);
                    }
                    else
                    {
                        v128 __a0 = a0;
                        v128 __a1 = a1;
                        PRELOOP_sqrt_ep64(ref __a0, out v128 mask0, out r0, signed);
                        PRELOOP_sqrt_ep64(ref __a1, out v128 mask1, out r1, signed);
                        v128 doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                        v128 doneMask1 = cmpeq_epi64(mask1, setzero_si128());

                        while (ContinueLoop(doneMask0, doneMask1, mask0, mask1))
                        {
                            LOOP_sqrt_ep64(ref __a0, ref r0, ref mask0, doneMask0, signed);
                            LOOP_sqrt_ep64(ref __a1, ref r1, ref mask1, doneMask1, signed);
                            doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                            doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                        }
                    }

                    constexpr.ASSUME_LE_EPU64(r0, signed ? 3_037_000_499 : uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r1, signed ? 3_037_000_499 : uint.MaxValue);

                RET:

                    constexpr.ASSUME_LE_EPU64(r0, a0);
                    if (constexpr.ALL_GT_EPU64(a0, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r0, a0);
                    }

                    constexpr.ASSUME_LE_EPU64(r1, a1);
                    if (constexpr.ALL_GT_EPU64(a1, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r1, a1);
                    }

                    constexpr.ASSUME(r0.ULong0 * r0.ULong0 <= a0.ULong0);
                    constexpr.ASSUME(r0.ULong1 * r0.ULong1 <= a0.ULong1);
                    constexpr.ASSUME(r1.ULong0 * r1.ULong0 <= a1.ULong0);
                    constexpr.ASSUME(r1.ULong1 * r1.ULong1 <= a1.ULong1);
                    
                    constexpr.ASSUME((UInt128)(r0.ULong0 + 1) * (UInt128)(r0.ULong0 + 1) > a0.ULong0);
                    constexpr.ASSUME((UInt128)(r0.ULong1 + 1) * (UInt128)(r0.ULong1 + 1) > a0.ULong1);
                    constexpr.ASSUME((UInt128)(r1.ULong0 + 1) * (UInt128)(r1.ULong0 + 1) > a1.ULong0);
                    constexpr.ASSUME((UInt128)(r1.ULong1 + 1) * (UInt128)(r1.ULong1 + 1) > a1.ULong1);
                    
                    constexpr.ASSUME((a0.ULong0 <= 1) == (r0.ULong0 == a0.ULong0));
                    constexpr.ASSUME((a0.ULong1 <= 1) == (r0.ULong1 == a0.ULong1));
                    constexpr.ASSUME((a1.ULong0 <= 1) == (r1.ULong0 == a1.ULong0));
                    constexpr.ASSUME((a1.ULong1 <= 1) == (r1.ULong1 == a1.ULong1));
                    
                    constexpr.ASSUME((a0.ULong0 != 0) == (r0.ULong0 > 0));
                    constexpr.ASSUME((a0.ULong1 != 0) == (r0.ULong1 > 0));
                    constexpr.ASSUME((a1.ULong0 != 0) == (r1.ULong0 > 0));
                    constexpr.ASSUME((a1.ULong1 != 0) == (r1.ULong1 > 0));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void sqrt_ep64x4(v128 a0, v128 a1, v128 a2, v128 a3, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3, bool signed, bool promiseDBLrange = false)
            {
                static bool ContinueLoop(v128 doneMask0, v128 doneMask1, v128 doneMask2, v128 doneMask3, v128 mask0, v128 mask1, v128 mask2, v128 mask3)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(or_si128(mask0, mask1), or_si128(mask2, mask3));

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(and_si128(doneMask0, doneMask1), and_si128(doneMask2, doneMask3));

                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    if ((constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a2, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a3, MAX_ACCURATE_INT_SQRT_F64))
                     || promiseDBLrange)
                    {
                        if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a2, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a3, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (Sse2.IsSse2Supported)
                            {
                                if (constexpr.ALL_LE_EPU64(a0, byte.MaxValue) && constexpr.ALL_LE_EPU64(a1, byte.MaxValue) && constexpr.ALL_LE_EPU64(a2, byte.MaxValue) && constexpr.ALL_LE_EPU64(a3, byte.MaxValue))
                                {
                                    r0 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a0))));
                                    r1 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a1))));
                                    r2 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a2))));
                                    r3 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a3))));

                                    if (!(constexpr.ALL_NEQ_EPU64(a0, 225) || constexpr.ALL_LT_EPU64(a0, 225) || constexpr.ALL_GT_EPU64(a0, 225)))
                                    {
                                        r0 = sub_epi64(r0, cmpeq_epi64(a0, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a1, 225) || constexpr.ALL_LT_EPU64(a1, 225) || constexpr.ALL_GT_EPU64(a1, 225)))
                                    {
                                        r1 = sub_epi64(r1, cmpeq_epi64(a1, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a2, 225) || constexpr.ALL_LT_EPU64(a2, 225) || constexpr.ALL_GT_EPU64(a2, 225)))
                                    {
                                        r2 = sub_epi64(r2, cmpeq_epi64(a2, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a3, 225) || constexpr.ALL_LT_EPU64(a3, 225) || constexpr.ALL_GT_EPU64(a3, 225)))
                                    {
                                        r3 = sub_epi64(r3, cmpeq_epi64(a3, set1_epi64x(225)));
                                    }

                                    constexpr.ASSUME_LE_EPU64(r0, 15);
                                    constexpr.ASSUME_LE_EPU64(r1, 15);
                                    constexpr.ASSUME_LE_EPU64(r2, 15);
                                    constexpr.ASSUME_LE_EPU64(r3, 15);
                                    
                                    goto RET;
                                }
                            }

                            r0 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a0)));
                            r1 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a1)));
                            r2 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a2)));
                            r3 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a3)));
                            constexpr.ASSUME_LE_EPU64(r0, constexpr.ALL_LE_EPU64(a0, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r1, constexpr.ALL_LE_EPU64(a1, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r2, constexpr.ALL_LE_EPU64(a2, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r3, constexpr.ALL_LE_EPU64(a3, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                            goto RET;
                        }
                        else
                        {
                            r0 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a0)));
                            r1 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a1)));
                            r2 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a2)));
                            r3 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a3)));
                            constexpr.ASSUME_LE_EPU64(r0, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r1, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r2, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r3, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            
                            goto RET;
                        }
                    }

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        r0 = sqrt_ep64(a0, signed, true);
                        r1 = sqrt_ep64(a1, signed, true);
                        r2 = sqrt_ep64(a2, signed, false);
                        r3 = sqrt_ep64(a3, signed, false);
                    }
                    else
                    {
                        v128 __a0 = a0;
                        v128 __a1 = a1;
                        v128 __a2 = a2;
                        v128 __a3 = a3;
                        PRELOOP_sqrt_ep64(ref __a0, out v128 mask0, out r0, signed);
                        PRELOOP_sqrt_ep64(ref __a1, out v128 mask1, out r1, signed);
                        PRELOOP_sqrt_ep64(ref __a2, out v128 mask2, out r2, signed);
                        PRELOOP_sqrt_ep64(ref __a3, out v128 mask3, out r3, signed);
                        v128 doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                        v128 doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                        v128 doneMask2 = cmpeq_epi64(mask2, setzero_si128());
                        v128 doneMask3 = cmpeq_epi64(mask3, setzero_si128());

                        while (ContinueLoop(doneMask0, doneMask1, doneMask2, doneMask3, mask0, mask1, mask2, mask3))
                        {
                            LOOP_sqrt_ep64(ref __a0, ref r0, ref mask0, doneMask0, signed);
                            LOOP_sqrt_ep64(ref __a1, ref r1, ref mask1, doneMask1, signed);
                            LOOP_sqrt_ep64(ref __a2, ref r2, ref mask2, doneMask2, signed);
                            LOOP_sqrt_ep64(ref __a3, ref r3, ref mask3, doneMask3, signed);
                            doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                            doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                            doneMask2 = cmpeq_epi64(mask2, setzero_si128());
                            doneMask3 = cmpeq_epi64(mask3, setzero_si128());
                        }
                    }

                    constexpr.ASSUME_LE_EPU64(r0, signed ? 3_037_000_499 : uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r1, signed ? 3_037_000_499 : uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r2, signed ? 3_037_000_499 : uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r3, signed ? 3_037_000_499 : uint.MaxValue);

                RET:

                    constexpr.ASSUME_LE_EPU64(r0, a0);
                    if (constexpr.ALL_GT_EPU64(a0, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r0, a0);
                    }

                    constexpr.ASSUME_LE_EPU64(r1, a1);
                    if (constexpr.ALL_GT_EPU64(a1, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r1, a1);
                    }

                    constexpr.ASSUME_LE_EPU64(r2, a2);
                    if (constexpr.ALL_GT_EPU64(a2, 3))
                    {
                        constexpr.ASSUME_LT_EPU64(r2, a2);
                    }

                    constexpr.ASSUME_LE_EPU64(r3, a3);
                    if (constexpr.ALL_GT_EPU64(a3, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r3, a3);
                    }

                    constexpr.ASSUME(r0.ULong0 * r0.ULong0 <= a0.ULong0);
                    constexpr.ASSUME(r0.ULong1 * r0.ULong1 <= a0.ULong1);
                    constexpr.ASSUME(r1.ULong0 * r1.ULong0 <= a1.ULong0);
                    constexpr.ASSUME(r1.ULong1 * r1.ULong1 <= a1.ULong1);
                    constexpr.ASSUME(r2.ULong0 * r2.ULong0 <= a2.ULong0);
                    constexpr.ASSUME(r2.ULong1 * r2.ULong1 <= a2.ULong1);
                    constexpr.ASSUME(r3.ULong0 * r3.ULong0 <= a3.ULong0);
                    constexpr.ASSUME(r3.ULong1 * r3.ULong1 <= a3.ULong1);
                    
                    constexpr.ASSUME((UInt128)(r0.ULong0 + 1) * (UInt128)(r0.ULong0 + 1) > a0.ULong0);
                    constexpr.ASSUME((UInt128)(r0.ULong1 + 1) * (UInt128)(r0.ULong1 + 1) > a0.ULong1);
                    constexpr.ASSUME((UInt128)(r1.ULong0 + 1) * (UInt128)(r1.ULong0 + 1) > a1.ULong0);
                    constexpr.ASSUME((UInt128)(r1.ULong1 + 1) * (UInt128)(r1.ULong1 + 1) > a1.ULong1);
                    constexpr.ASSUME((UInt128)(r2.ULong0 + 1) * (UInt128)(r2.ULong0 + 1) > a2.ULong0);
                    constexpr.ASSUME((UInt128)(r2.ULong1 + 1) * (UInt128)(r2.ULong1 + 1) > a2.ULong1);
                    constexpr.ASSUME((UInt128)(r3.ULong0 + 1) * (UInt128)(r3.ULong0 + 1) > a3.ULong0);
                    constexpr.ASSUME((UInt128)(r3.ULong1 + 1) * (UInt128)(r3.ULong1 + 1) > a3.ULong1);
                    
                    constexpr.ASSUME((a0.ULong0 <= 1) == (r0.ULong0 == a0.ULong0));
                    constexpr.ASSUME((a0.ULong1 <= 1) == (r0.ULong1 == a0.ULong1));
                    constexpr.ASSUME((a1.ULong0 <= 1) == (r1.ULong0 == a1.ULong0));
                    constexpr.ASSUME((a1.ULong1 <= 1) == (r1.ULong1 == a1.ULong1));
                    constexpr.ASSUME((a2.ULong0 <= 1) == (r2.ULong0 == a2.ULong0));
                    constexpr.ASSUME((a2.ULong1 <= 1) == (r2.ULong1 == a2.ULong1));
                    constexpr.ASSUME((a3.ULong0 <= 1) == (r3.ULong0 == a3.ULong0));
                    constexpr.ASSUME((a3.ULong1 <= 1) == (r3.ULong1 == a3.ULong1));
                    
                    constexpr.ASSUME((a0.ULong0 != 0) == (r0.ULong0 > 0));
                    constexpr.ASSUME((a0.ULong1 != 0) == (r0.ULong1 > 0));
                    constexpr.ASSUME((a1.ULong0 != 0) == (r1.ULong0 > 0));
                    constexpr.ASSUME((a1.ULong1 != 0) == (r1.ULong1 > 0));
                    constexpr.ASSUME((a2.ULong0 != 0) == (r2.ULong0 > 0));
                    constexpr.ASSUME((a2.ULong1 != 0) == (r2.ULong1 > 0));
                    constexpr.ASSUME((a3.ULong0 != 0) == (r3.ULong0 > 0));
                    constexpr.ASSUME((a3.ULong1 != 0) == (r3.ULong1 > 0));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep64([NoAlias] ref v256 a, [NoAlias] out v256 mask, [NoAlias] out v256 result, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1L);
                    v256 TWO = mm256_set1_epi64x(2L);

                    mask = new v256(1ul << 62);
                    mask = mm256_zeromissing_epi64(mask, elements);
                    mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_andnot_si256(ONE, mm256_lzcnt_epi64(a)));
                    mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_and_si256(TWO, signed ? Avx2.mm256_cmpgt_epi64(mask, a) : mm256_cmpgt_epu64(mask, a, elements)));

                    result = mask;
                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(signed ? Avx2.mm256_cmpgt_epi64(mask, a) : mm256_cmpgt_epu64(mask, a, elements), mask));
                    mask = Avx2.mm256_srli_epi64(mask, 2);

                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 resultAdded = Avx2.mm256_or_si256(result, mask);
                        v256 cmp = mm256_cmpgt_epu64(resultAdded, a, elements);
                        v256 tempResult = Avx2.mm256_srli_epi64(result, 1);

                        a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(cmp, resultAdded));
                        tempResult = mm256_ternarylogic_si256(cmp, mask, tempResult, TernaryOperation.OxAE);
                        result = mm256_blendv_si256(tempResult, result, Avx2.mm256_cmpeq_epi64(mask, ZERO));
                        mask = Avx2.mm256_srli_epi64(mask, 2);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep64([NoAlias] ref v256 a, [NoAlias] ref v256 result, [NoAlias] ref v256 mask, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1L);

                    v256 resultAdded = Avx2.mm256_or_si256(result, mask);
                    v256 cmp;
                    if (signed)
                    {
                        cmp = Avx2.mm256_cmpgt_epi64(resultAdded, a);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = mm256_cmpgt_epu64(resultAdded, a, elements);
                        //}
                        //else
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                                ? mm256_cmpgt_epu64(resultAdded, a)
                                : Avx2.mm256_cmpgt_epi64(resultAdded, a);
                        }
                    }
                    result = Avx2.mm256_srlv_epi64(result, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(mask, ZERO), ONE));

                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(cmp, resultAdded));
                    result = mm256_ternarylogic_si256(cmp, mask, result, TernaryOperation.OxAE);
                    mask = Avx2.mm256_srli_epi64(mask, 2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_sqrt_ep64(v256 a, bool signed, byte elements = 4, bool promiseDBLrange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    signed |= constexpr.ALL_LT_EPU64(a, 1ul << 63, elements);

                    v256 result;

                    if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F64, elements)
                     || promiseDBLrange)
                    {
                        if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F32, elements))
                        {
                            if (constexpr.ALL_LE_EPU64(a, byte.MaxValue, elements))
                            {
                                result = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU64(a, 225, elements) || constexpr.ALL_LT_EPU64(a, 225, elements) || constexpr.ALL_GT_EPU64(a, 225, elements)))
                                {
                                    result = Avx2.mm256_sub_epi64(result, Avx2.mm256_cmpeq_epi64(a, mm256_set1_epi64x(225)));
                                }

                                constexpr.ASSUME_LE_EPU64(result, 15);

                                goto RET;
                            }
                            else
                            {
                                result = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                                constexpr.ASSUME_LE_EPU64(result, constexpr.ALL_LE_EPU64(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                                
                                goto RET;
                            }
                        }
                        else
                        {
                            result = mm256_cvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a)), elements);

                            constexpr.ASSUME_LE_EPU64(result, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            
                            goto RET;
                        }
                    }

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        v256 sqrtDbl = Avx.mm256_sqrt_pd(mm256_cvtepu64_pd(a, elements));
                        v256 truncSqrtDbl = mm256_trunc_pd(sqrtDbl);
                        v256 cvtt = mm256_cvttpd_epu64(sqrtDbl, elements);

                        //// 64bit division by itself is worse than a pipeline flush
                        //// branch evaluation runs in parallel to cvt + sqrt + cvtt (~28 cycles), minimizing branch misprediction penalty
                        if (mm256_allfalse_epi256<ulong>(signed ? Avx2.mm256_cmpgt_epi64(a, mm256_set1_epi64x(MAX_ACCURATE_INT_SQRT_F64)) : mm256_cmpgt_epu64(a, mm256_set1_epi64x(MAX_ACCURATE_INT_SQRT_F64)), elements))
                        {
                            return cvtt;
                        }

                        result = mm256_srli_epi64(Avx2.mm256_add_epi64(cvtt, mm256_div_epu64(a, truncSqrtDbl, bIsDbl: true, elements: elements)), 1);
                        result = Avx2.mm256_add_epi64(result, signed ? Avx2.mm256_cmpgt_epi64(mm256_square_epi64(result, elements), a) : mm256_cmpgt_epu64(mm256_square_epi64(result, elements), a, elements));
                    }
                    else
                    {
                        v256 __a = a;
                        PRELOOP_sqrt_ep64(ref __a, out v256 mask, out result, signed, elements);
                        mask = mm256_zeromissing_epi64(mask, elements);

                        while (Hint.Likely(Avx.mm256_testz_si256(mask, mask) == 0))
                        {
                            LOOP_sqrt_ep64(ref __a, ref result, ref mask, signed, elements);
                        }
                    }

                    constexpr.ASSUME_LE_EPU64(result, signed ? 3_037_000_499 : uint.MaxValue, elements);

                RET:

                    constexpr.ASSUME_LE_EPU64(result, a);
                    if (constexpr.ALL_GT_EPU64(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(result, a);
                    }

                    constexpr.ASSUME(result.ULong0 * result.ULong0 <= a.ULong0);
                    constexpr.ASSUME(result.ULong1 * result.ULong1 <= a.ULong1);
                    constexpr.ASSUME(result.ULong2 * result.ULong2 <= a.ULong2);
                    constexpr.ASSUME(result.ULong3 * result.ULong3 <= a.ULong3);
                    
                    constexpr.ASSUME((UInt128)(result.ULong0 + 1) * (UInt128)(result.ULong0 + 1) > a.ULong0);
                    constexpr.ASSUME((UInt128)(result.ULong1 + 1) * (UInt128)(result.ULong1 + 1) > a.ULong1);
                    constexpr.ASSUME((UInt128)(result.ULong2 + 1) * (UInt128)(result.ULong2 + 1) > a.ULong2);
                    constexpr.ASSUME((UInt128)(result.ULong3 + 1) * (UInt128)(result.ULong3 + 1) > a.ULong3);
                    
                    constexpr.ASSUME((a.ULong0 <= 1) == (result.ULong0 == a.ULong0));
                    constexpr.ASSUME((a.ULong1 <= 1) == (result.ULong1 == a.ULong1));
                    constexpr.ASSUME((a.ULong2 <= 1) == (result.ULong2 == a.ULong2));
                    constexpr.ASSUME((a.ULong3 <= 1) == (result.ULong3 == a.ULong3));
                    
                    constexpr.ASSUME((a.ULong0 != 0) == (result.ULong0 > 0));
                    constexpr.ASSUME((a.ULong1 != 0) == (result.ULong1 > 0));
                    constexpr.ASSUME((a.ULong2 != 0) == (result.ULong2 > 0));
                    constexpr.ASSUME((a.ULong3 != 0) == (result.ULong3 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void mm256_sqrt_ep64x2(v256 a0, v256 a1, [NoAlias] out v256 r0, [NoAlias] out v256 r1, bool signed, byte elements = 4, bool promiseDBLrange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if ((constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F64))
                     || promiseDBLrange)
                    {
                        if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (constexpr.ALL_LE_EPU64(a0, byte.MaxValue) && constexpr.ALL_LE_EPU64(a1, byte.MaxValue))
                            {
                                r0 = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a0))));
                                r1 = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a1))));

                                if (!(constexpr.ALL_NEQ_EPU64(a0, 225) || constexpr.ALL_LT_EPU64(a0, 225) || constexpr.ALL_GT_EPU64(a0, 225)))
                                {
                                    r0 = Avx2.mm256_sub_epi64(r0, Avx2.mm256_cmpeq_epi64(a0, mm256_set1_epi64x(225)));
                                }
                                if (!(constexpr.ALL_NEQ_EPU64(a1, 225) || constexpr.ALL_LT_EPU64(a1, 225) || constexpr.ALL_GT_EPU64(a1, 225)))
                                {
                                    r1 = Avx2.mm256_sub_epi64(r1, Avx2.mm256_cmpeq_epi64(a1, mm256_set1_epi64x(225)));
                                }

                                constexpr.ASSUME_LE_EPU64(r0, 15);
                                constexpr.ASSUME_LE_EPU64(r1, 15);

                                goto RET;
                            }
                            else
                            {
                                r0 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a0)));
                                r1 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a1)));

                                constexpr.ASSUME_LE_EPU64(r0, constexpr.ALL_LE_EPU64(a0, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                                constexpr.ASSUME_LE_EPU64(r1, constexpr.ALL_LE_EPU64(a1, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                                goto RET;
                            }
                        }
                        else
                        {
                            r0 = mm256_cvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a0)));
                            r1 = mm256_cvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a1)));

                            constexpr.ASSUME_LE_EPU64(r0, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r1, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));

                            goto RET;
                        }
                    }

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        r0 = mm256_sqrt_ep64(a0, signed, elements);
                        r1 = mm256_sqrt_ep64(a1, signed, elements);
                    }
                    else
                    {
                        v256 __a0 = a0;
                        v256 __a1 = a1;

                        bool signed0 = signed | constexpr.ALL_LT_EPU64(a0, 1ul << 63);
                        bool signed1 = signed | constexpr.ALL_LT_EPU64(a1, 1ul << 63);

                        PRELOOP_sqrt_ep64(ref __a0, out v256 mask0, out r0, signed0, 4);
                        PRELOOP_sqrt_ep64(ref __a1, out v256 mask1, out r1, signed1, 4);

                        mask1 = mm256_zeromissing_epi64(mask1, elements);
                        v256 mask = Avx2.mm256_or_si256(mask0, mask1);
                        
                        while (Hint.Likely(Avx.mm256_testz_si256(mask, mask) == 0))
                        {
                            LOOP_sqrt_ep64(ref __a0, ref r0, ref mask0, signed0, 4);
                            LOOP_sqrt_ep64(ref __a1, ref r1, ref mask1, signed1, 4);

                            mask = Avx2.mm256_or_si256(mask0, mask1);
                        }
                    }

                    constexpr.ASSUME_LE_EPU64(r0, signed ? 3_037_000_499 : uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r1, signed ? 3_037_000_499 : uint.MaxValue);

                RET:

                    constexpr.ASSUME_LE_EPU64(r0, a0);
                    if (constexpr.ALL_GT_EPU64(a0, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r0, a0);
                    }

                    constexpr.ASSUME_LE_EPU64(r1, a1);
                    if (constexpr.ALL_GT_EPU64(a1, 1))
                    {
                        constexpr.ASSUME_LT_EPU64(r1, a1);
                    }

                    constexpr.ASSUME(r0.ULong0 * r0.ULong0 <= a0.ULong0);
                    constexpr.ASSUME(r0.ULong1 * r0.ULong1 <= a0.ULong1);
                    constexpr.ASSUME(r0.ULong2 * r0.ULong2 <= a0.ULong2);
                    constexpr.ASSUME(r0.ULong3 * r0.ULong3 <= a0.ULong3);
                    constexpr.ASSUME(r1.ULong0 * r1.ULong0 <= a1.ULong0);
                    constexpr.ASSUME(r1.ULong1 * r1.ULong1 <= a1.ULong1);
                    constexpr.ASSUME(r1.ULong2 * r1.ULong2 <= a1.ULong2);
                    constexpr.ASSUME(r1.ULong3 * r1.ULong3 <= a1.ULong3);
                    
                    constexpr.ASSUME((UInt128)(r0.ULong0 + 1) * (UInt128)(r0.ULong0 + 1) > a0.ULong0);
                    constexpr.ASSUME((UInt128)(r0.ULong1 + 1) * (UInt128)(r0.ULong1 + 1) > a0.ULong1);
                    constexpr.ASSUME((UInt128)(r0.ULong2 + 1) * (UInt128)(r0.ULong2 + 1) > a0.ULong2);
                    constexpr.ASSUME((UInt128)(r0.ULong3 + 1) * (UInt128)(r0.ULong3 + 1) > a0.ULong3);
                    constexpr.ASSUME((UInt128)(r1.ULong0 + 1) * (UInt128)(r1.ULong0 + 1) > a1.ULong0);
                    constexpr.ASSUME((UInt128)(r1.ULong1 + 1) * (UInt128)(r1.ULong1 + 1) > a1.ULong1);
                    constexpr.ASSUME((UInt128)(r1.ULong2 + 1) * (UInt128)(r1.ULong2 + 1) > a1.ULong2);
                    constexpr.ASSUME((UInt128)(r1.ULong3 + 1) * (UInt128)(r1.ULong3 + 1) > a1.ULong3);
                    
                    constexpr.ASSUME((a0.ULong0 <= 1) == (r0.ULong0 == a0.ULong0));
                    constexpr.ASSUME((a0.ULong1 <= 1) == (r0.ULong1 == a0.ULong1));
                    constexpr.ASSUME((a0.ULong2 <= 1) == (r0.ULong2 == a0.ULong2));
                    constexpr.ASSUME((a0.ULong3 <= 1) == (r0.ULong3 == a0.ULong3));
                    constexpr.ASSUME((a1.ULong0 <= 1) == (r1.ULong0 == a1.ULong0));
                    constexpr.ASSUME((a1.ULong1 <= 1) == (r1.ULong1 == a1.ULong1));
                    constexpr.ASSUME((a1.ULong2 <= 1) == (r1.ULong2 == a1.ULong2));
                    constexpr.ASSUME((a1.ULong3 <= 1) == (r1.ULong3 == a1.ULong3));
                    
                    constexpr.ASSUME((a0.ULong0 != 0) == (r0.ULong0 > 0));
                    constexpr.ASSUME((a0.ULong1 != 0) == (r0.ULong1 > 0));
                    constexpr.ASSUME((a0.ULong2 != 0) == (r0.ULong2 > 0));
                    constexpr.ASSUME((a0.ULong3 != 0) == (r0.ULong3 > 0));
                    constexpr.ASSUME((a1.ULong0 != 0) == (r1.ULong0 > 0));
                    constexpr.ASSUME((a1.ULong1 != 0) == (r1.ULong1 > 0));
                    constexpr.ASSUME((a1.ULong2 != 0) == (r1.ULong2 > 0));
                    constexpr.ASSUME((a1.ULong3 != 0) == (r1.ULong3 > 0));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi128(v128 aLo, v128 aHi, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return sqrt_ep128(aLo, aHi, signed: true, nonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu128(v128 aLo, v128 aHi, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return sqrt_ep128(aLo, aHi, signed: false, nonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epi128x2(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    sqrt_ep128x2(aLo, aHi, bLo, bHi, out r0, out r1, signed: true, nonZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epu128x2(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    sqrt_ep128x2(aLo, aHi, bLo, bHi, out r0, out r1, signed: false, nonZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi128(v256 aLo, v256 aHi, bool nonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep128(aLo, aHi, signed: true, nonZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu128(v256 aLo, v256 aHi, bool nonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep128(aLo, aHi, signed: false, nonZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep128([NoAlias] ref v128 aLo, [NoAlias] ref v128 aHi, [NoAlias] out v128 maskLo, [NoAlias] out v128 maskHi, [NoAlias] out v128 resultLo, [NoAlias] out v128 resultHi, bool signed)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1L);
                    v128 TWO = set1_epi64x(2L);

                    maskLo = set1_epi64x(((UInt128)1 << 126).lo64);
                    maskHi = set1_epi64x(((UInt128)1 << 126).hi64);
                    srlv_epi128(maskLo, maskHi, andnot_si128(ONE, lzcnt_epi128(aLo, aHi)), out maskLo, out maskHi, inRange: constexpr.ALL_NEQ_EPU64(or_si128(aLo, aHi), 0));
                    srlv_epi128(maskLo, maskHi, and_si128(TWO, signed ? cmpgt_epi128(maskLo, maskHi, aLo, aHi) : cmpgt_epu128(maskLo, maskHi, aLo, aHi)), out maskLo, out maskHi, inRange: true);

                    resultLo = maskLo;
                    resultHi = maskHi;
                    v128 subLo = andnot_si128(signed ? cmpgt_epi128(maskLo, maskHi, aLo, aHi) : cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskLo);
                    v128 subHi = andnot_si128(signed ? cmpgt_epi128(maskLo, maskHi, aLo, aHi) : cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskHi);
                    sub_epi128(aLo, aHi, subLo, subHi, out aLo, out aHi);
                    srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);

                    v128 doneMask;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (Arm.Neon.IsNeonSupported)
                    {
                        ;
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                        {
                            doneMask = cmpeq_epi128(maskLo, maskHi, ZERO, ZERO);

                            v128 resultAddedLo = or_si128(resultLo, maskLo);
                            v128 resultAddedHi = or_si128(resultHi, maskHi);
                            srli_epi128(resultLo, resultHi, 1, out v128 tempResultLo, out v128 tempResultHi);
                            v128 cmp = cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);

                            sub_epi128(aLo, aHi, andnot_si128(cmp, resultAddedLo), andnot_si128(cmp, resultAddedHi), out aLo, out aHi);
                            tempResultLo = ternarylogic_si128(cmp, maskLo, tempResultLo, TernaryOperation.OxAE);
                            tempResultHi = ternarylogic_si128(cmp, maskHi, tempResultHi, TernaryOperation.OxAE);
                            resultLo = blendv_si128(tempResultLo, resultLo, doneMask);
                            resultHi = blendv_si128(tempResultHi, resultHi, doneMask);

                            srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep128([NoAlias] ref v128 aLo, [NoAlias] ref v128 aHi, [NoAlias] ref v128 resultLo, [NoAlias] ref v128 resultHi, [NoAlias] ref v128 maskLo, [NoAlias] ref v128 maskHi, v128 doneMask, bool signed)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 resultAddedLo = or_si128(resultLo, maskLo);
                    v128 resultAddedHi = or_si128(resultHi, maskHi);
                    v128 cmp;
                    if (signed)
                    {
                        cmp = cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        //}
                        //else
                        if (Arm.Neon.IsNeonSupported)
                        {
                            cmp = cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        }
                        else
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                                ? cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi)
                                : cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi);
                        }
                    }

                    if (BurstArchitecture.IsVectorShiftSupported)
                    {
                        srlv_epi128(resultLo, resultHi, andnot_si128(doneMask, set1_epi64x(1L)), out resultLo, out resultHi, inRange: true);
                    }
                    else
                    {
                        srli_epi128(resultLo, resultHi, 1, out v128 shiftedLo, out v128 shiftedHi);

                        resultLo = blendv_si128(shiftedLo, resultLo, doneMask);
                        resultHi = blendv_si128(shiftedHi, resultHi, doneMask);
                    }

                    sub_epi128(aLo, aHi, andnot_si128(cmp, resultAddedLo), andnot_si128(cmp, resultAddedHi), out aLo, out aHi);
                    resultLo = ternarylogic_si128(cmp, maskLo, resultLo, TernaryOperation.OxAE);
                    resultHi = ternarylogic_si128(cmp, maskHi, resultHi, TernaryOperation.OxAE);
                    srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 sqrt_ep128(v128 aLo, v128 aHi, bool signed, bool nonZero = false, bool useFPU = false)
            {
                static bool ContinueLoop(v128 doneMask, v128 maskLo, v128 maskHi)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(maskLo, maskHi);

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU64(aHi, 0))
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return sqrt_ep64(aLo, signed, useFPU: false);
                        }
                        else
                        {
                            return sqrt_ep64(aLo, signed, useFPU: true);
                        }
                    }

                    v128 __aLo = aLo;
                    v128 __aHi = aHi;
                    v128 result;
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        v128 sqrtDbl = sqrt_pd(cvtepu128_pd(__aLo, __aHi));
                        v128 vLo;
                        v128 vHi;
                        if (signed)
                        {
                            vLo = cvttpd_epu64(sqrtDbl);
                            vHi = setzero_si128();
                        }
                        else
                        {
                            cvttpd_epu128(sqrtDbl, out vLo, out vHi);
                        }

                        v128 qLo;
                        v128 qHi;
                        if (useFPU)
                        {
                            if (!constexpr.ALL_NEQ_EPU64(__aHi, 0))
                            {
                                sqrtDbl = trunc_pd(sqrtDbl);
                            }

                            if (!nonZero)
                            {
                                v128 isZero = cmpeq_epi64(or_si128(__aLo, __aHi), setzero_si128());
                                sqrtDbl = or_si128(sqrtDbl, isZero);
                            }

                            divremepu128_epu64(__aLo, __aHi, sqrtDbl, out qLo, out qHi, out _, useFPU: true, bIsDbl: true, clampbDblToMaxValue: !signed);
                        }
                        else
                        {
                            v128 cvtt = cvttpd_epu64(sqrtDbl);
                            cvtt = or_si128(cvtt, cmpge_pd(sqrtDbl, set1_pd(ulong.MaxValue)));
                            UInt128 x = new UInt128(__aLo.ULong0, __aHi.ULong0);
                            UInt128 y = new UInt128(__aLo.ULong1, __aHi.ULong1);

                            if (!nonZero)
                            {
                                v128 isZero = cmpeq_epi64(or_si128(__aLo, __aHi), setzero_si128());
                                cvtt = or_si128(cvtt, isZero);

                                x /= cvtt.ULong0;
                                y /= cvtt.ULong1;
                            }
                            else
                            {
                                x /= cvtt.ULong0;
                                y /= cvtt.ULong1;
                            }

                            qLo = new v128(x.lo64, y.lo64);
                            qHi = new v128(x.hi64, y.hi64);
                        }

                        add_epi128(vLo, vHi, qLo, qHi, out vLo, out vHi);
                        srli_epi128(vLo, vHi, 1, out vLo, out vHi);

                        square_epi128(vLo, vHi, out v128 sqTestLo, out v128 sqTestHi);
                        v128 overshoot = cmpgt_epu128(sqTestLo, sqTestHi, __aLo, __aHi);
                        vLo = add_epi64(vLo, overshoot);

                        if (signed)
                        {
                            result = vLo;
                        }
                        else
                        {
                            v128 noOvershoot = cmpeq_epi64(vHi, setzero_si128());
                            result = ornot_si128(noOvershoot, vLo);
                        }
                    }
                    else
                    {
                        PRELOOP_sqrt_ep128(ref __aLo, ref __aHi, out v128 maskLo, out v128 maskHi, out v128 resultLo, out v128 resultHi, signed);
                        v128 doneMask;

                        while (ContinueLoop(doneMask = cmpeq_epi128(maskLo, maskHi, setzero_si128(), setzero_si128()), maskLo, maskHi))
                        {
                            LOOP_sqrt_ep128(ref __aLo, ref __aHi, ref resultLo, ref resultHi, ref maskLo, ref maskHi, doneMask, signed);
                        }

                        result = resultLo;
                    }

                    if (signed)
                    {
                        constexpr.ASSUME_LE_EPU64(result, 13_043_817_825_332_782_212ul);
                    }

                    constexpr.ASSUME(result.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    constexpr.ASSUME(result.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong0, aHi.ULong0) > 1))
                    {
                        constexpr.ASSUME(result.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    }
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong1, aHi.ULong1) > 1))
                    {
                        constexpr.ASSUME(result.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    }

                    constexpr.ASSUME((UInt128)result.ULong0 * result.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    constexpr.ASSUME((UInt128)result.ULong1 * result.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    
                    //constexpr.ASSUME((__UInt256__)(result.ULong0 + 1) * (__UInt256__)(result.ULong0 + 1) > new UInt128(aLo.ULong0, aHi.ULong0));
                    //constexpr.ASSUME((__UInt256__)(result.ULong1 + 1) * (__UInt256__)(result.ULong1 + 1) > new UInt128(aLo.ULong1, aHi.ULong1));
                    
                    constexpr.ASSUME((new UInt128(aLo.ULong0, aHi.ULong0) <= 1) == (result.ULong0 == new UInt128(aLo.ULong0, aHi.ULong0)));
                    constexpr.ASSUME((new UInt128(aLo.ULong1, aHi.ULong1) <= 1) == (result.ULong1 == new UInt128(aLo.ULong1, aHi.ULong1)));
                    
                    constexpr.ASSUME((new UInt128(aLo.ULong0, aHi.ULong0) != 0) == (result.ULong0 > 0));
                    constexpr.ASSUME((new UInt128(aLo.ULong1, aHi.ULong1) != 0) == (result.ULong1 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void sqrt_ep128x2(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, bool nonZero = false, byte elements = 4)
            {
                static bool ContinueLoop(v128 doneMaskA, v128 doneMaskB, v128 maskALo, v128 maskAHi, v128 maskBLo, v128 maskBHi)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 maskA = or_si128(maskALo, maskAHi);
                        v128 maskB = or_si128(maskBLo, maskBHi);
                        v128 mask  = or_si128(maskA, maskB);

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<long>(and_si128(doneMaskA, doneMaskB)));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 __aLo = aLo; 
                    v128 __aHi = aHi; 
                    v128 __bLo = bLo; 
                    v128 __bHi = bHi;
                    if (constexpr.ALL_EQ_EPU64(__aHi, 0) && constexpr.ALL_EQ_EPU64(__bHi, 0))
                    {
                        sqrt_ep64x2(__aLo, __bLo, out r0, out r1, signed);

                        return;
                    }


                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        r0 = sqrt_ep128(__aLo, __aHi, signed, nonZero, useFPU: true);
                        r1 = sqrt_ep128(__bLo, __bHi, signed, nonZero, useFPU: false);
                    }
                    else
                    {
                        PRELOOP_sqrt_ep128(ref __aLo, ref __aHi, out v128 maskALo, out v128 maskAHi, out r0, out v128 resultAHi, signed);
                        PRELOOP_sqrt_ep128(ref __bLo, ref __bHi, out v128 maskBLo, out v128 maskBHi, out r1, out v128 resultBHi, signed);
                        v128 doneMaskA;
                        v128 doneMaskB;

                        if (Sse4_1.IsSse41Supported)
                        {
                            maskBHi = zeromissing_epi32(maskBHi, (byte)(elements == 3 ? 2 : 4));
                        }

                        while (ContinueLoop(doneMaskA = cmpeq_epi128(maskALo, maskAHi, setzero_si128(), setzero_si128()),
                                            doneMaskB = cmpeq_epi128(maskBLo, maskBHi, setzero_si128(), setzero_si128()),
                                            maskALo, maskAHi,
                                            maskBLo, maskBHi))
                        {
                            LOOP_sqrt_ep128(ref __aLo, ref __aHi, ref r0, ref resultAHi, ref maskALo, ref maskAHi, doneMaskA, signed);
                            LOOP_sqrt_ep128(ref __bLo, ref __bHi, ref r1, ref resultBHi, ref maskBLo, ref maskBHi, doneMaskB, signed);
                        }
                    }

                    if (signed)
                    {
                        constexpr.ASSUME_LE_EPU64(r0, 13_043_817_825_332_782_212ul);
                        constexpr.ASSUME_LE_EPU64(r1, 13_043_817_825_332_782_212ul, (byte)(elements - 2));
                    }

                    constexpr.ASSUME(r0.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    constexpr.ASSUME(r0.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong0, aHi.ULong0) > 1))
                    {
                        constexpr.ASSUME(r0.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    }
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong1, aHi.ULong1) > 1))
                    {
                        constexpr.ASSUME(r0.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    }

                    constexpr.ASSUME(r1.ULong0 <= new UInt128(bLo.ULong0, bHi.ULong0));
                    constexpr.ASSUME(r1.ULong1 <= new UInt128(bLo.ULong1, bHi.ULong1));
                    if (constexpr.IS_TRUE(new UInt128(bLo.ULong0, bHi.ULong0) > 1))
                    {
                        constexpr.ASSUME(r1.ULong0 <= new UInt128(bLo.ULong0, bHi.ULong0));
                    }
                    if (constexpr.IS_TRUE(new UInt128(bLo.ULong1, bHi.ULong1) > 1))
                    {
                        constexpr.ASSUME(r1.ULong1 <= new UInt128(bLo.ULong1, bHi.ULong1));
                    }

                    constexpr.ASSUME((UInt128)r0.ULong0 * r0.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    constexpr.ASSUME((UInt128)r0.ULong1 * r0.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    constexpr.ASSUME((UInt128)r1.ULong0 * r1.ULong0 <= new UInt128(bLo.ULong0, bHi.ULong0));
                    constexpr.ASSUME((UInt128)r1.ULong1 * r1.ULong1 <= new UInt128(bLo.ULong1, bHi.ULong1));
                    
                    //constexpr.ASSUME((UInt256)(r0.ULong0 + 1) * (UInt256)(r0.ULong0 + 1) > new UInt128(aLo.ULong0, aHi.ULong0));
                    //constexpr.ASSUME((UInt256)(r0.ULong1 + 1) * (UInt256)(r0.ULong1 + 1) > new UInt128(aLo.ULong1, aHi.ULong1));
                    //constexpr.ASSUME((UInt256)(r1.ULong0 + 1) * (UInt256)(r1.ULong0 + 1) > new UInt128(bLo.ULong0, bHi.ULong0));
                    //constexpr.ASSUME((UInt256)(r1.ULong1 + 1) * (UInt256)(r1.ULong1 + 1) > new UInt128(bLo.ULong1, bHi.ULong1));
                    
                    constexpr.ASSUME((new UInt128(aLo.ULong0, aHi.ULong0) <= 1) == (r0.ULong0 == new UInt128(aLo.ULong0, aHi.ULong0)));
                    constexpr.ASSUME((new UInt128(aLo.ULong1, aHi.ULong1) <= 1) == (r0.ULong1 == new UInt128(aLo.ULong1, aHi.ULong1)));
                    constexpr.ASSUME((new UInt128(bLo.ULong0, bHi.ULong0) <= 1) == (r1.ULong0 == new UInt128(bLo.ULong0, bHi.ULong0)));
                    constexpr.ASSUME((new UInt128(bLo.ULong1, bHi.ULong1) <= 1) == (r1.ULong1 == new UInt128(bLo.ULong1, bHi.ULong1)));
                    
                    constexpr.ASSUME((new UInt128(aLo.ULong0, aHi.ULong0) != 0) == (r0.ULong0 > 0));
                    constexpr.ASSUME((new UInt128(aLo.ULong1, aHi.ULong1) != 0) == (r0.ULong1 > 0));
                    constexpr.ASSUME((new UInt128(bLo.ULong0, bHi.ULong0) != 0) == (r1.ULong0 > 0));
                    constexpr.ASSUME((new UInt128(bLo.ULong1, bHi.ULong1) != 0) == (r1.ULong1 > 0));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep128([NoAlias] ref v256 aLo, [NoAlias] ref v256 aHi, [NoAlias] out v256 maskLo, [NoAlias] out v256 maskHi, [NoAlias] out v256 resultLo, [NoAlias] out v256 resultHi, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1L);
                    v256 TWO = mm256_set1_epi64x(2L);

                    maskLo = mm256_set1_epi64x(((UInt128)1 << 126).lo64);
                    maskHi = mm256_set1_epi64x(((UInt128)1 << 126).hi64);
                    mm256_srlv_epi128(maskLo, maskHi, Avx2.mm256_andnot_si256(ONE, mm256_lzcnt_epi128(aLo, aHi)), out maskLo, out maskHi, elements: elements);
                    mm256_srlv_epi128(maskLo, maskHi, Avx2.mm256_and_si256(TWO, signed ? mm256_cmpgt_epi128(maskLo, maskHi, aLo, aHi, elements: elements) : mm256_cmpgt_epu128(maskLo, maskHi, aLo, aHi, elements: elements)), out maskLo, out maskHi, elements: elements);

                    resultLo = maskLo;
                    resultHi = maskHi;
                    v256 subLo = Avx2.mm256_andnot_si256(signed ? mm256_cmpgt_epi128(maskLo, maskHi, aLo, aHi, elements: elements) : mm256_cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskLo);
                    v256 subHi = Avx2.mm256_andnot_si256(signed ? mm256_cmpgt_epi128(maskLo, maskHi, aLo, aHi, elements: elements) : mm256_cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskHi);
                    mm256_sub_epi128(aLo, aHi, subLo, subHi, out aLo, out aHi, elements: elements);
                    mm256_srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi, elements: elements);

                    v256 doneMask;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        doneMask = mm256_cmpeq_epi128(maskLo, maskHi, ZERO, ZERO, elements: elements);

                        v256 resultAddedLo = Avx2.mm256_or_si256(resultLo, maskLo);
                        v256 resultAddedHi = Avx2.mm256_or_si256(resultHi, maskHi);
                        mm256_srli_epi128(resultLo, resultHi, 1, out v256 tempResultLo, out v256 tempResultHi, elements: elements);
                        v256 cmp = mm256_cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi, elements: elements);

                        mm256_sub_epi128(aLo, aHi, Avx2.mm256_andnot_si256(cmp, resultAddedLo), Avx2.mm256_andnot_si256(cmp, resultAddedHi), out aLo, out aHi, elements: elements);
                        tempResultLo = mm256_ternarylogic_si256(cmp, maskLo, tempResultLo, TernaryOperation.OxAE);
                        tempResultHi = mm256_ternarylogic_si256(cmp, maskHi, tempResultHi, TernaryOperation.OxAE);
                        resultLo = mm256_blendv_si256(tempResultLo, resultLo, doneMask);
                        resultHi = mm256_blendv_si256(tempResultHi, resultHi, doneMask);

                        mm256_srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi, elements: elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep128([NoAlias] ref v256 aLo, [NoAlias] ref v256 aHi, [NoAlias] ref v256 resultLo, [NoAlias] ref v256 resultHi, [NoAlias] ref v256 maskLo, [NoAlias] ref v256 maskHi, v256 doneMask, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 resultAddedLo = Avx2.mm256_or_si256(resultLo, maskLo);
                    v256 resultAddedHi = Avx2.mm256_or_si256(resultHi, maskHi);
                    v256 cmp;
                    if (signed)
                    {
                        cmp = mm256_cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi, elements: elements);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = mm256_cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        //}
                        //else
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size
                                ? mm256_cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi, elements: elements)
                                : mm256_cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi, elements: elements);
                        }
                    }

                    mm256_srlv_epi128(resultLo, resultHi, Avx2.mm256_andnot_si256(doneMask, mm256_set1_epi64x(1L)), out resultLo, out resultHi, elements: elements);
                    mm256_sub_epi128(aLo, aHi, Avx2.mm256_andnot_si256(cmp, resultAddedLo), Avx2.mm256_andnot_si256(cmp, resultAddedHi), out aLo, out aHi, elements: elements);
                    resultLo = mm256_ternarylogic_si256(cmp, maskLo, resultLo, TernaryOperation.OxAE);
                    resultHi = mm256_ternarylogic_si256(cmp, maskHi, resultHi, TernaryOperation.OxAE);
                    mm256_srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi, elements: elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_sqrt_ep128(v256 aLo, v256 aHi, bool signed, bool nonZero = false, byte elements = 4)
            {
                static bool ContinueLoop(v256 maskLo, v256 maskHi)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 mask = Avx2.mm256_or_si256(maskLo, maskHi);

                        return Hint.Likely(Avx.mm256_testz_si256(mask, mask) == 0);
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    v256 __aLo = aLo;
                    v256 __aHi = aHi;

                    if (constexpr.ALL_EQ_EPU64(__aHi, 0, elements))
                    {
                        return mm256_sqrt_ep64(__aLo, signed, elements);
                    }

                    v256 result;
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        v256 sqrtDbl = Avx.mm256_sqrt_pd(mm256_cvtepu128_pd(__aLo, __aHi, elements));
                        v256 vLo;
                        v256 vHi;
                        if (signed)
                        {
                            vLo = mm256_cvttpd_epu64(sqrtDbl, elements);
                            vHi = Avx.mm256_setzero_si256();
                        }
                        else
                        {
                            mm256_cvttpd_epu128(sqrtDbl, out vLo, out vHi, elements);
                        }

                        if (!constexpr.ALL_NEQ_EPU64(__aHi, 0, elements))
                        {
                            sqrtDbl = mm256_trunc_pd(sqrtDbl);
                        }

                        if (!nonZero)
                        {
                            v256 isZero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_or_si256(__aLo, __aHi), Avx.mm256_setzero_si256());
                            sqrtDbl = Avx2.mm256_or_si256(sqrtDbl, isZero);
                        }

                        mm256_divremepu128_epu64(__aLo, __aHi, sqrtDbl, out v256 qLo, out v256 qHi, out _, bIsDbl: true, clampbDblToMaxValue: !signed, elements: elements);
                        mm256_add_epi128(vLo, vHi, qLo, qHi, out vLo, out vHi, elements: elements);
                        mm256_srli_epi128(vLo, vHi, 1, out vLo, out vHi, elements: elements);

                        mm256_square_epi128(vLo, vHi, out v256 sqTestLo, out v256 sqTestHi, elements: elements);
                        v256 overshoot = mm256_cmpgt_epu128(sqTestLo, sqTestHi, __aLo, __aHi, elements: elements);
                        vLo = Avx2.mm256_add_epi64(vLo, overshoot);

                        if (signed)
                        {
                            result = vLo;
                        }
                        else
                        {
                            v256 noOvershoot = Avx2.mm256_cmpeq_epi64(vHi, Avx.mm256_setzero_si256());
                            result = mm256_ornot_si256(noOvershoot, vLo);
                        }
                    }
                    else
                    {
                        PRELOOP_sqrt_ep128(ref __aLo, ref __aHi, out v256 maskLo, out v256 maskHi, out v256 resultLo, out v256 resultHi, signed, elements);
                        v256 doneMask;
                        maskHi = mm256_zeromissing_epi64(maskHi, elements);

                        while (ContinueLoop(maskLo, maskHi))
                        {
                            doneMask = mm256_cmpeq_epi128(maskLo, maskHi, Avx.mm256_setzero_si256(), Avx.mm256_setzero_si256(), elements);
                            LOOP_sqrt_ep128(ref __aLo, ref __aHi, ref resultLo, ref resultHi, ref maskLo, ref maskHi, doneMask, signed, elements);
                        }

                        result = resultLo;
                    }

                    if (signed)
                    {
                        constexpr.ASSUME_LE_EPU64(result, 13_043_817_825_332_782_212ul, elements);
                    }

                    constexpr.ASSUME(result.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    constexpr.ASSUME(result.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    constexpr.ASSUME(result.ULong2 <= new UInt128(aLo.ULong2, aHi.ULong2));
                    constexpr.ASSUME(result.ULong3 <= new UInt128(aLo.ULong3, aHi.ULong3));
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong0, aHi.ULong0) > 1))
                    {
                        constexpr.ASSUME(result.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    }
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong1, aHi.ULong1) > 1))
                    {
                        constexpr.ASSUME(result.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    }
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong2, aHi.ULong2) > 1))
                    {
                        constexpr.ASSUME(result.ULong2 <= new UInt128(aLo.ULong2, aHi.ULong2));
                    }
                    if (constexpr.IS_TRUE(new UInt128(aLo.ULong3, aHi.ULong3) > 1))
                    {
                        constexpr.ASSUME(result.ULong3 <= new UInt128(aLo.ULong3, aHi.ULong3));
                    }

                    constexpr.ASSUME((UInt128)result.ULong0 * result.ULong0 <= new UInt128(aLo.ULong0, aHi.ULong0));
                    constexpr.ASSUME((UInt128)result.ULong1 * result.ULong1 <= new UInt128(aLo.ULong1, aHi.ULong1));
                    constexpr.ASSUME((UInt128)result.ULong2 * result.ULong2 <= new UInt128(aLo.ULong2, aHi.ULong2));
                    constexpr.ASSUME((UInt128)result.ULong3 * result.ULong3 <= new UInt128(aLo.ULong3, aHi.ULong3));
                    
                    //constexpr.ASSUME((UInt256)(result.ULong0 + 1) * (UInt256)(result.ULong0 + 1) > new UInt128(aLo.ULong0, aHi.ULong0));
                    //constexpr.ASSUME((UInt256)(result.ULong1 + 1) * (UInt256)(result.ULong1 + 1) > new UInt128(aLo.ULong1, aHi.ULong1));
                    //constexpr.ASSUME((UInt256)(result.ULong2 + 1) * (UInt256)(result.ULong2 + 1) > new UInt128(aLo.ULong2, aHi.ULong2));
                    //constexpr.ASSUME((UInt256)(result.ULong3 + 1) * (UInt256)(result.ULong3 + 1) > new UInt128(aLo.ULong3, aHi.ULong3));
                    
                    constexpr.ASSUME((new UInt128(aLo.ULong0, aHi.ULong0) <= 1) == (result.ULong0 == new UInt128(aLo.ULong0, aHi.ULong0)));
                    constexpr.ASSUME((new UInt128(aLo.ULong1, aHi.ULong1) <= 1) == (result.ULong1 == new UInt128(aLo.ULong1, aHi.ULong1)));
                    constexpr.ASSUME((new UInt128(aLo.ULong2, aHi.ULong2) <= 1) == (result.ULong2 == new UInt128(aLo.ULong2, aHi.ULong2)));
                    constexpr.ASSUME((new UInt128(aLo.ULong3, aHi.ULong3) <= 1) == (result.ULong3 == new UInt128(aLo.ULong3, aHi.ULong3)));
                    
                    constexpr.ASSUME((new UInt128(aLo.ULong0, aHi.ULong0) != 0) == (result.ULong0 > 0));
                    constexpr.ASSUME((new UInt128(aLo.ULong1, aHi.ULong1) != 0) == (result.ULong1 > 0));
                    constexpr.ASSUME((new UInt128(aLo.ULong2, aHi.ULong2) != 0) == (result.ULong2 > 0));
                    constexpr.ASSUME((new UInt128(aLo.ULong3, aHi.ULong3) != 0) == (result.ULong3 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte bytesqrt(byte x, bool unsigned)
        {
#if !TESTING
            if (Sse2.IsSse2Supported)
            {
                v128 mov = Xse.cvtsi32_si128(x);

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                    {
                        return unsigned ? Xse.sqrt_sqrthi4correction_epu8(mov, 16).Byte0
                                        : Xse.sqrt_sqrthi4correction_epi8(mov, 16).Byte0;
                    }
                }

                v128 sqrt = Xse.rcp_ss(Xse.rsqrt_ss(Xse.cvtepi32_ps(mov)));
                v128 toInt = Xse.cvttps_epi32(sqrt);
                
                if (unsigned)
                {
                    return (byte)(Xse.cvtsi128_si32(toInt) + tobyte(x == 225));
                }
                else
                {
                    return (byte)Xse.cvtsi128_si32(toInt);
                }
            }
            else
#endif
            {
                return (byte)sqrt(x);
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="__x"/>⌋ of a <see cref="UInt128"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> will <see langword="throw"/> an Exception for any <paramref name="__x"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(UInt128 x, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return intsqrt(x.lo64);
            }

            UInt128 __x = x;
            ulong result;
            
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
            {
                if (BurstArchitecture.IsX86Win64Supported)
                {
                    double sqrtDbl = sqrt((double)__x);

                    if (!(nonZero.Promises(Promise.NonZero) || __x.IsNotZero))
                    {
                        if (__x.IsZero)
                        {
                            return 0;
                        }
                    }

                    UInt128 v = (UInt128)sqrtDbl;
                    ulong v64 = select(v.lo64, ulong.MaxValue, sqrtDbl >= ulong.MaxValue);

                    v = (v + (__x / v64)) >> 1;
                    bool overshoot = v.hi64 != 0;

                    result = select(v.lo64 - tobyte(square(v) > __x), ulong.MaxValue, overshoot);
            
                    constexpr.ASSUME(result <= __x);
                    if (constexpr.IS_TRUE(__x > 1))
                    {
                        constexpr.ASSUME(result < __x);
                    }

                    return result;
                }
            }

            UInt128 result128 = 0;
            UInt128 mask = (UInt128)1 << 126;
            
            mask >>= lzcnt(__x) & (-1 << 1);
            if (Hint.Likely(mask > __x))
            {
                mask >>= 2;
            }
            
            if (__x >= mask)
            {
                __x -= mask;
                result128 = mask;
            }
            
            mask >>= 2;
            
            while (mask != 0)
            {
                UInt128 resultAdded = result128 | mask;
                result128 >>= 1;
            
                if (__x >= resultAdded)
                {
                    __x -= resultAdded;
                    result128 |= mask;
                }
            
                mask >>= 2;
            }
            
            result = result128.lo64;
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            //constexpr.ASSUME((result + 1) * (result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="__x"/>⌋ of a non-negative <see cref="Int128"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> will <see langword="throw"/> an Exception for any <paramref name="__x"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 13_043_817_825_332_782_212ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(Int128 x, Promise nonZero = Promise.Nothing)
        {
Assert.IsNotSmaller(x, 0);
constexpr.ASSUME(x >= 0);

            if (constexpr.IS_TRUE(x.hi64 == 0))
            {
                return intsqrt(x.lo64);
            }

            Int128 __x = x;
            ulong result;

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong v = (ulong)sqrt((double)(UInt128)__x);

                if (!(nonZero.Promises(Promise.NonZero) || __x.IsNotZero))
                {
                    if (__x.IsZero)
                    {
                        return 0;
                    }
                }

                v = ((v + ((UInt128)__x / v)) >> 1).lo64;

                result = v - tobyte(square((UInt128)v) > (UInt128)__x);
            }
            else
            {
                result = intsqrt((UInt128)__x);
            }
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            //constexpr.ASSUME((result + 1) * (result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 15ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte intsqrt(byte x)
        {
            byte result = bytesqrt(x, unsigned: true);
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            constexpr.ASSUME((result + 1) * (result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intsqrt(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu8(x, 2);
            }
            else
            {
                return (byte2)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intsqrt(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu8(x, 3);
            }
            else
            {
                return (byte3)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intsqrt(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu8(x, 4);
            }
            else
            {
                return (byte4)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intsqrt(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu8(x, 8);
            }
            else
            {
                return (byte8)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intsqrt(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu8(x, 16);
            }
            else
            {
                return new byte16((byte8)sqrt(x.v8_0), (byte8)sqrt(x.v8_8));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intsqrt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu8(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new byte32(Xse.sqrt_epu8(x.v16_0, 16), Xse.sqrt_epu8(x.v16_16, 16));
            }
            else
            {
                return new byte32((byte8)sqrt(x.v8_0), (byte8)sqrt(x.v8_8), (byte8)sqrt(x.v8_16), (byte8)sqrt(x.v8_24));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0, 11)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte intsqrt(sbyte x)
        {
Assert.IsNonNegative(x);
constexpr.ASSUME(x >= 0);

            sbyte result = (sbyte)bytesqrt((byte)x, unsigned: false);
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            constexpr.ASSUME((result + 1) * (result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intsqrt(sbyte2 x)
        {
VectorAssert.IsNotSmaller<sbyte2, sbyte>(x, 0, 2);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi8(x, 2);
            }
            else
            {
                return (sbyte2)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intsqrt(sbyte3 x)
        {
VectorAssert.IsNotSmaller<sbyte3, sbyte>(x, 0, 3);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi8(x, 3);
            }
            else
            {
                return (sbyte3)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intsqrt(sbyte4 x)
        {
VectorAssert.IsNotSmaller<sbyte4, sbyte>(x, 0, 4);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi8(x, 4);
            }
            else
            {
                return (sbyte4)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intsqrt(sbyte8 x)
        {
VectorAssert.IsNotSmaller<sbyte8, sbyte>(x, 0, 8);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi8(x, 8);
            }
            else
            {
                return (sbyte8)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intsqrt(sbyte16 x)
        {
VectorAssert.IsNotSmaller<sbyte16, sbyte>(x, 0, 16);
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi8(x, 16);
            }
            else
            {
                return new sbyte16((sbyte8)sqrt(x.v8_0), (sbyte8)sqrt(x.v8_8));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intsqrt(sbyte32 x)
        {
VectorAssert.IsNotSmaller<sbyte32, sbyte>(x, 0, 32);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi8(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new sbyte32(Xse.sqrt_epi8(x.v16_0, 16), Xse.sqrt_epi8(x.v16_16, 16));
            }
            else
            {
                return new sbyte32((sbyte8)sqrt(x.v8_0), (sbyte8)sqrt(x.v8_8), (sbyte8)sqrt(x.v8_16), (sbyte8)sqrt(x.v8_24));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort intsqrt(ushort x)
        {
            ushort result;

            if (constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                result = intsqrt((byte)x);
            }
            else
            {
                result =(ushort)sqrt(x);
            }
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            constexpr.ASSUME((uint)(result + 1) * (uint)(result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intsqrt(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu16(x, 2);
            }
            else
            {
                return (ushort2)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intsqrt(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu16(x, 3);
            }
            else
            {
                return (ushort3)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intsqrt(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu16(x, 4);
            }
            else
            {
                return (ushort4)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intsqrt(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu16(x, 8);
            }
            else
            {
                return (ushort8)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intsqrt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu16(x);
            }
            else
            {
                return new ushort16(intsqrt(x.v8_0), intsqrt(x.v8_8));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short"/>.    </summary>
        [return: AssumeRange(0, 181)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short intsqrt(short x)
        {
Assert.IsNonNegative(x);
constexpr.ASSUME(x >= 0);

            short result;

            if (constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                result = intsqrt((byte)x);
            }
            else
            {
                result = (short)intsqrt((ushort)x);
            }
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            constexpr.ASSUME((uint)(result + 1) * (uint)(result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intsqrt(short2 x)
        {
VectorAssert.IsNotSmaller<short2, short>(x, 0, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi16(x, 2);
            }
            else
            {
                return (short2)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intsqrt(short3 x)
        {
VectorAssert.IsNotSmaller<short3, short>(x, 0, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi16(x, 3);
            }
            else
            {
                return (short3)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intsqrt(short4 x)
        {
VectorAssert.IsNotSmaller<short4, short>(x, 0, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi16(x, 4);
            }
            else
            {
                return (short4)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intsqrt(short8 x)
        {
VectorAssert.IsNotSmaller<short8, short>(x, 0, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi16(x, 8);
            }
            else
            {
                return (short8)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intsqrt(short16 x)
        {
VectorAssert.IsNotSmaller<short16, short>(x, 0, 16);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi16(x);
            }
            else
            {
                return new short16(intsqrt(x.v8_0), intsqrt(x.v8_8));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint"/>.    </summary>
        [return: AssumeRange(0ul, (ulong)ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intsqrt(uint x)
        {
            uint result;

            if (constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                result = intsqrt((ushort)x);
            }
            else
            {
                if (constexpr.IS_TRUE(x <= MAX_ACCURATE_INT_SQRT_F32))
                {
                    result = (uint)sqrt((float)x);
                }
                else if (constexpr.IS_TRUE(x <= int.MaxValue))
                {
                    result = (uint)sqrt((double)(int)x);
                }
                else
                {
                    result = (uint)sqrt((double)x);
                }
            }
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            constexpr.ASSUME(((ulong)result + 1) *((ulong)result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intsqrt(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu32(x, 2);
            }
            else
            {
                return (uint2)sqrt((double2)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intsqrt(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu32(x, 3);
            }
            else
            {
                return (uint3)sqrt((double3)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intsqrt(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu32(x, 4);
            }
            else
            {
                return (uint4)sqrt((double4)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intsqrt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu32(x);
            }
            else
            {
                return new uint8(intsqrt(x.v4_0), intsqrt(x.v4_4));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int"/>.    </summary>
        [return: AssumeRange(0, 46_340)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intsqrt(int x)
        {
Assert.IsNonNegative(x);
constexpr.ASSUME(x >= 0);

            int result;

            if (constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                result = intsqrt((ushort)x);
            }
            else
            {
                result = (int)intsqrt((uint)x);
            }
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME((uint)result * (uint)result <= (uint)x);
            constexpr.ASSUME(((ulong)result + 1) * ((ulong)result + 1) > (uint)x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intsqrt(int2 x)
        {
VectorAssert.IsNotSmaller<int2, int>(x, 0, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi32(x, 2);
            }
            else
            {
                return (int2)sqrt((double2)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intsqrt(int3 x)
        {
VectorAssert.IsNotSmaller<int3, int>(x, 0, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi32(x, 3);
            }
            else
            {
                return (int3)sqrt((double3)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intsqrt(int4 x)
        {
VectorAssert.IsNotSmaller<int4, int>(x, 0, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi32(x, 4);
            }
            else
            {
                return (int4)sqrt((double4)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intsqrt(int8 x)
        {
VectorAssert.IsNotSmaller<int8, int>(x, 0, 8);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi32(x);
            }
            else
            {
                return new int8(intsqrt(x.v4_0), intsqrt(x.v4_4));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ulong"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [return: AssumeRange(0ul, (ulong)uint.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(ulong x, Promise promises = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intsqrt((uint)x);
            }

            double sqrtDbl = sqrt((double)x);
            ulong cvtt = (ulong)(long)sqrtDbl;
            // 64bit division by itself is worse than a pipeline flush
            // branch evaluation runs in parallel to cvt + sqrt + cvtt (~28 cycles), minimizing branch misprediction penalty
            if (x <= MAX_ACCURATE_INT_SQRT_F64 || promises.Promises(Promise.Unsafe0))
            {
                return cvtt;
            }
            ulong result = (cvtt + (x / cvtt)) >> 1;

            result -= tobyte(square(result) > x);
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }
            constexpr.ASSUME(result * result <= x);
            constexpr.ASSUME(((UInt128)result + 1) * ((UInt128)result + 1) > x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ulong2"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intsqrt(ulong2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epu64(x, promiseDBLrange: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong2(intsqrt(x.x, promises), intsqrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ulong3"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intsqrt(ulong3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu64(x, 3, promiseDBLrange: promises.Promises(Promise.Unsafe0));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.sqrt_epu64x2(x.xy, x.zz, out v128 lo, out v128 hi, promiseDBLrange: promises.Promises(Promise.Unsafe0));

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(intsqrt(x.xy, promises), intsqrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ulong4"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intsqrt(ulong4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu64(x, 4, promiseDBLrange: promises.Promises(Promise.Unsafe0));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.sqrt_epu64x2(x.xy, x.zw, out v128 lo, out v128 hi, promiseDBLrange: promises.Promises(Promise.Unsafe0));

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(intsqrt(x.xy, promises), intsqrt(x.zw, promises));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="long"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [return: AssumeRange(0, 3_037_000_499)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intsqrt(long x, Promise promises = Promise.Nothing)
        {
Assert.IsNonNegative(x);
constexpr.ASSUME(x >= 0);

            if (constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intsqrt((uint)x);
            }

            double sqrtDbl = sqrt((double)x);
            ulong cvtt = (ulong)(long)sqrtDbl;
            // 64bit division by itself is worse than a pipeline flush
            // branch evaluation runs in parallel to cvt + sqrt + cvtt (~28 cycles), minimizing branch misprediction penalty
            if ((ulong)x <= MAX_ACCURATE_INT_SQRT_F64)
            {
                return (long)cvtt;
            }
            ulong result = (cvtt + ((ulong)x / cvtt)) / 2;

            result -= tobyte(square(result) > (ulong)x);
            
            constexpr.ASSUME((long)result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME((long)result < x);
            }
            constexpr.ASSUME((ulong)result * (ulong)result <= (ulong)x);
            constexpr.ASSUME(((UInt128)result + 1) * ((UInt128)result + 1) > (ulong)x);
            
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x <= 1) == (x == (long)result));
            constexpr.ASSUME((x != 0) == (result > 0));

            return (long)result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="long2"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intsqrt(long2 x, Promise promises = Promise.Nothing)
        {
VectorAssert.IsNotSmaller<long2, long>(x, 0, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sqrt_epi64(x, promiseDBLrange: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new long2(intsqrt(x.x, promises), intsqrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="long3"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intsqrt(long3 x, Promise promises = Promise.Nothing)
        {
VectorAssert.IsNotSmaller<long3, long>(x, 0, 3);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi64(x, 3, promiseDBLrange: promises.Promises(Promise.Unsafe0));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.sqrt_epi64x2(x.xy, x.zz, out v128 lo, out v128 hi, promiseDBLrange: promises.Promises(Promise.Unsafe0));

                return new long3(lo, hi.SLong0);
            }
            else
            {
                return new long3(intsqrt(x.xy, promises), intsqrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="long4"/>.
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrectly rounded results for any <paramref name="x"/> greater than 4.503.239.301.588.329.       </para>    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intsqrt(long4 x, Promise promises = Promise.Nothing)
        {
VectorAssert.IsNotSmaller<long4, long>(x, 0, 4);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi64(x, 4, promiseDBLrange: promises.Promises(Promise.Unsafe0));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.sqrt_epi64x2(x.xy, x.zw, out v128 lo, out v128 hi, promiseDBLrange: promises.Promises(Promise.Unsafe0));

                return new long4(lo, hi);
            }
            else
            {
                return new long4(intsqrt(x.xy, promises), intsqrt(x.zw, promises));
            }
        }
    }
}