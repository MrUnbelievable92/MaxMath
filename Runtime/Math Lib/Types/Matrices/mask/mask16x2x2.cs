using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

#pragma warning disable CS0660
namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public ref struct mask16x2x2
    {
        public mask16x2 c0;
        public mask16x2 c1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(mask16x2 c0, mask16x2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(bool m00, bool m01,
                          bool m10, bool m11)
        {
            this.c0 = new mask16x2(m00, m10);
            this.c1 = new mask16x2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(bool v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(bool2x2 v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(mask8x2x2 v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(mask16x2x2 v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(mask32x2x2 v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(mask64x2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(byte v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(byte2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(sbyte v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(sbyte2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(ushort v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(ushort2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(short v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(short2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(uint v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(uint2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(int v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(int2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(ulong v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(ulong2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(long v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(long2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(UInt128 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Int128 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(quarter v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(half v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(float v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(float2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(double v)
        {
            this = (mask16x2x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(double2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(quadruple v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Unity.Mathematics.bool2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Unity.Mathematics.uint2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Unity.Mathematics.int2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Unity.Mathematics.half v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Unity.Mathematics.float2x2 v)
        {
            this = (mask16x2x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public mask16x2x2(Unity.Mathematics.double2x2 v)
        {
            this = (mask16x2x2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask16x2x2(mask32x2x2 v) => new mask16x2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask32x2x2(mask16x2x2 v) => new mask32x2x2 { c0 = v.c0, c1 = v.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask16x2x2(mask64x2x2 v) => new mask16x2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask64x2x2(mask16x2x2 v) => new mask64x2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask16x2x2(Unity.Mathematics.bool2x2 v) => new mask16x2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool2x2(mask16x2x2 v) => new Unity.Mathematics.bool2x2 { c0 = v.c0, c1 = v.c1 };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask16x2x2(bool2x2 v) => new mask16x2x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2x2(mask16x2x2 v) => new bool2x2 { c0 = v.c0, c1 = v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator mask16x2x2(bool v) => new mask16x2x2 { c0 = v, c1 = v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(byte v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(ushort v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(uint v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(ulong v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(UInt128 v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(sbyte v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(short v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(int v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(long v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(Int128 v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(quarter v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(half v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(float v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(double v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(quadruple v) => new mask16x2x2 { c0 = (mask16x2)v, c1 = (mask16x2)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(Unity.Mathematics.half v) => (mask16x2x2)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(Unity.Mathematics.float2x2 v) => (mask16x2x2)(float2x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(Unity.Mathematics.double2x2 v) => (mask16x2x2)(double2x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(Unity.Mathematics.uint2x2 v) => (mask16x2x2)(uint2x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2x2(Unity.Mathematics.int2x2 v) => (mask16x2x2)(int2x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2x2(mask16x2x2 v) => (float2x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2x2(mask16x2x2 v) => (double2x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2x2(mask16x2x2 v) => (uint2x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2x2(mask16x2x2 v) => (int2x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ! (mask16x2x2 val) => new mask16x2x2 { c0 = !val.c0, c1 = !val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (mask16x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (mask16x2x2 lhs, bool rhs) => new mask16x2x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (bool lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (mask16x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (mask16x2x2 lhs, bool rhs) => new mask16x2x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (bool lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (mask16x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (mask16x2x2 lhs, bool rhs) => new mask16x2x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (bool lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator & (mask16x2x2 lhs, mask32x2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator | (mask16x2x2 lhs, mask32x2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator ^ (mask16x2x2 lhs, mask32x2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator & (mask32x2x2 lhs, mask16x2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator | (mask32x2x2 lhs, mask16x2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator ^ (mask32x2x2 lhs, mask16x2x2 rhs) => new mask32x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator & (mask16x2x2 lhs, mask64x2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator | (mask16x2x2 lhs, mask64x2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator ^ (mask16x2x2 lhs, mask64x2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator & (mask64x2x2 lhs, mask16x2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator | (mask64x2x2 lhs, mask16x2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator ^ (mask64x2x2 lhs, mask16x2x2 rhs) => new mask64x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (mask16x2x2 lhs, Unity.Mathematics.bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (mask16x2x2 lhs, Unity.Mathematics.bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (mask16x2x2 lhs, Unity.Mathematics.bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (Unity.Mathematics.bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (Unity.Mathematics.bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (Unity.Mathematics.bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (mask16x2x2 lhs, bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (mask16x2x2 lhs, bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (mask16x2x2 lhs, bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator & (bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator | (bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator ^ (bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (mask16x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (mask16x2x2 lhs, bool rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (bool lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (mask16x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (mask16x2x2 lhs, bool rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (bool lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (mask16x2x2 lhs, Unity.Mathematics.bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (mask16x2x2 lhs, Unity.Mathematics.bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (Unity.Mathematics.bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (Unity.Mathematics.bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (mask16x2x2 lhs, bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (mask16x2x2 lhs, bool2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator == (bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2x2 operator != (bool2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (mask16x2x2 lhs, mask32x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (mask16x2x2 lhs, mask32x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator == (mask32x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2x2 operator != (mask32x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (mask16x2x2 lhs, mask64x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (mask16x2x2 lhs, mask64x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator == (mask64x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2x2 operator != (mask64x2x2 lhs, mask16x2x2 rhs) => new mask16x2x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        public ref mask16x2 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (mask16x2x2* array = &this) { return ref ((mask16x2*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask8x2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask16x2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask32x2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(mask64x2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool2x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool2x2)this).ToString();
    }
}
#pragma warning restore CS0660
