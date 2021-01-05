using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 2)]
    unsafe public struct byte2 : IEquatable<byte2>, IFormattable
    {
        [NoAlias] public byte x;
        [NoAlias] public byte y;


        public static byte2 zero => default(byte2);


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
        public byte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public byte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public byte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }                  
        public byte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public byte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public byte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public byte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public byte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public byte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }

        public byte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public byte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }               
        public byte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public byte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public byte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public byte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public byte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }

        public byte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public byte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte2 input) => new v128(*(short*)&input, 0, 0, 0, 0, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte2(v128 input) { short x = input.SShort0; return *(byte2*)&x; }

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
        public static implicit operator float2(byte2 input) { v128 temp = Cast.ByteToFloat(input); return *(float2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(byte2 input) => (double2)(int2)input;


        public byte this[int index]
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
        public static byte2 operator + (byte2 left, byte2 right) => Sse2.add_epi8(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator - (byte2 left, byte2 right) => Sse2.sub_epi8(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator * (byte2 left, byte2 right) => (byte2)((short2)left * (short2)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator / (byte2 left, byte2 right) => Operator.vdiv_byte(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator % (byte2 left, byte2 right) => Operator.vrem_byte(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator & (byte2 left, byte2 right) => Sse2.and_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator | (byte2 left, byte2 right) => Sse2.or_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 operator ^ (byte2 left, byte2 right) => Sse2.xor_si128(left, right);
    
    
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
        public static bool2 operator == (byte2 left, byte2 right) => TestIsTrue(Sse2.cmpeq_epi8(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (byte2 left, byte2 right) => TestIsTrue(Operator.greater_mask_byte(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (byte2 left, byte2 right) => TestIsTrue(Operator.greater_mask_byte(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (byte2 left, byte2 right) => TestIsFalse(Sse2.cmpeq_epi8(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (byte2 left, byte2 right) => TestIsFalse(Operator.greater_mask_byte(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (byte2 left, byte2 right) => TestIsFalse(Operator.greater_mask_byte(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            input = Sse2.and_si128(input, new v128(0x0101_0101));

            return *(bool2*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            input = Sse2.andnot_si128(input, new v128(0x0101_0101));

            return *(bool2*)&input;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte2 other) => maxmath.bitmask32(2 * sizeof(byte)) == (maxmath.bitmask32(2 * sizeof(byte)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi8(this, other))));

        public override bool Equals(object obj) => Equals((byte2)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => ((v128)this).UShort0;


        public override string ToString() => $"byte2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}