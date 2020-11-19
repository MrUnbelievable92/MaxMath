using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 andn(byte2 lhs, byte2 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 andn(byte3 lhs, byte3 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 andn(byte4 lhs, byte4 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 andn(byte8 lhs, byte8 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 andn(byte16 lhs, byte16 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 andn(byte32 lhs, byte32 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 andn(sbyte2 lhs, sbyte2 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 andn(sbyte3 lhs, sbyte3 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 andn(sbyte4 lhs, sbyte4 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 andn(sbyte8 lhs, sbyte8 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 andn(sbyte16 lhs, sbyte16 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 andn(sbyte32 lhs, sbyte32 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 andn(ushort2 lhs, ushort2 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 andn(ushort3 lhs, ushort3 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 andn(ushort4 lhs, ushort4 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 andn(ushort8 lhs, ushort8 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 andn(ushort16 lhs, ushort16 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 andn(short2 lhs, short2 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 andn(short3 lhs, short3 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 andn(short4 lhs, short4 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 andn(short8 lhs, short8 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 andn(short16 lhs, short16 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int andn(int lhs, int rhs)
        {
            return lhs & ~rhs;

            //_asm
            //{
            //    andn    eax, edx, ecx
            //
            //    ret
            //}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 andn(int2 lhs, int2 rhs)
        {
            v128 temp = X86.Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(int2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 andn(int3 lhs, int3 rhs)
        {
            v128 temp = X86.Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(int3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 andn(int4 lhs, int4 rhs)
        {
            v128 temp = X86.Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(int4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 andn(int8 lhs, int8 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint andn(uint lhs, uint rhs)
        {
            return lhs & ~rhs;

            //_asm
            //{
            //    andn    eax, edx, ecx
            //
            //    ret
            //}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 andn(uint2 lhs, uint2 rhs)
        {
            v128 temp = X86.Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(uint2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 andn(uint3 lhs, uint3 rhs)
        {
            v128 temp = X86.Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(uint3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 andn(uint4 lhs, uint4 rhs)
        {
            v128 temp = X86.Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(uint4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 andn(uint8 lhs, uint8 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long andn(long lhs, long rhs)
        {
            return lhs & ~rhs;

            //_asm
            //{
            //    andn    rax, rdx, rcx
            //
            //    ret
            //}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 andn(long2 lhs, long2 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 andn(long3 lhs, long3 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 andn(long4 lhs, long4 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong andn(ulong lhs, ulong rhs)
        {
            return lhs & ~rhs;

            //_asm
            //{
            //    andn    rax, rdx, rcx
            //
            //    ret
            //}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 andn(ulong2 lhs, ulong2 rhs)
        {
            return X86.Sse2.andnot_si128(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 andn(ulong3 lhs, ulong3 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 andn(ulong4 lhs, ulong4 rhs)
        {
            return X86.Avx2.mm256_andnot_si256(rhs, lhs);
        }
    }
}