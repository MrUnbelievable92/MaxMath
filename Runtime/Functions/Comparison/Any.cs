using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if any of the components of the input bool2x2 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x2 x)
        {
            return math.any(*(bool4*)&x);
        }

        /// <summary>       Returns true if any of the components of the input bool2x3 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x3 x)
        {
            return any(*(bool3x2*)&x);
        }

        /// <summary>       Returns true if any of the components of the input bool2x4 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x4 x)
        {
            return *(long*)&x != 0L;
        }

        /// <summary>       Returns true if any of the components of the input bool3x2 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x2 x)
        {
            return math.any(x.c0 | x.c1);
        }

        /// <summary>       Returns true if any of the components of the input bool3x3 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns true if any of the components of the input bool3x4 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x4 x)
        {
            return any(*(bool4x3*)&x);
        }

        /// <summary>       Returns true if any of the components of the input bool4x2 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x2 x)
        {
            return *(long*)&x != 0L;
        }

        /// <summary>       Returns true if any of the components of the input bool4x3 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns true if any of the components of the input bool4x4 matrix is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x4 x)
        {
            return any(*(bool16*)&x);
        }

        /// <summary>       Returns true if any of the components of the input bool8 vector is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return *(long*)&x != 0L;
        }

        /// <summary>       Returns true if any of the components of the input bool16 vector is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool16 x)
        {
            return Sse2.movemask_epi8(Sse2.slli_epi16(x, 7)) != 0;
        }

        /// <summary>       Returns true if any of the components of the input bool32 vector is true, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool32 x)
        {
            return Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(x, 7)) != 0;
        }


        /// <summary>       Returns true if any of the components of the input byte2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte2 x)
        {
            return 0 != Sse2.extract_epi16(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input byte3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte3 x)
        {
            return 0 != (bitmask32(24) & Sse4_1.extract_epi32(x, 0));
        }

        /// <summary>       Returns true if any of the components of the input byte4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte4 x)
        {
            return 0 != Sse4_1.extract_epi32(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input byte8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte8 x)
        {
            return 0 != Sse4_1.extract_epi64(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input byte16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte16 x)
        {
            return bitmask32(16 * sizeof(byte)) != Sse2.movemask_epi8(Sse2.cmpeq_epi8(x, default(v128)));
        }

        /// <summary>       Returns true if any of the components of the input byte32 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte32 x)
        {
            return -1 != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input sbyte2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte2 x)
        {
            return 0 != Sse2.extract_epi16(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input sbyte3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte3 x)
        {
            return 0 != (bitmask32(24) & Sse4_1.extract_epi32(x, 0));
        }

        /// <summary>       Returns true if any of the components of the input sbyte4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte4 x)
        {
            return 0 != Sse4_1.extract_epi32(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input sbyte8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte8 x)
        {
            return 0 != Sse4_1.extract_epi64(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input sbyte16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte16 x)
        {
            return bitmask32(16 * sizeof(sbyte)) != Sse2.movemask_epi8(Sse2.cmpeq_epi8(x, default(v128)));
        }

        /// <summary>       Returns true if any of the components of the input sbyte32 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte32 x)
        {
            return -1 != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input short2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short2 x)
        {
            return 0 != Sse4_1.extract_epi32(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input short3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short3 x)
        {
            return 0 != (bitmask64(48L) & Sse4_1.extract_epi64(x, 0));
        }

        /// <summary>       Returns true if any of the components of the input short4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short4 x)
        {
            return 0 != Sse4_1.extract_epi64(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input short8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short8 x)
        {
            return bitmask32(8 * sizeof(short)) != Sse2.movemask_epi8(Sse2.cmpeq_epi16(x, default(v128)));
        }

        /// <summary>       Returns true if any of the components of the input short16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short16 x)
        {
            return -1 != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input ushort2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort2 x)
        {
            return 0 != Sse4_1.extract_epi32(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input ushort3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort3 x)
        {
            return 0 != (bitmask64(48L) & Sse4_1.extract_epi64(x, 0));
        }

        /// <summary>       Returns true if any of the components of the input ushort4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort4 x)
        {
            return 0 != Sse4_1.extract_epi64(x, 0);
        }

        /// <summary>       Returns true if any of the components of the input ushort8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort8 x)
        {
            return bitmask32(8 * sizeof(ushort)) != Sse2.movemask_epi8(Sse2.cmpeq_epi16(x, default(v128)));
        }

        /// <summary>       Returns true if any of the components of the input ushort16 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort16 x)
        {
            return -1 != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input int8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(int8 x)
        {
            return bitmask32(8) != Avx.mm256_movemask_ps(Avx2.mm256_cmpeq_epi32(x, default(v256)));
        }

        /// <summary>       Returns true if any of the components of the input uint8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(uint8 x)
        {
            return bitmask32(8) != Avx.mm256_movemask_ps(Avx2.mm256_cmpeq_epi32(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input long2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long2 x)
        {
            return bitmask32(2) != Sse2.movemask_pd(Sse4_1.cmpeq_epi64(x, default(v128)));
        }

        /// <summary>       Returns true if any of the components of the input long3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long3 x)
        {
            return bitmask32(3) != (bitmask32(3) & Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(x, default(v256))));
        }

        /// <summary>       Returns true if any of the components of the input long4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long4 x)
        {
            return bitmask32(4) != Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input ulong2 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong2 x)
        {
            return bitmask32(2) != Sse2.movemask_pd(Sse4_1.cmpeq_epi64(x, default(v128)));
        }

        /// <summary>       Returns true if any of the components of the input ulong3 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong3 x)
        {
            return bitmask32(3) != (bitmask32(3) & Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(x, default(v256))));
        }

        /// <summary>       Returns true if any of the components of the input ulong4 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong4 x)
        {
            return bitmask32(4) != Avx.mm256_movemask_pd(Avx2.mm256_cmpeq_epi64(x, default(v256)));
        }


        /// <summary>       Returns true if any of the components of the input float8 vector is non-zero, false otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(float8 x)
        {
            return bitmask32(8) != Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(x, default(float8), (int)Avx.CMP.EQ_OQ));
        }
    }
}