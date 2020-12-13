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
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 16)]
    unsafe public struct sbyte16 : IEquatable<sbyte16>
    {
        [NoAlias] public sbyte x0;
        [NoAlias] public sbyte x1;
        [NoAlias] public sbyte x2;
        [NoAlias] public sbyte x3;
        [NoAlias] public sbyte x4;
        [NoAlias] public sbyte x5;
        [NoAlias] public sbyte x6;
        [NoAlias] public sbyte x7;
        [NoAlias] public sbyte x8;
        [NoAlias] public sbyte x9;
        [NoAlias] public sbyte x10;
        [NoAlias] public sbyte x11;
        [NoAlias] public sbyte x12;
        [NoAlias] public sbyte x13;
        [NoAlias] public sbyte x14;
        [NoAlias] public sbyte x15;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15)
        {
            this = Sse2.set_epi8(x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte x0x16)
        {
            this = Sse2.set1_epi8(x0x16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67, sbyte2 x89, sbyte2 x10_11, sbyte2 x12_13, sbyte2 x14_15)
        {
            this = new sbyte16(new sbyte8(x01, x23, x45, x67), new sbyte8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x0123, x4567), new sbyte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte3 x456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            this = new sbyte16((sbyte8)Sse4_1.insert_epi8(Sse2.unpacklo_epi32(x0123, x456), (byte)x789.x, 7),
                               new sbyte8(x789.yz, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte4 x3456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            this = new sbyte16(new sbyte8(new sbyte4(x012, x3456.x), new sbyte4(x3456.yzw, x789.x)),
                               new sbyte8(x789.yz, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte4 x6789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            this = new sbyte16(new sbyte8(x012, x345, x6789.xy),
                               new sbyte8(x6789.zw, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte4 x9_10_11_12, sbyte3 x13_14_15)
        {
            this = new sbyte16(new sbyte8(x012, x345, x678.xy),
                               new sbyte8(new sbyte4(x678.z, x9_10_11_12.xyz), new sbyte4(x9_10_11_12.w, x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte3 x9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x012, x345, x678.xy),
                               new sbyte8(new sbyte4(x678.z, x9_10_11), x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte8 x01234567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(x01234567, new sbyte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte8 x4_5_6_7_8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16((sbyte8)Sse2.unpacklo_epi32(x0123, x4_5_6_7_8_9_10_11),
                               (sbyte8)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x4_5_6_7_8_9_10_11, 4 * sizeof(sbyte)), x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte8 x8_9_10_11_12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte8 x01234567, sbyte8 x8_9_10_11_12_13_14_15)
        {
            this = Sse2.unpacklo_epi64(x01234567, x8_9_10_11_12_13_14_15);
        }


        public sbyte8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public sbyte8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 4, 5, 6, 7, 8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(6, 7, 8, 9, 10, 11, 12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); }
               
        public sbyte4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => (v128)this; }
        public sbyte4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte4 v4_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 v4_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(6, 7, 8, 9, 10, 11, 12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 v4_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte4 v4_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte4 v4_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(9, 10, 11, 12, 13, 14, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(10, 11, 12, 13, 14, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(11, 12, 13, 14, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 0, 3)); }
               
        public sbyte3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => (v128)this; }
        public sbyte3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(6, 7, 8, 9, 10, 11, 12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte3 v3_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte3 v3_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(9, 10, 11, 12, 13, 14, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(10, 11, 12, 13, 14, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(11, 12, 13, 14, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public sbyte3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(13, 14, 15, 15, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); }
               
        public sbyte2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => (v128)this; }
        public sbyte2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public sbyte2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public sbyte2 v2_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public sbyte2 v2_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Ssse3.shuffle_epi8(this, new v128(9, 10, 11, 12, 13, 14, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(10, 11, 12, 13, 14, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(11, 12, 13, 14, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public sbyte2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public sbyte2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(13, 14, 15, 15, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public sbyte2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(14, 15, 15, 15, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v128(sbyte16 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator sbyte16(v128 input) => new sbyte16 { x0 = input.SByte0, x1 = input.SByte1, x2 = input.SByte2, x3 = input.SByte3, x4 = input.SByte4, x5 = input.SByte5, x6 = input.SByte6, x7 = input.SByte7, x8 = input.SByte8, x9 = input.SByte9, x10 = input.SByte10, x11 = input.SByte11, x12 = input.SByte12, x13 = input.SByte13, x14 = input.SByte14, x15 = input.SByte15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte16(sbyte input) => new sbyte16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(byte16 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(short16 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(ushort16 input) => Cast.ShortToByte(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(sbyte16 input) => Avx2.mm256_cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort16(sbyte16 input) => Avx2.mm256_cvtepi8_epi16(input);


        public sbyte this[[AssumeRange(0, 15)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 16);
                
                fixed (void* ptr = &this)
                {
                    return ((sbyte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 16);

                fixed (void* ptr = &this)
                {
                    ((sbyte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator + (sbyte16 lhs, sbyte16 rhs) => Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator - (sbyte16 lhs, sbyte16 rhs) => Sse2.sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte16 lhs, sbyte16 rhs) => (sbyte16)((short16)lhs * (short16)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator / (sbyte16 lhs, sbyte16 rhs) => Operator.vdiv_sbyte(lhs, rhs);
                                                                       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]             
        public static sbyte16 operator % (sbyte16 lhs, sbyte16 rhs) => Operator.vrem_sbyte(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator & (sbyte16 lhs, sbyte16 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator | (sbyte16 lhs, sbyte16 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ^ (sbyte16 lhs, sbyte16 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator - (sbyte16 x) => Ssse3.sign_epi8(x, new v128((sbyte)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ++ (sbyte16 x) => Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator -- (sbyte16 x) => Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ~ (sbyte16 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator << (sbyte16 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator >> (sbyte16 x, int n) => (sbyte16)((short16)x >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (sbyte16 lhs, sbyte16 rhs) => TestIsTrue(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (sbyte16 lhs, sbyte16 rhs) => TestIsTrue(Sse2.cmpgt_epi8(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (sbyte16 lhs, sbyte16 rhs) => TestIsTrue(Sse2.cmpgt_epi8(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (sbyte16 lhs, sbyte16 rhs) => TestIsFalse(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (sbyte16 lhs, sbyte16 rhs) => TestIsFalse(Sse2.cmpgt_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (sbyte16 lhs, sbyte16 rhs) => TestIsFalse(Sse2.cmpgt_epi8(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool16 TestIsTrue(v128 input)
        {
            return Sse2.and_si128(input, new v128((sbyte)1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool16 TestIsFalse(v128 input)
        {
            return Sse2.andnot_si128(input, new v128((sbyte)1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte16 other) => maxmath.tobool(Sse4_1.test_all_ones(Sse2.cmpeq_epi8(this, other)));

        public override bool Equals(object obj) => Equals((sbyte16)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v128(this);


        public override string ToString() => $"sbyte16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}