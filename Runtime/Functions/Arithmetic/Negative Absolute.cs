using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise negative absolute value of an sbyte2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 nabs(sbyte2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(default(v128), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(default(v128), x));
            }
            else
            {
                return new sbyte2((sbyte)nabs((int)x.x), (sbyte)nabs((int)x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an sbyte3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 nabs(sbyte3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(default(v128), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(default(v128), x));
            }
            else
            {
                return new sbyte3((sbyte)nabs((int)x.x), (sbyte)nabs((int)x.y), (sbyte)nabs((int)x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an sbyte4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 nabs(sbyte4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(default(v128), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(default(v128), x));
            }
            else
            {
                return new sbyte4((sbyte)nabs((int)x.x), (sbyte)nabs((int)x.y), (sbyte)nabs((int)x.z), (sbyte)nabs((int)x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an sbyte8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 nabs(sbyte8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(default(v128), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(default(v128), x));
            }
            else
            {
                return new sbyte8((sbyte)nabs((int)x.x0), (sbyte)nabs((int)x.x1), (sbyte)nabs((int)x.x2), (sbyte)nabs((int)x.x3), (sbyte)nabs((int)x.x4), (sbyte)nabs((int)x.x5), (sbyte)nabs((int)x.x6), (sbyte)nabs((int)x.x7));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an sbyte16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 nabs(sbyte16 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi8(default(v128), Ssse3.abs_epi8(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi8(default(v128), x));
            }
            else
            {
                return new sbyte16((sbyte)nabs((int)x.x0), (sbyte)nabs((int)x.x1), (sbyte)nabs((int)x.x2), (sbyte)nabs((int)x.x3), (sbyte)nabs((int)x.x4), (sbyte)nabs((int)x.x5), (sbyte)nabs((int)x.x6), (sbyte)nabs((int)x.x7), (sbyte)nabs((int)x.x8), (sbyte)nabs((int)x.x9), (sbyte)nabs((int)x.x10), (sbyte)nabs((int)x.x11), (sbyte)nabs((int)x.x12), (sbyte)nabs((int)x.x13), (sbyte)nabs((int)x.x14), (sbyte)nabs((int)x.x15));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an sbyte32 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 nabs(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(default(v256), Avx2.mm256_abs_epi8(x));
            }
            else
            {
                return new sbyte32(abs(x.v16_0), nabs(x.v16_16));
            }
        }


        /// <summary>       Returns the componentwise negative absolute value of a short2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 nabs(short2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(default(v128), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi16(default(v128), x));
            }
            else
            {
                return new short2((short)nabs((int)x.x), (short)nabs((int)x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a short3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 nabs(short3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(default(v128), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi16(default(v128), x));
            }
            else
            {
                return new short3((short)nabs((int)x.x), (short)nabs((int)x.y), (short)nabs((int)x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a short4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 nabs(short4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(default(v128), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi16(default(v128), x));
            }
            else
            {
                return new short4((short)nabs((int)x.x), (short)nabs((int)x.y), (short)nabs((int)x.z), (short)nabs((int)x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a short8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 nabs(short8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Sse2.sub_epi16(default(v128), Ssse3.abs_epi16(x));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Sse2.cmpgt_epi16(default(v128), x));
            }
            else
            {
                return new short8((short)nabs((int)x.x0), (short)nabs((int)x.x1), (short)nabs((int)x.x2), (short)nabs((int)x.x3), (short)nabs((int)x.x4), (short)nabs((int)x.x5), (short)nabs((int)x.x6), (short)nabs((int)x.x7));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a short16 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 nabs(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(default(v256), Avx2.mm256_abs_epi16(x));
            }
            else
            {
                return new short16(abs(x.v8_0), nabs(x.v8_8));
            }
        }


        /// <summary>       Returns the negative absolute value of an int value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int nabs(int x)
        {
            return x < 0 ? x : -x;
        }

        /// <summary>       Returns the componentwise negative absolute value of an int2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 nabs(int2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 _nabs = Sse2.sub_epi32(default(v128), Ssse3.abs_epi32(*(v128*)&x));

                return *(int2*)&_nabs;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Mask.BlendV(Sse2.sub_epi32(default(v128), *(v128*)&x), *(v128*)&x, Sse2.cmpgt_epi32(default(v128), *(v128*)&x));

                return *(int2*)&_nabs;
            }
            else
            {
                return new int2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an int3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 nabs(int3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 _nabs = Sse2.sub_epi32(default(v128), Ssse3.abs_epi32(*(v128*)&x));

                return *(int3*)&_nabs;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Mask.BlendV(Sse2.sub_epi32(default(v128), *(v128*)&x), *(v128*)&x, Sse2.cmpgt_epi32(default(v128), *(v128*)&x));

                return *(int3*)&_nabs;
            }
            else
            {
                return new int3(nabs(x.x), nabs(x.y), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an int4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 nabs(int4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 _nabs = Sse2.sub_epi32(default(v128), Ssse3.abs_epi32(*(v128*)&x));

                return *(int4*)&_nabs;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Mask.BlendV(Sse2.sub_epi32(default(v128), *(v128*)&x), *(v128*)&x, Sse2.cmpgt_epi32(default(v128), *(v128*)&x));

                return *(int4*)&_nabs;
            }
            else
            {
                return new int4(nabs(x.x), nabs(x.y), nabs(x.z), nabs(x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of an int8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 nabs(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(default(v256), Avx2.mm256_abs_epi32(x));
            }
            else
            {
                return new int8(nabs(x.v4_0), nabs(x.v4_4));
            }
        }


        /// <summary>       Returns the negative absolute value of a long value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long nabs(long x)
        {
            return x < 0 ? x : -x;
        }

        /// <summary>       Returns the componentwise negative absolute value of a long2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 nabs(long2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(-x, x, Operator.greater_mask_long(default(v128), x));
            }
            else
            {
                return new long2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a long3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 nabs(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(-x, x, Avx2.mm256_cmpgt_epi64(default(v256), x));
            }
            else
            {
                return new long3(abs(x.xy), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a long4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 nabs(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(-x, x, Avx2.mm256_cmpgt_epi64(default(v256), x));
            }
            else
            {
                return new long4(abs(x.xy), nabs(x.zw));
            }
        }


        /// <summary>       Returns the negative absolute value of a quarter value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter nabs(quarter x)
        {
            return asquarter((byte)(asbyte(x) | 0b1000_0000));
        }

        /// <summary>       Returns the componentwise negative absolute value of a quarter2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 nabs(quarter2 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a quarter3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 nabs(quarter3 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }
        
        /// <summary>       Returns the componentwise negative absolute value of a quarter4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 nabs(quarter4 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }
        
        /// <summary>       Returns the componentwise negative absolute value of a quarter8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 nabs(quarter8 x)
        {
            return asquarter(asbyte(x) | 0b1000_0000);
        }


        /// <summary>       Returns the negative absolute value of a half value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half nabs(half x)
        {
            return new half { value = ((ushort)(x.value | 0x8000)) };
        }

        /// <summary>       Returns the componentwise negative absolute value of a half2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 nabs(half2 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a half3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 nabs(half3 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a half4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 nabs(half4 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }

        /// <summary>       Returns the componentwise negative absolute value of a half8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 nabs(half8 x)
        {
            return ashalf(asushort(x) | 0x8000);
        }


        /// <summary>       Returns the negative absolute value of a float value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float nabs(float x)
        {
            return math.asfloat(math.asint(x) | (1 << 31));
        }

        /// <summary>       Returns the componentwise negative absolute value of a float2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 nabs(float2 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 _nabs = Sse.or_ps(*(v128*)&x, new v128(1 << 31));

                return *(float2*)&_nabs;
            }
            else
            {
                return new float2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a float3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 nabs(float3 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 _nabs = Sse.or_ps(*(v128*)&x, new v128(1 << 31));

                return *(float3*)&_nabs;
            }
            else
            {
                return new float3(nabs(x.x), nabs(x.y), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a float4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 nabs(float4 x)
        {
            if (Sse.IsSseSupported)
            {
                v128 _nabs = Sse.or_ps(*(v128*)&x, new v128(1 << 31));

                return *(float4*)&_nabs;
            }
            else
            {
                return new float4(nabs(x.x), nabs(x.y), nabs(x.z), nabs(x.w));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a float8 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 nabs(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_or_ps(x, new v256(1 << 31));
            }
            else
            {
                return new float8(nabs(x.v4_0), nabs(x.v4_4));
            }
        }


        /// <summary>       Returns the negative absolute value of a double value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double nabs(double x)
        {
            return math.asdouble(math.aslong(x) | (1L << 63));
        }

        /// <summary>       Returns the componentwise negative absolute value of a double2 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 nabs(double2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _nabs = Sse2.or_pd(*(v128*)&x, new v128(1L << 63));

                return *(double2*)&_nabs;
            }
            else
            {
                return new double2(nabs(x.x), nabs(x.y));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a double3 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 nabs(double3 x)
        {
            if (Avx.IsAvxSupported)
            {
                v256 _nabs = Avx.mm256_or_pd(*(v256*)&x, new v256(1L << 63));

                return *(double3*)&_nabs;
            }
            else
            {
                return new double3(nabs(x.xy), nabs(x.z));
            }
        }

        /// <summary>       Returns the componentwise negative absolute value of a double4 vector.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 nabs(double4 x)
        {
            if (Avx.IsAvxSupported)
            {
                v256 _nabs = Avx.mm256_or_pd(*(v256*)&x, new v256(1L << 63));

                return *(double4*)&_nabs;
            }
            else
            {
                return new double4(nabs(x.xy), nabs(x.zw));
            }
        }
    }
}