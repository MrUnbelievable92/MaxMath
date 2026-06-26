using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int4x4 : IEquatable<int4x4>, IEquatable<Unity.Mathematics.int4x4>, IEquatable<int>, IFormattable
    {
        public int4 c0;
        public int4 c1;
        public int4 c2;
        public int4 c3;

        public static int4x4 identity => new int4x4(1, 0, 0, 0,   0, 1, 0, 0,   0, 0, 1, 0,   0, 0, 0, 1);
        public static int4x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(int4 c0, int4 c1, int4 c2, int4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(int m00, int m01, int m02, int m03,
                      int m10, int m11, int m12, int m13,
                      int m20, int m21, int m22, int m23,
                      int m30, int m31, int m32, int m33)
        {
            this.c0 = new int4(m00, m10, m20, m30);
            this.c1 = new int4(m01, m11, m21, m31);
            this.c2 = new int4(m02, m12, m22, m32);
            this.c3 = new int4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(bool v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(bool4x4 v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(mask8x4x4 v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(mask16x4x4 v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(mask32x4x4 v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(mask64x4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(byte v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(byte4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(sbyte v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(sbyte4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(ushort v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(ushort4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(short v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(short4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(int v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(int4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(uint v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(uint4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(ulong v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(ulong4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(long v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(long4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(UInt128 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Int128 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(quarter v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(half v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(float v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(float4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(double v)
        {
            this = (int4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(double4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(quadruple v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Unity.Mathematics.int4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Unity.Mathematics.half v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Unity.Mathematics.float4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x4(Unity.Mathematics.double4x4 v)
        {
            this = (int4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(Unity.Mathematics.int4x4 v) => new int4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4x4(int4x4 v) => new Unity.Mathematics.int4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(int4x4 v) => new bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(Unity.Mathematics.bool4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x4(int4x4 v) => new Unity.Mathematics.bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(Unity.Mathematics.uint4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x4(int4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(Unity.Mathematics.float4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x4(int4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(Unity.Mathematics.half v) => (int4x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(Unity.Mathematics.double4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x4(int4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(int v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(bool v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(bool4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x4(sbyte v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(sbyte4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x4(short v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(short4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(long v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(long4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x4(byte v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(byte4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x4(ushort v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x4(ushort4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(uint v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(uint4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(ulong v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(ulong4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(float v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(float4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(half v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(double v) => new int4x4 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v, c3 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(double4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(mask8x4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(mask16x4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(mask32x4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x4(mask64x4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x4(int4x4 v) => new mask8x4x4 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2, c3 = (mask8x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x4(int4x4 v) => new mask16x4x4 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2, c3 = (mask16x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(int4x4 v) => new mask32x4x4 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2, c3 = (mask32x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x4(int4x4 v) => new mask64x4x4 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2, c3 = (mask64x4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ++ (int4x4 val) => new int4x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator -- (int4x4 val) => new int4x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs + (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs - (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs * (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs / (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs % (int4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs % (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs % (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, byte4x4 rhs) => lhs + (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, byte4x4 rhs) => lhs - (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, byte4x4 rhs) => lhs * (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, byte4x4 rhs) => lhs / (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, byte4x4 rhs) => lhs % (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, sbyte4x4 rhs) => lhs + (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, sbyte4x4 rhs) => lhs - (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, sbyte4x4 rhs) => lhs * (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, sbyte4x4 rhs) => lhs / (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, sbyte4x4 rhs) => lhs % (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, ushort4x4 rhs) => lhs + (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, ushort4x4 rhs) => lhs - (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, ushort4x4 rhs) => lhs * (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, ushort4x4 rhs) => lhs / (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, ushort4x4 rhs) => lhs % (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, short4x4 rhs) => lhs + (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, short4x4 rhs) => lhs - (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, short4x4 rhs) => lhs * (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, short4x4 rhs) => lhs / (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, short4x4 rhs) => lhs % (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (short4x4 lhs, int4x4 rhs) => (int4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (short4x4 lhs, int4x4 rhs) => (int4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (short4x4 lhs, int4x4 rhs) => (int4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (short4x4 lhs, int4x4 rhs) => (int4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (short4x4 lhs, int4x4 rhs) => (int4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (byte lhs, int4x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (byte lhs, int4x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (byte lhs, int4x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (byte lhs, int4x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (byte lhs, int4x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (sbyte lhs, int4x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (sbyte lhs, int4x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (sbyte lhs, int4x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (sbyte lhs, int4x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (sbyte lhs, int4x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (ushort lhs, int4x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (ushort lhs, int4x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (ushort lhs, int4x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (ushort lhs, int4x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (ushort lhs, int4x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (int4x4 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator + (short lhs, int4x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (int4x4 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator - (short lhs, int4x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (int4x4 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator * (short lhs, int4x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (int4x4 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator / (short lhs, int4x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (int4x4 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator % (short lhs, int4x4 rhs) => (int)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator << (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs, c3 = lhs.c3 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator >> (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs, c3 = lhs.c3 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ~ (int4x4 v) => new int4x4 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2, c3 = ~v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, int4x4 rhs) => new int4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, int rhs) => new int4x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int lhs, int4x4 rhs) => new int4x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs & (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs | (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs ^ (int4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, byte4x4 rhs) => lhs & (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, byte4x4 rhs) => lhs | (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, byte4x4 rhs) => lhs ^ (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, sbyte4x4 rhs) => lhs & (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, sbyte4x4 rhs) => lhs | (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, sbyte4x4 rhs) => lhs ^ (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, ushort4x4 rhs) => lhs & (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, ushort4x4 rhs) => lhs | (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, ushort4x4 rhs) => lhs ^ (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, short4x4 rhs) => lhs & (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, short4x4 rhs) => lhs | (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, short4x4 rhs) => lhs ^ (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (short4x4 lhs, int4x4 rhs) => (int4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (short4x4 lhs, int4x4 rhs) => (int4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (short4x4 lhs, int4x4 rhs) => (int4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (byte lhs, int4x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (byte lhs, int4x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (byte lhs, int4x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (sbyte lhs, int4x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (sbyte lhs, int4x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (sbyte lhs, int4x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (ushort lhs, int4x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (ushort lhs, int4x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (ushort lhs, int4x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (int4x4 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator & (short lhs, int4x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (int4x4 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator | (short lhs, int4x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (int4x4 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x4 operator ^ (short lhs, int4x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, int rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, int rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, int rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, int rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, int rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, int rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int lhs, int4x4 rhs) => new mask32x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs == (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs != (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs < (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs > (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs <= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs >= (int4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.int4x4 lhs, int4x4 rhs) => (int4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs >= (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.float4x4 lhs, int4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (int4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs >= (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.double4x4 lhs, int4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, byte4x4 rhs) => lhs == (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, byte4x4 rhs) => lhs != (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, byte4x4 rhs) => lhs < (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, byte4x4 rhs) => lhs > (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, byte4x4 rhs) => lhs <= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, byte4x4 rhs) => lhs >= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (byte4x4 lhs, int4x4 rhs) => (int4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, sbyte4x4 rhs) => lhs == (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, sbyte4x4 rhs) => lhs != (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, sbyte4x4 rhs) => lhs < (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, sbyte4x4 rhs) => lhs > (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, sbyte4x4 rhs) => lhs <= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, sbyte4x4 rhs) => lhs >= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (sbyte4x4 lhs, int4x4 rhs) => (int4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, ushort4x4 rhs) => lhs == (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, ushort4x4 rhs) => lhs != (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, ushort4x4 rhs) => lhs < (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, ushort4x4 rhs) => lhs > (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, ushort4x4 rhs) => lhs <= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, ushort4x4 rhs) => lhs >= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ushort4x4 lhs, int4x4 rhs) => (int4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, short4x4 rhs) => lhs == (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, short4x4 rhs) => lhs != (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, short4x4 rhs) => lhs < (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, short4x4 rhs) => lhs > (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, short4x4 rhs) => lhs <= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, short4x4 rhs) => lhs >= (int4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (short4x4 lhs, int4x4 rhs) => (int4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (short4x4 lhs, int4x4 rhs) => (int4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (short4x4 lhs, int4x4 rhs) => (int4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (short4x4 lhs, int4x4 rhs) => (int4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (short4x4 lhs, int4x4 rhs) => (int4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (short4x4 lhs, int4x4 rhs) => (int4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (byte lhs, int4x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (byte lhs, int4x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (byte lhs, int4x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (byte lhs, int4x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (byte lhs, int4x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (byte lhs, int4x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (sbyte lhs, int4x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (sbyte lhs, int4x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (sbyte lhs, int4x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (sbyte lhs, int4x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (sbyte lhs, int4x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (sbyte lhs, int4x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ushort lhs, int4x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ushort lhs, int4x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ushort lhs, int4x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ushort lhs, int4x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ushort lhs, int4x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ushort lhs, int4x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (short lhs, int4x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (short lhs, int4x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (short lhs, int4x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (short lhs, int4x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (short lhs, int4x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (short lhs, int4x4 rhs) => (int)lhs >= rhs;


        public ref int4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (int4x4* array = &this) { return ref ((int4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is int4x4 converted && Equals(converted)) || (o is Unity.Mathematics.int4x4 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.int4x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.int4x4)this).ToString(format, formatProvider);
    }
}
