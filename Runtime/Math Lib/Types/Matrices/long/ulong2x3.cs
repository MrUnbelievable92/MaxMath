using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct ulong2x3 : IEquatable<ulong2x3>, IFormattable
    {
        public ulong2 c0;
        public ulong2 c1;
        public ulong2 c2;

        public static ulong2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong2 c0, ulong2 c1, ulong2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong m00, ulong m01, ulong m02,
                        ulong m10, ulong m11, ulong m12)
        {
            this.c0 = new ulong2(m00, m10);
            this.c1 = new ulong2(m01, m11);
            this.c2 = new ulong2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(bool v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(bool2x3 v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(mask8x2x3 v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(mask16x2x3 v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(mask32x2x3 v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(mask64x2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(byte v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(byte2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(sbyte v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(sbyte2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ushort v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ushort2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(short v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(short2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(uint v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(uint2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(int v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(int2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(long v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(long2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(ulong2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(UInt128 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Int128 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(quarter v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(half v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(float v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(float2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(double v)
        {
            this = (ulong2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(double2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(quadruple v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Unity.Mathematics.int2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Unity.Mathematics.half v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Unity.Mathematics.float2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x3(Unity.Mathematics.double2x3 v)
        {
            this = (ulong2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(ulong2x3 v) => new bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(Unity.Mathematics.bool2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x3(ulong2x3 v) => new Unity.Mathematics.bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(Unity.Mathematics.int2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x3(ulong2x3 v) => new int2x3 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(Unity.Mathematics.uint2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x3(ulong2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(Unity.Mathematics.half v) => (ulong2x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(Unity.Mathematics.float2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x3(ulong2x3 v) => new float2x3 { c0 = (float2)v.c0, c1 = (float2)v.c1, c2 = (float2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(Unity.Mathematics.double2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x3(ulong2x3 v) => new double2x3 { c0 = (double2)v.c0, c1 = (double2)v.c1, c2 = (double2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(ulong v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(bool v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(bool2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(sbyte v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(sbyte2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(short v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(short2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(int v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(int2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong2x3(byte v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(byte2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong2x3(ushort v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(ushort2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(uint v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(uint2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(long v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(long2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(half v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(float v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(float2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(double v) => new ulong2x3 { c0 = (ulong2)v, c1 = (ulong2)v, c2 = (ulong2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(double2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(mask8x2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(mask16x2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(mask32x2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(mask64x2x3 v) => new ulong2x3 { c0 = (ulong2)v.c0, c1 = (ulong2)v.c1, c2 = (ulong2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x3(ulong2x3 v) => new mask8x2x3 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x3(ulong2x3 v) => new mask16x2x3 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(ulong2x3 v) => new mask32x2x3 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x3(ulong2x3 v) => new mask64x2x3 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ++ (ulong2x3 val) => new ulong2x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator -- (ulong2x3 val) => new ulong2x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, byte2x3 rhs) => new ulong2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, byte2x3 rhs) => new ulong2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, byte2x3 rhs) => new ulong2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, byte2x3 rhs) => new ulong2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, byte2x3 rhs) => new ulong2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, ushort2x3 rhs) => new ulong2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, ushort2x3 rhs) => new ulong2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, ushort2x3 rhs) => new ulong2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, ushort2x3 rhs) => new ulong2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, ushort2x3 rhs) => new ulong2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => new ulong2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs % (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs + (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs - (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs * (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs / (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs % (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, byte rhs) => new ulong2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (byte lhs, ulong2x3 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, byte rhs) => new ulong2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (byte lhs, ulong2x3 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, byte rhs) => new ulong2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (byte lhs, ulong2x3 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, byte rhs) => new ulong2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (byte lhs, ulong2x3 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, byte rhs) => new ulong2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (byte lhs, ulong2x3 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, ushort rhs) => new ulong2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ushort lhs, ulong2x3 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, ushort rhs) => new ulong2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ushort lhs, ulong2x3 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, ushort rhs) => new ulong2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ushort lhs, ulong2x3 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, ushort rhs) => new ulong2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ushort lhs, ulong2x3 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, ushort rhs) => new ulong2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ushort lhs, ulong2x3 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (ulong2x3 lhs, uint rhs) => new ulong2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator + (uint lhs, ulong2x3 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (ulong2x3 lhs, uint rhs) => new ulong2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator - (uint lhs, ulong2x3 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (ulong2x3 lhs, uint rhs) => new ulong2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator * (uint lhs, ulong2x3 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (ulong2x3 lhs, uint rhs) => new ulong2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator / (uint lhs, ulong2x3 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (ulong2x3 lhs, uint rhs) => new ulong2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator % (uint lhs, ulong2x3 rhs) => (ulong)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ~ (ulong2x3 val) => new ulong2x3 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator << (ulong2x3 val, int n) => new ulong2x3 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator >> (ulong2x3 val, int n) => new ulong2x3 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, ulong rhs) => new ulong2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong lhs, ulong2x3 rhs) => new ulong2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, byte2x3 rhs) => lhs & (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, byte2x3 rhs) => lhs | (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, byte2x3 rhs) => lhs ^ (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, ushort2x3 rhs) => lhs & (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, ushort2x3 rhs) => lhs | (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, ushort2x3 rhs) => lhs ^ (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, uint2x3 rhs) => lhs & (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, uint2x3 rhs) => lhs | (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, uint2x3 rhs) => lhs ^ (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs & (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs | (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs ^ (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, byte rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (byte lhs, ulong2x3 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, byte rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (byte lhs, ulong2x3 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, byte rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (byte lhs, ulong2x3 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, ushort rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ushort lhs, ulong2x3 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, ushort rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ushort lhs, ulong2x3 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, ushort rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ushort lhs, ulong2x3 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (ulong2x3 lhs, uint rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator & (uint lhs, ulong2x3 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (ulong2x3 lhs, uint rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator | (uint lhs, ulong2x3 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (ulong2x3 lhs, uint rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x3 operator ^ (uint lhs, ulong2x3 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, ulong rhs) => new mask64x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, ulong rhs) => new mask64x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, ulong rhs) => new mask64x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, ulong rhs) => new mask64x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, ulong rhs) => new mask64x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, ulong rhs) => new mask64x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong lhs, ulong2x3 rhs) => new mask64x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, byte2x3 rhs) => lhs == (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, byte2x3 rhs) => lhs != (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, byte2x3 rhs) => lhs < (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, byte2x3 rhs) => lhs > (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, byte2x3 rhs) => lhs <= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, byte2x3 rhs) => lhs >= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (byte2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, ushort2x3 rhs) => lhs == (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, ushort2x3 rhs) => lhs != (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, ushort2x3 rhs) => lhs < (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, ushort2x3 rhs) => lhs > (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, ushort2x3 rhs) => lhs <= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, ushort2x3 rhs) => lhs >= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ushort2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, uint2x3 rhs) => lhs == (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, uint2x3 rhs) => lhs != (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, uint2x3 rhs) => lhs < (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, uint2x3 rhs) => lhs > (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, uint2x3 rhs) => lhs <= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, uint2x3 rhs) => lhs >= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs == (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs != (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs < (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs > (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs <= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs >= (ulong2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.uint2x3 lhs, ulong2x3 rhs) => (ulong2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ulong2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs >= (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.float2x3 lhs, ulong2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs == (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs != (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs < (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs > (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs <= (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs >= (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.double2x3 lhs, ulong2x3 rhs) => (double2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, byte rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (byte lhs, ulong2x3 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, byte rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (byte lhs, ulong2x3 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, byte rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (byte lhs, ulong2x3 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, byte rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (byte lhs, ulong2x3 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, byte rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (byte lhs, ulong2x3 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, byte rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (byte lhs, ulong2x3 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, ushort rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ushort lhs, ulong2x3 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, ushort rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ushort lhs, ulong2x3 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, ushort rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ushort lhs, ulong2x3 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, ushort rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ushort lhs, ulong2x3 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, ushort rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ushort lhs, ulong2x3 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, ushort rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ushort lhs, ulong2x3 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (ulong2x3 lhs, uint rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (uint lhs, ulong2x3 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (ulong2x3 lhs, uint rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (uint lhs, ulong2x3 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (ulong2x3 lhs, uint rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (uint lhs, ulong2x3 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (ulong2x3 lhs, uint rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (uint lhs, ulong2x3 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (ulong2x3 lhs, uint rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (uint lhs, ulong2x3 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (ulong2x3 lhs, uint rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (uint lhs, ulong2x3 rhs) => (ulong)lhs >= rhs;


        public ref ulong2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (ulong2x3* array = &this) { return ref ((ulong2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ulong2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        public override readonly bool Equals(object obj) => obj is ulong2x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"ulong2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}