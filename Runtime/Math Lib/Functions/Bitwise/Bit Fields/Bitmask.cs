//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi8(v128 a, v128 b = default(v128), byte elements = 16, bool promiseLT8 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 LOOKUP = new v128(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0, 0, 0, 0, 0, 0, 0);

                        result = sllv_epi8(shuffle_epi8(LOOKUP, a), b, elements: elements);
                    }
                    else
                    {
                        v128 __b = sllv_epi8(setall_si128(), b, elements: elements);

                        if (
                        #if !TESTING
                            promiseLT8 || 
                        #endif
                            constexpr.ALL_LT_EPU8(a, 8, elements))
                        {
                            result = andnot_si128(sllv_epi8(__b, a, elements: elements), __b);
                        }
                        else
                        {
                            v128 isMaxBitsMask = cmpeq_epi8(a, set1_epi8(8));

                            result = ternarylogic_si128(isMaxBitsMask, __b, sllv_epi8(__b, a), TernaryOperation.OxF4);
                        }
                    }

                    Assume.bitmask8(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.bitmask8(result.Byte1,  a.Byte1,  b.Byte1);

                    if (elements > 2)
                    {
                        Assume.bitmask8(result.Byte2,  a.Byte2,  b.Byte2);

                        if (elements > 3)
                        {
                            Assume.bitmask8(result.Byte3,  a.Byte3,  b.Byte3);

                            if (elements > 4)
                            {
                                Assume.bitmask8(result.Byte4,  a.Byte4,  b.Byte4);
                                Assume.bitmask8(result.Byte5,  a.Byte5,  b.Byte5);
                                Assume.bitmask8(result.Byte6,  a.Byte6,  b.Byte6);
                                Assume.bitmask8(result.Byte7,  a.Byte7,  b.Byte7);

                                if (elements > 8)
                                {
                                    Assume.bitmask8(result.Byte8,  a.Byte8,  b.Byte8);
                                    Assume.bitmask8(result.Byte9,  a.Byte9,  b.Byte9);
                                    Assume.bitmask8(result.Byte10, a.Byte10, b.Byte10);
                                    Assume.bitmask8(result.Byte11, a.Byte11, b.Byte11);
                                    Assume.bitmask8(result.Byte12, a.Byte12, b.Byte12);
                                    Assume.bitmask8(result.Byte13, a.Byte13, b.Byte13);
                                    Assume.bitmask8(result.Byte14, a.Byte14, b.Byte14);
                                    Assume.bitmask8(result.Byte15, a.Byte15, b.Byte15);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi8(v256 a, v256 b = default(v256))
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0, 0, 0, 0, 0, 0, 0,
                                           0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0, 0, 0, 0, 0, 0, 0);

                    v256 result = mm256_sllv_epi8(Avx2.mm256_shuffle_epi8(LOOKUP, a), b);

                    Assume.bitmask8(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.bitmask8(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.bitmask8(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.bitmask8(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.bitmask8(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.bitmask8(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.bitmask8(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.bitmask8(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.bitmask8(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.bitmask8(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.bitmask8(result.Byte10, a.Byte10, b.Byte10);
                    Assume.bitmask8(result.Byte11, a.Byte11, b.Byte11);
                    Assume.bitmask8(result.Byte12, a.Byte12, b.Byte12);
                    Assume.bitmask8(result.Byte13, a.Byte13, b.Byte13);
                    Assume.bitmask8(result.Byte14, a.Byte14, b.Byte14);
                    Assume.bitmask8(result.Byte15, a.Byte15, b.Byte15);
                    Assume.bitmask8(result.Byte16, a.Byte16, b.Byte16);
                    Assume.bitmask8(result.Byte17, a.Byte17, b.Byte17);
                    Assume.bitmask8(result.Byte18, a.Byte18, b.Byte18);
                    Assume.bitmask8(result.Byte19, a.Byte19, b.Byte19);
                    Assume.bitmask8(result.Byte20, a.Byte20, b.Byte20);
                    Assume.bitmask8(result.Byte21, a.Byte21, b.Byte21);
                    Assume.bitmask8(result.Byte22, a.Byte22, b.Byte22);
                    Assume.bitmask8(result.Byte23, a.Byte23, b.Byte23);
                    Assume.bitmask8(result.Byte24, a.Byte24, b.Byte24);
                    Assume.bitmask8(result.Byte25, a.Byte25, b.Byte25);
                    Assume.bitmask8(result.Byte26, a.Byte26, b.Byte26);
                    Assume.bitmask8(result.Byte27, a.Byte27, b.Byte27);
                    Assume.bitmask8(result.Byte28, a.Byte28, b.Byte28);
                    Assume.bitmask8(result.Byte29, a.Byte29, b.Byte29);
                    Assume.bitmask8(result.Byte30, a.Byte30, b.Byte30);
                    Assume.bitmask8(result.Byte31, a.Byte31, b.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi16(v128 a, v128 b = default(v128), byte elements = 8, bool promiseLT16 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 LOOKUP = new v128(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111,
                                               0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                        v128 lo = shuffle_epi8(LOOKUP, 
                        #if !TESTING
                            promiseLT16 ? a : 
                        #endif
                            add_epi16(a, cmpeq_epi16(a, set1_epi16(16))));
                        v128 hi = shuffle_epi8(LOOKUP, subs_epu16(a, set1_epi16(8)));

                        result = sllv_epi16(or_si128(lo, slli_epi16(hi, 8)), b, elements: elements);
                    }
                    else
                    {
                        v128 __b = sllv_epi16(setall_si128(), b, elements: elements);

                        if (
                        #if !TESTING
                            promiseLT16 || 
                        #endif
                            constexpr.ALL_LT_EPU16(a, 16, elements))
                        {
                            result = andnot_si128(sllv_epi16(__b, a, elements: elements), __b);
                        }
                        else
                        {
                            v128 isMaxBitsMask = cmpeq_epi16(a, set1_epi16(16));

                            result = ternarylogic_si128(isMaxBitsMask, __b, sllv_epi16(__b, a), TernaryOperation.OxF4);
                        }
                    }

                    Assume.bitmask16(result.UShort0, a.UShort0, b.UShort0);
                    Assume.bitmask16(result.UShort1, a.UShort1, b.UShort1);

                    if (elements > 2)
                    {
                        Assume.bitmask16(result.UShort2, a.UShort2, b.UShort2);

                        if (elements > 3)
                        {
                            Assume.bitmask16(result.UShort3, a.UShort3, b.UShort3);

                            if (elements > 4)
                            {
                                Assume.bitmask16(result.UShort4, a.UShort4, b.UShort4);
                                Assume.bitmask16(result.UShort5, a.UShort5, b.UShort5);
                                Assume.bitmask16(result.UShort6, a.UShort6, b.UShort6);
                                Assume.bitmask16(result.UShort7, a.UShort7, b.UShort7);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi16(v256 a, v256 b = default(v256), bool promiseLT16 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111,
                                           0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111,
                                           0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111,
                                           0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                    v256 lo = Avx2.mm256_shuffle_epi8(LOOKUP, 
                        #if !TESTING
                            promiseLT16 ? a : 
                        #endif
                            Avx2.mm256_add_epi16(a, Avx2.mm256_cmpeq_epi16(a, mm256_set1_epi16(16))));
                    v256 hi = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_subs_epu16(a, mm256_set1_epi16(8)));

                    v256 result = mm256_sllv_epi16(Avx2.mm256_or_si256(lo, mm256_slli_epi16(hi, 8)), b);

                    Assume.bitmask16(result.UShort0,  a.UShort0,  b.UShort0);
                    Assume.bitmask16(result.UShort1,  a.UShort1,  b.UShort1);
                    Assume.bitmask16(result.UShort2,  a.UShort2,  b.UShort2);
                    Assume.bitmask16(result.UShort3,  a.UShort3,  b.UShort3);
                    Assume.bitmask16(result.UShort4,  a.UShort4,  b.UShort4);
                    Assume.bitmask16(result.UShort5,  a.UShort5,  b.UShort5);
                    Assume.bitmask16(result.UShort6,  a.UShort6,  b.UShort6);
                    Assume.bitmask16(result.UShort7,  a.UShort7,  b.UShort7);
                    Assume.bitmask16(result.UShort8,  a.UShort8,  b.UShort8);
                    Assume.bitmask16(result.UShort9,  a.UShort9,  b.UShort9);
                    Assume.bitmask16(result.UShort10, a.UShort10, b.UShort10);
                    Assume.bitmask16(result.UShort11, a.UShort11, b.UShort11);
                    Assume.bitmask16(result.UShort12, a.UShort12, b.UShort12);
                    Assume.bitmask16(result.UShort13, a.UShort13, b.UShort13);
                    Assume.bitmask16(result.UShort14, a.UShort14, b.UShort14);
                    Assume.bitmask16(result.UShort15, a.UShort15, b.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi32(v128 a, v128 b = default(v128), byte elements = 4, bool promiseLT32 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    v128 __b = sllv_epi32(setall_si128(), b, elements: elements);

                    if (
                    #if !TESTING
                        promiseLT32 || 
                    #endif
                        constexpr.ALL_LT_EPU32(a, 32, elements))
                    {
                        result = andnot_si128(sllv_epi32(__b, a, elements: elements), __b);
                    }
                    else
                    {
                        v128 isMaxBitsMask = cmpeq_epi32(a, set1_epi32(32));

                        result = ternarylogic_si128(isMaxBitsMask, __b, sllv_epi32(__b, a), TernaryOperation.OxF4);
                    }

                    Assume.bitmask32(result.UInt0, a.UInt0, b.UInt0);
                    Assume.bitmask32(result.UInt1, a.UInt1, b.UInt1);

                    if (elements > 2)
                    {
                        Assume.bitmask32(result.UInt2, a.UInt2, b.UInt2);

                        if (elements > 3)
                        {
                            Assume.bitmask32(result.UInt3, a.UInt3, b.UInt3);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi32(v256 a, v256 b = default(v256), bool promiseLT32 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    v256 __b = Avx2.mm256_sllv_epi32(mm256_setall_si256(), b);

                    if (
                    #if !TESTING
                        promiseLT32 || 
                    #endif
                        constexpr.ALL_LT_EPU32(a, 32))
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi32(__b, a) , __b);
                    }
                    else
                    {
                        v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(32));

                        result = mm256_ternarylogic_si256(isMaxBitsMask, __b, Avx2.mm256_sllv_epi32(__b, a), TernaryOperation.OxF4);
                    }

                    Assume.bitmask32(result.UInt0, a.UInt0, b.UInt0);
                    Assume.bitmask32(result.UInt1, a.UInt1, b.UInt1);
                    Assume.bitmask32(result.UInt2, a.UInt2, b.UInt2);
                    Assume.bitmask32(result.UInt3, a.UInt3, b.UInt3);
                    Assume.bitmask32(result.UInt4, a.UInt4, b.UInt4);
                    Assume.bitmask32(result.UInt5, a.UInt5, b.UInt5);
                    Assume.bitmask32(result.UInt6, a.UInt6, b.UInt6);
                    Assume.bitmask32(result.UInt7, a.UInt7, b.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bitmask_epi64(v128 a, v128 b = default(v128), bool promiseLT64 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    v128 __b = sllv_epi64(setall_si128(), b);

                    if (
                    #if !TESTING
                        promiseLT64 || 
                    #endif
                        constexpr.ALL_LT_EPU64(a, 64))
                    {
                        result = andnot_si128(sllv_epi64(__b, a), __b);
                    }
                    else
                    {
                        v128 isMaxBitsMask = cmpeq_epi64(a, set1_epi64x(64));

                        result = ternarylogic_si128(isMaxBitsMask, __b, sllv_epi64(__b, a), TernaryOperation.OxF4);
                    }

                    Assume.bitmask64(result.ULong0, a.ULong0, b.ULong0);
                    Assume.bitmask64(result.ULong1, a.ULong1, b.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bitmask_epi64(v256 a, v256 b = default(v256), bool promiseLT64 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    v256 __b = Avx2.mm256_sllv_epi64(mm256_setall_si256(), b);

                    if (
                    #if !TESTING
                        promiseLT64 || 
                    #endif
                        constexpr.ALL_LT_EPU64(a, 64))
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi64(__b, a), __b);
                    }
                    else
                    {
                        v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi64(a, mm256_set1_epi64x(64));

                        result = mm256_ternarylogic_si256(isMaxBitsMask, __b, Avx2.mm256_sllv_epi64(__b, a), TernaryOperation.OxF4);
                    }

                    Assume.bitmask64(result.ULong0, a.ULong0, b.ULong0);
                    Assume.bitmask64(result.ULong1, a.ULong1, b.ULong1);
                    Assume.bitmask64(result.ULong2, a.ULong2, b.ULong2);
                    Assume.bitmask64(result.ULong3, a.ULong3, b.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bitmask8(byte result, byte numBits, byte index = 0)
        {
            if (constexpr.IS_TRUE(numBits <= 8 && index < 8))
            {
                constexpr.ASSUME(result == (byte)((((1u << numBits) - 1) << index) | (0u - math.touint(numBits == 8))));
                constexpr.ASSUME((numBits == 0) == (result == 0));
                constexpr.ASSUME((numBits == 8) == (result == 0xFF));
                constexpr.ASSUME((numBits == 8) | ((result & (byte)((1u << index) - 1)) == 0));
    
                if (constexpr.IS_TRUE(index + numBits < 8))
                {
                    constexpr.ASSUME((byte)(result >> (index + numBits)) == 0);
                }
    
                if (constexpr.IS_TRUE(numBits < 8 && index + numBits <= 8))
                {
                    constexpr.ASSUME(math.countbits(result) == numBits);
                    constexpr.ASSUME(result == (byte)(((1u << numBits) - 1) << index));
                    constexpr.ASSUME((byte)(result >> index) == (byte)((1u << numBits) - 1));
                }
                if (constexpr.IS_TRUE(numBits == 8))
                {
                    constexpr.ASSUME(math.countbits(result) == 8);
                }
                if (constexpr.IS_TRUE(numBits > 0 && index + numBits > 8))
                {
                    constexpr.ASSUME(math.countbits(result) == 8 - index);
                    constexpr.ASSUME(result == (byte)(0xFFu << index));
                }
    
                constexpr.ASSUME((result == 0) == (numBits == 0));
                constexpr.ASSUME((result == 0xFF) == (numBits == 8));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bitmask16(ushort result, ushort numBits, ushort index = 0)
        {
            if (constexpr.IS_TRUE(numBits <= 16 && index < 16))
            {
                try
                {
                constexpr.ASSUME(result == (ushort)((((1u << numBits) - 1) << index) | (0u - math.touint(numBits == 16))));

                }
                catch (System.Exception)
                {
                    UnityEngine.Debug.Log(result);
                    UnityEngine.Debug.Log(numBits);
                    UnityEngine.Debug.Log(index);
                    throw;
                }
                constexpr.ASSUME((numBits == 16) == (result == 0xFFFF));
                constexpr.ASSUME((numBits == 0) == (result == 0));
                constexpr.ASSUME((numBits == 16) | ((result & (ushort)((1u << index) - 1)) == 0));
    
                if (constexpr.IS_TRUE(index + numBits < 16))
                {
                    constexpr.ASSUME((ushort)(result >> (index + numBits)) == 0);
                }
    
                if (constexpr.IS_TRUE(numBits < 16 && index + numBits <= 16))
                {
                    constexpr.ASSUME(math.countbits(result) == numBits);
                    constexpr.ASSUME(result == (ushort)(((1u << numBits) - 1) << index));
                    constexpr.ASSUME((ushort)(result >> index) == (ushort)((1u << numBits) - 1));
                }
                if (constexpr.IS_TRUE(numBits == 16))
                {
                    constexpr.ASSUME(math.countbits(result) == 16);
                }
                if (constexpr.IS_TRUE(numBits > 0 && index + numBits > 16))
                {
                    constexpr.ASSUME(math.countbits(result) == 16 - index);
                    constexpr.ASSUME(result == (ushort)(0xFFFFu << index));
                }
    
                constexpr.ASSUME((result == 0) == (numBits == 0));
                constexpr.ASSUME((result == 0xFFFF) == (numBits == 16));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bitmask32(uint result, uint numBits, uint index = 0)
        {
            if (constexpr.IS_TRUE(numBits <= 32 && index < 32))
            {
                constexpr.ASSUME(result == ((((1u << (int)numBits) - 1) << (int)index) | (0u - math.touint(numBits == 32))));
                constexpr.ASSUME((numBits == 32) == (result == uint.MaxValue));
                constexpr.ASSUME((numBits == 0) == (result == 0));
                constexpr.ASSUME((numBits == 32) | ((result & ((1u << (int)index) - 1)) == 0));
    
                if (constexpr.IS_TRUE(index + numBits < 32))
                {
                    constexpr.ASSUME((result >> (int)(index + numBits)) == 0);
                }
    
                if (constexpr.IS_TRUE(numBits < 32 && index + numBits <= 32))
                {
                    constexpr.ASSUME(math.countbits(result) == (int)numBits);
                    constexpr.ASSUME(result == (((1u << (int)numBits) - 1) << (int)index));
                    constexpr.ASSUME((result >> (int)index) == ((1u << (int)numBits) - 1));
                }
                if (constexpr.IS_TRUE(numBits == 32))
                {
                    constexpr.ASSUME(math.countbits(result) == 32);
                }
                if (constexpr.IS_TRUE(numBits > 0 && index + numBits > 32))
                {
                    constexpr.ASSUME(math.countbits(result) == 32 - (int)index);
                    constexpr.ASSUME(result == (uint.MaxValue << (int)index));
                }
    
                constexpr.ASSUME((result == 0) == (numBits == 0));
                constexpr.ASSUME((result == uint.MaxValue) == (numBits == 32));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bitmask64(ulong result, ulong numBits, ulong index = 0)
        {
            if (constexpr.IS_TRUE(numBits <= 64 && index < 64))
            {
                constexpr.ASSUME(result == ((((1ul << (int)numBits) - 1) << (int)index) | (0ul - math.toulong(numBits == 64))));
                constexpr.ASSUME((numBits == 64) == (result == ulong.MaxValue));
                constexpr.ASSUME((numBits == 0) == (result == 0));
                constexpr.ASSUME((numBits == 64) | ((result & ((1ul << (int)index) - 1)) == 0));
    
                if (constexpr.IS_TRUE(index + numBits < 64))
                {
                    constexpr.ASSUME((result >> (int)(index + numBits)) == 0);
                }
    
                if (constexpr.IS_TRUE(numBits < 64 && index + numBits <= 64))
                {
                    constexpr.ASSUME(math.countbits(result) == (int)numBits);
                    constexpr.ASSUME(result == (((1ul << (int)numBits) - 1) << (int)index));
                    constexpr.ASSUME((result >> (int)index) == ((1ul << (int)numBits) - 1));
                }
                if (constexpr.IS_TRUE(numBits == 64))
                {
                    constexpr.ASSUME(math.countbits(result) == 64);
                }
                if (constexpr.IS_TRUE(numBits > 0 && index + numBits > 64))
                {
                    constexpr.ASSUME(math.countbits(result) == 64 - (int)index);
                    constexpr.ASSUME(result == (ulong.MaxValue << (int)index));
                }
    
                constexpr.ASSUME((result == 0) == (numBits == 0));
                constexpr.ASSUME((result == ulong.MaxValue) == (numBits == 64));
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns a 128-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bitmask128(ulong numBits, ulong index = 0)
        {
            UInt128 result;

            if (constexpr.IS_TRUE(numBits != 0))
            {
                result = bits_masktolowest((UInt128)1 << ((int)numBits - 1)) << (int)index;
            }
            else
            {
                result = ((((UInt128)1 << (int)numBits) - 1) << (int)index) | ((UInt128)0 - tobyte(numBits == 128));
            }

            if (constexpr.IS_TRUE(numBits <= 128 && index < 128))
            {
                constexpr.ASSUME((numBits == 0) == (result == 0));
                constexpr.ASSUME((numBits == 128) == (result == UInt128.MaxValue));
                constexpr.ASSUME((numBits == 128) | ((result & (((UInt128)1 << (int)index) - 1)) == 0));
    
                if (constexpr.IS_TRUE(index + numBits < 128))
                {
                    constexpr.ASSUME((result >> (int)(index + numBits)) == 0);
                }
    
                if (constexpr.IS_TRUE(numBits < 128 && index + numBits <= 128))
                {
                    constexpr.ASSUME(math.countbits(result) == (int)numBits);
                    constexpr.ASSUME(result == ((((UInt128)1 << (int)numBits) - 1) << (int)index));
                    constexpr.ASSUME((result >> (int)index) == (((UInt128)1 << (int)numBits) - 1));
                }
                if (constexpr.IS_TRUE(numBits == 128))
                {
                    constexpr.ASSUME(math.countbits(result) == 128);
                }
                if (constexpr.IS_TRUE(numBits > 0 && index + numBits > 128))
                {
                    constexpr.ASSUME(math.countbits(result) == 128 - (int)index);
                    constexpr.ASSUME(result == (UInt128.MaxValue << (int)index));
                }
    
                constexpr.ASSUME((result == 0) == (numBits == 0));
                constexpr.ASSUME((result == UInt128.MaxValue) == (numBits == 128));
            }

            return result;
        }

        /// <summary>       Returns a 128-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bitmask128(long numBits, long index = 0) => (Int128)bitmask128((ulong)numBits, (ulong)index);


        /// <summary>       Returns an 8-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bitmask8(uint numBits, uint index = 0)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return (byte)(bits_masktolowest(1u << ((int)numBits - 1)) << (int)index);
                }
            }

            byte result = (byte)(((1 << (int)numBits) - 1) << (int)index);

            Assume.bitmask8(result, (byte)numBits, (byte)index);

            return result;
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="byte2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bitmask8(byte2 numBits, byte2 index = default(byte2))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 2);
            }
            else
            {
                return new byte2(bitmask8((uint)numBits.x, index.x),
                                 bitmask8((uint)numBits.y, index.y));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="byte3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bitmask8(byte3 numBits, byte3 index = default(byte3))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 3);
            }
            else
            {
                return new byte3(bitmask8((uint)numBits.x, index.x),
                                 bitmask8((uint)numBits.y, index.y),
                                 bitmask8((uint)numBits.z, index.z));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="byte4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bitmask8(byte4 numBits, byte4 index = default(byte4))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 4);
            }
            else
            {
                return new byte4(bitmask8((uint)numBits.x, index.x),
                                 bitmask8((uint)numBits.y, index.y),
                                 bitmask8((uint)numBits.z, index.z),
                                 bitmask8((uint)numBits.w, index.w));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bitmask8(byte8 numBits, byte8 index = default(byte8))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 8);
            }
            else
            {
                return new byte8(bitmask8((uint)numBits.x0, index.x0),
                                 bitmask8((uint)numBits.x1, index.x1),
                                 bitmask8((uint)numBits.x2, index.x2),
                                 bitmask8((uint)numBits.x3, index.x3),
                                 bitmask8((uint)numBits.x4, index.x4),
                                 bitmask8((uint)numBits.x5, index.x5),
                                 bitmask8((uint)numBits.x6, index.x6),
                                 bitmask8((uint)numBits.x7, index.x7));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bitmask8(byte16 numBits, byte16 index = default(byte16))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi8(numBits, index, 16);
            }
            else
            {
                return new byte16(bitmask8((uint)numBits.x0,  index.x0),
                                  bitmask8((uint)numBits.x1,  index.x1),
                                  bitmask8((uint)numBits.x2,  index.x2),
                                  bitmask8((uint)numBits.x3,  index.x3),
                                  bitmask8((uint)numBits.x4,  index.x4),
                                  bitmask8((uint)numBits.x5,  index.x5),
                                  bitmask8((uint)numBits.x6,  index.x6),
                                  bitmask8((uint)numBits.x7,  index.x7),
                                  bitmask8((uint)numBits.x8,  index.x8),
                                  bitmask8((uint)numBits.x9,  index.x9),
                                  bitmask8((uint)numBits.x10, index.x10),
                                  bitmask8((uint)numBits.x11, index.x11),
                                  bitmask8((uint)numBits.x12, index.x12),
                                  bitmask8((uint)numBits.x13, index.x13),
                                  bitmask8((uint)numBits.x14, index.x14),
                                  bitmask8((uint)numBits.x15, index.x15));
            }
        }

        /// <summary>       Returns an 8-bit bitmask <see cref="byte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bitmask8(byte32 numBits, byte32 index = default(byte32))
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi8(numBits, index);
            }
            else
            {
                return new byte32(bitmask8(numBits.v16_0, index.v16_0), bitmask8(numBits.v16_16, index.v16_16));
            }
        }


        /// <summary>       Returns a 16-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bitmask16(uint numBits, uint index = 0)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return (ushort)(bits_masktolowest(1u << ((int)numBits - 1)) << (int)index);
                }
            }

            ushort result = (ushort)(((1 << (int)numBits) - 1) << (int)index);

            Assume.bitmask16(result, (ushort)numBits, (ushort)index);

            return result;
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="ushort2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bitmask16(ushort2 numBits, ushort2 index = default(ushort2))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 2);
            }
            else
            {
                return new ushort2(bitmask16((uint)numBits.x, index.x),
                                   bitmask16((uint)numBits.y, index.y));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="ushort3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bitmask16(ushort3 numBits, ushort3 index = default(ushort3))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 3);
            }
            else
            {
                return new ushort3(bitmask16((uint)numBits.x, index.x),
                                   bitmask16((uint)numBits.y, index.y),
                                   bitmask16((uint)numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="ushort4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bitmask16(ushort4 numBits, ushort4 index = default(ushort4))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 4);
            }
            else
            {
                return new ushort4(bitmask16((uint)numBits.x, index.x),
                                   bitmask16((uint)numBits.y, index.y),
                                   bitmask16((uint)numBits.z, index.z),
                                   bitmask16((uint)numBits.w, index.w));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="ushort8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bitmask16(ushort8 numBits, ushort8 index = default(ushort8))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi16(numBits, index, 8);
            }
            else
            {
                return new ushort8(bitmask16((uint)numBits.x0, index.x0),
                                   bitmask16((uint)numBits.x1, index.x1),
                                   bitmask16((uint)numBits.x2, index.x2),
                                   bitmask16((uint)numBits.x3, index.x3),
                                   bitmask16((uint)numBits.x4, index.x4),
                                   bitmask16((uint)numBits.x5, index.x5),
                                   bitmask16((uint)numBits.x6, index.x6),
                                   bitmask16((uint)numBits.x7, index.x7));
            }
        }

        /// <summary>       Returns a 16-bit bitmask <see cref="ushort8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bitmask16(ushort16 numBits, ushort16 index = default(ushort16))
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi16(numBits, index);
            }
            else
            {
                return new ushort16(bitmask16(numBits.v8_0, index.v8_0), bitmask16(numBits.v8_8, index.v8_8));
            }
        }


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitmask32(uint numBits, uint index = 0)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return bits_masktolowest(1u << ((int)numBits - 1)) << (int)index;
                }
            }

            uint result = (uint)(((1ul << (int)numBits) - 1) << (int)index);

            Assume.bitmask32(result, numBits, index);

            return result;
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(uint2 numBits, uint2 index = default(uint2))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi32(numBits, index, 2);
            }
            else
            {
                return new uint2(bitmask32(numBits.x, index.x),
                                 bitmask32(numBits.y, index.y));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(uint3 numBits, uint3 index = default(uint3))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi32(numBits, index, 3);
            }
            else
            {
                return new uint3(bitmask32(numBits.x, index.x),
                                 bitmask32(numBits.y, index.y),
                                 bitmask32(numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(uint4 numBits, uint4 index = default(uint4))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi32(numBits, index, 4);
            }
            else
            {
                return new uint4(bitmask32(numBits.x, index.x),
                                 bitmask32(numBits.y, index.y),
                                 bitmask32(numBits.z, index.z),
                                 bitmask32(numBits.w, index.w));
            }
        }

        /// <summary>       Returns a 32-bit bitmask <see cref="uint8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(uint8 numBits, uint8 index = default(uint8))
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi32(numBits, index);
            }
            else
            {
                return new uint8(bitmask32(numBits.v4_0, index.v4_0), bitmask32(numBits.v4_4, index.v4_4));
            }
        }


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64(ulong numBits, ulong index = 0)
        {
            if (Bmi1.IsBmi1Supported)
            {
                if (constexpr.IS_TRUE(numBits != 0))
                {
                    return bits_masktolowest(1ul << ((int)numBits - 1)) << (int)index;
                }
            }

            ulong result = (((1ul << (int)numBits) - 1) << (int)index) | (0 - toulong(numBits == 64));

            Assume.bitmask64(result, numBits, index);

            return result;
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="ulong2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(ulong2 numBits, ulong2 index = default(ulong2))
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bitmask_epi64(numBits, index);
            }
            else
            {
                return new ulong2(bitmask64(numBits.x, index.x),
                                  bitmask64(numBits.y, index.y));
            }
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="ulong3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(ulong3 numBits, ulong3 index = default(ulong3))
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi64(numBits, index);
            }
            else
            {
                return new ulong3(bitmask64(numBits.__x0, index.__x0), bitmask64(numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 64-bit bitmask <see cref="ulong4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(ulong4 numBits, ulong4 index = default(ulong4))
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bitmask_epi64(numBits, index);
            }
            else
            {
                return new ulong4(bitmask64(numBits.__x0, index.__x0), bitmask64(numBits.__x2, index.__x2));
            }
        }


        /// <summary>       Returns an 8-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bitmask8(int numBits, int index = 0) => (sbyte)bitmask8((uint)numBits, (uint)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="sbyte2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bitmask8(sbyte2 numBits, sbyte2 index = default(sbyte2)) => (sbyte2)bitmask8((byte2)numBits, (byte2)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="sbyte3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bitmask8(sbyte3 numBits, sbyte3 index = default(sbyte3)) => (sbyte3)bitmask8((byte3)numBits, (byte3)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="sbyte4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bitmask8(sbyte4 numBits, sbyte4 index = default(sbyte4)) => (sbyte4)bitmask8((byte4)numBits, (byte4)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bitmask8(sbyte8 numBits, sbyte8 index = default(sbyte8)) => (sbyte8)bitmask8((byte8)numBits, (byte8)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bitmask8(sbyte16 numBits, sbyte16 index = default(sbyte16)) => (sbyte16)bitmask8((byte16)numBits, (byte16)index);

        /// <summary>       Returns an 8-bit bitmask <see cref="sbyte8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bitmask8(sbyte32 numBits, sbyte32 index = default(sbyte32)) => (sbyte32)bitmask8((byte32)numBits, (byte32)index);


        /// <summary>       Returns a 16-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bitmask16(int numBits, int index = 0) => (short)bitmask16((uint)numBits, (uint)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="short2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bitmask16(short2 numBits, short2 index = default(short2)) => (short2)bitmask16((ushort2)numBits, (ushort2)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="short3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bitmask16(short3 numBits, short3 index = default(short3)) => (short3)bitmask16((ushort3)numBits, (ushort3)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="short4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bitmask16(short4 numBits, short4 index = default(short4)) => (short4)bitmask16((ushort4)numBits, (ushort4)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="short8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bitmask16(short8 numBits, short8 index = default(short8)) => (short8)bitmask16((ushort8)numBits, (ushort8)index);

        /// <summary>       Returns a 16-bit bitmask <see cref="short8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bitmask16(short16 numBits, short16 index = default(short16)) => (short16)bitmask16((ushort16)numBits, (ushort16)index);


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask32(int numBits, int index = 0) => (int)bitmask32((uint)numBits, (uint)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bitmask32(int2 numBits, int2 index = default(int2)) => (int2)bitmask32((uint2)numBits, (uint2)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bitmask32(int3 numBits, int3 index = default(int3)) => (int3)bitmask32((uint3)numBits, (uint3)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bitmask32(int4 numBits, int4 index = default(int4)) => (int4)bitmask32((uint4)numBits, (uint4)index);

        /// <summary>       Returns a 32-bit bitmask <see cref="int8"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bitmask32(int8 numBits, int8 index = default(int8)) => (int8)bitmask32((uint8)numBits, (uint8)index);


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bitmask64(long numBits, long index = 0) => (long)bitmask64((ulong)numBits, (ulong)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="long2"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bitmask64(long2 numBits, long2 index = default(long2)) => (long2)bitmask64((ulong2)numBits, (ulong2)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="long3"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bitmask64(long3 numBits, long3 index = default(long3)) => (long3)bitmask64((ulong3)numBits, (ulong3)index);

        /// <summary>       Returns a 64-bit bitmask <see cref="long4"/> with all componentwise bits set to 1 from <paramref name="index"/> to <see langword="("/><paramref name="index"/> <see langword="+"/> <paramref name="numBits"/> <see langword="-"/> 1<see langword=")"/> in LSB order.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bitmask64(long4 numBits, long4 index = new long4()) => (long4)bitmask64((ulong4)numBits, (ulong4)index);
    }
}