
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Negates the <see cref="Int128"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 negate(Int128 x, bool p)
        {
Assert.IsSafeBoolean(p);

            if (constexpr.IS_CONST((long)x.hi64 < 0))
            {
                return select(x, -x, p);
            }
            else
            {
                long mask = -tolong(p);
                return (x ^ new Int128(mask, mask)) - new Int128(mask, mask);
            }
        }


        /// <summary>       Negates the <see cref="MaxMath.quarter"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter negate(quarter x, bool p)
        {
Assert.IsSafeBoolean(p);

            return asquarter((byte)(asbyte(x) ^ (tobyte(p) << 7)));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, bool2 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, bool3 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, bool4 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 negate(quarter8 x, bool8 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 negate(quarter16 x, bool16 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter32"/> if the corresponding value in the <see cref="MaxMath.bool32"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 negate(quarter32 x, bool32 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }


        /// <summary>       Negates the <see cref="half"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half negate(half x, bool p)
        {
Assert.IsSafeBoolean(p);

            return ashalf((ushort)(asushort(x) ^ (toushort(p) << 15)));
        }

        /// <summary>       Negates the components of a <see cref="half2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, bool2 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="half3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, bool3 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="half4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, bool4 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 negate(half8 x, bool8 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 negate(half16 x, bool16 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }


        /// <summary>       Negates the <see cref="float"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float negate(float x, bool p)
        {
Assert.IsSafeBoolean(p);

            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="float2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="float3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="float4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, bool8 p)
        {
            return asfloat(asuint(x) ^ (touint(p) << 31));
        }


        /// <summary>       Negates the <see cref="double"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double negate(double x, bool p)
        {
Assert.IsSafeBoolean(p);

            return math.asdouble(math.asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="double2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="double3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="double4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, bool4 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }


        /// <summary>       Negates the <see cref="sbyte"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte negate(sbyte x, bool p)
        {
Assert.IsSafeBoolean(p);

            return p ? (sbyte)-x : x;
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, bool2 p)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(p), 1, 2);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi8(x, new v128((sbyte)(p.x ? -1 : 1), (sbyte)(p.y ? -1 : 1),    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, bool3 p)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(p), 1, 3);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi8(x, new v128((sbyte)(p.x ? -1 : 1), (sbyte)(p.y ? -1 : 1), (sbyte)(p.z ? -1 : 1),    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, bool4 p)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(p), 1, 4);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi8(x, new v128((sbyte)(p.x ? -1 : 1), (sbyte)(p.y ? -1 : 1), (sbyte)(p.z ? -1 : 1), (sbyte)(p.w ? -1 : 1),    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 negate(sbyte8 x, bool8 p)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(p), 1, 8);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi8(x, new v128((sbyte)(p.x0 ? -1 : 1), (sbyte)(p.x1 ? -1 : 1), (sbyte)(p.x2 ? -1 : 1), (sbyte)(p.x3 ? -1 : 1), (sbyte)(p.x4 ? -1 : 1), (sbyte)(p.x5 ? -1 : 1), (sbyte)(p.x6 ? -1 : 1), (sbyte)(p.x7 ? -1 : 1),    0, 0, 0, 0, 0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 negate(sbyte16 x, bool16 p)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(p), 1, 16);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi8(x, new v128((sbyte)(p.x0 ? -1 : 1), (sbyte)(p.x1 ? -1 : 1), (sbyte)(p.x2 ? -1 : 1), (sbyte)(p.x3 ? -1 : 1), (sbyte)(p.x4 ? -1 : 1), (sbyte)(p.x5 ? -1 : 1), (sbyte)(p.x6 ? -1 : 1), (sbyte)(p.x7 ? -1 : 1), (sbyte)(p.x8 ? -1 : 1), (sbyte)(p.x9 ? -1 : 1), (sbyte)(p.x10 ? -1 : 1), (sbyte)(p.x11 ? -1 : 1), (sbyte)(p.x12 ? -1 : 1), (sbyte)(p.x13 ? -1 : 1), (sbyte)(p.x14 ? -1 : 1), (sbyte)(p.x15 ? -1 : 1)));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte32"/> if the corresponding value in the <see cref="MaxMath.bool32"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 negate(sbyte32 x, bool32 p)
        {
VectorAssert.IsNotGreater<byte32, byte>(tobyte(p), 1, 32);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(p))
                {
                    return Avx2.mm256_sign_epi8(x, new v256((sbyte)(p.x0 ? -1 : 1), (sbyte)(p.x1 ? -1 : 1), (sbyte)(p.x2 ? -1 : 1), (sbyte)(p.x3 ? -1 : 1), (sbyte)(p.x4 ? -1 : 1), (sbyte)(p.x5 ? -1 : 1), (sbyte)(p.x6 ? -1 : 1), (sbyte)(p.x7 ? -1 : 1), (sbyte)(p.x8 ? -1 : 1), (sbyte)(p.x9 ? -1 : 1), (sbyte)(p.x10 ? -1 : 1), (sbyte)(p.x11 ? -1 : 1), (sbyte)(p.x12 ? -1 : 1), (sbyte)(p.x13 ? -1 : 1), (sbyte)(p.x14 ? -1 : 1), (sbyte)(p.x15 ? -1 : 1), (sbyte)(p.x16 ? -1 : 1), (sbyte)(p.x17 ? -1 : 1), (sbyte)(p.x18 ? -1 : 1), (sbyte)(p.x19 ? -1 : 1), (sbyte)(p.x20 ? -1 : 1), (sbyte)(p.x21 ? -1 : 1), (sbyte)(p.x22 ? -1 : 1), (sbyte)(p.x23 ? -1 : 1), (sbyte)(p.x24 ? -1 : 1), (sbyte)(p.x25 ? -1 : 1), (sbyte)(p.x26 ? -1 : 1), (sbyte)(p.x27 ? -1 : 1), (sbyte)(p.x28 ? -1 : 1), (sbyte)(p.x29 ? -1 : 1), (sbyte)(p.x30 ? -1 : 1), (sbyte)(p.x31 ? -1 : 1)));
                }
            }

            return select(x, -x, p);
        }



        /// <summary>       Negates the <see cref="short"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short negate(short x, bool p)
        {
Assert.IsSafeBoolean(p);

            return p ? (short)-x : x;
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, bool2 p)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(p), 1, 2);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi16(x, new v128((short)(p.x ? -1 : 1), (short)(p.y ? -1 : 1),    0, 0, 0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, bool3 p)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(p), 1, 3);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi16(x, new v128((short)(p.x ? -1 : 1), (short)(p.y ? -1 : 1), (short)(p.z ? -1 : 1),    0, 0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, bool4 p)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(p), 1, 4);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi16(x, new v128((short)(p.x ? -1 : 1), (short)(p.y ? -1 : 1), (short)(p.z ? -1 : 1), (short)(p.w ? -1 : 1),    0, 0, 0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 negate(short8 x, bool8 p)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(p), 1, 8);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi16(x, new v128((short)(p.x0 ? -1 : 1), (short)(p.x1 ? -1 : 1), (short)(p.x2 ? -1 : 1), (short)(p.x3 ? -1 : 1), (short)(p.x4 ? -1 : 1), (short)(p.x5 ? -1 : 1), (short)(p.x6 ? -1 : 1), (short)(p.x7 ? -1 : 1)));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 negate(short16 x, bool16 p)
        {
VectorAssert.IsNotGreater<byte16, byte>(tobyte(p), 1, 16);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(p))
                {
                    return Avx2.mm256_sign_epi16(x, new v256((short)(p.x0 ? -1 : 1), (short)(p.x1 ? -1 : 1), (short)(p.x2 ? -1 : 1), (short)(p.x3 ? -1 : 1), (short)(p.x4 ? -1 : 1), (short)(p.x5 ? -1 : 1), (short)(p.x6 ? -1 : 1), (short)(p.x7 ? -1 : 1), (short)(p.x8 ? -1 : 1), (short)(p.x9 ? -1 : 1), (short)(p.x10 ? -1 : 1), (short)(p.x11 ? -1 : 1), (short)(p.x12 ? -1 : 1), (short)(p.x13 ? -1 : 1), (short)(p.x14 ? -1 : 1), (short)(p.x15 ? -1 : 1)));
                }
            }

            return select(x, -x, p);
        }


        /// <summary>       Negates the <see cref="int"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int negate(int x, bool p)
        {
Assert.IsSafeBoolean(p);

            return p ? -x : x;
        }

        /// <summary>       Negates the components of an <see cref="int2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, bool2 p)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(p), 1, 2);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return RegisterConversion.ToInt2(Xse.sign_epi32(RegisterConversion.ToV128(x), new v128((int)(p.x ? -1 : 1), (int)(p.y ? -1 : 1),    0, 0)));
                }
            }

            return math.select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="int3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, bool3 p)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(p), 1, 3);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return RegisterConversion.ToInt3(Xse.sign_epi32(RegisterConversion.ToV128(x), new v128((int)(p.x ? -1 : 1), (int)(p.y ? -1 : 1), (int)(p.z ? -1 : 1),   0)));
                }
            }

            return math.select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="int4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, bool4 p)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(p), 1, 4);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return RegisterConversion.ToInt4(Xse.sign_epi32(RegisterConversion.ToV128(x), new v128((int)(p.x ? -1 : 1), (int)(p.y ? -1 : 1), (int)(p.z ? -1 : 1), (int)(p.w ? -1 : 1))));
                }
            }

            return math.select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 negate(int8 x, bool8 p)
        {
VectorAssert.IsNotGreater<byte8, byte>(tobyte(p), 1, 8);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(p))
                {
                    return Avx2.mm256_sign_epi32(x, new v256((int)(p.x0 ? -1 : 1), (int)(p.x1 ? -1 : 1), (int)(p.x2 ? -1 : 1), (int)(p.x3 ? -1 : 1), (int)(p.x4 ? -1 : 1), (int)(p.x5 ? -1 : 1), (int)(p.x6 ? -1 : 1), (int)(p.x7 ? -1 : 1)));
                }
            }

            return select(x, -x, p);
        }


        /// <summary>       Negates the <see cref="long"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long negate(long x, bool p)
        {
Assert.IsSafeBoolean(p);

            return p ? -x : x;
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, bool2 p)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(p), 1, 2);

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, bool3 p)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(p), 1, 3);

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, bool4 p)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(p), 1, 4);

            return select(x, -x, p);
        }
    }
}