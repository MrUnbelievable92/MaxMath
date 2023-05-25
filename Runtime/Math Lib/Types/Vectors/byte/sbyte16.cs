using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Explicit, Size = 16 * sizeof(sbyte))] 
    [DebuggerTypeProxy(typeof(sbyte16.DebuggerProxy))]
    unsafe public struct sbyte16 : IEquatable<sbyte16>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public sbyte x0;
            public sbyte x1;
            public sbyte x2;
            public sbyte x3;
            public sbyte x4;
            public sbyte x5;
            public sbyte x6;
            public sbyte x7;
            public sbyte x8;
            public sbyte x9;
            public sbyte x10;
            public sbyte x11;
            public sbyte x12;
            public sbyte x13;
            public sbyte x14;
            public sbyte x15;

            public DebuggerProxy(sbyte16 v)
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


        [FieldOffset(0)]  public sbyte x0;
        [FieldOffset(1)]  public sbyte x1;
        [FieldOffset(2)]  public sbyte x2;
        [FieldOffset(3)]  public sbyte x3;
        [FieldOffset(4)]  public sbyte x4;
        [FieldOffset(5)]  public sbyte x5;
        [FieldOffset(6)]  public sbyte x6;
        [FieldOffset(7)]  public sbyte x7;
        [FieldOffset(8)]  public sbyte x8;
        [FieldOffset(9)]  public sbyte x9;
        [FieldOffset(10)] public sbyte x10;
        [FieldOffset(11)] public sbyte x11;
        [FieldOffset(12)] public sbyte x12;
        [FieldOffset(13)] public sbyte x13;
        [FieldOffset(14)] public sbyte x14;
        [FieldOffset(15)] public sbyte x15;


        public static sbyte16 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte x0, sbyte x1, sbyte x2, sbyte x3, sbyte x4, sbyte x5, sbyte x6, sbyte x7, sbyte x8, sbyte x9, sbyte x10, sbyte x11, sbyte x12, sbyte x13, sbyte x14, sbyte x15)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi8(x15, x14, x13, x12, x11, x10, x9, x8, x7, x6, x5, x4, x3, x2, x1, x0);
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
        public sbyte16(sbyte x0x16)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi8(x0x16);
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
        public sbyte16(sbyte2 x01, sbyte2 x23, sbyte2 x45, sbyte2 x67, sbyte2 x89, sbyte2 x10_11, sbyte2 x12_13, sbyte2 x14_15)
        {
            this = new sbyte16(new sbyte8(x01, x23, x45, x67), new sbyte8(x89, x10_11, x12_13, x14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x0123, x4567), new sbyte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte3 x456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _0_6   = Sse2.unpacklo_epi32(x0123, x456);
                v128 _7_9   = Sse2.bslli_si128(x789, 7 * sizeof(sbyte));
                v128 _10_12 = Sse2.bslli_si128(x10_11_12, 10 * sizeof(sbyte));
                v128 _13_15 = Sse2.bslli_si128(x13_14_15, 13 * sizeof(sbyte));

                v128 lo = Xse.blendv_si128(_0_6, _7_9,     new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                v128 hi = Xse.blendv_si128(_10_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                this = Xse.blend_epi16(lo, hi, 0b1110_0000);
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
        public sbyte16(sbyte3 x012, sbyte4 x3456, sbyte3 x789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _3_9   = Sse2.unpacklo_epi32(x3456, x789);
                _3_9        = Sse2.bslli_si128(_3_9, 3 * sizeof(sbyte));
                v128 _10_12 = Sse2.bslli_si128(x10_11_12, 10 * sizeof(sbyte));
                v128 _13_15 = Sse2.bslli_si128(x13_14_15, 13 * sizeof(sbyte));

                v128 lo = Xse.blendv_si128(x012, _3_9, new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                v128 hi = Xse.blendv_si128(_10_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                this = Xse.blend_epi16(lo, hi, 0b1110_0000);
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
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte4 x6789, sbyte3 x10_11_12, sbyte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _3_5   = Sse2.bslli_si128(x345, 3 * sizeof(sbyte));
                v128 _6_12  = Sse2.unpacklo_epi32(x6789, x10_11_12);
                _6_12       = Sse2.bslli_si128(_6_12, 6 * sizeof(sbyte));
                v128 _13_15 = Sse2.bslli_si128(x13_14_15, 13 * sizeof(sbyte));

                v128 lo = Xse.blendv_si128(x012, _3_5, new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 hi = Xse.blendv_si128(_6_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                this = Xse.blend_epi16(lo, hi, 0b1111_1000);
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
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte4 x9_10_11_12, sbyte3 x13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 _3_5  = Sse2.bslli_si128(x345, 3 * sizeof(sbyte));
                v128 _6_8  = Sse2.bslli_si128(x678, 6 * sizeof(sbyte));
                v128 _9_15 = Sse2.unpacklo_epi32(x9_10_11_12, x13_14_15);
                _9_15      = Sse2.bslli_si128(_9_15, 9 * sizeof(sbyte));

                v128 lo = Xse.blendv_si128(x012, _3_5,  new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 hi = Xse.blendv_si128(_6_8, _9_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));

                this = Xse.blendv_si128(lo, hi, new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
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
        public sbyte16(sbyte3 x012, sbyte3 x345, sbyte3 x678, sbyte3 x9_10_11, sbyte4 x12_13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {               
                v128 _3_5   = Sse2.bslli_si128(x345, 3 * sizeof(sbyte));
                v128 _6_8   = Sse2.bslli_si128(x678, 6 * sizeof(sbyte));
                v128 _9_11  = Sse2.bslli_si128(x9_10_11, 9 * sizeof(sbyte));
                v128 _12_15 = Sse2.bslli_si128(x12_13_14_15, 12 * sizeof(sbyte));

                v128 lo  = Xse.blendv_si128(x012, _3_5,  new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 mid = Xse.blendv_si128(_6_8, _9_11, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0));
                lo       = Xse.blendv_si128(lo, mid,     new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0));

                this = Xse.blend_epi16(lo, _12_15, 0b1100_0000);
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
        public sbyte16(sbyte8 x01234567, sbyte4 x8_9_10_11, sbyte4 x12_13_14_15)
        {
            this = new sbyte16(x01234567, new sbyte8(x8_9_10_11, x12_13_14_15));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte4 x0123, sbyte8 x4_5_6_7_8_9_10_11, sbyte4 x12_13_14_15)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new sbyte16((sbyte8)Sse2.unpacklo_epi32(x0123, x4_5_6_7_8_9_10_11),
                                  (sbyte8)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x4_5_6_7_8_9_10_11, 4 * sizeof(sbyte)), x12_13_14_15));
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
        public sbyte16(sbyte4 x0123, sbyte4 x4567, sbyte8 x8_9_10_11_12_13_14_15)
        {
            this = new sbyte16(new sbyte8(x0123, x4567), x8_9_10_11_12_13_14_15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte16(sbyte8 x01234567, sbyte8 x8_9_10_11_12_13_14_15)
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
        public sbyte8 v8_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new sbyte8(x0, x1, x2, x3, x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, value, 0b0000_1111);
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
        public sbyte8 v8_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x1, x2, x3, x4, x5, x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 1 * sizeof(sbyte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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
        public sbyte8 v8_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x2, x3, x4, x5, x6, x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(sbyte)), 0b0001_1110);
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
        public sbyte8 v8_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x3, x4, x5, x6, x7, x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 3 * sizeof(sbyte)), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0));
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
        public sbyte8 v8_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x4, x5, x6, x7, x8, x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(sbyte)), 0b0011_1100);
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
        public sbyte8 v8_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x5, x6, x7, x8, x9, x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 5 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0));
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
        public sbyte8 v8_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 6 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x6, x7, x8, x9, x10, x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 6 * sizeof(sbyte)), 0b0111_1000);
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
        public sbyte8 v8_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 7 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x7, x8, x9, x10, x11, x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 7 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0));
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
        public sbyte8 v8_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 8 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte8(x8, x9, x10, x11, x12, x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 8 * sizeof(sbyte)), 0b1111_0000);
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

        public sbyte4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new sbyte4(x0, x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, value, 0b0000_0011);
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
        public sbyte4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 1 * sizeof(sbyte)), new v128(0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
        public sbyte4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(sbyte)), 0b0000_0110);
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
        public sbyte4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 3 * sizeof(sbyte)), new v128(0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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
        public sbyte4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(sbyte)), 0b0000_1100);
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
        public sbyte4 v4_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x5, x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 5 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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
        public sbyte4 v4_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 6 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x6, x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 6 * sizeof(sbyte)), 0b0001_1000);
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
        public sbyte4 v4_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 7 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x7, x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 7 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0));
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
        public sbyte4 v4_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 8 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x8, x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 8 * sizeof(sbyte)), 0b0011_0000);
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
        public sbyte4 v4_9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 9 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x9, x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 9 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0));
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
        public sbyte4 v4_10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 10 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x10, x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 10 * sizeof(sbyte)), 0b0110_0000);
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
        public sbyte4 v4_11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 11 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x11, x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 11 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0));
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
        public sbyte4 v4_12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 12 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte4(x12, x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 12 * sizeof(sbyte)), 0b1100_0000);
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

        public sbyte3 v3_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new sbyte3(x0, x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, value, new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x0  = value.x;
                    this.x1  = value.y;
                    this.x2  = value.z;
                }
            }
        }
        public sbyte3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 1 * sizeof(sbyte)), new v128(0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x1  = value.x;
                    this.x2  = value.y;
                    this.x3  = value.z;
                }
            }
        }
        public sbyte3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 2 * sizeof(sbyte)), new v128(0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x2  = value.x;
                    this.x3  = value.y;
                    this.x4  = value.z;
                }
            }
        }
        public sbyte3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3);
                }
                else
                {
                    return new sbyte3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 3 * sizeof(sbyte)), new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x3  = value.x;
                    this.x4  = value.y;
                    this.x5  = value.z;
                }
            }
        }
        public sbyte3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 4 * sizeof(sbyte)), new v128(0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x4  = value.x;
                    this.x5  = value.y;
                    this.x6  = value.z;
                }
            }
        }
        public sbyte3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 5 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x5  = value.x;
                    this.x6  = value.y;
                    this.x7  = value.z;
                }
            }
        }
        public sbyte3 v3_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 6 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x6, x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 6 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x6  = value.x;
                    this.x7  = value.y;
                    this.x8  = value.z;
                }
            }
        }
        public sbyte3 v3_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 7 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x7, x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 7 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                    this.x9  = value.z;
                }
            }
        }
        public sbyte3 v3_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 8 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x8, x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 8 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x8  = value.x;
                    this.x9  = value.y;
                    this.x10 = value.z;
                }
            }
        }
        public sbyte3 v3_9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 9 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x9, x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 9 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0));
                }
                else
                {
                    this.x9  = value.x;
                    this.x10 = value.y;
                    this.x11 = value.z;
                }
            }
        }
        public sbyte3 v3_10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 10 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x10, x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 10 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0));
                }
                else
                {
                    this.x10 = value.x;
                    this.x11 = value.y;
                    this.x12 = value.z;
                }
            }
        }
        public sbyte3 v3_11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 11 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x11, x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 11 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0));
                }
                else
                {
                    this.x11 = value.x;
                    this.x12 = value.y;
                    this.x13 = value.z;
                }
            }
        }
        public sbyte3 v3_12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 12 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x12, x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 12 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0));
                }
                else
                {
                    this.x12 = value.x;
                    this.x13 = value.y;
                    this.x14 = value.z;
                }
            }
        }
        public sbyte3 v3_13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 13 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte3(x13, x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 13 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                }
                else
                {
                    this.x13 = value.x;
                    this.x14 = value.y;
                    this.x15 = value.z;
                }
            }
        }

        public sbyte2 v2_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new sbyte2(x0, x1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 0);
                }
                else
                {
                    this.x0  = value.x;
                    this.x1  = value.y;
                }
            }
        }
        public sbyte2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 1 * sizeof(sbyte)), new v128(0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x1  = value.x;
                    this.x2  = value.y;
                }
            }
        }
        public sbyte2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 1);
                }
                else
                {
                    this.x2  = value.x;
                    this.x3  = value.y;
                }
            }
        }
        public sbyte2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 3 * sizeof(sbyte)), new v128(0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x3  = value.x;
                    this.x4  = value.y;
                }
            }
        }
        public sbyte2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 2);
                }
                else
                {
                    this.x4  = value.x;
                    this.x5  = value.y;
                }
            }
        }
        public sbyte2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 5 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x5  = value.x;
                    this.x6  = value.y;
                }
            }
        }
        public sbyte2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 6 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 3);
                }
                else
                {
                    this.x6  = value.x;
                    this.x7  = value.y;
                }
            }
        }
        public sbyte2 v2_7
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 7 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x7, x8);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 7 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x7  = value.x;
                    this.x8  = value.y;
                }
            }
        }
        public sbyte2 v2_8
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 8 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x8, x9);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 4);
                }
                else
                {
                    this.x8  = value.x;
                    this.x9  = value.y;
                }
            }
        }
        public sbyte2 v2_9
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 9 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x9, x10);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 9 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x9  = value.x;
                    this.x10 = value.y;
                }
            }
        }
        public sbyte2 v2_10
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 10 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x10, x11);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 5);
                }
                else
                {
                    this.x10 = value.x;
                    this.x11 = value.y;
                }
            }
        }
        public sbyte2 v2_11
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 11 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x11, x12);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 11 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0));
                }
                else
                {
                    this.x11 = value.x;
                    this.x12 = value.y;
                }
            }
        }
        public sbyte2 v2_12
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 12 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x12, x13);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 6);
                }
                else
                {
                    this.x12 = value.x;
                    this.x13 = value.y;
                }
            }
        }
        public sbyte2 v2_13
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 13 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x13, x14);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blendv_si128(this, Sse2.bslli_si128(value, 13 * sizeof(sbyte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0));
                }
                else
                {
                    this.x13 = value.x;
                    this.x14 = value.y;
                }
            }
        }
        public sbyte2 v2_14
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 14 * sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(x14, x15);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 7);
                }
                else
                {
                    this.x14 = value.x;
                    this.x15 = value.y;
                }
            }
        }
        #endregion 

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte16 input) => new v128{ SByte0 = input.x0, SByte1 = input.x1, SByte2 = input.x2, SByte3 = input.x3, SByte4 = input.x4, SByte5 = input.x5, SByte6 = input.x6, SByte7 = input.x7, SByte8 = input.x8, SByte9 = input.x9, SByte10 = input.x10, SByte11 = input.x11, SByte12 = input.x12, SByte13 = input.x13, SByte14 = input.x14, SByte15 = input.x15 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte16(v128 input) => new sbyte16{ x0 = input.SByte0, x1 = input.SByte1, x2 = input.SByte2, x3 = input.SByte3, x4 = input.SByte4, x5 = input.SByte5, x6 = input.SByte6, x7 = input.SByte7, x8 = input.SByte8, x9 = input.SByte9, x10 = input.SByte10, x11 = input.SByte11, x12 = input.SByte12, x13 = input.SByte13, x14 = input.SByte14, x15 = input.SByte15 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte16(sbyte input) => new sbyte16(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(byte16 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(sbyte16*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(short16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi16_epi8(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Short16To_S_Byte16_SSE2(input._v8_0, input._v8_8);
            }
            else
            {
                return new sbyte16((sbyte8)input.v8_0, (sbyte8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte16(ushort16 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi16_epi8(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Short16To_S_Byte16_SSE2(input._v8_0, input._v8_8);
            }
            else
            {
                return new sbyte16((sbyte8)input.v8_0, (sbyte8)input.v8_8);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short16(sbyte16 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.SByte16ToShort16(input);
            }
            else
            {
                return new short16((short8)input.v8_0, (short8)input.v8_8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort16(sbyte16 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (ushort16)Cast.SByte16ToShort16(input);
            }
            else
            {
                return new ushort16((ushort8)input.v8_0, (ushort8)input.v8_8);
            }
        }


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 16);

                if (Sse2.IsSse2Supported)
                {
                    return (sbyte)Xse.extract_epi8(this, (byte)index);
                }
                else
                {
                    sbyte16 onStack = this;

                    return *((sbyte*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 16);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi8(this, (byte)value, (byte)index);
                }
                else
                {
                    sbyte16 onStack = this;
                    *((sbyte*)&onStack + index) = value;

                    this = onStack;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator + (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 + right.x0), (sbyte)(left.x1 + right.x1), (sbyte)(left.x2 + right.x2), (sbyte)(left.x3 + right.x3), (sbyte)(left.x4 + right.x4), (sbyte)(left.x5 + right.x5), (sbyte)(left.x6 + right.x6), (sbyte)(left.x7 + right.x7), (sbyte)(left.x8 + right.x8), (sbyte)(left.x9 + right.x9), (sbyte)(left.x10 + right.x10), (sbyte)(left.x11 + right.x11), (sbyte)(left.x12 + right.x12), (sbyte)(left.x13 + right.x13), (sbyte)(left.x14 + right.x14), (sbyte)(left.x15 + right.x15));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator - (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 - right.x0), (sbyte)(left.x1 - right.x1), (sbyte)(left.x2 - right.x2), (sbyte)(left.x3 - right.x3), (sbyte)(left.x4 - right.x4), (sbyte)(left.x5 - right.x5), (sbyte)(left.x6 - right.x6), (sbyte)(left.x7 - right.x7), (sbyte)(left.x8 - right.x8), (sbyte)(left.x9 - right.x9), (sbyte)(left.x10 - right.x10), (sbyte)(left.x11 - right.x11), (sbyte)(left.x12 - right.x12), (sbyte)(left.x13 - right.x13), (sbyte)(left.x14 - right.x14), (sbyte)(left.x15 - right.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    bool sameValue = maxmath.all_eq(right);

                    if (sameValue)
                    {
                        return left * right.x0;
                    }
                    if (Avx2.IsAvx2Supported)
                    {
                        if (!sameValue && maxmath.all(maxmath.ispow2(right)))
                        {
                            return maxmath.shl(left, maxmath.tzcnt(right));
                        }
                    }
                }
                if (Constant.IsConstantExpression(left))
                {
                    bool sameValue = maxmath.all_eq(left);

                    if (sameValue)
                    {
                        return right * left.x0;
                    }
                    if (Avx2.IsAvx2Supported)
                    {
                        if (!sameValue && maxmath.all(maxmath.ispow2(left)))
                        {
                            return maxmath.shl(right, maxmath.tzcnt(left));
                        }
                    }
                }
                
                return Xse.mullo_epi8(left, right, 16);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 * right.x0), (sbyte)(left.x1 * right.x1), (sbyte)(left.x2 * right.x2), (sbyte)(left.x3 * right.x3), (sbyte)(left.x4 * right.x4), (sbyte)(left.x5 * right.x5), (sbyte)(left.x6 * right.x6), (sbyte)(left.x7 * right.x7), (sbyte)(left.x8 * right.x8), (sbyte)(left.x9 * right.x9), (sbyte)(left.x10 * right.x10), (sbyte)(left.x11 * right.x11), (sbyte)(left.x12 * right.x12), (sbyte)(left.x13 * right.x13), (sbyte)(left.x14 * right.x14), (sbyte)(left.x15 * right.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator / (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epi8(left, right, false, 16);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 / right.x0), (sbyte)(left.x1 / right.x1), (sbyte)(left.x2 / right.x2), (sbyte)(left.x3 / right.x3), (sbyte)(left.x4 / right.x4), (sbyte)(left.x5 / right.x5), (sbyte)(left.x6 / right.x6), (sbyte)(left.x7 / right.x7), (sbyte)(left.x8 / right.x8), (sbyte)(left.x9 / right.x9), (sbyte)(left.x10 / right.x10), (sbyte)(left.x11 / right.x11), (sbyte)(left.x12 / right.x12), (sbyte)(left.x13 / right.x13), (sbyte)(left.x14 / right.x14), (sbyte)(left.x15 / right.x15));
            }
        }
                                                                       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]             
        public static sbyte16 operator % (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epi8(left, right, 16);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 % right.x0), (sbyte)(left.x1 % right.x1), (sbyte)(left.x2 % right.x2), (sbyte)(left.x3 % right.x3), (sbyte)(left.x4 % right.x4), (sbyte)(left.x5 % right.x5), (sbyte)(left.x6 % right.x6), (sbyte)(left.x7 % right.x7), (sbyte)(left.x8 % right.x8), (sbyte)(left.x9 % right.x9), (sbyte)(left.x10 % right.x10), (sbyte)(left.x11 % right.x11), (sbyte)(left.x12 % right.x12), (sbyte)(left.x13 % right.x13), (sbyte)(left.x14 % right.x14), (sbyte)(left.x15 % right.x15));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte left, sbyte16 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator * (sbyte16 left, sbyte right)
        {
            if (Constant.IsConstantExpression(right))
            {
                return new sbyte16((sbyte)(left.x0 * right), (sbyte)(left.x1 * right), (sbyte)(left.x2 * right), (sbyte)(left.x3 * right), (sbyte)(left.x4 * right), (sbyte)(left.x5 * right), (sbyte)(left.x6 * right), (sbyte)(left.x7 * right), (sbyte)(left.x8 * right), (sbyte)(left.x9 * right), (sbyte)(left.x10 * right), (sbyte)(left.x11 * right), (sbyte)(left.x12 * right), (sbyte)(left.x13 * right), (sbyte)(left.x14 * right), (sbyte)(left.x15 * right));
            }
            else
            {
                return left * (sbyte16)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator / (sbyte16 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epi8(left, right, 16);
                }
            }
                
            return left / (sbyte16)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator % (sbyte16 left, sbyte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epi8(left, right, 16);
                }
            }
                
            return left % (sbyte16)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator & (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 & right.x0), (sbyte)(left.x1 & right.x1), (sbyte)(left.x2 & right.x2), (sbyte)(left.x3 & right.x3), (sbyte)(left.x4 & right.x4), (sbyte)(left.x5 & right.x5), (sbyte)(left.x6 & right.x6), (sbyte)(left.x7 & right.x7), (sbyte)(left.x8 & right.x8), (sbyte)(left.x9 & right.x9), (sbyte)(left.x10 & right.x10), (sbyte)(left.x11 & right.x11), (sbyte)(left.x12 & right.x12), (sbyte)(left.x13 & right.x13), (sbyte)(left.x14 & right.x14), (sbyte)(left.x15 & right.x15));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator | (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 | right.x0), (sbyte)(left.x1 | right.x1), (sbyte)(left.x2 | right.x2), (sbyte)(left.x3 | right.x3), (sbyte)(left.x4 | right.x4), (sbyte)(left.x5 | right.x5), (sbyte)(left.x6 | right.x6), (sbyte)(left.x7 | right.x7), (sbyte)(left.x8 | right.x8), (sbyte)(left.x9 | right.x9), (sbyte)(left.x10 | right.x10), (sbyte)(left.x11 | right.x11), (sbyte)(left.x12 | right.x12), (sbyte)(left.x13 | right.x13), (sbyte)(left.x14 | right.x14), (sbyte)(left.x15 | right.x15));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ^ (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new sbyte16((sbyte)(left.x0 ^ right.x0), (sbyte)(left.x1 ^ right.x1), (sbyte)(left.x2 ^ right.x2), (sbyte)(left.x3 ^ right.x3), (sbyte)(left.x4 ^ right.x4), (sbyte)(left.x5 ^ right.x5), (sbyte)(left.x6 ^ right.x6), (sbyte)(left.x7 ^ right.x7), (sbyte)(left.x8 ^ right.x8), (sbyte)(left.x9 ^ right.x9), (sbyte)(left.x10 ^ right.x10), (sbyte)(left.x11 ^ right.x11), (sbyte)(left.x12 ^ right.x12), (sbyte)(left.x13 ^ right.x13), (sbyte)(left.x14 ^ right.x14), (sbyte)(left.x15 ^ right.x15));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator - (sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte16((sbyte)(-x.x0), (sbyte)(-x.x1), (sbyte)(-x.x2), (sbyte)(-x.x3), (sbyte)(-x.x4), (sbyte)(-x.x5), (sbyte)(-x.x6), (sbyte)(-x.x7), (sbyte)(-x.x8), (sbyte)(-x.x9), (sbyte)(-x.x10), (sbyte)(-x.x11), (sbyte)(-x.x12), (sbyte)(-x.x13), (sbyte)(-x.x14), (sbyte)(-x.x15));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ++ (sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 + 1), (sbyte)(x.x1 + 1), (sbyte)(x.x2 + 1), (sbyte)(x.x3 + 1), (sbyte)(x.x4 + 1), (sbyte)(x.x5 + 1), (sbyte)(x.x6 + 1), (sbyte)(x.x7 + 1), (sbyte)(x.x8 + 1), (sbyte)(x.x9 + 1), (sbyte)(x.x10 + 1), (sbyte)(x.x11 + 1), (sbyte)(x.x12 + 1), (sbyte)(x.x13 + 1), (sbyte)(x.x14 + 1), (sbyte)(x.x15 + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator -- (sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 - 1), (sbyte)(x.x1 - 1), (sbyte)(x.x2 - 1), (sbyte)(x.x3 - 1), (sbyte)(x.x4 - 1), (sbyte)(x.x5 - 1), (sbyte)(x.x6 - 1), (sbyte)(x.x7 - 1), (sbyte)(x.x8 - 1), (sbyte)(x.x9 - 1), (sbyte)(x.x10 - 1), (sbyte)(x.x11 - 1), (sbyte)(x.x12 - 1), (sbyte)(x.x13 - 1), (sbyte)(x.x14 - 1), (sbyte)(x.x15 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator ~ (sbyte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new sbyte16((sbyte)(~x.x0), (sbyte)(~x.x1), (sbyte)(~x.x2), (sbyte)(~x.x3), (sbyte)(~x.x4), (sbyte)(~x.x5), (sbyte)(~x.x6), (sbyte)(~x.x7), (sbyte)(~x.x8), (sbyte)(~x.x9), (sbyte)(~x.x10), (sbyte)(~x.x11), (sbyte)(~x.x12), (sbyte)(~x.x13), (sbyte)(~x.x14), (sbyte)(~x.x15));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator << (sbyte16 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi8(x, n);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 << n), (sbyte)(x.x1 << n), (sbyte)(x.x2 << n), (sbyte)(x.x3 << n), (sbyte)(x.x4 << n), (sbyte)(x.x5 << n), (sbyte)(x.x6 << n), (sbyte)(x.x7 << n), (sbyte)(x.x8 << n), (sbyte)(x.x9 << n), (sbyte)(x.x10 << n), (sbyte)(x.x11 << n), (sbyte)(x.x12 << n), (sbyte)(x.x13 << n), (sbyte)(x.x14 << n), (sbyte)(x.x15 << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 operator >> (sbyte16 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srai_epi8(x, n);
            }
            else
            {
                return new sbyte16((sbyte)(x.x0 >> n), (sbyte)(x.x1 >> n), (sbyte)(x.x2 >> n), (sbyte)(x.x3 >> n), (sbyte)(x.x4 >> n), (sbyte)(x.x5 >> n), (sbyte)(x.x6 >> n), (sbyte)(x.x7 >> n), (sbyte)(x.x8 >> n), (sbyte)(x.x9 >> n), (sbyte)(x.x10 >> n), (sbyte)(x.x11 >> n), (sbyte)(x.x12 >> n), (sbyte)(x.x13 >> n), (sbyte)(x.x14 >> n), (sbyte)(x.x15 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator == (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7, left.x8 == right.x8, left.x9 == right.x9, left.x10 == right.x10, left.x11 == right.x11, left.x12 == right.x12, left.x13 == right.x13, left.x14 == right.x14, left.x15 == right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator < (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7, left.x8 < right.x8, left.x9 < right.x9, left.x10 < right.x10, left.x11 < right.x11, left.x12 < right.x12, left.x13 < right.x13, left.x14 < right.x14, left.x15 < right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator > (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8(Sse2.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7, left.x8 > right.x8, left.x9 > right.x9, left.x10 > right.x10, left.x11 > right.x11, left.x12 > right.x12, left.x13 > right.x13, left.x14 > right.x14, left.x15 > right.x15);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator != (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse8(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7, left.x8 != right.x8, left.x9 != right.x9, left.x10 != right.x10, left.x11 != right.x11, left.x12 != right.x12, left.x13 != right.x13, left.x14 != right.x14, left.x15 != right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator <= (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse8(Sse2.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7, left.x8 <= right.x8, left.x9 <= right.x9, left.x10 <= right.x10, left.x11 <= right.x11, left.x12 <= right.x12, left.x13 <= right.x13, left.x14 <= right.x14, left.x15 <= right.x15);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 operator >= (sbyte16 left, sbyte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse8(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new bool16(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7, left.x8 >= right.x8, left.x9 >= right.x9, left.x10 >= right.x10, left.x11 >= right.x11, left.x12 >= right.x12, left.x13 >= right.x13, left.x14 >= right.x14, left.x15 >= right.x15);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte16 other)
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

        public override readonly bool Equals(object obj) => obj is sbyte16 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v128(this);
            }
            else
            {
                sbyte16 temp = this;

                return (*(ulong*)&temp ^ *((ulong*)&temp + 1)).GetHashCode();
            }
        }


        public override readonly string ToString() => $"sbyte16({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte16({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)})";
    }
}