using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct double4x3 : IEquatable<double4x3>, IEquatable<Unity.Mathematics.double4x3>, IEquatable<double>, IFormattable
    {
        public double4 c0;
        public double4 c1;
        public double4 c2;

        public static double4x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(double4 c0, double4 c1, double4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(double m00, double m01, double m02,
                         double m10, double m11, double m12,
                         double m20, double m21, double m22,
                         double m30, double m31, double m32)
        {
            this.c0 = new double4(m00, m10, m20, m30);
            this.c1 = new double4(m01, m11, m21, m31);
            this.c2 = new double4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(bool v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(bool4x3 v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(mask8x4x3 v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(mask16x4x3 v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(mask32x4x3 v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(mask64x4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(byte v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(byte4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(sbyte v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(sbyte4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(ushort v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(ushort4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(short v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(short4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(uint v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(uint4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(int v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(int4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(ulong v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(ulong4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(long v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(long4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(UInt128 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Int128 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(quarter v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(half v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(float v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(float4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(double v)
        {
            this = (double4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(double4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(quadruple v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Unity.Mathematics.bool4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Unity.Mathematics.uint4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Unity.Mathematics.int4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Unity.Mathematics.half v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Unity.Mathematics.float4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x3(Unity.Mathematics.double4x3 v)
        {
            this = (double4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(UInt128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(Int128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(quarter x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(quadruple x) => (double)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(Unity.Mathematics.double4x3 v) => new double4x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x3(double4x3 v) => new Unity.Mathematics.double4x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(double4x3 v) => new bool4x3 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(Unity.Mathematics.bool4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x3(double4x3 v) => new Unity.Mathematics.bool4x3 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(Unity.Mathematics.int4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x3(double4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(Unity.Mathematics.uint4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x3(double4x3 v) => new uint4x3 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(Unity.Mathematics.float4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4x3(double4x3 v) => new float4x3 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(double v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(bool v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(bool4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x3(sbyte v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(sbyte4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x3(short v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(short4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(int v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(int4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(long v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(long4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x3(byte v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(byte4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x3(ushort v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(ushort4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(uint v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(uint4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(ulong v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(ulong4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(half v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(float v) => new double4x3 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(float4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(mask8x4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(mask16x4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(mask32x4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x3(mask64x4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x3(double4x3 v) => new mask8x4x3 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x3(double4x3 v) => new mask16x4x3 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x3(double4x3 v) => new mask32x4x3 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x3(double4x3 v) => new mask64x4x3 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 val) => new double4x3 { c0 = +val.c0, c1 = +val.c1, c2 = +val.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 val) => new double4x3 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator ++ (double4x3 val) => new double4x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator -- (double4x3 val) => new double4x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, double rhs) => new double4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double lhs, double4x3 rhs) => new double4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, double rhs) => new double4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double lhs, double4x3 rhs) => new double4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, double rhs) => new double4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double lhs, double4x3 rhs) => new double4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, double rhs) => new double4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double lhs, double4x3 rhs) => new double4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, double rhs) => new double4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double lhs, double4x3 rhs) => new double4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, quarter rhs) => new double4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, quarter rhs) => new double4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, quarter rhs) => new double4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, quarter rhs) => new double4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, quarter rhs) => new double4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (quarter lhs, double4x3 rhs) => new double4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (quarter lhs, double4x3 rhs) => new double4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (quarter lhs, double4x3 rhs) => new double4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (quarter lhs, double4x3 rhs) => new double4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (quarter lhs, double4x3 rhs) => new double4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, half rhs) => new double4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, half rhs) => new double4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, half rhs) => new double4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, half rhs) => new double4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, half rhs) => new double4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (half lhs, double4x3 rhs) => new double4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (half lhs, double4x3 rhs) => new double4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (half lhs, double4x3 rhs) => new double4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (half lhs, double4x3 rhs) => new double4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (half lhs, double4x3 rhs) => new double4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, Unity.Mathematics.half rhs) => new double4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, Unity.Mathematics.half rhs) => new double4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, Unity.Mathematics.half rhs) => new double4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, Unity.Mathematics.half rhs) => new double4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, Unity.Mathematics.half rhs) => new double4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.half lhs, double4x3 rhs) => new double4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.half lhs, double4x3 rhs) => new double4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.half lhs, double4x3 rhs) => new double4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.half lhs, double4x3 rhs) => new double4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.half lhs, double4x3 rhs) => new double4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, float rhs) => new double4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, float rhs) => new double4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, float rhs) => new double4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, float rhs) => new double4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, float rhs) => new double4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (float lhs, double4x3 rhs) => new double4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (float lhs, double4x3 rhs) => new double4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (float lhs, double4x3 rhs) => new double4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (float lhs, double4x3 rhs) => new double4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (float lhs, double4x3 rhs) => new double4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, float4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, float4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, float4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, float4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, float4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => new double4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, byte4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, byte4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, byte4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, byte4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, byte4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, sbyte4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, sbyte4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, sbyte4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, sbyte4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, sbyte4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, short4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, short4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, short4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, short4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, short4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (short4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (short4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (short4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (short4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (short4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, ushort4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, ushort4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, ushort4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, ushort4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, ushort4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, int4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, int4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, int4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, int4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, int4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (int4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (int4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (int4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (int4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (int4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, uint4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, uint4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, uint4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, uint4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, uint4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, long4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, long4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, long4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, long4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, long4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (long4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (long4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (long4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (long4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (long4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, ulong4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, ulong4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, ulong4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, ulong4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, ulong4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, byte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (byte lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, byte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (byte lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, byte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (byte lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, byte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (byte lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, byte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (byte lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, sbyte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (sbyte lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, sbyte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (sbyte lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, sbyte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (sbyte lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, sbyte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (sbyte lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, sbyte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (sbyte lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, short rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (short lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, short rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (short lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, short rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (short lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, short rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (short lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, short rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (short lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, ushort rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (ushort lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, ushort rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (ushort lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, ushort rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (ushort lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, ushort rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (ushort lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, ushort rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (ushort lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, int rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (int lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, int rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (int lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, int rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (int lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, int rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (int lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, int rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (int lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, uint rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (uint lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, uint rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (uint lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, uint rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (uint lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, uint rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (uint lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, uint rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (uint lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, long rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (long lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, long rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (long lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, long rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (long lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, long rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (long lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, long rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (long lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, ulong rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (ulong lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, ulong rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (ulong lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, ulong rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (ulong lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, ulong rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (ulong lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, ulong rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (ulong lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Int128 lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, Int128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Int128 lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, Int128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Int128 lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, Int128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Int128 lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, Int128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Int128 lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (double4x3 lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (UInt128 lhs, double4x3 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (double4x3 lhs, UInt128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (UInt128 lhs, double4x3 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (double4x3 lhs, UInt128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (UInt128 lhs, double4x3 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (double4x3 lhs, UInt128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (UInt128 lhs, double4x3 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (double4x3 lhs, UInt128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (UInt128 lhs, double4x3 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, double rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, double rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, double rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, double rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, double rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, double rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, Unity.Mathematics.double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.double4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, quarter rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, quarter rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, quarter rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, quarter rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, quarter rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, quarter rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (quarter lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (quarter lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (quarter lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (quarter lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (quarter lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (quarter lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, half rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, half rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, half rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, half rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, half rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, half rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, Unity.Mathematics.half rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, Unity.Mathematics.half rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, Unity.Mathematics.half rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, Unity.Mathematics.half rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, Unity.Mathematics.half rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, Unity.Mathematics.half rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.half lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, float rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, float rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, float rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, float rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, float rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, float rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (float lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (float lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (float lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (float lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (float lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (float lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, float4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, float4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, float4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, float4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, float4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, float4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (float4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (float4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (float4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (float4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (float4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (float4x3 lhs, double4x3 rhs) => new mask64x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs >= (double4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.float4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, byte4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, byte4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, byte4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, byte4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, byte4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, byte4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (byte4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, sbyte4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, sbyte4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, sbyte4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, sbyte4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, sbyte4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, sbyte4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (sbyte4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, short4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, short4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, short4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, short4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, short4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, short4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (short4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (short4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (short4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (short4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (short4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (short4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, ushort4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, ushort4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, ushort4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, ushort4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, ushort4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, ushort4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (ushort4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, int4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, int4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, int4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, int4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, int4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, int4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (int4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (int4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (int4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (int4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (int4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (int4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, uint4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, uint4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, uint4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, uint4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, uint4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, uint4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (uint4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.int4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.uint4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, long4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, long4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, long4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, long4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, long4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, long4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (long4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (long4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (long4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (long4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (long4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (long4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, ulong4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, ulong4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, ulong4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, ulong4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, ulong4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, ulong4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (ulong4x3 lhs, double4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, byte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (byte lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, byte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (byte lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, byte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (byte lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, byte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (byte lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, byte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (byte lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, byte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (byte lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, sbyte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (sbyte lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, sbyte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (sbyte lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, sbyte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (sbyte lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, sbyte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (sbyte lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, sbyte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (sbyte lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, sbyte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (sbyte lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, short rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (short lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, short rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (short lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, short rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (short lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, short rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (short lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, short rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (short lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, short rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (short lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, ushort rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (ushort lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, ushort rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (ushort lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, ushort rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (ushort lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, ushort rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (ushort lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, ushort rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (ushort lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, ushort rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (ushort lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, int rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (int lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, int rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (int lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, int rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (int lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, int rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (int lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, int rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (int lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, int rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (int lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, uint rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (uint lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, uint rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (uint lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, uint rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (uint lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, uint rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (uint lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, uint rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (uint lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, uint rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (uint lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, long rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (long lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, long rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (long lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, long rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (long lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, long rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (long lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, long rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (long lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, long rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (long lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, ulong rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (ulong lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, ulong rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (ulong lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, ulong rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (ulong lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, ulong rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (ulong lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, ulong rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (ulong lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, ulong rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (ulong lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, Int128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Int128 lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, Int128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Int128 lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, Int128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Int128 lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, Int128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Int128 lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, Int128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Int128 lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, Int128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Int128 lhs, double4x3 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (double4x3 lhs, UInt128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (UInt128 lhs, double4x3 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (double4x3 lhs, UInt128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (UInt128 lhs, double4x3 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (double4x3 lhs, UInt128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (UInt128 lhs, double4x3 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (double4x3 lhs, UInt128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (UInt128 lhs, double4x3 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (double4x3 lhs, UInt128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (UInt128 lhs, double4x3 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (double4x3 lhs, UInt128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (UInt128 lhs, double4x3 rhs) => (double)lhs >= rhs;


        public ref double4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (double4x3* array = &this) { return ref ((double4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.double4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is double4x3 converted && Equals(converted)) || (o is Unity.Mathematics.double4x3 convertedU && Equals(convertedU)) || (o is double convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.double4x3)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.double4x3)this).ToString(format, formatProvider);
    }
}
