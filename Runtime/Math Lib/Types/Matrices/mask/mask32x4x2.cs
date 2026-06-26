using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

#pragma warning disable CS0660
namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public ref struct mask32x4x2
    {
        public mask32x4 c0;
        public mask32x4 c1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(mask32x4 c0, mask32x4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(bool m00, bool m01,
                          bool m10, bool m11,
                          bool m20, bool m21,
                          bool m30, bool m31)
        {
            this.c0 = new mask32x4(m00, m10, m20, m30);
            this.c1 = new mask32x4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(bool v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(bool4x2 v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(mask8x4x2 v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(mask16x4x2 v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(mask32x4x2 v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(mask64x4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(byte v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(byte4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(sbyte v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(sbyte4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(ushort v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(ushort4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(short v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(short4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(uint v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(uint4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(int v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(int4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(ulong v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(ulong4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(long v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(long4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(UInt128 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Int128 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(quarter v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(half v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(float v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(float4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(double v)
        {
            this = (mask32x4x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(double4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(quadruple v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Unity.Mathematics.bool4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Unity.Mathematics.uint4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Unity.Mathematics.int4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Unity.Mathematics.half v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Unity.Mathematics.float4x2 v)
        {
            this = (mask32x4x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask32x4x2(Unity.Mathematics.double4x2 v)
        {
            this = (mask32x4x2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x2(mask64x4x2 v) => new mask32x4x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask64x4x2(mask32x4x2 v) => new mask64x4x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x2(Unity.Mathematics.bool4x2 v) => new mask32x4x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool4x2(mask32x4x2 v) => new Unity.Mathematics.bool4x2 { c0 = v.c0, c1 = v.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x2(bool4x2 v) => new mask32x4x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4x2(mask32x4x2 v) => new bool4x2 { c0 = v.c0, c1 = v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x4x2(bool v) => new mask32x4x2 { c0 = v, c1 = v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(byte v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(ushort v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(uint v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(ulong v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(UInt128 v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(sbyte v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(short v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(int v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(long v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(Int128 v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(quarter v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(half v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(float v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(double v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(quadruple v) => new mask32x4x2 { c0 = (mask32x4)v, c1 = (mask32x4)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(Unity.Mathematics.half v) => (mask32x4x2)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(Unity.Mathematics.float4x2 v) => (mask32x4x2)(float4x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(Unity.Mathematics.double4x2 v) => (mask32x4x2)(double4x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(Unity.Mathematics.uint4x2 v) => (mask32x4x2)(uint4x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x2(Unity.Mathematics.int4x2 v) => (mask32x4x2)(int4x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4x2(mask32x4x2 v) => (float4x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4x2(mask32x4x2 v) => (double4x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x2(mask32x4x2 v) => (uint4x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x2(mask32x4x2 v) => (int4x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ! (mask32x4x2 val) => new mask32x4x2 { c0 = !val.c0, c1 = !val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (mask32x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (mask32x4x2 lhs, bool rhs) => new mask32x4x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (bool lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (mask32x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (mask32x4x2 lhs, bool rhs) => new mask32x4x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (bool lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (mask32x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (mask32x4x2 lhs, bool rhs) => new mask32x4x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (bool lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator & (mask32x4x2 lhs, mask64x4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator | (mask32x4x2 lhs, mask64x4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator ^ (mask32x4x2 lhs, mask64x4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator & (mask64x4x2 lhs, mask32x4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator | (mask64x4x2 lhs, mask32x4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator ^ (mask64x4x2 lhs, mask32x4x2 rhs) => new mask64x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (mask32x4x2 lhs, Unity.Mathematics.bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (mask32x4x2 lhs, Unity.Mathematics.bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (mask32x4x2 lhs, Unity.Mathematics.bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (Unity.Mathematics.bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (Unity.Mathematics.bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (Unity.Mathematics.bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (mask32x4x2 lhs, bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (mask32x4x2 lhs, bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (mask32x4x2 lhs, bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator & (bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator | (bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator ^ (bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (mask32x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (mask32x4x2 lhs, bool rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (bool lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (mask32x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (mask32x4x2 lhs, bool rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (bool lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (mask32x4x2 lhs, Unity.Mathematics.bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (mask32x4x2 lhs, Unity.Mathematics.bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (Unity.Mathematics.bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (Unity.Mathematics.bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (mask32x4x2 lhs, bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (mask32x4x2 lhs, bool4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator == (bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x2 operator != (bool4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (mask32x4x2 lhs, mask64x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (mask32x4x2 lhs, mask64x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator == (mask64x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x2 operator != (mask64x4x2 lhs, mask32x4x2 rhs) => new mask32x4x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        public ref mask32x4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (mask32x4x2* array = &this) { return ref ((mask32x4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask8x4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask16x4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask32x4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask64x4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool4x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool4x2)this).ToString();
    }
}
#pragma warning restore CS0660
