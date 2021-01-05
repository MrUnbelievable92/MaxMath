using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 12)]
    unsafe public struct ushort2x3 : IEquatable<ushort2x3>, IFormattable
    {
        public ushort2 c0;
        public ushort2 c1;
        public ushort2 c2;


        public static ushort2x3 zero => default(ushort2x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2x3(ushort2 c0, ushort2 c1, ushort2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2x3(ushort m00, ushort m01, ushort m02,
                         ushort m10, ushort m11, ushort m12)
        {
            this.c0 = new ushort2(m00, m10);
            this.c1 = new ushort2(m01, m11);
            this.c2 = new ushort2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2x3(ushort v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2x3(ushort v) => new ushort2x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(short2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(int2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(uint2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(long2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(ulong2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(float2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2x3(double2x3 input) => new ushort2x3((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x3(ushort2x3 input) => new int2x3((int2)input.c0, (int2)input.c1, (int2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x3(ushort2x3 input) => new uint2x3((uint2)input.c0, (uint2)input.c1, (uint2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(ushort2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x3(ushort2x3 input) => new ulong2x3((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(ushort2x3 input) => new float2x3((float2)input.c0, (float2)input.c1, (float2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x3(ushort2x3 input) => new double2x3((double2)input.c0, (double2)input.c1, (double2)input.c2);


        public ref ushort2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((ushort2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator + (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator - (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator * (ushort2x3 left, ushort2x3 right) => new ushort2x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator / (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator % (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator * (ushort2x3 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator * (ushort left, ushort2x3 right) => new ushort2x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator / (ushort2x3 left, ushort right) => new ushort2x3 (left.c0 / right, left.c1 / right, left.c2 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator % (ushort2x3 left, ushort right) => new ushort2x3 (left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator & (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator | (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator ^ (ushort2x3 left, ushort2x3 right) => new ushort2x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator ++ (ushort2x3 val) => new ushort2x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator -- (ushort2x3 val) => new ushort2x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator ~ (ushort2x3 val) => new ushort2x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator << (ushort2x3 x, int n) => new ushort2x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2x3 operator >> (ushort2x3 x, int n) => new ushort2x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (ushort2x3 left, ushort2x3 right) => new bool2x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (ushort2x3 left, ushort2x3 right) => new bool2x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (ushort2x3 left, ushort2x3 right) => new bool2x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (ushort2x3 left, ushort2x3 right) => new bool2x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (ushort2x3 left, ushort2x3 right) => new bool2x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (ushort2x3 left, ushort2x3 right) => new bool2x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort2x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((ushort2x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode() ^ c2.GetHashCode();


        public override string ToString() => $"ushort2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}