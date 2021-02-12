using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(float))]
    unsafe public struct float8 : IEquatable<float8>, IFormattable
    {
        [FieldOffset(0)]  private fixed float asArray[8];

        [FieldOffset(0)]  internal float4 _v4_0;
        [FieldOffset(16)] internal float4 _v4_4;

        [FieldOffset(0)]  public float x0;
        [FieldOffset(4)]  public float x1;
        [FieldOffset(8)]  public float x2;
        [FieldOffset(12)] public float x3;
        [FieldOffset(16)] public float x4;
        [FieldOffset(20)] public float x5;
        [FieldOffset(24)] public float x6;
        [FieldOffset(28)] public float x7;


        public static float8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float x0, float x1, float x2, float x3, float x4, float x5, float x6, float x7)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_ps(x7, x6, x5, x4, x3, x2, x1, x0);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = new float4(x0, x1, x2, x3),
                    _v4_4 = new float4(x4, x5, x6, x7),
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float x0x8)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_ps(x0x8);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = new float4(x0x8),
                    _v4_4 = new float4(x0x8),
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float2 x23, float2 x45, float2 x67)
        {
            this = new float8(new float4(x01, x23), new float4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float3 x234, float3 x567)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse2.unpacklo_pd(*(v128*)&x01, *(v128*)&x234);
                v128 mid = Sse2.bsrli_si128(*(v128*)&x234, 2 * sizeof(float));
                v128 hi = Sse2.bslli_si128(*(v128*)&x567, sizeof(float));

                hi = Sse4_1.blend_ps(mid, hi, 0b1110);


                this = new float8(*(float4*)&lo, *(float4*)&hi);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = new float4(x01, x234.xy),
                    _v4_4 = new float4(x234.z, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float3 x012, float2 x34, float3 x567)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 mid = Sse2.bslli_si128(*(v128*)&x34, 3 * sizeof(float));
                v128 lo = Sse4_1.blend_ps(*(v128*)&x012, mid, 0b1000);

                mid = Sse2.bsrli_si128(*(v128*)&x34, sizeof(float));

                v128 hi = Sse2.bslli_si128(*(v128*)&x567, sizeof(float));
                hi = Sse4_1.blend_ps(mid, hi, 0b1110);


                this = new float8(*(float4*)&lo, *(float4*)&hi);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = new float4(x012, x34.x),
                    _v4_4 = new float4(x34.y, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float3 x012, float3 x345, float2 x67)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 mid = Sse2.bsrli_si128(*(v128*)&x345, sizeof(float));
                v128 hi = Sse2.unpacklo_pd(mid, *(v128*)&x67);

                mid = Sse2.bslli_si128(*(v128*)&x345, 3 * sizeof(float));

                v128 lo = Sse4_1.blend_ps(*(v128*)&x012, mid, 0b1000);


                this = new float8(*(float4*)&lo, *(float4*)&hi);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = new float4(x012, x345.x),
                    _v4_4 = new float4(x345.yz, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float4 x0123, float2 x45, float2 x67)
        {
            this = new float8(x0123, new float4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float4 x2345, float2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.unpacklo_pd(*(v128*)&x01, *(v128*)&x2345);
                v128 hi = Sse2.bslli_si128(*(v128*)&x67, 2 * sizeof(float));
                hi = Sse2.unpackhi_pd(*(v128*)&x2345, hi);

                this = new float8(*(float4*)&lo, *(float4*)&hi);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = new float4(x01, x2345.xy),
                    _v4_4 = new float4(x2345.zw, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float2 x01, float2 x23, float4 x4567)
        {
            this = new float8(new float4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float8(float4 x0123, float4 x4567)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128(*(v128*)&x4567, *(v128*)&x0123);
            }
            else
            {
                this = new float8
                {
                    _v4_0 = x0123,
                    _v4_4 = x4567
                };
            }
        }


        #region Shuffle
        public float4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(this);

                    return *(float4*)&temp;
                }
                else
                {
                    return _v4_0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_1111);
                }
                else
                {
                    this._v4_0 = value;
                }
            }
        }
        public float4 v4_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(1, 2, 3, 4))));

                    return *(float4*)&temp;
                }
                else
                {
                    return math.shuffle(_v4_0, _v4_4, math.ShuffleComponent.LeftY,
                                                      math.ShuffleComponent.LeftZ,
                                                      math.ShuffleComponent.LeftW,
                                                      math.ShuffleComponent.RightX);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 2, 3, 0, 0, 0)), 0b0001_1110);
                }
                else
                {
                    this._v4_0 = math.shuffle(_v4_0, value, math.ShuffleComponent.LeftX,
                                                            math.ShuffleComponent.RightX,
                                                            math.ShuffleComponent.RightY,
                                                            math.ShuffleComponent.RightZ);

                    this._v4_4 = math.shuffle(_v4_4, value, math.ShuffleComponent.RightW,
                                                            math.ShuffleComponent.LeftY,
                                                            math.ShuffleComponent.LeftZ,
                                                            math.ShuffleComponent.LeftW);
                }
            }
        }
        public float4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return *(float4*)&temp;
                }
                else
                {
                    return math.shuffle(_v4_0, _v4_4, math.ShuffleComponent.LeftZ,
                                                      math.ShuffleComponent.LeftW,
                                                      math.ShuffleComponent.RightX,
                                                      math.ShuffleComponent.RightY);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 3, 0, 0)), 0b0011_1100);
                }
                else
                {
                    this._v4_0 = math.shuffle(_v4_0, value, math.ShuffleComponent.LeftX,
                                                            math.ShuffleComponent.LeftY,
                                                            math.ShuffleComponent.RightX,
                                                            math.ShuffleComponent.RightY);

                    this._v4_4 = math.shuffle(_v4_4, value, math.ShuffleComponent.RightZ,
                                                            math.ShuffleComponent.RightW,
                                                            math.ShuffleComponent.LeftZ,
                                                            math.ShuffleComponent.LeftW);
                }
            }
        }
        public float4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 6))));

                    return *(float4*)&temp;
                }
                else
                {
                    return math.shuffle(_v4_0, _v4_4, math.ShuffleComponent.LeftW,
                                                      math.ShuffleComponent.RightX,
                                                      math.ShuffleComponent.RightY,
                                                      math.ShuffleComponent.RightZ);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 3, 0)), 0b0111_1000);
                }
                else
                {
                    this._v4_0 = math.shuffle(_v4_0, value, math.ShuffleComponent.LeftX,
                                                            math.ShuffleComponent.LeftY,
                                                            math.ShuffleComponent.LeftZ,
                                                            math.ShuffleComponent.RightX);

                    this._v4_4 = math.shuffle(_v4_4, value, math.ShuffleComponent.RightY,
                                                            math.ShuffleComponent.RightZ,
                                                            math.ShuffleComponent.RightW,
                                                            math.ShuffleComponent.LeftW);
                }
            }
        }
        public float4 v4_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx2.mm256_extracti128_si256(this, 1);

                    return *(float4*)&temp;
                }
                else
                {
                    return _v4_4;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 3)), 0b1111_0000);
                }
                else
                {
                    this._v4_4 = value;
                }
            }
        }
                                                                                                                                                                                                                                                    
        public float3 v3_0
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(this);

                    return *(float3*)&temp;
                }
                else
                {
                    return _v4_0.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_0111);
                }
                else
                {
                    this._v4_0.xyz = value;
                }
            }
        }
        public float3 v3_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(float));

                    return *(float3*)&temp;
                }
                else
                {
                    return _v4_0.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castsi128_si256(Sse2.shuffle_epi32(*(v128*)&value, Sse.SHUFFLE(2, 1, 0, 0))), 0b0000_1110);
                }
                else
                {
                    this._v4_0.yzw = value;
                }
            }
        }
        public float3 v3_2
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return *(float3*)&temp;
                }
                else
                {
                    return new float3(_v4_0.zw, _v4_4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 0, 0, 0)), 0b0001_1100);
                }
                else
                {
                    this._v4_0.zw = value.xy;
                    this._v4_4.x  = value.z;
                }
            }
        }
        public float3 v3_3
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 0))));

                    return *(float3*)&temp;
                }
                else
                {
                    return new float3(_v4_0.w, _v4_4.xy);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 0, 0)), 0b0011_1000);
                }
                else
                {
                    this._v4_0.w  = value.x;
                    this._v4_4.xy = value.yz;
                }
            }
        }
        public float3 v3_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx2.mm256_extracti128_si256(this, 1);

                    return *(float3*)&temp;
                }
                else
                {
                    return _v4_4.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 0)), 0b0111_0000);
                }
                else
                {
                    this._v4_4.xyz = value;
                }
            }
        }
        public float3 v3_5
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(5, 6, 7, 0))));

                    return *(float3*)&temp;
                }
                else
                {
                    return _v4_4.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 2)), 0b1110_0000);
                }
                else
                {
                    this._v4_4.yzw = value;
                } 
            }
        }
                                                                                                                                                                                                                                            
        public float2 v2_0
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(this);

                    return *(float2*)&temp;
                }
                else
                {
                    return _v4_0.xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 0);
                }
                else
                {
                    this._v4_0.xy = value;
                }
            }
        }
        public float2 v2_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(float));

                    return *(float2*)&temp;
                }
                else
                {
                    return _v4_0.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castsi128_si256(Sse2.shuffle_epi32(*(v128*)&value, Sse.SHUFFLE(0, 1, 0, 0))), 0b0000_0110);
                }
                else
                {
                    this._v4_0.yz = value;
                }
            }
        }
        public float2 v2_2
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(float));

                    return *(float2*)&temp;
                }
                else
                {
                    return _v4_0.zw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 1);
                }
                else
                {
                    this._v4_0.zw = value;
                }
            }
        }
        public float2 v2_3
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(3, 4, 0, 0))));

                    return *(float2*)&temp;
                }
                else
                {
                    return new float2(_v4_0.w, _v4_4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 0, 0, 0)), 0b0001_1000);
                }
                else
                {
                    this._v4_0.w = value.x;
                    this._v4_4.x = value.y;
                }
            }
        }
        public float2 v2_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx2.mm256_extracti128_si256(this, 1);

                    return *(float2*)&temp;
                }
                else
                {
                    return _v4_4.xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 2);
                }
                else
                {
                    this._v4_4.xy = value;
                }
            }
        }
        public float2 v2_5
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_ps(this, Avx.mm256_castsi128_si256(new v128(5, 6, 0, 0))));

                    return *(float2*)&temp;
                }
                else
                {
                    return _v4_4.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permutevar8x32_ps(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 0)), 0b0110_0000);
                }
                else
                {
                    this._v4_4.yz = value;
                }
            }
        }
        public float2 v2_6
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));

                    return *(float2*)&temp;
                }
                else
                {
                    return _v4_4.zw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 3);
                }
                else
                {
                    this._v4_4.zw = value;
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(float8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator float8(v256 input) => new float8 { x0 = input.Float0, x1 = input.Float1, x2 = input.Float2, x3 = input.Float3, x4 = input.Float4, x5 = input.Float5, x6 = input.Float6, x7 = input.Float7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(float input) => new float8(input);


        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                asArray[index] = value;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator + (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_ps(left, right);
            }
            else
            {
                return new float8(left._v4_0 + right._v4_0, left._v4_4 + right._v4_4);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(left, right);
            }
            else
            {
                return new float8(left._v4_0 - right._v4_0, left._v4_4 - right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator * (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_mul_ps(left, right);
            }
            else
            {
                return new float8(left._v4_0 * right._v4_0, left._v4_4 * right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator / (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_div_ps(left, right);
            }
            else
            {
                return new float8(left._v4_0 / right._v4_0, left._v4_4 / right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator % (float8 left, float8 right)
        {
        //    v256 ymm0, ymm1, ymm2, ymm3, ymm4, ymm5, ymm6, ymm7, ymm8, ymm9, ymm10, ymm11, ymm12, ymm13, ymm14, ymm15 = default;
        //
        //    ymm9 = left;
        //    ymm12 = default;
        //
        //    ymm2 = (float8)math.asfloat(0x7FFF_FFFF);
        //
        //    ymm1 = Avx.mm256_and_ps(ymm9, ymm2);
        //    ymm0 = Avx.mm256_and_ps(right, ymm2);
        //
        //    ymm2 = (float8)math.asfloat(0x0080_0000);
        //
        //    ymm10 = Avx.mm256_cmp_ps(ymm0, ymm2, (int)Avx.CMP.LT_OQ);
        //
        //    ymm2 = (float8)math.asfloat(0x4C00_0000);
        //
        //    ymm3 = Avx.mm256_mul_ps(ymm1, ymm2);
        //    ymm8 = Avx.mm256_blendv_ps(ymm1, ymm3, ymm10);
        //    ymm1 = Avx.mm256_mul_ps(ymm0, ymm2);
        //    ymm2 = Avx.mm256_blendv_ps(ymm0, ymm1, ymm10);
        //
        //    ymm0 = Avx.mm256_rcp_ps(ymm2);
        //
        //    ymm13 = (float8)math.asfloat(0x3F80_0000);
        //    ymm1 = ymm0;
        //
        //    ymm1 = Fma.mm256_fnmadd_ps(ymm1, ymm2, ymm13);
        //    ymm1 = Fma.mm256_fmadd_ps(ymm1, ymm0, ymm0);
        //
        //    ymm11 = new int8(-1);
        //
        //    ymm0 = Avx2.mm256_add_epi32(ymm11, ymm1);
        //
        //    ymm1 = Avx.mm256_cmp_ps(ymm12, ymm1, (int)Avx.CMP.NEQ_UQ);
        //    ymm14 = Avx.mm256_and_ps(ymm1, ymm0);
        //
        //    ymm0 = (float8)math.asfloat(0x4040_0000);
        //
        //    ymm15 = Avx.mm256_mul_ps(ymm2, ymm0);
        //    ymm0 = Avx.mm256_add_ps(ymm2, ymm2);
        //    ymm3 = Avx.mm256_xor_ps(ymm2, (float8)math.asfloat(0x8000_0000));
        //
        //    ymm6 = (float8)math.asfloat(0x4000_0000);
        //
        //    ymm5 = ymm8;
        //
        //    byte cmp = 0;
        //
        //LBB0_1:
        //
        //    ymm4 = Avx2.mm256_add_epi32(ymm11, ymm5);
        //    ymm7 = Avx.mm256_cmp_ps(ymm12, ymm5, (int)Avx.CMP.NEQ_UQ);
        //    ymm4 = Avx.mm256_and_ps(ymm7, ymm4);
        //    ymm4 = Avx.mm256_mul_ps(ymm14, ymm4);
        //    ymm4 = Avx.mm256_round_ps(ymm4, (int)X86.RoundingMode.FROUND_TRUNC_NOEXC);
        //
        //    ymm7 = Avx.mm256_cmp_ps(ymm15, ymm5, (int)Avx.CMP.GT_OQ);
        //    ymm1 = Avx.mm256_cmp_ps(ymm5, ymm2, (int)Avx.CMP.GE_OQ);
        //
        //    ymm7 = Avx.mm256_and_ps(ymm1, ymm7);
        //    ymm4 = Avx.mm256_blendv_ps(ymm4, ymm6, ymm7);
        //
        //    ymm7 = Avx.mm256_cmp_ps(ymm0, ymm5, (int)Avx.CMP.GT_OQ);
        //    ymm1 = Avx.mm256_and_ps(ymm7, ymm1);
        //    ymm1 = Avx.mm256_blendv_ps(ymm4, ymm13, ymm1);
        //
        //    ymm1 = Avx.mm256_round_ps(ymm1, (int)X86.RoundingMode.FROUND_TRUNC_NOEXC);
        //
        //    ymm4 = Avx.mm256_mul_ps(ymm1, ymm3);
        //
        //    ymm1 = Fma.mm256_fmsub_ps(ymm1, ymm3, ymm4);
        //
        //    ymm1 = Avx.mm256_add_ps(ymm5, ymm1);
        //    ymm5 = Avx.mm256_add_ps(ymm4, ymm1);
        //
        //
        //    if (cmp > 6) goto LBB0_2;
        //
        //    ymm1 = Avx.mm256_cmp_ps(ymm5, ymm2, (int)Avx.CMP.LT_OQ);
        //    short test = (short)Avx2.mm256_movemask_epi8(ymm1);
        //    cmp++;
        //
        //    if (test != -1) goto LBB0_1;
        //
        //LBB0_2: 
        //
        //    ymm0 = (float8)math.asfloat(0x3300_0000);
        //    ymm0 = Avx.mm256_blendv_ps(ymm13, ymm0, ymm10);
        //
        //    ymm0 = Avx.mm256_mul_ps(ymm0, ymm5);
        //
        //    ymm1 = Avx.mm256_cmp_ps(ymm5, ymm2, (int)Avx.CMP.NEQ_UQ);
        //
        //    ymm0 = Avx.mm256_and_ps(ymm1, ymm0);
        //
        //    ymm1 = default;
        //
        //    ymm3 = Avx.mm256_and_ps(ymm9, (float8)math.asfloat(0x8000_0000));
        //    ymm0 = Avx.mm256_xor_ps(ymm3, ymm0);
        //    ymm3 = Avx.mm256_cmp_ps(ymm8, ymm2, (int)Avx.CMP.LT_OQ);
        //
        //    ymm0 = Avx.mm256_blendv_ps(ymm0, ymm9, ymm3);
        //    ymm1 = Avx.mm256_cmp_ps(ymm2, ymm1, (int)Avx.CMP.EQ_OQ);
        //    ymm2 = (float8)math.asfloat(0x7FC0_0000);
        //
        //    return Avx.mm256_blendv_ps(ymm0, ymm2, ymm1);



            return new float8(left.v4_0 % right.v4_0, left.v4_4 % right.v4_4);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_xor_ps(x, new v256(1 << 31));
            }
            else
            {
                return new float8(-x._v4_0, -x._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator ++ (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_add_ps(x, new float8(1f));
            }
            else
            {
                return new float8(x._v4_0 + 1f, x._v4_4 + 1f);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator -- (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sub_ps(x, new float8(1f));
            }
            else
            {
                return new float8(x._v4_0 - 1f, x._v4_4 - 1f);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.EQ_OQ));
            }
            else
            {
                return new bool8(left._v4_0 == right._v4_0, left._v4_4 == right._v4_4);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.LT_OS));
            }
            else
            {
                return new bool8(left._v4_0 < right._v4_0, left._v4_4 < right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.GT_OS));
            }
            else
            {
                return new bool8(left._v4_0 > right._v4_0, left._v4_4 > right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.NEQ_UQ));
            }
            else
            {
                return new bool8(left._v4_0 != right._v4_0, left._v4_4 != right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.LE_OS));
            }
            else
            {
                return new bool8(left._v4_0 <= right._v4_0, left._v4_4 <= right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (float8 left, float8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return TestIsTrue(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.GE_OS));
            }
            else
            {
                return new bool8(left._v4_0 >= right._v4_0, left._v4_4 >= right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v256 input)
        {
            return (v128)((byte8)(-(int8)input));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float8 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return maxmath.bitmask32(8) == Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(this, other, (int)Avx.CMP.EQ_OQ));
            }
            else
            {
                return this._v4_0.Equals(other._v4_0) & this._v4_4.Equals(other._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object obj) => Equals((float8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Avx.IsAvxSupported)
            {
                return Hash.v256(this);
            }
            else
            {
                float8 temp = this;

                return ((*(ulong*)&temp ^ *((ulong*)&temp + 1)) ^ (*((ulong*)&temp + 2) ^ *((ulong*)&temp + 3))).GetHashCode();
            }
        }

        public override readonly string ToString() => $"float8({x0}f, {x1}f, {x2}f, {x3}f,    {x4}f, {x5}f, {x6}f, {x7}f)";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"float8({x0.ToString(format, formatProvider)}f, {x1.ToString(format, formatProvider)}f, {x2.ToString(format, formatProvider)}f, {x3.ToString(format, formatProvider)}f,    {x4.ToString(format, formatProvider)}f, {x5.ToString(format, formatProvider)}f, {x6.ToString(format, formatProvider)}f, {x7.ToString(format, formatProvider)}f)";
    }
}