using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Sequential, Size = 3 * 4 * sizeof(sbyte))]
    unsafe public struct sbyte3x4 : IEquatable<sbyte3x4>, IFormattable
    {
        public sbyte3 c0;
        public sbyte3 c1;
        public sbyte3 c2;
        public sbyte3 c3;


        public static sbyte3x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3x4(sbyte3 c0, sbyte3 c1, sbyte3 c2, sbyte3 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3x4(sbyte m00, sbyte m01, sbyte m02, sbyte m03,
                        sbyte m10, sbyte m11, sbyte m12, sbyte m13,
                        sbyte m20, sbyte m21, sbyte m22, sbyte m23)
        {
            this.c0 = new sbyte3(m00, m10, m20);
            this.c1 = new sbyte3(m01, m11, m21);
            this.c2 = new sbyte3(m02, m12, m22);
            this.c3 = new sbyte3(m03, m13, m23);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3x4(sbyte v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3x4(sbyte v) => new sbyte3x4(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(byte3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(short3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(ushort3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(int3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(uint3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(long3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(ulong3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(float3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3x4(double3x4 input) => new sbyte3x4((sbyte3)input.c0, (sbyte3)input.c1, (sbyte3)input.c2, (sbyte3)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3x4(sbyte3x4 input) => new short3x4((short3)input.c0, (short3)input.c1, (short3)input.c2, (short3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x4(sbyte3x4 input) => new ushort3x4((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2, (ushort3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x4(sbyte3x4 input) => new int3x4((int3)input.c0, (int3)input.c1, (int3)input.c2, (int3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3x4(sbyte3x4 input) => new uint3x4((uint3)input.c0, (uint3)input.c1, (uint3)input.c2, (uint3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x4(sbyte3x4 input) => new long3x4((long3)input.c0, (long3)input.c1, (long3)input.c2, (long3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3x4(sbyte3x4 input) => new ulong3x4((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2, (ulong3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x4(sbyte3x4 input) => new float3x4((float3)input.c0, (float3)input.c1, (float3)input.c2, (float3)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x4(sbyte3x4 input) => new double3x4((double3)input.c0, (double3)input.c1, (double3)input.c2, (double3)input.c3);


        public ref sbyte3 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ref ((sbyte3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator + (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2, left.c3 + right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator - (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2, left.c3 - right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator * (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator / (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4(left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator % (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4(left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator * (sbyte3x4 left, sbyte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator * (sbyte left, sbyte3x4 right) => new sbyte3x4 (left * right.c0, left * right.c1, left * right.c2, left * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator / (sbyte3x4 left, sbyte right) => new sbyte3x4(left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator % (sbyte3x4 left, sbyte right) => new sbyte3x4(left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator & (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2, left.c3 & right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator | (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2, left.c3 | right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator ^ (sbyte3x4 left, sbyte3x4 right) => new sbyte3x4 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2, left.c3 ^ right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator - (sbyte3x4 val) => new sbyte3x4 (-val.c0, -val.c1, -val.c2, -val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator ++ (sbyte3x4 val) => new sbyte3x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator -- (sbyte3x4 val) => new sbyte3x4 (--val.c0, --val.c1, --val.c2, --val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator ~ (sbyte3x4 val) => new sbyte3x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator << (sbyte3x4 x, int n) => new sbyte3x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3x4 operator >> (sbyte3x4 x, int n) => new sbyte3x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x4 operator == (sbyte3x4 left, sbyte3x4 right) => new bool3x4 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2, left.c3 == right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x4 operator < (sbyte3x4 left, sbyte3x4 right) => new bool3x4 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2, left.c3 < right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x4 operator > (sbyte3x4 left, sbyte3x4 right) => new bool3x4 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2, left.c3 > right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x4 operator != (sbyte3x4 left, sbyte3x4 right) => new bool3x4 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2, left.c3 != right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x4 operator <= (sbyte3x4 left, sbyte3x4 right) => new bool3x4 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2, left.c3 <= right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x4 operator >= (sbyte3x4 left, sbyte3x4 right) => new bool3x4 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2, left.c3 >= right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte3x4 other) => (this.c0.Equals(other.c0) & this.c1.Equals(other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override readonly bool Equals(object obj) => obj is sbyte3x4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) | (c2.GetHashCode() ^ c3.GetHashCode() << 8);


        public override readonly string ToString() => $"sbyte3x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y},  {c0.z}, {c1.z}, {c2.z}, {c3.z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte3x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)}, {c3.z.ToString(format, formatProvider)})";
    }
}