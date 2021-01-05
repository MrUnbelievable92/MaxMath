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
    unsafe public struct sbyte32 : IEquatable<sbyte32>, IFormattable
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
        [NoAlias] public sbyte x16;
        [NoAlias] public sbyte x17;
        [NoAlias] public sbyte x18;
        [NoAlias] public sbyte x19;
        [NoAlias] public sbyte x20;
        [NoAlias] public sbyte x21;
        [NoAlias] public sbyte x22;
        [NoAlias] public sbyte x23;
        [NoAlias] public sbyte x24;
        [NoAlias] public sbyte x25;
        [NoAlias] public sbyte x26;
        [NoAlias] public sbyte x27;
        [NoAlias] public sbyte x28;
        [NoAlias] public sbyte x29;
        [NoAlias] public sbyte x30;
        [NoAlias] public sbyte x31;


        public static sbyte32 zero => default(sbyte32);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15, sbyte x16, sbyte x17, sbyte x18, sbyte x19, sbyte x20, sbyte x21, sbyte x22, sbyte x23, sbyte x24, sbyte x25, sbyte x26, sbyte x27, sbyte x28, sbyte x29, sbyte x30, sbyte x31)
        {
            this = Avx.mm256_set_epi8((byte)x31, (byte)x30, (byte)x29, (byte)x28, (byte)x27, (byte)x26, (byte)x25, (byte)x24, (byte)x23, (byte)x22, (byte)x21, (byte)x20, (byte)x19, (byte)x18, (byte)x17, (byte)x16, (byte)x15, (byte)x14, (byte)x13, (byte)x12, (byte)x11, (byte)x10, (byte)x9, (byte)x8, (byte)x7, (byte)x6, (byte)x5, (byte)x4, (byte)x3, (byte)x2, (byte)x1, (byte)x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte x0x32)
        {
            this = new v256(x0x32);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte8 v8_0, sbyte8 v8_1, sbyte8 v8_2, sbyte8 v8_3)
        {
            this = new sbyte32(new sbyte16(v8_0, v8_1), new sbyte16(v8_2, v8_3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte32(sbyte16 v16_0, sbyte16 v16_1)
        {
            this = Avx.mm256_set_m128i(v16_1, v16_0);
        }


















        public sbyte16 v16_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public sbyte16 v16_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 1), (byte)Avx2.mm256_extract_epi8(this, 16), 15); }
        public sbyte16 v16_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshr(v16_0, 2), (short)Avx2.mm256_extract_epi16(this, 8), 7); }
        public sbyte16 v16_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 3), maxmath.vshl(v16_16, 13), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255)); }
        public sbyte16 v16_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi32(maxmath.vshr(v16_0, 4), Avx.mm256_extract_epi32(this, 4), 3); }
        public sbyte16 v16_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 5), maxmath.vshl(v16_16, 11), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 6), maxmath.vshl(v16_16, 10), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 7), maxmath.vshl(v16_16, 9), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi64(maxmath.vshr(v16_0, 8), Avx.mm256_extract_epi64(this, 2), 1); }
        public sbyte16 v16_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 9), maxmath.vshl(v16_16, 7), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 10), maxmath.vshl(v16_16, 6), new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 11), maxmath.vshl(v16_16, 5), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi32(maxmath.vshl(v16_16, 4), Avx.mm256_extract_epi32(this, 3), 0); }
        public sbyte16 v16_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.blendv_epi8(maxmath.vshr(v16_0, 13), maxmath.vshl(v16_16, 3), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255)); }
        public sbyte16 v16_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshl(v16_16, 2), Avx2.mm256_extract_epi16(this, 7), 0); }
        public sbyte16 v16_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshl(v16_16, 1), (byte)Avx2.mm256_extract_epi8(this, 15), 0); }
        public sbyte16 v16_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }

        public sbyte8 v8_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_0; }
        public sbyte8 v8_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_1; }
        public sbyte8 v8_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_2; }
        public sbyte8 v8_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_3; }
        public sbyte8 v8_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_4; }
        public sbyte8 v8_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_5; }
        public sbyte8 v8_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_6; }
        public sbyte8 v8_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_7; }
        public sbyte8 v8_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v8_8; }
        public sbyte8 v8_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 9), (byte)Avx2.mm256_extract_epi8(this, 16), 7); }
        public sbyte8 v8_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshr(v16_0, 10), (short)Avx2.mm256_extract_epi16(this, 8), 3); }
        public sbyte8 v8_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_11.v8_0; }
        public sbyte8 v8_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi32(maxmath.vshr(v16_0, 12), Avx.mm256_extract_epi32(this, 4), 1); }
        public sbyte8 v8_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_13.v8_0; }
        public sbyte8 v8_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_14.v8_0; }
        public sbyte8 v8_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_15.v8_0; }
        public sbyte8 v8_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_0; }
        public sbyte8 v8_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_1; }
        public sbyte8 v8_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_2; }
        public sbyte8 v8_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_3; }
        public sbyte8 v8_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_4; }
        public sbyte8 v8_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_5; }
        public sbyte8 v8_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_6; }
        public sbyte8 v8_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_7; }
        public sbyte8 v8_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v8_8; }

        public sbyte4 v4_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_0; }
        public sbyte4 v4_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_1; }
        public sbyte4 v4_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_2; }
        public sbyte4 v4_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_3; }
        public sbyte4 v4_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_4; }
        public sbyte4 v4_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_5; }
        public sbyte4 v4_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_6; }
        public sbyte4 v4_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_7; }
        public sbyte4 v4_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_8; }
        public sbyte4 v4_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_9; }
        public sbyte4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_10; }
        public sbyte4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_11; }
        public sbyte4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v4_12; }
        public sbyte4 v4_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 13), (byte)Avx2.mm256_extract_epi8(this, 16), 3); }
        public sbyte4 v4_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(maxmath.vshr(v16_0, 14), (short)Avx2.mm256_extract_epi16(this, 8), 1); }
        public sbyte4 v4_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshl(v16_16, 1), (byte)Avx2.mm256_extract_epi8(this, 15), 0); }
        public sbyte4 v4_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_0; }
        public sbyte4 v4_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_1; }
        public sbyte4 v4_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_2; }
        public sbyte4 v4_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_3; }
        public sbyte4 v4_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_4; }
        public sbyte4 v4_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_5; }
        public sbyte4 v4_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_6; }
        public sbyte4 v4_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_7; }
        public sbyte4 v4_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_8; }
        public sbyte4 v4_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_9; }
        public sbyte4 v4_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_10;}
        public sbyte4 v4_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_11;}
        public sbyte4 v4_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v4_12; }

        public sbyte3 v3_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_0; }
        public sbyte3 v3_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_1; }
        public sbyte3 v3_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_2; }
        public sbyte3 v3_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_3; }
        public sbyte3 v3_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_4; }
        public sbyte3 v3_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_5; }
        public sbyte3 v3_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_6; }
        public sbyte3 v3_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_7; }
        public sbyte3 v3_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_8; }
        public sbyte3 v3_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_9; }
        public sbyte3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_10; }
        public sbyte3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_11; }
        public sbyte3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_12; }
        public sbyte3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v3_13; }
        public sbyte3 v3_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 14), (byte)Avx2.mm256_extract_epi8(this, 16), 2); }
        public sbyte3 v3_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(Sse4_1.insert_epi8(maxmath.vshr(v16_0, 15), (byte)Avx2.mm256_extract_epi8(this, 16), 1), (byte)Avx2.mm256_extract_epi8(this, 17), 2); }
        public sbyte3 v3_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_0; }
        public sbyte3 v3_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_1; }
        public sbyte3 v3_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_2; }
        public sbyte3 v3_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_3; }
        public sbyte3 v3_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_4; }
        public sbyte3 v3_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_5; }
        public sbyte3 v3_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_6; }
        public sbyte3 v3_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_7; }
        public sbyte3 v3_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_8; }
        public sbyte3 v3_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_9; }
        public sbyte3 v3_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_10; }
        public sbyte3 v3_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_11; }
        public sbyte3 v3_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_12; }
        public sbyte3 v3_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v3_13; }

        public sbyte2 v2_0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_0; }
        public sbyte2 v2_1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_1; }
        public sbyte2 v2_2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_2; }
        public sbyte2 v2_3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_3; }
        public sbyte2 v2_4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_4; }
        public sbyte2 v2_5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_5; }
        public sbyte2 v2_6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_6; }
        public sbyte2 v2_7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_7; }
        public sbyte2 v2_8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_8; }
        public sbyte2 v2_9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_9; }
        public sbyte2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_10; }
        public sbyte2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_11; }
        public sbyte2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_12; }
        public sbyte2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_13; }
        public sbyte2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_0.v2_14; }
        public sbyte2 v2_15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse4_1.insert_epi8(maxmath.vshr(v16_0, 15), (byte)Avx2.mm256_extract_epi8(this, 16), 1); }
        public sbyte2 v2_16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_0; }
        public sbyte2 v2_17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_1; }
        public sbyte2 v2_18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_2; }
        public sbyte2 v2_19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_3; }
        public sbyte2 v2_20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_4; }
        public sbyte2 v2_21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_5; }
        public sbyte2 v2_22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_6; }
        public sbyte2 v2_23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_7; }
        public sbyte2 v2_24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_8; }
        public sbyte2 v2_25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_9; }
        public sbyte2 v2_26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_10; }
        public sbyte2 v2_27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_11; }
        public sbyte2 v2_28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_12; }
        public sbyte2 v2_29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_13; }
        public sbyte2 v2_30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => v16_16.v2_14; }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(sbyte32 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15, input.x16, input.x17, input.x18, input.x19, input.x20, input.x21, input.x22, input.x23, input.x24, input.x25, input.x26, input.x27, input.x28, input.x29, input.x30, input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator sbyte32(v256 input) => new sbyte32 { x0 = input.SByte0, x1 = input.SByte1, x2 = input.SByte2, x3 = input.SByte3, x4 = input.SByte4, x5 = input.SByte5, x6 = input.SByte6, x7 = input.SByte7, x8 = input.SByte8, x9 = input.SByte9, x10 = input.SByte10, x11 = input.SByte11, x12 = input.SByte12, x13 = input.SByte13, x14 = input.SByte14, x15 = input.SByte15, x16 = input.SByte16, x17 = input.SByte17, x18 = input.SByte18, x19 = input.SByte19, x20 = input.SByte20, x21 = input.SByte21, x22 = input.SByte22, x23 = input.SByte23, x24 = input.SByte24, x25 = input.SByte25, x26 = input.SByte26, x27 = input.SByte27, x28 = input.SByte28, x29 = input.SByte29, x30 = input.SByte30, x31 = input.SByte31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte32(sbyte input) => new sbyte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte32(byte32 input) => (v256)input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);
                
                fixed (void* ptr = &this)
                {
                    return ((sbyte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                fixed (void* ptr = &this)
                {
                    ((sbyte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator + (sbyte32 left, sbyte32 right) => Avx2.mm256_add_epi8(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 left, sbyte32 right) => Avx2.mm256_sub_epi8(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator * (sbyte32 left, sbyte32 right) => Operator.mul_byte(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator / (sbyte32 left, sbyte32 right) => Operator.vdiv_sbyte(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator % (sbyte32 left, sbyte32 right) => Operator.vrem_sbyte(left, right);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator & (sbyte32 left, sbyte32 right) => Avx2.mm256_and_si256(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator | (sbyte32 left, sbyte32 right) => Avx2.mm256_or_si256(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ^ (sbyte32 left, sbyte32 right) => Avx2.mm256_xor_si256(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator - (sbyte32 x) => Avx2.mm256_sign_epi8(x, new v256((sbyte)-1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ++ (sbyte32 x) => Avx2.mm256_add_epi8(x, new v256((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator -- (sbyte32 x) => Avx2.mm256_sub_epi8(x, new v256((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator ~ (sbyte32 x) => Avx2.mm256_andnot_si256(x, new v256((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator << (sbyte32 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 operator >> (sbyte32 x, int n) => Operator.shra_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (sbyte32 left, sbyte32 right) => TestIsTrue(Avx2.mm256_cmpeq_epi8(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (sbyte32 left, sbyte32 right) => TestIsTrue(Avx2.mm256_cmpgt_epi8(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (sbyte32 left, sbyte32 right) => TestIsTrue(Avx2.mm256_cmpgt_epi8(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (sbyte32 left, sbyte32 right) => TestIsFalse(Avx2.mm256_cmpeq_epi8(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (sbyte32 left, sbyte32 right) => TestIsFalse(Avx2.mm256_cmpgt_epi8(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (sbyte32 left, sbyte32 right) => TestIsFalse(Avx2.mm256_cmpgt_epi8(right, left));


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
        public bool Equals(sbyte32 other) => -1 == Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(this, other));

        public override bool Equals(object obj) => Equals((sbyte32)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);


        public override string ToString() =>  $"sbyte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}