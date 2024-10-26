using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Sequential, Size = 2 * 3 * sizeof(long))]
    unsafe public struct long2x3 : IEquatable<long2x3>, IFormattable
    {
        public long2 c0;
        public long2 c1;
        public long2 c2;


        public static long2x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long2 c0, long2 c1, long2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long m00, long m01, long m02,
                       long m10, long m11, long m12)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
            this.c2 = new long2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x3(long v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(long v) => new long2x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(ulong2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(int2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(uint2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x3(long2x3 input) => new int2x3((int2)input.c0, (int2)input.c1, (int2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(long2x3 input) => new uint2x3((uint2)input.c0, (uint2)input.c1, (uint2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(float2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x3(double2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(long2x3 input) => new float2x3((float2)input.c0, (float2)input.c1, (float2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x3(long2x3 input) => new double2x3((double2)input.c0, (double2)input.c1, (double2)input.c2);


        public ref long2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((long2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator + (long2x3 left, long2x3 right) => new long2x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 left, long2x3 right) => new long2x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 left, long2x3 right) => new long2x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 left, long2x3 right) => new long2x3 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 left, long2x3 right) => new long2x3 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 left, uint2x3 right) => new long2x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 left, ushort2x3 right) => new long2x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 left, byte2x3 right) => new long2x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (uint2x3 left, long2x3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (ushort2x3 left, long2x3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (byte2x3 left, long2x3 right) => right * left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long2x3 left, long right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator * (long left, long2x3 right) => new long2x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator / (long2x3 left, long right) => new long2x3 (left.c0 / right, left.c1 / right, left.c2 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator % (long2x3 left, long right) => new long2x3 (left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator & (long2x3 left, long2x3 right) => new long2x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator | (long2x3 left, long2x3 right) => new long2x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ^ (long2x3 left, long2x3 right) => new long2x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator - (long2x3 val) => new long2x3 (-val.c0, -val.c1, -val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ++ (long2x3 val) => new long2x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator -- (long2x3 val) => new long2x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator ~ (long2x3 val) => new long2x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator << (long2x3 x, int n) => new long2x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x3 operator >> (long2x3 x, int n) => new long2x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (long2x3 left, long2x3 right) => new bool2x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (long2x3 left, long2x3 right) => new bool2x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (long2x3 left, long2x3 right) => new bool2x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (long2x3 left, long2x3 right) => new bool2x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (long2x3 left, long2x3 right) => new bool2x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (long2x3 left, long2x3 right) => new bool2x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override readonly bool Equals(object obj) => obj is long2x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode() ^ c2.GetHashCode();


        public override readonly string ToString() => $"long2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}