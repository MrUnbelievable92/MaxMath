using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a 32-bit bitmask with all bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitmask32(uint numBits, uint index = 0)
        {
Assert.IsDefinedBitShift<uint>(numBits);
Assert.IsDefinedBitShift<uint>(index);

            // mask
            index = uint.MaxValue << (int)index;

            return andnot(index, index << (int)numBits);
        }

        /// <summary>       Returns a 32-bit bitmask uint2 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(uint2 numBits, uint2 index = default(uint2))
        {
Assert.IsDefinedBitShift<uint>(numBits.x);
Assert.IsDefinedBitShift<uint>(numBits.y);
Assert.IsDefinedBitShift<uint>(index.x);
Assert.IsDefinedBitShift<uint>(index.y);

            // mask
            index = shl(uint.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }

        /// <summary>       Returns a 32-bit bitmask uint3 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(uint3 numBits, uint3 index = default(uint3))
        {
Assert.IsDefinedBitShift<uint>(numBits.x);
Assert.IsDefinedBitShift<uint>(numBits.y);
Assert.IsDefinedBitShift<uint>(numBits.z);
Assert.IsDefinedBitShift<uint>(index.x);
Assert.IsDefinedBitShift<uint>(index.y);
Assert.IsDefinedBitShift<uint>(index.z);

            // mask
            index = shl(uint.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }

        /// <summary>       Returns a 32-bit bitmask uint4 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(uint4 numBits, uint4 index = default(uint4))
        {
Assert.IsDefinedBitShift<uint>(numBits.x);
Assert.IsDefinedBitShift<uint>(numBits.y);
Assert.IsDefinedBitShift<uint>(numBits.z);
Assert.IsDefinedBitShift<uint>(numBits.w);
Assert.IsDefinedBitShift<uint>(index.x);
Assert.IsDefinedBitShift<uint>(index.y);
Assert.IsDefinedBitShift<uint>(index.z);
Assert.IsDefinedBitShift<uint>(index.w);

            // mask
            index = shl(uint.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }

        /// <summary>       Returns a 32-bit bitmask uint8 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(uint8 numBits, uint8 index = default(uint8))
        {
Assert.IsDefinedBitShift<uint>(numBits.x0);
Assert.IsDefinedBitShift<uint>(numBits.x1);
Assert.IsDefinedBitShift<uint>(numBits.x2);
Assert.IsDefinedBitShift<uint>(numBits.x3);
Assert.IsDefinedBitShift<uint>(numBits.x4);
Assert.IsDefinedBitShift<uint>(numBits.x5);
Assert.IsDefinedBitShift<uint>(numBits.x6);
Assert.IsDefinedBitShift<uint>(numBits.x7);
Assert.IsDefinedBitShift<uint>(index.x0);
Assert.IsDefinedBitShift<uint>(index.x1);
Assert.IsDefinedBitShift<uint>(index.x2);
Assert.IsDefinedBitShift<uint>(index.x3);
Assert.IsDefinedBitShift<uint>(index.x4);
Assert.IsDefinedBitShift<uint>(index.x5);
Assert.IsDefinedBitShift<uint>(index.x6);
Assert.IsDefinedBitShift<uint>(index.x7);

            // mask
            index = shl(uint.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }


        /// <summary>       Returns a 64-bit bitmask with all bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64(ulong numBits, ulong index = 0)
        {
Assert.IsDefinedBitShift<ulong>((uint)numBits);
Assert.IsDefinedBitShift<ulong>((uint)index);

            ulong mask = ulong.MaxValue << (int)index;

            return andnot(mask, mask << (int)numBits);
        }

        /// <summary>       Returns a 64-bit bitmask ulong2 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(ulong2 numBits, ulong2 index = default(ulong2))
        {
Assert.IsDefinedBitShift<ulong>((uint)numBits.x);
Assert.IsDefinedBitShift<ulong>((uint)numBits.y);
Assert.IsDefinedBitShift<ulong>((uint)index.x);
Assert.IsDefinedBitShift<ulong>((uint)index.y);

            // mask
            index = shl(ulong.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }

        /// <summary>       Returns a 64-bit bitmask ulong3 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(ulong3 numBits, ulong3 index = default(ulong3))
        {
Assert.IsDefinedBitShift<ulong>((uint)numBits.x);
Assert.IsDefinedBitShift<ulong>((uint)numBits.y);
Assert.IsDefinedBitShift<ulong>((uint)numBits.z);
Assert.IsDefinedBitShift<ulong>((uint)index.x);
Assert.IsDefinedBitShift<ulong>((uint)index.y);
Assert.IsDefinedBitShift<ulong>((uint)index.z);

            // mask
            index = shl(ulong.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }

        /// <summary>       Returns a 64-bit bitmask ulong4 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(ulong4 numBits, ulong4 index = new ulong4())
        {
Assert.IsDefinedBitShift<ulong>((uint)numBits.x);
Assert.IsDefinedBitShift<ulong>((uint)numBits.y);
Assert.IsDefinedBitShift<ulong>((uint)numBits.z);
Assert.IsDefinedBitShift<ulong>((uint)numBits.w);
Assert.IsDefinedBitShift<ulong>((uint)index.x);
Assert.IsDefinedBitShift<ulong>((uint)index.y);
Assert.IsDefinedBitShift<ulong>((uint)index.z);
Assert.IsDefinedBitShift<ulong>((uint)index.w);

            // mask
            index = shl(ulong.MaxValue, index);

            return andnot(index, shl(index, numBits));
        }


        /// <summary>       Returns a 32-bit bitmask with all bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask32([AssumeRange(0, 32)] int numBits, [AssumeRange(0, 31)] int index = 0) => (int)bitmask32((uint)numBits, (uint)index);

        /// <summary>       Returns a 32-bit bitmask int2 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bitmask32(int2 numBits, int2 index = default(int2)) => (int2)bitmask32((uint2)numBits, (uint2)index);

        /// <summary>       Returns a 32-bit bitmask int3 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bitmask32(int3 numBits, int3 index = default(int3)) => (int3)bitmask32((uint3)numBits, (uint3)index);

        /// <summary>       Returns a 32-bit bitmask int4 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bitmask32(int4 numBits, int4 index = default(int4)) => (int4)bitmask32((uint4)numBits, (uint4)index);

        /// <summary>       Returns a 32-bit bitmask int8 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bitmask32(int8 numBits, int8 index = default(int8)) => (int8)bitmask32((uint8)numBits, (uint8)index);


        /// <summary>       Returns a 64-bit bitmask with all bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bitmask64([AssumeRange(0, 64)] long numBits, long index = 0) => (long)bitmask64((ulong)numBits, (ulong)index);

        /// <summary>       Returns a 64-bit bitmask long2 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bitmask64(long2 numBits, long2 index = default(long2)) => (long2)bitmask64((ulong2)numBits, (ulong2)index);

        /// <summary>       Returns a 64-bit bitmask long3 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bitmask64(long3 numBits, long3 index = default(long3)) => (long3)bitmask64((ulong3)numBits, (ulong3)index);

        /// <summary>       Returns a 64-bit bitmask long4 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bitmask64(long4 numBits, long4 index = new long4()) => (long4)bitmask64((ulong4)numBits, (ulong4)index);
    }
}