using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="float2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 subadd(float2 a, float2 b)
        {
            if (Sse3.IsSse3Supported)
            {
                v128 temp = Sse3.addsub_ps(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b));

                return *(float2*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="float3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 subadd(float3 a, float3 b)
        {
            if (Sse3.IsSse3Supported)
            {
                v128 temp = Sse3.addsub_ps(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b));

                return *(float3*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="float4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 subadd(float4 a, float4 b)
        {
            if (Sse3.IsSse3Supported)
            {
                v128 temp = Sse3.addsub_ps(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b));

                return *(float4*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.float8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 subadd(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_addsub_ps(a, b);
            }
            else
            {
                return new float8(subadd(a.v4_0, b.v4_0), subadd(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="double2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 subadd(double2 a, double2 b)
        {
            if (Sse3.IsSse3Supported)
            {
                v128 temp = Sse3.addsub_pd(UnityMathematicsLink.Tov128(a), UnityMathematicsLink.Tov128(b));

                return *(double2*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="double3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 subadd(double3 a, double3 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 temp = Avx.mm256_addsub_pd(UnityMathematicsLink.Tov256(a), UnityMathematicsLink.Tov256(b));

                return *(double3*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="double4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 subadd(double4 a, double4 b)
        {
            if (Avx.IsAvxSupported)
            {
                v256 temp = Avx.mm256_addsub_pd(UnityMathematicsLink.Tov256(a), UnityMathematicsLink.Tov256(b));

                return *(double4*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool4(false, true, false, true));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.byte2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 subadd(byte2 a, byte2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte2(255, 1));
            }
            else
            {
                return a - select(b, (byte2)(-(sbyte2)b), new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.byte3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 subadd(byte3 a, byte3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(255, 1, 255, 1));
            }
            else
            {
                return a - select(b, (byte3)(-(sbyte3)b), new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.byte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 subadd(byte4 a, byte4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(255, 1, 255, 1));
            }
            else
            {
                return a - select(b, (byte4)(-(sbyte4)b), new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.byte8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 subadd(byte8 a, byte8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte8(255, 1, 255, 1, 255, 1, 255, 1));
            }
            else
            {
                return a - select(b, (byte8)(-(sbyte8)b), new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.byte16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 subadd(byte16 a, byte16 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new v128(255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1));
            }
            else
            {
                return a - select(b, (byte16)(-(sbyte16)b), new bool16(false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.byte32"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 subadd(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi8(b, new v256(255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1));
            }
            else
            {
                return new byte32(subadd(a.v16_0, b.v16_0), subadd(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.sbyte2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 subadd(sbyte2 a, sbyte2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte2(255, 1));
            }
            else
            {
                return a - select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.sbyte3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 subadd(sbyte3 a, sbyte3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(255, 1, 255, 1));
            }
            else
            {
                return a - select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.sbyte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 subadd(sbyte4 a, sbyte4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte4(255, 1, 255, 1));
            }
            else
            {
                return a - select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.sbyte8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 subadd(sbyte8 a, sbyte8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new byte8(255, 1, 255, 1, 255, 1, 255, 1));
            }
            else
            {
                return a - select(b, -b, new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.sbyte16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 subadd(sbyte16 a, sbyte16 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi8(b, new v128(255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1));
            }
            else
            {
                return a - select(b, -b, new bool16(false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.sbyte32"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 subadd(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi8(b, new v256(255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1));
            }
            else
            {
                return new sbyte32(subadd(a.v16_0, b.v16_0), subadd(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ushort2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 subadd(ushort2 a, ushort2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort2(ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, (ushort2)(-(short2)b), new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ushort3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 subadd(ushort3 a, ushort3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, (ushort3)(-(short3)b), new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ushort4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 subadd(ushort4 a, ushort4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, (ushort4)(-(short4)b), new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ushort8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 subadd(ushort8 a, ushort8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort8(ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, (ushort8)(-(short8)b), new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ushort16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 subadd(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi16(b, new v256(ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return new ushort16(subadd(a.v8_0, b.v8_0), subadd(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.short2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 subadd(short2 a, short2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort2(ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.short3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 subadd(short3 a, short3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.short4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 subadd(short4 a, short4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort4(ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.short8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 subadd(short8 a, short8 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return a + Ssse3.sign_epi16(b, new ushort8(ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return a - select(b, -b, new bool8(false, true, false, true, false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.short16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 subadd(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi16(b, new v256(ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1));
            }
            else
            {
                return new short16(subadd(a.v8_0, b.v8_0), subadd(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="uint2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 subadd(uint2 a, uint2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(UnityMathematicsLink.Tov128(b), new v128(uint.MaxValue, 1, 0, 0));

                return a + *(uint2*)&temp;
            }
            else
            {
                return a - math.select(b, (uint2)(-(int2)b), new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="uint3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 subadd(uint3 a, uint3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(UnityMathematicsLink.Tov128(b), new v128(uint.MaxValue, 1, uint.MaxValue, 1));

                return a + *(uint3*)&temp;
            }
            else
            {
                return a - math.select(b, (uint3)(-(int3)b), new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="uint4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 subadd(uint4 a, uint4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(UnityMathematicsLink.Tov128(b), new v128(uint.MaxValue, 1, uint.MaxValue, 1));

                return a + *(uint4*)&temp;
            }
            else
            {
                return a - math.select(b, (uint4)(-(int4)b), new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.uint8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 subadd(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi32(b, new uint8(uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1));
            }
            else
            {
                return new uint8(subadd(a.v4_0, b.v4_0), subadd(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="int2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 subadd(int2 a, int2 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(UnityMathematicsLink.Tov128(b), new v128(uint.MaxValue, 1, 0, 0));

                return a + *(int2*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool2(false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="int3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 subadd(int3 a, int3 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(UnityMathematicsLink.Tov128(b), new v128(uint.MaxValue, 1, uint.MaxValue, 1));

                return a + *(int3*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool3(false, true, false));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="int4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 subadd(int4 a, int4 b)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 temp = Ssse3.sign_epi32(UnityMathematicsLink.Tov128(b), new v128(uint.MaxValue, 1, uint.MaxValue, 1));

                return a + *(int4*)&temp;
            }
            else
            {
                return a - math.select(b, -b, new bool4(false, true, false, true));
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.int8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 subadd(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_sign_epi32(b, new uint8(uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1));
            }
            else
            {
                return new int8(subadd(a.v4_0, b.v4_0), subadd(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ulong2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 subadd(ulong2 a, ulong2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return a + Sse4_1.blend_epi16(b, default(v128) - b, 0b0000_1111);
                }
                else
                {
                    return a + Mask.BlendEpi16_SSE2(b, default(v128) - b, 0b0000_1111);
                }
            }
            else
            {
                return new ulong2(a.x - b.x, a.y + b.y);
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ulong3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 subadd(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, default(v256) - b, 0b0000_1111);
            }
            else
            {
                return new ulong3(subadd(a.xy, b.xy), a.z - b.z);
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 subadd(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, default(v256) - b, 0b0000_1111);
            }
            else
            {
                return new ulong4(subadd(a.xy, b.xy), subadd(a.zw, b.zw));
            }
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.long2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 subadd(long2 a, long2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return a + Sse4_1.blend_epi16(b, -b, 0b0000_1111);
                }
                else
                {
                    return a + Mask.BlendEpi16_SSE2(b, -b, 0b0000_1111);
                }
            }
            else
            {
                return new long2(a.x - b.x, a.y + b.y);
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.long3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 subadd(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, -b, 0b0000_1111);
            }
            else
            {
                return new long3(subadd(a.xy, b.xy), a.z - b.z);
            }
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 subadd(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return a + Avx2.mm256_blend_epi16(b, -b, 0b0000_1111);
            }
            else
            {
                return new long4(subadd(a.xy, b.xy), subadd(a.zw, b.zw));
            }
        }
    }
}