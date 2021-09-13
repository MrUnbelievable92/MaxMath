using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * 255ul)]
        public static uint sad(byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cvtsi32_si128(maxmath.bitmask32(16));

                v128 maskedA = Sse2.and_si128(a, mask);
                v128 maskedB = Sse2.and_si128(b, mask);

                return Sse2.sad_epu8(maskedA, maskedB).UShort0;
            }
            else
            {
                return (uint)(math.abs(a.x - b.x) + math.abs(a.y - b.y));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * 255ul)]
        public static uint sad(byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cvtsi32_si128(maxmath.bitmask32(24));

                v128 maskedA = Sse2.and_si128(a, mask);
                v128 maskedB = Sse2.and_si128(b, mask);

                return Sse2.sad_epu8(maskedA, maskedB).UShort0;
            }
            else
            {
                return (uint)(math.abs(a.x - b.x) + math.abs(a.y - b.y) + math.abs(a.z - b.z));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 4ul * 255ul)]
        public static uint sad(byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cvtsi32_si128(-1);

                v128 maskedA = Sse2.and_si128(a, mask);
                v128 maskedB = Sse2.and_si128(b, mask);

                return Sse2.sad_epu8(maskedA, maskedB).UShort0;
            }
            else
            {
                return (uint)((math.abs(a.x - b.x) + math.abs(a.y - b.y)) + (math.abs(a.z - b.z) + math.abs(a.w - b.w)));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul * 255ul)]
        public static uint sad(byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sad_epu8(a, b).UShort0;
            }
            else
            {
                return (uint)(((math.abs(a.x0 - b.x0) + math.abs(a.x1 - b.x1)) + (math.abs(a.x2 - b.x2) + math.abs(a.x3 - b.x3))) + ((math.abs(a.x4 - b.x4) + math.abs(a.x5 - b.x5)) + (math.abs(a.x6 - b.x6) + math.abs(a.x7 - b.x7))));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul * 255ul)]
        public static uint sad(byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                a = Sse2.sad_epu8(a, b);

                return Sse2.add_epi16(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 2))).UShort0;
            }
            else
            {
                return (uint)(((math.abs(a.x0 - b.x0) + math.abs(a.x1 - b.x1)) + (math.abs(a.x2 - b.x2) + math.abs(a.x3 - b.x3))) + (((math.abs(a.x4 - b.x4) + math.abs(a.x5 - b.x5)) + (math.abs(a.x6 - b.x6) + math.abs(a.x7 - b.x7)))) + (((math.abs(a.x8 - b.x8) + math.abs(a.x9 - b.x9)) + (math.abs(a.x10 - b.x10) + math.abs(a.x11 - b.x11))) + ((math.abs(a.x12 - b.x12) + math.abs(a.x13 - b.x13)) + (math.abs(a.x14 - b.x14) + math.abs(a.x15 - b.x15)))));
            }
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.byte32"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 32ul * 255ul)]
        public static uint sad(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                a = Avx2.mm256_sad_epu8(a, b);
                a = Avx2.mm256_add_epi16(a, Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 2)));

                return Avx2.mm256_add_epi16(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(0, 0, 0, 3))).UShort0;
            }
            else
            {
                return sad(a.v16_0, b.v16_0) + sad(a.v16_16, b.v16_16);
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * 255ul)]
        public static uint sad(sbyte2 a, sbyte2 b)
        {
            return (uint)csum(abs((short2)a - (short2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * 255ul)]
        public static uint sad(sbyte3 a, sbyte3 b)
        {
            return (uint)csum(abs((short3)a - (short3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 4ul * 255ul)]
        public static uint sad(sbyte4 a, sbyte4 b)
        {
            return (uint)csum(abs((short4)a - (short4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul * 255ul)]
        public static uint sad(sbyte8 a, sbyte8 b)
        {
            return (uint)csum(abs((short8)a - (short8)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul * 255ul)]
        public static uint sad(sbyte16 a, sbyte16 b)
        {
            return (uint)(csum(abs((short16)a - (short16)b)));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.sbyte32"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 32ul * 255ul)]
        public static uint sad(sbyte32 a, sbyte32 b)
        {
            short16 sumUp = abs((short16)a.v16_0 - (short16)b.v16_0) + abs((short16)a.v16_16 - (short16)b.v16_16);
            short8 more = sumUp.v8_0 + sumUp.v8_8;

            if (Sse2.IsSse2Supported)
            {
                more += Sse2.shuffle_epi32(more, Sse.SHUFFLE(0, 1, 2, 3));
                more += Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 1, 2, 3));

                return Sse2.add_epi16(more, Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 0, 0, 1))).UShort0;
            }
            else
            {
                return (uint)(((more.x0 + more.x1) + (more.x2 + more.x3)) + ((more.x4 + more.x5) + (more.x6 + more.x7)));
            }
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * 65535ul)]
        public static uint sad(ushort2 a, ushort2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * 65535ul)]
        public static uint sad(ushort3 a, ushort3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 4ul * 65535ul)]
        public static uint sad(ushort4 a, ushort4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul * 65535ul)]
        public static uint sad(ushort8 a, ushort8 b)
        {
            return csum((uint8)abs((int8)a - (int8)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.ushort16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul * 65535ul)]
        public static uint sad(ushort16 a, ushort16 b)
        {
            return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short2"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * 65535ul)]
        public static uint sad(short2 a, short2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * 65535ul)]
        public static uint sad(short3 a, short3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 4ul * 65535ul)]
        public static uint sad(short4 a, short4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 8ul * 65535ul)]
        public static uint sad(short8 a, short8 b)
        {
            return csum((uint8)abs((int8)a - (int8)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.short16"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 16ul * 65535ul)]
        public static uint sad(short16 a, short16 b)
        {
            return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
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
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="uint4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint4 a, uint4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.uint8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint8 a, uint8 b)
        {
            return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
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
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="int4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int4 a, int4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.int8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int8 a, int8 b)
        {
            return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
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
            return csum((ulong2)abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.long3"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long3 a, long3 b)
        {
            return csum((ulong3)abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two <see cref="MaxMath.long4"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long4 a, long4 b)
        {
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