using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Sequential, Size = 2 * 4 * sizeof(long))]
    unsafe public struct long2x4 : IEquatable<long2x4>, IFormattable
    {
        public long2 c0;
        public long2 c1;
        public long2 c2;
        public long2 c3;


        public static long2x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long2 c0, long2 c1, long2 c2, long2 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long m00, long m01, long m02, long m03,
                       long m10, long m11, long m12, long m13)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
            this.c2 = new long2(m02, m12);
            this.c3 = new long2(m03, m13);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x4(long v)
        {
            this.c0 = v;
            this.c1 = v;
            this.c2 = v;
            this.c3 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(long v) => new long2x4(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(ulong2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(int2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x4(uint2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x4(long2x4 input) => new int2x4((int2)input.c0, (int2)input.c1, (int2)input.c2, (int2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x4(long2x4 input) => new uint2x4((uint2)input.c0, (uint2)input.c1, (uint2)input.c2, (uint2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(float2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x4(double2x4 input) => new long2x4((long2)input.c0, (long2)input.c1, (long2)input.c2, (long2)input.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x4(long2x4 input) => new float2x4((float2)input.c0, (float2)input.c1, (float2)input.c2, (float2)input.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x4(long2x4 input) => new double2x4((double2)input.c0, (double2)input.c1, (double2)input.c2, (double2)input.c3);


        public ref long2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ref ((long2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator + (long2x4 left, long2x4 right) => new long2x4 (left.c0 + right.c0, left.c1 + right.c1, left.c2 + right.c2, left.c3 + right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 left, long2x4 right) => new long2x4 (left.c0 - right.c0, left.c1 - right.c1, left.c2 - right.c2, left.c3 - right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 left, long2x4 right) => new long2x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, byte2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, ushort2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, uint2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, sbyte2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, short2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, int2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, long2x4 right) => new long2x4 (left.c0 / right.c0, left.c1 / right.c1, left.c2 / right.c2, left.c3 / right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, byte2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, ushort2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, uint2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, sbyte2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, short2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, int2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, long2x4 right) => new long2x4 (left.c0 % right.c0, left.c1 % right.c1, left.c2 % right.c2, left.c3 % right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 left, uint2x4 right) => new long2x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 left, ushort2x4 right) => new long2x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 left, byte2x4 right) => new long2x4(left.c0 * right.c0, left.c1 * right.c1, left.c2 * right.c2, left.c3 * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (uint2x4 left, long2x4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (ushort2x4 left, long2x4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (byte2x4 left, long2x4 right) => right * left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long2x4 left, long right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator * (long left, long2x4 right) => new long2x4 (left * right.c0, left * right.c1, left * right.c2, left * right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, byte right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, ushort right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, uint right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, sbyte right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, short right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, int right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator / (long2x4 left, long right) => new long2x4 (left.c0 / right, left.c1 / right, left.c2 / right, left.c3 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, byte right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, ushort right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, uint right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, sbyte right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, short right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, int right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator % (long2x4 left, long right) => new long2x4 (left.c0 % right, left.c1 % right, left.c2 % right, left.c3 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator & (long2x4 left, long2x4 right) => new long2x4 (left.c0 & right.c0, left.c1 & right.c1, left.c2 & right.c2, left.c3 & right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator | (long2x4 left, long2x4 right) => new long2x4 (left.c0 | right.c0, left.c1 | right.c1, left.c2 | right.c2, left.c3 | right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ^ (long2x4 left, long2x4 right) => new long2x4 (left.c0 ^ right.c0, left.c1 ^ right.c1, left.c2 ^ right.c2, left.c3 ^ right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator - (long2x4 val) => new long2x4(-val.c0, -val.c1, -val.c2, -val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ++ (long2x4 val) => new long2x4 (++val.c0, ++val.c1, ++val.c2, ++val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator -- (long2x4 val) => new long2x4 (--val.c0, --val.c1, --val.c2, --val.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator ~ (long2x4 val) => new long2x4 (~val.c0, ~val.c1, ~val.c2, ~val.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator << (long2x4 x, int n) => new long2x4 (x.c0 << n, x.c1 << n, x.c2 << n, x.c3 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x4 operator >> (long2x4 x, int n) => new long2x4 (x.c0 >> n, x.c1 >> n, x.c2 >> n, x.c3 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator == (long2x4 left, long2x4 right) => new bool2x4 (left.c0 == right.c0, left.c1 == right.c1, left.c2 == right.c2, left.c3 == right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator < (long2x4 left, long2x4 right) => new bool2x4 (left.c0 < right.c0, left.c1 < right.c1, left.c2 < right.c2, left.c3 < right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator > (long2x4 left, long2x4 right) => new bool2x4 (left.c0 > right.c0, left.c1 > right.c1, left.c2 > right.c2, left.c3 > right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator != (long2x4 left, long2x4 right) => new bool2x4 (left.c0 != right.c0, left.c1 != right.c1, left.c2 != right.c2, left.c3 != right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator <= (long2x4 left, long2x4 right) => new bool2x4 (left.c0 <= right.c0, left.c1 <= right.c1, left.c2 <= right.c2, left.c3 <= right.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x4 operator >= (long2x4 left, long2x4 right) => new bool2x4 (left.c0 >= right.c0, left.c1 >= right.c1, left.c2 >= right.c2, left.c3 >= right.c3);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2x4 other) => (this.c0.Equals(other.c0) & this.c1.Equals(other.c1)) & (this.c2.Equals(other.c2) & this.c3.Equals(other.c3));
        public override readonly bool Equals(object obj) => obj is long2x4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (c0.GetHashCode() ^ c1.GetHashCode()) ^ (c2.GetHashCode() ^ c3.GetHashCode());


        public override readonly string ToString() => $"long2x4({c0.x}, {c1.x}, {c2.x}, {c3.x},  {c0.y}, {c1.y}, {c2.y}, {c3.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2x4({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)}, {c2.x.ToString(format, formatProvider)}, {c3.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)}, {c2.y.ToString(format, formatProvider)}, {c3.y.ToString(format, formatProvider)})";
    }
}