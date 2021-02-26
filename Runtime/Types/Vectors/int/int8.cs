using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(int))]  [DebuggerTypeProxy(typeof(int8.DebuggerProxy))]
    unsafe public struct int8 : IEquatable<int8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public int x0;
            public int x1;
            public int x2;
            public int x3;
            public int x4;
            public int x5;
            public int x6;
            public int x7;

            public DebuggerProxy(int8 v)
            {
                x0 = v.x0;
                x1 = v.x1;
                x2 = v.x2;
                x3 = v.x3;
                x4 = v.x4;
                x5 = v.x5;
                x6 = v.x6;
                x7 = v.x7;
            }
        }


        [FieldOffset(0)]  private fixed int asArray[8];

        [FieldOffset(0)]  internal int4 _v4_0;
        [FieldOffset(16)] internal int4 _v4_4;

        [FieldOffset(0)]  public int x0;
        [FieldOffset(4)]  public int x1;
        [FieldOffset(8)]  public int x2;
        [FieldOffset(12)] public int x3;
        [FieldOffset(16)] public int x4;
        [FieldOffset(20)] public int x5;
        [FieldOffset(24)] public int x6;
        [FieldOffset(28)] public int x7;


        public static int8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0, int x1, int x2, int x3, int x4, int x5, int x6, int x7)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi32(x7, x6, x5, x4, x3, x2, x1, x0);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = new int4(x0, x1, x2, x3),
                    _v4_4 = new int4(x4, x5, x6, x7),
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int x0x8)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_epi32(x0x8);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = new int4(x0x8),
                    _v4_4 = new int4(x0x8),
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int2 x45, int2 x67)
        {
            this = new int8(new int4(x01, x23), new int4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int3 x234, int3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.unpacklo_epi64(*(v128*)&x01, *(v128*)&x234);
                v128 mid = Sse2.bsrli_si128(*(v128*)&x234, 2 * sizeof(int));
                v128 hi = Sse2.bslli_si128(*(v128*)&x567, sizeof(int));

                if (Sse4_1.IsSse41Supported)
                {
                    hi = Sse4_1.blend_epi16(mid, hi, 0b1111_1100);
                }
                else
                {
                    hi = Mask.BlendEpi16_SSE2(mid, hi, 0b1111_1100);
                }


                this = new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = new int4(x01, x234.xy),
                    _v4_4 = new int4(x234.z, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int2 x34, int3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo;
                v128 mid = Sse2.bslli_si128(*(v128*)&x34, 3 * sizeof(int)); 
                
                if (Sse4_1.IsSse41Supported)
                {
                    lo = Sse4_1.blend_epi16(*(v128*)&x012, mid, 0b1100_0000);
                }
                else
                {
                    lo = Mask.BlendEpi16_SSE2(*(v128*)&x012, mid, 0b1100_0000);
                }

                mid = Sse2.bsrli_si128(*(v128*)&x34, sizeof(int));

                v128 hi = Sse2.bslli_si128(*(v128*)&x567, sizeof(int));

                if (Sse4_1.IsSse41Supported)
                {
                    hi = Sse4_1.blend_epi16(mid, hi, 0b1111_1100);
                }
                else
                {
                    hi = Mask.BlendEpi16_SSE2(mid, hi, 0b1111_1100);
                }


                this = new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = new int4(x012, x34.x),
                    _v4_4 = new int4(x34.y, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int3 x012, int3 x345, int2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo;
                v128 mid = Sse2.bsrli_si128(*(v128*)&x345, sizeof(int));
                v128 hi = Sse2.unpacklo_epi64(mid, *(v128*)&x67);

                mid = Sse2.bslli_si128(*(v128*)&x345, 3 * sizeof(int));

                if (Sse4_1.IsSse41Supported)
                {
                    lo = Sse4_1.blend_epi16(*(v128*)&x012, mid, 0b1100_0000);
                }
                else
                {
                    lo = Mask.BlendEpi16_SSE2(*(v128*)&x012, mid, 0b1100_0000);
                }


                this = new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = new int4(x012, x345.x),
                    _v4_4 = new int4(x345.yz, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int2 x45, int2 x67)
        {
            this = new int8(x0123, new int4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int4 x2345, int2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.unpacklo_epi64(*(v128*)&x01, *(v128*)&x2345);
                v128 hi = Sse2.bslli_si128(*(v128*)&x67, 2 * sizeof(int));
                hi = Sse2.unpackhi_epi64(*(v128*)&x2345, hi);

                this = new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = new int4(x01, x2345.xy),
                    _v4_4 = new int4(x2345.zw, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int2 x01, int2 x23, int4 x4567)
        {
            this = new int8(new int4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int8(int4 x0123, int4 x4567)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(*(v128*)&x4567, *(v128*)&x0123);
            }
            else
            {
                this = new int8
                {
                    _v4_0 = x0123,
                    _v4_4 = x4567
                };
            }
        }


        #region Shuffle
        public int4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(this);

                    return *(int4*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_1111);
                }
                else
                {
                    this._v4_0 = value;
                }
            }
        }
        public int4 v4_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(1, 2, 3, 4))));

                    return *(int4*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 1, 2, 3, 0, 0, 0)), 0b0001_1110);
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
        public int4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return *(int4*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 3, 0, 0)), 0b0011_1100);
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
        public int4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 6))));

                    return *(int4*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 3, 0)), 0b0111_1000);
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
        public int4 v4_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx2.mm256_extracti128_si256(this, 1);

                    return *(int4*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 3)), 0b1111_0000);
                }
                else
                {
                    this._v4_4 = value;
                }
            }
        }
                                                                                                                                                                                                                                                    
        public int3 v3_0
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(this);

                    return *(int3*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(*(v128*)&value), 0b0000_0111);
                }
                else
                {
                    this._v4_0.xyz = value;
                }
            }
        }
        public int3 v3_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(int));

                    return *(int3*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Sse2.shuffle_epi32(*(v128*)&value, Sse.SHUFFLE(2, 1, 0, 0))), 0b0000_1110);
                }
                else
                {
                    this._v4_0.yzw = value;
                }
            }
        }
        public int3 v3_2
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return *(int3*)&temp;
                }
                else
                {
                    return new int3(_v4_0.zw, _v4_4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 1, 2, 0, 0, 0)), 0b0001_1100);
                }
                else
                {
                    this._v4_0.zw = value.xy;
                    this._v4_4.x  = value.z;
                }
            }
        }
        public int3 v3_3
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 5, 0))));

                    return *(int3*)&temp;
                }
                else
                {
                    return new int3(_v4_0.w, _v4_4.xy);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 2, 0, 0)), 0b0011_1000);
                }
                else
                {
                    this._v4_0.w  = value.x;
                    this._v4_4.xy = value.yz;
                }
            }
        }
        public int3 v3_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx2.mm256_extracti128_si256(this, 1);

                    return *(int3*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 1, 2, 0)), 0b0111_0000);
                }
                else
                {
                    this._v4_4.xyz = value;
                }
            }
        }
        public int3 v3_5
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5, 6, 7, 0))));

                    return *(int3*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 2)), 0b1110_0000);
                }
                else
                {
                    this._v4_4.yzw = value;
                } 
            }
        }
                                                                                                                                                                                                                                            
        public int2 v2_0
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(this);

                    return *(int2*)&temp;
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
        public int2 v2_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(int));

                    return *(int2*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Sse2.shuffle_epi32(*(v128*)&value, Sse.SHUFFLE(0, 1, 0, 0))), 0b0000_0110);
                }
                else
                {
                    this._v4_0.yz = value;
                }
            }
        }
        public int2 v2_2
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx.IsAvxSupported)
                {
                    v128 temp = Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(int));

                    return *(int2*)&temp;
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
        public int2 v2_3
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 0, 0))));

                    return *(int2*)&temp;
                }
                else
                {
                    return new int2(_v4_0.w, _v4_4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 1, 0, 0, 0)), 0b0001_1000);
                }
                else
                {
                    this._v4_0.w = value.x;
                    this._v4_4.x = value.y;
                }
            }
        }
        public int2 v2_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx2.mm256_extracti128_si256(this, 1);

                    return *(int2*)&temp;
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
        public int2 v2_5
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5, 6, 0, 0))));

                    return *(int2*)&temp;
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permutevar8x32_epi32(Avx.mm256_castsi128_si256(*(v128*)&value), new v256(0, 0, 0, 0, 0, 0, 1, 0)), 0b0110_0000);
                }
                else
                {
                    this._v4_4.yz = value;
                }
            }
        }
        public int2 v2_6
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
             get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 temp = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));

                    return *(int2*)&temp;
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
        public static implicit operator v256(int8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator int8(v256 input) => new int8 { x0 = input.SInt0, x1 = input.SInt1, x2 = input.SInt2, x3 = input.SInt3, x4 = input.SInt4, x5 = input.SInt5, x6 = input.SInt6, x7 = input.SInt7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(int input) => new int8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(uint8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return (v256)input;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new int8((int4)input._v4_0, (int4)input._v4_4);
            }
            else
            {
                return *(int8*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(half8 input) => (int8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int8(float8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvttps_epi32(input);
            }
            else
            {
                return new int8((int4)input._v4_0, (int4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(int8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(int8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_ps(input);
            }
            else
            {
                return new float8((float4)input._v4_0, (float4)input._v4_4);
            }
        }


        public int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get
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
        public static int8 operator + (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi32(left, right);
            }
            else
            {
                return new int8(left._v4_0 + right._v4_0, left._v4_4 + right._v4_4);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(left, right);
            }
            else
            {
                return new int8(left._v4_0 - right._v4_0, left._v4_4 - right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi32(left, right);
            }
            else
            {
                return new int8(left._v4_0 * right._v4_0, left._v4_4 * right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new int8((left.x0 / right.x0), (left.x1 / right.x1), (left.x2 / right.x2), (left.x3 / right.x3), (left.x4 / right.x4), (left.x5 / right.x5), (left.x6 / right.x6), (left.x7 / right.x7));
            }
            else
            {
                return new int8(left._v4_0 / right._v4_0, left._v4_4 / right._v4_4);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new int8((left.x0 % right.x0), (left.x1 % right.x1), (left.x2 % right.x2), (left.x3 % right.x3), (left.x4 % right.x4), (left.x5 % right.x5), (left.x6 % right.x6), (left.x7 % right.x7));
            }
            else
            {
                return new int8(left._v4_0 % right._v4_0, left._v4_4 % right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int left, int8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator * (int8 left, int right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new int8((left.x0 * right), (left.x1 * right), (left.x2 * right), (left.x3 * right), (left.x4 * right), (left.x5 * right), (left.x6 * right), (left.x7 * right));
            }
            else
            {
                return new int8(left._v4_0 * right, left._v4_4 * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator / (int8 left, int right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new int8((left.x0 / right), (left.x1 / right), (left.x2 / right), (left.x3 / right), (left.x4 / right), (left.x5 / right), (left.x6 / right), (left.x7 / right));
            }
            else
            {
                return new int8(left._v4_0 / right, left._v4_4 / right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator % (int8 left, int right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new int8((left.x0 % right), (left.x1 % right), (left.x2 % right), (left.x3 % right), (left.x4 % right), (left.x5 % right), (left.x6 % right), (left.x7 % right));
            }
            else
            {
                return new int8(left._v4_0 % right, left._v4_4 % right);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator & (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(left, right);
            }
            else
            {
                return new int8(left._v4_0 & right._v4_0, left._v4_4 & right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator | (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_or_si256(left, right);
            }
            else
            {
                return new int8(left._v4_0 | right._v4_0, left._v4_4 | right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ^ (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(left, right);
            }
            else
            {
                return new int8(left._v4_0 ^ right._v4_0, left._v4_4 ^ right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator - (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(default(v256), x);
            }
            else
            {
                return new int8(-x._v4_0, -x._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ++ (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi32(x, new int8(1));
            }
            else
            {
                return new int8(x._v4_0 + 1, x._v4_4 + 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator -- (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(x, new int8(1));
            }
            else
            {
                return new int8(x._v4_0 - 1, x._v4_4 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator ~ (int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(x, new int8(-1));
            }
            else
            {
                return new int8(~x._v4_0, ~x._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator << (int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shl_int(x, n);
            }
            else
            {
                return new int8(x._v4_0 << n, x._v4_4 << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 operator >> (int8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shra_int(x, n);
            }
            else
            {
                return new int8(x._v4_0 >> n, x._v4_4 >> n);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpeq_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 == right._v4_0, left._v4_4 == right._v4_4);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpgt_epi32(right, left));
            }
            else
            {
                return new bool8(left._v4_0 < right._v4_0, left._v4_4 < right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpgt_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 > right._v4_0, left._v4_4 > right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpeq_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 != right._v4_0, left._v4_4 != right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpgt_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 <= right._v4_0, left._v4_4 <= right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (int8 left, int8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpgt_epi32(right, left));
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
        private static bool8 TestIsFalse(v256 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128((byte8)(int8)input, new byte8(1));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  bool Equals(int8 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return uint.MaxValue == (uint)Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(this, other));
            }
            else
            {
                return this._v4_0.Equals(other._v4_0) & this._v4_4.Equals(other._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  bool Equals(object obj) => Equals((int8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v256((v256)this);
            }
            else
            {
                int8 temp = this;

                return ((*(ulong*)&temp ^ *((ulong*)&temp + 1)) ^ (*((ulong*)&temp + 2) ^ *((ulong*)&temp + 3))).GetHashCode();
            }
        }

        public override  string ToString() => $"int8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"int8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}