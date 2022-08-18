using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

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
                seed += maxmath.tobyte(seed == 0);
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


        /// <summary>       Returns a uniformly random <see cref="bool"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool3*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="bool4"/>.     </summary>
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
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(new v128(0x0101_0101_0101_0101ul), new v128(NextState(), NextState()));
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
                return Avx2.mm256_and_si256(new v256(0x0101_0101_0101_0101ul), new v256(NextState(), NextState(), NextState(), NextState()));
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
            return long.MinValue ^ new long2((long)NextState(), (long)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long3"/> with all components in the interval [-9.223.372.036.854.775.807, 9.223.372.036.854.775.807].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3()
        {
            return long.MinValue ^ new long3((long)NextState(), (long)NextState(), (long)NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long4"/> with all components in the interval [-9.223.372.036.854.775.807, 9.223.372.036.854.775.807].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4()
        {
            return long.MinValue ^ new long4((long)NextState(), (long)NextState(), (long)NextState(), (long)NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="long"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long NextLong(long min, long max)
        {
Assert.IsNotSmaller(max, min);

            Common.umul128(NextState(), (ulong)(max - min), out ulong result);

            return min + (long)result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2 NextLong2(long2 min, long2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            ulong2 result = ulong2.zero;
            max -= min;

            Common.umul128(NextState(), (ulong)(max.x), out result.x);
            Common.umul128(NextState(), (ulong)(max.y), out result.y);

            return min + (long2)result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3 NextLong3(long3 min, long3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            ulong3 result = ulong3.zero;
            max -= min;

            Common.umul128(NextState(), (ulong)(max.x), out result.x);
            Common.umul128(NextState(), (ulong)(max.y), out result.y);
            Common.umul128(NextState(), (ulong)(max.z), out result.z);

            return min + (long3)result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.long4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4 NextLong4(long4 min, long4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            ulong4 result = ulong4.zero;
            max -= min;
            
            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_mulhi_epu64(NextULong4(), max, out _, false);
            }
            else
            {
                Common.umul128(NextState(), (ulong)max.x, out result.x);
                Common.umul128(NextState(), (ulong)max.y, out result.y);
                Common.umul128(NextState(), (ulong)max.z, out result.z);
                Common.umul128(NextState(), (ulong)max.w, out result.w);
            }

            return min + (long4)result;
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
            return ulong.MaxValue + new ulong2(NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong3"/> with all components in the interval [min, 18.446.744.073.709.551.614].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3()
        {
            return ulong.MaxValue + new ulong3(NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong4"/> with all components in the interval [min, 18.446.744.073.709.551.614].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4()
        {
            return ulong.MaxValue + new ulong4(NextState(), NextState(), NextState(), NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="ulong"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong(ulong max)
        {
            Common.umul128(NextState(), max, out ulong result);

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong2"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2 NextULong2(ulong2 max)
        {
            ulong2 result;

            Common.umul128(NextState(), max.x, out result.x);
            Common.umul128(NextState(), max.y, out result.y);

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong3"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3(ulong3 max)
        {
            ulong3 result = ulong3.zero;

            Common.umul128(NextState(), max.x, out result.x);
            Common.umul128(NextState(), max.y, out result.y);
            Common.umul128(NextState(), max.z, out result.z);

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong4"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4(ulong4 max)
        {
            ulong4 result = ulong4.zero;
            
            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_mulhi_epu64(NextULong4(), max, out _, false);
            }
            else
            {
                Common.umul128(NextState(), max.x, out result.x);
                Common.umul128(NextState(), max.y, out result.y);
                Common.umul128(NextState(), max.z, out result.z);
                Common.umul128(NextState(), max.w, out result.w);
            }

            return result;
        }


        /// <summary>       Returns a uniformly random <see cref="ulong"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong NextULong(ulong min, ulong max)
        {
Assert.IsNotSmaller(max, min);

            Common.umul128(NextState(), max - min, out ulong result);

            return min + result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2 NextULong2(ulong2 min, ulong2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            max -= min;
            ulong2 result;

            Common.umul128(NextState(), max.x, out result.x);
            Common.umul128(NextState(), max.y, out result.y);

            return min + result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3 NextULong3(ulong3 min, ulong3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            max -= min;
            ulong3 result = ulong3.zero;

            Common.umul128(NextState(), max.x, out result.x);
            Common.umul128(NextState(), max.y, out result.y);
            Common.umul128(NextState(), max.z, out result.z);

            return min + result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.ulong4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4 NextULong4(ulong4 min, ulong4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            max -= min;
            ulong4 result = ulong4.zero;

            if (Avx2.IsAvx2Supported)
            {
                result = Xse.mm256_mulhi_epu64(NextULong4(), max, out _, false);
            }
            else
            {
                Common.umul128(NextState(), max.x, out result.x);
                Common.umul128(NextState(), max.y, out result.y);
                Common.umul128(NextState(), max.z, out result.z);
                Common.umul128(NextState(), max.w, out result.w);
            }

            return min + result;
        }
        

        /// <summary>       Returns a uniformly random <see cref="double"/> in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            return -1d + math.asdouble(0x3FF0_0000_0000_0000 | (NextState() >> 12));
        }

        /// <summary>       Returns a uniformly random <see cref="double2"/> with all components in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2()
        {
            return -1d + maxmath.asdouble(0x3FF0_0000_0000_0000 | (new ulong2(NextState(), NextState()) >> 12));
        }

        /// <summary>       Returns a uniformly random <see cref="double3"/> with all components in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3()
        {
            return -1d + maxmath.asdouble(0x3FF0_0000_0000_0000 | (new ulong3(NextState(), NextState(), NextState()) >> 12));
        }

        /// <summary>       Returns a uniformly random <see cref="double4"/> with all components in the interval [0, 1).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4()
        {
            return -1d + maxmath.asdouble(0x3FF0_0000_0000_0000 | (new ulong4(NextState(), NextState(), NextState(), NextState()) >> 12));
        }


        /// <summary>       Returns a uniformly random <see cref="double"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble(double min, double max) 
        { 
Assert.IsNotSmaller(max, min);

            return math.mad(NextDouble(), (max - min), min);
        }

        /// <summary>       Returns a uniformly random <see cref="double2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2 NextDouble2(double2 min, double2 max) 
        { 
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            return math.mad(NextDouble2(), (max - min), min);
        }

        /// <summary>       Returns a uniformly random <see cref="double3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3 NextDouble3(double3 min, double3 max) 
        { 
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            return math.mad(NextDouble3(), (max - min), min);
        }

        /// <summary>       Returns a uniformly random <see cref="double4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4 NextDouble4(double4 min, double4 max) 
        { 
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            return math.mad(NextDouble4(), (max - min), min);
        }
    }
}