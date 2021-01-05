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
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 4)]
    unsafe public struct ushort2 : IEquatable<ushort2>, IFormattable
    {
        [NoAlias] public ushort x;
        [NoAlias] public ushort y;


        public static ushort2 zero => default(ushort2);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort x, ushort y)
        {
            this = Sse2.set_epi16(0, 0, 0, 0, 0, 0, (short)y, (short)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort xy)
        {
            this = Sse2.set1_epi16((short)xy);
        }


        #region Shuffle
        public ushort4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public ushort4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public ushort4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public ushort4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public ushort4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public ushort4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public ushort4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public ushort4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public ushort4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public ushort4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public ushort4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public ushort4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public ushort4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public ushort4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public ushort4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1)); }
               
        public ushort3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ushort3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public ushort3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ushort3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ushort3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ushort3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ushort3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }
               
        public ushort2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }
        public ushort2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static implicit operator v128(ushort2 input) => new v128(*(int*)&input, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static implicit operator ushort2(v128 input) { int x = input.SInt0; return *(ushort2*)&x; }

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
        public static implicit operator int2(ushort2 input) { v128 temp = Sse4_1.cvtepu16_epi32(input); return *(int2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(ushort2 input) { v128 temp = Sse4_1.cvtepu16_epi32(input); return *(uint2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(ushort2 input) => Sse4_1.cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ushort2 input) => Sse4_1.cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ushort2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ushort2 input) { v128 t = Cast.UShortToFloat(input); return *(float2*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ushort2 input) => (int2)input;


        public ushort this[int index]
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
        public static ushort2 operator + (ushort2 left, ushort2 right) => Sse2.add_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort2 left, ushort2 right) => Sse2.sub_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, ushort2 right) => Sse2.mullo_epi16(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, ushort2 right) => Operator.vdiv_ushort(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, ushort2 right) => Operator.vrem_ushort(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort left, ushort2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, ushort right) => (v128)((ushort8)((v128)left) * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, ushort right) => (v128)((ushort8)((v128)left) / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, ushort right) => (v128)((ushort8)((v128)left) % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 left, ushort2 right) => Sse2.and_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 left, ushort2 right) => Sse2.or_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 left, ushort2 right) => Sse2.xor_si128(left, right);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ++ (ushort2 x) => Sse2.add_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator -- (ushort2 x) => Sse2.sub_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ~ (ushort2 x) => Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator << (ushort2 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator >> (ushort2 x, int n) => Operator.shrl_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (ushort2 left, ushort2 right) => TestIsTrue(Sse2.cmpeq_epi16(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (ushort2 left, ushort2 right) => TestIsTrue(Operator.greater_mask_ushort(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (ushort2 left, ushort2 right) => TestIsTrue(Operator.greater_mask_ushort(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (ushort2 left, ushort2 right) => TestIsFalse(Sse2.cmpeq_epi16(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (ushort2 left, ushort2 right) => TestIsFalse(Operator.greater_mask_ushort(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (ushort2 left, ushort2 right) => TestIsFalse(Operator.greater_mask_ushort(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            input = Sse2.and_si128((byte2)(ushort2)input, new v128(0x0101_0101));

            return *(bool2*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            input = Sse2.andnot_si128((byte2)(ushort2)input, new v128(0x0101_0101));

            return *(bool2*)&input;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort2 other) => maxmath.bitmask32(2 * sizeof(short)) == (maxmath.bitmask32(2 * sizeof(short)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other))));

        public override bool Equals(object obj) => Equals((ushort2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Sse4_1.extract_epi32(this, 0);
    

        public override string ToString() => $"ushort2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}