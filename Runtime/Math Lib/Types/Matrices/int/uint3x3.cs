using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint3x3 : IEquatable<uint3x3>, IEquatable<Unity.Mathematics.uint3x3>, IEquatable<uint>, IFormattable
    {
        public uint3 c0;
        public uint3 c1;
        public uint3 c2;


        public static uint3x3 identity => new uint3x3(1u, 0u, 0u,   0u, 1u, 0u,   0u, 0u, 1u);
        public static uint3x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(uint3 c0, uint3 c1, uint3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(uint m00, uint m01, uint m02,
                       uint m10, uint m11, uint m12,
                       uint m20, uint m21, uint m22)
        {
            this.c0 = new uint3(m00, m10, m20);
            this.c1 = new uint3(m01, m11, m21);
            this.c2 = new uint3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(bool v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(bool3x3 v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(mask8x3x3 v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(mask16x3x3 v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(mask32x3x3 v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(mask64x3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(byte v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(byte3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(sbyte v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(sbyte3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(ushort v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(ushort3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(short v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(short3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(uint v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(uint3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(int v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(int3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(ulong v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(ulong3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(long v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(long3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(UInt128 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Int128 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(quarter v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(half v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(float v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(float3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(double v)
        {
            this = (uint3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(double3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(quadruple v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Unity.Mathematics.bool3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Unity.Mathematics.uint3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Unity.Mathematics.int3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Unity.Mathematics.half v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Unity.Mathematics.float3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x3(Unity.Mathematics.double3x3 v)
        {
            this = (uint3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x3(Unity.Mathematics.uint3x3 v) => new uint3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3x3(uint3x3 v) => new Unity.Mathematics.uint3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(uint3x3 v) => new bool3x3 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(Unity.Mathematics.bool3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x3(uint3x3 v) => new Unity.Mathematics.bool3x3 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(Unity.Mathematics.int3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x3(uint3x3 v) => new int3x3 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(Unity.Mathematics.float3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x3(uint3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(Unity.Mathematics.half v) => (uint3x3)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(Unity.Mathematics.double3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x3(uint3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x3(uint v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(bool v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(bool3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(sbyte v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(sbyte3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(short v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(short3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(int v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(int3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(long v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(long3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3x3(byte v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x3(byte3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3x3(ushort v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x3(ushort3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(ulong v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(ulong3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(float v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(float3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(half v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(double v) => new uint3x3 { c0 = (uint3)v, c1 = (uint3)v, c2 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(double3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(mask8x3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(mask16x3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(mask32x3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x3(mask64x3x3 v) => new uint3x3 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(uint3x3 v) => new mask8x3x3 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1, c2 = (mask8x3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x3(uint3x3 v) => new mask16x3x3 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1, c2 = (mask16x3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x3(uint3x3 v) => new mask32x3x3 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1, c2 = (mask32x3)v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x3(uint3x3 v) => new mask64x3x3 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1, c2 = (mask64x3)v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ++ (uint3x3 val) => new uint3x3 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator -- (uint3x3 val) => new uint3x3 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs + (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs - (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs * (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs / (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs % (uint3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator + (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs + (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator - (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs - (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator * (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs * (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator / (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs / (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator % (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs % (float3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator + (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator - (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator * (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator / (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x3 operator % (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator + (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs + (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator - (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs - (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator * (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs * (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator / (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs / (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator % (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs % (double3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator + (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator - (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator * (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator / (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x3 operator % (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, byte3x3 rhs) => lhs + (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, byte3x3 rhs) => lhs - (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, byte3x3 rhs) => lhs * (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, byte3x3 rhs) => lhs / (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, byte3x3 rhs) => lhs % (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, ushort3x3 rhs) => lhs + (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, ushort3x3 rhs) => lhs - (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, ushort3x3 rhs) => lhs * (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, ushort3x3 rhs) => lhs / (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, ushort3x3 rhs) => lhs % (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (byte lhs, uint3x3 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (byte lhs, uint3x3 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (byte lhs, uint3x3 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (byte lhs, uint3x3 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (byte lhs, uint3x3 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (uint3x3 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator + (ushort lhs, uint3x3 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (uint3x3 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator - (ushort lhs, uint3x3 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (uint3x3 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator * (ushort lhs, uint3x3 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (uint3x3 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator / (ushort lhs, uint3x3 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (uint3x3 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator % (ushort lhs, uint3x3 rhs) => (uint)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator << (uint3x3 lhs, int rhs) => new uint3x3 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs, c2 = lhs.c2 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator >> (uint3x3 lhs, int rhs) => new uint3x3 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs, c2 = lhs.c2 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ~ (uint3x3 v) => new uint3x3 { c0 = ~v.c0, c1 = ~v.c1, c2 = ~v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, uint rhs) => new uint3x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint lhs, uint3x3 rhs) => new uint3x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs & (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs | (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs ^ (uint3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, byte3x3 rhs) => lhs & (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, byte3x3 rhs) => lhs | (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, byte3x3 rhs) => lhs ^ (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, ushort3x3 rhs) => lhs & (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, ushort3x3 rhs) => lhs | (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, ushort3x3 rhs) => lhs ^ (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (byte lhs, uint3x3 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (byte lhs, uint3x3 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (byte lhs, uint3x3 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (uint3x3 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator & (ushort lhs, uint3x3 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (uint3x3 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator | (ushort lhs, uint3x3 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (uint3x3 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x3 operator ^ (ushort lhs, uint3x3 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, uint rhs) => new mask32x3x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, uint rhs) => new mask32x3x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, uint rhs) => new mask32x3x3 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, uint rhs) => new mask32x3x3 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, uint rhs) => new mask32x3x3 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, uint rhs) => new mask32x3x3 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint lhs, uint3x3 rhs) => new mask32x3x3 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs == (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs != (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs < (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs > (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs <= (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, Unity.Mathematics.uint3x3 rhs) => lhs >= (uint3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (Unity.Mathematics.uint3x3 lhs, uint3x3 rhs) => (uint3x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs == (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs != (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs < (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs > (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs <= (float3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, Unity.Mathematics.float3x3 rhs) => lhs >= (float3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (Unity.Mathematics.float3x3 lhs, uint3x3 rhs) => (float3x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator == (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs == (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator != (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs != (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator < (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs < (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator > (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs > (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator <= (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs <= (double3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator >= (uint3x3 lhs, Unity.Mathematics.double3x3 rhs) => lhs >= (double3x3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator == (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator != (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator < (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator > (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator <= (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator >= (Unity.Mathematics.double3x3 lhs, uint3x3 rhs) => (double3x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, byte3x3 rhs) => lhs == (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, byte3x3 rhs) => lhs != (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, byte3x3 rhs) => lhs < (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, byte3x3 rhs) => lhs > (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, byte3x3 rhs) => lhs <= (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, byte3x3 rhs) => lhs >= (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (byte3x3 lhs, uint3x3 rhs) => (uint3x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, ushort3x3 rhs) => lhs == (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, ushort3x3 rhs) => lhs != (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, ushort3x3 rhs) => lhs < (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, ushort3x3 rhs) => lhs > (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, ushort3x3 rhs) => lhs <= (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, ushort3x3 rhs) => lhs >= (uint3x3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (ushort3x3 lhs, uint3x3 rhs) => (uint3x3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (byte lhs, uint3x3 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (byte lhs, uint3x3 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (byte lhs, uint3x3 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (byte lhs, uint3x3 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (byte lhs, uint3x3 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (byte lhs, uint3x3 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (uint3x3 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (ushort lhs, uint3x3 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (uint3x3 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (ushort lhs, uint3x3 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (uint3x3 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator < (ushort lhs, uint3x3 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (uint3x3 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator > (ushort lhs, uint3x3 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (uint3x3 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator <= (ushort lhs, uint3x3 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (uint3x3 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator >= (ushort lhs, uint3x3 rhs) => (uint)lhs >= rhs;


        public ref uint3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (uint3x3* array = &this) { return ref ((uint3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is uint3x3 converted && Equals(converted)) || (o is Unity.Mathematics.uint3x3 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.uint3x3)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.uint3x3)this).ToString(format, formatProvider);
    }
}

