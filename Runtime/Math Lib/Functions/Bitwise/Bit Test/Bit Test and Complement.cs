using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
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
            public static v128 btc_epi8(ref v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 7, elements))
                    {
                        v128 ret = result == MaskType.One ? srli_epi8(a, 7) : srai_epi8(a, 7);
                        a = Sse2.xor_si128(a, Sse2.set1_epi8(unchecked((sbyte)(1 << 7))));
                        
                        return ret;
                    }

                    // const (all ones) -> 1 instruction with pow2 table 
                    v128 powsOf2 = sllv_epi8(Sse2.set1_epi8(1), b, elements);
                    
                    v128 mask = Sse2.cmpeq_epi8(powsOf2, Sse2.and_si128(powsOf2, a));
                    a = Sse2.xor_si128(a, powsOf2);
                    
                    return result == MaskType.One ? negmask_epi8(mask, elements) : mask; 
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btc_epi8(ref v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {                 
                    if (constexpr.ALL_EQ_EPI8(b, 7))
                    {
                        v256 ret = result == MaskType.One ? mm256_srli_epi8(a, 7) : mm256_srai_epi8(a, 7);
                        a = Avx2.mm256_xor_si256(a, Avx.mm256_set1_epi8(unchecked((byte)(1 << 7))));
                        
                        return ret;
                    }
 
                    // const (all ones) -> 1 instruction with pow2 table
                    v256 powsOf2 = mm256_sllv_epi8(Avx.mm256_set1_epi8(1), b);

                    v256 mask = Avx2.mm256_cmpeq_epi8(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_xor_si256(a, powsOf2);
                    
                    return result == MaskType.One ? mm256_negmask_epi8(mask) : mask; 
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btc_epi16(ref v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 15, elements))
                    {
                        v128 ret = result == MaskType.One ? Sse2.srli_epi16(a, 15) : Sse2.srai_epi16(a, 15);
                        a = Sse2.xor_si128(a, Sse2.set1_epi16(unchecked((short)(1 << 15))));
                        
                        return ret;
                    }
                    
                    v128 powsOf2 = sllv_epi16(Sse2.set1_epi16(1), b, elements);
                    v128 mask = Sse2.cmpeq_epi16(powsOf2, Sse2.and_si128(powsOf2, a));
                    a = Sse2.xor_si128(a, powsOf2);;
                    
                    return result == MaskType.One ? negmask_epi16(mask, elements) : mask; 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btc_epi16(ref v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 15))
                    {
                        v256 ret = result == MaskType.One ? Avx2.mm256_srli_epi16(a, 15) : Avx2.mm256_srai_epi16(a, 15);
                        a = Avx2.mm256_xor_si256(a, Avx.mm256_set1_epi16(unchecked((short)(1 << 15))));
                        
                        return ret;
                    }

                    v256 powsOf2 = mm256_sllv_epi16(Avx.mm256_set1_epi16(1), b);
                    v256 mask = Avx2.mm256_cmpeq_epi16(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_xor_si256(a, powsOf2);;
                    
                    return result == MaskType.One ? mm256_negmask_epi16(mask) : mask; 
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btc_epi32(ref v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 31, elements))
                    {
                        v128 ret = result == MaskType.One ? Sse2.srli_epi32(a, 31) : Sse2.srai_epi32(a, 31);
                        a = Sse2.xor_si128(a, Sse2.set1_epi32(unchecked((int)(1 << 31))));
                        
                        return ret;
                    }
                    
                    v128 powsOf2 = sllv_epi32(Sse2.set1_epi32(1), b, elements);
                    v128 mask = Sse2.cmpeq_epi32(powsOf2, Sse2.and_si128(powsOf2, a));
                    a = Sse2.xor_si128(a, powsOf2);;
                    
                    return result == MaskType.One ? negmask_epi32(mask, elements) : mask; 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btc_epi32(ref v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 31))
                    {
                        v256 ret = result == MaskType.One ? Avx2.mm256_srli_epi32(a, 31) : Avx2.mm256_srai_epi32(a, 31);
                        a = Avx2.mm256_xor_si256(a, Avx.mm256_set1_epi32(unchecked((int)(1 << 31))));
                        
                        return ret;
                    }
                    
                    v256 powsOf2 = Avx2.mm256_sllv_epi32(Avx.mm256_set1_epi32(1), b);
                    v256 mask = Avx2.mm256_cmpeq_epi32(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_xor_si256(a, powsOf2);;
                    
                    return result == MaskType.One ? mm256_negmask_epi32(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btc_epi64(ref v128 a, v128 b, MaskType result = MaskType.AllOnes)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, 63))
                    {
                        v128 ret = result == MaskType.One ? Sse2.srli_epi64(a, 63) : srai_epi64(a, 63);
                        a = Sse2.xor_si128(a, Sse2.set1_epi64x(unchecked((long)(1ul << 63))));
                        
                        return ret;
                    }
                    
                    v128 powsOf2 = sllv_epi64(Sse2.set1_epi64x(1), b);
                    v128 mask = cmpeq_epi64(powsOf2, Sse2.and_si128(powsOf2, a));
                    a = Sse2.xor_si128(a, powsOf2);;
                    
                    return result == MaskType.One ? negmask_epi64(mask) : mask; 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btc_epi64(ref v256 a, v256 b, MaskType result = MaskType.AllOnes, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, 63, elements))
                    {
                        v256 ret = result == MaskType.One ? Avx2.mm256_srli_epi64(a, 63) : mm256_srai_epi64(a, 63);
                        a = Avx2.mm256_xor_si256(a, Avx.mm256_set1_epi64x(unchecked((long)(1ul << 63))));
                        
                        return ret;
                    }
                    
                    v256 powsOf2 = Avx2.mm256_sllv_epi64(Avx.mm256_set1_epi64x(1), b);
                    v256 mask = Avx2.mm256_cmpeq_epi64(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_xor_si256(a, powsOf2);;
                    
                    return result == MaskType.One ? mm256_negmask_epi64(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref UInt128 x, ulong i)
        {
            if (Constant.IsConstantExpression(i))
            {
                if (i >= 64)
                {
                    ulong __ref = x.hi64;
                    bool result = testbitflip(ref __ref, i - 64);
                    x = new UInt128(x.lo64, __ref);
                    
                    return result;
                }
                else
                {
                    ulong __ref = x.lo64;
                    bool result = testbitflip(ref __ref, i);
                    x = new UInt128(__ref, x.hi64);
                    
                    return result;
                }
            }
            else
            {
                return (x & ((UInt128)1 << (int)i)) != 0;
            }
        }
        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref Int128 x, long i)
        {
            UInt128 __ref = (UInt128)x;
            bool result = testbitflip(ref __ref, (ulong)i);
            x = (Int128)__ref;

            return result;
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref byte x, byte i)
        {
            uint bit = 1u << i;
            bool result = (x & bit) != 0;
            x ^= (byte)bit;

            return result;
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref byte2 x, byte2 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool2 result = RegisterConversion.ToBool2(Xse.btc_epi8(ref __ref, i, MaskType.One, 2));
                x = __ref;

                return result;
            }
            else
            {
                return new bool2(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref byte3 x, byte3 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool3 result = RegisterConversion.ToBool3(Xse.btc_epi8(ref __ref, i, MaskType.One, 3));
                x = __ref;

                return result;
            }
            else
            {
                return new bool3(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y), testbitflip(ref x.z, i.z));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref byte4 x, byte4 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool4 result = RegisterConversion.ToBool4(Xse.btc_epi8(ref __ref, i, MaskType.One, 4));
                x = __ref;

                return result;
            }
            else
            {
                return new bool4(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y), testbitflip(ref x.z, i.z), testbitflip(ref x.w, i.w));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitflip(ref byte8 x, byte8 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool8 result = Xse.btc_epi8(ref __ref, i, MaskType.One, 8);
                x = __ref;

                return result;
            }
            else
            {
                return new bool8(testbitflip(ref x.x0, i.x0), 
                                 testbitflip(ref x.x1, i.x1), 
                                 testbitflip(ref x.x2, i.x2), 
                                 testbitflip(ref x.x3, i.x3), 
                                 testbitflip(ref x.x4, i.x4), 
                                 testbitflip(ref x.x5, i.x5), 
                                 testbitflip(ref x.x6, i.x6), 
                                 testbitflip(ref x.x7, i.x7));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitflip(ref byte16 x, byte16 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool16 result = Xse.btc_epi8(ref __ref, i, MaskType.One, 16);
                x = __ref;

                return result;
            }
            else
            {
                return new bool16(testbitflip(ref x.x0,  i.x0), 
                                  testbitflip(ref x.x1,  i.x1), 
                                  testbitflip(ref x.x2,  i.x2), 
                                  testbitflip(ref x.x3,  i.x3), 
                                  testbitflip(ref x.x4,  i.x4), 
                                  testbitflip(ref x.x5,  i.x5), 
                                  testbitflip(ref x.x6,  i.x6), 
                                  testbitflip(ref x.x7,  i.x7), 
                                  testbitflip(ref x.x8,  i.x8), 
                                  testbitflip(ref x.x9,  i.x9), 
                                  testbitflip(ref x.x10, i.x10), 
                                  testbitflip(ref x.x11, i.x11), 
                                  testbitflip(ref x.x12, i.x12), 
                                  testbitflip(ref x.x13, i.x13), 
                                  testbitflip(ref x.x14, i.x14), 
                                  testbitflip(ref x.x15, i.x15));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 testbitflip(ref byte32 x, byte32 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool32 result = Xse.mm256_btc_epi8(ref __ref, i, MaskType.One);
                x = __ref;

                return result;
            }
            else
            {
                byte16 xLo = x.v16_0;
                byte16 xHi = x.v16_16;
                bool32 result = new bool32(testbitflip(ref xLo, i.v16_0), testbitflip(ref xHi, i.v16_16));
                x = new byte32(xLo, xHi);

                return result;
            }
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref ushort x, ushort i)
        {
            uint bit = 1u << i;
            bool result = (x & bit) != 0;
            x ^= (ushort)bit;

            return result;
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref ushort2 x, ushort2 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool2 result = RegisterConversion.ToBool2(Xse.cvtepi16_epi8(Xse.btc_epi16(ref __ref, i, MaskType.One, 2), 2));
                x = __ref;

                return result;
            }
            else
            {
                return new bool2(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref ushort3 x, ushort3 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool3 result = RegisterConversion.ToBool3(Xse.cvtepi16_epi8(Xse.btc_epi16(ref __ref, i, MaskType.One, 3), 3));
                x = __ref;

                return result;
            }
            else
            {
                return new bool3(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y), testbitflip(ref x.z, i.z));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref ushort4 x, ushort4 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool4 result = RegisterConversion.ToBool4(Xse.cvtepi16_epi8(Xse.btc_epi16(ref __ref, i, MaskType.One, 4), 4));
                x = __ref;

                return result;
            }
            else
            {
                return new bool4(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y), testbitflip(ref x.z, i.z), testbitflip(ref x.w, i.w));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitflip(ref ushort8 x, ushort8 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool8 result = Xse.cvtepi16_epi8(Xse.btc_epi16(ref __ref, i, MaskType.One, 8), 8);
                x = __ref;

                return result;
            }
            else
            {
                return new bool8(testbitflip(ref x.x0, i.x0), 
                                 testbitflip(ref x.x1, i.x1), 
                                 testbitflip(ref x.x2, i.x2), 
                                 testbitflip(ref x.x3, i.x3), 
                                 testbitflip(ref x.x4, i.x4), 
                                 testbitflip(ref x.x5, i.x5), 
                                 testbitflip(ref x.x6, i.x6), 
                                 testbitflip(ref x.x7, i.x7));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitflip(ref ushort16 x, ushort16 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool16 result = Xse.mm256_cvtepi16_epi8(Xse.mm256_btc_epi16(ref __ref, i, MaskType.One));
                x = __ref;

                return result;
            }
            else
            {
                ushort8 xLo = x.v8_0;
                ushort8 xHi = x.v8_8;
                bool16 result = new bool16(testbitflip(ref xLo, i.v8_0), testbitflip(ref xHi, i.v8_8));
                x = new ushort16(xLo, xHi);

                return result;
            }
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref uint x, uint i)
        {
            uint bit = 1u << (int)i;
            bool result = (x & bit) != 0;
            x ^= bit;

            return result;
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref uint2 x, uint2 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = RegisterConversion.ToV128(x);
                bool2 result = RegisterConversion.ToBool2(Xse.cvtepi32_epi8(Xse.btc_epi32(ref __ref, RegisterConversion.ToV128(i), MaskType.One, 2), 2));
                x = RegisterConversion.ToUInt2(__ref);

                return result;
            }
            else
            {
                return new bool2(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref uint3 x, uint3 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = RegisterConversion.ToV128(x);
                bool3 result = RegisterConversion.ToBool3(Xse.cvtepi32_epi8(Xse.btc_epi32(ref __ref, RegisterConversion.ToV128(i), MaskType.One, 3), 3));
                x = RegisterConversion.ToUInt3(__ref);

                return result;
            }
            else
            {
                return new bool3(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y), testbitflip(ref x.z, i.z));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref uint4 x, uint4 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = RegisterConversion.ToV128(x);
                bool4 result = RegisterConversion.ToBool4(Xse.cvtepi32_epi8(Xse.btc_epi32(ref __ref, RegisterConversion.ToV128(i), MaskType.One, 4), 4));
                x = RegisterConversion.ToUInt4(__ref);

                return result;
            }
            else
            {
                return new bool4(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y), testbitflip(ref x.z, i.z), testbitflip(ref x.w, i.w));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitflip(ref uint8 x, uint8 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool8 result = Xse.mm256_cvtepi32_epi8(Xse.mm256_btc_epi32(ref __ref, i, MaskType.One));
                x = __ref;

                return result;
            }
            else
            {
                uint4 xLo = x.v4_0;
                uint4 xHi = x.v4_4;
                bool8 result = new bool8(testbitflip(ref xLo, i.v4_0), testbitflip(ref xHi, i.v4_4));
                x = new uint8(xLo, xHi);

                return result;
            }
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref ulong x, ulong i)
        {
            ulong bit = 1ul << (int)i;
            bool result = (x & bit) != 0;
            x ^= bit;

            return result;
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref ulong2 x, ulong2 i)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 __ref = x;
                bool2 result = RegisterConversion.ToBool2(Xse.cvtepi64_epi8(Xse.btc_epi64(ref __ref, i, MaskType.One)));
                x = __ref;

                return result;
            }
            else
            {
                return new bool2(testbitflip(ref x.x, i.x), testbitflip(ref x.y, i.y));
            }
        }
        
        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref ulong3 x, ulong3 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool3 result = RegisterConversion.ToBool3(Xse.mm256_cvtepi64_epi8(Xse.mm256_btc_epi64(ref __ref, i, MaskType.One)));
                x = __ref;

                return result;
            }
            else
            {
                ulong2 __ref = x.xy;
                bool3 result = new bool3(testbitflip(ref __ref, i.xy), testbitflip(ref x.z, i.z)); 
                x = new ulong3(__ref, x.z);

                return result;
            }
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref ulong4 x, ulong4 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool4 result = RegisterConversion.ToBool4(Xse.mm256_cvtepi64_epi8(Xse.mm256_btc_epi64(ref __ref, i, MaskType.One)));
                x = __ref;

                return result;
            }
            else
            {
                ulong2 __xy = x.xy;
                ulong2 __zw = x.zw;
                bool4 result = new bool4(testbitflip(ref __xy, i.xy), testbitflip(ref __zw, i.zw)); 
                x = new ulong4(__xy, __zw);

                return result;
            }
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref sbyte x, sbyte i)
        {
            byte __ref = (byte)x;
            bool result = testbitflip(ref __ref, (byte)i);
            x = (sbyte)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref sbyte2 x, sbyte2 i)
        {
            byte2 __ref = (byte2)x;
            bool2 result = testbitflip(ref __ref, (byte2)i);
            x = (sbyte2)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref sbyte3 x, sbyte3 i)
        {
            byte3 __ref = (byte3)x;
            bool3 result = testbitflip(ref __ref, (byte3)i);
            x = (sbyte3)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref sbyte4 x, sbyte4 i)
        {
            byte4 __ref = (byte4)x;
            bool4 result = testbitflip(ref __ref, (byte4)i);
            x = (sbyte4)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitflip(ref sbyte8 x, sbyte8 i)
        {
            byte8 __ref = (byte8)x;
            bool8 result = testbitflip(ref __ref, (byte8)i);
            x = (sbyte8)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitflip(ref sbyte16 x, sbyte16 i)
        {
            byte16 __ref = (byte16)x;
            bool16 result = testbitflip(ref __ref, (byte16)i);
            x = (sbyte16)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 testbitflip(ref sbyte32 x, sbyte32 i)
        {
            byte32 __ref = (byte32)x;
            bool32 result = testbitflip(ref __ref, (byte32)i);
            x = (sbyte32)__ref;

            return result;
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref short x, short i)
        {
            ushort __ref = (ushort)x;
            bool result = testbitflip(ref __ref, (ushort)i);
            x = (short)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref short2 x, short2 i)
        {
            ushort2 __ref = (ushort2)x;
            bool2 result = testbitflip(ref __ref, (ushort2)i);
            x = (short2)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref short3 x, short3 i)
        {
            ushort3 __ref = (ushort3)x;
            bool3 result = testbitflip(ref __ref, (ushort3)i);
            x = (short3)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref short4 x, short4 i)
        {
            ushort4 __ref = (ushort4)x;
            bool4 result = testbitflip(ref __ref, (ushort4)i);
            x = (short4)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitflip(ref short8 x, short8 i)
        {
            ushort8 __ref = (ushort8)x;
            bool8 result = testbitflip(ref __ref, (ushort8)i);
            x = (short8)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitflip(ref short16 x, short16 i)
        {
            ushort16 __ref = (ushort16)x;
            bool16 result = testbitflip(ref __ref, (ushort16)i);
            x = (short16)__ref;

            return result;
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref int x, int i)
        {
            uint __ref = (uint)x;
            bool result = testbitflip(ref __ref, (uint)i);
            x = (int)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref int2 x, int2 i)
        {
            uint2 __ref = (uint2)x;
            bool2 result = testbitflip(ref __ref, (uint2)i);
            x = (int2)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref int3 x, int3 i)
        {
            uint3 __ref = (uint3)x;
            bool3 result = testbitflip(ref __ref, (uint3)i);
            x = (int3)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref int4 x, int4 i)
        {
            uint4 __ref = (uint4)x;
            bool4 result = testbitflip(ref __ref, (uint4)i);
            x = (int4)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitflip(ref int8 x, int8 i)
        {
            uint8 __ref = (uint8)x;
            bool8 result = testbitflip(ref __ref, (uint8)i);
            x = (int8)__ref;

            return result;
        }

        
        /// <summary>       Flips the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitflip(ref long x, long i)
        {
            ulong __ref = (ulong)x;
            bool result = testbitflip(ref __ref, (ulong)i);
            x = (long)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitflip(ref long2 x, long2 i)
        {
            ulong2 __ref = (ulong2)x;
            bool2 result = testbitflip(ref __ref, (ulong2)i);
            x = (long2)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitflip(ref long3 x, long3 i)
        {
            ulong3 __ref = (ulong3)x;
            bool3 result = testbitflip(ref __ref, (ulong3)i);
            x = (long3)__ref;

            return result;
        }

        /// <summary>       Flips the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitflip(ref long4 x, long4 i)
        {
            ulong4 __ref = (ulong4)x;
            bool4 result = testbitflip(ref __ref, (ulong4)i);
            x = (long4)__ref;

            return result;
        }
    }
}
