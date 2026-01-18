using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Sequential, Size = 2 * 2 * sizeof(long))]
    unsafe public struct long2x2 : IEquatable<long2x2>, IFormattable
    {
        public long2 c0;
        public long2 c1;


        public static long2x2 identity => new long2x2(1, 0,   0, 1);

        public static long2x2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long2 c0, long2 c1)
        {
            this.c0 = c0;
            this.c1 = c1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long m00, long m01,
                       long m10, long m11)
        {
            this.c0 = new long2(m00, m10);
            this.c1 = new long2(m01, m11);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long2x2(long v)
        {
            this.c0 = v;
            this.c1 = v;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(long v) => new long2x2(v);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(ulong2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(int2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2x2(uint2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2x2(long2x2 input) => new int2x2((int2)input.c0, (int2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2x2(long2x2 input) => new uint2x2((uint2)input.c0, (uint2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(float2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2x2(double2x2 input) => new long2x2((long2)input.c0, (long2)input.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2x2(long2x2 input) => new float2x2((float2)input.c0, (float2)input.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2x2(long2x2 input) => new double2x2((double2)input.c0, (double2)input.c1);


        public ref long2 this[int index]
        {
            get
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    return ref ((long2*)ptr)[index];
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator + (long2x2 left, long2x2 right) => new long2x2 (left.c0 + right.c0, left.c1 + right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 left, long2x2 right) => new long2x2 (left.c0 - right.c0, left.c1 - right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 left, long2x2 right) => new long2x2(left.c0 * right.c0, left.c1 * right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, byte2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, ushort2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, uint2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, sbyte2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, short2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, int2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, long2x2 right) => new long2x2 (left.c0 / right.c0, left.c1 / right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, byte2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, ushort2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, uint2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, sbyte2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, short2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, int2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, long2x2 right) => new long2x2 (left.c0 % right.c0, left.c1 % right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 left, uint2x2 right) => new long2x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 left, ushort2x2 right) => new long2x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 left, byte2x2 right) => new long2x2(left.c0 * right.c0, left.c1 * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (uint2x2 left, long2x2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (ushort2x2 left, long2x2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (byte2x2 left, long2x2 right) => right * left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long2x2 left, long right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator * (long left, long2x2 right) => new long2x2 (left * right.c0, left * right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, byte right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, ushort right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, uint right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, sbyte right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, short right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, int right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator / (long2x2 left, long right) => new long2x2 (left.c0 / right, left.c1 / right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, byte right) => new long2x2 (left.c0 % right, left.c1 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, ushort right) => new long2x2 (left.c0 % right, left.c1 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, uint right) => new long2x2 (left.c0 % right, left.c1 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, sbyte right) => new long2x2 (left.c0 % right, left.c1 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, short right) => new long2x2 (left.c0 % right, left.c1 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, int right) => new long2x2 (left.c0 % right, left.c1 % right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator % (long2x2 left, long right) => new long2x2 (left.c0 % right, left.c1 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator & (long2x2 left, long2x2 right) => new long2x2 (left.c0 & right.c0, left.c1 & right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator | (long2x2 left, long2x2 right) => new long2x2 (left.c0 | right.c0, left.c1 | right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ^ (long2x2 left, long2x2 right) => new long2x2 (left.c0 ^ right.c0, left.c1 ^ right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator - (long2x2 val) => new long2x2(-val.c0, -val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ++ (long2x2 val) => new long2x2 (++val.c0, ++val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator -- (long2x2 val) => new long2x2 (--val.c0, --val.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator ~ (long2x2 val) => new long2x2 (~val.c0, ~val.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator << (long2x2 x, int n) => new long2x2 (x.c0 << n, x.c1 << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2x2 operator >> (long2x2 x, int n) => new long2x2 (x.c0 >> n, x.c1 >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator == (long2x2 left, long2x2 right) => new bool2x2 (left.c0 == right.c0, left.c1 == right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator < (long2x2 left, long2x2 right) => new bool2x2 (left.c0 < right.c0, left.c1 < right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator > (long2x2 left, long2x2 right) => new bool2x2 (left.c0 > right.c0, left.c1 > right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator != (long2x2 left, long2x2 right) => new bool2x2 (left.c0 != right.c0, left.c1 != right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator <= (long2x2 left, long2x2 right) => new bool2x2 (left.c0 <= right.c0, left.c1 <= right.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2x2 operator >= (long2x2 left, long2x2 right) => new bool2x2 (left.c0 >= right.c0, left.c1 >= right.c1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long2x2 other) => this.c0.Equals(other.c0) & this.c1.Equals(other.c1);
        public override readonly bool Equals(object obj) => obj is long2x2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => c0.GetHashCode() ^ c1.GetHashCode();


        public override readonly string ToString() => $"long2x2({c0.x}, {c1.x},  {c0.y}, {c1.y})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long2x2({c0.x.ToString(format, formatProvider)}, {c1.x.ToString(format, formatProvider)},  {c0.y.ToString(format, formatProvider)}, {c1.y.ToString(format, formatProvider)})";
    }
}