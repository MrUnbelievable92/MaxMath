using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int3x2 : IEquatable<int3x2>, IEquatable<Unity.Mathematics.int3x2>, IEquatable<int>, IFormattable
    {
        public int3 c0;
        public int3 c1;

        public static int3x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int3 c0, int3 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int m00, int m01,
                      int m10, int m11,
                      int m20, int m21)
        {
            this.c0 = new int3(m00, m10, m20);
            this.c1 = new int3(m01, m11, m21);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(bool v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(bool3x2 v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(mask8x3x2 v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(mask16x3x2 v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(mask32x3x2 v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(mask64x3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(byte v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(byte3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(sbyte v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(sbyte3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(ushort v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(ushort3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(short v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(short3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(int3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(uint v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(uint3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(ulong v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(ulong3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(long v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(long3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(UInt128 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Int128 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(quarter v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(half v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(float v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(float3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(double v)
        {
            this = (int3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(double3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(quadruple v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Unity.Mathematics.bool3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Unity.Mathematics.int3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Unity.Mathematics.uint3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Unity.Mathematics.half v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Unity.Mathematics.float3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3x2(Unity.Mathematics.double3x2 v)
        {
            this = (int3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(Unity.Mathematics.int3x2 v) => new int3x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3x2(int3x2 v) => new Unity.Mathematics.int3x2 { c0 = v.c0, c1 = v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(int3x2 v) => new bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(Unity.Mathematics.bool3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x2(int3x2 v) => new Unity.Mathematics.bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(Unity.Mathematics.uint3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x2(int3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(Unity.Mathematics.float3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x2(int3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(Unity.Mathematics.half v) => (int3x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(Unity.Mathematics.double3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x2(int3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(int v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(bool v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(bool3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x2(sbyte v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(sbyte3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x2(short v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(short3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(long v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(long3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x2(byte v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(byte3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3x2(ushort v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(ushort3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(uint v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(uint3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(ulong v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(ulong3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(float v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(float3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(half v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(double v) => new int3x2 { c0 = (int3)v, c1 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(double3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(mask8x3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(mask16x3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(mask32x3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3x2(mask64x3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x2(int3x2 v) => new mask8x3x2 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x2(int3x2 v) => new mask16x3x2 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x2(int3x2 v) => new mask32x3x2 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x2(int3x2 v) => new mask64x3x2 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ++ (int3x2 val) => new int3x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator -- (int3x2 val) => new int3x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs + (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs - (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs * (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs / (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs % (int3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs + (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs - (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs * (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs / (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs % (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs + (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs - (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs * (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs / (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs % (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, byte3x2 rhs) => lhs + (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, byte3x2 rhs) => lhs - (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, byte3x2 rhs) => lhs * (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, byte3x2 rhs) => lhs / (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, byte3x2 rhs) => lhs % (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, sbyte3x2 rhs) => lhs + (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, sbyte3x2 rhs) => lhs - (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, sbyte3x2 rhs) => lhs * (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, sbyte3x2 rhs) => lhs / (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, sbyte3x2 rhs) => lhs % (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, ushort3x2 rhs) => lhs + (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, ushort3x2 rhs) => lhs - (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, ushort3x2 rhs) => lhs * (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, ushort3x2 rhs) => lhs / (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, ushort3x2 rhs) => lhs % (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, short3x2 rhs) => lhs + (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, short3x2 rhs) => lhs - (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, short3x2 rhs) => lhs * (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, short3x2 rhs) => lhs / (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, short3x2 rhs) => lhs % (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (short3x2 lhs, int3x2 rhs) => (int3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (short3x2 lhs, int3x2 rhs) => (int3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (short3x2 lhs, int3x2 rhs) => (int3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (short3x2 lhs, int3x2 rhs) => (int3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (short3x2 lhs, int3x2 rhs) => (int3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (byte lhs, int3x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (byte lhs, int3x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (byte lhs, int3x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (byte lhs, int3x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (byte lhs, int3x2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (sbyte lhs, int3x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (sbyte lhs, int3x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (sbyte lhs, int3x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (sbyte lhs, int3x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (sbyte lhs, int3x2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (ushort lhs, int3x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (ushort lhs, int3x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (ushort lhs, int3x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (ushort lhs, int3x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (ushort lhs, int3x2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (int3x2 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator + (short lhs, int3x2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (int3x2 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator - (short lhs, int3x2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (int3x2 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator * (short lhs, int3x2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (int3x2 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator / (short lhs, int3x2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (int3x2 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator % (short lhs, int3x2 rhs) => (int)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator << (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator >> (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ~ (int3x2 v) => new int3x2 { c0 = ~v.c0, c1 = ~v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, int3x2 rhs) => new int3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, int rhs) => new int3x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int lhs, int3x2 rhs) => new int3x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs & (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs | (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs ^ (int3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, byte3x2 rhs) => lhs & (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, byte3x2 rhs) => lhs | (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, byte3x2 rhs) => lhs ^ (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, sbyte3x2 rhs) => lhs & (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, sbyte3x2 rhs) => lhs | (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, sbyte3x2 rhs) => lhs ^ (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, ushort3x2 rhs) => lhs & (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, ushort3x2 rhs) => lhs | (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, ushort3x2 rhs) => lhs ^ (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, short3x2 rhs) => lhs & (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, short3x2 rhs) => lhs | (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, short3x2 rhs) => lhs ^ (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (short3x2 lhs, int3x2 rhs) => (int3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (short3x2 lhs, int3x2 rhs) => (int3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (short3x2 lhs, int3x2 rhs) => (int3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (byte lhs, int3x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (byte lhs, int3x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (byte lhs, int3x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (sbyte lhs, int3x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (sbyte lhs, int3x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (sbyte lhs, int3x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (ushort lhs, int3x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (ushort lhs, int3x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (ushort lhs, int3x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (int3x2 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator & (short lhs, int3x2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (int3x2 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator | (short lhs, int3x2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (int3x2 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3x2 operator ^ (short lhs, int3x2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, int rhs) => new mask32x3x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, int rhs) => new mask32x3x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, int rhs) => new mask32x3x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, int rhs) => new mask32x3x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, int rhs) => new mask32x3x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, int rhs) => new mask32x3x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int lhs, int3x2 rhs) => new mask32x3x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs == (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs != (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs < (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs > (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs <= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, Unity.Mathematics.int3x2 rhs) => lhs >= (int3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (Unity.Mathematics.int3x2 lhs, int3x2 rhs) => (int3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs == (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs != (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs < (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs > (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs <= (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs >= (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (Unity.Mathematics.float3x2 lhs, int3x2 rhs) => (float3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs == (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs != (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs < (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs > (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs <= (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (int3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs >= (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.double3x2 lhs, int3x2 rhs) => (double3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, byte3x2 rhs) => lhs == (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, byte3x2 rhs) => lhs != (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, byte3x2 rhs) => lhs < (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, byte3x2 rhs) => lhs > (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, byte3x2 rhs) => lhs <= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, byte3x2 rhs) => lhs >= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (byte3x2 lhs, int3x2 rhs) => (int3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, sbyte3x2 rhs) => lhs == (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, sbyte3x2 rhs) => lhs != (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, sbyte3x2 rhs) => lhs < (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, sbyte3x2 rhs) => lhs > (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, sbyte3x2 rhs) => lhs <= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, sbyte3x2 rhs) => lhs >= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (sbyte3x2 lhs, int3x2 rhs) => (int3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, ushort3x2 rhs) => lhs == (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, ushort3x2 rhs) => lhs != (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, ushort3x2 rhs) => lhs < (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, ushort3x2 rhs) => lhs > (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, ushort3x2 rhs) => lhs <= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, ushort3x2 rhs) => lhs >= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (ushort3x2 lhs, int3x2 rhs) => (int3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, short3x2 rhs) => lhs == (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, short3x2 rhs) => lhs != (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, short3x2 rhs) => lhs < (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, short3x2 rhs) => lhs > (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, short3x2 rhs) => lhs <= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, short3x2 rhs) => lhs >= (int3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (short3x2 lhs, int3x2 rhs) => (int3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (short3x2 lhs, int3x2 rhs) => (int3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (short3x2 lhs, int3x2 rhs) => (int3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (short3x2 lhs, int3x2 rhs) => (int3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (short3x2 lhs, int3x2 rhs) => (int3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (short3x2 lhs, int3x2 rhs) => (int3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (byte lhs, int3x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (byte lhs, int3x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (byte lhs, int3x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (byte lhs, int3x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (byte lhs, int3x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (byte lhs, int3x2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (sbyte lhs, int3x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (sbyte lhs, int3x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (sbyte lhs, int3x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (sbyte lhs, int3x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (sbyte lhs, int3x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (sbyte lhs, int3x2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (ushort lhs, int3x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (ushort lhs, int3x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (ushort lhs, int3x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (ushort lhs, int3x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (ushort lhs, int3x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (ushort lhs, int3x2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (int3x2 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (short lhs, int3x2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (int3x2 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (short lhs, int3x2 rhs) => (int)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (int3x2 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (short lhs, int3x2 rhs) => (int)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (int3x2 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (short lhs, int3x2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (int3x2 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (short lhs, int3x2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (int3x2 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (short lhs, int3x2 rhs) => (int)lhs >= rhs;


        public ref int3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (int3x2* array = &this) { return ref ((int3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is int3x2 converted && Equals(converted)) || (o is Unity.Mathematics.int3x2 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.int3x2)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.int3x2)this).ToString(format, formatProvider);
    }
}
