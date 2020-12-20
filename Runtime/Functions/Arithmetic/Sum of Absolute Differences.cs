using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the sum of componentwise absolute differences of two byte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte2 a, byte2 b)
        {
            v128 maskedA = Sse2.and_si128(a, new v128(maxmath.bitmask64(16ul)));
            v128 maskedB = Sse2.and_si128(b, new v128(maxmath.bitmask64(16ul)));

            return Sse2.sad_epu8(maskedA, maskedB).UShort0;
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two byte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte3 a, byte3 b)
        {
            v128 maskedA = Sse2.and_si128(a, new v128(maxmath.bitmask64(24ul)));
            v128 maskedB = Sse2.and_si128(b, new v128(maxmath.bitmask64(24ul)));

            return Sse2.sad_epu8(maskedA, maskedB).UShort0;
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two byte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte4 a, byte4 b)
        {
            v128 maskedA = Sse2.and_si128(a, new v128(maxmath.bitmask64(32ul)));
            v128 maskedB = Sse2.and_si128(b, new v128(maxmath.bitmask64(32ul)));

            return Sse2.sad_epu8(maskedA, maskedB).UShort0;
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two byte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte8 a, byte8 b)
        {
            return Sse2.sad_epu8(a, b).UShort0;
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two byte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte16 a, byte16 b)
        {
            a = Sse2.sad_epu8(a, b);

            return Sse2.add_epi16(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 2))).UShort0;
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two byte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte32 a, byte32 b)
        {
            a = Avx2.mm256_sad_epu8(a, b);
            a = Avx2.mm256_add_epi16(a, Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(0, 0,    0, 2)));

            return Avx2.mm256_add_epi16(a, Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(0, 0, 0, 3))).UShort0;
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two sbyte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte2 a, sbyte2 b)
        {
            return (uint)csum(abs((short2)a - (short2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two sbyte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte3 a, sbyte3 b)
        {
            return (uint)csum(abs((short3)a - (short3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two sbyte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte4 a, sbyte4 b)
        {
            return (uint)csum(abs((short4)a - (short4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two sbyte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte8 a, sbyte8 b)
        {
            return (uint)csum(abs((short8)a - (short8)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two sbyte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte16 a, sbyte16 b)
        {
            return (uint)(csum(abs((short16)a - (short16)b)));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two sbyte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte32 a, sbyte32 b)
        {
            short16 sumUp = abs((short16)a.v16_0 - (short16)b.v16_0) + abs((short16)a.v16_16 - (short16)b.v16_16);
            short8 more = sumUp.v8_0 + sumUp.v8_8;

            more += Sse2.shuffle_epi32(more, Sse.SHUFFLE(0, 1, 2, 3));
            more += Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 1, 2, 3));

            return Sse2.add_epi16(more, Sse2.shufflelo_epi16(more, Sse.SHUFFLE(0, 0, 0, 1))).UShort0;
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two ushort2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort2 a, ushort2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two ushort3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort3 a, ushort3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two ushort4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort4 a, ushort4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two ushort8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort8 a, ushort8 b)
        {
            return csum((uint8)abs((int8)a - (int8)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two ushort16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort16 a, ushort16 b)
        {
            return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two short2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short2 a, short2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two short3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short3 a, short3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two short4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short4 a, short4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two short8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short8 a, short8 b)
        {
            return csum((uint8)abs((int8)a - (int8)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two short16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short16 a, short16 b)
        {
            return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two uint2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint2 a, uint2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two uint3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint3 a, uint3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two uint4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint4 a, uint4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two uint8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint8 a, uint8 b)
        {
            return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two byte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int2 a, int2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two int3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int3 a, int3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two int4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int4 a, int4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two int8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int8 a, int8 b)
        {
            return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two ulong2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong2 a, ulong2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two ulong3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong3 a, ulong3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two ulong4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong4 a, ulong4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two long2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long2 a, long2 b)
        {
            return csum((ulong2)abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two long3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long3 a, long3 b)
        {
            return csum((ulong3)abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two long4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long4 a, long4 b)
        {
            return csum((ulong4)abs(a - b));
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two float2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float2 a, float2 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two float3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float3 a, float3 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two float4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float4 a, float4 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two float8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float8 a, float8 b)
        {
            return csum(abs(a - b));
        }


        /// <summary>       Returns the sum of componentwise absolute differences of two double2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double2 a, double2 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two double3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double3 a, double3 b)
        {
            return math.csum(math.abs(a - b));
        }

        /// <summary>       Returns the sum of componentwise absolute differences of two double4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double4 a, double4 b)
        {
            return math.csum(math.abs(a - b));
        }
    }
}