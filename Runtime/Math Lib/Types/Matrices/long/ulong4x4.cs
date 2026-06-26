using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct ulong4x4 : IEquatable<ulong4x4>, IFormattable
    {
        public ulong4 c0;
        public ulong4 c1;
        public ulong4 c2;
        public ulong4 c3;

        public static ulong4x4 identity => new ulong4x4(1, 0, 0, 0,   0, 1, 0, 0,   0, 0, 1, 0,   0, 0, 0, 1);
        public static ulong4x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(ulong4 c0, ulong4 c1, ulong4 c2, ulong4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(ulong m00, ulong m01, ulong m02, ulong m03,
                        ulong m10, ulong m11, ulong m12, ulong m13,
                        ulong m20, ulong m21, ulong m22, ulong m23,
                        ulong m30, ulong m31, ulong m32, ulong m33)
        {
            this.c0 = new ulong4(m00, m10, m20, m30);
            this.c1 = new ulong4(m01, m11, m21, m31);
            this.c2 = new ulong4(m02, m12, m22, m32);
            this.c3 = new ulong4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(bool v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(bool4x4 v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(mask8x4x4 v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(mask16x4x4 v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(mask32x4x4 v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(mask64x4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(byte v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(byte4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(sbyte v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(sbyte4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(ushort v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(ushort4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(short v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(short4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(uint v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(uint4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(int v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(int4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(long v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(long4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(ulong v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(ulong4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(UInt128 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Int128 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(quarter v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(half v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(float v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(float4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(double v)
        {
            this = (ulong4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(double4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(quadruple v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Unity.Mathematics.int4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Unity.Mathematics.half v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Unity.Mathematics.float4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x4(Unity.Mathematics.double4x4 v)
        {
            this = (ulong4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(ulong4x4 v) => new bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(Unity.Mathematics.bool4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x4(ulong4x4 v) => new Unity.Mathematics.bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(Unity.Mathematics.int4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x4(ulong4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x4(Unity.Mathematics.uint4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x4(ulong4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(Unity.Mathematics.half v) => (ulong4x4)(half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(Unity.Mathematics.float4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x4(ulong4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(Unity.Mathematics.double4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x4(ulong4x4 v) => new double4x4 { c0 = (double4)v.c0, c1 = (double4)v.c1, c2 = (double4)v.c2, c3 = (double4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x4(ulong v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(bool v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(bool4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(sbyte v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(sbyte4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(short v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(short4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(int v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(int4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong4x4(byte v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x4(byte4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong4x4(ushort v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x4(ushort4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x4(uint v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x4(uint4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(long v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(long4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(half v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(float v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(float4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(double v) => new ulong4x4 { c0 = (ulong4)v, c1 = (ulong4)v, c2 = (ulong4)v, c3 = (ulong4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(double4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(mask8x4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(mask16x4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(mask32x4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x4(mask64x4x4 v) => new ulong4x4 { c0 = (ulong4)v.c0, c1 = (ulong4)v.c1, c2 = (ulong4)v.c2, c3 = (ulong4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x4(ulong4x4 v) => new mask8x4x4 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2, c3 = (mask8x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x4(ulong4x4 v) => new mask16x4x4 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2, c3 = (mask16x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(ulong4x4 v) => new mask32x4x4 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2, c3 = (mask32x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x4(ulong4x4 v) => new mask64x4x4 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2, c3 = (mask64x4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ++ (ulong4x4 val) => new ulong4x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator -- (ulong4x4 val) => new ulong4x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, byte4x4 rhs) => new ulong4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, byte4x4 rhs) => new ulong4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, byte4x4 rhs) => new ulong4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, byte4x4 rhs) => new ulong4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, byte4x4 rhs) => new ulong4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, ushort4x4 rhs) => new ulong4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, ushort4x4 rhs) => new ulong4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, ushort4x4 rhs) => new ulong4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, ushort4x4 rhs) => new ulong4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, ushort4x4 rhs) => new ulong4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => new ulong4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs % (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs + (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs - (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs * (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs / (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs % (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, byte rhs) => new ulong4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (byte lhs, ulong4x4 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, byte rhs) => new ulong4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (byte lhs, ulong4x4 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, byte rhs) => new ulong4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (byte lhs, ulong4x4 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, byte rhs) => new ulong4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (byte lhs, ulong4x4 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, byte rhs) => new ulong4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (byte lhs, ulong4x4 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, ushort rhs) => new ulong4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ushort lhs, ulong4x4 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, ushort rhs) => new ulong4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ushort lhs, ulong4x4 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, ushort rhs) => new ulong4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ushort lhs, ulong4x4 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, ushort rhs) => new ulong4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ushort lhs, ulong4x4 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, ushort rhs) => new ulong4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ushort lhs, ulong4x4 rhs) => (ulong)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (ulong4x4 lhs, uint rhs) => new ulong4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator + (uint lhs, ulong4x4 rhs) => (ulong)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (ulong4x4 lhs, uint rhs) => new ulong4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator - (uint lhs, ulong4x4 rhs) => (ulong)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (ulong4x4 lhs, uint rhs) => new ulong4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator * (uint lhs, ulong4x4 rhs) => (ulong)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (ulong4x4 lhs, uint rhs) => new ulong4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator / (uint lhs, ulong4x4 rhs) => (ulong)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (ulong4x4 lhs, uint rhs) => new ulong4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator % (uint lhs, ulong4x4 rhs) => (ulong)lhs % rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ~ (ulong4x4 val) => new ulong4x4 { c0 = ~val.c0, c1 = ~val.c1, c2 = ~val.c2, c3 = ~val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator << (ulong4x4 val, int n) => new ulong4x4 { c0 = val.c0 << n, c1 = val.c1 << n, c2 = val.c2 << n, c3 = val.c3 << n };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator >> (ulong4x4 val, int n) => new ulong4x4 { c0 = val.c0 >> n, c1 = val.c1 >> n, c2 = val.c2 >> n, c3 = val.c3 >> n };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, ulong rhs) => new ulong4x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong lhs, ulong4x4 rhs) => new ulong4x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, byte4x4 rhs) => lhs & (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, byte4x4 rhs) => lhs | (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, byte4x4 rhs) => lhs ^ (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, ushort4x4 rhs) => lhs & (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, ushort4x4 rhs) => lhs | (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, ushort4x4 rhs) => lhs ^ (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, uint4x4 rhs) => lhs & (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, uint4x4 rhs) => lhs | (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, uint4x4 rhs) => lhs ^ (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs & (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs | (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs ^ (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, byte rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (byte lhs, ulong4x4 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, byte rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (byte lhs, ulong4x4 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, byte rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (byte lhs, ulong4x4 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, ushort rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ushort lhs, ulong4x4 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, ushort rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ushort lhs, ulong4x4 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, ushort rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ushort lhs, ulong4x4 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (ulong4x4 lhs, uint rhs) => lhs & (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator & (uint lhs, ulong4x4 rhs) => (ulong)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (ulong4x4 lhs, uint rhs) => lhs | (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator | (uint lhs, ulong4x4 rhs) => (ulong)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (ulong4x4 lhs, uint rhs) => lhs ^ (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x4 operator ^ (uint lhs, ulong4x4 rhs) => (ulong)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, ulong rhs) => new mask64x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, ulong rhs) => new mask64x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, ulong rhs) => new mask64x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, ulong rhs) => new mask64x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, ulong rhs) => new mask64x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, ulong rhs) => new mask64x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong lhs, ulong4x4 rhs) => new mask64x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, byte4x4 rhs) => lhs == (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, byte4x4 rhs) => lhs != (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, byte4x4 rhs) => lhs < (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, byte4x4 rhs) => lhs > (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, byte4x4 rhs) => lhs <= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, byte4x4 rhs) => lhs >= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (byte4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, ushort4x4 rhs) => lhs == (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, ushort4x4 rhs) => lhs != (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, ushort4x4 rhs) => lhs < (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, ushort4x4 rhs) => lhs > (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, ushort4x4 rhs) => lhs <= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, ushort4x4 rhs) => lhs >= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ushort4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, uint4x4 rhs) => lhs == (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, uint4x4 rhs) => lhs != (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, uint4x4 rhs) => lhs < (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, uint4x4 rhs) => lhs > (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, uint4x4 rhs) => lhs <= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, uint4x4 rhs) => lhs >= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs == (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs != (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs < (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs > (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs <= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs >= (ulong4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.uint4x4 lhs, ulong4x4 rhs) => (ulong4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ulong4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs >= (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.float4x4 lhs, ulong4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs >= (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.double4x4 lhs, ulong4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, byte rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (byte lhs, ulong4x4 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, byte rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (byte lhs, ulong4x4 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, byte rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (byte lhs, ulong4x4 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, byte rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (byte lhs, ulong4x4 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, byte rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (byte lhs, ulong4x4 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, byte rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (byte lhs, ulong4x4 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, ushort rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ushort lhs, ulong4x4 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, ushort rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ushort lhs, ulong4x4 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, ushort rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ushort lhs, ulong4x4 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, ushort rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ushort lhs, ulong4x4 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, ushort rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ushort lhs, ulong4x4 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, ushort rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ushort lhs, ulong4x4 rhs) => (ulong)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (ulong4x4 lhs, uint rhs) => lhs == (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (uint lhs, ulong4x4 rhs) => (ulong)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (ulong4x4 lhs, uint rhs) => lhs != (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (uint lhs, ulong4x4 rhs) => (ulong)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (ulong4x4 lhs, uint rhs) => lhs < (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (uint lhs, ulong4x4 rhs) => (ulong)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (ulong4x4 lhs, uint rhs) => lhs > (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (uint lhs, ulong4x4 rhs) => (ulong)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (ulong4x4 lhs, uint rhs) => lhs <= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (uint lhs, ulong4x4 rhs) => (ulong)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (ulong4x4 lhs, uint rhs) => lhs >= (ulong)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (uint lhs, ulong4x4 rhs) => (ulong)lhs >= rhs;


        public ref ulong4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (ulong4x4* array = &this) { return ref ((ulong4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ulong4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => o is ulong4x4 converted && Equals(converted); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override readonly string ToString() => $"ulong4x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y},  {c0.z}, {c1.z}, {c2.z}, {c3.z},  {c0.w}, {c1.w}, {c2.w}, {c3.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong4x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)}, {c3.w.ToString(format, formatProvider)})";
    }
}
