using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

#pragma warning disable CS0660
namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public ref struct mask8x3x3
    {
        public mask8x3 c0;
        public mask8x3 c1;
        public mask8x3 c2;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(mask8x3 c0, mask8x3 c1, mask8x3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(bool m00, bool m01, bool m02,
                         bool m10, bool m11, bool m12,
                         bool m20, bool m21, bool m22)
        {
            this.c0 = new mask8x3(m00, m10, m20);
            this.c1 = new mask8x3(m01, m11, m21);
            this.c2 = new mask8x3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(bool v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(bool3x3 v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(mask8x3x3 v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(mask16x3x3 v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(mask32x3x3 v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(mask64x3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(byte v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(byte3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(sbyte v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(sbyte3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(ushort v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(ushort3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(short v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(short3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(uint v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(uint3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(int v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(int3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(ulong v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(ulong3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(long v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(long3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(UInt128 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Int128 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(quarter v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(half v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(float v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(float3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(double v)
        {
            this = (mask8x3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(double3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(quadruple v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Unity.Mathematics.bool3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Unity.Mathematics.uint3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Unity.Mathematics.int3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Unity.Mathematics.half v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Unity.Mathematics.float3x3 v)
        {
            this = (mask8x3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask8x3x3(Unity.Mathematics.double3x3 v)
        {
            this = (mask8x3x3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask8x3x3(mask16x3x3 v) => new mask8x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask16x3x3(mask8x3x3 v) => new mask16x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask8x3x3(mask32x3x3 v) => new mask8x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x3x3(mask8x3x3 v) => new mask32x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask8x3x3(mask64x3x3 v) => new mask8x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask64x3x3(mask8x3x3 v) => new mask64x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask8x3x3(Unity.Mathematics.bool3x3 v) => new mask8x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool3x3(mask8x3x3 v) => new Unity.Mathematics.bool3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask8x3x3(bool3x3 v) => new mask8x3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x3(mask8x3x3 v) => new bool3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask8x3x3(bool v) => new mask8x3x3 { c0 = v, c1 = v, c2 = v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(byte v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(ushort v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(uint v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(ulong v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(UInt128 v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(sbyte v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(short v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(int v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(long v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(Int128 v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(quarter v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(half v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(float v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(double v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(quadruple v) => new mask8x3x3 { c0 = (mask8x3)v, c1 = (mask8x3)v, c2 = (mask8x3)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(Unity.Mathematics.half v) => (mask8x3x3)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(Unity.Mathematics.float3x3 v) => (mask8x3x3)(float3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(Unity.Mathematics.double3x3 v) => (mask8x3x3)(double3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(Unity.Mathematics.uint3x3 v) => (mask8x3x3)(uint3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3x3(Unity.Mathematics.int3x3 v) => (mask8x3x3)(int3x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3x3(mask8x3x3 v) => (float3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double3x3(mask8x3x3 v) => (double3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x3(mask8x3x3 v) => (uint3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x3(mask8x3x3 v) => (int3x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ! (mask8x3x3 val) => new mask8x3x3 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (mask8x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (mask8x3x3 lhs, bool rhs) => new mask8x3x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (bool lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (mask8x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (mask8x3x3 lhs, bool rhs) => new mask8x3x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (bool lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (mask8x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (mask8x3x3 lhs, bool rhs) => new mask8x3x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (bool lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator & (mask8x3x3 lhs, mask16x3x3 rhs) => new mask16x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator | (mask8x3x3 lhs, mask16x3x3 rhs) => new mask16x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator ^ (mask8x3x3 lhs, mask16x3x3 rhs) => new mask16x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator & (mask16x3x3 lhs, mask8x3x3 rhs) => new mask16x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator | (mask16x3x3 lhs, mask8x3x3 rhs) => new mask16x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator ^ (mask16x3x3 lhs, mask8x3x3 rhs) => new mask16x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator & (mask8x3x3 lhs, mask32x3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator | (mask8x3x3 lhs, mask32x3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator ^ (mask8x3x3 lhs, mask32x3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator & (mask32x3x3 lhs, mask8x3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator | (mask32x3x3 lhs, mask8x3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator ^ (mask32x3x3 lhs, mask8x3x3 rhs) => new mask32x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator & (mask8x3x3 lhs, mask64x3x3 rhs) => new mask64x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator | (mask8x3x3 lhs, mask64x3x3 rhs) => new mask64x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator ^ (mask8x3x3 lhs, mask64x3x3 rhs) => new mask64x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator & (mask64x3x3 lhs, mask8x3x3 rhs) => new mask64x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator | (mask64x3x3 lhs, mask8x3x3 rhs) => new mask64x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator ^ (mask64x3x3 lhs, mask8x3x3 rhs) => new mask64x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (mask8x3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (mask8x3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (mask8x3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (Unity.Mathematics.bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (Unity.Mathematics.bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (Unity.Mathematics.bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (mask8x3x3 lhs, bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (mask8x3x3 lhs, bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (mask8x3x3 lhs, bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (mask8x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (mask8x3x3 lhs, bool rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (bool lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (mask8x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (mask8x3x3 lhs, bool rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (bool lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (mask8x3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (mask8x3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (Unity.Mathematics.bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (Unity.Mathematics.bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (mask8x3x3 lhs, bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (mask8x3x3 lhs, bool3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (bool3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator == (mask8x3x3 lhs, mask16x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator != (mask8x3x3 lhs, mask16x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator == (mask16x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3x3 operator != (mask16x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (mask8x3x3 lhs, mask32x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (mask8x3x3 lhs, mask32x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator == (mask32x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3x3 operator != (mask32x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator == (mask8x3x3 lhs, mask64x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator != (mask8x3x3 lhs, mask64x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator == (mask64x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3x3 operator != (mask64x3x3 lhs, mask8x3x3 rhs) => new mask8x3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        public ref mask8x3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (mask8x3x3* array = &this) { return ref ((mask8x3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask8x3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask16x3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask32x3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask64x3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool3x3)this).ToString();
    }
}
#pragma warning restore CS0660
