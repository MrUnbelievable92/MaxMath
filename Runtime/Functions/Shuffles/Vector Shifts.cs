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

                    case 1: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 0, 1, 2, 3, 4, 5, 6));
                    case 2: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 0, 1, 2, 3, 4, 5));
                    case 3: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 0, 1, 2, 3, 4));
                    case 4: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 0, 1, 2, 3));
                    case 5: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 7, 0, 1, 2));
                    case 6: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 7, 7, 0, 1));
                    case 7: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 7, 7, 7, 0));

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

                    case 1: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 0, 1, 2, 3, 4, 5, 6));
                    case 2: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 0, 1, 2, 3, 4, 5));
                    case 3: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 0, 1, 2, 3, 4));
                    case 4: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 0, 1, 2, 3));
                    case 5: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 7, 0, 1, 2));
                    case 6: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 7, 7, 0, 1));
                    case 7: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 7), new v256(7, 7, 7, 7, 7, 7, 7, 0));

                    default: return int8.zero;
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

        ///// <summary>       Returns the result of shifting the components within a byte32 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static byte32 vshl(byte32 x, int n)
        //{
        //    switch (n)
        //    {
        //
        //    }
        //}


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

        ///// <summary>       Returns the result of shifting the components within an sbyte32 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static sbyte32 vshl(sbyte32 x, int n)
        //{
        //    return (sbyte32)vshl((byte32)x, n);
        //}


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

        ///// <summary>       Returns the result of shifting the components within a short16 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static short16 vshl(short16 x, int n)
        //{
        //    switch (n)
        //    {
        //        case 0: return x;
        //
        //        case 1:  return Avx.mm256_insert_epi16(Avx.mm256_insert_epi16(Avx2.mm256_bslli_epi128(x, sizeof(short)), 0, 0), x.x7, 8);
        //        case 2:  return Sse2.bslli_si128(x, 2 * sizeof(short));
        //        case 3:  return Sse2.bslli_si128(x, 3 * sizeof(short));
        //        case 4:  return Sse2.bslli_si128(x, 4 * sizeof(short));
        //        case 5:  return Sse2.bslli_si128(x, 5 * sizeof(short));
        //        case 6:  return Sse2.bslli_si128(x, 6 * sizeof(short));
        //        case 7:  return Sse2.bslli_si128(x, 7 * sizeof(short));
        //        case 8:  return Sse2.bslli_si128(x, 8 * sizeof(short));
        //        case 9:  return Sse2.bslli_si128(x, 9 * sizeof(short));
        //        case 10: return Sse2.bslli_si128(x, 10 * sizeof(short));
        //        case 11: return Sse2.bslli_si128(x, 11 * sizeof(short));
        //        case 12: return Sse2.bslli_si128(x, 12 * sizeof(short));
        //        case 13: return Sse2.bslli_si128(x, 13 * sizeof(short));
        //        case 14: return Sse2.bslli_si128(x, 14 * sizeof(short));
        //        case 15: return Sse2.bslli_si128(x, 15 * sizeof(short));
        //
        //        default: return short16.zero;
        //    }
        //}


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
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ushort16 vshl(ushort16 x, int n)
        //{
        //    return (ushort16)vshl((short16)x, n);
        //}


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
                    case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(3,   0, 3, 3));

                    default: return long3.zero;
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
                    case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(1, 0, 3, 3));
                    case 3: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(0, 3, 3, 3));

                    default: return long4.zero;
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

                    case 1: v128 temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(int)); return *(int2*)&temp;

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
                v128  temp ;

                switch (n)
                {
                    case 0: return x;

                    case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(int)); return *(int3*)&temp;
                    case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int3*)&temp;

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

                    case 1: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(1, 2, 3, 4, 5, 6, 7, 0));
                    case 2: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(2, 3, 4, 5, 6, 7, 0, 0));
                    case 3: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(3, 4, 5, 6, 7, 0, 0, 0));
                    case 4: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(4, 5, 6, 7, 0, 0, 0, 0));
                    case 5: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(5, 6, 7, 0, 0, 0, 0, 0));
                    case 6: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(6, 7, 0, 0, 0, 0, 0, 0));
                    case 7: return Avx2.mm256_permutevar8x32_epi32(Avx.mm256_insert_epi32(x, 0, 0), new v256(7, 0, 0, 0, 0, 0, 0, 0));

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

                    case 1: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(1, 2, 3, 4, 5, 6, 7, 0));
                    case 2: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(2, 3, 4, 5, 6, 7, 0, 0));
                    case 3: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(3, 4, 5, 6, 7, 0, 0, 0));
                    case 4: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(4, 5, 6, 7, 0, 0, 0, 0));
                    case 5: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(5, 6, 7, 0, 0, 0, 0, 0));
                    case 6: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(6, 7, 0, 0, 0, 0, 0, 0));
                    case 7: return Avx2.mm256_permutevar8x32_ps(Avx.mm256_insert_epi32(x, 0, 0), new v256(7, 0, 0, 0, 0, 0, 0, 0));

                    default: return int8.zero;
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

                    case 1: return Sse2.bsrli_si128(x, sizeof(byte));

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

                    case 1: return Sse2.bsrli_si128(x, sizeof(byte));
                    case 2: return Sse2.bsrli_si128(x, 2 * sizeof(byte));

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

                    case 1: return Sse2.bsrli_si128(x, sizeof(byte));
                    case 2: return Sse2.bsrli_si128(x, 2 * sizeof(byte));
                    case 3: return Sse2.bsrli_si128(x, 3 * sizeof(byte));

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
            if (Avx2.IsAvx2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(x, sizeof(byte));
                    case 2: return Sse2.bsrli_si128(x, 2 * sizeof(byte));
                    case 3: return Sse2.bsrli_si128(x, 3 * sizeof(byte));
                    case 4: return Sse2.bsrli_si128(x, 4 * sizeof(byte));
                    case 5: return Sse2.bsrli_si128(x, 5 * sizeof(byte));
                    case 6: return Sse2.bsrli_si128(x, 6 * sizeof(byte));
                    case 7: return Sse2.bsrli_si128(x, 7 * sizeof(byte));

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

        ///// <summary>       Returns the result of shifting the components within a byte32 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static byte32 vshr(byte32 x, int n)
        //{
        //    switch (n)
        //    {
        //
        //    }
        //}


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

        ///// <summary>       Returns the result of shifting the components within an sbyte32 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static sbyte32 vshr(sbyte32 x, int n)
        //{
        //    return (sbyte32)vshr((byte32)x, n);
        //}


        /// <summary>       Returns the result of shifting the components within a short2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshr(short2 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                switch (n)
                {
                    case 0: return x;

                    case 1: return Sse2.bsrli_si128(x, sizeof(short));

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

                    case 1: return Sse2.bsrli_si128(x, sizeof(short));
                    case 2: return Sse2.bsrli_si128(x, 2 * sizeof(short));

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

                    case 1: return Sse2.bsrli_si128(x, sizeof(short));
                    case 2: return Sse2.bsrli_si128(x, 2 * sizeof(short));
                    case 3: return Sse2.bsrli_si128(x, 3 * sizeof(short));

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
            if (Avx2.IsAvx2Supported)
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

        ///// <summary>       Returns the result of shifting the components within a short16 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static short16 vshr(short16 x, int n)
        //{
        //    switch (n)
        //    {
        //        case 0: return x;
        //
        //        case 1:  return Sse2.bsrli_si128(x, sizeof(short));
        //        case 2:  return Sse2.bsrli_si128(x, 2 * sizeof(short));
        //        case 3:  return Sse2.bsrli_si128(x, 3 * sizeof(short));
        //        case 4:  return Sse2.bsrli_si128(x, 4 * sizeof(short));
        //        case 5:  return Sse2.bsrli_si128(x, 5 * sizeof(short));
        //        case 6:  return Sse2.bsrli_si128(x, 6 * sizeof(short));
        //        case 7:  return Sse2.bsrli_si128(x, 7 * sizeof(short));
        //        case 8:  return Sse2.bsrli_si128(x, 8 * sizeof(short));
        //        case 9:  return Sse2.bsrli_si128(x, 9 * sizeof(short));
        //        case 10: return Sse2.bsrli_si128(x, 10 * sizeof(short));
        //        case 12: return Sse2.bsrli_si128(x, 12 * sizeof(short));
        //        case 13: return Sse2.bsrli_si128(x, 13 * sizeof(short));
        //        case 14: return Sse2.bsrli_si128(x, 14 * sizeof(short));
        //        case 15: return Sse2.bsrli_si128(x, 15 * sizeof(short));
        //
        //        default: return short16.zero;
        //    }
        //}


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

        ///// <summary>       Returns the result of shifting the components within a ushort16 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ushort16 vshr(ushort16 x, int n)
        //{
        //    return (ushort16)vshr((short16)x, n);
        //}



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
                    case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(0, 0, 3, 2));
                    case 3: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(0, 0, 0, 3));

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