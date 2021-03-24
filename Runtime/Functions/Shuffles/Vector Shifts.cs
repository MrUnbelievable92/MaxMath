using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of shifting the components within an int2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vshl(int2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: v128 temp = Sse2.bslli_si128(*(v128*)&x, sizeof(int)); return *(int2*)&temp;

                    default: return default(int2);
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int2(0, x.x);

                    default: return default(int2);
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an int3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vshl(int3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128  temp ;

                switch (n)
                {
                    case 0: return x;

                    case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(int)); return *(int3*)&temp;
                    case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int3*)&temp;

                    default: return default(int3);
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int3(0, x.x, x.y);
                    case 2: return new int3(0,   0, x.x);

                    default: return default(int3);
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an int4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 vshl(int4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128  temp ;

                switch (n)
                {
                    case 0: return x;

                    case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(int)); return *(int4*)&temp;
                    case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int4*)&temp;
                    case 3: temp = Sse2.bslli_si128(*(v128*)&x, 3 * sizeof(int)); return *(int4*)&temp;

                    default: return default(int4);
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int4(0, x.x, x.y, x.z);
                    case 2: return new int4(0,   0, x.x, x.y);
                    case 3: return new int4(0,   0,   0, x.x);

                    default: return default(int4);
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an int8 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 vshl(int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0)), x, 3 * sizeof(int));
                    case 2: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0)), x, 2 * sizeof(int));
                    case 3: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0)), x, 1 * sizeof(int));
                    case 4: return Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0));
                    case 5: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bslli_epi128(x, 1 * sizeof(int)), Sse.SHUFFLE(0, 2, 0, 0));
                    case 6: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bslli_epi128(x, 2 * sizeof(int)), Sse.SHUFFLE(0, 2, 0, 0));
                    case 7: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bslli_epi128(x, 3 * sizeof(int)), Sse.SHUFFLE(0, 2, 0, 0));

                    default: return int8.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: 
                    {
                        v128 lo = Sse2.bslli_si128(*(v128*)&x._v4_0, 1 * sizeof(int));

                        return new int8(*(int4*)&lo, math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ));
                    }
                    case 2: 
                    {
                        v128 lo = Sse2.bslli_si128(*(v128*)&x._v4_0, 2 * sizeof(int));

                        return new int8(*(int4*)&lo, math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY));
                    }
                    case 3: 
                    {
                        v128 lo = Sse2.bslli_si128(*(v128*)&x._v4_0, 3 * sizeof(int));

                        return new int8(*(int4*)&lo, math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX));
                    }

                    case 4: return new int8(int4.zero, x._v4_0);

                    case 5: 
                    {
                        v128 hi = Sse2.bslli_si128(*(v128*)&x._v4_0, 1 * sizeof(int));
                        
                        return new int8(int4.zero, *(int4*)&hi); 
                    }
                    case 6:
                    {
                        v128 hi = Sse2.bslli_si128(*(v128*)&x._v4_0, 2 * sizeof(int));
                        
                        return new int8(int4.zero, *(int4*)&hi); 
                    } 
                    case 7: 
                    {
                        v128 hi = Sse2.bslli_si128(*(v128*)&x._v4_0, 3 * sizeof(int));
                        
                        return new int8(int4.zero, *(int4*)&hi); 
                    }

                    default: return int8.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int8(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new int8(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new int8(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new int8(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new int8(0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 6: return new int8(0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 7: return new int8(0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return int8.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a uint2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vshl(uint2 x, int n)
        {
            return (uint2)vshl((int2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a uint3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vshl(uint3 x, int n)
        {
            return (uint3)vshl((int3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a uint4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vshl(uint4 x, int n)
        {
            return (uint4)vshl((int4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a uint8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vshl(uint8 x, int n)
        {
            return (uint8)vshl((int8)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a quarter2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vshl(quarter2 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a quarter4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vshl(quarter3 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a quarter4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vshl(quarter4 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a quarter8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vshl(quarter8 x, int n)
        {
            return asquarter(vshl(asbyte(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a half2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vshl(half2 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a half4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vshl(half3 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a half4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vshl(half4 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a half8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vshl(half8 x, int n)
        {
            return ashalf(vshl(asshort(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a float2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vshl(float2 x, int n)
        {
            return math.asfloat(vshl(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vshl(float3 x, int n)
        {
            return math.asfloat(vshl(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vshl(float4 x, int n)
        {
            return math.asfloat(vshl(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float8 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vshl(float8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_alignr_epi8(Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0)), x, 3 * sizeof(float));
                    case 2: return Avx2.mm256_alignr_epi8(Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0)), x, 2 * sizeof(float));
                    case 3: return Avx2.mm256_alignr_epi8(Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0)), x, 1 * sizeof(float));
                    case 4: return Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0));
                    case 5: return Avx.mm256_permute2f128_ps(default(v256), Avx2.mm256_bslli_epi128(x, 1 * sizeof(float)), Sse.SHUFFLE(0, 2, 0, 0));
                    case 6: return Avx.mm256_permute2f128_ps(default(v256), Avx2.mm256_bslli_epi128(x, 2 * sizeof(float)), Sse.SHUFFLE(0, 2, 0, 0));
                    case 7: return Avx.mm256_permute2f128_ps(default(v256), Avx2.mm256_bslli_epi128(x, 2 * sizeof(float)), Sse.SHUFFLE(0, 2, 0, 0));

                    default: return int8.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:
                    {
                        v128 lo = Sse2.bslli_si128(*(v128*)&x._v4_0, 1 * sizeof(float));

                        return new float8(*(float4*)&lo, math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ));
                    }
                    case 2:
                    {
                        v128 lo = Sse2.bslli_si128(*(v128*)&x._v4_0, 2 * sizeof(float));

                        return new float8(*(float4*)&lo, math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY));
                    }
                    case 3:
                    {
                        v128 lo = Sse2.bslli_si128(*(v128*)&x._v4_0, 3 * sizeof(float));

                        return new float8(*(float4*)&lo, math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX));
                    }

                    case 4: return new float8(float4.zero, x._v4_0);

                    case 5:
                    {
                        v128 hi = Sse2.bslli_si128(*(v128*)&x._v4_0, 1 * sizeof(float));

                        return new float8(float4.zero, *(float4*)&hi);
                    }
                    case 6:
                    {
                        v128 hi = Sse2.bslli_si128(*(v128*)&x._v4_0, 2 * sizeof(float));

                        return new float8(float4.zero, *(float4*)&hi);
                    }
                    case 7:
                    {
                        v128 hi = Sse2.bslli_si128(*(v128*)&x._v4_0, 3 * sizeof(float));

                        return new float8(float4.zero, *(float4*)&hi);
                    }

                    default: return float8.zero;
                }
            }
            else
            {
                return asfloat(vshl(asint(x), n));
            }
        }


        /// <summary>       Returns the result of shifting the components within a double2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vshl(double2 x, int n)
        {
            return asdouble(vshl(aslong(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a double3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vshl(double3 x, int n)
        {
            return asdouble(vshl(aslong(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a double4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vshl(double4 x, int n)
        {
            return asdouble(vshl(aslong(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a byte2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vshl(byte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(byte));

                    default: return byte2.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte2(0, x.x);

                    default: return byte2.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vshl(byte3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(byte));
                    case 2: return Sse2.bslli_si128(x, 2 * sizeof(byte));

                    default: return byte3.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte3(0, x.x, x.y);
                    case 2: return new byte3(0, 0, x.x);

                    default: return byte3.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vshl(byte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(byte));
                    case 2: return Sse2.bslli_si128(x, 2 * sizeof(byte));
                    case 3: return Sse2.bslli_si128(x, 3 * sizeof(byte));

                    default: return byte4.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte4(0, x.x, x.y, x.z);
                    case 2: return new byte4(0, 0, x.x, x.y);
                    case 3: return new byte4(0, 0, 0, x.x);

                    default: return byte4.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte8 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vshl(byte8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(byte));
                    case 2: return Sse2.bslli_si128(x, 2 * sizeof(byte));
                    case 3: return Sse2.bslli_si128(x, 3 * sizeof(byte));
                    case 4: return Sse2.bslli_si128(x, 4 * sizeof(byte));
                    case 5: return Sse2.bslli_si128(x, 5 * sizeof(byte));
                    case 6: return Sse2.bslli_si128(x, 6 * sizeof(byte));
                    case 7: return Sse2.bslli_si128(x, 7 * sizeof(byte));

                    default: return byte8.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte8(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new byte8(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new byte8(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new byte8(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new byte8(0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 6: return new byte8(0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 7: return new byte8(0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return byte8.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte16 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 vshl(byte16 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return Sse2.bslli_si128(x, sizeof(byte));
                    case 2:  return Sse2.bslli_si128(x, 2 * sizeof(byte));
                    case 3:  return Sse2.bslli_si128(x, 3 * sizeof(byte));
                    case 4:  return Sse2.bslli_si128(x, 4 * sizeof(byte));
                    case 5:  return Sse2.bslli_si128(x, 5 * sizeof(byte));
                    case 6:  return Sse2.bslli_si128(x, 6 * sizeof(byte));
                    case 7:  return Sse2.bslli_si128(x, 7 * sizeof(byte));
                    case 8:  return Sse2.bslli_si128(x, 8 * sizeof(byte));
                    case 9:  return Sse2.bslli_si128(x, 9 * sizeof(byte));
                    case 10: return Sse2.bslli_si128(x, 10 * sizeof(byte));
                    case 11: return Sse2.bslli_si128(x, 11 * sizeof(byte));
                    case 12: return Sse2.bslli_si128(x, 12 * sizeof(byte));
                    case 13: return Sse2.bslli_si128(x, 13 * sizeof(byte));
                    case 14: return Sse2.bslli_si128(x, 14 * sizeof(byte));
                    case 15: return Sse2.bslli_si128(x, 15 * sizeof(byte));

                    default: return byte16.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte16(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 2:  return new byte16(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 3:  return new byte16(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 4:  return new byte16(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 5:  return new byte16(0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 6:  return new byte16(0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 7:  return new byte16(0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 8:  return new byte16(0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 9:  return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 10: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 11: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 12: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 13: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 14: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 15: return new byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return byte16.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte32 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 vshl(byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 15 * sizeof(byte));
                    case 2:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 14 * sizeof(byte));
                    case 3:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 13 * sizeof(byte));
                    case 4:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 12 * sizeof(byte));
                    case 5:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 11 * sizeof(byte));
                    case 6:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 10 * sizeof(byte));
                    case 7:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  9 * sizeof(byte));
                    case 8:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  8 * sizeof(byte));
                    case 9:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  7 * sizeof(byte));
                    case 10: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  6 * sizeof(byte));
                    case 11: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  5 * sizeof(byte));
                    case 12: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  4 * sizeof(byte));
                    case 13: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  3 * sizeof(byte));
                    case 14: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  2 * sizeof(byte));
                    case 15: return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x,  1 * sizeof(byte));
                    case 16: return Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 17: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  1 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 18: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  2 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 19: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  3 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 20: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  4 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 21: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  5 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 22: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  6 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 23: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  7 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 24: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  8 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 25: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x,  9 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 26: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 10 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 27: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 11 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 28: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 12 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 29: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 13 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 30: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 14 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 31: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 15 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));

                    default: return x;
                }
            }
            else if (Ssse3.IsSsse3Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte32(Sse2.bslli_si128(x._v16_0,  1 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16, 15 * sizeof(byte)));
                    case 2:  return new byte32(Sse2.bslli_si128(x._v16_0,  2 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16, 14 * sizeof(byte)));
                    case 3:  return new byte32(Sse2.bslli_si128(x._v16_0,  3 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16, 13 * sizeof(byte)));
                    case 4:  return new byte32(Sse2.bslli_si128(x._v16_0,  4 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16, 12 * sizeof(byte)));
                    case 5:  return new byte32(Sse2.bslli_si128(x._v16_0,  5 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16, 11 * sizeof(byte)));
                    case 6:  return new byte32(Sse2.bslli_si128(x._v16_0,  6 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16, 10 * sizeof(byte)));
                    case 7:  return new byte32(Sse2.bslli_si128(x._v16_0,  7 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  9 * sizeof(byte)));
                    case 8:  return new byte32(Sse2.bslli_si128(x._v16_0,  8 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  8 * sizeof(byte)));
                    case 9:  return new byte32(Sse2.bslli_si128(x._v16_0,  9 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  7 * sizeof(byte)));
                    case 10: return new byte32(Sse2.bslli_si128(x._v16_0, 10 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  6 * sizeof(byte)));
                    case 11: return new byte32(Sse2.bslli_si128(x._v16_0, 11 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  5 * sizeof(byte)));
                    case 12: return new byte32(Sse2.bslli_si128(x._v16_0, 12 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  4 * sizeof(byte)));
                    case 13: return new byte32(Sse2.bslli_si128(x._v16_0, 13 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  3 * sizeof(byte)));
                    case 14: return new byte32(Sse2.bslli_si128(x._v16_0, 14 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  2 * sizeof(byte)));
                    case 15: return new byte32(Sse2.bslli_si128(x._v16_0, 15 * sizeof(byte)), Ssse3.alignr_epi8(x._v16_0, x._v16_16,  1 * sizeof(byte)));
                    case 16: return new byte32(byte16.zero,                                   x._v16_0);
                    case 17: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  1 * sizeof(byte)));
                    case 18: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  2 * sizeof(byte)));
                    case 19: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  3 * sizeof(byte)));
                    case 20: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  4 * sizeof(byte)));
                    case 21: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  5 * sizeof(byte)));
                    case 22: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  6 * sizeof(byte)));
                    case 23: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  7 * sizeof(byte)));
                    case 24: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  8 * sizeof(byte)));
                    case 25: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0,  9 * sizeof(byte)));
                    case 26: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0, 10 * sizeof(byte)));
                    case 27: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0, 11 * sizeof(byte)));
                    case 28: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0, 12 * sizeof(byte)));
                    case 29: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0, 13 * sizeof(byte)));
                    case 30: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0, 14 * sizeof(byte)));
                    case 31: return new byte32(byte16.zero,                                   Sse2.bslli_si128(x._v16_0, 15 * sizeof(byte)));

                    default: return x;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte32(Sse2.bslli_si128(x._v16_0, 1 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,  15 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  1 * sizeof(byte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 2:  return new byte32(Sse2.bslli_si128(x._v16_0, 2 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,  14 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  2 * sizeof(byte)), new v128(0,   0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 3:  return new byte32(Sse2.bslli_si128(x._v16_0, 3 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,  13 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  3 * sizeof(byte)), new v128(0,   0,   0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 4:  return new byte32(Sse2.bslli_si128(x._v16_0, 4 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,  12 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  4 * sizeof(byte)), new v128(0,   0,   0,   0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 5:  return new byte32(Sse2.bslli_si128(x._v16_0, 5 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,  11 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  5 * sizeof(byte)), new v128(0,   0,   0,   0,   0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 6:  return new byte32(Sse2.bslli_si128(x._v16_0, 6 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,  10 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  6 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 7:  return new byte32(Sse2.bslli_si128(x._v16_0, 7 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   9 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  7 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0, 255, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 8:  return new byte32(Sse2.bslli_si128(x._v16_0, 8 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   8 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  8 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0, 255, 255, 255, 255, 255, 255, 255, 255)));
                    case 9:  return new byte32(Sse2.bslli_si128(x._v16_0, 9 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   7 * sizeof(byte)), Sse2.bslli_si128(x._v16_16,  9 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0, 255, 255, 255, 255, 255, 255, 255)));
                    case 10: return new byte32(Sse2.bslli_si128(x._v16_0, 10 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   6 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 10 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 255, 255, 255, 255, 255, 255)));
                    case 11: return new byte32(Sse2.bslli_si128(x._v16_0, 11 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   5 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 11 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 255, 255, 255, 255, 255)));
                    case 12: return new byte32(Sse2.bslli_si128(x._v16_0, 12 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   4 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 12 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 255, 255, 255, 255)));
                    case 13: return new byte32(Sse2.bslli_si128(x._v16_0, 13 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   3 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 13 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 255, 255, 255)));
                    case 14: return new byte32(Sse2.bslli_si128(x._v16_0, 14 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   2 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 14 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 255, 255)));
                    case 15: return new byte32(Sse2.bslli_si128(x._v16_0, 15 * sizeof(byte)),
                                               Mask.BlendV(Sse2.bsrli_si128(x._v16_0,   1 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 15 * sizeof(byte)), new v128(0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0, 255)));
                    case 16: return new byte32(byte16.zero, x._v16_0);
                    case 17: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  1 * sizeof(byte)));
                    case 18: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  2 * sizeof(byte)));
                    case 19: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  3 * sizeof(byte)));
                    case 20: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  4 * sizeof(byte)));
                    case 21: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  5 * sizeof(byte)));
                    case 22: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  6 * sizeof(byte)));
                    case 23: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  7 * sizeof(byte)));
                    case 24: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  8 * sizeof(byte)));
                    case 25: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0,  9 * sizeof(byte)));
                    case 26: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0, 10 * sizeof(byte)));
                    case 27: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0, 11 * sizeof(byte)));
                    case 28: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0, 12 * sizeof(byte)));
                    case 29: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0, 13 * sizeof(byte)));
                    case 30: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0, 14 * sizeof(byte)));
                    case 31: return new byte32(byte16.zero, Sse2.bslli_si128(x._v16_0, 15 * sizeof(byte)));

                    default: return x;
                }
            }
            else
            { 
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte32(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30);
                    case 2:  return new byte32(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29);
                    case 3:  return new byte32(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28);
                    case 4:  return new byte32(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27);
                    case 5:  return new byte32(0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26);
                    case 6:  return new byte32(0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25);
                    case 7:  return new byte32(0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24);
                    case 8:  return new byte32(0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23);
                    case 9:  return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22);
                    case 10: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21);
                    case 11: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20);
                    case 12: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19);
                    case 13: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18);
                    case 14: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17);
                    case 15: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16);
                    case 16: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15);
                    case 17: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 18: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 19: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 20: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 21: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 22: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 23: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 24: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 25: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 26: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 27: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 28: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 29: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 30: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 31: return new byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return byte32.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within an sbyte2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vshl(sbyte2 x, int n)
        {
            return (sbyte2)vshl((byte2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vshl(sbyte3 x, int n)
        {
            return (sbyte3)vshl((byte3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vshl(sbyte4 x, int n)
        {
            return (sbyte4)vshl((byte4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vshl(sbyte8 x, int n)
        {
            return (sbyte8)vshl((byte8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte16 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vshl(sbyte16 x, int n)
        {
            return (sbyte16)vshl((byte16)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte32 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 vshl(sbyte32 x, int n)
        {
            return (sbyte32)vshl((byte32)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a short2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshl(short2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(short));

                    default: return short2.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short2(0, x.x);

                    default: return short2.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vshl(short3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(short));
                    case 2: return Sse2.bslli_si128(x, 2 * sizeof(short));

                    default: return short3.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short3(0, x.x, x.y);
                    case 2: return new short3(0, 0, x.x);

                    default: return short3.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vshl(short4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(short));
                    case 2: return Sse2.bslli_si128(x, 2 * sizeof(short));
                    case 3: return Sse2.bslli_si128(x, 3 * sizeof(short));

                    default: return short4.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short4(0, x.x, x.y, x.z);
                    case 2: return new short4(0, 0, x.x, x.y);
                    case 3: return new short4(0, 0, 0, x.x);

                    default: return short4.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short8 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 vshl(short8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(short));
                    case 2: return Sse2.bslli_si128(x, 2 * sizeof(short));
                    case 3: return Sse2.bslli_si128(x, 3 * sizeof(short));
                    case 4: return Sse2.bslli_si128(x, 4 * sizeof(short));
                    case 5: return Sse2.bslli_si128(x, 5 * sizeof(short));
                    case 6: return Sse2.bslli_si128(x, 6 * sizeof(short));
                    case 7: return Sse2.bslli_si128(x, 7 * sizeof(short));

                    default: return short8.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short8(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 2: return new short8(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 3: return new short8(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 4: return new short8(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 5: return new short8(0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 6: return new short8(0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 7: return new short8(0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return short8.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short16 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 vshl(short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 7 * sizeof(short));
                    case 2:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 6 * sizeof(short));
                    case 3:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 5 * sizeof(short));
                    case 4:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 4 * sizeof(short));
                    case 5:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 3 * sizeof(short));
                    case 6:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 2 * sizeof(short));
                    case 7:  return Avx2.mm256_alignr_epi8(Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2)), x, 1 * sizeof(short));
                    case 8:  return Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 9:  return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 1 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 10: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 2 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 11: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 3 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 12: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 4 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 13: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 5 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 14: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 6 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));
                    case 15: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bslli_epi128(x, 7 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 0, 0, 2));

                    default: return x;
                }
            }
            else if (Ssse3.IsSsse3Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new short16(Sse2.bslli_si128(x._v8_0, 1 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 7 * sizeof(short)));
                    case 2:  return new short16(Sse2.bslli_si128(x._v8_0, 2 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 6 * sizeof(short)));
                    case 3:  return new short16(Sse2.bslli_si128(x._v8_0, 3 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 5 * sizeof(short)));
                    case 4:  return new short16(Sse2.bslli_si128(x._v8_0, 4 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 4 * sizeof(short)));
                    case 5:  return new short16(Sse2.bslli_si128(x._v8_0, 5 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 3 * sizeof(short)));
                    case 6:  return new short16(Sse2.bslli_si128(x._v8_0, 6 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 2 * sizeof(short)));
                    case 7:  return new short16(Sse2.bslli_si128(x._v8_0, 7 * sizeof(short)), Ssse3.alignr_epi8(x._v8_0, x._v8_8, 1 * sizeof(short)));
                    case 8:  return new short16(short8.zero, x._v8_0);
                    case 9:  return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 1 * sizeof(short)));
                    case 10: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 2 * sizeof(short)));
                    case 11: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 3 * sizeof(short)));
                    case 12: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 4 * sizeof(short)));
                    case 13: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 5 * sizeof(short)));
                    case 14: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 6 * sizeof(short)));
                    case 15: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 7 * sizeof(short)));

                    default: return x;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new short16(Sse2.bslli_si128(x._v8_0, 1 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 7 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 1 * sizeof(short)), new v128(0, -1, -1, -1, -1, -1, -1, -1)));
                    case 2:  return new short16(Sse2.bslli_si128(x._v8_0, 2 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 6 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 2 * sizeof(short)), new v128(0,  0, -1, -1, -1, -1, -1, -1)));
                    case 3:  return new short16(Sse2.bslli_si128(x._v8_0, 3 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 5 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 3 * sizeof(short)), new v128(0,  0,  0, -1, -1, -1, -1, -1)));
                    case 4:  return new short16(Sse2.bslli_si128(x._v8_0, 4 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 4 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 4 * sizeof(short)), new v128(0,  0,  0,  0, -1, -1, -1, -1)));
                    case 5:  return new short16(Sse2.bslli_si128(x._v8_0, 5 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 3 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 5 * sizeof(short)), new v128(0,  0,  0,  0,  0, -1, -1, -1)));
                    case 6:  return new short16(Sse2.bslli_si128(x._v8_0, 6 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 2 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 6 * sizeof(short)), new v128(0,  0,  0,  0,  0,  0, -1, -1)));
                    case 7:  return new short16(Sse2.bslli_si128(x._v8_0, 7 * sizeof(short)),
                                                Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 1 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 7 * sizeof(short)), new v128(0,  0,  0,  0,  0,  0,  0, -1)));
                    case 8:  return new short16(short8.zero, x._v8_0);
                    case 9:  return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 1 * sizeof(short)));
                    case 10: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 2 * sizeof(short)));
                    case 11: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 3 * sizeof(short)));
                    case 12: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 4 * sizeof(short)));
                    case 13: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 5 * sizeof(short)));
                    case 14: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 6 * sizeof(short)));
                    case 15: return new short16(short8.zero, Sse2.bslli_si128(x._v8_0, 7 * sizeof(short)));

                    default: return x;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new short16(0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14);
                    case 2:  return new short16(0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13);
                    case 3:  return new short16(0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12);
                    case 4:  return new short16(0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11);
                    case 5:  return new short16(0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10);
                    case 6:  return new short16(0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9);
                    case 7:  return new short16(0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8);
                    case 8:  return new short16(0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7);
                    case 9:  return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5, x.x6);
                    case 10: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4, x.x5);
                    case 11: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3, x.x4);
                    case 12: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2, x.x3);
                    case 13: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1, x.x2);
                    case 14: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0, x.x1);
                    case 15: return new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, x.x0);

                    default: return short16.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a ushort2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vshl(ushort2 x, int n)
        {
            return (ushort2)vshl((short2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vshl(ushort3 x, int n)
        {
            return (ushort3)vshl((short3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vshl(ushort4 x, int n)
        {
            return (ushort4)vshl((short4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vshl(ushort8 x, int n)
        {
            return (ushort8)vshl((short8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort16 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 vshl(ushort16 x, int n)
        {
            return (ushort16)vshl((short16)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a long2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vshl(long2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bslli_si128(x, sizeof(long));

                    default: return long2.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long2(0, x.x);

                    default: return long2.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a long3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vshl(long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(3,   1, 0, 3));
                    case 2: return Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0));

                    default: return long3.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new long3(Sse2.bslli_si128(x._xy, 1 * sizeof(long)), x.y);
                    case 2:  return new long3(long2.zero, x.x);

                    default: return x;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long3(0, x.x, x.y);
                    case 2: return new long3(0, 0, x.x);

                    default: return long3.zero;
                }
            }
            
        }

        /// <summary>       Returns the result of shifting the components within a long4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 vshl(long4 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(2, 1, 0, 3));
                    case 2: return Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 2, 0, 0));
                    case 3: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bslli_epi128(x, 1 * sizeof(long)), Sse.SHUFFLE(0, 2, 0, 0));

                    default: return long4.zero;
                }
            }
            else if (Ssse3.IsSsse3Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new long4(Sse2.bslli_si128(x._xy, 1 * sizeof(long)), Ssse3.alignr_epi8(x._xy, x._zw, 1 * sizeof(long)));
                    case 2:  return new long4(long2.zero, x._xy);
                    case 3:  return new long4(long2.zero, Sse2.bslli_si128(x._xy, 1 * sizeof(long)));

                    default: return x;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long4(Sse2.bslli_si128(x._xy, 1 * sizeof(long)), Mask.BlendV(Sse2.bsrli_si128(x._xy, 1 * sizeof(long)), Sse2.bslli_si128(x._zw, 1 * sizeof(long)), new long2(0, -1)));
                    case 2: return new long4(long2.zero, x._xy);
                    case 3: return new long4(long2.zero, Sse2.bslli_si128(x._xy, 1 * sizeof(long)));

                    default: return x;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long4(0, x.x, x.y, x.z);
                    case 2: return new long4(0, 0, x.x, x.y);
                    case 3: return new long4(0, 0, 0, x.x);

                    default: return long4.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a ulong2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vshl(ulong2 x, int n)
        {
            return (ulong2)vshl((long2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ulong3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vshl(ulong3 x, int n)
        {
            return (ulong3)vshl((long3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ulong4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vshl(ulong4 x, int n)
        {
            return (ulong4)vshl((long4)x, n);
        }


        /// <summary>       Returns the result of shifting the components within an int2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vshr(int2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: v128 temp = Sse2.bsrli_si128(Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(int)), 3 * sizeof(int)); return *(int2*)&temp;

                    default: return default(int2);
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int2(x.y, 0);

                    default: return default(int2);
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an int3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vshr(int3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp;

                switch (n)
                {
                    case 0: return x;

                    case 1: temp = Sse2.bsrli_si128(Sse2.bslli_si128(*(v128*)&x, 1 * sizeof(int)), 2 * sizeof(int)); return *(int3*)&temp;
                    case 2: temp = Sse2.bsrli_si128(Sse2.bslli_si128(*(v128*)&x, 1 * sizeof(int)), 3 * sizeof(int)); return *(int3*)&temp;

                    default: return default(int3);
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int3(x.y, x.z, 0);
                    case 2: return new int3(x.z,   0, 0);

                    default: return default(int3);
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an int4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 vshr(int4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128  temp ;

                switch (n)
                {
                    case 0: return x;

                    case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(int)); return *(int4*)&temp;
                    case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int4*)&temp;
                    case 3: temp = Sse2.bsrli_si128(*(v128*)&x, 3 * sizeof(int)); return *(int4*)&temp;

                    default: return default(int4);
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int4(x.y, x.z, x.w, 0);
                    case 2: return new int4(x.z, x.w,   0, 0);
                    case 3: return new int4(x.w,   0,   0, 0);

                    default: return default(int4);
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within an int8 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 vshr(int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3)), 1 * sizeof(int));
                    case 2: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3)), 2 * sizeof(int));
                    case 3: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3)), 3 * sizeof(int));
                    case 4: return Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3));
                    case 5: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bsrli_epi128(x, 1 * sizeof(int)), Sse.SHUFFLE(0, 0, 0, 3));
                    case 6: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bsrli_epi128(x, 2 * sizeof(int)), Sse.SHUFFLE(0, 0, 0, 3));
                    case 7: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bsrli_epi128(x, 3 * sizeof(int)), Sse.SHUFFLE(0, 0, 0, 3));

                    default: return int8.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: 
                    {
                        v128 hi = Sse2.bsrli_si128(*(v128*)&x._v4_4, 1 * sizeof(int));

                        return new int8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX), *(int4*)&hi);
                    }
                    case 2: 
                    {
                        v128 hi = Sse2.bsrli_si128(*(v128*)&x._v4_4, 2 * sizeof(int));

                        return new int8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY), *(int4*)&hi);
                    }
                    case 3: 
                    {
                        v128 hi = Sse2.bsrli_si128(*(v128*)&x._v4_4, 3 * sizeof(int));

                        return new int8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ), *(int4*)&hi);
                    }

                    case 4: return new int8(x._v4_4, int4.zero);

                    case 5: 
                    {
                        v128 lo = Sse2.bsrli_si128(*(v128*)&x._v4_4, 1 * sizeof(int));
                        
                        return new int8(*(int4*)&lo, int4.zero); 
                    }
                    case 6:
                    {
                        v128 lo = Sse2.bsrli_si128(*(v128*)&x._v4_4, 2 * sizeof(int));
                        
                        return new int8(*(int4*)&lo, int4.zero); 
                    } 
                    case 7: 
                    {
                        v128 lo = Sse2.bsrli_si128(*(v128*)&x._v4_4, 3 * sizeof(int));
                        
                        return new int8(*(int4*)&lo, int4.zero); 
                    }

                    default: return int8.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new int8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0);
                    case 2: return new int8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0);
                    case 3: return new int8(x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0, 0);
                    case 4: return new int8(x.x4, x.x5, x.x6, x.x7, 0, 0, 0, 0);
                    case 5: return new int8(x.x5, x.x6, x.x7, 0, 0, 0, 0, 0);
                    case 6: return new int8(x.x6, x.x7, 0, 0, 0, 0, 0, 0);
                    case 7: return new int8(x.x7, 0, 0, 0, 0, 0, 0, 0);

                    default: return int8.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a uint2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vshr(uint2 x, int n)
        {
            return (uint2)vshr((int2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a uint3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vshr(uint3 x, int n)
        {
            return (uint3)vshr((int3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a uint4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vshr(uint4 x, int n)
        {
            return (uint4)vshr((int4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a uint8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vshr(uint8 x, int n)
        {
            return (uint8)vshr((int8)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a quarter2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vshr(quarter2 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a quarter4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vshr(quarter3 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a quarter4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vshr(quarter4 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a quarter8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vshr(quarter8 x, int n)
        {
            return asquarter(vshr(asbyte(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a half2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vshr(half2 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a half4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vshr(half3 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a half4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vshr(half4 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a half8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vshr(half8 x, int n)
        {
            return ashalf(vshr(asshort(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vshr(float2 x, int n)
        {
            return math.asfloat(vshr(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vshr(float3 x, int n)
        {
            return math.asfloat(vshr(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vshr(float4 x, int n)
        {
            return math.asfloat(vshr(math.asint(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a float8 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vshr(float8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_alignr_epi8(x, Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3)), 1 * sizeof(float));
                    case 2: return Avx2.mm256_alignr_epi8(x, Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3)), 2 * sizeof(float));
                    case 3: return Avx2.mm256_alignr_epi8(x, Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3)), 3 * sizeof(float));
                    case 4: return Avx.mm256_permute2f128_ps(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3));
                    case 5: return Avx.mm256_permute2f128_ps(default(v256), Avx2.mm256_bsrli_epi128(x, 1 * sizeof(float)), Sse.SHUFFLE(0, 0, 0, 3));
                    case 6: return Avx.mm256_permute2f128_ps(default(v256), Avx2.mm256_bsrli_epi128(x, 2 * sizeof(float)), Sse.SHUFFLE(0, 0, 0, 3));
                    case 7: return Avx.mm256_permute2f128_ps(default(v256), Avx2.mm256_bsrli_epi128(x, 3 * sizeof(float)), Sse.SHUFFLE(0, 0, 0, 3));

                    default: return int8.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:
                    {
                        v128 hi = Sse2.bsrli_si128(*(v128*)&x._v4_4, 1 * sizeof(float));

                        return new float8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftY, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX), *(float4*)&hi);
                    }
                    case 2:
                    {
                        v128 hi = Sse2.bsrli_si128(*(v128*)&x._v4_4, 2 * sizeof(float));

                        return new float8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftZ, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY), *(float4*)&hi);
                    }
                    case 3:
                    {
                        v128 hi = Sse2.bsrli_si128(*(v128*)&x._v4_4, 3 * sizeof(float));

                        return new float8(math.shuffle(x._v4_0, x._v4_4, math.ShuffleComponent.LeftW, math.ShuffleComponent.RightX, math.ShuffleComponent.RightY, math.ShuffleComponent.RightZ), *(float4*)&hi);
                    }

                    case 4: return new float8(x._v4_4, float4.zero);

                    case 5:
                    {
                        v128 lo = Sse2.bsrli_si128(*(v128*)&x._v4_4, 1 * sizeof(float));

                        return new float8(*(float4*)&lo, float4.zero);
                    }
                    case 6:
                    {
                        v128 lo = Sse2.bsrli_si128(*(v128*)&x._v4_4, 2 * sizeof(float));

                        return new float8(*(float4*)&lo, float4.zero);
                    }
                    case 7:
                    {
                        v128 lo = Sse2.bsrli_si128(*(v128*)&x._v4_4, 3 * sizeof(float));

                        return new float8(*(float4*)&lo, float4.zero);
                    }

                    default: return float8.zero;
                }
            }
            else
            {
                return asfloat(vshr(asint(x), n));
            }
        }


        /// <summary>       Returns the result of shifting the components within a double2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vshr(double2 x, int n)
        {
            return asdouble(vshr(aslong(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a double3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vshr(double3 x, int n)
        {
            return asdouble(vshr(aslong(x), n));
        }

        /// <summary>       Returns the result of shifting the components within a double4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vshr(double4 x, int n)
        {
            return asdouble(vshr(aslong(x), n));
        }


        /// <summary>       Returns the result of shifting the components within a byte2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vshr(byte2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 14 * sizeof(byte)), 15 * sizeof(byte));

                    default: return byte2.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte2(x.y, 0);

                    default: return byte2.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vshr(byte3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 13 * sizeof(byte)), 14 * sizeof(byte));
                    case 2: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 13 * sizeof(byte)), 15 * sizeof(byte));

                    default: return byte3.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte3(x.y, x.z, 0);
                    case 2: return new byte3(x.z, 0, 0);

                    default: return byte3.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vshr(byte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 12 * sizeof(byte)), 13 * sizeof(byte));
                    case 2: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 12 * sizeof(byte)), 14 * sizeof(byte));
                    case 3: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 12 * sizeof(byte)), 15 * sizeof(byte));

                    default: return byte4.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte4(x.y, x.z, x.w, 0);
                    case 2: return new byte4(x.z, x.w, 0, 0);
                    case 3: return new byte4(x.w, 0, 0, 0);

                    default: return byte4.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte8 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vshr(byte8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)),  9 * sizeof(byte));
                    case 2: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)), 10 * sizeof(byte));
                    case 3: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)), 11 * sizeof(byte));
                    case 4: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)), 12 * sizeof(byte));
                    case 5: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)), 13 * sizeof(byte));
                    case 6: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)), 14 * sizeof(byte));
                    case 7: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 8 * sizeof(byte)), 15 * sizeof(byte));

                    default: return byte8.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new byte8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0);
                    case 2: return new byte8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0);
                    case 3: return new byte8(x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0, 0);
                    case 4: return new byte8(x.x4, x.x5, x.x6, x.x7, 0, 0, 0, 0);
                    case 5: return new byte8(x.x5, x.x6, x.x7, 0, 0, 0, 0, 0);
                    case 6: return new byte8(x.x6, x.x7, 0, 0, 0, 0, 0, 0);
                    case 7: return new byte8(x.x7, 0, 0, 0, 0, 0, 0, 0);

                    default: return byte8.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte16 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 vshr(byte16 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return Sse2.bsrli_si128(x, sizeof(byte));
                    case 2:  return Sse2.bsrli_si128(x, 2 * sizeof(byte));
                    case 3:  return Sse2.bsrli_si128(x, 3 * sizeof(byte));
                    case 4:  return Sse2.bsrli_si128(x, 4 * sizeof(byte));
                    case 5:  return Sse2.bsrli_si128(x, 5 * sizeof(byte));
                    case 6:  return Sse2.bsrli_si128(x, 6 * sizeof(byte));
                    case 7:  return Sse2.bsrli_si128(x, 7 * sizeof(byte));
                    case 8:  return Sse2.bsrli_si128(x, 8 * sizeof(byte));
                    case 9:  return Sse2.bsrli_si128(x, 9 * sizeof(byte));
                    case 10: return Sse2.bsrli_si128(x, 10 * sizeof(byte));
                    case 11: return Sse2.bsrli_si128(x, 11 * sizeof(byte));
                    case 12: return Sse2.bsrli_si128(x, 12 * sizeof(byte));
                    case 13: return Sse2.bsrli_si128(x, 13 * sizeof(byte));
                    case 14: return Sse2.bsrli_si128(x, 14 * sizeof(byte));
                    case 15: return Sse2.bsrli_si128(x, 15 * sizeof(byte));

                    default: return byte16.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte16(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0);
                    case 2:  return new byte16(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0);
                    case 3:  return new byte16(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0);
                    case 4:  return new byte16(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0);
                    case 5:  return new byte16(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0);
                    case 6:  return new byte16(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0);
                    case 7:  return new byte16(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0);
                    case 8:  return new byte16(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 9:  return new byte16(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 10: return new byte16(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 11: return new byte16(x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 12: return new byte16(x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 13: return new byte16(x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 14: return new byte16(x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 15: return new byte16(x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    default: return byte16.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a byte32 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 vshr(byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  1 * sizeof(byte));
                    case 2:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  2 * sizeof(byte));
                    case 3:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  3 * sizeof(byte));
                    case 4:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  4 * sizeof(byte));
                    case 5:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  5 * sizeof(byte));
                    case 6:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  6 * sizeof(byte));
                    case 7:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  7 * sizeof(byte));
                    case 8:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  8 * sizeof(byte));
                    case 9:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  9 * sizeof(byte));
                    case 10: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)), 10 * sizeof(byte));
                    case 11: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)), 11 * sizeof(byte));
                    case 12: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)), 12 * sizeof(byte));
                    case 13: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)), 13 * sizeof(byte));
                    case 14: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)), 14 * sizeof(byte));
                    case 15: return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)), 15 * sizeof(byte));
                    case 16: return Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 17: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  1 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 18: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  2 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 19: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  3 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 20: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  4 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 21: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  5 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 22: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  6 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 23: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  7 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 24: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  8 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 25: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  9 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 26: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x, 10 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 27: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x, 11 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 28: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x, 12 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 29: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x, 13 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 30: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x, 14 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 31: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x, 15 * sizeof(byte)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));

                    default: return byte32.zero;
                }
            }
            else if (Ssse3.IsSsse3Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  1 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  1 * sizeof(byte)));
                    case 2:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  2 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  2 * sizeof(byte)));
                    case 3:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  3 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  3 * sizeof(byte)));
                    case 4:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  4 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  4 * sizeof(byte)));
                    case 5:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  5 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  5 * sizeof(byte)));
                    case 6:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  6 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  6 * sizeof(byte)));
                    case 7:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  7 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  7 * sizeof(byte)));
                    case 8:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  8 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  8 * sizeof(byte)));
                    case 9:  return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16,  9 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16,  9 * sizeof(byte)));
                    case 10: return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16, 10 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16, 10 * sizeof(byte)));
                    case 11: return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16, 11 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16, 11 * sizeof(byte)));
                    case 12: return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16, 12 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16, 12 * sizeof(byte)));
                    case 13: return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16, 13 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16, 13 * sizeof(byte)));
                    case 14: return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16, 14 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16, 14 * sizeof(byte)));
                    case 15: return new byte32(Ssse3.alignr_epi8(x._v16_0, x._v16_16, 15 * sizeof(byte)), Sse2.bsrli_si128(x._v16_16, 15 * sizeof(byte)));
                    case 16: return new byte32(x._v16_16, byte16.zero);
                    case 17: return new byte32(Sse2.bsrli_si128(x._v16_16,  1 * sizeof(byte)), byte16.zero);
                    case 18: return new byte32(Sse2.bsrli_si128(x._v16_16,  2 * sizeof(byte)), byte16.zero);
                    case 19: return new byte32(Sse2.bsrli_si128(x._v16_16,  3 * sizeof(byte)), byte16.zero);
                    case 20: return new byte32(Sse2.bsrli_si128(x._v16_16,  4 * sizeof(byte)), byte16.zero);
                    case 21: return new byte32(Sse2.bsrli_si128(x._v16_16,  5 * sizeof(byte)), byte16.zero);
                    case 22: return new byte32(Sse2.bsrli_si128(x._v16_16,  6 * sizeof(byte)), byte16.zero);
                    case 23: return new byte32(Sse2.bsrli_si128(x._v16_16,  7 * sizeof(byte)), byte16.zero);
                    case 24: return new byte32(Sse2.bsrli_si128(x._v16_16,  8 * sizeof(byte)), byte16.zero);
                    case 25: return new byte32(Sse2.bsrli_si128(x._v16_16,  9 * sizeof(byte)), byte16.zero);
                    case 26: return new byte32(Sse2.bsrli_si128(x._v16_16, 10 * sizeof(byte)), byte16.zero);
                    case 27: return new byte32(Sse2.bsrli_si128(x._v16_16, 11 * sizeof(byte)), byte16.zero);
                    case 28: return new byte32(Sse2.bsrli_si128(x._v16_16, 12 * sizeof(byte)), byte16.zero);
                    case 29: return new byte32(Sse2.bsrli_si128(x._v16_16, 13 * sizeof(byte)), byte16.zero);
                    case 30: return new byte32(Sse2.bsrli_si128(x._v16_16, 14 * sizeof(byte)), byte16.zero);
                    case 31: return new byte32(Sse2.bsrli_si128(x._v16_16, 15 * sizeof(byte)), byte16.zero);

                    default: return byte32.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 1 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255)), 
                                               Sse2.bsrli_si128(x._v16_16, 1 * sizeof(byte)));
                    case 2:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 2 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 2 * sizeof(byte)));
                    case 3:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 3 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 3 * sizeof(byte)));
                    case 4:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 4 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 12 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 4 * sizeof(byte)));
                    case 5:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 5 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 5 * sizeof(byte)));
                    case 6:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 6 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 10 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 6 * sizeof(byte)));
                    case 7:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 7 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 7 * sizeof(byte)));
                    case 8:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 8 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 8 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 8 * sizeof(byte)));
                    case 9:  return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 9 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 9 * sizeof(byte)));
                    case 10: return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 10 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 6 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 10 * sizeof(byte)));
                    case 11: return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 11 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 11 * sizeof(byte)));
                    case 12: return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 12 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 4 * sizeof(byte)), new v128(0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 12 * sizeof(byte)));
                    case 13: return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 13 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 13 * sizeof(byte)));
                    case 14: return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 14 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 2 * sizeof(byte)), new v128(0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 14 * sizeof(byte)));
                    case 15: return new byte32(Mask.BlendV(Sse2.bsrli_si128(x._v16_0, 15 * sizeof(byte)), Sse2.bslli_si128(x._v16_16, 1 * sizeof(byte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)),
                                               Sse2.bsrli_si128(x._v16_16, 15 * sizeof(byte)));
                    case 16: return new byte32(x._v16_16, byte16.zero);
                    case 17: return new byte32(Sse2.bsrli_si128(x._v16_16,  1 * sizeof(byte)), byte16.zero);
                    case 18: return new byte32(Sse2.bsrli_si128(x._v16_16,  2 * sizeof(byte)), byte16.zero);
                    case 19: return new byte32(Sse2.bsrli_si128(x._v16_16,  3 * sizeof(byte)), byte16.zero);
                    case 20: return new byte32(Sse2.bsrli_si128(x._v16_16,  4 * sizeof(byte)), byte16.zero);
                    case 21: return new byte32(Sse2.bsrli_si128(x._v16_16,  5 * sizeof(byte)), byte16.zero);
                    case 22: return new byte32(Sse2.bsrli_si128(x._v16_16,  6 * sizeof(byte)), byte16.zero);
                    case 23: return new byte32(Sse2.bsrli_si128(x._v16_16,  7 * sizeof(byte)), byte16.zero);
                    case 24: return new byte32(Sse2.bsrli_si128(x._v16_16,  8 * sizeof(byte)), byte16.zero);
                    case 25: return new byte32(Sse2.bsrli_si128(x._v16_16,  9 * sizeof(byte)), byte16.zero);
                    case 26: return new byte32(Sse2.bsrli_si128(x._v16_16, 10 * sizeof(byte)), byte16.zero);
                    case 27: return new byte32(Sse2.bsrli_si128(x._v16_16, 11 * sizeof(byte)), byte16.zero);
                    case 28: return new byte32(Sse2.bsrli_si128(x._v16_16, 12 * sizeof(byte)), byte16.zero);
                    case 29: return new byte32(Sse2.bsrli_si128(x._v16_16, 13 * sizeof(byte)), byte16.zero);
                    case 30: return new byte32(Sse2.bsrli_si128(x._v16_16, 14 * sizeof(byte)), byte16.zero);
                    case 31: return new byte32(Sse2.bsrli_si128(x._v16_16, 15 * sizeof(byte)), byte16.zero);

                    default: return byte32.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new byte32(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0);
                    case 2:  return new byte32(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0);
                    case 3:  return new byte32(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0);
                    case 4:  return new byte32(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0);
                    case 5:  return new byte32(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0);
                    case 6:  return new byte32(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0);
                    case 7:  return new byte32(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0);
                    case 8:  return new byte32(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 9:  return new byte32(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 10: return new byte32(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 11: return new byte32(x.x11, x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 12: return new byte32(x.x12, x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 13: return new byte32(x.x13, x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 14: return new byte32(x.x14, x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 15: return new byte32(x.x15, x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 16: return new byte32(x.x16, x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 17: return new byte32(x.x17, x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 18: return new byte32(x.x18, x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 19: return new byte32(x.x19, x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 20: return new byte32(x.x20, x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 21: return new byte32(x.x21, x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 22: return new byte32(x.x22, x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 23: return new byte32(x.x23, x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 24: return new byte32(x.x24, x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 25: return new byte32(x.x25, x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 26: return new byte32(x.x26, x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 27: return new byte32(x.x27, x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 28: return new byte32(x.x28, x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 29: return new byte32(x.x29, x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 30: return new byte32(x.x30, x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 31: return new byte32(x.x31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    default: return byte32.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within an sbyte2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vshr(sbyte2 x, int n)
        {
            return (sbyte2)vshr((byte2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vshr(sbyte3 x, int n)
        {
            return (sbyte3)vshr((byte3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vshr(sbyte4 x, int n)
        {
            return (sbyte4)vshr((byte4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vshr(sbyte8 x, int n)
        {
            return (sbyte8)vshr((byte8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte16 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vshr(sbyte16 x, int n)
        {
            return (sbyte16)vshr((byte16)x, n);
        }

        /// <summary>       Returns the result of shifting the components within an sbyte32 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 vshr(sbyte32 x, int n)
        {
            return (sbyte32)vshr((byte32)x, n);
        }


        /// <summary>       Returns the result of shifting the components within a short2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshr(short2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 6 * sizeof(short)), 7 * sizeof(short));

                    default: return short2.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short2(x.y, 0);

                    default: return short2.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vshr(short3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 5 * sizeof(short)), 6 * sizeof(short));
                    case 2: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 5 * sizeof(short)), 7 * sizeof(short));

                    default: return short3.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short3(x.y, x.z, 0);
                    case 2: return new short3(x.z, 0, 0);

                    default: return short3.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vshr(short4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 4 * sizeof(short)), 5 * sizeof(short));
                    case 2: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 4 * sizeof(short)), 6 * sizeof(short));
                    case 3: return Sse2.bsrli_si128(Sse2.bslli_si128(x, 4 * sizeof(short)), 7 * sizeof(short));

                    default: return short4.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short4(x.y, x.z, x.w, 0);
                    case 2: return new short4(x.z, x.w, 0, 0);
                    case 3: return new short4(x.w, 0, 0, 0);

                    default: return short4.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a short8 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 vshr(short8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(x, sizeof(short));
                    case 2: return Sse2.bsrli_si128(x, 2 * sizeof(short));
                    case 3: return Sse2.bsrli_si128(x, 3 * sizeof(short));
                    case 4: return Sse2.bsrli_si128(x, 4 * sizeof(short));
                    case 5: return Sse2.bsrli_si128(x, 5 * sizeof(short));
                    case 6: return Sse2.bsrli_si128(x, 6 * sizeof(short));
                    case 7: return Sse2.bsrli_si128(x, 7 * sizeof(short));

                    default: return short8.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new short8(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0);
                    case 2: return new short8(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0);
                    case 3: return new short8(x.x3, x.x4, x.x5, x.x6, x.x7, 0, 0, 0);
                    case 4: return new short8(x.x4, x.x5, x.x6, x.x7, 0, 0, 0, 0);
                    case 5: return new short8(x.x5, x.x6, x.x7, 0, 0, 0, 0, 0);
                    case 6: return new short8(x.x6, x.x7, 0, 0, 0, 0, 0, 0);
                    case 7: return new short8(x.x7, 0, 0, 0, 0, 0, 0, 0);

                    default: return short8.zero;
                }
            }        }

        /// <summary>       Returns the result of shifting the components within a short16 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 vshr(short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  1 * sizeof(short));
                    case 2:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  2 * sizeof(short));
                    case 3:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  3 * sizeof(short));
                    case 4:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  4 * sizeof(short));
                    case 5:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  5 * sizeof(short));
                    case 6:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  6 * sizeof(short));
                    case 7:  return Avx2.mm256_alignr_epi8(x, Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1)),  7 * sizeof(short));
                    case 8:  return Avx2.mm256_permute2x128_si256(x, default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 9:  return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  1 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 10: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  2 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 11: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  3 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 12: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  4 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 13: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  5 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 14: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  6 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));
                    case 15: return Avx2.mm256_permute2x128_si256(Avx2.mm256_bsrli_epi128(x,  7 * sizeof(short)), default(v256), Sse.SHUFFLE(0, 2, 0, 1));

                    default: return short16.zero;
                }
            }
            else if (Ssse3.IsSsse3Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  1 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  1 * sizeof(short)));
                    case 2:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  2 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  2 * sizeof(short)));
                    case 3:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  3 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  3 * sizeof(short)));
                    case 4:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  4 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  4 * sizeof(short)));
                    case 5:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  5 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  5 * sizeof(short)));
                    case 6:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  6 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  6 * sizeof(short)));
                    case 7:  return new short16(Ssse3.alignr_epi8(x._v8_0, x._v8_8,  7 * sizeof(short)), Sse2.bsrli_si128(x._v8_8,  7 * sizeof(short)));
                    case 8:  return new short16(x._v8_8, short8.zero);
                    case 9:  return new short16(Sse2.bsrli_si128(x._v8_8,  1 * sizeof(short)), short8.zero);
                    case 10: return new short16(Sse2.bsrli_si128(x._v8_8,  2 * sizeof(short)), short8.zero);
                    case 11: return new short16(Sse2.bsrli_si128(x._v8_8,  3 * sizeof(short)), short8.zero);
                    case 12: return new short16(Sse2.bsrli_si128(x._v8_8,  4 * sizeof(short)), short8.zero);
                    case 13: return new short16(Sse2.bsrli_si128(x._v8_8,  5 * sizeof(short)), short8.zero);
                    case 14: return new short16(Sse2.bsrli_si128(x._v8_8,  6 * sizeof(short)), short8.zero);
                    case 15: return new short16(Sse2.bsrli_si128(x._v8_8,  7 * sizeof(short)), short8.zero);

                    default: return short16.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 1 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 7 * sizeof(short)), new v128(0, 0, 0, 0, 0, 0, 0, -1)), 
                                                Sse2.bsrli_si128(x._v8_8, 1 * sizeof(short)));
                    case 2:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 2 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 6 * sizeof(short)), new v128(0, 0, 0, 0, 0, 0, -1, -1)),
                                                Sse2.bsrli_si128(x._v8_8, 2 * sizeof(short)));
                    case 3:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 3 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 5 * sizeof(short)), new v128(0, 0, 0, 0, 0, -1, -1, -1)),
                                                Sse2.bsrli_si128(x._v8_8, 3 * sizeof(short)));
                    case 4:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 4 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 4 * sizeof(short)), new v128(0, 0, 0, 0, -1, -1, -1, -1)),
                                                Sse2.bsrli_si128(x._v8_8, 4 * sizeof(short)));
                    case 5:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 5 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 3 * sizeof(short)), new v128(0, 0, 0, -1, -1, -1, -1, -1)),
                                                Sse2.bsrli_si128(x._v8_8, 5 * sizeof(short)));
                    case 6:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 6 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 2 * sizeof(short)), new v128(0, 0, -1, -1, -1, -1, -1, -1)),
                                                Sse2.bsrli_si128(x._v8_8, 6 * sizeof(short)));
                    case 7:  return new short16(Mask.BlendV(Sse2.bsrli_si128(x._v8_0, 7 * sizeof(short)), Sse2.bslli_si128(x._v8_8, 1 * sizeof(short)), new v128(0, -1, -1, -1, -1, -1, -1, -1)),
                                                Sse2.bsrli_si128(x._v8_8, 7 * sizeof(short)));
                    case 8:  return new short16(x._v8_8, short8.zero);
                    case 9:  return new short16(Sse2.bsrli_si128(x._v8_8,  1 * sizeof(short)), short8.zero);
                    case 10: return new short16(Sse2.bsrli_si128(x._v8_8,  2 * sizeof(short)), short8.zero);
                    case 11: return new short16(Sse2.bsrli_si128(x._v8_8,  3 * sizeof(short)), short8.zero);
                    case 12: return new short16(Sse2.bsrli_si128(x._v8_8,  4 * sizeof(short)), short8.zero);
                    case 13: return new short16(Sse2.bsrli_si128(x._v8_8,  5 * sizeof(short)), short8.zero);
                    case 14: return new short16(Sse2.bsrli_si128(x._v8_8,  6 * sizeof(short)), short8.zero);
                    case 15: return new short16(Sse2.bsrli_si128(x._v8_8,  7 * sizeof(short)), short8.zero);

                    default: return short16.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1:  return new short16(x.x1, x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0);
                    case 2:  return new short16(x.x2, x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0);
                    case 3:  return new short16(x.x3, x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0);
                    case 4:  return new short16(x.x4, x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0);
                    case 5:  return new short16(x.x5, x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0);
                    case 6:  return new short16(x.x6, x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0);
                    case 7:  return new short16(x.x7, x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0);
                    case 8:  return new short16(x.x8, x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 9:  return new short16(x.x9, x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 10: return new short16(x.x10, x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 11: return new short16(x.x11, x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 12: return new short16(x.x12, x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 13: return new short16(x.x13, x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 14: return new short16(x.x14, x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    case 15: return new short16(x.x15, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    default: return short16.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a ushort2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vshr(ushort2 x, int n)
        {
            return (ushort2)vshr((short2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vshr(ushort3 x, int n)
        {
            return (ushort3)vshr((short3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vshr(ushort4 x, int n)
        {
            return (ushort4)vshr((short4)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vshr(ushort8 x, int n)
        {
            return (ushort8)vshr((short8)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ushort16 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 vshr(ushort16 x, int n)
        {
            return (ushort16)vshr((short16)x, n);
        }



        /// <summary>       Returns the result of shifting the components within a long2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vshr(long2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(x, sizeof(long));

                    default: return long2.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long2(x.y, 0);

                    default: return long2.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a long3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vshr(long3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(2, 0, 2, 1));
                    case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(1, 0, 0, 2));

                    default: return long3.zero;
                }
            }
            else if (Sse4_1.IsSse41Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long3(Sse4_1.insert_epi64(Sse2.bsrli_si128(x._xy, 1 * sizeof(long)), x.z, 1), 0);
                    case 2: return new long3(x.z, 0, 0);

                    default: return long3.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long3(x.y, x.z, 0);
                    case 2: return new long3(x.z, 0, 0);

                    default: return long3.zero;
                }
            }
        }

        /// <summary>       Returns the result of shifting the components within a long4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 vshr(long4 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(0, 3, 2, 1));
                    case 2: return Avx2.mm256_permute2x128_si256(default(v256), x, Sse.SHUFFLE(0, 0, 0, 3));
                    case 3: return Avx2.mm256_permute2x128_si256(default(v256), Avx2.mm256_bsrli_epi128(x, 1 * sizeof(long)), Sse.SHUFFLE(0, 0, 0, 3));

                    default: return long4.zero;
                }
            }
            else if (Ssse3.IsSsse3Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long4(Ssse3.alignr_epi8(x._xy, x._zw, 1 * sizeof(long)), Sse2.bsrli_si128(x._zw, 1 * sizeof(long)));
                    case 2: return new long4(x._zw, long2.zero);
                    case 3: return new long4(Sse2.bsrli_si128(x._zw, 1 * sizeof(long)), long2.zero);

                    default: return long4.zero;
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long4(Mask.BlendV(Sse2.bsrli_si128(x._xy, 1 * sizeof(long)), Sse2.bslli_si128(x._zw, 1 * sizeof(long)), new long2(0, -1)),
                                             Sse2.bsrli_si128(x._zw, 1 * sizeof(long)));
                    case 2: return new long4(x._zw, long2.zero);
                    case 3: return new long4(Sse2.bsrli_si128(x._zw, 1 * sizeof(long)), long2.zero);

                    default: return long4.zero;
                }
            }
            else
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return new long4(x.y, x.z, x.w, 0);
                    case 2: return new long4(x.z, x.w, 0, 0);
                    case 3: return new long4(x.w, 0, 0, 0);

                    default: return long4.zero;
                }
            }
        }


        /// <summary>       Returns the result of shifting the components within a ulong2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vshr(ulong2 x, int n)
        {
            return (ulong2)vshr((long2)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ulong3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vshr(ulong3 x, int n)
        {
            return (ulong3)vshr((long3)x, n);
        }

        /// <summary>       Returns the result of shifting the components within a ulong4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vshr(ulong4 x, int n)
        {
            return (ulong4)vshr((long4)x, n);
        }
    }
}