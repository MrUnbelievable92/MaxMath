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
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct int8 : IEquatable<int8>, IFormattable
    {
        [NoAlias] public int x0;
        [NoAlias] public int x1;
        [NoAlias] public int x2;
        [NoAlias] public int x3;
        [NoAlias] public int x4;
        [NoAlias] public int x5;
        [NoAlias] public int x6;
        [NoAlias] public int x7;


        public static int8 zero => default(int8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7)
        {
            this = Avx.mm256_set_epi32(x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0x8)
        {
            this = Avx.mm256_set1_epi32(x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int2 x45, int2 x67)
        {
            this = new int8(new int4(x01, x23), new int4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int3 x234, int3 x567)
        {
            this = Avx.mm256_set_m128i(Sse4_1.insert_epi32(Sse2.bslli_si128(*(v128*)&x567, sizeof(int)), (int)x234.z, 0),
                                       Sse2.unpacklo_epi64(*(v128*)&x01, *(v128*)&x234));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int2 x34, int3 x567)
        {
            this = Avx.mm256_set_m128i(Sse4_1.insert_epi32(Sse2.bslli_si128(*(v128*)&x567, sizeof(int)), (int)x34.y, 0),
                                       Sse4_1.insert_epi32(*(v128*)&x012, (int)x34.x, 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int3 x345, int2 x67)
        {
            this = Avx.mm256_set_m128i(Sse2.unpacklo_epi64(Sse2.bsrli_si128(*(v128*)&x345, sizeof(int)), *(v128*)&x67),
                                       Sse4_1.insert_epi32(*(v128*)&x012, (int)x345.x, 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int2 x45, int2 x67)
        {
            this = new int8(x0123, new int4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int4 x2345, int2 x67)
        {
            v128 t = *(v128*)&x2345;

            this = Avx.mm256_set_m128i(Sse2.unpackhi_epi64(t, Sse2.bslli_si128(*(v128*)&x67, 2 * sizeof(int))),
                                       Sse2.unpacklo_epi64(*(v128*)&x01, t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int4 x4567)
        {
            this = new int8(new int4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int4 x4567)
        {
            this = Avx.mm256_set_m128i(*(v128*)&x4567,
                                       *(v128*)&x0123);
        }


        public int4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(int4*)&t; }                                                                                              }//set => this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_1111); }
        public int4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(1, 2, 3, 4)))); return *(int4*)&t; }            }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 2, 3, 0, 0, 0)), 0b0001_1110); }
        public int4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(2, 3, 4, 5)))); return *(int4*)&t; }            }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 3, 0, 0)), 0b0011_1100); }
        public int4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 6)))); return *(int4*)&t; }            }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 3, 0)), 0b0111_1000); }
        public int4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(int4*)&t; }                                                                                        }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 3)), 0b1111_0000); }
                                                                                                                                                                                                                                                     
        public int3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(int3*)&t; }                                                                                              }//set => this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_0111); }
        public int3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(int)); return *(int3*)&t; }                                                               }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 2, 0, 0, 0, 0)), 0b0000_1110); }
        public int3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(2, 3, 4, 0)))); return *(int3*)&t; }            }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 0, 0, 0)), 0b0001_1100); }
        public int3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 0)))); return *(int3*)&t; }            }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 0, 0)), 0b0011_1000); }
        public int3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(int3*)&t; }                                                                                        }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 0)), 0b0111_0000); }
        public int3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5, 6, 7, 0)))); return *(int3*)&t; }            }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 2)), 0b1110_0000); }
                                                                                                                                                                                                                                             
        public int2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(int2*)&t; }                                                                                              }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 0); }
        public int2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(int)); return *(int2*)&t; }                                                               }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 0, 0, 0, 0, 0)), 0b0000_0110); }
        public int2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(int)); return *(int2*)&t; }                                                           }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 1); }
        public int2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3L | (4L << 32),   0L)))); return *(int2*)&t; } }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 0, 0, 0)), 0b0001_1000); }
        public int2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(int2*)&t; }                                                                                        }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 2); }
        public int2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5L | (6L << 32), 0L)))); return *(int2*)&t; }   }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 0)), 0b0110_0000); }
        public int2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0,   3))); return *(int2*)&t; }                                     }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 3); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(int8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator int8(v256 input) => new int8 { x0 = input.SInt0, x1 = input.SInt1, x2 = input.SInt2, x3 = input.SInt3, x4 = input.SInt4, x5 = input.SInt5, x6 = input.SInt6, x7 = input.SInt7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(int input) => new int8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(uint8 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(half8 input) => (int8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(float8 input) => Avx.mm256_cvttps_epi32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(int8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(int8 input) => Avx.mm256_cvtepi32_ps(input);


        public int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((int*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((int*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator + (int8 left, int8 right) => Avx2.mm256_add_epi32(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 left, int8 right) => Avx2.mm256_sub_epi32(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 left, int8 right) => Avx2.mm256_mullo_epi32(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 left, int8 right) => new int8((left.x0 / right.x0),    (left.x1 / right.x1),    (left.x2 / right.x2),    (left.x3 / right.x3),    (left.x4 / right.x4),    (left.x5 / right.x5),    (left.x6 / right.x6),    (left.x7 / right.x7));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 left, int8 right) => new int8((left.x0 % right.x0),    (left.x1 % right.x1),    (left.x2 % right.x2),    (left.x3 % right.x3),    (left.x4 % right.x4),    (left.x5 % right.x5),    (left.x6 % right.x6),    (left.x7 % right.x7));
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int left, int8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 left, int right) => new int8(left.x0 * right, left.x1 * right, left.x2 * right, left.x3 * right, left.x4 * right, left.x5 * right, left.x6 * right, left.x7 * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 left, int right) => new int8(left.x0 / right, left.x1 / right, left.x2 / right, left.x3 / right, left.x4 / right, left.x5 / right, left.x6 / right, left.x7 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 left, int right) => new int8(left.x0 % right, left.x1 % right, left.x2 % right, left.x3 % right, left.x4 % right, left.x5 % right, left.x6 % right, left.x7 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator & (int8 left, int8 right) => Avx2.mm256_and_si256(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator | (int8 left, int8 right) => Avx2.mm256_or_si256(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ^ (int8 left, int8 right) => Avx2.mm256_xor_si256(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 x) => Avx2.mm256_sign_epi32(x, new v256((int)-1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ++ (int8 x) => Avx2.mm256_add_epi32(x, new v256((int)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator -- (int8 x) => Avx2.mm256_sub_epi32(x, new v256((int)1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ~ (int8 x) => Avx2.mm256_andnot_si256(x, new v256((int)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator << (int8 x, int n) => Operator.shl_int(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator >> (int8 x, int n) => Operator.shra_int(x, n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (int8 left, int8 right) => TestIsTrue(Avx2.mm256_cmpeq_epi32(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (int8 left, int8 right) => TestIsTrue(Avx2.mm256_cmpgt_epi32(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (int8 left, int8 right) => TestIsTrue(Avx2.mm256_cmpgt_epi32(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (int8 left, int8 right) => TestIsFalse(Avx2.mm256_cmpeq_epi32(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (int8 left, int8 right) => TestIsFalse(Avx2.mm256_cmpgt_epi32(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (int8 left, int8 right) => TestIsFalse(Avx2.mm256_cmpgt_epi32(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v256 input)
        {
            return Sse2.and_si128((byte8)(int8)input, new v128(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v256 input)
        {
            return Sse2.andnot_si128((byte8)(int8)input, new v128(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int8 other) => maxmath.bitmask32(8) == Avx.mm256_movemask_ps(Avx2.mm256_cmpeq_epi32(this, other));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => Equals((int8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);

        public override string ToString() => $"int8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"int8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}