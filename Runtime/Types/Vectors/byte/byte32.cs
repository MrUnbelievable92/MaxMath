using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct byte32 : IEquatable<byte32>, IFormattable
    {
        [NoAlias] public byte x0;
        [NoAlias] public byte x1;
        [NoAlias] public byte x2;
        [NoAlias] public byte x3;
        [NoAlias] public byte x4;
        [NoAlias] public byte x5;
        [NoAlias] public byte x6;
        [NoAlias] public byte x7;
        [NoAlias] public byte x8;
        [NoAlias] public byte x9;
        [NoAlias] public byte x10;
        [NoAlias] public byte x11;
        [NoAlias] public byte x12;
        [NoAlias] public byte x13;
        [NoAlias] public byte x14;
        [NoAlias] public byte x15;
        [NoAlias] public byte x16;
        [NoAlias] public byte x17;
        [NoAlias] public byte x18;
        [NoAlias] public byte x19;
        [NoAlias] public byte x20;
        [NoAlias] public byte x21;
        [NoAlias] public byte x22;
        [NoAlias] public byte x23;
        [NoAlias] public byte x24;
        [NoAlias] public byte x25;
        [NoAlias] public byte x26;
        [NoAlias] public byte x27;
        [NoAlias] public byte x28;
        [NoAlias] public byte x29;
        [NoAlias] public byte x30;
        [NoAlias] public byte x31;


        public static byte32 zero => default(byte32);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17, byte x18, byte x19, byte x20, byte x21, byte x22, byte x23, byte x24, byte x25, byte x26, byte x27, byte x28, byte x29, byte x30, byte x31)
        {
            this = Avx.mm256_set_epi8(x31, x30, x29, x28, x27, x26, x25, x24, x23, x22, x21, x20, x19, x18, x17, x16, x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0x32)
        {
            this = new v256(x0x32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte8 v8_0, byte8 v8_1, byte8 v8_2, byte8 v8_3)
        {
            this = new byte32(new byte16(v8_0, v8_1), new byte16(v8_2, v8_3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte16 v16_0, byte16 v16_1)
        {
            this = Avx.mm256_set_m128i(v16_1, v16_0);
        }


        public byte16 v16_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public byte16 v16_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 1), (byte)Avx2.mm256_extract_epi8(this, 16), 15); }
        public byte16 v16_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshr(v16_0, 2), (short)Avx2.mm256_extract_epi16(this, 8), 7); }
        public byte16 v16_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 3), maxmath.vshl(v16_16, 13), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255)); }
        public byte16 v16_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi32(maxmath.vshr(v16_0, 4), Avx.mm256_extract_epi32(this, 4), 3); }
        public byte16 v16_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 5), maxmath.vshl(v16_16, 11), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255)); }
        public byte16 v16_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 6), maxmath.vshl(v16_16, 10), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255)); }
        public byte16 v16_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 7), maxmath.vshl(v16_16, 9), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255)); }
        public byte16 v16_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi64(maxmath.vshr(v16_0, 8), Avx.mm256_extract_epi64(this, 2), 1); }
        public byte16 v16_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 9), maxmath.vshl(v16_16, 7), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public byte16 v16_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 10), maxmath.vshl(v16_16, 6), new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public byte16 v16_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 11), maxmath.vshl(v16_16, 5), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public byte16 v16_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi32(maxmath.vshl(v16_16, 4), Avx.mm256_extract_epi32(this, 3), 0); }
        public byte16 v16_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 13), maxmath.vshl(v16_16, 3), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public byte16 v16_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshl(v16_16, 2), Avx2.mm256_extract_epi16(this, 7), 0); }
        public byte16 v16_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshl(v16_16, 1), (byte)Avx2.mm256_extract_epi8(this, 15), 0); }
        public byte16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }

        public byte8 v8_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_0; }
        public byte8 v8_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_1; }
        public byte8 v8_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_2; }
        public byte8 v8_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_3; }
        public byte8 v8_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_4; }
        public byte8 v8_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_5; }
        public byte8 v8_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_6; }
        public byte8 v8_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_7; }
        public byte8 v8_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_8; }
        public byte8 v8_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 9), (byte)Avx2.mm256_extract_epi8(this, 16), 7); }
        public byte8 v8_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshr(v16_0, 10), (short)Avx2.mm256_extract_epi16(this, 8), 3); }
        public byte8 v8_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_11.v8_0; }
        public byte8 v8_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi32(maxmath.vshr(v16_0, 12), Avx.mm256_extract_epi32(this, 4), 1); }
        public byte8 v8_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_13.v8_0; }
        public byte8 v8_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_14.v8_0; }
        public byte8 v8_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_15.v8_0; }
        public byte8 v8_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_0; }
        public byte8 v8_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_1; }
        public byte8 v8_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_2; }
        public byte8 v8_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_3; }
        public byte8 v8_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_4; }
        public byte8 v8_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_5; }
        public byte8 v8_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_6; }
        public byte8 v8_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_7; }
        public byte8 v8_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_8; }

        public byte4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_0; }
        public byte4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_1; }
        public byte4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_2; }
        public byte4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_3; }
        public byte4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_4; }
        public byte4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_5; }
        public byte4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_6; }
        public byte4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_7; }
        public byte4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_8; }
        public byte4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_9; }
        public byte4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_10; }
        public byte4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_11; }
        public byte4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_12; }
        public byte4 v4_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 13), (byte)Avx2.mm256_extract_epi8(this, 16), 3); }
        public byte4 v4_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshr(v16_0, 14), (short)Avx2.mm256_extract_epi16(this, 8), 1); }
        public byte4 v4_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshl(v16_16, 1), (byte)Avx2.mm256_extract_epi8(this, 15), 0); }
        public byte4 v4_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_0; }
        public byte4 v4_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_1; }
        public byte4 v4_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_2; }
        public byte4 v4_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_3; }
        public byte4 v4_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_4; }
        public byte4 v4_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_5; }
        public byte4 v4_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_6; }
        public byte4 v4_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_7; }
        public byte4 v4_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_8; }
        public byte4 v4_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_9; }
        public byte4 v4_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_10;}
        public byte4 v4_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_11;}
        public byte4 v4_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_12; }

        public byte3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_0; }
        public byte3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_1; }
        public byte3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_2; }
        public byte3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_3; }
        public byte3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_4; }
        public byte3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_5; }
        public byte3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_6; }
        public byte3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_7; }
        public byte3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_8; }
        public byte3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_9; }
        public byte3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_10; }
        public byte3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_11; }
        public byte3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_12; }
        public byte3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_13; }
        public byte3 v3_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 14), (byte)Avx2.mm256_extract_epi8(this, 16), 2); }
        public byte3 v3_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(Sse4_1.insert_epi8(maxmath.vshr(v16_0, 15), (byte)Avx2.mm256_extract_epi8(this, 16), 1), (byte)Avx2.mm256_extract_epi8(this, 17), 2); }
        public byte3 v3_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_0; }
        public byte3 v3_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_1; }
        public byte3 v3_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_2; }
        public byte3 v3_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_3; }
        public byte3 v3_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_4; }
        public byte3 v3_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_5; }
        public byte3 v3_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_6; }
        public byte3 v3_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_7; }
        public byte3 v3_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_8; }
        public byte3 v3_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_9; }
        public byte3 v3_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_10; }
        public byte3 v3_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_11; }
        public byte3 v3_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_12; }
        public byte3 v3_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_13; }

        public byte2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_0; }
        public byte2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_1; }
        public byte2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_2; }
        public byte2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_3; }
        public byte2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_4; }
        public byte2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_5; }
        public byte2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_6; }
        public byte2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_7; }
        public byte2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_8; }
        public byte2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_9; }
        public byte2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_10; }
        public byte2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_11; }
        public byte2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_12; }
        public byte2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_13; }
        public byte2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_14; }
        public byte2 v2_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 15), (byte)Avx2.mm256_extract_epi8(this, 16), 1); }
        public byte2 v2_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_0; }
        public byte2 v2_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_1; }
        public byte2 v2_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_2; }
        public byte2 v2_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_3; }
        public byte2 v2_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_4; }
        public byte2 v2_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_5; }
        public byte2 v2_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_6; }
        public byte2 v2_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_7; }
        public byte2 v2_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_8; }
        public byte2 v2_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_9; }
        public byte2 v2_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_10; }
        public byte2 v2_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_11; }
        public byte2 v2_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_12; }
        public byte2 v2_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_13; }
        public byte2 v2_30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_14; }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(byte32 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15, input.x16, input.x17, input.x18, input.x19, input.x20, input.x21, input.x22, input.x23, input.x24, input.x25, input.x26, input.x27, input.x28, input.x29, input.x30, input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator byte32(v256 input) => new byte32 { x0 = input.Byte0, x1 = input.Byte1, x2 = input.Byte2, x3 = input.Byte3, x4 = input.Byte4, x5 = input.Byte5, x6 = input.Byte6, x7 = input.Byte7, x8 = input.Byte8, x9 = input.Byte9, x10 = input.Byte10, x11 = input.Byte11, x12 = input.Byte12, x13 = input.Byte13, x14 = input.Byte14, x15 = input.Byte15, x16 = input.Byte16, x17 = input.Byte17, x18 = input.Byte18, x19 = input.Byte19, x20 = input.Byte20, x21 = input.Byte21, x22 = input.Byte22, x23 = input.Byte23, x24 = input.Byte24, x25 = input.Byte25, x26 = input.Byte26, x27 = input.Byte27, x28 = input.Byte28, x29 = input.Byte29, x30 = input.Byte30, x31 = input.Byte31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte32(byte input) => new byte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(sbyte32 input) => (v256)input;


        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator + (byte32 left, byte32 right) => Avx2.mm256_add_epi8(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator - (byte32 left, byte32 right) => Avx2.mm256_sub_epi8(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 left, byte32 right) => Operator.mul_byte(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 left, byte32 right) => Operator.vdiv_byte(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 left, byte32 right) => Operator.vrem_byte(left, right);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator & (byte32 left, byte32 right) => Avx2.mm256_and_si256(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator | (byte32 left, byte32 right) => Avx2.mm256_or_si256(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ^ (byte32 left, byte32 right) => Avx2.mm256_xor_si256(left, right);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ++ (byte32 x) => Avx2.mm256_add_epi8(x, new v256((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator -- (byte32 x) => Avx2.mm256_sub_epi8(x, new v256((byte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ~ (byte32 x) => Avx2.mm256_andnot_si256(x, new v256((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator << (byte32 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator >> (byte32 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (byte32 left, byte32 right) => TestIsTrue(Avx2.mm256_cmpeq_epi8(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (byte32 left, byte32 right) => TestIsTrue(Operator.greater_mask_byte(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (byte32 left, byte32 right) => TestIsTrue(Operator.greater_mask_byte(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (byte32 left, byte32 right) => TestIsFalse(Avx2.mm256_cmpeq_epi8(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (byte32 left, byte32 right) => TestIsFalse(Operator.greater_mask_byte(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (byte32 left, byte32 right) => TestIsFalse(Operator.greater_mask_byte(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsTrue(v256 input)
        {
            return Avx2.mm256_and_si256(input, new v256(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsFalse(v256 input)
        {
            return Avx2.mm256_andnot_si256(input, new v256(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte32 other) => -1 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(this, other));

        public override bool Equals(object obj) => Equals((byte32)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);


        public override string ToString() =>  $"byte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}