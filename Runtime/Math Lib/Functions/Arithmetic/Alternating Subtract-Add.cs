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
            public static v128 addsub_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return sub_epi8(a, sign_epi8(b, new v128(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 add = add_epi8(a, b);
                    v128 sub = sub_epi8(a, b);
                    
                    if (Architecture.IsBlendSupported)
                    {
                        return blendv_si128(sub, add, new v128(0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255));
                    }
                    else if (elements == 2)
                    {
                        add = bsrli_si128(add, sizeof(byte));
                        return unpacklo_epi8(sub, add);
                    }
                    else
                    {
                        return blendv_si128(sub, add, new v128(0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255, 0, 255));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_addsub_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_sub_epi8(a, Avx2.mm256_sign_epi8(b, new v256(1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255, 1, 255)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 addsub_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (Avx.IsAvxSupported) // This is only always as fast as the SSSE3 version with the VEX prefix
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return sub_epi16(a, sign_epi16(b, new ushort8(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue)));
                    }


                    v128 add = add_epi16(a, b);
                    v128 sub = sub_epi16(a, b);

                    return blend_epi16(sub, add, 0b1010_1010);
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return sub_epi16(a, sign_epi16(b, new ushort8(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 add = add_epi16(a, b);
                    v128 sub = sub_epi16(a, b);
                    
                    if (Architecture.IsBlendSupported)
                    {
                        return blend_epi16(sub, add, 0b1010_1010);
                    }
                    else if (elements == 2)
                    {
                        add = bsrli_si128(add, sizeof(ushort));
                        return unpacklo_epi16(sub, add);
                    }
                    else
                    {
                        return blend_epi16(sub, add, 0b1010_1010);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_addsub_epi16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return Avx2.mm256_sub_epi16(a, Avx2.mm256_sign_epi16(b, new ushort16(1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue, 1, ushort.MaxValue)));
                    }


                    v256 sub = Avx2.mm256_sub_epi16(a, b);
                    v256 add = Avx2.mm256_add_epi16(a, b);

                    return Avx2.mm256_blend_epi16(sub, add, 0b1010_1010);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 addsub_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (Avx.IsAvxSupported) // This is only always as fast as the SSSE3 version with the VEX prefix
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return sub_epi32(a, sign_epi32(b, new v128(1, uint.MaxValue, 1, uint.MaxValue)));
                    }


                    v128 add = add_epi32(a, b);
                    v128 sub = sub_epi32(a, b);

                    return blend_epi16(sub, add, 0b1100_1100);
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return sub_epi32(a, sign_epi32(b, new v128(1, uint.MaxValue, 1, uint.MaxValue)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 add = add_epi32(a, b);
                    v128 sub = sub_epi32(a, b);
                    
                    if (Architecture.IsBlendSupported)
                    {
                        return blendv_si128(sub, add, new v128(0, uint.MaxValue, 0, uint.MaxValue));
                    }
                    else if (elements == 2)
                    {
                        add = bsrli_si128(add, sizeof(uint));
                        return unpacklo_epi32(sub, add);
                    }
                    else
                    {
                        return blendv_si128(sub, add, new v128(0, uint.MaxValue, 0, uint.MaxValue));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_addsub_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return Avx2.mm256_sub_epi32(a, Avx2.mm256_sign_epi32(b, new uint8(1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue, 1, uint.MaxValue)));
                    }


                    v256 sub = Avx2.mm256_sub_epi32(a, b);
                    v256 add = Avx2.mm256_add_epi32(a, b);

                    return Avx2.mm256_blend_epi32(sub, add, 0b1010_1010);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 addsub_epi64(v128 a, v128 b)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 add = add_epi64(a, b);
                    v128 sub = sub_epi64(a, b);

                    if (Architecture.IsBlendSupported)
                    {
                        return blend_epi16(sub, add, 0b1111_0000);
                    }
                    else
                    {
                        add = bsrli_si128(add, sizeof(ulong));
                        return unpacklo_epi64(sub, add);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_addsub_epi64(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 sub = Avx2.mm256_sub_epi64(a, b);
                    v256 add = Avx2.mm256_add_epi64(a, b);

                    return Avx2.mm256_blend_epi32(sub, add, 0b1100_1100);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 addsub_ps(v128 a, v128 b)
            {
                if (Sse3.IsSse3Supported)
                {
                    return Sse3.addsub_ps(a, b);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 partialNeg = xor_ps(b, new v128(1 << 31, 0, 1 << 31, 0));

                    return add_ps(a, partialNeg);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 addsub_pd(v128 a, v128 b)
            {
                if (Sse3.IsSse3Supported)
                {
                    return Sse3.addsub_pd(a, b);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 partialNeg = xor_pd(b, new v128(1L << 63, 0L));

                    return add_pd(a, partialNeg);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="float2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 subadd(float2 a, float2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.addsub_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new float2(a.x - b.x, a.y + b.y);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="float3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 subadd(float3 a, float3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.addsub_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new float3(a.x - b.x, a.y + b.y, a.z - b.z);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="float4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 subadd(float4 a, float4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.addsub_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else
            {
                return new float4(a.x - b.x, a.y + b.y, a.z - b.z, a.w + b.w);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.float8"/>s.      </summary>
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


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="double2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 subadd(double2 a, double2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.addsub_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));;
            }
            else
            {
                return new double2(a.x - b.x, a.y + b.y);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="double3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 subadd(double3 a, double3 b)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Avx.mm256_addsub_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b)));
            }
            else
            {
                return new double3(subadd(a.xy, b.xy), a.z - b.z);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="double4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 subadd(double4 a, double4 b)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Avx.mm256_addsub_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b)));
            }
            else
            {
                return new double4(subadd(a.xy, b.xy), subadd(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.byte2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 subadd(byte2 a, byte2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi8(a, b, 2);
            }
            else
            {
                return new byte2((byte)(a.x - b.x), (byte)(a.y + b.y));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="MaxMath.byte3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 subadd(byte3 a, byte3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi8(a, b, 3);
            }
            else
            {
                return new byte3((byte)(a.x - b.x), (byte)(a.y + b.y), (byte)(a.z - b.z));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.byte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 subadd(byte4 a, byte4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi8(a, b, 4);
            }
            else
            {
                return new byte4((byte)(a.x - b.x), (byte)(a.y + b.y), (byte)(a.z - b.z), (byte)(a.w + b.w));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.byte8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 subadd(byte8 a, byte8 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi8(a, b, 8);
            }
            else
            {
                return new byte8((byte)(a.x0 - b.x0), (byte)(a.x1 + b.x1), (byte)(a.x2 - b.x2), (byte)(a.x3 + b.x3), (byte)(a.x4 - b.x4), (byte)(a.x5 + b.x5), (byte)(a.x6 - b.x6), (byte)(a.x7 + b.x7));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.byte16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 subadd(byte16 a, byte16 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi8(a, b, 16);
            }
            else
            {
                return new byte16((byte)(a.x0 - b.x0), (byte)(a.x1 + b.x1), (byte)(a.x2 - b.x2), (byte)(a.x3 + b.x3), (byte)(a.x4 - b.x4), (byte)(a.x5 + b.x5), (byte)(a.x6 - b.x6), (byte)(a.x7 + b.x7), (byte)(a.x8 - b.x8), (byte)(a.x9 + b.x9), (byte)(a.x10 - b.x10), (byte)(a.x11 + b.x11), (byte)(a.x12 - b.x12), (byte)(a.x13 + b.x13), (byte)(a.x14 - b.x14), (byte)(a.x15 + b.x15));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.byte32"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 subadd(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_addsub_epi8(a, b);
            }
            else
            {
                return new byte32(subadd(a.v16_0, b.v16_0), subadd(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.sbyte2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 subadd(sbyte2 a, sbyte2 b)
        {
            return (sbyte2)subadd((byte2)a, (byte2)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="MaxMath.sbyte3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 subadd(sbyte3 a, sbyte3 b)
        {
            return (sbyte3)subadd((byte3)a, (byte3)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.sbyte4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 subadd(sbyte4 a, sbyte4 b)
        {
            return (sbyte4)subadd((byte4)a, (byte4)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.sbyte8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 subadd(sbyte8 a, sbyte8 b)
        {
            return (sbyte8)subadd((byte8)a, (byte8)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.sbyte16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 subadd(sbyte16 a, sbyte16 b)
        {
            return (sbyte16)subadd((byte16)a, (byte16)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.sbyte32"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 subadd(sbyte32 a, sbyte32 b)
        {
            return (sbyte32)subadd((byte32)a, (byte32)b);
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.ushort2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 subadd(ushort2 a, ushort2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi16(a, b, 2);
            }
            else
            {
                return new ushort2((ushort)(a.x - b.x), (ushort)(a.y + b.y));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="MaxMath.ushort3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 subadd(ushort3 a, ushort3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi16(a, b, 3);
            }
            else
            {
                return new ushort3((ushort)(a.x - b.x), (ushort)(a.y + b.y), (ushort)(a.z - b.z));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.ushort4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 subadd(ushort4 a, ushort4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi16(a, b, 4);
            }
            else
            {
                return new ushort4((ushort)(a.x - b.x), (ushort)(a.y + b.y), (ushort)(a.z - b.z), (ushort)(a.w + b.w));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.ushort8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 subadd(ushort8 a, ushort8 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi16(a, b, 8);
            }
            else
            {
                return new ushort8((ushort)(a.x0 - b.x0), (ushort)(a.x1 + b.x1), (ushort)(a.x2 - b.x2), (ushort)(a.x3 + b.x3), (ushort)(a.x4 - b.x4), (ushort)(a.x5 + b.x5), (ushort)(a.x6 - b.x6), (ushort)(a.x7 + b.x7));
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.ushort16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 subadd(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_addsub_epi16(a, b);
            }
            else
            {
                return new ushort16(subadd(a.v8_0, b.v8_0), subadd(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.short2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 subadd(short2 a, short2 b)
        {
            return (short2)subadd((ushort2)a, (ushort2)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="MaxMath.short3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 subadd(short3 a, short3 b)
        {
            return (short3)subadd((ushort3)a, (ushort3)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.short4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 subadd(short4 a, short4 b)
        {
            return (short4)subadd((ushort4)a, (ushort4)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.short8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 subadd(short8 a, short8 b)
        {
            return (short8)subadd((ushort8)a, (ushort8)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.short16"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 subadd(short16 a, short16 b)
        {
            return (short16)subadd((ushort16)a, (ushort16)b);
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="uint2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 subadd(uint2 a, uint2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.addsub_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 2));
            }
            else
            {
                return new uint2(a.x - b.x, a.y + b.y);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="uint3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 subadd(uint3 a, uint3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.addsub_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 3));
            }
            else
            {
                return new uint3(a.x - b.x, a.y + b.y, a.z - b.z);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="uint4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 subadd(uint4 a, uint4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.addsub_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 4));
            }
            else
            {
                return new uint4(a.x - b.x, a.y + b.y, a.z - b.z, a.w + b.w);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.uint8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 subadd(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_addsub_epi32(a, b);
            }
            else
            {
                return new uint8(subadd(a.v4_0, b.v4_0), subadd(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="int2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 subadd(int2 a, int2 b)
        {
            return (int2)subadd((uint2)a, (uint2)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="int3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 subadd(int3 a, int3 b)
        {
            return (int3)subadd((uint3)a, (uint3)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="int4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 subadd(int4 a, int4 b)
        {
            return (int4)subadd((uint4)a, (uint4)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.int8"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 subadd(int8 a, int8 b)
        {
            return (int8)subadd((uint8)a, (uint8)b);
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.ulong2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 subadd(ulong2 a, ulong2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.addsub_epi64(a, b);
            }
            else
            {
                return new ulong2(a.x - b.x, a.y + b.y);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="MaxMath.ulong3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 subadd(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_addsub_epi64(a, b);
            }
            else
            {
                return new ulong3(subadd(a.xy, b.xy), a.z - b.z);
            }
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 subadd(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_addsub_epi64(a, b);
            }
            else
            {
                return new ulong4(subadd(a.xy, b.xy), subadd(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.long2"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 subadd(long2 a, long2 b)
        {
            return (long2)subadd((ulong2)a, (ulong2)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/> <paramref name="b"/>) on two <see cref="MaxMath.long3"/>s.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 subadd(long3 a, long3 b)
        {
            return (long3)subadd((ulong3)a, (ulong3)b);
        }

        /// <summary>       Returns the result of a componentwise subtract/add operation (<paramref name ="a"/> <see langword="-"/>/<see langword="+"/>/<see langword="-"/>/<see langword="+"/> <paramref name="b"/>) on two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 subadd(long4 a, long4 b)
        {
            return (long4)subadd((ulong4)a, (ulong4)b);
        }
    }
}