using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct sbyte2x2 : IEquatable<sbyte2x2>, IFormattable
    {
        public sbyte2 c0;
        public sbyte2 c1;


        public static sbyte2x2 identity => new sbyte2x2(1, 0,   0, 1);
        public static sbyte2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(sbyte2 c0, sbyte2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(sbyte m00, sbyte m01,
                        sbyte m10, sbyte m11)
        {
            this.c0 = new sbyte2(m00, m10);
            this.c1 = new sbyte2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(bool v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(bool2x2 v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(mask8x2x2 v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(mask16x2x2 v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(mask32x2x2 v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(mask64x2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(byte v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(byte2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(sbyte v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(sbyte2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(ushort v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(ushort2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(short v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(short2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(uint v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(uint2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(int v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(int2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(long v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(long2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(ulong v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(ulong2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(UInt128 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Int128 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(quarter v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(half v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(float v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(float2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(double v)
        {
            this = (sbyte2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(double2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(quadruple v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Unity.Mathematics.int2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Unity.Mathematics.half v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Unity.Mathematics.float2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2x2(Unity.Mathematics.double2x2 v)
        {
            this = (sbyte2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(UInt128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Int128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(quarter x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(quadruple x) => (sbyte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x2(sbyte2x2 v) => new bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Unity.Mathematics.bool2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x2(sbyte2x2 v) => new Unity.Mathematics.bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Unity.Mathematics.int2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2x2(sbyte2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Unity.Mathematics.uint2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(sbyte2x2 v) => new uint2x2 { c0 = (uint2)v.c0, c1 = (uint2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Unity.Mathematics.half v) => (sbyte2x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Unity.Mathematics.float2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x2(sbyte2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(Unity.Mathematics.double2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x2(sbyte2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2x2(sbyte v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(bool v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(bool2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(short v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(short2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(int v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(int2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(long v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(long2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(byte v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(byte2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(ushort v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(ushort2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(uint v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(uint2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(ulong v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(ulong2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(half v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(float v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(float2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(double v) => new sbyte2x2 { c0 = (sbyte2)v, c1 = (sbyte2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(double2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(mask8x2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(mask16x2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(mask32x2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2x2(mask64x2x2 v) => new sbyte2x2 { c0 = (sbyte2)v.c0, c1 = (sbyte2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x2(sbyte2x2 v) => new mask8x2x2 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(sbyte2x2 v) => new mask16x2x2 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x2(sbyte2x2 v) => new mask32x2x2 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x2(sbyte2x2 v) => new mask64x2x2 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator - (sbyte2x2 val) => new sbyte2x2 { c0 = -val.c0, c1 = -val.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator ++ (sbyte2x2 val) => new sbyte2x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator -- (sbyte2x2 val) => new sbyte2x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator + (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator + (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator + (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator - (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator - (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator - (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator * (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator * (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator * (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator / (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator / (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator / (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator % (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator % (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator % (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator ~ (sbyte2x2 val) => new sbyte2x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator << (sbyte2x2 val, int n) => new sbyte2x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator >> (sbyte2x2 val, int n) => new sbyte2x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator & (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator & (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator & (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator | (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator | (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator | (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator ^ (sbyte2x2 lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator ^ (sbyte2x2 lhs, sbyte rhs) => new sbyte2x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2x2 operator ^ (sbyte lhs, sbyte2x2 rhs) => new sbyte2x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs ^ (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator == (sbyte2x2 lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator == (sbyte2x2 lhs, sbyte rhs) => new mask8x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator == (sbyte lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator != (sbyte2x2 lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator != (sbyte2x2 lhs, sbyte rhs) => new mask8x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator != (sbyte lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator < (sbyte2x2 lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator < (sbyte2x2 lhs, sbyte rhs) => new mask8x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator < (sbyte lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator > (sbyte2x2 lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator > (sbyte2x2 lhs, sbyte rhs) => new mask8x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator > (sbyte lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator <= (sbyte2x2 lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator <= (sbyte2x2 lhs, sbyte rhs) => new mask8x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator <= (sbyte lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator >= (sbyte2x2 lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator >= (sbyte2x2 lhs, sbyte rhs) => new mask8x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2x2 operator >= (sbyte lhs, sbyte2x2 rhs) => new mask8x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (sbyte2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs >= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.int2x2 lhs, sbyte2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (sbyte2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.float2x2 lhs, sbyte2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (sbyte2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.double2x2 lhs, sbyte2x2 rhs) => (double2x2)lhs >= rhs;


        public ref sbyte2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (sbyte2x2* array = &this) { return ref ((sbyte2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is sbyte2x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"sbyte2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}