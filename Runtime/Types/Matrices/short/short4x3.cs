using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 12)]
    unsafe public struct short4x3 : IEquatable<short4x3>, IFormattable
    {
        public short4 c0;
        public short4 c1;
        public short4 c2;


        public static short4x3 zero => default(short4x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4x3(short4 c0, short4 c1, short4 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4x3(short m00, short m01, short m02,
                        short m10, short m11, short m12,
                        short m20, short m21, short m22,
                        short m30, short m31, short m32)
        {
            this.c0 = new short4(m00, m10, m20, m30);
            this.c1 = new short4(m01, m11, m21, m31);
            this.c2 = new short4(m02, m12, m22, m32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4x3(short v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4x3(short v) => new short4x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(ushort4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(int4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(uint4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(long4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(ulong4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(float4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4x3(double4x3 input) => new short4x3((short4)input.c0, (short4)input.c1, (short4)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4x3(short4x3 input) => new int4x3((int4)input.c0, (int4)input.c1, (int4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4x3(short4x3 input) => new uint4x3((uint4)input.c0, (uint4)input.c1, (uint4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4x3(short4x3 input) => new long4x3((long4)input.c0, (long4)input.c1, (long4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4x3(short4x3 input) => new ulong4x3((ulong4)input.c0, (ulong4)input.c1, (ulong4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x3(short4x3 input) => new float4x3((float4)input.c0, (float4)input.c1, (float4)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4x3(short4x3 input) => new double4x3((double4)input.c0, (double4)input.c1, (double4)input.c2);


        public ref short4 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((short4*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator + (short4x3 left, short4x3 right) => new short4x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator - (short4x3 left, short4x3 right) => new short4x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator * (short4x3 left, short4x3 right) => new short4x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator / (short4x3 left, short4x3 right) => new short4x3 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator % (short4x3 left, short4x3 right) => new short4x3 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator * (short4x3 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator * (short left, short4x3 right) => new short4x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator / (short4x3 left, short right) => new short4x3 (left.c0 / right, left.c1 / right, left.c2 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator % (short4x3 left, short right) => new short4x3 (left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator & (short4x3 left, short4x3 right) => new short4x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator | (short4x3 left, short4x3 right) => new short4x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator ^ (short4x3 left, short4x3 right) => new short4x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator - (short4x3 val) => new short4x3 (-val.c0, -val.c1, -val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator ++ (short4x3 val) => new short4x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator -- (short4x3 val) => new short4x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator ~ (short4x3 val) => new short4x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator << (short4x3 x, int n) => new short4x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4x3 operator >> (short4x3 x, int n) => new short4x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator == (short4x3 left, short4x3 right) => new bool4x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator < (short4x3 left, short4x3 right) => new bool4x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator > (short4x3 left, short4x3 right) => new bool4x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator != (short4x3 left, short4x3 right) => new bool4x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator <= (short4x3 left, short4x3 right) => new bool4x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x3 operator >= (short4x3 left, short4x3 right) => new bool4x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short4x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((short4x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ c2.GetHashCode();


        public override string ToString() => $"short4x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z},  {c0.w}, {c1.w}, {c2.w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short4x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)},  {c0.w.ToString(format, formatProvider)}, {c1.w.ToString(format, formatProvider)}, {c2.w.ToString(format, formatProvider)})";
    }
}