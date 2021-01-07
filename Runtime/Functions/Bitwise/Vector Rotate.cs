using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of rotating the components within a byte2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vror(byte2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a byte3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vror(byte3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a byte4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vror(byte4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a byte8 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vror(byte8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Ssse3.shuffle_epi8(x, new v128(1, 2, 3, 4, 5, 6, 7, 0,      0, 0, 0, 0, 0, 0, 0, 0));
                case 2: return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 3: return Ssse3.shuffle_epi8(x, new v128(3, 4, 5, 6, 7, 0, 1, 2,      0, 0, 0, 0, 0, 0, 0, 0));
                case 4: return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Ssse3.shuffle_epi8(x, new v128(5, 6, 7, 0, 1, 2, 3, 4,      0, 0, 0, 0, 0, 0, 0, 0));
                case 6: return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 7: return Ssse3.shuffle_epi8(x, new v128(7, 0, 1, 2, 3, 4, 5, 6,      0, 0, 0, 0, 0, 0, 0, 0));

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a byte16 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 vror(byte16 x, int n)
        {
            switch (n % 16)
            {
                case 1:  return Ssse3.shuffle_epi8(x, new v128(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0));
                case 2:  return Ssse3.shuffle_epi8(x, new v128(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1));
                case 3:  return Ssse3.shuffle_epi8(x, new v128(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2));
                case 4:  return Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 5:  return Ssse3.shuffle_epi8(x, new v128(5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4));
                case 6:  return Ssse3.shuffle_epi8(x, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5));
                case 7:  return Ssse3.shuffle_epi8(x, new v128(7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6));
                case 8:  return Sse2.shuffle_epi32(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 9:  return Ssse3.shuffle_epi8(x, new v128(9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8));
                case 10: return Ssse3.shuffle_epi8(x, new v128(10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9));
                case 11: return Ssse3.shuffle_epi8(x, new v128(11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
                case 12: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 13: return Ssse3.shuffle_epi8(x, new v128(13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
                case 14: return Ssse3.shuffle_epi8(x, new v128(14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
                case 15: return Ssse3.shuffle_epi8(x, new v128(15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));

                default: return x;
            }
        }

        ///// <summary>       Returns the result of rotating the components within a byte32 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static byte32 vror(byte32 x, int n)
        //{
        //    switch (n % 32)
        //    {
        //        
        //    }
        //}


        /// <summary>       Returns the result of rotating the components within an sbyte2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vror(sbyte2 x, int n)
        {
            return (sbyte2)vror((byte2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vror(sbyte3 x, int n)
        {
            return (sbyte3)vror((byte3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vror(sbyte4 x, int n)
        {
            return (sbyte4)vror((byte4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte8 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vror(sbyte8 x, int n)
        {
            return (sbyte8)vror((byte8)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte16 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vror(sbyte16 x, int n)
        {
            return (sbyte16)vror((byte16)x, n);
        }

        ///// <summary>       Returns the result of rotating the components within an sbyte32 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static sbyte32 vror(sbyte32 x, int n)
        //{
        //    return (sbyte32)vror((byte32)x, n);
        //}


        /// <summary>       Returns the result of rotating the components within a short2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vror(short2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a short3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vror(short3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a short4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vror(short4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a short8 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 vror(short8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Ssse3.shuffle_epi8(x, new v128(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1));
                case 2: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 3: return Ssse3.shuffle_epi8(x, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5));
                case 4: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Ssse3.shuffle_epi8(x, new v128(10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9));
                case 6: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 7: return Ssse3.shuffle_epi8(x, new v128(14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));

                default: return x;
            }
        }

        ///// <summary>       Returns the result of rotating the components within a short16 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static short16 vror(short16 x, int n)
        //{
        //    switch (n % 16)
        //    {
        //        case 1:  return Avx.mm256_insert_epi16(Avx.mm256_insert_epi16(Avx2.mm256_bsrli_epi128(x, 1 * sizeof(short)), x.x8, 7), x.x0, 15);
        //        case 2:  return Avx2.mm256_permutevar8x32_epi32(x, new v256(1, 2, 3, 4, 5, 6, 7, 0));
        //
        //        case 4:  return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 3, 2, 1));
        //        
        //        case 6:  return Avx2.mm256_permutevar8x32_epi32(x, new v256(3, 4, 5, 6, 7, 0, 1, 2));
        //            
        //        case 8:  return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(1, 0, 3, 2));
        //        
        //        case 10: return Avx2.mm256_permutevar8x32_epi32(x, new v256(5, 6, 7, 0, 1, 2, 3, 4));
        //        
        //        case 12: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(2, 1, 0, 3));
        //        
        //        case 14: return Avx2.mm256_permutevar8x32_epi32(x, new v256(7, 0, 1, 2, 3, 4, 5, 6));
        //
        //
        //        default: return x;
        //    }
        //}

        /// <summary>       Returns the result of rotating the components within a ushort2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vror(ushort2 x, int n)
        {
            return (ushort2)vror((short2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ushort3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vror(ushort3 x, int n)
        {
            return (ushort3)vror((short3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ushort4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vror(ushort4 x, int n)
        {
            return (ushort4)vror((short4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ushort8 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vror(ushort8 x, int n)
        {
            return (ushort8)vror((short8)x, n);
        }

        ///// <summary>       Returns the result of rotating the components within a ushort16 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ushort16 vror(ushort16 x, int n)
        //{
        //    return (ushort16)vror((short16)x, n);
        //}


        /// <summary>       Returns the result of rotating the components within an int2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vror(int2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within an int3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vror(int3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an int4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 vror(int4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an int8 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 vror(int8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Avx2.mm256_permutevar8x32_epi32(x, new v256(1, 2, 3, 4, 5, 6, 7, 0));
                case 2: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 3: return Avx2.mm256_permutevar8x32_epi32(x, new v256(3, 4, 5, 6, 7, 0, 1, 2));
                case 4: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Avx2.mm256_permutevar8x32_epi32(x, new v256(5, 6, 7, 0, 1, 2, 3, 4));
                case 6: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 7: return Avx2.mm256_permutevar8x32_epi32(x, new v256(7, 0, 1, 2, 3, 4, 5, 6));

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a uint2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vror(uint2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a uint3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vror(uint3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a uint4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vror(uint4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a uint8 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vror(uint8 x, int n)
        {
            return (uint8)vror((int8)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a long2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vror(long2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a long3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vror(long3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a long4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 vror(long4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a ulong2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vror(ulong2 x, int n)
        {
            return (ulong2)vror((long2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ulong3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vror(ulong3 x, int n)
        {
            return (ulong3)vror((long3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ulong4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vror(ulong4 x, int n)
        {
            return (ulong4)vror((long4)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a quarter2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vror(quarter2 x, int n)
        {
            if (n % 2 != 0)
            {
                return x.yx;
            }
            else
            {
                return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a quarter3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vror(quarter3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a quarter4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vror(quarter4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a quarter8 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vror(quarter8 x, int n)
        {
            return asquarter(vror(asbyte(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a half2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vror(half2 x, int n)
        {
            if (n % 2 != 0)
            {
                return x.yx;
            }
            else
            {
                return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a half3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vror(half3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a half4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vror(half4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a half8 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vror(half8 x, int n)
        {
            return ashalf(vror(asshort(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a float2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vror(float2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a float3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vror(float3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a float4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vror(float4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a float8 vector right by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vror(float8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Avx2.mm256_permutevar8x32_ps(x, new v256(1, 2, 3, 4, 5, 6, 7, 0));
                case 2: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 3: return Avx2.mm256_permutevar8x32_ps(x, new v256(3, 4, 5, 6, 7, 0, 1, 2));
                case 4: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Avx2.mm256_permutevar8x32_ps(x, new v256(5, 6, 7, 0, 1, 2, 3, 4));
                case 6: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 7: return Avx2.mm256_permutevar8x32_ps(x, new v256(7, 0, 1, 2, 3, 4, 5, 6));

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a double2 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vror(double2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a double3 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vror(double3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.yzx;
                case 2: return x.zxy;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a double4 vector right by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vror(double4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.yzwx;
                case 2: return x.zwxy;
                case 3: return x.wxyz;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a byte2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 vrol(byte2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a byte3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 vrol(byte3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a byte4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 vrol(byte4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a byte8 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 vrol(byte8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Ssse3.shuffle_epi8(x, new v128(7, 0, 1, 2, 3, 4, 5, 6,      0, 0, 0, 0, 0, 0, 0, 0));
                case 2: return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 3: return Ssse3.shuffle_epi8(x, new v128(5, 6, 7, 0, 1, 2, 3, 4,      0, 0, 0, 0, 0, 0, 0, 0));
                case 4: return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Ssse3.shuffle_epi8(x, new v128(3, 4, 5, 6, 7, 0, 1, 2,      0, 0, 0, 0, 0, 0, 0, 0));
                case 6: return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 7: return Ssse3.shuffle_epi8(x, new v128(1, 2, 3, 4, 5, 6, 7, 0,      0, 0, 0, 0, 0, 0, 0, 0));

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a byte16 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 vrol(byte16 x, int n)
        {
            switch (n % 16)
            {
                case 1:  return Ssse3.shuffle_epi8(x, new v128(15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14));
                case 2:  return Ssse3.shuffle_epi8(x, new v128(14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
                case 3:  return Ssse3.shuffle_epi8(x, new v128(13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12));
                case 4:  return Sse2.shuffle_epi32(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 5:  return Ssse3.shuffle_epi8(x, new v128(11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
                case 6:  return Ssse3.shuffle_epi8(x, new v128(10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9));
                case 7:  return Ssse3.shuffle_epi8(x, new v128(9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8));
                case 8:  return Sse2.shuffle_epi32(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 9:  return Ssse3.shuffle_epi8(x, new v128(7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6));
                case 10: return Ssse3.shuffle_epi8(x, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5));
                case 11: return Ssse3.shuffle_epi8(x, new v128(5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4));
                case 12: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 13: return Ssse3.shuffle_epi8(x, new v128(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2));
                case 14: return Ssse3.shuffle_epi8(x, new v128(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1));
                case 15: return Ssse3.shuffle_epi8(x, new v128(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0));

                default: return x;
            }
        }

        ///// <summary>       Returns the result of rotating the components within a byte32 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static byte32 vrol(byte32 x, int n)
        //{
        //    switch (n % 32)
        //    {
        //        
        //    }
        //}


        /// <summary>       Returns the result of rotating the components within a sbyte2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 vrol(sbyte2 x, int n)
        {
            return (sbyte2)vrol((byte2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 vrol(sbyte3 x, int n)
        {
            return (sbyte3)vrol((byte3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 vrol(sbyte4 x, int n)
        {
            return (sbyte4)vrol((byte4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 vrol(sbyte8 x, int n)
        {
            return (sbyte8)vrol((byte8)x, n);
        }

        /// <summary>       Returns the result of rotating the components within an sbyte16 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 vrol(sbyte16 x, int n)
        {
            return (sbyte16)vrol((byte16)x, n);
        }

        ///// <summary>       Returns the result of rotating the components within an sbyte32 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static sbyte32 vrol(sbyte32 x, int n)
        //{
        //    return (sbyte32)vrol((byte32)x, n);
        //}


        /// <summary>       Returns the result of rotating the components within a short2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 vrol(short2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a short3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 vrol(short3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a short4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 vrol(short4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a short8 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 vrol(short8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Ssse3.shuffle_epi8(x, new v128(14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13));
                case 2: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 3: return Ssse3.shuffle_epi8(x, new v128(10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9));
                case 4: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Ssse3.shuffle_epi8(x, new v128(6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1, 2, 3, 4, 5));
                case 6: return Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 7: return Ssse3.shuffle_epi8(x, new v128(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0, 1));

                default: return x;
            }
        }

        ///// <summary>       Returns the result of rotating the components within a short16 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static short16 vrol(short16 x, int n)
        //{
        //    switch (n % 16)
        //    {
        //        
        //        case 2:  return Avx2.mm256_permutevar8x32_epi32(x, new v256(7, 0, 1, 2, 3, 4, 5, 6));
        //                 
        //        case 4:  return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(2, 1, 0, 3));
        //                 
        //        case 6:  return Avx2.mm256_permutevar8x32_epi32(x, new v256(5, 6, 7, 0, 1, 2, 3, 4));
        //                 
        //        case 8:  return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(1, 0, 3, 2));
        //
        //        case 10: return Avx2.mm256_permutevar8x32_epi32(x, new v256(3, 4, 5, 6, 7, 0, 1, 2));
        //
        //        case 12: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 3, 2, 1));
        //
        //        case 14: return Avx2.mm256_permutevar8x32_epi32(x, new v256(1, 2, 3, 4, 5, 6, 7, 0));
        //        case 15: return Avx.mm256_insert_epi16(Avx.mm256_insert_epi16(Avx2.mm256_bslli_epi128(x, 1 * sizeof(short)), x.x15, 0), x.x7, 8);
        //
        //        default: return x;
        //    }
        //}


        /// <summary>       Returns the result of rotating the components within a ushort2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 vrol(ushort2 x, int n)
        {
            return (ushort2)vrol((short2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ushort3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 vrol(ushort3 x, int n)
        {
            return (ushort3)vrol((short3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ushort4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 vrol(ushort4 x, int n)
        {
            return (ushort4)vrol((short4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ushort8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 vrol(ushort8 x, int n)
        {
            return (ushort8)vrol((short8)x, n);
        }

        ///// <summary>       Returns the result of rotating the components within a ushort16 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static ushort16 vrol(ushort16 x, int n)
        //{
        //    return (ushort16)vrol((short16)x, n);
        //}


        /// <summary>       Returns the result of rotating the components within an int2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 vrol(int2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within an int3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 vrol(int3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an int4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 vrol(int4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within an int8 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 vrol(int8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Avx2.mm256_permutevar8x32_epi32(x, new v256(7, 0, 1, 2, 3, 4, 5, 6));
                case 2: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 3: return Avx2.mm256_permutevar8x32_epi32(x, new v256(5, 6, 7, 0, 1, 2, 3, 4));
                case 4: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Avx2.mm256_permutevar8x32_epi32(x, new v256(3, 4, 5, 6, 7, 0, 1, 2));
                case 6: return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 7: return Avx2.mm256_permutevar8x32_epi32(x, new v256(1, 2, 3, 4, 5, 6, 7, 0));

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a uint2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 vrol(uint2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a uint3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 vrol(uint3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a uint4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 vrol(uint4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a uint8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 vrol(uint8 x, int n)
        {
            return (uint8)vrol((int8)x, n);
        }


        /// <summary>       Returns the result of rotating the components within a long2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 vrol(long2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a long3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 vrol(long3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a long4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 vrol(long4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a ulong2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 vrol(ulong2 x, int n)
        {
            return (ulong2)vrol((long2)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ulong3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 vrol(ulong3 x, int n)
        {
            return (ulong3)vrol((long3)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a ulong4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 vrol(ulong4 x, int n)
        {
            return (ulong4)vrol((long4)x, n);
        }

        /// <summary>       Returns the result of rotating the components within a quarter2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 vrol(quarter2 x, int n)
        {
            if (n % 2 != 0)
            {
                return x.yx;
            }
            else
            {
                return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a quarter3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 vrol(quarter3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a quarter4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 vrol(quarter4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a quarter8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 vrol(quarter8 x, int n)
        {
            return asquarter(vrol(asbyte(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a half2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 vrol(half2 x, int n)
        {
            if (n % 2 != 0)
            {
                return x.yx;
            }
            else
            {
                return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a half3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 vrol(half3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a half4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 vrol(half4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a half8 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 vrol(half8 x, int n)
        {
            return ashalf(vrol(asshort(x), n));
        }


        /// <summary>       Returns the result of rotating the components within a float2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 vrol(float2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a float3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 vrol(float3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a float4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 vrol(float4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a float8 vector left by n.      </summary>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 vrol(float8 x, int n)
        {
            switch (n % 8)
            {
                case 1: return Avx2.mm256_permutevar8x32_ps(x, new v256(7, 0, 1, 2, 3, 4, 5, 6));
                case 2: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(2, 1, 0, 3));
                case 3: return Avx2.mm256_permutevar8x32_ps(x, new v256(5, 6, 7, 0, 1, 2, 3, 4));
                case 4: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(1, 0, 3, 2));
                case 5: return Avx2.mm256_permutevar8x32_ps(x, new v256(3, 4, 5, 6, 7, 0, 1, 2));
                case 6: return Avx2.mm256_permute4x64_pd(x, Sse.SHUFFLE(0, 3, 2, 1));
                case 7: return Avx2.mm256_permutevar8x32_ps(x, new v256(1, 2, 3, 4, 5, 6, 7, 0));

                default: return x;
            }
        }


        /// <summary>       Returns the result of rotating the components within a double2 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 vrol(double2 x, int n)
        {
            return (n % 2 != 0) ? x.yx : x;
        }

        /// <summary>       Returns the result of rotating the components within a double3 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 vrol(double3 x, int n)
        {
            switch (n % 3)
            {
                case 1: return x.zxy;
                case 2: return x.yzx;

                default: return x;
            }
        }

        /// <summary>       Returns the result of rotating the components within a double4 vector left by n.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 vrol(double4 x, int n)
        {
            switch (n % 4)
            {
                case 1: return x.wxyz;
                case 2: return x.zwxy;
                case 3: return x.yzwx;

                default: return x;
            }
        }
    }
}
