using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int2x4 : IEquatable<int2x4>, IEquatable<Unity.Mathematics.int2x4>, IEquatable<int>, IFormattable
    {
        public int2 c0;
        public int2 c1;
        public int2 c2;
        public int2 c3;

        public static int2x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(int2 c0, int2 c1, int2 c2, int2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(int m00, int m01, int m02, int m03,
                      int m10, int m11, int m12, int m13)
        {
            this.c0 = new int2(m00, m10);
            this.c1 = new int2(m01, m11);
            this.c2 = new int2(m02, m12);
            this.c3 = new int2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(bool v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(bool2x4 v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(mask8x2x4 v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(mask16x2x4 v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(mask32x2x4 v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(mask64x2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(byte v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(byte2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(sbyte v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(sbyte2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(ushort v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(ushort2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(short v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(short2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(int v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(int2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(uint v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(uint2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(ulong v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(ulong2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(long v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(long2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(UInt128 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Int128 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(quarter v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(half v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(float v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(float2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(double v)
        {
            this = (int2x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(double2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(quadruple v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Unity.Mathematics.bool2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Unity.Mathematics.int2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Unity.Mathematics.uint2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Unity.Mathematics.half v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Unity.Mathematics.float2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x4(Unity.Mathematics.double2x4 v)
        {
            this = (int2x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(Unity.Mathematics.int2x4 v) => new int2x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2x4(int2x4 v) => new Unity.Mathematics.int2x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x4(int2x4 v) => new bool2x4 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2, c3 = (bool2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(Unity.Mathematics.bool2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x4(int2x4 v) => new Unity.Mathematics.bool2x4 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2, c3 = (bool2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(Unity.Mathematics.uint2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x4(int2x4 v) => new uint2x4 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2, c3 = (uint2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(Unity.Mathematics.float2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x4(int2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(Unity.Mathematics.half v) => (int2x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(Unity.Mathematics.double2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x4(int2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(int v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(bool v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(bool2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x4(sbyte v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(sbyte2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x4(short v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(short2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(long v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(long2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x4(byte v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(byte2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x4(ushort v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(ushort2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(uint v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(uint2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(ulong v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(ulong2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(float v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(float2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(half v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(double v) => new int2x4 { c0 = (int2)v, c1 = (int2)v, c2 = (int2)v, c3 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(double2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(mask8x2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(mask16x2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(mask32x2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(mask64x2x4 v) => new int2x4 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2, c3 = (int2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x4(int2x4 v) => new mask8x2x4 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2, c3 = (mask8x2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x4(int2x4 v) => new mask16x2x4 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2, c3 = (mask16x2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x4(int2x4 v) => new mask32x2x4 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2, c3 = (mask32x2)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x4(int2x4 v) => new mask64x2x4 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2, c3 = (mask64x2)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ++ (int2x4 val) => new int2x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator -- (int2x4 val) => new int2x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs + (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs - (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs * (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs / (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs % (int2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator + (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs + (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator - (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs - (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator * (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs * (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator / (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs / (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator % (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs % (float2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator + (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator - (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator * (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator / (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x4 operator % (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator + (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs + (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator - (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs - (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator * (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs * (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator / (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs / (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator % (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs % (double2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator + (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator - (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator * (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator / (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x4 operator % (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, byte2x4 rhs) => lhs + (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, byte2x4 rhs) => lhs - (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, byte2x4 rhs) => lhs * (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, byte2x4 rhs) => lhs / (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, byte2x4 rhs) => lhs % (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, sbyte2x4 rhs) => lhs + (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, sbyte2x4 rhs) => lhs - (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, sbyte2x4 rhs) => lhs * (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, sbyte2x4 rhs) => lhs / (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, sbyte2x4 rhs) => lhs % (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, ushort2x4 rhs) => lhs + (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, ushort2x4 rhs) => lhs - (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, ushort2x4 rhs) => lhs * (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, ushort2x4 rhs) => lhs / (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, ushort2x4 rhs) => lhs % (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, short2x4 rhs) => lhs + (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, short2x4 rhs) => lhs - (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, short2x4 rhs) => lhs * (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, short2x4 rhs) => lhs / (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, short2x4 rhs) => lhs % (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (short2x4 lhs, int2x4 rhs) => (int2x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (short2x4 lhs, int2x4 rhs) => (int2x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (short2x4 lhs, int2x4 rhs) => (int2x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (short2x4 lhs, int2x4 rhs) => (int2x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (short2x4 lhs, int2x4 rhs) => (int2x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (byte lhs, int2x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (byte lhs, int2x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (byte lhs, int2x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (byte lhs, int2x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (byte lhs, int2x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (sbyte lhs, int2x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (sbyte lhs, int2x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (sbyte lhs, int2x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (sbyte lhs, int2x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (sbyte lhs, int2x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (ushort lhs, int2x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (ushort lhs, int2x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (ushort lhs, int2x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (ushort lhs, int2x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (ushort lhs, int2x4 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (int2x4 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator + (short lhs, int2x4 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (int2x4 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator - (short lhs, int2x4 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (int2x4 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator * (short lhs, int2x4 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (int2x4 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator / (short lhs, int2x4 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (int2x4 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator % (short lhs, int2x4 rhs) => (int)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator << (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs, c3 = lhs.c3 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator >> (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs, c3 = lhs.c3 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ~ (int2x4 v) => new int2x4 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2, c3 = ~v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, int2x4 rhs) => new int2x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, int rhs) => new int2x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int lhs, int2x4 rhs) => new int2x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs & (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs | (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs ^ (int2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, byte2x4 rhs) => lhs & (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, byte2x4 rhs) => lhs | (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, byte2x4 rhs) => lhs ^ (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, sbyte2x4 rhs) => lhs & (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, sbyte2x4 rhs) => lhs | (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, sbyte2x4 rhs) => lhs ^ (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, ushort2x4 rhs) => lhs & (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, ushort2x4 rhs) => lhs | (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, ushort2x4 rhs) => lhs ^ (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, short2x4 rhs) => lhs & (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, short2x4 rhs) => lhs | (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, short2x4 rhs) => lhs ^ (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (short2x4 lhs, int2x4 rhs) => (int2x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (short2x4 lhs, int2x4 rhs) => (int2x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (short2x4 lhs, int2x4 rhs) => (int2x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (byte lhs, int2x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (byte lhs, int2x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (byte lhs, int2x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (sbyte lhs, int2x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (sbyte lhs, int2x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (sbyte lhs, int2x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (ushort lhs, int2x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (ushort lhs, int2x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (ushort lhs, int2x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (int2x4 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator & (short lhs, int2x4 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (int2x4 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator | (short lhs, int2x4 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (int2x4 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x4 operator ^ (short lhs, int2x4 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, int rhs) => new mask32x2x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, int rhs) => new mask32x2x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, int rhs) => new mask32x2x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, int rhs) => new mask32x2x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, int rhs) => new mask32x2x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, int rhs) => new mask32x2x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int lhs, int2x4 rhs) => new mask32x2x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs == (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs != (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs < (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs > (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs <= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, Unity.Mathematics.int2x4 rhs) => lhs >= (int2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (Unity.Mathematics.int2x4 lhs, int2x4 rhs) => (int2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs == (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs != (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs < (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs > (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs <= (float2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, Unity.Mathematics.float2x4 rhs) => lhs >= (float2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (Unity.Mathematics.float2x4 lhs, int2x4 rhs) => (float2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs == (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs != (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs < (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs > (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs <= (double2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (int2x4 lhs, Unity.Mathematics.double2x4 rhs) => lhs >= (double2x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator == (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator != (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator < (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator > (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator <= (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x4 operator >= (Unity.Mathematics.double2x4 lhs, int2x4 rhs) => (double2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, byte2x4 rhs) => lhs == (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, byte2x4 rhs) => lhs != (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, byte2x4 rhs) => lhs < (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, byte2x4 rhs) => lhs > (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, byte2x4 rhs) => lhs <= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, byte2x4 rhs) => lhs >= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (byte2x4 lhs, int2x4 rhs) => (int2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, sbyte2x4 rhs) => lhs == (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, sbyte2x4 rhs) => lhs != (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, sbyte2x4 rhs) => lhs < (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, sbyte2x4 rhs) => lhs > (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, sbyte2x4 rhs) => lhs <= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, sbyte2x4 rhs) => lhs >= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (sbyte2x4 lhs, int2x4 rhs) => (int2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, ushort2x4 rhs) => lhs == (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, ushort2x4 rhs) => lhs != (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, ushort2x4 rhs) => lhs < (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, ushort2x4 rhs) => lhs > (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, ushort2x4 rhs) => lhs <= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, ushort2x4 rhs) => lhs >= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (ushort2x4 lhs, int2x4 rhs) => (int2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, short2x4 rhs) => lhs == (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, short2x4 rhs) => lhs != (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, short2x4 rhs) => lhs < (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, short2x4 rhs) => lhs > (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, short2x4 rhs) => lhs <= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, short2x4 rhs) => lhs >= (int2x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (short2x4 lhs, int2x4 rhs) => (int2x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (short2x4 lhs, int2x4 rhs) => (int2x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (short2x4 lhs, int2x4 rhs) => (int2x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (short2x4 lhs, int2x4 rhs) => (int2x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (short2x4 lhs, int2x4 rhs) => (int2x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (short2x4 lhs, int2x4 rhs) => (int2x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (byte lhs, int2x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (byte lhs, int2x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (byte lhs, int2x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (byte lhs, int2x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (byte lhs, int2x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (byte lhs, int2x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (sbyte lhs, int2x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (sbyte lhs, int2x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (sbyte lhs, int2x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (sbyte lhs, int2x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (sbyte lhs, int2x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (sbyte lhs, int2x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (ushort lhs, int2x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (ushort lhs, int2x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (ushort lhs, int2x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (ushort lhs, int2x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (ushort lhs, int2x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (ushort lhs, int2x4 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (int2x4 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator == (short lhs, int2x4 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (int2x4 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator != (short lhs, int2x4 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (int2x4 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator < (short lhs, int2x4 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (int2x4 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator > (short lhs, int2x4 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (int2x4 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator <= (short lhs, int2x4 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (int2x4 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x4 operator >= (short lhs, int2x4 rhs) => (int)lhs >= rhs;


        public ref int2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (int2x4* array = &this) { return ref ((int2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int2x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int2x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is int2x4 converted && Equals(converted)) || (o is Unity.Mathematics.int2x4 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.int2x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.int2x4)this).ToString(format, formatProvider);
    }
}
