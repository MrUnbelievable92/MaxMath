using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shl(int2 x, int2 n)
        {
            v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shl(int3 x, int3 n)
        {
            v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shl(int4 x, int4 n)
        {
            v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shl(int8 x, int8 n)
        {
            return Avx2.mm256_sllv_epi32(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shl(uint2 x, uint2 n)
        {
            v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shl(uint3 x, uint3 n)
        {
            v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shl(uint4 x, uint4 n)
        {
            v128 temp = Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shl(uint8 x, uint8 n)
        {
            return Avx2.mm256_sllv_epi32(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shl(long2 x, long2 n)
        {
            return Avx2.sllv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shl(long3 x, long3 n)
        {
            return Avx2.mm256_sllv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shl(long4 x, long4 n)
        {
            return Avx2.mm256_sllv_epi64(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shl(ulong2 x, ulong2 n)
        {
            return Avx2.sllv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shl(ulong3 x, ulong3 n)
        {
            return Avx2.mm256_sllv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift left operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shl(ulong4 x, ulong4 n)
        {
            return Avx2.mm256_sllv_epi64(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shrl(int2 x, int2 n)
        {
            v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shrl(int3 x, int3 n)
        {
            v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shrl(int4 x, int4 n)
        {
            v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shrl(int8 x, int8 n)
        {
            return Avx2.mm256_srlv_epi32(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shrl(uint2 x, uint2 n)
        {
            v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shrl(uint3 x, uint3 n)
        {
            v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shrl(uint4 x, uint4 n)
        {
            v128 temp = Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shrl(uint8 x, uint8 n)
        {
            return Avx2.mm256_srlv_epi32(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shrl(long2 x, long2 n)
        {
            return Avx2.srlv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shrl(long3 x, long3 n)
        {
            return Avx2.mm256_srlv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shrl(long4 x, long4 n)
        {
            return Avx2.mm256_srlv_epi64(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shrl(ulong2 x, ulong2 n)
        {
            return Avx2.srlv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shrl(ulong3 x, ulong3 n)
        {
            return Avx2.mm256_srlv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (logical) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shrl(ulong4 x, ulong4 n)
        {
            return Avx2.mm256_srlv_epi64(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shra(int2 x, int2 n)
        {
            v128 temp = Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

            return *(int2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shra(int3 x, int3 n)
        {
            v128 temp = Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

            return *(int3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shra(int4 x, int4 n)
        {
            v128 temp = Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

            return *(int4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shra(int8 x, int8 n)
        {
            return Avx2.mm256_srav_epi32(x, n);
        }


        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shra(long2 x, long2 n)
        {
            long2 mask = Sse2.and_si128(Sse4_2.cmpgt_epi64(n, default(v128)),
                                        Sse4_2.cmpgt_epi64(default(v128), x));

            mask = Avx2.sllv_epi64(mask, (64L - n));

            return mask | Avx2.srlv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shra(long3 x, long3 n)
        {
            long3 mask = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(n, default(v256)),
                                              Avx2.mm256_cmpgt_epi64(default(v256), x));

            mask = Avx2.mm256_sllv_epi64(mask, (64L - n));

            return mask | Avx2.mm256_srlv_epi64(x, n);
        }

        /// <summary>       Returns the result of a componentwise bitshift right (arithmetic) operation of x by the corresponding value in n       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shra(long4 x, long4 n)
        {
            long4 mask = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(n, default(v256)),
                                              Avx2.mm256_cmpgt_epi64(default(v256), x));

            mask = Avx2.mm256_sllv_epi64(mask, (64L - n));

            return mask | Avx2.mm256_srlv_epi64(x, n);
        }
    }
}