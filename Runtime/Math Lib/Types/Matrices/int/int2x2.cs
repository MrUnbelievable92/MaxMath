using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int2x2 : IEquatable<int2x2>, IEquatable<Unity.Mathematics.int2x2>, IEquatable<int>, IFormattable
    {
        public int2 c0;
        public int2 c1;
        
        public static int2x2 identity => new int2x2(1, 0,   0, 1);
        public static int2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(int2 c0, int2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(int m00, int m01,
                      int m10, int m11)
        {
            this.c0 = new int2(m00, m10);
            this.c1 = new int2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(bool v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(bool2x2 v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(mask8x2x2 v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(mask16x2x2 v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(mask32x2x2 v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(mask64x2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(byte v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(byte2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(sbyte v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(sbyte2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(ushort v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(ushort2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(short v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(short2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(int v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(int2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(uint v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(uint2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(ulong v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(ulong2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(long v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(long2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(UInt128 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Int128 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(quarter v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(half v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(float v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(float2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(double v)
        {
            this = (int2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(double2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(quadruple v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Unity.Mathematics.int2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Unity.Mathematics.half v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Unity.Mathematics.float2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2x2(Unity.Mathematics.double2x2 v)
        {
            this = (int2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x2(Unity.Mathematics.int2x2 v) => new int2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2x2(int2x2 v) => new Unity.Mathematics.int2x2 { c0 = v.c0, c1 = v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x2(int2x2 v) => new bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(Unity.Mathematics.bool2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x2(int2x2 v) => new Unity.Mathematics.bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(Unity.Mathematics.uint2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(int2x2 v) => new uint2x2 { c0 = (uint2)v.c0, c1 = (uint2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(Unity.Mathematics.float2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x2(int2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(Unity.Mathematics.half v) => (int2x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(Unity.Mathematics.double2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x2(int2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x2(int v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(bool v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(bool2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x2(sbyte v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x2(sbyte2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x2(short v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x2(short2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(long v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(long2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x2(byte v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x2(byte2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2x2(ushort v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x2(ushort2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(uint v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(uint2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(ulong v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(ulong2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(float v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(float2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(half v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(double v) => new int2x2 { c0 = (int2)v, c1 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(double2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(mask8x2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(mask16x2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(mask32x2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(mask64x2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x2(int2x2 v) => new mask8x2x2 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(int2x2 v) => new mask16x2x2 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x2(int2x2 v) => new mask32x2x2 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x2(int2x2 v) => new mask64x2x2 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ++ (int2x2 val) => new int2x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator -- (int2x2 val) => new int2x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs % (int2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs % (float2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs % (double2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, byte2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, byte2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, byte2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, byte2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, byte2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, sbyte2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, sbyte2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, sbyte2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, sbyte2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, sbyte2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, ushort2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, ushort2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, ushort2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, ushort2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, ushort2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, short2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, short2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, short2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, short2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, short2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (short2x2 lhs, int2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (short2x2 lhs, int2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (short2x2 lhs, int2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (short2x2 lhs, int2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (short2x2 lhs, int2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (byte lhs, int2x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (byte lhs, int2x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (byte lhs, int2x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (byte lhs, int2x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (byte lhs, int2x2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (sbyte lhs, int2x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (sbyte lhs, int2x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (sbyte lhs, int2x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (sbyte lhs, int2x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (sbyte lhs, int2x2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (ushort lhs, int2x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (ushort lhs, int2x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (ushort lhs, int2x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (ushort lhs, int2x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (ushort lhs, int2x2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (int2x2 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (short lhs, int2x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (int2x2 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (short lhs, int2x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (int2x2 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (short lhs, int2x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (int2x2 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (short lhs, int2x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (int2x2 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (short lhs, int2x2 rhs) => (int)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator << (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator >> (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ~ (int2x2 v) => new int2x2 { c0 = ~v.c0, c1 = ~v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, int2x2 rhs) => new int2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, int rhs) => new int2x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int lhs, int2x2 rhs) => new int2x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs ^ (int2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, byte2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, byte2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, byte2x2 rhs) => lhs ^ (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, sbyte2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, sbyte2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, sbyte2x2 rhs) => lhs ^ (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, ushort2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, ushort2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, ushort2x2 rhs) => lhs ^ (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, short2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, short2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, short2x2 rhs) => lhs ^ (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (short2x2 lhs, int2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (short2x2 lhs, int2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (short2x2 lhs, int2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (byte lhs, int2x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (byte lhs, int2x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (byte lhs, int2x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (sbyte lhs, int2x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (sbyte lhs, int2x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (sbyte lhs, int2x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (ushort lhs, int2x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (ushort lhs, int2x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (ushort lhs, int2x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (int2x2 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (short lhs, int2x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (int2x2 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (short lhs, int2x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (int2x2 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (short lhs, int2x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, int rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, int rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, int rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, int rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, int rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, int rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int lhs, int2x2 rhs) => new mask32x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs >= (int2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.int2x2 lhs, int2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs >= (float2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.float2x2 lhs, int2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (int2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs >= (double2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.double2x2 lhs, int2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, byte2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, byte2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, byte2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, byte2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, byte2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, byte2x2 rhs) => lhs >= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (byte2x2 lhs, int2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, sbyte2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, sbyte2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, sbyte2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, sbyte2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, sbyte2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, sbyte2x2 rhs) => lhs >= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (sbyte2x2 lhs, int2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, ushort2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, ushort2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, ushort2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, ushort2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, ushort2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, ushort2x2 rhs) => lhs >= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (ushort2x2 lhs, int2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, short2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, short2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, short2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, short2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, short2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, short2x2 rhs) => lhs >= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (short2x2 lhs, int2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (short2x2 lhs, int2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (short2x2 lhs, int2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (short2x2 lhs, int2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (short2x2 lhs, int2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (short2x2 lhs, int2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (byte lhs, int2x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (byte lhs, int2x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (byte lhs, int2x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (byte lhs, int2x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (byte lhs, int2x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (byte lhs, int2x2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (sbyte lhs, int2x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (sbyte lhs, int2x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (sbyte lhs, int2x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (sbyte lhs, int2x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (sbyte lhs, int2x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (sbyte lhs, int2x2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (ushort lhs, int2x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (ushort lhs, int2x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (ushort lhs, int2x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (ushort lhs, int2x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (ushort lhs, int2x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (ushort lhs, int2x2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (short lhs, int2x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (short lhs, int2x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (short lhs, int2x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (short lhs, int2x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (short lhs, int2x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (short lhs, int2x2 rhs) => (int)lhs >= rhs;


        public ref int2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (int2x2* array = &this) { return ref ((int2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is int2x2 converted && Equals(converted)) || (o is Unity.Mathematics.int2x2 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.int2x2)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.int2x2)this).ToString(format, formatProvider);
    }
}
