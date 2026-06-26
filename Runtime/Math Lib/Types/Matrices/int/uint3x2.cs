using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint3x2 : IEquatable<uint3x2>, IEquatable<Unity.Mathematics.uint3x2>, IEquatable<uint>, IFormattable
    {
        public uint3 c0;
        public uint3 c1;

        public static uint3x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint3 c0, uint3 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint m00, uint m01,
                       uint m10, uint m11,
                       uint m20, uint m21)
        {
            this.c0 = new uint3(m00, m10, m20);
            this.c1 = new uint3(m01, m11, m21);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(bool v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(bool3x2 v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(mask8x3x2 v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(mask16x3x2 v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(mask32x3x2 v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(mask64x3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(byte v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(byte3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(sbyte v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(sbyte3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(ushort v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(ushort3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(short v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(short3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(uint3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(int v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(int3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(ulong v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(ulong3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(long v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(long3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(UInt128 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Int128 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(quarter v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(half v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(float v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(float3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(double v)
        {
            this = (uint3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(double3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(quadruple v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Unity.Mathematics.bool3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Unity.Mathematics.uint3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Unity.Mathematics.int3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Unity.Mathematics.half v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Unity.Mathematics.float3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3x2(Unity.Mathematics.double3x2 v)
        {
            this = (uint3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x2(Unity.Mathematics.uint3x2 v) => new uint3x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3x2(uint3x2 v) => new Unity.Mathematics.uint3x2 { c0 = v.c0, c1 = v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(uint3x2 v) => new bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(Unity.Mathematics.bool3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x2(uint3x2 v) => new Unity.Mathematics.bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(Unity.Mathematics.int3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x2(uint3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(Unity.Mathematics.float3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x2(uint3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(Unity.Mathematics.half v) => (uint3x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(Unity.Mathematics.double3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x2(uint3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x2(uint v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(bool v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(bool3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(sbyte v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(sbyte3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(short v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(short3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(int v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(int3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(long v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(long3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3x2(byte v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x2(byte3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3x2(ushort v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x2(ushort3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(ulong v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(ulong3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(float v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(float3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(half v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(double v) => new uint3x2 { c0 = (uint3)v, c1 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(double3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(mask8x3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(mask16x3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(mask32x3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x2(mask64x3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x2(uint3x2 v) => new mask8x3x2 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x2(uint3x2 v) => new mask16x3x2 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x2(uint3x2 v) => new mask32x3x2 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x2(uint3x2 v) => new mask64x3x2 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ++ (uint3x2 val) => new uint3x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator -- (uint3x2 val) => new uint3x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs + (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs - (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs * (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs / (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs % (uint3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs + (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs - (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs * (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs / (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs % (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs + (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs - (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs * (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs / (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs % (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, byte3x2 rhs) => lhs + (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, byte3x2 rhs) => lhs - (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, byte3x2 rhs) => lhs * (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, byte3x2 rhs) => lhs / (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, byte3x2 rhs) => lhs % (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, ushort3x2 rhs) => lhs + (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, ushort3x2 rhs) => lhs - (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, ushort3x2 rhs) => lhs * (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, ushort3x2 rhs) => lhs / (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, ushort3x2 rhs) => lhs % (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (byte lhs, uint3x2 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (byte lhs, uint3x2 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (byte lhs, uint3x2 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (byte lhs, uint3x2 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (byte lhs, uint3x2 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (uint3x2 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator + (ushort lhs, uint3x2 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (uint3x2 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator - (ushort lhs, uint3x2 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (uint3x2 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator * (ushort lhs, uint3x2 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (uint3x2 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator / (ushort lhs, uint3x2 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (uint3x2 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator % (ushort lhs, uint3x2 rhs) => (uint)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator << (uint3x2 lhs, int rhs) => new uint3x2 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator >> (uint3x2 lhs, int rhs) => new uint3x2 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ~ (uint3x2 v) => new uint3x2 { c0 = ~v.c0, c1 = ~v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, uint rhs) => new uint3x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint lhs, uint3x2 rhs) => new uint3x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs & (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs | (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs ^ (uint3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, byte3x2 rhs) => lhs & (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, byte3x2 rhs) => lhs | (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, byte3x2 rhs) => lhs ^ (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, ushort3x2 rhs) => lhs & (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, ushort3x2 rhs) => lhs | (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, ushort3x2 rhs) => lhs ^ (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (byte lhs, uint3x2 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (byte lhs, uint3x2 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (byte lhs, uint3x2 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (uint3x2 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator & (ushort lhs, uint3x2 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (uint3x2 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator | (ushort lhs, uint3x2 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (uint3x2 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3x2 operator ^ (ushort lhs, uint3x2 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, uint rhs) => new mask32x3x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, uint rhs) => new mask32x3x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, uint rhs) => new mask32x3x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, uint rhs) => new mask32x3x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, uint rhs) => new mask32x3x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, uint rhs) => new mask32x3x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint lhs, uint3x2 rhs) => new mask32x3x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs == (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs != (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs < (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs > (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs <= (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs >= (uint3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (Unity.Mathematics.uint3x2 lhs, uint3x2 rhs) => (uint3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs == (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs != (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs < (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs > (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs <= (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs >= (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (Unity.Mathematics.float3x2 lhs, uint3x2 rhs) => (float3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs == (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs != (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs < (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs > (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs <= (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (uint3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs >= (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.double3x2 lhs, uint3x2 rhs) => (double3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, byte3x2 rhs) => lhs == (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, byte3x2 rhs) => lhs != (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, byte3x2 rhs) => lhs < (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, byte3x2 rhs) => lhs > (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, byte3x2 rhs) => lhs <= (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, byte3x2 rhs) => lhs >= (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (byte3x2 lhs, uint3x2 rhs) => (uint3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, ushort3x2 rhs) => lhs == (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, ushort3x2 rhs) => lhs != (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, ushort3x2 rhs) => lhs < (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, ushort3x2 rhs) => lhs > (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, ushort3x2 rhs) => lhs <= (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, ushort3x2 rhs) => lhs >= (uint3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (ushort3x2 lhs, uint3x2 rhs) => (uint3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (byte lhs, uint3x2 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (byte lhs, uint3x2 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (byte lhs, uint3x2 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (byte lhs, uint3x2 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (byte lhs, uint3x2 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (byte lhs, uint3x2 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (uint3x2 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (ushort lhs, uint3x2 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (uint3x2 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (ushort lhs, uint3x2 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (uint3x2 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (ushort lhs, uint3x2 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (uint3x2 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (ushort lhs, uint3x2 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (uint3x2 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (ushort lhs, uint3x2 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (uint3x2 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (ushort lhs, uint3x2 rhs) => (uint)lhs >= rhs;


        public ref uint3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (uint3x2* array = &this) { return ref ((uint3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is uint3x2 converted && Equals(converted)) || (o is Unity.Mathematics.uint3x2 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.uint3x2)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.uint3x2)this).ToString(format, formatProvider);
    }
}
