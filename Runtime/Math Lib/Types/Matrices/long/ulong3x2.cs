using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct ulong3x2 : IEquatable<ulong3x2>, IFormattable
    {
        public ulong3 c0;
        public ulong3 c1;

        public static ulong3x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(ulong3 c0, ulong3 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(ulong m00, ulong m01,
                        ulong m10, ulong m11,
                        ulong m20, ulong m21)
        {
            this.c0 = new ulong3(m00, m10, m20);
            this.c1 = new ulong3(m01, m11, m21);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(bool v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(bool3x2 v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(mask8x3x2 v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(mask16x3x2 v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(mask32x3x2 v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(mask64x3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(byte v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(byte3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(sbyte v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(sbyte3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(ushort v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(ushort3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(short v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(short3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(uint v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(uint3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(int v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(int3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(long v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(long3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(ulong v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(ulong3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(UInt128 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Int128 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(quarter v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(half v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(float v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(float3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(double v)
        {
            this = (ulong3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(double3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(quadruple v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Unity.Mathematics.bool3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Unity.Mathematics.uint3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Unity.Mathematics.int3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Unity.Mathematics.half v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Unity.Mathematics.float3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x2(Unity.Mathematics.double3x2 v)
        {
            this = (ulong3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(ulong3x2 v) => new bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(Unity.Mathematics.bool3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x2(ulong3x2 v) => new Unity.Mathematics.bool3x2 { c0 = (bool3)v.c0, c1 = (bool3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(Unity.Mathematics.int3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x2(ulong3x2 v) => new int3x2 { c0 = (int3)v.c0, c1 = (int3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(Unity.Mathematics.uint3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x2(ulong3x2 v) => new uint3x2 { c0 = (uint3)v.c0, c1 = (uint3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(Unity.Mathematics.half v) => (ulong3x2)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(Unity.Mathematics.float3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x2(ulong3x2 v) => new float3x2 { c0 = (float3)v.c0, c1 = (float3)v.c1 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(Unity.Mathematics.double3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x2(ulong3x2 v) => new double3x2 { c0 = (double3)v.c0, c1 = (double3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(ulong v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(bool v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(bool3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(sbyte v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(sbyte3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(short v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(short3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(int v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(int3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3x2(byte v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(byte3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3x2(ushort v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(ushort3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(uint v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(uint3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(long v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(long3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(half v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(float v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(float3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(double v) => new ulong3x2 { c0 = (ulong3)v, c1 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(double3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(mask8x3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(mask16x3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(mask32x3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(mask64x3x2 v) => new ulong3x2 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x2(ulong3x2 v) => new mask8x3x2 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x2(ulong3x2 v) => new mask16x3x2 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x2(ulong3x2 v) => new mask32x3x2 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x2(ulong3x2 v) => new mask64x3x2 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ++ (ulong3x2 val) => new ulong3x2 { c0 = val.c0 + 1, c1 = val.c1 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator -- (ulong3x2 val) => new ulong3x2 { c0 = val.c0 - 1, c1 = val.c1 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, byte3x2 rhs) => new ulong3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, byte3x2 rhs) => new ulong3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, byte3x2 rhs) => new ulong3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, byte3x2 rhs) => new ulong3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, byte3x2 rhs) => new ulong3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, ushort3x2 rhs) => new ulong3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, ushort3x2 rhs) => new ulong3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, ushort3x2 rhs) => new ulong3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, ushort3x2 rhs) => new ulong3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, ushort3x2 rhs) => new ulong3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => new ulong3x2 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs + (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs - (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs * (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs / (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs % (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator + (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator - (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator * (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator / (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x2 operator % (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs + (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs - (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs * (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs / (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs % (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator + (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator - (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator * (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator / (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x2 operator % (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, byte rhs) => new ulong3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (byte lhs, ulong3x2 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, byte rhs) => new ulong3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (byte lhs, ulong3x2 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, byte rhs) => new ulong3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (byte lhs, ulong3x2 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, byte rhs) => new ulong3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (byte lhs, ulong3x2 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, byte rhs) => new ulong3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (byte lhs, ulong3x2 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, ushort rhs) => new ulong3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ushort lhs, ulong3x2 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, ushort rhs) => new ulong3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ushort lhs, ulong3x2 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, ushort rhs) => new ulong3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ushort lhs, ulong3x2 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, ushort rhs) => new ulong3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ushort lhs, ulong3x2 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, ushort rhs) => new ulong3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ushort lhs, ulong3x2 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 lhs, uint rhs) => new ulong3x2 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (uint lhs, ulong3x2 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 lhs, uint rhs) => new ulong3x2 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (uint lhs, ulong3x2 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 lhs, uint rhs) => new ulong3x2 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (uint lhs, ulong3x2 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 lhs, uint rhs) => new ulong3x2 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (uint lhs, ulong3x2 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 lhs, uint rhs) => new ulong3x2 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (uint lhs, ulong3x2 rhs) => (ulong)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ~ (ulong3x2 val) => new ulong3x2 { c0 = ~val.c0, c1 = ~val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator << (ulong3x2 val, int n) => new ulong3x2 { c0 = val.c0 << n, c1 = val.c1 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator >> (ulong3x2 val, int n) => new ulong3x2 { c0 = val.c0 >> n, c1 = val.c1 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, ulong rhs) => new ulong3x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong lhs, ulong3x2 rhs) => new ulong3x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, byte3x2 rhs) => lhs & (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, byte3x2 rhs) => lhs | (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, byte3x2 rhs) => lhs ^ (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, ushort3x2 rhs) => lhs & (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, ushort3x2 rhs) => lhs | (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, ushort3x2 rhs) => lhs ^ (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, uint3x2 rhs) => lhs & (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, uint3x2 rhs) => lhs | (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, uint3x2 rhs) => lhs ^ (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs & (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs | (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs ^ (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, byte rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (byte lhs, ulong3x2 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, byte rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (byte lhs, ulong3x2 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, byte rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (byte lhs, ulong3x2 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, ushort rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ushort lhs, ulong3x2 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, ushort rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ushort lhs, ulong3x2 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, ushort rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ushort lhs, ulong3x2 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 lhs, uint rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (uint lhs, ulong3x2 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 lhs, uint rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (uint lhs, ulong3x2 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 lhs, uint rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (uint lhs, ulong3x2 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, ulong rhs) => new mask64x3x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, ulong rhs) => new mask64x3x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, ulong rhs) => new mask64x3x2 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, ulong rhs) => new mask64x3x2 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, ulong rhs) => new mask64x3x2 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, ulong rhs) => new mask64x3x2 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong lhs, ulong3x2 rhs) => new mask64x3x2 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, byte3x2 rhs) => lhs == (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, byte3x2 rhs) => lhs != (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, byte3x2 rhs) => lhs < (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, byte3x2 rhs) => lhs > (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, byte3x2 rhs) => lhs <= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, byte3x2 rhs) => lhs >= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (byte3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, ushort3x2 rhs) => lhs == (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, ushort3x2 rhs) => lhs != (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, ushort3x2 rhs) => lhs < (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, ushort3x2 rhs) => lhs > (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, ushort3x2 rhs) => lhs <= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, ushort3x2 rhs) => lhs >= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ushort3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, uint3x2 rhs) => lhs == (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, uint3x2 rhs) => lhs != (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, uint3x2 rhs) => lhs < (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, uint3x2 rhs) => lhs > (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, uint3x2 rhs) => lhs <= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, uint3x2 rhs) => lhs >= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs == (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs != (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs < (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs > (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs <= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, Unity.Mathematics.uint3x2 rhs) => lhs >= (ulong3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.uint3x2 lhs, ulong3x2 rhs) => (ulong3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs == (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs != (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs < (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs > (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs <= (float3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (ulong3x2 lhs, Unity.Mathematics.float3x2 rhs) => lhs >= (float3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator == (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator != (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator < (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator > (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator <= (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x2 operator >= (Unity.Mathematics.float3x2 lhs, ulong3x2 rhs) => (float3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs == (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs != (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs < (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs > (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs <= (double3x2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, Unity.Mathematics.double3x2 rhs) => lhs >= (double3x2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (Unity.Mathematics.double3x2 lhs, ulong3x2 rhs) => (double3x2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, byte rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (byte lhs, ulong3x2 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, byte rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (byte lhs, ulong3x2 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, byte rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (byte lhs, ulong3x2 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, byte rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (byte lhs, ulong3x2 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, byte rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (byte lhs, ulong3x2 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, byte rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (byte lhs, ulong3x2 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, ushort rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ushort lhs, ulong3x2 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, ushort rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ushort lhs, ulong3x2 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, ushort rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ushort lhs, ulong3x2 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, ushort rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ushort lhs, ulong3x2 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, ushort rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ushort lhs, ulong3x2 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, ushort rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ushort lhs, ulong3x2 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (ulong3x2 lhs, uint rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator == (uint lhs, ulong3x2 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (ulong3x2 lhs, uint rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator != (uint lhs, ulong3x2 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (ulong3x2 lhs, uint rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator < (uint lhs, ulong3x2 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (ulong3x2 lhs, uint rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator > (uint lhs, ulong3x2 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (ulong3x2 lhs, uint rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator <= (uint lhs, ulong3x2 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (ulong3x2 lhs, uint rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x2 operator >= (uint lhs, ulong3x2 rhs) => (ulong)lhs >= rhs;


        public ref ulong3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (ulong3x2* array = &this) { return ref ((ulong3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ulong3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        public override readonly bool Equals(object obj) => obj is ulong3x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"ulong3x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong3x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)})";
    }
}