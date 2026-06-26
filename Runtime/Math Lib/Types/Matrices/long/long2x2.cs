using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct long2x2 : IEquatable<long2x2>, IFormattable
    {
        public long2 c0;
        public long2 c1;
        

        public static long2x2 identity => new long2x2(1, 0,   0, 1);
        public static long2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long2 c0, long2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long m00, long m01,
                       long m10, long m11)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(bool v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(bool2x2 v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(mask8x2x2 v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(mask16x2x2 v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(mask32x2x2 v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(mask64x2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(byte v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(byte2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(sbyte v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(sbyte2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(ushort v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(ushort2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(short v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(short2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(uint v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(uint2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(int v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(int2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(ulong v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(ulong2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(UInt128 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Int128 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(quarter v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(half v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(float v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(float2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(double v)
        {
            this = (long2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(double2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(quadruple v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Unity.Mathematics.int2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Unity.Mathematics.half v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Unity.Mathematics.float2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(Unity.Mathematics.double2x2 v)
        {
            this = (long2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x2(long2x2 v) => new bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(Unity.Mathematics.bool2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x2(long2x2 v) => new Unity.Mathematics.bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(Unity.Mathematics.int2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x2(long2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(Unity.Mathematics.uint2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(long2x2 v) => new uint2x2 { c0 = (uint2)v.c0, c1 = (uint2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(Unity.Mathematics.half v) => (long2x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(Unity.Mathematics.float2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x2(long2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(Unity.Mathematics.double2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x2(long2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(long v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(bool v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(bool2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x2(sbyte v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(sbyte2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x2(short v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(short2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(int v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(int2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x2(byte v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(byte2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x2(ushort v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(ushort2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(uint v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(uint2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(ulong v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(ulong2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(half v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(float v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(float2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(double v) => new long2x2 { c0 = (long2)v, c1 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(double2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(mask8x2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(mask16x2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(mask32x2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(mask64x2x2 v) => new long2x2 { c0 = (long2)v.c0, c1 = (long2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x2(long2x2 v) => new mask8x2x2 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(long2x2 v) => new mask16x2x2 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x2(long2x2 v) => new mask32x2x2 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x2(long2x2 v) => new mask64x2x2 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 val) => new long2x2 { c0 = -val.c0, c1 = -val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ++ (long2x2 val) => new long2x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator -- (long2x2 val) => new long2x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, byte2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, byte2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, byte2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, byte2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, byte2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, sbyte2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, sbyte2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, sbyte2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, sbyte2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, sbyte2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, short2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, short2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, short2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, short2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, short2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (short2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (short2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (short2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (short2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (short2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, ushort2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, ushort2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, ushort2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, ushort2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, ushort2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, int2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, int2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, int2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, int2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, int2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (int2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (int2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (int2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (int2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (int2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, uint2x2 rhs) => new long2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, uint2x2 rhs) => new long2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, uint2x2 rhs) => new long2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, uint2x2 rhs) => new long2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, uint2x2 rhs) => new long2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs + (uint2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs - (uint2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs * (uint2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs / (uint2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs % (uint2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs % (float2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs % (double2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, byte rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (byte lhs, long2x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, byte rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (byte lhs, long2x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, byte rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (byte lhs, long2x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, byte rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (byte lhs, long2x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, byte rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (byte lhs, long2x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, sbyte rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (sbyte lhs, long2x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, sbyte rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (sbyte lhs, long2x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, sbyte rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (sbyte lhs, long2x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, sbyte rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (sbyte lhs, long2x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, sbyte rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (sbyte lhs, long2x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, short rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (short lhs, long2x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, short rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (short lhs, long2x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, short rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (short lhs, long2x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, short rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (short lhs, long2x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, short rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (short lhs, long2x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, ushort rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (ushort lhs, long2x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, ushort rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (ushort lhs, long2x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, ushort rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (ushort lhs, long2x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, ushort rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (ushort lhs, long2x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, ushort rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (ushort lhs, long2x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, int rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (int lhs, long2x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, int rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (int lhs, long2x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, int rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (int lhs, long2x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, int rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (int lhs, long2x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, int rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (int lhs, long2x2 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 lhs, uint rhs) => new long2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (uint lhs, long2x2 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 lhs, uint rhs) => new long2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (uint lhs, long2x2 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 lhs, uint rhs) => new long2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (uint lhs, long2x2 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 lhs, uint rhs) => new long2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (uint lhs, long2x2 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 lhs, uint rhs) => new long2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (uint lhs, long2x2 rhs) => (long)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ~ (long2x2 val) => new long2x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator << (long2x2 val, int n) => new long2x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator >> (long2x2 val, int n) => new long2x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, long2x2 rhs) => new long2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, long rhs) => new long2x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long lhs, long2x2 rhs) => new long2x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, byte2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, byte2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, byte2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, sbyte2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, sbyte2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, sbyte2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, short2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, short2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, short2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (short2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (short2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (short2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, ushort2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, ushort2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, ushort2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, int2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, int2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, int2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (int2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (int2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (int2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, uint2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, uint2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, uint2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs & (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs | (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs ^ (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, byte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (byte lhs, long2x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, byte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (byte lhs, long2x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, byte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (byte lhs, long2x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, sbyte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (sbyte lhs, long2x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, sbyte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (sbyte lhs, long2x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, sbyte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (sbyte lhs, long2x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, short rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (short lhs, long2x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, short rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (short lhs, long2x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, short rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (short lhs, long2x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, ushort rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (ushort lhs, long2x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, ushort rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (ushort lhs, long2x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, ushort rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (ushort lhs, long2x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, int rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (int lhs, long2x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, int rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (int lhs, long2x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, int rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (int lhs, long2x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 lhs, uint rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (uint lhs, long2x2 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 lhs, uint rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (uint lhs, long2x2 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 lhs, uint rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (uint lhs, long2x2 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, long rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, long rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, long rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, long rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, long rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, long rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long lhs, long2x2 rhs) => new mask64x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, byte2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, byte2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, byte2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, byte2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, byte2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, byte2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (byte2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, sbyte2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, sbyte2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, sbyte2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, sbyte2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, sbyte2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, sbyte2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (sbyte2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, short2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, short2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, short2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, short2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, short2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, short2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (short2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (short2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (short2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (short2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (short2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (short2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, ushort2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, ushort2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, ushort2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, ushort2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, ushort2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, ushort2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (ushort2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, int2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, int2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, int2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, int2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, int2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, int2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (int2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (int2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (int2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (int2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (int2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (int2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, uint2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, uint2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, uint2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, uint2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, uint2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, uint2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (uint2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.int2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs == (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs != (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs < (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs > (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs <= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs >= (long2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.uint2x2 lhs, long2x2 rhs) => (long2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (long2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs >= (float2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.float2x2 lhs, long2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs >= (double2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.double2x2 lhs, long2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, byte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (byte lhs, long2x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, byte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (byte lhs, long2x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, byte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (byte lhs, long2x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, byte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (byte lhs, long2x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, byte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (byte lhs, long2x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, byte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (byte lhs, long2x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, sbyte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (sbyte lhs, long2x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, sbyte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (sbyte lhs, long2x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, sbyte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (sbyte lhs, long2x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, sbyte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (sbyte lhs, long2x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, sbyte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (sbyte lhs, long2x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, sbyte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (sbyte lhs, long2x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, short rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (short lhs, long2x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, short rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (short lhs, long2x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, short rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (short lhs, long2x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, short rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (short lhs, long2x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, short rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (short lhs, long2x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, short rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (short lhs, long2x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, ushort rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (ushort lhs, long2x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, ushort rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (ushort lhs, long2x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, ushort rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (ushort lhs, long2x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, ushort rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (ushort lhs, long2x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, ushort rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (ushort lhs, long2x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, ushort rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (ushort lhs, long2x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, int rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (int lhs, long2x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, int rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (int lhs, long2x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, int rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (int lhs, long2x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, int rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (int lhs, long2x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, int rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (int lhs, long2x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, int rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (int lhs, long2x2 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, uint rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (uint lhs, long2x2 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, uint rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (uint lhs, long2x2 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, uint rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (uint lhs, long2x2 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, uint rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (uint lhs, long2x2 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, uint rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (uint lhs, long2x2 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, uint rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (uint lhs, long2x2 rhs) => (long)lhs >= rhs;


        public ref long2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (long2x2* array = &this) { return ref ((long2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is long2x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"long2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}