using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct double4x4 : IEquatable<double4x4>, IEquatable<Unity.Mathematics.double4x4>, IEquatable<double>, IFormattable
    {
        public double4 c0;
        public double4 c1;
        public double4 c2;
        public double4 c3;

        public static double4x4 identity => new double4x4(1.0, 0.0, 0.0, 0.0,   0.0, 1.0, 0.0, 0.0,   0.0, 0.0, 1.0, 0.0,   0.0, 0.0, 0.0, 1.0);
        public static double4x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(double4 c0, double4 c1, double4 c2, double4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(double m00, double m01, double m02, double m03,
                         double m10, double m11, double m12, double m13,
                         double m20, double m21, double m22, double m23,
                         double m30, double m31, double m32, double m33)
        {
            this.c0 = new double4(m00, m10, m20, m30);
            this.c1 = new double4(m01, m11, m21, m31);
            this.c2 = new double4(m02, m12, m22, m32);
            this.c3 = new double4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(bool v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(bool4x4 v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(mask8x4x4 v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(mask16x4x4 v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(mask32x4x4 v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(mask64x4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(byte v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(byte4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(sbyte v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(sbyte4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(ushort v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(ushort4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(short v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(short4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(uint v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(uint4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(int v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(int4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(ulong v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(ulong4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(long v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(long4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(UInt128 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Int128 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(quarter v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(half v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(float v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(float4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(double v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(double4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(quadruple v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.int4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.half v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.float4x4 v)
        {
            this = (double4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.double4x4 v)
        {
            this = (double4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(AffineTransform transform) => this = Unity.Mathematics.math.float4x4(transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4x4(Unity.Mathematics.AffineTransform transform) => this = Unity.Mathematics.math.float4x4(transform);
        
        /// <summary>   Constructs a <see cref="double4x4"/> from a <see cref="double3x3"/> rotation matrix and a <see cref="double3"/> translation vector.   </summary>
        public double4x4(double3x3 rotation, double3 translation)
        {
            c0 = new double4(rotation.c0, 0d);
            c1 = new double4(rotation.c1, 0d);
            c2 = new double4(rotation.c2, 0d);
            c3 = new double4(translation, 1d);
        }

        /// <summary>   Constructs a <see cref="double4x4"/> from a quaternion and a <see cref="double3"/> translation vector.   </summary>
        public double4x4(quaternion rotation, double3 translation)
        {
            double3x3 rot = new double3x3(rotation);
            c0 = new double4(rot.c0, 0d);
            c1 = new double4(rot.c1, 0d);
            c2 = new double4(rot.c2, 0d);
            c3 = new double4(translation, 1d);
        }

        /// <summary>   Constructs a <see cref="double4x4"/> from a <see cref="RigidTransform"/>.   </summary>
        public double4x4(RigidTransform transform)
        {
            double3x3 rot = new double3x3(transform.rot);
            c0 = new double4(rot.c0, 0d);
            c1 = new double4(rot.c1, 0d);
            c2 = new double4(rot.c2, 0d);
            c3 = new double4(transform.pos, 1d);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(UInt128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(Int128 x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(quarter x) => (double)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(quadruple x) => (double)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(Unity.Mathematics.double4x4 v) => new double4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x4(double4x4 v) => new Unity.Mathematics.double4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(double4x4 v) => new bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(Unity.Mathematics.bool4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x4(double4x4 v) => new Unity.Mathematics.bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(Unity.Mathematics.int4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x4(double4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(Unity.Mathematics.uint4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x4(double4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(Unity.Mathematics.float4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4x4(double4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(double v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(bool v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(bool4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x4(sbyte v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(sbyte4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x4(short v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(short4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(int v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(int4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(long v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(long4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x4(byte v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(byte4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator double4x4(ushort v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(ushort4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(uint v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(uint4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(ulong v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(ulong4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(half v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(float v) => new double4x4 { c0 = (double4)v, c1 = (double4)v, c2 = (double4)v, c3 = (double4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x4(float4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(mask8x4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(mask16x4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(mask32x4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double4x4(mask64x4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x4(double4x4 v) => new mask8x4x4 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2, c3 = (mask8x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x4(double4x4 v) => new mask16x4x4 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2, c3 = (mask16x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(double4x4 v) => new mask32x4x4 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2, c3 = (mask32x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x4(double4x4 v) => new mask64x4x4 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2, c3 = (mask64x4)v.c3 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 val) => new double4x4 { c0 = +val.c0, c1 = +val.c1, c2 = +val.c2, c3 = +val.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 val) => new double4x4 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2, c3 = -val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator ++ (double4x4 val) => new double4x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator -- (double4x4 val) => new double4x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, double rhs) => new double4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double lhs, double4x4 rhs) => new double4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, double rhs) => new double4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double lhs, double4x4 rhs) => new double4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, double rhs) => new double4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double lhs, double4x4 rhs) => new double4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, double rhs) => new double4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double lhs, double4x4 rhs) => new double4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, double rhs) => new double4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double lhs, double4x4 rhs) => new double4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, quarter rhs) => new double4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, quarter rhs) => new double4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, quarter rhs) => new double4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, quarter rhs) => new double4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, quarter rhs) => new double4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (quarter lhs, double4x4 rhs) => new double4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (quarter lhs, double4x4 rhs) => new double4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (quarter lhs, double4x4 rhs) => new double4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (quarter lhs, double4x4 rhs) => new double4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (quarter lhs, double4x4 rhs) => new double4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, half rhs) => new double4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, half rhs) => new double4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, half rhs) => new double4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, half rhs) => new double4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, half rhs) => new double4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (half lhs, double4x4 rhs) => new double4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (half lhs, double4x4 rhs) => new double4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (half lhs, double4x4 rhs) => new double4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (half lhs, double4x4 rhs) => new double4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (half lhs, double4x4 rhs) => new double4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, Unity.Mathematics.half rhs) => new double4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, Unity.Mathematics.half rhs) => new double4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, Unity.Mathematics.half rhs) => new double4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, Unity.Mathematics.half rhs) => new double4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, Unity.Mathematics.half rhs) => new double4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.half lhs, double4x4 rhs) => new double4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.half lhs, double4x4 rhs) => new double4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.half lhs, double4x4 rhs) => new double4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.half lhs, double4x4 rhs) => new double4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.half lhs, double4x4 rhs) => new double4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, float rhs) => new double4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, float rhs) => new double4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, float rhs) => new double4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, float rhs) => new double4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, float rhs) => new double4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (float lhs, double4x4 rhs) => new double4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (float lhs, double4x4 rhs) => new double4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (float lhs, double4x4 rhs) => new double4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (float lhs, double4x4 rhs) => new double4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (float lhs, double4x4 rhs) => new double4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, byte4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, byte4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, byte4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, byte4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, byte4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, sbyte4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, sbyte4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, sbyte4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, sbyte4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, sbyte4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, short4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, short4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, short4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, short4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, short4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (short4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (short4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (short4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (short4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (short4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, ushort4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, ushort4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, ushort4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, ushort4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, ushort4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, int4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, int4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, int4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, int4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, int4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (int4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (int4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (int4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (int4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (int4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, uint4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, uint4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, uint4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, uint4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, uint4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, long4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, long4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, long4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, long4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, long4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (long4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (long4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (long4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (long4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (long4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, ulong4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, ulong4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, ulong4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, ulong4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, ulong4x4 rhs) => lhs % (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, byte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (byte lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, byte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (byte lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, byte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (byte lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, byte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (byte lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, byte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (byte lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, sbyte rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (sbyte lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, sbyte rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (sbyte lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, sbyte rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (sbyte lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, sbyte rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (sbyte lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, sbyte rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (sbyte lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, short rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (short lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, short rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (short lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, short rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (short lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, short rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (short lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, short rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (short lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, ushort rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (ushort lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, ushort rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (ushort lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, ushort rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (ushort lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, ushort rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (ushort lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, ushort rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (ushort lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, int rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (int lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, int rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (int lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, int rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (int lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, int rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (int lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, int rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (int lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, uint rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (uint lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, uint rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (uint lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, uint rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (uint lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, uint rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (uint lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, uint rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (uint lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, long rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (long lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, long rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (long lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, long rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (long lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, long rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (long lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, long rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (long lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, ulong rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (ulong lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, ulong rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (ulong lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, ulong rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (ulong lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, ulong rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (ulong lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, ulong rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (ulong lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Int128 lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, Int128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Int128 lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, Int128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Int128 lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, Int128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Int128 lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, Int128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Int128 lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (double4x4 lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (UInt128 lhs, double4x4 rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (double4x4 lhs, UInt128 rhs) => lhs - (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (UInt128 lhs, double4x4 rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (double4x4 lhs, UInt128 rhs) => lhs * (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (UInt128 lhs, double4x4 rhs) => (double)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (double4x4 lhs, UInt128 rhs) => lhs / (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (UInt128 lhs, double4x4 rhs) => (double)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (double4x4 lhs, UInt128 rhs) => lhs % (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (UInt128 lhs, double4x4 rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, double rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, double rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, double rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, double rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, double rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, double rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, Unity.Mathematics.double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.double4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, quarter rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, quarter rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, quarter rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, quarter rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, quarter rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, quarter rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (quarter lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (quarter lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (quarter lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (quarter lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (quarter lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (quarter lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, half rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, half rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, half rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, half rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, half rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, half rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, Unity.Mathematics.half rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, Unity.Mathematics.half rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, Unity.Mathematics.half rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, Unity.Mathematics.half rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, Unity.Mathematics.half rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, Unity.Mathematics.half rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.half lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, float rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, float rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, float rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, float rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, float rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, float rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (float lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (float lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (float lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (float lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (float lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (float lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, float4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, float4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, float4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, float4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, float4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, float4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (float4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (float4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (float4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (float4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (float4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (float4x4 lhs, double4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs >= (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.float4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, byte4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, byte4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, byte4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, byte4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, byte4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, byte4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (byte4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, sbyte4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, sbyte4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, sbyte4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, sbyte4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, sbyte4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, sbyte4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (sbyte4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, short4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, short4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, short4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, short4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, short4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, short4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (short4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (short4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (short4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (short4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (short4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (short4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, ushort4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, ushort4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, ushort4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, ushort4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, ushort4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, ushort4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ushort4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, int4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, int4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, int4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, int4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, int4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, int4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (int4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (int4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (int4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (int4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (int4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (int4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, uint4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, uint4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, uint4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, uint4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, uint4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, uint4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (uint4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.int4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.uint4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, long4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, long4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, long4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, long4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, long4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, long4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (long4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (long4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (long4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (long4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (long4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (long4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, ulong4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, ulong4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, ulong4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, ulong4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, ulong4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, ulong4x4 rhs) => lhs >= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, double4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, byte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (byte lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, byte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (byte lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, byte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (byte lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, byte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (byte lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, byte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (byte lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, byte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (byte lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, sbyte rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (sbyte lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, sbyte rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (sbyte lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, sbyte rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (sbyte lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, sbyte rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (sbyte lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, sbyte rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (sbyte lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, sbyte rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (sbyte lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, short rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (short lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, short rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (short lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, short rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (short lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, short rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (short lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, short rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (short lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, short rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (short lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, ushort rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ushort lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, ushort rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ushort lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, ushort rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ushort lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, ushort rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ushort lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, ushort rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ushort lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, ushort rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ushort lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, int rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (int lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, int rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (int lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, int rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (int lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, int rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (int lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, int rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (int lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, int rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (int lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, uint rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (uint lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, uint rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (uint lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, uint rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (uint lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, uint rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (uint lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, uint rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (uint lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, uint rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (uint lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, long rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (long lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, long rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (long lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, long rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (long lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, long rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (long lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, long rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (long lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, long rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (long lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, ulong rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, ulong rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, ulong rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, ulong rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, ulong rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, ulong rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, Int128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Int128 lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, Int128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Int128 lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, Int128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Int128 lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, Int128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Int128 lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, Int128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Int128 lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, Int128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Int128 lhs, double4x4 rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (double4x4 lhs, UInt128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (UInt128 lhs, double4x4 rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (double4x4 lhs, UInt128 rhs) => lhs != (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (UInt128 lhs, double4x4 rhs) => (double)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (double4x4 lhs, UInt128 rhs) => lhs < (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (UInt128 lhs, double4x4 rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (double4x4 lhs, UInt128 rhs) => lhs > (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (UInt128 lhs, double4x4 rhs) => (double)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (double4x4 lhs, UInt128 rhs) => lhs <= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (UInt128 lhs, double4x4 rhs) => (double)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (double4x4 lhs, UInt128 rhs) => lhs >= (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (UInt128 lhs, double4x4 rhs) => (double)lhs >= rhs;


        public ref double4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (double4x4* array = &this) { return ref ((double4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(double4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.double4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is double4x4 converted && Equals(converted)) || (o is Unity.Mathematics.double4x4 convertedU && Equals(convertedU)) || (o is double convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.double4x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.double4x4)this).ToString(format, formatProvider);


        /// <summary>   Returns a <see cref="double4x4"/> matrix representing a rotation around a unit axis by an angle in radians. The rotation direction is clockwise when looking along the rotation axis towards the origin.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 AxisAngle(double3 axis, double angle)
        {
            math.sincos(angle, out double sina, out double cosa);

            double4 u = new double4(axis, 0d);
            double4 u_yzx = u.yzxx;
            double4 u_zxy = u.zxyx;
            double4 u_inv_cosa = u - u * cosa;  // u * (1d - cosa);
            double4 t = new double4(u.xyz * sina, cosa);

            ulong4 ppnp = new ulong4(             0,              0,      1ul << 63, 0);
            ulong4 nppp = new ulong4(     1ul << 63,              0,              0, 0);
            ulong4 pnpp = new ulong4(             0,      1ul << 63,              0, 0);
            ulong4 mask = new ulong4(ulong.MaxValue, ulong.MaxValue, ulong.MaxValue, 0);

            return new double4x4(
                u.x * u_inv_cosa + math.asdouble((math.asulong(t.wzyx) ^ ppnp) & mask),
                u.y * u_inv_cosa + math.asdouble((math.asulong(t.zwxx) ^ nppp) & mask),
                u.z * u_inv_cosa + math.asdouble((math.asulong(t.yxwx) ^ pnpp) & mask),
                new double4(0d, 0d, 0d, 1d)
                );

        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerXYZ(double3 xyz)
        {
            math.sincos(xyz, out double3 s, out double3 c);
            return new double4x4(
                c.y * c.z,  c.z * s.x * s.y - c.x * s.z,    c.x * c.z * s.y + s.x * s.z,    0d,
                c.y * s.z,  c.x * c.z + s.x * s.y * s.z,    c.x * s.y * s.z - c.z * s.x,    0d,
                -s.y,       c.y * s.x,                      c.x * c.y,                      0d,
                0d,       0d,                           0d,                           1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerXZY(double3 xyz)
        {
            math.sincos(xyz, out double3 s, out double3 c);
            return new double4x4(
                c.y * c.z,  s.x * s.y - c.x * c.y * s.z,    c.x * s.y + c.y * s.x * s.z,    0d,
                s.z,        c.x * c.z,                      -c.z * s.x,                     0d,
                -c.z * s.y, c.y * s.x + c.x * s.y * s.z,    c.x * c.y - s.x * s.y * s.z,    0d,
                0d,       0d,                           0d,                           1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerYXZ(double3 xyz)
        {
            math.sincos(xyz, out double3 s, out double3 c);
            return new double4x4(
                c.y * c.z - s.x * s.y * s.z,    -c.x * s.z, c.z * s.y + c.y * s.x * s.z,    0d,
                c.z * s.x * s.y + c.y * s.z,    c.x * c.z,  s.y * s.z - c.y * c.z * s.x,    0d,
                -c.x * s.y,                     s.x,        c.x * c.y,                      0d,
                0d,                           0d,       0d,                           1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerYZX(double3 xyz)
        {
            math.sincos(xyz, out double3 s, out double3 c);
            return new double4x4(
                c.y * c.z,                      -s.z,       c.z * s.y,                      0d,
                s.x * s.y + c.x * c.y * s.z,    c.x * c.z,  c.x * s.y * s.z - c.y * s.x,    0d,
                c.y * s.x * s.z - c.x * s.y,    c.z * s.x,  c.x * c.y + s.x * s.y * s.z,    0d,
                0d,                           0d,       0d,                           1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerZXY(double3 xyz)
        {
            math.sincos(xyz, out double3 s, out double3 c);
            return new double4x4(
                c.y * c.z + s.x * s.y * s.z,    c.z * s.x * s.y - c.y * s.z,    c.x * s.y,  0d,
                c.x * s.z,                      c.x * c.z,                      -s.x,       0d,
                c.y * s.x * s.z - c.z * s.y,    c.y * c.z * s.x + s.y * s.z,    c.x * c.y,  0d,
                0d,                           0d,                           0d,       1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerZYX(double3 xyz)
        {
            math.sincos(xyz, out double3 s, out double3 c);
            return new double4x4(
                c.y * c.z,                      -c.y * s.z,                     s.y,        0d,
                c.z * s.x * s.y + c.x * s.z,    c.x * c.z - s.x * s.y * s.z,    -c.y * s.x, 0d,
                s.x * s.z - c.x * c.z * s.y,    c.z * s.x + c.x * s.y * s.z,    c.x * c.y,  0d,
                0d,                           0d,                           0d,       1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerXYZ(double x, double y, double z) { return EulerXYZ(new double3(x, y, z)); }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerXZY(double x, double y, double z) { return EulerXZY(new double3(x, y, z)); }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerYXZ(double x, double y, double z) { return EulerYXZ(new double3(x, y, z)); }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerYZX(double x, double y, double z) { return EulerYZX(new double3(x, y, z)); }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerZXY(double x, double y, double z) { return EulerZXY(new double3(x, y, z)); }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 EulerZYX(double x, double y, double z) { return EulerZYX(new double3(x, y, z)); }

        /// <summary>   Returns a <see cref="double4x4"/> constructed by first performing 3 rotations around the principal axes in a given order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. When the rotation order is known at compile time, it is recommended for performance reasons to use specific Euler rotation constructors such as EulerZXY(...).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Euler(double3 xyz, math.RotationOrder order = math.RotationOrder.Default)
        {
            switch (order)
            {
                case math.RotationOrder.XYZ: return EulerXYZ(xyz);
                case math.RotationOrder.XZY: return EulerXZY(xyz);
                case math.RotationOrder.YXZ: return EulerYXZ(xyz);
                case math.RotationOrder.YZX: return EulerYZX(xyz);
                case math.RotationOrder.ZXY: return EulerZXY(xyz);
                case math.RotationOrder.ZYX: return EulerZYX(xyz);
                default:                     return double4x4.identity;
            }
        }

        /// <summary>   Returns a <see cref="double4x4"/> rotation matrix constructed by first performing 3 rotations around the principal axes in a given order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. When the rotation order is known at compile time, it is recommended for performance reasons to use specific Euler rotation constructors such as EulerZXY(...).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Euler(double x, double y, double z, math.RotationOrder order = math.RotationOrder.Default)
        {
            return Euler(new double3(x, y, z), order);
        }

        /// <summary>   Returns a <see cref="double4x4"/> matrix that rotates around the x-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 RotateX(double angle)
        {
            math.sincos(angle, out double s, out double c);
            return new double4x4(1d, 0d, 0d, 0d,
                                 0d, c,    -s,   0d,
                                 0d, s,    c,    0d,
                                 0d, 0d, 0d, 1d);
        }

        /// <summary>   Returns a <see cref="double4x4"/> matrix that rotates around the y-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 RotateY(double angle)
        {
            math.sincos(angle, out double s, out double c);
            return new double4x4(c,    0d, s,    0d,
                                 0d, 1d, 0d, 0d,
                                 -s,   0d, c,    0d,
                                 0d, 0d, 0d, 1d);
        }

        /// <summary>   Returns a <see cref="double4x4"/> matrix that rotates around the z-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 RotateZ(double angle)
        {
            math.sincos(angle, out double s, out double c);
            return new double4x4(c,    -s,   0d, 0d,
                                 s,    c,    0d, 0d,
                                 0d, 0d, 1d, 0d,
                                 0d, 0d, 0d, 1d);
        }

        /// <summary>   Returns a <see cref="double4x4"/> scale matrix given 3 axis scales.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Scale(double s)
        {
            return new double4x4(s,    0d, 0d, 0d,
                                 0d, s,    0d, 0d,
                                 0d, 0d, s,    0d,
                                 0d, 0d, 0d, 1d);
        }

        /// <summary>   Returns a <see cref="double4x4"/> scale matrix given a <see cref="double3"/> vector containing the 3 axis scales.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Scale(double x, double y, double z)
        {
            return new double4x4(x,    0d, 0d, 0d,
                                 0d, y,    0d, 0d,
                                 0d, 0d, z,    0d,
                                 0d, 0d, 0d, 1d);
        }

        /// <summary>   Returns a <see cref="double4x4"/> scale matrix given a <see cref="double3"/> vector containing the 3 axis scales.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Scale(double3 scales)
        {
            return Scale(scales.x, scales.y, scales.z);
        }

        /// <summary>   Returns a <see cref="double4x4"/> translation matrix given a <see cref="double3"/> translation vector.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Translate(double3 vector)
        {
            return new double4x4(new double4(1d, 0d, 0d, 0d),
                                 new double4(0d, 1d, 0d, 0d),
                                 new double4(0d, 0d, 1d, 0d),
                                 new double4(vector.x, vector.y, vector.z, 1d));
        }

        /// <summary>   Returns a <see cref="double4x4"/> view matrix given an eye position, a target point and a unit length up vector. The up vector is assumed to be unit length, the eye and target points are assumed to be distinct and the vector between them is assumes to be collinear with the up vector. If these assumptions are not met use <see cref="double4x4.LookRotationSafe"/> instead. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 LookAt(double3 eye, double3 target, double3 up)
        {
            double3x3 rot = double3x3.LookRotation(math.normalize(target - eye), up);

            double4x4 matrix;
            matrix.c0 = new double4(rot.c0, 0d);
            matrix.c1 = new double4(rot.c1, 0d);
            matrix.c2 = new double4(rot.c2, 0d);
            matrix.c3 = new double4(eye, 1d);
            return matrix;
        }

        /// <summary>   Returns a <see cref="double4x4"/> centered orthographic projection matrix.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 Ortho(double width, double height, double near, double far)
        {
            double dx = width;
            double dy = height;
            double dz = far - near;

            return new double4x4(
                2d / dx,   0d,            0d,           0d,
                0d,           2d / dy,    0d,           0d,
                0d,           0d,           -2d / dz,  -(far + near) / dz,
                0d,           0d,            0d,           1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> off-center orthographic projection matrix.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 OrthoOffCenter(double left, double right, double bottom, double top, double near, double far)
        {
            double dx = right - left;
            double dy = top - bottom;
            double dz = far - near;

            return new double4x4(
                2d / dx,   0d,           0d,               -(right + left) / dx,
                0d,           2d / dy,   0d,               -(top + bottom) / dy,
                0d,           0d,          -2d / dz,       -(far + near) / dz,
                0d,           0d,           0d,                1d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> perspective projection matrix based on field of view.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 PerspectiveFov(double verticalFov, double aspect, double near, double far)
        {
            double cotangent = math.rcp(math.tan(verticalFov * 0.5d));
            double dz = near - far;

            return new double4x4(
                cotangent / aspect, 0d,       0d,                   0d,
                0d,               cotangent,  0d,                   0d,
                0d,               0d,       (far + near) / dz,   2d * near * far / dz,
                0d,               0d,      -1d,                   0d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> off-center perspective projection matrix.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 PerspectiveOffCenter(double left, double right, double bottom, double top, double near, double far)
        {
            double dz = near - far;
            double Width = right - left;
            double Height = top - bottom;

            return new double4x4(
                2d * near / Width,     0d,                       (left + right) / Width,     0d,
                0d,                       2d * near / Height,    (bottom + top) / Height,    0d,
                0d,                       0d,                        (far + near) / dz,          2d * near * far / dz,
                0d,                       0d,                       -1d,                          0d
                );
        }

        /// <summary>   Returns a <see cref="double4x4"/> matrix representing a combined scale-, rotation- and translation transform. Equivalent to mul(translationTransform, mul(rotationTransform, scaleTransform)).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 TRS(double3 translation, quaternion rotation, double3 scale)
        {
            double3x3 r = new double3x3(rotation);
            return new double4x4(new double4(r.c0 * scale.x, 0d),
                                 new double4(r.c1 * scale.y, 0d),
                                 new double4(r.c2 * scale.z, 0d),
                                 new double4(translation, 1d));
        }
    }
}
