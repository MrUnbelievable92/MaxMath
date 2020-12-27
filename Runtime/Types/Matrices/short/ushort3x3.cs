using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Sequential, Size = 18)]
    unsafe public struct ushort3x3 : IEquatable<ushort3x3>, IFormattable
    {
        public ushort3 c0;
        public ushort3 c1;
        public ushort3 c2;


        public static ushort3x3 identity => new ushort3x3(1, 0, 0,   0, 1, 0,   0, 0, 1);

        public static ushort3x3 zero => default(ushort3x3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3x3(ushort3 c0, ushort3 c1, ushort3 c2)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3x3(ushort m00, ushort m01, ushort m02,
                         ushort m10, ushort m11, ushort m12,
                         ushort m20, ushort m21, ushort m22)
        {
            this.c0 = new ushort3(m00, m10, m20);
            this.c1 = new ushort3(m01, m11, m21);
            this.c2 = new ushort3(m02, m12, m22);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3x3(ushort v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3x3(ushort v) => new ushort3x3(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(short3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(int3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(uint3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(long3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(ulong3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(float3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3x3(double3x3 input) => new ushort3x3((ushort3)input.c0, (ushort3)input.c1, (ushort3)input.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3x3(ushort3x3 input) => new int3x3((int3)input.c0, (int3)input.c1, (int3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3x3(ushort3x3 input) => new uint3x3((uint3)input.c0, (uint3)input.c1, (uint3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3x3(ushort3x3 input) => new long3x3((long3)input.c0, (long3)input.c1, (long3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3x3(ushort3x3 input) => new ulong3x3((ulong3)input.c0, (ulong3)input.c1, (ulong3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3x3(ushort3x3 input) => new float3x3((float3)input.c0, (float3)input.c1, (float3)input.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3x3(ushort3x3 input) => new double3x3((double3)input.c0, (double3)input.c1, (double3)input.c2);


        public ref ushort3 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ref ((ushort3*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator + (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 + rhs.c0, lhs.c1 + rhs.c1, lhs.c2 + rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator - (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 - rhs.c0, lhs.c1 - rhs.c1, lhs.c2 - rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator * (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3(lhs.c0 * rhs.c0, lhs.c1 * rhs.c1, lhs.c2 * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator / (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 / rhs.c0, lhs.c1 / rhs.c1, lhs.c2 / rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator % (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 % rhs.c0, lhs.c1 % rhs.c1, lhs.c2 % rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator * (ushort3x3 lhs, ushort rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator * (ushort lhs, ushort3x3 rhs) => new ushort3x3 (lhs * rhs.c0, lhs * rhs.c1, lhs * rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator / (ushort3x3 lhs, ushort rhs) => new ushort3x3 (lhs.c0 / rhs, lhs.c1 / rhs, lhs.c2 / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator % (ushort3x3 lhs, ushort rhs) => new ushort3x3 (lhs.c0 % rhs, lhs.c1 % rhs, lhs.c2 % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator & (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 & rhs.c0, lhs.c1 & rhs.c1, lhs.c2 & rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator | (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 | rhs.c0, lhs.c1 | rhs.c1, lhs.c2 | rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator ^ (ushort3x3 lhs, ushort3x3 rhs) => new ushort3x3 (lhs.c0 ^ rhs.c0, lhs.c1 ^ rhs.c1, lhs.c2 ^ rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator ++ (ushort3x3 val) => new ushort3x3 (++val.c0, ++val.c1, ++val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator -- (ushort3x3 val) => new ushort3x3 (--val.c0, --val.c1, --val.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator ~ (ushort3x3 val) => new ushort3x3 (~val.c0, ~val.c1, ~val.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator << (ushort3x3 x, int n) => new ushort3x3 (x.c0 << n, x.c1 << n, x.c2 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3x3 operator >> (ushort3x3 x, int n) => new ushort3x3 (x.c0 >> n, x.c1 >> n, x.c2 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator == (ushort3x3 lhs, ushort3x3 rhs) => new bool3x3 (lhs.c0 == rhs.c0, lhs.c1 == rhs.c1, lhs.c2 == rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator < (ushort3x3 lhs, ushort3x3 rhs) => new bool3x3 (lhs.c0 < rhs.c0, lhs.c1 < rhs.c1, lhs.c2 < rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator > (ushort3x3 lhs, ushort3x3 rhs) => new bool3x3 (lhs.c0 > rhs.c0, lhs.c1 > rhs.c1, lhs.c2 > rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator != (ushort3x3 lhs, ushort3x3 rhs) => new bool3x3 (lhs.c0 != rhs.c0, lhs.c1 != rhs.c1, lhs.c2 != rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator <= (ushort3x3 lhs, ushort3x3 rhs) => new bool3x3 (lhs.c0 <= rhs.c0, lhs.c1 <= rhs.c1, lhs.c2 <= rhs.c2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3x3 operator >= (ushort3x3 lhs, ushort3x3 rhs) => new bool3x3 (lhs.c0 >= rhs.c0, lhs.c1 >= rhs.c1, lhs.c2 >= rhs.c2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort3x3 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1) & this.c2.Equals(other.c2);
        public override bool Equals(object obj) => Equals((ushort3x3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() << 8);


        public override string ToString() => $"ushort3x3({c0.x}, {c1.x}, {c2.x},  {c0.y}, {c1.y}, {c2.y},  {c0.z}, {c1.z}, {c2.z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort3x3({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)},  {c0.z.ToString(format, formatProvider)}, {c1.z.ToString(format, formatProvider)}, {c2.z.ToString(format, formatProvider)})";
    }
}