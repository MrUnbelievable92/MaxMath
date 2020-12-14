using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Burst;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct short16 : IEquatable<short16>, IFormattable
    {
        [NoAlias] public short x0;
        [NoAlias] public short x1;
        [NoAlias] public short x2;
        [NoAlias] public short x3;
        [NoAlias] public short x4;
        [NoAlias] public short x5;
        [NoAlias] public short x6;
        [NoAlias] public short x7;
        [NoAlias] public short x8;
        [NoAlias] public short x9;
        [NoAlias] public short x10;
        [NoAlias] public short x11;
        [NoAlias] public short x12;
        [NoAlias] public short x13;
        [NoAlias] public short x14;
        [NoAlias] public short x15;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7, short x8, short x9, short x10, short x11, short x12, short x13, short x14, short x15)
        {
            this = Avx.mm256_set_epi16(x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short x0x16)
        {
            this = Avx.mm256_set1_epi16(x0x16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short2 x01, short2 x23, short2 x45, short2 x67, short2 x89, short2 x10_11, short2 x12_13, short2 x14_15)
        {
            this = new short16(new short8(x01, x23, x45, x67), new short8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short4 x4567, short4 x8_9_10_11, short4 x12_13_14_15)
        {
            this = new short16(new short8(x0123, x4567), new short8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short3 x456, short3 x789, short3 x10_11_12, short3 x13_14_15)
        {
            this = new short16((short8)Sse2.insert_epi16(Sse2.unpacklo_epi64(x0123, x456), x789.x, 7),
                               new short8(x789.yz, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short4 x3456, short3 x789, short3 x10_11_12, short3 x13_14_15)
        {
            this = new short16(new short8(new short4(x012, x3456.x), new short4(x3456.yzw, x789.x)),
                               new short8(x789.yz, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short3 x345, short4 x6789, short3 x10_11_12, short3 x13_14_15)
        {
            this = new short16(new short8(x012, x345, x6789.xy),
                               new short8(x6789.zw, x10_11_12, x13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short3 x345, short3 x678, short4 x9_10_11_12, short3 x13_14_15)
        {
            this = new short16(new short8(x012, x345, x678.xy),
                               new short8(new short4(x678.z, x9_10_11_12.xyz), new short4(x9_10_11_12.w, x13_14_15)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short3 x012, short3 x345, short3 x678, short3 x9_10_11, short4 x12_13_14_15)
        {
            this = new short16(new short8(x012, x345, x678.xy),
                               new short8(new short4(x678.z, x9_10_11), x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short8 x01234567, short4 x8_9_10_11, short4 x12_13_14_15)
        {
            this = new short16(x01234567, new short8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short8 x4_5_6_7_8_9_10_11, short4 x12_13_14_15)
        {
            this = Avx.mm256_set_m128i(Sse2.unpacklo_epi64(Sse2.bsrli_si128(x4_5_6_7_8_9_10_11, 4 * sizeof(short)), x12_13_14_15),
                                       Sse2.unpacklo_epi64(x0123, x4_5_6_7_8_9_10_11));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short4 x4567, short8 x8_9_10_11_12_13_14_15)
        {
            this = new short16(new short8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short8 x01234567, short8 x8_9_10_11_12_13_14_15)
        {
            this = Avx.mm256_set_m128i(x8_9_10_11_12_13_14_15, x01234567);
        }


        public short8 v8_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public short8 v8_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(short)), Avx2.mm256_extract_epi16(this, 8), 7); }
        public short8 v8_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(1, 2, 3, 4,   0, 0, 0, 0))); }
        public short8 v8_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.or_si128(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 3 * sizeof(short)), Sse2.bslli_si128(Avx2.mm256_extracti128_si256(this, 1), 5 * sizeof(short))); }
        public short8 v8_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(2, 3, 4, 5,   0, 0, 0, 0))); }
        public short8 v8_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.or_si128(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 5 * sizeof(short)), Sse2.bslli_si128(Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(short))); }
        public short8 v8_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(3, 4, 5, 6,   0, 0, 0, 0))); }
        public short8 v8_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.insert_epi16(Sse2.bslli_si128(Avx2.mm256_extracti128_si256(this, 1), sizeof(short)), Avx2.mm256_extract_epi16(this, 7), 0); }
        public short8 v8_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }

        public short4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx.mm256_castsi256_si128(this); }
        public short4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(short)); }
        public short4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0,   2, 1)); }
        public short4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 3 * sizeof(short)); }
        public short4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0,   3, 2)); }
        public short4 v4_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.insert_epi16(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 5 * sizeof(short)), Avx2.mm256_extract_epi16(this, 8), 3); }
        public short4 v4_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(3, 4,   0, 0, 0, 0, 0, 0))); }
        public short4 v4_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.insert_epi16(Sse2.bslli_si128(Avx2.mm256_extracti128_si256(this, 1), sizeof(short)), Avx2.mm256_extract_epi16(this, 7), 0); }
        public short4 v4_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx2.mm256_extracti128_si256(this, 1); }
        public short4 v4_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), sizeof(short)); }
        public short4 v4_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(5, 6,   0, 0, 0, 0, 0, 0))); }
        public short4 v4_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(short)); }
        public short4 v4_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(6, 7,   0, 0, 0, 0, 0, 0))); }

        public short3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx.mm256_castsi256_si128(this); }
        public short3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0,   3, 2, 1)); }
        public short3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0,   2, 1)); }
        public short3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 3 * sizeof(short)); }
        public short3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0,   3, 2)); }
        public short3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 5 * sizeof(short)); }
        public short3 v3_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, new v256(3, 4,   0, 0, 0, 0, 0, 0))); }
        public short3 v3_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.insert_epi16(Sse2.bslli_si128(Avx2.mm256_extracti128_si256(this, 1), sizeof(short)), Avx2.mm256_extract_epi16(this, 7), 0); }
        public short3 v3_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx2.mm256_extracti128_si256(this, 1); }
        public short3 v3_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0,   3, 2, 1)); }
        public short3 v3_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0, 0,   2, 1)); }
        public short3 v3_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(short)); }
        public short3 v3_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0, 0,   3, 2)); }
        public short3 v3_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 5 * sizeof(short)); }

        public short2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx.mm256_castsi256_si128(this); }
        public short2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0,   2, 1)); }
        public short2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0,   3, 2)); }
        public short2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 3 * sizeof(short)); }
        public short2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0, 0,   2)); }
        public short2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 5 * sizeof(short)); }
        public short2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(0, 0, 0,   3)); }
        public short2 v2_7 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => new short2((short)Avx2.mm256_extract_epi16(this, 7), (short)Avx2.mm256_extract_epi16(this, 8)); }
        public short2 v2_8 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Avx2.mm256_extracti128_si256(this, 1); }
        public short2 v2_9 { [MethodImpl(MethodImplOptions.AggressiveInlining)]  get => Sse2.shufflelo_epi16(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0, 0,   2, 1)); }
        public short2 v2_10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0, 0,   3, 2)); }
        public short2 v2_11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(short)); }
        public short2 v2_12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0, 0, 0,   2)); }
        public short2 v2_13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 5 * sizeof(short)); }
        public short2 v2_14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shuffle_epi32(Avx2.mm256_extracti128_si256(this, 1), Sse.SHUFFLE(0, 0, 0, 3)); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(short16 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator short16(v256 input) => new short16 { x0 = input.SShort0, x1 = input.SShort1, x2 = input.SShort2, x3 = input.SShort3, x4 = input.SShort4, x5 = input.SShort5, x6 = input.SShort6, x7 = input.SShort7, x8 = input.SShort8, x9 = input.SShort9, x10 = input.SShort10, x11 = input.SShort11, x12 = input.SShort12, x13 = input.SShort13, x14 = input.SShort14, x15 = input.SShort15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(short input) => new short16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short16(ushort16 input) => (v256)input;


        public short this[[AssumeRange(0, 15)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 16);
                
                fixed (void* ptr = &this)
                {
                    return ((short*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 16);

                fixed (void* ptr = &this)
                {
                    ((short*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator + (short16 lhs, short16 rhs) => Avx2.mm256_add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator - (short16 lhs, short16 rhs) => Avx2.mm256_sub_epi16(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short16 lhs, short16 rhs) => Avx2.mm256_mullo_epi16(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator / (short16 lhs, short16 rhs) => new short16((short)(lhs.x0 / rhs.x0),    (short)(lhs.x1 / rhs.x1),    (short)(lhs.x2 / rhs.x2),    (short)(lhs.x3 / rhs.x3),    (short)(lhs.x4 / rhs.x4),    (short)(lhs.x5 / rhs.x5),    (short)(lhs.x6 / rhs.x6),    (short)(lhs.x7 / rhs.x7), (short)(lhs.x8 / rhs.x8), (short)(lhs.x9 / rhs.x9), (short)(lhs.x10 / rhs.x10), (short)(lhs.x11 / rhs.x11), (short)(lhs.x12 / rhs.x12), (short)(lhs.x13 / rhs.x13), (short)(lhs.x14 / rhs.x14), (short)(lhs.x15 / rhs.x15));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator % (short16 lhs, short16 rhs) => new short16((short)(lhs.x0 % rhs.x0),    (short)(lhs.x1 % rhs.x1),    (short)(lhs.x2 % rhs.x2),    (short)(lhs.x3 % rhs.x3),    (short)(lhs.x4 % rhs.x4),    (short)(lhs.x5 % rhs.x5),    (short)(lhs.x6 % rhs.x6),    (short)(lhs.x7 % rhs.x7), (short)(lhs.x8 % rhs.x8), (short)(lhs.x9 % rhs.x9), (short)(lhs.x10 % rhs.x10), (short)(lhs.x11 % rhs.x11), (short)(lhs.x12 % rhs.x12), (short)(lhs.x13 % rhs.x13), (short)(lhs.x14 % rhs.x14), (short)(lhs.x15 % rhs.x15));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator & (short16 lhs, short16 rhs) => Avx2.mm256_and_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator | (short16 lhs, short16 rhs) => Avx2.mm256_or_si256(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ^ (short16 lhs, short16 rhs) => Avx2.mm256_xor_si256(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator - (short16 x) => Avx2.mm256_sign_epi16(x, new v256((short)-1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ++ (short16 x) => Avx2.mm256_add_epi16(x, new v256((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator -- (short16 x) => Avx2.mm256_sub_epi16(x, new v256((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ~ (short16 x) => Avx2.mm256_andnot_si256(x, new v256((short)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator << (short16 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator >> (short16 x, int n) => Operator.shra_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (short16 lhs, short16 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (short16 lhs, short16 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi16(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (short16 lhs, short16 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi16(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (short16 lhs, short16 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (short16 lhs, short16 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (short16 lhs, short16 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi16(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool16 TestIsTrue(v256 input)
        {
            return Sse2.and_si128((byte16)(short16)input, new v128((sbyte)1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool16 TestIsFalse(v256 input)
        {
            return Sse2.andnot_si128((byte16)(short16)input, new v128((sbyte)1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short16 other) => maxmath.tobool(Avx.mm256_testc_ps(Avx2.mm256_cmpeq_epi16(this, other), new v256(-1)));

        public override bool Equals(object obj) => Equals((short16)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);


        public override string ToString() =>  $"short16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}