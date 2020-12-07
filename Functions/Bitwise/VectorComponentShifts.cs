using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shl(int2 x, int2 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);

            v128 temp = X86.Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shl(int3 x, int3 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);
Assert.IsDefinedBitShift<int>(n.z);

            v128 temp = X86.Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shl(int4 x, int4 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);
Assert.IsDefinedBitShift<int>(n.z);
Assert.IsDefinedBitShift<int>(n.w);

            v128 temp = X86.Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shl(int8 x, int8 n)
        {
Assert.IsDefinedBitShift<int>(n.x0);
Assert.IsDefinedBitShift<int>(n.x1);
Assert.IsDefinedBitShift<int>(n.x2);
Assert.IsDefinedBitShift<int>(n.x3);
Assert.IsDefinedBitShift<int>(n.x4);
Assert.IsDefinedBitShift<int>(n.x5);
Assert.IsDefinedBitShift<int>(n.x6);
Assert.IsDefinedBitShift<int>(n.x7);

            return X86.Avx2.mm256_sllv_epi32(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shl(uint2 x, uint2 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x);
Assert.IsDefinedBitShift<uint>((int)n.y);

            v128 temp = X86.Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shl(uint3 x, uint3 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x);
Assert.IsDefinedBitShift<uint>((int)n.y);
Assert.IsDefinedBitShift<uint>((int)n.z);

            v128 temp = X86.Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shl(uint4 x, uint4 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x);
Assert.IsDefinedBitShift<uint>((int)n.y);
Assert.IsDefinedBitShift<uint>((int)n.z);
Assert.IsDefinedBitShift<uint>((int)n.w);

            v128 temp = X86.Avx2.sllv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shl(uint8 x, uint8 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x0);
Assert.IsDefinedBitShift<uint>((int)n.x1);
Assert.IsDefinedBitShift<uint>((int)n.x2);
Assert.IsDefinedBitShift<uint>((int)n.x3);
Assert.IsDefinedBitShift<uint>((int)n.x4);
Assert.IsDefinedBitShift<uint>((int)n.x5);
Assert.IsDefinedBitShift<uint>((int)n.x6);
Assert.IsDefinedBitShift<uint>((int)n.x7);

            return X86.Avx2.mm256_sllv_epi32(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shl(long2 x, long2 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);

            return X86.Avx2.sllv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shl(long3 x, long3 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);

            return X86.Avx2.mm256_sllv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shl(long4 x, long4 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);
Assert.IsDefinedBitShift<long>((int)n.w);

            return X86.Avx2.mm256_sllv_epi64(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shl(ulong2 x, ulong2 n)
        {
Assert.IsDefinedBitShift<ulong>((int)n.x);
Assert.IsDefinedBitShift<ulong>((int)n.y);

            return X86.Avx2.sllv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shl(ulong3 x, ulong3 n)
        {
Assert.IsDefinedBitShift<ulong>((int)n.x);
Assert.IsDefinedBitShift<ulong>((int)n.y);
Assert.IsDefinedBitShift<ulong>((int)n.z);

            return X86.Avx2.mm256_sllv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shl(ulong4 x, ulong4 n)
        {
Assert.IsDefinedBitShift<ulong>((int)n.x);
Assert.IsDefinedBitShift<ulong>((int)n.y);
Assert.IsDefinedBitShift<ulong>((int)n.z);
Assert.IsDefinedBitShift<ulong>((int)n.w);

            return X86.Avx2.mm256_sllv_epi64(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shr_l(int2 x, int2 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);

            v128 temp = X86.Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shr_l(int3 x, int3 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);
Assert.IsDefinedBitShift<int>(n.z);

            v128 temp = X86.Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shr_l(int4 x, int4 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);
Assert.IsDefinedBitShift<int>(n.z);
Assert.IsDefinedBitShift<int>(n.w);

            v128 temp = X86.Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(int4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shr_l(int8 x, int8 n)
        {
Assert.IsDefinedBitShift<int>(n.x0);
Assert.IsDefinedBitShift<int>(n.x1);
Assert.IsDefinedBitShift<int>(n.x2);
Assert.IsDefinedBitShift<int>(n.x3);
Assert.IsDefinedBitShift<int>(n.x4);
Assert.IsDefinedBitShift<int>(n.x5);
Assert.IsDefinedBitShift<int>(n.x6);
Assert.IsDefinedBitShift<int>(n.x7);

            return X86.Avx2.mm256_srlv_epi32(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shr_l(uint2 x, uint2 n)
        {              
Assert.IsDefinedBitShift<uint>((int)n.x);
Assert.IsDefinedBitShift<uint>((int)n.y);

            v128 temp = X86.Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shr_l(uint3 x, uint3 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x);
Assert.IsDefinedBitShift<uint>((int)n.y);
Assert.IsDefinedBitShift<uint>((int)n.z);

            v128 temp = X86.Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shr_l(uint4 x, uint4 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x);
Assert.IsDefinedBitShift<uint>((int)n.y);
Assert.IsDefinedBitShift<uint>((int)n.z);
Assert.IsDefinedBitShift<uint>((int)n.w);

            v128 temp = X86.Avx2.srlv_epi32(*(v128*)&x, *(v128*)&n);

            return *(uint4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 shr_l(uint8 x, uint8 n)
        {
Assert.IsDefinedBitShift<uint>((int)n.x0);
Assert.IsDefinedBitShift<uint>((int)n.x1);
Assert.IsDefinedBitShift<uint>((int)n.x2);
Assert.IsDefinedBitShift<uint>((int)n.x3);
Assert.IsDefinedBitShift<uint>((int)n.x4);
Assert.IsDefinedBitShift<uint>((int)n.x5);
Assert.IsDefinedBitShift<uint>((int)n.x6);
Assert.IsDefinedBitShift<uint>((int)n.x7);

            return X86.Avx2.mm256_srlv_epi32(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shr_l(long2 x, long2 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);

            return X86.Avx2.srlv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shr_l(long3 x, long3 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);

            return X86.Avx2.mm256_srlv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shr_l(long4 x, long4 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);
Assert.IsDefinedBitShift<long>((int)n.w);

            return X86.Avx2.mm256_srlv_epi64(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shr_l(ulong2 x, ulong2 n)
        {
Assert.IsDefinedBitShift<ulong>((int)n.x);
Assert.IsDefinedBitShift<ulong>((int)n.y);

            return X86.Avx2.srlv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shr_l(ulong3 x, ulong3 n)
        {
Assert.IsDefinedBitShift<ulong>((int)n.x);
Assert.IsDefinedBitShift<ulong>((int)n.y);
Assert.IsDefinedBitShift<ulong>((int)n.z);

            return X86.Avx2.mm256_srlv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shr_l(ulong4 x, ulong4 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);
Assert.IsDefinedBitShift<long>((int)n.w);

            return X86.Avx2.mm256_srlv_epi64(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shr_a(int2 x, int2 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);

            v128 temp = X86.Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

            return *(int2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shr_a(int3 x, int3 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);
Assert.IsDefinedBitShift<int>(n.z);

            v128 temp = X86.Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

            return *(int3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shr_a(int4 x, int4 n)
        {
Assert.IsDefinedBitShift<int>(n.x);
Assert.IsDefinedBitShift<int>(n.y);
Assert.IsDefinedBitShift<int>(n.z);
Assert.IsDefinedBitShift<int>(n.w);

            v128 temp = X86.Avx2.srav_epi32(*(v128*)&x, *(v128*)&n);

            return *(int4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 shr_a(int8 x, int8 n)
        {
Assert.IsDefinedBitShift<int>(n.x0);
Assert.IsDefinedBitShift<int>(n.x1);
Assert.IsDefinedBitShift<int>(n.x2);
Assert.IsDefinedBitShift<int>(n.x3);
Assert.IsDefinedBitShift<int>(n.x4);
Assert.IsDefinedBitShift<int>(n.x5);
Assert.IsDefinedBitShift<int>(n.x6);
Assert.IsDefinedBitShift<int>(n.x7);

            return X86.Avx2.mm256_srav_epi32(x, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shr_a(long2 x, long2 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);

            long2 mask = (long2)X86.Sse4_2.cmpgt_epi64(n, default(long2))
                         &
                         (long2)X86.Sse4_2.cmpgt_epi64(default(long2), x);

            mask = X86.Avx2.sllv_epi64(mask, (64L - n));

            return mask | X86.Avx2.srlv_epi64(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shr_a(long3 x, long3 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);

            return shr_a((long4)(v256)x, (long4)(v256)n).xyz;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shr_a(long4 x, long4 n)
        {
Assert.IsDefinedBitShift<long>((int)n.x);
Assert.IsDefinedBitShift<long>((int)n.y);
Assert.IsDefinedBitShift<long>((int)n.z);
Assert.IsDefinedBitShift<long>((int)n.w);

            long4 mask = (long4)X86.Avx2.mm256_cmpgt_epi64(n, default(long4))
                         &
                         (long4)X86.Avx2.mm256_cmpgt_epi64(default(long4), x);

            mask = X86.Avx2.mm256_sllv_epi64(mask, (64L - n));

            return mask | X86.Avx2.mm256_srlv_epi64(x, n);
        }
    }
}