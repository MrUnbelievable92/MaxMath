using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct long2x4 : IEquatable<long2x4>, IFormattable
    {
        public long2 c0;
        public long2 c1;
        public long2 c2;
        public long2 c3;


        public static long2x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long2 c0, long2 c1, long2 c2, long2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long m00, long m01, long m02, long m03,
                       long m10, long m11, long m12, long m13)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
            this.c2 = new long2(m02, m12);
            this.c3 = new long2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(bool v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(bool2x4 v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(mask8x2x4 v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(mask16x2x4 v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(mask32x2x4 v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(mask64x2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(byte v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(byte2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(sbyte v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(sbyte2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(ushort v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(ushort2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(short v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(short2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(uint v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(uint2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(int v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(int2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(ulong v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(ulong2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(UInt128 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Int128 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(quarter v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(half v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(float v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(float2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(double v)
        {
            this = (long2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(double2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(quadruple v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Unity.Mathematics.bool2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Unity.Mathematics.uint2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Unity.Mathematics.int2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Unity.Mathematics.half v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Unity.Mathematics.float2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(Unity.Mathematics.double2x4 v)
        {
            this = (long2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(long2x4 v) => new bool2x4 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2, c3 = (bool2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(Unity.Mathematics.bool2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x4(long2x4 v) => new Unity.Mathematics.bool2x4 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2, c3 = (bool2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(Unity.Mathematics.int2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x4(long2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(Unity.Mathematics.uint2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x4(long2x4 v) => new uint2x4 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2, c3 = (uint2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(Unity.Mathematics.half v) => (long2x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(Unity.Mathematics.float2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x4(long2x4 v) => new float2x4 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, c3 = (float2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(Unity.Mathematics.double2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x4(long2x4 v) => new double2x4 { c0 = (double2)v.c0, c1 = (double2)v.c1, c2 = (double2)v.c2, c3 = (double2)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(long v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(bool v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(bool2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x4(sbyte v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(sbyte2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x4(short v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(short2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(int v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(int2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x4(byte v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(byte2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long2x4(ushort v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(ushort2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(uint v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(uint2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(ulong v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(ulong2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(half v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(float v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(float2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(double v) => new long2x4 { c0 = (long2)v, c1 = (long2)v, c2 = (long2)v, c3 = (long2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(double2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(mask8x2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(mask16x2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(mask32x2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(mask64x2x4 v) => new long2x4 { c0 = (long2)v.c0, c1 = (long2)v.c1, c2 = (long2)v.c2, c3 = (long2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x4(long2x4 v) => new mask8x2x4 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2, c3 = (mask8x2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x4(long2x4 v) => new mask16x2x4 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2, c3 = (mask16x2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x4(long2x4 v) => new mask32x2x4 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2, c3 = (mask32x2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x4(long2x4 v) => new mask64x2x4 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2, c3 = (mask64x2)v.c3 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 val) => new long2x4 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2, c3 = -val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ++ (long2x4 val) => new long2x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator -- (long2x4 val) => new long2x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, byte2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, byte2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, byte2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, byte2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, byte2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, sbyte2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, sbyte2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, sbyte2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, sbyte2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, sbyte2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, short2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, short2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, short2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, short2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, short2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (short2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (short2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (short2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (short2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (short2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, ushort2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, ushort2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, ushort2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, ushort2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, ushort2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, int2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, int2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, int2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, int2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, int2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (int2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (int2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (int2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (int2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (int2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, uint2x4 rhs) => new long2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, uint2x4 rhs) => new long2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, uint2x4 rhs) => new long2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, uint2x4 rhs) => new long2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, uint2x4 rhs) => new long2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs + (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs - (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs * (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs / (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs % (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs + (uint2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs - (uint2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs * (uint2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs / (uint2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs % (uint2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator + (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs + (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator - (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs - (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator * (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs * (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator / (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs / (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator % (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs % (float2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator + (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator - (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator * (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator / (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator % (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator + (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs + (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator - (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs - (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator * (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs * (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator / (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs / (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator % (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs % (double2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator + (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator - (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator * (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator / (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator % (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, byte rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (byte lhs, long2x4 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, byte rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (byte lhs, long2x4 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, byte rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (byte lhs, long2x4 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, byte rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (byte lhs, long2x4 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, byte rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (byte lhs, long2x4 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, sbyte rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (sbyte lhs, long2x4 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, sbyte rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (sbyte lhs, long2x4 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, sbyte rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (sbyte lhs, long2x4 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, sbyte rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (sbyte lhs, long2x4 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, sbyte rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (sbyte lhs, long2x4 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, short rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (short lhs, long2x4 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, short rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (short lhs, long2x4 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, short rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (short lhs, long2x4 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, short rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (short lhs, long2x4 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, short rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (short lhs, long2x4 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, ushort rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (ushort lhs, long2x4 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, ushort rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (ushort lhs, long2x4 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, ushort rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (ushort lhs, long2x4 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, ushort rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (ushort lhs, long2x4 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, ushort rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (ushort lhs, long2x4 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, int rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (int lhs, long2x4 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, int rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (int lhs, long2x4 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, int rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (int lhs, long2x4 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, int rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (int lhs, long2x4 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, int rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (int lhs, long2x4 rhs) => (long)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 lhs, uint rhs) => new long2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (uint lhs, long2x4 rhs) => (long)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 lhs, uint rhs) => new long2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (uint lhs, long2x4 rhs) => (long)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 lhs, uint rhs) => new long2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (uint lhs, long2x4 rhs) => (long)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 lhs, uint rhs) => new long2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (uint lhs, long2x4 rhs) => (long)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 lhs, uint rhs) => new long2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (uint lhs, long2x4 rhs) => (long)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ~ (long2x4 val) => new long2x4 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2, c3 = ~val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator << (long2x4 val, int n) => new long2x4 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n, c3 = val.c3 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator >> (long2x4 val, int n) => new long2x4 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n, c3 = val.c3 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, long2x4 rhs) => new long2x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, long rhs) => new long2x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long lhs, long2x4 rhs) => new long2x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, byte2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, byte2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, byte2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, sbyte2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, sbyte2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, sbyte2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, short2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, short2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, short2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (short2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (short2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (short2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, ushort2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, ushort2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, ushort2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, int2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, int2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, int2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (int2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (int2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (int2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, uint2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, uint2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, uint2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs & (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs | (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs ^ (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, byte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (byte lhs, long2x4 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, byte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (byte lhs, long2x4 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, byte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (byte lhs, long2x4 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, sbyte rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (sbyte lhs, long2x4 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, sbyte rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (sbyte lhs, long2x4 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, sbyte rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (sbyte lhs, long2x4 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, short rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (short lhs, long2x4 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, short rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (short lhs, long2x4 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, short rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (short lhs, long2x4 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, ushort rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (ushort lhs, long2x4 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, ushort rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (ushort lhs, long2x4 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, ushort rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (ushort lhs, long2x4 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, int rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (int lhs, long2x4 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, int rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (int lhs, long2x4 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, int rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (int lhs, long2x4 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 lhs, uint rhs) => lhs & (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (uint lhs, long2x4 rhs) => (long)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 lhs, uint rhs) => lhs | (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (uint lhs, long2x4 rhs) => (long)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 lhs, uint rhs) => lhs ^ (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (uint lhs, long2x4 rhs) => (long)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, long rhs) => new mask64x2x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, long rhs) => new mask64x2x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, long rhs) => new mask64x2x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, long rhs) => new mask64x2x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, long rhs) => new mask64x2x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, long rhs) => new mask64x2x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long lhs, long2x4 rhs) => new mask64x2x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, byte2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, byte2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, byte2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, byte2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, byte2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, byte2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (byte2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, sbyte2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, sbyte2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, sbyte2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, sbyte2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, sbyte2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, sbyte2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (sbyte2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, short2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, short2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, short2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, short2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, short2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, short2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (short2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (short2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (short2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (short2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (short2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (short2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, ushort2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, ushort2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, ushort2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, ushort2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, ushort2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, ushort2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (ushort2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, int2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, int2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, int2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, int2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, int2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, int2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (int2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (int2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (int2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (int2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (int2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (int2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, uint2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, uint2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, uint2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, uint2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, uint2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, uint2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (uint2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (Unity.Mathematics.int2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs == (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs != (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs < (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs > (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs <= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, Unity.Mathematics.uint2x4 rhs) => lhs >= (long2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (Unity.Mathematics.uint2x4 lhs, long2x4 rhs) => (long2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs == (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs != (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs < (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs > (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs <= (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (long2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs >= (float2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (Unity.Mathematics.float2x4 lhs, long2x4 rhs) => (float2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs == (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs != (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs < (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs > (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs <= (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs >= (double2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (Unity.Mathematics.double2x4 lhs, long2x4 rhs) => (double2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, byte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (byte lhs, long2x4 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, byte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (byte lhs, long2x4 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, byte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (byte lhs, long2x4 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, byte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (byte lhs, long2x4 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, byte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (byte lhs, long2x4 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, byte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (byte lhs, long2x4 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, sbyte rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (sbyte lhs, long2x4 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, sbyte rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (sbyte lhs, long2x4 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, sbyte rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (sbyte lhs, long2x4 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, sbyte rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (sbyte lhs, long2x4 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, sbyte rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (sbyte lhs, long2x4 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, sbyte rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (sbyte lhs, long2x4 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, short rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (short lhs, long2x4 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, short rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (short lhs, long2x4 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, short rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (short lhs, long2x4 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, short rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (short lhs, long2x4 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, short rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (short lhs, long2x4 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, short rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (short lhs, long2x4 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, ushort rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (ushort lhs, long2x4 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, ushort rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (ushort lhs, long2x4 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, ushort rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (ushort lhs, long2x4 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, ushort rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (ushort lhs, long2x4 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, ushort rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (ushort lhs, long2x4 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, ushort rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (ushort lhs, long2x4 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, int rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (int lhs, long2x4 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, int rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (int lhs, long2x4 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, int rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (int lhs, long2x4 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, int rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (int lhs, long2x4 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, int rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (int lhs, long2x4 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, int rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (int lhs, long2x4 rhs) => (long)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (long2x4 lhs, uint rhs) => lhs == (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (uint lhs, long2x4 rhs) => (long)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (long2x4 lhs, uint rhs) => lhs != (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (uint lhs, long2x4 rhs) => (long)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (long2x4 lhs, uint rhs) => lhs < (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (uint lhs, long2x4 rhs) => (long)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (long2x4 lhs, uint rhs) => lhs > (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (uint lhs, long2x4 rhs) => (long)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (long2x4 lhs, uint rhs) => lhs <= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (uint lhs, long2x4 rhs) => (long)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (long2x4 lhs, uint rhs) => lhs >= (long)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (uint lhs, long2x4 rhs) => (long)lhs >= rhs;


        public ref long2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (long2x4* array = &this) { return ref ((long2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2x4 other) => (math.all(this.c0 == other.c0 & this.c1 == other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override readonly bool Equals(object obj) => obj is long2x4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"long2x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)})";
    }
}