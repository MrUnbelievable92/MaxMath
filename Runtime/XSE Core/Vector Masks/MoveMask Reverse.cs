using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 broadcastmask_epi8(int m, MaskType result = MaskType.AllOnes, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 BIT_ISOLATION_MASK = Sse2.set1_epi64x(unchecked((long)0x80_40_20_10_08_04_02_01));

                    v128 broadcast = Sse2.cvtsi32_si128(m);
                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK = (elements <= 8) ? Sse2.setzero_si128() : new v128(0x00_00_00_00_00_00_00_00, 0x01_01_01_01_01_01_01_01);
                        
                        broadcast = Ssse3.shuffle_epi8(broadcast, SHUFFLE_MASK);
                    }
                    else
                    {
                        broadcast = Sse2.unpacklo_epi8(broadcast, broadcast);

                        if (elements > 2)
                        {
                            broadcast = Sse2.unpacklo_epi8(broadcast, broadcast);

                            if (elements > 4)
                            {
                                broadcast = Sse2.unpacklo_epi8(broadcast, broadcast);
                            }
                        }
                    }

                    v128 ret = Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(broadcast, BIT_ISOLATION_MASK));

                    if  (result == MaskType.One)
                    {
                        ret = negmask_epi8(ret);
                    }

                    return ret;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_broadcastmask_epi8(int m, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK = Avx.mm256_set_epi64x(0x03_03_03_03_03_03_03_03, 0x02_02_02_02_02_02_02_02, 0x01_01_01_01_01_01_01_01, 0x00_00_00_00_00_00_00_00); 
                    v256 BIT_ISOLATION_MASK = Avx.mm256_set1_epi64x(unchecked((long)0x80_40_20_10_08_04_02_01)); 
                    
                    v256 broadcast = Avx2.mm256_shuffle_epi8(Avx.mm256_set1_epi32(m), SHUFFLE_MASK);
                    v256 ret = Avx2.mm256_cmpeq_epi8(BIT_ISOLATION_MASK, Avx2.mm256_and_si256(broadcast, BIT_ISOLATION_MASK)); 
                    
                    return result == MaskType.One ? Avx2.mm256_abs_epi8(ret) : ret; 
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 broadcastmask_epi16(int m, MaskType result = MaskType.AllOnes, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 BIT_ISOLATION_MASK = new v128(0x0008_0004_0002_0001, 0x0080_0040_0020_0010);

                    v128 broadcast;
                    if (Ssse3.IsSsse3Supported)
                    {
                        broadcast = Ssse3.shuffle_epi8(Sse2.cvtsi32_si128(m), Sse2.setzero_si128());
                    }
                    else
                    {
                        broadcast = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128(m), Sse.SHUFFLE(0, 0, 0, 0));

                        if (elements > 4)
                        {
                            broadcast = Sse2.unpacklo_epi64(broadcast, broadcast);
                        }
                    }

                    v128 ret = Sse2.cmpeq_epi16(BIT_ISOLATION_MASK, Sse2.and_si128(broadcast, BIT_ISOLATION_MASK));
                        
                    if  (result == MaskType.One)
                    {
                        ret = Sse2.srli_epi16(ret, 15);
                    }

                    return ret;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_broadcastmask_epi16(int m, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 broadcast = Avx.mm256_set1_epi32(m);

                    v256 shiftBoolsToSignBit_Lo = Avx2.mm256_sllv_epi32(broadcast, new v256(31, 30, 29, 28,     23, 22, 21, 20));
                    v256 shiftBoolsToSignBit_Hi = Avx2.mm256_sllv_epi32(broadcast, new v256(27, 26, 25, 24,     19, 18, 17, 16));
                                      
                    if (result == MaskType.One)
                    {
                        shiftBoolsToSignBit_Lo = Avx2.mm256_srli_epi32(shiftBoolsToSignBit_Lo, 31);
                        shiftBoolsToSignBit_Hi = Avx2.mm256_srli_epi32(shiftBoolsToSignBit_Hi, 31);
                    }
                    {
                        shiftBoolsToSignBit_Lo = Avx2.mm256_srai_epi32(shiftBoolsToSignBit_Lo, 31);
                        shiftBoolsToSignBit_Hi = Avx2.mm256_srai_epi32(shiftBoolsToSignBit_Hi, 31);
                    }

                    return Avx2.mm256_packs_epi32(shiftBoolsToSignBit_Lo, shiftBoolsToSignBit_Hi);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 broadcastmask_epi32(int m, MaskType result = MaskType.AllOnes)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 shiftBoolsToSignBit = Avx2.sllv_epi32(Sse2.set1_epi32(m), new v128(31, 30, 29, 28));
                        
                        switch (result)
                        {
                            case MaskType.SignBit: return shiftBoolsToSignBit;
                            case MaskType.AllOnes: return Sse2.srai_epi32(shiftBoolsToSignBit, 31);
                            case MaskType.One:     return Sse2.srli_epi32(shiftBoolsToSignBit, 31);

                            default : throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        v128 BIT_ISOLATION_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3);

                        v128 isolated = Sse2.and_si128(Sse2.set1_epi32(m), BIT_ISOLATION_MASK);
                        v128 ret = Sse2.cmpeq_epi32(BIT_ISOLATION_MASK, isolated);
                        
                        if  (result == MaskType.One)
                        {
                            ret = Sse2.srli_epi32(ret, 31);
                        }

                        return ret;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_broadcastmask_epi32(int m, MaskType result = MaskType.AllOnes)
            {
                if (Avx.IsAvxSupported)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 shiftBoolsToSignBit = Avx2.mm256_sllv_epi32(Avx.mm256_set1_epi32(m), new v256(31, 30, 29, 28, 27, 26, 25, 24));

                        switch (result)
                        {
                            case MaskType.SignBit: return shiftBoolsToSignBit;
                            case MaskType.AllOnes: return Avx2.mm256_srai_epi32(shiftBoolsToSignBit, 31);
                            case MaskType.One:     return Avx2.mm256_srli_epi32(shiftBoolsToSignBit, 31);

                            default : throw new ArgumentOutOfRangeException();
                        }
                    }
                    else
                    {
                        v128 BIT_ISOLATION_MASK_LO = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3);
                        v128 BIT_ISOLATION_MASK_HI = new v128(1 << 4, 1 << 5, 1 << 6, 1 << 7);

                        v128 isolated_lo = Sse2.and_si128(Sse2.set1_epi32(m), BIT_ISOLATION_MASK_LO);
                        v128 isolated_hi = Sse2.and_si128(Sse2.set1_epi32(m), BIT_ISOLATION_MASK_HI);
                        isolated_lo = Sse2.cmpeq_epi32(BIT_ISOLATION_MASK_LO, isolated_lo);
                        isolated_hi = Sse2.cmpeq_epi32(BIT_ISOLATION_MASK_HI, isolated_hi);

                        v256 ret = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(isolated_lo), isolated_hi, 1);
                        
                        switch (result)
                        {
                            case MaskType.SignBit: return ret;
                            case MaskType.AllOnes: return ret;
                            case MaskType.One:     return Avx.mm256_and_ps(Avx.mm256_set1_epi32(1), ret);

                            default : throw new ArgumentOutOfRangeException();
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 broadcastmask_epi64(int m, MaskType result = MaskType.AllOnes)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported && result == MaskType.AllOnes)
                    {
                        return Sse4_1.cvtepi32_epi64(broadcastmask_epi32(m, result));
                    }

                    v128 shiftBoolsToSignBit;

                    if (Avx2.IsAvx2Supported)
                    {
                        v128 splat = Sse2.shuffle_epi32(Sse2.cvtsi32_si128(m), Sse.SHUFFLE(3, 0, 3, 0));
                        shiftBoolsToSignBit = Avx2.sllv_epi64(splat, new long2(63, 62));
                    }
                    else
                    {
                        shiftBoolsToSignBit = Sse2.unpacklo_epi64(Sse2.cvtsi64x_si128((long)(uint)m << 63), 
                                                                  Sse2.cvtsi64x_si128((long)(uint)m << 62));
                    }

                    switch (result)
                    {
                        case MaskType.SignBit:  return shiftBoolsToSignBit;
                        case MaskType.AllOnes:  return srai_epi64(shiftBoolsToSignBit, 63);
                        case MaskType.One:      return Sse2.srli_epi64(shiftBoolsToSignBit, 63);

                        default: throw new ArgumentOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_broadcastmask_epi64(int m, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 splat = Avx2.mm256_broadcastq_epi64(Sse2.cvtsi32_si128(m));
                    v256 shiftBoolsToSignBit = Avx2.mm256_sllv_epi64(splat, new v256(63, 62, 61, 60));
                    
                    switch (result) 
                    {
                        case MaskType.SignBit:  return shiftBoolsToSignBit;
                        case MaskType.AllOnes:  return mm256_srai_epi64(shiftBoolsToSignBit, 63); 
                        case MaskType.One:      return Avx2.mm256_srli_epi64(shiftBoolsToSignBit, 63);

                        default: throw new ArgumentOutOfRangeException();
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}