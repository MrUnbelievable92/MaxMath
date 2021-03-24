using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using DevTools;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    unsafe public struct Random32
    {
        public uint State;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Random32(uint seed = 1851936439u)
        {
            State = seed;

            NextState();
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
        private uint NextState()
        {
 Assert.AreNotEqual(State, 0u);

            uint temp = State;

            State ^= State << 13;
            State ^= State >> 17;
            State ^= State << 5;

            return temp;
        }


        /// <summary>       Returns a uniformly random bool value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool*)&result;
        }

        /// <summary>       Returns a uniformly random bool2 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool2*)&result;
        }

        /// <summary>       Returns a uniformly random bool3 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool3*)&result;
        }

        /// <summary>       Returns a uniformly random bool4 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4 NextBool4()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool4*)&result;
        }

        /// <summary>       Returns a uniformly random bool8 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool8 NextBool8()
        {
            bool8 result = ((Random64)this).NextBool8();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random bool16 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool16 NextBool16()
        {
            bool16 result = ((Random64)this).NextBool16();

            NextState();

            return result;
        }

        /// <summary>       Returns a uniformly random bool32 vector.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool32 NextBool32()
        {
            bool32 result = ((Random64)this).NextBool32();

            NextState();

            return result;
        }


        /// <summary>       Returns a uniformly random int value in the interval [-2.147.483.647, 2.147.483.647].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt()
        {
            return int.MinValue ^ (int)NextState();
        }

        /// <summary>       Returns a uniformly random int2 vector with all components in the interval [-2.147.483.647, 2.147.483.647].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2()
        {
            return int.MinValue ^ new int2((int)NextState(), (int)NextState());
        }

        /// <summary>       Returns a uniformly random int3 vector with all components in the interval [-2.147.483.647, 2.147.483.647].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3()
        {
            return int.MinValue ^ new int3((int)NextState(), (int)NextState(), (int)NextState());
        }

        /// <summary>       Returns a uniformly random int4 vector with all components in the interval [-2.147.483.647, 2.147.483.647].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4()
        {
            return int.MinValue ^ new int4((int)NextState(), (int)NextState(), (int)NextState(), (int)NextState());
        }

        /// <summary>       Returns a uniformly random int8 vector with all components in the interval [-2.147.483.647, 2.147.483.647].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8 NextInt8()
        {
            return int.MinValue ^ new int8((int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState());
        }


        /// <summary>       Returns a uniformly random int value with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int min, int max)
        {
          return min + (int)((NextState() * (ulong)(max - min)) >> 32);
        }

        /// <summary>       Returns a uniformly random int2 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2(int2 min, int2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            if (Sse2.IsSse2Supported)
            {
                v128 hiProd = Sse2.mul_epu32(new v128(NextState(), 0, NextState(), 0), (ulong2)(max - min));
                hiProd = Sse2.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

                return min + *(int2*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextInt2(min, max);
            }
        }

        /// <summary>       Returns a uniformly random int3 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(int3 min, int3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, 0, 0), (long3)(max - min));
                hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return min + *(int3*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextInt3(min, max);
            }
        }

        /// <summary>       Returns a uniformly random int4 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(int4 min, int4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (long4)(max - min));
                hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return min + *(int4*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextInt4(min, max);
            }
        }

        /// <summary>       Returns a uniformly random int8 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8 NextInt8(int8 min, int8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);

            if (Avx2.IsAvx2Supported)
            {
                max -= min;

                v256 hiProd_lo = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (long4)max.v4_0);
                v256 hiProd_hi = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (long4)max.v4_4);

                hiProd_lo = Avx2.mm256_permutevar8x32_epi32(hiProd_lo, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));
                hiProd_hi = Avx2.mm256_permutevar8x32_epi32(hiProd_hi, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return min + Avx.mm256_set_m128i(Avx.mm256_castsi256_si128(hiProd_hi), Avx.mm256_castsi256_si128(hiProd_lo));
            }
            else
            {
                Unity.Mathematics.Random rng = this;

                return new int8(rng.NextInt4(min.v4_0, max.v4_0), rng.NextInt4(min.v4_4, max.v4_4));
            }
        }


        /// <summary>       Returns a uniformly random uint value in the interval [0, 4.294.967.294].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt()
        {
            return uint.MaxValue + NextState();
        }

        /// <summary>       Returns a uniformly random uint2 vector with all components in the interval [0, 4.294.967.294].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2()
        {
            return uint.MaxValue + new uint2(NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random uint3 vector with all components in the interval [0, 4.294.967.294].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3()
        {
            return uint.MaxValue + new uint3(NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random uint4 vector with all components in the interval [0, 4.294.967.294].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4()
        {
            return uint.MaxValue + new uint4(NextState(), NextState(), NextState(), NextState());
        }

        /// <summary>       Returns a uniformly random uint8 vector with all components in the interval [0, 4.294.967.294].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8()
        {
            return uint.MaxValue + new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }


        /// <summary>       Returns a uniformly random uint value in the interval [0, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint max)
        {
            return (uint)((NextState() * (ulong)max) >> 32);
        }

        /// <summary>       Returns a uniformly random uint2 vector with all components in the interval [0, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 hiProd = Sse2.mul_epu32(new v128(NextState(), 0, NextState(), 0), (ulong2)max);
                hiProd = Sse2.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

                return *(uint2*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextUInt2(max);
            }
        }

        /// <summary>       Returns a uniformly random uint3 vector with all components in the interval [0, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, 0, 0), (ulong3)max);
                hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return *(uint3*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextUInt3(max);
            }
        }

        /// <summary>       Returns a uniformly random uint4 vector with all components in the interval [0, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max);
                hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return *(uint4*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextUInt4(max);
            }
        }

        /// <summary>       Returns a uniformly random uint8 vector with all components in the interval [0, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8(uint8 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd_lo = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_0);
                v256 hiProd_hi = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_4);

                hiProd_lo = Avx2.mm256_permutevar8x32_epi32(hiProd_lo, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));
                hiProd_hi = Avx2.mm256_permutevar8x32_epi32(hiProd_hi, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return Avx.mm256_set_m128i(Avx.mm256_castsi256_si128(hiProd_hi), Avx.mm256_castsi256_si128(hiProd_lo));
            }
            else
            {
                Unity.Mathematics.Random rng = this;

                return new uint8(rng.NextUInt4(max.v4_0), rng.NextUInt4(max.v4_4));
            }
        }


        /// <summary>       Returns a uniformly random uint value in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint min, uint max)
        {
            return min + (uint)((NextState() * (ulong)(max - min)) >> 32);
        }

        /// <summary>       Returns a uniformly random uint2 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 min, uint2 max)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 hiProd = Sse2.mul_epu32(new v128(NextState(), 0, NextState(), 0), (ulong2)(max - min));
                hiProd = Sse2.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

                return min + *(uint2*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextUInt2(min, max);
            }
        }

        /// <summary>       Returns a uniformly random uint3 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 min, uint3 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, 0, 0), (ulong3)(max - min));
                hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return min + *(uint3*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextUInt3(min, max);
            }
        }

        /// <summary>       Returns a uniformly random uint4 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 min, uint4 max)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)(max - min));
                hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return min + *(uint4*)&hiProd;
            }
            else
            {
                return ((Unity.Mathematics.Random)this).NextUInt4(min, max);
            }
        }

        /// <summary>       Returns a uniformly random uint8 vector with all components in the interval [min, max).        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8(uint8 min, uint8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);

            if (Avx2.IsAvx2Supported)
            {
                max -= min;

                v256 hiProd_lo = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_0);
                v256 hiProd_hi = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_4);

                hiProd_lo = Avx2.mm256_permutevar8x32_epi32(hiProd_lo, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));
                hiProd_hi = Avx2.mm256_permutevar8x32_epi32(hiProd_hi, Avx.mm256_castsi128_si256(new v128(1, 3, 5, 7)));

                return min + Avx.mm256_set_m128i(Avx.mm256_castsi256_si128(hiProd_hi), Avx.mm256_castsi256_si128(hiProd_lo));
            }
            else
            {
                Unity.Mathematics.Random rng = this;

                return new uint8(rng.NextUInt4(min.v4_0, max.v4_0), rng.NextUInt4(min.v4_4, max.v4_4));
            }
        }


        /// <summary>       Returns a uniformly random float value in the interval [0, 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return -1f + math.asfloat(0x3F80_0000 | (NextState() >> 9));
        }

        /// <summary>       Returns a uniformly random float2 vector with all components in the interval [0, 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2()
        {
            return -1f + math.asfloat(0x3F80_0000 | (new uint2(NextState(), NextState()) >> 9));
        }

        /// <summary>       Returns a uniformly random float3 vector with all components in the interval [0, 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3()
        {
            return -1f + math.asfloat(0x3F80_0000 | (new uint3(NextState(), NextState(), NextState()) >> 9));
        }

        /// <summary>       Returns a uniformly random float4 vector with all components in the interval [0, 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4()
        {
            return -1f + math.asfloat(0x3F80_0000 | (new uint4(NextState(), NextState(), NextState(), NextState()) >> 9));
        }

        /// <summary>       Returns a uniformly random float8 vector with all components in the interval [0, 1).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8()
        {
            return -1f + maxmath.asfloat(0x3F80_0000 | (new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()) >> 9));
        }


        /// <summary>       Returns a uniformly random float valuewith in the interval [min, max).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float min, float max) 
        {
Assert.IsNotSmaller(max, min);

            return math.mad(NextFloat(), max - min, min);
        }

        /// <summary>       Returns a uniformly random float2 vector with all components in the interval [min, max).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2(float2 min, float2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            return math.mad(NextFloat2(), max - min, min);
        }

        /// <summary>       Returns a uniformly random float3 vector with all components in the interval [min, max).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3(float3 min, float3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            return math.mad(NextFloat3(), max - min, min);
        }

        /// <summary>       Returns a uniformly random float4 vector with all components in the interval [min, max).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4(float4 min, float4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            return math.mad(NextFloat4(), max - min, min);
        }

        /// <summary>       Returns a uniformly random float8 vector with all components in the interval [min, max).      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8(float8 min, float8 max)
        {
Assert.IsNotSmaller(max.x0, min.x0);
Assert.IsNotSmaller(max.x1, min.x1);
Assert.IsNotSmaller(max.x2, min.x2);
Assert.IsNotSmaller(max.x3, min.x3);
Assert.IsNotSmaller(max.x4, min.x4);
Assert.IsNotSmaller(max.x5, min.x5);
Assert.IsNotSmaller(max.x6, min.x6);
Assert.IsNotSmaller(max.x7, min.x7);

            return maxmath.mad(NextFloat8(), max - min, min);
        }
    }
}