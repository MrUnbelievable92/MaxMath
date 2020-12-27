using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Negates the float value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float negate(float x, bool p)
        {
            return Sse.xor_ps(*(v128*)&x, new v128(touint32(p) << 31, 0, 0, 0)).Float0;
        }

        /// <summary>       Negates the components of a float2 vector if the value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 negate(float2 x, bool2 p)
        {
            uint2 sign = touint32(p) << 31;
            v128 result = Sse.xor_ps(*(v128*)&x, *(v128*)&sign);

            return *(float2*)&result;
        }

        /// <summary>       Negates the components of a float3 vector if the value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 negate(float3 x, bool3 p)
        {
            uint3 sign = touint32(p) << 31;
            v128 result = Sse.xor_ps(*(v128*)&x, *(v128*)&sign);

            return *(float3*)&result;
        }

        /// <summary>       Negates the components of a float4 vector if the value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 negate(float4 x, bool4 p)
        {
            uint4 sign = touint32(p) << 31;
            v128 result = Sse.xor_ps(*(v128*)&x, *(v128*)&sign);

            return *(float4*)&result;
        }

        /// <summary>       Negates the components of a float8 vector if the value of the corresponding bool8 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 negate(float8 x, bool8 p)
        {
            return Avx.mm256_xor_ps(x, touint32(p) << 31);
        }


        /// <summary>       Negates the double value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double negate(double x, bool p)
        {
            return Sse2.xor_pd(*(v128*)&x, new v128(touint64(p) << 63, 0)).Double0;
        }

        /// <summary>       Negates the components of a double2 vector if the value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 negate(double2 x, bool2 p)
        {
            ulong2 sign = touint64(p) << 63;
            v128 result = Sse2.xor_pd(*(v128*)&x, sign);

            return *(double2*)&result;
        }

        /// <summary>       Negates the components of a double3 vector if the value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 negate(double3 x, bool3 p)
        {
            ulong3 sign = touint64(p) << 63;
            v256 result = Avx.mm256_xor_pd(*(v256*)&x, sign);

            return *(double3*)&result;
        }

        /// <summary>       Negates the components of a double4 vector if the value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 negate(double4 x, bool4 p)
        {
            ulong4 sign = touint64(p) << 63;
            v256 result = Avx.mm256_xor_pd(*(v256*)&x, sign);

            return *(double4*)&result;
        }


        /// <summary>       Negates the components of an sbyte2 vector if the value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 negate(sbyte2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            sbyte2 mask = Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of an sbyte3 vector if the value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 negate(sbyte3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            sbyte3 mask = Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of an sbyte4 vector if the value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 negate(sbyte4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            sbyte4 mask = Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of an sbyte8 vector if the value of the corresponding bool8 vector is true.       </summary>
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

            sbyte8 mask = Sse2.cmpgt_epi8(p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of an sbyte16 vector if the value of the corresponding bool16 vector is true.       </summary>
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

            sbyte16 mask = Sse2.cmpgt_epi8(p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of an sbyte32 vector if the value of the corresponding bool32 vector is true.       </summary>
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

            sbyte32 mask = Avx2.mm256_cmpgt_epi8(p, default(v256));

            return (x ^ mask) - mask;
        }


        /// <summary>       Negates the components of a short2 vector if the value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 negate(short2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            short2 mask = (sbyte2)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of a short3 vector if the value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 negate(short3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            short3 mask = (sbyte3)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of a short4 vector if the value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 negate(short4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            short4 mask = (sbyte4)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of a short8 vector if the value of the corresponding bool8 vector is true.       </summary>
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

            short8 mask = (sbyte8)Sse2.cmpgt_epi8(p, default(v128));

            return (x ^ mask) - mask;
        }
        
        /// <summary>       Negates the components of a short16 vector if the value of the corresponding bool16 vector is true.       </summary>
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

            short16 mask = (sbyte16)Sse2.cmpgt_epi8(p, default(v128));

            return (x ^ mask) - mask;
        }


        /// <summary>       Negates the int value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int negate(int x, bool p)
        {
            int mask = toint8(p);

            return (x ^ -mask) + mask;
        }

        /// <summary>       Negates the components of an int2 vector if the value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 negate(int2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            int2 mask = (sbyte2)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of an int3 vector if the value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 negate(int3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            int3 mask = (sbyte3)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of an int4 vector if the value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 negate(int4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            int4 mask = (sbyte4)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of an int8 vector if the value of the corresponding bool8 vector is true.       </summary>
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

            int8 mask = (sbyte8)Sse2.cmpgt_epi8(p, default(v128));

            return (x ^ mask) - mask;
        }


        /// <summary>       Negates the long value if the supplied bool value is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long negate(long x, bool p)
        {
            long mask = toint8(p);

            return (x ^ -mask) + mask;
        }

        /// <summary>       Negates the components of a long2 vector if the value of the corresponding bool2 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 negate(long2 x, bool2 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);

            long2 mask = (sbyte2)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of a long3 vector if the value of the corresponding bool3 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 negate(long3 x, bool3 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);

            long3 mask = (sbyte3)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }

        /// <summary>       Negates the components of a long4 vector if the value of the corresponding bool4 vector is true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 negate(long4 x, bool4 p)
        {
Assert.IsSafeBoolean(p.x);
Assert.IsSafeBoolean(p.y);
Assert.IsSafeBoolean(p.z);
Assert.IsSafeBoolean(p.w);

            long4 mask = (sbyte4)Sse2.cmpgt_epi8(*(v128*)&p, default(v128));

            return (x ^ mask) - mask;
        }
    }
}