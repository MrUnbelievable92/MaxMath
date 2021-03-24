using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two byte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 andnot(byte2 left, byte2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two byte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 andnot(byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two byte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 andnot(byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two byte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 andnot(byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two byte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 andnot(byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two byte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 andnot(byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new byte32(andnot(left.v16_0, right.v16_0), andnot(left.v16_16, right.v16_16));
            }
        }


        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two sbyte2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 andnot(sbyte2 left, sbyte2 right)
        {
            return (sbyte2)andnot((byte2)left, (byte2)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two sbyte3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 andnot(sbyte3 left, sbyte3 right)
        {
            return (sbyte3)andnot((byte3)left, (byte3)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two sbyte4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 andnot(sbyte4 left, sbyte4 right)
        {
            return (sbyte4)andnot((byte4)left, (byte4)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two sbyte8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 andnot(sbyte8 left, sbyte8 right)
        {
            return (sbyte8)andnot((byte8)left, (byte8)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two sbyte16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 andnot(sbyte16 left, sbyte16 right)
        {
            return (sbyte16)andnot((byte16)left, (byte16)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two sbyte32 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 andnot(sbyte32 left, sbyte32 right)
        {
            return (sbyte32)andnot((byte32)left, (byte32)right);
        }


        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ushort2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 andnot(ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ushort3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 andnot(ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ushort4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 andnot(ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ushort8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 andnot(ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ushort16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 andnot(ushort16 left, ushort16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new ushort16(andnot(left.v8_0, right.v8_0), andnot(left.v8_8, right.v8_8));
            }
        }


        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two short2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 andnot(short2 left, short2 right)
        {
            return (short2)andnot((ushort2)left, (ushort2)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two short3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 andnot(short3 left, short3 right)
        {
            return (short3)andnot((ushort3)left, (ushort3)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two short4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 andnot(short4 left, short4 right)
        {
            return (short4)andnot((ushort4)left, (ushort4)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two short8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 andnot(short8 left, short8 right)
        {
            return (short8)andnot((ushort8)left, (ushort8)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two short16 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 andnot(short16 left, short16 right)
        {
            return (short16)andnot((ushort16)left, (ushort16)right);
        }


        /// <summary>       Returns the result of the logical AND operation between left and NOT(right) of two int values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int andnot(int left, int right)
        {
            return (int)andnot((uint)left, (uint)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two int2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 andnot(int2 left, int2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Sse2.andnot_si128(*(v128*)&right, *(v128*)&left);

                return *(int2*)&temp;
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two int3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 andnot(int3 left, int3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Sse2.andnot_si128(*(v128*)&right, *(v128*)&left);

                return *(int3*)&temp;
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two int4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 andnot(int4 left, int4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Sse2.andnot_si128(*(v128*)&right, *(v128*)&left);

                return *(int4*)&temp;
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two int8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 andnot(int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new int8(andnot(left.v4_0, right.v4_0), andnot(left.v4_4, right.v4_4));
            }
        }


        /// <summary>       Returns the result of the logical AND operation between left and NOT(right) of two uint values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint andnot(uint left, uint right)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.andn_u32(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two uint2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 andnot(uint2 left, uint2 right)
        {
            return (uint2)andnot((int2)left, (int2)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two uint3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 andnot(uint3 left, uint3 right)
        {
            return (uint3)andnot((int3)left, (int3)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two uint4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 andnot(uint4 left, uint4 right)
        {
            return (uint4)andnot((int4)left, (int4)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two uint8 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 andnot(uint8 left, uint8 right)
        {
            return (uint8)andnot((int8)left, (int8)right);
        }


        /// <summary>       Returns the result of the logical AND operation between left and NOT(right) of two long values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long andnot(long left, long right)
        {
            return (long)andnot((ulong)left, (ulong)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two long2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 andnot(long2 left, long2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two long3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 andnot(long3 left, long3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new long3(andnot(left.xy, right.xy), andnot(left.z, right.z));
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two long4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 andnot(long4 left, long4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(right, left);
            }
            else
            {
                return new long4(andnot(left.xy, right.xy), andnot(left.zw, right.zw));
            }
        }


        /// <summary>       Returns the result of the logical AND operation between left and NOT(right) of two ulong values.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong andnot(ulong left, ulong right)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.andn_u64(right, left);
            }
            else
            {
                return left & ~right;
            }
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ulong2 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 andnot(ulong2 left, ulong2 right)
        {
            return (ulong2)andnot((long2)left, (long2)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ulong3 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 andnot(ulong3 left, ulong3 right)
        {
            return (ulong3)andnot((long3)left, (long3)right);
        }

        /// <summary>       Returns the result of the componentwise logical AND operation between left and NOT(right) of two ulong4 vectors.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 andnot(ulong4 left, ulong4 right)
        {
            return (ulong4)andnot((long4)left, (long4)right);
        }
    }
}