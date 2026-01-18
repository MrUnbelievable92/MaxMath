using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;
using static Unity.Mathematics.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random64
    {
        public ulong State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random64(ulong seed = 0xB799_8C11_F332_F914ul)
        {
            State = seed;

            NextState();
        }


        /// <summary>       Returns a randomly seeded <see cref="Random64"/>.     </summary>
        public static Random64 New
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                ulong seed = (uint)Environment.TickCount;
                seed += tobyte(seed == 0);
                Random64 result = new Random64(seed);
                result.NextState();

                return result;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random128(Random64 input)
        {
            return new Random128(input.State);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random8(Random64 input)
        {
            return new Random8 { State = (byte)input.NextULong(1, byte.MaxValue + 1) };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random16(Random64 input)
        {
            return new Random16 { State = (ushort)input.NextULong(1, ushort.MaxValue + 1) };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random32(Random64 input)
        {
            return new Random32 { State = (uint)input.NextULong(1, (ulong)uint.MaxValue + 1) };
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong NextState()
        {
Assert.AreNotEqual(State, 0ul);

            ulong temp = State;

            State ^= State << 13;
            State ^= State >> 7;
            State ^= State << 17;

            return temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong2 NextState2()
        {
            return new ulong2(NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong3 NextState3()
        {
            return new ulong3(NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong4 NextState4()
        {
            return new ulong4(NextState(), NextState(), NextState(), NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="bool"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            return (long)NextState() < 0;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool3*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.bool4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool4*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8 NextBool8()
        {
            ulong result = NextState() & 0x0101_0101_0101_0101ul;

            return *(bool8*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16 NextBool16()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(new v128(0x0101_0101_0101_0101ul), NextState2());
            }
            else
            {
                return new bool16(NextBool8(), NextBool8());
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(new v256(0x0101_0101_0101_0101ul), NextState4());
            }
            else
            {
                return new bool32(NextBool16(), NextBool16());
            }
        }


        /// <summary>       Returns a uniformly random <see cref="long"/> in the interval [-9.223.372.036.854.775.807, 9.223.372.036.854.775.807].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong()
        {
            return long.MinValue ^ (long)NextState();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long2"/> with all components in the interval [-9.223.372.036.854.775.807, 9.223.372.036.854.775.807].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2 NextLong2()
        {
            return long.MinValue ^ (long2)NextState2();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long3"/> with all components in the interval [-9.223.372.036.854.775.807, 9.223.372.036.854.775.807].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3()
        {
            return long.MinValue ^ (long3)NextState3();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long4"/> with all components in the interval [-9.223.372.036.854.775.807, 9.223.372.036.854.775.807].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4()
        {
            return long.MinValue ^ (long4)NextState4();
        }


        /// <summary>       Returns a uniformly random <see cref="long"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong(long min, long max)
        {
Assert.IsNotSmaller(max, min);

            return min + (long)UInt128.umul128(NextState(), (ulong)(max - min)).hi64;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2 NextLong2(long2 min, long2 max)
        {
VectorAssert.IsNotSmaller<long2, long>(max, min, 2);

            max -= min;

            UInt128 x = UInt128.umul128(NextState(), (ulong)(max.x));
            UInt128 y = UInt128.umul128(NextState(), (ulong)(max.y));

            return min + new long2((long)x.hi64, (long)y.hi64);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3(long3 min, long3 max)
        {
VectorAssert.IsNotSmaller<long3, long>(max, min, 3);

            max -= min;

            UInt128 x = UInt128.umul128(NextState(), (ulong)(max.x));
            UInt128 y = UInt128.umul128(NextState(), (ulong)(max.y));
            UInt128 z = UInt128.umul128(NextState(), (ulong)(max.z));

            return min + new long3((long)x.hi64, (long)y.hi64, (long)z.hi64);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4(long4 min, long4 max)
        {
VectorAssert.IsNotSmaller<long4, long>(max, min, 4);

            ulong4 result = ulong4.zero;
            max -= min;

            UInt128 x = UInt128.umul128(NextState(), (ulong)(max.x));
            UInt128 y = UInt128.umul128(NextState(), (ulong)(max.y));
            UInt128 z = UInt128.umul128(NextState(), (ulong)(max.z));
            UInt128 w = UInt128.umul128(NextState(), (ulong)(max.w));

            return min + new long4((long)x.hi64, (long)y.hi64, (long)z.hi64, (long)w.hi64);
        }


        /// <summary>       Returns a uniformly random <see cref="ulong"/> in the interval [0, 18.446.744.073.709.551.614].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong()
        {
            return NextState() - 1;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong2"/> with all components in the interval [min, 18.446.744.073.709.551.614].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2 NextULong2()
        {
            return ulong.MaxValue + NextState2();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong3"/> with all components in the interval [min, 18.446.744.073.709.551.614].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3()
        {
            return ulong.MaxValue + NextState3();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong4"/> with all components in the interval [min, 18.446.744.073.709.551.614].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4()
        {
            return ulong.MaxValue + NextState4();
        }


        /// <summary>       Returns a uniformly random <see cref="ulong"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong(ulong max)
        {
            return UInt128.umul128(NextState(), max).hi64;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong2"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2 NextULong2(ulong2 max)
        {
            UInt128 x = UInt128.umul128(NextState(), max.x);
            UInt128 y = UInt128.umul128(NextState(), max.y);

            return new ulong2(x.hi64, y.hi64);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong3"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3(ulong3 max)
        {
            UInt128 x = UInt128.umul128(NextState(), max.x);
            UInt128 y = UInt128.umul128(NextState(), max.y);
            UInt128 z = UInt128.umul128(NextState(), max.z);

            return new ulong3(x.hi64, y.hi64, z.hi64);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong4"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4(ulong4 max)
        {
            UInt128 x = UInt128.umul128(NextState(), max.x);
            UInt128 y = UInt128.umul128(NextState(), max.y);
            UInt128 z = UInt128.umul128(NextState(), max.z);
            UInt128 w = UInt128.umul128(NextState(), max.w);

            return new ulong4(x.hi64, y.hi64, z.hi64, w.hi64);
        }


        /// <summary>       Returns a uniformly random <see cref="ulong"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong(ulong min, ulong max)
        {
Assert.IsNotSmaller(max, min);

            return min + UInt128.umul128(NextState(), max - min).hi64;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2 NextULong2(ulong2 min, ulong2 max)
        {
VectorAssert.IsNotSmaller<ulong2, ulong>(max, min, 2);

            max -= min;

            UInt128 x = UInt128.umul128(NextState(), max.x);
            UInt128 y = UInt128.umul128(NextState(), max.y);

            return min + new ulong2(x.hi64, y.hi64);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3(ulong3 min, ulong3 max)
        {
VectorAssert.IsNotSmaller<ulong3, ulong>(max, min, 3);

            max -= min;

            UInt128 x = UInt128.umul128(NextState(), max.x);
            UInt128 y = UInt128.umul128(NextState(), max.y);
            UInt128 z = UInt128.umul128(NextState(), max.z);

            return min + new ulong3(x.hi64, y.hi64, z.hi64);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4(ulong4 min, ulong4 max)
        {
VectorAssert.IsNotSmaller<ulong4, ulong>(max, min, 4);

            max -= min;
            UInt128 x = UInt128.umul128(NextState(), max.x);
            UInt128 y = UInt128.umul128(NextState(), max.y);
            UInt128 z = UInt128.umul128(NextState(), max.z);
            UInt128 w = UInt128.umul128(NextState(), max.w);

            return min + new ulong4(x.hi64, y.hi64, z.hi64, w.hi64);
        }


        /// <summary>       Returns a uniformly random <see cref="double"/> in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            return -1d + asdouble(asulong(1d) | (NextState() >> (F64_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.double2"/> with all components in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2()
        {
            return -1d + asdouble(asulong(1d) | (NextState2() >> (F64_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.double3"/> with all components in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3()
        {
            return -1d + asdouble(asulong(1d) | (NextState3() >> (F64_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.double4"/> with all components in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4()
        {
            return -1d + asdouble(asulong(1d) | (NextState4() >> (F64_EXPONENT_BITS + 1)));
        }


        /// <summary>       Returns a uniformly random <see cref="double"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble(double min, double max)
        {
Assert.IsNotSmaller(max, min);

            return mad(NextDouble(), (max - min), min);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.double2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2(double2 min, double2 max)
        {
VectorAssert.IsNotSmaller<double2, double>(max, min, 2);

            return mad(NextDouble2(), (max - min), min);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.double3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3(double3 min, double3 max)
        {
VectorAssert.IsNotSmaller<double3, double>(max, min, 3);

            return mad(NextDouble3(), (max - min), min);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.double4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4(double4 min, double4 max)
        {
VectorAssert.IsNotSmaller<double4, double>(max, min, 4);

            return mad(NextDouble4(), (max - min), min);
        }
    }
}