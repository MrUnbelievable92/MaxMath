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
        public static uint bitmask32([AssumeRange(0, 32)] int numBits, [AssumeRange(0, 31)] int index = 0)
        {
Assert.IsDefinedBitShift<uint>(numBits);
Assert.IsDefinedBitShift<uint>(index);

            // mask
            index = -1 << index;

            return (uint)andn(index, index << numBits);
        }

        /// <summary>       Returns a 32-bit bitmask uint2 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(int2 numBits, int2 index = default(int2))
        {
Assert.IsDefinedBitShift<uint>(numBits.x);
Assert.IsDefinedBitShift<uint>(numBits.y);
Assert.IsDefinedBitShift<uint>(index.x);
Assert.IsDefinedBitShift<uint>(index.y);

            // mask
            index = shl(-1, index);

            return math.asuint(andn(index, shl(index, numBits)));
        }

        /// <summary>       Returns a 32-bit bitmask uint3 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(int3 numBits, int3 index = default(int3))
        {
Assert.IsDefinedBitShift<uint>(numBits.x);
Assert.IsDefinedBitShift<uint>(numBits.y);
Assert.IsDefinedBitShift<uint>(numBits.z);
Assert.IsDefinedBitShift<uint>(index.x);
Assert.IsDefinedBitShift<uint>(index.y);
Assert.IsDefinedBitShift<uint>(index.z);

            // mask
            index = shl(-1, index);

            return math.asuint(andn(index, shl(index, numBits)));
        }

        /// <summary>       Returns a 32-bit bitmask uint4 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(int4 numBits, int4 index = default(int4))
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
            index = shl(-1, index);

            return math.asuint(andn(index, shl(index, numBits)));
        }

        /// <summary>       Returns a 32-bit bitmask uint8 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(int8 numBits, int8 index = default(int8))
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
            index = shl(-1, index);

            return (uint8)andn(index, shl(index, numBits));
        }


        /// <summary>       Returns a 64-bit bitmask with all bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64([AssumeRange(0, 64)] int numBits, [AssumeRange(0, 63)] int index = 0)
        {
Assert.IsDefinedBitShift<ulong>(numBits);
Assert.IsDefinedBitShift<ulong>(index);

            ulong mask = ulong.MaxValue << index;

            return andn(mask, mask << numBits);
        }

        /// <summary>       Returns a 64-bit bitmask ulong2 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(long2 numBits, long2 index = default(long2))
        {
Assert.IsDefinedBitShift<ulong>((int)numBits.x);
Assert.IsDefinedBitShift<ulong>((int)numBits.y);
Assert.IsDefinedBitShift<ulong>((int)index.x);
Assert.IsDefinedBitShift<ulong>((int)index.y);

            // mask
            index = shl(-1L, index);

            return (ulong2)andn(index, shl(index, numBits));
        }

        /// <summary>       Returns a 64-bit bitmask ulong3 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(long3 numBits, long3 index = default(long3))
        {
Assert.IsDefinedBitShift<ulong>((int)numBits.x);
Assert.IsDefinedBitShift<ulong>((int)numBits.y);
Assert.IsDefinedBitShift<ulong>((int)numBits.z);
Assert.IsDefinedBitShift<ulong>((int)index.x);
Assert.IsDefinedBitShift<ulong>((int)index.y);
Assert.IsDefinedBitShift<ulong>((int)index.z);

            // mask
            index = shl(-1L, index);

            return (ulong3)andn(index, shl(index, numBits));
        }

        /// <summary>       Returns a 64-bit bitmask ulong4 vector with all componentwise bits set to one from index to (index + numBits - 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(long4 numBits, long4 index = new long4())
        {
Assert.IsDefinedBitShift<ulong>((int)numBits.x);
Assert.IsDefinedBitShift<ulong>((int)numBits.y);
Assert.IsDefinedBitShift<ulong>((int)numBits.z);
Assert.IsDefinedBitShift<ulong>((int)numBits.w);
Assert.IsDefinedBitShift<ulong>((int)index.x);
Assert.IsDefinedBitShift<ulong>((int)index.y);
Assert.IsDefinedBitShift<ulong>((int)index.z);
Assert.IsDefinedBitShift<ulong>((int)index.w);

            // mask
            index = shl(-1L, index);

            return (ulong4)andn(index, shl(index, numBits));
        }
    }
}