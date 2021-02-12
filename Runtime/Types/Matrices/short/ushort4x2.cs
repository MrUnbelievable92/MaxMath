using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 4 * 2 * sizeof(ushort))]
    unsafe public struct ushort4x2 : IEquatable<ushort4x2>, IFormattable
    {
        public ushort4 c0;
        public ushort4 c1;


        public static ushort4x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x2(ushort4 c0, ushort4 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x2(ushort m00, ushort m01,
                         ushort m10, ushort m11,
                         ushort m20, ushort m21,
                         ushort m30, ushort m31)
        {
            this.c0 = new ushort4(m00, m10, m20, m30);
            this.c1 = new ushort4(m01, m11, m21, m31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4x2(ushort v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4x2(ushort v) => new ushort4x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(short4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(int4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(uint4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(long4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(ulong4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(float4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4x2(double4x2 input) => new ushort4x2((ushort4)input.c0, (ushort4)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x2(ushort4x2 input) => new int4x2((int4)input.c0, (int4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4x2(ushort4x2 input) => new uint4x2((uint4)input.c0, (uint4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x2(ushort4x2 input) => new long4x2((long4)input.c0, (long4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4x2(ushort4x2 input) => new ulong4x2((ulong4)input.c0, (ulong4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x2(ushort4x2 input) => new float4x2((float4)input.c0, (float4)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x2(ushort4x2 input) => new double4x2((double4)input.c0, (double4)input.c1);


        public ref ushort4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((ushort4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator + (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator - (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator * (ushort4x2 left, ushort4x2 right) => new ushort4x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator / (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 / right.c0, left.c1 / right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator % (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 % right.c0, left.c1 % right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator * (ushort4x2 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator * (ushort left, ushort4x2 right) => new ushort4x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator / (ushort4x2 left, ushort right) => new ushort4x2 (left.c0 / right, left.c1 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator % (ushort4x2 left, ushort right) => new ushort4x2 (left.c0 % right, left.c1 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator & (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator | (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator ^ (ushort4x2 left, ushort4x2 right) => new ushort4x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator ++ (ushort4x2 val) => new ushort4x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator -- (ushort4x2 val) => new ushort4x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator ~ (ushort4x2 val) => new ushort4x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator << (ushort4x2 x, int n) => new ushort4x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4x2 operator >> (ushort4x2 x, int n) => new ushort4x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator == (ushort4x2 left, ushort4x2 right) => new bool4x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator < (ushort4x2 left, ushort4x2 right) => new bool4x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator > (ushort4x2 left, ushort4x2 right) => new bool4x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator != (ushort4x2 left, ushort4x2 right) => new bool4x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator <= (ushort4x2 left, ushort4x2 right) => new bool4x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x2 operator >= (ushort4x2 left, ushort4x2 right) => new bool4x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ushort4x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override readonly bool Equals(object obj) => Equals((ushort4x2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override readonly string ToString() => $"ushort4x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z},  {c0.w}, {c1.w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ushort4x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)})";
    }
}