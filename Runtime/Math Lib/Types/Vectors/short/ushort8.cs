using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(ushort))] 
    [DebuggerTypeProxy(typeof(ushort8.DebuggerProxy))]
    unsafe public struct ushort8 : IEquatable<ushort8>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public ushort x0;
            public ushort x1;
            public ushort x2;
            public ushort x3;
            public ushort x4;
            public ushort x5;
            public ushort x6;
            public ushort x7;

            public DebuggerProxy(ushort8 v)
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


        [FieldOffset(0)]  public ushort x0;
        [FieldOffset(2)]  public ushort x1;
        [FieldOffset(4)]  public ushort x2;
        [FieldOffset(6)]  public ushort x3;
        [FieldOffset(8)]  public ushort x4;
        [FieldOffset(10)] public ushort x5;
        [FieldOffset(12)] public ushort x6;
        [FieldOffset(14)] public ushort x7;


        public static ushort8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi16((short)x7, (short)x6, (short)x5, (short)x4, (short)x3, (short)x2, (short)x1, (short)x0);
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
        public ushort8(ushort x0x8)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi16((short)x0x8);
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
        public ushort8(ushort2 x01, ushort2 x23, ushort2 x45, ushort2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new ushort8(new ushort4(x01, x23), new ushort4(x45, x67));
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
        public ushort8(ushort2 x01, ushort3 x234, ushort3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(x234, 2 * sizeof(ushort));
                v128 hi  = Sse2.bslli_si128(x567, 5 * sizeof(ushort));

                hi = Xse.blend_epi16(mid, hi, 0b1110_0000);

                this = Xse.blend_epi16(x01, hi, 0b1111_1100);
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
        public ushort8(ushort3 x012, ushort2 x34, ushort3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 hi = Sse2.bslli_si128(x567, 2 * sizeof(short));

                hi = Xse.blend_epi16(x34, hi, 0b0001_1100);
                hi = Sse2.bslli_si128(hi, 3 * sizeof(short));

                this = Xse.blend_epi16(x012, hi, 0b1111_1000);
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
        public ushort8(ushort3 x012, ushort3 x345, ushort2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(x345, 3 * sizeof(ushort));
                v128 hi  = Sse2.bslli_si128(x67, 6 * sizeof(ushort));

                if (Sse4_1.IsSse41Supported)
                {
                    mid = Sse4_1.blend_epi16(x012, mid, 0b0011_1000);

                    this = Sse4_1.blend_epi16(mid, hi, 0b1100_0000);
                }
                else
                {
                    mid = Xse.blend_epi16(x012, mid, 0b0011_1000);

                    this = Xse.blend_epi16(mid, hi, 0b1100_0000);
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
        public ushort8(ushort4 x0123, ushort2 x45, ushort2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new ushort8(x0123, new ushort4(x45, x67));
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
        public ushort8(ushort2 x01, ushort4 x2345, ushort2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new ushort8((ushort4)Sse2.unpacklo_epi32(x01, x2345),
                                   (ushort4)Sse2.unpacklo_epi32(Sse2.bsrli_si128(x2345, 2 * sizeof(ushort)), x67));
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
        public ushort8(ushort2 x01, ushort2 x23, ushort4 x4567)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new ushort8(new ushort4(x01, x23), x4567);
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
        public ushort8(ushort4 x0123, ushort4 x4567)
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
        public ushort4 v4_0
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
                    return new ushort4(x0, x1, x2, x3);
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
                    this.x0 = value.x;
                    this.x1 = value.y;
                    this.x2 = value.z;
                    this.x3 = value.w;
                }
            }
        }
        public ushort4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0001_1110);
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
        public ushort4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0011_1100);
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
        public ushort4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0111_1000);
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
        public ushort4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(ushort)), 0b1111_0000);
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

        public ushort3 v3_0
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
                    return new ushort3(x0, x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, value, 0b0000_0111);
                }
                else
                {
                    this.x0 = value.x;
                    this.x1 = value.y;
                    this.x2 = value.z;
                }
            }
        }
        public ushort3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_1110);
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                    this.x3 = value.z;
                }
            }
        }
        public ushort3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0001_1100);
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                    this.x4 = value.z;
                }
            }
        }
        public ushort3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0011_1000);
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                    this.x5 = value.z;
                }
            }
        }
        public ushort3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(ushort)), 0b0111_0000);
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                    this.x6 = value.z;
                }
            }
        }
        public ushort3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(ushort)), 0b1110_0000);
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                    this.x7 = value.z;
                }
            }
        }
                                                                                                                                                                                     
        public ushort2 v2_0
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
                    return new ushort2(x0, x1);
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
                    this.x0 = value.x;
                    this.x1 = value.y;
                }
            }
        }
        public ushort2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 1 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_0110);
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                }
            }
        }
        public ushort2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 2 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 2 * sizeof(ushort)), 0b0000_1100);
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                }
            }
        }
        public ushort2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 3 * sizeof(ushort)), 0b0001_1000);
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                }
            }
        }
        public ushort2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 4 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 4 * sizeof(ushort)), 0b0011_0000);
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                }
            }
        }
        public ushort2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 5 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 5 * sizeof(ushort)), 0b0110_0000);
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                }
            }
        }
        public ushort2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 6 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, 6 * sizeof(ushort)), 0b1100_0000);
                }
                else
                {
                    this.x6 = value.x;
                    this.x7 = value.y;
                }
            }
        }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort8 input) => new v128 { UShort0 = input.x0, UShort1 = input.x1, UShort2 = input.x2, UShort3 = input.x3, UShort4 = input.x4, UShort5 = input.x5, UShort6 = input.x6, UShort7 = input.x7 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(v128 input) => new ushort8 { x0 = input.UShort0, x1 = input.UShort1, x2 = input.UShort2, x3 = input.UShort3, x4 = input.UShort4, x5 = input.UShort5, x6 = input.UShort6, x7 = input.UShort7 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(ushort input) => new ushort8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(short8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(ushort8*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_epi16(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Int8To_U_Short8_SSE2(RegisterConversion.ToV128(input._v4_0), RegisterConversion.ToV128(input._v4_4));
            }
            else
            {
                return new ushort8((ushort4)input._v4_0, (ushort4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(int8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_epi16(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Int8To_U_Short8_SSE2(RegisterConversion.ToV128(input._v4_0), RegisterConversion.ToV128(input._v4_4));
            }
            else
            {
                return new ushort8((ushort4)input._v4_0, (ushort4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(half8 input) => (ushort8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(float8 input) => (ushort8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(ushort8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (uint8)Cast.UShort8ToInt8(input);
            }
            else
            {
                return new uint8((uint4)input.v4_0, (uint4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(ushort8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.UShort8ToInt8(input);
            }
            else
            {
                return new int8((int4)input.v4_0, (int4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(ushort8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(ushort8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                ;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 lo = Cast.UShort8To_Float8_SSE2(input, out v128 hi);

                return new float8(*(float4*)&lo, *(float4*)&hi);
            }

            return (float8)(int8)input;
        }


        public ushort this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Sse2.IsSse2Supported)
                {
                    return Xse.extract_epi16(this, (byte)index);
                }
                else
                {
                    ushort8 onStack = this;

                    return *((ushort*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, value, (byte)index);
                }
                else
                {
                    ushort8 onStack = this;
                    *((ushort*)&onStack + index) = value;
                    this = onStack;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 + right.x0), (ushort)(left.x1 + right.x1), (ushort)(left.x2 + right.x2), (ushort)(left.x3 + right.x3), (ushort)(left.x4 + right.x4), (ushort)(left.x5 + right.x5), (ushort)(left.x6 + right.x6), (ushort)(left.x7 + right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 - right.x0), (ushort)(left.x1 - right.x1), (ushort)(left.x2 - right.x2), (ushort)(left.x3 - right.x3), (ushort)(left.x4 - right.x4), (ushort)(left.x5 - right.x5), (ushort)(left.x6 - right.x6), (ushort)(left.x7 - right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 * right.x0), (ushort)(left.x1 * right.x1), (ushort)(left.x2 * right.x2), (ushort)(left.x3 * right.x3), (ushort)(left.x4 * right.x4), (ushort)(left.x5 * right.x5), (ushort)(left.x6 * right.x6), (ushort)(left.x7 * right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epu16(left, right, 8);
            }
            else
            {
                return new ushort8((ushort)(left.x0 / right.x0), (ushort)(left.x1 / right.x1), (ushort)(left.x2 / right.x2), (ushort)(left.x3 / right.x3), (ushort)(left.x4 / right.x4), (ushort)(left.x5 / right.x5), (ushort)(left.x6 / right.x6), (ushort)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epu16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 % right.x0), (ushort)(left.x1 % right.x1), (ushort)(left.x2 % right.x2), (ushort)(left.x3 % right.x3), (ushort)(left.x4 % right.x4), (ushort)(left.x5 % right.x5), (ushort)(left.x6 % right.x6), (ushort)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort left, ushort8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return new ushort8((ushort)(left.x0 * right), (ushort)(left.x1 * right), (ushort)(left.x2 * right), (ushort)(left.x3 * right), (ushort)(left.x4 * right), (ushort)(left.x5 * right), (ushort)(left.x6 * right), (ushort)(left.x7 * right));
                }
            }

            return left * (ushort8)right;
        } 
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epu16(left, right, 8);
                }
            }
                
            return left / (ushort8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epu16(left, right, 8);
                }
            }
                
            return left % (ushort8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 & right.x0), (ushort)(left.x1 & right.x1), (ushort)(left.x2 & right.x2), (ushort)(left.x3 & right.x3), (ushort)(left.x4 & right.x4), (ushort)(left.x5 & right.x5), (ushort)(left.x6 & right.x6), (ushort)(left.x7 & right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 | right.x0), (ushort)(left.x1 | right.x1), (ushort)(left.x2 | right.x2), (ushort)(left.x3 | right.x3), (ushort)(left.x4 | right.x4), (ushort)(left.x5 | right.x5), (ushort)(left.x6 | right.x6), (ushort)(left.x7 | right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 ^ right.x0), (ushort)(left.x1 ^ right.x1), (ushort)(left.x2 ^ right.x2), (ushort)(left.x3 ^ right.x3), (ushort)(left.x4 ^ right.x4), (ushort)(left.x5 ^ right.x5), (ushort)(left.x6 ^ right.x6), (ushort)(left.x7 ^ right.x7));
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ++ (ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new ushort8((ushort)(x.x0 + 1), (ushort)(x.x1 + 1), (ushort)(x.x2 + 1), (ushort)(x.x3 + 1), (ushort)(x.x4 + 1), (ushort)(x.x5 + 1), (ushort)(x.x6 + 1), (ushort)(x.x7 + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator -- (ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new ushort8((ushort)(x.x0 - 1), (ushort)(x.x1 - 1), (ushort)(x.x2 - 1), (ushort)(x.x3 - 1), (ushort)(x.x4 - 1), (ushort)(x.x5 - 1), (ushort)(x.x6 - 1), (ushort)(x.x7 - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ~ (ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new ushort8((ushort)~x.x0, (ushort)~x.x1, (ushort)~x.x2, (ushort)~x.x3, (ushort)~x.x4, (ushort)~x.x5, (ushort)~x.x6, (ushort)~x.x7);
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator << (ushort8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi16(x, n);
            }
            else
            {
                return new ushort8((ushort)(x.x0 << n), (ushort)(x.x1 << n), (ushort)(x.x2 << n), (ushort)(x.x3 << n), (ushort)(x.x4 << n), (ushort)(x.x5 << n), (ushort)(x.x6 << n), (ushort)(x.x7 << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator >> (ushort8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srli_epi16(x, n);
            }
            else
            {
                return new ushort8((ushort)(x.x0 >> n), (ushort)(x.x1 >> n), (ushort)(x.x2 >> n), (ushort)(x.x3 >> n), (ushort)(x.x4 >> n), (ushort)(x.x5 >> n), (ushort)(x.x6 >> n), (ushort)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.cmplt_epu16(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.cmpgt_epu16(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse16(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.cmple_epu16(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue16(Xse.cmpge_epu16(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ushort8 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return bitmask32(8 * sizeof(ushort)) == Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other));
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override readonly bool Equals(object obj) => obj is ushort8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v128(this);
            }
            else
            {
                ushort8 temp = this;

                return (*(ulong*)&temp ^ *((ulong*)&temp + 1)).GetHashCode();
            }
        }


        public override readonly string ToString() => $"ushort8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ushort8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}