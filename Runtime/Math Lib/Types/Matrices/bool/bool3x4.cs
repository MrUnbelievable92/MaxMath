using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool3x4 : IEquatable<bool3x4>, IEquatable<Unity.Mathematics.bool3x4>, IEquatable<bool>
    {
        public bool3 c0;
        public bool3 c1;
        public bool3 c2;
        public bool3 c3;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(bool3 c0, bool3 c1, bool3 c2, bool3 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(bool m00, bool m01, bool m02, bool m03,
                       bool m10, bool m11, bool m12, bool m13,
                       bool m20, bool m21, bool m22, bool m23)
        {
            this.c0 = new bool3(m00, m10, m20);
            this.c1 = new bool3(m01, m11, m21);
            this.c2 = new bool3(m02, m12, m22);
            this.c3 = new bool3(m03, m13, m23);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(bool v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(bool3x4 v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(mask8x3x4 v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(mask16x3x4 v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(mask32x3x4 v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(mask64x3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(byte v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(byte3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(sbyte v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(sbyte3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(ushort v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(ushort3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(short v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(short3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(uint v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(uint3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(int v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(int3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(ulong v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(ulong3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(long v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(long3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(UInt128 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Int128 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(quarter v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(half v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(float v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(float3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(double v)
        {
            this = (bool3x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(double3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(quadruple v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Unity.Mathematics.bool3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Unity.Mathematics.uint3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Unity.Mathematics.int3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Unity.Mathematics.half v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Unity.Mathematics.float3x4 v)
        {
            this = (bool3x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x4(Unity.Mathematics.double3x4 v)
        {
            this = (bool3x4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x4(Unity.Mathematics.bool3x4 v) => new bool3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool3x4(bool3x4 v) => new Unity.Mathematics.bool3x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x4(bool v) => (Unity.Mathematics.bool3x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(byte v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(ushort v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(uint v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(ulong v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(UInt128 v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(sbyte v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(short v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(int v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(long v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(Int128 v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(quarter v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(half v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(float v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(double v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(quadruple v) => new bool3x4 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v, c3 = (bool3)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(Unity.Mathematics.half v) => (bool3x4)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(Unity.Mathematics.float3x4 v) => (bool3x4)(float3x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(Unity.Mathematics.double3x4 v) => (bool3x4)(double3x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(Unity.Mathematics.uint3x4 v) => (bool3x4)(uint3x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x4(Unity.Mathematics.int3x4 v) => (bool3x4)(int3x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3x4(bool3x4 v) => (float3x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double3x4(bool3x4 v) => (double3x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x4(bool3x4 v) => (uint3x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x4(bool3x4 v) => (int3x4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator ! (bool3x4 val) => new bool3x4 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2, c3 = !val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator & (bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator & (bool3x4 lhs, bool rhs) => new bool3x4 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs, c3 = lhs.c3 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator & (bool lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2, c3 = lhs & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator | (bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator | (bool3x4 lhs, bool rhs) => new bool3x4 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs, c3 = lhs.c3 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator | (bool lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2, c3 = lhs | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator ^ (bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator ^ (bool3x4 lhs, bool rhs) => new bool3x4 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs, c3 = lhs.c3 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator ^ (bool lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2, c3 = lhs ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator & (bool3x4 lhs, Unity.Mathematics.bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator | (bool3x4 lhs, Unity.Mathematics.bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator ^ (bool3x4 lhs, Unity.Mathematics.bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator & (Unity.Mathematics.bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2, c3 = lhs.c3 & rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator | (Unity.Mathematics.bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2, c3 = lhs.c3 | rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator ^ (Unity.Mathematics.bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2, c3 = lhs.c3 ^ rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator == (bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator == (bool3x4 lhs, bool rhs) => new bool3x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator == (bool lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator != (bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator != (bool3x4 lhs, bool rhs) => new bool3x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator != (bool lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator == (bool3x4 lhs, Unity.Mathematics.bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator != (bool3x4 lhs, Unity.Mathematics.bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator == (Unity.Mathematics.bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x4 operator != (Unity.Mathematics.bool3x4 lhs, bool3x4 rhs) => new bool3x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };


        public ref bool3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (bool3x4* array = &this) { return ref ((bool3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool3x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is bool3x4 converted && Equals(converted)) || (o is Unity.Mathematics.bool3x4 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool3x4)this).ToString();
    }
}
