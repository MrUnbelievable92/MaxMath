using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random128
    {
        public UInt128 State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random128(UInt128 seed)
        {
            State = seed;

            NextState();
        }

        
        /// <summary>       Returns a randomly seeded <see cref="Random128"/>.     </summary>
        public static Random128 New
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get 
            {
                ulong seed = (ulong)Environment.TickCount;
                seed += maxmath.tobyte(seed == 0);
                
                seed ^= seed >> 24;
                UInt128 seed128 = seed;
                seed128 ^= seed128 << 69;
                seed128 ^= seed128 >> 35;

                return new Random128{ State = seed128 };
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random8(Random128 input)
        {
            return new Random8 { State = (byte)input.NextUInt128(1, byte.MaxValue + 1) };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random16(Random128 input)
        {
            return new Random16 { State = (ushort)input.NextUInt128(1, ushort.MaxValue + 1) };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random32(Random128 input)
        {
            return new Random32 { State = (uint)input.NextUInt128(1, (ulong)uint.MaxValue + 1) };
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random64(Random128 input)
        {
            return new Random64 { State = (uint)input.NextUInt128(1, (UInt128)ulong.MaxValue + 1) };
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private UInt128 NextState()
        {
Assert.AreNotEqual(State, (UInt128)0);

            UInt128 temp = State;

            State ^= State >> 24;
            State ^= State << 69;
            State ^= State >> 35;

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
            ulong result = (ulong)NextState() & 0x0101_0101_0101_0101ul;

            return *(bool8*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16 NextBool16()
        {
            if (Sse2.IsSse2Supported)
            {
                UInt128 next = NextState();

                return Sse2.and_si128(new v128(0x0101_0101_0101_0101ul), new v128(next.lo, next.hi));
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
                UInt128 next_lo = NextState();
                UInt128 next_hi = NextState();

                return Avx2.mm256_and_si256(new v256(0x0101_0101_0101_0101ul), new v256(next_lo.lo, next_lo.hi, next_hi.lo, next_hi.hi));
            }
            else
            {
                return new bool32(NextBool16(), NextBool16());
            }
        }


        /// <summary>       Returns a uniformly random <see cref="Int128"/> in the interval [<see cref="Int128.MinValue"/>, <see cref="Int128.MaxValue"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128 NextInt128()
        {
            return Int128.MinValue ^ (Int128)NextState();
        }

        /// <summary>       Returns a uniformly random <see cref="Int128"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128 NextInt128(Int128 min, Int128 max)
        {
Assert.IsNotSmaller(max, min);

            Operator.umul256(NextState(), (UInt128)(max - min), out UInt128 result, lo: false);

            return (Int128)((UInt128)min + result);
        }


        /// <summary>       Returns a uniformly random <see cref="UInt128"/> in the interval [0, <see cref="UInt128.MaxValue"/> - 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 NextUInt128()
        {
            return NextState() - 1;
        }

        /// <summary>       Returns a uniformly random <see cref="UInt128"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 NextUInt128(UInt128 max)
        {
            Operator.umul256(NextState(), max, out UInt128 result, lo: false);

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="UInt128"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 NextUInt128(UInt128 min, UInt128 max)
        {
Assert.IsNotSmaller(max, min);

            Operator.umul256(NextState(), max - min, out UInt128 result, lo: false);

            return min + result;
        }
    }
}