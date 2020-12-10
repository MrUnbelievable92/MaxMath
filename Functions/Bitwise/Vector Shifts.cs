using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using System;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of shifting the components of an int2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vshl(int2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bslli_si128(*(v128*)&x, sizeof(int)); return *(int2*)&temp;

                default: return default(int2);
            }
        }

        /// <summary>       Returns the result of shifting the components of an int3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vshl(int3 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(int)); return *(int3*)&temp;
                case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int3*)&temp;

                default: return default(int3);
            }
        }

        /// <summary>       Returns the result of shifting the components of an int4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 vshl(int4 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(int)); return *(int4*)&temp;
                case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int4*)&temp;
                case 3: temp = Sse2.bslli_si128(*(v128*)&x, 3 * sizeof(int)); return *(int4*)&temp;

                default: return default(int4);
            }
        }

        /// <summary>       Returns the result of shifting the components of an int8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 vshl(int8 x, int n)
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

                default: return default(int8);
            }
        }


        /// <summary>       Returns the result of shifting the components of a uint2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vshl(uint2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bslli_si128(*(v128*)&x, sizeof(uint)); return *(uint2*)&temp;

                default: return default(uint2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a uint3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vshl(uint3 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(uint)); return *(uint3*)&temp;
                case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(uint)); return *(uint3*)&temp;

                default: return default(uint3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a uint4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vshl(uint4 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(uint)); return *(uint4*)&temp;
                case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(uint)); return *(uint4*)&temp;
                case 3: temp = Sse2.bslli_si128(*(v128*)&x, 3 * sizeof(uint)); return *(uint4*)&temp;

                default: return default(uint4);
            }
        }

        /// <summary>       Returns the result of rotating the components of a uint8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vshl(uint8 x, int n)
        {
            return (uint8)vshl((int8)x, n);
        }


        /// <summary>       Returns the result of shifting the components of a float2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vshl(float2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bslli_si128(*(v128*)&x, sizeof(float)); return *(float2*)&temp;

                default: return default(float2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a float3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vshl(float3 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(float)); return *(float3*)&temp;
                case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(float)); return *(float3*)&temp;

                default: return default(float3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a float4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vshl(float4 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bslli_si128(*(v128*)&x, sizeof(float)); return *(float4*)&temp;
                case 2: temp = Sse2.bslli_si128(*(v128*)&x, 2 * sizeof(float)); return *(float4*)&temp;
                case 3: temp = Sse2.bslli_si128(*(v128*)&x, 3 * sizeof(float)); return *(float4*)&temp;

                default: return default(float4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a float8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vshl(float8 x, int n)
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

                default: return default(int8); ;
            }
        }


        /// <summary>       Returns the result of shifting the components of a double2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vshl(double2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bslli_si128(*(v128*)&x, sizeof(double)); return *(double2*)&temp;

                default: return default(double2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a double3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vshl(double3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return new double3(0d, x.xy);
                case 2: return new double3(default(double2), x.x);
        
                default: return default(double3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a double4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vshl(double4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return new double4(0d, x.xyz);
                case 2: return new double4(default(double2), x.xy);
                case 3: return new double4(default(double3), x.x);
        
                default: return default(double4);
            }
        }


        /// <summary>       Returns the result of shifting the components of a byte2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vshl(byte2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(byte));

                default: return default(byte2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vshl(byte3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(byte));
                case 2: return Sse2.bslli_si128(x, 2 * sizeof(byte));

                default: return default(byte3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vshl(byte4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(byte));
                case 2: return Sse2.bslli_si128(x, 2 * sizeof(byte));
                case 3: return Sse2.bslli_si128(x, 3 * sizeof(byte));

                default: return default(byte4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vshl(byte8 x, int n)
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

                default: return default(byte8);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte16 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 vshl(byte16 x, int n)
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
                case 12: return Sse2.bslli_si128(x, 12 * sizeof(byte));
                case 13: return Sse2.bslli_si128(x, 13 * sizeof(byte));
                case 14: return Sse2.bslli_si128(x, 14 * sizeof(byte));
                case 15: return Sse2.bslli_si128(x, 15 * sizeof(byte));

                default: return default(byte16);
            }
        }

        ///// <summary>       Returns the result of shifting the components of a byte32 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static byte32 vshl(byte32 x, int n)
        //{
        //    switch (n)
        //    {
        //
        //    }
        //}


        /// <summary>       Returns the result of shifting the components of an sbyte2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vshl(sbyte2 x, int n)
        {
            return (sbyte2)vshl((byte2)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vshl(sbyte3 x, int n)
        {
            return (sbyte3)vshl((byte3)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vshl(sbyte4 x, int n)
        {
            return (sbyte4)vshl((byte4)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vshl(sbyte8 x, int n)
        {
            return (sbyte8)vshl((byte8)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte16 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vshl(sbyte16 x, int n)
        {
            return (sbyte16)vshl((byte16)x, n);
        }

        ///// <summary>       Returns the result of shifting the components of an sbyte32 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static sbyte32 vshl(sbyte32 x, int n)
        //{
        //    return (sbyte32)vshl((byte32)x, n);
        //}


        /// <summary>       Returns the result of shifting the components of a short2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshl(short2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(short));

                default: return default(short2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a short3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vshl(short3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(short));
                case 2: return Sse2.bslli_si128(x, 2 * sizeof(short));

                default: return default(short3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a short4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vshl(short4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(short));
                case 2: return Sse2.bslli_si128(x, 2 * sizeof(short));
                case 3: return Sse2.bslli_si128(x, 3 * sizeof(short));

                default: return default(short4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a short8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 vshl(short8 x, int n)
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

                default: return default(short8);
            }
        }

        ///// <summary>       Returns the result of shifting the components of a short16 vector left by n while shifting in zeros.      </summary>
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
        //        default: return default(short16);
        //    }
        //}


        /// <summary>       Returns the result of shifting the components of a ushort2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vshl(ushort2 x, int n)
        {
            return (ushort2)vshl((short2)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vshl(ushort3 x, int n)
        {
            return (ushort3)vshl((short3)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vshl(ushort4 x, int n)
        {
            return (ushort4)vshl((short4)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort8 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vshl(ushort8 x, int n)
        {
            return (ushort8)vshl((short8)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort16 vector left by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ushort16 vshl(ushort16 x, int n)
        //{
        //    return (ushort16)vshl((short16)x, n);
        //}


        /// <summary>       Returns the result of shifting the components of a long2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vshl(long2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bslli_si128(x, sizeof(long));

                default: return default(long2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a long3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vshl(long3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(3,   1, 0, 3));
                case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(3,   0, 3, 3));

                default: return default(long3); ;
            }
        }

        /// <summary>       Returns the result of shifting the components of a long4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 vshl(long4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(2, 1, 0, 3));
                case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(1, 0, 3, 3));
                case 3: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0, 3), Sse.SHUFFLE(0, 3, 3, 3));

                default: return default(long4); ;
            }
        }


        /// <summary>       Returns the result of shifting the components of a ulong2 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vshl(ulong2 x, int n)
        {
            return (ulong2)vshl((long2)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ulong3 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vshl(ulong3 x, int n)
        {
            return (ulong3)vshl((long3)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ulong4 vector left by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vshl(ulong4 x, int n)
        {
            return (ulong4)vshl((long4)x, n);
        }


        /// <summary>       Returns the result of shifting the components of an int2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vshr(int2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(int)); return *(int2*)&temp;

                default: return default(int2);
            }
        }

        /// <summary>       Returns the result of shifting the components of an int3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vshr(int3 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(int)); return *(int3*)&temp;
                case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2* sizeof(int)); return *(int3*)&temp;

                default: return default(int3);
            }
        }

        /// <summary>       Returns the result of shifting the components of an int4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 vshr(int4 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(int)); return *(int4*)&temp;
                case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(int)); return *(int4*)&temp;
                case 3: temp = Sse2.bsrli_si128(*(v128*)&x, 3 * sizeof(int)); return *(int4*)&temp;

                default: return default(int4);
            }
        }

        /// <summary>       Returns the result of shifting the components of an int8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 vshr(int8 x, int n)
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

                default: return default(int8); ;
            }
        }


        /// <summary>       Returns the result of shifting the components of a uint2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vshr(uint2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(uint)); return *(uint2*)&temp;

                default: return default(uint2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a uint3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vshr(uint3 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(uint)); return *(uint3*)&temp;
                case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(uint)); return *(uint3*)&temp;

                default: return default(uint3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a uint4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vshr(uint4 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(uint)); return *(uint4*)&temp;
                case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(uint)); return *(uint4*)&temp;
                case 3: temp = Sse2.bsrli_si128(*(v128*)&x, 3 * sizeof(uint)); return *(uint4*)&temp;

                default: return default(uint4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a uint8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vshr(uint8 x, int n)
        {
            return (uint8)vshr((int8)x, n);
        }


        /// <summary>       Returns the result of shifting the components of a float2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vshr(float2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(float)); return *(float2*)&temp;

                default: return default(float2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a float3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vshr(float3 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(float)); return *(float3*)&temp;
                case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(float)); return *(float3*)&temp;

                default: return default(float3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a float4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vshr(float4 x, int n)
        {
            v128 temp;

            switch (n)
            {
                case 0: return x;

                case 1: temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(float)); return *(float4*)&temp;
                case 2: temp = Sse2.bsrli_si128(*(v128*)&x, 2 * sizeof(float)); return *(float4*)&temp;
                case 3: temp = Sse2.bsrli_si128(*(v128*)&x, 3 * sizeof(float)); return *(float4*)&temp;

                default: return default(float4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a float8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vshr(float8 x, int n)
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

                default: return default(int8); ;
            }
        }


        /// <summary>       Returns the result of shifting the components of a double2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vshr(double2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: v128 temp = Sse2.bsrli_si128(*(v128*)&x, sizeof(double)); return *(double2*)&temp;

                default: return default(double2);
            }
        }


        /// <summary>       Returns the result of shifting the components of a double3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vshr(double3 x, int n)
        {
            switch (n)
            {
                case 0:    return x;

                case 1:    return new double3(x.yz, 0d);
                case 2:    return new double3(x.z, default(double2));

                default:   return default(double3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a double4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vshr(double4 x, int n)
        {
            switch (n)
            {
                case 0:     return x;

                case 1:     return new double4(x.yzw, 0d);
                case 2:     return new double4(x.zw, new double2(2d));
                case 3:     return new double4(x.w, default(double3));
        
                default:    return default(double4);
            }
        }


        /// <summary>       Returns the result of shifting the components of a byte2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vshr(byte2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(byte));

                default: return default(byte2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vshr(byte3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(byte));
                case 2: return Sse2.bsrli_si128(x, 2 * sizeof(byte));

                default: return default(byte3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vshr(byte4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(byte));
                case 2: return Sse2.bsrli_si128(x, 2 * sizeof(byte));
                case 3: return Sse2.bsrli_si128(x, 3 * sizeof(byte));

                default: return default(byte4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vshr(byte8 x, int n)
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

                default: return default(byte8);
            }
        }

        /// <summary>       Returns the result of shifting the components of a byte16 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 vshr(byte16 x, int n)
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
                case 12: return Sse2.bsrli_si128(x, 12 * sizeof(byte));
                case 13: return Sse2.bsrli_si128(x, 13 * sizeof(byte));
                case 14: return Sse2.bsrli_si128(x, 14 * sizeof(byte));
                case 15: return Sse2.bsrli_si128(x, 15 * sizeof(byte));

                default: return default(byte16);
            }
        }

        ///// <summary>       Returns the result of shifting the components of a byte32 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static byte32 vshr(byte32 x, int n)
        //{
        //    switch (n)
        //    {
        //
        //    }
        //}


        /// <summary>       Returns the result of shifting the components of an sbyte2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vshr(sbyte2 x, int n)
        {
            return (sbyte2)vshr((byte2)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vshr(sbyte3 x, int n)
        {
            return (sbyte3)vshr((byte3)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vshr(sbyte4 x, int n)
        {
            return (sbyte4)vshr((byte4)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vshr(sbyte8 x, int n)
        {
            return (sbyte8)vshr((byte8)x, n);
        }

        /// <summary>       Returns the result of shifting the components of an sbyte16 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vshr(sbyte16 x, int n)
        {
            return (sbyte16)vshr((byte16)x, n);
        }

        ///// <summary>       Returns the result of shifting the components of an sbyte32 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static sbyte32 vshr(sbyte32 x, int n)
        //{
        //    return (sbyte32)vshr((byte32)x, n);
        //}


        /// <summary>       Returns the result of shifting the components of a short2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vshr(short2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(short));

                default: return default(short2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a short3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vshr(short3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(short));
                case 2: return Sse2.bsrli_si128(x, 2 * sizeof(short));

                default: return default(short3);
            }
        }

        /// <summary>       Returns the result of shifting the components of a short4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vshr(short4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(short));
                case 2: return Sse2.bsrli_si128(x, 2 * sizeof(short));
                case 3: return Sse2.bsrli_si128(x, 3 * sizeof(short));

                default: return default(short4);
            }
        }

        /// <summary>       Returns the result of shifting the components of a short8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 vshr(short8 x, int n)
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

                default: return default(short8);
            }
        }

        ///// <summary>       Returns the result of shifting the components of a short16 vector right by n while shifting in zeros.      </summary>
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
        //        default: return default(short16);
        //    }
        //}


        /// <summary>       Returns the result of shifting the components of a ushort2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vshr(ushort2 x, int n)
        {
            return (ushort2)vshr((short2)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vshr(ushort3 x, int n)
        {
            return (ushort3)vshr((short3)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vshr(ushort4 x, int n)
        {
            return (ushort4)vshr((short4)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ushort8 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vshr(ushort8 x, int n)
        {
            return (ushort8)vshr((short8)x, n);
        }

        ///// <summary>       Returns the result of shifting the components of a ushort16 vector right by n while shifting in zeros.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ushort16 vshr(ushort16 x, int n)
        //{
        //    return (ushort16)vshr((short16)x, n);
        //}



        /// <summary>       Returns the result of shifting the components of a long2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vshr(long2 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Sse2.bsrli_si128(x, sizeof(long));

                default: return default(long2);
            }
        }

        /// <summary>       Returns the result of shifting the components of a long3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vshr(long3 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(2,   0, 2, 1));
                case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(1,   0, 0, 2));

                default: return default(long3); ;
            }
        }

        /// <summary>       Returns the result of shifting the components of a long4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 vshr(long4 x, int n)
        {
            switch (n)
            {
                case 0: return x;

                case 1: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(0, 3, 2, 1));
                case 2: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(0, 0, 3, 2));
                case 3: return Avx2.mm256_permute4x64_epi64(Avx.mm256_insert_epi64(x, 0L, 0), Sse.SHUFFLE(0, 0, 0, 3));

                default: return default(long4); ;
            }
        }


        /// <summary>       Returns the result of shifting the components of a ulong2 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vshr(ulong2 x, int n)
        {
            return (ulong2)vshr((long2)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ulong3 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vshr(ulong3 x, int n)
        {
            return (ulong3)vshr((long3)x, n);
        }

        /// <summary>       Returns the result of shifting the components of a ulong4 vector right by n while shifting in zeros.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vshr(ulong4 x, int n)
        {
            return (ulong4)vshr((long4)x, n);
        }
    }
}