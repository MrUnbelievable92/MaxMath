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
        /// <summary>       Returns the dot product of two <see cref="MaxMath.float8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dot(float8 x, float8 y)
        {
            if (Avx.IsAvxSupported)
            {
                x = Avx.mm256_dp_ps(x, y, 255);

                return Sse.add_ss(Avx.mm256_castps256_ps128(x), Avx.mm256_extractf128_ps(x, 1)).Float0;
            }
            else
            {
                return math.dot(x.v4_0, y.v4_0) + math.dot(x.v4_4, y.v4_4);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 2ul * 255ul * 255ul)]
        public static uint dot(byte2 a, byte2 b)
        {
            return dot((ushort2)a, (ushort2)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0ul, 3ul * 255ul * 255ul * 255ul)]
        public static uint dot(byte3 a, byte3 b)
        {
            return dot((ushort3)a, (ushort3)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte4 a, byte4 b)
        {
            return dot((ushort4)a, (ushort4)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte8 a, byte8 b)
        {
            return dot((ushort8)a, (ushort8)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte16 a, byte16 b)
        {
            return dot((ushort16)a, (ushort16)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte32"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte32 a, byte32 b)
        {
            return dot((ushort16)a.v16_0, (ushort16)b.v16_0) + dot((ushort16)a.v16_16, (ushort16)b.v16_16);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * -128 * 127, 2 * 127 * 127)]
        public static int dot(sbyte2 a, sbyte2 b)
        {
            return dot((short2)a, (short2)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-3 * 128 * 128 * 128, 3 * 128 * 128 * 127)]
        public static int dot(sbyte3 a, sbyte3 b)
        {
            return dot((short3)a, (short3)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte4 a, sbyte4 b)
        {
            return dot((short4)a, (short4)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte8 a, sbyte8 b)
        {
            return dot((short8)a, (short8)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte16 a, sbyte16 b)
        {
            return dot((short16)a, (short16)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte32"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte32 a, sbyte32 b)
        {
            return dot((short16)a.v16_0, (short16)b.v16_0) + dot((short16)a.v16_16, (short16)b.v16_16);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.short2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(2 * -32768 * 32767, 2 * 32767 * 32767)]
        public static int dot(short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.madd_epi16(a, b).SInt0;
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                short4 temp = Sse2.madd_epi16(Sse2.insert_epi16(a, 0, 3), b);

                return Sse2.add_epi32(temp, Sse2.shufflelo_epi16(temp, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                a = Sse2.madd_epi16(a, b);

                return Sse2.add_epi32(a, Sse2.shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return ((a.x * b.x) + (a.y * b.y)) + ((a.z * b.z) + (a.w * b.w));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                a = Sse2.madd_epi16(a, b);

                a = Sse2.add_epi32(a, Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 1, 2, 3)));

                return Sse2.add_epi32(a, Sse2.shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
            }
            else
            {
                return (((a.x0 * b.x0) + (a.x1 * b.x1)) + ((a.x2 * b.x2) + (a.x3 * b.x3))) + (((a.x4 * b.x4) + (a.x5 * b.x5)) + ((a.x6 * b.x6) + (a.x7 * b.x7)));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return csum((int8)Avx2.mm256_madd_epi16(a, b));
            }
            else
            {
                return dot(a.v8_0, b.v8_0) + dot(a.v8_8, b.v8_8);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort2 a, ushort2 b)
        {
            return math.dot((uint2)a, (uint2)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort3 a, ushort3 b)
        {
            return math.dot((uint3)a, (uint3)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort4 a, ushort4 b)
        {
            return math.dot((uint4)a, (uint4)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort8 a, ushort8 b)
        {
            return dot((uint8)a, (uint8)b);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort16"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort16 a, ushort16 b)
        {
            return csum(((uint8)a.v8_0 * (uint8)b.v8_0) + ((uint8)a.v8_8 * (uint8)b.v8_8));
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.int8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(int8 x, int8 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.uint8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(uint8 x, uint8 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.long2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long2 x, long2 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.long3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long3 x, long3 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long4 x, long4 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.ulong2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong2 x, ulong2 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ulong3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong3 x, ulong3 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong4 x, ulong4 y)
        {
            return csum(x * y);
        }
    }
}