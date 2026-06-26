using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool3x3 : IEquatable<bool3x3>, IEquatable<Unity.Mathematics.bool3x3>, IEquatable<bool>
    {
        public bool3 c0;
        public bool3 c1;
        public bool3 c2;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(bool3 c0, bool3 c1, bool3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(bool m00, bool m01, bool m02,
                       bool m10, bool m11, bool m12,
                       bool m20, bool m21, bool m22)
        {
            this.c0 = new bool3(m00, m10, m20);
            this.c1 = new bool3(m01, m11, m21);
            this.c2 = new bool3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(bool v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(bool3x3 v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(mask8x3x3 v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(mask16x3x3 v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(mask32x3x3 v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(mask64x3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(byte v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(byte3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(sbyte v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(sbyte3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(ushort v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(ushort3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(short v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(short3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(uint v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(uint3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(int v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(int3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(ulong v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(ulong3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(long v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(long3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(UInt128 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Int128 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(quarter v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(half v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(float v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(float3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(double v)
        {
            this = (bool3x3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(double3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(quadruple v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Unity.Mathematics.bool3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Unity.Mathematics.uint3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Unity.Mathematics.int3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Unity.Mathematics.half v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Unity.Mathematics.float3x3 v)
        {
            this = (bool3x3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool3x3(Unity.Mathematics.double3x3 v)
        {
            this = (bool3x3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x3(Unity.Mathematics.bool3x3 v) => new bool3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool3x3(bool3x3 v) => new Unity.Mathematics.bool3x3 { c0 = v.c0, c1 = v.c1, c2 = v.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool3x3(bool v) => (Unity.Mathematics.bool3x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(byte v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(ushort v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(uint v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(ulong v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(UInt128 v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(sbyte v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(short v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(int v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(long v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(Int128 v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(quarter v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(half v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(float v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(double v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(quadruple v) => new bool3x3 { c0 = (bool3)v, c1 = (bool3)v, c2 = (bool3)v };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(Unity.Mathematics.half v) => (bool3x3)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(Unity.Mathematics.float3x3 v) => (bool3x3)(float3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(Unity.Mathematics.double3x3 v) => (bool3x3)(double3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(Unity.Mathematics.uint3x3 v) => (bool3x3)(uint3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3x3(Unity.Mathematics.int3x3 v) => (bool3x3)(int3x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3x3(bool3x3 v) => (float3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double3x3(bool3x3 v) => (double3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3x3(bool3x3 v) => (uint3x3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3x3(bool3x3 v) => (int3x3)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ! (bool3x3 val) => new bool3x3 { c0 = !val.c0, c1 = !val.c1, c2 = !val.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (bool3x3 lhs, bool rhs) => new bool3x3 { c0 = lhs.c0 & rhs, c1 = lhs.c1 & rhs, c2 = lhs.c2 & rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (bool lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs & rhs.c0, c1 = lhs & rhs.c1, c2 = lhs & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (bool3x3 lhs, bool rhs) => new bool3x3 { c0 = lhs.c0 | rhs, c1 = lhs.c1 | rhs, c2 = lhs.c2 | rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (bool lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs | rhs.c0, c1 = lhs | rhs.c1, c2 = lhs | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (bool3x3 lhs, bool rhs) => new bool3x3 { c0 = lhs.c0 ^ rhs, c1 = lhs.c1 ^ rhs, c2 = lhs.c2 ^ rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (bool lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs ^ rhs.c0, c1 = lhs ^ rhs.c1, c2 = lhs ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (bool3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (bool3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (bool3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator & (Unity.Mathematics.bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 & rhs.c0, c1 = lhs.c1 & rhs.c1, c2 = lhs.c2 & rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator | (Unity.Mathematics.bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 | rhs.c0, c1 = lhs.c1 | rhs.c1, c2 = lhs.c2 | rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator ^ (Unity.Mathematics.bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 ^ rhs.c0, c1 = lhs.c1 ^ rhs.c1, c2 = lhs.c2 ^ rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (bool3x3 lhs, bool rhs) => new bool3x3 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (bool lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (bool3x3 lhs, bool rhs) => new bool3x3 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (bool lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (bool3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (bool3x3 lhs, Unity.Mathematics.bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator == (Unity.Mathematics.bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3x3 operator != (Unity.Mathematics.bool3x3 lhs, bool3x3 rhs) => new bool3x3 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2 };


        public ref bool3 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (bool3x3* array = &this) { return ref ((bool3*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool3x3 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2);
        
        public override readonly bool Equals(object o) => (o is bool3x3 converted && Equals(converted)) || (o is Unity.Mathematics.bool3x3 convertedU && Equals(convertedU)) || (o is bool convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.bool3x3)this).ToString();
    }
}
