using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random64
    {
        public ulong state;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random64(ulong seed = 0xB799_8C11_F332_F914ul)
        {
Assert.AreNotEqual(seed, 0ul);

            state = seed;

            NextState();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random64(ref Random32 seed)
        {
Assert.AreNotEqual(seed.state.state, 0u);

            state = (seed.NextUInt() << 1) | seed.NextUInt();

            NextState();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong NextState()
        {
Assert.AreNotEqual(state, 0ul);

            ulong t = state;

            state ^= state << 13;
            state ^= state >> 7;
            state ^= state << 17;

            return t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4x2 NextBool4x2()
        {
            ulong result = NextState() & 0x0101_0101_0101_0101ul;

            return *(bool4x2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong()
        {
            return long.MinValue ^ (long)NextState();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong(long max)
        {
Assert.IsGreater<long>(max, -1L);

            max = (long)Common.umul128(NextState(), (ulong)max, out ulong result);

            return (long)result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong(long min, long max)
        {
Assert.IsNotSmaller<long>(max, min);

            max = (long)Common.umul128(NextState(), (ulong)(max -= min), out ulong result);

            return min + (long)result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong()
        {
            return NextState() - 1ul;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong(ulong max)
        {
            max = Common.umul128(NextState(), max, out ulong result);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong(ulong min, ulong max)
        {
Assert.IsNotSmaller<ulong>(max, min);

            max = Common.umul128(NextState(), max - min, out ulong result);

            return min + result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            return math.asdouble(0x3FF0_0000_0000_0000 | (NextState() >> 12)) - 1d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble(double max) 
        { 
            return NextDouble() * max; 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble(double min, double max) 
        { 
Assert.IsNotSmaller<double>(max, min);

            return math.mad(NextDouble(), (max - min), min);
        }
    }
}