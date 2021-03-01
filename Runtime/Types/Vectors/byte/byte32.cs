using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 32 * sizeof(byte))]  [DebuggerTypeProxy(typeof(byte32.DebuggerProxy))]
    unsafe public struct byte32 : IEquatable<byte32>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public byte x0;
            public byte x1;
            public byte x2;
            public byte x3;
            public byte x4;
            public byte x5;
            public byte x6;
            public byte x7;
            public byte x8;
            public byte x9;
            public byte x10;
            public byte x11;
            public byte x12;
            public byte x13;
            public byte x14;
            public byte x15;
            public byte x16;
            public byte x17;
            public byte x18;
            public byte x19;
            public byte x20;
            public byte x21;
            public byte x22;
            public byte x23;
            public byte x24;
            public byte x25;
            public byte x26;
            public byte x27;
            public byte x28;
            public byte x29;
            public byte x30;
            public byte x31;

            public DebuggerProxy(byte32 v)
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
                x16 = v.x16;
                x17 = v.x17;
                x18 = v.x18;
                x19 = v.x19;
                x20 = v.x20;
                x21 = v.x21;
                x22 = v.x22;
                x23 = v.x23;
                x24 = v.x24;
                x25 = v.x25;
                x26 = v.x26;
                x27 = v.x27;
                x28 = v.x28;
                x29 = v.x29;
                x30 = v.x30;
                x31 = v.x31;
            }
        }


        [FieldOffset(0)]  private fixed byte asArray[32];

        [FieldOffset(0)]  internal byte16 _v16_0;
        [FieldOffset(16)] internal byte16 _v16_16;

        [FieldOffset(0)]  public byte x0;
        [FieldOffset(1)]  public byte x1;
        [FieldOffset(2)]  public byte x2;
        [FieldOffset(3)]  public byte x3;
        [FieldOffset(4)]  public byte x4;
        [FieldOffset(5)]  public byte x5;
        [FieldOffset(6)]  public byte x6;
        [FieldOffset(7)]  public byte x7;
        [FieldOffset(8)]  public byte x8;
        [FieldOffset(9)]  public byte x9;
        [FieldOffset(10)] public byte x10;
        [FieldOffset(11)] public byte x11;
        [FieldOffset(12)] public byte x12;
        [FieldOffset(13)] public byte x13;
        [FieldOffset(14)] public byte x14;
        [FieldOffset(15)] public byte x15;
        [FieldOffset(16)] public byte x16;
        [FieldOffset(17)] public byte x17;
        [FieldOffset(18)] public byte x18;
        [FieldOffset(19)] public byte x19;
        [FieldOffset(20)] public byte x20;
        [FieldOffset(21)] public byte x21;
        [FieldOffset(22)] public byte x22;
        [FieldOffset(23)] public byte x23;
        [FieldOffset(24)] public byte x24;
        [FieldOffset(25)] public byte x25;
        [FieldOffset(26)] public byte x26;
        [FieldOffset(27)] public byte x27;
        [FieldOffset(28)] public byte x28;
        [FieldOffset(29)] public byte x29;
        [FieldOffset(30)] public byte x30;
        [FieldOffset(31)] public byte x31;


        public static byte32 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15, byte x16, byte x17, byte x18, byte x19, byte x20, byte x21, byte x22, byte x23, byte x24, byte x25, byte x26, byte x27, byte x28, byte x29, byte x30, byte x31)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi8(x31, x30, x29, x28, x27, x26, x25, x24, x23, x22, x21, x20, x19, x18, x17, x16, x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
            }
            else
            {
                this = new byte32
                {
                    _v16_0 = new byte16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15),
                    _v16_16 = new byte16(x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30, x31)
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0x32)
        {
            if (Avx.IsAvxSupported)
            {
                this = new v256(x0x32);
            }
            else
            {
                this = new byte32
                {
                    _v16_0 = new byte16(x0x32),
                    _v16_16 = new byte16(x0x32)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte8 v8_0, byte8 v8_8, byte8 v8_16, byte8 v8_24)
        {
            this = new byte32(new byte16(v8_0, v8_8), new byte16(v8_16, v8_24));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte16 v16_0, byte8 v8_16, byte8 v8_24)
        {
            this = new byte32(v16_0, new byte16(v8_16, v8_24));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte8 v8_0, byte16 v16_8, byte8 v8_24)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mid = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(v16_8), Sse.SHUFFLE(0, 1, 0, 0));
                mid = Avx.mm256_insert_epi64(mid, *(long*)&v8_0, 0);
                this = Avx.mm256_insert_epi64(mid, *(long*)&v8_24, 3);
            }
            else
            {
                this = new byte32(new byte16(v8_0, v16_8.v8_0), new byte16(v16_8.v8_8, v8_24));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte8 v8_0, byte8 v8_8, byte16 v16_16)
        {
            this = new byte32(new byte16(v8_0, v8_8), v16_16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte16 v16_0, byte16 v16_16)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(v16_16, v16_0);
            }
            else
            {
                this = new byte32
                {
                    _v16_0 = v16_0,
                    _v16_16 = v16_16
                };
            }
        }


        #region Shuffle
        public byte16 v16_0
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
                    return _v16_0;
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
                    this._v16_0 = value;
                }
            }
        }
        public byte16 v16_1
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse4_1.insert_epi8(Sse2.bsrli_si128(v16_0, sizeof(byte)), (byte)Avx2.mm256_extract_epi8(this, 16), 15);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(_v16_0,  sizeof(byte)), 
                                       Sse2.bslli_si128(_v16_16, 15 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                }
                else
                {
                    return new byte16(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, sizeof(byte)), Sse2.bsrli_si128(value, 15 * sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value,      sizeof(byte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value, 15 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    this.x9  = value.x8;
                    this.x10 = value.x9;
                    this.x11 = value.x10;
                    this.x12 = value.x11;
                    this.x13 = value.x12;
                    this.x14 = value.x13;
                    this.x15 = value.x14;
                    this.x16 = value.x15;
                }
            }
        }
        public byte16 v16_2
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.insert_epi16(Sse2.bsrli_si128(v16_0, 2 * sizeof(byte)), (short)Avx2.mm256_extract_epi16(this, 8), 7);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(_v16_0, 2 * sizeof(byte)),
                                                  Sse2.bslli_si128(_v16_16, 14 * sizeof(byte)),
                                                  0b1000_0000);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v16_0, 2 * sizeof(byte)),
                                                    Sse2.bslli_si128(_v16_16, 14 * sizeof(byte)),
                                                    0b1000_0000);
                    }
                }
                else
                {
                    return new byte16(x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 2 * sizeof(byte)), Sse2.bsrli_si128(value, 14 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value,  2 * sizeof(byte)), 0b1111_1110);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value, 14 * sizeof(byte)), 0b0000_0001);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value,  2 * sizeof(byte)), 0b1111_1110);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value, 14 * sizeof(byte)), 0b0000_0001);
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
                    this.x10 = value.x8;
                    this.x11 = value.x9;
                    this.x12 = value.x10;
                    this.x13 = value.x11;
                    this.x14 = value.x12;
                    this.x15 = value.x13;
                    this.x16 = value.x14;
                    this.x17 = value.x15;
                }

            }
        }
        public byte16 v16_3
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(v16_0,  3 * sizeof(byte)), 
                                       Sse2.bslli_si128(v16_16, 13 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                }
                else
                {
                    return new byte16(x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 3 * sizeof(byte)), Sse2.bsrli_si128(value, 13 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value,  3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value, 13 * sizeof(byte)), new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    this.x11 = value.x8;
                    this.x12 = value.x9;
                    this.x13 = value.x10;
                    this.x14 = value.x11;
                    this.x15 = value.x12;
                    this.x16 = value.x13;
                    this.x17 = value.x14;
                    this.x18 = value.x15;
                }
            }
        }
        public byte16 v16_4
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse4_1.insert_epi32(Sse2.bsrli_si128(v16_0, 4 * sizeof(byte)), Avx.mm256_extract_epi32(this, 4), 3);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(_v16_0, 4 * sizeof(byte)),
                                                  Sse2.bslli_si128(_v16_16, 12 * sizeof(byte)),
                                                  0b1100_0000);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v16_0, 4 * sizeof(byte)),
                                                    Sse2.bslli_si128(_v16_16, 12 * sizeof(byte)),
                                                    0b1100_0000);
                    }
                }
                else
                {
                    return new byte16(x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 4 * sizeof(byte)), Sse2.bsrli_si128(value, 12 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0001_1110);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value,  4 * sizeof(byte)), 0b1111_1100);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value, 12 * sizeof(byte)), 0b0000_0011);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value,  4 * sizeof(byte)), 0b1111_1100);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value, 12 * sizeof(byte)), 0b0000_0011);
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
                    this.x12 = value.x8;
                    this.x13 = value.x9;
                    this.x14 = value.x10;
                    this.x15 = value.x11;
                    this.x16 = value.x12;
                    this.x17 = value.x13;
                    this.x18 = value.x14;
                    this.x19 = value.x15;
                }
            }
        }
        public byte16 v16_5
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(v16_0,  5 * sizeof(byte)), 
                                       Sse2.bslli_si128(v16_16, 11 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte16(x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 5 * sizeof(byte)), Sse2.bsrli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value,  5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value, 11 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    this.x13 = value.x8;
                    this.x14 = value.x9;
                    this.x15 = value.x10;
                    this.x16 = value.x11;
                    this.x17 = value.x12;
                    this.x18 = value.x13;
                    this.x19 = value.x14;
                    this.x20 = value.x15;
                }
            }
        }
        public byte16 v16_6
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(v16_0, 6 * sizeof(byte)),
                                                  Sse2.bslli_si128(v16_16, 10 * sizeof(byte)),
                                                  0b1110_0000);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(v16_0, 6 * sizeof(byte)),
                                                    Sse2.bslli_si128(v16_16, 10 * sizeof(byte)),
                                                    0b1110_0000);
                    }
                }
                else
                {
                    return new byte16(x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 6 * sizeof(byte)), Sse2.bsrli_si128(value, 10 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value,  6 * sizeof(byte)), 0b1111_1000);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value, 10 * sizeof(byte)), 0b0000_0111);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value,  6 * sizeof(byte)), 0b1111_1000);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value, 10 * sizeof(byte)), 0b0000_0111);
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
                    this.x14 = value.x8;
                    this.x15 = value.x9;
                    this.x16 = value.x10;
                    this.x17 = value.x11;
                    this.x18 = value.x12;
                    this.x19 = value.x13;
                    this.x20 = value.x14;
                    this.x21 = value.x15;
                }
            }
        }
        public byte16 v16_7
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(v16_0,  7 * sizeof(byte)), 
                                       Sse2.bslli_si128(v16_16, 9 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte16(x7, x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 7 * sizeof(byte)), Sse2.bsrli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value,  7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value,  9 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    this.x15 = value.x8;
                    this.x16 = value.x9;
                    this.x17 = value.x10;
                    this.x18 = value.x11;
                    this.x19 = value.x12;
                    this.x20 = value.x13;
                    this.x21 = value.x14;
                    this.x22 = value.x15;
                }
            }
        }
        public byte16 v16_8
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse4_1.insert_epi64(Sse2.bsrli_si128(v16_0, 8 * sizeof(byte)), Avx.mm256_extract_epi64(this, 2), 1);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi64(Sse2.bsrli_si128(_v16_0,  8 * sizeof(byte)), _v16_16);
                }
                else
                {
                    return new byte16(x8, x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 8 * sizeof(byte)), Sse2.bsrli_si128(value, 8 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0011_1100);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value,  8 * sizeof(byte)), 0b1111_0000);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value,  8 * sizeof(byte)), 0b0000_1111);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value,  8 * sizeof(byte)), 0b1111_0000);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value,  8 * sizeof(byte)), 0b0000_1111);
                    }
                }
                else
                {
                    this.x8  = value.x0;
                    this.x9  = value.x1;
                    this.x10 = value.x2;
                    this.x11 = value.x3;
                    this.x12 = value.x4;
                    this.x13 = value.x5;
                    this.x14 = value.x6;
                    this.x15 = value.x7;
                    this.x16 = value.x8;
                    this.x17 = value.x9;
                    this.x18 = value.x10;
                    this.x19 = value.x11;
                    this.x20 = value.x12;
                    this.x21 = value.x13;
                    this.x22 = value.x14;
                    this.x23 = value.x15;
                }
            }
        }
        public byte16 v16_9
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(v16_0,  9 * sizeof(byte)), 
                                       Sse2.bslli_si128(v16_16, 7 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte16(x9, x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 9 * sizeof(byte)), Sse2.bsrli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value,  9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value,  7 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x9  = value.x0;
                    this.x10 = value.x1;
                    this.x11 = value.x2;
                    this.x12 = value.x3;
                    this.x13 = value.x4;
                    this.x14 = value.x5;
                    this.x15 = value.x6;
                    this.x16 = value.x7;
                    this.x17 = value.x8;
                    this.x18 = value.x9;
                    this.x19 = value.x10;
                    this.x20 = value.x11;
                    this.x21 = value.x12;
                    this.x22 = value.x13;
                    this.x23 = value.x14;
                    this.x24 = value.x15;
                }
            }
        }
        public byte16 v16_10
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(v16_0, 10 * sizeof(byte)),
                                                  Sse2.bslli_si128(v16_16, 6 * sizeof(byte)),
                                                  0b1111_1000);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(v16_0, 10 * sizeof(byte)),
                                                    Sse2.bslli_si128(v16_16, 6 * sizeof(byte)),
                                                    0b1111_1000);
                    }
                }
                else
                {
                    return new byte16(x10, x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 10 * sizeof(byte)), Sse2.bsrli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value, 10 * sizeof(byte)), 0b1110_0000);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value,  6 * sizeof(byte)), 0b0001_1111);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value, 10 * sizeof(byte)), 0b1110_0000);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value,  6 * sizeof(byte)), 0b0001_1111);
                    }
                }
                else
                {
                    this.x10 = value.x0;
                    this.x11 = value.x1;
                    this.x12 = value.x2;
                    this.x13 = value.x3;
                    this.x14 = value.x4;
                    this.x15 = value.x5;
                    this.x16 = value.x6;
                    this.x17 = value.x7;
                    this.x18 = value.x8;
                    this.x19 = value.x9;
                    this.x20 = value.x10;
                    this.x21 = value.x11;
                    this.x22 = value.x12;
                    this.x23 = value.x13;
                    this.x24 = value.x14;
                    this.x25 = value.x15;
                }
            }
        }
        public byte16 v16_11
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(v16_0,  11 * sizeof(byte)), 
                                       Sse2.bslli_si128(v16_16, 5 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte16(x11, x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 11 * sizeof(byte)), Sse2.bsrli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value,  5 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x11 = value.x0;
                    this.x12 = value.x1;
                    this.x13 = value.x2;
                    this.x14 = value.x3;
                    this.x15 = value.x4;
                    this.x16 = value.x5;
                    this.x17 = value.x6;
                    this.x18 = value.x7;
                    this.x19 = value.x8;
                    this.x20 = value.x9;
                    this.x21 = value.x10;
                    this.x22 = value.x11;
                    this.x23 = value.x12;
                    this.x24 = value.x13;
                    this.x25 = value.x14;
                    this.x26 = value.x15;
                }
            }
        }
        public byte16 v16_12
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse4_1.insert_epi32(Sse2.bslli_si128(v16_16, 4 * sizeof(byte)), Avx.mm256_extract_epi32(this, 3), 0);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(_v16_0, 12 * sizeof(byte)),
                                                  Sse2.bslli_si128(_v16_16, 4 * sizeof(byte)),
                                                  0b1111_1100);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v16_0, 12 * sizeof(byte)),
                                                    Sse2.bslli_si128(_v16_16, 4 * sizeof(byte)),
                                                    0b1111_1100);
                    }
                }
                else
                {
                    return new byte16(x12, x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 12 * sizeof(byte)), Sse2.bsrli_si128(value, 4 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0111_1000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value, 12 * sizeof(byte)), 0b1100_0000);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value,  4 * sizeof(byte)), 0b0011_1111);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value, 12 * sizeof(byte)), 0b1100_0000);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value,  4 * sizeof(byte)), 0b0011_1111);
                    }
                }
                else
                {
                    this.x12 = value.x0;
                    this.x13 = value.x1;
                    this.x14 = value.x2;
                    this.x15 = value.x3;
                    this.x16 = value.x4;
                    this.x17 = value.x5;
                    this.x18 = value.x6;
                    this.x19 = value.x7;
                    this.x20 = value.x8;
                    this.x21 = value.x9;
                    this.x22 = value.x10;
                    this.x23 = value.x11;
                    this.x24 = value.x12;
                    this.x25 = value.x13;
                    this.x26 = value.x14;
                    this.x27 = value.x15;
                }
            }
        }
        public byte16 v16_13
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(v16_0,  13 * sizeof(byte)), 
                                       Sse2.bslli_si128(v16_16, 3 * sizeof(byte)),
                                       new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte16(x13, x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 13 * sizeof(byte)), Sse2.bsrli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value,  3 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0));
                }
                else
                {
                    this.x13 = value.x0;
                    this.x14 = value.x1;
                    this.x15 = value.x2;
                    this.x16 = value.x3;
                    this.x17 = value.x4;
                    this.x18 = value.x5;
                    this.x19 = value.x6;
                    this.x20 = value.x7;
                    this.x21 = value.x8;
                    this.x22 = value.x9;
                    this.x23 = value.x10;
                    this.x24 = value.x11;
                    this.x25 = value.x12;
                    this.x26 = value.x13;
                    this.x27 = value.x14;
                    this.x28 = value.x15;
                }
            }
        }
        public byte16 v16_14
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.insert_epi16(Sse2.bslli_si128(v16_16, 2 * sizeof(byte)), Avx2.mm256_extract_epi16(this, 7), 0);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(_v16_0, 14 * sizeof(byte)),
                                                  Sse2.bslli_si128(_v16_16, 2 * sizeof(byte)),
                                                  0b1111_1110);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v16_0, 14 * sizeof(byte)),
                                                    Sse2.bslli_si128(_v16_16, 2 * sizeof(byte)),
                                                    0b1111_1110);
                    }
                }
                else
                {
                    return new byte16(x14, x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 14 * sizeof(byte)), Sse2.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this._v16_0  = Sse4_1.blend_epi16(_v16_0,  Sse2.bslli_si128(value, 14 * sizeof(byte)), 0b1000_0000);
                        this._v16_16 = Sse4_1.blend_epi16(_v16_16, Sse2.bsrli_si128(value,  2 * sizeof(byte)), 0b0111_1111);
                    }
                    else
                    {
                        this._v16_0  = Mask.BlendEpi16_SSE2(_v16_0,  Sse2.bslli_si128(value, 14 * sizeof(byte)), 0b1000_0000);
                        this._v16_16 = Mask.BlendEpi16_SSE2(_v16_16, Sse2.bsrli_si128(value,  2 * sizeof(byte)), 0b0111_1111);
                    }
                }
                else
                {
                    this.x14 = value.x0;
                    this.x15 = value.x1;
                    this.x16 = value.x2;
                    this.x17 = value.x3;
                    this.x18 = value.x4;
                    this.x19 = value.x5;
                    this.x20 = value.x6;
                    this.x21 = value.x7;
                    this.x22 = value.x8;
                    this.x23 = value.x9;
                    this.x24 = value.x10;
                    this.x25 = value.x11;
                    this.x26 = value.x12;
                    this.x27 = value.x13;
                    this.x28 = value.x14;
                    this.x29 = value.x15;
                }
            }
        }
        public byte16 v16_15
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse4_1.insert_epi8(Sse2.bslli_si128(v16_16, sizeof(byte)), (byte)Avx2.mm256_extract_epi8(this, 15), 0);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(_v16_0,  15 * sizeof(byte)), 
                                       Sse2.bslli_si128(_v16_16, sizeof(byte)),
                                       new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte16(x15, x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 15 * sizeof(byte)), Sse2.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(_v16_0,  Sse2.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this._v16_16 = Mask.BlendV(_v16_16, Sse2.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0));
                }
                else
                {
                    this.x15 = value.x0;
                    this.x16 = value.x1;
                    this.x17 = value.x2;
                    this.x18 = value.x3;
                    this.x19 = value.x4;
                    this.x20 = value.x5;
                    this.x21 = value.x6;
                    this.x22 = value.x7;
                    this.x23 = value.x8;
                    this.x24 = value.x9;
                    this.x25 = value.x10;
                    this.x26 = value.x11;
                    this.x27 = value.x12;
                    this.x28 = value.x13;
                    this.x29 = value.x14;
                    this.x30 = value.x15;
                }
            }
        }
        public byte16 v16_16
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
                    return _v16_16;
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
                    this._v16_16 = value;
                }
            }
        }

        public byte8 v8_0
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_0;
                }
                else
                {
                    return new byte8(x0, x1, x2, x3, x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 0);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_0 = value;
                }
                else
                {
                    this.x0  = value.x0;
                    this.x1  = value.x1;
                    this.x2  = value.x2;
                    this.x3  = value.x3;
                    this.x4  = value.x4;
                    this.x5  = value.x5;
                    this.x6  = value.x6;
                    this.x7  = value.x7;
                }
            }
        }
        public byte8 v8_1
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_1;
                }
                else
                {
                    return new byte8(x1, x2, x3, x4, x5, x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_1 = value;
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
        public byte8 v8_2
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_2;
                }
                else
                {
                    return new byte8(x2, x3, x4, x5, x6, x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_2 = value;
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
        public byte8 v8_3
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_3;
                }
                else
                {
                    return new byte8(x3, x4, x5, x6, x7, x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_3 = value;
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
        public byte8 v8_4
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_4;
                }
                else
                {
                    return new byte8(x4, x5, x6, x7, x8, x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 4 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0000_0110);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_4 = value;
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
        public byte8 v8_5
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_5;
                }
                else
                {
                    return new byte8(x5, x6, x7, x8, x9, x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_5 = value;
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
        public byte8 v8_6
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_6;
                }
                else
                {
                    return new byte8(x6, x7, x8, x9, x10, x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_6 = value;
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
        public byte8 v8_7
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_7;
                }
                else
                {
                    return new byte8(x7, x8, x9, x10, x11, x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_7 = value;
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
        public byte8 v8_8
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v8_8;
                }
                else
                {
                    return new byte8(x8, x9, x10, x11, x12, x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 1);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v8_8 = value;
                }
                else
                {
                    this.x8  = value.x0;
                    this.x9  = value.x1;
                    this.x10 = value.x2;
                    this.x11 = value.x3;
                    this.x12 = value.x4;
                    this.x13 = value.x5;
                    this.x14 = value.x6;
                    this.x15 = value.x7;
                }
            }
        }
        public byte8 v8_9
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return Sse2.bsrli_si128(perm, sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(_v16_0,  9 * sizeof(byte)),
                                       Sse2.bslli_si128(_v16_16, 7 * sizeof(byte)),
                                       new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                }
                else
                {
                    return new byte8(x9, x10, x11, x12, x13, x14, x15, x16);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 9 * sizeof(byte)), Sse2.bsrli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value, 7 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x9  = value.x0;
                    this.x10 = value.x1;
                    this.x11 = value.x2;
                    this.x12 = value.x3;
                    this.x13 = value.x4;
                    this.x14 = value.x5;
                    this.x15 = value.x6;
                    this.x16 = value.x7;
                }
            }
        }
        public byte8 v8_10
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return Sse2.bsrli_si128(perm, 2 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blend_epi16(Sse2.bsrli_si128(_v16_0, 10 * sizeof(byte)),
                                                  Sse2.bslli_si128(_v16_16, 6 * sizeof(byte)),
                                                  0b1111_1000);
                    }
                    else
                    {
                        return Mask.BlendEpi16_SSE2(Sse2.bsrli_si128(_v16_0, 10 * sizeof(byte)),
                                                    Sse2.bslli_si128(_v16_16, 6 * sizeof(byte)),
                                                    0b1111_1000);
                    }
                }
                else
                {
                    return new byte8(x10, x11, x12, x13, x14, x15, x16, x17);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 10 * sizeof(byte)), Sse2.bsrli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 10 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  6 * sizeof(byte)), new v128(255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x10 = value.x0;
                    this.x11 = value.x1;
                    this.x12 = value.x2;
                    this.x13 = value.x3;
                    this.x14 = value.x4;
                    this.x15 = value.x5;
                    this.x16 = value.x6;
                    this.x17 = value.x7;
                }
            }
        }
        public byte8 v8_11
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return Sse2.bsrli_si128(perm, 3 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_11.v8_0;
                }
                else
                {
                    return new byte8(x11, x12, x13, x14, x15, x16, x17, x18);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 11 * sizeof(byte)), Sse2.bsrli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  5 * sizeof(byte)), new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x11 = value.x0;
                    this.x12 = value.x1;
                    this.x13 = value.x2;
                    this.x14 = value.x3;
                    this.x15 = value.x4;
                    this.x16 = value.x5;
                    this.x17 = value.x6;
                    this.x18 = value.x7;
                }
            }
        }
        public byte8 v8_12
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(3, 4, 0, 0))));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi32(Sse2.bsrli_si128(_v16_0, 12 * sizeof(byte)), _v16_16);
                }
                else
                {
                    return new byte8(x12, x13, x14, x15, x16, x17, x18, x19);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 12 * sizeof(byte)), Sse2.bsrli_si128(value, 4 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0001_1000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 12 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  4 * sizeof(byte)), new v128(255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x12 = value.x0;
                    this.x13 = value.x1;
                    this.x14 = value.x2;
                    this.x15 = value.x3;
                    this.x16 = value.x4;
                    this.x17 = value.x5;
                    this.x18 = value.x6;
                    this.x19 = value.x7;
                }
            }
        }
        public byte8 v8_13
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return Sse2.bsrli_si128(perm, 5 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_13.v8_0;
                }
                else
                {
                    return new byte8(x13, x14, x15, x16, x17, x18, x19, x20);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 13 * sizeof(byte)), Sse2.bsrli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  3 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x13 = value.x0;
                    this.x14 = value.x1;
                    this.x15 = value.x2;
                    this.x16 = value.x3;
                    this.x17 = value.x4;
                    this.x18 = value.x5;
                    this.x19 = value.x6;
                    this.x20 = value.x7;
                }
            }
        }
        public byte8 v8_14
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return Sse2.bsrli_si128(perm, 6 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_14.v8_0;
                }
                else
                {
                    return new byte8(x14, x15, x16, x17, x18, x19, x20, x21);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 14 * sizeof(byte)), Sse2.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  2 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x14 = value.x0;
                    this.x15 = value.x1;
                    this.x16 = value.x2;
                    this.x17 = value.x3;
                    this.x18 = value.x4;
                    this.x19 = value.x5;
                    this.x20 = value.x6;
                    this.x21 = value.x7;
                }
            }
        }
        public byte8 v8_15
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));

                    return Sse2.bsrli_si128(perm, 7 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_15.v8_0;
                }
                else
                {
                    return new byte8(x15, x16, x17, x18, x19, x20, x21, x22);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 15 * sizeof(byte)), Sse2.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x15 = value.x0;
                    this.x16 = value.x1;
                    this.x17 = value.x2;
                    this.x18 = value.x3;
                    this.x19 = value.x4;
                    this.x20 = value.x5;
                    this.x21 = value.x6;
                    this.x22 = value.x7;
                }
            }
        }
        public byte8 v8_16
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_0;
                }
                else
                {
                    return new byte8(x16, x17, x18, x19, x20, x21, x22, x23);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 2);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_0 = value;
                }
                else
                {
                    this.x16 = value.x0;
                    this.x17 = value.x1;
                    this.x18 = value.x2;
                    this.x19 = value.x3;
                    this.x20 = value.x4;
                    this.x21 = value.x5;
                    this.x22 = value.x6;
                    this.x23 = value.x7;
                }
            }
        }
        public byte8 v8_17
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Sse2.bsrli_si128(perm, sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_1;
                }
                else
                {
                    return new byte8(x17, x18, x19, x20, x21, x22, x23, x24);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_1 = value;
                }
                else
                {
                    this.x17 = value.x0;
                    this.x18 = value.x1;
                    this.x19 = value.x2;
                    this.x20 = value.x3;
                    this.x21 = value.x4;
                    this.x22 = value.x5;
                    this.x23 = value.x6;
                    this.x24 = value.x7;
                }
            }
        }
        public byte8 v8_18
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Sse2.bsrli_si128(perm, 2 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_2;
                }
                else
                {
                    return new byte8(x18, x19, x20, x21, x22, x23, x24, x25);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 2 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_2 = value;
                }
                else
                {
                    this.x18 = value.x0;
                    this.x19 = value.x1;
                    this.x20 = value.x2;
                    this.x21 = value.x3;
                    this.x22 = value.x4;
                    this.x23 = value.x5;
                    this.x24 = value.x6;
                    this.x25 = value.x7;
                }
            }
        }
        public byte8 v8_19
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Sse2.bsrli_si128(perm, 3 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_3;
                }
                else
                {
                    return new byte8(x19, x20, x21, x22, x23, x24, x25, x26);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_3 = value;
                }
                else
                {
                    this.x19 = value.x0;
                    this.x20 = value.x1;
                    this.x21 = value.x2;
                    this.x22 = value.x3;
                    this.x23 = value.x4;
                    this.x24 = value.x5;
                    this.x25 = value.x6;
                    this.x26 = value.x7;
                }
            }
        }
        public byte8 v8_20
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(this, Avx.mm256_castsi128_si256(new v128(5, 6, 0, 0))));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_4;
                }
                else
                {
                    return new byte8(x20, x21, x22, x23, x24, x25, x26, x27);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 4 * sizeof(byte)), 1);

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0110_0000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_4 = value;
                }
                else
                {
                    this.x20 = value.x0;
                    this.x21 = value.x1;
                    this.x22 = value.x2;
                    this.x23 = value.x3;
                    this.x24 = value.x4;
                    this.x25 = value.x5;
                    this.x26 = value.x6;
                    this.x27 = value.x7;
                }
            }
        }
        public byte8 v8_21
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Sse2.bsrli_si128(perm, 5 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_5;
                }
                else
                {
                    return new byte8(x21, x22, x23, x24, x25, x26, x27, x28);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_5 = value;
                }
                else
                {
                    this.x21 = value.x0;
                    this.x22 = value.x1;
                    this.x23 = value.x2;
                    this.x24 = value.x3;
                    this.x25 = value.x4;
                    this.x26 = value.x5;
                    this.x27 = value.x6;
                    this.x28 = value.x7;
                }
            }
        }
        public byte8 v8_22
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Sse2.bsrli_si128(perm, 6 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_6;
                }
                else
                {
                    return new byte8(x22, x23, x24, x25, x26, x27, x28, x29);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 6 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_6 = value;
                }
                else
                {
                    this.x22 = value.x0;
                    this.x23 = value.x1;
                    this.x24 = value.x2;
                    this.x25 = value.x3;
                    this.x26 = value.x4;
                    this.x27 = value.x5;
                    this.x28 = value.x6;
                    this.x29 = value.x7;
                }
            }
        }
        public byte8 v8_23
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Sse2.bsrli_si128(perm, 7 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v8_7;
                }
                else
                {
                    return new byte8(x23, x24, x25, x26, x27, x28, x29, x30);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_7 = value;
                }
                else
                {
                    this.x23 = value.x0;
                    this.x24 = value.x1;
                    this.x25 = value.x2;
                    this.x26 = value.x3;
                    this.x27 = value.x4;
                    this.x28 = value.x5;
                    this.x29 = value.x6;
                    this.x30 = value.x7;
                }
            }
        }
        public byte8 v8_24
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
                    return v16_16.v8_8;
                }
                else
                {
                    return new byte8(x24, x25, x26, x27, x28, x29, x30, x31);
                }
                
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 3);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v8_8 = value;
                }
                else
                {
                    this.x24 = value.x0;
                    this.x25 = value.x1;
                    this.x26 = value.x2;
                    this.x27 = value.x3;
                    this.x28 = value.x4;
                    this.x29 = value.x5;
                    this.x30 = value.x6;
                    this.x31 = value.x7;
                }
            }
        }

        public byte4 v4_0
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_0;
                }
                else
                {
                    return new byte4(x0, x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 0);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_0 = Sse4_1.insert_epi32(this._v16_0, *(int*)&value, 0);
                }
                else
                {
                    this.x0  = value.x;
                    this.x1  = value.y;
                    this.x2  = value.z;
                    this.x3  = value.w;
                }
            }
        }
        public byte4 v4_1
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_1;
                }
                else
                {
                    return new byte4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_1 = value;
                }
                else
                {
                    this.x1  = value.x;
                    this.x2  = value.y;
                    this.x3  = value.z;
                    this.x4  = value.w;
                }
            }
        }
        public byte4 v4_2
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_2;
                }
                else
                {
                    return new byte4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_2 = value;
                }
                else
                {
                    this.x2  = value.x;
                    this.x3  = value.y;
                    this.x4  = value.z;
                    this.x5  = value.w;
                }
            }
        }
        public byte4 v4_3
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_3;
                }
                else
                {
                    return new byte4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_3 = value;
                }
                else
                {
                    this.x3  = value.x;
                    this.x4  = value.y;
                    this.x5  = value.z;
                    this.x6  = value.w;
                }
            }
        }
        public byte4 v4_4
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_4;
                }
                else
                {
                    return new byte4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 1);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_0 = Sse4_1.insert_epi32(this._v16_0, *(int*)&value, 1);
                }
                else
                {
                    this.x4  = value.x;
                    this.x5  = value.y;
                    this.x6  = value.z;
                    this.x7  = value.w;
                }
            }
        }
        public byte4 v4_5
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_5;
                }
                else
                {
                    return new byte4(x5, x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_5 = value;
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
        public byte4 v4_6
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_6;
                }
                else
                {
                    return new byte4(x6, x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_6 = value;
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
        public byte4 v4_7
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_7;
                }
                else
                {
                    return new byte4(x7, x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_7 = value;
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
        public byte4 v4_8
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_8;
                }
                else
                {
                    return new byte4(x8, x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 2);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_0 = Sse4_1.insert_epi32(this._v16_0, *(int*)&value, 2);
                }
                else
                {
                    this.x8  = value.x;
                    this.x9  = value.y;
                    this.x10 = value.z;
                    this.x11 = value.w;
                }
            }
        }
        public byte4 v4_9
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_9;
                }
                else
                {
                    return new byte4(x9, x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_9 = value;
                }
                else
                {
                    this.x9  = value.x;
                    this.x10 = value.y;
                    this.x11 = value.z;
                    this.x12 = value.w;
                }

            }
        }
        public byte4 v4_10
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_10;
                }
                else
                {
                    return new byte4(x10, x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 10 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_10 = value;
                }
                else
                {
                    this.x10 = value.x;
                    this.x11 = value.y;
                    this.x12 = value.z;
                    this.x13 = value.w;
                }
            }
        }
        public byte4 v4_11
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_11;
                }
                else
                {
                    return new byte4(x11, x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v4_11 = value;
                }
                else
                {
                    this.x11 = value.x;
                    this.x12 = value.y;
                    this.x13 = value.z;
                    this.x14 = value.w;
                }
            }
        }
        public byte4 v4_12
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v4_12;
                }
                else
                {
                    return new byte4(x12, x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 3);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_0 = Sse4_1.insert_epi32(this._v16_0, *(int*)&value, 3);
                }
                else
                {
                    this.x12 = value.x;
                    this.x13 = value.y;
                    this.x14 = value.z;
                    this.x15 = value.w;
                }
            }
        }
        public byte4 v4_13
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.bsrli_si128(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))), 5 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(_v16_0,  13 * sizeof(byte)),
                                       Sse2.bslli_si128(_v16_16, 3 * sizeof(byte)),
                                       new byte4(0, 0, 0, 255));
                }
                else
                {
                    return new byte4(x13, x14, x15, x16);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 13 * sizeof(byte)), Sse2.bsrli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  3 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x13 = value.x;
                    this.x14 = value.y;
                    this.x15 = value.z;
                    this.x16 = value.w;
                }
            }
        }
        public byte4 v4_14
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.bsrli_si128(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))), 6 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi16(Sse2.bsrli_si128(_v16_0,  14 * sizeof(byte)), _v16_16);
                }
                else
                {
                    return new byte4(x14, x15, x16, x17);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 14 * sizeof(byte)), Sse2.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  2 * sizeof(byte)), new v128(255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x14 = value.x;
                    this.x15 = value.y;
                    this.x16 = value.z;
                    this.x17 = value.w;
                }
            }
        }
        public byte4 v4_15
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.bsrli_si128(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))), 7 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(_v16_0,  15 * sizeof(byte)),
                                       Sse2.bslli_si128(_v16_16, sizeof(byte)),
                                       new byte4(0, 255, 255, 255));
                }
                else
                {
                    return new byte4(x15, x16, x17, x18);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 15 * sizeof(byte)), Sse2.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x15 = value.x;
                    this.x16 = value.y;
                    this.x17 = value.z;
                    this.x18 = value.w;
                }
            }
        }
        public byte4 v4_16
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_0;
                }
                else
                {
                    return new byte4(x16, x17, x18, x19);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 4);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_16 = Sse4_1.insert_epi32(this._v16_16, *(int*)&value, 0);
                }
                else
                {
                    this.x16 = value.x;
                    this.x17 = value.y;
                    this.x18 = value.z;
                    this.x19 = value.w;
                }
            }
        }
        public byte4 v4_17
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_1;
                }
                else
                {
                    return new byte4(x17, x18, x19, x20);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_1 = value;
                }
                else
                {
                    this.x17 = value.x;
                    this.x18 = value.y;
                    this.x19 = value.z;
                    this.x20 = value.w;
                }
            }
        }
        public byte4 v4_18
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_2;
                }
                else
                {
                    return new byte4(x18, x19, x20, x21);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 2 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_2 = value;
                }
                else
                {
                    this.x18 = value.x;
                    this.x19 = value.y;
                    this.x20 = value.z;
                    this.x21 = value.w;
                }
            }
        }
        public byte4 v4_19
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_3;
                }
                else
                {
                    return new byte4(x19, x20, x21, x22);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_3 = value;
                }
                else
                {
                    this.x19 = value.x;
                    this.x20 = value.y;
                    this.x21 = value.z;
                    this.x22 = value.w;
                }
            }
        }
        public byte4 v4_20
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 5);

                    return *(byte4*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_4;
                }
                else
                {
                    return new byte4(x20, x21, x22, x23);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 5);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_16 = Sse4_1.insert_epi32(this._v16_16, *(int*)&value, 1);
                }
                else
                {
                    this.x20 = value.x;
                    this.x21 = value.y;
                    this.x22 = value.z;
                    this.x23 = value.w;
                }
            }
        }
        public byte4 v4_21
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_5;
                }
                else
                {
                    return new byte4(x21, x22, x23, x24);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_5 = value;
                }
                else
                {
                    this.x21 = value.x;
                    this.x22 = value.y;
                    this.x23 = value.z;
                    this.x24 = value.w;
                }
            }
        }
        public byte4 v4_22
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_6;
                }
                else
                {
                    return new byte4(x22, x23, x24, x25);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 6 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_6 = value;
                }
                else
                {
                    this.x22 = value.x;
                    this.x23 = value.y;
                    this.x24 = value.z;
                    this.x25 = value.w;
                }
            }
        }
        public byte4 v4_23
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_7;
                }
                else
                {
                    return new byte4(x23, x24, x25, x26);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_7 = value;
                }
                else
                {
                    this.x23 = value.x;
                    this.x24 = value.y;
                    this.x25 = value.z;
                    this.x26 = value.w;
                }
            }
        }
        public byte4 v4_24
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
                    return v16_16.v4_8;
                }
                else
                {
                    return new byte4(x24, x25, x26, x27);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 6);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_16 = Sse4_1.insert_epi32(this._v16_16, *(int*)&value, 2);
                }
                else
                {
                    this.x24 = value.x;
                    this.x25 = value.y;
                    this.x26 = value.z;
                    this.x27 = value.w;
                }
            }
        }
        public byte4 v4_25
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_9;
                }
                else
                {
                    return new byte4(x25, x26, x27, x28);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 9 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_9 = value;
                }
                else
                {
                    this.x25 = value.x;
                    this.x26 = value.y;
                    this.x27 = value.z;
                    this.x28 = value.w;
                }
            }
        }
        public byte4 v4_26
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_10;
                }
                else
                {
                    return new byte4(x26, x27, x28, x29);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 10 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_10 = value;
                }
                else
                {
                    this.x26 = value.x;
                    this.x27 = value.y;
                    this.x28 = value.z;
                    this.x29 = value.w;
                }
            }
        }
        public byte4 v4_27
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_11;
                }
                else
                {
                    return new byte4(x27, x28, x29, x30);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 11 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v4_11 = value;
                }
                else
                {
                    this.x27 = value.x;
                    this.x28 = value.y;
                    this.x29 = value.z;
                    this.x30 = value.w;
                }
            }
        }
        public byte4 v4_28
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
            {
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 7);

                    return *(byte4*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v4_12;
                }
                else
                {
                    return new byte4( x28, x29, x30, x31);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi32(this, *(int*)&value, 7);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    this._v16_16 = Sse4_1.insert_epi32(this._v16_16, *(int*)&value, 3);
                }
                else
                {
                    this.x28 = value.x;
                    this.x29 = value.y;
                    this.x30 = value.z;
                    this.x31 = value.w;
                }
            }
        }

        public byte3 v3_0
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_0;
                }
                else
                {
                    return new byte3(x0, x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(value);
                    v256 mask = new v256(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_0 = value;
                }
                else
                {
                    this.x0  = value.x;
                    this.x1  = value.y;
                    this.x2  = value.z;
                }

            }
        }
        public byte3 v3_1
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_1;
                }
                else
                {
                    return new byte3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_1 = value;
                }
                else
                {
                    this.x1  = value.x;
                    this.x2  = value.y;
                    this.x3  = value.z;
                }
            }
        }
        public byte3 v3_2
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_2;
                }
                else
                {
                    return new byte3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_2 = value;
                }
                else
                {
                    this.x2  = value.x;
                    this.x3  = value.y;
                    this.x4  = value.z;
                }
            }
        }
        public byte3 v3_3
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_3;
                }
                else
                {
                    return new byte3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_3 = value;
                }
                else
                {
                    this.x3  = value.x;
                    this.x4  = value.y;
                    this.x5  = value.z;
                }
            }
        }
        public byte3 v3_4
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_4;
                }
                else
                {
                    return new byte3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 4 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_4 = value;
                }
                else
                {
                    this.x4  = value.x;
                    this.x5  = value.y;
                    this.x6  = value.z;
                }
            }
        }
        public byte3 v3_5
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_5;
                }
                else
                {
                    return new byte3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_5 = value;
                }
                else
                {
                    this.x5  = value.x;
                    this.x6  = value.y;
                    this.x7  = value.z;
                }
            }
        }
        public byte3 v3_6
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_6;
                }
                else
                {
                    return new byte3(x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_6 = value;
                }
                else
                {
                    this.x6  = value.x;
                    this.x7  = value.y;
                    this.x8  = value.z;
                }
            }
        }
        public byte3 v3_7
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_7;
                }
                else
                {
                    return new byte3(x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_7 = value;
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                    this.x9  = value.z;
                }
            }
        }
        public byte3 v3_8
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_8;
                }
                else
                {
                    return new byte3(x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 8 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_8 = value;
                }
                else
                {
                    this.x8  = value.x;
                    this.x9  = value.y;
                    this.x10 = value.z;
                }
            }
        }
        public byte3 v3_9
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_9;
                }
                else
                {
                    return new byte3(x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_9 = value;
                }
                else
                {
                    this.x9  = value.x;
                    this.x10 = value.y;
                    this.x11 = value.z;
                }
            }
        }
        public byte3 v3_10
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_10;
                }
                else
                {
                    return new byte3(x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 10 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_10 = value;
                }
                else
                {
                    this.x10 = value.x;
                    this.x11 = value.y;
                    this.x12 = value.z;
                }
            }
        }
        public byte3 v3_11
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_11;
                }
                else
                {
                    return new byte3(x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_11 = value;
                }
                else
                {
                    this.x11 = value.x;
                    this.x12 = value.y;
                    this.x13 = value.z;
                }
            }
        }
        public byte3 v3_12
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_12;
                }
                else
                {
                    return new byte3(x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 12 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_12 = value;
                }
                else
                {
                    this.x12 = value.x;
                    this.x13 = value.y;
                    this.x14 = value.z;
                }
            }
        }
        public byte3 v3_13
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v3_13;
                }
                else
                {
                    return new byte3(x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 13 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v3_13 = value;
                }
                else
                {
                    this.x13 = value.x;
                    this.x14 = value.y;
                    this.x15 = value.z;
                }
            }
        }
        public byte3 v3_14
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.bsrli_si128(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))), 6 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi16(Sse2.bsrli_si128(_v16_0,  14 * sizeof(byte)), _v16_16);
                }
                else
                {
                    return new byte3(x14, x15, x16);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 14 * sizeof(byte)), Sse2.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,  2 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x14 = value.x;
                    this.x15 = value.y;
                    this.x16 = value.z;
                }
            }
        }
        public byte3 v3_15
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.bsrli_si128(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))), 7 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Mask.BlendV(Sse2.bsrli_si128(_v16_0,  15 * sizeof(byte)),
                                       Sse2.bslli_si128(_v16_16, sizeof(byte)),
                                       new byte4(0, 255, 255, 255));
                }
                else
                {
                    return new byte3(x15, x16, x17);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 15 * sizeof(byte)), Sse2.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x15 = value.x;
                    this.x16 = value.y;
                    this.x17 = value.z;
                }
            }
        }
        public byte3 v3_16
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_0;
                }
                else
                {
                    return new byte3(x16, x17, x18);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), value, 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_0 = value;
                }
                else
                {
                    this.x16 = value.x;
                    this.x17 = value.y;
                    this.x18 = value.z;
                }
            }
        }
        public byte3 v3_17
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_1;
                }
                else
                {
                    return new byte3(x17, x18, x19);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 1 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_1 = value;
                }
                else
                {
                    this.x17 = value.x;
                    this.x18 = value.y;
                    this.x19 = value.z;
                }
            }
        }
        public byte3 v3_18
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_2;
                }
                else
                {
                    return new byte3(x18, x19, x20);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 2 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_2 = value;
                }
                else
                {
                    this.x18 = value.x;
                    this.x19 = value.y;
                    this.x20 = value.z;
                }
            }
        }
        public byte3 v3_19
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_3;
                }
                else
                {
                    return new byte3(x19, x20, x21);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_3 = value;
                }
                else
                {
                    this.x19 = value.x;
                    this.x20 = value.y;
                    this.x21 = value.z;
                }
            }
        }
        public byte3 v3_20
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 5);

                    return *(byte3*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_4;
                }
                else
                {
                    return new byte3(x20, x21, x22);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 4 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_4 = value;
                }
                else
                {
                    this.x20 = value.x;
                    this.x21 = value.y;
                    this.x22 = value.z;
                }
            }
        }
        public byte3 v3_21
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_5;
                }
                else
                {
                    return new byte3(x21, x22, x23);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_5 = value;
                }
                else
                {
                    this.x21 = value.x;
                    this.x22 = value.y;
                    this.x23 = value.z;
                }
            }
        }
        public byte3 v3_22
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_6;
                }
                else
                {
                    return new byte3(x22, x23, x24);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 6 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_6 = value;
                }
                else
                {
                    this.x22 = value.x;
                    this.x23 = value.y;
                    this.x24 = value.z;
                }
            }
        }
        public byte3 v3_23
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_7;
                }
                else
                {
                    return new byte3(x23, x24, x25);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_7 = value;
                }
                else
                {
                    this.x23 = value.x;
                    this.x24 = value.y;
                    this.x25 = value.z;
                }
            }
        }
        public byte3 v3_24
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_8;
                }
                else
                {
                    return new byte3(x24, x25, x26);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 8 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_8 = value;
                }
                else
                {
                    this.x24 = value.x;
                    this.x25 = value.y;
                    this.x26 = value.z;
                }
            }
        }
        public byte3 v3_25
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_9;
                }
                else
                {
                    return new byte3(x25, x26, x27);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 9 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_9 = value;
                }
                else
                {
                    this.x25 = value.x;
                    this.x26 = value.y;
                    this.x27 = value.z;
                }
            }
        }
        public byte3 v3_26
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_10;
                }
                else
                {
                    return new byte3(x26, x27, x28);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 10 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_10 = value;
                }
                else
                {
                    this.x26 = value.x;
                    this.x27 = value.y;
                    this.x28 = value.z;
                }
            }
        }
        public byte3 v3_27
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_11;
                }
                else
                {
                    return new byte3(x27, x28, x29);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 11 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_11 = value;
                }
                else
                {
                    this.x27 = value.x;
                    this.x28 = value.y;
                    this.x29 = value.z;
                }
            }
        }
        public byte3 v3_28
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 7);

                    return *(byte3*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_12;
                }
                else
                {
                    return new byte3(x28, x29, x30);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 12 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_12 = value;
                }
                else
                {
                    this.x28 = value.x;
                    this.x29 = value.y;
                    this.x30 = value.z;
                }
            }
        }
        public byte3 v3_29
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v3_13;
                }
                else
                {
                    return new byte3(x29, x30, x31);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default(v256), Sse2.bslli_si128(value, 13 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v3_13 = value;
                }
                else
                {
                    this.x29 = value.x;
                    this.x30 = value.y;
                    this.x31 = value.z;
                }
            }
        }

        public byte2 v2_0
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_0;
                }
                else
                {
                    return new byte2(x0, x1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 0);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 0);
                }
                else
                {
                    this.x0  = value.x;
                    this.x1  = value.y;
                }
            }
        }
        public byte2 v2_1
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_1;
                }
                else
                {
                    return new byte2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_1 = value;
                }
                else
                {
                    this.x1  = value.x;
                    this.x2  = value.y;
                }
            }
        }
        public byte2 v2_2
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_2;
                }
                else
                {
                    return new byte2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 1);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 1);
                }
                else
                {
                    this.x2  = value.x;
                    this.x3  = value.y;
                }
            }
        }
        public byte2 v2_3
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_3;
                }
                else
                {
                    return new byte2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_3 = value;
                }
                else
                {
                    this.x3  = value.x;
                    this.x4  = value.y;
                }
            }
        }
        public byte2 v2_4
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_4;
                }
                else
                {
                    return new byte2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 2);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 2);
                }
                else
                {
                    this.x4  = value.x;
                    this.x5  = value.y;
                }
            }
        }
        public byte2 v2_5
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_5;
                }
                else
                {
                    return new byte2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_5 = value;
                }
                else
                {
                    this.x5  = value.x;
                    this.x6  = value.y;
                }
            }
        }
        public byte2 v2_6
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_6;
                }
                else
                {
                    return new byte2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 3);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 3);
                }
                else
                {
                    this.x6  = value.x;
                    this.x7  = value.y;
                }
            }
        }
        public byte2 v2_7
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_7;
                }
                else
                {
                    return new byte2(x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_7 = value;
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                }
            }
        }
        public byte2 v2_8
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_8;
                }
                else
                {
                    return new byte2(x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 4);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 4);
                }
                else
                {
                    this.x8  = value.x;
                    this.x9  = value.y;
                }
            }
        }
        public byte2 v2_9
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_9;
                }
                else
                {
                    return new byte2(x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_9 = value;
                }
                else
                {
                    this.x9  = value.x;
                    this.x10 = value.y;
                }
            }
        }
        public byte2 v2_10
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_10;
                }
                else
                {
                    return new byte2(x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 5);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 5);
                }
                else
                {
                    this.x10 = value.x;
                    this.x11 = value.y;
                }
            }
        }
        public byte2 v2_11
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_11;
                }
                else
                {
                    return new byte2(x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_11 = value;
                }
                else
                {
                    this.x11 = value.x;
                    this.x12 = value.y;
                }
            }
        }
        public byte2 v2_12
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_12;
                }
                else
                {
                    return new byte2(x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 6);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 6);
                }
                else
                {
                    this.x12 = value.x;
                    this.x13 = value.y;
                }
            }
        }
        public byte2 v2_13
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_13;
                }
                else
                {
                    return new byte2(x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Sse2.bslli_si128(value, 13 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0.v2_13 = value;
                }
                else
                {
                    this.x13 = value.x;
                    this.x14 = value.y;
                }
            }
        }
        public byte2 v2_14
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_0.v2_14;
                }
                else
                {
                    return new byte2(x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 7);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0 = Sse2.insert_epi16(this._v16_0, *(short*)&value, 7);
                }
                else
                {
                    this.x14 = value.x;
                    this.x15 = value.y;
                }
            }
        }
        public byte2 v2_15
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Sse2.bsrli_si128(Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1))), 7 * sizeof(byte));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Sse2.unpacklo_epi8(Sse2.bsrli_si128(_v16_0, 15 * sizeof(byte)), _v16_16);
                }
                else
                {
                    return new byte2(x15, x16);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = new v256(Sse2.bslli_si128(value, 15 * sizeof(byte)), Sse2.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_0  = Mask.BlendV(this._v16_0,  Sse2.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this._v16_16 = Mask.BlendV(this._v16_16, Sse2.bsrli_si128(value,      sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x15 = value.x;
                    this.x16 = value.y;
                }
            }
        }
        public byte2 v2_16
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_0;
                }
                else
                {
                    return new byte2(x16, x17);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 8);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 0);
                }
                else
                {
                    this.x16 = value.x;
                    this.x17 = value.y;
                }
            }
        }
        public byte2 v2_17
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_1;
                }
                else
                {
                    return new byte2(x17, x18);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_1 = value;
                }
                else
                {
                    this.x17 = value.x;
                    this.x18 = value.y;
                }
            }
        }
        public byte2 v2_18
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 9);

                    return *(byte2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_2;
                }
                else
                {
                    return new byte2(x18, x19);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 9);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 1);
                }
                else
                {
                    this.x18 = value.x;
                    this.x19 = value.y;
                }
            }
        }
        public byte2 v2_19
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_3;
                }
                else
                {
                    return new byte2(x19, x20);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_3 = value;
                }
                else
                {
                    this.x19 = value.x;
                    this.x20 = value.y;
                }
            }
        }
        public byte2 v2_20
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 10);

                    return *(byte2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_4;
                }
                else
                {
                    return new byte2(x20, x21);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 10);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 2);
                }
                else
                {
                    this.x20 = value.x;
                    this.x21 = value.y;
                }
            }
        }
        public byte2 v2_21
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_5;
                }
                else
                {
                    return new byte2(x21, x22);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_5 = value;
                }
                else
                {
                    this.x21 = value.x;
                    this.x22 = value.y;
                }
            }
        }
        public byte2 v2_22
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 11);

                    return *(byte2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_6;
                }
                else
                {
                    return new byte2(x22, x23);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 11);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 3);
                }
                else
                {
                    this.x22 = value.x;
                    this.x23 = value.y;
                }
            }
        }
        public byte2 v2_23
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_7;
                }
                else
                {
                    return new byte2(x23, x24);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_7 = value;
                }
                else
                {
                    this.x23 = value.x;
                    this.x24 = value.y;
                }
            }
        }
        public byte2 v2_24
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_8;
                }
                else
                {
                    return new byte2(x24, x25);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 12);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 4);
                }
                else
                {
                    this.x24 = value.x;
                    this.x25 = value.y;
                }
            }
        }
        public byte2 v2_25
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_9;
                }
                else
                {
                    return new byte2(x25, x26);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, 9 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_9 = value;
                }
                else
                {
                    this.x25 = value.x;
                    this.x26 = value.y;
                }
            }
        }
        public byte2 v2_26
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 13);

                    return *(byte2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_10;
                }
                else
                {
                    return new byte2(x26, x27);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 13);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 5);
                }
                else
                {
                    this.x26 = value.x;
                    this.x27 = value.y;
                }
            }
        }
        public byte2 v2_27
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_11;
                }
                else
                {
                    return new byte2(x27, x28);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, 11 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_11 = value;
                }
                else
                {
                    this.x27 = value.x;
                    this.x28 = value.y;
                }
            }
        }
        public byte2 v2_28
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 14);

                    return *(byte2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_12;
                }
                else
                {
                    return new byte2(x28, x29);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 14);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 6);
                }
                else
                {
                    this.x28 = value.x;
                    this.x29 = value.y;
                }
            }
        }
        public byte2 v2_29
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_13;
                }
                else
                {
                    return new byte2(x29, x30);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Sse2.bslli_si128(value, 13 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0);

                    this = Avx2.mm256_blendv_epi8(this, blend, mask);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16.v2_13 = value;
                }
                else
                {
                    this.x29 = value.x;
                    this.x30 = value.y;
                }
            }
        }
        public byte2 v2_30
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get 
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 15);

                    return *(byte2*)&temp;
                }
                else if (Sse2.IsSse2Supported)
                {
                    return v16_16.v2_14;
                }
                else
                {
                    return new byte2(x30, x31);
                }
			}

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi16(this, *(short*)&value, 15);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this._v16_16 = Sse2.insert_epi16(this._v16_16, *(short*)&value, 7);
                }
                else
                {
                    this.x30 = value.x;
                    this.x31 = value.y;
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v256(byte32 input) => new v256(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15, input.x16, input.x17, input.x18, input.x19, input.x20, input.x21, input.x22, input.x23, input.x24, input.x25, input.x26, input.x27, input.x28, input.x29, input.x30, input.x31);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v256 x)
        public static implicit operator byte32(v256 input) => new byte32 { x0 = input.Byte0, x1 = input.Byte1, x2 = input.Byte2, x3 = input.Byte3, x4 = input.Byte4, x5 = input.Byte5, x6 = input.Byte6, x7 = input.Byte7, x8 = input.Byte8, x9 = input.Byte9, x10 = input.Byte10, x11 = input.Byte11, x12 = input.Byte12, x13 = input.Byte13, x14 = input.Byte14, x15 = input.Byte15, x16 = input.Byte16, x17 = input.Byte17, x18 = input.Byte18, x19 = input.Byte19, x20 = input.Byte20, x21 = input.Byte21, x22 = input.Byte22, x23 = input.Byte23, x24 = input.Byte24, x25 = input.Byte25, x26 = input.Byte26, x27 = input.Byte27, x28 = input.Byte28, x29 = input.Byte29, x30 = input.Byte30, x31 = input.Byte31 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte32(byte input) => new byte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(sbyte32 input)
        {
            if (Avx.IsAvxSupported)
            {
                return (v256)input;
            }
            else if (Sse.IsSseSupported)
            {
                return new byte32((v128)input._v16_0, (v128)input._v16_16);
            }
            else
            {
                return *(byte32*)&input;
            }
        }


        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get
            {
Assert.IsWithinArrayBounds(index, 32);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                asArray[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator + (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi8(left, right);
            }
            else
            {
                return new byte32(left._v16_0 + right._v16_0, left._v16_16 + right._v16_16);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator - (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(left, right);
            }
            else
            {
                return new byte32(left._v16_0 - right._v16_0, left._v16_16 - right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.mul_byte(left, right);
            }
            else
            {
                return new byte32(left._v16_0 * right._v16_0, left._v16_16 * right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdiv_byte(left, right);
            }
            else
            {
                return new byte32(left._v16_0 / right._v16_0, left._v16_16 / right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vrem_byte(left, right);
            }
            else
            {
                return new byte32(left._v16_0 % right._v16_0, left._v16_16 % right._v16_16);
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator & (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(left, right);
            }
            else
            {
                return new byte32(left._v16_0 & right._v16_0, left._v16_16 & right._v16_16);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator | (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_or_si256(left, right);
            }
            else
            {
                return new byte32(left._v16_0 | right._v16_0, left._v16_16 | right._v16_16);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ^ (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(left, right);
            }
            else
            {
                return new byte32(left._v16_0 ^ right._v16_0, left._v16_16 ^ right._v16_16);
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte left, byte32 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 left, byte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new byte32((byte)(left.x0 * right), (byte)(left.x1 * right), (byte)(left.x2 * right), (byte)(left.x3 * right), (byte)(left.x4 * right), (byte)(left.x5 * right), (byte)(left.x6 * right), (byte)(left.x7 * right), (byte)(left.x8 * right), (byte)(left.x9 * right), (byte)(left.x10 * right), (byte)(left.x11 * right), (byte)(left.x12 * right), (byte)(left.x13 * right), (byte)(left.x14 * right), (byte)(left.x15 * right), (byte)(left.x16 * right), (byte)(left.x17 * right), (byte)(left.x18 * right), (byte)(left.x19 * right), (byte)(left.x20 * right), (byte)(left.x21 * right), (byte)(left.x22 * right), (byte)(left.x23 * right), (byte)(left.x24 * right), (byte)(left.x25 * right), (byte)(left.x26 * right), (byte)(left.x27 * right), (byte)(left.x28 * right), (byte)(left.x29 * right), (byte)(left.x30 * right), (byte)(left.x31 * right));
            }
            else
            {
                return new byte32(left._v16_0 * right, left._v16_16 * right);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 left, byte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new byte32((byte)(left.x0 / right), (byte)(left.x1 / right), (byte)(left.x2 / right), (byte)(left.x3 / right), (byte)(left.x4 / right), (byte)(left.x5 / right), (byte)(left.x6 / right), (byte)(left.x7 / right), (byte)(left.x8 / right), (byte)(left.x9 / right), (byte)(left.x10 / right), (byte)(left.x11 / right), (byte)(left.x12 / right), (byte)(left.x13 / right), (byte)(left.x14 / right), (byte)(left.x15 / right), (byte)(left.x16 / right), (byte)(left.x17 / right), (byte)(left.x18 / right), (byte)(left.x19 / right), (byte)(left.x20 / right), (byte)(left.x21 / right), (byte)(left.x22 / right), (byte)(left.x23 / right), (byte)(left.x24 / right), (byte)(left.x25 / right), (byte)(left.x26 / right), (byte)(left.x27 / right), (byte)(left.x28 / right), (byte)(left.x29 / right), (byte)(left.x30 / right), (byte)(left.x31 / right));
            }
            else
            {
                return new byte32(left._v16_0 / right, left._v16_16 / right);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 left, byte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return new byte32((byte)(left.x0 % right), (byte)(left.x1 % right), (byte)(left.x2 % right), (byte)(left.x3 % right), (byte)(left.x4 % right), (byte)(left.x5 % right), (byte)(left.x6 % right), (byte)(left.x7 % right), (byte)(left.x8 % right), (byte)(left.x9 % right), (byte)(left.x10 % right), (byte)(left.x11 % right), (byte)(left.x12 % right), (byte)(left.x13 % right), (byte)(left.x14 % right), (byte)(left.x15 % right), (byte)(left.x16 % right), (byte)(left.x17 % right), (byte)(left.x18 % right), (byte)(left.x19 % right), (byte)(left.x20 % right), (byte)(left.x21 % right), (byte)(left.x22 % right), (byte)(left.x23 % right), (byte)(left.x24 % right), (byte)(left.x25 % right), (byte)(left.x26 % right), (byte)(left.x27 % right), (byte)(left.x28 % right), (byte)(left.x29 % right), (byte)(left.x30 % right), (byte)(left.x31 % right));
            }
            else
            {
                return new byte32(left._v16_0 % right, left._v16_16 % right);
            }
        }

    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ++ (byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else
            {
                return new byte32(x._v16_0 + 1, x._v16_16 + 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator -- (byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi8(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else
            {
                return new byte32(x._v16_0 - 1, x._v16_16 - 1);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ~ (byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else
            {
                return new byte32(~x._v16_0, ~x._v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator << (byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new byte32(x._v16_0 << n, x._v16_16 << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator >> (byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.shrl_byte(x, n);
            }
            else
            {
                return new byte32(x._v16_0 >> n, x._v16_16 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator == (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpeq_epi8(left, right));
            }
            else
            {
                return new bool32(left._v16_0 == right._v16_0, left._v16_16 == right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator < (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(right, left));
            }
            else
            {
                return new bool32(left._v16_0 < right._v16_0, left._v16_16 < right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator > (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(left, right));
            }
            else
            {
                return new bool32(left._v16_0 > right._v16_0, left._v16_16 > right._v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator != (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsFalse(Avx2.mm256_cmpeq_epi8(left, right));
            }
            else
            {
                return new bool32(left._v16_0 != right._v16_0, left._v16_16 != right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator <= (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(left, right), left));
            }
            else
            {
                return new bool32(left._v16_0 <= right._v16_0, left._v16_16 <= right._v16_16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 operator >= (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return TestIsTrue(Avx2.mm256_cmpeq_epi8(Avx2.mm256_max_epu8(left, right), left));
            }
            else
            {
                return new bool32(left._v16_0 >= right._v16_0, left._v16_16 >= right._v16_16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsTrue(v256 input)
        {
            return (v256)(-((sbyte32)input));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool32 TestIsFalse(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_andnot_si256(input, new v256(0x0101_0101));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  bool Equals(byte32 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return uint.MaxValue == (uint)Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi32(this, other));
            }
            else
            {
                return this._v16_0.Equals(other._v16_0) & this._v16_16.Equals(other._v16_16);
            }
        }

        public override  bool Equals(object obj) => Equals((byte32)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v256(this);
            }
            else
            {
                return _v16_0.GetHashCode() ^ _v16_16.GetHashCode();
            }
        }


        public override  string ToString() =>  $"byte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"byte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}