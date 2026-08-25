using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;


namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(v128 i, out v128 s, byte elements = 8)
            {
                static void GetIndices(ushort value, int shortIdx, out byte lo, out byte hi)
                {
                    lo = (byte)(value == 8 ? shortIdx * 2 + 1 : shortIdx * 2);
                    hi = (byte)(value == 8 ? shortIdx * 2 : shortIdx * 2 + 1);
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
            internal static bool ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(v256 i, out v256 s)
            {
                s = default;

                if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(i.Lo128, out v128 lo)
                 && ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(i.Hi128, out v128 hi))
                {
                    s.Lo128 = lo;
                    s.Hi128 = hi;

                    return true;
                }

                return false;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(v128 i, out v128 s, byte elements = 4)
            {
                static void GetIndices(uint value, int intIdx, out byte i0, out byte i1, out byte i2, out byte i3)
                {
                    i0 = (byte)(4 * intIdx);
                    i1 = (byte)(4 * intIdx);
                    i2 = (byte)(4 * intIdx);
                    i3 = (byte)(4 * intIdx);

                    uint rot = (value >> 3) & 3;
                    i0 += (byte)rot;
                    i1 += (byte)((rot + 1) & 3);
                    i2 += (byte)((rot + 2) & 3);
                    i3 += (byte)((rot + 3) & 3);
                }

                s = default;

                bool test0 = ((i.UInt0) & 7) == 0;
                bool test1 = ((i.UInt1) & 7) == 0;
                bool test2 = ((i.UInt2) & 7) == 0;
                bool test3 = ((i.UInt3) & 7) == 0;

                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(test0)
                          & constexpr.IS_TRUE(test1))
                        {
                            GetIndices(i.UInt0, 0, out byte Byte0, out byte Byte1, out byte Byte2, out byte Byte3);
                            GetIndices(i.UInt1, 1, out byte Byte4, out byte Byte5, out byte Byte6, out byte Byte7);

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
                    case 3:
                    {
                        if (constexpr.IS_TRUE(test0)
                          & constexpr.IS_TRUE(test1)
                          & constexpr.IS_TRUE(test2))
                        {
                            GetIndices(i.UInt0, 0, out byte Byte0, out byte Byte1, out byte Byte2,  out byte Byte3);
                            GetIndices(i.UInt1, 1, out byte Byte4, out byte Byte5, out byte Byte6,  out byte Byte7);
                            GetIndices(i.UInt2, 2, out byte Byte8, out byte Byte9, out byte Byte10, out byte Byte11);

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
                          & constexpr.IS_TRUE(test3))
                        {
                            GetIndices(i.UInt0, 0, out byte Byte0,  out byte Byte1,  out byte Byte2,  out byte Byte3);
                            GetIndices(i.UInt1, 1, out byte Byte4,  out byte Byte5,  out byte Byte6,  out byte Byte7);
                            GetIndices(i.UInt2, 2, out byte Byte8,  out byte Byte9,  out byte Byte10, out byte Byte11);
                            GetIndices(i.UInt3, 3, out byte Byte12, out byte Byte13, out byte Byte14, out byte Byte15);

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
            internal static bool ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(v256 i, out v256 s)
            {
                s = default;

                if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(i.Lo128, out v128 lo)
                 && ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(i.Hi128, out v128 hi))
                {
                    s.Lo128 = lo;
                    s.Hi128 = hi;

                    return true;
                }

                return false;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(v128 i, out v128 s, byte elements = 4)
            {
                static void GetIndices(uint value, int intIdx, out byte i0, out byte i1, out byte i2, out byte i3)
                {
                    i0 = (byte)(4 * intIdx);
                    i1 = (byte)(4 * intIdx);
                    i2 = (byte)(4 * intIdx);
                    i3 = (byte)(4 * intIdx);

                    uint rot = ((uint)-(int)value >> 3) & 3;
                    i0 += (byte)rot;
                    i1 += (byte)((rot + 1) & 3);
                    i2 += (byte)((rot + 2) & 3);
                    i3 += (byte)((rot + 3) & 3);
                }

                s = default;

                bool test0 = ((i.UInt0) & 7) == 0;
                bool test1 = ((i.UInt1) & 7) == 0;
                bool test2 = ((i.UInt2) & 7) == 0;
                bool test3 = ((i.UInt3) & 7) == 0;

                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(test0)
                          & constexpr.IS_TRUE(test1))
                        {
                            GetIndices(i.UInt0, 0, out byte Byte0, out byte Byte1, out byte Byte2, out byte Byte3);
                            GetIndices(i.UInt1, 1, out byte Byte4, out byte Byte5, out byte Byte6, out byte Byte7);

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
                    case 3:
                    {
                        if (constexpr.IS_TRUE(test0)
                          & constexpr.IS_TRUE(test1)
                          & constexpr.IS_TRUE(test2))
                        {
                            GetIndices(i.UInt0, 0, out byte Byte0, out byte Byte1, out byte Byte2,  out byte Byte3);
                            GetIndices(i.UInt1, 1, out byte Byte4, out byte Byte5, out byte Byte6,  out byte Byte7);
                            GetIndices(i.UInt2, 2, out byte Byte8, out byte Byte9, out byte Byte10, out byte Byte11);

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
                          & constexpr.IS_TRUE(test3))
                        {
                            GetIndices(i.UInt0, 0, out byte Byte0,  out byte Byte1,  out byte Byte2,  out byte Byte3);
                            GetIndices(i.UInt1, 1, out byte Byte4,  out byte Byte5,  out byte Byte6,  out byte Byte7);
                            GetIndices(i.UInt2, 2, out byte Byte8,  out byte Byte9,  out byte Byte10, out byte Byte11);
                            GetIndices(i.UInt3, 3, out byte Byte12, out byte Byte13, out byte Byte14, out byte Byte15);

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
            internal static bool ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(v256 i, out v256 s)
            {
                s = default;

                if (ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(i.Lo128, out v128 lo)
                 && ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(i.Hi128, out v128 hi))
                {
                    s.Lo128 = lo;
                    s.Hi128 = hi;

                    return true;
                }

                return false;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(v128 i, out v128 s)
            {
                static void GetIndices(ulong value, int longiDX, out byte i0, out byte i1, out byte i2, out byte i3, out byte i4, out byte i5, out byte i6, out byte i7)
                {
                    i0 = (byte)(8 * longiDX);
                    i1 = (byte)(8 * longiDX);
                    i2 = (byte)(8 * longiDX);
                    i3 = (byte)(8 * longiDX);
                    i4 = (byte)(8 * longiDX);
                    i5 = (byte)(8 * longiDX);
                    i6 = (byte)(8 * longiDX);
                    i7 = (byte)(8 * longiDX);

                    ulong rot = (value >> 3) & 7;
                    i0 += (byte)rot;
                    i1 += (byte)((rot + 1) & 7);
                    i2 += (byte)((rot + 2) & 7);
                    i3 += (byte)((rot + 3) & 7);
                    i4 += (byte)((rot + 4) & 7);
                    i5 += (byte)((rot + 5) & 7);
                    i6 += (byte)((rot + 6) & 7);
                    i7 += (byte)((rot + 7) & 7);
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
            internal static bool ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(v256 i, out v256 s)
            {
                s = default;

                if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(i.Lo128, out v128 lo)
                 && ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(i.Hi128, out v128 hi))
                {
                    s.Lo128 = lo;
                    s.Hi128 = hi;

                    return true;
                }

                return false;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(v128 i, out v128 s, byte elements = 8)
            {
                static void GetIndices(ulong value, int longiDX, out byte i0, out byte i1, out byte i2, out byte i3, out byte i4, out byte i5, out byte i6, out byte i7)
                {
                    i0 = (byte)(8 * longiDX);
                    i1 = (byte)(8 * longiDX);
                    i2 = (byte)(8 * longiDX);
                    i3 = (byte)(8 * longiDX);
                    i4 = (byte)(8 * longiDX);
                    i5 = (byte)(8 * longiDX);
                    i6 = (byte)(8 * longiDX);
                    i7 = (byte)(8 * longiDX);

                    ulong rot = ((ulong)-(long)value >> 3) & 7;
                    i0 += (byte)rot;
                    i1 += (byte)((rot + 1) & 7);
                    i2 += (byte)((rot + 2) & 7);
                    i3 += (byte)((rot + 3) & 7);
                    i4 += (byte)((rot + 4) & 7);
                    i5 += (byte)((rot + 5) & 7);
                    i6 += (byte)((rot + 6) & 7);
                    i7 += (byte)((rot + 7) & 7);
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
            internal static bool ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(v256 i, out v256 s)
            {
                s = default;

                if (ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(i.Lo128, out v128 lo)
                 && ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(i.Hi128, out v128 hi))
                {
                    s.Lo128 = lo;
                    s.Hi128 = hi;

                    return true;
                }

                return false;
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi8(v128 a, v128 b, bool promise = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI8(b))
                    {
                        return ror_epi8(a, b.Byte0);
                    }
                }

                if (BurstArchitecture.IsVectorShiftSupported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = cvtepu8_epi32(a);
                        v128 b32 = cvtepu8_epi32(b);

                        if (!promise)
                        {
                            b32 = and_si128(b32, set1_epi32(7));
                        }

                        v128 inv = and_si128(neg_epi32(b32), set1_epi32(7));

                        return cvtepi32_epi8(or_si128(srlv_epi32(a32, b32), sllv_epi32(a32, inv)));
                    }
                    else if (elements <= 8)
                    {
                        if (BurstArchitecture.IsVectorShift16Supported)
                        {
                            v128 a16 = cvtepu8_epi16(a);
                            v128 b16 = cvtepu8_epi16(b);

                            if (!promise)
                            {
                                b16 = and_si128(b16, set1_epi16(7));
                            }

                            v128 inv = and_si128(neg_epi16(b16), set1_epi16(7));

                            return cvtepi16_epi8(or_si128(srlv_epi16(a16, b16), sllv_epi16(a16, inv)));
                        }
                        else
                        {
                            if (!promise)
                            {
                                b = and_si128(b, set1_epi8(7));
                            }

                            v128 a32Lo = cvt2x2epu8_epi32(a, out v128 a32Hi);
                            v128 b32Lo = cvt2x2epu8_epi32(b, out v128 b32Hi);
                            
                            v128 invLo = and_si128(neg_epi32(b32Lo), set1_epi32(7));
                            v128 invHi = and_si128(neg_epi32(b32Hi), set1_epi32(7));

                            v128 rLo = or_si128(srlv_epi32(a32Lo, b32Lo), sllv_epi32(a32Lo, invLo));
                            v128 rHi = or_si128(srlv_epi32(a32Hi, b32Hi), sllv_epi32(a32Hi, invHi));

                            return cvt2x2epi32_epi8(rLo, rHi);
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsVectorShift16Supported)
                        {
                            if (!promise)
                            {
                                b = and_si128(b, set1_epi8(7));
                            }

                            v128 a16Lo = cvt2x2epu8_epi16(a, out v128 a16Hi);
                            v128 b16Lo = cvt2x2epu8_epi16(b, out v128 b16Hi);

                            v128 invLo = and_si128(neg_epi16(b16Lo), set1_epi16(7));
                            v128 invHi = and_si128(neg_epi16(b16Hi), set1_epi16(7));

                            v128 rLo = or_si128(srlv_epi16(a16Lo, b16Lo), sllv_epi16(a16Lo, invLo));
                            v128 rHi = or_si128(srlv_epi16(a16Hi, b16Hi), sllv_epi16(a16Hi, invHi));

                            return cvt2x2epi16_epi8(rLo, rHi);
                        }
                        else
                        {
                            if (!promise)
                            {
                                b = and_si128(b, set1_epi8(7));
                            }
                            
                            cvt4x4epu8_epi32(a, out v128 a32_0, out v128 a32_1, out v128 a32_2, out v128 a32_3);
                            cvt4x4epu8_epi32(b, out v128 b32_0, out v128 b32_1, out v128 b32_2, out v128 b32_3);
                            
                            v128 inv_0;
                            v128 inv_1;
                            v128 inv_2;
                            v128 inv_3;
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                v128 inv = and_si128(neg_epi8(b), set1_epi8(7));
                            
                                cvt4x4epu8_epi32(inv, out inv_0, out inv_1, out inv_2, out inv_3);
                            }
                            else
                            {
                                inv_0 = and_si128(neg_epi32(b32_0), set1_epi32(7));
                                inv_1 = and_si128(neg_epi32(b32_1), set1_epi32(7));
                                inv_2 = and_si128(neg_epi32(b32_2), set1_epi32(7));
                                inv_3 = and_si128(neg_epi32(b32_3), set1_epi32(7));
                            }

                            v128 r_0 = or_si128(srlv_epi32(a32_0, b32_0), sllv_epi32(a32_0, inv_0));
                            v128 r_1 = or_si128(srlv_epi32(a32_1, b32_1), sllv_epi32(a32_1, inv_1));
                            v128 r_2 = or_si128(srlv_epi32(a32_2, b32_2), sllv_epi32(a32_2, inv_2));
                            v128 r_3 = or_si128(srlv_epi32(a32_3, b32_3), sllv_epi32(a32_3, inv_3));

                            return cvt4x4epi32_epi8(r_0, r_1, r_2, r_3, signed: false, noOverflowU16: true);
                        }
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    if (!promise)
                    {
                        b = and_si128(b, set1_epi8(7));
                    }

                    v128 inv = and_si128(neg_epi8(b), set1_epi8(7));

                    return or_si128(srlv_epi8(a, b, inRange: true, elements: elements), sllv_epi8(a, inv, inRange: true, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi8(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI8(b))
                    {
                        return mm256_ror_epi8(a, b.Byte0);
                    }
                    
                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi8(7));
                        }
                    
                        v256 a16Lo = mm256_cvt2x2epu8_epi16(a, out v256 a16Hi);
                        v256 b16Lo = mm256_cvt2x2epu8_epi16(b, out v256 b16Hi);
                    
                        v256 invLo = Avx2.mm256_and_si256(mm256_neg_epi16(b16Lo), mm256_set1_epi16(7));
                        v256 invHi = Avx2.mm256_and_si256(mm256_neg_epi16(b16Hi), mm256_set1_epi16(7));
                    
                        v256 rLo = Avx2.mm256_or_si256(mm256_srlv_epi16(a16Lo, b16Lo), mm256_sllv_epi16(a16Lo, invLo));
                        v256 rHi = Avx2.mm256_or_si256(mm256_srlv_epi16(a16Hi, b16Hi), mm256_sllv_epi16(a16Hi, invHi));
                    
                        return mm256_cvt2x2epi16_epi8(rLo, rHi);
                    }
                    else
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi8(7));
                        }
                        
                        mm256_cvt4x4epu8_epi32(a, out v256 a32_0, out v256 a32_1, out v256 a32_2, out v256 a32_3);
                        mm256_cvt4x4epu8_epi32(b, out v256 b32_0, out v256 b32_1, out v256 b32_2, out v256 b32_3);
                        
                        v256 inv_0;
                        v256 inv_1;
                        v256 inv_2;
                        v256 inv_3;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v256 inv = Avx2.mm256_and_si256(mm256_neg_epi8(b), mm256_set1_epi8(7));
                        
                            mm256_cvt4x4epu8_epi32(inv, out inv_0, out inv_1, out inv_2, out inv_3);
                        }
                        else
                        {
                            inv_0 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_0), mm256_set1_epi32(7));
                            inv_1 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_1), mm256_set1_epi32(7));
                            inv_2 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_2), mm256_set1_epi32(7));
                            inv_3 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_3), mm256_set1_epi32(7));
                        }
                    
                        v256 r_0 = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32_0, b32_0), Avx2.mm256_sllv_epi32(a32_0, inv_0));
                        v256 r_1 = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32_1, b32_1), Avx2.mm256_sllv_epi32(a32_1, inv_1));
                        v256 r_2 = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32_2, b32_2), Avx2.mm256_sllv_epi32(a32_2, inv_2));
                        v256 r_3 = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32_3, b32_3), Avx2.mm256_sllv_epi32(a32_3, inv_3));
                    
                        return mm256_cvt4x4epi32_epi8(r_0, r_1, r_2, r_3, signed: false, noOverflowU16: true);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi16(v128 a, v128 b, bool promise = false, byte elements = 8)
            {
                static v128 naive(v128 a, v128 b, bool promise = false, byte elements = 8)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (!promise)
                        {
                            b = and_si128(b, set1_epi16(15));
                        }

                        v128 inv = and_si128(neg_epi16(b), set1_epi16(15));

                        return or_si128(srlv_epi16(a, b, inRange: true, elements: elements), sllv_epi16(a, inv, inRange: true, elements: elements));
                    }
                    else throw new IllegalInstructionException();
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI16(b))
                    {
                        return ror_epi16(a, b.UShort0);
                    }
                }

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v128 shuffle, elements))
                    {
                        return shuffle_epi8(a, shuffle, elements);
                    }
                }

                if (BurstArchitecture.IsVectorShift16Supported)
                {
                    return naive(a, b, promise, elements);
                }
                else if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = cvtepu16_epi32(a);
                        v128 b32 = cvtepu16_epi32(b);

                        if (!promise)
                        {
                            b32 = and_si128(b32, set1_epi32(15));
                        }

                        v128 inv = and_si128(neg_epi32(b32), set1_epi32(15));

                        return cvtepi32_epi16(or_si128(srlv_epi32(a32, b32), sllv_epi32(a32, inv)), elements);
                    }
                    else
                    {
                        v128 a32Lo = cvt2x2epu16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epu16_epi32(b, out v128 b32Hi);

                        if (!promise)
                        {
                            b32Lo = and_si128(b32Lo, set1_epi32(15));
                            b32Hi = and_si128(b32Hi, set1_epi32(15));
                        }

                        v128 invLo = and_si128(neg_epi32(b32Lo), set1_epi32(15));
                        v128 invHi = and_si128(neg_epi32(b32Hi), set1_epi32(15));

                        v128 r32Lo = or_si128(srlv_epi32(a32Lo, b32Lo), sllv_epi32(a32Lo, invLo));
                        v128 r32Hi = or_si128(srlv_epi32(a32Hi, b32Hi), sllv_epi32(a32Hi, invHi));

                        return cvt2x2epi32_epi16(r32Lo, r32Hi);
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return naive(a, b, promise, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi16(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI16(b))
                    {
                        return mm256_ror_epi16(a, b.UShort0);
                    }
                    
                    if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v256 shuffle))
                    {
                        return Avx2.mm256_shuffle_epi8(a, shuffle);
                    }

                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi16(15));
                        }

                        v256 inv = Avx2.mm256_and_si256(mm256_neg_epi16(b), mm256_set1_epi16(15));

                        return Avx2.mm256_or_si256(mm256_srlv_epi16(a, b), mm256_sllv_epi16(a, inv));
                    }
                    else
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi8(15));
                        }
                    
                        v256 a32Lo = mm256_cvt2x2epu16_epi32(a, out v256 a32Hi);
                        v256 b32Lo = mm256_cvt2x2epu16_epi32(b, out v256 b32Hi);
                    
                        v256 invLo = Avx2.mm256_and_si256(mm256_neg_epi32(b32Lo), mm256_set1_epi32(15));
                        v256 invHi = Avx2.mm256_and_si256(mm256_neg_epi32(b32Hi), mm256_set1_epi32(15));
                    
                        v256 rLo = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32Lo, b32Lo), Avx2.mm256_sllv_epi32(a32Lo, invLo));
                        v256 rHi = Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32Hi, b32Hi), Avx2.mm256_sllv_epi32(a32Hi, invHi));
                    
                        return mm256_cvt2x2epi32_epi16(rLo, rHi);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi32(v128 a, v128 b, bool promise = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI32(b))
                    {
                        return ror_epi32(a, b.SInt0);
                    }

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(b, out v128 shuffle, elements))
                        {
                            return shuffle_epi8(a, shuffle, elements);
                        }
                    }

                    if (!promise)
                    {
                        b = and_si128(b, set1_epi32(31));
                    }

                    v128 inv = and_si128(neg_epi32(b), set1_epi32(31));

                    return or_si128(srlv_epi32(a, b, inRange: true, elements: elements), sllv_epi32(a, inv, inRange: true, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi32(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI32(b))
                    {
                        return mm256_ror_epi32(a, b.SInt0);
                    }
                    
                    if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(b, out v256 shuffle))
                    {
                        return Avx2.mm256_shuffle_epi8(a, shuffle);
                    }

                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, mm256_set1_epi32(31));
                    }

                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b), mm256_set1_epi32(31));

                    return Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a, b), Avx2.mm256_sllv_epi32(a, inv));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi64(v128 a, v128 b, bool promise = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI64(b))
                    {
                        return ror_epi64(a, b.SInt0);
                    }

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(b, out v128 shuffle))
                        {
                            return shuffle_epi8(a, shuffle);
                        }
                    }

                    if (!promise)
                    {
                        b = and_si128(b, set1_epi64x(63));
                    }

                    v128 inv = and_si128(neg_epi64(b), set1_epi64x(63));

                    return or_si128(srlv_epi64(a, b, inRange: true), sllv_epi64(a, inv, inRange: true));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi64(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI64(b))
                    {
                        return mm256_ror_epi64(a, b.SInt0);
                    }

                    if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(b, out v256 shuffle))
                    {
                        return Avx2.mm256_shuffle_epi8(a, shuffle);
                    }

                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, mm256_set1_epi64x(63));
                    }

                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi64(b), mm256_set1_epi64x(63));

                    return Avx2.mm256_or_si256(Avx2.mm256_srlv_epi64(a, b), Avx2.mm256_sllv_epi64(a, inv));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi8(v128 a, v128 b, bool promise = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI8(b))
                    {
                        return rol_epi8(a, b.Byte0);
                    }
                }

                if (BurstArchitecture.IsVectorShiftSupported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = cvtepu8_epi32(a);
                        v128 b32 = cvtepu8_epi32(b);

                        if (!promise)
                        {
                            b32 = and_si128(b32, set1_epi32(7));
                        }

                        v128 inv = and_si128(neg_epi32(b32), set1_epi32(7));

                        return cvtepi32_epi8(or_si128(sllv_epi32(a32, b32), srlv_epi32(a32, inv)));
                    }
                    else if (elements <= 8)
                    {
                        if (BurstArchitecture.IsVectorShift16Supported)
                        {
                            v128 a16 = cvtepu8_epi16(a);
                            v128 b16 = cvtepu8_epi16(b);

                            if (!promise)
                            {
                                b16 = and_si128(b16, set1_epi16(7));
                            }

                            v128 inv = and_si128(neg_epi16(b16), set1_epi16(7));

                            return cvtepi16_epi8(or_si128(sllv_epi16(a16, b16), srlv_epi16(a16, inv)));
                        }
                        else
                        {
                            if (!promise)
                            {
                                b = and_si128(b, set1_epi8(7));
                            }

                            v128 a32Lo = cvt2x2epu8_epi32(a, out v128 a32Hi);
                            v128 b32Lo = cvt2x2epu8_epi32(b, out v128 b32Hi);
                            
                            v128 invLo = and_si128(neg_epi32(b32Lo), set1_epi32(7));
                            v128 invHi = and_si128(neg_epi32(b32Hi), set1_epi32(7));

                            v128 rLo = or_si128(sllv_epi32(a32Lo, b32Lo), srlv_epi32(a32Lo, invLo));
                            v128 rHi = or_si128(sllv_epi32(a32Hi, b32Hi), srlv_epi32(a32Hi, invHi));

                            return cvt2x2epi32_epi8(rLo, rHi);
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsVectorShift16Supported)
                        {
                            if (!promise)
                            {
                                b = and_si128(b, set1_epi8(7));
                            }

                            v128 a16Lo = cvt2x2epu8_epi16(a, out v128 a16Hi);
                            v128 b16Lo = cvt2x2epu8_epi16(b, out v128 b16Hi);

                            v128 invLo = and_si128(neg_epi16(b16Lo), set1_epi16(7));
                            v128 invHi = and_si128(neg_epi16(b16Hi), set1_epi16(7));

                            v128 rLo = or_si128(sllv_epi16(a16Lo, b16Lo), srlv_epi16(a16Lo, invLo));
                            v128 rHi = or_si128(sllv_epi16(a16Hi, b16Hi), srlv_epi16(a16Hi, invHi));

                            return cvt2x2epi16_epi8(rLo, rHi);
                        }
                        else
                        {
                            if (!promise)
                            {
                                b = and_si128(b, set1_epi8(7));
                            }
                            
                            cvt4x4epu8_epi32(a, out v128 a32_0, out v128 a32_1, out v128 a32_2, out v128 a32_3);
                            cvt4x4epu8_epi32(b, out v128 b32_0, out v128 b32_1, out v128 b32_2, out v128 b32_3);
                            
                            v128 inv_0;
                            v128 inv_1;
                            v128 inv_2;
                            v128 inv_3;
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                v128 inv = and_si128(neg_epi8(b), set1_epi8(7));
                            
                                cvt4x4epu8_epi32(inv, out inv_0, out inv_1, out inv_2, out inv_3);
                            }
                            else
                            {
                                inv_0 = and_si128(neg_epi32(b32_0), set1_epi32(7));
                                inv_1 = and_si128(neg_epi32(b32_1), set1_epi32(7));
                                inv_2 = and_si128(neg_epi32(b32_2), set1_epi32(7));
                                inv_3 = and_si128(neg_epi32(b32_3), set1_epi32(7));
                            }

                            v128 r_0 = or_si128(sllv_epi32(a32_0, b32_0), srlv_epi32(a32_0, inv_0));
                            v128 r_1 = or_si128(sllv_epi32(a32_1, b32_1), srlv_epi32(a32_1, inv_1));
                            v128 r_2 = or_si128(sllv_epi32(a32_2, b32_2), srlv_epi32(a32_2, inv_2));
                            v128 r_3 = or_si128(sllv_epi32(a32_3, b32_3), srlv_epi32(a32_3, inv_3));

                            return cvt4x4epi32_epi8(r_0, r_1, r_2, r_3, signed: false, noOverflowU16: true);
                        }
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    if (!promise)
                    {
                        b = and_si128(b, set1_epi8(7));
                    }

                    v128 inv = and_si128(neg_epi8(b), set1_epi8(7));

                    return or_si128(sllv_epi8(a, b, inRange: true, elements: elements), srlv_epi8(a, inv, inRange: true, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi8(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI8(b))
                    {
                        return mm256_rol_epi8(a, b.Byte0);
                    }
                    
                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi8(7));
                        }
                    
                        v256 a16Lo = mm256_cvt2x2epu8_epi16(a, out v256 a16Hi);
                        v256 b16Lo = mm256_cvt2x2epu8_epi16(b, out v256 b16Hi);
                    
                        v256 invLo = Avx2.mm256_and_si256(mm256_neg_epi16(b16Lo), mm256_set1_epi16(7));
                        v256 invHi = Avx2.mm256_and_si256(mm256_neg_epi16(b16Hi), mm256_set1_epi16(7));
                    
                        v256 rLo = Avx2.mm256_or_si256(mm256_sllv_epi16(a16Lo, b16Lo), mm256_srlv_epi16(a16Lo, invLo));
                        v256 rHi = Avx2.mm256_or_si256(mm256_sllv_epi16(a16Hi, b16Hi), mm256_srlv_epi16(a16Hi, invHi));
                    
                        return mm256_cvt2x2epi16_epi8(rLo, rHi);
                    }
                    else
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi8(7));
                        }
                        
                        mm256_cvt4x4epu8_epi32(a, out v256 a32_0, out v256 a32_1, out v256 a32_2, out v256 a32_3);
                        mm256_cvt4x4epu8_epi32(b, out v256 b32_0, out v256 b32_1, out v256 b32_2, out v256 b32_3);
                        
                        v256 inv_0;
                        v256 inv_1;
                        v256 inv_2;
                        v256 inv_3;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v256 inv = Avx2.mm256_and_si256(mm256_neg_epi8(b), mm256_set1_epi8(7));
                        
                            mm256_cvt4x4epu8_epi32(inv, out inv_0, out inv_1, out inv_2, out inv_3);
                        }
                        else
                        {
                            inv_0 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_0), mm256_set1_epi32(7));
                            inv_1 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_1), mm256_set1_epi32(7));
                            inv_2 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_2), mm256_set1_epi32(7));
                            inv_3 = Avx2.mm256_and_si256(mm256_neg_epi32(b32_3), mm256_set1_epi32(7));
                        }
                    
                        v256 r_0 = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32_0, b32_0), Avx2.mm256_srlv_epi32(a32_0, inv_0));
                        v256 r_1 = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32_1, b32_1), Avx2.mm256_srlv_epi32(a32_1, inv_1));
                        v256 r_2 = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32_2, b32_2), Avx2.mm256_srlv_epi32(a32_2, inv_2));
                        v256 r_3 = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32_3, b32_3), Avx2.mm256_srlv_epi32(a32_3, inv_3));
                    
                        return mm256_cvt4x4epi32_epi8(r_0, r_1, r_2, r_3, signed: false, noOverflowU16: true);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi16(v128 a, v128 b, bool promise = false, byte elements = 8)
            {
                static v128 naive(v128 a, v128 b, bool promise = false, byte elements = 8)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (!promise)
                        {
                            b = and_si128(b, set1_epi16(15));
                        }

                        v128 inv = and_si128(neg_epi16(b), set1_epi16(15));

                        return or_si128(sllv_epi16(a, b, inRange: true, elements: elements), srlv_epi16(a, inv, inRange: true, elements: elements));
                    }
                    else throw new IllegalInstructionException();
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI16(b))
                    {
                        return rol_epi16(a, b.UShort0);
                    }
                }

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v128 shuffle, elements))
                    {
                        return shuffle_epi8(a, shuffle, elements);
                    }
                }

                if (BurstArchitecture.IsVectorShift16Supported)
                {
                    return naive(a, b, promise, elements);
                }
                else if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = cvtepu16_epi32(a);
                        v128 b32 = cvtepu16_epi32(b);

                        if (!promise)
                        {
                            b32 = and_si128(b32, set1_epi32(15));
                        }

                        v128 inv = and_si128(neg_epi32(b32), set1_epi32(15));

                        return cvtepi32_epi16(or_si128(sllv_epi32(a32, b32), srlv_epi32(a32, inv)), elements);
                    }
                    else
                    {
                        v128 a32Lo = cvt2x2epu16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epu16_epi32(b, out v128 b32Hi);

                        if (!promise)
                        {
                            b32Lo = and_si128(b32Lo, set1_epi32(15));
                            b32Hi = and_si128(b32Hi, set1_epi32(15));
                        }

                        v128 invLo = and_si128(neg_epi32(b32Lo), set1_epi32(15));
                        v128 invHi = and_si128(neg_epi32(b32Hi), set1_epi32(15));

                        v128 r32Lo = or_si128(sllv_epi32(a32Lo, b32Lo), srlv_epi32(a32Lo, invLo));
                        v128 r32Hi = or_si128(sllv_epi32(a32Hi, b32Hi), srlv_epi32(a32Hi, invHi));

                        return cvt2x2epi32_epi16(r32Lo, r32Hi);
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return naive(a, b, promise, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi16(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI16(b))
                    {
                        return mm256_rol_epi16(a, b.UShort0);
                    }
                    
                    if (ROR_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI16(b, out v256 shuffle))
                    {
                        return Avx2.mm256_shuffle_epi8(a, shuffle);
                    }

                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi16(15));
                        }

                        v256 inv = Avx2.mm256_and_si256(mm256_neg_epi16(b), mm256_set1_epi16(15));

                        return Avx2.mm256_or_si256(mm256_sllv_epi16(a, b), mm256_srlv_epi16(a, inv));
                    }
                    else
                    {
                        if (!promise)
                        {
                            b = Avx2.mm256_and_si256(b, mm256_set1_epi8(15));
                        }
                    
                        v256 a32Lo = mm256_cvt2x2epu16_epi32(a, out v256 a32Hi);
                        v256 b32Lo = mm256_cvt2x2epu16_epi32(b, out v256 b32Hi);
                    
                        v256 invLo = Avx2.mm256_and_si256(mm256_neg_epi32(b32Lo), mm256_set1_epi32(15));
                        v256 invHi = Avx2.mm256_and_si256(mm256_neg_epi32(b32Hi), mm256_set1_epi32(15));
                    
                        v256 rLo = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32Lo, b32Lo), Avx2.mm256_srlv_epi32(a32Lo, invLo));
                        v256 rHi = Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32Hi, b32Hi), Avx2.mm256_srlv_epi32(a32Hi, invHi));
                    
                        return mm256_cvt2x2epi32_epi16(rLo, rHi);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi32(v128 a, v128 b, bool promise = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI32(b))
                    {
                        return rol_epi32(a, b.SInt0);
                    }
                    
                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        if (ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(b, out v128 shuffle, elements))
                        {
                            return shuffle_epi8(a, shuffle, elements);
                        }
                    }

                    if (!promise)
                    {
                        b = and_si128(b, set1_epi32(31));
                    }

                    v128 inv = and_si128(neg_epi32(b), set1_epi32(31));

                    return or_si128(sllv_epi32(a, b, inRange: true, elements: elements), srlv_epi32(a, inv, inRange: true, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi32(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI32(b))
                    {
                        return mm256_rol_epi32(a, b.SInt0);
                    }
                    
                    if (ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI32(b, out v256 shuffle))
                    {
                        return Avx2.mm256_shuffle_epi8(a, shuffle);
                    }

                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, mm256_set1_epi32(31));
                    }

                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b), mm256_set1_epi32(31));

                    return Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a, b), Avx2.mm256_srlv_epi32(a, inv));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi64(v128 a, v128 b, bool promise = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_SAME_EPI64(b))
                    {
                        return rol_epi64(a, b.SInt0);
                    }
                    
                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        if (ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(b, out v128 shuffle))
                        {
                            return shuffle_epi8(a, shuffle);
                        }
                    }

                    if (!promise)
                    {
                        b = and_si128(b, set1_epi64x(63));
                    }

                    v128 inv = and_si128(neg_epi64(b), set1_epi64x(63));

                    return or_si128(sllv_epi64(a, b, inRange: true), srlv_epi64(a, inv, inRange: true));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi64(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_SAME_EPI64(b))
                    {
                        return mm256_rol_epi64(a, b.SInt0);
                    }
                    
                    if (ROL_SHUFFLE_MASK_FROM_MULTIPLE_OF_8_INDICES_EPI64(b, out v256 shuffle))
                    {
                        return Avx2.mm256_shuffle_epi8(a, shuffle);
                    }

                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, mm256_set1_epi64x(63));
                    }

                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi64(b), mm256_set1_epi64x(63));

                    return Avx2.mm256_or_si256(Avx2.mm256_sllv_epi64(a, b), Avx2.mm256_srlv_epi64(a, inv));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, sbyte2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new sbyte2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, sbyte3 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new sbyte3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, sbyte4 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new sbyte4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, sbyte8 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new sbyte8(ror(x.x0, n.x0), ror(x.x1, n.x1), ror(x.x2, n.x2), ror(x.x3, n.x3), ror(x.x4, n.x4), ror(x.x5, n.x5), ror(x.x6, n.x6), ror(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, sbyte16 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 16);
            }
            else
            {
                return new sbyte16(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte32"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, sbyte32 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte32(ror(x.v16_0, n.v16_0), ror(x.v16_16, n.v16_16));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, byte2 n, Promise inRange = Promise.Nothing)
        {
            return (byte2)ror((sbyte2)x, (sbyte2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, byte3 n, Promise inRange = Promise.Nothing)
        {
            return (byte3)ror((sbyte3)x, (sbyte3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, byte4 n, Promise inRange = Promise.Nothing)
        {
            return (byte4)ror((sbyte4)x, (sbyte4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, byte8 n, Promise inRange = Promise.Nothing)
        {
            return (byte8)ror((sbyte8)x, (sbyte8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, byte16 n, Promise inRange = Promise.Nothing)
        {
            return (byte16)ror((sbyte16)x, (sbyte16)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte32"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, byte32 n, Promise inRange = Promise.Nothing)
        {
            return (byte32)ror((sbyte32)x, (sbyte32)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, short2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new short2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, short3 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new short3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, short4 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new short4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, short8 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new short8(ror(x.x0, n.x0), ror(x.x1, n.x1), ror(x.x2, n.x2), ror(x.x3, n.x3), ror(x.x4, n.x4), ror(x.x5, n.x5), ror(x.x6, n.x6), ror(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, short16 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, ushort2 n, Promise inRange = Promise.Nothing)
        {
            return (ushort2)ror((short2)x, (short2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, ushort3 n, Promise inRange = Promise.Nothing)
        {
            return (ushort3)ror((short3)x, (short3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, ushort4 n, Promise inRange = Promise.Nothing)
        {
            return (ushort4)ror((short4)x, (short4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, ushort8 n, Promise inRange = Promise.Nothing)
        {
            return (ushort8)ror((short8)x, (short8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, ushort16 n, Promise inRange = Promise.Nothing)
        {
            return (ushort16)ror((short16)x, (short16)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ror(int2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi32(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new int2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ror(int3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi32(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new int3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ror(int4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi32(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new int4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi32(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(ror(x.v4_0, n.v4_0), ror(x.v4_4, n.v4_4));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, uint2 n, Promise inRange = Promise.Nothing)
        {
            return (uint2)ror((int2)x, (int2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, uint3 n, Promise inRange = Promise.Nothing)
        {
            return (uint3)ror((int3)x, (int3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, uint4 n, Promise inRange = Promise.Nothing)
        {
            return (uint4)ror((int4)x, (int4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, uint8 n, Promise inRange = Promise.Nothing)
        {
            return (uint8)ror((int8)x, (int8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint8)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="long2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rorv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(ror(x.x, (int)n.x), ror(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="long3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long3(ror(x.xy, n.xy), ror(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="long4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long4(ror(x.xy, n.xy), ror(x.zw, n.zw));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, ulong2 n, Promise inRange = Promise.Nothing)
        {
            return (ulong2)ror((long2)x, (long2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, ulong3 n, Promise inRange = Promise.Nothing)
        {
            return (ulong3)ror((long3)x, (long3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, ulong4 n, Promise inRange = Promise.Nothing)
        {
            return (ulong4)ror((long4)x, (long4)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (ulong2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (ulong3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (ulong4)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 rol(sbyte2 x, sbyte2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new sbyte2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 rol(sbyte3 x, sbyte3 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new sbyte3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 rol(sbyte4 x, sbyte4 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new sbyte4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 rol(sbyte8 x, sbyte8 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new sbyte8(rol(x.x0, n.x0), rol(x.x1, n.x1), rol(x.x2, n.x2), rol(x.x3, n.x3), rol(x.x4, n.x4), rol(x.x5, n.x5), rol(x.x6, n.x6), rol(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 rol(sbyte16 x, sbyte16 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 16);
            }
            else
            {
                return new sbyte16(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="sbyte32"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 rol(sbyte32 x, sbyte32 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte32(rol(x.v16_0, n.v16_0), rol(x.v16_16, n.v16_16));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 rol(byte2 x, byte2 n, Promise inRange = Promise.Nothing)
        {
            return (byte2)rol((sbyte2)x, (sbyte2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rol(byte3 x, byte3 n, Promise inRange = Promise.Nothing)
        {
            return (byte3)rol((sbyte3)x, (sbyte3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rol(byte4 x, byte4 n, Promise inRange = Promise.Nothing)
        {
            return (byte4)rol((sbyte4)x, (sbyte4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 rol(byte8 x, byte8 n, Promise inRange = Promise.Nothing)
        {
            return (byte8)rol((sbyte8)x, (sbyte8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 rol(byte16 x, byte16 n, Promise inRange = Promise.Nothing)
        {
            return (byte16)rol((sbyte16)x, (sbyte16)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="byte32"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 rol(byte32 x, byte32 n, Promise inRange = Promise.Nothing)
        {
            return (byte32)rol((sbyte32)x, (sbyte32)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 rol(short2 x, short2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new short2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 rol(short3 x, short3 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new short3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 rol(short4 x, short4 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new short4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 rol(short8 x, short8 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new short8(rol(x.x0, n.x0), rol(x.x1, n.x1), rol(x.x2, n.x2), rol(x.x3, n.x3), rol(x.x4, n.x4), rol(x.x5, n.x5), rol(x.x6, n.x6), rol(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="short16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 rol(short16 x, short16 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 rol(ushort2 x, ushort2 n, Promise inRange = Promise.Nothing)
        {
            return (ushort2)rol((short2)x, (short2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 rol(ushort3 x, ushort3 n, Promise inRange = Promise.Nothing)
        {
            return (ushort3)rol((short3)x, (short3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 rol(ushort4 x, ushort4 n, Promise inRange = Promise.Nothing)
        {
            return (ushort4)rol((short4)x, (short4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 rol(ushort8 x, ushort8 n, Promise inRange = Promise.Nothing)
        {
            return (ushort8)rol((short8)x, (short8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ushort16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 rol(ushort16 x, ushort16 n, Promise inRange = Promise.Nothing)
        {
            return (ushort16)rol((short16)x, (short16)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 rol(int2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi32(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new int2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 rol(int3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi32(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new int3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 rol(int4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi32(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new int4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi32(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(rol(x.v4_0, n.v4_0), rol(x.v4_4, n.v4_4));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, uint2 n, Promise inRange = Promise.Nothing)
        {
            return (uint2)rol((int2)x, (int2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, uint3 n, Promise inRange = Promise.Nothing)
        {
            return (uint3)rol((int3)x, (int3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, uint4 n, Promise inRange = Promise.Nothing)
        {
            return (uint4)rol((int4)x, (int4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, uint8 n, Promise inRange = Promise.Nothing)
        {
            return (uint8)rol((int8)x, (int8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint8)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="long2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rolv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(rol(x.x, (int)n.x), rol(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="long3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long3(rol(x.xy, n.xy), rol(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="long4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long4(rol(x.xy, n.xy), rol(x.zw, n.zw));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, ulong2 n, Promise inRange = Promise.Nothing)
        {
            return (ulong2)rol((long2)x, (long2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, ulong3 n, Promise inRange = Promise.Nothing)
        {
            return (ulong3)rol((long3)x, (long3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, ulong4 n, Promise inRange = Promise.Nothing)
        {
            return (ulong4)rol((long4)x, (long4)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (ulong2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (ulong3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="ulong4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (ulong4)n, inRange);
        }
    }
}