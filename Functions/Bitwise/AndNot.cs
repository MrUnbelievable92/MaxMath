using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two byte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 andnot(byte2 lhs, byte2 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two byte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 andnot(byte3 lhs, byte3 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two byte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 andnot(byte4 lhs, byte4 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two byte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 andnot(byte8 lhs, byte8 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two byte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 andnot(byte16 lhs, byte16 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two byte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 andnot(byte32 lhs, byte32 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two sbyte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 andnot(sbyte2 lhs, sbyte2 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two sbyte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 andnot(sbyte3 lhs, sbyte3 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two sbyte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 andnot(sbyte4 lhs, sbyte4 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two sbyte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 andnot(sbyte8 lhs, sbyte8 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two sbyte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 andnot(sbyte16 lhs, sbyte16 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two sbyte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 andnot(sbyte32 lhs, sbyte32 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ushort2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 andnot(ushort2 lhs, ushort2 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ushort3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 andnot(ushort3 lhs, ushort3 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ushort4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 andnot(ushort4 lhs, ushort4 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ushort8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 andnot(ushort8 lhs, ushort8 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ushort16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 andnot(ushort16 lhs, ushort16 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two short2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 andnot(short2 lhs, short2 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two short3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 andnot(short3 lhs, short3 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two short4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 andnot(short4 lhs, short4 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two short8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 andnot(short8 lhs, short8 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two short16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 andnot(short16 lhs, short16 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the logical AND operation between lhs and NOT(rhs) of two int values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int andnot(int lhs, int rhs)
        {
            return lhs & ~rhs;

            //_asm
            //{
            //    andn    eax, edx, ecx
            //}
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two int2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 andnot(int2 lhs, int2 rhs)
        {
            v128 temp = Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(int2*)&temp;
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two int3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 andnot(int3 lhs, int3 rhs)
        {
            v128 temp = Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(int3*)&temp;
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two int4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 andnot(int4 lhs, int4 rhs)
        {
            v128 temp = Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(int4*)&temp;
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two int8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 andnot(int8 lhs, int8 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the logical AND operation between lhs and NOT(rhs) of two uint values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint andnot(uint lhs, uint rhs)
        {
            return lhs & ~rhs;

            //_asm
            //{
            //    andn    eax, edx, ecx
            //}
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two uint2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 andnot(uint2 lhs, uint2 rhs)
        {
            v128 temp = Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(uint2*)&temp;
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two uint3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 andnot(uint3 lhs, uint3 rhs)
        {
            v128 temp = Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(uint3*)&temp;
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two uint4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 andnot(uint4 lhs, uint4 rhs)
        {
            v128 temp = Sse2.andnot_si128(*(v128*)&rhs, *(v128*)&lhs);

            return *(uint4*)&temp;
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two uint8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 andnot(uint8 lhs, uint8 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the logical AND operation between lhs and NOT(rhs) of two long values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long andnot(long lhs, long rhs)
        {
            return lhs & ~rhs;

            //_asm64
            //{
            //    andn    rax, rdx, rcx
            //}
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two long2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 andnot(long2 lhs, long2 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two long3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 andnot(long3 lhs, long3 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two long4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 andnot(long4 lhs, long4 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }


        /// <summary>       Returns the result of the logical AND operation between lhs and NOT(rhs) of two ulong values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong andnot(ulong lhs, ulong rhs)
        {
            return lhs & ~rhs;

            //_asm64
            //{
            //    andn    rax, rdx, rcx
            //}
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ulong2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 andnot(ulong2 lhs, ulong2 rhs)
        {
            return Sse2.andnot_si128(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ulong3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 andnot(ulong3 lhs, ulong3 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between lhs and NOT(rhs) of two ulong4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 andnot(ulong4 lhs, ulong4 rhs)
        {
            return Avx2.mm256_andnot_si256(rhs, lhs);
        }
    }
}