using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

#pragma warning disable CS0660
namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public ref struct mask32x4x4
    {
        public mask32x4 c0;
        public mask32x4 c1;
        public mask32x4 c2;
        public mask32x4 c3;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(mask32x4 c0, mask32x4 c1, mask32x4 c2, mask32x4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(bool m00, bool m01, bool m02, bool m03,
                          bool m10, bool m11, bool m12, bool m13,
                          bool m20, bool m21, bool m22, bool m23,
                          bool m30, bool m31, bool m32, bool m33)
        {
            this.c0 = new mask32x4(m00, m10, m20, m30);
            this.c1 = new mask32x4(m01, m11, m21, m31);
            this.c2 = new mask32x4(m02, m12, m22, m32);
            this.c3 = new mask32x4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(bool v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(bool4x4 v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(mask8x4x4 v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(mask16x4x4 v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(mask32x4x4 v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(mask64x4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(byte v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(byte4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(sbyte v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(sbyte4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(ushort v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(ushort4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(short v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(short4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(uint v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(uint4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(int v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(int4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(ulong v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(ulong4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(long v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(long4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(UInt128 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Int128 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(quarter v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(half v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(float v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(float4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(double v)
        {
            this = (mask32x4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(double4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(quadruple v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Unity.Mathematics.int4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Unity.Mathematics.half v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Unity.Mathematics.float4x4 v)
        {
            this = (mask32x4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x4(Unity.Mathematics.double4x4 v)
        {
            this = (mask32x4x4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x4(mask64x4x4 v) => new mask32x4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask64x4x4(mask32x4x4 v) => new mask64x4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x4(Unity.Mathematics.bool4x4 v) => new mask32x4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool4x4(mask32x4x4 v) => new Unity.Mathematics.bool4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x4(bool4x4 v) => new mask32x4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x4(mask32x4x4 v) => new bool4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x4(bool v) => new mask32x4x4 { c0 = v, c1 = v, c2 = v, c3 = v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(byte v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(ushort v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(uint v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(ulong v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(UInt128 v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(sbyte v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(short v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(int v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(long v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(Int128 v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(quarter v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(half v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(float v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(double v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(quadruple v) => new mask32x4x4 { c0 = (mask32x4)v, c1 = (mask32x4)v, c2 = (mask32x4)v, c3 = (mask32x4)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(Unity.Mathematics.half v) => (mask32x4x4)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(Unity.Mathematics.float4x4 v) => (mask32x4x4)(float4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(Unity.Mathematics.double4x4 v) => (mask32x4x4)(double4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(Unity.Mathematics.uint4x4 v) => (mask32x4x4)(uint4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(Unity.Mathematics.int4x4 v) => (mask32x4x4)(int4x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4x4(mask32x4x4 v) => (float4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4x4(mask32x4x4 v) => (double4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x4(mask32x4x4 v) => (uint4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x4(mask32x4x4 v) => (int4x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ! (mask32x4x4 val) => new mask32x4x4 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2, c3 = !val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (mask32x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (mask32x4x4 lhs, bool rhs) => new mask32x4x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (bool lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (mask32x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (mask32x4x4 lhs, bool rhs) => new mask32x4x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (bool lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (mask32x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (mask32x4x4 lhs, bool rhs) => new mask32x4x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (bool lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator & (mask32x4x4 lhs, mask64x4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator | (mask32x4x4 lhs, mask64x4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator ^ (mask32x4x4 lhs, mask64x4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator & (mask64x4x4 lhs, mask32x4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator | (mask64x4x4 lhs, mask32x4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator ^ (mask64x4x4 lhs, mask32x4x4 rhs) => new mask64x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (mask32x4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (mask32x4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (mask32x4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (Unity.Mathematics.bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (Unity.Mathematics.bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (Unity.Mathematics.bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (mask32x4x4 lhs, bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (mask32x4x4 lhs, bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (mask32x4x4 lhs, bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator & (bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator | (bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator ^ (bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (mask32x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (mask32x4x4 lhs, bool rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (bool lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (mask32x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (mask32x4x4 lhs, bool rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (bool lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (mask32x4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (mask32x4x4 lhs, Unity.Mathematics.bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (mask32x4x4 lhs, bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (mask32x4x4 lhs, bool4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (bool4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (mask32x4x4 lhs, mask64x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (mask32x4x4 lhs, mask64x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (mask64x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (mask64x4x4 lhs, mask32x4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        public ref mask32x4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (mask32x4x4* array = &this) { return ref ((mask32x4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask8x4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask16x4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask32x4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask64x4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool4x4)this).ToString();
    }
}
#pragma warning restore CS0660
