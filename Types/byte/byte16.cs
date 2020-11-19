using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Burst;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 16)]
    unsafe public struct byte16 : IEquatable<byte16>
    {
        [NoAlias] [FieldOffset(0)]  public byte x0;
        [NoAlias] [FieldOffset(1)]  public byte x1;
        [NoAlias] [FieldOffset(2)]  public byte x2;
        [NoAlias] [FieldOffset(3)]  public byte x3;
        [NoAlias] [FieldOffset(4)]  public byte x4;
        [NoAlias] [FieldOffset(5)]  public byte x5;
        [NoAlias] [FieldOffset(6)]  public byte x6;
        [NoAlias] [FieldOffset(7)]  public byte x7;
        [NoAlias] [FieldOffset(8)]  public byte x8;
        [NoAlias] [FieldOffset(9)]  public byte x9;
        [NoAlias] [FieldOffset(10)] public byte x10;
        [NoAlias] [FieldOffset(11)] public byte x11;
        [NoAlias] [FieldOffset(12)] public byte x12;
        [NoAlias] [FieldOffset(13)] public byte x13;
        [NoAlias] [FieldOffset(14)] public byte x14;
        [NoAlias] [FieldOffset(15)] public byte x15;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15)
        {
            this = X86.Sse2.set_epi8((sbyte)x15, (sbyte)x14, (sbyte)x13, (sbyte)x12, (sbyte)x11, (sbyte)x10, (sbyte)x9, (sbyte)x8, (sbyte)x7, (sbyte)x6, (sbyte)x5, (sbyte)x4, (sbyte)x3, (sbyte)x2, (sbyte)x1, (sbyte)x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte x0x16)
        {
            this = X86.Sse2.set1_epi8((sbyte)x0x16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte2 x01, byte2 x23, byte2 x45, byte2 x67, byte2 x89, byte2 x10_11, byte2 x12_13, byte2 x14_15)
        {
            this = new byte16(new byte8(x01, x23, x45, x67), new byte8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte4 x4567, byte4 x8_9_10_11, byte4 x12_13_14_15)
        {
            this = new byte16(new byte8(x0123, x4567), new byte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte3 x456, byte3 x789, byte3 x10_11_12, byte3 x13_14_15)
        {
            this = new byte16((byte8)X86.Sse4_1.insert_epi8(X86.Sse2.unpacklo_epi32(x0123, x456), x789.x, 7),
                              new byte8(x789.yz, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte4 x3456, byte3 x789, byte3 x10_11_12, byte3 x13_14_15)
        {
            this = new byte16(new byte8(new byte4(x012, x3456.x), new byte4(x3456.yzw, x789.x)),
                              new byte8(x789.yz, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte3 x345, byte4 x6789, byte3 x10_11_12, byte3 x13_14_15)
        {
            this = new byte16(new byte8(x012, x345, x6789.xy),
                              new byte8(x6789.zw, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte3 x345, byte3 x678, byte4 x9_10_11_12, byte3 x13_14_15)
        {
            this = new byte16(new byte8(x012, x345, x678.xy),
                              new byte8(new byte4(x678.z, x9_10_11_12.xyz), new byte4(x9_10_11_12.w, x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte3 x345, byte3 x678, byte3 x9_10_11, byte4 x12_13_14_15)
        {
            this = new byte16(new byte8(x012, x345, x678.xy),
                              new byte8(new byte4(x678.z, x9_10_11), x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte8 x01234567, byte4 x8_9_10_11, byte4 x12_13_14_15)
        {
            this = new byte16(x01234567, new byte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte8 x4_5_6_7_8_9_10_11, byte4 x12_13_14_15)
        {
            this = new byte16((byte8)X86.Sse2.unpacklo_epi32(x0123, x4_5_6_7_8_9_10_11),
                              (byte8)X86.Sse2.unpacklo_epi32(X86.Sse2.bsrli_si128(x4_5_6_7_8_9_10_11, 4 * sizeof(byte)), x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte4 x4567, byte8 x8_9_10_11_12_13_14_15)
        {
            this = new byte16(new byte8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte8 x01234567, byte8 x8_9_10_11_12_13_14_15)
        {
            this = X86.Sse2.unpacklo_epi64(x01234567, x8_9_10_11_12_13_14_15);
        }


        public byte8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 3, 4, 5, 6, 7, 8, 9,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7, 8, 9, 10, 11, 12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
               
        public byte4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte4 v4_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7, 8, 9, 10, 11, 12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 v4_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte4 v4_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(9, 10, 11, 12, 13, 14, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11, 12, 13, 14, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(11, 12, 13, 14, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 0, 3)); }
               
        public byte3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(6, 7, 8, 9, 10, 11, 12, 13,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 v3_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte3 v3_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(9, 10, 11, 12, 13, 14, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11, 12, 13, 14, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(11, 12, 13, 14, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 0, 3)); }
        public byte3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(13, 14, 15, 15, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); }
               
        public byte2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 4, 5, 6, 7, 8,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 2, 1)); }
        public byte2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(3, 4, 5, 6, 7, 8, 9, 10,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(5, 6, 7, 8, 9, 10, 11, 12,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shufflelo_epi16(this, X86.Sse.SHUFFLE(0, 0, 0, 3)); }
        public byte2 v2_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(7, 8, 9, 10, 11, 12, 13, 14,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 3, 2)); }
        public byte2 v2_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(9, 10, 11, 12, 13, 14, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(10, 11, 12, 13, 14, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(11, 12, 13, 14, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); } 
        public byte2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Sse2.shuffle_epi32(this, X86.Sse.SHUFFLE(0, 0, 0, 3)); }
        public byte2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(13, 14, 15, 15, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(14, 15, 15, 15, 15, 15, 15, 15,   0, 0, 0, 0, 0, 0, 0, 0)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse4_1.stream_load_si128(void* ptr)   X86.Sse.load_ps(void* ptr)
        public static implicit operator v128(byte16 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   X86.Sse.store_ps(void* ptr, v128 x)
        public static implicit operator byte16(v128 input) => new byte16 { x0 = input.Byte0, x1 = input.Byte1, x2 = input.Byte2, x3 = input.Byte3, x4 = input.Byte4, x5 = input.Byte5, x6 = input.Byte6, x7 = input.Byte7, x8 = input.Byte8, x9 = input.Byte9, x10 = input.Byte10, x11 = input.Byte11, x12 = input.Byte12, x13 = input.Byte13, x14 = input.Byte14, x15 = input.Byte15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte16(byte input) => new byte16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(sbyte16 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(short16 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(ushort16 input) => Cast.ShortToByte(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(byte16 input) => X86.Avx2.mm256_cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort16(byte16 input) => X86.Avx2.mm256_cvtepu8_epi16(input);


        public byte this[[AssumeRange(0, 15)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 16);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 16);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator + (byte16 lhs, byte16 rhs) => X86.Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator - (byte16 lhs, byte16 rhs) => X86.Sse2.sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator * (byte16 lhs, byte16 rhs) => (byte16)((ushort16)lhs * (ushort16)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator / (byte16 lhs, byte16 rhs) => Operator.div_byte(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator % (byte16 lhs, byte16 rhs) => Operator.rem_byte(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator & (byte16 lhs, byte16 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator | (byte16 lhs, byte16 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator ^ (byte16 lhs, byte16 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator ++ (byte16 x) => X86.Sse2.add_epi8(x, new v128((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator -- (byte16 x) => X86.Sse2.sub_epi8(x, new v128((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator ~ (byte16 x) => X86.Sse2.andnot_si128(x, new v128((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator << (byte16 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator >> (byte16 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator == (byte16 lhs, byte16 rhs) => TestIsTrue(X86.Sse2.cmpeq_epi8(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator < (byte16 lhs, byte16 rhs) => (short16)lhs < (short16)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator > (byte16 lhs, byte16 rhs) => (short16)lhs > (short16)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator != (byte16 lhs, byte16 rhs) => TestIsFalse(X86.Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator <= (byte16 lhs, byte16 rhs) => (short16)lhs <= (short16)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4x4 operator >= (byte16 lhs, byte16 rhs) => (short16)lhs >= (short16)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4x4 TestIsTrue(v128 input)
        {
            input = X86.Sse2.and_si128(new v128((sbyte)1), input);

            return *(bool4x4*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4x4 TestIsFalse(v128 input)
        {
            input = X86.Sse2.andnot_si128(input, new v128((byte)1));

            return *(bool4x4*)&input;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte16 other) => maxmath.cvt_boolean(X86.Sse4_1.test_all_ones(X86.Sse2.cmpeq_epi8(this, other)));

        public override bool Equals(object obj) => Equals((byte16)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._128bit(this);


        public override string ToString() =>  $"byte16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
    }
}