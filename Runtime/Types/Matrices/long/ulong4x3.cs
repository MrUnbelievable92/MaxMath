using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 96)]
    unsafe public struct ulong4x3 : IEquatable<ulong4x3>, IFormattable
    {
        public ulong4 c0;
        public ulong4 c1;
        public ulong4 c2;


        public static ulong4x3 zero => default(ulong4x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x3(ulong4 c0, ulong4 c1, ulong4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x3(ulong m00, ulong m01, ulong m02,
                        ulong m10, ulong m11, ulong m12,
                        ulong m20, ulong m21, ulong m22,
                        ulong m30, ulong m31, ulong m32)
        {
            this.c0 = new ulong4(m00, m10, m20, m30);
            this.c1 = new ulong4(m01, m11, m21, m31);
            this.c2 = new ulong4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4x3(ulong v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x3(ulong v) => new ulong4x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x3(long4x3 input) => new ulong4x3((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x3(float4x3 input) => new ulong4x3((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x3(double4x3 input) => new ulong4x3((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x3(ulong4x3 input) => new float4x3((float4)input.c0, (float4)input.c1, (float4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(ulong4x3 input) => new double4x3((double4)input.c0, (double4)input.c1, (double4)input.c2);


        public ref ulong4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((ulong4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator + (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator - (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator * (ulong4x3 left, ulong4x3 right) => new ulong4x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator / (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator % (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator * (ulong4x3 left, ulong right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator * (ulong left, ulong4x3 right) => new ulong4x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator / (ulong4x3 left, ulong right) => new ulong4x3 (left.c0 / right, left.c1 / right, left.c2 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator % (ulong4x3 left, ulong right) => new ulong4x3 (left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator & (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator | (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator ^ (ulong4x3 left, ulong4x3 right) => new ulong4x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator ++ (ulong4x3 val) => new ulong4x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator -- (ulong4x3 val) => new ulong4x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator ~ (ulong4x3 val) => new ulong4x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator << (ulong4x3 x, int n) => new ulong4x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4x3 operator >> (ulong4x3 x, int n) => new ulong4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (ulong4x3 left, ulong4x3 right) => new bool4x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (ulong4x3 left, ulong4x3 right) => new bool4x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (ulong4x3 left, ulong4x3 right) => new bool4x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (ulong4x3 left, ulong4x3 right) => new bool4x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (ulong4x3 left, ulong4x3 right) => new bool4x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (ulong4x3 left, ulong4x3 right) => new bool4x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong4x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((ulong4x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ c2.GetHashCode();


        public override string ToString() => $"ulong4x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z},  {c0.w}, {c1.w}, {c2.w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong4x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)})";
    }
}