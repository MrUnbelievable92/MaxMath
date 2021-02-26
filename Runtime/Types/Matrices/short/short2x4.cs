using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 2 * 4 * sizeof(short))]
    unsafe public struct short2x4 : IEquatable<short2x4>, IFormattable
    {
        public short2 c0;
        public short2 c1;
        public short2 c2;
        public short2 c3;


        public static short2x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x4(short2 c0, short2 c1, short2 c2, short2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x4(short m00, short m01, short m02, short m03,
                        short m10, short m11, short m12, short m13)
        {
            this.c0 = new short2(m00, m10);
            this.c1 = new short2(m01, m11);
            this.c2 = new short2(m02, m12);
            this.c3 = new short2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x4(short v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x4(short v) => new short2x4(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(ushort2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(int2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(uint2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(long2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(ulong2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(float2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x4(double2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(short2x4 input) => new int2x4((int2)input.c0, (int2)input.c1, (int2)input.c2, (int2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(short2x4 input) => new uint2x4((uint2)input.c0, (uint2)input.c1, (uint2)input.c2, (uint2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(short2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x4(short2x4 input) => new ulong2x4((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2, (ulong2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x4(short2x4 input) => new float2x4((float2)input.c0, (float2)input.c1, (float2)input.c2, (float2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x4(short2x4 input) => new double2x4((double2)input.c0, (double2)input.c1, (double2)input.c2, (double2)input.c3);


        public ref short2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ref ((short2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator + (short2x4 left, short2x4 right) => new short2x4 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2, left.c3 + right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator - (short2x4 left, short2x4 right) => new short2x4 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2, left.c3 - right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator * (short2x4 left, short2x4 right) => new short2x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator / (short2x4 left, short2x4 right) => new short2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator % (short2x4 left, short2x4 right) => new short2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator * (short2x4 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator * (short left, short2x4 right) => new short2x4 (left * right.c0, left * right.c1, left * right.c2, left * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator / (short2x4 left, short right) => new short2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator % (short2x4 left, short right) => new short2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator & (short2x4 left, short2x4 right) => new short2x4 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2, left.c3 & right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator | (short2x4 left, short2x4 right) => new short2x4 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2, left.c3 | right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator ^ (short2x4 left, short2x4 right) => new short2x4 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2, left.c3 ^ right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator - (short2x4 val) => new short2x4(-val.c0, -val.c1, -val.c2, -val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator ++ (short2x4 val) => new short2x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator -- (short2x4 val) => new short2x4 (--val.c0, --val.c1, --val.c2, --val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator ~ (short2x4 val) => new short2x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator << (short2x4 x, int n) => new short2x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x4 operator >> (short2x4 x, int n) => new short2x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (short2x4 left, short2x4 right) => new bool2x4 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2, left.c3 == right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (short2x4 left, short2x4 right) => new bool2x4 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2, left.c3 < right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (short2x4 left, short2x4 right) => new bool2x4 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2, left.c3 > right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (short2x4 left, short2x4 right) => new bool2x4 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2, left.c3 != right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (short2x4 left, short2x4 right) => new bool2x4 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2, left.c3 <= right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (short2x4 left, short2x4 right) => new bool2x4 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2, left.c3 >= right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  bool Equals(short2x4 other) => (this.c0.Equals(other.c0) & this.c1.Equals(other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override  bool Equals(object obj) => Equals((short2x4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() ^ c3.GetHashCode());


        public override  string ToString() => $"short2x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"short2x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)})";
    }
}