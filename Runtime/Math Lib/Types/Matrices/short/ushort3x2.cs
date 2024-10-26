using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Sequential, Size = 3 * 2 * sizeof(ushort))]
    unsafe public struct ushort3x2 : IEquatable<ushort3x2>, IFormattable
    {
        public ushort3 c0;
        public ushort3 c1;


        public static ushort3x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3x2(ushort3 c0, ushort3 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3x2(ushort m00, ushort m01,
                         ushort m10, ushort m11,
                         ushort m20, ushort m21)
        {
            this.c0 = new ushort3(m00, m10, m20);
            this.c1 = new ushort3(m01, m11, m21);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3x2(ushort v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3x2(ushort v) => new ushort3x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(short3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(int3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(uint3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(long3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(ulong3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(float3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x2(double3x2 input) => new ushort3x2((ushort3)input.c0, (ushort3)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x2(ushort3x2 input) => new int3x2((int3)input.c0, (int3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x2(ushort3x2 input) => new uint3x2((uint3)input.c0, (uint3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x2(ushort3x2 input) => new long3x2((long3)input.c0, (long3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x2(ushort3x2 input) => new ulong3x2((ulong3)input.c0, (ulong3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x2(ushort3x2 input) => new float3x2((float3)input.c0, (float3)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x2(ushort3x2 input) => new double3x2((double3)input.c0, (double3)input.c1);


        public ref ushort3 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((ushort3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator + (ushort3x2 left, ushort3x2 right) => new ushort3x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator - (ushort3x2 left, ushort3x2 right) => new ushort3x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator * (ushort3x2 left, ushort3x2 right) => new ushort3x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator / (ushort3x2 left, ushort3x2 right) => new ushort3x2(left.c0 / right.c0, left.c1 / right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator % (ushort3x2 left, ushort3x2 right) => new ushort3x2(left.c0 % right.c0, left.c1 % right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator * (ushort3x2 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator * (ushort left, ushort3x2 right) => new ushort3x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator / (ushort3x2 left, ushort right) => new ushort3x2(left.c0 / right, left.c1 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator % (ushort3x2 left, ushort right) => new ushort3x2(left.c0 % right, left.c1 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator & (ushort3x2 left, ushort3x2 right) => new ushort3x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator | (ushort3x2 left, ushort3x2 right) => new ushort3x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator ^ (ushort3x2 left, ushort3x2 right) => new ushort3x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator ++ (ushort3x2 val) => new ushort3x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator -- (ushort3x2 val) => new ushort3x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator ~ (ushort3x2 val) => new ushort3x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator << (ushort3x2 x, int n) => new ushort3x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x2 operator >> (ushort3x2 x, int n) => new ushort3x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator == (ushort3x2 left, ushort3x2 right) => new bool3x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator < (ushort3x2 left, ushort3x2 right) => new bool3x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator > (ushort3x2 left, ushort3x2 right) => new bool3x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator != (ushort3x2 left, ushort3x2 right) => new bool3x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator <= (ushort3x2 left, ushort3x2 right) => new bool3x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x2 operator >= (ushort3x2 left, ushort3x2 right) => new bool3x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ushort3x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override readonly bool Equals(object obj) => obj is ushort3x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override readonly string ToString() => $"ushort3x2({c0.x}, {c1.x},  {c0.y}, {c1.y},  {c0.z}, {c1.z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ushort3x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)})";
    }
}