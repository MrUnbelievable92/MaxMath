using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    // maddubs(byte16 a, sbyte16 b) is useless.
    // (127 * 255) + (127 * 255) > short.MaxValue (& for negative)
    // => overflow + saturation = completely broken
    unsafe public static partial class maxmath
    {
        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dot(float8 x, float8 y)
        {
            x = X86.Avx.mm256_dp_ps(x, y, 255);

            return X86.Sse.add_ps(X86.Avx.mm256_castps256_ps128(x), X86.Avx.mm256_extractf128_ps(x, 1)).Float0;
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(byte32 a, sbyte32 b)
        {
            return dot((short16)a.v16_0, (short16)b.v16_0) + dot((short16)a.v16_16, (short16)b.v16_16);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte32 a, byte32 b)
        {
            return dot((short16)a.v16_0, (short16)b.v16_0) + dot((short16)a.v16_16, (short16)b.v16_16);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte32 a, byte32 b)
        {
            return (uint)dot((short16)a.v16_0, (short16)b.v16_0) + (uint)dot((short16)a.v16_16, (short16)b.v16_16);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte32 a, sbyte32 b)
        {
            return dot((short16)a.v16_0, (short16)b.v16_0) + dot((short16)a.v16_16, (short16)b.v16_16);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short2 a, short2 b)
        {
            return X86.Sse4_1.extract_epi32(X86.Sse2.madd_epi16(a, b), 0);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short3 a, short3 b)
        {
            short4 t = X86.Sse2.madd_epi16(X86.Sse2.insert_epi16(a, 0, 3), b);

            return X86.Sse4_1.extract_epi32(t, 0) + X86.Sse4_1.extract_epi32(t, 1);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short4 a, short4 b)
        {
            a = X86.Sse2.madd_epi16(a, b);

            return X86.Sse4_1.extract_epi32(a, 0) + X86.Sse4_1.extract_epi32(a, 1);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short8 a, short8 b)
        {
            a = X86.Sse2.madd_epi16(a, b);

            a = X86.Sse2.add_epi32(a, X86.Sse2.shuffle_epi32(a, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(a, 0) + X86.Sse4_1.extract_epi32(a, 2);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short16 a, short16 b)
        {
            return csum((int8)X86.Avx2.mm256_madd_epi16(a, b));
        }


        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort2 a, ushort2 b)
        {
            return math.dot((uint2)a, (uint2)b);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort3 a, ushort3 b)
        {
            return math.dot((uint3)a, (uint3)b);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort4 a, ushort4 b)
        {
            return math.dot((uint4)a, (uint4)b);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort8 a, ushort8 b)
        {
            return dot((uint8)a, (uint8)b);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort16 a, ushort16 b)
        {
            return csum(((uint8)a.v8_0 * (uint8)b.v8_0) + ((uint8)a.v8_8 * (uint8)b.v8_8));
        }


        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(int8 x, int8 y)
        {
            return csum(x * y);
        }

        /// <summary> csum(a * b) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(uint8 x, uint8 y)
        {
            return csum(x * y);
        }
    }
}
