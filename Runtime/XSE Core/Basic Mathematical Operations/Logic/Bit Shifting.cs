//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

#if TESTING
using DevTools;
#endif

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SHL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(v128 i, out v128 s, byte elements = 8)
        {
            static void GetIndices(ushort value, int shortIdx, out byte lo, out byte hi)
            {
                lo = value > 15 ? byte.MaxValue : (byte)(value == 0 ? shortIdx * 2 + 0 : byte.MaxValue);
                hi = value > 15 ? byte.MaxValue : (byte)(value == 0 ? shortIdx * 2 + 1 : (value == 8 ? shortIdx * 2 + 0 : byte.MaxValue));
            }
        
            s = default;
        
            bool test0 = ((i.UShort0) & 7) == 0;
            bool test1 = ((i.UShort1) & 7) == 0;
            bool test2 = ((i.UShort2) & 7) == 0;
            bool test3 = ((i.UShort3) & 7) == 0;
            bool test4 = ((i.UShort4) & 7) == 0;
            bool test5 = ((i.UShort5) & 7) == 0;
            bool test6 = ((i.UShort6) & 7) == 0;
            bool test7 = ((i.UShort7) & 7) == 0;
        
            switch (elements)
            {
                case 2:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0, out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2, out byte Byte3);
        
                        s.Byte0 = Byte0;
                        s.Byte1 = Byte1;
                        s.Byte2 = Byte2;
                        s.Byte3 = Byte3;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case 3:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1)
                      & constexpr.IS_TRUE(test2))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0, out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2, out byte Byte3);
                        GetIndices(i.UShort2, 2, out byte Byte4, out byte Byte5);
        
                        s.Byte0 = Byte0;
                        s.Byte1 = Byte1;
                        s.Byte2 = Byte2;
                        s.Byte3 = Byte3;
                        s.Byte4 = Byte4;
                        s.Byte5 = Byte5;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case 4:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1)
                      & constexpr.IS_TRUE(test2)
                      & constexpr.IS_TRUE(test3))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0, out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2, out byte Byte3);
                        GetIndices(i.UShort2, 2, out byte Byte4, out byte Byte5);
                        GetIndices(i.UShort3, 3, out byte Byte6, out byte Byte7);
        
                        s.Byte0 = Byte0;
                        s.Byte1 = Byte1;
                        s.Byte2 = Byte2;
                        s.Byte3 = Byte3;
                        s.Byte4 = Byte4;
                        s.Byte5 = Byte5;
                        s.Byte6 = Byte6;
                        s.Byte7 = Byte7;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                default:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1)
                      & constexpr.IS_TRUE(test2)
                      & constexpr.IS_TRUE(test3)
                      & constexpr.IS_TRUE(test4)
                      & constexpr.IS_TRUE(test5)
                      & constexpr.IS_TRUE(test6)
                      & constexpr.IS_TRUE(test7))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0,  out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2,  out byte Byte3);
                        GetIndices(i.UShort2, 2, out byte Byte4,  out byte Byte5);
                        GetIndices(i.UShort3, 3, out byte Byte6,  out byte Byte7);
                        GetIndices(i.UShort4, 4, out byte Byte8,  out byte Byte9);
                        GetIndices(i.UShort5, 5, out byte Byte10, out byte Byte11);
                        GetIndices(i.UShort6, 6, out byte Byte12, out byte Byte13);
                        GetIndices(i.UShort7, 7, out byte Byte14, out byte Byte15);
        
                        s.Byte0  = Byte0;
                        s.Byte1  = Byte1;
                        s.Byte2  = Byte2;
                        s.Byte3  = Byte3;
                        s.Byte4  = Byte4;
                        s.Byte5  = Byte5;
                        s.Byte6  = Byte6;
                        s.Byte7  = Byte7;
                        s.Byte8  = Byte8;
                        s.Byte9  = Byte9;
                        s.Byte10 = Byte10;
                        s.Byte11 = Byte11;
                        s.Byte12 = Byte12;
                        s.Byte13 = Byte13;
                        s.Byte14 = Byte14;
                        s.Byte15 = Byte15;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SHL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(v256 i, out v256 s)
        {
            s = default;
        
            if (SHL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(i.Lo128, out v128 lo)
             && SHL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(i.Hi128, out v128 hi))
            {
                s.Lo128 = lo;
                s.Hi128 = hi;
        
                return true;
            }
        
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SHR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(v128 i, out v128 s, byte elements = 8)
        {
            static void GetIndices(ushort value, int shortIdx, out byte lo, out byte hi)
            {
                lo = value > 15 ? byte.MaxValue : (byte)(value == 0 ? shortIdx * 2 + 0 : (value == 8 ? shortIdx * 2 + 1 : byte.MaxValue));
                hi = value > 15 ? byte.MaxValue : (byte)(value == 0 ? shortIdx * 2 + 1 : byte.MaxValue);
            }
        
            s = default;
        
            bool test0 = ((i.UShort0) & 7) == 0;
            bool test1 = ((i.UShort1) & 7) == 0;
            bool test2 = ((i.UShort2) & 7) == 0;
            bool test3 = ((i.UShort3) & 7) == 0;
            bool test4 = ((i.UShort4) & 7) == 0;
            bool test5 = ((i.UShort5) & 7) == 0;
            bool test6 = ((i.UShort6) & 7) == 0;
            bool test7 = ((i.UShort7) & 7) == 0;
        
            switch (elements)
            {
                case 2:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0, out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2, out byte Byte3);
        
                        s.Byte0 = Byte0;
                        s.Byte1 = Byte1;
                        s.Byte2 = Byte2;
                        s.Byte3 = Byte3;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case 3:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1)
                      & constexpr.IS_TRUE(test2))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0, out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2, out byte Byte3);
                        GetIndices(i.UShort2, 2, out byte Byte4, out byte Byte5);
        
                        s.Byte0 = Byte0;
                        s.Byte1 = Byte1;
                        s.Byte2 = Byte2;
                        s.Byte3 = Byte3;
                        s.Byte4 = Byte4;
                        s.Byte5 = Byte5;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                case 4:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1)
                      & constexpr.IS_TRUE(test2)
                      & constexpr.IS_TRUE(test3))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0, out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2, out byte Byte3);
                        GetIndices(i.UShort2, 2, out byte Byte4, out byte Byte5);
                        GetIndices(i.UShort3, 3, out byte Byte6, out byte Byte7);
        
                        s.Byte0 = Byte0;
                        s.Byte1 = Byte1;
                        s.Byte2 = Byte2;
                        s.Byte3 = Byte3;
                        s.Byte4 = Byte4;
                        s.Byte5 = Byte5;
                        s.Byte6 = Byte6;
                        s.Byte7 = Byte7;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                default:
                {
                    if (constexpr.IS_TRUE(test0)
                      & constexpr.IS_TRUE(test1)
                      & constexpr.IS_TRUE(test2)
                      & constexpr.IS_TRUE(test3)
                      & constexpr.IS_TRUE(test4)
                      & constexpr.IS_TRUE(test5)
                      & constexpr.IS_TRUE(test6)
                      & constexpr.IS_TRUE(test7))
                    {
                        GetIndices(i.UShort0, 0, out byte Byte0,  out byte Byte1);
                        GetIndices(i.UShort1, 1, out byte Byte2,  out byte Byte3);
                        GetIndices(i.UShort2, 2, out byte Byte4,  out byte Byte5);
                        GetIndices(i.UShort3, 3, out byte Byte6,  out byte Byte7);
                        GetIndices(i.UShort4, 4, out byte Byte8,  out byte Byte9);
                        GetIndices(i.UShort5, 5, out byte Byte10, out byte Byte11);
                        GetIndices(i.UShort6, 6, out byte Byte12, out byte Byte13);
                        GetIndices(i.UShort7, 7, out byte Byte14, out byte Byte15);
        
                        s.Byte0  = Byte0;
                        s.Byte1  = Byte1;
                        s.Byte2  = Byte2;
                        s.Byte3  = Byte3;
                        s.Byte4  = Byte4;
                        s.Byte5  = Byte5;
                        s.Byte6  = Byte6;
                        s.Byte7  = Byte7;
                        s.Byte8  = Byte8;
                        s.Byte9  = Byte9;
                        s.Byte10 = Byte10;
                        s.Byte11 = Byte11;
                        s.Byte12 = Byte12;
                        s.Byte13 = Byte13;
                        s.Byte14 = Byte14;
                        s.Byte15 = Byte15;
        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SHR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(v256 i, out v256 s)
        {
            s = default;
        
            if (SHR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(i.Lo128, out v128 lo)
             && SHR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(i.Hi128, out v128 hi))
            {
                s.Lo128 = lo;
                s.Hi128 = hi;
        
                return true;
            }
        
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SHRA_SIGN_BYTE_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(v128 i, out v128 s)
        {
            static void GetIndices(ulong value, int longiDX, out byte i0, out byte i1, out byte i2, out byte i3, out byte i4, out byte i5, out byte i6, out byte i7)
            {
                byte idx = (byte)(longiDX == 0 ? 7 : 15);

                i0 = value > 63 ? byte.MaxValue : value >= 64 ? idx : byte.MaxValue;
                i1 = value > 63 ? byte.MaxValue : value >= 56 ? idx : byte.MaxValue;
                i2 = value > 63 ? byte.MaxValue : value >= 48 ? idx : byte.MaxValue;
                i3 = value > 63 ? byte.MaxValue : value >= 40 ? idx : byte.MaxValue;
                i4 = value > 63 ? byte.MaxValue : value >= 32 ? idx : byte.MaxValue;
                i5 = value > 63 ? byte.MaxValue : value >= 24 ? idx : byte.MaxValue;
                i6 = value > 63 ? byte.MaxValue : value >= 16 ? idx : byte.MaxValue;
                i7 = value > 63 ? byte.MaxValue : value >=  8 ? idx : byte.MaxValue;
            }
        
            s = default;
        
            bool test0 = ((i.ULong0) & 7) == 0;
            bool test1 = ((i.ULong1) & 7) == 0;
            
            if (constexpr.IS_TRUE(test0)
              & constexpr.IS_TRUE(test1))
            {
                GetIndices(i.ULong0, 0, out byte Byte0, out byte Byte1, out byte Byte2,  out byte Byte3,  out byte Byte4,  out byte Byte5,  out byte Byte6,  out byte Byte7);
                GetIndices(i.ULong1, 1, out byte Byte8, out byte Byte9, out byte Byte10, out byte Byte11, out byte Byte12, out byte Byte13, out byte Byte14, out byte Byte15);
            
                s.Byte0  = Byte0;
                s.Byte1  = Byte1;
                s.Byte2  = Byte2;
                s.Byte3  = Byte3;
                s.Byte4  = Byte4;
                s.Byte5  = Byte5;
                s.Byte6  = Byte6;
                s.Byte7  = Byte7;
                s.Byte8  = Byte8;
                s.Byte9  = Byte9;
                s.Byte10 = Byte10;
                s.Byte11 = Byte11;
                s.Byte12 = Byte12;
                s.Byte13 = Byte13;
                s.Byte14 = Byte14;
                s.Byte15 = Byte15;
            
                return true;
            }
            else
            {
                return false;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool SHRA_SIGN_BYTE_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(v256 i, out v256 s)
        {
            s = default;
        
            if (SHRA_SIGN_BYTE_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(i.Lo128, out v128 lo)
             && SHRA_SIGN_BYTE_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(i.Hi128, out v128 hi))
            {
                s.Lo128 = lo;
                s.Hi128 = hi;
        
                return true;
            }
        
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sll_epi8(v128 a, v128 count, bool inRange = false, bool maskBefore = true, byte elements = 16)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 7ul);
#endif
            if (Sse2.IsSse2Supported)
            {
                if ((constexpr.ALL_LT_EPU8(a, 1 << 7, elements) && constexpr.IS_TRUE(count.ULong0 <= 1))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 6, elements) && constexpr.IS_TRUE(count.ULong0 <= 2))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 5, elements) && constexpr.IS_TRUE(count.ULong0 <= 3))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 4, elements) && constexpr.IS_TRUE(count.ULong0 <= 4))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 3, elements) && constexpr.IS_TRUE(count.ULong0 <= 5))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 2, elements) && constexpr.IS_TRUE(count.ULong0 <= 6))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 1, elements) && constexpr.IS_TRUE(count.ULong0 <= 7)))
                {
                    return sll_epi16(a, count);
                }

                return slli_epi8(a, count.SInt0, inRange, maskBefore);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 8);

                if (!inRange && (count.ULong0 & ~7ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vdupq_n_s8(count.SByte0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srl_epi8(v128 a, v128 count, bool inRange = false, bool maskBefore = true, byte elements = 16)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 7ul);
#endif
            if (Sse2.IsSse2Supported)
            {
                if ((constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << count.SInt0) - 1))), 0, elements)))
                {
                    return srl_epi16(a, count);
                }

                return srli_epi8(a, count.SInt0, inRange, maskBefore, elements: elements);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 8);

                if (!inRange && (count.ULong0 & ~7ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u8(a, Arm.Neon.vdupq_n_s8((sbyte)-count.SByte0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sra_epi8(v128 a, v128 count, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 7ul);
#endif
            if (Sse2.IsSse2Supported)
            {
                return srai_epi8(a, count.SInt0, inRange);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 8);

                if (!inRange && (count.ULong0 & ~7ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s8(a, 7);
                }
                else
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vdupq_n_s8((sbyte)-count.SByte0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srl_epi8(v256 a, v128 count, bool maskBefore = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                if ((constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << count.SInt0) - 1))), 0)))
                {
                    return Avx2.mm256_srl_epi16(a, count);
                }

                return mm256_srli_epi8(a, count.SInt0, maskBefore);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sll_epi8(v256 a, v128 count, bool maskBefore = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                if ((constexpr.ALL_LT_EPU8(a, 1 << 7) && constexpr.IS_TRUE(count.ULong0 <= 1))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 6) && constexpr.IS_TRUE(count.ULong0 <= 2))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 5) && constexpr.IS_TRUE(count.ULong0 <= 3))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 4) && constexpr.IS_TRUE(count.ULong0 <= 4))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 3) && constexpr.IS_TRUE(count.ULong0 <= 5))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 2) && constexpr.IS_TRUE(count.ULong0 <= 6))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 1) && constexpr.IS_TRUE(count.ULong0 <= 7)))
                {
                    return Avx2.mm256_sll_epi16(a, count);
                }

                return mm256_slli_epi8(a, count.SInt0, maskBefore);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sra_epi8(v256 a, v128 count)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_srai_epi8(a, count.SInt0);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi8(v128 a, int n, bool inRange = false, bool maskBefore = true, bool lzcntNot0 = false, byte elements = 16)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 7);
