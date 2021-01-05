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
    unsafe public struct float8 : IEquatable<float8>, IFormattable
    {
        [NoAlias] public float x0;
        [NoAlias] public float x1;
        [NoAlias] public float x2;
        [NoAlias] public float x3;
        [NoAlias] public float x4;
        [NoAlias] public float x5;
        [NoAlias] public float x6;
        [NoAlias] public float x7;


        public static float8 zero => default(float8);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7)
        {
            this = Avx.mm256_set_ps(x7, x6, x5, x4, x3, x2, x1, x0);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float x0x8)
        {
            this = Avx.mm256_set1_ps(x0x8);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float2 x23, float2 x45, float2 x67)
        {
            this = new float8(new float4(x01, x23), new float4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float3 x234, float3 x567)
        {
            this = Avx.mm256_set_m128i(Sse4_1.insert_epi32(Sse2.bslli_si128(*(v128*)&x567, sizeof(float)), math.asint(x234.z), 0),
                                       Sse2.unpacklo_epi64(*(v128*)&x01, *(v128*)&x234));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float3 x012, float2 x34, float3 x567)
        {
            this = Avx.mm256_set_m128i(Sse4_1.insert_epi32(Sse2.bslli_si128(*(v128*)&x567, sizeof(float)), math.asint(x34.y), 0),
                                       Sse4_1.insert_epi32(*(v128*)&x012, math.asint(x34.x), 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float3 x012, float3 x345, float2 x67)
        {
            this = Avx.mm256_set_m128i(Sse2.unpacklo_epi64(Sse2.bsrli_si128(*(v128*)&x345, sizeof(float)), *(v128*)&x67),
                                       Sse4_1.insert_epi32(*(v128*)&x012, math.asint(x345.x), 3));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float4 x0123, float2 x45, float2 x67)
        {
            this = new float8(x0123, new float4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float4 x2345, float2 x67)
        {
            v128 t = *(v128*)&x2345;

            this = Avx.mm256_set_m128i(Sse2.unpackhi_epi64(t, Sse2.bslli_si128(*(v128*)&x67, 2 * sizeof(float))),
                                       Sse2.unpacklo_epi64(*(v128*)&x01, t));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float2 x23, float4 x4567)
        {
            this = new float8(new float4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float4 x0123, float4 x4567)
        {
            this = Avx.mm256_set_m128i(*(v128*)&x4567,
                                       *(v128*)&x0123);
        }


        public float4 v4_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(float4*)&t; }                                                                                           }//set => this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(*(v128*)&value), 0b0000_1111); }
        public float4 v4_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(1, 2, 3, 4)))); return *(float4*)&t; }            }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 1, 2, 3, 0, 0, 0)), 0b0001_1110); }
        public float4 v4_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(2, 3, 4, 5)))); return *(float4*)&t; }            }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 3, 0, 0)), 0b0011_1100); }
        public float4 v4_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 6)))); return *(float4*)&t; }            }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 3, 0)), 0b0111_1000); }
        public float4 v4_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(float4*)&t; }                                                                                     }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 3)), 0b1111_0000); }

        public float3 v3_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(float3*)&t; }                                                                                           }//set => this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(*(v128*)&value), 0b0000_0111); }
        public float3 v3_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(float)); return *(float3*)&t; }                                                          }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 1, 2, 0, 0, 0, 0)), 0b0000_1110); }
        public float3 v3_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(2, 3, 4, 0)))); return *(float3*)&t; }            }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 0, 0, 0)), 0b0001_1100); }
        public float3 v3_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 0)))); return *(float3*)&t; }            }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 0, 0)), 0b0011_1000); }
        public float3 v3_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(float3*)&t; }                                                                                     }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 0)), 0b0111_0000); }
        public float3 v3_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(5, 6, 7, 0)))); return *(float3*)&t; }            }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 2)), 0b1110_0000); }
 
        public float2 v2_0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(this); return *(float2*)&t; }                                                                                           }//set => this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(*(v128*)&value), 0b0000_0011); }
        public float2 v2_1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(float)); return *(float2*)&t; }                                                          }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 1, 0, 0, 0, 0, 0)), 0b0000_0110); }
        public float2 v2_2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(float)); return *(float2*)&t; }                                                      }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 1, 0, 0, 0, 0)), 0b0000_1100); }
        public float2 v2_3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(3L | (4L << 32),   0L)))); return *(float2*)&t; } }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 0, 0, 0)), 0b0001_1000); }
        public float2 v2_4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx2.mm256_extracti128_si256(this, 1); return *(float2*)&t; }                                                                                     }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 0, 0)), 0b0011_0000); }
        public float2 v2_5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(5L | (6L << 32), 0L)))); return *(float2*)&t; }   }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 0)), 0b0110_0000); }
        public float2 v2_6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] /*readonly */get { v128 t = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(6L | (7L << 32), 0L)))); return *(float2*)&t; }   }//set => this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castps128_ps256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 0, 1)), 0b1100_0000); }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(float8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator float8(v256 input) => new float8 { x0 = input.Float0, x1 = input.Float1, x2 = input.Float2, x3 = input.Float3, x4 = input.Float4, x5 = input.Float5, x6 = input.Float6, x7 = input.Float7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(float input) => new float8(input);


        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);
                
                fixed (void* ptr = &this)
                {
                    return ((float*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                fixed (void* ptr = &this)
                {
                    ((float*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 left, float8 right) => Avx.mm256_add_ps(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 left, float8 right) => Avx.mm256_sub_ps(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 left, float8 right) => Avx.mm256_mul_ps(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 left, float8 right) => Avx.mm256_div_ps(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 left, float8 right) => new float8(left.v4_0 % right.v4_0, left.v4_4 % right.v4_4);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 x) => Avx.mm256_xor_ps(x, new v256(1 << 31));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator ++ (float8 x) => Avx.mm256_add_ps(x, new v256((float)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator -- (float8 x) => Avx.mm256_sub_ps(x, new v256((float)1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (float8 left, float8 right) => TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.EQ_OQ));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (float8 left, float8 right) => TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.LT_OS));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (float8 left, float8 right) => TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.GT_OS));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (float8 left, float8 right) => TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.NEQ_UQ));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (float8 left, float8 right) => TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.LE_OS));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (float8 left, float8 right) => TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.GE_OS));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v256 input)
        {
            return Sse2.and_si128(new v128(0x0101_0101), (byte8)(uint8)input);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float8 other) => maxmath.bitmask32(8) == Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(this, other, (int)Avx.CMP.EQ_OQ));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => Equals((float8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);

        public override string ToString() => $"float8({x0}f, {x1}f, {x2}f, {x3}f,    {x4}f, {x5}f, {x6}f, {x7}f)";
        public string ToString(string format, IFormatProvider formatProvider) => $"float8({x0.ToString(format, formatProvider)}f, {x1.ToString(format, formatProvider)}f, {x2.ToString(format, formatProvider)}f, {x3.ToString(format, formatProvider)}f,    {x4.ToString(format, formatProvider)}f, {x5.ToString(format, formatProvider)}f, {x6.ToString(format, formatProvider)}f, {x7.ToString(format, formatProvider)}f)";
    }
}