using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(short))]  [DebuggerTypeProxy(typeof(short8.DebuggerProxy))]
    unsafe public struct short8 : IEquatable<short8>, IFormattable
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

            public DebuggerProxy(short8 v)
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


        [FieldOffset(0)]  private fixed short asArray[8];

        [FieldOffset(0)]  public short x0;
        [FieldOffset(2)]  public short x1;
        [FieldOffset(4)]  public short x2;
        [FieldOffset(6)]  public short x3;
        [FieldOffset(8)]  public short x4;
        [FieldOffset(10)] public short x5;
        [FieldOffset(12)] public short x6;
        [FieldOffset(14)] public short x7;


        public static short8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0, short x1, short x2, short x3, short x4, short x5, short x6, short x7)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi16(x7, x6, x5, x4, x3, x2, x1, x0);
            }
            else
            {
                this.x0 = x0;
                this.x1 = x1;
                this.x2 = x2;
                this.x3 = x3;
                this.x4 = x4;
                this.x5 = x5;
                this.x6 = x6;
                this.x7 = x7;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short x0x8)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi16(x0x8);
            }
            else
            {
                this.x0 = x0x8;
                this.x1 = x0x8;
                this.x2 = x0x8;
                this.x3 = x0x8;
                this.x4 = x0x8;
                this.x5 = x0x8;
                this.x6 = x0x8;
                this.x7 = x0x8;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short2 x45, short2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new short8(new short4(x01, x23), new short4(x45, x67));
            }
            else
            {
                this.x0 = x01.x;
                this.x1 = x01.y;
                this.x2 = x23.x;
                this.x3 = x23.y;
                this.x4 = x45.x;
                this.x5 = x45.y;
                this.x6 = x67.x;
                this.x7 = x67.y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short3 x234, short3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(x234, 2 * sizeof(short));
                v128 hi  = Sse2.bslli_si128(x567, 5 * sizeof(short));

                if (Sse4_1.IsSse41Supported)
                {
                    hi = Sse4_1.blend_epi16(mid, hi, 0b1110_0000);

                    this = Sse4_1.blend_epi16(x01, hi, 0b1111_1100);
                }
                else
                {
                    hi = Mask.BlendEpi16_SSE2(mid, hi, 0b1110_0000);

                    this = Mask.BlendEpi16_SSE2(x01, hi, 0b1111_1100);
                }
            }
            else
            {
                this.x0 = x01.x;
                this.x1 = x01.y;
                this.x2 = x234.x;
                this.x3 = x234.y;
                this.x4 = x234.z;
                this.x5 = x567.x;
                this.x6 = x567.y;
                this.x7 = x567.z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short2 x34, short3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 hi = Sse2.bslli_si128(x567, 2 * sizeof(short));

                if (Sse4_1.IsSse41Supported)
                {
                    hi = Sse4_1.blend_epi16(x34, hi, 0b0001_1100);
                    hi = Sse2.bslli_si128(hi, 3 * sizeof(short));

                    this = Sse4_1.blend_epi16(x012, hi, 0b1111_1000);
                }
                else
                {
                    hi = Mask.BlendEpi16_SSE2(x34, hi, 0b0001_1100);
                    hi = Sse2.bslli_si128(hi, 3 * sizeof(short));

                    this = Mask.BlendEpi16_SSE2(x012, hi, 0b1111_1000);
                }
            }
            else
            {
                this.x0 = x012.x;
                this.x1 = x012.y;
                this.x2 = x012.z;
                this.x3 = x34.x;
                this.x4 = x34.y;
                this.x5 = x567.x;
                this.x6 = x567.y;
                this.x7 = x567.z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short3 x012, short3 x345, short2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(x345, 3 * sizeof(short));
                v128 hi  = Sse2.bslli_si128(x67, 6 * sizeof(short));

                if (Sse4_1.IsSse41Supported)
                {
                    mid = Sse4_1.blend_epi16(x012, mid, 0b0011_1000);

                    this = Sse4_1.blend_epi16(mid, hi, 0b1100_0000);
                }
                else
                {
                    mid = Mask.BlendEpi16_SSE2(x012, mid, 0b0011_1000);

                    this = Mask.BlendEpi16_SSE2(mid, hi, 0b1100_0000);
                }
            }
            else
            {
                this.x0 = x012.x;
                this.x1 = x012.y;
                this.x2 = x012.z;
                this.x3 = x345.x;
                this.x4 = x345.y;
                this.x5 = x345.z;
                this.x6 = x67.x;
                this.x7 = x67.y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short2 x45, short2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new short8(x0123, new short4(x45, x67));
            }
            else
            {
                this.x0 = x0123.x;
                this.x1 = x0123.y;
                this.x2 = x0123.z;
                this.x3 = x0123.w;
                this.x4 = x45.x;
                this.x5 = x45.y;
                this.x6 = x67.x;
                this.x7 = x67.y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short4 x2345, short2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new short8((short4)Sse2.unpacklo_epi32(x01, x2345),
                                  (short4)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x2345, 2 * sizeof(short)), x67));
            }
            else
            {
                this.x0 = x01.x;
                this.x1 = x01.y;
                this.x2 = x2345.x;
                this.x3 = x2345.y;
                this.x4 = x2345.z;
                this.x5 = x2345.w;
                this.x6 = x67.x;
                this.x7 = x67.y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short2 x01, short2 x23, short4 x4567)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new short8(new short4(x01, x23), x4567);
            }
            else
            {
                this.x0 = x01.x;
                this.x1 = x01.y;
                this.x2 = x23.x;
                this.x3 = x23.y;
                this.x4 = x4567.x;
                this.x5 = x4567.y;
                this.x6 = x4567.z;
                this.x7 = x4567.w;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short8(short4 x0123, short4 x4567)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.unpacklo_epi64(x0123, x4567);
            }
            else
            {
                this.x0 = x0123.x;
                this.x1 = x0123.y;
                this.x2 = x0123.z;
                this.x3 = x0123.w;
                this.x4 = x4567.x;
                this.x5 = x4567.y;
                this.x6 = x4567.z;
                this.x7 = x4567.w;
            }
        }


        #region Shuffle
        public short4 v4_0
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
                    return new short4(x0, x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(this, value, 0b0000_1111);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16_SSE2(this, value, 0b0000_1111);
                }
                else
                {
                    this.x0 = value.x;
                    this.x1 = value.y;
                    this.x2 = value.z;
                    this.x3 = value.w;
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(short));
                }
                else
                {
                    return new short4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(short)), 0b0001_1110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 1 * sizeof(short)), 0b0001_1110);
                    }
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                    this.x3 = value.z;
                    this.x4 = value.w;
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(short));
                }
                else
                {
                    return new short4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b0011_1100);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b0011_1100);
                    }
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                    this.x4 = value.z;
                    this.x5 = value.w;
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
                    return Sse2.bsrli_si128(this, 3 * sizeof(short));
                }
                else
                {
                    return new short4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b0111_1000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b0111_1000);
                    }
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                    this.x5 = value.z;
                    this.x6 = value.w;
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(short));
                }
                else
                {
                    return new short4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b1111_0000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b1111_0000);
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                    this.x6 = value.z;
                    this.x7 = value.w;
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
                    return (v128)this;
                }
                else
                {
                    return new short3(x0, x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, value, 0b0000_0111);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, value, 0b0000_0111);
                    }
                }
                else
                {
                    this.x0 = value.x;
                    this.x1 = value.y;
                    this.x2 = value.z;
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(short));
                }
                else
                {
                    return new short3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(short)), 0b0000_1110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 1 * sizeof(short)), 0b0000_1110);
                    }
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                    this.x3 = value.z;
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(short));
                }
                else
                {
                    return new short3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b0001_1100);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b0001_1100);
                    }
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                    this.x4 = value.z;
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
                    return Sse2.bsrli_si128(this, 3 * sizeof(short));
                }
                else
                {
                    return new short3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b0011_1000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b0011_1000);
                    }
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                    this.x5 = value.z;
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(short));
                }
                else
                {
                    return new short3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b0111_0000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b0111_0000);
                    }
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                    this.x6 = value.z;
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
                    return Sse2.bsrli_si128(this, 5 * sizeof(short));
                }
                else
                {
                    return new short3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b1110_0000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b1110_0000);
                    }
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                    this.x7 = value.z;
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
                    return (v128)this;
                }
                else
                {
                    return new short2(x0, x1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(this, value, 0b0000_0011);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16_SSE2(this, value, 0b0000_0011);
                }
                else
                {
                    this.x0 = value.x;
                    this.x1 = value.y;
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
                    return Sse2.bsrli_si128(this, 1 * sizeof(short));
                }
                else
                {
                    return new short2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(short)), 0b0000_0110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 1 * sizeof(short)), 0b0000_0110);
                    }
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
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
                    return Sse2.bsrli_si128(this, 2 * sizeof(short));
                }
                else
                {
                    return new short2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b0000_1100);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 2 * sizeof(short)), 0b0000_1100);
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
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
                    return Sse2.bsrli_si128(this, 3 * sizeof(short));
                }
                else
                {
                    return new short2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b0001_1000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 3 * sizeof(short)), 0b0001_1000);
                    }
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
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
                    return Sse2.bsrli_si128(this, 4 * sizeof(short));
                }
                else
                {
                    return new short2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b0011_0000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 4 * sizeof(short)), 0b0011_0000);
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
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
                    return Sse2.bsrli_si128(this, 5 * sizeof(short));
                }
                else
                {
                    return new short2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b0110_0000);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 5 * sizeof(short)), 0b0110_0000);
                    }
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
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
                    return Sse2.bsrli_si128(this, 6 * sizeof(short));
                }
                else
                {
                    return new short2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse4_1.IsSse41Supported)
                {
                    this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, 6 * sizeof(short)), 0b1100_0000);
                }
                else
                {
                    this.x6 = value.x;
                    this.x7 = value.y;
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse4_1.stream_load_si128(void* ptr)   Sse2.load(u)_[...].
        public static implicit operator v128(short8 input) => new v128(input.x0, input.x1, input.x2, input.x3, input.x4, input.x5, input.x6, input.x7);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Sse.store_ps(void* ptr, v128 x)
        public static implicit operator short8(v128 input) => new short8 { x0 = input.SShort0, x1 = input.SShort1, x2 = input.SShort2, x3 = input.SShort3, x4 = input.SShort4, x5 = input.SShort5, x6 = input.SShort6, x7 = input.SShort7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(short input) => new short8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(ushort8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(short8*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Int8ToShort8(input);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                return Cast.Int8To_U_Short8_SSE4_1(UnityMathematicsLink.Tov128(input._v4_0), UnityMathematicsLink.Tov128(input._v4_4));
            }
            else
            {
                return new short8((short4)input._v4_0, (short4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(int8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Int8ToShort8(input);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                return Cast.Int8To_U_Short8_SSE4_1(UnityMathematicsLink.Tov128(input._v4_0), UnityMathematicsLink.Tov128(input._v4_4));
            }
            else
            {
                return new short8((short4)input._v4_0, (short4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(half8 input) => (short8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short8(float8 input) => (short8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(short8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (uint8)Cast.Short8ToInt8(input);
            }
            else
            {
                return new uint8((uint4)input.v4_0, (uint4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(short8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.Short8ToInt8(input);
            }
            else
            {
                return new int8((int4)input.v4_0, (int4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(short8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(short8 input) => (float8)(int8)input;


        public short this[int index]
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
        public static short8 operator + (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new short8((short)(left.x0 + right.x0), (short)(left.x1 + right.x1), (short)(left.x2 + right.x2), (short)(left.x3 + right.x3), (short)(left.x4 + right.x4), (short)(left.x5 + right.x5), (short)(left.x6 + right.x6), (short)(left.x7 + right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new short8((short)(left.x0 - right.x0), (short)(left.x1 - right.x1), (short)(left.x2 - right.x2), (short)(left.x3 - right.x3), (short)(left.x4 - right.x4), (short)(left.x5 - right.x5), (short)(left.x6 - right.x6), (short)(left.x7 - right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new short8((short)(left.x0 * right.x0), (short)(left.x1 * right.x1), (short)(left.x2 * right.x2), (short)(left.x3 * right.x3), (short)(left.x4 * right.x4), (short)(left.x5 * right.x5), (short)(left.x6 * right.x6), (short)(left.x7 * right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, short8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdiv_short(left, right);
            }
            else
            {
                return new short8(left.v4_0 / right.v4_0, left.v4_4 / right.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, short8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vrem_short(left, right);
            }
            else
            {
                return new short8(left.v4_0 % right.v4_0, left.v4_4 % right.v4_4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short left, short8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator * (short8 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new short8((short)(left.x0 * right), (short)(left.x1 * right), (short)(left.x2 * right), (short)(left.x3 * right), (short)(left.x4 * right), (short)(left.x5 * right), (short)(left.x6 * right), (short)(left.x7 * right));
                }
            }

            return left * (short8)right;
        } 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator / (short8 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new short8((short)(left.x0 / right), (short)(left.x1 / right), (short)(left.x2 / right), (short)(left.x3 / right), (short)(left.x4 / right), (short)(left.x5 / right), (short)(left.x6 / right), (short)(left.x7 / right));
                }
            }

            return left / (short8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator % (short8 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new short8((short)(left.x0 % right), (short)(left.x1 % right), (short)(left.x2 % right), (short)(left.x3 % right), (short)(left.x4 % right), (short)(left.x5 % right), (short)(left.x6 % right), (short)(left.x7 % right));
                }
            }

            return left % (short8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator & (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new short8((short)(left.x0 & right.x0), (short)(left.x1 & right.x1), (short)(left.x2 & right.x2), (short)(left.x3 & right.x3), (short)(left.x4 & right.x4), (short)(left.x5 & right.x5), (short)(left.x6 & right.x6), (short)(left.x7 & right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator | (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new short8((short)(left.x0 | right.x0), (short)(left.x1 | right.x1), (short)(left.x2 | right.x2), (short)(left.x3 | right.x3), (short)(left.x4 | right.x4), (short)(left.x5 | right.x5), (short)(left.x6 | right.x6), (short)(left.x7 | right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ^ (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new short8((short)(left.x0 ^ right.x0), (short)(left.x1 ^ right.x1), (short)(left.x2 ^ right.x2), (short)(left.x3 ^ right.x3), (short)(left.x4 ^ right.x4), (short)(left.x5 ^ right.x5), (short)(left.x6 ^ right.x6), (short)(left.x7 ^ right.x7));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator - (short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(default(v128), x);
            }
            else
            {
                return new short8((short)(-x.x0), (short)(-x.x1), (short)(-x.x2), (short)(-x.x3), (short)(-x.x4), (short)(-x.x5), (short)(-x.x6), (short)(-x.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ++ (short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new short8((short)(x.x0 + 1), (short)(x.x1 + 1), (short)(x.x2 + 1), (short)(x.x3 + 1), (short)(x.x4 + 1), (short)(x.x5 + 1), (short)(x.x6 + 1), (short)(x.x7 + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator -- (short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new short8((short)(x.x0 - 1), (short)(x.x1 - 1), (short)(x.x2 - 1), (short)(x.x3 - 1), (short)(x.x4 - 1), (short)(x.x5 - 1), (short)(x.x6 - 1), (short)(x.x7 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator ~ (short8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new short8((short)(~x.x0), (short)(~x.x1), (short)(~x.x2), (short)(~x.x3), (short)(~x.x4), (short)(~x.x5), (short)(~x.x6), (short)(~x.x7));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator << (short8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_short(x, n);
            }
            else
            {
                return new short8((short)(x.x0 << n), (short)(x.x1 << n), (short)(x.x2 << n), (short)(x.x3 << n), (short)(x.x4 << n), (short)(x.x5 << n), (short)(x.x6 << n), (short)(x.x7 << n));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 operator >> (short8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shra_short(x, n);
            }
            else
            {
                return new short8((short)(x.x0 >> n), (short)(x.x1 >> n), (short)(x.x2 >> n), (short)(x.x3 >> n), (short)(x.x4 >> n), (short)(x.x5 >> n), (short)(x.x6 >> n), (short)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return ConvertToBool.IsTrue16(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return ConvertToBool.IsTrue16(Sse2.cmpgt_epi16(right, left));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return ConvertToBool.IsTrue16(Sse2.cmpgt_epi16(left, right));
            }
            else
            {
                return new bool8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return ConvertToBool.IsFalse16(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return ConvertToBool.IsFalse16(Sse2.cmpgt_epi16(left, right));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (short8 left, short8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return ConvertToBool.IsFalse16(Sse2.cmpgt_epi16(right, left));
            }
            else
            {
                return new bool8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short8 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.bitmask32(8 * sizeof(short)) == Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other));
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override bool Equals(object obj) => Equals((short8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v128(this);
            }
            else
            {
                short8 temp = this;

                return (*(ulong*)&temp ^ *((ulong*)&temp + 1)).GetHashCode();
            }
        }


        public override string ToString() => $"short8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}