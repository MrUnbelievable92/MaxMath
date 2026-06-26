using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct short2x2 : IEquatable<short2x2>, IFormattable
    {
        public short2 c0;
        public short2 c1;
        

        public static short2x2 identity => new short2x2(1, 0,   0, 1);
        public static short2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(short2 c0, short2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(short m00, short m01,
                        short m10, short m11)
        {
            this.c0 = new short2(m00, m10);
            this.c1 = new short2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(bool v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(bool2x2 v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(mask8x2x2 v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(mask16x2x2 v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(mask32x2x2 v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(mask64x2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(byte v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(byte2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(sbyte v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(sbyte2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(short v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(short2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(ushort v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(ushort2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(uint v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(uint2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(int v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(int2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(long v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(long2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(ulong v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(ulong2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(UInt128 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Int128 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(quarter v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(half v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(float v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(float2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(double v)
        {
            this = (short2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(double2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(quadruple v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Unity.Mathematics.int2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Unity.Mathematics.half v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Unity.Mathematics.float2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x2(Unity.Mathematics.double2x2 v)
        {
            this = (short2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(UInt128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Int128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(quarter x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(quadruple x) => (short)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x2(short2x2 v) => new bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Unity.Mathematics.bool2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x2(short2x2 v) => new Unity.Mathematics.bool2x2 { c0 = (bool2)v.c0, c1 = (bool2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Unity.Mathematics.int2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2x2(short2x2 v) => new int2x2 { c0 = (int2)v.c0, c1 = (int2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Unity.Mathematics.uint2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(short2x2 v) => new uint2x2 { c0 = (uint2)v.c0, c1 = (uint2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Unity.Mathematics.half v) => (short2x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Unity.Mathematics.float2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x2(short2x2 v) => new float2x2 { c0 = (float2)v.c0, c1 = (float2)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(Unity.Mathematics.double2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x2(short2x2 v) => new double2x2 { c0 = (double2)v.c0, c1 = (double2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x2(short v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(bool v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(bool2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short2x2(sbyte v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x2(sbyte2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(int v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(int2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(long v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(long2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short2x2(byte v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x2(byte2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(ushort v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(ushort2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(uint v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(uint2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(ulong v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(ulong2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(half v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(float v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(float2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(double v) => new short2x2 { c0 = (short2)v, c1 = (short2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(double2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(mask8x2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(mask16x2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(mask32x2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x2(mask64x2x2 v) => new short2x2 { c0 = (short2)v.c0, c1 = (short2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x2(short2x2 v) => new mask8x2x2 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(short2x2 v) => new mask16x2x2 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x2(short2x2 v) => new mask32x2x2 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x2(short2x2 v) => new mask64x2x2 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 val) => new short2x2 { c0 = -val.c0, c1 = -val.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ++ (short2x2 val) => new short2x2 { c0 = val.c0 + (short)1, c1 = val.c1 + (short)1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator -- (short2x2 val) => new short2x2 { c0 = val.c0 - (short)1, c1 = val.c1 - (short)1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs + (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs - (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs * (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs / (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs % (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator + (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator - (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator * (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator / (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator % (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs + (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs - (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs * (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs / (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs % (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator + (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator - (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator * (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator / (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator % (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs + (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs - (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs * (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs / (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs % (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator + (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator - (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator * (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator / (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x2 operator % (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (short2x2 lhs, sbyte rhs) => new short2x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator + (sbyte lhs, short2x2 rhs) => new short2x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (short2x2 lhs, sbyte rhs) => new short2x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator - (sbyte lhs, short2x2 rhs) => new short2x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (short2x2 lhs, sbyte rhs) => new short2x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator * (sbyte lhs, short2x2 rhs) => new short2x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (short2x2 lhs, sbyte rhs) => new short2x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator / (sbyte lhs, short2x2 rhs) => new short2x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (short2x2 lhs, sbyte rhs) => new short2x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator % (sbyte lhs, short2x2 rhs) => new short2x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ~ (short2x2 val) => new short2x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator << (short2x2 val, int n) => new short2x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator >> (short2x2 val, int n) => new short2x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (short2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (short2x2 lhs, short rhs) => new short2x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (short lhs, short2x2 rhs) => new short2x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (short2x2 lhs, byte2x2 rhs) => new short2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (byte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (short2x2 lhs, sbyte2x2 rhs) => new short2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (sbyte2x2 lhs, short2x2 rhs) => new short2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs & (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs | (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs ^ (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator & (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator | (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2x2 operator ^ (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator & (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator | (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (short2x2 lhs, byte rhs) => new short2x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x2 operator ^ (byte lhs, short2x2 rhs) => new short2x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short2x2 lhs, short rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short2x2 lhs, short rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short2x2 lhs, short rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short2x2 lhs, short rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short2x2 lhs, short rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short2x2 lhs, short rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short2x2 lhs, byte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short2x2 lhs, byte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short2x2 lhs, byte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short2x2 lhs, byte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short2x2 lhs, byte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short2x2 lhs, byte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (byte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (byte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (byte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (byte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (byte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (byte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short2x2 lhs, sbyte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short2x2 lhs, sbyte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short2x2 lhs, sbyte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short2x2 lhs, sbyte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short2x2 lhs, sbyte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short2x2 lhs, sbyte2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (sbyte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (sbyte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (sbyte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (sbyte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (sbyte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (sbyte2x2 lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs == (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs != (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs < (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs > (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs <= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (short2x2 lhs, Unity.Mathematics.int2x2 rhs) => lhs >= (int2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.int2x2 lhs, short2x2 rhs) => (int2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs == (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs != (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs < (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs > (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs <= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (short2x2 lhs, Unity.Mathematics.float2x2 rhs) => lhs >= (float2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator < (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator > (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator <= (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator >= (Unity.Mathematics.float2x2 lhs, short2x2 rhs) => (float2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs == (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs != (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs < (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs > (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs <= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (short2x2 lhs, Unity.Mathematics.double2x2 rhs) => lhs >= (double2x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator < (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator > (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator <= (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator >= (Unity.Mathematics.double2x2 lhs, short2x2 rhs) => (double2x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short2x2 lhs, byte rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (byte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short2x2 lhs, byte rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (byte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short2x2 lhs, byte rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (byte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short2x2 lhs, byte rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (byte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short2x2 lhs, byte rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (byte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short2x2 lhs, byte rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (byte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (short2x2 lhs, sbyte rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (sbyte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (short2x2 lhs, sbyte rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (sbyte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (short2x2 lhs, sbyte rhs) => new mask16x2x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator < (sbyte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (short2x2 lhs, sbyte rhs) => new mask16x2x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator > (sbyte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (short2x2 lhs, sbyte rhs) => new mask16x2x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator <= (sbyte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (short2x2 lhs, sbyte rhs) => new mask16x2x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator >= (sbyte lhs, short2x2 rhs) => new mask16x2x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        public ref short2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (short2x2* array = &this) { return ref ((short2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is short2x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"short2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}