using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random32
    {
        public Unity.Mathematics.Random state;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random32(uint seed = 1851936439u)
        {
            state = new Unity.Mathematics.Random(seed);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint NextState()
        {
 Assert.AreNotEqual(state.state, 0u);

            uint t = state.state;

            state.state ^= state.state << 13;
            state.state ^= state.state >> 17;
            state.state ^= state.state << 5;

            return t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 1u;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101u;

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = NextState() & 0x0001_0101u;

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool4*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt()
        {
            return state.NextInt();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int max)
        {
            return state.NextInt(max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int min, int max)
        {
            return state.NextInt(min, max);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt()
        {
            return state.NextUInt();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint max)
        {
            return state.NextUInt(max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint min, uint max)
        {
            return state.NextUInt(min, max);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return state.NextFloat();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float max) 
        {
            return state.NextFloat(max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float min, float max) 
        { 
            return state.NextFloat(min, max);
        }
    }
}