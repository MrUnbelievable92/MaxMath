using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Reverses the element order of a <see cref="MaxMath.byte2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 reverse(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.yx;
            }
            else
            {
                ushort res = rol(*(ushort*)&x, 8 * sizeof(byte));
                return *(byte2*)&res;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.byte3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 reverse(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.zyx;
            }
            else
            {
                byte t = x.x;
                x.x = x.z;
                x.z = t;

                return x;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.byte4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 reverse(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.wzyx;
            }
            else
            {
                int bswap = reversebytes(*(int*)&x);

                return *(byte4*)&bswap;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.byte8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 reverse(byte8 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.shuffle_epi8(x, Xse.cvtsi64x_si128((long)bitfield(7, 6, 5, 4, 3, 2, 1, (byte)0)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtsi64x_si128(reversebytes(Xse.cvtsi128_si64x(x)));
            }
            else
            {
                long bswap = reversebytes(*(long*)&x);

                return *(byte8*)&bswap;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.byte16"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 reverse(byte16 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.shuffle_epi8(x, new v128(15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long lo = reversebytes(Xse.cvtsi128_si64x(x));
                long hi = reversebytes(((v128)x).SLong1);
                return new v128(hi, lo);
            }
            else
            {
                UInt128 bswap = reversebytes(*(UInt128*)&x);

                return *(byte16*)&bswap;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.byte32"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 reverse(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0,
                                                        15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0));

                return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(1, 0, 3, 2));
            }
            else
            {
                return new byte32(reverse(x.v16_16), reverse(x.v16_0));
            }
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.sbyte2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 reverse(sbyte2 x)
        {
            return (sbyte2)reverse((byte2)x);
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.sbyte3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 reverse(sbyte3 x)
        {
            return (sbyte3)reverse((byte3)x);
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.sbyte4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 reverse(sbyte4 x)
        {
            return (sbyte4)reverse((byte4)x);
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.sbyte8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 reverse(sbyte8 x)
        {
            return (sbyte8)reverse((byte8)x);
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.sbyte16"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 reverse(sbyte16 x)
        {
            return (sbyte16)reverse((byte16)x);
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.sbyte32"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 reverse(sbyte32 x)
        {
            return (sbyte32)reverse((byte32)x);
        }


        /// <summary>       Reverses the element order of a <see cref="MaxMath.ushort2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 reverse(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.yx;
            }
            else
            {
                uint res = math.rol(*(uint*)&x, 8 * sizeof(ushort));
                return *(ushort2*)&res;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.ushort3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 reverse(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.zyx;
            }
            else
            {
                ushort t = x.x;
                x.x = x.z;
                x.z = t;

                return x;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.ushort4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 reverse(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.wzyx;
            }
            else
            {
                uint lo = math.rol(*(uint*)&x, 8 * sizeof(ushort));
                uint hi = math.rol(*((uint*)&x + 1), 8 * sizeof(ushort));

                *(uint*)&x = hi;
                *((uint*)&x + 1) = lo;

                return x;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.ushort8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 reverse(ushort8 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return Xse.shuffle_epi8(x, new v128(14, 15, 12, 13, 10, 11, 8, 9, 6, 7, 4, 5, 2, 3, 0, 1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                x = Xse.shufflelo_epi16(x, Sse.SHUFFLE(0, 1, 2, 3));
                x = Xse.shufflehi_epi16(x, Sse.SHUFFLE(0, 1, 2, 3));
                x = Xse.shuffle_epi32(x, Sse.SHUFFLE(1, 0, 3, 2));

                return x;
            }
            else
            {
                return new ushort8(reverse(x.v4_4), reverse(x.v4_0));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.ushort16"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 reverse(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(14, 15, 12, 13, 10, 11, 8, 9, 6, 7, 4, 5, 2, 3, 0, 1,
                                                        14, 15, 12, 13, 10, 11, 8, 9, 6, 7, 4, 5, 2, 3, 0, 1));

                return Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(1, 0, 3, 2));
            }
            else
            {
                return new ushort16(reverse(x.v8_8), reverse(x.v8_0));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.short2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 reverse(short2 x)
        {
            return (short2)reverse((ushort2)x);
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.short3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 reverse(short3 x)
        {
            return (short3)reverse((ushort3)x);
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.short4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 reverse(short4 x)
        {
            return (short4)reverse((ushort4)x);
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.short8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 reverse(short8 x)
        {
            return (short8)reverse((ushort8)x);
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.short16"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 reverse(short16 x)
        {
            return (short16)reverse((ushort16)x);
        }


        /// <summary>       Reverses the element order of a <see cref="uint2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 reverse(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.yx;
            }
            else
            {
                ulong res = math.rol(*(ulong*)&x, 8 * sizeof(uint));
                return *(uint2*)&res;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="uint3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 reverse(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.zyx;
            }
            else
            {
                uint t = x.x;
                x.x = x.z;
                x.z = t;

                return x;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="uint4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 reverse(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.wzyx;
            }
            else
            {
                ulong lo = math.rol(*(ulong*)&x, 8 * sizeof(uint));
                ulong hi = math.rol(*((ulong*)&x + 1), 8 * sizeof(uint));

                *(ulong*)&x = hi;
                *((ulong*)&x + 1) = lo;

                return x;
            }
        }

        /// <summary>       Reverses the element order of a <see cref="uint8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 reverse(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_permutevar8x32_epi32(x, new v256(7, 6, 5, 4, 3, 2, 1, 0));
            }
            else
            {
                return new uint8(reverse(x.v4_4), reverse(x.v4_0));
            }
        }

        /// <summary>       Reverses the element order of an <see cref="int2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 reverse(int2 x)
        {
            return (int2)reverse((uint2)x);
        }

        /// <summary>       Reverses the element order of an <see cref="int3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 reverse(int3 x)
        {
            return (int3)reverse((uint3)x);
        }

        /// <summary>       Reverses the element order of an <see cref="int4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 reverse(int4 x)
        {
            return (int4)reverse((uint4)x);
        }

        /// <summary>       Reverses the element order of an <see cref="MaxMath.int8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 reverse(int8 x)
        {
            return (int8)reverse((uint8)x);
        }


        /// <summary>       Reverses the element order of a <see cref="MaxMath.ulong2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 reverse(ulong2 x)
        {
            return x.yx;
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.ulong3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 reverse(ulong3 x)
        {
            return x.zyx;
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.ulong4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 reverse(ulong4 x)
        {
            return x.wzyx;
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.long2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 reverse(long2 x)
        {
            return x.yx;
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.long3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 reverse(long3 x)
        {
            return x.zyx;
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.long4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 reverse(long4 x)
        {
            return x.wzyx;
        }


        /// <summary>       Reverses the element order of a <see cref="MaxMath.quarter2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 reverse(quarter2 x)
        {
            return asquarter(reverse(asbyte(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.quarter3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 reverse(quarter3 x)
        {
            return asquarter(reverse(asbyte(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.quarter4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 reverse(quarter4 x)
        {
            return asquarter(reverse(asbyte(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.quarter8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 reverse(quarter8 x)
        {
            return asquarter(reverse(asbyte(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.quarter16"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 reverse(quarter16 x)
        {
            return asquarter(reverse(asbyte(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.quarter32"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 reverse(quarter32 x)
        {
            return asquarter(reverse(asbyte(x)));
        }


        /// <summary>       Reverses the element order of a <see cref="half2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 reverse(half2 x)
        {
            return ashalf(reverse(asushort(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="half3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 reverse(half3 x)
        {
            return ashalf(reverse(asushort(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="half4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 reverse(half4 x)
        {
            return ashalf(reverse(asushort(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.half8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 reverse(half8 x)
        {
            return ashalf(reverse(asushort(x)));
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.half16"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 reverse(half16 x)
        {
            return ashalf(reverse(asushort(x)));
        }


        /// <summary>       Reverses the element order of a <see cref="float2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 reverse(float2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.yx;
            }
            else
            {
                return math.asfloat(reverse(math.asuint(x)));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="float3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 reverse(float3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.zyx;
            }
            else
            {
                return math.asfloat(reverse(math.asuint(x)));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="float4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 reverse(float4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.wzyx;
            }
            else
            {
                return math.asfloat(reverse(math.asuint(x)));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="MaxMath.float8"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 reverse(float8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_permutevar8x32_ps(x, new v256(7, 6, 5, 4, 3, 2, 1, 0));
            }
            else
            {
                return new float8(reverse(x.v4_4), reverse(x.v4_0));
            }
        }


        /// <summary>       Reverses the element order of a <see cref="double2"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 reverse(double2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.yx;
            }
            else
            {
                return asdouble(reverse(asulong(x)));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="double3"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 reverse(double3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.zyx;
            }
            else
            {
                return asdouble(reverse(asulong(x)));
            }
        }

        /// <summary>       Reverses the element order of a <see cref="double4"/>.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 reverse(double4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return x.wzyx;
            }
            else
            {
                return asdouble(reverse(asulong(x)));
            }
        }
    }
}
