using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint4x4 : IEquatable<uint4x4>, IEquatable<Unity.Mathematics.uint4x4>, IEquatable<uint>, IFormattable
    {
        public uint4 c0;
        public uint4 c1;
        public uint4 c2;
        public uint4 c3;

        public static uint4x4 identity => new uint4x4(1, 0, 0, 0,   0, 1, 0, 0,   0, 0, 1, 0,   0, 0, 0, 1);
        public static uint4x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(uint4 c0, uint4 c1, uint4 c2, uint4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(uint m00, uint m01, uint m02, uint m03,
                       uint m10, uint m11, uint m12, uint m13,
                       uint m20, uint m21, uint m22, uint m23,
                       uint m30, uint m31, uint m32, uint m33)
        {
            this.c0 = new uint4(m00, m10, m20, m30);
            this.c1 = new uint4(m01, m11, m21, m31);
            this.c2 = new uint4(m02, m12, m22, m32);
            this.c3 = new uint4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(bool v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(bool4x4 v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(mask8x4x4 v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(mask16x4x4 v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(mask32x4x4 v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(mask64x4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(byte v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(byte4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(sbyte v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(sbyte4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(ushort v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(ushort4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(short v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(short4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(uint v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(uint4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(int v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(int4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(ulong v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(ulong4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(long v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(long4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(UInt128 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Int128 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(quarter v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(half v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(float v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(float4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(double v)
        {
            this = (uint4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(double4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(quadruple v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Unity.Mathematics.int4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Unity.Mathematics.half v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Unity.Mathematics.float4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x4(Unity.Mathematics.double4x4 v)
        {
            this = (uint4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x4(Unity.Mathematics.uint4x4 v) => new uint4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4x4(uint4x4 v) => new Unity.Mathematics.uint4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(uint4x4 v) => new bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(Unity.Mathematics.bool4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x4(uint4x4 v) => new Unity.Mathematics.bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(Unity.Mathematics.int4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x4(uint4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(Unity.Mathematics.float4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x4(uint4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(Unity.Mathematics.half v) => (uint4x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(Unity.Mathematics.double4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x4(uint4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x4(uint v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(bool v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(bool4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(sbyte v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(sbyte4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(short v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(short4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(int v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(int4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(long v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(long4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint4x4(byte v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x4(byte4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint4x4(ushort v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x4(ushort4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(ulong v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(ulong4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(float v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(float4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(half v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(double v) => new uint4x4 { c0 = (uint4)v, c1 = (uint4)v, c2 = (uint4)v, c3 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(double4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(mask8x4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(mask16x4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(mask32x4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x4(mask64x4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x4(uint4x4 v) => new mask8x4x4 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2, c3 = (mask8x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x4(uint4x4 v) => new mask16x4x4 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2, c3 = (mask16x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(uint4x4 v) => new mask32x4x4 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2, c3 = (mask32x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x4(uint4x4 v) => new mask64x4x4 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2, c3 = (mask64x4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ++ (uint4x4 val) => new uint4x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator -- (uint4x4 val) => new uint4x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs + (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs - (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs * (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs / (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs % (uint4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs % (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs % (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, byte4x4 rhs) => lhs + (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, byte4x4 rhs) => lhs - (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, byte4x4 rhs) => lhs * (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, byte4x4 rhs) => lhs / (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, byte4x4 rhs) => lhs % (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, ushort4x4 rhs) => lhs + (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, ushort4x4 rhs) => lhs - (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, ushort4x4 rhs) => lhs * (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, ushort4x4 rhs) => lhs / (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, ushort4x4 rhs) => lhs % (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (byte lhs, uint4x4 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (byte lhs, uint4x4 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (byte lhs, uint4x4 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (byte lhs, uint4x4 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (byte lhs, uint4x4 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (uint4x4 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator + (ushort lhs, uint4x4 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (uint4x4 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator - (ushort lhs, uint4x4 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (uint4x4 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator * (ushort lhs, uint4x4 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (uint4x4 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator / (ushort lhs, uint4x4 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (uint4x4 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator % (ushort lhs, uint4x4 rhs) => (uint)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator << (uint4x4 lhs, int rhs) => new uint4x4 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs, c3 = lhs.c3 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator >> (uint4x4 lhs, int rhs) => new uint4x4 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs, c3 = lhs.c3 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ~ (uint4x4 v) => new uint4x4 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2, c3 = ~v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, uint rhs) => new uint4x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint lhs, uint4x4 rhs) => new uint4x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs & (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs | (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs ^ (uint4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, byte4x4 rhs) => lhs & (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, byte4x4 rhs) => lhs | (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, byte4x4 rhs) => lhs ^ (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, ushort4x4 rhs) => lhs & (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, ushort4x4 rhs) => lhs | (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, ushort4x4 rhs) => lhs ^ (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (byte lhs, uint4x4 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (byte lhs, uint4x4 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (byte lhs, uint4x4 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (uint4x4 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator & (ushort lhs, uint4x4 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (uint4x4 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator | (ushort lhs, uint4x4 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (uint4x4 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x4 operator ^ (ushort lhs, uint4x4 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, uint rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, uint rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, uint rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, uint rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, uint rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, uint rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint lhs, uint4x4 rhs) => new mask32x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs == (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs != (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs < (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs > (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs <= (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs >= (uint4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.uint4x4 lhs, uint4x4 rhs) => (uint4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs >= (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.float4x4 lhs, uint4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (uint4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs >= (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.double4x4 lhs, uint4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, byte4x4 rhs) => lhs == (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, byte4x4 rhs) => lhs != (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, byte4x4 rhs) => lhs < (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, byte4x4 rhs) => lhs > (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, byte4x4 rhs) => lhs <= (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, byte4x4 rhs) => lhs >= (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (byte4x4 lhs, uint4x4 rhs) => (uint4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, ushort4x4 rhs) => lhs == (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, ushort4x4 rhs) => lhs != (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, ushort4x4 rhs) => lhs < (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, ushort4x4 rhs) => lhs > (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, ushort4x4 rhs) => lhs <= (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, ushort4x4 rhs) => lhs >= (uint4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ushort4x4 lhs, uint4x4 rhs) => (uint4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (byte lhs, uint4x4 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (byte lhs, uint4x4 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (byte lhs, uint4x4 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (byte lhs, uint4x4 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (byte lhs, uint4x4 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (byte lhs, uint4x4 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ushort lhs, uint4x4 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ushort lhs, uint4x4 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ushort lhs, uint4x4 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ushort lhs, uint4x4 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ushort lhs, uint4x4 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ushort lhs, uint4x4 rhs) => (uint)lhs >= rhs;


        public ref uint4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (uint4x4* array = &this) { return ref ((uint4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is uint4x4 converted && Equals(converted)) || (o is Unity.Mathematics.uint4x4 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.uint4x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.uint4x4)this).ToString(format, formatProvider);
    }
}
