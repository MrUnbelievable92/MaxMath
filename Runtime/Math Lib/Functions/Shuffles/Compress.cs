using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using DevTools;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte2 val, mask8x2 mask)
        {
            for (int i = 0; i < 2; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte3 val, mask8x3 mask)
        {
            for (int i = 0; i < 3; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }
            
            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte4 val, mask8x4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                uint selectMask32 = bits_extractparallel(0xFFFF_FFFFu, ((v128)mask).UInt0);
                uint result32 = bits_extractparallel(((v128)val).UInt0, ((v128)mask).UInt0);
                *(byte4*)(output + index) = select(*(byte4*)(output + index), Xse.cvtsi32_si128(result32), (mask8x4)Xse.cvtsi32_si128(selectMask32));

                return index + (int)count(mask);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (mask[i])
                    {
                        *(output + index++) = val[i];
                    }
                }

                return index;
            }
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte8 val, mask8x8 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                ulong selectMask64 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFFul, ((v128)mask).ULong0);
                ulong result64 = bits_extractparallel(((v128)val).ULong0, ((v128)mask).ULong0);
                *(byte8*)(output + index) = select(*(byte8*)(output + index), Xse.cvtsi64x_si128(result64), (mask8x8)Xse.cvtsi64x_si128(selectMask64));

                return index + (int)count(mask);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (mask[i])
                    {
                        *(output + index++) = val[i];
                    }
                }

                return index;
            }
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte16 val, mask8x16 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                ulong castMask = Xse.cvtepi8_epi4(mask);
                ulong shuf8 = bits_extractparallel(0xFEDC_BA98_7654_3210, castMask);
                ulong select8 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, castMask);
                v128 shuf32 = Xse.cvtepu4_epi8(shuf8);
                v128 select32 = Xse.cvtepu4_epi8(select8);
                select32 = Xse.slli_epi16(select32, 4);
                *(byte16*)(output + index) = Xse.blendv_epi8(*(byte16*)(output + index), Xse.shuffle_epi8(val, shuf32), (mask8x16)select32);

                return index + (int)count(mask);
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    if (mask[i])
                    {
                        *(output + index++) = val[i];
                    }
                }

                return index;
            }
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte32 val, mask8x32 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
			    v256 cvt = Xse.mm256_cvtepi8_epi4(mask);
			    ulong shuf8_lo = bits_extractparallel(0xFEDC_BA98_7654_3210, cvt.ULong0);
			    ulong shuf8_hi = bits_extractparallel(0xFEDC_BA98_7654_3210, cvt.ULong2);
			    ulong mask8_lo = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, cvt.ULong0);
			    ulong mask8_hi = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, cvt.ULong2);
			    
			    int loVals = countbits(cvt.ULong0);
			    mask8_lo |= cvt.ULong0 == 0xFFFF_FFFF_FFFF_FFFF ? 0 : mask8_hi << loVals;
			    shuf8_lo |= cvt.ULong0 == 0xFFFF_FFFF_FFFF_FFFF ? 0 : shuf8_hi << loVals;
			    mask8_hi  = cvt.ULong0 == 0                     ? 0 : mask8_hi >> (64 - loVals);
			    shuf8_hi  = cvt.ULong0 == 0                     ? 0 : shuf8_hi >> (64 - loVals);

			    v256 shuf32 = Xse.mm256_cvtepu4_epi8(shuf8_lo, shuf8_hi);
			    v256 mask32 = Xse.mm256_cvtepu4_epi8(mask8_lo, mask8_hi);
			    mask32 = Avx2.mm256_slli_epi16(mask32, 4);
                
                byte* wantsHiHalf = stackalloc byte[64];
                *(v256*)(wantsHiHalf + 0) = Avx.mm256_setzero_si256();
                *(v256*)(wantsHiHalf + 32) = Avx.mm256_setzero_si256();
                *(v256*)(wantsHiHalf + loVals / 4) = Xse.mm256_setall_si256();

                // inlined optimized mm256_permutevar_epi8
                v256 alolo = Avx2.mm256_permute4x64_epi64(val, Sse.SHUFFLE(1, 0, 1, 0));
                v256 ahihi = Avx2.mm256_permute4x64_epi64(val, Sse.SHUFFLE(3, 2, 3, 2));
                v256 shufflelo = Avx2.mm256_shuffle_epi8(alolo, shuf32);
                v256 shufflehi = Avx2.mm256_shuffle_epi8(ahihi, shuf32);
                val = Xse.mm256_blendv_si256(shufflelo, shufflehi, *(v256*)wantsHiHalf);

                *(byte32*)(output + index) = Avx2.mm256_blendv_epi8(*(byte32*)(output + index), val, mask32);

			    return index + (int)count(mask);
            }
            else
            {
                index = compress(output, index, val.v16_0,  mask.v16_0);
                return  compress(output, index, val.v16_16, mask.v16_16);
            }
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte8 val, mask32x8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte8 val, mask16x8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte16 val, mask16x16 mask)
        {
            return compress(output, index, val, (mask8x16)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte2 val, bool2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte3 val, bool3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte4 val, bool4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte8 val, bool8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte16 val, bool16 mask)
        {
            return compress(output, index, val, (mask8x16)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(byte* output, int index, byte32 val, bool32 mask)
        {
            return compress(output, index, val, (mask8x32)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte2 val, mask8x2 mask)
        {
            return compress((byte*)output, index, (byte2)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte3 val, mask8x3 mask)
        {
            return compress((byte*)output, index, (byte3)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte4 val, mask8x4 mask)
        {
            return compress((byte*)output, index, (byte4)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte8 val, mask8x8 mask)
        {
            return compress((byte*)output, index, (byte8)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte16 val, mask8x16 mask)
        {
            return compress((byte*)output, index, (byte16)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte32 val, mask8x32 mask)
        {
            return compress((byte*)output, index, (byte32)val, mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte8 val, mask32x8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte8 val, mask16x8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte16 val, mask16x16 mask)
        {
            return compress(output, index, val, (mask8x16)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte2 val, bool2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte3 val, bool3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte4 val, bool4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte8 val, bool8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte16 val, bool16 mask)
        {
            return compress(output, index, val, (mask8x16)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(sbyte* output, int index, sbyte32 val, bool32 mask)
        {
            return compress(output, index, val, (mask8x32)mask);
        }


        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort2 val, mask16x2 mask)
        {
            for (int i = 0; i < 2; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort3 val, mask16x3 mask)
        {
            for (int i = 0; i < 3; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort4 val, mask16x4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                ulong selectMask64 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, ((v128)mask).ULong0);
                ulong result64 = bits_extractparallel(((v128)val).ULong0, ((v128)mask).ULong0);
                *(ushort4*)(output + index) = select(*(ushort4*)(output + index), Xse.cvtsi64x_si128(result64), (mask16x4)Xse.cvtsi64x_si128(selectMask64));

                return index + (int)count(mask);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (mask[i])
                    {
                        *(output + index++) = val[i];
                    }
                }

                return index;
            }
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort8 val, mask16x8 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                mask8x8 castMask = mask;
                ulong shuf8 = bits_extractparallel(0x0706_0504_0302_0100, ((v128)castMask).ULong0);
                ulong select8 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, ((v128)castMask).ULong0);
                v128 shuf32 = Xse.cvtepu8_epi16(Xse.cvtsi64x_si128(shuf8)); 
                v128 select32 = Xse.cvtepi8_epi16(Xse.cvtsi64x_si128(select8)); 
                *(ushort8*)(output + index) = select(*(ushort8*)(output + index), Xse.shuffle_epi16(val, shuf32), (mask16x8)select32);

                return index + (int)count(mask);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (mask[i])
                    {
                        *(output + index++) = val[i];
                    }
                }

                return index;
            }
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort16 val, mask16x16 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong castMask = Xse.cvtepi8_epi4(Xse.mm256_cvtepi16_epi8(mask));
                ulong shuf8 = bits_extractparallel(0xFEDC_BA98_7654_3210, castMask);
                ulong select8 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, castMask);
                v256 shuf32 = Avx2.mm256_cvtepu8_epi16(Xse.cvtepu4_epi8(shuf8));
                v256 select32 = Avx2.mm256_cvtepu8_epi16(Xse.cvtepu4_epi8(select8));
                select32 = Avx2.mm256_sub_epi16(Xse.mm256_set1_epi16(0xE), select32);
                *(ushort16*)(output + index) = Avx2.mm256_blendv_epi8(*(ushort16*)(output + index), Xse.mm256_permutevar_epi16(val, shuf32), select32);

                return index + (int)count(mask);
            }
            else
            {
                index = compress(output, index, val.v8_0, mask.v8_0);
                return  compress(output, index, val.v8_8, mask.v8_8);
            }
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort8 val, mask32x8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort8 val, mask8x8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort16 val, mask8x16 mask)
        {
            return compress(output, index, val, (mask16x16)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort2 val, bool2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort3 val, bool3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort4 val, bool4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort8 val, bool8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ushort* output, int index, ushort16 val, bool16 mask)
        {
            return compress(output, index, val, (mask16x16)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short2 val, mask16x2 mask)
        {
            return compress((ushort*)output, index, (ushort2)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short3 val, mask16x3 mask)
        {
            return compress((ushort*)output, index, (ushort3)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short4 val, mask16x4 mask)
        {
            return compress((ushort*)output, index, (ushort4)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short8 val, mask16x8 mask)
        {
            return compress((ushort*)output, index, (ushort8)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short16 val, mask16x16 mask)
        {
            return compress((ushort*)output, index, (ushort16)val, mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short8 val, mask32x8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short8 val, mask8x8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short16 val, mask8x16 mask)
        {
            return compress(output, index, val, (mask16x16)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short2 val, bool2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short3 val, bool3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short4 val, bool4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short8 val, bool8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(short* output, int index, short16 val, bool16 mask)
        {
            return compress(output, index, val, (mask16x16)mask);
        }


        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint2 val, mask32x2 mask)
        {
            for (int i = 0; i < 2; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint3 val, mask32x3 mask)
        {
            for (int i = 0; i < 3; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint4 val, mask32x4 mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                UInt128 selectMask128 = bits_extractparallel(new UInt128(0xFFFF_FFFF_FFFF_FFFFul, 0xFFFF_FFFF_FFFF_FFFFul), new UInt128(((v128)mask).ULong0, ((v128)mask).ULong1));
                UInt128 result128 = bits_extractparallel(new UInt128(((v128)val).ULong0, ((v128)val).ULong1), new UInt128(((v128)mask).ULong0, ((v128)mask).ULong1));
                *(uint4*)(output + index) = select(*(uint4*)(output + index), new v128(result128.lo64, result128.hi64), (mask32x4)new v128(selectMask128.lo64, selectMask128.hi64));
            
                return index + (int)count(mask);
            }
            else
            {
                return Unity.Mathematics.math.compress(output, index, val, mask);
            }
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint8 val, mask32x8 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                mask8x8 castMask = mask;
                ulong shuf8 = bits_extractparallel(0x0706_0504_0302_0100, ((v128)castMask).ULong0);
                ulong select8 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, ((v128)castMask).ULong0);
                v256 shuf32 = Avx2.mm256_cvtepi8_epi32(Xse.cvtsi64x_si128(shuf8)); 
                v256 select32 = Avx2.mm256_cvtepi8_epi32(Xse.cvtsi64x_si128(select8)); 
                Avx2.mm256_maskstore_epi32(output + index, select32, Avx2.mm256_permutevar8x32_epi32(val, shuf32));

                return index + (int)count(mask);
            }
            else
            {
                index = compress(output, index, val.v4_0, mask.v4_0);
                return  compress(output, index, val.v4_4, mask.v4_4);
            }
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint8 val, mask16x8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint8 val, mask8x8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint2 val, bool2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint3 val, bool3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint4 val, bool4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(uint* output, int index, uint8 val, bool8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int2 val, mask32x2 mask)
        {
            return compress((uint*)output, index, (uint2)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int3 val, mask32x3 mask)
        {
            return compress((uint*)output, index, (uint3)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int4 val, mask32x4 mask)
        {
            return compress((uint*)output, index, (uint4)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int8 val, mask32x8 mask)
        {
            return compress((uint*)output, index, (uint8)val, mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int8 val, mask16x8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int8 val, mask8x8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int2 val, bool2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int3 val, bool3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int4 val, bool4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(int* output, int index, int8 val, bool8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }


        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong2 val, mask64x2 mask)
        {
            for (int i = 0; i < 2; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong3 val, mask64x3 mask)
        {
            for (int i = 0; i < 3; i++)
            {
                if (mask[i])
                {
                    *(output + index++) = val[i];
                }
            }

            return index;
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong4 val, mask64x4 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                mask16x4 castMask = mask;
                ulong shuf8 = bits_extractparallel(0x0706_0504_0302_0100, ((v128)castMask).ULong0);
                ulong select8 = bits_extractparallel(0xFFFF_FFFF_FFFF_FFFF, ((v128)castMask).ULong0);
                v256 select32 = Avx2.mm256_cvtepi16_epi64(Xse.cvtsi64x_si128(select8)); 
                v256 shuf32 = Avx2.mm256_cvtepu8_epi32(Xse.cvtsi64x_si128(shuf8)); 
                Avx2.mm256_maskstore_epi64(output + index, select32, Avx2.mm256_permutevar8x32_epi32(val, shuf32));

                return index + (int)count(mask);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (mask[i])
                    {
                        *(output + index++) = val[i];
                    }
                }

                return index;
            }
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong2 val, bool2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong3 val, bool3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(ulong* output, int index, ulong4 val, bool4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }


         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long2 val, mask64x2 mask)
        {
            return compress((ulong*)output, index, (ulong2)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long3 val, mask64x3 mask)
        {
            return compress((ulong*)output, index, (ulong3)val, mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long4 val, mask64x4 mask)
        {
            return compress((ulong*)output, index, (ulong4)val, mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long2 val, bool2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long3 val, bool3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(long* output, int index, long4 val, bool4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }


         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter2 val, mask8x2 mask)
        {
            return compress((byte*)output, index, asbyte(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter3 val, mask8x3 mask)
        {
            return compress((byte*)output, index, asbyte(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter4 val, mask8x4 mask)
        {
            return compress((byte*)output, index, asbyte(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter8 val, mask8x8 mask)
        {
            return compress((byte*)output, index, asbyte(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter16 val, mask8x16 mask)
        {
            return compress((byte*)output, index, asbyte(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter32 val, mask8x32 mask)
        {
            return compress((byte*)output, index, asbyte(val), mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter8 val, mask32x8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter8 val, mask16x8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter16 val, mask16x16 mask)
        {
            return compress(output, index, val, (mask8x16)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter2 val, bool2 mask)
        {
            return compress(output, index, val, (mask8x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter3 val, bool3 mask)
        {
            return compress(output, index, val, (mask8x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter4 val, bool4 mask)
        {
            return compress(output, index, val, (mask8x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter8 val, bool8 mask)
        {
            return compress(output, index, val, (mask8x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter16 val, bool16 mask)
        {
            return compress(output, index, val, (mask8x16)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(quarter* output, int index, quarter32 val, bool32 mask)
        {
            return compress(output, index, val, (mask8x32)mask);
        }


         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half2 val, mask16x2 mask)
        {
            return compress((ushort*)output, index, asushort(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half3 val, mask16x3 mask)
        {
            return compress((ushort*)output, index, asushort(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half4 val, mask16x4 mask)
        {
            return compress((ushort*)output, index, asushort(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half8 val, mask16x8 mask)
        {
            return compress((ushort*)output, index, asushort(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half16 val, mask16x16 mask)
        {
            return compress((ushort*)output, index, asushort(val), mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half8 val, mask32x8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half8 val, mask8x8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half16 val, mask8x16 mask)
        {
            return compress(output, index, val, (mask16x16)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half2 val, bool2 mask)
        {
            return compress(output, index, val, (mask16x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half3 val, bool3 mask)
        {
            return compress(output, index, val, (mask16x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half4 val, bool4 mask)
        {
            return compress(output, index, val, (mask16x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half8 val, bool8 mask)
        {
            return compress(output, index, val, (mask16x8)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(half* output, int index, half16 val, bool16 mask)
        {
            return compress(output, index, val, (mask16x16)mask);
        }


         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float2 val, mask32x2 mask)
        {
            return compress((uint*)output, index, asuint(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float3 val, mask32x3 mask)
        {
            return compress((uint*)output, index, asuint(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float4 val, mask32x4 mask)
        {
            return compress((uint*)output, index, asuint(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float8 val, mask32x8 mask)
        {
            return compress((uint*)output, index, asuint(val), mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float2 val, mask64x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float3 val, mask64x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float4 val, mask64x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float8 val, mask16x8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float8 val, mask8x8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float2 val, bool2 mask)
        {
            return compress(output, index, val, (mask32x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float3 val, bool3 mask)
        {
            return compress(output, index, val, (mask32x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float4 val, bool4 mask)
        {
            return compress(output, index, val, (mask32x4)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(float* output, int index, float8 val, bool8 mask)
        {
            return compress(output, index, val, (mask32x8)mask);
        }


         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double2 val, mask64x2 mask)
        {
            return compress((ulong*)output, index, asulong(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double3 val, mask64x3 mask)
        {
            return compress((ulong*)output, index, asulong(val), mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double4 val, mask64x4 mask)
        {
            return compress((ulong*)output, index, asulong(val), mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double2 val, mask32x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double3 val, mask32x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double4 val, mask32x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double2 val, mask16x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double3 val, mask16x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double4 val, mask16x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double2 val, mask8x2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double3 val, mask8x3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double4 val, mask8x4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }

        /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double2 val, bool2 mask)
        {
            return compress(output, index, val, (mask64x2)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double3 val, bool3 mask)
        {
            return compress(output, index, val, (mask64x3)mask);
        }

         /// <summary> Also known as left packing. Packs components with an enabled-mask to the left. Filters out components that are not enabled and leaves an output buffer tightly packed with only the enabled components. Returns the index to the element after the last one stored.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compress(double* output, int index, double4 val, bool4 mask)
        {
            return compress(output, index, val, (mask64x4)mask);
        }
    }
}
