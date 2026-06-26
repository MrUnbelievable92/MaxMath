using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct short2x3 : IEquatable<short2x3>, IFormattable
    {
        public short2 c0;
        public short2 c1;
        public short2 c2;

        public static short2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short2 c0, short2 c1, short2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short m00, short m01, short m02,
                        short m10, short m11, short m12)
        {
            this.c0 = new short2(m00, m10);
            this.c1 = new short2(m01, m11);
            this.c2 = new short2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(bool v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(bool2x3 v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(mask8x2x3 v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(mask16x2x3 v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(mask32x2x3 v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(mask64x2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(byte v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(byte2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(sbyte v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(sbyte2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(ushort v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(ushort2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(uint v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(uint2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(int v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(int2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(long v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(long2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(ulong v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(ulong2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(UInt128 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Int128 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(quarter v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(half v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(float v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(float2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(double v)
        {
            this = (short2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(double2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(quadruple v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Unity.Mathematics.int2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Unity.Mathematics.half v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Unity.Mathematics.float2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(Unity.Mathematics.double2x3 v)
        {
            this = (short2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(UInt128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Int128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(quarter x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(quadruple x) => (short)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(short2x3 v) => new bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Unity.Mathematics.bool2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x3(short2x3 v) => new Unity.Mathematics.bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Unity.Mathematics.int2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2x3(short2x3 v) => new int2x3 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Unity.Mathematics.uint2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x3(short2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Unity.Mathematics.half v) => (short2x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Unity.Mathematics.float2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x3(short2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(Unity.Mathematics.double2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x3(short2x3 v) => new double2x3 { c0 = (double2)v.c0, c1 = (double2)v.c1, c2 = (double2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x3(short v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(bool v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(bool2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short2x3(sbyte v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x3(sbyte2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(int v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(int2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(long v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(long2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short2x3(byte v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x3(byte2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ushort v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ushort2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(uint v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(uint2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ulong v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ulong2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(half v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(float v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(float2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(double v) => new short2x3 { c0 = (short2)v, c1 = (short2)v, c2 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(double2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(mask8x2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(mask16x2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(mask32x2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(mask64x2x3 v) => new short2x3 { c0 = (short2)v.c0, c1 = (short2)v.c1, c2 = (short2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x3(short2x3 v) => new mask8x2x3 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x3(short2x3 v) => new mask16x2x3 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(short2x3 v) => new mask32x2x3 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x3(short2x3 v) => new mask64x2x3 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 val) => new short2x3 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ++ (short2x3 val) => new short2x3 { c0 = val.c0 + (short)1, c1 = val.c1 + (short)1, c2 = val.c2 + (short)1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator -- (short2x3 val) => new short2x3 { c0 = val.c0 - (short)1, c1 = val.c1 - (short)1, c2 = val.c2 - (short)1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator + (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs + (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator - (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs - (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator * (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs * (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator / (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs / (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator % (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs % (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator + (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator - (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator * (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator / (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator % (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs % (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs + (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs - (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs * (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs / (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs % (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, sbyte rhs) => new short2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (sbyte lhs, short2x3 rhs) => new short2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, sbyte rhs) => new short2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (sbyte lhs, short2x3 rhs) => new short2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, sbyte rhs) => new short2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (sbyte lhs, short2x3 rhs) => new short2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, sbyte rhs) => new short2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (sbyte lhs, short2x3 rhs) => new short2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, sbyte rhs) => new short2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (sbyte lhs, short2x3 rhs) => new short2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ~ (short2x3 val) => new short2x3 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator << (short2x3 val, int n) => new short2x3 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator >> (short2x3 val, int n) => new short2x3 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 lhs, short rhs) => new short2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short lhs, short2x3 rhs) => new short2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 lhs, byte2x3 rhs) => new short2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (byte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 lhs, sbyte2x3 rhs) => new short2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (sbyte2x3 lhs, short2x3 rhs) => new short2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator & (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs & (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator | (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs | (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator ^ (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs ^ (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator & (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator | (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x3 operator ^ (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 lhs, byte rhs) => new short2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (byte lhs, short2x3 rhs) => new short2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short2x3 lhs, short rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short2x3 lhs, short rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short2x3 lhs, short rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short2x3 lhs, short rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short2x3 lhs, short rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short2x3 lhs, short rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short2x3 lhs, byte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short2x3 lhs, byte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short2x3 lhs, byte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short2x3 lhs, byte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short2x3 lhs, byte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short2x3 lhs, byte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (byte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (byte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (byte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (byte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (byte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (byte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short2x3 lhs, sbyte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short2x3 lhs, sbyte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short2x3 lhs, sbyte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short2x3 lhs, sbyte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short2x3 lhs, sbyte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short2x3 lhs, sbyte2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (sbyte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (sbyte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (sbyte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (sbyte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (sbyte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (sbyte2x3 lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs == (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs != (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs < (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs > (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs <= (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (short2x3 lhs, Unity.Mathematics.int2x3 rhs) => lhs >= (int2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.int2x3 lhs, short2x3 rhs) => (int2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (short2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs >= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.float2x3 lhs, short2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs == (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs != (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs < (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs > (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs <= (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (short2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs >= (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.double2x3 lhs, short2x3 rhs) => (double2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short2x3 lhs, byte rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (byte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short2x3 lhs, byte rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (byte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short2x3 lhs, byte rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (byte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short2x3 lhs, byte rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (byte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short2x3 lhs, byte rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (byte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short2x3 lhs, byte rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (byte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (short2x3 lhs, sbyte rhs) => new mask16x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator == (sbyte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (short2x3 lhs, sbyte rhs) => new mask16x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator != (sbyte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (short2x3 lhs, sbyte rhs) => new mask16x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator < (sbyte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (short2x3 lhs, sbyte rhs) => new mask16x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator > (sbyte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (short2x3 lhs, sbyte rhs) => new mask16x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator <= (sbyte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (short2x3 lhs, sbyte rhs) => new mask16x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x3 operator >= (sbyte lhs, short2x3 rhs) => new mask16x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        public ref short2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (short2x3* array = &this) { return ref ((short2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        public override readonly bool Equals(object obj) => obj is short2x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"short2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}