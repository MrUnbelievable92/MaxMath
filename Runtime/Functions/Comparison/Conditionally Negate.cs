using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Negates the <see cref="Int128"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 negate(Int128 x, bool p)
        {
            ulong sign64 = (ulong)(-tolong(p));

            ulong lo = x.intern.lo ^ sign64;
            ulong hi = x.intern.hi ^ sign64;

            lo -= sign64;
            hi -= sign64;
            hi -= tobyte(lo < sign64); 
            
            return new Int128(lo, hi);
        }


        /// <summary>       Negates the <see cref="quarter"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter negate(quarter x, bool p)
        {
Assert.IsSafeBoolean(p);

            return asquarter((byte)(asbyte(x) ^ (tobyte(p) << 7)));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 negate(quarter2 x, bool2 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 negate(quarter3 x, bool3 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 negate(quarter4 x, bool4 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.quarter8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 negate(quarter8 x, bool8 p)
        {
            return asquarter(asbyte(x) ^ (tobyte(p) << 7));
        }
        
        
        /// <summary>       Negates the <see cref="half"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half negate(half x, bool p)
        {
Assert.IsSafeBoolean(p);

            return ashalf((ushort)(asushort(x) ^ (toushort(p) << 15)));
        }

        /// <summary>       Negates the components of a <see cref="half2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 negate(half2 x, bool2 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="half3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 negate(half3 x, bool3 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="half4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 negate(half4 x, bool4 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.half8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 negate(half8 x, bool8 p)
        {
            return ashalf(asushort(x) ^ (toushort(p) << 15));
        }
        
        
        /// <summary>       Negates the <see cref="float"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float negate(float x, bool p)
        {
Assert.IsSafeBoolean(p);

            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="float2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="float3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="float4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            return math.asfloat(math.asuint(x) ^ (touint(p) << 31));
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.float8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, bool8 p)
        {
            return asfloat(asuint(x) ^ (touint(p) << 31));
        }


        /// <summary>       Negates the <see cref="double"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double negate(double x, bool p)
        {
Assert.IsSafeBoolean(p);

            return math.asdouble(math.asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="double2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="double3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        /// <summary>       Negates the components of a <see cref="double4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, bool4 p)
        {
            return asdouble(asulong(x) ^ (toulong(p) << 63));
        }

        
        /// <summary>       Negates the <see cref="sbyte"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte negate(sbyte x, bool p)
        {
Assert.IsSafeBoolean(p);

            int mask = tobyte(p);

            return (sbyte)((x ^ -mask) + mask);
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            if (Sse2.IsSse2Supported)
            {
                sbyte2 mask = Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                sbyte2 mask = tosbyte(p);

                return (x ^ -mask) + mask;
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            if (Sse2.IsSse2Supported)
            {
                sbyte3 mask = Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                sbyte3 mask = tosbyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            if (Sse2.IsSse2Supported)
            {
                sbyte4 mask = Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                sbyte4 mask = tosbyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 negate(sbyte8 x, bool8 p)
        {
Assert.IsSafeBoolean(p.x0);
Assert.IsSafeBoolean(p.x1);
Assert.IsSafeBoolean(p.x2);
Assert.IsSafeBoolean(p.x3);
Assert.IsSafeBoolean(p.x4);
Assert.IsSafeBoolean(p.x5);
Assert.IsSafeBoolean(p.x6);
Assert.IsSafeBoolean(p.x7);

            if (Sse2.IsSse2Supported)
            {
                sbyte8 mask = Sse2.cmpgt_epi8(p, default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                sbyte8 mask = tosbyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 negate(sbyte16 x, bool16 p)
        {
Assert.IsSafeBoolean(p.x0);
Assert.IsSafeBoolean(p.x1);
Assert.IsSafeBoolean(p.x2);
Assert.IsSafeBoolean(p.x3);
Assert.IsSafeBoolean(p.x4);
Assert.IsSafeBoolean(p.x5);
Assert.IsSafeBoolean(p.x6);
Assert.IsSafeBoolean(p.x7);
Assert.IsSafeBoolean(p.x8);
Assert.IsSafeBoolean(p.x9);
Assert.IsSafeBoolean(p.x10);
Assert.IsSafeBoolean(p.x11);
Assert.IsSafeBoolean(p.x12);
Assert.IsSafeBoolean(p.x13);
Assert.IsSafeBoolean(p.x14);
Assert.IsSafeBoolean(p.x15);

            if (Sse2.IsSse2Supported)
            {
                sbyte16 mask = Sse2.cmpgt_epi8(p, default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                sbyte16 mask = tosbyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of an <see cref="MaxMath.sbyte32"/> if the corresponding value in the <see cref="MaxMath.bool32"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 negate(sbyte32 x, bool32 p)
        {
Assert.IsSafeBoolean(p.x0);
Assert.IsSafeBoolean(p.x1);
Assert.IsSafeBoolean(p.x2);
Assert.IsSafeBoolean(p.x3);
Assert.IsSafeBoolean(p.x4);
Assert.IsSafeBoolean(p.x5);
Assert.IsSafeBoolean(p.x6);
Assert.IsSafeBoolean(p.x7);
Assert.IsSafeBoolean(p.x8);
Assert.IsSafeBoolean(p.x9);
Assert.IsSafeBoolean(p.x10);
Assert.IsSafeBoolean(p.x11);
Assert.IsSafeBoolean(p.x12);
Assert.IsSafeBoolean(p.x13);
Assert.IsSafeBoolean(p.x14);
Assert.IsSafeBoolean(p.x15);
Assert.IsSafeBoolean(p.x16);
Assert.IsSafeBoolean(p.x17);
Assert.IsSafeBoolean(p.x18);
Assert.IsSafeBoolean(p.x19);
Assert.IsSafeBoolean(p.x20);
Assert.IsSafeBoolean(p.x21);
Assert.IsSafeBoolean(p.x22);
Assert.IsSafeBoolean(p.x23);
Assert.IsSafeBoolean(p.x24);
Assert.IsSafeBoolean(p.x25);
Assert.IsSafeBoolean(p.x26);
Assert.IsSafeBoolean(p.x27);
Assert.IsSafeBoolean(p.x28);
Assert.IsSafeBoolean(p.x29);
Assert.IsSafeBoolean(p.x30);
Assert.IsSafeBoolean(p.x31);

            if (Avx2.IsAvx2Supported)
            {
                sbyte32 mask = Avx2.mm256_cmpgt_epi8(p, default(v256));

                return (x ^ mask) - mask;
            }
            else
            {
                return new sbyte32(negate(x.v16_0, p.v16_0), negate(x.v16_16, p.v16_16)); ;
            }
        }


        
        /// <summary>       Negates the <see cref="short"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short negate(short x, bool p)
        {
Assert.IsSafeBoolean(p);

            int mask = tobyte(p);

            return (short)((x ^ -mask) + mask);
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            if (Sse2.IsSse2Supported)
            {
                short2 mask = (sbyte2)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                short2 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.short3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            if (Sse2.IsSse2Supported)
            {
                short3 mask = (sbyte3)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                short3 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of a <see cref="MaxMath.short4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            if (Sse2.IsSse2Supported)
            {
                short4 mask = (sbyte4)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                short4 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of a <see cref="MaxMath.short8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 negate(short8 x, bool8 p)
        {
Assert.IsSafeBoolean(p.x0);
Assert.IsSafeBoolean(p.x1);
Assert.IsSafeBoolean(p.x2);
Assert.IsSafeBoolean(p.x3);
Assert.IsSafeBoolean(p.x4);
Assert.IsSafeBoolean(p.x5);
Assert.IsSafeBoolean(p.x6);
Assert.IsSafeBoolean(p.x7);

            if (Sse2.IsSse2Supported)
            {
                short8 mask = (sbyte8)Sse2.cmpgt_epi8(p, default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                short8 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }
        
        /// <summary>       Negates the components of a <see cref="MaxMath.short16"/> if the corresponding value in the <see cref="MaxMath.bool16"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 negate(short16 x, bool16 p)
        {
Assert.IsSafeBoolean(p.x0);
Assert.IsSafeBoolean(p.x1);
Assert.IsSafeBoolean(p.x2);
Assert.IsSafeBoolean(p.x3);
Assert.IsSafeBoolean(p.x4);
Assert.IsSafeBoolean(p.x5);
Assert.IsSafeBoolean(p.x6);
Assert.IsSafeBoolean(p.x7);
Assert.IsSafeBoolean(p.x8);
Assert.IsSafeBoolean(p.x9);
Assert.IsSafeBoolean(p.x10);
Assert.IsSafeBoolean(p.x11);
Assert.IsSafeBoolean(p.x12);
Assert.IsSafeBoolean(p.x13);
Assert.IsSafeBoolean(p.x14);
Assert.IsSafeBoolean(p.x15);

            if (Avx2.IsAvx2Supported)
            {
                short16 mask = (sbyte16)Sse2.cmpgt_epi8(p, default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                return new short16(negate(x.v8_0, p.v8_0), negate(x.v8_8, p.v8_8));
            }
        }


        /// <summary>       Negates the <see cref="int"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int negate(int x, bool p)
        {
Assert.IsSafeBoolean(p);

            int mask = tobyte(p);

            return (x ^ -mask) + mask;
        }

        /// <summary>       Negates the components of an <see cref="int2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            if (Sse2.IsSse2Supported)
            {
                int2 mask = (sbyte2)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                int2 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }

        /// <summary>       Negates the components of an <see cref="int3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            if (Sse2.IsSse2Supported)
            {
                int3 mask = (sbyte3)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                int3 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }

        /// <summary>       Negates the components of an <see cref="int4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            if (Sse2.IsSse2Supported)
            {
                int4 mask = (sbyte4)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                int4 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }

        /// <summary>       Negates the components of an <see cref="MaxMath.int8"/> if the corresponding value in the <see cref="MaxMath.bool8"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 negate(int8 x, bool8 p)
        {
Assert.IsSafeBoolean(p.x0);
Assert.IsSafeBoolean(p.x1);
Assert.IsSafeBoolean(p.x2);
Assert.IsSafeBoolean(p.x3);
Assert.IsSafeBoolean(p.x4);
Assert.IsSafeBoolean(p.x5);
Assert.IsSafeBoolean(p.x6);
Assert.IsSafeBoolean(p.x7);

            if (Avx2.IsAvx2Supported)
            {
                int8 mask = (sbyte8)Sse2.cmpgt_epi8(p, default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                return new int8(negate(x.v4_0, p.v4_0), negate(x.v4_4, p.v4_4));
            }
        }


        /// <summary>       Negates the <see cref="long"/> <paramref name="x"/> if the <see cref="bool"/> <paramref name="p"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long negate(long x, bool p)
        {
Assert.IsSafeBoolean(p);

            long mask = tobyte(p);

            return (x ^ -mask) + mask;
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long2"/> if the corresponding value in the <see cref="bool2"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            if (Sse2.IsSse2Supported)
            {
                long2 mask = (sbyte2)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                long2 mask = tobyte(p);

                return (x ^ -mask) + mask;
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long3"/> if the corresponding value in the <see cref="bool3"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            if (Avx2.IsAvx2Supported)
            {
                long3 mask = (sbyte3)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                return new long3(negate(x.xy, p.xy), negate(x.z, p.z));
            }
        }

        /// <summary>       Negates the components of a <see cref="MaxMath.long4"/> if the corresponding value in the <see cref="bool4"/> is <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            if (Avx2.IsAvx2Supported)
            {
                long4 mask = (sbyte4)Sse2.cmpgt_epi8(UnityMathematicsLink.Tov128(p), default(v128));

                return (x ^ mask) - mask;
            }
            else
            {
                return new long4(negate(x.xy, p.xy), negate(x.zw, p.zw));
            }
        }
    }
}