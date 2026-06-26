using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct float2x2 : IEquatable<float2x2>, IEquatable<Unity.Mathematics.float2x2>, IEquatable<float>, IFormattable
    {
        public float2 c0;
        public float2 c1;
        

        public static float2x2 identity => new float2x2(1f, 0f,   0f, 1f);
        public static float2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float2 c0, float2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float m00, float m01,
                        float m10, float m11)
        {
            this.c0 = new float2(m00, m10);
            this.c1 = new float2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(bool v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(bool2x2 v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(mask8x2x2 v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(mask16x2x2 v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(mask32x2x2 v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(mask64x2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(byte v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(byte2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(sbyte v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(sbyte2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(ushort v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(ushort2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(short v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(short2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(uint v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(uint2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(int v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(int2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(ulong v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(ulong2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(long v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(long2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(UInt128 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Int128 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(quarter v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(half v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(double v)
        {
            this = (float2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(double2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(quadruple v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Unity.Mathematics.int2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Unity.Mathematics.half v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Unity.Mathematics.float2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(Unity.Mathematics.double2x2 v)
        {
            this = (float2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(quarter x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(Unity.Mathematics.float2x2 v) => new float2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x2(float2x2 v) => new Unity.Mathematics.float2x2 { c0 = v.c0, c1 = v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x2(float2x2 v) => new bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(Unity.Mathematics.bool2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x2(float2x2 v) => new Unity.Mathematics.bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(Unity.Mathematics.int2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x2(float2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(Unity.Mathematics.uint2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(float2x2 v) => new uint2x2 { c0 = (uint2)v.c0, c1 = (uint2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(Unity.Mathematics.double2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x2(float2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(float v) => new float2x2 { c0 = (float2)v, c1 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(bool v) => new float2x2 { c0 = (float2)v, c1 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(bool2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x2(sbyte v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(sbyte2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x2(short v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(short2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(int v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(int2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(long v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(long2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x2(byte v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(byte2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float2x2(ushort v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(ushort2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(uint v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(uint2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(ulong v) => new float2x2 { c0 = (float2)v, c1 = (float2)v, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(ulong2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1, };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(half v) => new float2x2 { c0 = (float2)v, c1 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(double v) => new float2x2 { c0 = (float2)v, c1 = (float2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(double2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(mask8x2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(mask16x2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(mask32x2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2x2(mask64x2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x2(float2x2 v) => new mask8x2x2 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(float2x2 v) => new mask16x2x2 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x2(float2x2 v) => new mask32x2x2 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x2(float2x2 v) => new mask64x2x2 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 val) => new float2x2 { c0 = +val.c0, c1 = +val.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 val) => new float2x2 { c0 = -val.c0, c1 = -val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator ++ (float2x2 val) => new float2x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator -- (float2x2 val) => new float2x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, float rhs) => new float2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float lhs, float2x2 rhs) => new float2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, float rhs) => new float2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float lhs, float2x2 rhs) => new float2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, float rhs) => new float2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float lhs, float2x2 rhs) => new float2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, float rhs) => new float2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float lhs, float2x2 rhs) => new float2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, float rhs) => new float2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float lhs, float2x2 rhs) => new float2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => new float2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => new float2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => new float2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => new float2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => new float2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => new float2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => new double2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, quarter rhs) => new float2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, quarter rhs) => new float2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, quarter rhs) => new float2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, quarter rhs) => new float2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, quarter rhs) => new float2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (quarter lhs, float2x2 rhs) => new float2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (quarter lhs, float2x2 rhs) => new float2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (quarter lhs, float2x2 rhs) => new float2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (quarter lhs, float2x2 rhs) => new float2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (quarter lhs, float2x2 rhs) => new float2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, half rhs) => new float2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, half rhs) => new float2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, half rhs) => new float2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, half rhs) => new float2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, half rhs) => new float2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (half lhs, float2x2 rhs) => new float2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (half lhs, float2x2 rhs) => new float2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (half lhs, float2x2 rhs) => new float2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (half lhs, float2x2 rhs) => new float2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (half lhs, float2x2 rhs) => new float2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, Unity.Mathematics.half rhs) => new float2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, Unity.Mathematics.half rhs) => new float2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, Unity.Mathematics.half rhs) => new float2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, Unity.Mathematics.half rhs) => new float2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, Unity.Mathematics.half rhs) => new float2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.half lhs, float2x2 rhs) => new float2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.half lhs, float2x2 rhs) => new float2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.half lhs, float2x2 rhs) => new float2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.half lhs, float2x2 rhs) => new float2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.half lhs, float2x2 rhs) => new float2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, byte2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, byte2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, byte2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, byte2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, byte2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, sbyte2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, sbyte2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, sbyte2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, sbyte2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, sbyte2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, short2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, short2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, short2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, short2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, short2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (short2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (short2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (short2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (short2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (short2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, ushort2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, ushort2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, ushort2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, ushort2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, ushort2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, int2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, int2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, int2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, int2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, int2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (int2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (int2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (int2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (int2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (int2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, uint2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, uint2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, uint2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, uint2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, uint2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, long2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, long2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, long2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, long2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, long2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (long2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (long2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (long2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (long2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (long2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, ulong2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, ulong2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, ulong2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, ulong2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, ulong2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (byte lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (byte lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (byte lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (byte lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (byte lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (sbyte lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (sbyte lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (sbyte lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (sbyte lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (sbyte lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (short lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (short lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (short lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (short lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (short lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (ushort lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (ushort lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (ushort lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (ushort lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (ushort lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (int lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (int lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (int lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (int lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (int lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (uint lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (uint lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (uint lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (uint lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (uint lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (long lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (long lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (long lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (long lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (long lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (ulong lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (ulong lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (ulong lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (ulong lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (ulong lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Int128 lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Int128 lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Int128 lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Int128 lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Int128 lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (float2x2 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (UInt128 lhs, float2x2 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (float2x2 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (UInt128 lhs, float2x2 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (float2x2 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (UInt128 lhs, float2x2 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (float2x2 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (UInt128 lhs, float2x2 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (float2x2 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (UInt128 lhs, float2x2 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, float rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, float rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, float rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, float rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, float rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, float rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs >= (float2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.float2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (float2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs >= (double2x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.double2x2 lhs, float2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, quarter rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, quarter rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, quarter rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, quarter rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, quarter rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, quarter rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (quarter lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (quarter lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (quarter lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (quarter lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (quarter lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (quarter lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, half rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, half rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, half rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, half rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, half rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, half rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, Unity.Mathematics.half rhs) => new mask32x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, Unity.Mathematics.half rhs) => new mask32x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, Unity.Mathematics.half rhs) => new mask32x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, Unity.Mathematics.half rhs) => new mask32x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, Unity.Mathematics.half rhs) => new mask32x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, Unity.Mathematics.half rhs) => new mask32x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.half lhs, float2x2 rhs) => new mask32x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, byte2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, byte2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, byte2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, byte2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, byte2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, byte2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (byte2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, sbyte2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, sbyte2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, sbyte2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, sbyte2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, sbyte2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, sbyte2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (sbyte2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, short2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, short2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, short2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, short2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, short2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, short2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (short2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (short2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (short2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (short2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (short2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (short2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, ushort2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, ushort2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, ushort2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, ushort2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, ushort2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, ushort2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (ushort2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, int2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, int2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, int2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, int2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, int2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, int2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, uint2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, uint2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, uint2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, uint2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, uint2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, uint2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (uint2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.int2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, Unity.Mathematics.uint2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.uint2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, long2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, long2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, long2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, long2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, long2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, long2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (long2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (long2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (long2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (long2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (long2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (long2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, ulong2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, ulong2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, ulong2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, ulong2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, ulong2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, ulong2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (ulong2x2 lhs, float2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, byte rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (byte lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, byte rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (byte lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, byte rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (byte lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, byte rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (byte lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, byte rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (byte lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, byte rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (byte lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, sbyte rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (sbyte lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, sbyte rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (sbyte lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, sbyte rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (sbyte lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, sbyte rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (sbyte lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, sbyte rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (sbyte lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, sbyte rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (sbyte lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, short rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (short lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, short rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (short lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, short rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (short lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, short rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (short lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, short rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (short lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, short rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (short lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, ushort rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (ushort lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, ushort rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (ushort lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, ushort rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (ushort lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, ushort rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (ushort lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, ushort rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (ushort lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, ushort rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (ushort lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, int rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (int lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, int rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (int lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, int rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (int lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, int rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (int lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, int rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (int lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, int rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (int lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, uint rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (uint lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, uint rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (uint lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, uint rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (uint lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, uint rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (uint lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, uint rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (uint lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, uint rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (uint lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, long rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (long lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, long rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (long lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, long rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (long lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, long rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (long lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, long rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (long lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, long rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (long lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, ulong rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (ulong lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, ulong rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (ulong lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, ulong rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (ulong lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, ulong rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (ulong lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, ulong rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (ulong lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, ulong rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (ulong lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, Int128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Int128 lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, Int128 rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Int128 lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, Int128 rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Int128 lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, Int128 rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Int128 lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, Int128 rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Int128 lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, Int128 rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Int128 lhs, float2x2 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (float2x2 lhs, UInt128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (UInt128 lhs, float2x2 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (float2x2 lhs, UInt128 rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (UInt128 lhs, float2x2 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (float2x2 lhs, UInt128 rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (UInt128 lhs, float2x2 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (float2x2 lhs, UInt128 rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (UInt128 lhs, float2x2 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (float2x2 lhs, UInt128 rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (UInt128 lhs, float2x2 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (float2x2 lhs, UInt128 rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (UInt128 lhs, float2x2 rhs) => (float)lhs >= rhs;


        public ref float2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (float2x2* array = &this) { return ref ((float2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.float2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is float2x2 converted && Equals(converted)) || (o is Unity.Mathematics.float2x2 convertedU && Equals(convertedU)) || (o is float convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.float2x2)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.float2x2)this).ToString(format, formatProvider);


        /// <summary>   Computes a <see cref="float2x2"/> matrix representing a counter-clockwise rotation by an angle in radians.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 Rotate(float angle)
        {
            math.sincos(angle, out float s, out float c);
            return new float2x2(c, -s,
                                s,  c);
        }

        /// <summary>   Returns a <see cref="float2x2"/> matrix representing a uniform scaling of both axes by <paramref name="s"/>. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 Scale(float s)
        {
            return new float2x2(s,  0f,
                                0f, s);
        }

        /// <summary>   Returns a <see cref="float2x2"/> matrix representing a non-uniform axis scaling by <paramref name="x"/> and <paramref name="y"/>. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 Scale(float x, float y)
        {
            return new float2x2(x,  0f,
                                0f, y);
        }

        /// <summary>Returns a <see cref="float2x2"/> matrix representing a non-uniform axis scaling by the components of the <see cref="float2"/> vector <paramref name="v"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 Scale(float2 v)
        {
            return Scale(v.x, v.y);
        }
    }
}
