using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 24)]
    unsafe public struct ushort4x3 : IEquatable<ushort4x3>, IFormattable
    {
        public ushort4 c0;
        public ushort4 c1;
        public ushort4 c2;


        public static ushort4x3 zero => default(ushort4x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort4 c0, ushort4 c1, ushort4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort m00, ushort m01, ushort m02,
                         ushort m10, ushort m11, ushort m12,
                         ushort m20, ushort m21, ushort m22,
                         ushort m30, ushort m31, ushort m32)
        {
            this.c0 = new ushort4(m00, m10, m20, m30);
            this.c1 = new ushort4(m01, m11, m21, m31);
            this.c2 = new ushort4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x3(ushort v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4x3(ushort v) => new ushort4x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(short4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(int4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(uint4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(long4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(ulong4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(float4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x3(double4x3 input) => new ushort4x3((ushort4)input.c0, (ushort4)input.c1, (ushort4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(ushort4x3 input) => new int4x3((int4)input.c0, (int4)input.c1, (int4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x3(ushort4x3 input) => new uint4x3((uint4)input.c0, (uint4)input.c1, (uint4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x3(ushort4x3 input) => new long4x3((long4)input.c0, (long4)input.c1, (long4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x3(ushort4x3 input) => new ulong4x3((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x3(ushort4x3 input) => new float4x3((float4)input.c0, (float4)input.c1, (float4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(ushort4x3 input) => new double4x3((double4)input.c0, (double4)input.c1, (double4)input.c2);


        public ref ushort4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((ushort4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator + (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator - (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort4x3 left, ushort4x3 right) => new ushort4x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort4x3 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator * (ushort left, ushort4x3 right) => new ushort4x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator / (ushort4x3 left, ushort right) => new ushort4x3 (left.c0 / right, left.c1 / right, left.c2 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator % (ushort4x3 left, ushort right) => new ushort4x3 (left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator & (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator | (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ^ (ushort4x3 left, ushort4x3 right) => new ushort4x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ++ (ushort4x3 val) => new ushort4x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator -- (ushort4x3 val) => new ushort4x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator ~ (ushort4x3 val) => new ushort4x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator << (ushort4x3 x, int n) => new ushort4x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x3 operator >> (ushort4x3 x, int n) => new ushort4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (ushort4x3 left, ushort4x3 right) => new bool4x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (ushort4x3 left, ushort4x3 right) => new bool4x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (ushort4x3 left, ushort4x3 right) => new bool4x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (ushort4x3 left, ushort4x3 right) => new bool4x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (ushort4x3 left, ushort4x3 right) => new bool4x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (ushort4x3 left, ushort4x3 right) => new bool4x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort4x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((ushort4x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ c2.GetHashCode();


        public override string ToString() => $"ushort4x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z},  {c0.w}, {c1.w}, {c2.w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort4x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)})";
    }
}