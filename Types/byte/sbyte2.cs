﻿using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 2)]
    unsafe public struct sbyte2 : IEquatable<sbyte2>
    {
        [FieldOffset(0)] internal short cast_short;

        [FieldOffset(0)] public sbyte x;
        [FieldOffset(1)] public sbyte y;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte x, sbyte y)
        {
            this = X86.Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte2(sbyte xy)
        {
            this = X86.Sse2.set1_epi8(xy);
        }


        #region Shuffle
        public sbyte4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public sbyte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public sbyte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
               
        public sbyte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public sbyte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public sbyte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
               
        public sbyte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public sbyte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte2 input) => X86.Sse2.set1_epi16(input.cast_short);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte2(v128 input) => new sbyte2 { cast_short = (short)X86.Sse2.extract_epi16(input, 0) };

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
        public static implicit operator short2(sbyte2 input) => X86.Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(sbyte2 input) => X86.Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(sbyte2 input) { v128 temp = X86.Sse4_1.cvtepi8_epi32(input); return *(int2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(sbyte2 input) { v128 temp = X86.Sse4_1.cvtepi8_epi32(input); return *(uint2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(sbyte2 input) => X86.Sse4_1.cvtepi8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(sbyte2 input) => X86.Sse4_1.cvtepi8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(sbyte2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(sbyte2 input) => (float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(sbyte2 input) => (double2)(int2)input;

        
        public sbyte this[[AssumeRange(0, 1)] int index]
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
        public static sbyte2 operator + (sbyte2 lhs, sbyte2 rhs) => X86.Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 lhs, sbyte2 rhs) => X86.Sse2.sub_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator * (sbyte2 lhs, sbyte2 rhs) => (sbyte2)((ushort2)lhs * (ushort2)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator / (sbyte2 lhs, sbyte2 rhs) => new sbyte2((sbyte)(lhs.x / rhs.x),    (sbyte)(lhs.y / rhs.y));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator % (sbyte2 lhs, sbyte2 rhs) => new sbyte2((sbyte)(lhs.x % rhs.x),    (sbyte)(lhs.y % rhs.y));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator & (sbyte2 lhs, sbyte2 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator | (sbyte2 lhs, sbyte2 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ^ (sbyte2 lhs, sbyte2 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator - (sbyte2 x) => X86.Ssse3.sign_epi8(x, new v128((sbyte)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ++ (sbyte2 x) => X86.Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator -- (sbyte2 x) => X86.Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator ~ (sbyte2 x) => X86.Sse2.andnot_si128(x, new v128((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator << (sbyte2 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 operator >> (sbyte2 x, int n) => (sbyte2)((short2)x >> n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (sbyte2 lhs, sbyte2 rhs) => TestIsTrue(X86.Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (sbyte2 lhs, sbyte2 rhs) => TestIsTrue(X86.Sse2.cmpgt_epi8(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (sbyte2 lhs, sbyte2 rhs) => TestIsTrue(X86.Sse2.cmpgt_epi8(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (sbyte2 lhs, sbyte2 rhs) => TestIsFalse(X86.Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (sbyte2 lhs, sbyte2 rhs) => TestIsFalse(X86.Sse2.cmpgt_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (sbyte2 lhs, sbyte2 rhs) => TestIsFalse(X86.Sse2.cmpgt_epi8(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int result = 0x0101 & X86.Sse2.extract_epi16(input, 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101, X86.Sse2.extract_epi16(input, 0));

            return *(bool2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte2 other) => maxmath.cvt_boolean(X86.Sse4_1.testc_si128(X86.Sse2.cmpeq_epi8(this, other), new v128(-1, 0, 0, 0, 0, 0, 0, 0)));

        public override bool Equals(object obj) => Equals((sbyte2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => X86.Sse2.extract_epi16(this, 0);


        public override string ToString() => $"sbyte2({x}, {y})";
    }
}