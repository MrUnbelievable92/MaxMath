using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 12)]
    unsafe public struct short2x3 : IEquatable<short2x3>, IFormattable
    {
        public short2 c0;
        public short2 c1;
        public short2 c2;


        public static short2x3 zero => default(short2x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short2 c0, short2 c1, short2 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short m00, short m01, short m02,
                         short m10, short m11, short m12)
        {
            this.c0 = new short2(m00, m10);
            this.c1 = new short2(m01, m11);
            this.c2 = new short2(m02, m12);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2x3(short v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x3(short v) => new short2x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ushort2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(int2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(uint2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(long2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(ulong2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(float2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2x3(double2x3 input) => new short2x3((short2)input.c0, (short2)input.c1, (short2)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x3(short2x3 input) => new int2x3((int2)input.c0, (int2)input.c1, (int2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x3(short2x3 input) => new uint2x3((uint2)input.c0, (uint2)input.c1, (uint2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x3(short2x3 input) => new long2x3((long2)input.c0, (long2)input.c1, (long2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2x3(short2x3 input) => new ulong2x3((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x3(short2x3 input) => new float2x3((float2)input.c0, (float2)input.c1, (float2)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x3(short2x3 input) => new double2x3((double2)input.c0, (double2)input.c1, (double2)input.c2);


        public ref short2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((short2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator + (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, short2x3 rhs) => new short2x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short2x3 lhs, short rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator * (short lhs, short2x3 rhs) => new short2x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator / (short2x3 lhs, short rhs) => new short2x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator % (short2x3 lhs, short rhs) => new short2x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator & (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator | (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ^ (short2x3 lhs, short2x3 rhs) => new short2x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator - (short2x3 val) => new short2x3(-val.c0, -val.c1, -val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ++ (short2x3 val) => new short2x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator -- (short2x3 val) => new short2x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator ~ (short2x3 val) => new short2x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator << (short2x3 x, int n) => new short2x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2x3 operator >> (short2x3 x, int n) => new short2x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator == (short2x3 lhs, short2x3 rhs) => new bool2x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator < (short2x3 lhs, short2x3 rhs) => new bool2x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator > (short2x3 lhs, short2x3 rhs) => new bool2x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator != (short2x3 lhs, short2x3 rhs) => new bool2x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator <= (short2x3 lhs, short2x3 rhs) => new bool2x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x3 operator >= (short2x3 lhs, short2x3 rhs) => new bool2x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short2x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((short2x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode() ^ c2.GetHashCode();


        public override string ToString() => $"short2x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short2x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)})";
    }
}