using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 8)]
    unsafe public struct byte2x4 : IEquatable<byte2x4>, IFormattable
    {
        public byte2 c0;
        public byte2 c1;
        public byte2 c2;
        public byte2 c3;


        public static byte2x4 zero => default(byte2x4);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2x4(byte2 c0, byte2 c1, byte2 c2, byte2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2x4(byte m00, byte m01, byte m02, byte m03,
                       byte m10, byte m11, byte m12, byte m13)
        {
            this.c0 = new byte2(m00, m10);
            this.c1 = new byte2(m01, m11);
            this.c2 = new byte2(m02, m12);
            this.c3 = new byte2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2x4(byte v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2x4(byte v) => new byte2x4(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(sbyte2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(short2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(ushort2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(int2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(uint2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(long2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(ulong2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(float2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2x4(double2x4 input) => new byte2x4((byte2)input.c0, (byte2)input.c1, (byte2)input.c2, (byte2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2x4(byte2x4 input) => new short2x4((short2)input.c0, (short2)input.c1, (short2)input.c2, (short2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2x4(byte2x4 input) => new ushort2x4((ushort2)input.c0, (ushort2)input.c1, (ushort2)input.c2, (ushort2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2x4(byte2x4 input) => new int2x4((int2)input.c0, (int2)input.c1, (int2)input.c2, (int2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2x4(byte2x4 input) => new uint2x4((uint2)input.c0, (uint2)input.c1, (uint2)input.c2, (uint2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(byte2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2x4(byte2x4 input) => new ulong2x4((ulong2)input.c0, (ulong2)input.c1, (ulong2)input.c2, (ulong2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x4(byte2x4 input) => new float2x4((float2)input.c0, (float2)input.c1, (float2)input.c2, (float2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x4(byte2x4 input) => new double2x4((double2)input.c0, (double2)input.c1, (double2)input.c2, (double2)input.c3);


        public ref byte2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ref ((byte2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator + (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2, lhs.c3 + rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator - (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2, lhs.c3 - rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator * (byte2x4 lhs, byte2x4 rhs) => new byte2x4(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2, lhs.c3 * rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator / (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2, lhs.c3 / rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator % (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2, lhs.c3 % rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator * (byte2x4 lhs, byte rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator * (byte lhs, byte2x4 rhs) => new byte2x4 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2, lhs * rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator / (byte2x4 lhs, byte rhs) => new byte2x4 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs, lhs.c3 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator % (byte2x4 lhs, byte rhs) => new byte2x4 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs, lhs.c3 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator & (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2, lhs.c3 & rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator | (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2, lhs.c3 | rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator ^ (byte2x4 lhs, byte2x4 rhs) => new byte2x4 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2, lhs.c3 ^ rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator ++ (byte2x4 val) => new byte2x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator -- (byte2x4 val) => new byte2x4 (--val.c0, --val.c1, --val.c2, --val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator ~ (byte2x4 val) => new byte2x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator << (byte2x4 x, int n) => new byte2x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2x4 operator >> (byte2x4 x, int n) => new byte2x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (byte2x4 lhs, byte2x4 rhs) => new bool2x4 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2, lhs.c3 == rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (byte2x4 lhs, byte2x4 rhs) => new bool2x4 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2, lhs.c3 < rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (byte2x4 lhs, byte2x4 rhs) => new bool2x4 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2, lhs.c3 > rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (byte2x4 lhs, byte2x4 rhs) => new bool2x4 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2, lhs.c3 != rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (byte2x4 lhs, byte2x4 rhs) => new bool2x4 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2, lhs.c3 <= rhs.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (byte2x4 lhs, byte2x4 rhs) => new bool2x4 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2, lhs.c3 >= rhs.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte2x4 other) => (this.c0.Equals(other.c0) & this.c1.Equals(other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override bool Equals(object obj) => Equals((byte2x4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) | (c2.GetHashCode() ^ c3.GetHashCode() << 16);


        public override string ToString() => $"byte2x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte2x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)})";
    }
}