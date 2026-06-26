using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int4x3 : IEquatable<int4x3>, IEquatable<Unity.Mathematics.int4x3>, IEquatable<int>, IFormattable
    {
        public int4 c0;
        public int4 c1;
        public int4 c2;

        public static int4x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int4 c0, int4 c1, int4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int m00, int m01, int m02,
                      int m10, int m11, int m12,
                      int m20, int m21, int m22,
                      int m30, int m31, int m32)
        {
            this.c0 = new int4(m00, m10, m20, m30);
            this.c1 = new int4(m01, m11, m21, m31);
            this.c2 = new int4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(bool v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(bool4x3 v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(mask8x4x3 v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(mask16x4x3 v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(mask32x4x3 v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(mask64x4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(byte v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(byte4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(sbyte v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(sbyte4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(ushort v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(ushort4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(short v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(short4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(int4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(uint v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(uint4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(ulong v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(ulong4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(long v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(long4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(UInt128 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Int128 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(quarter v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(half v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(float v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(float4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(double v)
        {
            this = (int4x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(double4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(quadruple v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Unity.Mathematics.bool4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Unity.Mathematics.int4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Unity.Mathematics.uint4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Unity.Mathematics.half v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Unity.Mathematics.float4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int4x3(Unity.Mathematics.double4x3 v)
        {
            this = (int4x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(Unity.Mathematics.int4x3 v) => new int4x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4x3(int4x3 v) => new Unity.Mathematics.int4x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x3(int4x3 v) => new bool4x3 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(Unity.Mathematics.bool4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x3(int4x3 v) => new Unity.Mathematics.bool4x3 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(Unity.Mathematics.uint4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x3(int4x3 v) => new uint4x3 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(Unity.Mathematics.float4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x3(int4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(Unity.Mathematics.half v) => (int4x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(Unity.Mathematics.double4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x3(int4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(int v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(bool v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(bool4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x3(sbyte v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(sbyte4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x3(short v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(short4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(long v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(long4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x3(byte v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(byte4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int4x3(ushort v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(ushort4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(uint v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(uint4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(ulong v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(ulong4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(float v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(float4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(half v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(double v) => new int4x3 { c0 = (int4)v, c1 = (int4)v, c2 = (int4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(double4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(mask8x4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(mask16x4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(mask32x4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4x3(mask64x4x3 v) => new int4x3 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x3(int4x3 v) => new mask8x4x3 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x3(int4x3 v) => new mask16x4x3 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x3(int4x3 v) => new mask32x4x3 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x3(int4x3 v) => new mask64x4x3 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ++ (int4x3 val) => new int4x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator -- (int4x3 val) => new int4x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs + (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs - (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs * (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs / (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs % (int4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator + (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs + (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator - (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs - (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator * (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs * (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator / (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs / (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator % (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs % (float4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator + (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator - (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator * (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator / (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x3 operator % (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs + (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs - (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs * (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs / (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs % (double4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator + (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator - (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator * (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator / (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x3 operator % (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, byte4x3 rhs) => lhs + (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, byte4x3 rhs) => lhs - (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, byte4x3 rhs) => lhs * (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, byte4x3 rhs) => lhs / (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, byte4x3 rhs) => lhs % (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, sbyte4x3 rhs) => lhs + (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, sbyte4x3 rhs) => lhs - (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, sbyte4x3 rhs) => lhs * (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, sbyte4x3 rhs) => lhs / (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, sbyte4x3 rhs) => lhs % (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, ushort4x3 rhs) => lhs + (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, ushort4x3 rhs) => lhs - (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, ushort4x3 rhs) => lhs * (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, ushort4x3 rhs) => lhs / (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, ushort4x3 rhs) => lhs % (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, short4x3 rhs) => lhs + (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, short4x3 rhs) => lhs - (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, short4x3 rhs) => lhs * (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, short4x3 rhs) => lhs / (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, short4x3 rhs) => lhs % (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (short4x3 lhs, int4x3 rhs) => (int4x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (short4x3 lhs, int4x3 rhs) => (int4x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (short4x3 lhs, int4x3 rhs) => (int4x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (short4x3 lhs, int4x3 rhs) => (int4x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (short4x3 lhs, int4x3 rhs) => (int4x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (byte lhs, int4x3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (byte lhs, int4x3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (byte lhs, int4x3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (byte lhs, int4x3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (byte lhs, int4x3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (sbyte lhs, int4x3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (sbyte lhs, int4x3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (sbyte lhs, int4x3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (sbyte lhs, int4x3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (sbyte lhs, int4x3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (ushort lhs, int4x3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (ushort lhs, int4x3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (ushort lhs, int4x3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (ushort lhs, int4x3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (ushort lhs, int4x3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (int4x3 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator + (short lhs, int4x3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (int4x3 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator - (short lhs, int4x3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (int4x3 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator * (short lhs, int4x3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (int4x3 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator / (short lhs, int4x3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (int4x3 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator % (short lhs, int4x3 rhs) => (int)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator << (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator >> (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ~ (int4x3 v) => new int4x3 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, int4x3 rhs) => new int4x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, int rhs) => new int4x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int lhs, int4x3 rhs) => new int4x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs & (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs | (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs ^ (int4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, byte4x3 rhs) => lhs & (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, byte4x3 rhs) => lhs | (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, byte4x3 rhs) => lhs ^ (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, sbyte4x3 rhs) => lhs & (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, sbyte4x3 rhs) => lhs | (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, sbyte4x3 rhs) => lhs ^ (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, ushort4x3 rhs) => lhs & (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, ushort4x3 rhs) => lhs | (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, ushort4x3 rhs) => lhs ^ (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, short4x3 rhs) => lhs & (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, short4x3 rhs) => lhs | (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, short4x3 rhs) => lhs ^ (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (short4x3 lhs, int4x3 rhs) => (int4x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (short4x3 lhs, int4x3 rhs) => (int4x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (short4x3 lhs, int4x3 rhs) => (int4x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (byte lhs, int4x3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (byte lhs, int4x3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (byte lhs, int4x3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (sbyte lhs, int4x3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (sbyte lhs, int4x3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (sbyte lhs, int4x3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (ushort lhs, int4x3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (ushort lhs, int4x3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (ushort lhs, int4x3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (int4x3 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator & (short lhs, int4x3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (int4x3 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator | (short lhs, int4x3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (int4x3 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4x3 operator ^ (short lhs, int4x3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, int rhs) => new mask32x4x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, int rhs) => new mask32x4x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, int rhs) => new mask32x4x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, int rhs) => new mask32x4x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, int rhs) => new mask32x4x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, int rhs) => new mask32x4x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int lhs, int4x3 rhs) => new mask32x4x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs == (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs != (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs < (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs > (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs <= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, Unity.Mathematics.int4x3 rhs) => lhs >= (int4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (Unity.Mathematics.int4x3 lhs, int4x3 rhs) => (int4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs == (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs != (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs < (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs > (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs <= (float4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, Unity.Mathematics.float4x3 rhs) => lhs >= (float4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (Unity.Mathematics.float4x3 lhs, int4x3 rhs) => (float4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs == (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs != (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs < (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs > (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs <= (double4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (int4x3 lhs, Unity.Mathematics.double4x3 rhs) => lhs >= (double4x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator == (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator != (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator < (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator > (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator <= (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x3 operator >= (Unity.Mathematics.double4x3 lhs, int4x3 rhs) => (double4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, byte4x3 rhs) => lhs == (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, byte4x3 rhs) => lhs != (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, byte4x3 rhs) => lhs < (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, byte4x3 rhs) => lhs > (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, byte4x3 rhs) => lhs <= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, byte4x3 rhs) => lhs >= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (byte4x3 lhs, int4x3 rhs) => (int4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, sbyte4x3 rhs) => lhs == (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, sbyte4x3 rhs) => lhs != (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, sbyte4x3 rhs) => lhs < (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, sbyte4x3 rhs) => lhs > (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, sbyte4x3 rhs) => lhs <= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, sbyte4x3 rhs) => lhs >= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (sbyte4x3 lhs, int4x3 rhs) => (int4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, ushort4x3 rhs) => lhs == (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, ushort4x3 rhs) => lhs != (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, ushort4x3 rhs) => lhs < (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, ushort4x3 rhs) => lhs > (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, ushort4x3 rhs) => lhs <= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, ushort4x3 rhs) => lhs >= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (ushort4x3 lhs, int4x3 rhs) => (int4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, short4x3 rhs) => lhs == (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, short4x3 rhs) => lhs != (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, short4x3 rhs) => lhs < (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, short4x3 rhs) => lhs > (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, short4x3 rhs) => lhs <= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, short4x3 rhs) => lhs >= (int4x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (short4x3 lhs, int4x3 rhs) => (int4x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (short4x3 lhs, int4x3 rhs) => (int4x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (short4x3 lhs, int4x3 rhs) => (int4x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (short4x3 lhs, int4x3 rhs) => (int4x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (short4x3 lhs, int4x3 rhs) => (int4x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (short4x3 lhs, int4x3 rhs) => (int4x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (byte lhs, int4x3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (byte lhs, int4x3 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (byte lhs, int4x3 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (byte lhs, int4x3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (byte lhs, int4x3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (byte lhs, int4x3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (sbyte lhs, int4x3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (sbyte lhs, int4x3 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (sbyte lhs, int4x3 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (sbyte lhs, int4x3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (sbyte lhs, int4x3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (sbyte lhs, int4x3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (ushort lhs, int4x3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (ushort lhs, int4x3 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (ushort lhs, int4x3 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (ushort lhs, int4x3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (ushort lhs, int4x3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (ushort lhs, int4x3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (int4x3 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator == (short lhs, int4x3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (int4x3 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator != (short lhs, int4x3 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (int4x3 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator < (short lhs, int4x3 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (int4x3 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator > (short lhs, int4x3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (int4x3 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator <= (short lhs, int4x3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (int4x3 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x3 operator >= (short lhs, int4x3 rhs) => (int)lhs >= rhs;


        public ref int4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (int4x3* array = &this) { return ref ((int4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int4x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is int4x3 converted && Equals(converted)) || (o is Unity.Mathematics.int4x3 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.int4x3)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.int4x3)this).ToString(format, formatProvider);
    }
}
