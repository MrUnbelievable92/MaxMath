using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(short))]  [DebuggerTypeProxy(typeof(short16.DebuggerProxy))]
    unsafe public struct short16 : IEquatable<short16>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public short x0;
            public short x1;
            public short x2;
            public short x3;
            public short x4;
            public short x5;
            public short x6;
            public short x7;
            public short x8;
            public short x9;
            public short x10;
            public short x11;
            public short x12;
            public short x13;
            public short x14;
            public short x15;

            public DebuggerProxy(short16 v)
            {
                x0  = v.x0;
                x1  = v.x1;
                x2  = v.x2;
                x3  = v.x3;
                x4  = v.x4;
                x5  = v.x5;
                x6  = v.x6;
                x7  = v.x7;
                x8  = v.x8;
                x9  = v.x9;
                x10 = v.x10;
                x11 = v.x11;
                x12 = v.x12;
                x13 = v.x13;
                x14 = v.x14;
                x15 = v.x15;
            }
        }


        [FieldOffset(0)] private fixed short asArray[16];

        [FieldOffset(0)]  internal short8 _v8_0;
        [FieldOffset(16)] internal short8 _v8_8;

        [FieldOffset(0)]  public short x0;
        [FieldOffset(2)]  public short x1;
        [FieldOffset(4)]  public short x2;
        [FieldOffset(6)]  public short x3;
        [FieldOffset(8)]  public short x4;
        [FieldOffset(10)] public short x5;
        [FieldOffset(12)] public short x6;
        [FieldOffset(14)] public short x7;
        [FieldOffset(16)] public short x8;
        [FieldOffset(18)] public short x9;
        [FieldOffset(20)] public short x10;
        [FieldOffset(22)] public short x11;
        [FieldOffset(24)] public short x12;
        [FieldOffset(26)] public short x13;
        [FieldOffset(28)] public short x14;
        [FieldOffset(30)] public short x15;


        public static short16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7, short x8, short x9, short x10, short x11, short x12, short x13, short x14, short x15)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi16(x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
            }
            else
            {
                this = new short16
                {
                    _v8_0 = new short8(x0, x1, x2, x3, x4, x5, x6, x7),
                    _v8_8 = new short8(x8, x9, x10, x11, x12, x13, x14, x15)
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short x0x16)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_epi16(x0x16);
            }
            else
            {
                this = new short16
                {
                    _v8_0 = new short8(x0x16),
                    _v8_8 = new short8(x0x16)
                };
            }
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
            short8 lo;

            if (Sse2.IsSse2Supported)
            {
                lo = Sse2.insert_epi16(Sse2.unpacklo_epi64(x0123, x456), x789.x, 7);
            }
            else
            {
                lo = new short8(x0123, new short4(x456, x789.x));
            }

            this = new short16(lo,
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
            short8 lo;
            short8 hi;

            if (Sse2.IsSse2Supported)
            {
                lo = Sse2.unpacklo_epi64(x0123, x4_5_6_7_8_9_10_11); 
                hi = Sse2.unpacklo_epi64(Sse2.bsrli_si128(x4_5_6_7_8_9_10_11, 4 * sizeof(short)), x12_13_14_15);
            }
            else
            {
                lo = new short8(x0123, x4_5_6_7_8_9_10_11.v4_0);
                hi = new short8(x4_5_6_7_8_9_10_11.v4_4, x12_13_14_15);
            }

            this = new short16(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short4 x0123, short4 x4567, short8 x8_9_10_11_12_13_14_15)
        {
            this = new short16(new short8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short16(short8 x01234567, short8 x8_9_10_11_12_13_14_15)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(x8_9_10_11_12_13_14_15, x01234567);
            }
            else
            {
                this = new short16
                {
                    _v8_0 = x01234567,
                    _v8_8 = x8_9_10_11_12_13_14_15
                };
            }
        }


        #region Shuffle
        public short8 v8_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return _v8_0;
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value, 0);
                }
                else
                {
                    _v8_0 = value;
                }
            }
        }
        public short8 v8_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 1 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, sizeof(short)), Sse2.bslli_si128(_v8_8, 7 * sizeof(short)), 0b1000_0000);
                }
                else
                {
                    return new short8(x1, x2, x3, x4, x5, x6, x7, x8);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, sizeof(short)), Sse2.bsrli_si128(value, 7 * sizeof(short)));
                    v256 mask = new short16(0, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, sizeof(short)), 0b1111_1110);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 7 * sizeof(short)), 0b0000_0001);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, sizeof(short)), 0b1111_1110);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 7 * sizeof(short)), 0b0000_0001);
                    }
                }
                else
                {
                    this.x1  = value.x0;
                    this.x2  = value.x1;
                    this.x3  = value.x2;
                    this.x4  = value.x3;
                    this.x5  = value.x4;
                    this.x6  = value.x5;
                    this.x7  = value.x6;
                    this.x8  = value.x7;
                }
            }
        }
        public short8 v8_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 2 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 2 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 2 * sizeof(short)), Sse2.bslli_si128(_v8_8, 6 * sizeof(short)), 0b1100_0000);
                }
                else
                {
                    return new short8(x2, x3, x4, x5, x6, x7, x8, x9);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 2 * sizeof(short)), Sse2.bsrli_si128(value, 6 * sizeof(short)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0001_1110);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b1111_1100);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 6 * sizeof(short)), 0b0000_0011);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b1111_1100);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 6 * sizeof(short)), 0b0000_0011);
                    }
                }
                else
                {
                    this.x2  = value.x0;
                    this.x3  = value.x1;
                    this.x4  = value.x2;
                    this.x5  = value.x3;
                    this.x6  = value.x4;
                    this.x7  = value.x5;
                    this.x8  = value.x6;
                    this.x9  = value.x7;
                }
            }
        }
        public short8 v8_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 3 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 3 * sizeof(short)), Sse2.bslli_si128(_v8_8, 5 * sizeof(short)), 0b1110_0000);
                }
                else
                {
                    return new short8(x3, x4, x5, x6, x7, x8, x9, x10);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 3 * sizeof(short)), Sse2.bsrli_si128(value, 5 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b1111_1000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 5 * sizeof(short)), 0b0000_0111);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b1111_1000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 5 * sizeof(short)), 0b0000_0111);
                    }
                }
                else
                {
                    this.x3  = value.x0;
                    this.x4  = value.x1;
                    this.x5  = value.x2;
                    this.x6  = value.x3;
                    this.x7  = value.x4;
                    this.x8  = value.x5;
                    this.x9  = value.x6;
                    this.x10 = value.x7;
                }
            }
        }
        public short8 v8_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 1)));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 4 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 4 * sizeof(short)), Sse2.bslli_si128(_v8_8, 4 * sizeof(short)), 0b1111_0000);
                }
                else
                {
                    return new short8(x4, x5, x6, x7, x8, x9, x10, x11);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 4 * sizeof(short)), Sse2.bsrli_si128(value, 4 * sizeof(short)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0011_1100);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b1111_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 4 * sizeof(short)), 0b0000_1111);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b1111_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 4 * sizeof(short)), 0b0000_1111);
                    }
                }
                else
                {
                    this.x4  = value.x0;
                    this.x5  = value.x1;
                    this.x6  = value.x2;
                    this.x7  = value.x3;
                    this.x8  = value.x4;
                    this.x9  = value.x5;
                    this.x10 = value.x6;
                    this.x11 = value.x7;
                }
            }
        }
        public short8 v8_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 5 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 5 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 5 * sizeof(short)), Sse2.bslli_si128(_v8_8, 3 * sizeof(short)), 0b1111_1000);
                }
                else
                {
                    return new short8(x5, x6, x7, x8, x9, x10, x11, x12);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 5 * sizeof(short)), Sse2.bsrli_si128(value, 3 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b1110_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 3 * sizeof(short)), 0b0001_1111);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b1110_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 3 * sizeof(short)), 0b0001_1111);
                    }
                }
                else
                {
                    this.x5  = value.x0;
                    this.x6  = value.x1;
                    this.x7  = value.x2;
                    this.x8  = value.x3;
                    this.x9  = value.x4;
                    this.x10 = value.x5;
                    this.x11 = value.x6;
                    this.x12 = value.x7;
                }
            }
        }
        public short8 v8_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 6 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 6 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 6 * sizeof(short)), Sse2.bslli_si128(_v8_8, 2 * sizeof(short)), 0b1111_1100);
                }
                else
                {
                    return new short8(x6, x7, x8, x9, x10, x11, x12, x13);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 6 * sizeof(short)), Sse2.bsrli_si128(value, 2 * sizeof(short)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0111_1000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 2 * sizeof(short)), 0b0011_1111);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 2 * sizeof(short)), 0b0011_1111);
                    }
                }
                else
                {
                    this.x6  = value.x0;
                    this.x7  = value.x1;
                    this.x8  = value.x2;
                    this.x9  = value.x3;
                    this.x10 = value.x4;
                    this.x11 = value.x5;
                    this.x12 = value.x6;
                    this.x13 = value.x7;
                }
            }
        }
        public short8 v8_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 7 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 7 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 7 * sizeof(short)), Sse2.bslli_si128(_v8_8, sizeof(short)), 0b1111_1110);
                }
                else
                {
                    return new short8(x7, x8, x9, x10, x11, x12, x13, x14);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 7 * sizeof(short)), Sse2.bsrli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, sizeof(short)),     0b0111_1111);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, sizeof(short)),     0b0111_1111);
                    }
                }
                else
                {
                    this.x7  = value.x0;
                    this.x8  = value.x1;
                    this.x9  = value.x2;
                    this.x10 = value.x3;
                    this.x11 = value.x4;
                    this.x12 = value.x5;
                    this.x13 = value.x6;
                    this.x14 = value.x7;
                }
            }
        }
        public short8 v8_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return _v8_8;
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value, 1);
                }
                else
                {
                    _v8_8 = value;
                }
            }
        }
        
        public short4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v4_0;
                }
                else
                {
                    return new short4(x0, x1, x2, x3);
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
                    _v8_0.v4_0 = value;
                }
            }
        }
        public short4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v4_1;
                }
                else
                {
                    return new short4(x1, x2, x3, x4);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v4_1 = value;
                }
            }
        }
        public short4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v4_2;
                }
                else
                {
                    return new short4(x2, x3, x4, x5);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 2 * sizeof(short)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0000_0110);
                }
                else
                {
                    _v8_0.v4_2 = value;
                }
            }
        }
        public short4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v4_3;
                }
                else
                {
                    return new short4(x3, x4, x5, x6);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v4_3 = value;
                }
            }
        }
        public short4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v4_4;
                }
                else
                {
                    return new short4(x4, x5, x6, x7);
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
                    _v8_0.v4_4 = value;
                }
            }
        }
        public short4 v4_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 5 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 5 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 5 * sizeof(short)), Sse2.bslli_si128(_v8_8, 3 * sizeof(short)), 0b1000);
                }
                else
                {
                    return new short4(x5, x6, x7, x8);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 5 * sizeof(short)), Sse2.bsrli_si128(value, 3 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b1110_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 3 * sizeof(short)), 0b0000_0001);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b1110_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 3 * sizeof(short)), 0b0000_0001);
                    }
                }
                else
                {
                    this.x5  = value.x;
                    this.x6  = value.y;
                    this.x7  = value.z;
                    this.x8  = value.w;
                }
            }
        }
        public short4 v4_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 6 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 6 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 6 * sizeof(short)), Sse2.bslli_si128(_v8_8, 2 * sizeof(short)), 0b1100);
                }
                else
                {
                    return new short4(x6, x7, x8, x9);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 6 * sizeof(short)), Sse2.bsrli_si128(value, 2 * sizeof(short)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0001_1000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 2 * sizeof(short)), 0b0000_0011);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 2 * sizeof(short)), 0b0000_0011);
                    }
                }
                else
                {
                    this.x6  = value.x;
                    this.x7  = value.y;
                    this.x8  = value.z;
                    this.x9  = value.w;
                }
            }
        }
        public short4 v4_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 7 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 7 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 7 * sizeof(short)), Sse2.bslli_si128(_v8_8, sizeof(short)), 0b1110);
                }
                else
                {
                    return new short4(x7, x8, x9, x10);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    short16 blend = new short16(Sse2.bslli_si128(value, 7 * sizeof(short)), Sse2.bsrli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, sizeof(short)),     0b0000_0111);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, sizeof(short)),     0b0000_0111);
                    }
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                    this.x9  = value.z;
                    this.x10 = value.w;
                }
            }
        }
        public short4 v4_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v4_0;
                }
                else
                {
                    return new short4(x8, x9, x10, x11);
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
                    _v8_8.v4_0 = value;
                }
            }
        }
        public short4 v4_9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v4_1;
                }
                else
                {
                    return new short4(x9, x10, x11, x12);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, sizeof(short)), 1);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v4_1 = value;
                }
            }
        }
        public short4 v4_10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v4_2;
                }
                else
                {
                    return new short4(x10, x11, x12, x13);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 2 * sizeof(short)), 1);

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0110_0000);
                }
                else
                {
                    _v8_8.v4_2 = value;
                }
            }
        }
        public short4 v4_11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v4_3;
                }
                else
                {
                    return new short4(x11, x12, x13, x14);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 3 * sizeof(short)), 1);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, -1, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v4_3 = value;
                }
            }
        }
        public short4 v4_12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v8_8.v4_4;
                }
                else
                {
                    return new short4(x12, x13, x14, x15);
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
                    _v8_8.v4_4 = value;
                }
            }
        }
        
        public short3 v3_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v3_0;
                }
                else
                {
                    return new short3(x0, x1, x2);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(value);
                    v256 mask = new short16(-1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v3_0 = value;
                }
            }
        }
        public short3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v3_1;
                }
                else
                {
                    return new short3(x1, x2, x3);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v3_1 = value;
                }
            }
        }
        public short3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v3_2;
                }
                else
                {
                    return new short3(x2, x3, x4);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 2 * sizeof(short)));
                    v256 mask = new short16(0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v3_2 = value;
                }
            }
        }
        public short3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v3_3;
                }
                else
                {
                    return new short3(x3, x4, x5);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v3_3 = value;
                }
            }
        }
        public short3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v3_4;
                }
                else
                {
                    return new short3(x4, x5, x6);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 4 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v3_4 = value;
                }
            }
        }
        public short3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v3_5;
                }
                else
                {
                    return new short3(x5, x6, x7);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 5 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v3_5 = value;
                }
            }
        }
        public short3 v3_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 6 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 6 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 6 * sizeof(short)), Sse2.bslli_si128(_v8_8, 2 * sizeof(short)), 0b0100);
                }
                else
                {
                    return new short3(x6, x7, x8);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(Sse2.bslli_si128(value, 6 * sizeof(short)), Sse2.bsrli_si128(value, 2 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, 2 * sizeof(short)), 0b0000_0001);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, 2 * sizeof(short)), 0b0000_0001);
                    }
                }
                else
                {
                    this.x6  = value.x;
                    this.x7  = value.y;
                    this.x8  = value.z;
                }
            }
        }
        public short3 v3_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 7 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 7 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 7 * sizeof(short)), Sse2.bslli_si128(_v8_8, sizeof(short)), 0b1110);
                }
                else
                {
                    return new short3(x7, x8, x9);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(Sse2.bslli_si128(value, 7 * sizeof(short)), Sse2.bsrli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value, sizeof(short)),     0b0000_0011);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value, sizeof(short)),     0b0000_0011);
                    }
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                    this.x9  = value.z;
                }
            }
        }
        public short3 v3_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return v8_8.v3_0;
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(default(v128), (v128)value);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v3_0 = value;
                }
            }
        }
        public short3 v3_9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v3_1;
                }
                else
                {
                    return new short3(x9, x10, x11);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            { 
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(default(v128), Sse2.bslli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v3_1 = value;
                }
            }
        }
        public short3 v3_10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v3_2;
                }
                else
                {
                    return new short3(x10, x11, x12);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(default(v128), Sse2.bslli_si128(value, 2 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v3_2 = value;
                }
            }
        }
        public short3 v3_11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v3_3;
                }
                else
                {
                    return new short3(x11, x12, x13);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(default(v128), Sse2.bslli_si128(value, 3 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v3_3 = value;
                }
            }
        }
        public short3 v3_12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return v8_8.v3_4;
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(default(v128), Sse2.bslli_si128(value, 4 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v3_4 = value;
                }
            }
        }
        public short3 v3_13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return v8_8.v3_5;
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new short16(default(v128), Sse2.bslli_si128(value, 5 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v3_5 = value;
                }
            }
        }
        
        public short2 v2_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_0;
                }
                else
                {
                    return new short2(x0, x1);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 0);
                }
                else
                {
                    _v8_0.v2_0 = value;
                }
            }
        }
        public short2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_1;
                }
                else
                {
                    return new short2(x1, x2);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(short)));
                    v256 mask = new short16(0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v2_1 = value;
                }
            }
        }
        public short2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_2;
                }
                else
                {
                    return new short2(x2, x3);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 1);
                }
                else
                {
                    _v8_0.v2_2 = value;
                }
            }
        }
        public short2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_3;
                }
                else
                {
                    return new short2(x3, x4);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v2_3 = value;
                }
            }
        }
        public short2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_4;
                }
                else
                {
                    return new short2(x4, x5);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 2);
                }
                else
                {
                    _v8_0.v2_4 = value;
                }
            }
        }
        public short2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_5;
                }
                else
                {
                    return new short2(x5, x6);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 5 * sizeof(short)));
                    v256 mask = new short16(0, 0, 0, 0, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_0.v2_5 = value;
                }
            }
        }
        public short2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_0.v2_6;
                }
                else
                {
                    return new short2(x6, x7);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 3);
                }
                else
                {
                    _v8_0.v2_6 = value;
                }
            }
        }
        public short2 v2_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Ssse3.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 7 * sizeof(short));
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.alignr_epi8(this._v8_0, this._v8_8, 7 * sizeof(short));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v8_0, 7 * sizeof(short)), Sse2.bslli_si128(_v8_8, sizeof(short)), 0b1110);
                }
                else
                {
                    return new short2(x7, x8);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 7 * sizeof(short))),
                                                             Sse2.bsrli_si128(value, sizeof(short)),
                                                             1);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v8_0 = Sse4_1.blend_epi16(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Sse4_1.blend_epi16(this._v8_8, Sse2.bsrli_si128(value,     sizeof(short)), 0b0000_0001);
                    }
                    else
                    {
                        this._v8_0 = Mask.BlendEpi16_SSE2(this._v8_0, Sse2.bslli_si128(value, 7 * sizeof(short)), 0b1000_0000);
                        this._v8_8 = Mask.BlendEpi16_SSE2(this._v8_8, Sse2.bsrli_si128(value,     sizeof(short)), 0b0000_0001);
                    }
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                }
            }
        }
        public short2 v2_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return v8_8.v2_0;
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 4);
                }
                else
                {
                    _v8_8.v2_0 = value;
                }
            }
        }
        public short2 v2_9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v2_1;
                }
                else
                {
                    return new short2(x9, x10);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, sizeof(short)), 1);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v2_1 = value;
                }
            }
        }
        public short2 v2_10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 5);

                    return *(short2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v8_8.v2_2;
                }
                else
                {
                    return new short2(x10, x11);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 5);
                }
                else
                {
                    _v8_8.v2_2 = value;
                }
            }
        }
        public short2 v2_11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v2_3;
                }
                else
                {
                    return new short2(x11, x12);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 3 * sizeof(short)), 1);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v2_3 = value;
                }
            }
        }
        public short2 v2_12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v8_8.v2_4;
                }
                else
                {
                    return new short2(x12, x13);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 6);
                }
                else
                {
                    _v8_8.v2_4 = value;
                }
            }
        }
        public short2 v2_13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v8_8.v2_5;
                }
                else
                {
                    return new short2(x13, x14);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 5 * sizeof(short)), 1);
                    v256 mask = new short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else
                {
                    _v8_8.v2_5 = value;
                }
            }
        }
        public short2 v2_14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 7);

                    return *(short2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v8_8.v2_6;
                }
                else
                {
                    return new short2(x14, x15);
                }
            }
        
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 7);
                }
                else
                {
                    _v8_8.v2_6 = value;
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(short16 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator short16(v256 input) => new short16 { x0 = input.SShort0, x1 = input.SShort1, x2 = input.SShort2, x3 = input.SShort3, x4 = input.SShort4, x5 = input.SShort5, x6 = input.SShort6, x7 = input.SShort7, x8 = input.SShort8, x9 = input.SShort9, x10 = input.SShort10, x11 = input.SShort11, x12 = input.SShort12, x13 = input.SShort13, x14 = input.SShort14, x15 = input.SShort15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(short input) => new short16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short16(ushort16 input)
        {
            if (Avx.IsAvxSupported)
            {
                return (v256)input;
            }
            else if (Sse.IsSseSupported)
            {
                return new short16((v128)input._v8_0, (v128)input._v8_8);
            }
            else
            {
                return *(short16*)&input;
            }
        }


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 16);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 16);

                asArray[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator + (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi16(left, right);
            }
            else
            {
                return new short16(left._v8_0 + right._v8_0, left._v8_8 + right._v8_8);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator - (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(left, right);
            }
            else
            {
                return new short16(left._v8_0 - right._v8_0, left._v8_8 - right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi16(left, right);
            }
            else
            {
                return new short16(left._v8_0 * right._v8_0, left._v8_8 * right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator / (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdiv_short(left, right);
            }
            else
            {
                return new short16(left._v8_0 / right._v8_0, left._v8_8 / right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator % (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vrem_short(left, right);
            }
            else
            {
                return new short16(left._v8_0 % right._v8_0, left._v8_8 % right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short left, short16 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator * (short16 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new short16((short)(left.x0 * right), (short)(left.x1 * right), (short)(left.x2 * right), (short)(left.x3 * right), (short)(left.x4 * right), (short)(left.x5 * right), (short)(left.x6 * right), (short)(left.x7 * right), (short)(left.x8 * right), (short)(left.x9 * right), (short)(left.x10 * right), (short)(left.x11 * right), (short)(left.x12 * right), (short)(left.x13 * right), (short)(left.x14 * right), (short)(left.x15 * right));
                }
                else
                {
                    return left * (short16)right;
                }
            }
            else
            {
                return new short16(left._v8_0 * right, left._v8_8 * right);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator / (short16 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new short16((short)(left.x0 / right), (short)(left.x1 / right), (short)(left.x2 / right), (short)(left.x3 / right), (short)(left.x4 / right), (short)(left.x5 / right), (short)(left.x6 / right), (short)(left.x7 / right), (short)(left.x8 / right), (short)(left.x9 / right), (short)(left.x10 / right), (short)(left.x11 / right), (short)(left.x12 / right), (short)(left.x13 / right), (short)(left.x14 / right), (short)(left.x15 / right));
                }
                else
                {
                    return left / (short16)right;
                }
            }
            else
            {
                return new short16(left._v8_0 / right, left._v8_8 / right);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator % (short16 left, short right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new short16((short)(left.x0 % right), (short)(left.x1 % right), (short)(left.x2 % right), (short)(left.x3 % right), (short)(left.x4 % right), (short)(left.x5 % right), (short)(left.x6 % right), (short)(left.x7 % right), (short)(left.x8 % right), (short)(left.x9 % right), (short)(left.x10 % right), (short)(left.x11 % right), (short)(left.x12 % right), (short)(left.x13 % right), (short)(left.x14 % right), (short)(left.x15 % right));
                }
                else
                {
                    return left % (short16)right;
                }
            }
            else
            {
                return new short16(left._v8_0 % right, left._v8_8 % right);
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator & (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(left, right);
            }
            else
            {
                return new short16(left._v8_0 & right._v8_0, left._v8_8 & right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator | (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_or_si256(left, right);
            }
            else
            {
                return new short16(left._v8_0 | right._v8_0, left._v8_8 | right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ^ (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(left, right);
            }
            else
            {
                return new short16(left._v8_0 ^ right._v8_0, left._v8_8 ^ right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator - (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(default(v256), x);
            }
            else
            {
                return new short16(-x._v8_0, -x._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ++ (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else
            {
                return new short16(x._v8_0 + 1, x._v8_8 + 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator -- (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi16(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else
            {
                return new short16(x._v8_0 - 1, x._v8_8 - 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator ~ (short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else
            {
                return new short16(~x._v8_0, ~x._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator << (short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shl_short(x, n);
            }
            else
            {
                return new short16(x._v8_0 << n, x._v8_8 << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 operator >> (short16 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shra_short(x, n);
            }
            else
            {
                return new short16(x._v8_0 >> n, x._v8_8 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ConvertToBool.IsTrue16(Avx2.mm256_cmpeq_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 == right._v8_0, left._v8_8 == right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ConvertToBool.IsTrue16(Avx2.mm256_cmpgt_epi16(right, left));
            }
            else
            {
                return new bool16(left._v8_0 < right._v8_0, left._v8_8 < right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ConvertToBool.IsTrue16(Avx2.mm256_cmpgt_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 > right._v8_0, left._v8_8 > right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ConvertToBool.IsFalse16(Avx2.mm256_cmpeq_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 != right._v8_0, left._v8_8 != right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ConvertToBool.IsFalse16(Avx2.mm256_cmpgt_epi16(left, right));
            }
            else
            {
                return new bool16(left._v8_0 <= right._v8_0, left._v8_8 <= right._v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (short16 left, short16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ConvertToBool.IsFalse16(Avx2.mm256_cmpgt_epi16(right, left));
            }
            else
            {
                return new bool16(left._v8_0 >= right._v8_0, left._v8_8 >= right._v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short16 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return uint.MaxValue == (uint)Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(this, other));
            }
            else
            {
                return this._v8_0.Equals(other._v8_0) & this._v8_8.Equals(other._v8_8);
            }
        }

        public override bool Equals(object obj) => Equals((short16)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v256(this);
            }
            else
            {
                return this.v8_0.GetHashCode() ^ this.v8_8.GetHashCode();
            }
        }


        public override string ToString() =>  $"short16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}