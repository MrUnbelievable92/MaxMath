using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random16
    {
        public ushort State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random16(ushort seed = 0xF952)
        {
Assert.AreNotEqual(seed, 0);

            State = seed;

            NextState();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort NextState()
        {
Assert.AreNotEqual(State, 0);

            ushort t = State;

            State = (ushort)(State ^ (State << 7));
            State = (ushort)(State ^ (State >> 9));
            State = (ushort)(State ^ (State << 13));

            return t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 0x0101u;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101u;

            return *(bool2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short NextShort()
        {
            return (short)(short.MinValue ^ NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2 NextShort2()
        {
            return short.MinValue ^ new short2((short)NextState(), (short)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 NextShort3()
        {
            return short.MinValue ^ new short3((short)NextState(), (short)NextState(), (short)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 NextShort4()
        {
            return short.MinValue ^ new short4((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8 NextShort8()
        {
            return short.MinValue ^ new short8((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16()
        {
            return short.MinValue ^ new short16((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState());
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short NextShort(short min, short max)
        {
Assert.IsNotSmaller(max, min);

            return (short)(min + (((uint)NextState() * (max - min)) >> 16));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2 NextShort2(short2 min, short2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            return min + Sse2.mulhi_epi16(max - min, new short2((short)NextState(), (short)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 NextShort3(short3 min, short3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            return min + Sse2.mulhi_epi16(max - min, new short3((short)NextState(), (short)NextState(), (short)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 NextShort4(short4 min, short4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            return min + Sse2.mulhi_epi16(max - min, new short4((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8 NextShort8(short8 min, short8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);

            return min + Sse2.mulhi_epi16(max - min, new short8((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16(short16 min, short16 max)
        {
Assert.IsNotSmaller(max.x0,  min.x0);
Assert.IsNotSmaller(max.x1,  min.x1);
Assert.IsNotSmaller(max.x2,  min.x2);
Assert.IsNotSmaller(max.x3,  min.x3);
Assert.IsNotSmaller(max.x4,  min.x4);
Assert.IsNotSmaller(max.x5,  min.x5);
Assert.IsNotSmaller(max.x6,  min.x6);
Assert.IsNotSmaller(max.x7,  min.x7);
Assert.IsNotSmaller(max.x8,  min.x8);
Assert.IsNotSmaller(max.x9,  min.x9);
Assert.IsNotSmaller(max.x10, min.x10);
Assert.IsNotSmaller(max.x11, min.x11);
Assert.IsNotSmaller(max.x12, min.x12);
Assert.IsNotSmaller(max.x13, min.x13);
Assert.IsNotSmaller(max.x14, min.x14);
Assert.IsNotSmaller(max.x15, min.x15);

            return min + Avx2.mm256_mulhi_epi16(max - min, new short16((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState()));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort()
        {
            return (ushort)(ushort.MaxValue + NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2()
        {
            return ushort.MaxValue + new ushort2((ushort)NextState(), (ushort)NextState()) ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3()
        {
            return ushort.MaxValue + new ushort3((ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4()
        {
            return ushort.MaxValue + new ushort4((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8()
        {
            return ushort.MaxValue + new ushort8((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16()
        {
            return ushort.MaxValue + new ushort16((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort(ushort max)
        {
Assert.IsPositive(max);

            return (ushort)(((uint)NextState() * max) >> 16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2(ushort2 max)
        {
Assert.IsPositive(max.x);
Assert.IsPositive(max.y);

            return Sse2.mulhi_epi16(max, new ushort2((ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3(ushort3 max)
        {
Assert.IsPositive(max.x);
Assert.IsPositive(max.y);
Assert.IsPositive(max.z);

            return Sse2.mulhi_epi16(max, new ushort3((ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4(ushort4 max)
        {
Assert.IsPositive(max.x);
Assert.IsPositive(max.y);
Assert.IsPositive(max.z);
Assert.IsPositive(max.w);

            return Sse2.mulhi_epi16(max, new ushort4((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8(ushort8 max)
        {
Assert.IsPositive(max.x0);
Assert.IsPositive(max.x1);
Assert.IsPositive(max.x2);
Assert.IsPositive(max.x3);
Assert.IsPositive(max.x4);
Assert.IsPositive(max.x5);
Assert.IsPositive(max.x6);
Assert.IsPositive(max.x7);

            return Sse2.mulhi_epi16(max, new ushort8((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16(ushort16 max)
        {
Assert.IsPositive(max.x0);
Assert.IsPositive(max.x1);
Assert.IsPositive(max.x2);
Assert.IsPositive(max.x3);
Assert.IsPositive(max.x4);
Assert.IsPositive(max.x5);
Assert.IsPositive(max.x6);
Assert.IsPositive(max.x7);
Assert.IsPositive(max.x8);
Assert.IsPositive(max.x9);
Assert.IsPositive(max.x10);
Assert.IsPositive(max.x11);
Assert.IsPositive(max.x12);
Assert.IsPositive(max.x13);
Assert.IsPositive(max.x14);
Assert.IsPositive(max.x15);

            return Avx2.mm256_mulhi_epi16(max, new ushort16((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort(ushort min, ushort max)
        {
Assert.IsNotSmaller(max, min);

            return (ushort)(min + (((uint)NextState() * (max - min)) >> 16));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2(ushort2 min, ushort2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            return min + Sse2.mulhi_epi16(max - min, new ushort2((ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3(ushort3 min, ushort3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            return min + Sse2.mulhi_epi16(max - min, new ushort3((ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4(ushort4 min, ushort4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            return min + Sse2.mulhi_epi16(max - min, new ushort4((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8(ushort8 min, ushort8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);

            return min + Sse2.mulhi_epi16(max - min, new ushort8((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16(ushort16 min, ushort16 max)
        {
Assert.IsNotSmaller(max.x0,  min.x0);
Assert.IsNotSmaller(max.x1,  min.x1);
Assert.IsNotSmaller(max.x2,  min.x2);
Assert.IsNotSmaller(max.x3,  min.x3);
Assert.IsNotSmaller(max.x4,  min.x4);
Assert.IsNotSmaller(max.x5,  min.x5);
Assert.IsNotSmaller(max.x6,  min.x6);
Assert.IsNotSmaller(max.x7,  min.x7);
Assert.IsNotSmaller(max.x8,  min.x8);
Assert.IsNotSmaller(max.x9,  min.x9);
Assert.IsNotSmaller(max.x10, min.x10);
Assert.IsNotSmaller(max.x11, min.x11);
Assert.IsNotSmaller(max.x12, min.x12);
Assert.IsNotSmaller(max.x13, min.x13);
Assert.IsNotSmaller(max.x14, min.x14);
Assert.IsNotSmaller(max.x15, min.x15);

            return min + Avx2.mm256_mulhi_epi16(max - min, new ushort16((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
        }
    }
}