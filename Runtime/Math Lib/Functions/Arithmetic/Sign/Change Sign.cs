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
            public static v128 chgsign_pq(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return ternarylogic_si128(a, b, set1_epi8(1 << 7), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 chgsign_ph(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return ternarylogic_si128(a, b, set1_epi16(1 << 15), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 chgsign_ps(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return ternarylogic_si128(a, b, set1_epi32(1u << 31), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 chgsign_pd(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return ternarylogic_si128(a, b, set1_epi64x(1ul << 63), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_chgsign_pq(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_ternarylogic_si256(a, b, mm256_set1_epi8(1 << 7), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_chgsign_ph(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_ternarylogic_si256(a, b, mm256_set1_epi16(1 << 15), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_chgsign_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_ternarylogic_si256(a, b, mm256_set1_epi32(1u << 31), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_chgsign_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_ternarylogic_si256(a, b, mm256_set1_epi64x(1ul << 63), TernaryOperation.Ox78);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>   Change the sign of <paramref name="x"/> based on the most significant bit of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter chgsign(quarter x, quarter y)
        {
            return asquarter((byte)(asbyte(x) ^ (asbyte(y) & (1 << 7))));
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 chgsign(quarter2 x, quarter2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.chgsign_pq(x, y);
            }
            else
            {
                return asquarter(asbyte(x) ^ (asbyte(y) & (1 << 7)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 chgsign(quarter3 x, quarter3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.chgsign_pq(x, y);
            }
            else
            {
                return asquarter(asbyte(x) ^ (asbyte(y) & (1 << 7)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 chgsign(quarter4 x, quarter4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.chgsign_pq(x, y);
            }
            else
            {
                return asquarter(asbyte(x) ^ (asbyte(y) & (1 << 7)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 chgsign(quarter8 x, quarter8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.chgsign_pq(x, y);
            }
            else
            {
                return asquarter(asbyte(x) ^ (asbyte(y) & (1 << 7)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 chgsign(quarter16 x, quarter16 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.chgsign_pq(x, y);
            }
            else
            {
                return asquarter(asbyte(x) ^ (asbyte(y) & (1 << 7)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 chgsign(quarter32 x, quarter32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_chgsign_pq(x, y);
            }
            else
            {
                return new quarter32(chgsign(x.v16_0, y.v16_0), chgsign(x.v16_16, y.v16_16));
            }
        }


        /// <summary>   Change the sign of <paramref name="x"/> based on the most significant bit of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half chgsign(half x, half y)
        {
            return ashalf((ushort)(asushort(x) ^ (asushort(y) & (1 << 15))));
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 chgsign(half2 x, half2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.chgsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return ashalf(asushort(x) ^ (asushort(y) & (1 << 15)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 chgsign(half3 x, half3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.chgsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return ashalf(asushort(x) ^ (asushort(y) & (1 << 15)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 chgsign(half4 x, half4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.chgsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return ashalf(asushort(x) ^ (asushort(y) & (1 << 15)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 chgsign(half8 x, half8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.chgsign_ph(x, y);
            }
            else
            {
                return ashalf(asushort(x) ^ (asushort(y) & (1 << 15)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 chgsign(half16 x, half16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_chgsign_pq(x, y);
            }
            else
            {
                return new half16(chgsign(x.v8_0, y.v8_0), chgsign(x.v8_8, y.v8_8));
            }
        }


        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 chgsign(float8 x, float8 y)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_chgsign_ps(x, y);
            }
            else
            {
                return new float8(math.chgsign(x.v4_0, y.v4_0), math.chgsign(x.v4_4, y.v4_4));
            }
        }


        /// <summary>   Change the sign of <paramref name="x"/> based on the most significant bit of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double chgsign(double x, double y)
        {
            return math.asdouble(math.asulong(x) ^ (math.asulong(y) & (1ul << 63)));
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 chgsign(double2 x, double2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.chgsign_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return asdouble(asulong(x) ^ (asulong(y) & (1ul << 63)));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 chgsign(double3 x, double3 y)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_chgsign_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y)));
            }
            else
            {
                return new double3(chgsign(x.xy, y.xy), chgsign(x.z, y.z));
            }
        }

        /// <summary>   Change the sign of components of <paramref name="x"/> based on the most significant bit of components of <paramref name="y"/> [msb(<paramref name="y"/>) <see langword="?"/> <see langword="-"/><paramref name="x"/> <see langword=":"/> <paramref name="x"/>].    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 chgsign(double4 x, double4 y)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_chgsign_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y)));
            }
            else
            {
                return new double4(chgsign(x.xy, y.xy), chgsign(x.zw, y.zw));
            }
        }
    }
}