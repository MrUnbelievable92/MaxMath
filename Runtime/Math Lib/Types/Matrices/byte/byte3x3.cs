using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Sequential, Size = 3 * 3 * sizeof(byte))]
    unsafe public struct byte3x3 : IEquatable<byte3x3>, IFormattable
    {
        public byte3 c0;
        public byte3 c1;
        public byte3 c2;


        public static byte3x3 identity => new byte3x3(1, 0, 0,   0, 1, 0,   0, 0, 1);

        public static byte3x3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3x3(byte3 c0, byte3 c1, byte3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3x3(byte m00, byte m01, byte m02,
                       byte m10, byte m11, byte m12,
                       byte m20, byte m21, byte m22)
        {
            this.c0 = new byte3(m00, m10, m20);
            this.c1 = new byte3(m01, m11, m21);
            this.c2 = new byte3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3x3(byte v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3x3(byte v) => new byte3x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(sbyte3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(short3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(ushort3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(int3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(uint3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(long3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(ulong3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(float3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3x3(double3x3 input) => new byte3x3((byte3)input.c0, (byte3)input.c1, (byte3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3x3(byte3x3 input) => new short3x3((short3)input.c0, (short3)input.c1, (short3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3x3(byte3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x3(byte3x3 input) => new int3x3((int3)input.c0, (int3)input.c1, (int3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x3(byte3x3 input) => new uint3x3((uint3)input.c0, (uint3)input.c1, (uint3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x3(byte3x3 input) => new long3x3((long3)input.c0, (long3)input.c1, (long3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x3(byte3x3 input) => new ulong3x3((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x3(byte3x3 input) => new float3x3((float3)input.c0, (float3)input.c1, (float3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(byte3x3 input) => new double3x3((double3)input.c0, (double3)input.c1, (double3)input.c2);


        public ref byte3 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((byte3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator + (byte3x3 left, byte3x3 right) => new byte3x3 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator - (byte3x3 left, byte3x3 right) => new byte3x3 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator * (byte3x3 left, byte3x3 right) => new byte3x3(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator / (byte3x3 left, byte3x3 right) => new byte3x3(left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator % (byte3x3 left, byte3x3 right) => new byte3x3(left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator * (byte3x3 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator * (byte left, byte3x3 right) => new byte3x3 (left * right.c0, left * right.c1, left * right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator / (byte3x3 left, byte right) => new byte3x3(left.c0 / right, left.c1 / right, left.c2 / right); 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator % (byte3x3 left, byte right) => new byte3x3(left.c0 % right, left.c1 % right, left.c2 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator & (byte3x3 left, byte3x3 right) => new byte3x3 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator | (byte3x3 left, byte3x3 right) => new byte3x3 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator ^ (byte3x3 left, byte3x3 right) => new byte3x3 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator ++ (byte3x3 val) => new byte3x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator -- (byte3x3 val) => new byte3x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator ~ (byte3x3 val) => new byte3x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator << (byte3x3 x, int n) => new byte3x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3x3 operator >> (byte3x3 x, int n) => new byte3x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (byte3x3 left, byte3x3 right) => new bool3x3 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (byte3x3 left, byte3x3 right) => new bool3x3 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (byte3x3 left, byte3x3 right) => new bool3x3 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (byte3x3 left, byte3x3 right) => new bool3x3 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (byte3x3 left, byte3x3 right) => new bool3x3 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (byte3x3 left, byte3x3 right) => new bool3x3 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte3x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override readonly bool Equals(object obj) => obj is byte3x3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() << 8);


        public override readonly string ToString() => $"byte3x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte3x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)})";
    }
}