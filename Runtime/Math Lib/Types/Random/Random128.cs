using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
    /// <summary>       A random number generator for producing uniformly distributed 128-bit values.     </summary>
    [Serializable]
    unsafe public struct Random128
    {
        public static UInt128 DEFAULT_SEED => new UInt128(0xE7A1_F3C9_2D5B_6A40ul, 0x8C4F_21BE_97D0_A653ul);

        public UInt128 State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random128(UInt128 seed = default)
        {
            if (constexpr.IS_TRUE(seed == 0))
            {
                seed = DEFAULT_SEED;
            }
            
            State = seed;

            NextState();
        }


        /// <summary>       Returns a randomly seeded <see cref="Random128"/>.     </summary>
        public static Random128 New
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new Random128 { State = BijectiveHash((ulong)Stopwatch.GetTimestamp()) };
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
        private static UInt128 BijectiveHash(ulong n)
        {
            UInt128 __n = UInt128.umul((UInt128)n, 0x9E3779B97F4A7C15ul);
            __n = rol(__n, 47);
            __n ^= new UInt128(0xD6E8FEB86659FD93ul, 0xA4093822299F31D0ul);
            __n = UInt128.umul(__n, 0xBF58476D1CE4E5B9ul);
            __n = rol(__n, 79);
            __n ^= new UInt128(0xC3A5C85C97CB3127ul, 0xB492B66FBE98F273ul);

            return __n;
        }

        /// <summary>   Initialized the state of the <see cref="Random128"/> instance with a given seed value. The seed must be non-zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InitState(UInt128 seed = default)
        {
            if (constexpr.IS_TRUE(seed == 0))
            {
                seed = DEFAULT_SEED;
            }
            
Assert.AreNotEqual(seed, (UInt128)0);

            State = seed;
            NextState();
        }
        
        /// <summary>   Constructs a <see cref="Random128"/> instance with an index <paramref name="i"/> that gets hashed. Use this function when you expect to create several <see cref="Random128"/> instances in a loop.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Random128 CreateFromIndex(uint i)
        {
            return new Random128 { State = BijectiveHash(i) };
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
            return (long)NextState().hi64 < 0;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = (uint)NextState() & 0x0101_0101u;

            return *(bool3*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.bool4"/>.     </summary>
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                UInt128 next = NextState();

                return Xse.and_si128(new v128(0x0101_0101_0101_0101ul), new v128(next.lo64, next.hi64));
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

                return Avx2.mm256_and_si256(new v256(0x0101_0101_0101_0101ul), new v256(next_lo.lo64, next_lo.hi64, next_hi.lo64, next_hi.hi64));
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
            return MaxMath.Int128.MinValue ^ (Int128)NextState();
        }

        /// <summary>       Returns a uniformly random <see cref="Int128"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128 NextInt128(Int128 min, Int128 max)
        {
Assert.IsNotSmaller(max, min);

            __UInt256__ product = __UInt256__.umul256(NextState(), (UInt128)(max - min));

            return (Int128)((UInt128)min + product.hi128);
        }


        /// <summary>       Returns a uniformly random <see cref="UInt128"/> in the interval [0, <see cref="MaxMath.UInt128.MaxValue"/> - 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 NextUInt128()
        {
            return NextState() - 1;
        }

        /// <summary>       Returns a uniformly random <see cref="UInt128"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 NextUInt128(UInt128 max)
        {
            __UInt256__ product = __UInt256__.umul256(NextState(), max);

            return product.hi128;
        }

        /// <summary>       Returns a uniformly random <see cref="UInt128"/> in the interval [<paramref name="min"/>, <paramref name="max"/>].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128 NextUInt128(UInt128 min, UInt128 max)
        {
Assert.IsNotSmaller(max, min);

           __UInt256__ product =  __UInt256__.umul256(NextState(), max - min);

            return min + product.hi128;
        }


        /// <summary>       Returns a uniformly random <see cref="quadruple"/> in the interval [0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple NextQuadruple()
        {
            quadruple.ConstChecked left = asquadruple(math.ONE_AS_QUADRUPLE | (NextState() >> (quadruple.EXPONENT_BITS + 1)));
            left.Promise |= FloatingPointPromise<quadruple>.NOT_INF;
            left.Promise |= FloatingPointPromise<quadruple>.NOT_NAN;
            left.Promise |= FloatingPointPromise<quadruple>.POSITIVE;

            quadruple.ConstChecked result = quadruple.Subtract(left, asquadruple(math.ONE_AS_QUADRUPLE), sameSign: true);
            left.Promise |= FloatingPointPromise<quadruple>.NOT_INF;
            left.Promise |= FloatingPointPromise<quadruple>.NOT_NAN;
            left.Promise |= FloatingPointPromise<quadruple>.POSITIVE;
            left.Promise.MinPossible = 0d;
            left.Promise.MaxPossible = nextsmaller((quadruple)1d);

            return result;
        }

        /// <summary>       Returns a uniformly random <see cref="quadruple"/> in the interval [<paramref name="min"/>, <paramref name="max"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple NextQuadruple(quadruple min, quadruple max)
        {
Assert.IsNotSmaller(max, min);

            quadruple.ConstChecked left = asquadruple(math.ONE_AS_QUADRUPLE | (NextState() >> (quadruple.EXPONENT_BITS + 1)));
            left.Promise |= FloatingPointPromise<quadruple>.NOT_INF;
            left.Promise |= FloatingPointPromise<quadruple>.NOT_NAN;
            left.Promise |= FloatingPointPromise<quadruple>.POSITIVE;
            left.Promise.MinPossible = 1d;
            left.Promise.MaxPossible = nextsmaller((quadruple)2d);

            quadruple.ConstChecked result = quadruple.fmadd(quadruple.Subtract(left, asquadruple(math.ONE_AS_QUADRUPLE), sameSign: true), max - min, min);
            left.Promise.MinPossible = min;
            left.Promise.MaxPossible = constexpr.IS_CONST(max) ? nextsmaller(max) : max;

            return result;
        }
    }
}