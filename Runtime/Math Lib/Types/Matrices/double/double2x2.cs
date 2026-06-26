using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct double2x2 : IEquatable<double2x2>, IEquatable<Unity.Mathematics.double2x2>, IEquatable<double>, IFormattable
    {
        public double2 c0;
        public double2 c1;
        

        public static double2x2 identity => new double2x2(1.0, 0.0,   0.0, 1.0);
        public static double2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(double2 c0, double2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(double m00, double m01,
                         double m10, double m11)
        {
            this.c0 = new double2(m00, m10);
            this.c1 = new double2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(bool v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(bool2x2 v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(mask8x2x2 v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(mask16x2x2 v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(mask32x2x2 v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(mask64x2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(byte v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(byte2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(sbyte v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(sbyte2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(ushort v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(ushort2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(short v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(short2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(uint v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(uint2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(int v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(int2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(ulong v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(ulong2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(long v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(long2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(UInt128 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Int128 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(quarter v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(half v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(float v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(float2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(double v)
        {
            this = (double2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(double2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(quadruple v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Unity.Mathematics.int2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Unity.Mathematics.half v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Unity.Mathematics.float2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double2x2(Unity.Mathematics.double2x2 v)
        {
            this = (double2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(UInt128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(Int128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(quarter x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(quadruple x) => (double)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(Unity.Mathematics.double2x2 v) => new double2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x2(double2x2 v) => new Unity.Mathematics.double2x2 { c0 = v.c0, c1 = v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x2(double2x2 v) => new bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(Unity.Mathematics.bool2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x2(double2x2 v) => new Unity.Mathematics.bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(Unity.Mathematics.int2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x2(double2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(Unity.Mathematics.uint2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(double2x2 v) => new uint2x2 { c0 = (uint2)v.c0, c1 = (uint2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(Unity.Mathematics.float2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2x2(double2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(double v) => new double2x2 { c0 = (double2)v, c1 = (double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(bool v) => new double2x2 { c0 = (double2)v, c1 = (double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(bool2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2x2(sbyte v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(sbyte2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2x2(short v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(short2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(int v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(int2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(long v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(long2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2x2(byte v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(byte2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double2x2(ushort v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(ushort2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(uint v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(uint2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(ulong v) => new double2x2 { c0 = (double2)v, c1 = (double2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(ulong2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(half v) => new double2x2 { c0 = (double2)v, c1 = (double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(float v) => new double2x2 { c0 = (double2)v, c1 = (double2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(float2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(mask8x2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(mask16x2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(mask32x2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2x2(mask64x2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x2(double2x2 v) => new mask8x2x2 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(double2x2 v) => new mask16x2x2 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x2(double2x2 v) => new mask32x2x2 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x2(double2x2 v) => new mask64x2x2 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 val) => new double2x2 { c0 = +val.c0, c1 = +val.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 val) => new double2x2 { c0 = -val.c0, c1 = -val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator ++ (double2x2 val) => new double2x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator -- (double2x2 val) => new double2x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, double rhs) => new double2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double lhs, double2x2 rhs) => new double2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, double rhs) => new double2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double lhs, double2x2 rhs) => new double2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, double rhs) => new double2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double lhs, double2x2 rhs) => new double2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, double rhs) => new double2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double lhs, double2x2 rhs) => new double2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, double rhs) => new double2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double lhs, double2x2 rhs) => new double2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, quarter rhs) => new double2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, quarter rhs) => new double2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, quarter rhs) => new double2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, quarter rhs) => new double2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, quarter rhs) => new double2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (quarter lhs, double2x2 rhs) => new double2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (quarter lhs, double2x2 rhs) => new double2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (quarter lhs, double2x2 rhs) => new double2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (quarter lhs, double2x2 rhs) => new double2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (quarter lhs, double2x2 rhs) => new double2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, half rhs) => new double2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, half rhs) => new double2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, half rhs) => new double2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, half rhs) => new double2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, half rhs) => new double2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (half lhs, double2x2 rhs) => new double2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (half lhs, double2x2 rhs) => new double2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (half lhs, double2x2 rhs) => new double2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (half lhs, double2x2 rhs) => new double2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (half lhs, double2x2 rhs) => new double2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, Unity.Mathematics.half rhs) => new double2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, Unity.Mathematics.half rhs) => new double2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, Unity.Mathematics.half rhs) => new double2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, Unity.Mathematics.half rhs) => new double2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, Unity.Mathematics.half rhs) => new double2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.half lhs, double2x2 rhs) => new double2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.half lhs, double2x2 rhs) => new double2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.half lhs, double2x2 rhs) => new double2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.half lhs, double2x2 rhs) => new double2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.half lhs, double2x2 rhs) => new double2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, float rhs) => new double2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, float rhs) => new double2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, float rhs) => new double2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, float rhs) => new double2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, float rhs) => new double2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (float lhs, double2x2 rhs) => new double2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (float lhs, double2x2 rhs) => new double2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (float lhs, double2x2 rhs) => new double2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (float lhs, double2x2 rhs) => new double2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (float lhs, double2x2 rhs) => new double2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, byte2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, byte2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, byte2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, byte2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, byte2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, sbyte2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, sbyte2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, sbyte2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, sbyte2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, sbyte2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, short2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, short2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, short2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, short2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, short2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (short2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (short2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (short2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (short2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (short2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, ushort2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, ushort2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, ushort2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, ushort2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, ushort2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, int2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, int2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, int2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, int2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, int2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (int2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (int2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (int2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (int2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (int2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, uint2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, uint2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, uint2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, uint2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, uint2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, long2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, long2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, long2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, long2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, long2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (long2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (long2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (long2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (long2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (long2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, ulong2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, ulong2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, ulong2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, ulong2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, ulong2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, byte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (byte lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, byte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (byte lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, byte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (byte lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, byte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (byte lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, byte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (byte lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, sbyte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (sbyte lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, sbyte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (sbyte lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, sbyte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (sbyte lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, sbyte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (sbyte lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, sbyte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (sbyte lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, short rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (short lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, short rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (short lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, short rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (short lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, short rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (short lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, short rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (short lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, ushort rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (ushort lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, ushort rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (ushort lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, ushort rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (ushort lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, ushort rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (ushort lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, ushort rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (ushort lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, int rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (int lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, int rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (int lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, int rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (int lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, int rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (int lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, int rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (int lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, uint rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (uint lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, uint rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (uint lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, uint rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (uint lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, uint rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (uint lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, uint rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (uint lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, long rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (long lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, long rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (long lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, long rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (long lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, long rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (long lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, long rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (long lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, ulong rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (ulong lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, ulong rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (ulong lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, ulong rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (ulong lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, ulong rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (ulong lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, ulong rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (ulong lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Int128 lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, Int128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Int128 lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, Int128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Int128 lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, Int128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Int128 lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, Int128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Int128 lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (double2x2 lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (UInt128 lhs, double2x2 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (double2x2 lhs, UInt128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (UInt128 lhs, double2x2 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (double2x2 lhs, UInt128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (UInt128 lhs, double2x2 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (double2x2 lhs, UInt128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (UInt128 lhs, double2x2 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (double2x2 lhs, UInt128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (UInt128 lhs, double2x2 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, double rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, double rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, double rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, double rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, double rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, double rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, Unity.Mathematics.double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.double2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, quarter rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, quarter rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, quarter rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, quarter rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, quarter rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, quarter rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (quarter lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (quarter lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (quarter lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (quarter lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (quarter lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (quarter lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, half rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, half rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, half rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, half rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, half rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, half rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, Unity.Mathematics.half rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, Unity.Mathematics.half rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, Unity.Mathematics.half rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, Unity.Mathematics.half rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, Unity.Mathematics.half rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, Unity.Mathematics.half rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.half lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, float rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, float rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, float rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, float rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, float rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, float rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (float lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (float lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (float lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (float lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (float lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (float lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, float2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, float2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, float2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, float2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, float2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, float2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (float2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (float2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (float2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (float2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (float2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (float2x2 lhs, double2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs >= (double2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.float2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, byte2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, byte2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, byte2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, byte2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, byte2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, byte2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (byte2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, sbyte2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, sbyte2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, sbyte2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, sbyte2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, sbyte2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, sbyte2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (sbyte2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, short2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, short2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, short2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, short2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, short2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, short2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (short2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (short2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (short2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (short2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (short2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (short2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, ushort2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, ushort2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, ushort2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, ushort2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, ushort2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, ushort2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (ushort2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, int2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, int2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, int2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, int2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, int2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, int2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (int2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (int2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (int2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (int2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (int2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (int2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, uint2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, uint2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, uint2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, uint2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, uint2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, uint2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (uint2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.int2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.uint2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, long2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, long2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, long2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, long2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, long2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, long2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, ulong2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, ulong2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, ulong2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, ulong2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, ulong2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, ulong2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (ulong2x2 lhs, double2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, byte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (byte lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, byte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (byte lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, byte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (byte lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, byte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (byte lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, byte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (byte lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, byte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (byte lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, sbyte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (sbyte lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, sbyte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (sbyte lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, sbyte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (sbyte lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, sbyte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (sbyte lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, sbyte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (sbyte lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, sbyte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (sbyte lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, short rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (short lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, short rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (short lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, short rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (short lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, short rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (short lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, short rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (short lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, short rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (short lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, ushort rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (ushort lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, ushort rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (ushort lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, ushort rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (ushort lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, ushort rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (ushort lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, ushort rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (ushort lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, ushort rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (ushort lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, int rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (int lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, int rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (int lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, int rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (int lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, int rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (int lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, int rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (int lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, int rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (int lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, uint rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (uint lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, uint rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (uint lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, uint rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (uint lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, uint rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (uint lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, uint rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (uint lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, uint rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (uint lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, long rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (long lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, long rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (long lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, long rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (long lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, long rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (long lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, long rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (long lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, long rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (long lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, ulong rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (ulong lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, ulong rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (ulong lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, ulong rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (ulong lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, ulong rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (ulong lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, ulong rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (ulong lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, ulong rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (ulong lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, Int128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Int128 lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, Int128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Int128 lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, Int128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Int128 lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, Int128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Int128 lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, Int128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Int128 lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, Int128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Int128 lhs, double2x2 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (double2x2 lhs, UInt128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (UInt128 lhs, double2x2 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (double2x2 lhs, UInt128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (UInt128 lhs, double2x2 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (double2x2 lhs, UInt128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (UInt128 lhs, double2x2 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (double2x2 lhs, UInt128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (UInt128 lhs, double2x2 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (double2x2 lhs, UInt128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (UInt128 lhs, double2x2 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (double2x2 lhs, UInt128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (UInt128 lhs, double2x2 rhs) => (double)lhs >= rhs;


        public ref double2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (double2x2* array = &this) { return ref ((double2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.double2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is double2x2 converted && Equals(converted)) || (o is Unity.Mathematics.double2x2 convertedU && Equals(convertedU)) || (o is double convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.double2x2)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.double2x2)this).ToString(format, formatProvider);


        /// <summary>   Computes a <see cref="double2x2"/> matrix representing a counter-clockwise rotation by an angle in radians.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 Rotate(double angle)
        {
            math.sincos(angle, out double s, out double c);
            return new double2x2(c, -s,
                                 s,  c);
        }

        /// <summary>   Returns a <see cref="double2x2"/> matrix representing a uniform scaling of both axes by <paramref name="s"/>. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 Scale(double s)
        {
            return new double2x2(s,  0d,
                                 0d, s);
        }

        /// <summary>   Returns a <see cref="double2x2"/> matrix representing a non-uniform axis scaling by <paramref name="x"/> and <paramref name="y"/>. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 Scale(double x, double y)
        {
            return new double2x2(x,  0d,
                                 0d, y);
        }

        /// <summary>Returns a <see cref="double2x2"/> matrix representing a non-uniform axis scaling by the components of the <see cref="double2"/> vector <paramref name="v"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 Scale(double2 v)
        {
            return Scale(v.x, v.y);
        }
    }
}
