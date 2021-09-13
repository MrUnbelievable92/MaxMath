using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool2x2"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool2x3"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool2x4"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x4 x)
        {
            return math.all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool3x2"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool3x3"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool3x4"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x4 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool4x2"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x2 x)
        {
            return math.all(x.c0 & x.c1);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool4x3"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x3 x)
        {
            return math.all(x.c0 & x.c1 & x.c2);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="bool4x4"/> matrix are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x4 x)
        {
            return math.all(x.c0 & x.c1 & x.c2 & x.c3);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.bool8"/> are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.bool16"/> are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.bool32"/> are <see langword="true" />, <see langword="false" /> otherwise.       </summary>
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


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.byte2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.byte3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.byte4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.byte8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.byte16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.byte32"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.sbyte2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte2 x)
        {
            return all((byte2)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.sbyte3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte3 x)
        {
            return all((byte3)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.sbyte4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte4 x)
        {
            return all((byte4)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.sbyte8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte8 x)
        {
            return all((byte8)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.sbyte16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte16 x)
        {
            return all((byte16)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.sbyte32"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(sbyte32 x)
        {
            return all((byte32)x);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.short2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.short3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.short4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.short8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.short16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ushort2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort2 x)
        {
            return all((short2)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ushort3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort3 x)
        {
            return all((short3)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ushort4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort4 x)
        {
            return all((short4)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ushort8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort8 x)
        {
            return all((short8)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ushort16"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ushort16 x)
        {
            return all((short16)x);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.int8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.uint8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(uint8 x)
        {
            return all((int8)x);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.long2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0 == Sse2.movemask_epi8(Operator.equals_mask_long(x, default(v128)));
            }
            else
            {
                return math.all(x != 0);
            }
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.long3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.long4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ulong2"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong2 x)
        {
            return all((long2)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ulong3"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong3 x)
        {
            return all((long3)x);
        }

        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.ulong4"/> is non-zero, <see langword="false" /> otherwise.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(ulong4 x)
        {
            return all((long4)x);
        }


        /// <summary>       Returns <see langword="true" /> if all of the components of the input <see cref="MaxMath.float8"/> is non-zero, <see langword="false" /> otherwise.      </summary>
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