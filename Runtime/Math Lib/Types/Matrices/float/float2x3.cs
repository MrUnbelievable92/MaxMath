using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct float2x3 : IEquatable<float2x3>, IEquatable<Unity.Mathematics.float2x3>, IEquatable<float>, IFormattable
    {
        public float2 c0;
        public float2 c1;
        public float2 c2;

        public static float2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float2 c0, float2 c1, float2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float m00, float m01, float m02,
                        float m10, float m11, float m12)
        {
            this.c0 = new float2(m00, m10);
            this.c1 = new float2(m01, m11);
            this.c2 = new float2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(bool v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(bool2x3 v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(mask8x2x3 v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(mask16x2x3 v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(mask32x2x3 v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(mask64x2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(byte v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(byte2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(sbyte v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(sbyte2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(ushort v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(ushort2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(short v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(short2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(uint v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(uint2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(int v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(int2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(ulong v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(ulong2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(long v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(long2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(UInt128 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Int128 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(quarter v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(half v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(float2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(double v)
        {
            this = (float2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(double2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(quadruple v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Unity.Mathematics.int2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Unity.Mathematics.half v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Unity.Mathematics.float2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x3(Unity.Mathematics.double2x3 v)
        {
            this = (float2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(quarter x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(Unity.Mathematics.float2x3 v) => new float2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x3(float2x3 v) => new Unity.Mathematics.float2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(float2x3 v) => new bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(Unity.Mathematics.bool2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x3(float2x3 v) => new Unity.Mathematics.bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(Unity.Mathematics.int2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x3(float2x3 v) => new int2x3 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(Unity.Mathematics.uint2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x3(float2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(Unity.Mathematics.double2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x3(float2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(float v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(bool v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(bool2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x3(sbyte v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(sbyte2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x3(short v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(short2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(int v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(int2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(long v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(long2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x3(byte v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(byte2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x3(ushort v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(ushort2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(uint v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(uint2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(ulong v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(ulong2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(half v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(double v) => new float2x3 { c0 = (float2)v, c1 = (float2)v, c2 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(double2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(mask8x2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(mask16x2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(mask32x2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x3(mask64x2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x3(float2x3 v) => new mask8x2x3 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x3(float2x3 v) => new mask16x2x3 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(float2x3 v) => new mask32x2x3 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x3(float2x3 v) => new mask64x2x3 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 val) => new float2x3 { c0 = +val.c0, c1 = +val.c1, c2 = +val.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 val) => new float2x3 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator ++ (float2x3 val) => new float2x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator -- (float2x3 val) => new float2x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, float rhs) => new float2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float lhs, float2x3 rhs) => new float2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, float rhs) => new float2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float lhs, float2x3 rhs) => new float2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, float rhs) => new float2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float lhs, float2x3 rhs) => new float2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, float rhs) => new float2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float lhs, float2x3 rhs) => new float2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, float rhs) => new float2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float lhs, float2x3 rhs) => new float2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => new float2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => new float2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => new float2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => new float2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => new float2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => new float2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => new double2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => new double2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => new double2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => new double2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => new double2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => new double2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => new double2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => new double2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => new double2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => new double2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, quarter rhs) => new float2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, quarter rhs) => new float2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, quarter rhs) => new float2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, quarter rhs) => new float2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, quarter rhs) => new float2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (quarter lhs, float2x3 rhs) => new float2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (quarter lhs, float2x3 rhs) => new float2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (quarter lhs, float2x3 rhs) => new float2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (quarter lhs, float2x3 rhs) => new float2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (quarter lhs, float2x3 rhs) => new float2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, half rhs) => new float2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, half rhs) => new float2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, half rhs) => new float2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, half rhs) => new float2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, half rhs) => new float2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (half lhs, float2x3 rhs) => new float2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (half lhs, float2x3 rhs) => new float2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (half lhs, float2x3 rhs) => new float2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (half lhs, float2x3 rhs) => new float2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (half lhs, float2x3 rhs) => new float2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, Unity.Mathematics.half rhs) => new float2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, Unity.Mathematics.half rhs) => new float2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, Unity.Mathematics.half rhs) => new float2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, Unity.Mathematics.half rhs) => new float2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, Unity.Mathematics.half rhs) => new float2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.half lhs, float2x3 rhs) => new float2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.half lhs, float2x3 rhs) => new float2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.half lhs, float2x3 rhs) => new float2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.half lhs, float2x3 rhs) => new float2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.half lhs, float2x3 rhs) => new float2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, byte2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, byte2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, byte2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, byte2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, byte2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, sbyte2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, sbyte2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, sbyte2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, sbyte2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, sbyte2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, short2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, short2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, short2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, short2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, short2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (short2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (short2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (short2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (short2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (short2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, ushort2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, ushort2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, ushort2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, ushort2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, ushort2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, int2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, int2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, int2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, int2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, int2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (int2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (int2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (int2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (int2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (int2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, uint2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, uint2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, uint2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, uint2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, uint2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, long2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, long2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, long2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, long2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, long2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (long2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (long2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (long2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (long2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (long2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, ulong2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, ulong2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, ulong2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, ulong2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, ulong2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (byte lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (byte lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (byte lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (byte lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (byte lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (sbyte lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (sbyte lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (sbyte lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (sbyte lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (sbyte lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (short lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (short lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (short lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (short lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (short lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (ushort lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (ushort lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (ushort lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (ushort lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (ushort lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (int lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (int lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (int lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (int lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (int lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (uint lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (uint lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (uint lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (uint lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (uint lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (long lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (long lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (long lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (long lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (long lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (ulong lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (ulong lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (ulong lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (ulong lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (ulong lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Int128 lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Int128 lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Int128 lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Int128 lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Int128 lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (float2x3 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (UInt128 lhs, float2x3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (float2x3 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (UInt128 lhs, float2x3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (float2x3 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (UInt128 lhs, float2x3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (float2x3 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (UInt128 lhs, float2x3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (float2x3 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (UInt128 lhs, float2x3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, float rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, float rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, float rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, float rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, float rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, float rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs >= (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.float2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs == (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs != (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs < (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs > (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs <= (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (float2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs >= (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => (double2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => (double2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => (double2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => (double2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => (double2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.double2x3 lhs, float2x3 rhs) => (double2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, quarter rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, quarter rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, quarter rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, quarter rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, quarter rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, quarter rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (quarter lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (quarter lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (quarter lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (quarter lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (quarter lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (quarter lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, half rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, half rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, half rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, half rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, half rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, half rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, Unity.Mathematics.half rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, Unity.Mathematics.half rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, Unity.Mathematics.half rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, Unity.Mathematics.half rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, Unity.Mathematics.half rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, Unity.Mathematics.half rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.half lhs, float2x3 rhs) => new mask32x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, byte2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, byte2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, byte2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, byte2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, byte2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, byte2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (byte2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, sbyte2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, sbyte2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, sbyte2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, sbyte2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, sbyte2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, sbyte2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (sbyte2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, short2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, short2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, short2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, short2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, short2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, short2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (short2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (short2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (short2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (short2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (short2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (short2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, ushort2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, ushort2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, ushort2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, ushort2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, ushort2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, ushort2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ushort2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, int2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, int2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, int2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, int2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, int2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, int2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (int2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (int2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (int2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (int2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (int2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (int2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, uint2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, uint2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, uint2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, uint2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, uint2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, uint2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.int2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.uint2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, long2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, long2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, long2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, long2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, long2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, long2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (long2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (long2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (long2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (long2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (long2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (long2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, ulong2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, ulong2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, ulong2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, ulong2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, ulong2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, ulong2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ulong2x3 lhs, float2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, byte rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (byte lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, byte rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (byte lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, byte rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (byte lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, byte rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (byte lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, byte rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (byte lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, byte rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (byte lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, sbyte rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (sbyte lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, sbyte rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (sbyte lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, sbyte rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (sbyte lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, sbyte rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (sbyte lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, sbyte rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (sbyte lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, sbyte rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (sbyte lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, short rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (short lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, short rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (short lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, short rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (short lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, short rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (short lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, short rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (short lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, short rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (short lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, ushort rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ushort lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, ushort rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ushort lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, ushort rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ushort lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, ushort rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ushort lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, ushort rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ushort lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, ushort rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ushort lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, int rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (int lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, int rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (int lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, int rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (int lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, int rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (int lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, int rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (int lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, int rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (int lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, uint rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, uint rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, uint rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, uint rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, uint rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, uint rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, long rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (long lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, long rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (long lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, long rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (long lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, long rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (long lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, long rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (long lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, long rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (long lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, ulong rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ulong lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, ulong rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ulong lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, ulong rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ulong lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, ulong rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ulong lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, ulong rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ulong lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, ulong rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ulong lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, Int128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Int128 lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, Int128 rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Int128 lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, Int128 rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Int128 lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, Int128 rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Int128 lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, Int128 rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Int128 lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, Int128 rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Int128 lhs, float2x3 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (float2x3 lhs, UInt128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (UInt128 lhs, float2x3 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (float2x3 lhs, UInt128 rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (UInt128 lhs, float2x3 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (float2x3 lhs, UInt128 rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (UInt128 lhs, float2x3 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (float2x3 lhs, UInt128 rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (UInt128 lhs, float2x3 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (float2x3 lhs, UInt128 rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (UInt128 lhs, float2x3 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (float2x3 lhs, UInt128 rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (UInt128 lhs, float2x3 rhs) => (float)lhs >= rhs;


        public ref float2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (float2x3* array = &this) { return ref ((float2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.float2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is float2x3 converted && Equals(converted)) || (o is Unity.Mathematics.float2x3 convertedU && Equals(convertedU)) || (o is float convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.float2x3)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.float2x3)this).ToString(format, formatProvider);
    }
}
