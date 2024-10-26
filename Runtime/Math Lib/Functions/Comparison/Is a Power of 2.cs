using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu8(v128 a, bool signed, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result = cmpeq_epi8(blsr_epi8(a), setzero_si128());

                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI8(a, 0, elements))
                        {
                            result = and_si128(cmpgt_epi8(a, setzero_si128()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU8(a, 0, elements))
                        {
                            result = andnot_si128(cmpeq_epi8(a, setzero_si128()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu16(v128 a, bool signed, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result = cmpeq_epi16(blsr_epi16(a), setzero_si128());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI16(a, 0, elements))
                        {
                            result = and_si128(cmpgt_epi16(a, setzero_si128()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU16(a, 0, elements))
                        {
                            result = andnot_si128(cmpeq_epi16(a, setzero_si128()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu32(v128 a, bool signed, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result = cmpeq_epi32(blsr_epi32(a), setzero_si128());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI32(a, 0, elements))
                        {
                            result = and_si128(cmpgt_epi32(a, setzero_si128()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU32(a, 0, elements))
                        {
                            result = andnot_si128(cmpeq_epi32(a, setzero_si128()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu64(v128 a, bool signed)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result = cmpeq_epi64(blsr_epi64(a), setzero_si128());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI64(a, 0))
                        {
                            result = and_si128(cmpgt_epi64(a, setzero_si128()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU64(a, 0))
                        {
                            result = andnot_si128(cmpeq_epi64(a, setzero_si128()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu8(v256 a, bool signed)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_cmpeq_epi8(mm256_blsr_epi8(a), Avx.mm256_setzero_si256());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI8(a, 0))
                        {
                            result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(a, Avx.mm256_setzero_si256()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU8(a, 0))
                        {
                            result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu16(v256 a, bool signed)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_cmpeq_epi16(mm256_blsr_epi16(a), Avx.mm256_setzero_si256());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI16(a, 0))
                        {
                            result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi16(a, Avx.mm256_setzero_si256()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU16(a, 0))
                        {
                            result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu32(v256 a, bool signed)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_cmpeq_epi32(mm256_blsr_epi32(a), Avx.mm256_setzero_si256());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI32(a, 0))
                        {
                            result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi32(a, Avx.mm256_setzero_si256()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU32(a, 0))
                        {
                            result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu64(v256 a, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_cmpeq_epi64(mm256_blsr_epi64(a), Avx.mm256_setzero_si256());
                    
                    if (signed)
                    {
                        if (!constexpr.ALL_GT_EPI64(a, 0, elements))
                        {
                            result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(a, Avx.mm256_setzero_si256()), result);
                        }
                    }
                    else
                    {
                        if (!constexpr.ALL_GT_EPU64(a, 0, elements))
                        {
                            result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256()), result);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe public static partial class maxmath
    {
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(UInt128 x)
        {
            if (Architecture.IsPopcntSupported)
            {
                return countbits(x) == 1;
            }
            else
            {
                return x.IsNotZero & (bits_resetlowest(x) == 0);
            }
        }

        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(Int128 x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(byte x)
        {
            return (x != 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.pow2_epu8(x, false, 2)));
            }
            else
            {
                return new bool2(math.ispow2((uint)x.x), math.ispow2((uint)x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.pow2_epu8(x, false, 3)));
            }
            else
            {
                return new bool3(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.pow2_epu8(x, false, 4)));
            }
            else
            {
                return new bool4(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z), math.ispow2((uint)x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.pow2_epu8(x, false, 8));
            }
            else
            {
                return new bool8(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.pow2_epu8(x, false, 16));
            }
            else
            {
                return new bool16(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7), math.ispow2((uint)x.x8), math.ispow2((uint)x.x9), math.ispow2((uint)x.x10), math.ispow2((uint)x.x11), math.ispow2((uint)x.x12), math.ispow2((uint)x.x13), math.ispow2((uint)x.x14), math.ispow2((uint)x.x15));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 ispow2(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_pow2_epu8(x, false));
            }
            else
            {
                return new bool32(ispow2(x.v16_0), ispow2(x.v16_16));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(sbyte x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(sbyte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.pow2_epu8(x, true, 2)));
            }
            else
            {
                return new bool2(math.ispow2(x.x), math.ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.pow2_epu8(x, true, 3)));
            }
            else
            {
                return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(sbyte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.pow2_epu8(x, true, 4)));
            }
            else
            {
                return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(sbyte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.pow2_epu8(x, true, 8));
            }
            else
            {
                return new bool8(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(sbyte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.pow2_epu8(x, true, 16));
            }
            else
            {
                return new bool16(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7), math.ispow2(x.x8), math.ispow2(x.x9), math.ispow2(x.x10), math.ispow2(x.x11), math.ispow2(x.x12), math.ispow2(x.x13), math.ispow2(x.x14), math.ispow2(x.x15));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 ispow2(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.mm256_pow2_epu8(x, true));
            }
            else
            {
                return new bool32(ispow2(x.v16_0), ispow2(x.v16_16));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ushort x)
        {
            return (x != 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.pow2_epu16(x, false, 2)));
            }
            else
            {
                return new bool2(math.ispow2((uint)x.x), math.ispow2((uint)x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.pow2_epu16(x, false, 3)));
            }
            else
            {
                return new bool3(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.pow2_epu16(x, false, 4)));
            }
            else
            {
                return new bool4(math.ispow2((uint)x.x), math.ispow2((uint)x.y), math.ispow2((uint)x.z), math.ispow2((uint)x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.pow2_epu16(x, false, 8));
            }
            else
            {
                return new bool8(math.ispow2((uint)x.x0), math.ispow2((uint)x.x1), math.ispow2((uint)x.x2), math.ispow2((uint)x.x3), math.ispow2((uint)x.x4), math.ispow2((uint)x.x5), math.ispow2((uint)x.x6), math.ispow2((uint)x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_pow2_epu16(x, false));
            }
            else
            {
                return new bool16(ispow2(x.v8_0), ispow2(x.v8_8));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(short x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.pow2_epu16(x, true, 2)));
            }
            else
            {
                return new bool2(math.ispow2(x.x), math.ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.pow2_epu16(x, true, 3)));
            }
            else
            {
                return new bool3(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.pow2_epu16(x, true, 4)));
            }
            else
            {
                return new bool4(math.ispow2(x.x), math.ispow2(x.y), math.ispow2(x.z), math.ispow2(x.w));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(short8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Xse.pow2_epu16(x, true, 8));
            }
            else
            {
                return new bool8(math.ispow2(x.x0), math.ispow2(x.x1), math.ispow2(x.x2), math.ispow2(x.x3), math.ispow2(x.x4), math.ispow2(x.x5), math.ispow2(x.x6), math.ispow2(x.x7));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 ispow2(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.mm256_pow2_epu16(x, true));
            }
            else
            {
                return new bool16(ispow2(x.v8_0), ispow2(x.v8_8));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_pow2_epu32(x, false));
            }
            else
            {
                return new bool8(math.ispow2(x.v4_0), math.ispow2(x.v4_4));
            }
        }


        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 ispow2(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_pow2_epu32(x, true));
            }
            else
            {
                return new bool8(math.ispow2(x.v4_0), math.ispow2(x.v4_4));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ulong x)
        {
            return (x != 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.pow2_epu64(x, false)));
            }
            else
            {
                return new bool2(ispow2(x.x), ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_pow2_epu64(x, false, 3)));
            }
            else
            {
                return new bool3(ispow2(x.xy), ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_pow2_epu64(x, false, 4)));
            }
            else
            {
                return new bool4(ispow2(x.xy), ispow2(x.zw));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(long x)
        {
            return (x > 0) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(long2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.pow2_epu64(x, true)));
            }
            else
            {
                return new bool2(ispow2(x.x), ispow2(x.y));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 ispow2(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_pow2_epu64(x, true, 3)));
            }
            else
            {
                return new bool3(ispow2(x.xy), ispow2(x.z));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 ispow2(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_pow2_epu64(x, true, 4)));
            }
            else
            {
                return new bool4(ispow2(x.xy), ispow2(x.zw));
            }
        }
    }
}