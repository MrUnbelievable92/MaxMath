using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private static v128 FACTORIALS_EPU8
            {
                get
                {
                    if (Sse2.IsSse2Supported)
                    {
                        return Sse2.cvtsi64x_si128((long)maxmath.bitfield((byte)1, 1, 2, 6, 24, 120, byte.MaxValue, 0));
                    }
                    else throw new IllegalInstructionException();
                }
            }

            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gamma_epu8(v128 a, bool promiseNoOverflow = false, byte elements = 16)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = Sse2.min_epu8(a, Sse2.set1_epi8(7));
                    }

                    return Ssse3.shuffle_epi8(FACTORIALS_EPU8, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (elements > 4)
                    {
                        v128 zeroOne = cmple_epu8(a, Sse2.set1_epi8(1));
                        v128 two = Sse2.cmpeq_epi8(a, Sse2.set1_epi8(2));
                        v128 three = Sse2.cmpeq_epi8(a, Sse2.set1_epi8(3));
                        v128 four   = Sse2.cmpeq_epi8(a, Sse2.set1_epi8(4));
                        v128 five    = Sse2.cmpeq_epi8(a, Sse2.set1_epi8(5));

                        v128 result = Sse2.sub_epi8(Sse2.xor_si128(setall_si128(), zeroOne), zeroOne);
                        result = blendv_si128(result, Sse2.set1_epi8(2), two);
                        result = blendv_si128(result, Sse2.set1_epi8(6), three);
                        result = blendv_si128(result, Sse2.set1_epi8(24), four);
                        result = blendv_si128(result, Sse2.set1_epi8(120), five);

                        return result;
                    }
                    else
                    {
                        ulong TABLE = maxmath.bitfield(1, 1, 2, 6, 24, 120, byte.MaxValue, byte.MaxValue);

                        if (!promiseNoOverflow)
                        {
                            a = Sse2.min_epu8(a, Sse2.set1_epi8(7));
                        }

                        switch (elements)
                        {
                            case 2:  return new byte2 (*((byte*)&TABLE + a.Byte0), *((byte*)&TABLE + a.Byte1));
                            case 3:  return new byte3 (*((byte*)&TABLE + a.Byte0), *((byte*)&TABLE + a.Byte1), *((byte*)&TABLE + a.Byte2));
                            default: return new byte4 (*((byte*)&TABLE + a.Byte0), *((byte*)&TABLE + a.Byte1), *((byte*)&TABLE + a.Byte2), *((byte*)&TABLE + a.Byte3));
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gamma_epu8(v256 a, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = Avx2.mm256_min_epu8(a, Avx.mm256_set1_epi8(7));
                    }

                    return Avx2.mm256_shuffle_epi8(new v256(FACTORIALS_EPU8, FACTORIALS_EPU8), a);
                }
                else throw new IllegalInstructionException();
            }

            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gamma_epu16(v128 a, bool promiseNoOverflow = false, byte elements = 8)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, 5))
                    {
                        a = Sse2.or_si128(a, Sse2.set1_epi16(unchecked((short)0xFF00)));

                        return Ssse3.shuffle_epi8(FACTORIALS_EPU8, a);
                    }
                }
                    
                if (Sse2.IsSse2Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = min_epu16(a, Sse2.set1_epi16(9));
                    }

                    if (Avx2.IsAvx2Supported)
                    {
                        uint* TABLE = stackalloc uint[10] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, ushort.MaxValue };

                        switch (elements)
                        {
                            case 2:
                            case 3:
                            case 4:
                            {
                                return cvtepi32_epi16(Avx2.i32gather_epi32(TABLE, cvtepu16_epi32(a), sizeof(uint)));
                            }
                            default:
                            {
                                v128 lo32 = cvt2x2epu16_epi32(a, out v128 hi32); 

                                lo32 = Avx2.i32gather_epi32(TABLE, lo32, sizeof(uint));
                                hi32 = Avx2.i32gather_epi32(TABLE, hi32, sizeof(uint));

                                return Sse4_1.packus_epi32(lo32, hi32);
                            }
                        }
                    }
                    else
                    {
                        a = Sse2.slli_epi16(a, 1);

                        ushort* TABLE = stackalloc ushort[10] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, ushort.MaxValue };

                        switch (elements)
                        {
                            case 2:  return new ushort2(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1));
                            case 3:  return new ushort3(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1), *(ushort*)((byte*)TABLE + a.UShort2));
                            case 4:  return new ushort4(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1), *(ushort*)((byte*)TABLE + a.UShort2), *(ushort*)((byte*)TABLE + a.UShort3));
                            default: return new ushort8(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1), *(ushort*)((byte*)TABLE + a.UShort2), *(ushort*)((byte*)TABLE + a.UShort3), *(ushort*)((byte*)TABLE + a.UShort4), *(ushort*)((byte*)TABLE + a.UShort5), *(ushort*)((byte*)TABLE + a.UShort6), *(ushort*)((byte*)TABLE + a.UShort7));
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gamma_epu16(v256 a, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, 5))
                    {
                        a = Avx2.mm256_or_si256(a, Avx.mm256_set1_epi16(unchecked((short)0xFF00)));

                        return Avx2.mm256_shuffle_epi8(new v256(FACTORIALS_EPU8, FACTORIALS_EPU8), a);
                    }
                    
                    if (!promiseNoOverflow)
                    {
                        a = Avx2.mm256_min_epu16(a, Avx.mm256_set1_epi16(9));
                    }
                    
                    uint* TABLE = stackalloc uint[10] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, ushort.MaxValue };
                    
                    v256 lo32 = mm256_cvt2x2epu16_epi32(a, out v256 hi32); 
                    
                    lo32 = Avx2.mm256_i32gather_epi32(TABLE, lo32, sizeof(uint));
                    hi32 = Avx2.mm256_i32gather_epi32(TABLE, hi32, sizeof(uint));
                    
                    return Avx2.mm256_packus_epi32(lo32, hi32);
                }
                else throw new IllegalInstructionException();
            }


            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gamma_epi16(v128 a, bool promiseNoOverflow = false, byte elements = 8)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, 5))
                    {
                        a = Sse2.or_si128(a, Sse2.set1_epi16(unchecked((short)0xFF00)));

                        return Ssse3.shuffle_epi8(FACTORIALS_EPU8, a);
                    }
                }
                    
                if (Sse2.IsSse2Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = min_epu16(a, Sse2.set1_epi16(8));
                    }

                    if (Avx2.IsAvx2Supported)
                    {
                        uint* TABLE = stackalloc uint[9] { 1, 1, 2, 6, 24, 120, 720, 5_040, (uint)short.MaxValue };

                        switch (elements)
                        {
                            case 2:
                            case 3:
                            case 4:
                            {
                                return cvtepi32_epi16(Avx2.i32gather_epi32(TABLE, cvtepu16_epi32(a), sizeof(uint)));
                            }
                            default:
                            {
                                v128 lo32 = cvt2x2epu16_epi32(a, out v128 hi32); 

                                lo32 = Avx2.i32gather_epi32(TABLE, lo32, sizeof(uint));
                                hi32 = Avx2.i32gather_epi32(TABLE, hi32, sizeof(uint));

                                return Sse4_1.packus_epi32(lo32, hi32);
                            }
                        }
                    }
                    else
                    {
                        a = Sse2.slli_epi16(a, 1);

                        ushort* TABLE = stackalloc ushort[9] { 1, 1, 2, 6, 24, 120, 720, 5_040, (ushort)short.MaxValue };

                        switch (elements)
                        {
                            case 2:  return new ushort2(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1));
                            case 3:  return new ushort3(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1), *(ushort*)((byte*)TABLE + a.UShort2));
                            case 4:  return new ushort4(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1), *(ushort*)((byte*)TABLE + a.UShort2), *(ushort*)((byte*)TABLE + a.UShort3));
                            default: return new ushort8(*(ushort*)((byte*)TABLE + a.UShort0), *(ushort*)((byte*)TABLE + a.UShort1), *(ushort*)((byte*)TABLE + a.UShort2), *(ushort*)((byte*)TABLE + a.UShort3), *(ushort*)((byte*)TABLE + a.UShort4), *(ushort*)((byte*)TABLE + a.UShort5), *(ushort*)((byte*)TABLE + a.UShort6), *(ushort*)((byte*)TABLE + a.UShort7));
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gamma_epi16(v256 a, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, 5))
                    {
                        a = Avx2.mm256_or_si256(a, Avx.mm256_set1_epi16(unchecked((short)0xFF00)));

                        return Avx2.mm256_shuffle_epi8(new v256(FACTORIALS_EPU8, FACTORIALS_EPU8), a);
                    }
                    
                    if (!promiseNoOverflow)
                    {
                        a = Avx2.mm256_min_epu16(a, Avx.mm256_set1_epi16(9));
                    }
                    
                    uint* TABLE = stackalloc uint[9] { 1, 1, 2, 6, 24, 120, 720, 5_040, (uint)short.MaxValue };
                    
                    v256 lo32 = mm256_cvt2x2epu16_epi32(a, out v256 hi32); 
                    
                    lo32 = Avx2.mm256_i32gather_epi32(TABLE, lo32, sizeof(uint));
                    hi32 = Avx2.mm256_i32gather_epi32(TABLE, hi32, sizeof(uint));
                    
                    return Avx2.mm256_packs_epi32(lo32, hi32);
                }
                else throw new IllegalInstructionException();
            }

            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gamma_epu32(v128 a, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, 5))
                    {
                        a = Sse2.or_si128(a, Sse2.set1_epi32(unchecked((int)0xFFFF_FF00u)));

                        return Ssse3.shuffle_epi8(FACTORIALS_EPU8, a);
                    }
                }

                if (Sse2.IsSse2Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = min_epu32(a, Sse2.set1_epi32(13));
                    }
                    
                    uint* TABLE = stackalloc uint[14] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, uint.MaxValue };
                    
                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx2.i32gather_epi32(TABLE, a, sizeof(uint));
                    }
                    else
                    {
                        a = Sse2.slli_epi32(a, 2);

                        switch (elements)
                        {
                            case 2:  return RegisterConversion.ToV128(new uint2(*(uint*)((byte*)TABLE + a.UInt0), *(uint*)((byte*)TABLE + a.UInt1)));
                            case 3:  return RegisterConversion.ToV128(new uint3(*(uint*)((byte*)TABLE + a.UInt0), *(uint*)((byte*)TABLE + a.UInt1), *(uint*)((byte*)TABLE + a.UInt2)));
                            default: return RegisterConversion.ToV128(new uint4(*(uint*)((byte*)TABLE + a.UInt0), *(uint*)((byte*)TABLE + a.UInt1), *(uint*)((byte*)TABLE + a.UInt2), *(uint*)((byte*)TABLE + a.UInt3)));
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gamma_epu32(v256 a, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, 5))
                    {
                        a = Avx2.mm256_or_si256(a, Avx.mm256_set1_epi32(unchecked((int)0xFFFF_FF00u)));

                        return Avx2.mm256_shuffle_epi8(new v256(FACTORIALS_EPU8, FACTORIALS_EPU8), a);
                    }
                    
                    if (!promiseNoOverflow)
                    {
                        a = Avx2.mm256_min_epu32(a, Avx.mm256_set1_epi32(13));
                    }
                    
                    uint* TABLE = stackalloc uint[14] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, uint.MaxValue };
                    
                    return Avx2.mm256_i32gather_epi32(TABLE, a, sizeof(uint));
                }
                else throw new IllegalInstructionException();
            }

            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gamma_epu64(v128 a, bool promiseNoOverflow = false)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, 5))
                    {
                        a = Sse2.or_si128(a, Sse2.set1_epi64x(unchecked((long)0xFFFF_FFFF_FFFF_FF00ul)));

                        return Ssse3.shuffle_epi8(FACTORIALS_EPU8, a);
                    }
                }
                
                if (Sse2.IsSse2Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = min_epu64(a, Sse2.set1_epi64x(21));
                    }
                    
                    ulong* TABLE = stackalloc ulong[22] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, 6_227_020_800ul, 87_178_291_200ul, 1_307_674_368_000ul, 20_922_789_888_000ul, 355_687_428_096_000ul, 6_402_373_705_728_000ul, 121_645_100_408_832_000ul, 2_432_902_008_176_640_000ul, ulong.MaxValue };
                    
                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx2.i64gather_epi64(TABLE, a, sizeof(ulong));
                    }
                    else
                    {
                        a = Sse2.slli_epi64(a, 3);

                        return new v128(*(ulong*)((byte*)TABLE + a.ULong0), *(ulong*)((byte*)TABLE + a.ULong1));
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gamma_epu64(v256 a, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, 5))
                    {
                        a = Avx2.mm256_or_si256(a, Avx.mm256_set1_epi64x(unchecked((long)0xFFFF_FFFF_FFFF_FF00ul)));

                        return Avx2.mm256_shuffle_epi8(new v256(FACTORIALS_EPU8, FACTORIALS_EPU8), a);
                    }

                    if (!promiseNoOverflow)
                    {
                        a = mm256_min_epu64(a, Avx.mm256_set1_epi64x(21));
                    }
                    else if (elements == 3)
                    {
                        a.SLong3 = 0;
                    }
                    
                    ulong* TABLE = stackalloc ulong[22] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, 6_227_020_800ul, 87_178_291_200ul, 1_307_674_368_000ul, 20_922_789_888_000ul, 355_687_428_096_000ul, 6_402_373_705_728_000ul, 121_645_100_408_832_000ul, 2_432_902_008_176_640_000ul, ulong.MaxValue };
                    
                    return Avx2.mm256_i64gather_epi64(TABLE, a, sizeof(ulong));
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gamma_epi64(v128 a, bool promiseNoOverflow = false)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, 5))
                    {
                        a = Sse2.or_si128(a, Sse2.set1_epi64x(unchecked((long)0xFFFF_FFFF_FFFF_FF00ul)));

                        return Ssse3.shuffle_epi8(FACTORIALS_EPU8, a);
                    }
                }
                
                if (Sse2.IsSse2Supported)
                {
                    if (!promiseNoOverflow)
                    {
                        a = min_epu64(a, Sse2.set1_epi64x(21));
                    }
                    
                    long* TABLE = stackalloc long[22] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, 6_227_020_800L, 87_178_291_200L, 1_307_674_368_000L, 20_922_789_888_000L, 355_687_428_096_000L, 6_402_373_705_728_000L, 121_645_100_408_832_000L, 2_432_902_008_176_640_000L, long.MaxValue };
                    
                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx2.i64gather_epi64(TABLE, a, sizeof(ulong));
                    }
                    else
                    {
                        a = Sse2.slli_epi64(a, 3);

                        return new v128(*(ulong*)((byte*)TABLE + a.ULong0), *(ulong*)((byte*)TABLE + a.ULong1));
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [SkipLocalsInit]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gamma_epi64(v256 a, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, 5))
                    {
                        a = Avx2.mm256_or_si256(a, Avx.mm256_set1_epi64x(unchecked((long)0xFFFF_FFFF_FFFF_FF00ul)));

                        return Avx2.mm256_shuffle_epi8(new v256(FACTORIALS_EPU8, FACTORIALS_EPU8), a);
                    }

                    if (!promiseNoOverflow)
                    {
                        a = mm256_min_epu64(a, Avx.mm256_set1_epi64x(21));
                    }
                    else if (elements == 3)
                    {
                        a.SLong3 = 0;
                    }
                    
                    long* TABLE = stackalloc long[22] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, 6_227_020_800L, 87_178_291_200L, 1_307_674_368_000L, 20_922_789_888_000L, 355_687_428_096_000L, 6_402_373_705_728_000L, 121_645_100_408_832_000L, 2_432_902_008_176_640_000L, long.MaxValue };
                    
                    return Avx2.mm256_i64gather_epi64(TABLE, a, sizeof(ulong));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="UInt128.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 34].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 factorial(UInt128 x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x <= 20))
            {
                return factorial(x.lo64, Promise.NoOverflow);
            }

            if (Xse.constexpr.IS_TRUE(x < 35))
            {
                noOverflow |= Promise.NoOverflow;
            }

            UInt128* TABLE = stackalloc UInt128[36]
            { 
                1, 
                1,
                2, 
                6,
                24, 
                120, 
                720, 
                5_040,
                40_320, 
                362_880,
                3_628_800, 
                39_916_800,
                479_001_600, 
                6_227_020_800ul,
                87_178_291_200ul, 
                1_307_674_368_000ul,
                20_922_789_888_000ul, 
                355_687_428_096_000ul,
                6_402_373_705_728_000ul, 
                121_645_100_408_832_000ul,
                2_432_902_008_176_640_000ul,
                /*51090942171709440000*/new UInt128(0xC507_7D36_B8C4_0000, 0x0000_0000_0000_0002),
                /*1124000727777607680000*/new UInt128(0xEEA4_C2B3_E0D8_0000, 0x0000_0000_0000_003C),
                /*25852016738884976640000*/new UInt128(0x70CD_7E29_3368_0000, 0x0000_0000_0000_0579),
                /*620448401733239439360000*/new UInt128(0x9343_D3DC_D1C0_0000, 0x0000_0000_0000_8362),
                /*15511210043330985984000000*/new UInt128(0x619F_B090_7BC0_0000, 0x0000_0000_000C_D4A0),
                /*403291461126605635584000000*/new UInt128(0xEA37_EEAC_9180_0000, 0x0000_0000_014D_9849),
                /*10888869450418352160768000000*/new UInt128(0xB3E6_2C33_5880_0000, 0x0000_0000_232F_0FCB),
                /*304888344611713860501504000000*/new UInt128(0xAD2C_D59D_AE00_0000, 0x0000_0003_D925_BA47),
                /*8841761993739701954543616000000*/new UInt128(0x9E14_32DC_B600_0000, 0x0000_006F_9946_1A1E),
                /*265252859812191058636308480000000*/new UInt128(0x865D_F5DD_5400_0000, 0x0000_0D13_F637_0F96),
                /*8222838654177922817725562880000000*/new UInt128(0x4560_C5CD_2C00_0000, 0x0001_956A_D0AA_E33A),
                /*263130836933693530167218012160000000*/new UInt128(0xAC18_B9A5_8000_0000, 0x0032_AD5A_155C_6748),
                /*8683317618811886495518194401280000000*/new UInt128(0x2F2F_EE55_8000_0000, 0x0688_589C_C0E9_505E),
                /*295232799039604140847618609643520000000*/new UInt128(0x445D_A75B_0000_0000, 0xDE1B_C4D1_9EFC_AC82),
                UInt128.MaxValue
            };
            
            ulong offset = noOverflow.Promises(Promise.NoOverflow)
                           ? (ulong)sizeof(UInt128) * x.lo64
                           : math.min((ulong)sizeof(UInt128) * x.lo64, (ulong)sizeof(UInt128) * 35ul);

            return *(UInt128*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="Int128.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 33].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 factorial(Int128 x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0 & x <= 33))
            {
                noOverflow |= Promise.NoOverflow;
            }

            if (Xse.constexpr.IS_TRUE(x <= 20))
            {
                if (Xse.constexpr.IS_TRUE(x >= 0))
                {
                    return factorial(x.lo64, Promise.NoOverflow);
                }
                else
                {
                    return factorial((long)x, noOverflow);
                }
            }

            Int128* TABLE = stackalloc Int128[35]
            { 
                1, 
                1,
                2, 
                6,
                24, 
                120, 
                720, 
                5_040,
                40_320, 
                362_880,
                3_628_800, 
                39_916_800,
                479_001_600, 
                6_227_020_800ul,
                87_178_291_200ul, 
                1_307_674_368_000ul,
                20_922_789_888_000ul, 
                355_687_428_096_000ul,
                6_402_373_705_728_000ul, 
                121_645_100_408_832_000ul,
                2_432_902_008_176_640_000ul,
                /*51090942171709440000*/new Int128(0xC507_7D36_B8C4_0000, 0x0000_0000_0000_0002),
                /*1124000727777607680000*/new Int128(0xEEA4_C2B3_E0D8_0000, 0x0000_0000_0000_003C),
                /*25852016738884976640000*/new Int128(0x70CD_7E29_3368_0000, 0x0000_0000_0000_0579),
                /*620448401733239439360000*/new Int128(0x9343_D3DC_D1C0_0000, 0x0000_0000_0000_8362),
                /*15511210043330985984000000*/new Int128(0x619F_B090_7BC0_0000, 0x0000_0000_000C_D4A0),
                /*403291461126605635584000000*/new Int128(0xEA37_EEAC_9180_0000, 0x0000_0000_014D_9849),
                /*10888869450418352160768000000*/new Int128(0xB3E6_2C33_5880_0000, 0x0000_0000_232F_0FCB),
                /*304888344611713860501504000000*/new Int128(0xAD2C_D59D_AE00_0000, 0x0000_0003_D925_BA47),
                /*8841761993739701954543616000000*/new Int128(0x9E14_32DC_B600_0000, 0x0000_006F_9946_1A1E),
                /*265252859812191058636308480000000*/new Int128(0x865D_F5DD_5400_0000, 0x0000_0D13_F637_0F96),
                /*8222838654177922817725562880000000*/new Int128(0x4560_C5CD_2C00_0000, 0x0001_956A_D0AA_E33A),
                /*263130836933693530167218012160000000*/new Int128(0xAC18_B9A5_8000_0000, 0x0032_AD5A_155C_6748),
                /*8683317618811886495518194401280000000*/new Int128(0x2F2F_EE55_8000_0000, 0x0688_589C_C0E9_505E),
                Int128.MaxValue
            };
            
            int offset = noOverflow.Promises(Promise.NoOverflow)
                         ? sizeof(Int128) * (int)x.lo64
                         : (int)math.min((uint)(sizeof(Int128) * (uint)x), (uint)sizeof(Int128) * 34u);

            return *(Int128*)((byte*)TABLE + offset);
        }

        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte factorial(byte x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x < 6))
            {
                noOverflow |= Promise.NoOverflow;
            }

            ulong TABLE = bitfield(1, 1, 2, 6, 24, 120, byte.MaxValue, byte.MaxValue);

            uint offset = noOverflow.Promises(Promise.NoOverflow)
                          ? sizeof(byte) * (uint)x
                          : math.min(sizeof(byte) * (uint)x, sizeof(byte) * 7);

            return *((byte*)&TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 factorial(byte2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new byte2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 factorial(byte3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new byte3(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 factorial(byte4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new byte4(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow), factorial(x.w, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 factorial(byte8 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new byte8(factorial(x.x0, noOverflow), factorial(x.x1, noOverflow), factorial(x.x2, noOverflow), factorial(x.x3, noOverflow), factorial(x.x4, noOverflow), factorial(x.x5, noOverflow), factorial(x.x6, noOverflow), factorial(x.x7, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 factorial(byte16 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 16);
            }
            else
            {
                return new byte16(factorial(x.x0, noOverflow), factorial(x.x1, noOverflow), factorial(x.x2, noOverflow), factorial(x.x3, noOverflow), factorial(x.x4, noOverflow), factorial(x.x5, noOverflow), factorial(x.x6, noOverflow), factorial(x.x7, noOverflow), factorial(x.x8, noOverflow), factorial(x.x9, noOverflow), factorial(x.x10, noOverflow), factorial(x.x11, noOverflow), factorial(x.x12, noOverflow), factorial(x.x13, noOverflow), factorial(x.x14, noOverflow), factorial(x.x15, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="byte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 factorial(byte32 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte32(factorial(x.v16_0, noOverflow), factorial(x.v16_16, noOverflow));
            }
        }

        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte factorial(sbyte x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0 & x <= 5))
            {
                noOverflow |= Promise.NoOverflow;
            }


            ulong TABLE = bitfield(1, 1, 2, 6, 24, 120, sbyte.MaxValue, sbyte.MaxValue);
            
            int offset = noOverflow.Promises(Promise.NoOverflow)
                         ? sizeof(byte) * (int)x
                         : (int)math.min((uint)(sizeof(byte) * (byte)x), (uint)sizeof(byte) * 7u);

            return *((sbyte*)&TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 factorial(sbyte2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new sbyte2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 factorial(sbyte3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new sbyte3(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 factorial(sbyte4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new sbyte4(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow), factorial(x.w, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 factorial(sbyte8 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new sbyte8(factorial(x.x0, noOverflow), factorial(x.x1, noOverflow), factorial(x.x2, noOverflow), factorial(x.x3, noOverflow), factorial(x.x4, noOverflow), factorial(x.x5, noOverflow), factorial(x.x6, noOverflow), factorial(x.x7, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 factorial(sbyte16 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow), 16);
            }
            else
            {
                return new sbyte16(factorial(x.x0, noOverflow), factorial(x.x1, noOverflow), factorial(x.x2, noOverflow), factorial(x.x3, noOverflow), factorial(x.x4, noOverflow), factorial(x.x5, noOverflow), factorial(x.x6, noOverflow), factorial(x.x7, noOverflow), factorial(x.x8, noOverflow), factorial(x.x9, noOverflow), factorial(x.x10, noOverflow), factorial(x.x11, noOverflow), factorial(x.x12, noOverflow), factorial(x.x13, noOverflow), factorial(x.x14, noOverflow), factorial(x.x15, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="sbyte.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 5].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 factorial(sbyte32 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu8(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte32(factorial(x.v16_0, noOverflow), factorial(x.v16_16, noOverflow));
            }
        }

        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ushort.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 8].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort factorial(ushort x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x <= 5))
            {
                return factorial((byte)x, Promise.NoOverflow);
            }

            if (Xse.constexpr.IS_TRUE(x < 9))
            {
                noOverflow |= Promise.NoOverflow;
            }

            ushort* TABLE = stackalloc ushort[10] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, ushort.MaxValue };
            
            uint offset = noOverflow.Promises(Promise.NoOverflow)
                          ? sizeof(ushort) * (uint)x
                          : math.min(sizeof(ushort) * (uint)x, sizeof(ushort) * 9);

            return *(ushort*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ushort.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 8].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 factorial(ushort2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu16(x, noOverflow.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new ushort2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ushort.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 8].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 factorial(ushort3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu16(x, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new ushort3(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ushort.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 8].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 factorial(ushort4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu16(x, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new ushort4(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow), factorial(x.w, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ushort.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 8].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 factorial(ushort8 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu16(x, noOverflow.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new ushort8(factorial(x.x0, noOverflow), factorial(x.x1, noOverflow), factorial(x.x2, noOverflow), factorial(x.x3, noOverflow), factorial(x.x4, noOverflow), factorial(x.x5, noOverflow), factorial(x.x6, noOverflow), factorial(x.x7, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ushort.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 8].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 factorial(ushort16 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu16(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort16(factorial(x.v8_0, noOverflow), factorial(x.v8_8, noOverflow));
            }
        }

        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="short.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 7].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short factorial(short x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0 & x <= 7))
            {
                noOverflow |= Promise.NoOverflow;
            }

            if (Xse.constexpr.IS_TRUE(x <= 5))
            {
                return factorial((byte)x, noOverflow);
            }
            
            short* TABLE = stackalloc short[9] { 1, 1, 2, 6, 24, 120, 720, 5_040, short.MaxValue };
            
            int offset = noOverflow.Promises(Promise.NoOverflow)
                         ? sizeof(short) * (int)x
                         : (int)math.min((uint)(sizeof(short) * (ushort)x), (uint)sizeof(short) * 8u);

            return *(short*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="short.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 7].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 factorial(short2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epi16(x, noOverflow.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new short2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="short.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 7].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 factorial(short3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epi16(x, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new short3(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="short.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 7].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 factorial(short4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epi16(x, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new short4(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow), factorial(x.w, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="short.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 7].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 factorial(short8 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epi16(x, noOverflow.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new short8(factorial(x.x0, noOverflow), factorial(x.x1, noOverflow), factorial(x.x2, noOverflow), factorial(x.x3, noOverflow), factorial(x.x4, noOverflow), factorial(x.x5, noOverflow), factorial(x.x6, noOverflow), factorial(x.x7, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="short.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 7].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 factorial(short16 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epi16(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(factorial(x.v8_0, noOverflow), factorial(x.v8_8, noOverflow));
            }
        }

        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="uint.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint factorial(uint x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x <= 7))
            {
                return factorial((ushort)x, Promise.NoOverflow);
            }

            if (Xse.constexpr.IS_TRUE(x < 13))
            {
                noOverflow |= Promise.NoOverflow;
            }
            
            uint* TABLE = stackalloc uint[14] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, uint.MaxValue };
            
            uint offset = noOverflow.Promises(Promise.NoOverflow)
                          ? sizeof(uint) * (uint)x
                          : math.min(sizeof(uint) * (uint)x, sizeof(uint) * 13);

            return *(uint*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="uint.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 factorial(uint2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.gamma_epu32(RegisterConversion.ToV128(x), noOverflow.Promises(Promise.NoOverflow), 2));
            }
            else
            {
                return new uint2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="uint.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 factorial(uint3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.gamma_epu32(RegisterConversion.ToV128(x), noOverflow.Promises(Promise.NoOverflow), 3));
            }
            else
            {
                return new uint3(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="uint.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 factorial(uint4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.gamma_epu32(RegisterConversion.ToV128(x), noOverflow.Promises(Promise.NoOverflow), 4));
            }
            else
            {
                return new uint4(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow), factorial(x.w, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="uint.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 factorial(uint8 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu32(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint8(factorial(x.v4_0, noOverflow), factorial(x.v4_4, noOverflow));
            }
        }
        
        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="int.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int factorial(int x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0 & x <= 12))
            {
                noOverflow |= Promise.NoOverflow;
            }

            if (Xse.constexpr.IS_TRUE(x <= 8))
            {
                if (Xse.constexpr.IS_TRUE(x >= 0))
                {
                    return factorial((ushort)x, Promise.NoOverflow);
                }
                if (Xse.constexpr.IS_TRUE(x <= 7))
                {
                    return factorial((short)x, noOverflow);
                }
            }

            int* TABLE = stackalloc int[14] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, int.MaxValue };
            
            int offset = noOverflow.Promises(Promise.NoOverflow)
                         ? sizeof(int) * (int)x
                         : (int)math.min((uint)(sizeof(int) * (uint)x), (uint)sizeof(int) * 13u);

            return *(int*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="int.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 factorial(int2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.gamma_epu32(RegisterConversion.ToV128(x), noOverflow.Promises(Promise.NoOverflow), 2));
            }
            else
            {
                return new int2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="int.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 factorial(int3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int3>(Xse.gamma_epu32(RegisterConversion.ToV128(x), noOverflow.Promises(Promise.NoOverflow), 3));
            }
            else
            {
                return new int3(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="int.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 factorial(int4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int4>(Xse.gamma_epu32(RegisterConversion.ToV128(x), noOverflow.Promises(Promise.NoOverflow), 4));
            }
            else
            {
                return new int4(factorial(x.x, noOverflow), factorial(x.y, noOverflow), factorial(x.z, noOverflow), factorial(x.w, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="int.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 12].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 factorial(int8 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu32(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(factorial(x.v4_0, noOverflow), factorial(x.v4_4, noOverflow));
            }
        }
        
        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ulong.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong factorial(ulong x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x <= 12))
            {
                return factorial((uint)x, Promise.NoOverflow);
            }

            if (Xse.constexpr.IS_TRUE(x < 21))
            {
                noOverflow |= Promise.NoOverflow;
            }
            
            ulong* TABLE = stackalloc ulong[22] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, 6_227_020_800ul, 87_178_291_200ul, 1_307_674_368_000ul, 20_922_789_888_000ul, 355_687_428_096_000ul, 6_402_373_705_728_000ul, 121_645_100_408_832_000ul, 2_432_902_008_176_640_000ul, ulong.MaxValue };
            
            ulong offset = noOverflow.Promises(Promise.NoOverflow)
                           ? sizeof(ulong) * (ulong)x
                           : math.min(sizeof(ulong) * (ulong)x, sizeof(ulong) * 21);

            return *(ulong*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ulong.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 factorial(ulong2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epu64(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ulong.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 factorial(ulong3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu64(x, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new ulong3(factorial(x.xy, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="ulong.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 factorial(ulong4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epu64(x, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new ulong4(factorial(x.xy, noOverflow), factorial(x.zw, noOverflow));
            }
        }

        
        /// <summary>   Returns the factorial of <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="long.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long factorial(long x, Promise noOverflow = Promise.Nothing)
        {
            if (Xse.constexpr.IS_TRUE(x >= 0 & x <= 20))
            {
                noOverflow |= Promise.NoOverflow;
            }

            if (Xse.constexpr.IS_TRUE(x <= 12))
            {
                if (Xse.constexpr.IS_TRUE(x >= 0))
                {
                    return factorial((uint)x, Promise.NoOverflow);
                }
                else
                {
                    return factorial((int)x, noOverflow);
                }
            }

            long* TABLE = stackalloc long[22] { 1, 1, 2, 6, 24, 120, 720, 5_040, 40_320, 362_880, 3_628_800, 39_916_800, 479_001_600, 6_227_020_800L, 87_178_291_200L, 1_307_674_368_000L, 20_922_789_888_000L, 355_687_428_096_000L, 6_402_373_705_728_000L, 121_645_100_408_832_000L, 2_432_902_008_176_640_000L, long.MaxValue };
            
            int offset = noOverflow.Promises(Promise.NoOverflow)
                         ? sizeof(long) * (int)x
                         : (int)math.min((uint)(sizeof(long) * (uint)x), (uint)sizeof(long) * 21u);

            return *(long*)((byte*)TABLE + offset);
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="long.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 factorial(long2 x, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.gamma_epi64(x, noOverflow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(factorial(x.x, noOverflow), factorial(x.y, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="long.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 factorial(long3 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epi64(x, noOverflow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new long3(factorial(x.xy, noOverflow), factorial(x.z, noOverflow));
            }
        }
        
        /// <summary>   Returns the componentwise factorial of each <paramref name="x"/>, where any <paramref name="x"/>! causing an overflow results in <see cref="long.MaxValue"/>     </summary>
        /// <remarks>   A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set may cause a memory access violation if <paramref name="x"/> is outside the interval [0, 20].     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 factorial(long4 x, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gamma_epi64(x, noOverflow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new long4(factorial(x.xy, noOverflow), factorial(x.zw, noOverflow));
            }
        }
    }
}
