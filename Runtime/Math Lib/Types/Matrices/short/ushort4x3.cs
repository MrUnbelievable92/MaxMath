using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct ushort4x3 : IEquatable<ushort4x3>, IFormattable
    {
        public ushort4 c0;
        public ushort4 c1;
        public ushort4 c2;

        public static ushort4x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort4 c0, ushort4 c1, ushort4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort m00, ushort m01, ushort m02,
                         ushort m10, ushort m11, ushort m12,
                         ushort m20, ushort m21, ushort m22,
                         ushort m30, ushort m31, ushort m32)
        {
            this.c0 = new ushort4(m00, m10, m20, m30);
            this.c1 = new ushort4(m01, m11, m21, m31);
            this.c2 = new ushort4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(bool v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(bool4x3 v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(mask8x4x3 v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(mask16x4x3 v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(mask32x4x3 v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(mask64x4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(byte v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(byte4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(sbyte v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(sbyte4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(short v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(short4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(uint v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(uint4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(int v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(int4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(long v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(long4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ulong v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ulong4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(UInt128 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Int128 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(quarter v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(half v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(float v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(float4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(double v)
        {
            this = (ushort4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(double4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(quadruple v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Unity.Mathematics.bool4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Unity.Mathematics.uint4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Unity.Mathematics.int4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Unity.Mathematics.half v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Unity.Mathematics.float4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(Unity.Mathematics.double4x3 v)
        {
            this = (ushort4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(UInt128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Int128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(quarter x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(quadruple x) => (ushort)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(ushort4x3 v) => new bool4x3 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Unity.Mathematics.bool4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x3(ushort4x3 v) => new Unity.Mathematics.bool4x3 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Unity.Mathematics.int4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4x3(ushort4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Unity.Mathematics.uint4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4x3(ushort4x3 v) => new uint4x3 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Unity.Mathematics.half v) => (ushort4x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Unity.Mathematics.float4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x3(ushort4x3 v) => new float4x3 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(Unity.Mathematics.double4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x3(ushort4x3 v) => new double4x3 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4x3(ushort v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(bool v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(bool4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(sbyte v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(sbyte4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(short v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(short4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(int v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(int4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(long v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(long4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ushort4x3(byte v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4x3(byte4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(uint v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(uint4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(ulong v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(ulong4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(half v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(float v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(float4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(double v) => new ushort4x3 { c0 = (ushort4)v, c1 = (ushort4)v, c2 = (ushort4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(double4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(mask8x4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(mask16x4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(mask32x4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(mask64x4x3 v) => new ushort4x3 { c0 = (ushort4)v.c0, c1 = (ushort4)v.c1, c2 = (ushort4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x3(ushort4x3 v) => new mask8x4x3 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x3(ushort4x3 v) => new mask16x4x3 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x3(ushort4x3 v) => new mask32x4x3 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x3(ushort4x3 v) => new mask64x4x3 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ++ (ushort4x3 val) => new ushort4x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator -- (ushort4x3 val) => new ushort4x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator + (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs + (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator - (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs - (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator * (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs * (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator / (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs / (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator % (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs % (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator + (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator - (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator * (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator / (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator % (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs + (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs - (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs * (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs / (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs % (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator + (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs + (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator - (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs - (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator * (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs * (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator / (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs / (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator % (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs % (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator + (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator - (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator * (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator / (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator % (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs % (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ~ (ushort4x3 val) => new ushort4x3 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator << (ushort4x3 val, int n) => new ushort4x3 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator >> (ushort4x3 val, int n) => new ushort4x3 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (ushort4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (ushort4x3 lhs, ushort rhs) => new ushort4x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (ushort lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (ushort4x3 lhs, byte4x3 rhs) => new ushort4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (byte4x3 lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator & (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs & (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator | (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs | (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ^ (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs ^ (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator & (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator | (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x3 operator ^ (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs & (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs | (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs ^ (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (ushort4x3 lhs, byte rhs) => new ushort4x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (byte lhs, ushort4x3 rhs) => new ushort4x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (ushort4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (ushort4x3 lhs, ushort rhs) => new mask16x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (ushort lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (ushort4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (ushort4x3 lhs, ushort rhs) => new mask16x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (ushort lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (ushort4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (ushort4x3 lhs, ushort rhs) => new mask16x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (ushort lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (ushort4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (ushort4x3 lhs, ushort rhs) => new mask16x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (ushort lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (ushort4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (ushort4x3 lhs, ushort rhs) => new mask16x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (ushort lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (ushort4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (ushort4x3 lhs, ushort rhs) => new mask16x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (ushort lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (ushort4x3 lhs, byte4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (ushort4x3 lhs, byte4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (ushort4x3 lhs, byte4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (ushort4x3 lhs, byte4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (ushort4x3 lhs, byte4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (ushort4x3 lhs, byte4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (byte4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (byte4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (byte4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (byte4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (byte4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (byte4x3 lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs == (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs != (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs < (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs > (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs <= (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (ushort4x3 lhs, Unity.Mathematics.uint4x3 rhs) => lhs >= (uint4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (Unity.Mathematics.uint4x3 lhs, ushort4x3 rhs) => (uint4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs == (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs != (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs < (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs > (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs <= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (ushort4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs >= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (Unity.Mathematics.int4x3 lhs, ushort4x3 rhs) => (int4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs == (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs != (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs < (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs > (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs <= (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (ushort4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs >= (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (Unity.Mathematics.float4x3 lhs, ushort4x3 rhs) => (float4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (ushort4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs >= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.double4x3 lhs, ushort4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (ushort4x3 lhs, byte rhs) => new mask16x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator == (byte lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (ushort4x3 lhs, byte rhs) => new mask16x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator != (byte lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (ushort4x3 lhs, byte rhs) => new mask16x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator < (byte lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (ushort4x3 lhs, byte rhs) => new mask16x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator > (byte lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (ushort4x3 lhs, byte rhs) => new mask16x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator <= (byte lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (ushort4x3 lhs, byte rhs) => new mask16x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4x3 operator >= (byte lhs, ushort4x3 rhs) => new mask16x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        public ref ushort4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (ushort4x3* array = &this) { return ref ((ushort4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ushort4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        public override readonly bool Equals(object obj) => obj is ushort4x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"ushort4x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z},  {c0.w}, {c1.w}, {c2.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ushort4x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)})";
    }
}