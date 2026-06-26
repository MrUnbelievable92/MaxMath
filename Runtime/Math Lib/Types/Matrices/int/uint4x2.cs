using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint4x2 : IEquatable<uint4x2>, IEquatable<Unity.Mathematics.uint4x2>, IEquatable<uint>, IFormattable
    {
        public uint4 c0;
        public uint4 c1;

        public static uint4x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(uint4 c0, uint4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(uint m00, uint m01,
                       uint m10, uint m11,
                       uint m20, uint m21,
                       uint m30, uint m31)
        {
            this.c0 = new uint4(m00, m10, m20, m30);
            this.c1 = new uint4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(bool v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(bool4x2 v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(mask8x4x2 v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(mask16x4x2 v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(mask32x4x2 v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(mask64x4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(byte v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(byte4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(sbyte v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(sbyte4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(ushort v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(ushort4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(short v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(short4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(uint v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(uint4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(int v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(int4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(ulong v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(ulong4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(long v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(long4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(UInt128 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Int128 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(quarter v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(half v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(float v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(float4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(double v)
        {
            this = (uint4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(double4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(quadruple v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Unity.Mathematics.bool4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Unity.Mathematics.uint4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Unity.Mathematics.int4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Unity.Mathematics.half v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Unity.Mathematics.float4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4x2(Unity.Mathematics.double4x2 v)
        {
            this = (uint4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x2(Unity.Mathematics.uint4x2 v) => new uint4x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4x2(uint4x2 v) => new Unity.Mathematics.uint4x2 { c0 = v.c0, c1 = v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x2(uint4x2 v) => new bool4x2 { c0 = (bool4)v.c0, c1 = (bool4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(Unity.Mathematics.bool4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x2(uint4x2 v) => new Unity.Mathematics.bool4x2 { c0 = (bool4)v.c0, c1 = (bool4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(Unity.Mathematics.int4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x2(uint4x2 v) => new int4x2 { c0 = (int4)v.c0, c1 = (int4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(Unity.Mathematics.float4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x2(uint4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(Unity.Mathematics.half v) => (uint4x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(Unity.Mathematics.double4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x2(uint4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x2(uint v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(bool v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(bool4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(sbyte v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(sbyte4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(short v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(short4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(int v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(int4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(long v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(long4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint4x2(byte v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x2(byte4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint4x2(ushort v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x2(ushort4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(ulong v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(ulong4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(float v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(float4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(half v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(double v) => new uint4x2 { c0 = (uint4)v, c1 = (uint4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(double4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(mask8x4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(mask16x4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(mask32x4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x2(mask64x4x2 v) => new uint4x2 { c0 = (uint4)v.c0, c1 = (uint4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x2(uint4x2 v) => new mask8x4x2 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x2(uint4x2 v) => new mask16x4x2 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(uint4x2 v) => new mask32x4x2 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x2(uint4x2 v) => new mask64x4x2 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ++ (uint4x2 val) => new uint4x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator -- (uint4x2 val) => new uint4x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs + (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs - (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs * (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs / (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs % (uint4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator + (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs + (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator - (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs - (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator * (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs * (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator / (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs / (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator % (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs % (float4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator + (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator - (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator * (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator / (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x2 operator % (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator + (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs + (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator - (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs - (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator * (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs * (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator / (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs / (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator % (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs % (double4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator + (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator - (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator * (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator / (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x2 operator % (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, byte4x2 rhs) => lhs + (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, byte4x2 rhs) => lhs - (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, byte4x2 rhs) => lhs * (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, byte4x2 rhs) => lhs / (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, byte4x2 rhs) => lhs % (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, ushort4x2 rhs) => lhs + (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, ushort4x2 rhs) => lhs - (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, ushort4x2 rhs) => lhs * (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, ushort4x2 rhs) => lhs / (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, ushort4x2 rhs) => lhs % (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (byte lhs, uint4x2 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (byte lhs, uint4x2 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (byte lhs, uint4x2 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (byte lhs, uint4x2 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (byte lhs, uint4x2 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (uint4x2 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator + (ushort lhs, uint4x2 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (uint4x2 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator - (ushort lhs, uint4x2 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (uint4x2 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator * (ushort lhs, uint4x2 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (uint4x2 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator / (ushort lhs, uint4x2 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (uint4x2 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator % (ushort lhs, uint4x2 rhs) => (uint)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator << (uint4x2 lhs, int rhs) => new uint4x2 { c0 = lhs.c0 << rhs, c1 = lhs.c1 << rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator >> (uint4x2 lhs, int rhs) => new uint4x2 { c0 = lhs.c0 >> rhs, c1 = lhs.c1 >> rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ~ (uint4x2 v) => new uint4x2 { c0 = ~v.c0, c1 = ~v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, uint rhs) => new uint4x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint lhs, uint4x2 rhs) => new uint4x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs & (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs | (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs ^ (uint4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, byte4x2 rhs) => lhs & (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, byte4x2 rhs) => lhs | (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, byte4x2 rhs) => lhs ^ (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, ushort4x2 rhs) => lhs & (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, ushort4x2 rhs) => lhs | (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, ushort4x2 rhs) => lhs ^ (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (byte lhs, uint4x2 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (byte lhs, uint4x2 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (byte lhs, uint4x2 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (uint4x2 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator & (ushort lhs, uint4x2 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (uint4x2 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator | (ushort lhs, uint4x2 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (uint4x2 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4x2 operator ^ (ushort lhs, uint4x2 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, uint rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, uint rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, uint rhs) => new mask32x4x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, uint rhs) => new mask32x4x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, uint rhs) => new mask32x4x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, uint rhs) => new mask32x4x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint lhs, uint4x2 rhs) => new mask32x4x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs == (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs != (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs < (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs > (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs <= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, Unity.Mathematics.uint4x2 rhs) => lhs >= (uint4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (Unity.Mathematics.uint4x2 lhs, uint4x2 rhs) => (uint4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs == (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs != (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs < (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs > (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs <= (float4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, Unity.Mathematics.float4x2 rhs) => lhs >= (float4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (Unity.Mathematics.float4x2 lhs, uint4x2 rhs) => (float4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs == (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs != (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs < (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs > (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs <= (double4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (uint4x2 lhs, Unity.Mathematics.double4x2 rhs) => lhs >= (double4x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator < (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator > (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator <= (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator >= (Unity.Mathematics.double4x2 lhs, uint4x2 rhs) => (double4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, byte4x2 rhs) => lhs == (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, byte4x2 rhs) => lhs != (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, byte4x2 rhs) => lhs < (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, byte4x2 rhs) => lhs > (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, byte4x2 rhs) => lhs <= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, byte4x2 rhs) => lhs >= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (byte4x2 lhs, uint4x2 rhs) => (uint4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, ushort4x2 rhs) => lhs == (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, ushort4x2 rhs) => lhs != (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, ushort4x2 rhs) => lhs < (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, ushort4x2 rhs) => lhs > (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, ushort4x2 rhs) => lhs <= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, ushort4x2 rhs) => lhs >= (uint4x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (ushort4x2 lhs, uint4x2 rhs) => (uint4x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (byte lhs, uint4x2 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (byte lhs, uint4x2 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (byte lhs, uint4x2 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (byte lhs, uint4x2 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (byte lhs, uint4x2 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (byte lhs, uint4x2 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (uint4x2 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (ushort lhs, uint4x2 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (uint4x2 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (ushort lhs, uint4x2 rhs) => (uint)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (uint4x2 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator < (ushort lhs, uint4x2 rhs) => (uint)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (uint4x2 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator > (ushort lhs, uint4x2 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (uint4x2 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator <= (ushort lhs, uint4x2 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (uint4x2 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator >= (ushort lhs, uint4x2 rhs) => (uint)lhs >= rhs;


        public ref uint4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (uint4x2* array = &this) { return ref ((uint4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is uint4x2 converted && Equals(converted)) || (o is Unity.Mathematics.uint4x2 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.uint4x2)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.uint4x2)this).ToString(format, formatProvider);
    }
}
