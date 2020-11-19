using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bitmask32([AssumeRange(0, 31)] int numBits, [AssumeRange(0, 31)] int index = 0)
        {
Assert.DefinedBitShift<uint>(numBits);
Assert.DefinedBitShift<uint>(index);

            // mask
            index = -1 << index;

            return (uint)andn(index, index << numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bitmask32(int2 numBits, int2 index = default(int2))
        {
Assert.DefinedBitShift<uint>(numBits.x);
Assert.DefinedBitShift<uint>(numBits.y);
Assert.DefinedBitShift<uint>(index.x);
Assert.DefinedBitShift<uint>(index.y);

            // mask
            index = shl(-1, index);

            return math.asuint(andn(index, shl(index, numBits)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bitmask32(int3 numBits, int3 index = default(int3))
        {
Assert.DefinedBitShift<uint>(numBits.x);
Assert.DefinedBitShift<uint>(numBits.y);
Assert.DefinedBitShift<uint>(numBits.z);
Assert.DefinedBitShift<uint>(index.x);
Assert.DefinedBitShift<uint>(index.y);
Assert.DefinedBitShift<uint>(index.z);

            // mask
            index = shl(-1, index);

            return math.asuint(andn(index, shl(index, numBits)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bitmask32(int4 numBits, int4 index = default(int4))
        {
Assert.DefinedBitShift<uint>(numBits.x);
Assert.DefinedBitShift<uint>(numBits.y);
Assert.DefinedBitShift<uint>(numBits.z);
Assert.DefinedBitShift<uint>(numBits.w);
Assert.DefinedBitShift<uint>(index.x);
Assert.DefinedBitShift<uint>(index.y);
Assert.DefinedBitShift<uint>(index.z);
Assert.DefinedBitShift<uint>(index.w);

            // mask
            index = shl(-1, index);

            return math.asuint(andn(index, shl(index, numBits)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bitmask32(int8 numBits, int8 index = default(int8))
        {
Assert.DefinedBitShift<uint>(numBits.x0);
Assert.DefinedBitShift<uint>(numBits.x1);
Assert.DefinedBitShift<uint>(numBits.x2);
Assert.DefinedBitShift<uint>(numBits.x3);
Assert.DefinedBitShift<uint>(numBits.x4);
Assert.DefinedBitShift<uint>(numBits.x5);
Assert.DefinedBitShift<uint>(numBits.x6);
Assert.DefinedBitShift<uint>(numBits.x7);
Assert.DefinedBitShift<uint>(index.x0);
Assert.DefinedBitShift<uint>(index.x1);
Assert.DefinedBitShift<uint>(index.x2);
Assert.DefinedBitShift<uint>(index.x3);
Assert.DefinedBitShift<uint>(index.x4);
Assert.DefinedBitShift<uint>(index.x5);
Assert.DefinedBitShift<uint>(index.x6);
Assert.DefinedBitShift<uint>(index.x7);

            // mask
            index = shl(-1, index);

            return (uint8)andn(index, shl(index, numBits));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bitmask64([AssumeRange(0, 63)] int numBits, [AssumeRange(0, 63)] int index = 0)
        {
Assert.DefinedBitShift<ulong>(numBits);
Assert.DefinedBitShift<ulong>(index);

            ulong mask = ulong.MaxValue << index;

            return andn(mask, mask << numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bitmask64(long2 numBits, long2 index = default(long2))
        {
Assert.DefinedBitShift<ulong>((int)numBits.x);
Assert.DefinedBitShift<ulong>((int)numBits.y);
Assert.DefinedBitShift<ulong>((int)index.x);
Assert.DefinedBitShift<ulong>((int)index.y);

            // mask
            index = shl(-1L, index);

            return (ulong2)andn(index, shl(index, numBits));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bitmask64(long3 numBits, long3 index = default(long3))
        {
Assert.DefinedBitShift<ulong>((int)numBits.x);
Assert.DefinedBitShift<ulong>((int)numBits.y);
Assert.DefinedBitShift<ulong>((int)numBits.z);
Assert.DefinedBitShift<ulong>((int)index.x);
Assert.DefinedBitShift<ulong>((int)index.y);
Assert.DefinedBitShift<ulong>((int)index.z);

            // mask
            index = shl(-1L, index);

            return (ulong3)andn(index, shl(index, numBits));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bitmask64(long4 numBits, long4 index = new long4())
        {
Assert.DefinedBitShift<ulong>((int)numBits.x);
Assert.DefinedBitShift<ulong>((int)numBits.y);
Assert.DefinedBitShift<ulong>((int)numBits.z);
Assert.DefinedBitShift<ulong>((int)numBits.w);
Assert.DefinedBitShift<ulong>((int)index.x);
Assert.DefinedBitShift<ulong>((int)index.y);
Assert.DefinedBitShift<ulong>((int)index.z);
Assert.DefinedBitShift<ulong>((int)index.w);

            // mask
            index = shl(-1L, index);

            return (ulong4)andn(index, shl(index, numBits));
        }
    }
}