#endif
            inRange |= constexpr.IS_TRUE(n >= 0 && n <= 7);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.ALL_EQ_EPU8(a, 0, elements))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 1))
                {
                    return add_epi8(a, a);
                }
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_TRUE(n >= 4)
                     && constexpr.IS_CONST(n)
                     && (lzcntNot0 || constexpr.ALL_LT_EPU8(a, 1 << 7, elements)))
                    {
                        v128 TABLE = new v128((byte)(0 << n), (byte)(1 << n), (byte)(2 << n), (byte)(3 << n), (byte)(4 << n), (byte)(5 << n), (byte)(6 << n), (byte)(7 << n), (byte)(8 << n), (byte)(9 << n), (byte)(10 << n), (byte)(11 << n), (byte)(12 << n), (byte)(13 << n), (byte)(14 << n), (byte)(15 << n));

                        return shuffle_epi8(TABLE, a);
                    }
                }

                v128 result;

                if ((constexpr.ALL_LT_EPU8(a, 1 << 7, elements) && constexpr.IS_TRUE(n <= 1))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 6, elements) && constexpr.IS_TRUE(n <= 2))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 5, elements) && constexpr.IS_TRUE(n <= 3))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 4, elements) && constexpr.IS_TRUE(n <= 4))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 3, elements) && constexpr.IS_TRUE(n <= 5))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 2, elements) && constexpr.IS_TRUE(n <= 6))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 1, elements) && constexpr.IS_TRUE(n <= 7)))
                {
                    result = slli_epi16(a, n);
                }
                else if (constexpr.IS_TRUE(n == 2))
                {
                    v128 a2 = add_epi8(a, a);
                    result = add_epi8(a2, a2);
                }
                else
                {
                    // maskBefore has no effect if optimizing for size
                    if (maskBefore || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v128 mask = set1_epi8((byte)(0b1111_1111 >> n));
                        result = slli_epi16(and_si128(a, mask), n);
                    }
                    else
                    {
                        v128 mask = set1_epi8((byte)(0b1111_1111 << n));
                        result = and_si128(slli_epi16(a, n), mask);
                    }
                }
                
                constexpr.ASSUME(result.Byte0  == (inRange ? (byte)(a.Byte0  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte0  << n))));
                constexpr.ASSUME(result.Byte1  == (inRange ? (byte)(a.Byte1  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte1  << n))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2  == (inRange ? (byte)(a.Byte2  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte2  << n))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.Byte3  == (inRange ? (byte)(a.Byte3  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte3  << n))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.Byte4  == (inRange ? (byte)(a.Byte4  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte4  << n))));
                            constexpr.ASSUME(result.Byte5  == (inRange ? (byte)(a.Byte5  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte5  << n))));
                            constexpr.ASSUME(result.Byte6  == (inRange ? (byte)(a.Byte6  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte6  << n))));
                            constexpr.ASSUME(result.Byte7  == (inRange ? (byte)(a.Byte7  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte7  << n))));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.Byte8  == (inRange ? (byte)(a.Byte8  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte8  << n))));
                                constexpr.ASSUME(result.Byte9  == (inRange ? (byte)(a.Byte9  << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte9  << n))));
                                constexpr.ASSUME(result.Byte10 == (inRange ? (byte)(a.Byte10 << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte10 << n))));
                                constexpr.ASSUME(result.Byte11 == (inRange ? (byte)(a.Byte11 << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte11 << n))));
                                constexpr.ASSUME(result.Byte12 == (inRange ? (byte)(a.Byte12 << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte12 << n))));
                                constexpr.ASSUME(result.Byte13 == (inRange ? (byte)(a.Byte13 << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte13 << n))));
                                constexpr.ASSUME(result.Byte14 == (inRange ? (byte)(a.Byte14 << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte14 << n))));
                                constexpr.ASSUME(result.Byte15 == (inRange ? (byte)(a.Byte15 << n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte15 << n))));
                            }
                        }
                    }
                }

                if (inRange)
                {
                    constexpr.ASSUME((result.Byte0  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte1  & ((1 << n) - 1)) == 0);

                    if (elements > 2)
                    {
                        constexpr.ASSUME((result.Byte2  & ((1 << n) - 1)) == 0);

                        if (elements > 3)
                        {
                            constexpr.ASSUME((result.Byte3  & ((1 << n) - 1)) == 0);

                            if (elements > 4)
                            {
                                constexpr.ASSUME((result.Byte4  & ((1 << n) - 1)) == 0);
                                constexpr.ASSUME((result.Byte5  & ((1 << n) - 1)) == 0);
                                constexpr.ASSUME((result.Byte6  & ((1 << n) - 1)) == 0);
                                constexpr.ASSUME((result.Byte7  & ((1 << n) - 1)) == 0);

                                if (elements > 8)
                                {
                                    constexpr.ASSUME((result.Byte8  & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte9  & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte10 & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte11 & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte12 & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte13 & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte14 & ((1 << n) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte15 & ((1 << n) - 1)) == 0);
                                }
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sll_epi8(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi8(v128 a, int n, bool inRange = false, bool maskBefore = true, byte elements = 16)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 7);
#endif
            inRange |= constexpr.IS_TRUE(n >= 0 && n <= 7);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }

                v128 result;

                if ((constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements))
                 || (constexpr.ALL_EQ_EPU8(and_si128(a, set1_epi8((byte)((1 << n) - 1))), 0, elements)))
                {
                    result = srli_epi16(a, n);
                }
                else if (constexpr.IS_TRUE(n == 7))
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = blendv_epi8(setzero_si128(), set1_epi8(1), a);
                    }
                    else
                    {
                        result = neg_epi8(cmpgt_epi8(setzero_si128(), a));
                    }
                }
                else if (constexpr.IS_TRUE(n == 1))
                {
                    result = srli_epi16(andnot_si128(set1_epi8(1), a), 1);
                }
                else
                {
                    // maskBefore has no effect if optimizing for size
                    if (maskBefore || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v128 mask = set1_epi8((byte)(0b1111_1111 << n));
                        result = srli_epi16(and_si128(a, mask), n);
                    }
                    else
                    {
                        v128 mask = set1_epi8((byte)(0b1111_1111 >> n));
                        result = and_si128(srli_epi16(a, n), mask);
                    }
                }
                
                constexpr.ASSUME(result.Byte0  == (inRange ? (byte)(a.Byte0  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte0  >> n))));
                constexpr.ASSUME(result.Byte1  == (inRange ? (byte)(a.Byte1  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte1  >> n))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2  == (inRange ? (byte)(a.Byte2  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte2  >> n))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.Byte3  == (inRange ? (byte)(a.Byte3  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte3  >> n))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.Byte4  == (inRange ? (byte)(a.Byte4  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte4  >> n))));
                            constexpr.ASSUME(result.Byte5  == (inRange ? (byte)(a.Byte5  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte5  >> n))));
                            constexpr.ASSUME(result.Byte6  == (inRange ? (byte)(a.Byte6  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte6  >> n))));
                            constexpr.ASSUME(result.Byte7  == (inRange ? (byte)(a.Byte7  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte7  >> n))));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.Byte8  == (inRange ? (byte)(a.Byte8  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte8  >> n))));
                                constexpr.ASSUME(result.Byte9  == (inRange ? (byte)(a.Byte9  >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte9  >> n))));
                                constexpr.ASSUME(result.Byte10 == (inRange ? (byte)(a.Byte10 >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte10 >> n))));
                                constexpr.ASSUME(result.Byte11 == (inRange ? (byte)(a.Byte11 >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte11 >> n))));
                                constexpr.ASSUME(result.Byte12 == (inRange ? (byte)(a.Byte12 >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte12 >> n))));
                                constexpr.ASSUME(result.Byte13 == (inRange ? (byte)(a.Byte13 >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte13 >> n))));
                                constexpr.ASSUME(result.Byte14 == (inRange ? (byte)(a.Byte14 >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte14 >> n))));
                                constexpr.ASSUME(result.Byte15 == (inRange ? (byte)(a.Byte15 >> n) : (n < 0 || n > 7 ? 0 : (byte)(a.Byte15 >> n))));
                            }
                        }
                    }
                }

                constexpr.ASSUME_LE_EPU8(result, (byte)(byte.MaxValue >> n), elements);

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return srl_epi8(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi8(v128 a, int n, bool inRange = false, byte elements = 16)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 7);
#endif
            inRange |= constexpr.IS_TRUE(n >= 0 && n <= 7);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }

                v128 result;

                if (constexpr.IS_TRUE(n == 7))
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements))
                    {
                        result = setzero_si128();
                    }
                    else if (constexpr.ALL_LT_EPI8(a, 0, elements))
                    {
                        result = setall_si128();
                    }
                    else
                    {
                        result = cmpgt_epi8(setzero_si128(), a);
                    }

                    goto RET;
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    if (elements <= 8)
                    {
                        result = cvtepi16_epi8(srai_epi16(cvtepi8_epi16(a), n));

                        goto RET;
                    }
                }

                v128 even = srai_epi16(slli_epi16(a, 8), n + 8);
                v128 odd = srai_epi16(a, n);

                result = blendv_si128(even, odd, new v128(0xFF00_FF00));

            RET:
                
                constexpr.ASSUME(result.SByte0  == (inRange ? (sbyte)(a.SByte0  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte0  >> n))));
                constexpr.ASSUME(result.SByte1  == (inRange ? (sbyte)(a.SByte1  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte1  >> n))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.SByte2  == (inRange ? (sbyte)(a.SByte2  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte2  >> n))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.SByte3  == (inRange ? (sbyte)(a.SByte3  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte3  >> n))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.SByte4  == (inRange ? (sbyte)(a.SByte4  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte4  >> n))));
                            constexpr.ASSUME(result.SByte5  == (inRange ? (sbyte)(a.SByte5  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte5  >> n))));
                            constexpr.ASSUME(result.SByte6  == (inRange ? (sbyte)(a.SByte6  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte6  >> n))));
                            constexpr.ASSUME(result.SByte7  == (inRange ? (sbyte)(a.SByte7  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte7  >> n))));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.SByte8  == (inRange ? (sbyte)(a.SByte8  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte8  >> n))));
                                constexpr.ASSUME(result.SByte9  == (inRange ? (sbyte)(a.SByte9  >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte9  >> n))));
                                constexpr.ASSUME(result.SByte10 == (inRange ? (sbyte)(a.SByte10 >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte10 >> n))));
                                constexpr.ASSUME(result.SByte11 == (inRange ? (sbyte)(a.SByte11 >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte11 >> n))));
                                constexpr.ASSUME(result.SByte12 == (inRange ? (sbyte)(a.SByte12 >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte12 >> n))));
                                constexpr.ASSUME(result.SByte13 == (inRange ? (sbyte)(a.SByte13 >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte13 >> n))));
                                constexpr.ASSUME(result.SByte14 == (inRange ? (sbyte)(a.SByte14 >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte14 >> n))));
                                constexpr.ASSUME(result.SByte15 == (inRange ? (sbyte)(a.SByte15 >> n) : (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte15 >> n))));
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sra_epi8(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi8(v256 a, int n, bool maskBefore = true, bool lzcntNot0 = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 1))
                {
                    return Avx2.mm256_add_epi8(a, a);
                }

                v256 result;

                if ((constexpr.ALL_LT_EPU8(a, 1 << 7) && constexpr.IS_TRUE(n <= 1))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 6) && constexpr.IS_TRUE(n <= 2))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 5) && constexpr.IS_TRUE(n <= 3))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 4) && constexpr.IS_TRUE(n <= 4))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 3) && constexpr.IS_TRUE(n <= 5))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 2) && constexpr.IS_TRUE(n <= 6))
                 || (constexpr.ALL_LT_EPU8(a, 1 << 1) && constexpr.IS_TRUE(n <= 7)))
                {
                    result = mm256_slli_epi16(a, n);
                }
                else if (constexpr.IS_TRUE(n >= 4)
                 && constexpr.IS_CONST(n)
                 && (lzcntNot0 || constexpr.ALL_LT_EPU8(a, 1 << 7)))
                {
                    v256 TABLE = new v256((byte)(0 << n), (byte)(1 << n), (byte)(2 << n), (byte)(3 << n), (byte)(4 << n), (byte)(5 << n), (byte)(6 << n), (byte)(7 << n), (byte)(8 << n), (byte)(9 << n), (byte)(10 << n), (byte)(11 << n), (byte)(12 << n), (byte)(13 << n), (byte)(14 << n), (byte)(15 << n),
                                          (byte)(0 << n), (byte)(1 << n), (byte)(2 << n), (byte)(3 << n), (byte)(4 << n), (byte)(5 << n), (byte)(6 << n), (byte)(7 << n), (byte)(8 << n), (byte)(9 << n), (byte)(10 << n), (byte)(11 << n), (byte)(12 << n), (byte)(13 << n), (byte)(14 << n), (byte)(15 << n));

                    result = Avx2.mm256_shuffle_epi8(TABLE, a);
                }
                else if (constexpr.IS_TRUE(n == 2))
                {
                    v256 a2 = Avx2.mm256_add_epi8(a, a);

                    result = Avx2.mm256_add_epi8(a2, a2);
                }
                else
                {
                    // maskBefore has no effect if optimizing for size
                    if (maskBefore || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v256 mask = mm256_set1_epi8((byte)(0b1111_1111 >> n));
                        result = mm256_slli_epi16(Avx2.mm256_and_si256(a, mask), n);
                    }
                    else
                    {
                        v256 mask = mm256_set1_epi8((byte)(0b1111_1111 << n));
                        result = Avx2.mm256_and_si256(mm256_slli_epi16(a, n), mask);
                    }
                }

                constexpr.ASSUME(result.Byte0  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte0  << n)));
                constexpr.ASSUME(result.Byte1  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte1  << n)));
                constexpr.ASSUME(result.Byte2  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte2  << n)));
                constexpr.ASSUME(result.Byte3  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte3  << n)));
                constexpr.ASSUME(result.Byte4  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte4  << n)));
                constexpr.ASSUME(result.Byte5  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte5  << n)));
                constexpr.ASSUME(result.Byte6  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte6  << n)));
                constexpr.ASSUME(result.Byte7  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte7  << n)));
                constexpr.ASSUME(result.Byte8  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte8  << n)));
                constexpr.ASSUME(result.Byte9  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte9  << n)));
                constexpr.ASSUME(result.Byte10 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte10 << n)));
                constexpr.ASSUME(result.Byte11 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte11 << n)));
                constexpr.ASSUME(result.Byte12 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte12 << n)));
                constexpr.ASSUME(result.Byte13 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte13 << n)));
                constexpr.ASSUME(result.Byte14 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte14 << n)));
                constexpr.ASSUME(result.Byte15 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte15 << n)));
                constexpr.ASSUME(result.Byte16 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte16 << n)));
                constexpr.ASSUME(result.Byte17 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte17 << n)));
                constexpr.ASSUME(result.Byte18 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte18 << n)));
                constexpr.ASSUME(result.Byte19 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte19 << n)));
                constexpr.ASSUME(result.Byte20 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte20 << n)));
                constexpr.ASSUME(result.Byte21 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte21 << n)));
                constexpr.ASSUME(result.Byte22 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte22 << n)));
                constexpr.ASSUME(result.Byte23 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte23 << n)));
                constexpr.ASSUME(result.Byte24 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte24 << n)));
                constexpr.ASSUME(result.Byte25 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte25 << n)));
                constexpr.ASSUME(result.Byte26 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte26 << n)));
                constexpr.ASSUME(result.Byte27 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte27 << n)));
                constexpr.ASSUME(result.Byte28 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte28 << n)));
                constexpr.ASSUME(result.Byte29 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte29 << n)));
                constexpr.ASSUME(result.Byte30 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte30 << n)));
                constexpr.ASSUME(result.Byte31 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte31 << n)));

                if (constexpr.IS_TRUE(n >= 0 && n <= 7))
                {
                    constexpr.ASSUME((result.Byte0  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte1  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte2  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte3  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte4  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte5  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte6  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte7  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte8  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte9  & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte10 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte11 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte12 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte13 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte14 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte15 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte16 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte17 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte18 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte19 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte20 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte21 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte22 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte23 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte24 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte25 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte26 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte27 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte28 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte29 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte30 & ((1 << n) - 1)) == 0);
                    constexpr.ASSUME((result.Byte31 & ((1 << n) - 1)) == 0);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi8(v256 a, int n, bool maskBefore = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }

                v256 result;

                if ((constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0))
                 || (constexpr.ALL_EQ_EPU8(Avx2.mm256_and_si256(a, mm256_set1_epi8((byte)((1 << n) - 1))), 0)))
                {
                    result = mm256_srli_epi16(a, n);
                }
                else if (constexpr.IS_TRUE(n == 7))
                {
                    result = mm256_neg_epi8(Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a));
                }
                else if (constexpr.IS_TRUE(n == 1))
                {
                    result = mm256_srli_epi16(Avx2.mm256_andnot_si256(mm256_set1_epi8(1), a), 1);
                }
                else
                {
                    // maskBefore has no effect if optimizing for size
                    if (maskBefore || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v256 mask = mm256_set1_epi8((byte)(0b1111_1111 << n));
                        result = mm256_srli_epi16(Avx2.mm256_and_si256(a, mask), n);
                    }
                    else
                    {
                        v256 mask = mm256_set1_epi8((byte)(0b1111_1111 >> n));
                        result = Avx2.mm256_and_si256(mm256_srli_epi16(a, n), mask);
                    }
                }

                constexpr.ASSUME(result.Byte0  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte0  >> n)));
                constexpr.ASSUME(result.Byte1  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte1  >> n)));
                constexpr.ASSUME(result.Byte2  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte2  >> n)));
                constexpr.ASSUME(result.Byte3  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte3  >> n)));
                constexpr.ASSUME(result.Byte4  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte4  >> n)));
                constexpr.ASSUME(result.Byte5  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte5  >> n)));
                constexpr.ASSUME(result.Byte6  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte6  >> n)));
                constexpr.ASSUME(result.Byte7  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte7  >> n)));
                constexpr.ASSUME(result.Byte8  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte8  >> n)));
                constexpr.ASSUME(result.Byte9  == (n < 0 || n > 7 ? 0 : (byte)(a.Byte9  >> n)));
                constexpr.ASSUME(result.Byte10 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte10 >> n)));
                constexpr.ASSUME(result.Byte11 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte11 >> n)));
                constexpr.ASSUME(result.Byte12 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte12 >> n)));
                constexpr.ASSUME(result.Byte13 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte13 >> n)));
                constexpr.ASSUME(result.Byte14 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte14 >> n)));
                constexpr.ASSUME(result.Byte15 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte15 >> n)));
                constexpr.ASSUME(result.Byte16 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte16 >> n)));
                constexpr.ASSUME(result.Byte17 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte17 >> n)));
                constexpr.ASSUME(result.Byte18 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte18 >> n)));
                constexpr.ASSUME(result.Byte19 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte19 >> n)));
                constexpr.ASSUME(result.Byte20 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte20 >> n)));
                constexpr.ASSUME(result.Byte21 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte21 >> n)));
                constexpr.ASSUME(result.Byte22 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte22 >> n)));
                constexpr.ASSUME(result.Byte23 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte23 >> n)));
                constexpr.ASSUME(result.Byte24 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte24 >> n)));
                constexpr.ASSUME(result.Byte25 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte25 >> n)));
                constexpr.ASSUME(result.Byte26 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte26 >> n)));
                constexpr.ASSUME(result.Byte27 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte27 >> n)));
                constexpr.ASSUME(result.Byte28 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte28 >> n)));
                constexpr.ASSUME(result.Byte29 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte29 >> n)));
                constexpr.ASSUME(result.Byte30 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte30 >> n)));
                constexpr.ASSUME(result.Byte31 == (n < 0 || n > 7 ? 0 : (byte)(a.Byte31 >> n)));

                constexpr.ASSUME_LE_EPU8(result, (uint)byte.MaxValue >> n);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi8(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }

                v256 result;

                if (constexpr.IS_TRUE(n == 7))
                {
                    if (constexpr.ALL_GE_EPI8(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }
                    else if (constexpr.ALL_LT_EPI8(a, 0))
                    {
                        return mm256_setall_si256();
                    }
                    else
                    {
                        result = Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a);
                    }
                }
                else
                {
                    v256 even = mm256_srai_epi16(mm256_slli_epi16(a, 8), n + 8);
                    v256 odd = mm256_srai_epi16(a, n);

                    result = mm256_blendv_si256(even, odd, new v256(0xFF00_FF00));
                }

                constexpr.ASSUME(result.SByte0  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte0  >> n)));
                constexpr.ASSUME(result.SByte1  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte1  >> n)));
                constexpr.ASSUME(result.SByte2  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte2  >> n)));
                constexpr.ASSUME(result.SByte3  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte3  >> n)));
                constexpr.ASSUME(result.SByte4  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte4  >> n)));
                constexpr.ASSUME(result.SByte5  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte5  >> n)));
                constexpr.ASSUME(result.SByte6  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte6  >> n)));
                constexpr.ASSUME(result.SByte7  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte7  >> n)));
                constexpr.ASSUME(result.SByte8  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte8  >> n)));
                constexpr.ASSUME(result.SByte9  == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte9  >> n)));
                constexpr.ASSUME(result.SByte10 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte10 >> n)));
                constexpr.ASSUME(result.SByte11 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte11 >> n)));
                constexpr.ASSUME(result.SByte12 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte12 >> n)));
                constexpr.ASSUME(result.SByte13 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte13 >> n)));
                constexpr.ASSUME(result.SByte14 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte14 >> n)));
                constexpr.ASSUME(result.SByte15 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte15 >> n)));
                constexpr.ASSUME(result.SByte16 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte16 >> n)));
                constexpr.ASSUME(result.SByte17 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte17 >> n)));
                constexpr.ASSUME(result.SByte18 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte18 >> n)));
                constexpr.ASSUME(result.SByte19 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte19 >> n)));
                constexpr.ASSUME(result.SByte20 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte20 >> n)));
                constexpr.ASSUME(result.SByte21 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte21 >> n)));
                constexpr.ASSUME(result.SByte22 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte22 >> n)));
                constexpr.ASSUME(result.SByte23 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte23 >> n)));
                constexpr.ASSUME(result.SByte24 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte24 >> n)));
                constexpr.ASSUME(result.SByte25 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte25 >> n)));
                constexpr.ASSUME(result.SByte26 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte26 >> n)));
                constexpr.ASSUME(result.SByte27 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte27 >> n)));
                constexpr.ASSUME(result.SByte28 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte28 >> n)));
                constexpr.ASSUME(result.SByte29 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte29 >> n)));
                constexpr.ASSUME(result.SByte30 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte30 >> n)));
                constexpr.ASSUME(result.SByte31 == (n < 0 || n > 7 ? 0 : (sbyte)(a.SByte31 >> n)));

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi8(v128 a, v128 b, bool inRange = false, bool noOverflow = false, byte elements = 16)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<byte16, byte>(b, 0, 7, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return slli_epi8(a, b.Byte0, inRange);
                }

                v128 result;

                //if (Avx512.IsAvx512Supported)
                //{
                //    if (elements <= 8)
                //    {
                //        v128 r16 = sllv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));
                //
                //        result = noOverflow ? packus_epi16(r16, r16) : cvtepi16_epi8(r16);
                //    }
                //    else
                //    {
                //        v128 loA16 = cvt2x2epu8_epi16(a, out v128 hiA16);
                //        v128 loB16 = cvt2x2epu8_epi16(b, out v128 hiB16);
                //
                //        v128 r16Lo = sllv_epi16(loA16, loB16);
                //        v128 r16Hi = sllv_epi16(hiA16, hiB16);
                //
                //        result = noOverflow ? packus_epi16(r16Lo, r16Hi) : cvt2x2epi16_epi8(r16Lo, r16Hi);
                //    }
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        v128 __b = min_epu8(b, set1_epi8(8));

                        v128 mask = new v128((byte)((1 << __b.Byte0)  - 1),
                                             (byte)((1 << __b.Byte1)  - 1),
                                             (byte)((1 << __b.Byte2)  - 1),
                                             (byte)((1 << __b.Byte3)  - 1),
                                             (byte)((1 << __b.Byte4)  - 1),
                                             (byte)((1 << __b.Byte5)  - 1),
                                             (byte)((1 << __b.Byte6)  - 1),
                                             (byte)((1 << __b.Byte7)  - 1),
                                             (byte)((1 << __b.Byte8)  - 1),
                                             (byte)((1 << __b.Byte9)  - 1),
                                             (byte)((1 << __b.Byte10) - 1),
                                             (byte)((1 << __b.Byte11) - 1),
                                             (byte)((1 << __b.Byte12) - 1),
                                             (byte)((1 << __b.Byte13) - 1),
                                             (byte)((1 << __b.Byte14) - 1),
                                             (byte)((1 << __b.Byte15) - 1));

                        switch (elements)
                        {
                            case 2:
                            case 3:
                            {
                                if (__b.Byte0 == __b.Byte1)
                                {
                                    __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                    v128 shift32 = sllv_epi16(a, __b, elements: elements);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            case 4:
                            {
                                if (__b.Byte0 == __b.Byte1
                                 && __b.Byte2 == __b.Byte3)
                                {
                                    __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                    v128 shift32 = sllv_epi16(a, __b, elements: elements);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            case 8:
                            {
                                if (__b.Byte0 == __b.Byte1
                                 && __b.Byte2 == __b.Byte3
                                 && __b.Byte4 == __b.Byte5
                                 && __b.Byte6 == __b.Byte7)
                                {
                                    __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                    v128 shift32 = sllv_epi16(a, __b, elements: elements);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            default:
                            {
                                if (__b.Byte0  == __b.Byte1
                                 && __b.Byte2  == __b.Byte3
                                 && __b.Byte4  == __b.Byte5
                                 && __b.Byte6  == __b.Byte7
                                 && __b.Byte8  == __b.Byte9
                                 && __b.Byte10 == __b.Byte11
                                 && __b.Byte12 == __b.Byte13
                                 && __b.Byte14 == __b.Byte15)
                                {
                                    __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                    v128 shift32 = sllv_epi16(a, __b, elements: elements);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                        }
                    }

                    if (elements <= 4)
                    {
                        result = cvtepi32_epi8(sllv_epi32(cvtepu8_epi32(a), cvtepu8_epi32(b)));
                    }
                    else if (elements == 8)
                    {
                        v128 loA32 = cvt2x2epu8_epi32(a, out v128 hiA32);
                        v128 loB32 = cvt2x2epu8_epi32(b, out v128 hiB32);

                        v128 loR32 = sllv_epi32(loA32, loB32);
                        v128 hiR32 = sllv_epi32(hiA32, hiB32);

                        v128 r16 = packs_epi32(loR32, hiR32);

                        result = noOverflow ? packus_epi16(r16, r16) : cvtepi16_epi8(r16);
                    }
                    else
                    {
                        cvt4x4epu8_epi32(a, out v128 a0, out v128 a1, out v128 a2, out v128 a3);
                        cvt4x4epu8_epi32(b, out v128 b0, out v128 b1, out v128 b2, out v128 b3);

                        v128 r0 = sllv_epi32(a0, b0);
                        v128 r1 = sllv_epi32(a1, b1);
                        v128 r2 = sllv_epi32(a2, b2);
                        v128 r3 = sllv_epi32(a3, b3);

                        result = cvt4x4epi32_epi8(r0, r1, r2, r3, signed: false, noOverflowU16: true, noOverflowU8: noOverflow);
                    }
                }
                else if (constexpr.IS_CONST(b))
                {
                    result = mullo_epi8(a, new v128((byte)(1 << b.Byte0), (byte)(1 << b.Byte1), (byte)(1 << b.Byte2), (byte)(1 << b.Byte3), (byte)(1 << b.Byte4), (byte)(1 << b.Byte5), (byte)(1 << b.Byte6), (byte)(1 << b.Byte7), (byte)(1 << b.Byte8), (byte)(1 << b.Byte9), (byte)(1 << b.Byte10), (byte)(1 << b.Byte11), (byte)(1 << b.Byte12), (byte)(1 << b.Byte13), (byte)(1 << b.Byte14), (byte)(1 << b.Byte15)), elements);
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0);

                        result = shuffle_epi8(LOOKUP, b);
                    }
                    else
                    {
                        v128 POW2_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,     0, 0, 0, 0, 0, 0, 0, 0);
                        v128 mulValues = shuffle_epi8(POW2_MASK, b);

                        result = mullo_epi8(a, mulValues, elements);
                    }
                }
                else
                {
                    v128 __a = a;
                    v128 __b = b;

                    int shift = 1;

                    result = setzero_si128();
                    if (!constexpr.ALL_NEQ_EPU8(__b, 0, elements))
                    {
                        result = and_si128(__a, cmpeq_epi8(setzero_si128(), __b));
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 1, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(1), __b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(__b, 1, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 2, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(2), __b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(__b, 2, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 3, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(3), __b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(__b, 3, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 4, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(4), __b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(__b, 4, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 5, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(5), __b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(__b, 5, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 6, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(6), __b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(__b, 6, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(__b, 7, elements))
                    {
                        __a = slli_epi8(__a, shift);
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(7), __b)));
                    }
                }

            RET:
                
                constexpr.ASSUME(result.Byte0  == (inRange ? (byte)(a.Byte0  << b.Byte0)  : (b.Byte0  > 7 ? 0 : (byte)(a.Byte0  << b.Byte0))));
                constexpr.ASSUME(result.Byte1  == (inRange ? (byte)(a.Byte1  << b.Byte1)  : (b.Byte1  > 7 ? 0 : (byte)(a.Byte1  << b.Byte1))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2  == (inRange ? (byte)(a.Byte2  << b.Byte2)  : (b.Byte2  > 7 ? 0 : (byte)(a.Byte2  << b.Byte2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.Byte3  == (inRange ? (byte)(a.Byte3  << b.Byte3)  : (b.Byte3  > 7 ? 0 : (byte)(a.Byte3  << b.Byte3))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.Byte4  == (inRange ? (byte)(a.Byte4  << b.Byte4)  : (b.Byte4  > 7 ? 0 : (byte)(a.Byte4  << b.Byte4))));
                            constexpr.ASSUME(result.Byte5  == (inRange ? (byte)(a.Byte5  << b.Byte5)  : (b.Byte5  > 7 ? 0 : (byte)(a.Byte5  << b.Byte5))));
                            constexpr.ASSUME(result.Byte6  == (inRange ? (byte)(a.Byte6  << b.Byte6)  : (b.Byte6  > 7 ? 0 : (byte)(a.Byte6  << b.Byte6))));
                            constexpr.ASSUME(result.Byte7  == (inRange ? (byte)(a.Byte7  << b.Byte7)  : (b.Byte7  > 7 ? 0 : (byte)(a.Byte7  << b.Byte7))));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.Byte8  == (inRange ? (byte)(a.Byte8  << b.Byte8)  : (b.Byte8  > 7 ? 0 : (byte)(a.Byte8  << b.Byte8))));
                                constexpr.ASSUME(result.Byte9  == (inRange ? (byte)(a.Byte9  << b.Byte9)  : (b.Byte9  > 7 ? 0 : (byte)(a.Byte9  << b.Byte9))));
                                constexpr.ASSUME(result.Byte10 == (inRange ? (byte)(a.Byte10 << b.Byte10) : (b.Byte10 > 7 ? 0 : (byte)(a.Byte10 << b.Byte10))));
                                constexpr.ASSUME(result.Byte11 == (inRange ? (byte)(a.Byte11 << b.Byte11) : (b.Byte11 > 7 ? 0 : (byte)(a.Byte11 << b.Byte11))));
                                constexpr.ASSUME(result.Byte12 == (inRange ? (byte)(a.Byte12 << b.Byte12) : (b.Byte12 > 7 ? 0 : (byte)(a.Byte12 << b.Byte12))));
                                constexpr.ASSUME(result.Byte13 == (inRange ? (byte)(a.Byte13 << b.Byte13) : (b.Byte13 > 7 ? 0 : (byte)(a.Byte13 << b.Byte13))));
                                constexpr.ASSUME(result.Byte14 == (inRange ? (byte)(a.Byte14 << b.Byte14) : (b.Byte14 > 7 ? 0 : (byte)(a.Byte14 << b.Byte14))));
                                constexpr.ASSUME(result.Byte15 == (inRange ? (byte)(a.Byte15 << b.Byte15) : (b.Byte15 > 7 ? 0 : (byte)(a.Byte15 << b.Byte15))));
                            }
                        }
                    }
                }

                if (inRange)
                {
                    constexpr.ASSUME((result.Byte0  & ((1 << b.Byte0)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte1  & ((1 << b.Byte1)  - 1)) == 0);

                    if (elements > 2)
                    {
                        constexpr.ASSUME((result.Byte2  & ((1 << b.Byte2)  - 1)) == 0);

                        if (elements > 3)
                        {
                            constexpr.ASSUME((result.Byte3  & ((1 << b.Byte3)  - 1)) == 0);

                            if (elements > 4)
                            {
                                constexpr.ASSUME((result.Byte4  & ((1 << b.Byte4)  - 1)) == 0);
                                constexpr.ASSUME((result.Byte5  & ((1 << b.Byte5)  - 1)) == 0);
                                constexpr.ASSUME((result.Byte6  & ((1 << b.Byte6)  - 1)) == 0);
                                constexpr.ASSUME((result.Byte7  & ((1 << b.Byte7)  - 1)) == 0);

                                if (elements > 8)
                                {
                                    constexpr.ASSUME((result.Byte8  & ((1 << b.Byte8)  - 1)) == 0);
                                    constexpr.ASSUME((result.Byte9  & ((1 << b.Byte9)  - 1)) == 0);
                                    constexpr.ASSUME((result.Byte10 & ((1 << b.Byte10) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte11 & ((1 << b.Byte11) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte12 & ((1 << b.Byte12) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte13 & ((1 << b.Byte13) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte14 & ((1 << b.Byte14) - 1)) == 0);
                                    constexpr.ASSUME((result.Byte15 & ((1 << b.Byte15) - 1)) == 0);
                                }
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU8(b, 7, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u8(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u8(Arm.Neon.vshlq_u8(a, b), Arm.Neon.vcltq_u8(b, set1_epi8(8)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi8(v128 a, v128 b, bool inRange = false, byte elements = 16)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<byte16, byte>(b, 0, 7, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return srli_epi8(a, b.Byte0, inRange, elements: elements);
                }

                v128 result;

                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                        result = shuffle_epi8(LOOKUP, b);

                        goto RET;
                    }
                    else if (Avx2.IsAvx2Supported)
                    {
                        if (constexpr.IS_CONST(b))
                        {
                            v128 __b = min_epu8(b, set1_epi8(8));

                            v128 mask = new v128((byte)((1 << (8 - __b.Byte0))  - 1),
                                                 (byte)((1 << (8 - __b.Byte1))  - 1),
                                                 (byte)((1 << (8 - __b.Byte2))  - 1),
                                                 (byte)((1 << (8 - __b.Byte3))  - 1),
                                                 (byte)((1 << (8 - __b.Byte4))  - 1),
                                                 (byte)((1 << (8 - __b.Byte5))  - 1),
                                                 (byte)((1 << (8 - __b.Byte6))  - 1),
                                                 (byte)((1 << (8 - __b.Byte7))  - 1),
                                                 (byte)((1 << (8 - __b.Byte8))  - 1),
                                                 (byte)((1 << (8 - __b.Byte9))  - 1),
                                                 (byte)((1 << (8 - __b.Byte10)) - 1),
                                                 (byte)((1 << (8 - __b.Byte11)) - 1),
                                                 (byte)((1 << (8 - __b.Byte12)) - 1),
                                                 (byte)((1 << (8 - __b.Byte13)) - 1),
                                                 (byte)((1 << (8 - __b.Byte14)) - 1),
                                                 (byte)((1 << (8 - __b.Byte15)) - 1));

                            switch (elements)
                            {
                                case 2:
                                case 3:
                                {
                                    if (__b.Byte0 == __b.Byte1)
                                    {
                                        __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                        v128 shift16 = srlv_epi16(a, __b, elements: elements);
                                        result = and_si128(mask, shift16);

                                        goto RET;
                                    }

                                    break;
                                }
                                case 4:
                                {
                                    if (__b.Byte0 == __b.Byte1
                                     && __b.Byte2 == __b.Byte3)
                                    {
                                        __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                        v128 shift16 = srlv_epi16(a, __b, elements: elements);
                                        result = and_si128(mask, shift16);

                                        goto RET;
                                    }

                                    break;
                                }
                                case 8:
                                {
                                    if (__b.Byte0 == __b.Byte1
                                     && __b.Byte2 == __b.Byte3
                                     && __b.Byte4 == __b.Byte5
                                     && __b.Byte6 == __b.Byte7)
                                    {
                                        __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                        v128 shift16 = srlv_epi16(a, __b, elements: elements);
                                        result = and_si128(mask, shift16);

                                        goto RET;
                                    }

                                    break;
                                }
                                default:
                                {
                                    if (__b.Byte0  == __b.Byte1
                                     && __b.Byte2  == __b.Byte3
                                     && __b.Byte4  == __b.Byte5
                                     && __b.Byte6  == __b.Byte7
                                     && __b.Byte8  == __b.Byte9
                                     && __b.Byte10 == __b.Byte11
                                     && __b.Byte12 == __b.Byte13
                                     && __b.Byte14 == __b.Byte15)
                                    {
                                        __b = and_si128(__b, set1_epi16(byte.MaxValue));
                                        v128 shift16 = srlv_epi16(a, __b, elements: elements);
                                        result = and_si128(mask, shift16);

                                        goto RET;
                                    }

                                    break;
                                }
                            }
                        }
                    }
                    else if ((constexpr.IS_CONST(b) || COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                     && constexpr.ALL_NEQ_EPI8(b, 0))
                    {
                        v128 INV_POW2 = new v128(0, 1 << 7, 1 << 6, 1 << 5, 1 << 4, 1 << 3, 1 << 2, 1 << 1, 0, 0, 0, 0, 0, 0, 0, 0);

                        result = mulhi_epu8(a, shuffle_epi8(INV_POW2, b), elements);

                        goto RET;
                    }
                }

                //if (Avx512.IsAvx512Supported)
                //{
                //    if (elements <= 8)
                //    {
                //        v128 r16 = srlv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));
                //
                //        result = packus_epi16(r16, r16);
                //    }
                //    else
                //    {
                //        v128 loA16 = cvt2x2epu8_epi16(a, out v128 hiA16);
                //        v128 loB16 = cvt2x2epu8_epi16(b, out v128 hiB16);
                //
                //        v128 r16Lo = srlv_epi16(loA16, loB16);
                //        v128 r16Hi = srlv_epi16(hiA16, hiB16);
                //
                //        result = packus_epi16(r16Lo, r16Hi);
                //    }
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        result = cvtepi32_epi8(srlv_epi32(cvtepu8_epi32(a), cvtepu8_epi32(b)));
                    }
                    else if (elements == 8)
                    {
                        v128 loA32 = cvt2x2epu8_epi32(a, out v128 hiA32);
                        v128 loB32 = cvt2x2epu8_epi32(b, out v128 hiB32);

                        v128 loR32 = srlv_epi32(loA32, loB32);
                        v128 hiR32 = srlv_epi32(hiA32, hiB32);

                        v128 r16 = packus_epi32(loR32, hiR32);

                        result = packus_epi16(r16, r16);
                    }
                    else
                    {
                        cvt4x4epu8_epi32(a, out v128 a0, out v128 a1, out v128 a2, out v128 a3);
                        cvt4x4epu8_epi32(b, out v128 b0, out v128 b1, out v128 b2, out v128 b3);

                        v128 r0 = srlv_epi32(a0, b0);
                        v128 r1 = srlv_epi32(a1, b1);
                        v128 r2 = srlv_epi32(a2, b2);
                        v128 r3 = srlv_epi32(a3, b3);

                        result = cvt4x4epi32_epi8(r0, r1, r2, r3, signed: false, noOverflowU16: true, noOverflowU8: true);
                    }
                }
                else
                {
                    v128 __a = a;

                    int shift = 1;

                    result = setzero_si128();
                    if (!constexpr.ALL_NEQ_EPU8(b, 0, elements))
                    {
                        result = and_si128(__a, cmpeq_epi8(setzero_si128(), b));
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 1, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(1), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 1, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 2, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(2), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 2, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 3, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(3), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 3, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 4, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(4), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 4, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 5, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(5), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 5, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 6, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(6), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 6, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 7, elements))
                    {
                        __a = srli_epi8(__a, shift, elements: elements);
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(7), b)));
                    }
                }

            RET:
                
                constexpr.ASSUME(result.Byte0  == (inRange ? (byte)(a.Byte0  >> b.Byte0)  : (b.Byte0  > 7 ? 0 : (byte)(a.Byte0  >> b.Byte0))));
                constexpr.ASSUME(result.Byte1  == (inRange ? (byte)(a.Byte1  >> b.Byte1)  : (b.Byte1  > 7 ? 0 : (byte)(a.Byte1  >> b.Byte1))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2  == (inRange ? (byte)(a.Byte2  >> b.Byte2)  : (b.Byte2  > 7 ? 0 : (byte)(a.Byte2  >> b.Byte2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.Byte3  == (inRange ? (byte)(a.Byte3  >> b.Byte3)  : (b.Byte3  > 7 ? 0 : (byte)(a.Byte3  >> b.Byte3))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.Byte4  == (inRange ? (byte)(a.Byte4  >> b.Byte4)  : (b.Byte4  > 7 ? 0 : (byte)(a.Byte4  >> b.Byte4))));
                            constexpr.ASSUME(result.Byte5  == (inRange ? (byte)(a.Byte5  >> b.Byte5)  : (b.Byte5  > 7 ? 0 : (byte)(a.Byte5  >> b.Byte5))));
                            constexpr.ASSUME(result.Byte6  == (inRange ? (byte)(a.Byte6  >> b.Byte6)  : (b.Byte6  > 7 ? 0 : (byte)(a.Byte6  >> b.Byte6))));
                            constexpr.ASSUME(result.Byte7  == (inRange ? (byte)(a.Byte7  >> b.Byte7)  : (b.Byte7  > 7 ? 0 : (byte)(a.Byte7  >> b.Byte7))));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.Byte8  == (inRange ? (byte)(a.Byte8  >> b.Byte8)  : (b.Byte8  > 7 ? 0 : (byte)(a.Byte8  >> b.Byte8))));
                                constexpr.ASSUME(result.Byte9  == (inRange ? (byte)(a.Byte9  >> b.Byte9)  : (b.Byte9  > 7 ? 0 : (byte)(a.Byte9  >> b.Byte9))));
                                constexpr.ASSUME(result.Byte10 == (inRange ? (byte)(a.Byte10 >> b.Byte10) : (b.Byte10 > 7 ? 0 : (byte)(a.Byte10 >> b.Byte10))));
                                constexpr.ASSUME(result.Byte11 == (inRange ? (byte)(a.Byte11 >> b.Byte11) : (b.Byte11 > 7 ? 0 : (byte)(a.Byte11 >> b.Byte11))));
                                constexpr.ASSUME(result.Byte12 == (inRange ? (byte)(a.Byte12 >> b.Byte12) : (b.Byte12 > 7 ? 0 : (byte)(a.Byte12 >> b.Byte12))));
                                constexpr.ASSUME(result.Byte13 == (inRange ? (byte)(a.Byte13 >> b.Byte13) : (b.Byte13 > 7 ? 0 : (byte)(a.Byte13 >> b.Byte13))));
                                constexpr.ASSUME(result.Byte14 == (inRange ? (byte)(a.Byte14 >> b.Byte14) : (b.Byte14 > 7 ? 0 : (byte)(a.Byte14 >> b.Byte14))));
                                constexpr.ASSUME(result.Byte15 == (inRange ? (byte)(a.Byte15 >> b.Byte15) : (b.Byte15 > 7 ? 0 : (byte)(a.Byte15 >> b.Byte15))));
                            }
                        }
                    }
                }

                if (inRange)
                {
                    constexpr.ASSUME(result.Byte0  <= (byte)(byte.MaxValue >> b.Byte0));
                    constexpr.ASSUME(result.Byte1  <= (byte)(byte.MaxValue >> b.Byte1));

                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.Byte2  <= (byte)(byte.MaxValue >> b.Byte2));

                        if (elements > 3)
                        {
                            constexpr.ASSUME(result.Byte3  <= (byte)(byte.MaxValue >> b.Byte3));

                            if (elements > 4)
                            {
                                constexpr.ASSUME(result.Byte4  <= (byte)(byte.MaxValue >> b.Byte4));
                                constexpr.ASSUME(result.Byte5  <= (byte)(byte.MaxValue >> b.Byte5));
                                constexpr.ASSUME(result.Byte6  <= (byte)(byte.MaxValue >> b.Byte6));
                                constexpr.ASSUME(result.Byte7  <= (byte)(byte.MaxValue >> b.Byte7));

                                if (elements > 8)
                                {
                                    constexpr.ASSUME(result.Byte8  <= (byte)(byte.MaxValue >> b.Byte8));
                                    constexpr.ASSUME(result.Byte9  <= (byte)(byte.MaxValue >> b.Byte9));
                                    constexpr.ASSUME(result.Byte10 <= (byte)(byte.MaxValue >> b.Byte10));
                                    constexpr.ASSUME(result.Byte11 <= (byte)(byte.MaxValue >> b.Byte11));
                                    constexpr.ASSUME(result.Byte12 <= (byte)(byte.MaxValue >> b.Byte12));
                                    constexpr.ASSUME(result.Byte13 <= (byte)(byte.MaxValue >> b.Byte13));
                                    constexpr.ASSUME(result.Byte14 <= (byte)(byte.MaxValue >> b.Byte14));
                                    constexpr.ASSUME(result.Byte15 <= (byte)(byte.MaxValue >> b.Byte15));
                                }
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU8(b, 7, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u8(a, Arm.Neon.vnegq_s8(b));
                }
                else
                {
                    return Arm.Neon.vshlq_u8(a, Arm.Neon.vnegq_s8(Arm.Neon.vminq_u8(b, Arm.Neon.vdupq_n_u8(7))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi8(v128 a, v128 b, bool inRange = false, byte elements = 16)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<byte16, byte>(b, 0, 7, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return srai_epi8(a, b.Byte0, inRange: inRange, elements: elements);
                }

                v128 result;

                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                        result = shuffle_epi8(LOOKUP, b);

                        goto RET;
                    }
                }

                //if (Avx512.IsAvx512Supported)
                //{
                //    if (elements <= 8)
                //    {
                //        v128 r16 = srav_epi16(cvtepi8_epi16(a), cvtepi8_epi16(b));
                //
                //        result = packs_epi16(r16, r16);
                //    }
                //    else
                //    {
                //        v128 loA16 = cvt2x2epi8_epi16(a, out v128 hiA16);
                //        v128 loB16 = cvt2x2epi8_epi16(b, out v128 hiB16);
                //
                //        v128 r16Lo = srav_epi16(loA16, loB16);
                //        v128 r16Hi = srav_epi16(hiA16, hiB16);
                //
                //        result = packs_epi16(r16Lo, r16Hi);
                //    }
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        result = cvtepi32_epi8(srav_epi32(cvtepi8_epi32(a), cvtepu8_epi32(b)));
                    }
                    else if (elements == 8)
                    {
                        v128 loA32 = cvt2x2epi8_epi32(a, out v128 hiA32);
                        v128 loB32 = cvt2x2epu8_epi32(b, out v128 hiB32);

                        v128 loR32 = srav_epi32(loA32, loB32);
                        v128 hiR32 = srav_epi32(hiA32, hiB32);

                        v128 r16 = packs_epi32(loR32, hiR32);

                        result = packs_epi16(r16, r16);
                    }
                    else
                    {
                        cvt4x4epi8_epi32(a, out v128 a0, out v128 a1, out v128 a2, out v128 a3);
                        cvt4x4epu8_epi32(b, out v128 b0, out v128 b1, out v128 b2, out v128 b3);

                        v128 r0 = srav_epi32(a0, b0);
                        v128 r1 = srav_epi32(a1, b1);
                        v128 r2 = srav_epi32(a2, b2);
                        v128 r3 = srav_epi32(a3, b3);

                        result = cvt4x4epi32_epi8(r0, r1, r2, r3, signed: true, noOverflowU16: true, noOverflowU8: true);
                    }
                }
                else
                {
                    v128 __a = a;

                    int shift = 1;

                    result = setzero_si128();
                    if (!constexpr.ALL_NEQ_EPU8(b, 0, elements))
                    {
                        result = and_si128(__a, cmpeq_epi8(setzero_si128(), b));
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 1, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(1), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 1, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 2, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(2), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 2, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 3, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(3), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 3, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 4, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(4), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 4, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 5, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(5), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 5, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 6, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(6), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 6, elements))
                    {
                        goto RET;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 7, elements))
                    {
                        __a = srai_epi8(__a, shift);
                        result = or_si128(result, and_si128(__a, cmpeq_epi8(set1_epi8(7), b)));
                    }
                }

            RET:
                
                constexpr.ASSUME(result.SByte0  == (inRange ? (sbyte)(a.SByte0  >> b.SByte0)  : (b.SByte0  < 0 || b.SByte0  > 7 ? 0 : b.SByte0)));
                constexpr.ASSUME(result.SByte1  == (inRange ? (sbyte)(a.SByte1  >> b.SByte1)  : (b.SByte1  < 0 || b.SByte1  > 7 ? 0 : b.SByte1)));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.SByte2  == (inRange ? (sbyte)(a.SByte2  >> b.SByte2)  : (b.SByte2  < 0 || b.SByte2  > 7 ? 0 : b.SByte2)));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.SByte3  == (inRange ? (sbyte)(a.SByte3  >> b.SByte3)  : (b.SByte3  < 0 || b.SByte3  > 7 ? 0 : b.SByte3)));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.SByte4  == (inRange ? (sbyte)(a.SByte4  >> b.SByte4)  : (b.SByte4  < 0 || b.SByte4  > 7 ? 0 : b.SByte4)));
                            constexpr.ASSUME(result.SByte5  == (inRange ? (sbyte)(a.SByte5  >> b.SByte5)  : (b.SByte5  < 0 || b.SByte5  > 7 ? 0 : b.SByte5)));
                            constexpr.ASSUME(result.SByte6  == (inRange ? (sbyte)(a.SByte6  >> b.SByte6)  : (b.SByte6  < 0 || b.SByte6  > 7 ? 0 : b.SByte6)));
                            constexpr.ASSUME(result.SByte7  == (inRange ? (sbyte)(a.SByte7  >> b.SByte7)  : (b.SByte7  < 0 || b.SByte7  > 7 ? 0 : b.SByte7)));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.SByte8  == (inRange ? (sbyte)(a.SByte8  >> b.SByte8)  : (b.SByte8  < 0 || b.SByte8  > 7 ? 0 : b.SByte8)));
                                constexpr.ASSUME(result.SByte9  == (inRange ? (sbyte)(a.SByte9  >> b.SByte9)  : (b.SByte9  < 0 || b.SByte9  > 7 ? 0 : b.SByte9)));
                                constexpr.ASSUME(result.SByte10 == (inRange ? (sbyte)(a.SByte10 >> b.SByte10) : (b.SByte10 < 0 || b.SByte10 > 7 ? 0 : b.SByte10)));
                                constexpr.ASSUME(result.SByte11 == (inRange ? (sbyte)(a.SByte11 >> b.SByte11) : (b.SByte11 < 0 || b.SByte11 > 7 ? 0 : b.SByte11)));
                                constexpr.ASSUME(result.SByte12 == (inRange ? (sbyte)(a.SByte12 >> b.SByte12) : (b.SByte12 < 0 || b.SByte12 > 7 ? 0 : b.SByte12)));
                                constexpr.ASSUME(result.SByte13 == (inRange ? (sbyte)(a.SByte13 >> b.SByte13) : (b.SByte13 < 0 || b.SByte13 > 7 ? 0 : b.SByte13)));
                                constexpr.ASSUME(result.SByte14 == (inRange ? (sbyte)(a.SByte14 >> b.SByte14) : (b.SByte14 < 0 || b.SByte14 > 7 ? 0 : b.SByte14)));
                                constexpr.ASSUME(result.SByte15 == (inRange ? (sbyte)(a.SByte15 >> b.SByte15) : (b.SByte15 < 0 || b.SByte15 > 7 ? 0 : b.SByte15)));
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU8(b, 7, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vnegq_s8(b));
                }
                else
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vnegq_s8(Arm.Neon.vminq_u8(b, Arm.Neon.vdupq_n_u8(7))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sllv_epi8(v256 a, v256 b, bool noOverflow = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_slli_epi8(a, b.Byte0);
                }

                v256 result;

                if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                {
                    v256 LOOKUP = new v256((byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                           (byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    result = Avx2.mm256_shuffle_epi8(LOOKUP, b);
                }
                else if (constexpr.IS_CONST(b))
                {
                    v256 __b = Avx2.mm256_min_epu8(b, mm256_set1_epi8(8));

                    v256 mask = new v256((byte)((1 << __b.Byte0)  - 1),
                                         (byte)((1 << __b.Byte1)  - 1),
                                         (byte)((1 << __b.Byte2)  - 1),
                                         (byte)((1 << __b.Byte3)  - 1),
                                         (byte)((1 << __b.Byte4)  - 1),
                                         (byte)((1 << __b.Byte5)  - 1),
                                         (byte)((1 << __b.Byte6)  - 1),
                                         (byte)((1 << __b.Byte7)  - 1),
                                         (byte)((1 << __b.Byte8)  - 1),
                                         (byte)((1 << __b.Byte9)  - 1),
                                         (byte)((1 << __b.Byte10) - 1),
                                         (byte)((1 << __b.Byte11) - 1),
                                         (byte)((1 << __b.Byte12) - 1),
                                         (byte)((1 << __b.Byte13) - 1),
                                         (byte)((1 << __b.Byte14) - 1),
                                         (byte)((1 << __b.Byte15) - 1),
                                         (byte)((1 << __b.Byte16) - 1),
                                         (byte)((1 << __b.Byte17) - 1),
                                         (byte)((1 << __b.Byte18) - 1),
                                         (byte)((1 << __b.Byte19) - 1),
                                         (byte)((1 << __b.Byte20) - 1),
                                         (byte)((1 << __b.Byte21) - 1),
                                         (byte)((1 << __b.Byte22) - 1),
                                         (byte)((1 << __b.Byte23) - 1),
                                         (byte)((1 << __b.Byte24) - 1),
                                         (byte)((1 << __b.Byte25) - 1),
                                         (byte)((1 << __b.Byte26) - 1),
                                         (byte)((1 << __b.Byte27) - 1),
                                         (byte)((1 << __b.Byte28) - 1),
                                         (byte)((1 << __b.Byte29) - 1),
                                         (byte)((1 << __b.Byte30) - 1),
                                         (byte)((1 << __b.Byte31) - 1));
                    
                    if (__b.Byte0  == __b.Byte1
                     && __b.Byte2  == __b.Byte3
                     && __b.Byte4  == __b.Byte5
                     && __b.Byte6  == __b.Byte7
                     && __b.Byte8  == __b.Byte9
                     && __b.Byte10 == __b.Byte11
                     && __b.Byte12 == __b.Byte13
                     && __b.Byte14 == __b.Byte15
                     && __b.Byte16 == __b.Byte17
                     && __b.Byte18 == __b.Byte19
                     && __b.Byte20 == __b.Byte21
                     && __b.Byte22 == __b.Byte23
                     && __b.Byte24 == __b.Byte25
                     && __b.Byte26 == __b.Byte27
                     && __b.Byte28 == __b.Byte29
                     && __b.Byte30 == __b.Byte31)
                    {
                        __b = Avx2.mm256_and_si256(__b, mm256_set1_epi16(byte.MaxValue));
                        v256 shift32 = mm256_sllv_epi16(a, __b);
                        result = Avx2.mm256_andnot_si256(mask, shift32);
                    
                        goto RET;
                    }
                }

                //if (Avx512.IsAvx512Supported)
                //{
                //    v256 loA16 = mm256_cvt2x2epu8_epi16(a, out v256 hiA16);
                //    v256 loB16 = mm256_cvt2x2epu8_epi16(b, out v256 hiB16);
                //
                //    v256 r16Lo = mm256_sllv_epi16(loA16, loB16);
                //    v256 r16Hi = mm256_sllv_epi16(hiA16, hiB16);
                //
                //    result = noOverflow ? Avx2.mm256_packus_epi16(r16Lo, r16Hi) : mm256_cvt2x2epi16_epi8(r16Lo, r16Hi);
                //}
                //else
                {
                    mm256_cvt4x4epu8_epi32(a, out v256 a0, out v256 a1, out v256 a2, out v256 a3);
                    mm256_cvt4x4epu8_epi32(b, out v256 b0, out v256 b1, out v256 b2, out v256 b3);
                    
                    v256 r0 = Avx2.mm256_sllv_epi32(a0, b0);
                    v256 r1 = Avx2.mm256_sllv_epi32(a1, b1);
                    v256 r2 = Avx2.mm256_sllv_epi32(a2, b2);
                    v256 r3 = Avx2.mm256_sllv_epi32(a3, b3);
                    
                    result = mm256_cvt4x4epi32_epi8(r0, r1, r2, r3, signed: false, noOverflowU16: true, noOverflowU8: noOverflow);
                }

            RET:
                constexpr.ASSUME(result.Byte0  == (b.Byte0  > 7 ? 0 : (byte)(a.Byte0  << b.Byte0)));
                constexpr.ASSUME(result.Byte1  == (b.Byte1  > 7 ? 0 : (byte)(a.Byte1  << b.Byte1)));
                constexpr.ASSUME(result.Byte2  == (b.Byte2  > 7 ? 0 : (byte)(a.Byte2  << b.Byte2)));
                constexpr.ASSUME(result.Byte3  == (b.Byte3  > 7 ? 0 : (byte)(a.Byte3  << b.Byte3)));
                constexpr.ASSUME(result.Byte4  == (b.Byte4  > 7 ? 0 : (byte)(a.Byte4  << b.Byte4)));
                constexpr.ASSUME(result.Byte5  == (b.Byte5  > 7 ? 0 : (byte)(a.Byte5  << b.Byte5)));
                constexpr.ASSUME(result.Byte6  == (b.Byte6  > 7 ? 0 : (byte)(a.Byte6  << b.Byte6)));
                constexpr.ASSUME(result.Byte7  == (b.Byte7  > 7 ? 0 : (byte)(a.Byte7  << b.Byte7)));
                constexpr.ASSUME(result.Byte8  == (b.Byte8  > 7 ? 0 : (byte)(a.Byte8  << b.Byte8)));
                constexpr.ASSUME(result.Byte9  == (b.Byte9  > 7 ? 0 : (byte)(a.Byte9  << b.Byte9)));
                constexpr.ASSUME(result.Byte10 == (b.Byte10 > 7 ? 0 : (byte)(a.Byte10 << b.Byte10)));
                constexpr.ASSUME(result.Byte11 == (b.Byte11 > 7 ? 0 : (byte)(a.Byte11 << b.Byte11)));
                constexpr.ASSUME(result.Byte12 == (b.Byte12 > 7 ? 0 : (byte)(a.Byte12 << b.Byte12)));
                constexpr.ASSUME(result.Byte13 == (b.Byte13 > 7 ? 0 : (byte)(a.Byte13 << b.Byte13)));
                constexpr.ASSUME(result.Byte14 == (b.Byte14 > 7 ? 0 : (byte)(a.Byte14 << b.Byte14)));
                constexpr.ASSUME(result.Byte15 == (b.Byte15 > 7 ? 0 : (byte)(a.Byte15 << b.Byte15)));
                constexpr.ASSUME(result.Byte16 == (b.Byte16 > 7 ? 0 : (byte)(a.Byte16 << b.Byte16)));
                constexpr.ASSUME(result.Byte17 == (b.Byte17 > 7 ? 0 : (byte)(a.Byte17 << b.Byte17)));
                constexpr.ASSUME(result.Byte18 == (b.Byte18 > 7 ? 0 : (byte)(a.Byte18 << b.Byte18)));
                constexpr.ASSUME(result.Byte19 == (b.Byte19 > 7 ? 0 : (byte)(a.Byte19 << b.Byte19)));
                constexpr.ASSUME(result.Byte20 == (b.Byte20 > 7 ? 0 : (byte)(a.Byte20 << b.Byte20)));
                constexpr.ASSUME(result.Byte21 == (b.Byte21 > 7 ? 0 : (byte)(a.Byte21 << b.Byte21)));
                constexpr.ASSUME(result.Byte22 == (b.Byte22 > 7 ? 0 : (byte)(a.Byte22 << b.Byte22)));
                constexpr.ASSUME(result.Byte23 == (b.Byte23 > 7 ? 0 : (byte)(a.Byte23 << b.Byte23)));
                constexpr.ASSUME(result.Byte24 == (b.Byte24 > 7 ? 0 : (byte)(a.Byte24 << b.Byte24)));
                constexpr.ASSUME(result.Byte25 == (b.Byte25 > 7 ? 0 : (byte)(a.Byte25 << b.Byte25)));
                constexpr.ASSUME(result.Byte26 == (b.Byte26 > 7 ? 0 : (byte)(a.Byte26 << b.Byte26)));
                constexpr.ASSUME(result.Byte27 == (b.Byte27 > 7 ? 0 : (byte)(a.Byte27 << b.Byte27)));
                constexpr.ASSUME(result.Byte28 == (b.Byte28 > 7 ? 0 : (byte)(a.Byte28 << b.Byte28)));
                constexpr.ASSUME(result.Byte29 == (b.Byte29 > 7 ? 0 : (byte)(a.Byte29 << b.Byte29)));
                constexpr.ASSUME(result.Byte30 == (b.Byte30 > 7 ? 0 : (byte)(a.Byte30 << b.Byte30)));
                constexpr.ASSUME(result.Byte31 == (b.Byte31 > 7 ? 0 : (byte)(a.Byte31 << b.Byte31)));

                if (constexpr.ALL_LE_EPU8(b, 7))
                {
                    constexpr.ASSUME((result.Byte0  & ((1 << b.Byte0)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte1  & ((1 << b.Byte1)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte2  & ((1 << b.Byte2)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte3  & ((1 << b.Byte3)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte4  & ((1 << b.Byte4)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte5  & ((1 << b.Byte5)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte6  & ((1 << b.Byte6)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte7  & ((1 << b.Byte7)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte8  & ((1 << b.Byte8)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte9  & ((1 << b.Byte9)  - 1)) == 0);
                    constexpr.ASSUME((result.Byte10 & ((1 << b.Byte10) - 1)) == 0);
                    constexpr.ASSUME((result.Byte11 & ((1 << b.Byte11) - 1)) == 0);
                    constexpr.ASSUME((result.Byte12 & ((1 << b.Byte12) - 1)) == 0);
                    constexpr.ASSUME((result.Byte13 & ((1 << b.Byte13) - 1)) == 0);
                    constexpr.ASSUME((result.Byte14 & ((1 << b.Byte14) - 1)) == 0);
                    constexpr.ASSUME((result.Byte15 & ((1 << b.Byte15) - 1)) == 0);
                    constexpr.ASSUME((result.Byte16 & ((1 << b.Byte16) - 1)) == 0);
                    constexpr.ASSUME((result.Byte17 & ((1 << b.Byte17) - 1)) == 0);
                    constexpr.ASSUME((result.Byte18 & ((1 << b.Byte18) - 1)) == 0);
                    constexpr.ASSUME((result.Byte19 & ((1 << b.Byte19) - 1)) == 0);
                    constexpr.ASSUME((result.Byte20 & ((1 << b.Byte20) - 1)) == 0);
                    constexpr.ASSUME((result.Byte21 & ((1 << b.Byte21) - 1)) == 0);
                    constexpr.ASSUME((result.Byte22 & ((1 << b.Byte22) - 1)) == 0);
                    constexpr.ASSUME((result.Byte23 & ((1 << b.Byte23) - 1)) == 0);
                    constexpr.ASSUME((result.Byte24 & ((1 << b.Byte24) - 1)) == 0);
                    constexpr.ASSUME((result.Byte25 & ((1 << b.Byte25) - 1)) == 0);
                    constexpr.ASSUME((result.Byte26 & ((1 << b.Byte26) - 1)) == 0);
                    constexpr.ASSUME((result.Byte27 & ((1 << b.Byte27) - 1)) == 0);
                    constexpr.ASSUME((result.Byte28 & ((1 << b.Byte28) - 1)) == 0);
                    constexpr.ASSUME((result.Byte29 & ((1 << b.Byte29) - 1)) == 0);
                    constexpr.ASSUME((result.Byte30 & ((1 << b.Byte30) - 1)) == 0);
                    constexpr.ASSUME((result.Byte31 & ((1 << b.Byte31) - 1)) == 0);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srlv_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_srli_epi8(a, b.Byte0);
                }

                v256 result;

                if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                {
                    v256 LOOKUP = new v256((byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                           (byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    result = Avx2.mm256_shuffle_epi8(LOOKUP, b);
                }
                else if (constexpr.IS_CONST(b))
                {
                    v256 __b = Avx2.mm256_min_epu8(b, mm256_set1_epi8(8));

                    v256 mask = new v256((byte)((1 << (8 - __b.Byte0))  - 1),
                                         (byte)((1 << (8 - __b.Byte1))  - 1),
                                         (byte)((1 << (8 - __b.Byte2))  - 1),
                                         (byte)((1 << (8 - __b.Byte3))  - 1),
                                         (byte)((1 << (8 - __b.Byte4))  - 1),
                                         (byte)((1 << (8 - __b.Byte5))  - 1),
                                         (byte)((1 << (8 - __b.Byte6))  - 1),
                                         (byte)((1 << (8 - __b.Byte7))  - 1),
                                         (byte)((1 << (8 - __b.Byte8))  - 1),
                                         (byte)((1 << (8 - __b.Byte9))  - 1),
                                         (byte)((1 << (8 - __b.Byte10)) - 1),
                                         (byte)((1 << (8 - __b.Byte11)) - 1),
                                         (byte)((1 << (8 - __b.Byte12)) - 1),
                                         (byte)((1 << (8 - __b.Byte13)) - 1),
                                         (byte)((1 << (8 - __b.Byte14)) - 1),
                                         (byte)((1 << (8 - __b.Byte15)) - 1),
                                         (byte)((1 << (8 - __b.Byte16)) - 1),
                                         (byte)((1 << (8 - __b.Byte17)) - 1),
                                         (byte)((1 << (8 - __b.Byte18)) - 1),
                                         (byte)((1 << (8 - __b.Byte19)) - 1),
                                         (byte)((1 << (8 - __b.Byte20)) - 1),
                                         (byte)((1 << (8 - __b.Byte21)) - 1),
                                         (byte)((1 << (8 - __b.Byte22)) - 1),
                                         (byte)((1 << (8 - __b.Byte23)) - 1),
                                         (byte)((1 << (8 - __b.Byte24)) - 1),
                                         (byte)((1 << (8 - __b.Byte25)) - 1),
                                         (byte)((1 << (8 - __b.Byte26)) - 1),
                                         (byte)((1 << (8 - __b.Byte27)) - 1),
                                         (byte)((1 << (8 - __b.Byte28)) - 1),
                                         (byte)((1 << (8 - __b.Byte29)) - 1),
                                         (byte)((1 << (8 - __b.Byte30)) - 1),
                                         (byte)((1 << (8 - __b.Byte31)) - 1));
                    
                    if (__b.Byte0  == __b.Byte1
                     && __b.Byte2  == __b.Byte3
                     && __b.Byte4  == __b.Byte5
                     && __b.Byte6  == __b.Byte7
                     && __b.Byte8  == __b.Byte9
                     && __b.Byte10 == __b.Byte11
                     && __b.Byte12 == __b.Byte13
                     && __b.Byte14 == __b.Byte15
                     && __b.Byte16 == __b.Byte17
                     && __b.Byte18 == __b.Byte19
                     && __b.Byte20 == __b.Byte21
                     && __b.Byte22 == __b.Byte23
                     && __b.Byte24 == __b.Byte25
                     && __b.Byte26 == __b.Byte27
                     && __b.Byte28 == __b.Byte29
                     && __b.Byte30 == __b.Byte31)
                    {
                        __b = Avx2.mm256_and_si256(__b, mm256_set1_epi16(byte.MaxValue));
                        v256 shift32 = mm256_srlv_epi16(a, __b);
                        result = Avx2.mm256_and_si256(mask, shift32);

                        goto RET;
                    }
                    else if (constexpr.ALL_NEQ_EPI8(b, 0))
                    {
                        v256 INV_POW2 = new v256(0, 1 << 7, 1 << 6, 1 << 5, 1 << 4, 1 << 3, 1 << 2, 1 << 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                 0, 1 << 7, 1 << 6, 1 << 5, 1 << 4, 1 << 3, 1 << 2, 1 << 1, 0, 0, 0, 0, 0, 0, 0, 0);

                        result = mm256_mulhi_epu8(a, Avx2.mm256_shuffle_epi8(INV_POW2, b));

                        goto RET;
                    }
                }

                //if (Avx512.IsAvx512Supported)
                //{
                //    v256 loA16 = mm256_cvt2x2epi8_epi16(a, out v256 hiA16);
                //    v256 loB16 = mm256_cvt2x2epi8_epi16(b, out v256 hiB16);
                //
                //    v256 r16Lo = mm256_srlv_epi16(loA16, loB16);
                //    v256 r16Hi = mm256_srlv_epi16(hiA16, hiB16);
                //
                //    result = Avx2.mm256_packus_epi16(r16Lo, r16Hi);
                //}
                //else
                {
                    mm256_cvt4x4epu8_epi32(a, out v256 a0, out v256 a1, out v256 a2, out v256 a3);
                    mm256_cvt4x4epu8_epi32(b, out v256 b0, out v256 b1, out v256 b2, out v256 b3);

                    v256 r0 = Avx2.mm256_srlv_epi32(a0, b0);
                    v256 r1 = Avx2.mm256_srlv_epi32(a1, b1);
                    v256 r2 = Avx2.mm256_srlv_epi32(a2, b2);
                    v256 r3 = Avx2.mm256_srlv_epi32(a3, b3);

                    result = mm256_cvt4x4epi32_epi8(r0, r1, r2, r3, signed: false, noOverflowU16: true, noOverflowU8: true);
                }

            RET:
                constexpr.ASSUME(result.Byte0  == (b.Byte0  > 7 ? 0 : (byte)(a.Byte0  >> b.Byte0)));
                constexpr.ASSUME(result.Byte1  == (b.Byte1  > 7 ? 0 : (byte)(a.Byte1  >> b.Byte1)));
                constexpr.ASSUME(result.Byte2  == (b.Byte2  > 7 ? 0 : (byte)(a.Byte2  >> b.Byte2)));
                constexpr.ASSUME(result.Byte3  == (b.Byte3  > 7 ? 0 : (byte)(a.Byte3  >> b.Byte3)));
                constexpr.ASSUME(result.Byte4  == (b.Byte4  > 7 ? 0 : (byte)(a.Byte4  >> b.Byte4)));
                constexpr.ASSUME(result.Byte5  == (b.Byte5  > 7 ? 0 : (byte)(a.Byte5  >> b.Byte5)));
                constexpr.ASSUME(result.Byte6  == (b.Byte6  > 7 ? 0 : (byte)(a.Byte6  >> b.Byte6)));
                constexpr.ASSUME(result.Byte7  == (b.Byte7  > 7 ? 0 : (byte)(a.Byte7  >> b.Byte7)));
                constexpr.ASSUME(result.Byte8  == (b.Byte8  > 7 ? 0 : (byte)(a.Byte8  >> b.Byte8)));
                constexpr.ASSUME(result.Byte9  == (b.Byte9  > 7 ? 0 : (byte)(a.Byte9  >> b.Byte9)));
                constexpr.ASSUME(result.Byte10 == (b.Byte10 > 7 ? 0 : (byte)(a.Byte10 >> b.Byte10)));
                constexpr.ASSUME(result.Byte11 == (b.Byte11 > 7 ? 0 : (byte)(a.Byte11 >> b.Byte11)));
                constexpr.ASSUME(result.Byte12 == (b.Byte12 > 7 ? 0 : (byte)(a.Byte12 >> b.Byte12)));
                constexpr.ASSUME(result.Byte13 == (b.Byte13 > 7 ? 0 : (byte)(a.Byte13 >> b.Byte13)));
                constexpr.ASSUME(result.Byte14 == (b.Byte14 > 7 ? 0 : (byte)(a.Byte14 >> b.Byte14)));
                constexpr.ASSUME(result.Byte15 == (b.Byte15 > 7 ? 0 : (byte)(a.Byte15 >> b.Byte15)));
                constexpr.ASSUME(result.Byte16 == (b.Byte16 > 7 ? 0 : (byte)(a.Byte16 >> b.Byte16)));
                constexpr.ASSUME(result.Byte17 == (b.Byte17 > 7 ? 0 : (byte)(a.Byte17 >> b.Byte17)));
                constexpr.ASSUME(result.Byte18 == (b.Byte18 > 7 ? 0 : (byte)(a.Byte18 >> b.Byte18)));
                constexpr.ASSUME(result.Byte19 == (b.Byte19 > 7 ? 0 : (byte)(a.Byte19 >> b.Byte19)));
                constexpr.ASSUME(result.Byte20 == (b.Byte20 > 7 ? 0 : (byte)(a.Byte20 >> b.Byte20)));
                constexpr.ASSUME(result.Byte21 == (b.Byte21 > 7 ? 0 : (byte)(a.Byte21 >> b.Byte21)));
                constexpr.ASSUME(result.Byte22 == (b.Byte22 > 7 ? 0 : (byte)(a.Byte22 >> b.Byte22)));
                constexpr.ASSUME(result.Byte23 == (b.Byte23 > 7 ? 0 : (byte)(a.Byte23 >> b.Byte23)));
                constexpr.ASSUME(result.Byte24 == (b.Byte24 > 7 ? 0 : (byte)(a.Byte24 >> b.Byte24)));
                constexpr.ASSUME(result.Byte25 == (b.Byte25 > 7 ? 0 : (byte)(a.Byte25 >> b.Byte25)));
                constexpr.ASSUME(result.Byte26 == (b.Byte26 > 7 ? 0 : (byte)(a.Byte26 >> b.Byte26)));
                constexpr.ASSUME(result.Byte27 == (b.Byte27 > 7 ? 0 : (byte)(a.Byte27 >> b.Byte27)));
                constexpr.ASSUME(result.Byte28 == (b.Byte28 > 7 ? 0 : (byte)(a.Byte28 >> b.Byte28)));
                constexpr.ASSUME(result.Byte29 == (b.Byte29 > 7 ? 0 : (byte)(a.Byte29 >> b.Byte29)));
                constexpr.ASSUME(result.Byte30 == (b.Byte30 > 7 ? 0 : (byte)(a.Byte30 >> b.Byte30)));
                constexpr.ASSUME(result.Byte31 == (b.Byte31 > 7 ? 0 : (byte)(a.Byte31 >> b.Byte31)));
                
                if (constexpr.ALL_LE_EPU8(b, 7))
                {
                    constexpr.ASSUME(result.Byte0  <= (byte)(byte.MaxValue >> b.Byte0));
                    constexpr.ASSUME(result.Byte1  <= (byte)(byte.MaxValue >> b.Byte1));
                    constexpr.ASSUME(result.Byte2  <= (byte)(byte.MaxValue >> b.Byte2));
                    constexpr.ASSUME(result.Byte3  <= (byte)(byte.MaxValue >> b.Byte3));
                    constexpr.ASSUME(result.Byte4  <= (byte)(byte.MaxValue >> b.Byte4));
                    constexpr.ASSUME(result.Byte5  <= (byte)(byte.MaxValue >> b.Byte5));
                    constexpr.ASSUME(result.Byte6  <= (byte)(byte.MaxValue >> b.Byte6));
                    constexpr.ASSUME(result.Byte7  <= (byte)(byte.MaxValue >> b.Byte7));
                    constexpr.ASSUME(result.Byte8  <= (byte)(byte.MaxValue >> b.Byte8));
                    constexpr.ASSUME(result.Byte9  <= (byte)(byte.MaxValue >> b.Byte9));
                    constexpr.ASSUME(result.Byte10 <= (byte)(byte.MaxValue >> b.Byte10));
                    constexpr.ASSUME(result.Byte11 <= (byte)(byte.MaxValue >> b.Byte11));
                    constexpr.ASSUME(result.Byte12 <= (byte)(byte.MaxValue >> b.Byte12));
                    constexpr.ASSUME(result.Byte13 <= (byte)(byte.MaxValue >> b.Byte13));
                    constexpr.ASSUME(result.Byte14 <= (byte)(byte.MaxValue >> b.Byte14));
                    constexpr.ASSUME(result.Byte15 <= (byte)(byte.MaxValue >> b.Byte15));
                    constexpr.ASSUME(result.Byte16 <= (byte)(byte.MaxValue >> b.Byte16));
                    constexpr.ASSUME(result.Byte17 <= (byte)(byte.MaxValue >> b.Byte17));
                    constexpr.ASSUME(result.Byte18 <= (byte)(byte.MaxValue >> b.Byte18));
                    constexpr.ASSUME(result.Byte19 <= (byte)(byte.MaxValue >> b.Byte19));
                    constexpr.ASSUME(result.Byte20 <= (byte)(byte.MaxValue >> b.Byte20));
                    constexpr.ASSUME(result.Byte21 <= (byte)(byte.MaxValue >> b.Byte21));
                    constexpr.ASSUME(result.Byte22 <= (byte)(byte.MaxValue >> b.Byte22));
                    constexpr.ASSUME(result.Byte23 <= (byte)(byte.MaxValue >> b.Byte23));
                    constexpr.ASSUME(result.Byte24 <= (byte)(byte.MaxValue >> b.Byte24));
                    constexpr.ASSUME(result.Byte25 <= (byte)(byte.MaxValue >> b.Byte25));
                    constexpr.ASSUME(result.Byte26 <= (byte)(byte.MaxValue >> b.Byte26));
                    constexpr.ASSUME(result.Byte27 <= (byte)(byte.MaxValue >> b.Byte27));
                    constexpr.ASSUME(result.Byte28 <= (byte)(byte.MaxValue >> b.Byte28));
                    constexpr.ASSUME(result.Byte29 <= (byte)(byte.MaxValue >> b.Byte29));
                    constexpr.ASSUME(result.Byte30 <= (byte)(byte.MaxValue >> b.Byte30));
                    constexpr.ASSUME(result.Byte31 <= (byte)(byte.MaxValue >> b.Byte31));
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srav_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_srai_epi8(a, b.Byte0);
                }

                v256 result;

                if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                {
                    v256 LOOKUP = new v256((sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                           (sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    result = Avx2.mm256_shuffle_epi8(LOOKUP, b);
                }
                //else if (Avx512.IsAvx512Supported)
                //{
                //    v256 loA16 = mm256_cvt2x2epi8_epi16(a, out v256 hiA16);
                //    v256 loB16 = mm256_cvt2x2epi8_epi16(b, out v256 hiB16);
                //
                //    v256 r16Lo = mm256_srav_epi16(loA16, loB16);
                //    v256 r16Hi = mm256_srav_epi16(hiA16, hiB16);
                //
                //    result = Avx2.mm256_packs_epi16(r16Lo, r16Hi);
                //}
                else
                {
                    mm256_cvt4x4epi8_epi32(a, out v256 a0, out v256 a1, out v256 a2, out v256 a3);
                    mm256_cvt4x4epu8_epi32(b, out v256 b0, out v256 b1, out v256 b2, out v256 b3);

                    v256 r0 = Avx2.mm256_srav_epi32(a0, b0);
                    v256 r1 = Avx2.mm256_srav_epi32(a1, b1);
                    v256 r2 = Avx2.mm256_srav_epi32(a2, b2);
                    v256 r3 = Avx2.mm256_srav_epi32(a3, b3);

                    result = mm256_cvt4x4epi32_epi8(r0, r1, r2, r3, signed: true, noOverflowU16: true, noOverflowU8: true);
                }

                constexpr.ASSUME(result.SByte0  == (b.SByte0  < 0 || b.SByte0  > 7 ? 0 : (sbyte)(a.SByte0  >> b.SByte0)));
                constexpr.ASSUME(result.SByte1  == (b.SByte1  < 0 || b.SByte1  > 7 ? 0 : (sbyte)(a.SByte1  >> b.SByte1)));
                constexpr.ASSUME(result.SByte2  == (b.SByte2  < 0 || b.SByte2  > 7 ? 0 : (sbyte)(a.SByte2  >> b.SByte2)));
                constexpr.ASSUME(result.SByte3  == (b.SByte3  < 0 || b.SByte3  > 7 ? 0 : (sbyte)(a.SByte3  >> b.SByte3)));
                constexpr.ASSUME(result.SByte4  == (b.SByte4  < 0 || b.SByte4  > 7 ? 0 : (sbyte)(a.SByte4  >> b.SByte4)));
                constexpr.ASSUME(result.SByte5  == (b.SByte5  < 0 || b.SByte5  > 7 ? 0 : (sbyte)(a.SByte5  >> b.SByte5)));
                constexpr.ASSUME(result.SByte6  == (b.SByte6  < 0 || b.SByte6  > 7 ? 0 : (sbyte)(a.SByte6  >> b.SByte6)));
                constexpr.ASSUME(result.SByte7  == (b.SByte7  < 0 || b.SByte7  > 7 ? 0 : (sbyte)(a.SByte7  >> b.SByte7)));
                constexpr.ASSUME(result.SByte8  == (b.SByte8  < 0 || b.SByte8  > 7 ? 0 : (sbyte)(a.SByte8  >> b.SByte8)));
                constexpr.ASSUME(result.SByte9  == (b.SByte9  < 0 || b.SByte9  > 7 ? 0 : (sbyte)(a.SByte9  >> b.SByte9)));
                constexpr.ASSUME(result.SByte10 == (b.SByte10 < 0 || b.SByte10 > 7 ? 0 : (sbyte)(a.SByte10 >> b.SByte10)));
                constexpr.ASSUME(result.SByte11 == (b.SByte11 < 0 || b.SByte11 > 7 ? 0 : (sbyte)(a.SByte11 >> b.SByte11)));
                constexpr.ASSUME(result.SByte12 == (b.SByte12 < 0 || b.SByte12 > 7 ? 0 : (sbyte)(a.SByte12 >> b.SByte12)));
                constexpr.ASSUME(result.SByte13 == (b.SByte13 < 0 || b.SByte13 > 7 ? 0 : (sbyte)(a.SByte13 >> b.SByte13)));
                constexpr.ASSUME(result.SByte14 == (b.SByte14 < 0 || b.SByte14 > 7 ? 0 : (sbyte)(a.SByte14 >> b.SByte14)));
                constexpr.ASSUME(result.SByte15 == (b.SByte15 < 0 || b.SByte15 > 7 ? 0 : (sbyte)(a.SByte15 >> b.SByte15)));
                constexpr.ASSUME(result.SByte16 == (b.SByte16 < 0 || b.SByte16 > 7 ? 0 : (sbyte)(a.SByte16 >> b.SByte16)));
                constexpr.ASSUME(result.SByte17 == (b.SByte17 < 0 || b.SByte17 > 7 ? 0 : (sbyte)(a.SByte17 >> b.SByte17)));
                constexpr.ASSUME(result.SByte18 == (b.SByte18 < 0 || b.SByte18 > 7 ? 0 : (sbyte)(a.SByte18 >> b.SByte18)));
                constexpr.ASSUME(result.SByte19 == (b.SByte19 < 0 || b.SByte19 > 7 ? 0 : (sbyte)(a.SByte19 >> b.SByte19)));
                constexpr.ASSUME(result.SByte20 == (b.SByte20 < 0 || b.SByte20 > 7 ? 0 : (sbyte)(a.SByte20 >> b.SByte20)));
                constexpr.ASSUME(result.SByte21 == (b.SByte21 < 0 || b.SByte21 > 7 ? 0 : (sbyte)(a.SByte21 >> b.SByte21)));
                constexpr.ASSUME(result.SByte22 == (b.SByte22 < 0 || b.SByte22 > 7 ? 0 : (sbyte)(a.SByte22 >> b.SByte22)));
                constexpr.ASSUME(result.SByte23 == (b.SByte23 < 0 || b.SByte23 > 7 ? 0 : (sbyte)(a.SByte23 >> b.SByte23)));
                constexpr.ASSUME(result.SByte24 == (b.SByte24 < 0 || b.SByte24 > 7 ? 0 : (sbyte)(a.SByte24 >> b.SByte24)));
                constexpr.ASSUME(result.SByte25 == (b.SByte25 < 0 || b.SByte25 > 7 ? 0 : (sbyte)(a.SByte25 >> b.SByte25)));
                constexpr.ASSUME(result.SByte26 == (b.SByte26 < 0 || b.SByte26 > 7 ? 0 : (sbyte)(a.SByte26 >> b.SByte26)));
                constexpr.ASSUME(result.SByte27 == (b.SByte27 < 0 || b.SByte27 > 7 ? 0 : (sbyte)(a.SByte27 >> b.SByte27)));
                constexpr.ASSUME(result.SByte28 == (b.SByte28 < 0 || b.SByte28 > 7 ? 0 : (sbyte)(a.SByte28 >> b.SByte28)));
                constexpr.ASSUME(result.SByte29 == (b.SByte29 < 0 || b.SByte29 > 7 ? 0 : (sbyte)(a.SByte29 >> b.SByte29)));
                constexpr.ASSUME(result.SByte30 == (b.SByte30 < 0 || b.SByte30 > 7 ? 0 : (sbyte)(a.SByte30 >> b.SByte30)));
                constexpr.ASSUME(result.SByte31 == (b.SByte31 < 0 || b.SByte31 > 7 ? 0 : (sbyte)(a.SByte31 >> b.SByte31)));

                return result;
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sll_epi16(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 15ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sll_epi16(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 16);

                if (!inRange && (count.ULong0 & ~15ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vdupq_n_s16(count.SShort0));
                }
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srl_epi16(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 15ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.srl_epi16(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 16);

                if (!inRange && (count.ULong0 & ~15ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u16(a, Arm.Neon.vdupq_n_s16((short)-count.SShort0));
                }
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sra_epi16(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 15ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sra_epi16(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 16);

                if (!inRange && (count.ULong0 & ~15ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s16(a, 15);
                }
                else
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vdupq_n_s16((short)-count.SShort0));
                }
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi16(v128 a, int n, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return sll_epi16(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srli_epi16(v128 a, int n, bool inRange = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
                return srl_epi16(a, cvtsi32_si128(n), inRange);
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi16(v128 a, int n, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return sra_epi16(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi16(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi16(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi16(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi16(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi16(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi16(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi16(v128 a, v128 b, bool inRange = false, bool noOverflow = false, byte elements = 8)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<ushort8, ushort>(b, 0, 15, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return slli_epi16(a, b.UShort0);
                }

                v128 result;

                if (Ssse3.IsSsse3Supported)
                {
                    if (SHL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v128 shuffle, elements))
                    {
                        result = shuffle_epi8(a, shuffle, elements);

                        goto RET;
                    }
                }

                //if (BurstArchitecture.IsVectorShift16Supported)
                //{
                //    ;
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        v128 __b = min_epu16(b, set1_epi16(16));

                        v128 mask = new v128((ushort)((1 << __b.UShort0) - 1),
                                             (ushort)((1 << __b.UShort1) - 1),
                                             (ushort)((1 << __b.UShort2) - 1),
                                             (ushort)((1 << __b.UShort3) - 1),
                                             (ushort)((1 << __b.UShort4) - 1),
                                             (ushort)((1 << __b.UShort5) - 1),
                                             (ushort)((1 << __b.UShort6) - 1),
                                             (ushort)((1 << __b.UShort7) - 1));

                        switch (elements)
                        {
                            case 2:
                            case 3:
                            {
                                if (__b.UShort0 == __b.UShort1)
                                {
                                    __b = and_si128(__b, set1_epi32(ushort.MaxValue));
                                    v128 shift32 = Avx2.sllv_epi32(a, __b);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            case 4:
                            {
                                if (__b.UShort0 == __b.UShort1
                                 && __b.UShort2 == __b.UShort3)
                                {
                                    __b = and_si128(__b, set1_epi32(ushort.MaxValue));
                                    v128 shift32 = Avx2.sllv_epi32(a, __b);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            default:
                            {
                                if (__b.UShort0 == __b.UShort1
                                 && __b.UShort2 == __b.UShort3
                                 && __b.UShort4 == __b.UShort5
                                 && __b.UShort6 == __b.UShort7)
                                {
                                    __b = and_si128(__b, set1_epi32(ushort.MaxValue));
                                    v128 shift32 = Avx2.sllv_epi32(a, __b);
                                    result = andnot_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                        }
                    }

                    if (elements > 4)
                    {
                        v128 aLo = cvt2x2epu16_epi32(a, out v128 aHi);
                        v128 bLo = cvt2x2epu16_epi32(b, out v128 bHi);

                        aLo = sllv_epi32(aLo, bLo);
                        aHi = sllv_epi32(aHi, bHi);

                        result = noOverflow ? packs_epi32(aLo, aHi) : cvt2x2epi32_epi16(aLo, aHi);
                    }
                    else
                    {
                        result = cvtepi32_epi16(sllv_epi32(cvtepu16_epi32(a), cvtepu16_epi32(b)), elements);
                    }
                }
                else if (constexpr.IS_CONST(b))
                {
                    result = mullo_epi16(a, new v128((short)(b.UShort0 > 15 ? 0 : (1 << b.SShort0)), 
                                                     (short)(b.UShort1 > 15 ? 0 : (1 << b.SShort1)), 
                                                     (short)(b.UShort2 > 15 ? 0 : (1 << b.SShort2)), 
                                                     (short)(b.UShort3 > 15 ? 0 : (1 << b.SShort3)), 
                                                     (short)(b.UShort4 > 15 ? 0 : (1 << b.SShort4)), 
                                                     (short)(b.UShort5 > 15 ? 0 : (1 << b.SShort5)), 
                                                     (short)(b.UShort6 > 15 ? 0 : (1 << b.SShort6)), 
                                                     (short)(b.UShort7 > 15 ? 0 : (1 << b.SShort7))));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        if (elements <= 3)
                        {
                            v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

                            v128 _x = sll_epi16(a, shuffle_epi8(b, shuffleMask));
                            shuffleMask = insert_epi8(shuffleMask, 2, 0);
                            v128 _y = sll_epi16(a, shuffle_epi8(b, shuffleMask));
                            v128 _xy = blend_epi16(_x, _y, 0b0000_0010);

                            if (elements == 2)
                            {
                                result = _xy;
                                goto RET;
                            }

                            shuffleMask = insert_epi8(shuffleMask, 4, 0);
                            v128 _z = sll_epi16(a, shuffle_epi8(b, shuffleMask));

                            result = blend_epi16(_xy, _z, 0b0000_0100);
                            goto RET;
                        }
                    }

                    v128 POW2_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,       0, 0, 0, 0, 0, 0, 0, 0);

                    v128 mulValues = packus_epi16(b, b);
                    v128 pow8to15 = sub_epi8(mulValues, set1_epi8(8));

                    pow8to15 = shuffle_epi8(POW2_MASK, pow8to15);
                    v128 mulLo = shuffle_epi8(POW2_MASK, mulValues);

                    mulValues = unpacklo_epi8(mulLo, pow8to15);

                    if (constexpr.ALL_EQ_EPI16(a, 1, elements))
                    {
                        result = mulValues;
                    }
                    else
                    {
                        result = mullo_epi16(a, andnot_si128(cmpgt_epu16(b, set1_epi16(15)), mulValues));
                    }
                }
                else
                {
                    v128 EPI16_MASK = new v128(ushort.MaxValue, 0, 0, 0);
                    v128 elementMask = EPI16_MASK;

                    v128 __b = b;

                    result = sll_epi16(a, and_si128(__b, EPI16_MASK));
                    result = and_si128(result, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    __b = bsrli_si128(__b, sizeof(short));
                    v128 result1 = sll_epi16(a, and_si128(__b, EPI16_MASK));
                    result1 = and_si128(result1, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    result = or_si128(result, result1);

                    if (elements > 2)
                    {
                        __b = bsrli_si128(__b, sizeof(short));
                        result1 = sll_epi16(a, and_si128(__b, EPI16_MASK));
                        result1 = and_si128(result1, elementMask);
                        elementMask = bslli_si128(elementMask, sizeof(short));
                        result = or_si128(result, result1);

                        if (elements > 3)
                        {
                            __b = bsrli_si128(__b, sizeof(short));
                            result1 = sll_epi16(a, and_si128(__b, EPI16_MASK));
                            result1 = and_si128(result1, elementMask);
                            elementMask = bslli_si128(elementMask, sizeof(short));
                            result = or_si128(result, result1);

                            if (elements > 4)
                            {
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sll_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sll_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sll_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sll_epi16(a, __b);
                                result1 = and_si128(result1, elementMask);
                                result = or_si128(result, result1);
                            }
                        }
                    }
                }

            RET: 
                
                constexpr.ASSUME(result.UShort0 == (inRange ? (ushort)(a.UShort0 << b.UShort0) : (b.UShort0 > 15 ? 0 : (ushort)(a.UShort0 << b.UShort0))));
                constexpr.ASSUME(result.UShort1 == (inRange ? (ushort)(a.UShort1 << b.UShort1) : (b.UShort1 > 15 ? 0 : (ushort)(a.UShort1 << b.UShort1))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.UShort2 == (inRange ? (ushort)(a.UShort2 << b.UShort2) : (b.UShort2 > 15 ? 0 : (ushort)(a.UShort2 << b.UShort2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.UShort3 == (inRange ? (ushort)(a.UShort3 << b.UShort3) : (b.UShort3 > 15 ? 0 : (ushort)(a.UShort3 << b.UShort3))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.UShort4 == (inRange ? (ushort)(a.UShort4 << b.UShort4) : (b.UShort4 > 15 ? 0 : (ushort)(a.UShort4 << b.UShort4))));
                            constexpr.ASSUME(result.UShort5 == (inRange ? (ushort)(a.UShort5 << b.UShort5) : (b.UShort5 > 15 ? 0 : (ushort)(a.UShort5 << b.UShort5))));
                            constexpr.ASSUME(result.UShort6 == (inRange ? (ushort)(a.UShort6 << b.UShort6) : (b.UShort6 > 15 ? 0 : (ushort)(a.UShort6 << b.UShort6))));
                            constexpr.ASSUME(result.UShort7 == (inRange ? (ushort)(a.UShort7 << b.UShort7) : (b.UShort7 > 15 ? 0 : (ushort)(a.UShort7 << b.UShort7))));
                        }
                    }
                }

                if (constexpr.ALL_LE_EPU16(b, 15))
                {
                    constexpr.ASSUME((result.UShort0 & ((1 << b.UShort0) - 1)) == 0);
                    constexpr.ASSUME((result.UShort1 & ((1 << b.UShort1) - 1)) == 0);

                    if (elements > 2)
                    {
                        constexpr.ASSUME((result.UShort2 & ((1 << b.UShort2) - 1)) == 0);

                        if (elements > 3)
                        {
                            constexpr.ASSUME((result.UShort3 & ((1 << b.UShort3) - 1)) == 0);

                            if (elements > 4)
                            {
                                constexpr.ASSUME((result.UShort4 & ((1 << b.UShort4) - 1)) == 0);
                                constexpr.ASSUME((result.UShort5 & ((1 << b.UShort5) - 1)) == 0);
                                constexpr.ASSUME((result.UShort6 & ((1 << b.UShort6) - 1)) == 0);
                                constexpr.ASSUME((result.UShort7 & ((1 << b.UShort7) - 1)) == 0);
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU16(b, 15, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u16(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u16(Arm.Neon.vshlq_u16(a, b), Arm.Neon.vcltq_u16(b, set1_epi16(16)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi16(v128 a, v128 b, bool inRange = false, byte elements = 8)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<ushort8, ushort>(b, 0, 15, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return srli_epi16(a, b.UShort0, inRange);
                }

                v128 result;

                //if (BurstArchitecture.IsVectorShift16Supported)
                //{
                //    ;
                //}
                //else
                //{
                //}

                if (Ssse3.IsSsse3Supported)
                {
                    if (SHR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v128 shuffle, elements))
                    {
                        result = shuffle_epi8(a, shuffle, elements);
                        goto RET;
                    }
                }
                
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        v128 __b = min_epu16(b, set1_epi16(16));

                        v128 mask = new v128((ushort)((1 << (16 - __b.UShort0)) - 1),
                                             (ushort)((1 << (16 - __b.UShort1)) - 1),
                                             (ushort)((1 << (16 - __b.UShort2)) - 1),
                                             (ushort)((1 << (16 - __b.UShort3)) - 1),
                                             (ushort)((1 << (16 - __b.UShort4)) - 1),
                                             (ushort)((1 << (16 - __b.UShort5)) - 1),
                                             (ushort)((1 << (16 - __b.UShort6)) - 1),
                                             (ushort)((1 << (16 - __b.UShort7)) - 1));

                        switch (elements)
                        {
                            case 2:
                            case 3:
                            {
                                if (__b.UShort0 == __b.UShort1)
                                {
                                    __b = and_si128(__b, set1_epi32(ushort.MaxValue));
                                    v128 shift32 = Avx2.srlv_epi32(a, __b);
                                    result = and_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            case 4:
                            {
                                if (__b.UShort0 == __b.UShort1
                                 && __b.UShort2 == __b.UShort3)
                                {
                                    __b = and_si128(__b, set1_epi32(ushort.MaxValue));
                                    v128 shift32 = Avx2.srlv_epi32(a, __b);
                                    result = and_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                            default:
                            {
                                if (__b.UShort0 == __b.UShort1
                                 && __b.UShort2 == __b.UShort3
                                 && __b.UShort4 == __b.UShort5
                                 && __b.UShort6 == __b.UShort7)
                                {
                                    __b = and_si128(__b, set1_epi32(ushort.MaxValue));
                                    v128 shift32 = Avx2.srlv_epi32(a, __b);
                                    result = and_si128(mask, shift32);

                                    goto RET;
                                }

                                break;
                            }
                        }
                    }
                }

                if (constexpr.IS_CONST(b)
                 && constexpr.ALL_NEQ_EPI16(b, 0, elements))
                {
                    v128 INV_POW2_LO = new v128(0, 1 << 15, 1 << 14, 1 << 13, 1 << 12, 1 << 11, 1 << 10, 1 << 9);
                    v128 INV_POW2_HI = new v128(1 << 8, 1 << 7, 1 << 6, 1 << 5, 1 << 4, 1 << 3, 1 << 2, 1 << 1);
                
                    v128 shiftGE8 = cmpgt_epi16(b, set1_epi16(7));
                    v128 shuf = blendv_si128(shuffle_epi16(INV_POW2_LO, b), shuffle_epi16(INV_POW2_HI, sub_epi16(b, set1_epi16(8))), shiftGE8);

                    result = mulhi_epu16(a, andnot_si128(cmpgt_epu16(b, set1_epi16(15)), shuf));
                }
                else if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 a32Lo = cvt2x2epu16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epu16_epi32(b, out v128 b32Hi);

                        v128 lo = srlv_epi32(a32Lo, b32Lo);
                        v128 hi = srlv_epi32(a32Hi, b32Hi);

                        result = packus_epi32(lo, hi);
                    }
                    else
                    {
                        result = cvtepi32_epi16(srlv_epi32(cvtepu16_epi32(a), cvtepu16_epi32(b)), elements);
                    }
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

                    v128 _x = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 2, 0);
                    v128 _y = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_0010);

                    if (elements == 2)
                    {
                        result = _xy;
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _z = srl_epi16(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        result = blend_epi16(_xy, _z, 0b0000_0100);
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 6, 0);
                    v128 _w = srl_epi16(a, shuffle_epi8(b, shuffleMask));

                    v128 _zw = blend_epi16(_z, _w, 0b0000_1000);

                    result = blend_epi16(_xy, _zw, 0b0000_1100);

                    if (elements == 4)
                    {
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0001_0000);

                    shuffleMask = insert_epi8(shuffleMask, 10, 0);
                    shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0010_0000);

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0100_0000);

                    shuffleMask = insert_epi8(shuffleMask, 14, 0);
                    shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b1000_0000);
                }
                else
                {
                    v128 EPI16_MASK = new v128(ushort.MaxValue, 0, 0, 0);
                    v128 elementMask = EPI16_MASK;

                    v128 __b = b;

                    result = srl_epi16(a, and_si128(__b, EPI16_MASK));
                    result = and_si128(result, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    __b = bsrli_si128(__b, sizeof(short));
                    v128 result1 = srl_epi16(a, and_si128(__b, EPI16_MASK));
                    result1 = and_si128(result1, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    result = or_si128(result, result1);

                    if (elements > 2)
                    {
                        __b = bsrli_si128(__b, sizeof(short));
                        result1 = srl_epi16(a, and_si128(__b, EPI16_MASK));
                        result1 = and_si128(result1, elementMask);
                        elementMask = bslli_si128(elementMask, sizeof(short));
                        result = or_si128(result, result1);

                        if (elements > 3)
                        {
                            __b = bsrli_si128(__b, sizeof(short));
                            result1 = srl_epi16(a, and_si128(__b, EPI16_MASK));
                            result1 = and_si128(result1, elementMask);
                            elementMask = bslli_si128(elementMask, sizeof(short));
                            result = or_si128(result, result1);

                            if (elements > 4)
                            {
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = srl_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = srl_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = srl_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = srl_epi16(a, __b);
                                result1 = and_si128(result1, elementMask);
                                result = or_si128(result, result1);
                            }
                        }
                    }
                }

            RET:
                
                constexpr.ASSUME(result.UShort0 == (inRange ? (ushort)(a.UShort0 >> b.UShort0) : (b.UShort0 > 15 ? 0 : (ushort)(a.UShort0 >> b.UShort0))));
                constexpr.ASSUME(result.UShort1 == (inRange ? (ushort)(a.UShort1 >> b.UShort1) : (b.UShort1 > 15 ? 0 : (ushort)(a.UShort1 >> b.UShort1))));
                if (elements > 2)
                {
                    constexpr.ASSUME(result.UShort2 == (inRange ? (ushort)(a.UShort2 >> b.UShort2) : (b.UShort2 > 15 ? 0 : (ushort)(a.UShort2 >> b.UShort2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.UShort3 == (inRange ? (ushort)(a.UShort3 >> b.UShort3) : (b.UShort3 > 15 ? 0 : (ushort)(a.UShort3 >> b.UShort3))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.UShort4 == (inRange ? (ushort)(a.UShort4 >> b.UShort4) : (b.UShort4 > 15 ? 0 : (ushort)(a.UShort4 >> b.UShort4))));
                            constexpr.ASSUME(result.UShort5 == (inRange ? (ushort)(a.UShort5 >> b.UShort5) : (b.UShort5 > 15 ? 0 : (ushort)(a.UShort5 >> b.UShort5))));
                            constexpr.ASSUME(result.UShort6 == (inRange ? (ushort)(a.UShort6 >> b.UShort6) : (b.UShort6 > 15 ? 0 : (ushort)(a.UShort6 >> b.UShort6))));
                            constexpr.ASSUME(result.UShort7 == (inRange ? (ushort)(a.UShort7 >> b.UShort7) : (b.UShort7 > 15 ? 0 : (ushort)(a.UShort7 >> b.UShort7))));
                        }
                    }
                }

                if (constexpr.ALL_LE_EPU16(b, 15))
                {
                    constexpr.ASSUME(result.UShort0 <= (ushort)(ushort.MaxValue >> b.UShort0));
                    constexpr.ASSUME(result.UShort1 <= (ushort)(ushort.MaxValue >> b.UShort1));

                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.UShort2 <= (ushort)(ushort.MaxValue >> b.UShort2));

                        if (elements > 3)
                        {
                            constexpr.ASSUME(result.UShort3 <= (ushort)(ushort.MaxValue >> b.UShort3));

                            if (elements > 4)
                            {
                                constexpr.ASSUME(result.UShort4 <= (ushort)(ushort.MaxValue >> b.UShort4));
                                constexpr.ASSUME(result.UShort5 <= (ushort)(ushort.MaxValue >> b.UShort5));
                                constexpr.ASSUME(result.UShort6 <= (ushort)(ushort.MaxValue >> b.UShort6));
                                constexpr.ASSUME(result.UShort7 <= (ushort)(ushort.MaxValue >> b.UShort7));
                            }
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU16(b, 15, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u16(a, Arm.Neon.vnegq_s16(b));
                }
                else
                {
                    return Arm.Neon.vshlq_u16(a, Arm.Neon.vnegq_s16(Arm.Neon.vminq_u16(b, Arm.Neon.vdupq_n_u16(15))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi16(v128 a, v128 b, bool inRange = false, byte elements = 8)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<ushort8, ushort>(b, 0, 15, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return srai_epi16(a, b.UShort0, inRange);
                }

                v128 result;

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 a32Lo = cvt2x2epi16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epi16_epi32(b, out v128 b32Hi);

                        v128 lo = srav_epi32(a32Lo, b32Lo);
                        v128 hi = srav_epi32(a32Hi, b32Hi);

                        result = packs_epi32(lo, hi);
                    }
                    else
                    {
                        result = cvtepi32_epi16(srav_epi32(cvtepi16_epi32(a), cvtepu16_epi32(b)), elements);
                    }
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

                    v128 _x = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 2, 0);
                    v128 _y = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_0010);

                    if (elements == 2)
                    {
                        result = _xy;
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _z = sra_epi16(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        result = blend_epi16(_xy, _z, 0b0000_0100);
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 6, 0);
                    v128 _w = sra_epi16(a, shuffle_epi8(b, shuffleMask));

                    v128 _zw = blend_epi16(_z, _w, 0b0000_1000);

                    result = blend_epi16(_xy, _zw, 0b0000_1100);

                    if (elements == 4)
                    {
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0001_0000);

                    shuffleMask = insert_epi8(shuffleMask, 10, 0);
                    shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0010_0000);

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0100_0000);

                    shuffleMask =insert_epi8(shuffleMask, 14, 0);
                    shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b1000_0000);
                }
                else
                {
                    v128 EPI16_MASK = new v128(ushort.MaxValue, 0, 0, 0);
                    v128 elementMask = EPI16_MASK;

                    v128 __b = b;

                    result = sra_epi16(a, and_si128(__b, EPI16_MASK));
                    result = and_si128(result, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    __b = bsrli_si128(__b, sizeof(short));
                    v128 result1 = sra_epi16(a, and_si128(__b, EPI16_MASK));
                    result1 = and_si128(result1, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    result = or_si128(result, result1);

                    if (elements > 2)
                    {
                        __b = bsrli_si128(__b, sizeof(short));
                        result1 = sra_epi16(a, and_si128(__b, EPI16_MASK));
                        result1 = and_si128(result1, elementMask);
                        elementMask = bslli_si128(elementMask, sizeof(short));
                        result = or_si128(result, result1);

                        if (elements > 3)
                        {
                            __b = bsrli_si128(__b, sizeof(short));
                            result1 = sra_epi16(a, and_si128(__b, EPI16_MASK));
                            result1 = and_si128(result1, elementMask);
                            elementMask = bslli_si128(elementMask, sizeof(short));
                            result = or_si128(result, result1);

                            if (elements > 4)
                            {
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sra_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sra_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sra_epi16(a, and_si128(__b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result = or_si128(result, result1);
                                __b = bsrli_si128(__b, sizeof(short));
                                result1 = sra_epi16(a, __b);
                                result1 = and_si128(result1, elementMask);
                                result = or_si128(result, result1);
                            }
                        }
                    }
                }

            RET:
                
                constexpr.ASSUME(result.SShort0 == (inRange ? (short)(a.SShort0 >> b.SShort0) : (b.SShort0 < 0 || b.SShort0 > 15 ? 0 : (short)(a.SShort0 >> b.SShort0))));
                constexpr.ASSUME(result.SShort1 == (inRange ? (short)(a.SShort1 >> b.SShort1) : (b.SShort1 < 0 || b.SShort1 > 15 ? 0 : (short)(a.SShort1 >> b.SShort1))));
                if (elements > 2)
                {
                    constexpr.ASSUME(result.SShort2 == (inRange ? (short)(a.SShort2 >> b.SShort2) : (b.SShort2 < 0 || b.SShort2 > 15 ? 0 : (short)(a.SShort2 >> b.SShort2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.SShort3 == (inRange ? (short)(a.SShort3 >> b.SShort3) : (b.SShort3 < 0 || b.SShort3 > 15 ? 0 : (short)(a.SShort3 >> b.SShort3))));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.SShort4 == (inRange ? (short)(a.SShort4 >> b.SShort4) : (b.SShort4 < 0 || b.SShort4 > 15 ? 0 : (short)(a.SShort4 >> b.SShort4))));
                            constexpr.ASSUME(result.SShort5 == (inRange ? (short)(a.SShort5 >> b.SShort5) : (b.SShort5 < 0 || b.SShort5 > 15 ? 0 : (short)(a.SShort5 >> b.SShort5))));
                            constexpr.ASSUME(result.SShort6 == (inRange ? (short)(a.SShort6 >> b.SShort6) : (b.SShort6 < 0 || b.SShort6 > 15 ? 0 : (short)(a.SShort6 >> b.SShort6))));
                            constexpr.ASSUME(result.SShort7 == (inRange ? (short)(a.SShort7 >> b.SShort7) : (b.SShort7 < 0 || b.SShort7 > 15 ? 0 : (short)(a.SShort7 >> b.SShort7))));
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU16(b, 15, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vnegq_s16(b));
                }
                else
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vnegq_s16(Arm.Neon.vminq_u16(b, Arm.Neon.vdupq_n_u16(15))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sllv_epi16(v256 a, v256 b, bool noOverflow = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                //if (BurstArchitecture.IsVectorShift16Supported)
                //{
                //    ;
                //}
                //else
                //{
                //}

                if (constexpr.ALL_GE_EPU16(b, 16))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_slli_epi16(a, b.UShort0);
                }

                v256 result;

                if (SHL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v256 shuffle))
                {
                    result = Avx2.mm256_shuffle_epi8(a, shuffle);
                }
                else if (constexpr.IS_CONST(b))
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance 
                     && b.UShort0  == b.UShort1
                     && b.UShort2  == b.UShort3
                     && b.UShort4  == b.UShort5
                     && b.UShort6  == b.UShort7
                     && b.UShort8  == b.UShort9
                     && b.UShort10 == b.UShort11
                     && b.UShort12 == b.UShort13
                     && b.UShort14 == b.UShort15)
                    {
                        v256 __b = Avx2.mm256_min_epu16(b, mm256_set1_epi16(16));

                        v256 mask = new v256((ushort)((1 << __b.UShort0)  - 1),
                                             (ushort)((1 << __b.UShort1)  - 1),
                                             (ushort)((1 << __b.UShort2)  - 1),
                                             (ushort)((1 << __b.UShort3)  - 1),
                                             (ushort)((1 << __b.UShort4)  - 1),
                                             (ushort)((1 << __b.UShort5)  - 1),
                                             (ushort)((1 << __b.UShort6)  - 1),
                                             (ushort)((1 << __b.UShort7)  - 1),
                                             (ushort)((1 << __b.UShort8)  - 1),
                                             (ushort)((1 << __b.UShort9)  - 1),
                                             (ushort)((1 << __b.UShort10) - 1),
                                             (ushort)((1 << __b.UShort11) - 1),
                                             (ushort)((1 << __b.UShort12) - 1),
                                             (ushort)((1 << __b.UShort13) - 1),
                                             (ushort)((1 << __b.UShort14) - 1),
                                             (ushort)((1 << __b.UShort15) - 1));
                        
                        __b = Avx2.mm256_and_si256(__b, mm256_set1_epi32(ushort.MaxValue));
                        v256 shift32 = Avx2.mm256_sllv_epi32(a, __b);
                        result = Avx2.mm256_andnot_si256(mask, shift32);
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi16(a, new v256((short)(b.UShort0  > 15 ? 0 : 1 << b.SShort0), 
                                                                    (short)(b.UShort1  > 15 ? 0 : 1 << b.SShort1), 
                                                                    (short)(b.UShort2  > 15 ? 0 : 1 << b.SShort2), 
                                                                    (short)(b.UShort3  > 15 ? 0 : 1 << b.SShort3), 
                                                                    (short)(b.UShort4  > 15 ? 0 : 1 << b.SShort4), 
                                                                    (short)(b.UShort5  > 15 ? 0 : 1 << b.SShort5), 
                                                                    (short)(b.UShort6  > 15 ? 0 : 1 << b.SShort6), 
                                                                    (short)(b.UShort7  > 15 ? 0 : 1 << b.SShort7), 
                                                                    (short)(b.UShort8  > 15 ? 0 : 1 << b.SShort8), 
                                                                    (short)(b.UShort9  > 15 ? 0 : 1 << b.SShort9), 
                                                                    (short)(b.UShort10 > 15 ? 0 : 1 << b.SShort10), 
                                                                    (short)(b.UShort11 > 15 ? 0 : 1 << b.SShort11), 
                                                                    (short)(b.UShort12 > 15 ? 0 : 1 << b.SShort12), 
                                                                    (short)(b.UShort13 > 15 ? 0 : 1 << b.SShort13), 
                                                                    (short)(b.UShort14 > 15 ? 0 : 1 << b.SShort14), 
                                                                    (short)(b.UShort15 > 15 ? 0 : 1 << b.SShort15)));
                    }
                }
                else
                {
                    v256 aLo = mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                    v256 bLo = mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                    aLo = Avx2.mm256_sllv_epi32(aLo, bLo);
                    aHi = Avx2.mm256_sllv_epi32(aHi, bHi);

                    result = noOverflow ? Avx2.mm256_packs_epi32(aLo, aHi) : mm256_cvt2x2epi32_epi16(aLo, aHi);
                }

                constexpr.ASSUME(result.UShort0  == (b.UShort0  > 15 ? 0 : (ushort)(a.UShort0  << b.UShort0)));
                constexpr.ASSUME(result.UShort1  == (b.UShort1  > 15 ? 0 : (ushort)(a.UShort1  << b.UShort1)));
                constexpr.ASSUME(result.UShort2  == (b.UShort2  > 15 ? 0 : (ushort)(a.UShort2  << b.UShort2)));
                constexpr.ASSUME(result.UShort3  == (b.UShort3  > 15 ? 0 : (ushort)(a.UShort3  << b.UShort3)));
                constexpr.ASSUME(result.UShort4  == (b.UShort4  > 15 ? 0 : (ushort)(a.UShort4  << b.UShort4)));
                constexpr.ASSUME(result.UShort5  == (b.UShort5  > 15 ? 0 : (ushort)(a.UShort5  << b.UShort5)));
                constexpr.ASSUME(result.UShort6  == (b.UShort6  > 15 ? 0 : (ushort)(a.UShort6  << b.UShort6)));
                constexpr.ASSUME(result.UShort7  == (b.UShort7  > 15 ? 0 : (ushort)(a.UShort7  << b.UShort7)));
                constexpr.ASSUME(result.UShort8  == (b.UShort8  > 15 ? 0 : (ushort)(a.UShort8  << b.UShort8)));
                constexpr.ASSUME(result.UShort9  == (b.UShort9  > 15 ? 0 : (ushort)(a.UShort9  << b.UShort9)));
                constexpr.ASSUME(result.UShort10 == (b.UShort10 > 15 ? 0 : (ushort)(a.UShort10 << b.UShort10)));
                constexpr.ASSUME(result.UShort11 == (b.UShort11 > 15 ? 0 : (ushort)(a.UShort11 << b.UShort11)));
                constexpr.ASSUME(result.UShort12 == (b.UShort12 > 15 ? 0 : (ushort)(a.UShort12 << b.UShort12)));
                constexpr.ASSUME(result.UShort13 == (b.UShort13 > 15 ? 0 : (ushort)(a.UShort13 << b.UShort13)));
                constexpr.ASSUME(result.UShort14 == (b.UShort14 > 15 ? 0 : (ushort)(a.UShort14 << b.UShort14)));
                constexpr.ASSUME(result.UShort15 == (b.UShort15 > 15 ? 0 : (ushort)(a.UShort15 << b.UShort15)));

                if (constexpr.ALL_LE_EPU16(b, 15))
                {
                    constexpr.ASSUME((result.UShort0  & ((1 << b.UShort0)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort1  & ((1 << b.UShort1)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort2  & ((1 << b.UShort2)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort3  & ((1 << b.UShort3)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort4  & ((1 << b.UShort4)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort5  & ((1 << b.UShort5)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort6  & ((1 << b.UShort6)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort7  & ((1 << b.UShort7)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort8  & ((1 << b.UShort8)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort9  & ((1 << b.UShort9)  - 1)) == 0);
                    constexpr.ASSUME((result.UShort10 & ((1 << b.UShort10) - 1)) == 0);
                    constexpr.ASSUME((result.UShort11 & ((1 << b.UShort11) - 1)) == 0);
                    constexpr.ASSUME((result.UShort12 & ((1 << b.UShort12) - 1)) == 0);
                    constexpr.ASSUME((result.UShort13 & ((1 << b.UShort13) - 1)) == 0);
                    constexpr.ASSUME((result.UShort14 & ((1 << b.UShort14) - 1)) == 0);
                    constexpr.ASSUME((result.UShort15 & ((1 << b.UShort15) - 1)) == 0);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srlv_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_srli_epi16(a, b.UShort0);
                }

                v256 result;

                //if (BurstArchitecture.IsVectorShift16Supported)
                //{
                //    ;
                //}
                //else
                if (SHR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v256 shuffle))
                {
                    result = Avx2.mm256_shuffle_epi8(a, shuffle);
                }
                else if (constexpr.IS_CONST(b))
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance 
                     && b.UShort0  == b.UShort1
                     && b.UShort2  == b.UShort3
                     && b.UShort4  == b.UShort5
                     && b.UShort6  == b.UShort7
                     && b.UShort8  == b.UShort9
                     && b.UShort10 == b.UShort11
                     && b.UShort12 == b.UShort13
                     && b.UShort14 == b.UShort15)
                    {
                        v256 __b = Avx2.mm256_min_epu16(b, mm256_set1_epi16(16));

                        v256 mask = new v256((ushort)((1 << (16 - __b.UShort0))  - 1),
                                             (ushort)((1 << (16 - __b.UShort1))  - 1),
                                             (ushort)((1 << (16 - __b.UShort2))  - 1),
                                             (ushort)((1 << (16 - __b.UShort3))  - 1),
                                             (ushort)((1 << (16 - __b.UShort4))  - 1),
                                             (ushort)((1 << (16 - __b.UShort5))  - 1),
                                             (ushort)((1 << (16 - __b.UShort6))  - 1),
                                             (ushort)((1 << (16 - __b.UShort7))  - 1),
                                             (ushort)((1 << (16 - __b.UShort8))  - 1),
                                             (ushort)((1 << (16 - __b.UShort9))  - 1),
                                             (ushort)((1 << (16 - __b.UShort10)) - 1),
                                             (ushort)((1 << (16 - __b.UShort11)) - 1),
                                             (ushort)((1 << (16 - __b.UShort12)) - 1),
                                             (ushort)((1 << (16 - __b.UShort13)) - 1),
                                             (ushort)((1 << (16 - __b.UShort14)) - 1),
                                             (ushort)((1 << (16 - __b.UShort15)) - 1));
                        
                        __b = Avx2.mm256_and_si256(__b, mm256_set1_epi32(ushort.MaxValue));
                        v256 shift32 = Avx2.mm256_srlv_epi32(a, __b);
                        result = Avx2.mm256_and_si256(mask, shift32);

                        goto RET;
                    }
                    else if (constexpr.ALL_NEQ_EPI16(b, 0))
                    {
                        v256 INV_POW2 = new v256(0, 1 << 15, 1 << 14, 1 << 13, 1 << 12, 1 << 11, 1 << 10, 1 << 9, 1 << 8, 1 << 7, 1 << 6, 1 << 5, 1 << 4, 1 << 3, 1 << 2, 1 << 1);
                        v256 shuf = mm256_permutevar_epi16(INV_POW2, Avx2.mm256_and_si256(b, mm256_set1_epi16(15)));

                        result = Avx2.mm256_mulhi_epu16(a, Avx2.mm256_andnot_si256(mm256_cmpgt_epu16(b, mm256_set1_epi16(15)), shuf));

                        goto RET;
                    }
                }

                v256 aLo = mm256_cvt2x2epu16_epi32(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epu16_epi32(b, out v256 bHi);
                
                aLo = Avx2.mm256_srlv_epi32(aLo, bLo);
                aHi = Avx2.mm256_srlv_epi32(aHi, bHi);
                
                result = Avx2.mm256_packus_epi32(aLo, aHi);
                
            RET:
                constexpr.ASSUME(result.UShort0  == (b.UShort0  > 15 ? 0 : (ushort)(a.UShort0  >> b.UShort0)));
                constexpr.ASSUME(result.UShort1  == (b.UShort1  > 15 ? 0 : (ushort)(a.UShort1  >> b.UShort1)));
                constexpr.ASSUME(result.UShort2  == (b.UShort2  > 15 ? 0 : (ushort)(a.UShort2  >> b.UShort2)));
                constexpr.ASSUME(result.UShort3  == (b.UShort3  > 15 ? 0 : (ushort)(a.UShort3  >> b.UShort3)));
                constexpr.ASSUME(result.UShort4  == (b.UShort4  > 15 ? 0 : (ushort)(a.UShort4  >> b.UShort4)));
                constexpr.ASSUME(result.UShort5  == (b.UShort5  > 15 ? 0 : (ushort)(a.UShort5  >> b.UShort5)));
                constexpr.ASSUME(result.UShort6  == (b.UShort6  > 15 ? 0 : (ushort)(a.UShort6  >> b.UShort6)));
                constexpr.ASSUME(result.UShort7  == (b.UShort7  > 15 ? 0 : (ushort)(a.UShort7  >> b.UShort7)));
                constexpr.ASSUME(result.UShort8  == (b.UShort8  > 15 ? 0 : (ushort)(a.UShort8  >> b.UShort8)));
                constexpr.ASSUME(result.UShort9  == (b.UShort9  > 15 ? 0 : (ushort)(a.UShort9  >> b.UShort9)));
                constexpr.ASSUME(result.UShort10 == (b.UShort10 > 15 ? 0 : (ushort)(a.UShort10 >> b.UShort10)));
                constexpr.ASSUME(result.UShort11 == (b.UShort11 > 15 ? 0 : (ushort)(a.UShort11 >> b.UShort11)));
                constexpr.ASSUME(result.UShort12 == (b.UShort12 > 15 ? 0 : (ushort)(a.UShort12 >> b.UShort12)));
                constexpr.ASSUME(result.UShort13 == (b.UShort13 > 15 ? 0 : (ushort)(a.UShort13 >> b.UShort13)));
                constexpr.ASSUME(result.UShort14 == (b.UShort14 > 15 ? 0 : (ushort)(a.UShort14 >> b.UShort14)));
                constexpr.ASSUME(result.UShort15 == (b.UShort15 > 15 ? 0 : (ushort)(a.UShort15 >> b.UShort15)));

                if (constexpr.ALL_LE_EPU16(b, 15))
                {
                    constexpr.ASSUME(result.UShort0  <= (ushort)(ushort.MaxValue >> b.UShort0));
                    constexpr.ASSUME(result.UShort1  <= (ushort)(ushort.MaxValue >> b.UShort1));
                    constexpr.ASSUME(result.UShort2  <= (ushort)(ushort.MaxValue >> b.UShort2));
                    constexpr.ASSUME(result.UShort3  <= (ushort)(ushort.MaxValue >> b.UShort3));
                    constexpr.ASSUME(result.UShort4  <= (ushort)(ushort.MaxValue >> b.UShort4));
                    constexpr.ASSUME(result.UShort5  <= (ushort)(ushort.MaxValue >> b.UShort5));
                    constexpr.ASSUME(result.UShort6  <= (ushort)(ushort.MaxValue >> b.UShort6));
                    constexpr.ASSUME(result.UShort7  <= (ushort)(ushort.MaxValue >> b.UShort7));
                    constexpr.ASSUME(result.UShort8  <= (ushort)(ushort.MaxValue >> b.UShort8));
                    constexpr.ASSUME(result.UShort9  <= (ushort)(ushort.MaxValue >> b.UShort9));
                    constexpr.ASSUME(result.UShort10 <= (ushort)(ushort.MaxValue >> b.UShort10));
                    constexpr.ASSUME(result.UShort11 <= (ushort)(ushort.MaxValue >> b.UShort11));
                    constexpr.ASSUME(result.UShort12 <= (ushort)(ushort.MaxValue >> b.UShort12));
                    constexpr.ASSUME(result.UShort13 <= (ushort)(ushort.MaxValue >> b.UShort13));
                    constexpr.ASSUME(result.UShort14 <= (ushort)(ushort.MaxValue >> b.UShort14));
                    constexpr.ASSUME(result.UShort15 <= (ushort)(ushort.MaxValue >> b.UShort15));
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srav_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_srai_epi16(a, b.UShort0);
                }

                v256 aLo = mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                aLo = Avx2.mm256_srav_epi32(aLo, bLo);
                aHi = Avx2.mm256_srav_epi32(aHi, bHi);

                v256 result = Avx2.mm256_packs_epi32(aLo, aHi);
                
                constexpr.ASSUME(result.SShort0  == (b.SShort0  < 0 || b.SShort0  > 15 ? 0 : (short)(a.SShort0  >> b.SShort0)));
                constexpr.ASSUME(result.SShort1  == (b.SShort1  < 0 || b.SShort1  > 15 ? 0 : (short)(a.SShort1  >> b.SShort1)));
                constexpr.ASSUME(result.SShort2  == (b.SShort2  < 0 || b.SShort2  > 15 ? 0 : (short)(a.SShort2  >> b.SShort2)));
                constexpr.ASSUME(result.SShort3  == (b.SShort3  < 0 || b.SShort3  > 15 ? 0 : (short)(a.SShort3  >> b.SShort3)));
                constexpr.ASSUME(result.SShort4  == (b.SShort4  < 0 || b.SShort4  > 15 ? 0 : (short)(a.SShort4  >> b.SShort4)));
                constexpr.ASSUME(result.SShort5  == (b.SShort5  < 0 || b.SShort5  > 15 ? 0 : (short)(a.SShort5  >> b.SShort5)));
                constexpr.ASSUME(result.SShort6  == (b.SShort6  < 0 || b.SShort6  > 15 ? 0 : (short)(a.SShort6  >> b.SShort6)));
                constexpr.ASSUME(result.SShort7  == (b.SShort7  < 0 || b.SShort7  > 15 ? 0 : (short)(a.SShort7  >> b.SShort7)));
                constexpr.ASSUME(result.SShort8  == (b.SShort8  < 0 || b.SShort8  > 15 ? 0 : (short)(a.SShort8  >> b.SShort8)));
                constexpr.ASSUME(result.SShort9  == (b.SShort9  < 0 || b.SShort9  > 15 ? 0 : (short)(a.SShort9  >> b.SShort9)));
                constexpr.ASSUME(result.SShort10 == (b.SShort10 < 0 || b.SShort10 > 15 ? 0 : (short)(a.SShort10 >> b.SShort10)));
                constexpr.ASSUME(result.SShort11 == (b.SShort11 < 0 || b.SShort11 > 15 ? 0 : (short)(a.SShort11 >> b.SShort11)));
                constexpr.ASSUME(result.SShort12 == (b.SShort12 < 0 || b.SShort12 > 15 ? 0 : (short)(a.SShort12 >> b.SShort12)));
                constexpr.ASSUME(result.SShort13 == (b.SShort13 < 0 || b.SShort13 > 15 ? 0 : (short)(a.SShort13 >> b.SShort13)));
                constexpr.ASSUME(result.SShort14 == (b.SShort14 < 0 || b.SShort14 > 15 ? 0 : (short)(a.SShort14 >> b.SShort14)));
                constexpr.ASSUME(result.SShort15 == (b.SShort15 < 0 || b.SShort15 > 15 ? 0 : (short)(a.SShort15 >> b.SShort15)));

                return result;
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sll_epi32(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 31ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sll_epi32(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 32);

                if (!inRange && (count.ULong0 & ~31ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vdupq_n_s32(count.SInt0));
                }
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srl_epi32(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 31ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.srl_epi32(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 32);

                if (!inRange && (count.ULong0 & ~31ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u32(a, Arm.Neon.vdupq_n_s32(-count.SInt0));
                }
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sra_epi32(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 31ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sra_epi32(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 32);

                if (!inRange && (count.ULong0 & ~31ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s32(a, 31);
                }
                else
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vdupq_n_s32(-count.SInt0));
                }
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 slli_epi32(v128 a, int imm8, bool inRange = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
                return sll_epi32(a, cvtsi32_si128(imm8), inRange);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srli_epi32(v128 a, int imm8, bool inRange = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
                return srl_epi32(a, cvtsi32_si128(imm8), inRange);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srai_epi32(v128 a, int imm8, bool inRange = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
                return sra_epi32(a, cvtsi32_si128(imm8), inRange);
			}
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi32(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi32(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi32(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi32(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi32(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi32(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi32(v128 a, v128 b, bool inRange = false, byte elements = 4)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<uint4, uint>(b, 0, 31, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU32(b, 32, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return slli_epi32(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.sllv_epi32(a, b);
                }

                v128 result;

                if (Sse4_1.IsSse41Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = mullo_epi32(a, new v128(b.UInt0 > 31 ? 0 : 1 << b.SInt0, 
                                                         b.UInt1 > 31 ? 0 : 1 << b.SInt1, 
                                                         b.UInt2 > 31 ? 0 : 1 << b.SInt2,
                                                         b.UInt3 > 31 ? 0 : 1 << b.SInt3));
                        goto RET;
                    }

                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = sll_epi32(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _y = sll_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_1100);

                    if (elements == 2)
                    {
                        result = _xy;
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _z = sll_epi32(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        result = blend_epi16(_xy, _z, 0b0011_0000);
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    v128 _w = sll_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _zw = blend_epi16(_z, _w, 0b1100_0000);

                    result = blend_epi16(_xy, _zw, 0b1111_0000);
                }
                else
                {
                    if (constexpr.IS_CONST(b) && elements > 3)
                    {
                        result = mullo_epi32(a, new v128(b.UInt0 > 31 ? 0 : 1 << b.SInt0, 
                                                         b.UInt1 > 31 ? 0 : 1 << b.SInt1, 
                                                         b.UInt2 > 31 ? 0 : 1 << b.SInt2,
                                                         b.UInt3 > 31 ? 0 : 1 << b.SInt3));
                        goto RET;
                    }

                    v128 MASK = cvtsi32_si128(-1);

                    v128 _x = sll_epi32(a,                               and_si128(MASK, b));
                    v128 _y = sll_epi32(bsrli_si128(a, 1 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 1 * sizeof(int))));

                    if (elements == 2)
                    {
                        result = unpacklo_epi32(_x, _y);
                        goto RET;
                    }

                    v128 lo = unpacklo_epi32(_x, _y);
                    v128 _z = sll_epi32(bsrli_si128(a, 2 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 2 * sizeof(int))));

                    if (elements == 3)
                    {
                        result = unpacklo_epi64(lo, _z);
                        goto RET;
                    }

                    v128 _w = sll_epi32(bsrli_si128(a, 3 * sizeof(int)), bsrli_si128(b, 3 * sizeof(int)));

                    v128 hi = unpacklo_epi32(_z, _w);

                    result = unpacklo_epi64(lo, hi);
                }

            RET:

                constexpr.ASSUME(result.UInt0 == (inRange ? (a.UInt0 << b.SInt0) : (b.SInt0 < 0 || b.SInt0 > 31 ? 0 : (a.UInt0 << b.SInt0))));
                constexpr.ASSUME(result.UInt1 == (inRange ? (a.UInt1 << b.SInt1) : (b.SInt1 < 0 || b.SInt1 > 31 ? 0 : (a.UInt1 << b.SInt1))));
                if (elements > 2)
                {
                    constexpr.ASSUME(result.UInt2 == (inRange ? (a.UInt2 << b.SInt2) : (b.SInt2 < 0 || b.SInt2 > 31 ? 0 : (a.UInt2 << b.SInt2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.UInt3 == (inRange ? (a.UInt3 << b.SInt3) : (b.SInt3 < 0 || b.SInt3 > 31 ? 0 : (a.UInt3 << b.SInt3))));
                    }
                }

                if (constexpr.ALL_LE_EPU32(b, 31))
                {
                    constexpr.ASSUME((result.UInt0 & ((1 << b.SInt0) - 1)) == 0);
                    constexpr.ASSUME((result.UInt1 & ((1 << b.SInt1) - 1)) == 0);

                    if (elements > 2)
                    {
                        constexpr.ASSUME((result.UInt2 & ((1 << b.SInt2) - 1)) == 0);

                        if (elements > 3)
                        {
                            constexpr.ASSUME((result.UInt3 & ((1 << b.SInt3) - 1)) == 0);
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU32(b, 31, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u32(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u32(Arm.Neon.vshlq_u32(a, b), Arm.Neon.vcltq_u32(b, set1_epi32(32)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi32(v128 a, v128 b, bool inRange = false, byte elements = 4)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<uint4, uint>(b, 0, 31, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU32(b, 32, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return srli_epi32(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srlv_epi32(a, b);
                }
                
                v128 result;
                
                if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = srl_epi32(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _y = srl_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_1100);

                    if (elements == 2)
                    {
                        result = _xy;
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _z = srl_epi32(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        result = blend_epi16(_xy, _z, 0b0011_0000);
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    v128 _w = srl_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _zw = blend_epi16(_z, _w, 0b1100_0000);

                    result = blend_epi16(_xy, _zw, 0b1111_0000);
                }
                else
                {
                    v128 MASK = cvtsi32_si128(-1);

                    v128 _x = srl_epi32(a,                               and_si128(MASK, b));
                    v128 _y = srl_epi32(bsrli_si128(a, 1 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 1 * sizeof(int))));

                    if (elements == 2)
                    {
                        result = unpacklo_epi32(_x, _y);
                        goto RET;
                    }

                    v128 lo = unpacklo_epi32(_x, _y);
                    v128 _z = srl_epi32(bsrli_si128(a, 2 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 2 * sizeof(int))));

                    if (elements == 3)
                    {
                        result = unpacklo_epi64(lo, _z);
                        goto RET;
                    }

                    v128 _w = srl_epi32(bsrli_si128(a, 3 * sizeof(int)), bsrli_si128(b, 3 * sizeof(int)));

                    v128 hi = unpacklo_epi32(_z, _w);

                    result = unpacklo_epi64(lo, hi);
                }

            RET:
                
                constexpr.ASSUME(result.UInt0 == (inRange ? (a.UInt0 >> b.SInt0) : (b.SInt0 < 0 || b.SInt0 > 31 ? 0 : (a.UInt0 >> b.SInt0))));
                constexpr.ASSUME(result.UInt1 == (inRange ? (a.UInt1 >> b.SInt1) : (b.SInt1 < 0 || b.SInt1 > 31 ? 0 : (a.UInt1 >> b.SInt1))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.UInt2 == (inRange ? (a.UInt2 >> b.SInt2) : (b.SInt2 < 0 || b.SInt2 > 31 ? 0 : (a.UInt2 >> b.SInt2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.UInt3 == (inRange ? (a.UInt3 >> b.SInt3) : (b.SInt3 < 0 || b.SInt3 > 31 ? 0 : (a.UInt3 >> b.SInt3))));
                    }
                }

                if (constexpr.ALL_LE_EPU32(b, 31))
                {
                    constexpr.ASSUME(result.UInt0 <= uint.MaxValue >> b.SInt0);
                    constexpr.ASSUME(result.UInt1 <= uint.MaxValue >> b.SInt1);

                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.UInt2 <= uint.MaxValue >> b.SInt2);

                        if (elements > 3)
                        {
                            constexpr.ASSUME(result.UInt3 <= uint.MaxValue >> b.SInt3);
                        }
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU32(b, 31, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u32(a, Arm.Neon.vnegq_s32(b));
                }
                else
                {
                    return Arm.Neon.vshlq_u32(a, Arm.Neon.vnegq_s32(Arm.Neon.vminq_u32(b, Arm.Neon.vdupq_n_u32(31))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi32(v128 a, v128 b, bool inRange = false, byte elements = 4)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<uint4, uint>(b, 0, 31, elements);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU32(b, 32, elements))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return srai_epi32(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srav_epi32(a, b);
                }
                
                v128 result;

                if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = sra_epi32(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _y = sra_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_1100);

                    if (elements == 2)
                    {
                        result = _xy;
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _z = sra_epi32(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        result = blend_epi16(_xy, _z, 0b0011_0000);
                        goto RET;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    v128 _w = sra_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _zw = blend_epi16(_z, _w, 0b1100_0000);

                    return blend_epi16(_xy, _zw, 0b1111_0000);
                }
                else
                {
                    v128 MASK = cvtsi32_si128(-1);

                    v128 _x = sra_epi32(a,                               and_si128(MASK, b));
                    v128 _y = sra_epi32(bsrli_si128(a, 1 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 1 * sizeof(int))));

                    if (elements == 2)
                    {
                        result = unpacklo_epi32(_x, _y);
                        goto RET;
                    }

                    v128 lo = unpacklo_epi32(_x, _y);
                    v128 _z = sra_epi32(bsrli_si128(a, 2 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 2 * sizeof(int))));

                    if (elements == 3)
                    {
                        result = unpacklo_epi64(lo, _z);
                        goto RET;
                    }

                    v128 _w = sra_epi32(bsrli_si128(a, 3 * sizeof(int)), bsrli_si128(b, 3 * sizeof(int)));

                    v128 hi = unpacklo_epi32(_z, _w);

                    result = unpacklo_epi64(lo, hi);
                }

            RET:
                
                constexpr.ASSUME(result.SInt0 == (inRange ? (a.SInt0 >> b.SInt0) : (b.SInt0 < 0 || b.SInt0 > 31 ? 0 : (a.SInt0 >> b.SInt0))));
                constexpr.ASSUME(result.SInt1 == (inRange ? (a.SInt1 >> b.SInt1) : (b.SInt1 < 0 || b.SInt1 > 31 ? 0 : (a.SInt1 >> b.SInt1))));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.SInt2 == (inRange ? (a.SInt2 >> b.SInt2) : (b.SInt2 < 0 || b.SInt2 > 31 ? 0 : (a.SInt2 >> b.SInt2))));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.SInt3 == (inRange ? (a.SInt3 >> b.SInt3) : (b.SInt3 < 0 || b.SInt3 > 31 ? 0 : (a.SInt3 >> b.SInt3))));
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU32(b, 31, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vnegq_s32(b));
                }
                else
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vnegq_s32(Arm.Neon.vminq_u32(b, Arm.Neon.vdupq_n_u32(31))));
                }
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sll_epi64(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 63ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.sll_epi64(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 64);

                if (!inRange && (count.ULong0 & ~63ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s64(a, Arm.Neon.vdupq_n_s64(count.SLong0));
                }
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srl_epi64(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 63ul);
#endif
			if (Sse2.IsSse2Supported)
			{
				return Sse2.srl_epi64(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 64);

                if (!inRange && (count.ULong0 & ~63ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u64(a, Arm.Neon.vdupq_n_s64(-count.SLong0));
                }
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sra_epi64(v128 a, v128 count, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 63ul);
#endif
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(count.ULong0 <= 0 | count.ULong0 >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return srl_epi64(a, count, inRange);
                }

                v128 result;

                v128 sign = shuffle_epi32(srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(count.ULong0))
                {
                    if (count.ULong0 == 63)
                    {
                        result = sign;
                        goto RET;
                    }
                    if (count.ULong0 <= 32)
                    {
                        result = blend_epi16(srl_epi64(a, count), sra_epi32(a, count), 0b1100_1100);
                        goto RET;
                    }
                }

                v128 shiftedSign = sll_epi64(sign, subs_epu16(cvtsi64x_si128(64), count));

                result = or_si128(shiftedSign, srl_epi64(a, count));

            RET:

                constexpr.ASSUME(result.SLong0 == (inRange ? (a.SLong0 >> count.SInt0) : (count.SInt0 < 0 || count.SInt0 > 63 ? 0 : (a.SLong0 >> count.SInt0))));
                constexpr.ASSUME(result.SLong1 == (inRange ? (a.SLong1 >> count.SInt0) : (count.SInt0 < 0 || count.SInt0 > 63 ? 0 : (a.SLong1 >> count.SInt0))));

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 64);

                if (!inRange && (count.ULong0 & ~63ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s64(a, 63);
                }
                else
                {
                    return Arm.Neon.vshlq_s64(a, Arm.Neon.vdupq_n_s64(-count.SLong0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sra_epi64(v256 a, v128 count)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(count.ULong0 <= 0 | count.ULong0 >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return Avx2.mm256_srl_epi64(a, count);
                }

                v256 result;

                v256 sign = Avx2.mm256_shuffle_epi32(Avx2.mm256_srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(count.ULong0))
                {
                    if (count.ULong0 == 63)
                    {
                        result = sign;
                        goto RET;
                    }
                    if (count.ULong0 <= 32)
                    {
                        result = Avx2.mm256_blend_epi16(Avx2.mm256_srl_epi64(a, count), Avx2.mm256_sra_epi32(a, count), 0b1100_1100);
                        goto RET;
                    }
                }

                v256 shiftedSign = Avx2.mm256_sll_epi64(sign, subs_epu16(cvtsi64x_si128(64), count));

                result = Avx2.mm256_or_si256(shiftedSign, Avx2.mm256_srl_epi64(a, count));

            RET:

                constexpr.ASSUME(result.SLong0 == (count.SInt0 < 0 || count.SInt0 > 63 ? 0 : (a.SLong0 >> count.SInt0)));
                constexpr.ASSUME(result.SLong1 == (count.SInt0 < 0 || count.SInt0 > 63 ? 0 : (a.SLong1 >> count.SInt0)));
                constexpr.ASSUME(result.SLong2 == (count.SInt0 < 0 || count.SInt0 > 63 ? 0 : (a.SLong2 >> count.SInt0)));
                constexpr.ASSUME(result.SLong3 == (count.SInt0 < 0 || count.SInt0 > 63 ? 0 : (a.SLong3 >> count.SInt0)));

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi64(v128 a, int n, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return sll_epi64(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi64(v128 a, int n, bool inRange = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return srl_epi64(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi64(v128 a, int n, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 63);
#endif
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n == 63))
                {
                    return cmpgt_epi64(setzero_si128(), a);
                }
            }

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return srli_epi64(a, n);
                }

                v128 result;

                v128 sign = shuffle_epi32(srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(n))
                {
                    if (n == 63)
                    {
                        result = sign;
                        goto RET;
                    }
                    if (n <= 32)
                    {
                        result = blend_epi16(srli_epi64(a, n), srai_epi32(a, n), 0b1100_1100);
                        goto RET;
                    }
                }

                v128 shiftedSign = slli_epi64(sign, 64 - n);

                result = or_si128(shiftedSign, srli_epi64(a, n));

            RET:

                constexpr.ASSUME(result.SLong0 == (inRange ? (a.SLong0 >> n) : (n < 0 || n > 63 ? 0 : (a.SLong0 >> n))));
                constexpr.ASSUME(result.SLong1 == (inRange ? (a.SLong1 >> n) : (n < 0 || n > 63 ? 0 : (a.SLong1 >> n))));

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sra_epi64(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi64(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi64(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi64(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi64(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi64(v256 a, int n, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    return mm256_srli_epi64(a, n);
                }
                
                if (constexpr.IS_TRUE(n == 63))
                {
                    return Avx2.mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), a);
                }

                v256 result;

                if (constexpr.IS_CONST(n))
                {
                    if (n <= 32)
                    {
                        result = Avx2.mm256_blend_epi32(mm256_srli_epi64(a, n), mm256_srai_epi32(a, n), 0b1010_1010);
                        goto RET;
                    }
                }

                v256 sign = Avx2.mm256_shuffle_epi32(Avx2.mm256_srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));
                v256 shiftedSign = mm256_slli_epi64(sign, 64 - n);

                result = Avx2.mm256_or_si256(shiftedSign, mm256_srli_epi64(a, n));

            RET:

                constexpr.ASSUME(result.SLong0 == (n < 0 || n > 63 ? 0 : (a.SLong0 >> n)));
                constexpr.ASSUME(result.SLong1 == (n < 0 || n > 63 ? 0 : (a.SLong1 >> n)));
                constexpr.ASSUME(result.SLong2 == (n < 0 || n > 63 ? 0 : (a.SLong2 >> n)));
                constexpr.ASSUME(result.SLong3 == (n < 0 || n > 63 ? 0 : (a.SLong3 >> n)));

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi64(v128 a, v128 b, bool inRange = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return slli_epi64(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.sllv_epi64(a, b);
                }
                else
                {
                    v128 MASK = cvtsi64x_si128(-1);

                    v128 _x = sll_epi64(a,                                 and_si128(MASK, b));
                    v128 _y = sll_epi64(bsrli_si128(a, 1 * sizeof(ulong)), bsrli_si128(b, 1 * sizeof(ulong)));

                    v128 result = unpacklo_epi64(_x, _y);

                    constexpr.ASSUME(result.ULong0 == (inRange ? (a.ULong0 << (int)b.ULong0) : ((int)b.ULong0 < 0 || (int)b.ULong0 > 63 ? 0 : (a.ULong0 << (int)b.ULong0))));
                    constexpr.ASSUME(result.ULong1 == (inRange ? (a.ULong1 << (int)b.ULong1) : ((int)b.ULong1 < 0 || (int)b.ULong1 > 63 ? 0 : (a.ULong1 << (int)b.ULong1))));

                    if (inRange)
                    {
                        constexpr.ASSUME((result.ULong0 & ((1ul << (int)b.ULong0) - 1)) == 0);
                        constexpr.ASSUME((result.ULong1 & ((1ul << (int)b.ULong1) - 1)) == 0);
                    }

                    return result;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU64(b, 63);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u64(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u64(Arm.Neon.vshlq_u64(a, b), Arm.Neon.vcltq_u64(b, set1_epi64x(64)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi64(v128 a, v128 b, bool inRange = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return srli_epi64(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srlv_epi64(a, b);
                }
                else
                {
                    v128 MASK = cvtsi64x_si128(-1);

                    v128 _x = srl_epi64(a,                                 and_si128(MASK, b));
                    v128 _y = srl_epi64(bsrli_si128(a, 1 * sizeof(ulong)), bsrli_si128(b, 1 * sizeof(ulong)));

                    v128 result = unpacklo_epi64(_x, _y);
                    
                    constexpr.ASSUME(result.ULong0 == (inRange ? (a.ULong0 >> (int)b.ULong0) : ((int)b.ULong0 < 0 || (int)b.ULong0 > 63 ? 0 : (a.ULong0 >> (int)b.ULong0))));
                    constexpr.ASSUME(result.ULong1 == (inRange ? (a.ULong1 >> (int)b.ULong1) : ((int)b.ULong1 < 0 || (int)b.ULong1 > 63 ? 0 : (a.ULong1 >> (int)b.ULong1))));

                    if (inRange)
                    {
                        constexpr.ASSUME(result.ULong0 <= ulong.MaxValue >> (int)b.ULong0);
                        constexpr.ASSUME(result.ULong1 <= ulong.MaxValue >> (int)b.ULong1);
                    }

                    return result;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU64(b, 63);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u64(a, Arm.Neon.vnegq_s64(b));
                }
                else
                {
                    return Arm.Neon.vandq_u64(Arm.Neon.vshlq_u64(a, Arm.Neon.vnegq_s64(b)), Arm.Neon.vcltq_u64(b, set1_epi64x(64)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi64(v128 a, v128 b, bool inRange = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return srai_epi64(a, b.SInt0, inRange);
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return srlv_epi64(a, b);
                }
                    
                v128 result;

                if (Avx2.IsAvx2Supported)
                {
                    if (SHRA_SIGN_BYTE_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(b, out v128 shuffleSignByte))
                    {
                        v128 shrl = srlv_epi64(a, b, inRange);
                        v128 placedSignBytes = shuffle_epi8(a, shuffleSignByte);

                        result = blendv_epi8(shrl, setall_si128(), placedSignBytes);
                    }
                    else if (constexpr.ALL_LT_EPI64(b, 32))
                    {
                        v128 shiftLo = srlv_epi64(a, b);
                        v128 shiftHi = srav_epi32(a, shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0)));

                        result = Avx2.blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                    }
                    else
                    {
                        v128 sign = srai_epi64(a, 63);
                        v128 shiftedSign = sllv_epi64(sign, sub_epi64(set1_epi64x(64), b));

                        result = or_si128(shiftedSign, srlv_epi64(a, b));
                    }

                    constexpr.ASSUME(result.SLong0 == (inRange ? (a.SLong0 >> (int)b.SLong0) : (b.SLong0 < 0 || b.SLong0 > 63 ? 0 : (a.SLong0 >> (int)b.SLong0))));
                    constexpr.ASSUME(result.SLong1 == (inRange ? (a.SLong1 >> (int)b.SLong1) : (b.SLong1 < 0 || b.SLong1 > 63 ? 0 : (a.SLong1 >> (int)b.SLong1))));

                    return result;
                }
                else
                {
                    return new v128(a.SLong0 >> b.SInt0, a.SLong1 >> b.SInt2);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU64(b, 63);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s64(a, Arm.Neon.vnegq_s64(b));
                }
                else
                {
                    return Arm.Neon.vbslq_u64(Arm.Neon.vcltq_u64(b, set1_epi64x(64)), Arm.Neon.vshlq_s64(a, Arm.Neon.vnegq_s64(b)), Arm.Neon.vshrq_n_s64(a, 63));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srav_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64, elements))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return mm256_srai_epi64(a, b.SInt0, elements);
                }

                v256 result;

                if (constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    result = Avx2.mm256_srlv_epi64(a, b);
                }
                else if (SHRA_SIGN_BYTE_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(b, out v256 shuffleSignByte))
                {
                    v256 shrl = Avx2.mm256_srlv_epi64(a, b);
                    v256 placedSignBytes = Avx2.mm256_shuffle_epi8(a, shuffleSignByte);

                    result = Avx2.mm256_blendv_epi8(shrl, mm256_setall_si256(), placedSignBytes);
                }
                else if (constexpr.ALL_LT_EPI64(b, 32, elements))
                {
                    v256 shiftLo = Avx2.mm256_srlv_epi64(a, b);
                    v256 shiftHi = Avx2.mm256_srav_epi32(a, Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0)));

                    result = Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                }
                else
                {
                    v256 sign = mm256_srai_epi64(a, 63, elements);
                    v256 shiftedSign = Avx2.mm256_sllv_epi64(sign, Avx2.mm256_sub_epi64(new v256(64L), b));

                    result = Avx2.mm256_or_si256(shiftedSign, Avx2.mm256_srlv_epi64(a, b));
                }

                constexpr.ASSUME(result.SLong0 == (b.SLong0 < 0 || b.SLong0 > 63 ? 0 : (a.SLong0 >> (int)b.SLong0)));
                constexpr.ASSUME(result.SLong1 == (b.SLong1 < 0 || b.SLong1 > 63 ? 0 : (a.SLong1 >> (int)b.SLong1)));
                constexpr.ASSUME(result.SLong2 == (b.SLong2 < 0 || b.SLong2 > 63 ? 0 : (a.SLong2 >> (int)b.SLong2)));
                constexpr.ASSUME(result.SLong3 == (b.SLong3 < 0 || b.SLong3 > 63 ? 0 : (a.SLong3 >> (int)b.SLong3)));
                
                return result;
            }
            else throw new IllegalInstructionException();
        }
    }
}