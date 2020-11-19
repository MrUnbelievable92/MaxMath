using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 4)]
    unsafe public struct ushort2 : IEquatable<ushort2>
    {
        [FieldOffset(0)] internal int cast_int;

        [FieldOffset(0)] public ushort x;
        [FieldOffset(2)] public ushort y;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort x, ushort y)
        {
            this = X86.Sse2.set_epi16(0, 0, 0, 0, 0, 0, (short)y, (short)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort xy)
        {
            this = X86.Sse2.set1_epi16((short)xy);
        }


        #region Shuffle
        public ushort4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public ushort4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 0, 1)); }
        public ushort4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 1, 0)); }
        public ushort4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 1, 0, 0)); }
        public ushort4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 0, 0, 0)); }
        public ushort4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 1, 1)); }
        public ushort4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 1, 0, 1)); }
        public ushort4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 0, 0, 1)); }
        public ushort4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 1, 1, 0)); }
        public ushort4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastd_epi32(this); }
        public ushort4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 1, 0, 0)); }
        public ushort4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 1, 1, 1)); }
        public ushort4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 0, 1, 1)); }
        public ushort4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 1, 0, 1)); }
        public ushort4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 1, 1, 0)); }
        public ushort4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(1, 1, 1, 1)); }
               
        public ushort3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public ushort3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 0, 0, 1)); }
        public ushort3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastd_epi32(this); }
        public ushort3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 1, 0, 0)); }
        public ushort3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 0, 1, 1)); }
        public ushort3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 1, 0, 1)); }
        public ushort3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 1, 1, 0)); }
        public ushort3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 1, 1, 1)); }
               
        public ushort2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public ushort2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 3, 0, 1)); }
        public ushort2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(3, 3, 1, 1)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static implicit operator v128(ushort2 input) => X86.Sse2.set1_epi32(input.cast_int);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static implicit operator ushort2(v128 input) => new ushort2 { cast_int = X86.Sse4_1.extract_epi32(input, 0) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(ushort input) => new ushort2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(short2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(int2 input) => Cast.Int2ToShort2(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(uint2 input) => Cast.Int2ToShort2(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(long2 input) => Cast.Long2ToShort2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(ulong2 input) => Cast.Long2ToShort2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(half2 input) => (ushort2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(float2 input) => (ushort2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(double2 input) => (ushort2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(ushort2 input) { v128 temp = X86.Sse4_1.cvtepu16_epi32(input); return *(int2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(ushort2 input) { v128 temp = X86.Sse4_1.cvtepu16_epi32(input); return *(uint2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(ushort2 input) => X86.Sse4_1.cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ushort2 input) => X86.Sse4_1.cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ushort2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ushort2 input) { v128 t = Cast.UShortToFloat(input); return *(float2*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ushort2 input) => (int2)input;


        public ushort this[[AssumeRange(0, 1)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);
                
                fixed (void* ptr = &this)
                {
                    return ((ushort*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    ((ushort*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (ushort2 lhs, ushort2 rhs) => X86.Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort2 lhs, ushort2 rhs) => X86.Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 lhs, ushort2 rhs) => X86.Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 lhs, ushort2 rhs) => new ushort2((ushort)(lhs.x / rhs.x), (ushort)(lhs.y / rhs.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 lhs, ushort2 rhs) => new ushort2((ushort)(lhs.x % rhs.x),    (ushort)(lhs.y % rhs.y));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 lhs, ushort rhs) => (v128)maxmath.idiv((v128)lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 lhs, ushort rhs) => throw new NotImplementedException();
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 lhs, ushort2 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 lhs, ushort2 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 lhs, ushort2 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ++ (ushort2 x) => X86.Sse2.add_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator -- (ushort2 x) => X86.Sse2.sub_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ~ (ushort2 x) => X86.Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator << (ushort2 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator >> (ushort2 x, int n) => Operator.shrl_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (ushort2 lhs, ushort2 rhs) => TestIsTrue(X86.Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (ushort2 lhs, ushort2 rhs) => (int2)lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (ushort2 lhs, ushort2 rhs) => (int2)lhs > (int2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (ushort2 lhs, ushort2 rhs) => TestIsFalse(X86.Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (ushort2 lhs, ushort2 rhs) => (int2)lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (ushort2 lhs, ushort2 rhs) => (int2)lhs >= (int2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int result = 0x0101 & X86.Sse2.extract_epi16((byte2)(ushort2)input, 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101, X86.Sse2.extract_epi16((byte2)(ushort2)input, 0));

            return *(bool2*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort2 other) => maxmath.cvt_boolean(X86.Sse4_1.testc_si128(X86.Sse2.cmpeq_epi16(this, other), new v128(-1, -1, 0, 0, 0, 0, 0, 0)));

        public override bool Equals(object obj) => Equals((ushort2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => X86.Sse4_1.extract_epi32(this, 0);
    

        public override string ToString() => $"ushort2({x}, {y})";
    }
}