
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
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

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, bool2 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, bool3 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
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


        /// <summary>       Negates the <see cref="MaxMath.half"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half negate(half x, bool p)
        {
Assert.IsSafeBoolean(p);

            return ashalf((ushort)(asushort(x) ^ (toushort(p) << 15)));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, bool2 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, bool3 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
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

            return asfloat(asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            return asfloat(asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            return asfloat(asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            return asfloat(asuint(x) ^ (touint(p) << 31));
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

            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.double2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.double3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.double4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
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

        /// <summary>       Negates the components of an <see cref="MaxMath.int2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, bool2 p)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(p), 1, 2);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi32(x, new v128((int)(p.x ? -1 : 1), (int)(p.y ? -1 : 1),    0, 0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, bool3 p)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(p), 1, 3);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi32(x, new v128((int)(p.x ? -1 : 1), (int)(p.y ? -1 : 1), (int)(p.z ? -1 : 1),   0));
                }
            }

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, bool4 p)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(p), 1, 4);

            if (constexpr.IS_CONST(p))
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Xse.sign_epi32(x, new v128((int)(p.x ? -1 : 1), (int)(p.y ? -1 : 1), (int)(p.z ? -1 : 1), (int)(p.w ? -1 : 1)));
                }
            }

            return select(x, -x, p);
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

        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, bool2 p)
        {
VectorAssert.IsNotGreater<byte2, byte>(tobyte(p), 1, 2);

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, bool3 p)
        {
VectorAssert.IsNotGreater<byte3, byte>(tobyte(p), 1, 3);

            return select(x, -x, p);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, bool4 p)
        {
VectorAssert.IsNotGreater<byte4, byte>(tobyte(p), 1, 4);

            return select(x, -x, p);
        }


        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.half2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.float2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.double2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.int2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, Unity.Mathematics.bool2 p) => negate(x, (bool2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, Unity.Mathematics.bool3 p) => negate(x, (bool3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="MaxMath.Unity.Mathematics.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, Unity.Mathematics.bool4 p) => negate(x, (bool4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, mask8x2 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi8(1 << 7), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, mask8x3 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi8(1 << 7), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, mask8x4 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi8(1 << 7), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 negate(quarter8 x, mask8x8 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi8(1 << 7), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool8)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 negate(quarter16 x, mask8x16 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi8(1 << 7), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool16)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter32"/> if the corresponding value in the <see cref="MaxMath.bool32"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 negate(quarter32 x, mask8x32 p)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ternarylogic_si256(x, p, Xse.mm256_set1_epi8(1 << 7), TernaryOperation.Ox78);
            }
            else
            {
                return new quarter32(negate(x.v16_0, p.v16_0), negate(x.v16_16, p.v16_16));
            }
        }


        /// <summary>       Negates the components of a <see cref="MaxMath.half2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, mask8x2 p) => negate(x, (mask16x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, mask8x3 p) => negate(x, (mask16x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, mask8x4 p) => negate(x, (mask16x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 negate(half8 x, mask8x8 p) => negate(x, (mask16x8)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 negate(half16 x, mask8x16 p) => negate(x, (mask16x16)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.float2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, mask8x2 p) => negate(x, (mask32x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, mask8x3 p) => negate(x, (mask32x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, mask8x4 p) => negate(x, (mask32x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, mask8x8 p) => negate(x, (mask32x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.double2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, mask8x2 p) => negate(x, (mask64x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, mask8x3 p) => negate(x, (mask64x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, mask8x4 p) => negate(x, (mask64x4)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, mask8x2 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi8(1), Xse.set1_epi8(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi8(x, sign);
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, sbyte16>().v2_0) - p.mask.Reinterpret<ulong2, sbyte16>().v2_0;
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, mask8x3 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi8(1), Xse.set1_epi8(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi8(x, sign);
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, sbyte16>().v3_0) - p.mask.Reinterpret<ulong2, sbyte16>().v3_0;
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, mask8x4 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi8(1), Xse.set1_epi8(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi8(x, sign);
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, sbyte16>().v4_0) - p.mask.Reinterpret<ulong2, sbyte16>().v4_0;
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 negate(sbyte8 x, mask8x8 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi8(1), Xse.set1_epi8(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi8(x, sign);
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, sbyte16>().v8_0) - p.mask.Reinterpret<ulong2, sbyte16>().v8_0;
            }
            else
            {
                return negate(x, (bool8)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 negate(sbyte16 x, mask8x16 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi8(1), Xse.set1_epi8(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi8(x, sign);
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, sbyte16>()) - p.mask.Reinterpret<ulong2, sbyte16>();
            }
            else
            {
                return negate(x, (bool16)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte32"/> if the corresponding value in the <see cref="MaxMath.bool32"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 negate(sbyte32 x, mask8x32 p)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 sign = Xse.mm256_blendv_si256(Xse.mm256_set1_epi8(1), Xse.mm256_set1_epi8(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Avx2.mm256_sign_epi8(x, sign);
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong4, sbyte32>()) - p.mask.Reinterpret<ulong4, sbyte32>();
            }
            else
            {
                return negate(x, (bool32)p);
            }
        }


        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, mask8x2 p) => negate(x, (mask16x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, mask8x3 p) => negate(x, (mask16x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, mask8x4 p) => negate(x, (mask16x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 negate(short8 x, mask8x8 p) => negate(x, (mask16x8)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 negate(short16 x, mask8x16 p) => negate(x, (mask16x16)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.int2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, mask8x2 p) => negate(x, (mask32x2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, mask8x3 p) => negate(x, (mask32x3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, mask8x4 p) => negate(x, (mask32x4)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 negate(int8 x, mask8x8 p) => negate(x, (mask32x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, mask8x2 p) => negate(x, (mask64x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, mask8x3 p) => negate(x, (mask64x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, mask8x4 p) => negate(x, (mask64x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, mask16x2 p) => negate(x, (mask8x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, mask16x3 p) => negate(x, (mask8x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, mask16x4 p) => negate(x, (mask8x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 negate(quarter8 x, mask16x8 p) => negate(x, (mask8x8)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 negate(quarter16 x, mask16x16 p) => negate(x, (mask8x16)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.half2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, mask16x2 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi16(1 << 15), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, mask16x3 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi16(1 << 15), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, mask16x4 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi16(1 << 15), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 negate(half8 x, mask16x8 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi16(1 << 15), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool8)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 negate(half16 x, mask16x16 p)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ternarylogic_si256(x, p, Xse.mm256_set1_epi16(1 << 15), TernaryOperation.Ox78);
            }
            else
            {
                return new half16(negate(x.v8_0, p.v8_0), negate(x.v8_8, p.v8_8));
            }
        }


        /// <summary>       Negates the components of a <see cref="MaxMath.float2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, mask16x2 p) => negate(x, (mask32x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, mask16x3 p) => negate(x, (mask32x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, mask16x4 p) => negate(x, (mask32x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, mask16x8 p) => negate(x, (mask32x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.double2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, mask16x2 p) => negate(x, (mask64x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, mask16x3 p) => negate(x, (mask64x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, mask16x4 p) => negate(x, (mask64x4)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, mask16x2 p) => negate(x, (mask8x2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, mask16x3 p) => negate(x, (mask8x3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, mask16x4 p) => negate(x, (mask8x4)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 negate(sbyte8 x, mask16x8 p) => negate(x, (mask8x8)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 negate(sbyte16 x, mask16x16 p) => negate(x, (mask8x16)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, mask16x2 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi16(1), Xse.set1_epi16(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi16(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, short8>().v2_0) - p.mask.Reinterpret<ulong2, short8>().v2_0;
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, mask16x3 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi16(1), Xse.set1_epi16(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi16(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, short8>().v3_0) - p.mask.Reinterpret<ulong2, short8>().v3_0;
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, mask16x4 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi16(1), Xse.set1_epi16(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi16(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, short8>().v4_0) - p.mask.Reinterpret<ulong2, short8>().v4_0;
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 negate(short8 x, mask16x8 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi16(1), Xse.set1_epi16(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi16(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, short8>()) - p.mask.Reinterpret<ulong2, short8>();
            }
            else
            {
                return negate(x, (bool8)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 negate(short16 x, mask16x16 p)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 sign = Xse.mm256_blendv_si256(Xse.mm256_set1_epi16(1), Xse.mm256_set1_epi16(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Avx2.mm256_sign_epi16(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong4, short16>()) - p.mask.Reinterpret<ulong4, short16>();
            }
            else
            {
                return negate(x, (bool16)p);
            }
        }


        /// <summary>       Negates the components of an <see cref="MaxMath.int2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, mask16x2 p) => negate(x, (mask32x2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, mask16x3 p) => negate(x, (mask32x3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, mask16x4 p) => negate(x, (mask32x4)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 negate(int8 x, mask16x8 p) => negate(x, (mask32x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, mask16x2 p) => negate(x, (mask64x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, mask16x3 p) => negate(x, (mask64x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, mask16x4 p) => negate(x, (mask64x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, mask32x2 p) => negate(x, (mask8x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, mask32x3 p) => negate(x, (mask8x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, mask32x4 p) => negate(x, (mask8x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 negate(quarter8 x, mask32x8 p) => negate(x, (mask8x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.half2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, mask32x2 p) => negate(x, (mask16x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, mask32x3 p) => negate(x, (mask16x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, mask32x4 p) => negate(x, (mask16x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 negate(half8 x, mask32x8 p) => negate(x, (mask16x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.float2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, mask32x2 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi32(1u << 31), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, mask32x3 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi32(1u << 31), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, mask32x4 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi32(1u << 31), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, mask32x8 p)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ternarylogic_si256(x, p, Xse.mm256_set1_epi32(1u << 31), TernaryOperation.Ox78);
            }
            else
            {
                return new float8(negate(x.v4_0, p.v4_0), negate(x.v4_4, p.v4_4));
            }
        }


        /// <summary>       Negates the components of a <see cref="MaxMath.double2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, mask32x2 p) => negate(x, (mask64x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, mask32x3 p) => negate(x, (mask64x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.double4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, mask32x4 p) => negate(x, (mask64x4)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, mask32x2 p) => negate(x, (mask8x2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, mask32x3 p) => negate(x, (mask8x3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, mask32x4 p) => negate(x, (mask8x4)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 negate(sbyte8 x, mask32x8 p) => negate(x, (mask8x8)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, mask32x2 p) => negate(x, (mask16x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, mask32x3 p) => negate(x, (mask16x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, mask32x4 p) => negate(x, (mask16x4)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 negate(short8 x, mask32x8 p) => negate(x, (mask16x8)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.int2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, mask32x2 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi32(1), Xse.set1_epi32(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi32(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, int4>().xy) - p.mask.Reinterpret<ulong2, int4>().xy;
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, mask32x3 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi32(1), Xse.set1_epi32(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi32(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, int4>().xyz) - p.mask.Reinterpret<ulong2, int4>().xyz;
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, mask32x4 p)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 sign = Xse.blendv_si128(Xse.set1_epi32(1), Xse.set1_epi32(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Xse.sign_epi32(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong2, int4>()) - p.mask.Reinterpret<ulong2, int4>();
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 negate(int8 x, mask32x8 p)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 sign = Xse.mm256_blendv_si256(Xse.mm256_set1_epi32(1), Xse.mm256_set1_epi32(-1), p);

                if (constexpr.IS_CONST(sign))
                {
                    return Avx2.mm256_sign_epi32(x, sign);
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ p.mask.Reinterpret<ulong4, int8>()) - p.mask.Reinterpret<ulong4, int8>();
            }
            else
            {
                return negate(x, (bool8)p);
            }
        }


        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, mask32x2 p) => negate(x, (mask64x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, mask32x3 p) => negate(x, (mask64x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, mask32x4 p) => negate(x, (mask64x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, mask64x2 p) => negate(x, (mask8x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, mask64x3 p) => negate(x, (mask8x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, mask64x4 p) => negate(x, (mask8x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.half2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, mask64x2 p) => negate(x, (mask16x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, mask64x3 p) => negate(x, (mask16x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.half4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, mask64x4 p) => negate(x, (mask16x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.float2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, mask64x2 p) => negate(x, (mask32x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, mask64x3 p) => negate(x, (mask32x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.float4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, mask64x4 p) => negate(x, (mask32x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.double2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, mask64x2 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ternarylogic_si128(x, p, Xse.set1_epi64x(1ul << 63), TernaryOperation.Ox78);
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.double3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, mask64x3 p)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ternarylogic_si256(x, p, Xse.mm256_set1_epi64x(1ul << 63), TernaryOperation.Ox78);
            }
            else
            {
                return new double3(negate(x.xy, p.xy), negate(x.z, p.z));
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.double4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, mask64x4 p)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ternarylogic_si256(x, p, Xse.mm256_set1_epi64x(1ul << 63), TernaryOperation.Ox78);
            }
            else
            {
                return new double4(negate(x.xy, p.xy), negate(x.zw, p.zw));
            }
        }


        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, mask64x2 p) => negate(x, (mask8x2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, mask64x3 p) => negate(x, (mask8x3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, mask64x4 p) => negate(x, (mask8x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, mask64x2 p) => negate(x, (mask16x2)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, mask64x3 p) => negate(x, (mask16x3)p);

        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, mask64x4 p) => negate(x, (mask16x4)p);


        /// <summary>       Negates the components of an <see cref="MaxMath.int2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, mask64x2 p) => negate(x, (mask32x2)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, mask64x3 p) => negate(x, (mask32x3)p);

        /// <summary>       Negates the components of an <see cref="MaxMath.int4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, mask64x4 p) => negate(x, (mask32x4)p);


        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="MaxMath.bool2"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, mask64x2 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ (long2)p.mask) - (long2)p.mask;
            }
            else
            {
                return negate(x, (bool2)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="MaxMath.bool3"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, mask64x3 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ (long3)p.mask.xyz) - (long3)p.mask.xyz;
            }
            else
            {
                return negate(x, (bool3)p);
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="MaxMath.bool4"/> is <see langword="true"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, mask64x4 p)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (x ^ (long4)p.mask) - (long4)p.mask;
            }
            else
            {
                return negate(x, (bool4)p);
            }
        }
    }
}