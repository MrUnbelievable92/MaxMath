using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 3 * 2 * sizeof(ulong))]
    unsafe public struct ulong3x2 : IEquatable<ulong3x2>, IFormattable
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
        public ulong3x2(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(ulong v) => new ulong3x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(long3x2 input) => new ulong3x2((ulong3)input.c0, (ulong3)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(float3x2 input) => new ulong3x2((ulong3)input.c0, (ulong3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x2(double3x2 input) => new ulong3x2((ulong3)input.c0, (ulong3)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(ulong3x2 input) => new float3x2((float3)input.c0, (float3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(ulong3x2 input) => new double3x2((double3)input.c0, (double3)input.c1);


        public ref ulong3 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator + (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator - (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 left, ulong3x2 right) => new ulong3x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 / right.c0, left.c1 / right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 % right.c0, left.c1 % right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong3x2 left, ulong right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator * (ulong left, ulong3x2 right) => new ulong3x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator / (ulong3x2 left, ulong right) => new ulong3x2 (left.c0 / right, left.c1 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator % (ulong3x2 left, ulong right) => new ulong3x2 (left.c0 % right, left.c1 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator & (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator | (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ^ (ulong3x2 left, ulong3x2 right) => new ulong3x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ++ (ulong3x2 val) => new ulong3x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator -- (ulong3x2 val) => new ulong3x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator ~ (ulong3x2 val) => new ulong3x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator << (ulong3x2 x, int n) => new ulong3x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3x2 operator >> (ulong3x2 x, int n) => new ulong3x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (ulong3x2 left, ulong3x2 right) => new bool3x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (ulong3x2 left, ulong3x2 right) => new bool3x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (ulong3x2 left, ulong3x2 right) => new bool3x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (ulong3x2 left, ulong3x2 right) => new bool3x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (ulong3x2 left, ulong3x2 right) => new bool3x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (ulong3x2 left, ulong3x2 right) => new bool3x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong3x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override bool Equals(object obj) => Equals((ulong3x2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override string ToString() => $"ulong3x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong3x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)})";
    }
}