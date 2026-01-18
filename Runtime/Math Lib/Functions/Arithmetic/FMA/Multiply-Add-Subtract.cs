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
            public static v128 fmsubadd_epi8(v128 a, v128 b, v128 c, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ab = mullo_epi8(a, b, elements);
                    v128 negC;

                    if (elements > 2)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            negC = sign_epi8(c, new v128(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255));
                        }
                        else
                        {
                            negC = neg_epi8(c);
                            negC = blendv_si128(c, negC, new v128(0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255));
                        }
                    }
                    else
                    {
                        negC = neg_epi8(c);
                        negC = unpacklo_epi8(c, bsrli_si128(negC, sizeof(sbyte)));
                    }

                    return add_epi8(ab, negC);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_fmsubadd_epi8(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ab = mm256_mullo_epi8(a, b);
                    v256 negC = Avx2.mm256_sign_epi8(c, new v256(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255));

                    return Avx2.mm256_add_epi8(ab, negC);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 fmsubadd_epi16(v128 a, v128 b, v128 c, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ab = mullo_epi16(a, b);
                    v128 negC;

                    if (Ssse3.IsSsse3Supported)
                    {
                        negC = sign_epi16(c, new v128(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue));
                    }
                    else
                    {
                        negC = neg_epi16(c);

                        if (BurstArchitecture.IsBlendSupported)
                        {
                            negC = blend_epi16(c, negC, 0b1010_1010);
                        }
                        else if (elements > 2)
                        {
                            negC = blendv_si128(c, negC, new v128(0, ushort.MaxValue, 0, ushort.MaxValue, 0, ushort.MaxValue, 0, ushort.MaxValue));
                        }
                        else
                        {
                            negC = unpacklo_epi16(c, bsrli_si128(negC, sizeof(ushort)));
                        }
                    }

                    return add_epi16(ab, negC);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_fmsubadd_epi16(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ab = Avx2.mm256_mullo_epi16(a, b);
                    v256 negC = Avx2.mm256_sign_epi16(c, new v256(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue));
                    return Avx2.mm256_add_epi16(ab, negC);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 fmsubadd_epi32(v128 a, v128 b, v128 c, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ab = mullo_epi32(a, b, elements);
                    v128 negC;

                    if (Ssse3.IsSsse3Supported)
                    {
                        negC = sign_epi32(c, new v128(1, uint.MaxValue, 1, uint.MaxValue));
                    }
                    else
                    {
                        negC = neg_epi32(c);

                        if (BurstArchitecture.IsBlendSupported)
                        {
                            negC = blend_epi16(c, negC, 0b1100_1100);
                        }
                        if (elements > 2)
                        {
                            negC = blendv_si128(c, negC, new v128(0, uint.MaxValue, 0, uint.MaxValue));
                        }
                        else
                        {
                            negC = unpacklo_epi32(c, bsrli_si128(negC, sizeof(uint)));
                        }
                    }

                    return add_epi32(ab, negC);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_fmsubadd_epi32(v256 a, v256 b, v256 c)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ab = Avx2.mm256_mullo_epi32(a, b);
                    v256 negC = Avx2.mm256_sign_epi32(c, new v256(1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue));
                    return Avx2.mm256_add_epi32(ab, negC);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 fmsubadd_epi64(v128 a, v128 b, v128 c)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ab = mullo_epi64(a, b);
                    v128 neg = neg_epi64(c);

                    if (BurstArchitecture.IsBlendSupported)
                    {
                        neg = blend_epi16(c, neg, 0b1111_0000);
                    }
                    else
                    {
                        neg = unpacklo_epi64(c, bsrli_si128(neg, sizeof(long)));
                    }

                    return add_epi64(ab, neg);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_fmsubadd_epi64(v256 a, v256 b, v256 c, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ab = mm256_mullo_epi64(a, b, elements);

                    v256 negC = mm256_neg_epi64(c);
                    negC = Avx2.mm256_blend_epi32(c, negC, 0b1100_1100);

                    return Avx2.mm256_add_epi64(ab, negC);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on 3 <see cref="float2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 madsub(float2 a, float2 b, float2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.fmsubadd_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return addsub(a * b, c);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on 3 <see cref="float3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 madsub(float3 a, float3 b, float3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.fmsubadd_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return addsub(a * b, c);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on 3 <see cref="float4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 madsub(float4 a, float4 b, float4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.fmsubadd_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return addsub(a * b, c);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on 3 <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 madsub(float8 a, float8 b, float8 c)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_fmsubadd_ps(a, b, c);
            }
            else
            {
                return new float8(madsub(a.v4_0, b.v4_0, c.v4_0), madsub(a.v4_4, b.v4_4, c.v4_4));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on 3 <see cref="double2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 madsub(double2 a, double2 b, double2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.fmsubadd_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c)));
            }
            else
            {
                return addsub(a * b, c);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on 3 <see cref="double3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 madsub(double3 a, double3 b, double3 c)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_fmsubadd_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), RegisterConversion.ToV256(c)));
            }
            else
            {
                return new double3(madsub(a.xy, b.xy, c.xy), a.z * b.z + c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/ <paramref name="c"/>) on 3 <see cref="double4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 madsub(double4 a, double4 b, double4 c)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_fmsubadd_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), RegisterConversion.ToV256(c)));
            }
            else
            {
                return new double4(madsub(a.xy, b.xy, c.xy), madsub(a.zw, b.zw, c.zw));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.byte2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 madsub(byte2 a, byte2 b, byte2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi8(a, b, c, 2);
            }
            else
            {
                return new byte2((byte)(a.x * b.x + c.x), (byte)(a.y * b.y - c.y));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="MaxMath.byte3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 madsub(byte3 a, byte3 b, byte3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi8(a, b, c, 3);
            }
            else
            {
                return new byte3((byte)(a.x * b.x + c.x), (byte)(a.y * b.y - c.y), (byte)(a.z * b.z + c.z));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.byte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 madsub(byte4 a, byte4 b, byte4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi8(a, b, c, 4);
            }
            else
            {
                return new byte4((byte)(a.x * b.x + c.x), (byte)(a.y * b.y - c.y), (byte)(a.z * b.z + c.z), (byte)(a.w * b.w - c.w));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.byte8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 madsub(byte8 a, byte8 b, byte8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi8(a, b, c, 8);
            }
            else
            {
                return new byte8((byte)(a.x0 * b.x0 + c.x0), (byte)(a.x1 * b.x1 - c.x1), (byte)(a.x2 * b.x2 + c.x2), (byte)(a.x3 * b.x3 - c.x3), (byte)(a.x4 * b.x4 + c.x4), (byte)(a.x5 * b.x5 - c.x5), (byte)(a.x6 * b.x6 + c.x6), (byte)(a.x7 * b.x7 - c.x7));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.byte16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 madsub(byte16 a, byte16 b, byte16 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi8(a, b, c, 16);
            }
            else
            {
                return new byte16((byte)(a.x0 * b.x0 + c.x0), (byte)(a.x1 * b.x1 - c.x1), (byte)(a.x2 * b.x2 + c.x2), (byte)(a.x3 * b.x3 - c.x3), (byte)(a.x4 * b.x4 + c.x4), (byte)(a.x5 * b.x5 - c.x5), (byte)(a.x6 * b.x6 + c.x6), (byte)(a.x7 * b.x7 - c.x7), (byte)(a.x8 * b.x8 + c.x8), (byte)(a.x9 * b.x9 - c.x9), (byte)(a.x10 * b.x10 + c.x10), (byte)(a.x11 * b.x11 - c.x11), (byte)(a.x12 * b.x12 + c.x12), (byte)(a.x13 * b.x13 - c.x13), (byte)(a.x14 * b.x14 + c.x14), (byte)(a.x15 * b.x15 - c.x15));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.byte32"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 madsub(byte32 a, byte32 b, byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_fmsubadd_epi8(a, b, c);
            }
            else
            {
                return new byte32(madsub(a.v16_0, b.v16_0, c.v16_0), madsub(a.v16_16, b.v16_16, c.v16_16));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.sbyte2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 madsub(sbyte2 a, sbyte2 b, sbyte2 c)
        {
            return (sbyte2)madsub((byte2)a, (byte2)b, (byte2)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="MaxMath.sbyte3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 madsub(sbyte3 a, sbyte3 b, sbyte3 c)
        {
            return (sbyte3)madsub((byte3)a, (byte3)b, (byte3)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.sbyte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 madsub(sbyte4 a, sbyte4 b, sbyte4 c)
        {
            return (sbyte4)madsub((byte4)a, (byte4)b, (byte4)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.sbyte8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 madsub(sbyte8 a, sbyte8 b, sbyte8 c)
        {
            return (sbyte8)madsub((byte8)a, (byte8)b, (byte8)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.sbyte16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 madsub(sbyte16 a, sbyte16 b, sbyte16 c)
        {
            return (sbyte16)madsub((byte16)a, (byte16)b, (byte16)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.sbyte32"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 madsub(sbyte32 a, sbyte32 b, sbyte32 c)
        {
            return (sbyte32)madsub((byte32)a, (byte32)b, (byte32)c);
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.ushort2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 madsub(ushort2 a, ushort2 b, ushort2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi16(a, b, c, 2);
            }
            else
            {
                return new ushort2((ushort)(a.x * b.x + c.x), (ushort)(a.y * b.y - c.y));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="MaxMath.ushort3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 madsub(ushort3 a, ushort3 b, ushort3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi16(a, b, c, 3);
            }
            else
            {
                return new ushort3((ushort)(a.x * b.x + c.x), (ushort)(a.y * b.y - c.y), (ushort)(a.z * b.z + c.z));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.ushort4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 madsub(ushort4 a, ushort4 b, ushort4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi16(a, b, c, 4);
            }
            else
            {
                return new ushort4((ushort)(a.x * b.x + c.x), (ushort)(a.y * b.y - c.y), (ushort)(a.z * b.z + c.z), (ushort)(a.w * b.w - c.w));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.ushort8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 madsub(ushort8 a, ushort8 b, ushort8 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi16(a, b, c, 8);
            }
            else
            {
                return new ushort8((ushort)(a.x0 * b.x0 + c.x0), (ushort)(a.x1 * b.x1 - c.x1), (ushort)(a.x2 * b.x2 + c.x2), (ushort)(a.x3 * b.x3 - c.x3), (ushort)(a.x4 * b.x4 + c.x4), (ushort)(a.x5 * b.x5 - c.x5), (ushort)(a.x6 * b.x6 + c.x6), (ushort)(a.x7 * b.x7 - c.x7));
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.ushort16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 madsub(ushort16 a, ushort16 b, ushort16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_fmsubadd_epi16(a, b, c);
            }
            else
            {
                return new ushort16(madsub(a.v8_0, b.v8_0, c.v8_0), madsub(a.v8_8, b.v8_8, c.v8_8));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.short2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 madsub(short2 a, short2 b, short2 c)
        {
            return (short2)madsub((ushort2)a, (ushort2)b, (ushort2)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="MaxMath.short3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 madsub(short3 a, short3 b, short3 c)
        {
            return (short3)madsub((ushort3)a, (ushort3)b, (ushort3)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.short4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 madsub(short4 a, short4 b, short4 c)
        {
            return (short4)madsub((ushort4)a, (ushort4)b, (ushort4)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.short8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 madsub(short8 a, short8 b, short8 c)
        {
            return (short8)madsub((ushort8)a, (ushort8)b, (ushort8)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.short16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 madsub(short16 a, short16 b, short16 c)
        {
            return (short16)madsub((ushort16)a, (ushort16)b, (ushort16)c);
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="uint2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 madsub(uint2 a, uint2 b, uint2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.fmsubadd_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c), 2));
            }
            else
            {
                return new uint2(a.x * b.x + c.x, a.y * b.y - c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="uint3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 madsub(uint3 a, uint3 b, uint3 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.fmsubadd_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c), 3));
            }
            else
            {
                return new uint3(a.x * b.x + c.x, a.y * b.y - c.y, a.z * b.z + c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="uint4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 madsub(uint4 a, uint4 b, uint4 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.fmsubadd_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(c), 4));
            }
            else
            {
                return new uint4(a.x * b.x + c.x, a.y * b.y - c.y, a.z * b.z + c.z, a.w * b.w - c.w);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.uint8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 madsub(uint8 a, uint8 b, uint8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_fmsubadd_epi32(a, b, c);
            }
            else
            {
                return new uint8(madsub(a.v4_0, b.v4_0, c.v4_0), madsub(a.v4_4, b.v4_4, c.v4_4));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="int2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 madsub(int2 a, int2 b, int2 c)
        {
            return (int2)madsub((uint2)a, (uint2)b, (uint2)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="int3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 madsub(int3 a, int3 b, int3 c)
        {
            return (int3)madsub((uint3)a, (uint3)b, (uint3)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="int4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 madsub(int4 a, int4 b, int4 c)
        {
            return (int4)madsub((uint4)a, (uint4)b, (uint4)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.int8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 madsub(int8 a, int8 b, int8 c)
        {
            return (int8)madsub((uint8)a, (uint8)b, (uint8)c);
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.ulong2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 madsub(ulong2 a, ulong2 b, ulong2 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.fmsubadd_epi64(a, b, c);
            }
            else
            {
                return new ulong2(a.x * b.x + c.x, a.y * b.y - c.y);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="MaxMath.ulong3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 madsub(ulong3 a, ulong3 b, ulong3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_fmsubadd_epi64(a, b, c, 3);
            }
            else
            {
                return new ulong3(madsub(a.xy, b.xy, c.xy), a.z * b.z + c.z);
            }
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 madsub(ulong4 a, ulong4 b, ulong4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_fmsubadd_epi64(a, b, c, 4);
            }
            else
            {
                return new ulong4(madsub(a.xy, b.xy, c.xy), madsub(a.zw, b.zw, c.zw));
            }
        }


        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.long2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 madsub(long2 a, long2 b, long2 c)
        {
            return (long2)madsub((ulong2)a, (ulong2)b, (ulong2)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="c"/>) on two <see cref="MaxMath.long3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 madsub(long3 a, long3 b, long3 c)
        {
            return (long3)madsub((ulong3)a, (ulong3)b, (ulong3)c);
        }

        /// <summary>       Returns the result of a componentwise multiply-add/subtract operation (<paramref name="a"/> <see langword="*"/> <paramref name="b"/> <see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="c"/>) on two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 madsub(long4 a, long4 b, long4 c)
        {
            return (long4)madsub((ulong4)a, (ulong4)b, (ulong4)c);
        }
    }
}