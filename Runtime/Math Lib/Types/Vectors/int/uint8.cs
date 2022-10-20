using System;
using System.Diagnostics;
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
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(uint))]  
    [DebuggerTypeProxy(typeof(uint8.DebuggerProxy))]
    unsafe public struct uint8 : IEquatable<uint8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public uint x0;
            public uint x1;
            public uint x2;
            public uint x3;
            public uint x4;
            public uint x5;
            public uint x6;
            public uint x7;

            public DebuggerProxy(uint8 v)
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


        [FieldOffset(0)]  internal uint4 _v4_0;
        [FieldOffset(16)] internal uint4 _v4_4;

        [FieldOffset(0)]  public uint x0;
        [FieldOffset(4)]  public uint x1;
        [FieldOffset(8)]  public uint x2;
        [FieldOffset(12)] public uint x3;
        [FieldOffset(16)] public uint x4;
        [FieldOffset(20)] public uint x5;
        [FieldOffset(24)] public uint x6;
        [FieldOffset(28)] public uint x7;


        public static uint8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi32((int)x7, (int)x6, (int)x5, (int)x4, (int)x3, (int)x2, (int)x1, (int)x0);
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = new uint4(x0, x1, x2, x3),
                    _v4_4 = new uint4(x4, x5, x6, x7),
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint x0x8)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_epi32((int)x0x8);
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = new uint4(x0x8),
                    _v4_4 = new uint4(x0x8),
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint2 x23, uint2 x45, uint2 x67)
        {
            this = new uint8(new uint4(x01, x23), new uint4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint3 x234, uint3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.unpacklo_epi64(RegisterConversion.ToV128(x01), RegisterConversion.ToV128(x234));
                v128 mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x234), 2 * sizeof(uint));
                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x567), sizeof(uint));

                hi = Xse.blend_epi16(mid, hi, 0b1111_1100);

                this = new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = new uint4(x01, x234.xy),
                    _v4_4 = new uint4(x234.z, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint3 x012, uint2 x34, uint3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(RegisterConversion.ToV128(x34), 3 * sizeof(uint)); 
                v128 lo = Xse.blend_epi16(RegisterConversion.ToV128(x012), mid, 0b1100_0000);

                mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x34), sizeof(uint));

                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x567), sizeof(uint));
                hi = Xse.blend_epi16(mid, hi, 0b1111_1100);

                this = new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = new uint4(x012, x34.x),
                    _v4_4 = new uint4(x34.y, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint3 x012, uint3 x345, uint2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                
                v128 mid = Sse2.bsrli_si128(RegisterConversion.ToV128(x345), sizeof(uint));
                v128 hi = Sse2.unpacklo_epi64(mid, RegisterConversion.ToV128(x67));

                mid = Sse2.bslli_si128(RegisterConversion.ToV128(x345), 3 * sizeof(uint));
                v128 lo = Xse.blend_epi16(RegisterConversion.ToV128(x012), mid, 0b1100_0000);

                this = new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = new uint4(x012, x345.x),
                    _v4_4 = new uint4(x345.yz, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint4 x0123, uint2 x45, uint2 x67)
        {
            this = new uint8(x0123, new uint4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint4 x2345, uint2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.unpacklo_epi64(RegisterConversion.ToV128(x01), RegisterConversion.ToV128(x2345));
                v128 hi = Sse2.bslli_si128(RegisterConversion.ToV128(x67), 2 * sizeof(uint));
                hi = Sse2.unpackhi_epi64(RegisterConversion.ToV128(x2345), hi);

                this = new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = new uint4(x01, x2345.xy),
                    _v4_4 = new uint4(x2345.zw, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint2 x23, uint4 x4567)
        {
            this = new uint8(new uint4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint4 x0123, uint4 x4567)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(RegisterConversion.ToV128(x4567), RegisterConversion.ToV128(x0123));
            }
            else
            {
                this = new uint8
                {
                    _v4_0 = x0123,
                    _v4_4 = x4567
                };
            }
        }

        
        #region Shuffle
        public uint4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToUInt4(Avx.mm256_castsi256_si128(this));
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 0b0000_1111);
                }
                else
                {
                    this._v4_0 = value;
                }
            }
        }
        public uint4 v4_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt4(Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(uint)));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    uint4 lo = this._v4_0;
                    uint4 hi = this._v4_4;

                    return RegisterConversion.ToUInt4(Ssse3.alignr_epi8(RegisterConversion.ToV128(lo), RegisterConversion.ToV128(hi), 1 * sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 1), 0b0001_1110);
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
        public uint4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt4(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    uint4 lo = this._v4_0;
                    uint4 hi = this._v4_4;

                    return RegisterConversion.ToUInt4(Ssse3.alignr_epi8(RegisterConversion.ToV128(lo), RegisterConversion.ToV128(hi), 2 * sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), Sse.SHUFFLE(0, 1, 0, 0)), 0b0011_1100);
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
        public uint4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt4(Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(uint)));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    uint4 lo = this._v4_0;
                    uint4 hi = this._v4_4;

                    return RegisterConversion.ToUInt4(Ssse3.alignr_epi8(RegisterConversion.ToV128(lo), RegisterConversion.ToV128(hi), 3 * sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 3), 0b0111_1000);
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
        public uint4 v4_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt4(Avx2.mm256_extracti128_si256(this, 1));
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
                    this = Avx2.mm256_inserti128_si256(this, RegisterConversion.ToV128(value), 1);
                }
                else
                {
                    this._v4_4 = value;
                }
            }
        }
                                                                                                                                                                                                                                                    
        public uint3 v3_0
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToUInt3(Avx.mm256_castsi256_si128(this));
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 0b0000_0111);
                }
                else
                {
                    this._v4_0.xyz = value;
                }
            }
        }
        public uint3 v3_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToUInt3(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Sse2.shuffle_epi32(RegisterConversion.ToV128(value), Sse.SHUFFLE(2, 1, 0, 0))), 0b0000_1110);
                }
                else
                {
                    this._v4_0.yzw = value;
                }
            }
        }
        public uint3 v3_2
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt3(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    uint4 lo = this._v4_0;
                    uint4 hi = this._v4_4;

                    return RegisterConversion.ToUInt3(Ssse3.alignr_epi8(RegisterConversion.ToV128(lo), RegisterConversion.ToV128(hi), 2 * sizeof(uint)));
                }
                else
                {
                    return new uint3(_v4_0.zw, _v4_4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), Sse.SHUFFLE(0, 1, 0, 0)), 0b0001_1100);
                }
                else
                {
                    this._v4_0.zw = value.xy;
                    this._v4_4.x  = value.z;
                }
            }
        }
        public uint3 v3_3
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt3(Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(uint)));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    uint4 lo = this._v4_0;
                    uint4 hi = this._v4_4;

                    return RegisterConversion.ToUInt3(Ssse3.alignr_epi8(RegisterConversion.ToV128(lo), RegisterConversion.ToV128(hi), 3 * sizeof(uint)));
                }
                else
                {
                    return new uint3(_v4_0.w, _v4_4.xy);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 3), 0b0011_1000);
                }
                else
                {
                    this._v4_0.w  = value.x;
                    this._v4_4.xy = value.yz;
                }
            }
        }
        public uint3 v3_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt3(Avx2.mm256_extracti128_si256(this, 1));
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
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), Sse.SHUFFLE(1, 0, 0, 0)), 0b0111_0000);
                }
                else
                {
                    this._v4_4.xyz = value;
                }
            }
        }
        public uint3 v3_5
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt3(Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 5), 0b1110_0000);
                }
                else
                {
                    this._v4_4.yzw = value;
                } 
            }
        }
                                                                                                                                                                                                                                            
        public uint2 v2_0
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToUInt2(Avx.mm256_castsi256_si128(this));
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
        public uint2 v2_1
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToUInt2(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Sse2.shuffle_epi32(RegisterConversion.ToV128(value), Sse.SHUFFLE(0, 1, 0, 0))), 0b0000_0110);
                }
                else
                {
                    this._v4_0.yz = value;
                }
            }
        }
        public uint2 v2_2
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx.IsAvxSupported)
                {
                    return RegisterConversion.ToUInt2(Sse2.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(uint)));
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
        public uint2 v2_3
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt2(Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(uint)));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    uint4 lo = this._v4_0;
                    uint4 hi = this._v4_4;

                    return RegisterConversion.ToUInt2(Ssse3.alignr_epi8(RegisterConversion.ToV128(lo), RegisterConversion.ToV128(hi), 3 * sizeof(uint)));
                }
                else
                {
                    return new uint2(_v4_0.w, _v4_4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 3), 0b0001_1000);
                }
                else
                {
                    this._v4_0.w = value.x;
                    this._v4_4.x = value.y;
                }
            }
        }
        public uint2 v2_4
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt2(Avx2.mm256_extracti128_si256(this, 1));
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
        public uint2 v2_5
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt2(Sse2.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(uint)));
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
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(RegisterConversion.ToV128(value)), 5), 0b0110_0000);
                }
                else
                {
                    this._v4_4.yz = value;
                }
            }
        }
        public uint2 v2_6
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            readonly get 
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToUInt2(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3))));
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
        public static implicit operator v256(uint8 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(v256 input) => new uint8{ x0 = input.UInt0, x1 = input.UInt1, x2 = input.UInt2, x3 = input.UInt3, x4 = input.UInt4, x5 = input.UInt5, x6 = input.UInt6, x7 = input.UInt7 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(uint input) => new uint8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(int8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return (v256)input;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new uint8((uint4)input._v4_0, (uint4)input._v4_4);
            }
            else
            {
                return *(uint8*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(half8 input) => (uint8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(float8 input) => new uint8((uint4)input._v4_0, (uint4)input._v4_4);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(uint8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu32_ps(input);
            }
            else
            {
                return new float8((float4)input._v4_0, (float4)input._v4_4);
            }
        }

        public uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Avx2.IsAvx2Supported)
                {
                    return Xse.mm256_extract_epi32(this, (byte)index);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(index))
                    {
                        if (index < 4)
                        {
                            return Xse.extract_epi32(RegisterConversion.ToV128(_v4_0), (byte)index);
                        }
                        else
                        {
                            return Xse.extract_epi32(RegisterConversion.ToV128(_v4_4), (byte)(index - 4));
                        }
                    }
                }

                uint8 onStack = this;
                
                return *((uint*)&onStack + index);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);
                
                if (Avx2.IsAvx2Supported)
                {
                    this = Xse.mm256_insert_epi32(this, value, (byte)index);

                    return;
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(index))
                    {
                        if (index < 4)
                        {
                            _v4_0 = RegisterConversion.ToUInt4(Xse.insert_epi32(RegisterConversion.ToV128(_v4_0), value, (byte)index));
                        }
                        else
                        {
                            _v4_4 = RegisterConversion.ToUInt4(Xse.insert_epi32(RegisterConversion.ToV128(_v4_4), value, (byte)(index - 4)));
                        }

                        return;
                    }
                }

                uint8 onStack = this;
                *((uint*)&onStack + index) = value;
                this = onStack;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator + (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi32(left, right);
            }
            else
            {
                return new uint8(left._v4_0 + right._v4_0, left._v4_4 + right._v4_4);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator - (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(left, right);
            }
            else
            {
                return new uint8(left._v4_0 - right._v4_0, left._v4_4 - right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi32(left, right);
            }
            else
            {
                return new uint8(left._v4_0 * right._v4_0, left._v4_4 * right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 left, uint8 right)
        {
Assert.AreNotEqual(right.x0, 0u);
Assert.AreNotEqual(right.x1, 0u);
Assert.AreNotEqual(right.x2, 0u);
Assert.AreNotEqual(right.x3, 0u);
Assert.AreNotEqual(right.x4, 0u);
Assert.AreNotEqual(right.x5, 0u);
Assert.AreNotEqual(right.x6, 0u);
Assert.AreNotEqual(right.x7, 0u);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epu32(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new uint8(RegisterConversion.ToUInt4(Xse.div_epu32(RegisterConversion.ToV128(left.v4_0), RegisterConversion.ToV128(right.v4_0))), 
                                 RegisterConversion.ToUInt4(Xse.div_epu32(RegisterConversion.ToV128(left.v4_4), RegisterConversion.ToV128(right.v4_4))));
            }
            else
            {
                return new uint8((left.x0 / right.x0), (left.x1 / right.x1), (left.x2 / right.x2), (left.x3 / right.x3), (left.x4 / right.x4), (left.x5 / right.x5), (left.x6 / right.x6), (left.x7 / right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 left, uint8 right)
        {
Assert.AreNotEqual(right.x0, 0u);
Assert.AreNotEqual(right.x1, 0u);
Assert.AreNotEqual(right.x2, 0u);
Assert.AreNotEqual(right.x3, 0u);
Assert.AreNotEqual(right.x4, 0u);
Assert.AreNotEqual(right.x5, 0u);
Assert.AreNotEqual(right.x6, 0u);
Assert.AreNotEqual(right.x7, 0u);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epu32(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new uint8(RegisterConversion.ToUInt4(Xse.rem_epu32(RegisterConversion.ToV128(left.v4_0), RegisterConversion.ToV128(right.v4_0))), 
                                 RegisterConversion.ToUInt4(Xse.rem_epu32(RegisterConversion.ToV128(left.v4_4), RegisterConversion.ToV128(right.v4_4))));
            }
            else
            {
                return new uint8((left.x0 % right.x0), (left.x1 % right.x1), (left.x2 % right.x2), (left.x3 % right.x3), (left.x4 % right.x4), (left.x5 % right.x5), (left.x6 % right.x6), (left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint left, uint8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint8 left, uint right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new uint8((left.x0 * right), (left.x1 * right), (left.x2 * right), (left.x3 * right), (left.x4 * right), (left.x5 * right), (left.x6 * right), (left.x7 * right));
                }
                else
                {
                    return left * (uint8)right;
                }
            }
            else
            {
                return new uint8(left._v4_0 * right, left._v4_4 * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 left, uint right)
        {
Assert.AreNotEqual(right, 0u);
            
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mm256_div_epu32(left, right);
                }
            }

            return left / (uint8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 left, uint right)
        {
Assert.AreNotEqual(right, 0u);
            
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mm256_rem_epu32(left, right);
                }
            }

            return left % (uint8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator & (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(left, right);
            }
            else
            {
                return new uint8(left._v4_0 & right._v4_0, left._v4_4 & right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator | (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_or_si256(left, right);
            }
            else
            {
                return new uint8(left._v4_0 | right._v4_0, left._v4_4 | right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ^ (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(left, right);
            }
            else
            {
                return new uint8(left._v4_0 ^ right._v4_0, left._v4_4 ^ right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ++ (uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi32(x);
            }
            else
            {
                return new uint8(x._v4_0 + 1, x._v4_4 + 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator -- (uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi32(x);
            }
            else
            {
                return new uint8(x._v4_0 - 1, x._v4_4 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ~ (uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_not_si256(x);
            }
            else
            {
                return new uint8(~x._v4_0, ~x._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator << (uint8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_slli_epi32(x, n);
            }
            else
            {
                return new uint8(x._v4_0 << n, x._v4_4 << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator >> (uint8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi32(x, n);
            }
            else
            {
                return new uint8(x._v4_0 >> n, x._v4_4 >> n);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Avx2.mm256_cmpeq_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 == right._v4_0, left._v4_4 == right._v4_4);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmplt_epu32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 < right._v4_0, left._v4_4 < right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmpgt_epu32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 > right._v4_0, left._v4_4 > right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Avx2.mm256_cmpeq_epi32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 != right._v4_0, left._v4_4 != right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmple_epu32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 <= right._v4_0, left._v4_4 <= right._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmpge_epu32(left, right));
            }
            else
            {
                return new bool8(left._v4_0 >= right._v4_0, left._v4_4 >= right._v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint8 other)
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
        public override readonly bool Equals(object obj) => obj is uint8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v256((v256)this);
            }
            else
            {
                uint8 temp = this;

                return ((*(ulong*)&temp ^ *((ulong*)&temp + 1)) ^ (*((ulong*)&temp + 2) ^ *((ulong*)&temp + 3))).GetHashCode(); 
            }
        }
        

        public override readonly string ToString() => $"uint8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"uint8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}