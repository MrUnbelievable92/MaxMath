using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // maddubs(byte16 a, sbyte16 b) is useless.
    // (127 * 255) + (127 * 255) > short.MaxValue (& for negative)
    // => overflow + saturation = completely broken
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the dot product of two float8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dot(float8 x, float8 y)
        {
            x = Avx.mm256_dp_ps(x, y, 255);

            return Sse.add_ss(Avx.mm256_castps256_ps128(x), Avx.mm256_extractf128_ps(x, 1)).Float0;
        }


        /// <summary>       Returns the dot product of two byte2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * 255ul * 255ul)]
        public static uint dot(byte2 a, byte2 b)
        {
            return dot((ushort2)a, (ushort2)b);
        }

        /// <summary>       Returns the dot product of two byte3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * 255ul * 255ul * 255ul)]
        public static uint dot(byte3 a, byte3 b)
        {
            return dot((ushort3)a, (ushort3)b);
        }

        /// <summary>       Returns the dot product of two byte4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte4 a, byte4 b)
        {
            return dot((ushort4)a, (ushort4)b);
        }

        /// <summary>       Returns the dot product of two byte8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte8 a, byte8 b)
        {
            return dot((ushort8)a, (ushort8)b);
        }

        /// <summary>       Returns the dot product of two byte16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte16 a, byte16 b)
        {
            return dot((ushort16)a, (ushort16)b);
        }

        /// <summary>       Returns the dot product of two byte32 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte32 a, byte32 b)
        {
            return (uint)dot((short16)a.v16_0, (short16)b.v16_0) + (uint)dot((short16)a.v16_16, (short16)b.v16_16);
        }


        /// <summary>       Returns the dot product of two sbyte2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * -128 * 127, 2 * 127 * 127)]
        public static int dot(sbyte2 a, sbyte2 b)
        {
            return dot((short2)a, (short2)b);
        }

        /// <summary>       Returns the dot product of two sbyte3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-3 * 128 * 128 * 128, 3 * 128 * 128 * 127)]
        public static int dot(sbyte3 a, sbyte3 b)
        {
            return dot((short3)a, (short3)b);
        }

        /// <summary>       Returns the dot product of two sbyte4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte4 a, sbyte4 b)
        {
            return dot((short4)a, (short4)b);
        }

        /// <summary>       Returns the dot product of two sbyte8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte8 a, sbyte8 b)
        {
            return dot((short8)a, (short8)b);
        }

        /// <summary>       Returns the dot product of two sbyte16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte16 a, sbyte16 b)
        {
            return dot((short16)a, (short16)b);
        }

        /// <summary>       Returns the dot product of two sbyte32 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte32 a, sbyte32 b)
        {
            return dot((short16)a.v16_0, (short16)b.v16_0) + dot((short16)a.v16_16, (short16)b.v16_16);
        }


        /// <summary>       Returns the dot product of two short2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * -32768 * 32767, 2 * 32767 * 32767)]
        public static int dot(short2 a, short2 b)
        {
            return Sse2.madd_epi16(a, b).SInt0;
        }

        /// <summary>       Returns the dot product of two short3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short3 a, short3 b)
        {
            short4 t = Sse2.madd_epi16(Sse2.insert_epi16(a, 0, 3), b);

            return Sse2.add_epi32(t, Sse2.shuffle_epi32(t, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }

        /// <summary>       Returns the dot product of two short4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short4 a, short4 b)
        {
            a = Sse2.madd_epi16(a, b);

            return Sse2.add_epi32(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }

        /// <summary>       Returns the dot product of two short8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short8 a, short8 b)
        {
            a = Sse2.madd_epi16(a, b);

            a = Sse2.add_epi32(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse2.add_epi32(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }

        /// <summary>       Returns the dot product of two short16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short16 a, short16 b)
        {
            return csum((int8)Avx2.mm256_madd_epi16(a, b));
        }


        /// <summary>       Returns the dot product of two ushort2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort2 a, ushort2 b)
        {
            return math.dot((uint2)a, (uint2)b);
        }

        /// <summary>       Returns the dot product of two ushort3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort3 a, ushort3 b)
        {
            return math.dot((uint3)a, (uint3)b);
        }

        /// <summary>       Returns the dot product of two ushort4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort4 a, ushort4 b)
        {
            return math.dot((uint4)a, (uint4)b);
        }

        /// <summary>       Returns the dot product of two ushort8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort8 a, ushort8 b)
        {
            return dot((uint8)a, (uint8)b);
        }

        /// <summary>       Returns the dot product of two ushort16 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort16 a, ushort16 b)
        {
            return csum(((uint8)a.v8_0 * (uint8)b.v8_0) + ((uint8)a.v8_8 * (uint8)b.v8_8));
        }


        /// <summary>       Returns the dot product of two int8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(int8 x, int8 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two uint8 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(uint8 x, uint8 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two long2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long2 x, long2 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two long3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long3 x, long3 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two long4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long4 x, long4 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two ulong2 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong2 x, ulong2 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two ulong3 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong3 x, ulong3 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two ulong4 vectors.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong4 x, ulong4 y)
        {
            return csum(x * y);
        }
    }
}