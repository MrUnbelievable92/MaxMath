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
            State = seed;

            NextState();
        }

        
        /// <summary>       Returns a randomly seeded <see cref="Random16"/>.     </summary>
        public static Random16 New
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get 
            {
                ushort seed = (ushort)Environment.TickCount;
                seed += maxmath.tobyte(seed == 0);

                return new Random16(seed);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random32(Random16 input)
        {
            return new Random32(input.State);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random64(Random16 input)
        {
            return new Random64(input.State);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random128(Random16 input)
        {
            return new Random128(input.State);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random8(Random16 input)
        {
            return new Random8 { State = (byte)input.NextUShort(1, byte.MaxValue + 1) };
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort NextState()
        {
Assert.AreNotEqual(State, 0);

            ushort temp = State;

            State = (ushort)(State ^ State << 7);
            State = (ushort)(State ^ State >> 9);
            State = (ushort)(State ^ State << 13);

            return temp;
        }


        /// <summary>       Returns a uniformly random <see cref="bool"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 0x0101u;

            return *(bool*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            bool3 result = ((Random32)this).NextBool3();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            bool4 result = ((Random32)this).NextBool4();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8 NextBool8()
        {
            bool8 result = ((Random64)this).NextBool8();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16 NextBool16()
        {
            bool16 result = ((Random64)this).NextBool16();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            bool32 result = ((Random64)this).NextBool32();

            NextState();

            return result;
        }


        /// <summary>       Returns a uniformly random <see cref="short"/> in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short NextShort()
        {
            return (short)(short.MinValue ^ NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short2"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2 NextShort2()
        {
            return short.MinValue ^ new short2((short)NextState(), (short)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short3"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 NextShort3()
        {
            return short.MinValue ^ new short3((short)NextState(), (short)NextState(), (short)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short4"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 NextShort4()
        {
            return short.MinValue ^ new short4((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short8"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8 NextShort8()
        {
            return short.MinValue ^ new short8((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short16"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16()
        {
            return short.MinValue ^ new short16((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="short"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short NextShort(short min, short max)
        {
Assert.IsNotSmaller(max, min);

            return (short)(min + (((uint)NextState() * (max - min)) >> 16));
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2 NextShort2(short2 min, short2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new short2((short)NextState(), (short)NextState()));
            }
            else
            {
                return min + (short2)(((uint2)(max - min) * new uint2(NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 NextShort3(short3 min, short3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new short3((short)NextState(), (short)NextState(), (short)NextState()));
            }
            else
            {
                return min + (short3)(((uint3)(max - min) * new uint3(NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 NextShort4(short4 min, short4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new short4((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState()));
            }
            else
            {
                return min + (short4)(((uint4)(max - min) * new uint4(NextState(), NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
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

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new short8((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState()));
            }
            else
            {
                return min + (short8)(((uint8)(max - min) * new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short16"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
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

            if (Avx2.IsAvx2Supported)
            {
                return min + Avx2.mm256_mulhi_epu16(max - min, new short16((short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState(), (short)NextState()));
            }
            else
            {
                return new short16(NextShort8(min.v8_0, max.v8_0), NextShort8(min.v8_8, max.v8_8));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="ushort"/> in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort()
        {
            return (ushort)(NextState() - 1);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort2"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2()
        {
            return ushort.MaxValue + new ushort2((ushort)NextState(), (ushort)NextState()) ;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort3"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3()
        {
            return ushort.MaxValue + new ushort3((ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort4"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4()
        {
            return ushort.MaxValue + new ushort4((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort8"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8()
        {
            return ushort.MaxValue + new ushort8((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort16"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16()
        {
            return ushort.MaxValue + new ushort16((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()) ;
        }


        /// <summary>       Returns a uniformly random <see cref="ushort"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort(ushort max)
        {
Assert.IsPositive(max);

            return (ushort)(((uint)NextState() * max) >> 16);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort2"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2(ushort2 max)
        {
Assert.IsPositive(max.x);
Assert.IsPositive(max.y);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.mulhi_epu16(max, new ushort2((ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return (ushort2)(((uint2)max * new uint2(NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort3"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3(ushort3 max)
        {
Assert.IsPositive(max.x);
Assert.IsPositive(max.y);
Assert.IsPositive(max.z);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.mulhi_epu16(max, new ushort3((ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return (ushort3)(((uint3)max * new uint3(NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort4"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4(ushort4 max)
        {
Assert.IsPositive(max.x);
Assert.IsPositive(max.y);
Assert.IsPositive(max.z);
Assert.IsPositive(max.w);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.mulhi_epu16(max, new ushort4((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return (ushort4)(((uint4)max * new uint4(NextState(), NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort8"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
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

            if (Sse2.IsSse2Supported)
            {
                return Sse2.mulhi_epu16(max, new ushort8((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return (ushort8)(((uint8)max * new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort16"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
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

            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mulhi_epu16(max, new ushort16((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return new ushort16(NextUShort8(max.v8_0), NextUShort8(max.v8_8));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="ushort"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort(ushort min, ushort max)
        {
Assert.IsNotSmaller(max, min);

            return (ushort)(min + (((uint)NextState() * (max - min)) >> 16));
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2(ushort2 min, ushort2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new ushort2((ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return min + (ushort2)(((uint2)(max - min) * new uint2(NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3(ushort3 min, ushort3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new ushort3((ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return min + (ushort3)(((uint3)(max - min) * new uint3(NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4(ushort4 min, ushort4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new ushort4((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return min + (ushort4)(((uint4)(max - min) * new uint4(NextState(), NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
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

            if (Sse2.IsSse2Supported)
            {
                return min + Sse2.mulhi_epu16(max - min, new ushort8((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return min + (ushort8)(((uint8)(max - min) * new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState())) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort16"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
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

            if (Avx2.IsAvx2Supported)
            {
                return min + Avx2.mm256_mulhi_epu16(max - min, new ushort16((ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState(), (ushort)NextState()));
            }
            else
            {
                return new ushort16(NextUShort8(min.v8_0, max.v8_0), NextUShort8(min.v8_8, max.v8_8));
            }
        }
    }
}