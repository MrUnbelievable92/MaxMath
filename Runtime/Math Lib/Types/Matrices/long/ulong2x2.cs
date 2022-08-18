using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Sequential, Size = 2 * 2 * sizeof(ulong))]
    unsafe public struct ulong2x2 : IEquatable<ulong2x2>, IFormattable
    {
        public ulong2 c0;
        public ulong2 c1;


        public static ulong2x2 identity => new ulong2x2(1, 0,   0, 1);

        public static ulong2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x2(ulong2 c0, ulong2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x2(ulong m00, ulong m01,
                        ulong m10, ulong m11)
        {
            this.c0 = new ulong2(m00, m10);
            this.c1 = new ulong2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2x2(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x2(ulong v) => new ulong2x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x2(long2x2 input) => new ulong2x2((ulong2)input.c0, (ulong2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x2(float2x2 input) => new ulong2x2((ulong2)input.c0, (ulong2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x2(double2x2 input) => new ulong2x2((ulong2)input.c0, (ulong2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(ulong2x2 input) => new float2x2((float2)input.c0, (float2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(ulong2x2 input) => new double2x2((double2)input.c0, (double2)input.c1);


        public ref ulong2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator + (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator - (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator * (ulong2x2 left, ulong2x2 right) => new ulong2x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator / (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 / right.c0, left.c1 / right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator % (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 % right.c0, left.c1 % right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator * (ulong2x2 left, ulong right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator * (ulong left, ulong2x2 right) => new ulong2x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator / (ulong2x2 left, ulong right) => new ulong2x2 (left.c0 / right, left.c1 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator % (ulong2x2 left, ulong right) => new ulong2x2 (left.c0 % right, left.c1 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator & (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator | (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator ^ (ulong2x2 left, ulong2x2 right) => new ulong2x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator ++ (ulong2x2 val) => new ulong2x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator -- (ulong2x2 val) => new ulong2x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator ~ (ulong2x2 val) => new ulong2x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator << (ulong2x2 x, int n) => new ulong2x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2x2 operator >> (ulong2x2 x, int n) => new ulong2x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (ulong2x2 left, ulong2x2 right) => new bool2x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (ulong2x2 left, ulong2x2 right) => new bool2x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (ulong2x2 left, ulong2x2 right) => new bool2x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (ulong2x2 left, ulong2x2 right) => new bool2x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (ulong2x2 left, ulong2x2 right) => new bool2x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (ulong2x2 left, ulong2x2 right) => new bool2x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ulong2x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override readonly bool Equals(object obj) => obj is ulong2x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override readonly string ToString() => $"ulong2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}