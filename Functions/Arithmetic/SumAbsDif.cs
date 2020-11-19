using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte2 a, byte2 b)
        {
            v128 maskedA = X86.Sse2.and_si128(a, new v128(maxmath.bitmask64(16)));
            v128 maskedB = X86.Sse2.and_si128(b, new v128(maxmath.bitmask64(16)));

            return X86.Sse2.extract_epi16(X86.Sse2.sad_epu8(maskedA, maskedB), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte3 a, byte3 b)
        {
            v128 maskedA = X86.Sse2.and_si128(a, new v128(maxmath.bitmask64(24)));
            v128 maskedB = X86.Sse2.and_si128(b, new v128(maxmath.bitmask64(24)));

            return X86.Sse2.extract_epi16(X86.Sse2.sad_epu8(maskedA, maskedB), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte4 a, byte4 b)
        {
            v128 maskedA = X86.Sse2.and_si128(a, new v128(maxmath.bitmask64(32)));
            v128 maskedB = X86.Sse2.and_si128(b, new v128(maxmath.bitmask64(32)));

            return X86.Sse2.extract_epi16(X86.Sse2.sad_epu8(maskedA, maskedB), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte8 a, byte8 b)
        {
            return X86.Sse2.extract_epi16(X86.Sse2.sad_epu8(a, b), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte16 a, byte16 b)
        {
            a = X86.Sse2.sad_epu8(a, b);

            return (uint)X86.Sse2.extract_epi16(a, 0) + (uint)X86.Sse2.extract_epi16(a, 4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(byte32 a, byte32 b)
        {
            a = X86.Avx2.mm256_sad_epu8(a, b);
            a = X86.Avx2.mm256_add_epi16(a, X86.Avx2.mm256_shuffle_epi32(a, X86.Sse.SHUFFLE(0, 0,    0, 2)));

            return (uint)X86.Avx2.mm256_extract_epi16(a, 0) + (uint)X86.Avx2.mm256_extract_epi16(a, 12);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte2 a, sbyte2 b)
        {
            return (uint)csum(abs((short2)a - (short2)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte3 a, sbyte3 b)
        {
            return (uint)csum(abs((short3)a - (short3)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte4 a, sbyte4 b)
        {
            return (uint)csum(abs((short4)a - (short4)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte8 a, sbyte8 b)
        {
            return (uint)csum(abs((short8)a - (short8)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte16 a, sbyte16 b)
        {
            return (uint)(csum(abs((short16)a - (short16)b)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(sbyte32 a, sbyte32 b)
        {
            short16 sumUp = abs((short16)a.v16_0 - (short16)b.v16_0) + abs((short16)a.v16_16 - (short16)b.v16_16);
            short8 more = sumUp.v8_0 + sumUp.v8_8;

            more += X86.Sse2.shuffle_epi32(more, X86.Sse.SHUFFLE(0, 1, 2, 3));
            more += X86.Sse2.shufflelo_epi16(more, X86.Sse.SHUFFLE(0, 1, 2, 3));

            return (uint)(X86.Sse2.extract_epi16(more, 0) + X86.Sse2.extract_epi16(more, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort2 a, ushort2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort3 a, ushort3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort4 a, ushort4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort8 a, ushort8 b)
        {
            return csum((uint8)abs((int8)a - (int8)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(ushort16 a, ushort16 b)
        {
            return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short2 a, short2 b)
        {
            return math.csum((uint2)math.abs((int2)a - (int2)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short3 a, short3 b)
        {
            return math.csum((uint3)math.abs((int3)a - (int3)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short4 a, short4 b)
        {
            return math.csum((uint4)math.abs((int4)a - (int4)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short8 a, short8 b)
        {
            return csum((uint8)abs((int8)a - (int8)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint sad(short16 a, short16 b)
        {
            return sad(a.v8_0, b.v8_0) + sad(a.v8_8, b.v8_8);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint2 a, uint2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint3 a, uint3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint4 a, uint4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(uint8 a, uint8 b)
        {
            return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int2 a, int2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int3 a, int3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int4 a, int4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(int8 a, int8 b)
        {
            return sad(a.v4_0, b.v4_0) + sad(a.v4_4, b.v4_4);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong2 a, ulong2 b)
        {
            return csum((ulong2)abs((long2)a - (long2)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong3 a, ulong3 b)
        {
            return csum((ulong3)abs((long3)a - (long3)b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(ulong4 a, ulong4 b)
        {
            return csum((ulong4)abs((long4)a - (long4)b));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long2 a, long2 b)
        {
            return csum((ulong2)abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long3 a, long3 b)
        {
            return csum((ulong3)abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong sad(long4 a, long4 b)
        {
            return csum((ulong4)abs(a - b));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float2 a, float2 b)
        {
            return math.csum(math.abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float3 a, float3 b)
        {
            return math.csum(math.abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float4 a, float4 b)
        {
            return math.csum(math.abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sad(float8 a, float8 b)
        {
            return csum(abs(a - b));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double2 a, double2 b)
        {
            return math.csum(math.abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double3 a, double3 b)
        {
            return math.csum(math.abs(a - b));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sad(double4 a, double4 b)
        {
            return math.csum(math.abs(a - b));
        }
    }
}