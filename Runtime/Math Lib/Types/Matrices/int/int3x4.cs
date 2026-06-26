using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int3x4 : IEquatable<int3x4>, IEquatable<Unity.Mathematics.int3x4>, IEquatable<int>, IFormattable
    {
        public int3 c0;
        public int3 c1;
        public int3 c2;
        public int3 c3;

        public static int3x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(int3 c0, int3 c1, int3 c2, int3 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(int m00, int m01, int m02, int m03,
                      int m10, int m11, int m12, int m13,
                      int m20, int m21, int m22, int m23)
        {
            this.c0 = new int3(m00, m10, m20);
            this.c1 = new int3(m01, m11, m21);
            this.c2 = new int3(m02, m12, m22);
            this.c3 = new int3(m03, m13, m23);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(bool v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(bool3x4 v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(mask8x3x4 v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(mask16x3x4 v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(mask32x3x4 v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(mask64x3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(byte v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(byte3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(sbyte v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(sbyte3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(ushort v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(ushort3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(short v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(short3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(int v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(int3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(uint v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(uint3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(ulong v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(ulong3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(long v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(long3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(UInt128 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Int128 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(quarter v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(half v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(float v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(float3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(double v)
        {
            this = (int3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(double3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(quadruple v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Unity.Mathematics.bool3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Unity.Mathematics.int3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Unity.Mathematics.uint3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Unity.Mathematics.half v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Unity.Mathematics.float3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x4(Unity.Mathematics.double3x4 v)
        {
            this = (int3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(Unity.Mathematics.int3x4 v) => new int3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3x4(int3x4 v) => new Unity.Mathematics.int3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(int3x4 v) => new bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(Unity.Mathematics.bool3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x4(int3x4 v) => new Unity.Mathematics.bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(Unity.Mathematics.uint3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x4(int3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(Unity.Mathematics.float3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x4(int3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(Unity.Mathematics.half v) => (int3x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(Unity.Mathematics.double3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x4(int3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(int v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(bool v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(bool3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x4(sbyte v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(sbyte3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x4(short v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(short3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(long v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(long3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x4(byte v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(byte3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x4(ushort v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(ushort3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(uint v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(uint3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(ulong v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(ulong3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(float v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(float3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(half v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(double v) => new int3x4 { c0 = (int3)v, c1 = (int3)v, c2 = (int3)v, c3 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(double3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(mask8x3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(mask16x3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(mask32x3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x4(mask64x3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x4(int3x4 v) => new mask8x3x4 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1, c2 = (mask8x3)v.c2, c3 = (mask8x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x4(int3x4 v) => new mask16x3x4 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1, c2 = (mask16x3)v.c2, c3 = (mask16x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x4(int3x4 v) => new mask32x3x4 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1, c2 = (mask32x3)v.c2, c3 = (mask32x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x4(int3x4 v) => new mask64x3x4 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1, c2 = (mask64x3)v.c2, c3 = (mask64x3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ++ (int3x4 val) => new int3x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator -- (int3x4 val) => new int3x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs + (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs - (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs * (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs / (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs % (int3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator + (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs + (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator - (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs - (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator * (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs * (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator / (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs / (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator % (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs % (float3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator + (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator - (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator * (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator / (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator % (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs % (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, byte3x4 rhs) => lhs + (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, byte3x4 rhs) => lhs - (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, byte3x4 rhs) => lhs * (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, byte3x4 rhs) => lhs / (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, byte3x4 rhs) => lhs % (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, sbyte3x4 rhs) => lhs + (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, sbyte3x4 rhs) => lhs - (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, sbyte3x4 rhs) => lhs * (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, sbyte3x4 rhs) => lhs / (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, sbyte3x4 rhs) => lhs % (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, ushort3x4 rhs) => lhs + (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, ushort3x4 rhs) => lhs - (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, ushort3x4 rhs) => lhs * (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, ushort3x4 rhs) => lhs / (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, ushort3x4 rhs) => lhs % (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, short3x4 rhs) => lhs + (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, short3x4 rhs) => lhs - (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, short3x4 rhs) => lhs * (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, short3x4 rhs) => lhs / (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, short3x4 rhs) => lhs % (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (short3x4 lhs, int3x4 rhs) => (int3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (short3x4 lhs, int3x4 rhs) => (int3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (short3x4 lhs, int3x4 rhs) => (int3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (short3x4 lhs, int3x4 rhs) => (int3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (short3x4 lhs, int3x4 rhs) => (int3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (byte lhs, int3x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (byte lhs, int3x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (byte lhs, int3x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (byte lhs, int3x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (byte lhs, int3x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (sbyte lhs, int3x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (sbyte lhs, int3x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (sbyte lhs, int3x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (sbyte lhs, int3x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (sbyte lhs, int3x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (ushort lhs, int3x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (ushort lhs, int3x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (ushort lhs, int3x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (ushort lhs, int3x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (ushort lhs, int3x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (int3x4 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator + (short lhs, int3x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (int3x4 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator - (short lhs, int3x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (int3x4 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator * (short lhs, int3x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (int3x4 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator / (short lhs, int3x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (int3x4 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator % (short lhs, int3x4 rhs) => (int)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator << (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs, c3 = lhs.c3 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator >> (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs, c3 = lhs.c3 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ~ (int3x4 v) => new int3x4 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2, c3 = ~v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, int3x4 rhs) => new int3x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, int rhs) => new int3x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int lhs, int3x4 rhs) => new int3x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs & (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs | (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs ^ (int3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, byte3x4 rhs) => lhs & (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, byte3x4 rhs) => lhs | (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, byte3x4 rhs) => lhs ^ (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, sbyte3x4 rhs) => lhs & (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, sbyte3x4 rhs) => lhs | (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, sbyte3x4 rhs) => lhs ^ (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, ushort3x4 rhs) => lhs & (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, ushort3x4 rhs) => lhs | (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, ushort3x4 rhs) => lhs ^ (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, short3x4 rhs) => lhs & (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, short3x4 rhs) => lhs | (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, short3x4 rhs) => lhs ^ (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (short3x4 lhs, int3x4 rhs) => (int3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (short3x4 lhs, int3x4 rhs) => (int3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (short3x4 lhs, int3x4 rhs) => (int3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (byte lhs, int3x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (byte lhs, int3x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (byte lhs, int3x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (sbyte lhs, int3x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (sbyte lhs, int3x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (sbyte lhs, int3x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (ushort lhs, int3x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (ushort lhs, int3x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (ushort lhs, int3x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (int3x4 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator & (short lhs, int3x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (int3x4 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator | (short lhs, int3x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (int3x4 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x4 operator ^ (short lhs, int3x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, int rhs) => new mask32x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, int rhs) => new mask32x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, int rhs) => new mask32x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, int rhs) => new mask32x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, int rhs) => new mask32x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, int rhs) => new mask32x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int lhs, int3x4 rhs) => new mask32x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs == (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs != (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs < (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs > (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs <= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, Unity.Mathematics.int3x4 rhs) => lhs >= (int3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (Unity.Mathematics.int3x4 lhs, int3x4 rhs) => (int3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs == (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs != (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs < (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs > (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs <= (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs >= (float3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (Unity.Mathematics.float3x4 lhs, int3x4 rhs) => (float3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (int3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs >= (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.double3x4 lhs, int3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, byte3x4 rhs) => lhs == (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, byte3x4 rhs) => lhs != (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, byte3x4 rhs) => lhs < (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, byte3x4 rhs) => lhs > (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, byte3x4 rhs) => lhs <= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, byte3x4 rhs) => lhs >= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (byte3x4 lhs, int3x4 rhs) => (int3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, sbyte3x4 rhs) => lhs == (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, sbyte3x4 rhs) => lhs != (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, sbyte3x4 rhs) => lhs < (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, sbyte3x4 rhs) => lhs > (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, sbyte3x4 rhs) => lhs <= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, sbyte3x4 rhs) => lhs >= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (sbyte3x4 lhs, int3x4 rhs) => (int3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, ushort3x4 rhs) => lhs == (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, ushort3x4 rhs) => lhs != (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, ushort3x4 rhs) => lhs < (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, ushort3x4 rhs) => lhs > (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, ushort3x4 rhs) => lhs <= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, ushort3x4 rhs) => lhs >= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (ushort3x4 lhs, int3x4 rhs) => (int3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, short3x4 rhs) => lhs == (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, short3x4 rhs) => lhs != (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, short3x4 rhs) => lhs < (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, short3x4 rhs) => lhs > (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, short3x4 rhs) => lhs <= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, short3x4 rhs) => lhs >= (int3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (short3x4 lhs, int3x4 rhs) => (int3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (short3x4 lhs, int3x4 rhs) => (int3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (short3x4 lhs, int3x4 rhs) => (int3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (short3x4 lhs, int3x4 rhs) => (int3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (short3x4 lhs, int3x4 rhs) => (int3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (short3x4 lhs, int3x4 rhs) => (int3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (byte lhs, int3x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (byte lhs, int3x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (byte lhs, int3x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (byte lhs, int3x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (byte lhs, int3x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (byte lhs, int3x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (sbyte lhs, int3x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (sbyte lhs, int3x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (sbyte lhs, int3x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (sbyte lhs, int3x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (sbyte lhs, int3x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (sbyte lhs, int3x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (ushort lhs, int3x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (ushort lhs, int3x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (ushort lhs, int3x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (ushort lhs, int3x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (ushort lhs, int3x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (ushort lhs, int3x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (int3x4 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (short lhs, int3x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (int3x4 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (short lhs, int3x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (int3x4 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (short lhs, int3x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (int3x4 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (short lhs, int3x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (int3x4 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (short lhs, int3x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (int3x4 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (short lhs, int3x4 rhs) => (int)lhs >= rhs;


        public ref int3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (int3x4* array = &this) { return ref ((int3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is int3x4 converted && Equals(converted)) || (o is Unity.Mathematics.int3x4 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.int3x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.int3x4)this).ToString(format, formatProvider);
    }
}
