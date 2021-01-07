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
    unsafe public struct uint8 : IEquatable<uint8>, IFormattable
    {
        [NoAlias] public uint x0;
        [NoAlias] public uint x1;
        [NoAlias] public uint x2;
        [NoAlias] public uint x3;
        [NoAlias] public uint x4;
        [NoAlias] public uint x5;
        [NoAlias] public uint x6;
        [NoAlias] public uint x7;


        public static uint8 zero => default(uint8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
        {
            this = Avx.mm256_set_epi32((int)x7, (int)x6, (int)x5, (int)x4, (int)x3, (int)x2, (int)x1, (int)x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint x0x8)
        {
            this = Avx.mm256_set1_epi32((int)x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint2 x23, uint2 x45, uint2 x67)
        {
            this = new uint8(new uint4(x01, x23), new uint4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint3 x234, uint3 x567)
        {
            this = Avx.mm256_set_m128i(Sse4_1.insert_epi32(Sse2.bslli_si128(*(v128*)&x567, sizeof(uint)), (int)x234.z, 0),
                                       Sse2.unpacklo_epi64(*(v128*)&x01, *(v128*)&x234));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint3 x012, uint2 x34, uint3 x567)
        {
            this = Avx.mm256_set_m128i(Sse4_1.insert_epi32(Sse2.bslli_si128(*(v128*)&x567, sizeof(uint)), (int)x34.y, 0),
                                       Sse4_1.insert_epi32(*(v128*)&x012, (int)x34.x, 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint3 x012, uint3 x345, uint2 x67)
        {
            this = Avx.mm256_set_m128i(Sse2.unpacklo_epi64(Sse2.bsrli_si128(*(v128*)&x345, sizeof(uint)), *(v128*)&x67),
                                       Sse4_1.insert_epi32(*(v128*)&x012, (int)x345.x, 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint4 x0123, uint2 x45, uint2 x67)
        {
            this = new uint8(x0123, new uint4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint4 x2345, uint2 x67)
        {
            v128 t = *(v128*)&x2345;

            this = Avx.mm256_set_m128i(Sse2.unpackhi_epi64(t, Sse2.bslli_si128(*(v128*)&x67, 2 * sizeof(int))),
                                       Sse2.unpacklo_epi64(*(v128*)&x01, t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint2 x23, uint4 x4567)
        {
            this = new uint8(new uint4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint4 x0123, uint4 x4567)
        {
            this = Avx.mm256_set_m128i(*(v128*)&x4567, 
                                       *(v128*)&x0123);
        }


        public uint4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(uint4*)&t; }                                                                                               }//set => this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_1111); }
        public uint4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(1, 2, 3, 4)))); return *(uint4*)&t; }             }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 2, 3, 0, 0, 0)), 0b0001_1110); }
        public uint4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(2, 3, 4, 5)))); return *(uint4*)&t; }             }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 3, 0, 0)), 0b0011_1100); }
        public uint4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 6)))); return *(uint4*)&t; }             }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 3, 0)), 0b0111_1000); }
        public uint4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(uint4*)&t; }                                                                                         }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 3)), 0b1111_0000); }
                                                                                                                                                                                                                                                                         
        public uint3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(uint3*)&t; }                                                                                               }//set => this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_0111); }
        public uint3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(uint)); return *(uint3*)&t; }                                                               }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 2, 0, 0, 0, 0)), 0b0000_1110); }
        public uint3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(2, 3, 4, 0)))); return *(uint3*)&t; }             }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 0, 0, 0)), 0b0001_1100); }
        public uint3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 0)))); return *(uint3*)&t; }             }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 0, 0)), 0b0011_1000); }
        public uint3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(uint3*)&t; }                                                                                         }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 0)), 0b0111_0000); }
        public uint3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5, 6, 7, 0)))); return *(uint3*)&t; }             }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 2)), 0b1110_0000); }
                                                                                                                                                                                                                                                                     
        public uint2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(uint2*)&t; }                                                                                               }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 0); }
        public uint2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(uint)); return *(uint2*)&t; }                                                               }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 0, 0, 0, 0, 0)), 0b0000_0110); }
        public uint2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(uint)); return *(uint2*)&t; }                                                           }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 1); }
        public uint2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3L | (4L << 32),   0L)))); return *(uint2*)&t; }  }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 0, 0, 0)), 0b0001_1000); }
        public uint2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(uint2*)&t; }                                                                                         }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 2); }
        public uint2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5L | (6L << 32), 0L)))); return *(uint2*)&t; }    }//set => this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 0)), 0b0110_0000); }
        public uint2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0,   3))); return *(uint2*)&t; }                                      }//set => this = Avx.mm256_insert_epi64(this, *(long*)&value, 3); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(uint8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator uint8(v256 input) => new uint8 { x0 = input.UInt0, x1 = input.UInt1, x2 = input.UInt2, x3 = input.UInt3, x4 = input.UInt4, x5 = input.UInt5, x6 = input.UInt6, x7 = input.UInt7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(uint input) => new uint8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(int8 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(half8 input) => (uint8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(float8 input) => new uint8((uint)input.x0, (uint)input.x1, (uint)input.x2, (uint)input.x3, (uint)input.x4, (uint)input.x5, (uint)input.x6, (uint)input.x7);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(uint8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(uint8 input) => Cast.Uint8ToFloat8(input);

        public uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((uint*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((uint*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator + (uint8 left, uint8 right) => Avx2.mm256_add_epi32(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator - (uint8 left, uint8 right) => Avx2.mm256_sub_epi32(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint8 left, uint8 right) => Avx2.mm256_mullo_epi32(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 left, uint8 right) => new uint8((left.x0 / right.x0),    (left.x1 / right.x1),    (left.x2 / right.x2),    (left.x3 / right.x3),    (left.x4 / right.x4),    (left.x5 / right.x5),    (left.x6 / right.x6),    (left.x7 / right.x7));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 left, uint8 right) => new uint8((left.x0 % right.x0),    (left.x1 % right.x1),    (left.x2 % right.x2),    (left.x3 % right.x3),    (left.x4 % right.x4),    (left.x5 % right.x5),    (left.x6 % right.x6),    (left.x7 % right.x7));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint left, uint8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint8 left, uint right) => new uint8(left.x0 * right, left.x1 * right, left.x2 * right, left.x3 * right, left.x4 * right, left.x5 * right, left.x6 * right, left.x7 * right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 left, uint right) => new uint8(left.x0 / right, left.x1 / right, left.x2 / right, left.x3 / right, left.x4 / right, left.x5 / right, left.x6 / right, left.x7 / right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 left, uint right) => new uint8(left.x0 % right, left.x1 % right, left.x2 % right, left.x3 % right, left.x4 % right, left.x5 % right, left.x6 % right, left.x7 % right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator & (uint8 left, uint8 right) => Avx2.mm256_and_si256(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator | (uint8 left, uint8 right) => Avx2.mm256_or_si256(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ^ (uint8 left, uint8 right) => Avx2.mm256_xor_si256(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ++ (uint8 x) => Avx2.mm256_add_epi32(x, new v256((uint)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator -- (uint8 x) => Avx2.mm256_sub_epi32(x, new v256((uint)1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ~ (uint8 x) => Avx2.mm256_andnot_si256(x, new v256((int)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator << (uint8 x, int n) => Operator.shl_int(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator >> (uint8 x, int n) => Operator.shrl_int(x, n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (uint8 left, uint8 right) => TestIsTrue(Avx2.mm256_cmpeq_epi32(left, right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (uint8 left, uint8 right) => TestIsTrue(Operator.greater_mask_uint(right, left));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (uint8 left, uint8 right) => TestIsTrue(Operator.greater_mask_uint(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (uint8 left, uint8 right) => TestIsFalse(Avx2.mm256_cmpeq_epi32(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (uint8 left, uint8 right) => TestIsFalse(Operator.greater_mask_uint(left, right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (uint8 left, uint8 right) => TestIsFalse(Operator.greater_mask_uint(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v256 input)
        {
            return Sse2.and_si128((byte8)(uint8)input, new v128(0x0101_0101));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v256 input)
        {
            return Sse2.andnot_si128((byte8)(uint8)input, new v128(0x0101_0101));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint8 other) => maxmath.bitmask32(8) == Avx.mm256_movemask_ps(Avx2.mm256_cmpeq_epi32(this, other));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => Equals((uint8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);

        public override string ToString() => $"uint8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"uint8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}