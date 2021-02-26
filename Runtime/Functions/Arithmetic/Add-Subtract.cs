using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two float2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 addsub(float2 a, float2 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return a + math.select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two float3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 addsub(float3 a, float3 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return a + math.select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two float4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 addsub(float4 a, float4 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return a + math.select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two float8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 addsub(float8 a, float8 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return new float8(addsub(a.v4_0, b.v4_0), addsub(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two double2 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 addsub(double2 a, double2 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return a + math.select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two double3 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 addsub(double3 a, double3 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return a + math.select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two double4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 addsub(double4 a, double4 b)
        {
            if (Fma.IsFmaSupported)
            {
                return madsub(1f, a, b);
            }
            else
            {
                return a + math.select(b, -b, new bool4(false, true, false, true));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two byte2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 addsub(byte2 a, byte2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte2(1, 255));
            }
            else
            {
                return a + select(b, (byte2)(-(sbyte2)b), new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two byte3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 addsub(byte3 a, byte3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(1, 255, 1, 255));
            }
            else
            {
                return a + select(b, (byte3)(-(sbyte3)b), new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two byte4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 addsub(byte4 a, byte4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(1, 255, 1, 255));
            }
            else
            {
                return a + select(b, (byte4)(-(sbyte4)b), new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two byte8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 addsub(byte8 a, byte8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte8(1, 255, 1, 255, 1, 255, 1, 255));
            }
            else
            {
                return a + select(b, (byte8)(-(sbyte8)b), new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two byte16 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 addsub(byte16 a, byte16 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new v128(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255));
            }
            else
            {
                return a + select(b, (byte16)(-(sbyte16)b), new bool16(false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two byte32 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 addsub(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi8(b, new v256(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255));
            }
            else
            {
                return new byte32(addsub(a.v16_0, b.v16_0), addsub(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two sbyte2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 addsub(sbyte2 a, sbyte2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte2(1, 255));
            }
            else
            {
                return a + select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two sbyte3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 addsub(sbyte3 a, sbyte3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(1, 255, 1, 255));
            }
            else
            {
                return a + select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two sbyte4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 addsub(sbyte4 a, sbyte4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(1, 255, 1, 255));
            }
            else
            {
                return a + select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two sbyte8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 addsub(sbyte8 a, sbyte8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte8(1, 255, 1, 255, 1, 255, 1, 255));
            }
            else
            {
                return a + select(b, -b, new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two sbyte16 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 addsub(sbyte16 a, sbyte16 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new v128(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255));
            }
            else
            {
                return a + select(b, -b, new bool16(false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two sbyte32 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 addsub(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi8(b, new v256(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255));
            }
            else
            {
                return new sbyte32(addsub(a.v16_0, b.v16_0), addsub(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ushort2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 addsub(ushort2 a, ushort2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort2(1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, (ushort2)(-(short2)b), new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ushort3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 addsub(ushort3 a, ushort3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, (ushort3)(-(short3)b), new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ushort4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 addsub(ushort4 a, ushort4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, (ushort4)(-(short4)b), new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ushort8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 addsub(ushort8 a, ushort8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort8(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, (ushort8)(-(short8)b), new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ushort16 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 addsub(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi16(b, new v256(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return new ushort16(addsub(a.v8_0, b.v8_0), addsub(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two short2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 addsub(short2 a, short2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort2(1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two short3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 addsub(short3 a, short3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two short4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 addsub(short4 a, short4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two short8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 addsub(short8 a, short8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort8(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return a + select(b, -b, new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two short16 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 addsub(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi16(b, new v256(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue));
            }
            else
            {
                return new short16(addsub(a.v8_0, b.v8_0), addsub(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two uint2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 addsub(uint2 a, uint2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(*(v128*)&b, new v128(1, uint.MaxValue, uint.MaxValue, uint.MaxValue));

                return a + *(uint2*)&temp;
            }
            else
            {
                return a + math.select(b, (uint2)(-(int2)b), new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two uint3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 addsub(uint3 a, uint3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(*(v128*)&b, new v128(1, uint.MaxValue, 1, uint.MaxValue));

                return a + *(uint3*)&temp;
            }
            else
            {
                return a + math.select(b, (uint3)(-(int3)b), new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two uint4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 addsub(uint4 a, uint4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(*(v128*)&b, new v128(1, uint.MaxValue, 1, uint.MaxValue));

                return a + *(uint4*)&temp;
            }
            else
            {
                return a + math.select(b, (uint4)(-(int4)b), new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two uint8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 addsub(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi32(b, new uint8(1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue));
            }
            else
            {
                return new uint8(addsub(a.v4_0, b.v4_0), addsub(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two int2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 addsub(int2 a, int2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(*(v128*)&b, new v128(1, uint.MaxValue, 0, 0));

                return a + *(int2*)&temp;
            }
            else
            {
                return a + math.select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two int3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 addsub(int3 a, int3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(*(v128*)&b, new v128(1, uint.MaxValue, 1, uint.MaxValue));

                return a + *(int3*)&temp;
            }
            else
            {
                return a + math.select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two int4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 addsub(int4 a, int4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(*(v128*)&b, new v128(1, uint.MaxValue, 1, uint.MaxValue));

                return a + *(int4*)&temp;
            }
            else
            {
                return a + math.select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two int8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 addsub(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi32(b, new uint8(1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue));
            }
            else
            {
                return new int8(addsub(a.v4_0, b.v4_0), addsub(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ulong2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 addsub(ulong2 a, ulong2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return a + Sse4_1.blend_epi16(b, default(v128) - b, 0b1111_0000);
                }
                else
                {
                    return a + Mask.BlendEpi16_SSE2(b, default(v128) - b, 0b1111_0000);
                }
            }
            else
            {
                return new ulong2(a.x + b.x, a.y - b.y);
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ulong3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 addsub(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, default(v256) - b, 0b1111_0000);
            }
            else
            {
                return new ulong3(addsub(a.xy, b.xy), a.z + b.z);
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two ulong4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 addsub(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, default(v256) - b, 0b1111_0000);
            }
            else
            {
                return new ulong4(addsub(a.xy, b.xy), addsub(a.zw, b.zw));
            }
        }


        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two long2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 addsub(long2 a, long2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return a + Sse4_1.blend_epi16(b, -b, 0b1111_0000);
                }
                else
                {
                    return a + Mask.BlendEpi16_SSE2(b, -b, 0b1111_0000);
                }
            }
            else
            {
                return new long2(a.x + b.x, a.y - b.y);
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two long3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 addsub(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, -b, 0b1111_0000);
            }
            else
            {
                return new long3(addsub(a.xy, b.xy), a.z + b.z);
            }
        }

        /// <summary>       Adds even indexed and subtracts odd indexed components (zero based) of two long4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 addsub(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, -b, 0b1111_0000);
            }
            else
            {
                return new long4(addsub(a.xy, b.xy), addsub(a.zw, b.zw));
            }
        }
    }
}