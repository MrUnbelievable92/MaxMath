using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 4 * 3 * sizeof(long))]
    unsafe public struct long4x3 : IEquatable<long4x3>, IFormattable
    {
        public long4 c0;
        public long4 c1;
        public long4 c2;


        public static long4x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x3(long4 c0, long4 c1, long4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x3(long m00, long m01, long m02,
                       long m10, long m11, long m12,
                       long m20, long m21, long m22,
                       long m30, long m31, long m32)
        {
            this.c0 = new long4(m00, m10, m20, m30);
            this.c1 = new long4(m01, m11, m21, m31);
            this.c2 = new long4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4x3(long v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x3(long v) => new long4x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x3(ulong4x3 input) => new long4x3((long4)input.c0, (long4)input.c1, (long4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x3(float4x3 input) => new long4x3((long4)input.c0, (long4)input.c1, (long4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4x3(double4x3 input) => new long4x3((long4)input.c0, (long4)input.c1, (long4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x3(long4x3 input) => new float4x3((float4)input.c0, (float4)input.c1, (float4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(long4x3 input) => new double4x3((double4)input.c0, (double4)input.c1, (double4)input.c2);


        public ref long4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((long4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator + (long4x3 left, long4x3 right) => new long4x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator - (long4x3 left, long4x3 right) => new long4x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator * (long4x3 left, long4x3 right) => new long4x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator / (long4x3 left, long4x3 right) => new long4x3 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator % (long4x3 left, long4x3 right) => new long4x3 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator * (long4x3 left, long right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator * (long left, long4x3 right) => new long4x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator / (long4x3 left, long right) => new long4x3 (left.c0 / right, left.c1 / right, left.c2 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator % (long4x3 left, long right) => new long4x3 (left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator & (long4x3 left, long4x3 right) => new long4x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator | (long4x3 left, long4x3 right) => new long4x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator ^ (long4x3 left, long4x3 right) => new long4x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator - (long4x3 val) => new long4x3 (-val.c0, -val.c1, -val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator ++ (long4x3 val) => new long4x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator -- (long4x3 val) => new long4x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator ~ (long4x3 val) => new long4x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator << (long4x3 x, int n) => new long4x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4x3 operator >> (long4x3 x, int n) => new long4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (long4x3 left, long4x3 right) => new bool4x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (long4x3 left, long4x3 right) => new bool4x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (long4x3 left, long4x3 right) => new bool4x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (long4x3 left, long4x3 right) => new bool4x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (long4x3 left, long4x3 right) => new bool4x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (long4x3 left, long4x3 right) => new bool4x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long4x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override readonly bool Equals(object obj) => Equals((long4x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ c2.GetHashCode();


        public override readonly string ToString() => $"long4x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z},  {c0.w}, {c1.w}, {c2.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long4x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)})";
    }
}