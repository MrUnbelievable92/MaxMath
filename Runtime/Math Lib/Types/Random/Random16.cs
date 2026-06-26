using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DevTools;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
    /// <summary>       A random number generator for producing uniformly distributed 16-bit values, including vectors of 16-bit values.     </summary>
    [Serializable]
    unsafe public struct Random16
    {
        public const ushort DEFAULT_SEED = 0xF952;

        public ushort State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random16(ushort seed = DEFAULT_SEED)
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
                ushort seed = (ushort)Stopwatch.GetTimestamp();
                seed -= tobyte(seed == ushort.MaxValue);

                return new Random16 { State = BijectiveHash(seed) };
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
        private static ushort BijectiveHash(ushort n)
        {
            if (!constexpr.IS_TRUE(n != 52349 - 1))
            {
                n += 52349;
            }

            n *= 0x9E37;
            n = rol(n, 7);
            n ^= 0xBEEF;
            n *= 0xB119;
            n = rol(n, 11);
            n ^= 0xA5A5;
            
            return n;
        }

        /// <summary>   Initialized the state of the <see cref="Random16"/> instance with a given seed value. The seed must be non-zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InitState(ushort seed = DEFAULT_SEED)
        {
Assert.AreNotEqual(seed, 0);

            State = seed;
            NextState();
        }
        
        /// <summary>   Constructs a <see cref="Random16"/> instance with an index <paramref name="i"/> that gets hashed. The index must not be <see cref="ushort.MaxValue"/>. Use this function when you expect to create several <see cref="Random16"/> instances in a loop.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Random16 CreateFromIndex(uint i)
        {
Assert.AreNotEqual(i, ushort.MaxValue);
            

            return new Random16 { State = BijectiveHash((ushort)i) };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort NextState()
        {
Assert.AreNotEqual(State, 0);

            ushort temp = State;

            State = (ushort)(State ^ (ushort)(State << 7));
            State = (ushort)(State ^ (ushort)(State >> 9));
            State = (ushort)(State ^ (ushort)(State << 13));

            return temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort2 NextState2()
        {
            return new ushort2(NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort3 NextState3()
        {
            return new ushort3(NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort4 NextState4()
        {
            return new ushort4(NextState(), NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort8 NextState8()
        {
            return new ushort8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ushort16 NextState16()
        {
            return new ushort16(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="bool"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            return (short)NextState() < 0;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            bool3 result = ((Random32)this).NextBool3();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool4"/>.     </summary>
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
            bool16 result = ((Random128)this).NextBool16();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            bool32 result = ((Random128)this).NextBool32();

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
            return short.MinValue ^ (short2)NextState2();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short3"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 NextShort3()
        {
            return short.MinValue ^ (short3)NextState3();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short4"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 NextShort4()
        {
            return short.MinValue ^ (short4)NextState4();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short8"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8 NextShort8()
        {
            return short.MinValue ^ (short8)NextState8();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short16"/> with all components in the interval [-32.767, 32.767].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16()
        {
            return short.MinValue ^ (short16)NextState16();
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
VectorAssert.IsNotSmaller<short2, short>(max, min, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (short2)Xse.mulhi_epu16(max - min, NextState2());
            }
            else
            {
                return min + (short2)(((uint2)(max - min) * NextState2()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3 NextShort3(short3 min, short3 max)
        {
VectorAssert.IsNotSmaller<short3, short>(max, min, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (short3)Xse.mulhi_epu16(max - min, NextState3());
            }
            else
            {
                return min + (short3)(((uint3)(max - min) * NextState3()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4 NextShort4(short4 min, short4 max)
        {
VectorAssert.IsNotSmaller<short4, short>(max, min, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (short4)Xse.mulhi_epu16(max - min, NextState4());
            }
            else
            {
                return min + (short4)(((uint4)(max - min) * NextState4()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8 NextShort8(short8 min, short8 max)
        {
VectorAssert.IsNotSmaller<short8, short>(max, min, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (short8)Xse.mulhi_epu16(max - min, NextState8());
            }
            else
            {
                return min + (short8)(((uint8)(max - min) * NextState8()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.short16"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16 NextShort16(short16 min, short16 max)
        {
VectorAssert.IsNotSmaller<short16, short>(max, min, 16);

            if (Avx2.IsAvx2Supported)
            {
                return min + Avx2.mm256_mulhi_epu16(max - min, NextState16());
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
            return ushort.MaxValue + NextState2();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort3"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3()
        {
            return ushort.MaxValue + NextState3();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort4"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4()
        {
            return ushort.MaxValue + NextState4();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort8"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8()
        {
            return ushort.MaxValue + NextState8();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort16"/> with all components in the interval [0, 65.534].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16()
        {
            return ushort.MaxValue + NextState16();
        }


        /// <summary>       Returns a uniformly random <see cref="ushort"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort NextUShort(ushort max)
        {
            return (ushort)(((uint)NextState() * max) >> 16);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort2"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2 NextUShort2(ushort2 max)
        {
VectorAssert.IsGreater<ushort2, ushort>(max, 0, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mulhi_epu16(max, NextState2());
            }
            else
            {
                return (ushort2)(((uint2)max * NextState2()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort3"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3(ushort3 max)
        {
VectorAssert.IsGreater<ushort3, ushort>(max, 0, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mulhi_epu16(max, NextState3());
            }
            else
            {
                return (ushort3)(((uint3)max * NextState3()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort4"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4(ushort4 max)
        {
VectorAssert.IsGreater<ushort4, ushort>(max, 0, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mulhi_epu16(max, NextState4());
            }
            else
            {
                return (ushort4)(((uint4)max * NextState4()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort8"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8(ushort8 max)
        {
VectorAssert.IsGreater<ushort8, ushort>(max, 0, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mulhi_epu16(max, NextState8());
            }
            else
            {
                return (ushort8)(((uint8)max * NextState8()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort16"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16(ushort16 max)
        {
VectorAssert.IsGreater<ushort16, ushort>(max, 0, 16);

            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mulhi_epu16(max, NextState16());
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
VectorAssert.IsNotSmaller<ushort2, ushort>(max, min, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (ushort2)Xse.mulhi_epu16(max - min, NextState2());
            }
            else
            {
                return min + (ushort2)(((uint2)(max - min) * NextState2()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3 NextUShort3(ushort3 min, ushort3 max)
        {
VectorAssert.IsNotSmaller<ushort3, ushort>(max, min, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (ushort3)Xse.mulhi_epu16(max - min, NextState3());
            }
            else
            {
                return min + (ushort3)(((uint3)(max - min) * NextState3()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4 NextUShort4(ushort4 min, ushort4 max)
        {
VectorAssert.IsNotSmaller<ushort4, ushort>(max, min, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (ushort4)Xse.mulhi_epu16(max - min, NextState4());
            }
            else
            {
                return min + (ushort4)(((uint4)(max - min) * NextState4()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8 NextUShort8(ushort8 min, ushort8 max)
        {
VectorAssert.IsNotSmaller<ushort8, ushort>(max, min, 8);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return min + (ushort8)Xse.mulhi_epu16(max - min, NextState8());
            }
            else
            {
                return min + (ushort8)(((uint8)(max - min) * NextState8()) >> 16);
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ushort16"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort16 NextUShort16(ushort16 min, ushort16 max)
        {
VectorAssert.IsNotSmaller<ushort16, ushort>(max, min, 16);

            if (Avx2.IsAvx2Supported)
            {
                return min + (ushort16)Avx2.mm256_mulhi_epu16(max - min, NextState16());
            }
            else
            {
                return new ushort16(NextUShort8(min.v8_0, max.v8_0), NextUShort8(min.v8_8, max.v8_8));
            }
        }
    }
}