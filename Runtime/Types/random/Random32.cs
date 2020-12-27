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
Assert.AreNotEqual(seed, 0u);

            State = seed;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Random32(Unity.Mathematics.Random input)
        {
            return new Random32(input.state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.Random(Random32 input)
        {
            return new Unity.Mathematics.Random(input.State);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint NextState()
        {
 Assert.AreNotEqual(State, 0u);

            uint t = State;

            State ^= State << 13;
            State ^= State >> 17;
            State ^= State << 5;

            return t;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool NextBool()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2 NextBool2()
        {
            uint result = NextState() & 0x0101_0101u;

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3 NextBool3()
        {
            uint result = NextState() & 0x0101_0101u;

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
            return int.MinValue ^ (int)NextState();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2()
        {
            return int.MinValue ^ new int2((int)NextState(), (int)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3()
        {
            return int.MinValue ^ new int3((int)NextState(), (int)NextState(), (int)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4()
        {
            return int.MinValue ^ new int4((int)NextState(), (int)NextState(), (int)NextState(), (int)NextState());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8 NextInt8()
        {
            return int.MinValue ^ new int8((int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState(), (int)NextState());
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int NextInt(int min, int max)
        {
          return min + (int)((NextState() * (ulong)(max - min)) >> 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2 NextInt2(int2 min, int2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            v128 hiProd = Sse2.mul_epu32(new v128(NextState(), 0, NextState(), 0), (ulong2)(max - min));
            hiProd = Sse2.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

            return min + *(int2*)&hiProd;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3 NextInt3(int3 min, int3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, 0, 0), (long3)(max - min));
            hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, new v256(1, 3, 5, 0, 0, 0, 0, 0));
        
            return min + *(int3*)&hiProd;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4 NextInt4(int4 min, int4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (long4)(max - min));
            hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return min + *(int4*)&hiProd;
        }
        
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

            max -= min;

            v256 hiProd_lo = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (long4)max.v4_0);
            v256 hiProd_hi = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (long4)max.v4_4);

            hiProd_lo = Avx2.mm256_permutevar8x32_epi32(hiProd_lo, new v256(1, 3, 5, 7, 0, 0, 0, 0));
            hiProd_hi = Avx2.mm256_permutevar8x32_epi32(hiProd_hi, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return min + Avx.mm256_set_m128i(Avx.mm256_castsi256_si128(hiProd_hi), Avx.mm256_castsi256_si128(hiProd_lo));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt()
        {
            return uint.MaxValue + NextState();
        }
  
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2()
        {
            return uint.MaxValue + new uint2(NextState(), NextState());
        }
  
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3()
        {
            return uint.MaxValue + new uint3(NextState(), NextState(), NextState());
        }
  
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4()
        {
            return uint.MaxValue + new uint4(NextState(), NextState(), NextState(), NextState());
        }
  
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8()
        {
            return uint.MaxValue + new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState());
        }
  
  
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint max)
        {
            return (uint)((NextState() * (ulong)max) >> 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 max)
        {
            v128 hiProd = Sse2.mul_epu32(new v128(NextState(), 0, NextState(), 0), (ulong2)max);
            hiProd = Sse2.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

            return *(uint2*)&hiProd;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 max)
        {
            v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, 0, 0), (ulong3)max);
            hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, new v256(1, 3, 5, 0, 0, 0, 0, 0));

            return *(uint3*)&hiProd;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 max)
        {
            v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max);
            hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return *(uint4*)&hiProd;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8 NextUInt8(uint8 max)
        {
            v256 hiProd_lo = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_0);
            v256 hiProd_hi = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_4);

            hiProd_lo = Avx2.mm256_permutevar8x32_epi32(hiProd_lo, new v256(1, 3, 5, 7, 0, 0, 0, 0));
            hiProd_hi = Avx2.mm256_permutevar8x32_epi32(hiProd_hi, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return Avx.mm256_set_m128i(Avx.mm256_castsi256_si128(hiProd_hi), Avx.mm256_castsi256_si128(hiProd_lo));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint NextUInt(uint min, uint max)
        {
            return min + (uint)((NextState() * (ulong)(max - min)) >> 32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2 NextUInt2(uint2 min, uint2 max)
        {
            v128 hiProd = Sse2.mul_epu32(new v128(NextState(), 0, NextState(), 0), (ulong2)(max - min));
            hiProd = Sse2.shuffle_epi32(hiProd, Sse.SHUFFLE(0, 0, 3, 1));

            return min + *(uint2*)&hiProd;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3 NextUInt3(uint3 min, uint3 max)
        {
            v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, 0, 0), (ulong3)(max - min));
            hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, new v256(1, 3, 5, 0, 0, 0, 0, 0));

            return min + *(uint3*)&hiProd;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4 NextUInt4(uint4 min, uint4 max)
        {
            v256 hiProd = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)(max - min));
            hiProd = Avx2.mm256_permutevar8x32_epi32(hiProd, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return min + *(uint4*)&hiProd;
        }
        
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

            max -= min;

            v256 hiProd_lo = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_0);
            v256 hiProd_hi = Avx2.mm256_mul_epu32(new v256(NextState(), 0, NextState(), 0, NextState(), 0, NextState(), 0), (ulong4)max.v4_4);

            hiProd_lo = Avx2.mm256_permutevar8x32_epi32(hiProd_lo, new v256(1, 3, 5, 7, 0, 0, 0, 0));
            hiProd_hi = Avx2.mm256_permutevar8x32_epi32(hiProd_hi, new v256(1, 3, 5, 7, 0, 0, 0, 0));

            return min + Avx.mm256_set_m128i(Avx.mm256_castsi256_si128(hiProd_hi), Avx.mm256_castsi256_si128(hiProd_lo));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return -1f + math.asfloat(0x3F80_0000 | (NextState() >> 9));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2()
        {
            return -1f + math.asfloat(0x3F80_0000 | (new uint2(NextState(), NextState()) >> 9));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3()
        {
            return -1f + math.asfloat(0x3F80_0000 | (new uint3(NextState(), NextState(), NextState()) >> 9));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4()
        {
            return -1f + math.asfloat(0x3F80_0000 | (new uint4(NextState(), NextState(), NextState(), NextState()) >> 9));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8 NextFloat8()
        {
            return -1f + maxmath.asfloat(0x3F80_0000 | (new uint8(NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState(), NextState()) >> 9));
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat(float min, float max) 
        {
Assert.IsNotSmaller(max, min);

            return math.mad(NextFloat(), max - min, min);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2 NextFloat2(float2 min, float2 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);

            return math.mad(NextFloat2(), max - min, min);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3 NextFloat3(float3 min, float3 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);

            return math.mad(NextFloat3(), max - min, min);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4 NextFloat4(float4 min, float4 max)
        {
Assert.IsNotSmaller(max.x, min.x);
Assert.IsNotSmaller(max.y, min.y);
Assert.IsNotSmaller(max.z, min.z);
Assert.IsNotSmaller(max.w, min.w);

            return math.mad(NextFloat4(), max - min, min);
        }
        
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