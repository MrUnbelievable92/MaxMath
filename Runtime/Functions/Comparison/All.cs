using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if all of the components of the input bool2x2 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns true if all of the components of the input bool2x3 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns true if all of the components of the input bool2x4 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x4 x)
        {
            return math.all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns true if all of the components of the input bool3x2 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns true if all of the components of the input bool3x3 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns true if all of the components of the input bool3x4 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x4 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns true if all of the components of the input bool4x2 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns true if all of the components of the input bool4x3 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns true if all of the components of the input bool4x4 matrix are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x4 x)
        {
            return math.all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns true if all of the components of the input bool8 vector are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Sse2.IsSse2Supported)
            {
                return ((v128)x).ULong0 == 0x0101_0101_0101_0101;
            }
            else
            {
                return *(long*)&x == 0x0101_0101_0101_0101;
            }
        }

        /// <summary>       Returns true if all of the components of the input bool16 vector are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.bitmask32(16) == Sse2.movemask_epi8(Sse2.slli_epi16(x, 7));
            }
            else
            {
                return all(x.v8_0) & all(x.v8_8); 
            }
        }

        /// <summary>       Returns true if all of the components of the input bool32 vector are true, false otherwise.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return uint.MaxValue == (uint)Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(x, 7));
            }
            else
            {
                return all(x.v16_0) & all(x.v16_16);
            }
        }


        /// <summary>       Returns true if all of the components of the input byte2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.extract_epi16(Sse2.cmpeq_epi8(x, default(v128)), 0);
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input byte3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (bitmask32(24) & Sse2.cmpeq_epi8(x, default(v128)).UInt0);
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input byte4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.cmpeq_epi8(x, default(v128)).UInt0;
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input byte8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.cmpeq_epi8(x, default(v128)).ULong0;
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input byte16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi8(x, default(v128)));
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input byte32 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(x, default(v256)));
            }
            else
            {
                return all(x.v16_0) & all(x.v16_16);
            }
        }


        /// <summary>       Returns true if all of the components of the input sbyte2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte2 x)
        {
            return all((byte2)x);
        }

        /// <summary>       Returns true if all of the components of the input sbyte3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte3 x)
        {
            return all((byte3)x);
        }

        /// <summary>       Returns true if all of the components of the input sbyte4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte4 x)
        {
            return all((byte4)x);
        }

        /// <summary>       Returns true if all of the components of the input sbyte8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte8 x)
        {
            return all((byte8)x);
        }

        /// <summary>       Returns true if all of the components of the input sbyte16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte16 x)
        {
            return all((byte16)x);
        }

        /// <summary>       Returns true if all of the components of the input sbyte32 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte32 x)
        {
            return all((byte32)x);
        }


        /// <summary>       Returns true if all of the components of the input short2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.cmpeq_epi16(x, default(v128)).UInt0;
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input short3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == (bitmask64(48ul) & Sse2.cmpeq_epi16(x, default(v128)).ULong0);
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input short4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.cmpeq_epi16(x, default(v128)).ULong0;
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input short8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse2.cmpeq_epi16(x, default(v128)));
            }
            else
            {
                return all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input short16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(x, default(v256)));
            }
            else
            {
                return all(x.v8_0) & all(x.v8_8);
            }
        }


        /// <summary>       Returns true if all of the components of the input ushort2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort2 x)
        {
            return all((short2)x);
        }

        /// <summary>       Returns true if all of the components of the input ushort3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort3 x)
        {
            return all((short3)x);
        }

        /// <summary>       Returns true if all of the components of the input ushort4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort4 x)
        {
            return all((short4)x);
        }

        /// <summary>       Returns true if all of the components of the input ushort8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort8 x)
        {
            return all((short8)x);
        }

        /// <summary>       Returns true if all of the components of the input ushort16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort16 x)
        {
            return all((short16)x);
        }


        /// <summary>       Returns true if all of the components of the input int8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(x, default(v256)));
            }
            else
            {
                return math.all(x.v4_0) & math.all(x.v4_4);
            }
        }

        /// <summary>       Returns true if all of the components of the input uint8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(uint8 x)
        {
            return all((int8)x);
        }


        /// <summary>       Returns true if all of the components of the input long2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return 0 == Sse2.movemask_epi8(Sse4_1.cmpeq_epi64(x, default(v128)));
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input long3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == (bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(x, default(v256))));
            }
            else
            {
                return all(x.xy) & (x.z != 0);
            }
        }

        /// <summary>       Returns true if all of the components of the input long4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(x, default(v256)));
            }
            else
            {
                return all(x.xy) & all(x.zw);
            }
        }


        /// <summary>       Returns true if all of the components of the input ulong2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong2 x)
        {
            return all((long2)x);
        }

        /// <summary>       Returns true if all of the components of the input ulong3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong3 x)
        {
            return all((long3)x);
        }

        /// <summary>       Returns true if all of the components of the input ulong4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong4 x)
        {
            return all((long4)x);
        }


        /// <summary>       Returns true if all of the components of the input float8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return 0 == Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(x, default(float8), (int)Avx.CMP.EQ_OQ));
            }
            else
            {
                return math.all(x.v4_0) & math.all(x.v4_4);
            }
        }
    }
}