using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the quotient of the first byte divided by the second byte with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte divrem(byte dividend, byte divisor, out byte remainder)
        {
            byte quotient = (byte)Math.DivRem(dividend, divisor, out int rem);
            remainder = (byte)rem;

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first byte2 vector by the second byte2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 divrem(byte2 dividend, byte2 divisor, out byte2 remainder)
        {
            remainder = default(v128);

            return new byte2(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first byte3 vector by the second byte3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 divrem(byte3 dividend, byte3 divisor, out byte3 remainder)
        {
            remainder = default(v128);

            return new byte3(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y),
                             divrem(dividend.z, divisor.z, out remainder.z));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first byte4 vector by the second byte4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 divrem(byte4 dividend, byte4 divisor, out byte4 remainder)
        {
            remainder = default(v128);

            return new byte4(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y),
                             divrem(dividend.z, divisor.z, out remainder.z),
                             divrem(dividend.w, divisor.w, out remainder.w));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first byte8 vector by the second byte8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 divrem(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            byte8 quotient = (v128)Operator.vdivrem_byte((v128)dividend, (v128)divisor, out byte16 remainders);

            remainder = (v128)remainders;

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first byte16 vector by the second byte16 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 divrem(byte16 dividend, byte16 divisor, out byte16 remainder)
        {
            return Operator.vdivrem_byte(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the first byte32 vector by the second byte32 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 divrem(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
            return Operator.vdivrem_byte(dividend, divisor, out remainder);
        }


        /// <summary>       Returns the quotient of the first sbyte divided by the second sbyte with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte divrem(sbyte dividend, sbyte divisor, out sbyte remainder)
        {
            sbyte quotient = (sbyte)Math.DivRem(dividend, divisor, out int rem);
            remainder = (sbyte)rem;

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first sbyte2 vector by the second sbyte2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divrem(sbyte2 dividend, sbyte2 divisor, out sbyte2 remainder)
        {
            remainder = default(v128);                              

            return new sbyte2(divrem(dividend.x, divisor.x, out remainder.x),
                              divrem(dividend.y, divisor.y, out remainder.y));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first sbyte3 vector by the second sbyte3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divrem(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
            remainder = default(v128);

            return new sbyte3(divrem(dividend.x, divisor.x, out remainder.x),
                              divrem(dividend.y, divisor.y, out remainder.y),
                              divrem(dividend.z, divisor.z, out remainder.z));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first sbyte4 vector by the second sbyte4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divrem(sbyte4 dividend, sbyte4 divisor, out sbyte4 remainder)
        {
            remainder = default(v128);

            return new sbyte4(divrem(dividend.x, divisor.x, out remainder.x),
                              divrem(dividend.y, divisor.y, out remainder.y),
                              divrem(dividend.z, divisor.z, out remainder.z),
                              divrem(dividend.w, divisor.w, out remainder.w));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first sbyte8 vector by the second sbyte8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divrem(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            sbyte8 quotient = (v128)Operator.vdivrem_sbyte((v128)dividend, (v128)divisor, out sbyte16 remainders);

            remainder = (v128)remainders;

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first sbyte16 vector by the second sbyte16 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divrem(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the first sbyte32 vector by the second sbyte32 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divrem(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
        }


        /// <summary>       Returns the quotient of the first ushort divided by the second ushort with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort divrem(ushort dividend, ushort divisor, out ushort remainder)
        {
            ushort quotient = (ushort)Math.DivRem(dividend, divisor, out int rem);
            remainder = (ushort)rem;

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ushort2 vector by the second ushort2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 divrem(ushort2 dividend, ushort2 divisor, out ushort2 remainder)
        {
            remainder = default(v128);

            return new ushort2(divrem(dividend.x, divisor.x, out remainder.x),
                               divrem(dividend.y, divisor.y, out remainder.y));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ushort3 vector by the second ushort3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 divrem(ushort3 dividend, ushort3 divisor, out ushort3 remainder)
        {
            remainder = default(v128);

            return new ushort3(divrem(dividend.x, divisor.x, out remainder.x),
                               divrem(dividend.y, divisor.y, out remainder.y),
                               divrem(dividend.z, divisor.z, out remainder.z));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ushort4 vector by the second ushort4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 divrem(ushort4 dividend, ushort4 divisor, out ushort4 remainder)
        {
            remainder = default(v128);

            return new ushort4(divrem(dividend.x, divisor.x, out remainder.x),
                               divrem(dividend.y, divisor.y, out remainder.y),
                               divrem(dividend.z, divisor.z, out remainder.z),
                               divrem(dividend.w, divisor.w, out remainder.w));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ushort8 vector by the second ushort8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 divrem(ushort8 dividend, ushort8 divisor, out ushort8 remainder)
        {
            remainder = default(v128);

            return new ushort8(divrem(dividend.x0, divisor.x0, out remainder.x0),
                               divrem(dividend.x1, divisor.x1, out remainder.x1),
                               divrem(dividend.x2, divisor.x2, out remainder.x2),
                               divrem(dividend.x3, divisor.x3, out remainder.x3),
                               divrem(dividend.x4, divisor.x4, out remainder.x4),
                               divrem(dividend.x5, divisor.x5, out remainder.x5),
                               divrem(dividend.x6, divisor.x6, out remainder.x6),
                               divrem(dividend.x7, divisor.x7, out remainder.x7));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ushort16 vector by the second ushort16 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 divrem(ushort16 dividend, ushort16 divisor, out ushort16 remainder)
        {
            return Operator.vdivrem_ushort(dividend, divisor, out remainder);
        }


        /// <summary>       Returns the quotient of the first short divided by the second short with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short divrem(short dividend, short divisor, out short remainder)
        {
            short quotient = (short)Math.DivRem(dividend, divisor, out int rem);
            remainder = (short)rem;

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first short2 vector by the second short2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divrem(short2 dividend, short2 divisor, out short2 remainder)
        {
            remainder = default(v128);

            return new short2(divrem(dividend.x, divisor.x, out remainder.x),
                              divrem(dividend.y, divisor.y, out remainder.y));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first short3 vector by the second short3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divrem(short3 dividend, short3 divisor, out short3 remainder)
        {
            remainder = default(v128);

            return new short3(divrem(dividend.x, divisor.x, out remainder.x),
                              divrem(dividend.y, divisor.y, out remainder.y),
                              divrem(dividend.z, divisor.z, out remainder.z));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first short4 vector by the second short4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divrem(short4 dividend, short4 divisor, out short4 remainder)
        {
            remainder = default(v128);

            return new short4(divrem(dividend.x, divisor.x, out remainder.x),
                              divrem(dividend.y, divisor.y, out remainder.y),
                              divrem(dividend.z, divisor.z, out remainder.z),
                              divrem(dividend.w, divisor.w, out remainder.w));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first short8 vector by the second short8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divrem(short8 dividend, short8 divisor, out short8 remainder)
        {
            remainder = default(v128);

            return new short8(divrem(dividend.x0, divisor.x0, out remainder.x0),
                              divrem(dividend.x1, divisor.x1, out remainder.x1),
                              divrem(dividend.x2, divisor.x2, out remainder.x2),
                              divrem(dividend.x3, divisor.x3, out remainder.x3),
                              divrem(dividend.x4, divisor.x4, out remainder.x4),
                              divrem(dividend.x5, divisor.x5, out remainder.x5),
                              divrem(dividend.x6, divisor.x6, out remainder.x6),
                              divrem(dividend.x7, divisor.x7, out remainder.x7));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first short16 vector by the second short16 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 divrem(short16 dividend, short16 divisor, out short16 remainder)
        {
            return Operator.vdivrem_short(dividend, divisor, out remainder);
        }


        /// <summary>       Returns the quotient of the first int divided by the second int with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int divrem(int dividend, int divisor, out int remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the first int2 vector by the second int2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 divrem(int2 dividend, int2 divisor, out int2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first int3 vector by the second int3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 divrem(int3 dividend, int3 divisor, out int3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first int4 vector by the second int4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 divrem(int4 dividend, int4 divisor, out int4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first int8 vector by the second int8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 divrem(int8 dividend, int8 divisor, out int8 remainder)
        {
            remainder = default(v256);

            return new int8(divrem(dividend.x0, divisor.x0, out remainder.x0),
                            divrem(dividend.x1, divisor.x1, out remainder.x1),
                            divrem(dividend.x2, divisor.x2, out remainder.x2),
                            divrem(dividend.x3, divisor.x3, out remainder.x3),
                            divrem(dividend.x4, divisor.x4, out remainder.x4),
                            divrem(dividend.x5, divisor.x5, out remainder.x5),
                            divrem(dividend.x6, divisor.x6, out remainder.x6),
                            divrem(dividend.x7, divisor.x7, out remainder.x7));
        }



        /// <summary>       Returns the quotient of the first uint divided by the second uint with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint divrem(uint dividend, uint divisor, out uint remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first uint2 vector by the second uint2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 divrem(uint2 dividend, uint2 divisor, out uint2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first uint3 vector by the second uint3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 divrem(uint3 dividend, uint3 divisor, out uint3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first uint4 vector by the second uint4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 divrem(uint4 dividend, uint4 divisor, out uint4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first uint8 vector by the second uint8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 divrem(uint8 dividend, uint8 divisor, out uint8 remainder)
        {
            uint8 quotient = new uint8((uint)divrem((long)dividend.x0, (long)divisor.x0, out long x0),
                                       (uint)divrem((long)dividend.x1, (long)divisor.x1, out long x1),
                                       (uint)divrem((long)dividend.x2, (long)divisor.x2, out long x2),
                                       (uint)divrem((long)dividend.x3, (long)divisor.x3, out long x3),
                                       (uint)divrem((long)dividend.x4, (long)divisor.x4, out long x4),
                                       (uint)divrem((long)dividend.x5, (long)divisor.x5, out long x5),
                                       (uint)divrem((long)dividend.x6, (long)divisor.x6, out long x6),
                                       (uint)divrem((long)dividend.x7, (long)divisor.x7, out long x7));

            remainder = new uint8((uint)x0, (uint)x1, (uint)x2, (uint)x3, (uint)x4, (uint)x5, (uint)x6, (uint)x7);

            return quotient;
        }


        /// <summary>       Returns the quotient of the first long divided by the second long with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long divrem(long dividend, long divisor, out long remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the first long2 vector by the second long2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, long2 divisor, out long2 remainder)
        {
            remainder = default(v128);

            return new long2(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first long3 vector by the second long3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, long3 divisor, out long3 remainder)
        {
            remainder = default(v256);

            return new long3(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y),
                             divrem(dividend.z, divisor.z, out remainder.z));
        }

        /// <summary>       Returns the quotients of the componentwise division of the first long4 vector by the second long4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, long4 divisor, out long4 remainder)
        {
            remainder = default(v256);

            return new long4(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y),
                             divrem(dividend.z, divisor.z, out remainder.z),
                             divrem(dividend.w, divisor.w, out remainder.w));
        }


        /// <summary>       Returns the quotient of the first ulong divided by the second ulong with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong divrem(ulong dividend, ulong divisor, out ulong remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ulong2 vector by the second ulong2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, ulong2 divisor, out ulong2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ulong3 vector by the second ulong3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, ulong3 divisor, out ulong3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the first ulong4 vector by the second ulong4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ulong4 divisor, out ulong4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }


        /// <summary>       Returns the truncated quotient of the first float divided by the second float with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float divrem(float dividend, float divisor, out float remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor), out float quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first float2 vector by the second float2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 divrem(float2 dividend, float2 divisor, out float2 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor), out float2 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float2 quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first float3 vector by the second float3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 divrem(float3 dividend, float3 divisor, out float3 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor), out float3 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float3 quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first float4 vector by the second float4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 divrem(float4 dividend, float4 divisor, out float4 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor), out float4 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float4 quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first float8 vector by the second float8 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 divrem(float8 dividend, float8 divisor, out float8 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * modf(div(dividend, divisor), out float8 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * modf(dividend / divisor, out float8 quotient);

                return quotient;
            }
        }


        /// <summary>       Returns the truncated quotient of the first double divided by the second double with the remainder as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double divrem(double dividend, double divisor, out double remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first double2 vector by the second double2 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 divrem(double2 dividend, double2 divisor, out double2 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double2 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first double3 vector by the second double3 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 divrem(double3 dividend, double3 divisor, out double3 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double3 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the first double4 vector by the second double4 vector with the remainders as an out parameter.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 divrem(double4 dividend, double4 divisor, out double4 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double4 quotient);

            return quotient;
        }
    }
}