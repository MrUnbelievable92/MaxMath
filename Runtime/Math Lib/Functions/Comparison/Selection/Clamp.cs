using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            public static v128 saturate_pq(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(srai_epi8(a, 7), min_epu8(a, set1_epi8(maxmath.ONE_AS_QUARTER)));
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_saturate_pq(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(mm256_srai_epi8(a, 7), Avx2.mm256_min_epu8(a, mm256_set1_epi8(maxmath.ONE_AS_QUARTER)));
                }
                else throw new IllegalInstructionException();
            }


            public static v128 saturate_ph(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return andnot_si128(srai_epi16(a, 15), min_epu16(a, set1_epi16(maxmath.ONE_AS_HALF)));
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_saturate_ph(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_andnot_si256(Avx2.mm256_srai_epi16(a, 15), Avx2.mm256_min_epu16(a, mm256_set1_epi16(maxmath.ONE_AS_HALF)));
                }
                else throw new IllegalInstructionException();
            }


            public static v128 saturate_ps(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_ps(1f);

                    if (BurstArchitecture.IsMinMaxSupported)
                    {
                        return andnot_ps(srai_epi32(a, 31), min_epu32(a, ONE));
                    }
                    else
                    {
                        return max_ps(setzero_ps(), min_ps(a, ONE));
                    }
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_saturate_ps(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 ONE = mm256_set1_ps(1f);

                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx.mm256_andnot_ps(Avx2.mm256_srai_epi32(a, 31), Avx2.mm256_min_epu32(a, ONE));
                    }
                    else
                    {
                        return Avx.mm256_max_ps(Avx.mm256_setzero_ps(), Avx.mm256_min_ps(a, ONE));
                    }
                }
                else throw new IllegalInstructionException();
            }


            public static v128 saturate_pd(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return max_pd(setzero_ps(), min_pd(a, set1_pd(1d)));
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_saturate_pd(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_max_pd(Avx.mm256_setzero_pd(), Avx.mm256_min_pd(a, mm256_set1_pd(1d)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.float8"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 saturate(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_saturate_ps(x);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new float8(RegisterConversion.ToFloat4(Xse.saturate_ps(RegisterConversion.ToV128(x.v4_0))),
                                  RegisterConversion.ToFloat4(Xse.saturate_ps(RegisterConversion.ToV128(x.v4_4))));
            }
            else
            {
                return clamp(x, 0f, 1f);
            }
        }


        /// <summary>       Returns the result of a clamping of the value <see cref="MaxMath.quarter"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter saturate(quarter x)
        {
            return asquarter(andnot(min(x.value, ONE_AS_QUARTER), (byte)((sbyte)x.value >> 31)));
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.quarter2"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 saturate(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.saturate_pq(x);
            }
            else
            {
                return new quarter2(saturate(x.x), saturate(x.y));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.quarter3"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 saturate(quarter3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.saturate_pq(x);
            }
            else
            {
                return new quarter3(saturate(x.x), saturate(x.y), saturate(x.z));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.quarter4"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 saturate(quarter4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.saturate_pq(x);
            }
            else
            {
                return new quarter4(saturate(x.x), saturate(x.y), saturate(x.z), saturate(x.w));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.quarter8"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 saturate(quarter8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.saturate_pq(x);
            }
            else
            {
                return new quarter8(saturate(x.x0),
                                    saturate(x.x1),
                                    saturate(x.x2),
                                    saturate(x.x3),
                                    saturate(x.x4),
                                    saturate(x.x5),
                                    saturate(x.x6),
                                    saturate(x.x7));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.quarter16"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 saturate(quarter16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.saturate_pq(x);
            }
            else
            {
                return new quarter16(saturate(x.x0),
                                     saturate(x.x1),
                                     saturate(x.x2),
                                     saturate(x.x3),
                                     saturate(x.x4),
                                     saturate(x.x5),
                                     saturate(x.x6),
                                     saturate(x.x7),
                                     saturate(x.x8),
                                     saturate(x.x9),
                                     saturate(x.x10),
                                     saturate(x.x11),
                                     saturate(x.x12),
                                     saturate(x.x13),
                                     saturate(x.x14),
                                     saturate(x.x15));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.quarter32"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 saturate(quarter32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_saturate_pq(x);
            }
            else
            {
                return new quarter32(saturate(x.v16_0), saturate(x.v16_16));
            }
        }


        /// <summary>       Returns the result of a clamping of the value <see cref="half"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half saturate(half x)
        {
            return ashalf(andnot(min(x.value, ONE_AS_HALF), (ushort)((short)x.value >> 31)));
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="half2"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 saturate(half2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.saturate_ph(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new half2(saturate(x.x), saturate(x.y));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="half3"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 saturate(half3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.saturate_ph(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new half3(saturate(x.x), saturate(x.y), saturate(x.z));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="half4"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 saturate(half4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.saturate_ph(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new half4(saturate(x.x), saturate(x.y), saturate(x.z), saturate(x.w));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.half8"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 saturate(half8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.saturate_ph(x);
            }
            else
            {
                return new half8(saturate(x.x0),
                                 saturate(x.x1),
                                 saturate(x.x2),
                                 saturate(x.x3),
                                 saturate(x.x4),
                                 saturate(x.x5),
                                 saturate(x.x6),
                                 saturate(x.x7));
            }
        }

        /// <summary>       Returns the result of a componentwise clamping of a <see cref="MaxMath.half16"/> into the interval [0, 1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 saturate(half16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_saturate_ph(x);
            }
            else
            {
                return new half16(saturate(x.v8_0), saturate(x.v8_8));
            }
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 clamp(UInt128 x, UInt128 a, UInt128 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 clamp(Int128 x, Int128 a, Int128 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte clamp(byte x, byte a, byte b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 clamp(byte2 x, byte2 a, byte2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 clamp(byte3 x, byte3 a, byte3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 clamp(byte4 x, byte4 a, byte4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 clamp(byte8 x, byte8 a, byte8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 clamp(byte16 x, byte16 a, byte16 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 clamp(byte32 x, byte32 a, byte32 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte clamp(sbyte x, sbyte a, sbyte b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 clamp(sbyte2 x, sbyte2 a, sbyte2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 clamp(sbyte3 x, sbyte3 a, sbyte3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 clamp(sbyte4 x, sbyte4 a, sbyte4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 clamp(sbyte8 x, sbyte8 a, sbyte8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 clamp(sbyte16 x, sbyte16 a, sbyte16 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 clamp(sbyte32 x, sbyte32 a, sbyte32 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort clamp(ushort x, ushort a, ushort b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 clamp(ushort2 x, ushort2 a, ushort2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 clamp(ushort3 x, ushort3 a, ushort3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 clamp(ushort4 x, ushort4 a, ushort4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 clamp(ushort8 x, ushort8 a, ushort8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 clamp(ushort16 x, ushort16 a, ushort16 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short clamp(short x, short a, short b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 clamp(short2 x, short2 a, short2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 clamp(short3 x, short3 a, short3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 clamp(short4 x, short4 a, short4 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 clamp(short8 x, short8 a, short8 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 clamp(short16 x, short16 a, short16 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 clamp(int8 x, int8 a, int8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 clamp(uint8 x, uint8 a, uint8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 clamp(ulong2 x, ulong2 a, ulong2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 clamp(ulong3 x, ulong3 a, ulong3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 clamp(ulong4 x, ulong4 a, ulong4 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 clamp(long2 x, long2 a, long2 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 clamp(long3 x, long3 a, long3 b)
        {
            return max(a, min(x, b));
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 clamp(long4 x, long4 a, long4 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 clamp(float8 x, float8 a, float8 b)
        {
            return max(a, min(x, b));
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="half"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="x"/>, <paramref name="b"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="x"/>, <paramref name="b"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half clamp(half x, half a, half b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="half2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 clamp(half2 x, half2 a, half2 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="half3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 clamp(half3 x, half3 a, half3 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="half4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 clamp(half4 x, half4 a, half4 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.half8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 clamp(half8 x, half8 a, half8 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.half16"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 clamp(half16 x, half16 a, half16 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }


        /// <summary>       Returns the result of a clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="x"/>, <paramref name="b"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="x"/>, <paramref name="b"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter clamp(quarter x, quarter a, quarter b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 clamp(quarter2 x, quarter2 a, quarter2 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 clamp(quarter3 x, quarter3 a, quarter3 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 clamp(quarter4 x, quarter4 a, quarter4 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 clamp(quarter8 x, quarter8 a, quarter8 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter16"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 clamp(quarter16 x, quarter16 a, quarter16 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }

        /// <summary>       Returns the result of a componentwise clamping of the value <paramref name="x"/> into the interval [<paramref name="a"/>, <paramref name="b"/>], where <paramref name="x"/>, <paramref name="a"/> and <paramref name="b"/> are <see cref="MaxMath.quarter32"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="x"/>, <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 clamp(quarter32 x, quarter32 a, quarter32 b, Promise promises = Promise.Nothing)
        {
            return max(a, min(x, b, promises), promises);
        }
    }
}