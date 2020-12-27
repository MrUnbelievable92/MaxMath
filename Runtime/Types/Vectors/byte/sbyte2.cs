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
    unsafe public struct sbyte2 : IEquatable<sbyte2>, IFormattable
    {
        [NoAlias] public sbyte x;
        [NoAlias] public sbyte y;


        public static sbyte2 zero => default(sbyte2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte x, sbyte y)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte xy)
        {
            this = Sse2.set1_epi8(xy);
        }


        #region Shuffle
        public sbyte4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public sbyte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public sbyte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
               
        public sbyte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public sbyte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public sbyte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
               
        public sbyte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public sbyte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public sbyte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte2 input) => new v128(*(short*)&input, 0, 0, 0, 0, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(v128 input) { short x = input.SShort0; return *(sbyte2*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(sbyte input) => new sbyte2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(byte2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(short2 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ushort2 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(int2 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(uint2 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(long2 input) => Cast.Long2ToByte2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(ulong2 input) => Cast.Long2ToByte2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(half2 input) => (sbyte2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(float2 input) => (sbyte2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(double2 input) => (sbyte2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(sbyte2 input) => Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(sbyte2 input) => Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(sbyte2 input) { v128 temp = Sse4_1.cvtepi8_epi32(input); return *(int2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(sbyte2 input) { v128 temp = Sse4_1.cvtepi8_epi32(input); return *(uint2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(sbyte2 input) => Sse4_1.cvtepi8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(sbyte2 input) => Sse4_1.cvtepi8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(sbyte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(sbyte2 input) => (float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(sbyte2 input) => (double2)(int2)input;

        
        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);
                
                fixed (void* ptr = &this)
                {
                    return ((sbyte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    ((sbyte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator + (sbyte2 lhs, sbyte2 rhs) => Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 lhs, sbyte2 rhs) => Sse2.sub_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 lhs, sbyte2 rhs) => (sbyte2)((ushort2)lhs * (ushort2)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 lhs, sbyte2 rhs) => Operator.vdiv_sbyte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 lhs, sbyte2 rhs) => Operator.vrem_sbyte(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte lhs, sbyte2 rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 lhs, sbyte rhs) => (v128)((sbyte16)((v128)lhs) * rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 lhs, sbyte rhs) => (v128)((sbyte16)((v128)lhs) / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 lhs, sbyte rhs) => (v128)((sbyte16)((v128)lhs) % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator & (sbyte2 lhs, sbyte2 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte2 lhs, sbyte2 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte2 lhs, sbyte2 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 x) => Ssse3.sign_epi8(x, new v128((sbyte)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ++ (sbyte2 x) => Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator -- (sbyte2 x) => Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ~ (sbyte2 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator << (sbyte2 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator >> (sbyte2 x, int n) => (sbyte2)((short2)x >> n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (sbyte2 lhs, sbyte2 rhs) => TestIsTrue(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (sbyte2 lhs, sbyte2 rhs) => TestIsTrue(Sse2.cmpgt_epi8(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (sbyte2 lhs, sbyte2 rhs) => TestIsTrue(Sse2.cmpgt_epi8(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (sbyte2 lhs, sbyte2 rhs) => TestIsFalse(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (sbyte2 lhs, sbyte2 rhs) => TestIsFalse(Sse2.cmpgt_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (sbyte2 lhs, sbyte2 rhs) => TestIsFalse(Sse2.cmpgt_epi8(rhs, lhs));


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
        public bool Equals(sbyte2 other) => maxmath.bitmask32(2 * sizeof(sbyte)) == (maxmath.bitmask32(2 * sizeof(sbyte)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi8(this, other))));

        public override bool Equals(object obj) => Equals((sbyte2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => ((v128)this).UShort0;


        public override string ToString() => $"sbyte2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}