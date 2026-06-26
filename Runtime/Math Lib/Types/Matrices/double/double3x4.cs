using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct double3x4 : IEquatable<double3x4>, IEquatable<Unity.Mathematics.double3x4>, IEquatable<double>, IFormattable
    {
        public double3 c0;
        public double3 c1;
        public double3 c2;
        public double3 c3;

        public static double3x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(double3 c0, double3 c1, double3 c2, double3 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(double m00, double m01, double m02, double m03,
                         double m10, double m11, double m12, double m13,
                         double m20, double m21, double m22, double m23)
        {
            this.c0 = new double3(m00, m10, m20);
            this.c1 = new double3(m01, m11, m21);
            this.c2 = new double3(m02, m12, m22);
            this.c3 = new double3(m03, m13, m23);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(bool v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(bool3x4 v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(mask8x3x4 v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(mask16x3x4 v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(mask32x3x4 v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(mask64x3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(byte v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(byte3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(sbyte v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(sbyte3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(ushort v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(ushort3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(short v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(short3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(uint v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(uint3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(int v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(int3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(ulong v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(ulong3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(long v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(long3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(UInt128 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Int128 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(quarter v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(half v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(float v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(float3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(double v)
        {
            this = (double3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(double3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(quadruple v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Unity.Mathematics.bool3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Unity.Mathematics.uint3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Unity.Mathematics.int3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Unity.Mathematics.half v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Unity.Mathematics.float3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3x4(Unity.Mathematics.double3x4 v)
        {
            this = (double3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(UInt128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(Int128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(quarter x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(quadruple x) => (double)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(Unity.Mathematics.double3x4 v) => new double3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x4(double3x4 v) => new Unity.Mathematics.double3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(double3x4 v) => new bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(Unity.Mathematics.bool3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x4(double3x4 v) => new Unity.Mathematics.bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(Unity.Mathematics.int3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x4(double3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(Unity.Mathematics.uint3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x4(double3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(Unity.Mathematics.float3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3x4(double3x4 v) => new float3x4 { c0 = (float3)v.c0, c1 = (float3)v.c1, c2 = (float3)v.c2, c3 = (float3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(double v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(bool v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(bool3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3x4(sbyte v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(sbyte3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3x4(short v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(short3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(int v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(int3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(long v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(long3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3x4(byte v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(byte3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double3x4(ushort v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(ushort3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(uint v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(uint3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(ulong v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(ulong3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(half v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(float v) => new double3x4 { c0 = (double3)v, c1 = (double3)v, c2 = (double3)v, c3 = (double3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(float3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(mask8x3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(mask16x3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(mask32x3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double3x4(mask64x3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x4(double3x4 v) => new mask8x3x4 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1, c2 = (mask8x3)v.c2, c3 = (mask8x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x4(double3x4 v) => new mask16x3x4 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1, c2 = (mask16x3)v.c2, c3 = (mask16x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x4(double3x4 v) => new mask32x3x4 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1, c2 = (mask32x3)v.c2, c3 = (mask32x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x4(double3x4 v) => new mask64x3x4 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1, c2 = (mask64x3)v.c2, c3 = (mask64x3)v.c3 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 val) => new double3x4 { c0 = +val.c0, c1 = +val.c1, c2 = +val.c2, c3 = +val.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 val) => new double3x4 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2, c3 = -val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator ++ (double3x4 val) => new double3x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator -- (double3x4 val) => new double3x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, double rhs) => new double3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double lhs, double3x4 rhs) => new double3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, double rhs) => new double3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double lhs, double3x4 rhs) => new double3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, double rhs) => new double3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double lhs, double3x4 rhs) => new double3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, double rhs) => new double3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double lhs, double3x4 rhs) => new double3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, double rhs) => new double3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double lhs, double3x4 rhs) => new double3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, quarter rhs) => new double3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, quarter rhs) => new double3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, quarter rhs) => new double3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, quarter rhs) => new double3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, quarter rhs) => new double3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (quarter lhs, double3x4 rhs) => new double3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (quarter lhs, double3x4 rhs) => new double3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (quarter lhs, double3x4 rhs) => new double3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (quarter lhs, double3x4 rhs) => new double3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (quarter lhs, double3x4 rhs) => new double3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, half rhs) => new double3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, half rhs) => new double3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, half rhs) => new double3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, half rhs) => new double3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, half rhs) => new double3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (half lhs, double3x4 rhs) => new double3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (half lhs, double3x4 rhs) => new double3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (half lhs, double3x4 rhs) => new double3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (half lhs, double3x4 rhs) => new double3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (half lhs, double3x4 rhs) => new double3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, Unity.Mathematics.half rhs) => new double3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, Unity.Mathematics.half rhs) => new double3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, Unity.Mathematics.half rhs) => new double3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, Unity.Mathematics.half rhs) => new double3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, Unity.Mathematics.half rhs) => new double3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.half lhs, double3x4 rhs) => new double3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.half lhs, double3x4 rhs) => new double3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.half lhs, double3x4 rhs) => new double3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.half lhs, double3x4 rhs) => new double3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.half lhs, double3x4 rhs) => new double3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, float rhs) => new double3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, float rhs) => new double3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, float rhs) => new double3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, float rhs) => new double3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, float rhs) => new double3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (float lhs, double3x4 rhs) => new double3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (float lhs, double3x4 rhs) => new double3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (float lhs, double3x4 rhs) => new double3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (float lhs, double3x4 rhs) => new double3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (float lhs, double3x4 rhs) => new double3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, float3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, float3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, float3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, float3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, float3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => new double3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, byte3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, byte3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, byte3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, byte3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, byte3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, sbyte3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, sbyte3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, sbyte3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, sbyte3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, sbyte3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, short3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, short3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, short3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, short3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, short3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (short3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (short3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (short3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (short3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (short3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, ushort3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, ushort3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, ushort3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, ushort3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, ushort3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, int3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, int3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, int3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, int3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, int3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (int3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (int3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (int3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (int3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (int3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, uint3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, uint3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, uint3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, uint3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, uint3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, long3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, long3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, long3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, long3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, long3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (long3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (long3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (long3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (long3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (long3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, ulong3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, ulong3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, ulong3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, ulong3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, ulong3x4 rhs) => lhs % (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, byte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (byte lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, byte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (byte lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, byte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (byte lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, byte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (byte lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, byte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (byte lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, sbyte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (sbyte lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, sbyte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (sbyte lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, sbyte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (sbyte lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, sbyte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (sbyte lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, sbyte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (sbyte lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, short rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (short lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, short rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (short lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, short rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (short lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, short rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (short lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, short rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (short lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, ushort rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (ushort lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, ushort rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (ushort lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, ushort rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (ushort lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, ushort rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (ushort lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, ushort rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (ushort lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, int rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (int lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, int rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (int lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, int rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (int lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, int rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (int lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, int rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (int lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, uint rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (uint lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, uint rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (uint lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, uint rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (uint lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, uint rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (uint lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, uint rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (uint lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, long rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (long lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, long rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (long lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, long rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (long lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, long rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (long lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, long rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (long lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, ulong rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (ulong lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, ulong rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (ulong lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, ulong rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (ulong lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, ulong rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (ulong lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, ulong rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (ulong lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Int128 lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, Int128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Int128 lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, Int128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Int128 lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, Int128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Int128 lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, Int128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Int128 lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (double3x4 lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (UInt128 lhs, double3x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (double3x4 lhs, UInt128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (UInt128 lhs, double3x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (double3x4 lhs, UInt128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (UInt128 lhs, double3x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (double3x4 lhs, UInt128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (UInt128 lhs, double3x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (double3x4 lhs, UInt128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (UInt128 lhs, double3x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, double rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, double rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, double rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, double rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, double rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, double rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, Unity.Mathematics.double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.double3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, quarter rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, quarter rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, quarter rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, quarter rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, quarter rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, quarter rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (quarter lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (quarter lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (quarter lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (quarter lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (quarter lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (quarter lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, half rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, half rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, half rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, half rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, half rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, half rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, Unity.Mathematics.half rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, Unity.Mathematics.half rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, Unity.Mathematics.half rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, Unity.Mathematics.half rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, Unity.Mathematics.half rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, Unity.Mathematics.half rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.half lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, float rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, float rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, float rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, float rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, float rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, float rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (float lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (float lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (float lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (float lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (float lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (float lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, float3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, float3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, float3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, float3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, float3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, float3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (float3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (float3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (float3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (float3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (float3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (float3x4 lhs, double3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs >= (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.float3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, byte3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, byte3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, byte3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, byte3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, byte3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, byte3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (byte3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, sbyte3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, sbyte3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, sbyte3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, sbyte3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, sbyte3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, sbyte3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (sbyte3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, short3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, short3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, short3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, short3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, short3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, short3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (short3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (short3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (short3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (short3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (short3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (short3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, ushort3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, ushort3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, ushort3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, ushort3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, ushort3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, ushort3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ushort3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, int3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, int3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, int3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, int3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, int3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, int3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (int3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (int3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (int3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (int3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (int3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (int3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, uint3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, uint3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, uint3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, uint3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, uint3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, uint3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (uint3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.int3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.uint3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, long3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, long3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, long3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, long3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, long3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, long3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (long3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (long3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (long3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (long3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (long3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (long3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, ulong3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, ulong3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, ulong3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, ulong3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, ulong3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, ulong3x4 rhs) => lhs >= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, double3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, byte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (byte lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, byte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (byte lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, byte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (byte lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, byte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (byte lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, byte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (byte lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, byte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (byte lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, sbyte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (sbyte lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, sbyte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (sbyte lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, sbyte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (sbyte lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, sbyte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (sbyte lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, sbyte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (sbyte lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, sbyte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (sbyte lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, short rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (short lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, short rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (short lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, short rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (short lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, short rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (short lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, short rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (short lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, short rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (short lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, ushort rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ushort lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, ushort rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ushort lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, ushort rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ushort lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, ushort rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ushort lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, ushort rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ushort lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, ushort rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ushort lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, int rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (int lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, int rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (int lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, int rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (int lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, int rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (int lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, int rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (int lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, int rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (int lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, uint rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (uint lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, uint rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (uint lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, uint rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (uint lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, uint rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (uint lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, uint rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (uint lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, uint rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (uint lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, long rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (long lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, long rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (long lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, long rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (long lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, long rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (long lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, long rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (long lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, long rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (long lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, ulong rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, ulong rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, ulong rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, ulong rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, ulong rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, ulong rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, Int128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Int128 lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, Int128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Int128 lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, Int128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Int128 lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, Int128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Int128 lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, Int128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Int128 lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, Int128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Int128 lhs, double3x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (double3x4 lhs, UInt128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (UInt128 lhs, double3x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (double3x4 lhs, UInt128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (UInt128 lhs, double3x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (double3x4 lhs, UInt128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (UInt128 lhs, double3x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (double3x4 lhs, UInt128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (UInt128 lhs, double3x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (double3x4 lhs, UInt128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (UInt128 lhs, double3x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (double3x4 lhs, UInt128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (UInt128 lhs, double3x4 rhs) => (double)lhs >= rhs;


        public ref double3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (double3x4* array = &this) { return ref ((double3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.double3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is double3x4 converted && Equals(converted)) || (o is Unity.Mathematics.double3x4 convertedU && Equals(convertedU)) || (o is double convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.double3x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.double3x4)this).ToString(format, formatProvider);
    }
}
