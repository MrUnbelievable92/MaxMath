using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint2x3 : IEquatable<uint2x3>, IEquatable<Unity.Mathematics.uint2x3>, IEquatable<uint>, IFormattable
    {
        public uint2 c0;
        public uint2 c1;
        public uint2 c2;

        public static uint2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(uint2 c0, uint2 c1, uint2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(uint m00, uint m01, uint m02,
                       uint m10, uint m11, uint m12)
        {
            this.c0 = new uint2(m00, m10);
            this.c1 = new uint2(m01, m11);
            this.c2 = new uint2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(bool v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(bool2x3 v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(mask8x2x3 v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(mask16x2x3 v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(mask32x2x3 v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(mask64x2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(byte v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(byte2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(sbyte v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(sbyte2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(ushort v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(ushort2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(short v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(short2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(uint v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(uint2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(int v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(int2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(ulong v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(ulong2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(long v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(long2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(UInt128 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Int128 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(quarter v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(half v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(float v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(float2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(double v)
        {
            this = (uint2x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(double2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(quadruple v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Unity.Mathematics.bool2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Unity.Mathematics.uint2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Unity.Mathematics.int2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Unity.Mathematics.half v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Unity.Mathematics.float2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2x3(Unity.Mathematics.double2x3 v)
        {
            this = (uint2x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x3(Unity.Mathematics.uint2x3 v) => new uint2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint2x3(uint2x3 v) => new Unity.Mathematics.uint2x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2x3(uint2x3 v) => new bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(Unity.Mathematics.bool2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2x3(uint2x3 v) => new Unity.Mathematics.bool2x3 { c0 = (bool2)v.c0, c1 = (bool2)v.c1, c2 = (bool2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(Unity.Mathematics.int2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x3(uint2x3 v) => new int2x3 { c0 = (int2)v.c0, c1 = (int2)v.c1, c2 = (int2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(Unity.Mathematics.float2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2x3(uint2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(Unity.Mathematics.half v) => (uint2x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(Unity.Mathematics.double2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2x3(uint2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x3(uint v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(bool v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(bool2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(sbyte v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(sbyte2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(short v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(short2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(int v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(int2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(long v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(long2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint2x3(byte v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x3(byte2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint2x3(ushort v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x3(ushort2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(ulong v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(ulong2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(float v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(float2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(half v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(double v) => new uint2x3 { c0 = (uint2)v, c1 = (uint2)v, c2 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(double2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(mask8x2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(mask16x2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(mask32x2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(mask64x2x3 v) => new uint2x3 { c0 = (uint2)v.c0, c1 = (uint2)v.c1, c2 = (uint2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2x3(uint2x3 v) => new mask8x2x3 { c0 = (mask8x2)v.c0, c1 = (mask8x2)v.c1, c2 = (mask8x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x3(uint2x3 v) => new mask16x2x3 { c0 = (mask16x2)v.c0, c1 = (mask16x2)v.c1, c2 = (mask16x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2x3(uint2x3 v) => new mask32x2x3 { c0 = (mask32x2)v.c0, c1 = (mask32x2)v.c1, c2 = (mask32x2)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2x3(uint2x3 v) => new mask64x2x3 { c0 = (mask64x2)v.c0, c1 = (mask64x2)v.c1, c2 = (mask64x2)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ++ (uint2x3 val) => new uint2x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator -- (uint2x3 val) => new uint2x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs + (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs - (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs * (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs / (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs % (uint2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs + (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs - (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs * (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs / (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs % (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator + (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator - (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator * (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator / (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x3 operator % (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs + (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs - (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs * (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs / (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs % (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator + (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator - (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator * (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator / (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2x3 operator % (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, byte2x3 rhs) => lhs + (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, byte2x3 rhs) => lhs - (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, byte2x3 rhs) => lhs * (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, byte2x3 rhs) => lhs / (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, byte2x3 rhs) => lhs % (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, ushort2x3 rhs) => lhs + (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, ushort2x3 rhs) => lhs - (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, ushort2x3 rhs) => lhs * (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, ushort2x3 rhs) => lhs / (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, ushort2x3 rhs) => lhs % (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (byte lhs, uint2x3 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (byte lhs, uint2x3 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (byte lhs, uint2x3 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (byte lhs, uint2x3 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (byte lhs, uint2x3 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (uint2x3 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator + (ushort lhs, uint2x3 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (uint2x3 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator - (ushort lhs, uint2x3 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (uint2x3 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator * (ushort lhs, uint2x3 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (uint2x3 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator / (ushort lhs, uint2x3 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (uint2x3 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator % (ushort lhs, uint2x3 rhs) => (uint)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator << (uint2x3 lhs, int rhs) => new uint2x3 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator >> (uint2x3 lhs, int rhs) => new uint2x3 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ~ (uint2x3 v) => new uint2x3 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, uint rhs) => new uint2x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint lhs, uint2x3 rhs) => new uint2x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs & (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs | (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs ^ (uint2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, byte2x3 rhs) => lhs & (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, byte2x3 rhs) => lhs | (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, byte2x3 rhs) => lhs ^ (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, ushort2x3 rhs) => lhs & (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, ushort2x3 rhs) => lhs | (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, ushort2x3 rhs) => lhs ^ (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (byte lhs, uint2x3 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (byte lhs, uint2x3 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (byte lhs, uint2x3 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (uint2x3 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator & (ushort lhs, uint2x3 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (uint2x3 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator | (ushort lhs, uint2x3 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (uint2x3 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2x3 operator ^ (ushort lhs, uint2x3 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, uint rhs) => new mask32x2x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, uint rhs) => new mask32x2x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, uint rhs) => new mask32x2x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, uint rhs) => new mask32x2x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, uint rhs) => new mask32x2x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, uint rhs) => new mask32x2x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint lhs, uint2x3 rhs) => new mask32x2x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs == (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs != (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs < (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs > (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs <= (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, Unity.Mathematics.uint2x3 rhs) => lhs >= (uint2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.uint2x3 lhs, uint2x3 rhs) => (uint2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs == (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs != (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs < (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs > (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs <= (float2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, Unity.Mathematics.float2x3 rhs) => lhs >= (float2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (Unity.Mathematics.float2x3 lhs, uint2x3 rhs) => (float2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs == (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs != (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs < (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs > (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs <= (double2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (uint2x3 lhs, Unity.Mathematics.double2x3 rhs) => lhs >= (double2x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator == (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator != (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator < (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator > (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator <= (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x3 operator >= (Unity.Mathematics.double2x3 lhs, uint2x3 rhs) => (double2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, byte2x3 rhs) => lhs == (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, byte2x3 rhs) => lhs != (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, byte2x3 rhs) => lhs < (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, byte2x3 rhs) => lhs > (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, byte2x3 rhs) => lhs <= (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, byte2x3 rhs) => lhs >= (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (byte2x3 lhs, uint2x3 rhs) => (uint2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, ushort2x3 rhs) => lhs == (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, ushort2x3 rhs) => lhs != (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, ushort2x3 rhs) => lhs < (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, ushort2x3 rhs) => lhs > (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, ushort2x3 rhs) => lhs <= (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, ushort2x3 rhs) => lhs >= (uint2x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ushort2x3 lhs, uint2x3 rhs) => (uint2x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (byte lhs, uint2x3 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (byte lhs, uint2x3 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (byte lhs, uint2x3 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (byte lhs, uint2x3 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (byte lhs, uint2x3 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (byte lhs, uint2x3 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (uint2x3 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator == (ushort lhs, uint2x3 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (uint2x3 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator != (ushort lhs, uint2x3 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (uint2x3 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator < (ushort lhs, uint2x3 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (uint2x3 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator > (ushort lhs, uint2x3 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (uint2x3 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator <= (ushort lhs, uint2x3 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (uint2x3 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x3 operator >= (ushort lhs, uint2x3 rhs) => (uint)lhs >= rhs;


        public ref uint2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (uint2x3* array = &this) { return ref ((uint2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint2x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is uint2x3 converted && Equals(converted)) || (o is Unity.Mathematics.uint2x3 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.uint2x3)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.uint2x3)this).ToString(format, formatProvider);
    }
}
