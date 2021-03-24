using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the integer square root ⌊√x⌋ of a byte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, 15ul)]
        public static byte intsqrt(byte x)
        {
            return (byte)math.sqrt(x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a byte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intsqrt(byte2 x)
        {
            return (byte2)(math.sqrt(x));
        } 

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a byte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intsqrt(byte3 x)
        {
            return (byte3)(math.sqrt(x));
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a byte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intsqrt(byte4 x)
        {
            return (byte4)(math.sqrt(x));
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a byte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intsqrt(byte8 x)
        {
            return (byte8)sqrt(x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a byte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intsqrt(byte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new byte16(intsqrt(x.v8_0), intsqrt(x.v8_8));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);

                byte16 result = ZERO;
                byte16 mask = new byte16(1 << 6);

                v128 doneMask = ZERO;


                v128 tempMask = Sse2.cmpeq_epi8(ZERO, ZERO);

                doneMask = Sse2.cmpeq_epi8(x, max(mask, x));
                tempMask = Mask.BlendV(tempMask, mask, doneMask);

                while (bitmask32(16 * sizeof(byte)) != Sse2.movemask_epi8(doneMask))
                {
                    mask >>= 2;

                    doneMask = Sse2.or_si128(doneMask, Sse2.cmpeq_epi8(x, max(mask, x)));

                    if (Sse4_1.IsSse41Supported)
                    {
                        tempMask = Mask.BlendV(tempMask, mask, Sse2.and_si128(tempMask, doneMask));
                    }
                    else
                    {
                        tempMask = Mask.BlendV(tempMask, mask, Sse2.and_si128(Sse2.cmpgt_epi8(default, tempMask), doneMask));
                    }
                }

                mask = tempMask;


                doneMask = Sse2.cmpeq_epi8(mask, ZERO);

                while (bitmask32(16 * sizeof(byte)) != Sse2.movemask_epi8(doneMask))
                {
                    byte16 result_shifted = result >> 1;
                    v128 result_added = Sse2.add_epi8(result, mask);

                    v128 blendMask = Sse2.cmpeq_epi8(x, max(x, result_added));
                    v128 result_if_true = Sse2.add_epi8(result_shifted, mask);
                    v128 x_if_true = Sse2.sub_epi8(x, result_added);

                    x = Mask.BlendV(x, x_if_true, blendMask);
                    result = Mask.BlendV(Mask.BlendV(result_shifted, result, doneMask), result_if_true, Sse2.andnot_si128(doneMask, blendMask));


                    mask >>= 2;

                    doneMask = Sse2.cmpeq_epi8(mask, ZERO);
                }


                return result;
            }
            else
            {
                return new byte16(intsqrt(x.x0), intsqrt(x.x1), intsqrt(x.x2), intsqrt(x.x3), intsqrt(x.x4), intsqrt(x.x5), intsqrt(x.x6), intsqrt(x.x7), intsqrt(x.x8), intsqrt(x.x9), intsqrt(x.x10), intsqrt(x.x11), intsqrt(x.x12), intsqrt(x.x13), intsqrt(x.x14), intsqrt(x.x15));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a byte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intsqrt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = default(v256);

                byte32 result = ZERO;
                byte32 mask = new byte32(1 << 6);

                v256 doneMask = ZERO;


                v256 tempMask = Avx2.mm256_cmpeq_epi8(ZERO, ZERO);

                doneMask = Avx2.mm256_cmpeq_epi8(x, max(mask, x));
                tempMask = Avx2.mm256_blendv_epi8(tempMask, mask, doneMask);

                while (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    mask >>= 2;

                    doneMask = Avx2.mm256_or_si256(doneMask, Avx2.mm256_cmpeq_epi8(x, max(mask, x)));
                    tempMask = Avx2.mm256_blendv_epi8(tempMask, mask, Avx2.mm256_and_si256(tempMask, doneMask));
                }

                mask = tempMask;


                doneMask = Avx2.mm256_cmpeq_epi8(mask, ZERO);

                while (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    byte32 result_shifted = result >> 1;
                    v256 result_added = Avx2.mm256_add_epi8(result, mask);

                    v256 blendMask = Avx2.mm256_cmpeq_epi8(x, max(x, result_added));
                    v256 result_if_true = Avx2.mm256_add_epi8(result_shifted, mask);
                    v256 x_if_true = Avx2.mm256_sub_epi8(x, result_added);

                    x = Avx2.mm256_blendv_epi8(x, x_if_true, blendMask);
                    result = Avx2.mm256_blendv_epi8(Avx2.mm256_blendv_epi8(result_shifted, result, doneMask), result_if_true, Avx2.mm256_andnot_si256(doneMask, blendMask));


                    mask >>= 2;

                    doneMask = Avx2.mm256_cmpeq_epi8(mask, ZERO);
                }


                return result;
            }
            else
            {
                return new byte32(intsqrt(x.v16_0), intsqrt(x.v16_16));
            }
        }

        /// <summary>       Computes the integer square root ⌊√x⌋ of a non-negative sbyte value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 11)]
        public static sbyte intsqrt(sbyte x)
        {
Assert.IsNonNegative(x);

            return (sbyte)intsqrt((byte)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative sbyte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intsqrt(sbyte2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (sbyte2)intsqrt((byte2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative sbyte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intsqrt(sbyte3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (sbyte3)intsqrt((byte3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative sbyte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intsqrt(sbyte4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (sbyte4)intsqrt((byte4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative sbyte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intsqrt(sbyte8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);

            return (sbyte8)intsqrt((byte8)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative sbyte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intsqrt(sbyte16 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);

            return (sbyte16)intsqrt((byte16)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative sbyte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intsqrt(sbyte32 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);
Assert.IsNonNegative(x.x16);
Assert.IsNonNegative(x.x17);
Assert.IsNonNegative(x.x18);
Assert.IsNonNegative(x.x19);
Assert.IsNonNegative(x.x20);
Assert.IsNonNegative(x.x21);
Assert.IsNonNegative(x.x22);
Assert.IsNonNegative(x.x23);
Assert.IsNonNegative(x.x24);
Assert.IsNonNegative(x.x25);
Assert.IsNonNegative(x.x26);
Assert.IsNonNegative(x.x27);
Assert.IsNonNegative(x.x28);
Assert.IsNonNegative(x.x29);
Assert.IsNonNegative(x.x30);
Assert.IsNonNegative(x.x31);

            return (sbyte32)intsqrt((sbyte32)x);
        }


        /// <summary>       Computes the integer square root ⌊√x⌋ of a ushort value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, (ulong)byte.MaxValue)]
        public static ushort intsqrt(ushort x)
        {
            return (ushort)math.sqrt(x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ushort2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intsqrt(ushort2 x)
        {
            return (ushort2)(math.sqrt(x));
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ushort3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intsqrt(ushort3 x)
        {
            return (ushort3)(math.sqrt(x));
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ushort4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intsqrt(ushort4 x)
        {
            return (ushort4)(math.sqrt(x));
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ushort8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intsqrt(ushort8 x)
        {
            return (ushort8)(sqrt(x));
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ushort16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intsqrt(ushort16 x)
        {
            return new ushort16(intsqrt(x.v8_0), intsqrt(x.v8_8));
        }

        /// <summary>       Computes the integer square root ⌊√x⌋ of a non-negative short value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 181)]
        public static short intsqrt(short x)
        {
Assert.IsNonNegative(x);

            return (short)intsqrt((ushort)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative short2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intsqrt(short2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (short2)intsqrt((ushort2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative short3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intsqrt(short3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (short3)intsqrt((ushort3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative short4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intsqrt(short4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (short4)intsqrt((ushort4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative short8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intsqrt(short8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);

            return (short8)intsqrt((ushort8)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative short16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intsqrt(short16 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);

            return (short16)intsqrt((ushort16)x);
        }


        /// <summary>       Computes the integer square root ⌊√x⌋ of a uint value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, (ulong)ushort.MaxValue)]
        public static uint intsqrt(uint x)
        {
            return (uint)math.sqrt((double)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a uint2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intsqrt(uint2 x)
        {
            return (uint2)math.sqrt((double2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a uint3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intsqrt(uint3 x)
        {
            return (uint3)math.sqrt((double3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a uint4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intsqrt(uint4 x)
        {
            return (uint4)math.sqrt((double4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a uint8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intsqrt(uint8 x)
        {
            return new uint8(intsqrt(x.v4_0), intsqrt(x.v4_4));
        }

        /// <summary>       Computes the integer square root ⌊√x⌋ of a non-negative int value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 46_340)]
        public static int intsqrt(int x)
        {
Assert.IsNonNegative(x);

            return (int)intsqrt((uint)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative int2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intsqrt(int2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (int2)intsqrt((uint2)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative int3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intsqrt(int3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (int3)intsqrt((uint3)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative int4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intsqrt(int4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (int4)intsqrt((uint4)x);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a non-negative int8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intsqrt(int8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);

            return (int8)intsqrt((uint8)x);
        }


        /// <summary>       Computes the integer square root ⌊√x⌋ of a ulong value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0ul, (ulong)uint.MaxValue)]
        public static ulong intsqrt(ulong x)
        {
            ulong result = 0;
            ulong mask = 1ul << 62;

            while (mask > x)
            {
                mask >>= 2;
            }

            while (mask != 0)
            {
                ulong resultShifted = result >> 1;
                ulong resultAdded = result + mask;

                if (x >= resultAdded)
                {
                    x -= resultAdded;
                    result = resultShifted + mask;
                }
                else
                {
                    result = resultShifted;
                }

                mask >>= 2;
            }

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ulong2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intsqrt(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 ZERO = default(v128);

                v128 result = ZERO;
                v128 mask = new v128(1ul << 62);

                v128 doneMask = ZERO;


                if (Avx2.IsAvx2Supported)
                {
                    doneMask = Operator.equals_mask_long(x, max(mask, x));

                    while (bitmask32(2 * sizeof(ulong)) != Sse2.movemask_epi8(doneMask))
                    {
                        mask = Avx2.srlv_epi64(mask, Mask.BlendV(new v128(2ul), ZERO, doneMask));

                        doneMask = Sse2.or_si128(doneMask, Operator.equals_mask_long(x, max(mask, x)));
                    }
                }
                else
                {
                    v128 tempMask = Operator.equals_mask_long(ZERO, ZERO);

                    doneMask = Operator.equals_mask_long(x, max(mask, x));
                    tempMask = Mask.BlendV(tempMask, mask, doneMask);

                    while (bitmask32(2 * sizeof(ulong)) != Sse2.movemask_epi8(doneMask))
                    {
                        mask = Sse2.srli_epi64(mask, 2);

                        doneMask = Sse2.or_si128(doneMask, Operator.equals_mask_long(x, max(mask, x)));

                        if (Sse4_1.IsSse41Supported)
                        {
                            tempMask = Mask.BlendV(tempMask, mask, Sse2.and_si128(tempMask, doneMask));
                        }
                        else
                        {
                            tempMask = Mask.BlendV(tempMask, mask, Sse2.and_si128(Operator.greater_mask_long(default, tempMask), doneMask));
                        }
                    }

                    mask = tempMask;
                }


                doneMask = Operator.equals_mask_long(mask, ZERO);

                while (bitmask32(2 * sizeof(ulong)) != Sse2.movemask_epi8(doneMask))
                {
                    v128 result_shifted = Sse2.srli_epi64(result, 1);
                    v128 result_added = Sse2.add_epi64(result, mask);

                    v128 blendMask = Operator.equals_mask_long(x, max(x, result_added));
                    v128 result_if_true = Sse2.add_epi64(result_shifted, mask);
                    v128 x_if_true = Sse2.sub_epi64(x, result_added);

                    x = Mask.BlendV(x, x_if_true, blendMask);
                    result = Mask.BlendV(Mask.BlendV(result_shifted, result, doneMask), result_if_true, Sse2.andnot_si128(doneMask, blendMask));


                    mask = Sse2.srli_epi64(mask, 2);

                    doneMask = Operator.equals_mask_long(mask, ZERO);
                }


                return result;
            }
            else
            {
                return new ulong2(intsqrt(x.x), intsqrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ulong3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intsqrt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = default(v256);

                v256 result = ZERO;
                v256 mask = new v256(1ul << 62);

                v256 doneMask = ZERO;


                doneMask = Avx2.mm256_cmpeq_epi64(x, max(mask, x));

                while (bitmask32(3 * sizeof(ulong)) != (bitmask32(3 * sizeof(ulong)) & Avx2.mm256_movemask_epi8(doneMask)))
                {
                    mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_blendv_epi8(new v256(2ul), ZERO, doneMask));

                    doneMask = Avx2.mm256_or_si256(doneMask, Avx2.mm256_cmpeq_epi64(x, max(mask, x)));
                }


                doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);

                while (bitmask32(3 * sizeof(ulong)) != (bitmask32(3 * sizeof(ulong)) & Avx2.mm256_movemask_epi8(doneMask)))
                {
                    v256 result_shifted = Avx2.mm256_srli_epi64(result, 1);
                    v256 result_added = Avx2.mm256_add_epi64(result, mask);

                    v256 blendMask = Avx2.mm256_cmpeq_epi64(x, max(x, result_added));
                    v256 result_if_true = Avx2.mm256_add_epi64(result_shifted, mask);
                    v256 x_if_true = Avx2.mm256_sub_epi64(x, result_added);

                    x = Avx2.mm256_blendv_epi8(x, x_if_true, blendMask);
                    result = Avx2.mm256_blendv_epi8(Avx2.mm256_blendv_epi8(result_shifted, result, doneMask), result_if_true, Avx2.mm256_andnot_si256(doneMask, blendMask));


                    mask = Avx2.mm256_srli_epi64(mask, 2);

                    doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                }


                return result;
            }
            else
            {
                return new ulong3(intsqrt(x.xy), intsqrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√x⌋ of a ulong4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intsqrt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = default(v256);

                v256 result = ZERO;
                v256 mask = new v256(1ul << 62);

                v256 doneMask = ZERO;


                doneMask = Avx2.mm256_cmpeq_epi64(x, max(mask, x));

                while (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_blendv_epi8(new v256(2ul), ZERO, doneMask));

                    doneMask = Avx2.mm256_or_si256(doneMask, Avx2.mm256_cmpeq_epi64(x, max(mask, x)));
                }


                doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);

                while (-1 != Avx2.mm256_movemask_epi8(doneMask))
                {
                    v256 result_shifted = Avx2.mm256_srli_epi64(result, 1);
                    v256 result_added = Avx2.mm256_add_epi64(result, mask);

                    v256 blendMask = Avx2.mm256_cmpeq_epi64(x, max(x, result_added));
                    v256 result_if_true = Avx2.mm256_add_epi64(result_shifted, mask);
                    v256 x_if_true = Avx2.mm256_sub_epi64(x, result_added);

                    x = Avx2.mm256_blendv_epi8(x, x_if_true, blendMask);
                    result = Avx2.mm256_blendv_epi8(Avx2.mm256_blendv_epi8(result_shifted, result, doneMask), result_if_true, Avx2.mm256_andnot_si256(doneMask, blendMask));


                    mask = Avx2.mm256_srli_epi64(mask, 2);

                    doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                }


                return result;
            }
            else
            {
                return new ulong4(intsqrt(x.xy), intsqrt(x.zw));
            }
        }

        /// <summary>       Computes the longeger square root ⌊√x⌋ of a non-negative long value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] [return: AssumeRange(0, 3_037_000_499)]
        public static long intsqrt(long x)
        {
Assert.IsNonNegative(x);

            return (long)intsqrt((ulong)x);
        }

        /// <summary>       Computes the componentwise longeger square root ⌊√x⌋ of a non-negative long2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intsqrt(long2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);

            return (long2)intsqrt((ulong2)x);
        }

        /// <summary>       Computes the componentwise longeger square root ⌊√x⌋ of a non-negative long3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intsqrt(long3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);

            return (long3)intsqrt((ulong3)x);
        }

        /// <summary>       Computes the componentwise longeger square root ⌊√x⌋ of a non-negative long4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intsqrt(long4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);

            return (long4)intsqrt((ulong4)x);
        }
    }
}