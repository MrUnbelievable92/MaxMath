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
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 4)]
    unsafe public struct short2 : IEquatable<short2>
    {
        [FieldOffset(0)] internal int cast_int;

        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short x, short y)
        {
            this = Sse2.set_epi16(0, 0, 0, 0, 0, 0, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short2(short xy)
        {
            this = Sse2.set1_epi16(xy);
        }


        #region Shuffle
        public short4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public short4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public short4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public short4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public short4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public short4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public short4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public short4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public short4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public short4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public short4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public short4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public short4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public short4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public short4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public short4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1)); }

        public short3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public short3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public short3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public short3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public short3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public short3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public short3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public short3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }

        public short2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public short2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public short2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator v128(short2 input) => Sse2.set1_epi32(input.cast_int);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator short2(v128 input) => new short2 { cast_int = Sse4_1.extract_epi32(input, 0) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short2(short input) => new short2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ushort2 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(int2 input) => Cast.Int2ToShort2(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(uint2 input) => Cast.Int2ToShort2(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(long2 input) => Cast.Long2ToShort2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(ulong2 input) => Cast.Long2ToShort2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(half2 input) => (short2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(float2 input) => (short2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(double2 input) => (short2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(short2 input) { v128 temp = Sse4_1.cvtepi16_epi32(input); return *(int2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(short2 input) { v128 temp = Sse4_1.cvtepi16_epi32(input); return *(uint2*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(short2 input) => Sse4_1.cvtepi16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(short2 input) => Sse4_1.cvtepi16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(short2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(short2 input) => (float2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(short2 input) => (double2)(int2)input;


        public short this[[AssumeRange(0, 1)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);
                
                fixed (void* ptr = &this)
                {
                    return ((short*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

                fixed (void* ptr = &this)
                {
                    ((short*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator + (short2 lhs, short2 rhs) => Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 lhs, short2 rhs) => Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator * (short2 lhs, short2 rhs) => Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator / (short2 lhs, short2 rhs) => new short2((short)(lhs.x / rhs.x),    (short)(lhs.y / rhs.y));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator % (short2 lhs, short2 rhs) => new short2((short)(lhs.x % rhs.x),    (short)(lhs.y % rhs.y));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator & (short2 lhs, short2 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator | (short2 lhs, short2 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ^ (short2 lhs, short2 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator - (short2 x) => Ssse3.sign_epi16(x, new v128((short)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ++ (short2 x) => Sse2.add_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator -- (short2 x) => Sse2.sub_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator ~ (short2 x) => Sse2.andnot_si128(x, new v128((short)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator <<(short2 x, int n) => Operator.shl_short(x, n);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 operator >> (short2 x, int n) => Operator.shra_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (short2 lhs, short2 rhs) => TestIsTrue(Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (short2 lhs, short2 rhs) => TestIsTrue(Sse2.cmpgt_epi16(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (short2 lhs, short2 rhs) => TestIsTrue(Sse2.cmpgt_epi16(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (short2 lhs, short2 rhs) => TestIsFalse(Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (short2 lhs, short2 rhs) => TestIsFalse(Sse2.cmpgt_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (short2 lhs, short2 rhs) => TestIsFalse(Sse2.cmpgt_epi16(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsTrue(v128 input)
        {
            int result = 0x0101 & Sse2.extract_epi16((byte2)(ushort2)input, 0);

            return *(bool2*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool2 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101, Sse2.extract_epi16((byte2)(ushort2)input, 0));

            return *(bool2*)&result;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short2 other) => maxmath.cvt_boolean(Sse4_1.testc_si128(Sse2.cmpeq_epi16(this, other), new v128(-1, -1, 0, 0, 0, 0, 0, 0)));

        public override bool Equals(object obj) => Equals((short2)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Sse4_1.extract_epi32(this, 0);


        public override string ToString() => $"short2({x}, {y})";
    }
}