using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint3x4 : IEquatable<uint3x4>, IEquatable<Unity.Mathematics.uint3x4>, IEquatable<uint>, IFormattable
    {
        public uint3 c0;
        public uint3 c1;
        public uint3 c2;
        public uint3 c3;

        public static uint3x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(uint3 c0, uint3 c1, uint3 c2, uint3 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(uint m00, uint m01, uint m02, uint m03,
                       uint m10, uint m11, uint m12, uint m13,
                       uint m20, uint m21, uint m22, uint m23)
        {
            this.c0 = new uint3(m00, m10, m20);
            this.c1 = new uint3(m01, m11, m21);
            this.c2 = new uint3(m02, m12, m22);
            this.c3 = new uint3(m03, m13, m23);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(bool v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(bool3x4 v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(mask8x3x4 v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(mask16x3x4 v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(mask32x3x4 v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(mask64x3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(byte v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(byte3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(sbyte v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(sbyte3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(ushort v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(ushort3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(short v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(short3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(uint v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(uint3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(int v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(int3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(ulong v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(ulong3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(long v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(long3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(UInt128 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Int128 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(quarter v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(half v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(float v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(float3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(double v)
        {
            this = (uint3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(double3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(quadruple v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Unity.Mathematics.bool3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Unity.Mathematics.uint3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Unity.Mathematics.int3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Unity.Mathematics.half v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Unity.Mathematics.float3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x4(Unity.Mathematics.double3x4 v)
        {
            this = (uint3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x4(Unity.Mathematics.uint3x4 v) => new uint3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3x4(uint3x4 v) => new Unity.Mathematics.uint3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(uint3x4 v) => new bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(Unity.Mathematics.bool3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x4(uint3x4 v) => new Unity.Mathematics.bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(Unity.Mathematics.int3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x4(uint3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(Unity.Mathematics.float3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x4(uint3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(Unity.Mathematics.half v) => (uint3x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(Unity.Mathematics.double3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x4(uint3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x4(uint v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(bool v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(bool3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(sbyte v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(sbyte3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(short v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(short3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(int v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(int3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(long v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(long3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3x4(byte v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x4(byte3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3x4(ushort v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x4(ushort3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(ulong v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(ulong3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(float v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(float3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(half v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(double v) => new uint3x4 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v, c3 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(double3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(mask8x3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(mask16x3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(mask32x3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(mask64x3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x4(uint3x4 v) => new mask8x3x4 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1, c2 = (mask8x3)v.c2, c3 = (mask8x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x4(uint3x4 v) => new mask16x3x4 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1, c2 = (mask16x3)v.c2, c3 = (mask16x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x4(uint3x4 v) => new mask32x3x4 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1, c2 = (mask32x3)v.c2, c3 = (mask32x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x4(uint3x4 v) => new mask64x3x4 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1, c2 = (mask64x3)v.c2, c3 = (mask64x3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ++ (uint3x4 val) => new uint3x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator -- (uint3x4 val) => new uint3x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs + (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs - (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs * (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs / (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs % (uint3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator + (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs + (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator - (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs - (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator * (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs * (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator / (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs / (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator % (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs % (float3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator + (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator - (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator * (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator / (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator % (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs % (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, byte3x4 rhs) => lhs + (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, byte3x4 rhs) => lhs - (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, byte3x4 rhs) => lhs * (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, byte3x4 rhs) => lhs / (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, byte3x4 rhs) => lhs % (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, ushort3x4 rhs) => lhs + (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, ushort3x4 rhs) => lhs - (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, ushort3x4 rhs) => lhs * (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, ushort3x4 rhs) => lhs / (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, ushort3x4 rhs) => lhs % (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (byte lhs, uint3x4 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (byte lhs, uint3x4 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (byte lhs, uint3x4 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (byte lhs, uint3x4 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (byte lhs, uint3x4 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (uint3x4 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator + (ushort lhs, uint3x4 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (uint3x4 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator - (ushort lhs, uint3x4 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (uint3x4 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator * (ushort lhs, uint3x4 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (uint3x4 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator / (ushort lhs, uint3x4 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (uint3x4 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator % (ushort lhs, uint3x4 rhs) => (uint)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator << (uint3x4 lhs, int rhs) => new uint3x4 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs, c3 = lhs.c3 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator >> (uint3x4 lhs, int rhs) => new uint3x4 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs, c3 = lhs.c3 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ~ (uint3x4 v) => new uint3x4 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2, c3 = ~v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, uint rhs) => new uint3x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint lhs, uint3x4 rhs) => new uint3x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs & (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs | (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs ^ (uint3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, byte3x4 rhs) => lhs & (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, byte3x4 rhs) => lhs | (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, byte3x4 rhs) => lhs ^ (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, ushort3x4 rhs) => lhs & (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, ushort3x4 rhs) => lhs | (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, ushort3x4 rhs) => lhs ^ (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (byte lhs, uint3x4 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (byte lhs, uint3x4 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (byte lhs, uint3x4 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (uint3x4 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator & (ushort lhs, uint3x4 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (uint3x4 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator | (ushort lhs, uint3x4 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (uint3x4 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x4 operator ^ (ushort lhs, uint3x4 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, uint rhs) => new mask32x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, uint rhs) => new mask32x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, uint rhs) => new mask32x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, uint rhs) => new mask32x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, uint rhs) => new mask32x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, uint rhs) => new mask32x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint lhs, uint3x4 rhs) => new mask32x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs == (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs != (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs < (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs > (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs <= (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs >= (uint3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (Unity.Mathematics.uint3x4 lhs, uint3x4 rhs) => (uint3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs == (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs != (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs < (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs > (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs <= (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs >= (float3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (Unity.Mathematics.float3x4 lhs, uint3x4 rhs) => (float3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (uint3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs >= (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.double3x4 lhs, uint3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, byte3x4 rhs) => lhs == (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, byte3x4 rhs) => lhs != (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, byte3x4 rhs) => lhs < (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, byte3x4 rhs) => lhs > (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, byte3x4 rhs) => lhs <= (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, byte3x4 rhs) => lhs >= (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (byte3x4 lhs, uint3x4 rhs) => (uint3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, ushort3x4 rhs) => lhs == (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, ushort3x4 rhs) => lhs != (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, ushort3x4 rhs) => lhs < (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, ushort3x4 rhs) => lhs > (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, ushort3x4 rhs) => lhs <= (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, ushort3x4 rhs) => lhs >= (uint3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (ushort3x4 lhs, uint3x4 rhs) => (uint3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (byte lhs, uint3x4 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (byte lhs, uint3x4 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (byte lhs, uint3x4 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (byte lhs, uint3x4 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (byte lhs, uint3x4 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (byte lhs, uint3x4 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (uint3x4 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (ushort lhs, uint3x4 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (uint3x4 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (ushort lhs, uint3x4 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (uint3x4 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (ushort lhs, uint3x4 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (uint3x4 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (ushort lhs, uint3x4 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (uint3x4 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (ushort lhs, uint3x4 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (uint3x4 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (ushort lhs, uint3x4 rhs) => (uint)lhs >= rhs;


        public ref uint3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (uint3x4* array = &this) { return ref ((uint3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is uint3x4 converted && Equals(converted)) || (o is Unity.Mathematics.uint3x4 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.uint3x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.uint3x4)this).ToString(format, formatProvider);
    }
}
