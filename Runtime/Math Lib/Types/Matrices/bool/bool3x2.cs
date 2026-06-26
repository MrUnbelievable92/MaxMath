using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool3x2 : IEquatable<bool3x2>, IEquatable<Unity.Mathematics.bool3x2>, IEquatable<bool>
    {
        public bool3 c0;
        public bool3 c1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(bool3 c0, bool3 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(bool m00, bool m01,
                       bool m10, bool m11,
                       bool m20, bool m21)
        {
            this.c0 = new bool3(m00, m10, m20);
            this.c1 = new bool3(m01, m11, m21);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(bool v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(bool3x2 v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(mask8x3x2 v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(mask16x3x2 v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(mask32x3x2 v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(mask64x3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(byte v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(byte3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(sbyte v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(sbyte3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(ushort v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(ushort3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(short v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(short3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(uint v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(uint3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(int v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(int3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(ulong v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(ulong3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(long v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(long3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(UInt128 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Int128 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(quarter v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(half v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(float v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(float3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(double v)
        {
            this = (bool3x2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(double3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(quadruple v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Unity.Mathematics.bool3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Unity.Mathematics.uint3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Unity.Mathematics.int3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Unity.Mathematics.half v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Unity.Mathematics.float3x2 v)
        {
            this = (bool3x2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x2(Unity.Mathematics.double3x2 v)
        {
            this = (bool3x2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x2(Unity.Mathematics.bool3x2 v) => new bool3x2 { c0 = v.c0, c1 = v.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool3x2(bool3x2 v) => new Unity.Mathematics.bool3x2 { c0 = v.c0, c1 = v.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x2(bool v) => (Unity.Mathematics.bool3x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(byte v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(ushort v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(uint v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(ulong v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(UInt128 v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(sbyte v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(short v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(int v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(long v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(Int128 v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(quarter v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(half v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(float v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(double v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(quadruple v) => new bool3x2 { c0 = (bool3)v, c1 = (bool3)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(Unity.Mathematics.half v) => (bool3x2)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(Unity.Mathematics.float3x2 v) => (bool3x2)(float3x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(Unity.Mathematics.double3x2 v) => (bool3x2)(double3x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(Unity.Mathematics.uint3x2 v) => (bool3x2)(uint3x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x2(Unity.Mathematics.int3x2 v) => (bool3x2)(int3x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3x2(bool3x2 v) => (float3x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double3x2(bool3x2 v) => (double3x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x2(bool3x2 v) => (uint3x2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x2(bool3x2 v) => (int3x2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator ! (bool3x2 val) => new bool3x2 { c0 = !val.c0, c1 = !val.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator & (bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator & (bool3x2 lhs, bool rhs) => new bool3x2 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator & (bool lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator | (bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator | (bool3x2 lhs, bool rhs) => new bool3x2 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator | (bool lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator ^ (bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator ^ (bool3x2 lhs, bool rhs) => new bool3x2 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator ^ (bool lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator & (bool3x2 lhs, Unity.Mathematics.bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator | (bool3x2 lhs, Unity.Mathematics.bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator ^ (bool3x2 lhs, Unity.Mathematics.bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator & (Unity.Mathematics.bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator | (Unity.Mathematics.bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator ^ (Unity.Mathematics.bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator == (bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator == (bool3x2 lhs, bool rhs) => new bool3x2 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator == (bool lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator != (bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator != (bool3x2 lhs, bool rhs) => new bool3x2 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator != (bool lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator == (bool3x2 lhs, Unity.Mathematics.bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator != (bool3x2 lhs, Unity.Mathematics.bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator == (Unity.Mathematics.bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x2 operator != (Unity.Mathematics.bool3x2 lhs, bool3x2 rhs) => new bool3x2 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1 };


        public ref bool3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (bool3x2* array = &this) { return ref ((bool3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool3x2 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1);
        
        public override readonly bool Equals(object o) => (o is bool3x2 converted && Equals(converted)) || (o is Unity.Mathematics.bool3x2 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool3x2)this).ToString();
    }
}
