using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte divrem(byte dividend, byte divisor, out byte remainder)
        {
            byte quotient = (byte)Math.DivRem(dividend, divisor, out int rem);
            remainder = (byte)rem;

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 divrem(byte2 dividend, byte2 divisor, out byte2 remainder)
        {
            byte2 quotient = new byte2(divrem(dividend.x, divisor.x, out byte x0),
                                       divrem(dividend.y, divisor.y, out byte x1));

            remainder = new byte2(x0, x1);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 divrem(byte3 dividend, byte3 divisor, out byte3 remainder)
        {
            byte3 quotient = new byte3(divrem(dividend.x, divisor.x, out byte x0),
                                       divrem(dividend.y, divisor.y, out byte x1),
                                       divrem(dividend.z, divisor.z, out byte x2));

            remainder = new byte3(x0, x1, x2);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 divrem(byte4 dividend, byte4 divisor, out byte4 remainder)
        {
            byte4 quotient = new byte4(divrem(dividend.x, divisor.x, out byte x0),
                                       divrem(dividend.y, divisor.y, out byte x1),
                                       divrem(dividend.z, divisor.z, out byte x2),
                                       divrem(dividend.w, divisor.w, out byte x3));

            remainder = new byte4(x0, x1, x2, x3);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 divrem(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            byte8 quotient = new byte8(divrem(dividend.x0, divisor.x0, out byte x0),
                                       divrem(dividend.x1, divisor.x1, out byte x1),
                                       divrem(dividend.x2, divisor.x2, out byte x2),
                                       divrem(dividend.x3, divisor.x3, out byte x3),
                                       divrem(dividend.x4, divisor.x4, out byte x4),
                                       divrem(dividend.x5, divisor.x5, out byte x5),
                                       divrem(dividend.x6, divisor.x6, out byte x6),
                                       divrem(dividend.x7, divisor.x7, out byte x7));

            remainder = new byte8(x0, x1, x2, x3, x4, x5, x6, x7);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 divrem(byte16 dividend, byte16 divisor, out byte16 remainder)
        {
            return Operator.divrem_byte(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 divrem(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
            return Operator.divrem_byte(dividend, divisor, out remainder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte divrem(sbyte dividend, sbyte divisor, out sbyte remainder)
        {
            sbyte quotient = (sbyte)Math.DivRem(dividend, divisor, out int rem);
            remainder = (sbyte)rem;

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divrem(sbyte2 dividend, sbyte2 divisor, out sbyte2 remainder)
        {
            sbyte2 quotient = new sbyte2(divrem(dividend.x, divisor.x, out sbyte x0),
                                         divrem(dividend.y, divisor.y, out sbyte x1));

            remainder = new sbyte2(x0, x1);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divrem(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
            sbyte3 quotient = new sbyte3(divrem(dividend.x, divisor.x, out sbyte x0),
                                         divrem(dividend.y, divisor.y, out sbyte x1),
                                         divrem(dividend.z, divisor.z, out sbyte x2));

            remainder = new sbyte3(x0, x1, x2);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divrem(sbyte4 dividend, sbyte4 divisor, out sbyte4 remainder)
        {
            sbyte4 quotient = new sbyte4(divrem(dividend.x, divisor.x, out sbyte x0),
                                         divrem(dividend.y, divisor.y, out sbyte x1),
                                         divrem(dividend.z, divisor.z, out sbyte x2),
                                         divrem(dividend.w, divisor.w, out sbyte x3));

            remainder = new sbyte4(x0, x1, x2, x3);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divrem(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            sbyte8 quotient = new sbyte8(divrem(dividend.x0, divisor.x0, out sbyte x0),
                                         divrem(dividend.x1, divisor.x1, out sbyte x1),
                                         divrem(dividend.x2, divisor.x2, out sbyte x2),
                                         divrem(dividend.x3, divisor.x3, out sbyte x3),
                                         divrem(dividend.x4, divisor.x4, out sbyte x4),
                                         divrem(dividend.x5, divisor.x5, out sbyte x5),
                                         divrem(dividend.x6, divisor.x6, out sbyte x6),
                                         divrem(dividend.x7, divisor.x7, out sbyte x7));

            remainder = new sbyte8(x0, x1, x2, x3, x4, x5, x6, x7);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divrem(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            return Operator.divrem_byte(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divrem(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            return Operator.divrem_byte(dividend, divisor, out remainder);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort divrem(ushort dividend, ushort divisor, out ushort remainder)
        {
            ushort quotient = (ushort)Math.DivRem(dividend, divisor, out int rem);
            remainder = (ushort)rem;

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 divrem(ushort2 dividend, ushort2 divisor, out ushort2 remainder)
        {
            ushort2 quotient = new ushort2(divrem(dividend.x, divisor.x, out ushort x0),
                                           divrem(dividend.y, divisor.y, out ushort x1));

            remainder = new ushort2(x0, x1);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 divrem(ushort3 dividend, ushort3 divisor, out ushort3 remainder)
        {
            ushort3 quotient = new ushort3(divrem(dividend.x, divisor.x, out ushort x0),
                                           divrem(dividend.y, divisor.y, out ushort x1),
                                           divrem(dividend.z, divisor.z, out ushort x2));

            remainder = new ushort3(x0, x1, x2);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 divrem(ushort4 dividend, ushort4 divisor, out ushort4 remainder)
        {
            ushort4 quotient = new ushort4(divrem(dividend.x, divisor.x, out ushort x0),
                                           divrem(dividend.y, divisor.y, out ushort x1),
                                           divrem(dividend.z, divisor.z, out ushort x2),
                                           divrem(dividend.w, divisor.w, out ushort x3));

            remainder = new ushort4(x0, x1, x2, x3);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 divrem(ushort8 dividend, ushort8 divisor, out ushort8 remainder)
        {
            ushort8 quotient = new ushort8(divrem(dividend.x0, divisor.x0, out ushort x0),
                                           divrem(dividend.x1, divisor.x1, out ushort x1),
                                           divrem(dividend.x2, divisor.x2, out ushort x2),
                                           divrem(dividend.x3, divisor.x3, out ushort x3),
                                           divrem(dividend.x4, divisor.x4, out ushort x4),
                                           divrem(dividend.x5, divisor.x5, out ushort x5),
                                           divrem(dividend.x6, divisor.x6, out ushort x6),
                                           divrem(dividend.x7, divisor.x7, out ushort x7));

            remainder = new ushort8(x0, x1, x2, x3, x4, x5, x6, x7);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 divrem(ushort16 dividend, ushort16 divisor, out ushort16 remainder)
        {
            ushort16 quotient = new ushort16(divrem(dividend.x0,  divisor.x0,  out ushort x0),
                                           divrem(dividend.x1,  divisor.x1,  out ushort x1),
                                           divrem(dividend.x2,  divisor.x2,  out ushort x2),
                                           divrem(dividend.x3,  divisor.x3,  out ushort x3),
                                           divrem(dividend.x4,  divisor.x4,  out ushort x4),
                                           divrem(dividend.x5,  divisor.x5,  out ushort x5),
                                           divrem(dividend.x6,  divisor.x6,  out ushort x6),
                                           divrem(dividend.x7,  divisor.x7,  out ushort x7),
                                           divrem(dividend.x8,  divisor.x8,  out ushort x8),
                                           divrem(dividend.x9,  divisor.x9,  out ushort x9),
                                           divrem(dividend.x10, divisor.x10, out ushort x10),
                                           divrem(dividend.x11, divisor.x11, out ushort x11),
                                           divrem(dividend.x12, divisor.x12, out ushort x12),
                                           divrem(dividend.x13, divisor.x13, out ushort x13),
                                           divrem(dividend.x14, divisor.x14, out ushort x14),
                                           divrem(dividend.x15, divisor.x15, out ushort x15));

            remainder = new ushort16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

            return quotient;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short divrem(short dividend, short divisor, out short remainder)
        {
            short quotient = (short)Math.DivRem(dividend, divisor, out int rem);
            remainder = (short)rem;

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divrem(short2 dividend, short2 divisor, out short2 remainder)
        {
            short2 quotient = new short2(divrem(dividend.x, divisor.x, out short x0),
                                         divrem(dividend.y, divisor.y, out short x1));

            remainder = new short2(x0, x1);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divrem(short3 dividend, short3 divisor, out short3 remainder)
        {
            short3 quotient = new short3(divrem(dividend.x, divisor.x, out short x0),
                                         divrem(dividend.y, divisor.y, out short x1),
                                         divrem(dividend.z, divisor.z, out short x2));

            remainder = new short3(x0, x1, x2);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divrem(short4 dividend, short4 divisor, out short4 remainder)
        {
            short4 quotient = new short4(divrem(dividend.x, divisor.x, out short x0),
                                         divrem(dividend.y, divisor.y, out short x1),
                                         divrem(dividend.z, divisor.z, out short x2),
                                         divrem(dividend.w, divisor.w, out short x3));

            remainder = new short4(x0, x1, x2, x3);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divrem(short8 dividend, short8 divisor, out short8 remainder)
        {
            short8 quotient = new short8(divrem(dividend.x0, divisor.x0, out short x0),
                                         divrem(dividend.x1, divisor.x1, out short x1),
                                         divrem(dividend.x2, divisor.x2, out short x2),
                                         divrem(dividend.x3, divisor.x3, out short x3),
                                         divrem(dividend.x4, divisor.x4, out short x4),
                                         divrem(dividend.x5, divisor.x5, out short x5),
                                         divrem(dividend.x6, divisor.x6, out short x6),
                                         divrem(dividend.x7, divisor.x7, out short x7));

            remainder = new short8(x0, x1, x2, x3, x4, x5, x6, x7);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 divrem(short16 dividend, short16 divisor, out short16 remainder)
        {
            short16 quotient = new short16(divrem(dividend.x0,  divisor.x0,  out short x0),
                                           divrem(dividend.x1,  divisor.x1,  out short x1),
                                           divrem(dividend.x2,  divisor.x2,  out short x2),
                                           divrem(dividend.x3,  divisor.x3,  out short x3),
                                           divrem(dividend.x4,  divisor.x4,  out short x4),
                                           divrem(dividend.x5,  divisor.x5,  out short x5),
                                           divrem(dividend.x6,  divisor.x6,  out short x6),
                                           divrem(dividend.x7,  divisor.x7,  out short x7),
                                           divrem(dividend.x8,  divisor.x8,  out short x8),
                                           divrem(dividend.x9,  divisor.x9,  out short x9),
                                           divrem(dividend.x10, divisor.x10, out short x10),
                                           divrem(dividend.x11, divisor.x11, out short x11),
                                           divrem(dividend.x12, divisor.x12, out short x12),
                                           divrem(dividend.x13, divisor.x13, out short x13),
                                           divrem(dividend.x14, divisor.x14, out short x14),
                                           divrem(dividend.x15, divisor.x15, out short x15));

            remainder = new short16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);

            return quotient;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int divrem(int dividend, int divisor, out int remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 divrem(int2 dividend, int2 divisor, out int2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 divrem(int3 dividend, int3 divisor, out int3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 divrem(int4 dividend, int4 divisor, out int4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 divrem(int8 dividend, int8 divisor, out int8 remainder)
        {
            int8 quotient = new int8(divrem(dividend.x0, divisor.x0, out int x0),
                                     divrem(dividend.x1, divisor.x1, out int x1),
                                     divrem(dividend.x2, divisor.x2, out int x2),
                                     divrem(dividend.x3, divisor.x3, out int x3),
                                     divrem(dividend.x4, divisor.x4, out int x4),
                                     divrem(dividend.x5, divisor.x5, out int x5),
                                     divrem(dividend.x6, divisor.x6, out int x6),
                                     divrem(dividend.x7, divisor.x7, out int x7));

            remainder = new int8(x0, x1, x2, x3, x4, x5, x6, x7);

            return quotient;
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint divrem(uint dividend, uint divisor, out uint remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 divrem(uint2 dividend, uint2 divisor, out uint2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 divrem(uint3 dividend, uint3 divisor, out uint3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 divrem(uint4 dividend, uint4 divisor, out uint4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long divrem(long dividend, long divisor, out long remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, long2 divisor, out long2 remainder)
        {
            long2 quotient = new long2(divrem(dividend.x, divisor.x, out long x),
                                       divrem(dividend.y, divisor.y, out long y));

            remainder = new long2(x, y);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, long3 divisor, out long3 remainder)
        {
            long3 quotient = new long3(divrem(dividend.x, divisor.x, out long x),
                                       divrem(dividend.y, divisor.y, out long y),
                                       divrem(dividend.z, divisor.z, out long z));

            remainder = new long3(x, y, z);

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, long4 divisor, out long4 remainder)
        {
            long4 quotient = new long4(divrem(dividend.x, divisor.x, out long x),
                                       divrem(dividend.y, divisor.y, out long y),
                                       divrem(dividend.z, divisor.z, out long z),
                                       divrem(dividend.w, divisor.w, out long w));

            remainder = new long4(x, y, z, w);

            return quotient;
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong divrem(ulong dividend, ulong divisor, out ulong remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, ulong2 divisor, out ulong2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, ulong3 divisor, out ulong3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ulong4 divisor, out ulong4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }


        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float divrem(float dividend, float divisor, out float remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out float quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 divrem(float2 dividend, float2 divisor, out float2 remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out float2 quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 divrem(float3 dividend, float3 divisor, out float3 remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out float3 quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 divrem(float4 dividend, float4 divisor, out float4 remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out float4 quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 divrem(float8 dividend, float8 divisor, out float8 remainder)
        {
            remainder = divisor * modf(div(dividend, divisor), out float8 quotient);

            return quotient;
        }

        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        /// <summary>       Truncates quotient      <returns></returns>
        public static double divrem(double dividend, double divisor, out double remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out double quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 divrem(double2 dividend, double2 divisor, out double2 remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out double2 quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 divrem(double3 dividend, double3 divisor, out double3 remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out double3 quotient);

            return quotient;
        }

        /// <summary>       Truncates quotient      <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 divrem(double4 dividend, double4 divisor, out double4 remainder)
        {
            remainder = divisor * math.modf(div(dividend, divisor), out double4 quotient);

            return quotient;
        }
    }
}