using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct ulong3x4 : IEquatable<ulong3x4>, IFormattable
    {
        public ulong3 c0;
        public ulong3 c1;
        public ulong3 c2;
        public ulong3 c3;

        public static ulong3x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(ulong3 c0, ulong3 c1, ulong3 c2, ulong3 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(ulong m00, ulong m01, ulong m02, ulong m03,
                        ulong m10, ulong m11, ulong m12, ulong m13,
                        ulong m20, ulong m21, ulong m22, ulong m23)
        {
            this.c0 = new ulong3(m00, m10, m20);
            this.c1 = new ulong3(m01, m11, m21);
            this.c2 = new ulong3(m02, m12, m22);
            this.c3 = new ulong3(m03, m13, m23);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(bool v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(bool3x4 v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(mask8x3x4 v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(mask16x3x4 v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(mask32x3x4 v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(mask64x3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(byte v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(byte3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(sbyte v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(sbyte3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(ushort v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(ushort3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(short v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(short3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(uint v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(uint3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(int v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(int3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(long v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(long3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(ulong v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(ulong3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(UInt128 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Int128 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(quarter v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(half v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(float v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(float3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(double v)
        {
            this = (ulong3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(double3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(quadruple v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Unity.Mathematics.bool3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Unity.Mathematics.uint3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Unity.Mathematics.int3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Unity.Mathematics.half v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Unity.Mathematics.float3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3x4(Unity.Mathematics.double3x4 v)
        {
            this = (ulong3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(ulong3x4 v) => new bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(Unity.Mathematics.bool3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3x4(ulong3x4 v) => new Unity.Mathematics.bool3x4 { c0 = (bool3)v.c0, c1 = (bool3)v.c1, c2 = (bool3)v.c2, c3 = (bool3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(Unity.Mathematics.int3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x4(ulong3x4 v) => new int3x4 { c0 = (int3)v.c0, c1 = (int3)v.c1, c2 = (int3)v.c2, c3 = (int3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x4(Unity.Mathematics.uint3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x4(ulong3x4 v) => new uint3x4 { c0 = (uint3)v.c0, c1 = (uint3)v.c1, c2 = (uint3)v.c2, c3 = (uint3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(Unity.Mathematics.half v) => (ulong3x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(Unity.Mathematics.float3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3x4(ulong3x4 v) => new float3x4 { c0 = (float3)v.c0, c1 = (float3)v.c1, c2 = (float3)v.c2, c3 = (float3)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(Unity.Mathematics.double3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3x4(ulong3x4 v) => new double3x4 { c0 = (double3)v.c0, c1 = (double3)v.c1, c2 = (double3)v.c2, c3 = (double3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x4(ulong v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(bool v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(bool3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(sbyte v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(sbyte3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(short v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(short3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(int v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(int3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3x4(byte v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x4(byte3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong3x4(ushort v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x4(ushort3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x4(uint v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x4(uint3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(long v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(long3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(half v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(float v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(float3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(double v) => new ulong3x4 { c0 = (ulong3)v, c1 = (ulong3)v, c2 = (ulong3)v, c3 = (ulong3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(double3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(mask8x3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(mask16x3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(mask32x3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(mask64x3x4 v) => new ulong3x4 { c0 = (ulong3)v.c0, c1 = (ulong3)v.c1, c2 = (ulong3)v.c2, c3 = (ulong3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x4(ulong3x4 v) => new mask8x3x4 { c0 = (mask8x3)v.c0, c1 = (mask8x3)v.c1, c2 = (mask8x3)v.c2, c3 = (mask8x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3x4(ulong3x4 v) => new mask16x3x4 { c0 = (mask16x3)v.c0, c1 = (mask16x3)v.c1, c2 = (mask16x3)v.c2, c3 = (mask16x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3x4(ulong3x4 v) => new mask32x3x4 { c0 = (mask32x3)v.c0, c1 = (mask32x3)v.c1, c2 = (mask32x3)v.c2, c3 = (mask32x3)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3x4(ulong3x4 v) => new mask64x3x4 { c0 = (mask64x3)v.c0, c1 = (mask64x3)v.c1, c2 = (mask64x3)v.c2, c3 = (mask64x3)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ++ (ulong3x4 val) => new ulong3x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator -- (ulong3x4 val) => new ulong3x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, byte3x4 rhs) => new ulong3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, byte3x4 rhs) => new ulong3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, byte3x4 rhs) => new ulong3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, byte3x4 rhs) => new ulong3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, byte3x4 rhs) => new ulong3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, ushort3x4 rhs) => new ulong3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, ushort3x4 rhs) => new ulong3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, ushort3x4 rhs) => new ulong3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, ushort3x4 rhs) => new ulong3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, ushort3x4 rhs) => new ulong3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => new ulong3x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator + (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs + (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator - (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs - (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator * (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs * (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator / (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs / (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator % (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs % (float3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator + (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator - (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator * (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator / (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 operator % (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs + (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs - (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs * (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs / (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs % (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator + (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator - (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator * (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator / (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3x4 operator % (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, byte rhs) => new ulong3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (byte lhs, ulong3x4 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, byte rhs) => new ulong3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (byte lhs, ulong3x4 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, byte rhs) => new ulong3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (byte lhs, ulong3x4 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, byte rhs) => new ulong3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (byte lhs, ulong3x4 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, byte rhs) => new ulong3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (byte lhs, ulong3x4 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, ushort rhs) => new ulong3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ushort lhs, ulong3x4 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, ushort rhs) => new ulong3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ushort lhs, ulong3x4 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, ushort rhs) => new ulong3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ushort lhs, ulong3x4 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, ushort rhs) => new ulong3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ushort lhs, ulong3x4 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, ushort rhs) => new ulong3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ushort lhs, ulong3x4 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (ulong3x4 lhs, uint rhs) => new ulong3x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator + (uint lhs, ulong3x4 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (ulong3x4 lhs, uint rhs) => new ulong3x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator - (uint lhs, ulong3x4 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (ulong3x4 lhs, uint rhs) => new ulong3x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator * (uint lhs, ulong3x4 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (ulong3x4 lhs, uint rhs) => new ulong3x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator / (uint lhs, ulong3x4 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (ulong3x4 lhs, uint rhs) => new ulong3x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator % (uint lhs, ulong3x4 rhs) => (ulong)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ~ (ulong3x4 val) => new ulong3x4 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2, c3 = ~val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator << (ulong3x4 val, int n) => new ulong3x4 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n, c3 = val.c3 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator >> (ulong3x4 val, int n) => new ulong3x4 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n, c3 = val.c3 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, ulong rhs) => new ulong3x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong lhs, ulong3x4 rhs) => new ulong3x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, byte3x4 rhs) => lhs & (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, byte3x4 rhs) => lhs | (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, byte3x4 rhs) => lhs ^ (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, ushort3x4 rhs) => lhs & (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, ushort3x4 rhs) => lhs | (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, ushort3x4 rhs) => lhs ^ (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, uint3x4 rhs) => lhs & (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, uint3x4 rhs) => lhs | (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, uint3x4 rhs) => lhs ^ (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs & (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs | (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs ^ (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, byte rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (byte lhs, ulong3x4 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, byte rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (byte lhs, ulong3x4 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, byte rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (byte lhs, ulong3x4 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, ushort rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ushort lhs, ulong3x4 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, ushort rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ushort lhs, ulong3x4 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, ushort rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ushort lhs, ulong3x4 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (ulong3x4 lhs, uint rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator & (uint lhs, ulong3x4 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (ulong3x4 lhs, uint rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator | (uint lhs, ulong3x4 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (ulong3x4 lhs, uint rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x4 operator ^ (uint lhs, ulong3x4 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, ulong rhs) => new mask64x3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, ulong rhs) => new mask64x3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, ulong rhs) => new mask64x3x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, ulong rhs) => new mask64x3x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, ulong rhs) => new mask64x3x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, ulong rhs) => new mask64x3x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong lhs, ulong3x4 rhs) => new mask64x3x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, byte3x4 rhs) => lhs == (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, byte3x4 rhs) => lhs != (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, byte3x4 rhs) => lhs < (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, byte3x4 rhs) => lhs > (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, byte3x4 rhs) => lhs <= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, byte3x4 rhs) => lhs >= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (byte3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, ushort3x4 rhs) => lhs == (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, ushort3x4 rhs) => lhs != (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, ushort3x4 rhs) => lhs < (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, ushort3x4 rhs) => lhs > (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, ushort3x4 rhs) => lhs <= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, ushort3x4 rhs) => lhs >= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ushort3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, uint3x4 rhs) => lhs == (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, uint3x4 rhs) => lhs != (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, uint3x4 rhs) => lhs < (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, uint3x4 rhs) => lhs > (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, uint3x4 rhs) => lhs <= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, uint3x4 rhs) => lhs >= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs == (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs != (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs < (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs > (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs <= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, Unity.Mathematics.uint3x4 rhs) => lhs >= (ulong3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.uint3x4 lhs, ulong3x4 rhs) => (ulong3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs == (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs != (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs < (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs > (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs <= (float3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (ulong3x4 lhs, Unity.Mathematics.float3x4 rhs) => lhs >= (float3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator == (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator != (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator < (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator > (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator <= (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x4 operator >= (Unity.Mathematics.float3x4 lhs, ulong3x4 rhs) => (float3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs == (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs != (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs < (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs > (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs <= (double3x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, Unity.Mathematics.double3x4 rhs) => lhs >= (double3x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (Unity.Mathematics.double3x4 lhs, ulong3x4 rhs) => (double3x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, byte rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (byte lhs, ulong3x4 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, byte rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (byte lhs, ulong3x4 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, byte rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (byte lhs, ulong3x4 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, byte rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (byte lhs, ulong3x4 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, byte rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (byte lhs, ulong3x4 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, byte rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (byte lhs, ulong3x4 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, ushort rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ushort lhs, ulong3x4 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, ushort rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ushort lhs, ulong3x4 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, ushort rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ushort lhs, ulong3x4 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, ushort rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ushort lhs, ulong3x4 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, ushort rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ushort lhs, ulong3x4 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, ushort rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ushort lhs, ulong3x4 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (ulong3x4 lhs, uint rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator == (uint lhs, ulong3x4 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (ulong3x4 lhs, uint rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator != (uint lhs, ulong3x4 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (ulong3x4 lhs, uint rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator < (uint lhs, ulong3x4 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (ulong3x4 lhs, uint rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator > (uint lhs, ulong3x4 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (ulong3x4 lhs, uint rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator <= (uint lhs, ulong3x4 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (ulong3x4 lhs, uint rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x4 operator >= (uint lhs, ulong3x4 rhs) => (ulong)lhs >= rhs;


        public ref ulong3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (ulong3x4* array = &this) { return ref ((ulong3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ulong3x4 other) => (math.all(this.c0 == other.c0 & this.c1 == other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override readonly bool Equals(object obj) => obj is ulong3x4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"ulong3x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y},  {c0.z}, {c1.z}, {c2.z}, {c3.z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong3x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.z.ToString(format, formatProvider)})";
    }
}