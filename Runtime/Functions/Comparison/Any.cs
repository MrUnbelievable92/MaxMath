using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool2x2"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x2 x)
        {
            return math.any(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool2x3"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool2x4"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x4 x)
        {
            return math.any(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool3x2"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x2 x)
        {
            return math.any(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool3x3"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool3x4"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x4 x)
        {
            return math.any(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool4x2"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x2 x)
        {
            return math.any(x.c0 | x.c1);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool4x3"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x3 x)
        {
            return math.any(x.c0 | x.c1 | x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="bool4x4"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x4 x)
        {
            return math.any(x.c0 | x.c1 | x.c2 | x.c3);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.bool8"/> is true, <see langword="false" /> otherwise.      </summary>
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

            if (Sse2.IsSse2Supported)
            {
                return ((v128)x).ULong0 != 0;
            }
            else
            {
                return *(long*)&x != 0;
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.bool16"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.movemask_epi8(Sse2.slli_epi16(x, 7)) != 0;
            }
            else
            {
                return any(x.v8_0) | any(x.v8_8);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.bool32"/> is true, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(x, 7)) != 0;
            }
            else
            {
                return any(x.v16_0) | any(x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.byte2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != Sse2.extract_epi16(x, 0);
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.byte3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != (bitmask32(24) & ((v128)x).UInt0);
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.byte4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != ((v128)x).UInt0;
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.byte8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != ((v128)x).ULong0;
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.byte16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return bitmask32(16 * sizeof(byte)) != Sse2.movemask_epi8(Sse2.cmpeq_epi8(x, default(v128)));
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.byte32"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return -1 != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(x, default(v256)));
            }
            else
            {
                return any(x.v16_0) & any(x.v16_16);
            }
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.sbyte2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte2 x)
        {
            return any((byte2)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.sbyte3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte3 x)
        {
            return any((byte3)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.sbyte4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte4 x)
        {
            return any((byte4)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.sbyte8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte8 x)
        {
            return any((byte8)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.sbyte16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte16 x)
        {
            return any((byte16)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.sbyte32"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(sbyte32 x)
        {
            return any((byte32)x);
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.short2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != ((v128)x).UInt0;
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.short3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != (bitmask64(48ul) & ((v128)x).ULong0);
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.short4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 != ((v128)x).ULong0;
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.short8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return bitmask32(8 * sizeof(short)) != Sse2.movemask_epi8(Sse2.cmpeq_epi16(x, default(v128)));
            }
            else
            {
                return any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.short16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return -1 != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi16(x, default(v256)));
            }
            else
            {
                return any(x.v8_0) & any(x.v8_8);
            }
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ushort2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort2 x)
        {
            return any((short2)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ushort3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort3 x)
        {
            return any((short3)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ushort4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort4 x)
        {
            return any((short4)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ushort8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort8 x)
        {
            return any((short8)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ushort16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ushort16 x)
        {
            return any((short16)x);
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.int8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return bitmask32(8 * sizeof(int)) != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(x, default(v256)));
            }
            else
            {
                return math.any(x.v4_0) & math.any(x.v4_4);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.uint8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(uint8 x)
        {
            return any((int8)x);
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.long2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return bitmask32(2 * sizeof(long)) != Sse2.movemask_epi8(Operator.equals_mask_long(x, default(v128)));
            }
            else
            {
                return math.any(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.long3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return bitmask32(3 * sizeof(long)) != (bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(x, default(v256))));
            }
            else
            {
                return any(x.xy) | (x.z != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.long4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return bitmask32(4 * sizeof(long)) != Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(x, default(v256)));
            }
            else
            {
                return any(x.xy) | any(x.zw);
            }
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ulong2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong2 x)
        {
            return any((long2)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ulong3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong3 x)
        {
            return any((long3)x);
        }

        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.ulong4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(ulong4 x)
        {
            return any((long4)x);
        }


        /// <summary>       Returns <see langword="true" /> if any of the components of the input <see cref="MaxMath.float8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return bitmask32(8) != Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(x, default(float8), (int)Avx.CMP.EQ_OQ));
            }
            else
            {
                return math.any(x.v4_0) | math.any(x.v4_4);
            }
        }
    }
}