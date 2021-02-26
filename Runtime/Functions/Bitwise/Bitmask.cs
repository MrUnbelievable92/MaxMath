using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitmask32(uint numBits, uint index = 0)
        {
Assert.IsBetween(index, 0u, 32u);
Assert.IsBetween(numBits, 0u, 32u - index);

            // mask
            index = uint.MaxValue << (int)index;

            return (numBits == 32) ? uint.MaxValue : andnot(index, index << (int)numBits);
        }

        /// <summary>       Returns a 32-bit bitmask uint2 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(uint2 numBits, uint2 index = default(uint2))
        {
Assert.IsBetween(index.x, 0u, 32u);
Assert.IsBetween(index.y, 0u, 32u);
Assert.IsBetween(numBits.x, 0u, 32u - index.x);
Assert.IsBetween(numBits.y, 0u, 32u - index.y);

            // mask
            index = shl(uint.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi32(*(v128*)&numBits, new v128(32));

                return (*(uint2*)&isMaxBitsMask) | andnot(index, shl(index, numBits));
            }
            else
            {
                return (uint2)(-toint32(numBits == 32)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 32-bit bitmask uint3 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(uint3 numBits, uint3 index = default(uint3))
        {
Assert.IsBetween(index.x, 0u, 32u);
Assert.IsBetween(index.y, 0u, 32u);
Assert.IsBetween(index.z, 0u, 32u);
Assert.IsBetween(numBits.x, 0u, 32u - index.x);
Assert.IsBetween(numBits.y, 0u, 32u - index.y);
Assert.IsBetween(numBits.z, 0u, 32u - index.z);

            // mask
            index = shl(uint.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi32(*(v128*)&numBits, new v128(32));

                return (*(uint3*)&isMaxBitsMask) | andnot(index, shl(index, numBits));
            }
            else
            {
                return (uint3)(-toint32(numBits == 32)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 32-bit bitmask uint4 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(uint4 numBits, uint4 index = default(uint4))
        {
Assert.IsBetween(index.x, 0u, 32u);
Assert.IsBetween(index.y, 0u, 32u);
Assert.IsBetween(index.z, 0u, 32u);
Assert.IsBetween(index.w, 0u, 32u);
Assert.IsBetween(numBits.x, 0u, 32u - index.x);
Assert.IsBetween(numBits.y, 0u, 32u - index.y);
Assert.IsBetween(numBits.z, 0u, 32u - index.z);
Assert.IsBetween(numBits.w, 0u, 32u - index.w);

            // mask
            index = shl(uint.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse2.cmpeq_epi32(*(v128*)&numBits, new v128(32));

                return (*(uint4*)&isMaxBitsMask) | andnot(index, shl(index, numBits));
            }
            else
            {
                return (uint4)(-toint32(numBits == 32)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 32-bit bitmask uint8 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(uint8 numBits, uint8 index = default(uint8))
        {
Assert.IsBetween(index.x0, 0u, 32u);
Assert.IsBetween(index.x1, 0u, 32u);
Assert.IsBetween(index.x2, 0u, 32u);
Assert.IsBetween(index.x3, 0u, 32u);
Assert.IsBetween(index.x4, 0u, 32u);
Assert.IsBetween(index.x5, 0u, 32u);
Assert.IsBetween(index.x6, 0u, 32u);
Assert.IsBetween(index.x7, 0u, 32u);
Assert.IsBetween(numBits.x0, 0u, 32u - index.x0);
Assert.IsBetween(numBits.x1, 0u, 32u - index.x1);
Assert.IsBetween(numBits.x2, 0u, 32u - index.x2);
Assert.IsBetween(numBits.x3, 0u, 32u - index.x3);
Assert.IsBetween(numBits.x4, 0u, 32u - index.x4);
Assert.IsBetween(numBits.x5, 0u, 32u - index.x5);
Assert.IsBetween(numBits.x6, 0u, 32u - index.x6);
Assert.IsBetween(numBits.x7, 0u, 32u - index.x7);


            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(uint.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi32(numBits, new v256(32));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new uint8(bitmask32(numBits.v4_0, index.v4_0), bitmask32(numBits.v4_4, index.v4_4));
            }
        }


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64(ulong numBits, ulong index = 0)
        {
Assert.IsBetween(index, 0ul, 64ul);
Assert.IsBetween(numBits, 0ul, 64ul - index);

            ulong mask = ulong.MaxValue << (int)index;

            return (numBits == 64) ? ulong.MaxValue : andnot(mask, mask << (int)numBits);
        }

        /// <summary>       Returns a 64-bit bitmask ulong2 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(ulong2 numBits, ulong2 index = default(ulong2))
        {
Assert.IsBetween(index.x, 0ul, 64ul);
Assert.IsBetween(index.y, 0ul, 64ul);
Assert.IsBetween(numBits.x, 0ul, 64ul - index.x);
Assert.IsBetween(numBits.y, 0ul, 64ul - index.y);

            // mask
            index = shl(ulong.MaxValue, index);

            if (Sse2.IsSse2Supported)
            {
                v128 isMaxBitsMask = Sse4_1.cmpeq_epi64(numBits, new v128(64ul));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return (ulong2)(-toint64(numBits == 64)) | andnot(index, shl(index, numBits));
            }
        }

        /// <summary>       Returns a 64-bit bitmask ulong3 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(ulong3 numBits, ulong3 index = default(ulong3))
        {
Assert.IsBetween(index.x, 0ul, 64ul);
Assert.IsBetween(index.y, 0ul, 64ul);
Assert.IsBetween(index.z, 0ul, 64ul);
Assert.IsBetween(numBits.x, 0ul, 64ul - index.x);
Assert.IsBetween(numBits.y, 0ul, 64ul - index.y);
Assert.IsBetween(numBits.z, 0ul, 64ul - index.z);

            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(ulong.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi64(numBits, new v256(64ul));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new ulong3(bitmask64(numBits._xy, index._xy), bitmask64(numBits.z, index.z));
            }
        }

        /// <summary>       Returns a 64-bit bitmask ulong4 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(ulong4 numBits, ulong4 index = default(ulong4))
        {
Assert.IsBetween(index.x, 0ul, 64ul);
Assert.IsBetween(index.y, 0ul, 64ul);
Assert.IsBetween(index.z, 0ul, 64ul);
Assert.IsBetween(index.w, 0ul, 64ul);
Assert.IsBetween(numBits.x, 0ul, 64ul - index.x);
Assert.IsBetween(numBits.y, 0ul, 64ul - index.y);
Assert.IsBetween(numBits.z, 0ul, 64ul - index.z);
Assert.IsBetween(numBits.w, 0ul, 64ul - index.w);

            if (Avx2.IsAvx2Supported)
            {
                // mask
                index = shl(ulong.MaxValue, index);

                v256 isMaxBitsMask = Avx2.mm256_cmpeq_epi64(numBits, new v256(64ul));

                return isMaxBitsMask | andnot(index, shl(index, numBits));
            }
            else
            {
                return new ulong4(bitmask64(numBits._xy, index._xy), bitmask64(numBits._zw, index._zw));
            }
        }


        /// <summary>       Returns a 32-bit bitmask with all bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask32(int numBits, int index = 0) => (int)bitmask32((uint)numBits, (uint)index);

        /// <summary>       Returns a 32-bit bitmask int2 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bitmask32(int2 numBits, int2 index = default(int2)) => (int2)bitmask32((uint2)numBits, (uint2)index);

        /// <summary>       Returns a 32-bit bitmask int3 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bitmask32(int3 numBits, int3 index = default(int3)) => (int3)bitmask32((uint3)numBits, (uint3)index);

        /// <summary>       Returns a 32-bit bitmask int4 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bitmask32(int4 numBits, int4 index = default(int4)) => (int4)bitmask32((uint4)numBits, (uint4)index);

        /// <summary>       Returns a 32-bit bitmask int8 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bitmask32(int8 numBits, int8 index = default(int8)) => (int8)bitmask32((uint8)numBits, (uint8)index);


        /// <summary>       Returns a 64-bit bitmask with all bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bitmask64(long numBits, long index = 0) => (long)bitmask64((ulong)numBits, (ulong)index);

        /// <summary>       Returns a 64-bit bitmask long2 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bitmask64(long2 numBits, long2 index = default(long2)) => (long2)bitmask64((ulong2)numBits, (ulong2)index);

        /// <summary>       Returns a 64-bit bitmask long3 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bitmask64(long3 numBits, long3 index = default(long3)) => (long3)bitmask64((ulong3)numBits, (ulong3)index);

        /// <summary>       Returns a 64-bit bitmask long4 vector with all componentwise bits set to 1 from index to (index + numBits - 1) in LSB order.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bitmask64(long4 numBits, long4 index = new long4()) => (long4)bitmask64((ulong4)numBits, (ulong4)index);
    }
}