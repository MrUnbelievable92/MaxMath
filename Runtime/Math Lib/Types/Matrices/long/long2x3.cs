using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct long2x3 : IEquatable<long2x3>, IFormattable
    {
        public long2 c0;
        public long2 c1;
        public long2 c2;

        public static long2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long2 c0, long2 c1, long2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long m00, long m01, long m02,
                       long m10, long m11, long m12)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
            this.c2 = new long2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(bool v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(bool2x3 v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(mask8x2x3 v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(mask16x2x3 v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(mask32x2x3 v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(mask64x2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(byte v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(byte2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(sbyte v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(sbyte2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(ushort v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(ushort2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(short v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(short2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(uint v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(uint2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(int v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(int2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(ulong v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(ulong2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(UInt128 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Int128 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(quarter v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(half v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(float v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(float2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(double v)
        {
            this = (long2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(double2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(quadruple v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Unity.Mathematics.int2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Unity.Mathematics.half v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Unity.Mathematics.float2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(Unity.Mathematics.double2x3 v)
        {
            this = (long2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(long2x3 v) => new bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(Unity.Mathematics.bool2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x3(long2x3 v) => new Unity.Mathematics.bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(Unity.Mathematics.int2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x3(long2x3 v) => new int2x3 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(Unity.Mathematics.uint2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x3(long2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(Unity.Mathematics.half v) => (long2x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(Unity.Mathematics.float2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x3(long2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(Unity.Mathematics.double2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x3(long2x3 v) => new double2x3 { c0 = (double2)v.c0, c1 = (double2)v.c1, c2 = (double2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(long v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(bool v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(bool2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x3(sbyte v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(sbyte2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x3(short v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(short2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(int v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(int2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x3(byte v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(byte2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x3(ushort v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(ushort2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(uint v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(uint2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(ulong v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(ulong2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(half v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(float v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(float2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(double v) => new long2x3 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(double2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(mask8x2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(mask16x2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(mask32x2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(mask64x2x3 v) => new long2x3 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x3(long2x3 v) => new mask8x2x3 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x3(long2x3 v) => new mask16x2x3 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(long2x3 v) => new mask32x2x3 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x3(long2x3 v) => new mask64x2x3 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 val) => new long2x3 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ++ (long2x3 val) => new long2x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator -- (long2x3 val) => new long2x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, byte2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, byte2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, byte2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, byte2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, byte2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, sbyte2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, sbyte2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, sbyte2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, sbyte2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, sbyte2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, short2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, short2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, short2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, short2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, short2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (short2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (short2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (short2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (short2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (short2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, ushort2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, ushort2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, ushort2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, ushort2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, ushort2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, int2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, int2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, int2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, int2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, int2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (int2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (int2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (int2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (int2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (int2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, uint2x3 rhs) => new long2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, uint2x3 rhs) => new long2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, uint2x3 rhs) => new long2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, uint2x3 rhs) => new long2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, uint2x3 rhs) => new long2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs + (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs - (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs * (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs / (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs % (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs + (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs - (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs * (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs / (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs % (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs % (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs + (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs - (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs * (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs / (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs % (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, byte rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (byte lhs, long2x3 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, byte rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (byte lhs, long2x3 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, byte rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (byte lhs, long2x3 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, byte rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (byte lhs, long2x3 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, byte rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (byte lhs, long2x3 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, sbyte rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (sbyte lhs, long2x3 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, sbyte rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (sbyte lhs, long2x3 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, sbyte rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (sbyte lhs, long2x3 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, sbyte rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (sbyte lhs, long2x3 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, sbyte rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (sbyte lhs, long2x3 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, short rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (short lhs, long2x3 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, short rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (short lhs, long2x3 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, short rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (short lhs, long2x3 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, short rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (short lhs, long2x3 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, short rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (short lhs, long2x3 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, ushort rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (ushort lhs, long2x3 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, ushort rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (ushort lhs, long2x3 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, ushort rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (ushort lhs, long2x3 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, ushort rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (ushort lhs, long2x3 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, ushort rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (ushort lhs, long2x3 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, int rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (int lhs, long2x3 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, int rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (int lhs, long2x3 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, int rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (int lhs, long2x3 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, int rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (int lhs, long2x3 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, int rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (int lhs, long2x3 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 lhs, uint rhs) => new long2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (uint lhs, long2x3 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 lhs, uint rhs) => new long2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (uint lhs, long2x3 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 lhs, uint rhs) => new long2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (uint lhs, long2x3 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 lhs, uint rhs) => new long2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (uint lhs, long2x3 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 lhs, uint rhs) => new long2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (uint lhs, long2x3 rhs) => (long)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ~ (long2x3 val) => new long2x3 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator << (long2x3 val, int n) => new long2x3 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator >> (long2x3 val, int n) => new long2x3 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, long2x3 rhs) => new long2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, long rhs) => new long2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long lhs, long2x3 rhs) => new long2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, byte2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, byte2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, byte2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, sbyte2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, sbyte2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, sbyte2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, short2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, short2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, short2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (short2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (short2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (short2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, ushort2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, ushort2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, ushort2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, int2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, int2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, int2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (int2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (int2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (int2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, uint2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, uint2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, uint2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs & (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs | (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs ^ (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, byte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (byte lhs, long2x3 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, byte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (byte lhs, long2x3 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, byte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (byte lhs, long2x3 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, sbyte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (sbyte lhs, long2x3 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, sbyte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (sbyte lhs, long2x3 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, sbyte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (sbyte lhs, long2x3 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, short rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (short lhs, long2x3 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, short rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (short lhs, long2x3 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, short rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (short lhs, long2x3 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, ushort rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (ushort lhs, long2x3 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, ushort rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (ushort lhs, long2x3 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, ushort rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (ushort lhs, long2x3 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, int rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (int lhs, long2x3 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, int rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (int lhs, long2x3 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, int rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (int lhs, long2x3 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 lhs, uint rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (uint lhs, long2x3 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 lhs, uint rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (uint lhs, long2x3 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 lhs, uint rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (uint lhs, long2x3 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, long rhs) => new mask64x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, long rhs) => new mask64x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, long rhs) => new mask64x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, long rhs) => new mask64x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, long rhs) => new mask64x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, long rhs) => new mask64x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long lhs, long2x3 rhs) => new mask64x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, byte2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, byte2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, byte2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, byte2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, byte2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, byte2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (byte2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, sbyte2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, sbyte2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, sbyte2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, sbyte2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, sbyte2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, sbyte2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (sbyte2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, short2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, short2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, short2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, short2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, short2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, short2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (short2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (short2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (short2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (short2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (short2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (short2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, ushort2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, ushort2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, ushort2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, ushort2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, ushort2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, ushort2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ushort2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, int2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, int2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, int2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, int2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, int2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, int2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (int2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (int2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (int2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (int2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (int2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (int2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, uint2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, uint2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, uint2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, uint2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, uint2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, uint2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (uint2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.int2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs == (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs != (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs < (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs > (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs <= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs >= (long2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.uint2x3 lhs, long2x3 rhs) => (long2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (long2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs >= (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.float2x3 lhs, long2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs == (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs != (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs < (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs > (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs <= (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs >= (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.double2x3 lhs, long2x3 rhs) => (double2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, byte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (byte lhs, long2x3 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, byte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (byte lhs, long2x3 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, byte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (byte lhs, long2x3 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, byte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (byte lhs, long2x3 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, byte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (byte lhs, long2x3 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, byte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (byte lhs, long2x3 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, sbyte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (sbyte lhs, long2x3 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, sbyte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (sbyte lhs, long2x3 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, sbyte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (sbyte lhs, long2x3 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, sbyte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (sbyte lhs, long2x3 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, sbyte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (sbyte lhs, long2x3 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, sbyte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (sbyte lhs, long2x3 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, short rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (short lhs, long2x3 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, short rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (short lhs, long2x3 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, short rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (short lhs, long2x3 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, short rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (short lhs, long2x3 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, short rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (short lhs, long2x3 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, short rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (short lhs, long2x3 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, ushort rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ushort lhs, long2x3 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, ushort rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ushort lhs, long2x3 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, ushort rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ushort lhs, long2x3 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, ushort rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ushort lhs, long2x3 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, ushort rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ushort lhs, long2x3 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, ushort rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ushort lhs, long2x3 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, int rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (int lhs, long2x3 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, int rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (int lhs, long2x3 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, int rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (int lhs, long2x3 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, int rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (int lhs, long2x3 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, int rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (int lhs, long2x3 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, int rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (int lhs, long2x3 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (long2x3 lhs, uint rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (uint lhs, long2x3 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (long2x3 lhs, uint rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (uint lhs, long2x3 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (long2x3 lhs, uint rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (uint lhs, long2x3 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (long2x3 lhs, uint rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (uint lhs, long2x3 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (long2x3 lhs, uint rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (uint lhs, long2x3 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (long2x3 lhs, uint rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (uint lhs, long2x3 rhs) => (long)lhs >= rhs;


        public ref long2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (long2x3* array = &this) { return ref ((long2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        public override readonly bool Equals(object obj) => obj is long2x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"long2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}