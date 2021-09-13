using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise absolute value of an <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 abs(Int128 x)
        {
            ulong mask = (ulong)((long)x.intern.hi >> 63);

            ulong lo = x.intern.lo ^ mask;
            ulong hi = x.intern.hi ^ mask;

            return new Int128(lo, hi) + ((ulong)-(long)mask);
        }


        /// <summary>       Returns the componentwise absolute value of an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte abs(sbyte x)
        {
            return (sbyte)math.abs(x);
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 abs(sbyte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new sbyte2((sbyte)math.abs(x.x), (sbyte)math.abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 abs(sbyte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new sbyte3((sbyte)math.abs(x.x), (sbyte)math.abs(x.y), (sbyte)math.abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 abs(sbyte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new sbyte4((sbyte)math.abs(x.x), (sbyte)math.abs(x.y), (sbyte)math.abs(x.z), (sbyte)math.abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 abs(sbyte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new sbyte8((sbyte)math.abs(x.x0), (sbyte)math.abs(x.x1), (sbyte)math.abs(x.x2), (sbyte)math.abs(x.x3), (sbyte)math.abs(x.x4), (sbyte)math.abs(x.x5), (sbyte)math.abs(x.x6), (sbyte)math.abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 abs(sbyte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new sbyte16((sbyte)math.abs(x.x0), (sbyte)math.abs(x.x1), (sbyte)math.abs(x.x2), (sbyte)math.abs(x.x3), (sbyte)math.abs(x.x4), (sbyte)math.abs(x.x5), (sbyte)math.abs(x.x6), (sbyte)math.abs(x.x7), (sbyte)math.abs(x.x8), (sbyte)math.abs(x.x9), (sbyte)math.abs(x.x10), (sbyte)math.abs(x.x11), (sbyte)math.abs(x.x12), (sbyte)math.abs(x.x13), (sbyte)math.abs(x.x14), (sbyte)math.abs(x.x15));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 abs(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_abs_epi8(x);
            }
            else
            {
                return new sbyte32(abs(x.v16_0), abs(x.v16_16));
            }
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short abs(short x)
        {
            return (short)math.abs(x);
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 abs(short2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short2((short)math.abs(x.x), (short)math.abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 abs(short3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short3((short)math.abs(x.x), (short)math.abs(x.y), (short)math.abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 abs(short4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short4((short)math.abs(x.x), (short)math.abs(x.y), (short)math.abs(x.z), (short)math.abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 abs(short8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.abs_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(Sse2.sub_epi16(Sse2.setzero_si128(), x), x);
            }
            else
            {
                return new short8((short)math.abs(x.x0), (short)math.abs(x.x1), (short)math.abs(x.x2), (short)math.abs(x.x3), (short)math.abs(x.x4), (short)math.abs(x.x5), (short)math.abs(x.x6), (short)math.abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 abs(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_abs_epi16(x);
            }
            else
            {
                return new short16(abs(x.v8_0), abs(x.v8_8));
            }
        }


        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 abs(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_abs_epi32(x);
            }
            else
            {
                return new int8(math.abs(x.v4_0), math.abs(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 abs(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                long2 mask = Operator.greater_mask_long(Sse2.setzero_si128(), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new long2(math.abs(x.x), math.abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 abs(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                long3 mask = Avx2.mm256_cmpgt_epi64(default(v256), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new long3(abs(x.xy), math.abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 abs(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                long4 mask = Avx2.mm256_cmpgt_epi64(default(v256), x);

                return (x + mask) ^ mask;
            }
            else
            {
                return new long4(abs(x.xy), abs(x.zw));
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter abs(quarter x)
        {
            return asquarter((byte)(asbyte(x) & 0b0111_1111));
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 abs(quarter2 x)
        {
            return asquarter(asbyte(x) & 0b0111_1111);
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 abs(quarter3 x)
        {
            return asquarter(asbyte(x) & 0b0111_1111);
        }
        
        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 abs(quarter4 x)
        {
            return asquarter(asbyte(x) & 0b0111_1111);
        }
        
        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 abs(quarter8 x)
        {
            return asquarter(asbyte(x) & 0b0111_1111);
        }


        /// <summary>       Returns the absolute value of a <see cref="half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half abs(half x)
        {
            return new half { value = ((ushort)(x.value & 0x7FFF)) };
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 abs(half2 x)
        {
            return ashalf(asushort(x) & 0x7FFF);
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 abs(half3 x)
        {
            return ashalf(asushort(x) & 0x7FFF);
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 abs(half4 x)
        {
            return ashalf(asushort(x) & 0x7FFF);
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 abs(half8 x)
        {
            return ashalf(asushort(x) & 0x7FFF);
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 abs(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(x, new v256(maxmath.bitmask32(31)));
            }
            else
            {
                return new float8(math.abs(x.v4_0), math.abs(x.v4_4));
            }
        }
    }
}