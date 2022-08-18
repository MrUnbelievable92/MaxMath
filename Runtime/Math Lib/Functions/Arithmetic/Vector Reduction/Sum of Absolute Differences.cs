using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sad_epi8(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 NORMALIZE = Sse2.set1_epi8(sbyte.MinValue);

                    a = Sse2.add_epi8(a, NORMALIZE);
                    b = Sse2.add_epi8(b, NORMALIZE);

                    return Sse2.sad_epu8(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sad_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 NORMALIZE = Avx.mm256_set1_epi8(unchecked((byte)sbyte.MinValue));

                    a = Avx2.mm256_add_epi8(a, NORMALIZE);
                    b = Avx2.mm256_add_epi8(b, NORMALIZE);

                    return Avx2.mm256_sad_epu8(a, b);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SadHelper(v128 a, v128 b, int elements, bool signed)
        {
            if (Sse2.IsSse2Supported)
            {
                if (elements < 8)
                {
                    v128 mask = Sse2.cvtsi32_si128(maxmath.bitmask32(8 * elements));

                    a = Sse2.and_si128(a, mask);
                    b = Sse2.and_si128(b, mask);

                    return (signed ? Xse.sad_epi8(a, b) : Sse2.sad_epu8(a, b));
                }
                else if (elements == 8)
                {
                    return Sse2.sad_epu8(a, b);
                }
                else
                {
                    a = signed ? Xse.sad_epi8(a, b) : Sse2.sad_epu8(a, b);

                    return Sse2.add_epi16(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 2)));
                }
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte2"/>s.     </summary>
        [return: AssumeRange(0ul, 2ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 2, false).UShort0;
            }
            else
            {
                return (uint)(math.abs(a.x - b.x) + math.abs(a.y - b.y));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte3"/>s.     </summary>
        [return: AssumeRange(0ul, 3ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 3, false).UShort0;
            }
            else
            {
                return (uint)(math.abs(a.x - b.x) + math.abs(a.y - b.y) + math.abs(a.z - b.z));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte4"/>s.     </summary>
        [return: AssumeRange(0ul, 4ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 4, false).UShort0;
            }
            else
            {
                return (uint)((math.abs(a.x - b.x) + math.abs(a.y - b.y)) + (math.abs(a.z - b.z) + math.abs(a.w - b.w)));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte8"/>s.     </summary>
        [return: AssumeRange(0ul, 8ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 8, false).UShort0;
            }
            else
            {
                return (uint)(((math.abs(a.x0 - b.x0) + math.abs(a.x1 - b.x1)) + (math.abs(a.x2 - b.x2) + math.abs(a.x3 - b.x3))) + ((math.abs(a.x4 - b.x4) + math.abs(a.x5 - b.x5)) + (math.abs(a.x6 - b.x6) + math.abs(a.x7 - b.x7))));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte16"/>s.     </summary>
        [return: AssumeRange(0ul, 16ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 16, false).UShort0;
            }
            else
            {
                return (uint)(((math.abs(a.x0 - b.x0) + math.abs(a.x1 - b.x1)) + (math.abs(a.x2 - b.x2) + math.abs(a.x3 - b.x3))) + (((math.abs(a.x4 - b.x4) + math.abs(a.x5 - b.x5)) + (math.abs(a.x6 - b.x6) + math.abs(a.x7 - b.x7)))) + (((math.abs(a.x8 - b.x8) + math.abs(a.x9 - b.x9)) + (math.abs(a.x10 - b.x10) + math.abs(a.x11 - b.x11))) + ((math.abs(a.x12 - b.x12) + math.abs(a.x13 - b.x13)) + (math.abs(a.x14 - b.x14) + math.abs(a.x15 - b.x15)))));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte32"/>s.     </summary>
        [return: AssumeRange(0ul, 32ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (uint)csum((ulong4)Avx2.mm256_sad_epu8(a, b));
            }
            else
            {
                return sad(a.v16_0, b.v16_0) + sad(a.v16_16, b.v16_16);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte2"/>s.     </summary>
        [return: AssumeRange(0ul, 2ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(sbyte2 a, sbyte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 2, true).UShort0;
            }
            else
            {
                return (uint)csum(abs((short2)a - (short2)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte3"/>s.     </summary>
        [return: AssumeRange(0ul, 3ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(sbyte3 a, sbyte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 3, true).UShort0;
            }
            else
            {
                return (uint)csum(abs((short3)a - (short3)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte4"/>s.     </summary>
        [return: AssumeRange(0ul, 4ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(sbyte4 a, sbyte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 4, true).UShort0;
            }
            else
            {
                return (uint)csum(abs((short4)a - (short4)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte8"/>s.     </summary>
        [return: AssumeRange(0ul, 8ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(sbyte8 a, sbyte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 8, true).UShort0;
            }
            else
            {
                return (uint)csum(abs((short8)a - (short8)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte16"/>s.     </summary>
        [return: AssumeRange(0ul, 16ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(sbyte16 a, sbyte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return SadHelper(a, b, 16, true).UShort0;
            }
            else
            {
                return (uint)(csum(abs((short16)a - (short16)b)));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte32"/>s.     </summary>
        [return: AssumeRange(0ul, 32ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint sad(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (uint)csum((ulong4)Xse.mm256_sad_epi8(a, b));
            }
            else
            {
                return sad(a.v16_0, b.v16_0) + sad(a.v16_16, b.v16_16);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort2"/>s.     </summary>
        [return: AssumeRange(0ul, 2ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint sad(ushort2 a, ushort2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort3"/>s.     </summary>
        [return: AssumeRange(0ul, 3ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort3 a, ushort3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort4"/>s.     </summary>
        [return: AssumeRange(0ul, 4ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort4 a, ushort4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort8"/>s.     </summary>
        [return: AssumeRange(0ul, 8ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(ushort8 a, ushort8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = Xse.cvt2x2epu16_epi32(a, out v128 aHi);
                v128 bLo = Xse.cvt2x2epu16_epi32(b, out v128 bHi);

                v128 absDifLo = Xse.abs_epi32(Sse2.sub_epi32(aLo, bLo));
                v128 absDifHi = Xse.abs_epi32(Sse2.sub_epi32(aHi, bHi));

                v128 sum = Sse2.add_epi32(absDifLo, absDifHi);
                sum = Sse2.add_epi32(sum, Sse2.shuffle_epi32(sum, Sse.SHUFFLE(0, 0, 3, 2)));
                sum = Sse2.add_epi32(sum, Sse2.shuffle_epi32(sum, Sse.SHUFFLE(0, 0, 0, 1)));

                return sum.UInt0;
            }
            else
            {
                return csum((uint8)abs((int8)a - (int8)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort16"/>s.     </summary>
        [return: AssumeRange(0ul, 16ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint sad(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = Xse.mm256_cvt2x2epu16_epi32(a, out v256 aHi);
                v256 bLo = Xse.mm256_cvt2x2epu16_epi32(b, out v256 bHi);

                v256 absDifLo = Avx2.mm256_abs_epi32(Avx2.mm256_sub_epi32(aLo, bLo));
                v256 absDifHi = Avx2.mm256_abs_epi32(Avx2.mm256_sub_epi32(aHi, bHi));

                return csum((uint8)Avx2.mm256_add_epi32(absDifLo, absDifHi));
            }
            else
            {
                return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short2"/>s.     </summary>
        [return: AssumeRange(0ul, 2ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(short2 a, short2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short3"/>s.     </summary>
        [return: AssumeRange(0ul, 3ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(short3 a, short3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short4"/>s.     </summary>
        [return: AssumeRange(0ul, 4ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(short4 a, short4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short8"/>s.     </summary>
        [return: AssumeRange(0ul, 8ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = Xse.cvt2x2epi16_epi32(a, out v128 aHi);
                v128 bLo = Xse.cvt2x2epi16_epi32(b, out v128 bHi);

                v128 absDifLo = Xse.abs_epi32(Sse2.sub_epi32(aLo, bLo));
                v128 absDifHi = Xse.abs_epi32(Sse2.sub_epi32(aHi, bHi));

                v128 sum = Sse2.add_epi32(absDifLo, absDifHi);
                sum = Sse2.add_epi32(sum, Sse2.shuffle_epi32(sum, Sse.SHUFFLE(0, 0, 3, 2)));
                sum = Sse2.add_epi32(sum, Sse2.shuffle_epi32(sum, Sse.SHUFFLE(0, 0, 0, 1)));

                return sum.UInt0;
            }
            else
            {
                return csum((uint8)abs((int8)a - (int8)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short16"/>s.     </summary>
        [return: AssumeRange(0ul, 16ul * 65535ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint sad(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = Xse.mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                v256 bLo = Xse.mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                v256 absDifLo = Avx2.mm256_abs_epi32(Avx2.mm256_sub_epi32(aLo, bLo));
                v256 absDifHi = Avx2.mm256_abs_epi32(Avx2.mm256_sub_epi32(aHi, bHi));

                return csum((uint8)Avx2.mm256_add_epi32(absDifLo, absDifHi));
            }
            else
            {
                return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="uint2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint2 a, uint2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="uint3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint3 a, uint3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(a), out v128 aZ);
                v128 bLo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(b), out v128 bZ);

                v128 absDifLo = Xse.abs_epi64(Sse2.sub_epi64(aLo, bLo));
                v128 absDifZ  = Xse.abs_epi64(Sse2.sub_epi64(aZ,  bZ));

                v128 sum = Sse2.add_epi64(absDifLo, Sse2.shuffle_epi32(absDifLo, Sse.SHUFFLE(0, 0, 3, 2)));
                sum = Sse2.add_epi64(sum, absDifZ);

                return sum.ULong0;
            }
            else
            {
                return csum((ulong3)abs((long3)a - (long3)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="uint4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint4 a, uint4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(a), out v128 aHi);
                v128 bLo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(b), out v128 bHi);

                v128 absDifLo = Xse.abs_epi64(Sse2.sub_epi64(aLo, bLo));
                v128 absDifHi = Xse.abs_epi64(Sse2.sub_epi64(aHi, bHi));

                return csum((ulong2)Sse2.add_epi64(absDifLo, absDifHi));
            }
            else
            {
                return csum((ulong4)abs((long4)a - (long4)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.uint8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = Xse.mm256_cvt2x2epu32_epi64(a, out v256 aHi);
                v256 bLo = Xse.mm256_cvt2x2epu32_epi64(b, out v256 bHi);

                v256 absDifLo = Xse.mm256_abs_epi64(Avx2.mm256_sub_epi64(aLo, bLo));
                v256 absDifHi = Xse.mm256_abs_epi64(Avx2.mm256_sub_epi64(aHi, bHi));

                return csum((ulong4)Avx2.mm256_add_epi64(absDifLo, absDifHi));
            }
            else
            {
                return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int2 a, int2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="int3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int3 a, int3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = Xse.cvt2x2epi32_epi64(RegisterConversion.ToV128(a), out v128 aZ);
                v128 bLo = Xse.cvt2x2epi32_epi64(RegisterConversion.ToV128(b), out v128 bZ);

                v128 absDifLo = Xse.abs_epi64(Sse2.sub_epi64(aLo, bLo));
                v128 absDifZ  = Xse.abs_epi64(Sse2.sub_epi64(aZ,  bZ));

                v128 sum = Sse2.add_epi64(absDifLo, Sse2.shuffle_epi32(absDifLo, Sse.SHUFFLE(0, 0, 3, 2)));
                sum = Sse2.add_epi64(sum, absDifZ);

                return sum.ULong0;
            }
            else
            {
                return csum((ulong3)abs((long3)a - (long3)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="int4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int4 a, int4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = Xse.cvt2x2epi32_epi64(RegisterConversion.ToV128(a), out v128 aHi);
                v128 bLo = Xse.cvt2x2epi32_epi64(RegisterConversion.ToV128(b), out v128 bHi);

                v128 absDifLo = Xse.abs_epi64(Sse2.sub_epi64(aLo, bLo));
                v128 absDifHi = Xse.abs_epi64(Sse2.sub_epi64(aHi, bHi));

                return csum((ulong2)Sse2.add_epi64(absDifLo, absDifHi));
            }
            else
            {
                return csum((ulong4)abs((long4)a - (long4)b));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.int8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = Xse.mm256_cvt2x2epi32_epi64(a, out v256 aHi);
                v256 bLo = Xse.mm256_cvt2x2epi32_epi64(b, out v256 bHi);

                v256 absDifLo = Xse.mm256_abs_epi64(Avx2.mm256_sub_epi64(aLo, bLo));
                v256 absDifHi = Xse.mm256_abs_epi64(Avx2.mm256_sub_epi64(aHi, bHi));

                return csum((ulong4)Avx2.mm256_add_epi64(absDifLo, absDifHi));
            }
            else
            {
                return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ulong2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong2 a, ulong2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ulong3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong3 a, ulong3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ulong4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong4 a, ulong4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.long2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long2 a, long2 b)
        {
            a += long.MinValue;
            b += long.MinValue;

            return csum((ulong2)abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.long3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long3 a, long3 b)
        {
            a += long.MinValue;
            b += long.MinValue;

            return csum((ulong3)abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.long4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long4 a, long4 b)
        {
            a += long.MinValue;
            b += long.MinValue;

            return csum((ulong4)abs(a - b));
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="float2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float2 a, float2 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="float3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float3 a, float3 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="float4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float4 a, float4 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float8 a, float8 b)
        {
            return csum(abs(a - b));
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="double2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double2 a, double2 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="double3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double3 a, double3 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="double4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double4 a, double4 b)
        {
            return math.csum(math.abs(a - b));
        }
    }
}