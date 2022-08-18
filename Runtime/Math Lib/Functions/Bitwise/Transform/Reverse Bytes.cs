using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bswap_epi16(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(a, new v128(1, 0,   3, 2,   5, 4,   7, 6,   9, 8,   11, 10,   13, 12,   15, 14));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return rol_epi16(a, 8);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bswap_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_shuffle_epi8(a, new v256(1, 0,   3, 2,   5, 4,   7, 6,   9, 8,   11, 10,   13, 12,   15, 14,
                                                               1, 0,   3, 2,   5, 4,   7, 6,   9, 8,   11, 10,   13, 12,   15, 14));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bswap_epi32(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(a, new v128(3, 2, 1, 0,   7, 6, 5, 4,   11, 10, 9, 8,   15, 14, 13, 12));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return rol_epi32(bswap_epi16(a), 16);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bswap_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_shuffle_epi8(a, new v256(3, 2, 1, 0,   7, 6, 5, 4,   11, 10, 9, 8,   15, 14, 13, 12,
                                                               3, 2, 1, 0,   7, 6, 5, 4,   11, 10, 9, 8,   15, 14, 13, 12));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bswap_epi64(v128 a)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(a, new v128(7, 6, 5, 4, 3, 2, 1, 0,   15, 14, 13, 12, 11, 10, 9, 8));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return rol_epi64(bswap_epi32(a), 32);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bswap_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_shuffle_epi8(a, new v256(7, 6, 5, 4, 3, 2, 1, 0,   15, 14, 13, 12, 11, 10, 9, 8,
                                                               7, 6, 5, 4, 3, 2, 1, 0,   15, 14, 13, 12, 11, 10, 9, 8));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="UInt128"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 reversebytes(UInt128 x)
        {
            return new UInt128(reversebytes(x.hi64), reversebytes(x.lo64)); 
        }

        ///<summary>        Returns the result of performing a reversal of the byte order of an <see cref="Int128"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 reversebytes(Int128 x)
        {
            return new Int128(reversebytes(x.hi64), reversebytes(x.lo64)); 
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="ushort"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort reversebytes(ushort x)
        {
            return rol(x, 8);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ushort2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 reversebytes(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bswap_epi16(x);
            }
            else
            {
                return new ushort2(reversebytes(x.x), reversebytes(x.y));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ushort3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 reversebytes(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bswap_epi16(x);
            }
            else
            {
                return new ushort3(reversebytes(x.x), reversebytes(x.y), reversebytes(x.z));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ushort4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 reversebytes(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bswap_epi16(x);
            }
            else
            {
                return new ushort4(reversebytes(x.x), reversebytes(x.y), reversebytes(x.z), reversebytes(x.w));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ushort8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 reversebytes(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bswap_epi16(x);
            }
            else
            {
                return new ushort8(reversebytes(x.x0), reversebytes(x.x1), reversebytes(x.x2), reversebytes(x.x3), reversebytes(x.x4), reversebytes(x.x5), reversebytes(x.x6), reversebytes(x.x7));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ushort16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 reversebytes(ushort16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.mm256_bswap_epi16(x);
            }
            else
            {
                return new ushort16(reversebytes(x.v8_0), reversebytes(x.v8_8));
            }
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="uint"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint reversebytes(uint x)
        {
            // compiles to bswap
            uint byte0 = x & 0x0000_00FF;
            uint byte1 = x & 0x0000_FF00;
            uint byte2 = x & 0x00FF_0000;
            uint byte3 = x & 0xFF00_0000;

            return (byte0 << 24) | (byte1 << 8) | (byte2 >> 8) | (byte3 >> 24);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="uint2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 reversebytes(uint2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.bswap_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint2(reversebytes(x.x), reversebytes(x.y));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="uint3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 reversebytes(uint3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.bswap_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint3(reversebytes(x.x), reversebytes(x.y), reversebytes(x.z));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="uint4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 reversebytes(uint4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.bswap_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new uint4(reversebytes(x.x), reversebytes(x.y), reversebytes(x.z), reversebytes(x.w));
            }
        }

        
        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 reversebytes(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bswap_epi32(x);
            }
            else
            {
                return new uint8(reversebytes(x.v4_0), reversebytes(x.v4_4));
            }
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="ulong"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong reversebytes(ulong x)
        {
            // compiles to bswap
            ulong byte0 = x & 0x0000_0000_0000_00FF;
            ulong byte1 = x & 0x0000_0000_0000_FF00;
            ulong byte2 = x & 0x0000_0000_00FF_0000;
            ulong byte3 = x & 0x0000_0000_FF00_0000;
            ulong byte4 = x & 0x0000_00FF_0000_0000;
            ulong byte5 = x & 0x0000_FF00_0000_0000;
            ulong byte6 = x & 0x00FF_0000_0000_0000;
            ulong byte7 = x & 0xFF00_0000_0000_0000;
            
            return (byte0 << 56) | (byte1 << 40) | (byte2 << 24) | (byte3 << 8) | (byte4 >> 8) | (byte5 >> 24) | (byte6 >> 40) | (byte7 >> 56);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 reversebytes(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.bswap_epi64(x);
            }
            else
            {
                return new ulong2(reversebytes(x.x), reversebytes(x.y));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 reversebytes(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bswap_epi64(x);
            }
            else
            {
                return new ulong3(reversebytes(x.xy), reversebytes(x.z));
            }
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 reversebytes(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bswap_epi64(x);
            }
            else
            {
                return new ulong4(reversebytes(x.xy), reversebytes(x.zw));
            }
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="short"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short reversebytes(short x)
        {
            return (short)reversebytes((ushort)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.short2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 reversebytes(short2 x)
        {
            return (short2)reversebytes((ushort2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.short3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 reversebytes(short3 x)
        {
            return (short3)reversebytes((ushort3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.short4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 reversebytes(short4 x)
        {
            return (short4)reversebytes((ushort4)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.short8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 reversebytes(short8 x)
        {
            return (short8)reversebytes((ushort8)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.short16"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 reversebytes(short16 x)
        {
            return (short16)reversebytes((ushort16)x);
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of an <see cref="int"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int reversebytes(int x)
        {
            return (int)reversebytes((uint)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of an <see cref="int2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 reversebytes(int2 x)
        {
            return (int2)reversebytes((uint2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of an <see cref="int3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 reversebytes(int3 x)
        {
            return (int3)reversebytes((uint3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of an <see cref="int4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 reversebytes(int4 x)
        {
            return (int4)reversebytes((uint4)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of an <see cref="MaxMath.int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 reversebytes(int8 x)
        {
            return (int8)reversebytes((uint8)x);
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="long"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long reversebytes(long x)
        {
            return (long)reversebytes((ulong)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 reversebytes(long2 x)
        {
            return (long2)reversebytes((ulong2)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 reversebytes(long3 x)
        {
            return (long3)reversebytes((ulong3)x);
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 reversebytes(long4 x)
        {
            return (long4)reversebytes((ulong4)x);
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="half"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half reversebytes(half x)
        {
            return ashalf(reversebytes(asushort(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="half2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 reversebytes(half2 x)
        {
            return ashalf(reversebytes(asushort(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="half3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 reversebytes(half3 x)
        {
            return ashalf(reversebytes(asushort(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="half4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 reversebytes(half4 x)
        {
            return ashalf(reversebytes(asushort(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.half8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 reversebytes(half8 x)
        {
            return ashalf(reversebytes(asushort(x)));
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float reversebytes(float x)
        {
            return math.asfloat(reversebytes(math.asuint(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 reversebytes(float2 x)
        {
            return math.asfloat(reversebytes(math.asuint(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 reversebytes(float3 x)
        {
            return math.asfloat(reversebytes(math.asuint(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 reversebytes(float4 x)
        {
            return math.asfloat(reversebytes(math.asuint(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 reversebytes(float8 x)
        {
            return asfloat(reversebytes(asuint(x)));
        }


        ///<summary>        Returns the result of performing a reversal of the byte order of a <see cref="double"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double reversebytes(double x)
        {
            return math.asdouble(reversebytes(math.asulong(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 reversebytes(double2 x)
        {
            return asdouble(reversebytes(asulong(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 reversebytes(double3 x)
        {
            return asdouble(reversebytes(asulong(x)));
        }

        /// <summary>       Returns the result of performing a componentwise reversal of the byte order of a <see cref="double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 reversebytes(double4 x)
        {
            return asdouble(reversebytes(asulong(x)));
        }
    }
}