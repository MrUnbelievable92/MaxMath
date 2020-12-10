using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 2)]
    unsafe public struct byte2 : IEquatable<byte2>
    {
        [FieldOffset(0)] internal short cast_short;

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte x, byte y)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)y, (sbyte)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte2(byte xy)
        {
            this = Sse2.set1_epi8((sbyte)xy);
        }


        #region Shuffle
        public byte4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }                  
        public byte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }               
        public byte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte2 input)  => Sse2.set1_epi16(input.cast_short);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(v128 input)  => new byte2 { cast_short = (short)Sse2.extract_epi16(input, 0) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(byte input) => new byte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(sbyte2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(short2 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ushort2 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(int2 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(uint2 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(long2 input) => Cast.Long2ToByte2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(ulong2 input) => Cast.Long2ToByte2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(half2 input) => (byte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(float2 input) => (byte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(double2 input) => (byte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(byte2 input) => Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(byte2 input) => Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(byte2 input) { v128 temp = Sse4_1.cvtepu8_epi32(input);  return *(int2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(byte2 input) { v128 temp = Sse4_1.cvtepu8_epi32(input); return *(uint2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(byte2 input) => Sse4_1.cvtepu8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(byte2 input) => Sse4_1.cvtepu8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(byte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(byte2 input) => (float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(byte2 input) => (double2)(int2)input;


        public byte this[[AssumeRange(0, 1)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator + (byte2 lhs, byte2 rhs) => Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte2 lhs, byte2 rhs) => Sse2.sub_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 lhs, byte2 rhs) => (byte2)((short2)lhs * (short2)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 lhs, byte2 rhs) => new byte2((byte)(lhs.x / rhs.x),    (byte)(lhs.y / rhs.y));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 lhs, byte2 rhs) => new byte2((byte)(lhs.x % rhs.x),    (byte)(lhs.y % rhs.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 lhs, byte rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 lhs, byte rhs) => Operator.rem(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte2 lhs, byte2 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte2 lhs, byte2 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte2 lhs, byte2 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ++ (byte2 x) => Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator -- (byte2 x) => Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ~ (byte2 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator << (byte2 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator >> (byte2 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (byte2 lhs, byte2 rhs) => TestIsTrue(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (byte2 lhs, byte2 rhs) => (short2)lhs < (short2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (byte2 lhs, byte2 rhs) => (short2)lhs > (short2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (byte2 lhs, byte2 rhs) => TestIsFalse(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (byte2 lhs, byte2 rhs) => (short2)lhs <= (short2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (byte2 lhs, byte2 rhs) => (short2)lhs >= (short2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int result = 0x0101 & Sse2.extract_epi16(input, 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101, Sse2.extract_epi16(input, 0));

            return *(bool2*)&result;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte2 other) => maxmath.cvt_boolean(Sse4_1.testc_si128(Sse2.cmpeq_epi8(this, other), new v128(-1, 0, 0, 0, 0, 0, 0, 0)));

        public override bool Equals(object obj) => Equals((byte2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Sse2.extract_epi16(this, 0);


        public override string ToString() => $"byte2({x}, {y})";
    }
}