using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise sign of a float8 value. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sign(float8 x)
        {
            v256 exp = new v256(math.asfloat(0x3F80_0000));

            float8 zeroMask = Avx.mm256_cmp_ps(x, default(v256), (int)Avx.CMP.EQ_OQ);
            float8 negativeMask = Avx.mm256_cmp_ps(x, default(v256), (int)Avx.CMP.LT_OS);
            float8 positiveMask = Avx.mm256_cmp_ps(x, default(v256), (int)Avx.CMP.GT_OS);

            negativeMask = Avx.mm256_and_ps(negativeMask, exp);
            positiveMask = Avx.mm256_and_ps(positiveMask, exp);


            return Avx.mm256_blendv_ps(positiveMask - negativeMask, x, zeroMask);
        }


        /// <summary>       Returns the componentwise sign of an sbyte2. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 sign(sbyte2 x)
        {
            return ((sbyte2)Sse2.cmpgt_epi8(x, default(v128)) & 1) + Sse2.cmpgt_epi8(default(v128), x);
        }

        /// <summary>       Returns the componentwise sign of an sbyte3. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 sign(sbyte3 x)
        {
            return ((sbyte3)Sse2.cmpgt_epi8(x, default(v128)) & 1) + Sse2.cmpgt_epi8(default(v128), x);
        }

        /// <summary>       Returns the componentwise sign of an sbyte4. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 sign(sbyte4 x)
        {
            return ((sbyte4)Sse2.cmpgt_epi8(x, default(v128)) & 1) + Sse2.cmpgt_epi8(default(v128), x);
        }

        /// <summary>       Returns the componentwise sign of an sbyte8. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 sign(sbyte8 x)
        {
            return ((sbyte8)Sse2.cmpgt_epi8(x, default(v128)) & 1) + Sse2.cmpgt_epi8(default(v128), x);
        }

        /// <summary>       Returns the componentwise sign of an sbyte16. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 sign(sbyte16 x)
        {
            return ((sbyte16)Sse2.cmpgt_epi8(x, default(v128)) & 1) + Sse2.cmpgt_epi8(default(v128), x);
        }

        /// <summary>       Returns the componentwise sign of an sbyte32. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 sign(sbyte32 x)
        {
            return ((sbyte32)Avx2.mm256_cmpgt_epi8(x, default(v256)) & 1) + Avx2.mm256_cmpgt_epi8(default(v256), x);
        }


        /// <summary>       Returns the componentwise sign of a short2. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 sign(short2 x)
        {
            return (x >> 15) | (short2)((ushort2)(-x) >> 15);
        }

        /// <summary>       Returns the componentwise sign of a short3. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 sign(short3 x)
        {
            return (x >> 15) | (short3)((ushort3)(-x) >> 15);
        }

        /// <summary>       Returns the componentwise sign of a short4. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 sign(short4 x)
        {
            return (x >> 15) | (short4)((ushort4)(-x) >> 15);
        }

        /// <summary>       Returns the componentwise sign of a short8. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 sign(short8 x)
        {
            return (x >> 15) | (short8)((ushort8)(-x) >> 15);
        }

        /// <summary>       Returns the componentwise sign of a short16. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 sign(short16 x)
        {
            return (x >> 15) | (short16)((ushort16)(-x) >> 15);
        }


        /// <summary>       Returns the sign of an int value. 1 for a positive int, 0 for zero and -1 for a negative int.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int sign(int x)
        {
            return (x >> 31) | (int)((uint)(-x) >> 31);
        }

        /// <summary>       Returns the componentwise sign of an int2. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(int2 x)
        {
            return (x >> 31) | (int2)((uint2)(-x) >> 31);
        }

        /// <summary>       Returns the componentwise sign of an int3. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(int3 x)
        {
            return (x >> 31) | (int3)((uint3)(-x) >> 31);
        }

        /// <summary>       Returns the componentwise sign of an int4. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(int4 x)
        {
            return (x >> 31) | (int4)((uint4)(-x) >> 31);
        }

        /// <summary>       Returns the componentwise sign of an int8. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 sign(int8 x)
        {
            return (x >> 31) | (int8)((uint8)(-x) >> 31);
        }


        /// <summary>       Returns the sign of a long value. 1 for a positive long, 0 for zero and -1 for a negative long.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1L, 1L)]
        public static long sign(long x)
        {
            return (x >> 63) | (long)((ulong)(-x) >> 63);
        }

        /// <summary>       Returns the componentwise sign of a long2. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 sign(long2 x)
        {
            return (x >> 63) | (long2)((ulong2)(-x) >> 63);
        }

        /// <summary>       Returns the componentwise sign of a long3. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 sign(long3 x)
        {
            return (x >> 63) | (long3)((ulong3)(-x) >> 63);
        }

        /// <summary>       Returns the componentwise sign of a long4. 1 for positive components, 0 for zero components and -1 for a negative components.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 sign(long4 x)
        {
            return (x >> 63) | (long4)((ulong4)(-x) >> 63);
        }
    }
}