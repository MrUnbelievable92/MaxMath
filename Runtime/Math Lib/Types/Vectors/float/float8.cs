using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]  
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(float))]
    unsafe public struct float8 : IEquatable<float8>, IFormattable
    {
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
            if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.unpacklo_pd(RegisterConversion.ToV128(x01), RegisterConversion.ToV128(x234));
                v128 mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x234), 2 * sizeof(float));
                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x567), sizeof(float));

                if (Sse4_1.IsSse41Supported)
                {
                    hi = Sse4_1.blend_ps(mid, hi, 0b1110);
                }
                else
                {
                    hi = Xse.blendv_ps(mid, hi, new v128(0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                }


                this = new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
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
                v128 mid = Sse2.bslli_si128(RegisterConversion.ToV128(x34), 3 * sizeof(float));
                v128 lo = Sse4_1.blend_ps(RegisterConversion.ToV128(x012), mid, 0b1000);

                mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x34), sizeof(float));

                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x567), sizeof(float));
                hi = Sse4_1.blend_ps(mid, hi, 0b1110);


                this = new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(RegisterConversion.ToV128(x34), 3 * sizeof(float));
                v128 lo = Xse.blendv_ps(RegisterConversion.ToV128(x012), mid, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255));

                mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x34), sizeof(float));

                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x567), sizeof(float));
                hi = Xse.blendv_ps(mid, hi, new v128(0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));


                this = new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
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
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x345), sizeof(float));
                v128 hi = Sse2.unpacklo_pd(mid, RegisterConversion.ToV128(x67));

                mid = Sse2.bslli_si128(RegisterConversion.ToV128(x345), 3 * sizeof(float));
                v128 lo;

                if (Sse4_1.IsSse41Supported)
                {
                    lo = Sse4_1.blend_ps(RegisterConversion.ToV128(x012), mid, 0b1000);
                }
                else
                {
                    lo = Xse.blendv_ps(RegisterConversion.ToV128(x012), mid, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255));
                }


                this = new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
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
                v128 lo = Sse2.unpacklo_pd(RegisterConversion.ToV128(x01), RegisterConversion.ToV128(x2345));
                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x67), 2 * sizeof(float));
                hi = Sse2.unpackhi_pd(RegisterConversion.ToV128(x2345), hi);

                this = new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
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
                this = Avx.mm256_set_m128(RegisterConversion.ToV128(x4567), RegisterConversion.ToV128(x0123));
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
                    return RegisterConversion.ToFloat4(Avx.mm256_castps256_ps128(this));
                }
                else
                {
                    return _v4_0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 0b0000_1111);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat4(Ssse3.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 1 * sizeof(float)));
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
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 1), 0b0001_1110);
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
                    return RegisterConversion.ToFloat4(Avx.mm256_castps256_ps128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 2, 1))));
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
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permute4x64_pd(Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), Sse.SHUFFLE(0, 1, 0, 0)), 0b0011_1100);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat4(Ssse3.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 3 * sizeof(float)));
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
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 3), 0b0111_1000);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat4(Avx.mm256_extractf128_ps(this, 1));
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
                    this = Avx.mm256_insertf128_ps(this, RegisterConversion.ToV128(value), 1);
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
                    return RegisterConversion.ToFloat3(Avx.mm256_castps256_ps128(this));
                }
                else
                {
                    return _v4_0.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 0b0000_0111);
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
                    return RegisterConversion.ToFloat3(Sse2.bsrli_si128(Avx.mm256_castps256_ps128(this), sizeof(float)));
                }
                else
                {
                    return _v4_0.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(Sse2.shuffle_epi32(RegisterConversion.ToV128(value), Sse.SHUFFLE(2, 1, 0, 0))), 0b0000_1110);
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
                    return RegisterConversion.ToFloat3(Avx.mm256_castps256_ps128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 2, 1))));
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
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permute4x64_pd(Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), Sse.SHUFFLE(0, 1, 0, 0)), 0b0001_1100);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat3(Ssse3.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 3 * sizeof(float)));
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
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 3), 0b0011_1000);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat3(Avx.mm256_extractf128_ps(this, 1));
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
                    this = Avx.mm256_blend_ps(this, Avx2.mm256_permute4x64_pd(Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), Sse.SHUFFLE(1, 0, 0, 0)), 0b0111_0000);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat3(Sse2.bsrli_si128(Avx.mm256_extractf128_ps(this, 1), 1 * sizeof(float)));
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
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 5), 0b1110_0000);
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
                    return RegisterConversion.ToFloat2(Avx.mm256_castps256_ps128(this));
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
                    return RegisterConversion.ToFloat2(Sse2.bsrli_si128(Avx.mm256_castps256_ps128(this), sizeof(float)));
                }
                else
                {
                    return _v4_0.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_blend_ps(this, Avx.mm256_castps128_ps256(Sse2.shuffle_epi32(RegisterConversion.ToV128(value), Sse.SHUFFLE(0, 1, 0, 0))), 0b0000_0110);
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
                    return RegisterConversion.ToFloat2(Sse2.bsrli_si128(Avx.mm256_castps256_ps128(this), 2 * sizeof(float)));
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat2(Ssse3.alignr_epi8(Avx.mm256_castps256_ps128(this), Avx.mm256_extractf128_ps(this, 1), 3 * sizeof(float)));
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
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 3), 0b0001_1000);
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat2(Avx.mm256_extractf128_ps(this, 1));
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
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToFloat2(Sse2.bsrli_si128(Avx.mm256_extractf128_ps(this, 1), 1 * sizeof(float)));
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
                    this = Avx.mm256_blend_ps(this, vrol((float8)Avx.mm256_castps128_ps256(RegisterConversion.ToV128(value)), 5), 0b0110_0000);
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
                    return RegisterConversion.ToFloat2(Avx.mm256_castps256_ps128(Avx2.mm256_permute4x64_pd(this, Sse.SHUFFLE(0, 0, 0, 3))));
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(float8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(v256 input) => new float8{ x0 = input.Float0, x1 = input.Float1, x2 = input.Float2, x3 = input.Float3, x4 = input.Float4, x5 = input.Float5, x6 = input.Float6, x7 = input.Float7 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(quarter input) => new float8((float)input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(half input) => new float8((float)input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(float input) => new float8(input);


        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Avx.IsAvxSupported)
                {
                    return Xse.mm256_extract_ps(this, (byte)index);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(index))
                    {
                        if (index < 4)
                        {
                            return Xse.extract_ps(RegisterConversion.ToV128(_v4_0), (byte)index);
                        }
                        else
                        {
                            return Xse.extract_ps(RegisterConversion.ToV128(_v4_4), (byte)(index - 4));
                        }
                    }
                }

                float8 onStack = this;
                
                return *((float*)&onStack + index);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);
                
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_ps(this, value, (byte)index);

                    return;
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(index))
                    {
                        if (index < 4)
                        {
                            _v4_0 = RegisterConversion.ToFloat4(Xse.insert_ps(RegisterConversion.ToV128(_v4_0), value, (byte)index));
                        }
                        else
                        {
                            _v4_4 = RegisterConversion.ToFloat4(Xse.insert_ps(RegisterConversion.ToV128(_v4_4), value, (byte)(index - 4)));
                        }

                        return;
                    }
                }

                float8 onStack = this;
                *((float*)&onStack + index) = value;
                this = onStack;
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
            return fmod(left, right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 operator - (float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_neg_ps(x);
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
                return RegisterConversion.IsTrue32(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.EQ_OQ));
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
                return RegisterConversion.IsTrue32(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.LT_OS));
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
                return RegisterConversion.IsTrue32(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.GT_OS));
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
                return RegisterConversion.IsTrue32(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.NEQ_UQ));
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
                return RegisterConversion.IsTrue32(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.LE_OS));
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
                return RegisterConversion.IsTrue32(Avx.mm256_cmp_ps(left, right, (int)Avx.CMP.GE_OS));
            }
            else
            {
                return new bool8(left._v4_0 >= right._v4_0, left._v4_4 >= right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float8 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return bitmask32(8) == Avx.mm256_movemask_ps(Avx.mm256_cmp_ps(this, other, (int)Avx.CMP.EQ_OQ));
            }
            else
            {
                return this._v4_0.Equals(other._v4_0) & this._v4_4.Equals(other._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object obj) => obj is float8 converted && this.Equals(converted);


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