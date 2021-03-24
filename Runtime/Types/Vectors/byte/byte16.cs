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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(byte))]  [DebuggerTypeProxy(typeof(byte16.DebuggerProxy))]
    unsafe public struct byte16 : IEquatable<byte16>, IFormattable
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

            public DebuggerProxy(byte16 v)
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


        [FieldOffset(0)]  private fixed byte asArray[16];

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


        public static byte16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7, byte x8, byte x9, byte x10, byte x11, byte x12, byte x13, byte x14, byte x15)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi8((sbyte)x15, (sbyte)x14, (sbyte)x13, (sbyte)x12, (sbyte)x11, (sbyte)x10, (sbyte)x9, (sbyte)x8, (sbyte)x7, (sbyte)x6, (sbyte)x5, (sbyte)x4, (sbyte)x3, (sbyte)x2, (sbyte)x1, (sbyte)x0);
            }
            else
            {
                this.x0  = x0; 
                this.x1  = x1; 
                this.x2  = x2; 
                this.x3  = x3; 
                this.x4  = x4; 
                this.x5  = x5; 
                this.x6  = x6; 
                this.x7  = x7; 
                this.x8  = x8; 
                this.x9  = x9; 
                this.x10 = x10;
                this.x11 = x11;
                this.x12 = x12;
                this.x13 = x13;
                this.x14 = x14;
                this.x15 = x15;
            }
            }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte x0x16)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi8((sbyte)x0x16);
            }
            else
            {
                this.x0  = x0x16;
                this.x1  = x0x16;
                this.x2  = x0x16;
                this.x3  = x0x16;
                this.x4  = x0x16;
                this.x5  = x0x16;
                this.x6  = x0x16;
                this.x7  = x0x16;
                this.x8  = x0x16;
                this.x9  = x0x16;
                this.x10 = x0x16;
                this.x11 = x0x16;
                this.x12 = x0x16;
                this.x13 = x0x16;
                this.x14 = x0x16;
                this.x15 = x0x16;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte2 x01, byte2 x23, byte2 x45, byte2 x67, byte2 x89, byte2 x10_11, byte2 x12_13, byte2 x14_15)
        {
            this = new byte16(new byte8(x01, x23, x45, x67), new byte8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte4 x4567, byte4 x8_9_10_11, byte4 x12_13_14_15)
        {
            this = new byte16(new byte8(x0123, x4567), new byte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte3 x456, byte3 x789, byte3 x10_11_12, byte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _0_6   = Sse2.unpacklo_epi32(x0123, x456);
                v128 _7_9   = Sse2.bslli_si128(x789, 7 * sizeof(byte));
                v128 _10_12 = Sse2.bslli_si128(x10_11_12, 10 * sizeof(byte));
                v128 _13_15 = Sse2.bslli_si128(x13_14_15, 13 * sizeof(byte));

                v128 lo = Mask.BlendV(_0_6, _7_9,     new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                v128 hi = Mask.BlendV(_10_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(lo, hi, 0b1110_0000);
                }
                else
                {
                    this = Mask.BlendEpi16_SSE2(lo, hi, 0b1110_0000);
                }
            }
            else
            {
                this.x0  = x0123.x;
                this.x1  = x0123.y;
                this.x2  = x0123.z;
                this.x3  = x0123.w;
                this.x4  = x456.x;
                this.x5  = x456.y;
                this.x6  = x456.z;
                this.x7  = x789.x;
                this.x8  = x789.y;
                this.x9  = x789.z;
                this.x10 = x10_11_12.x;
                this.x11 = x10_11_12.y;
                this.x12 = x10_11_12.z;
                this.x13 = x13_14_15.x;
                this.x14 = x13_14_15.y;
                this.x15 = x13_14_15.z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte4 x3456, byte3 x789, byte3 x10_11_12, byte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _3_9   = Sse2.unpacklo_epi32(x3456, x789);
                _3_9        = Sse2.bslli_si128(_3_9, 3 * sizeof(byte));
                v128 _10_12 = Sse2.bslli_si128(x10_11_12, 10 * sizeof(byte));
                v128 _13_15 = Sse2.bslli_si128(x13_14_15, 13 * sizeof(byte));

                v128 lo = Mask.BlendV(x012, _3_9, new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                v128 hi = Mask.BlendV(_10_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(lo, hi, 0b1110_0000);
                }
                else
                {
                    this = Mask.BlendEpi16_SSE2(lo, hi, 0b1110_0000);
                }
            }
            else
            {
                this.x0  = x012.x;
                this.x1  = x012.y;
                this.x2  = x012.z;
                this.x3  = x3456.x;
                this.x4  = x3456.y;
                this.x5  = x3456.z;
                this.x6  = x3456.w;
                this.x7  = x789.x;
                this.x8  = x789.y;
                this.x9  = x789.z;
                this.x10 = x10_11_12.x;
                this.x11 = x10_11_12.y;
                this.x12 = x10_11_12.z;
                this.x13 = x13_14_15.x;
                this.x14 = x13_14_15.y;
                this.x15 = x13_14_15.z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte3 x345, byte4 x6789, byte3 x10_11_12, byte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _3_5   = Sse2.bslli_si128(x345, 3 * sizeof(byte));
                v128 _6_12  = Sse2.unpacklo_epi32(x6789, x10_11_12);
                _6_12       = Sse2.bslli_si128(_6_12, 6 * sizeof(byte));
                v128 _13_15 = Sse2.bslli_si128(x13_14_15, 13 * sizeof(byte));

                v128 lo = Mask.BlendV(x012, _3_5, new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 hi = Mask.BlendV(_6_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(lo, hi, 0b1111_1000);
                }
                else
                {
                    this = Mask.BlendEpi16_SSE2(lo, hi, 0b1111_1000);
                }
            }
            else
            {
                this.x0  = x012.x;
                this.x1  = x012.y;
                this.x2  = x012.z;
                this.x3  = x345.x;
                this.x4  = x345.y;
                this.x5  = x345.z;
                this.x6  = x6789.x;
                this.x7  = x6789.y;
                this.x8  = x6789.z;
                this.x9  = x6789.w;
                this.x10 = x10_11_12.x;
                this.x11 = x10_11_12.y;
                this.x12 = x10_11_12.z;
                this.x13 = x13_14_15.x;
                this.x14 = x13_14_15.y;
                this.x15 = x13_14_15.z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte3 x345, byte3 x678, byte4 x9_10_11_12, byte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _3_5  = Sse2.bslli_si128(x345, 3 * sizeof(byte));
                v128 _6_8  = Sse2.bslli_si128(x678, 6 * sizeof(byte));
                v128 _9_15 = Sse2.unpacklo_epi32(x9_10_11_12, x13_14_15);
                _9_15      = Sse2.bslli_si128(_9_15, 9 * sizeof(byte));

                v128 lo = Mask.BlendV(x012, _3_5,  new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 hi = Mask.BlendV(_6_8, _9_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));

                this = Mask.BlendV(lo, hi, new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
            }
            else
            {
                this.x0  = x012.x;
                this.x1  = x012.y;
                this.x2  = x012.z;
                this.x3  = x345.x;
                this.x4  = x345.y;
                this.x5  = x345.z;
                this.x6  = x678.x;
                this.x7  = x678.y;
                this.x8  = x678.z;
                this.x9  = x9_10_11_12.x;
                this.x10 = x9_10_11_12.y;
                this.x11 = x9_10_11_12.z;
                this.x12 = x9_10_11_12.w;
                this.x13 = x13_14_15.x;
                this.x14 = x13_14_15.y;
                this.x15 = x13_14_15.z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte3 x012, byte3 x345, byte3 x678, byte3 x9_10_11, byte4 x12_13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {               
                v128 _3_5   = Sse2.bslli_si128(x345, 3 * sizeof(byte));
                v128 _6_8   = Sse2.bslli_si128(x678, 6 * sizeof(byte));
                v128 _9_11  = Sse2.bslli_si128(x9_10_11, 9 * sizeof(byte));
                v128 _12_15 = Sse2.bslli_si128(x12_13_14_15, 12 * sizeof(byte));

                v128 lo  = Mask.BlendV(x012, _3_5,  new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 mid = Mask.BlendV(_6_8, _9_11, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0));
                lo       = Mask.BlendV(lo, mid,     new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0));

                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(lo, _12_15, 0b1100_0000);
                }
                else
                {
                    this = Mask.BlendEpi16_SSE2(lo, _12_15, 0b1100_0000);
                }
            }
            else
            {
                this.x0  = x012.x;
                this.x1  = x012.y;
                this.x2  = x012.z;
                this.x3  = x345.x;
                this.x4  = x345.y;
                this.x5  = x345.z;
                this.x6  = x678.x;
                this.x7  = x678.y;
                this.x8  = x678.z;
                this.x9  = x9_10_11.x;
                this.x10 = x9_10_11.y;
                this.x11 = x9_10_11.z;
                this.x12 = x12_13_14_15.x;
                this.x13 = x12_13_14_15.y;
                this.x14 = x12_13_14_15.z;
                this.x15 = x12_13_14_15.w;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte8 x01234567, byte4 x8_9_10_11, byte4 x12_13_14_15)
        {
            this = new byte16(x01234567, new byte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte8 x4_5_6_7_8_9_10_11, byte4 x12_13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new byte16((byte8)Sse2.unpacklo_epi32(x0123, x4_5_6_7_8_9_10_11),
                                  (byte8)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x4_5_6_7_8_9_10_11, 4 * sizeof(byte)), x12_13_14_15));
            }
            else
            {
                this.x0  = x0123.x;
                this.x1  = x0123.y;
                this.x2  = x0123.z;
                this.x3  = x0123.w;
                this.x4  = x4_5_6_7_8_9_10_11.x0;
                this.x5  = x4_5_6_7_8_9_10_11.x1;
                this.x6  = x4_5_6_7_8_9_10_11.x2;
                this.x7  = x4_5_6_7_8_9_10_11.x3;
                this.x8  = x4_5_6_7_8_9_10_11.x4;
                this.x9  = x4_5_6_7_8_9_10_11.x5;
                this.x10 = x4_5_6_7_8_9_10_11.x6;
                this.x11 = x4_5_6_7_8_9_10_11.x7;
                this.x12 = x12_13_14_15.x;
                this.x13 = x12_13_14_15.y;
                this.x14 = x12_13_14_15.z;
                this.x15 = x12_13_14_15.w;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte4 x0123, byte4 x4567, byte8 x8_9_10_11_12_13_14_15)
        {
            this = new byte16(new byte8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte16(byte8 x01234567, byte8 x8_9_10_11_12_13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.unpacklo_epi64(x01234567, x8_9_10_11_12_13_14_15);
            }
            else
            {
                this.x0  = x01234567.x0;
                this.x1  = x01234567.x1;
                this.x2  = x01234567.x2;
                this.x3  = x01234567.x3;
                this.x4  = x01234567.x4;
                this.x5  = x01234567.x5;
                this.x6  = x01234567.x6;
                this.x7  = x01234567.x7;
                this.x8  = x8_9_10_11_12_13_14_15.x0;
                this.x9  = x8_9_10_11_12_13_14_15.x1;
                this.x10 = x8_9_10_11_12_13_14_15.x2;
                this.x11 = x8_9_10_11_12_13_14_15.x3;
                this.x12 = x8_9_10_11_12_13_14_15.x4;
                this.x13 = x8_9_10_11_12_13_14_15.x5;
                this.x14 = x8_9_10_11_12_13_14_15.x6;
                this.x15 = x8_9_10_11_12_13_14_15.x7;
            }
        }


        #region Shuffle
        public byte8 v8_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new byte8(x0, x1, x2, x3, x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.insert_epi64(this, *(long*)&value, 0);
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte8(x1, x2, x3, x4, x5, x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte8(x2, x3, x4, x5, x6, x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), 0b0001_1110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), 0b0001_1110);
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
        public byte8 v8_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(byte));
                }
                else
                {
                    return new byte8(x3, x4, x5, x6, x7, x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte8(x4, x5, x6, x7, x8, x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(byte)), 0b0011_1100);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 4 * sizeof(byte)), 0b0011_1100);
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
        public byte8 v8_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(byte));
                }
                else
                {
                    return new byte8(x5, x6, x7, x8, x9, x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 6 * sizeof(byte));
                }
                else
                {
                    return new byte8(x6, x7, x8, x9, x10, x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 6 * sizeof(byte)), 0b0111_1000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 6 * sizeof(byte)), 0b0111_1000);
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
        public byte8 v8_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 7 * sizeof(byte));
                }
                else
                {
                    return new byte8(x7, x8, x9, x10, x11, x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0));
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
                    return Sse2.bsrli_si128(this, 8 * sizeof(byte));
                }
                else
                {
                    return new byte8(x8, x9, x10, x11, x12, x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.insert_epi64(this, *(long*)&value, 1);
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

        public byte4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new byte4(x0, x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.insert_epi32(this, *(int*)&value, 0);
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new v128(0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), 0b0000_0110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), 0b0000_0110);
                    }
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
                    return Sse2.bsrli_si128(this, 3 * sizeof(byte));
                }
                else
                {
                    return new byte4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.insert_epi32(this, *(int*)&value, 1);
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
                    return Sse2.bsrli_si128(this, 5 * sizeof(byte));
                }
                else
                {
                    return new byte4(x5, x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 6 * sizeof(byte));
                }
                else
                {
                    return new byte4(x6, x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 6 * sizeof(byte)), 0b0001_1000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 6 * sizeof(byte)), 0b0001_1000);
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
        public byte4 v4_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 7 * sizeof(byte));
                }
                else
                {
                    return new byte4(x7, x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 8 * sizeof(byte));
                }
                else
                {
                    return new byte4(x8, x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.insert_epi32(this, *(int*)&value, 2);
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
                    return Sse2.bsrli_si128(this, 9 * sizeof(byte));
                }
                else
                {
                    return new byte4(x9, x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 10 * sizeof(byte));
                }
                else
                {
                    return new byte4(x10, x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 10 * sizeof(byte)), 0b0110_0000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 10 * sizeof(byte)), 0b0110_0000);
                    }
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
                    return Sse2.bsrli_si128(this, 11 * sizeof(byte));
                }
                else
                {
                    return new byte4(x11, x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0));
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
                    return Sse2.bsrli_si128(this, 12 * sizeof(byte));
                }
                else
                {
                    return new byte4(x12, x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.insert_epi32(this, *(int*)&value, 3);
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

        public byte3 v3_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new byte3(x0, x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, value, new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new v128(0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), new v128(0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 3);
                }
                else
                {
                    return new byte3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 4 * sizeof(byte)), new v128(0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 5 * sizeof(byte));
                }
                else
                {
                    return new byte3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 6 * sizeof(byte));
                }
                else
                {
                    return new byte3(x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 6 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 7 * sizeof(byte));
                }
                else
                {
                    return new byte3(x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 8 * sizeof(byte));
                }
                else
                {
                    return new byte3(x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 8 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 9 * sizeof(byte));
                }
                else
                {
                    return new byte3(x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 10 * sizeof(byte));
                }
                else
                {
                    return new byte3(x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 10 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 11 * sizeof(byte));
                }
                else
                {
                    return new byte3(x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0));
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
                    return Sse2.bsrli_si128(this, 12 * sizeof(byte));
                }
                else
                {
                    return new byte3(x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 12 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0));
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
                    return Sse2.bsrli_si128(this, 13 * sizeof(byte));
                }
                else
                {
                    return new byte3(x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                }
                else
                {
                    this.x13 = value.x;
                    this.x14 = value.y;
                    this.x15 = value.z;
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
                    return (v128)this;
                }
                else
                {
                    return new byte2(x0, x1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 0);
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new v128(0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 1);
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
                    return Sse2.bsrli_si128(this, 3 * sizeof(byte));
                }
                else
                {
                    return new byte2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 2);
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
                    return Sse2.bsrli_si128(this, 5 * sizeof(byte));
                }
                else
                {
                    return new byte2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 6 * sizeof(byte));
                }
                else
                {
                    return new byte2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 3);
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
                    return Sse2.bsrli_si128(this, 7 * sizeof(byte));
                }
                else
                {
                    return new byte2(x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 8 * sizeof(byte));
                }
                else
                {
                    return new byte2(x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 4);
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
                    return Sse2.bsrli_si128(this, 9 * sizeof(byte));
                }
                else
                {
                    return new byte2(x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 10 * sizeof(byte));
                }
                else
                {
                    return new byte2(x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 5);
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
                    return Sse2.bsrli_si128(this, 11 * sizeof(byte));
                }
                else
                {
                    return new byte2(x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0));
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
                    return Sse2.bsrli_si128(this, 12 * sizeof(byte));
                }
                else
                {
                    return new byte2(x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 6);
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
                    return Sse2.bsrli_si128(this, 13 * sizeof(byte));
                }
                else
                {
                    return new byte2(x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0));
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
                    return Sse2.bsrli_si128(this, 14 * sizeof(byte));
                }
                else
                {
                    return new byte2(x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 7);
                }
                else
                {
                    this.x14 = value.x;
                    this.x15 = value.y;
                }
            }
        }
        #endregion 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse.load_ps(void* ptr)
        public static implicit operator v128(byte16 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7, input.x8, input.x9, input.x10, input.x11, input.x12, input.x13, input.x14, input.x15);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator byte16(v128 input) => new byte16 { x0 = input.Byte0, x1 = input.Byte1, x2 = input.Byte2, x3 = input.Byte3, x4 = input.Byte4, x5 = input.Byte5, x6 = input.Byte6, x7 = input.Byte7, x8 = input.Byte8, x9 = input.Byte9, x10 = input.Byte10, x11 = input.Byte11, x12 = input.Byte12, x13 = input.Byte13, x14 = input.Byte14, x15 = input.Byte15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte16(byte input) => new byte16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(sbyte16 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte16*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(short16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new byte16((byte8)input.v8_0, (byte8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte16(ushort16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new byte16((byte8)input.v8_0, (byte8)input.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(byte16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi16(input);
            }
            else
            {
                return new short16((short8)input.v8_0, (short8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort16(byte16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi16(input);
            }
            else
            {
                return new ushort16((ushort8)input.v8_0, (ushort8)input.v8_8);
            }
        }


        public byte this[int index]
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
        public static byte16 operator + (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 + right.x0), (byte)(left.x1 + right.x1), (byte)(left.x2 + right.x2), (byte)(left.x3 + right.x3), (byte)(left.x4 + right.x4), (byte)(left.x5 + right.x5), (byte)(left.x6 + right.x6), (byte)(left.x7 + right.x7), (byte)(left.x8 + right.x8), (byte)(left.x9 + right.x9), (byte)(left.x10 + right.x10), (byte)(left.x11 + right.x11), (byte)(left.x12 + right.x12), (byte)(left.x13 + right.x13), (byte)(left.x14 + right.x14), (byte)(left.x15 + right.x15));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator - (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 - right.x0), (byte)(left.x1 - right.x1), (byte)(left.x2 - right.x2), (byte)(left.x3 - right.x3), (byte)(left.x4 - right.x4), (byte)(left.x5 - right.x5), (byte)(left.x6 - right.x6), (byte)(left.x7 - right.x7), (byte)(left.x8 - right.x8), (byte)(left.x9 - right.x9), (byte)(left.x10 - right.x10), (byte)(left.x11 - right.x11), (byte)(left.x12 - right.x12), (byte)(left.x13 - right.x13), (byte)(left.x14 - right.x14), (byte)(left.x15 - right.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator * (byte16 left, byte16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (byte16)((short16)left * (short16)right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Operator.mul_byte(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 * right.x0), (byte)(left.x1 * right.x1), (byte)(left.x2 * right.x2), (byte)(left.x3 * right.x3), (byte)(left.x4 * right.x4), (byte)(left.x5 * right.x5), (byte)(left.x6 * right.x6), (byte)(left.x7 * right.x7), (byte)(left.x8 * right.x8), (byte)(left.x9 * right.x9), (byte)(left.x10 * right.x10), (byte)(left.x11 * right.x11), (byte)(left.x12 * right.x12), (byte)(left.x13 * right.x13), (byte)(left.x14 * right.x14), (byte)(left.x15 * right.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator / (byte16 left, byte16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdiv_byte(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_byte_SSE_FALLBACK(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 / right.x0), (byte)(left.x1 / right.x1), (byte)(left.x2 / right.x2), (byte)(left.x3 / right.x3), (byte)(left.x4 / right.x4), (byte)(left.x5 / right.x5), (byte)(left.x6 / right.x6), (byte)(left.x7 / right.x7), (byte)(left.x8 / right.x8), (byte)(left.x9 / right.x9), (byte)(left.x10 / right.x10), (byte)(left.x11 / right.x11), (byte)(left.x12 / right.x12), (byte)(left.x13 / right.x13), (byte)(left.x14 / right.x14), (byte)(left.x15 / right.x15));
            }
        }
                                                                       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]             
        public static byte16 operator % (byte16 left, byte16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vrem_byte(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_byte_SSE_FALLBACK(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 % right.x0), (byte)(left.x1 % right.x1), (byte)(left.x2 % right.x2), (byte)(left.x3 % right.x3), (byte)(left.x4 % right.x4), (byte)(left.x5 % right.x5), (byte)(left.x6 % right.x6), (byte)(left.x7 % right.x7), (byte)(left.x8 % right.x8), (byte)(left.x9 % right.x9), (byte)(left.x10 % right.x10), (byte)(left.x11 % right.x11), (byte)(left.x12 % right.x12), (byte)(left.x13 % right.x13), (byte)(left.x14 % right.x14), (byte)(left.x15 % right.x15));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator * (byte left, byte16 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator * (byte16 left, byte right)
        {
            if (Constant.IsConstantExpression(right))
            {
                return new byte16((byte)(left.x0 * right), (byte)(left.x1 * right), (byte)(left.x2 * right), (byte)(left.x3 * right), (byte)(left.x4 * right), (byte)(left.x5 * right), (byte)(left.x6 * right), (byte)(left.x7 * right), (byte)(left.x8 * right), (byte)(left.x9 * right), (byte)(left.x10 * right), (byte)(left.x11 * right), (byte)(left.x12 * right), (byte)(left.x13 * right), (byte)(left.x14 * right), (byte)(left.x15 * right));
            }
            else
            {
                return left * (byte16)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator / (byte16 left, byte right)
        {
            if (Constant.IsConstantExpression(right))
            {
                return new byte16((byte)(left.x0 / right), (byte)(left.x1 / right), (byte)(left.x2 / right), (byte)(left.x3 / right), (byte)(left.x4 / right), (byte)(left.x5 / right), (byte)(left.x6 / right), (byte)(left.x7 / right), (byte)(left.x8 / right), (byte)(left.x9 / right), (byte)(left.x10 / right), (byte)(left.x11 / right), (byte)(left.x12 / right), (byte)(left.x13 / right), (byte)(left.x14 / right), (byte)(left.x15 / right));
            }
            else
            {
                return left / (byte16)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator % (byte16 left, byte right)
        {
            if (Constant.IsConstantExpression(right))
            {
                return new byte16((byte)(left.x0 % right), (byte)(left.x1 % right), (byte)(left.x2 % right), (byte)(left.x3 % right), (byte)(left.x4 % right), (byte)(left.x5 % right), (byte)(left.x6 % right), (byte)(left.x7 % right), (byte)(left.x8 % right), (byte)(left.x9 % right), (byte)(left.x10 % right), (byte)(left.x11 % right), (byte)(left.x12 % right), (byte)(left.x13 % right), (byte)(left.x14 % right), (byte)(left.x15 % right));
            }
            else
            {
                return left % (byte16)right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator & (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 & right.x0), (byte)(left.x1 & right.x1), (byte)(left.x2 & right.x2), (byte)(left.x3 & right.x3), (byte)(left.x4 & right.x4), (byte)(left.x5 & right.x5), (byte)(left.x6 & right.x6), (byte)(left.x7 & right.x7), (byte)(left.x8 & right.x8), (byte)(left.x9 & right.x9), (byte)(left.x10 & right.x10), (byte)(left.x11 & right.x11), (byte)(left.x12 & right.x12), (byte)(left.x13 & right.x13), (byte)(left.x14 & right.x14), (byte)(left.x15 & right.x15));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator | (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 | right.x0), (byte)(left.x1 | right.x1), (byte)(left.x2 | right.x2), (byte)(left.x3 | right.x3), (byte)(left.x4 | right.x4), (byte)(left.x5 | right.x5), (byte)(left.x6 | right.x6), (byte)(left.x7 | right.x7), (byte)(left.x8 | right.x8), (byte)(left.x9 | right.x9), (byte)(left.x10 | right.x10), (byte)(left.x11 | right.x11), (byte)(left.x12 | right.x12), (byte)(left.x13 | right.x13), (byte)(left.x14 | right.x14), (byte)(left.x15 | right.x15));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator ^ (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte16((byte)(left.x0 ^ right.x0), (byte)(left.x1 ^ right.x1), (byte)(left.x2 ^ right.x2), (byte)(left.x3 ^ right.x3), (byte)(left.x4 ^ right.x4), (byte)(left.x5 ^ right.x5), (byte)(left.x6 ^ right.x6), (byte)(left.x7 ^ right.x7), (byte)(left.x8 ^ right.x8), (byte)(left.x9 ^ right.x9), (byte)(left.x10 ^ right.x10), (byte)(left.x11 ^ right.x11), (byte)(left.x12 ^ right.x12), (byte)(left.x13 ^ right.x13), (byte)(left.x14 ^ right.x14), (byte)(left.x15 ^ right.x15));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator ++ (byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new byte16((byte)(x.x0 + 1), (byte)(x.x1 + 1), (byte)(x.x2 + 1), (byte)(x.x3 + 1), (byte)(x.x4 + 1), (byte)(x.x5 + 1), (byte)(x.x6 + 1), (byte)(x.x7 + 1), (byte)(x.x8 + 1), (byte)(x.x9 + 1), (byte)(x.x10 + 1), (byte)(x.x11 + 1), (byte)(x.x12 + 1), (byte)(x.x13 + 1), (byte)(x.x14 + 1), (byte)(x.x15 + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator -- (byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new byte16((byte)(x.x0 - 1), (byte)(x.x1 - 1), (byte)(x.x2 - 1), (byte)(x.x3 - 1), (byte)(x.x4 - 1), (byte)(x.x5 - 1), (byte)(x.x6 - 1), (byte)(x.x7 - 1), (byte)(x.x8 - 1), (byte)(x.x9 - 1), (byte)(x.x10 - 1), (byte)(x.x11 - 1), (byte)(x.x12 - 1), (byte)(x.x13 - 1), (byte)(x.x14 - 1), (byte)(x.x15 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator ~ (byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new byte16((byte)(~x.x0), (byte)(~x.x1), (byte)(~x.x2), (byte)(~x.x3), (byte)(~x.x4), (byte)(~x.x5), (byte)(~x.x6), (byte)(~x.x7), (byte)(~x.x8), (byte)(~x.x9), (byte)(~x.x10), (byte)(~x.x11), (byte)(~x.x12), (byte)(~x.x13), (byte)(~x.x14), (byte)(~x.x15));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator << (byte16 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new byte16((byte)(x.x0 << n), (byte)(x.x1 << n), (byte)(x.x2 << n), (byte)(x.x3 << n), (byte)(x.x4 << n), (byte)(x.x5 << n), (byte)(x.x6 << n), (byte)(x.x7 << n), (byte)(x.x8 << n), (byte)(x.x9 << n), (byte)(x.x10 << n), (byte)(x.x11 << n), (byte)(x.x12 << n), (byte)(x.x13 << n), (byte)(x.x14 << n), (byte)(x.x15 << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 operator >> (byte16 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_byte(x, n);
            }
            else
            {
                return new byte16((byte)(x.x0 >> n), (byte)(x.x1 >> n), (byte)(x.x2 >> n), (byte)(x.x3 >> n), (byte)(x.x4 >> n), (byte)(x.x5 >> n), (byte)(x.x6 >> n), (byte)(x.x7 >> n), (byte)(x.x8 >> n), (byte)(x.x9 >> n), (byte)(x.x10 >> n), (byte)(x.x11 >> n), (byte)(x.x12 >> n), (byte)(x.x13 >> n), (byte)(x.x14 >> n), (byte)(x.x15 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7, left.x8 == right.x8, left.x9 == right.x9, left.x10 == right.x10, left.x11 == right.x11, left.x12 == right.x12, left.x13 == right.x13, left.x14 == right.x14, left.x15 == right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(right, left));
            }
            else
            {
                return new bool16(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7, left.x8 < right.x8, left.x9 < right.x9, left.x10 < right.x10, left.x11 < right.x11, left.x12 < right.x12, left.x13 < right.x13, left.x14 < right.x14, left.x15 < right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(left, right));
            }
            else
            {
                return new bool16(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7, left.x8 > right.x8, left.x9 > right.x9, left.x10 > right.x10, left.x11 > right.x11, left.x12 > right.x12, left.x13 > right.x13, left.x14 > right.x14, left.x15 > right.x15);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7, left.x8 != right.x8, left.x9 != right.x9, left.x10 != right.x10, left.x11 != right.x11, left.x12 != right.x12, left.x13 != right.x13, left.x14 != right.x14, left.x15 != right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.min_epu8(left, right), left));
            }
            else
            {
                return new bool16(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7, left.x8 <= right.x8, left.x9 <= right.x9, left.x10 <= right.x10, left.x11 <= right.x11, left.x12 <= right.x12, left.x13 <= right.x13, left.x14 <= right.x14, left.x15 <= right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.max_epu8(left, right), left));
            }
            else
            {
                return new bool16(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7, left.x8 >= right.x8, left.x9 >= right.x9, left.x10 >= right.x10, left.x11 >= right.x11, left.x12 >= right.x12, left.x13 >= right.x13, left.x14 >= right.x14, left.x15 >= right.x15);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool16 TestIsTrue(v128 input)
        {
            return (v128)(-((sbyte16)input));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool16 TestIsFalse(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(input, new v128(0x0101_0101));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte16 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.bitmask32(16 * sizeof(byte)) == Sse2.movemask_epi8(Sse2.cmpeq_epi8(this, other));
            }
            else
            {
                return (((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7))) & (((this.x8 == other.x8 & this.x9 == other.x9) & (this.x10 == other.x10 & this.x11 == other.x11)) & ((this.x12 == other.x12 & this.x13 == other.x13) & (this.x14 == other.x14 & this.x15 == other.x15)));
            }
        }

        public override bool Equals(object obj) => Equals((byte16)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v128(this);
            }
            else
            {
                byte16 temp = this;

                return (*(ulong*)&temp ^ *((ulong*)&temp + 1)).GetHashCode();
            }
        }


        public override string ToString() =>  $"byte16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}