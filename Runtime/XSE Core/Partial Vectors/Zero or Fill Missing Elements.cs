using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 zeromissing_epi8(v128 a, byte elements)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(a.Byte2  == 0) &&
                            constexpr.IS_TRUE(a.Byte3  == 0) &&
                            constexpr.IS_TRUE(a.Byte4  == 0) &&
                            constexpr.IS_TRUE(a.Byte5  == 0) &&
                            constexpr.IS_TRUE(a.Byte6  == 0) &&
                            constexpr.IS_TRUE(a.Byte7  == 0) &&
                            constexpr.IS_TRUE(a.Byte8  == 0) &&
                            constexpr.IS_TRUE(a.Byte9  == 0) &&
                            constexpr.IS_TRUE(a.Byte10 == 0) &&
                            constexpr.IS_TRUE(a.Byte11 == 0) &&
                            constexpr.IS_TRUE(a.Byte12 == 0) &&
                            constexpr.IS_TRUE(a.Byte13 == 0) &&
                            constexpr.IS_TRUE(a.Byte14 == 0) &&
                            constexpr.IS_TRUE(a.Byte15 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setzero_si128(), 0b1111_1110);
                            }
                            else
                            {
                                return and_si128(a, new v128(-1, -1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                            }
                        }
                    }
                    case 3:
                    {
                        if (constexpr.IS_TRUE(a.Byte3  == 0) &&
                            constexpr.IS_TRUE(a.Byte4  == 0) &&
                            constexpr.IS_TRUE(a.Byte5  == 0) &&
                            constexpr.IS_TRUE(a.Byte6  == 0) &&
                            constexpr.IS_TRUE(a.Byte7  == 0) &&
                            constexpr.IS_TRUE(a.Byte8  == 0) &&
                            constexpr.IS_TRUE(a.Byte9  == 0) &&
                            constexpr.IS_TRUE(a.Byte10 == 0) &&
                            constexpr.IS_TRUE(a.Byte11 == 0) &&
                            constexpr.IS_TRUE(a.Byte12 == 0) &&
                            constexpr.IS_TRUE(a.Byte13 == 0) &&
                            constexpr.IS_TRUE(a.Byte14 == 0) &&
                            constexpr.IS_TRUE(a.Byte15 == 0))
                        {
                            return a;
                        }
                        else
                        {

                            return and_si128(a, new v128(-1, -1, -1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                        }
                    }
                    case 4:
                    {
                        if (constexpr.IS_TRUE(a.Byte4  == 0) &&
                            constexpr.IS_TRUE(a.Byte5  == 0) &&
                            constexpr.IS_TRUE(a.Byte6  == 0) &&
                            constexpr.IS_TRUE(a.Byte7  == 0) &&
                            constexpr.IS_TRUE(a.Byte8  == 0) &&
                            constexpr.IS_TRUE(a.Byte9  == 0) &&
                            constexpr.IS_TRUE(a.Byte10 == 0) &&
                            constexpr.IS_TRUE(a.Byte11 == 0) &&
                            constexpr.IS_TRUE(a.Byte12 == 0) &&
                            constexpr.IS_TRUE(a.Byte13 == 0) &&
                            constexpr.IS_TRUE(a.Byte14 == 0) &&
                            constexpr.IS_TRUE(a.Byte15 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setzero_si128(), 0b1111_1100);
                            }
                            else
                            {
                                return and_si128(a, new v128(-1, -1, -1, -1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                            }
                        }
                    }
                    case 8:
                    {
                        if (constexpr.IS_TRUE(a.Byte8  == 0) &&
                            constexpr.IS_TRUE(a.Byte9  == 0) &&
                            constexpr.IS_TRUE(a.Byte10 == 0) &&
                            constexpr.IS_TRUE(a.Byte11 == 0) &&
                            constexpr.IS_TRUE(a.Byte12 == 0) &&
                            constexpr.IS_TRUE(a.Byte13 == 0) &&
                            constexpr.IS_TRUE(a.Byte14 == 0) &&
                            constexpr.IS_TRUE(a.Byte15 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            return unpacklo_epi64(a, setzero_si128());
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
        public static v128 zeromissing_epi16(v128 a, byte elements)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(a.UShort2 == 0) &&
                            constexpr.IS_TRUE(a.UShort3 == 0) &&
                            constexpr.IS_TRUE(a.UShort4 == 0) &&
                            constexpr.IS_TRUE(a.UShort5 == 0) &&
                            constexpr.IS_TRUE(a.UShort6 == 0) &&
                            constexpr.IS_TRUE(a.UShort7 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setzero_si128(), 0b1111_1100);
                            }
                            else
                            {
                                return and_si128(a, new v128(-1, -1,   0, 0, 0, 0, 0, 0));
                            }
                        }
                    }
                    case 3:
                    {
                        if (constexpr.IS_TRUE(a.UShort3 == 0) &&
                            constexpr.IS_TRUE(a.UShort4 == 0) &&
                            constexpr.IS_TRUE(a.UShort5 == 0) &&
                            constexpr.IS_TRUE(a.UShort6 == 0) &&
                            constexpr.IS_TRUE(a.UShort7 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setzero_si128(), 0b1111_1000);
                            }
                            else
                            {
                                return and_si128(a, new v128(-1, -1, -1,   0, 0, 0, 0, 0));
                            }
                        }
                    }
                    case 4:
                    {
                        if (constexpr.IS_TRUE(a.UShort4 == 0) &&
                            constexpr.IS_TRUE(a.UShort5 == 0) &&
                            constexpr.IS_TRUE(a.UShort6 == 0) &&
                            constexpr.IS_TRUE(a.UShort7 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            return unpacklo_epi64(a, setzero_si128());
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
        public static v128 zeromissing_epi32(v128 a, byte elements)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(a.UInt2 == 0) &&
                            constexpr.IS_TRUE(a.UInt3 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            return unpacklo_epi64(a, setzero_si128());
                        }
                    }
                    case 3:
                    {
                        if (constexpr.IS_TRUE(a.UInt3 == 0))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setzero_si128(), 0b1100_0000);
                            }
                            else
                            {
                                return and_si128(a, new v128(-1, -1, -1,   0));
                            }
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
        public static v256 mm256_zeromissing_epi64(v256 a, byte elements)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (elements == 3)
                {
                    if (!constexpr.IS_TRUE(a.ULong3 == 0))
                    {
                        a = Avx2.mm256_blend_epi32(a, Avx.mm256_setzero_si256(), 0b1100_0000);
                    }
                }

                return a;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 fillmissing_epi8(v128 a, byte elements)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(a.Byte2  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte3  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte4  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte5  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte6  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte7  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte8  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte9  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte10 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte11 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte12 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte13 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte14 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte15 == byte.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setall_si128(), 0b1111_1110);
                            }
                            else
                            {
                                return or_si128(a, new v128(0, 0,   -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                            }
                        }
                    }
                    case 3:
                    {
                        if (constexpr.IS_TRUE(a.Byte3  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte4  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte5  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte6  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte7  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte8  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte9  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte10 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte11 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte12 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte13 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte14 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte15 == byte.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            return or_si128(a, new v128(0, 0, 0,   -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                        }
                    }
                    case 4:
                    {
                        if (constexpr.IS_TRUE(a.Byte4  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte5  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte6  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte7  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte8  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte9  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte10 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte11 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte12 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte13 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte14 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte15 == byte.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setall_si128(), 0b1111_1100);
                            }
                            else
                            {
                                return or_si128(a, new v128(0, 0, 0, 0,   -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
                            }
                        }
                    }
                    case 8:
                    {
                        if (constexpr.IS_TRUE(a.Byte8  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte9  == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte10 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte11 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte12 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte13 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte14 == byte.MaxValue) &&
                            constexpr.IS_TRUE(a.Byte15 == byte.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            return unpacklo_epi64(a, setall_si128());
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
        public static v128 fillmissing_epi16(v128 a, byte elements)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(a.UShort2 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort3 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort4 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort5 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort6 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort7 == ushort.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setall_si128(), 0b1111_1100);
                            }
                            else
                            {
                                return or_si128(a, new v128(0, 0,   -1, -1, -1, -1, -1, -1));
                            }
                        }
                    }
                    case 3:
                    {
                        if (constexpr.IS_TRUE(a.UShort3 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort4 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort5 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort6 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort7 == ushort.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setall_si128(), 0b1111_1000);
                            }
                            else
                            {
                                return or_si128(a, new v128(0, 0, 0,   -1, -1, -1, -1, -1));
                            }
                        }
                    }
                    case 4:
                    {
                        if (constexpr.IS_TRUE(a.UShort4 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort5 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort6 == ushort.MaxValue) &&
                            constexpr.IS_TRUE(a.UShort7 == ushort.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            return unpacklo_epi64(a, setall_si128());
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
        public static v128 fillmissing_epi32(v128 a, byte elements)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                switch (elements)
                {
                    case 2:
                    {
                        if (constexpr.IS_TRUE(a.UInt2 == uint.MaxValue) &&
                            constexpr.IS_TRUE(a.UInt3 == uint.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            return unpacklo_epi64(a, setall_si128());
                        }
                    }
                    case 3:
                    {
                        if (constexpr.IS_TRUE(a.UInt3 == uint.MaxValue))
                        {
                            return a;
                        }
                        else
                        {
                            if (BurstArchitecture.IsBlendSupported)
                            {
                                return blend_epi16(a, setall_si128(), 0b1100_0000);
                            }
                            else
                            {
                                return or_si128(a, new v128(0, 0, 0,   -1));
                            }
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
        public static v256 mm256_fillmissing_epi64(v256 a, byte elements)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (elements == 3)
                {
                    if (!constexpr.IS_TRUE(a.ULong3 == ulong.MaxValue))
                    {
                        a = Avx2.mm256_blend_epi32(a, mm256_setall_si256(), 0b1100_0000);
                    }
                }

                return a;
            }
            else throw new IllegalInstructionException();
        }
    }
}
