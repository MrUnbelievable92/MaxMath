using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DevTools;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       A random number generator for producing uniformly distributed 32-bit values, including vectors of 32-bit values.     </summary>
    [Serializable]
    unsafe public struct Random32
    {
        public const uint DEFAULT_SEED = 1851936439u;

        public uint State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random32(uint seed = DEFAULT_SEED)
        {
            State = seed;

            NextState();
        }


        /// <summary>       Returns a randomly seeded <see cref="Random32"/>.     </summary>
        public static Random32 New
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                uint seed = (uint)Stopwatch.GetTimestamp();
                seed -= tobyte(seed == uint.MaxValue);

                return new Random32 { State = BijectiveHash(seed) };
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Random32(Unity.Mathematics.Random input)
        {
            return *(Random32*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.Random(Random32 input)
        {
            return *(Unity.Mathematics.Random*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random64(Random32 input)
        {
            return new Random64(input.State);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random128(Random32 input)
        {
            return new Random128(input.State);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random8(Random32 input)
        {
            return new Random8 { State = (byte)input.NextUInt(1, byte.MaxValue + 1) };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Random16(Random32 input)
        {
            return new Random16 { State = (ushort)input.NextUInt(1, ushort.MaxValue + 1) };
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint BijectiveHash(uint n)
        {
            if (!constexpr.IS_TRUE(n != 1334218399 - 1))
            {
                n += 1334218399;
            }

            n *= 0x9E3779B1u;
            n = rol(n, 13);
            n ^= 0xA5A5A5A5u;
            n *= 0x85EBCA6Bu;
            n = rol(n, 16);
            n ^= 0xC3C3C3C3u;
            
            return n;
        }

        /// <summary>   Initialized the state of the <see cref="Random32"/> instance with a given seed value. The seed must be non-zero.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void InitState(uint seed = DEFAULT_SEED)
        {
Assert.AreNotEqual(seed, 0u);

            State = seed;
            NextState();
        }
        
        /// <summary>   Constructs a <see cref="Random32"/> instance with an index <paramref name="i"/> that gets hashed. The index must not be <see cref="uint.MaxValue"/>. Use this function when you expect to create several <see cref="Random32"/> instances in a loop.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Random32 CreateFromIndex(uint i)
        {
Assert.AreNotEqual(i, uint.MaxValue);
            
            return new Random32 { State = BijectiveHash(i) };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint NextState()
        {
 Assert.AreNotEqual(State, 0u);

            uint temp = State;

            State ^= State << 13;
            State ^= State >> 17;
            State ^= State << 5;

            return temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint2 NextState2()
        {
            return new uint2(NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint3 NextState3()
        {
            return new uint3(NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint4 NextState4()
        {
            return new uint4(NextState(), NextState(), NextState(), NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint8 NextState8()
        {
            return new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }


        /// <summary>       Returns a uniformly random <see cref="bool"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            return (int)NextState() < 0;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.bool2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.bool3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool3*)&result;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.bool4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool4*)&result;
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


        /// <summary>       Returns a uniformly random <see cref="int"/> in the interval [-2.147.483.647, 2.147.483.647].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt()
        {
            return int.MinValue ^ (int)NextState();
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.int2"/> with all components in the interval [-2.147.483.647, 2.147.483.647].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2()
        {
            return int.MinValue ^ (int2)NextState2();
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.int3"/> with all components in the interval [-2.147.483.647, 2.147.483.647].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3()
        {
            return int.MinValue ^ (int3)NextState3();
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.int4"/> with all components in the interval [-2.147.483.647, 2.147.483.647].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4()
        {
            return int.MinValue ^ (int4)NextState4();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.int8"/> with all components in the interval [-2.147.483.647, 2.147.483.647].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8 NextInt8()
        {
            return int.MinValue ^ (int8)NextState8();
        }


        /// <summary>       Returns a uniformly random <see cref="int"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int min, int max)
        {
            return min + (int)((NextState() * (ulong)(max - min)) >> 32);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.int2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2(int2 min, int2 max)
        {
VectorAssert.IsNotSmaller<int2, int>(max, min, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hiProd = Xse.mul_epu32(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())), (ulong2)(max - min));
                hiProd = Xse.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

                return min + (int2)hiProd;
            }
            else
            {
                return new int2(NextInt(min.x, max.x),
                                NextInt(min.y, max.y));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.int3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(int3 min, int3 max)
        {
VectorAssert.IsNotSmaller<int3, int>(max, min, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                int3 dif = max - min;

                v128 lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v128 hi = Xse.cvtsi32_si128((int)NextState());
                lo = Xse.mul_epu32(lo, (ulong2)(uint2)(dif.xy));
                hi = Xse.mul_epu32(hi, Xse.bsrli_si128(dif, 2 * sizeof(int)));
                v128 result = Xse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));

                return min + (int3)result;
            }
            else
            {
                return new int3(NextInt2(min.xy, max.xy), NextInt(min.z, max.z));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.int4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(int4 min, int4 max)
        {
VectorAssert.IsNotSmaller<int4, int>(max, min, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                int4 dif = max - min;

                v128 lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v128 hi = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                lo = Xse.mul_epu32(lo, (ulong2)(uint2)(dif.xy));
                hi = Xse.mul_epu32(hi, (ulong2)(uint2)(dif.zw));
                v128 result = Xse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));

                return min + (int4)result;
            }
            else
            {
                return new int4(NextInt2(min.xy, max.xy), NextInt2(min.zw, max.zw));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.int8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8 NextInt8(int8 min, int8 max)
        {
VectorAssert.IsNotSmaller<int8, int>(max, min, 8);

            if (Avx2.IsAvx2Supported)
            {
                max -= min;

                v256 lo_lo = Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())));
                v128 hi_lo =                           Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v256 lo_hi = Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())));
                v128 hi_hi =                           Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));

                v256 hiProd_lo = Xse.mm256_cvt2x2epu32_epi64(max, out v256 hiProd_hi);
                hiProd_lo = Avx2.mm256_mul_epu32(hiProd_lo, Avx2.mm256_inserti128_si256(lo_lo, hi_lo, 1));
                hiProd_hi = Avx2.mm256_mul_epu32(hiProd_hi, Avx2.mm256_inserti128_si256(lo_hi, hi_hi, 1));

                return min + (int8)Avx.mm256_shuffle_ps(hiProd_lo, hiProd_hi, Sse.SHUFFLE(3, 1, 3, 1));
            }
            else
            {
                return new int8(NextInt4(min.v4_0, max.v4_0), NextInt4(min.v4_4, max.v4_4));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="uint"/> in the interval [0, 4.294.967.294].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt()
        {
            return NextState() - 1;
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint2"/> with all components in the interval [0, 4.294.967.294].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2()
        {
            return uint.MaxValue + NextState2();
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint3"/> with all components in the interval [0, 4.294.967.294].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3()
        {
            return uint.MaxValue + NextState3();
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint4"/> with all components in the interval [0, 4.294.967.294].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4()
        {
            return uint.MaxValue + NextState4();
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.uint8"/> with all components in the interval [0, 4.294.967.294].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8()
        {
            return uint.MaxValue + NextState8();
        }


        /// <summary>       Returns a uniformly random <see cref="uint"/> in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint max)
        {
            return (uint)((NextState() * (ulong)max) >> 32);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint2"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 max)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hiProd = Xse.mul_epu32(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())), (ulong2)max);
                hiProd = Xse.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

                return hiProd;
            }
            else
            {
                return new uint2(NextUInt(max.x),
                                 NextUInt(max.y));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint3"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 max)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v128 hi = Xse.cvtsi32_si128((int)NextState());
                lo = Xse.mul_epu32(lo, (ulong2)(max.xy));
                hi = Xse.mul_epu32(hi, Xse.bsrli_si128(max, 2 * sizeof(int)));
                v128 result = Xse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));

                return result;
            }
            else
            {
                return new uint3(NextUInt2(max.xy), NextUInt(max.z));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint4"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 max)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v128 hi = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                lo = Xse.mul_epu32(lo, (ulong2)(max.xy));
                hi = Xse.mul_epu32(hi, (ulong2)(max.zw));
                v128 result = Xse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));

                return result;
            }
            else
            {
                return new uint4(NextUInt2(max.xy), NextUInt2(max.zw));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.uint8"/> with all components in the interval [0, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8(uint8 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo_lo = Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())));
                v128 hi_lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v256 lo_hi = Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())));
                v128 hi_hi = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));

                v256 hiProd_lo = Xse.mm256_cvt2x2epu32_epi64(max, out v256 hiProd_hi);
                hiProd_lo = Avx2.mm256_mul_epu32(hiProd_lo, Avx2.mm256_inserti128_si256(lo_lo, hi_lo, 1));
                hiProd_hi = Avx2.mm256_mul_epu32(hiProd_hi, Avx2.mm256_inserti128_si256(lo_hi, hi_hi, 1));

                return Avx.mm256_shuffle_ps(hiProd_lo, hiProd_hi, Sse.SHUFFLE(3, 1, 3, 1));
            }
            else
            {
                return new uint8(NextUInt4(max.v4_0), NextUInt4(max.v4_4));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="uint"/> in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint min, uint max)
        {
            return min + (uint)((NextState() * (ulong)(max - min)) >> 32);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 min, uint2 max)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hiProd = Xse.mul_epu32(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())), (ulong2)(max - min));
                hiProd = Xse.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

                return min + (uint2)hiProd;
            }
            else
            {
                return new uint2(NextUInt(min.x, max.x),
                                 NextUInt(min.y, max.y));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 min, uint3 max)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                uint3 dif = max - min;

                v128 lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v128 hi = Xse.cvtsi32_si128((int)NextState());
                lo = Xse.mul_epu32(lo, (ulong2)dif.xy);
                hi = Xse.mul_epu32(hi, Xse.bsrli_si128(dif, 2 * sizeof(int)));
                v128 result = Xse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));

                return min + (uint3)result;
            }
            else
            {
                return new uint3(NextUInt2(min.xy, max.xy), NextUInt(min.z, max.z));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.uint4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 min, uint4 max)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                uint4 dif = max - min;

                v128 lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v128 hi = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                lo = Xse.mul_epu32(lo, (ulong2)dif.xy);
                hi = Xse.mul_epu32(hi, (ulong2)dif.zw);
                v128 result = Xse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));

                return min + (uint4)result;
            }
            else
            {
                return new uint4(NextUInt2(min.xy, max.xy), NextUInt2(min.zw, max.zw));
            }
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.uint8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>).       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8(uint8 min, uint8 max)
        {
VectorAssert.IsNotSmaller<uint8, uint>(max, min, 8);

            if (Avx2.IsAvx2Supported)
            {
                max -= min;

                v256 lo_lo = Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())));
                v128 hi_lo = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));
                v256 lo_hi = Avx.mm256_castsi128_si256(Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState())));
                v128 hi_hi = Xse.unpacklo_epi64(Xse.cvtsi32_si128((int)NextState()), Xse.cvtsi32_si128((int)NextState()));

                v256 hiProd_lo = Xse.mm256_cvt2x2epu32_epi64(max, out v256 hiProd_hi);
                hiProd_lo = Avx2.mm256_mul_epu32(hiProd_lo, Avx2.mm256_inserti128_si256(lo_lo, hi_lo, 1));
                hiProd_hi = Avx2.mm256_mul_epu32(hiProd_hi, Avx2.mm256_inserti128_si256(lo_hi, hi_hi, 1));

                return min + (uint8)Avx.mm256_shuffle_ps(hiProd_lo, hiProd_hi, Sse.SHUFFLE(3, 1, 3, 1));
            }
            else
            {
                return new uint8(NextUInt4(min.v4_0, max.v4_0), NextUInt4(min.v4_4, max.v4_4));
            }
        }


        /// <summary>       Returns a uniformly random <see cref="float"/> in the interval [0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return -1f + asfloat(asuint(1f) | (NextState() >> (F32_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.float2"/> with all components in the interval [0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2()
        {
            return -1f + asfloat(asuint(1f) | (NextState2() >> (F32_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.float3"/> with all components in the interval [0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3()
        {
            return -1f + asfloat(asuint(1f) | (NextState3() >> (F32_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.float4"/> with all components in the interval [0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4()
        {
            return -1f + asfloat(asuint(1f) | (NextState4() >> (F32_EXPONENT_BITS + 1)));
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.float8"/> with all components in the interval [0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8()
        {
            return -1f + asfloat(asuint(1f) | (NextState8() >> (F32_EXPONENT_BITS + 1)));
        }


        /// <summary>       Returns a uniformly random <see cref="float"/> in the interval [<paramref name="min"/>, <paramref name="max"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float min, float max)
        {
Assert.IsNotSmaller(max, min);

            return mad(NextFloat(), max - min, min);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.float2"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2(float2 min, float2 max)
        {
VectorAssert.IsNotSmaller<float2, float>(max, min, 2);

            return mad(NextFloat2(), max - min, min);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.float3"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3(float3 min, float3 max)
        {
VectorAssert.IsNotSmaller<float3, float>(max, min, 3);

            return mad(NextFloat3(), max - min, min);
        }

        /// <summary>       Returns a uniformly random <see cref="Unity.Mathematics.float4"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4(float4 min, float4 max)
        {
VectorAssert.IsNotSmaller<float4, float>(max, min, 4);

            return mad(NextFloat4(), max - min, min);
        }

        /// <summary>       Returns a uniformly random <see cref="MaxMath.float8"/> with all components in the interval [<paramref name="min"/>, <paramref name="max"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8(float8 min, float8 max)
        {
VectorAssert.IsNotSmaller<float8, float>(max, min, 8);

            return mad(NextFloat8(), max - min, min);
        }


        /// <summary>       Returns a unit length <see cref="float2"/> vector representing a uniformly random 2D direction.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2Direction()
        {
            float angle = NextFloat() * (PI * 2f);
            sincos(angle, out float s, out float c);
            return new float2(c, s);
        }

        /// <summary>       Returns a unit length <see cref="float3"/> vector representing a uniformly random 3D direction.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3Direction()
        {
            float2 rnd = NextFloat2();
            rnd = mad(rnd, new float2(2f, PI * 2f), new float2(-1f, 0f));
            float r = sqrt(max(1f - square(rnd.x), 0f));
            sincos(rnd.y, out float s, out float c);
            return new float3(r * new float2(c, s), rnd.x);
        }

        /// <summary>       Returns a unit length <see cref="quaternion"/> representing a uniformly random 3D rotation.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quaternion NextQuaternionRotation()
        {
            float3 rnd = NextFloat3(0f, new float3(2f * PI, 2f * PI, 1f));

            sincos(rnd.xy, out float2 sin_theta_rho, out float2 cos_theta_rho);
            float4 u = sqrt(mad(rnd.zzzz, new float4(-1f, -1f, 1f, 1f), new float4(1f, 1f, 0f, 0f)));

            quaternion q = new quaternion(u * shuffle(sin_theta_rho, cos_theta_rho, ShuffleComponent.LeftX, ShuffleComponent.RightX, ShuffleComponent.LeftY, ShuffleComponent.RightY));
            return new quaternion(select(q.value, -q.value, q.value.wwww < 0f));
        }
    }
}