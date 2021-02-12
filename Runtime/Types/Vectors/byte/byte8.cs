using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(byte))] [DebuggerTypeProxy(typeof(byte8.DebuggerProxy))]
    unsafe public struct byte8 : IEquatable<byte8>, IFormattable
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

            public DebuggerProxy(byte8 v)
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


        [FieldOffset(0)] private fixed byte asArray[8];

        [FieldOffset(0)] public byte x0;
        [FieldOffset(1)] public byte x1;
        [FieldOffset(2)] public byte x2;
        [FieldOffset(3)] public byte x3;
        [FieldOffset(4)] public byte x4;
        [FieldOffset(5)] public byte x5;
        [FieldOffset(6)] public byte x6;
        [FieldOffset(7)] public byte x7;


        public static byte8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte8(byte x0, byte x1, byte x2, byte x3, byte x4, byte x5, byte x6, byte x7)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, (sbyte)x7, (sbyte)x6, (sbyte)x5, (sbyte)x4, (sbyte)x3, (sbyte)x2, (sbyte)x1, (sbyte)x0);
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
        public byte8(byte x0x8)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi8((sbyte)x0x8);
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
        public byte8(byte2 x01, byte2 x23, byte2 x45, byte2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new byte8(new byte4(x01, x23), new byte4(x45, x67));
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
        public byte8(byte2 x01, byte3 x234, byte3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(x234, 2 * sizeof(byte));
                v128 hi  = Sse2.bslli_si128(x567, 5 * sizeof(byte));

                hi = Mask.BlendV(mid, hi, new byte8(0, 0, 0, 0, 0, 255, 255, 255));

                this = Mask.BlendEpi16(x01, hi, 0b1110);
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
        public byte8(byte3 x012, byte2 x34, byte3 x567)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 hi = Sse2.bslli_si128(x567, 2 * sizeof(byte));
                hi = Mask.BlendEpi16(x34, hi, 0b0110);
                hi = Sse2.bslli_si128(hi, 3 * sizeof(byte));

                this = Mask.BlendV(x012, hi, new byte8(0, 0, 0, 255, 255, 255, 255, 255));
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
        public byte8(byte3 x012, byte3 x345, byte2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mid = Sse2.bslli_si128(x345, 3 * sizeof(byte));
                v128 hi  = Sse2.bslli_si128(x67,  6 * sizeof(byte));

                mid = Mask.BlendV(x012, mid, new byte8(0, 0, 0, 255, 255, 255, 0, 0));

                this = Mask.BlendEpi16(mid, hi, 0b1000);
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
        public byte8(byte4 x0123, byte2 x45, byte2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new byte8(x0123, new byte4(x45, x67));
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
        public byte8(byte2 x01, byte4 x2345, byte2 x67)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new byte8((byte4)Sse2.unpacklo_epi16(x01, x2345),
                                 (byte4)Sse2.unpacklo_epi16(Sse2.bsrli_si128(x2345, 2 * sizeof(byte)), x67));
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
        public byte8(byte2 x01, byte2 x23, byte4 x4567)
        {
            if (Sse2.IsSse2Supported)
            {
                this = new byte8(new byte4(x01, x23), x4567);
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
        public byte8(byte4 x0123, byte4 x4567)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.unpacklo_epi32(x0123, x4567);
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
        public byte4 v4_0
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
                    return new byte4(x0, x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16(this, value, 0b0011);
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
        public byte4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new byte8(0, 255, 255, 255, 255, 0, 0, 0));
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
        public byte4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendEpi16(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), 0b0110);
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
        public byte4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new byte8(0, 0, 0, 255, 255, 255, 255, 0));
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
        public byte4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                if (Sse2.IsSse2Supported)
                {
                    this = Sse2.unpacklo_epi32(this, value);
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

        public byte3 v3_0
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
                    return new byte3(x0, x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, value, new byte8(255, 255, 255, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x0 = value.x;
                    this.x1 = value.y;
                    this.x2 = value.z;
                }
            }
        }
        public byte3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new byte8(0, 255, 255, 255, 0, 0, 0, 0));
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                    this.x3 = value.z;
                }
            }
        }
        public byte3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 2 * sizeof(byte)), new byte8(0, 0, 255, 255, 255, 0, 0, 0));
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                    this.x4 = value.z;
                }
            }
        }
        public byte3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, 3 * sizeof(byte));
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new byte8(0, 0, 0, 255, 255, 255, 0, 0));
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                    this.x5 = value.z;
                }
            }
        }
        public byte3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 4 * sizeof(byte)), new byte8(0, 0, 0, 0, 255, 255, 255, 0));
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                    this.x6 = value.z;
                }
            }
        }
        public byte3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 5 * sizeof(byte)), new byte8(0, 0, 0, 0, 0, 255, 255, 255));
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                    this.x7 = value.z;
                }
            }
        }
                                                                                                                                                                                     
        public byte2 v2_0
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
                    return new byte2(x0, x1);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16(this, value, 0b0001);
                }
                else if (Sse2.IsSse2Supported)
                {
                    this = Sse2.insert_epi16(this, *(short*)&value, 0);
                }
                else
                {
                    this.x0 = value.x;
                    this.x1 = value.y;
                }
            }
        }
        public byte2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 1 * sizeof(byte)), new byte8(0, 255, 255, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                }
            }
        }
        public byte2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this.x2 = value.x;
                    this.x3 = value.y;
                }
            }
        }
        public byte2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 3 * sizeof(byte)), new byte8(0, 0, 0, 255, 255, 0, 0, 0));
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                }
            }
        }
        public byte2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this.x4 = value.x;
                    this.x5 = value.y;
                }
            }
        }
        public byte2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, 5 * sizeof(byte)), new byte8(0, 0, 0, 0, 0, 255, 255, 0));
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                }
            }
        }
        public byte2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
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
                    this.x6 = value.x;
                    this.x7 = value.y;
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte8 input) => new v128(*(long*)&input, 0L);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte8(v128 input) { long x = input.SLong0; return *(byte8*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte8(byte input) => new byte8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(sbyte8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte8*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(ushort8 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new byte8((byte)input.x0, (byte)input.x1, (byte)input.x2, (byte)input.x3, (byte)input.x4, (byte)input.x5, (byte)input.x6, (byte)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(short8 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new byte8((byte)input.x0, (byte)input.x1, (byte)input.x2, (byte)input.x3, (byte)input.x4, (byte)input.x5, (byte)input.x6, (byte)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Int8ToByte8(input);
            }
            else
            {
                return new byte8((byte4)input._v4_0, (byte4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(int8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Int8ToByte8(input);
            }
            else
            {
                return new byte8((byte4)input._v4_0, (byte4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(half8 input) => (byte8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(float8 input) => (byte8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(byte8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToShort(input);
            }
            else
            {
                return new ushort8((ushort)input.x0, (ushort)input.x1, (ushort)input.x2, (ushort)input.x3, (ushort)input.x4, (ushort)input.x5, (ushort)input.x6, (ushort)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(byte8 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToShort(input);
            }
            else
            {
                return new short8((short)input.x0, (short)input.x1, (short)input.x2, (short)input.x3, (short)input.x4, (short)input.x5, (short)input.x6, (short)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(byte8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi32(input);
            }
            else
            {
                return new uint8((uint4)input.v4_0, (uint4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int8(byte8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi32(input);
            }
            else
            {
                return new int8((int4)input.v4_0, (int4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(byte8 input) => (half8)(float8)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(byte8 input) => (float8)(int8)input;


        public byte this[int index]
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
        public static byte8 operator + (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 + right.x0), (byte)(left.x1 + right.x1), (byte)(left.x2 + right.x2), (byte)(left.x3 + right.x3), (byte)(left.x4 + right.x4), (byte)(left.x5 + right.x5), (byte)(left.x6 + right.x6), (byte)(left.x7 + right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator - (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 - right.x0), (byte)(left.x1 - right.x1), (byte)(left.x2 - right.x2), (byte)(left.x3 - right.x3), (byte)(left.x4 - right.x4), (byte)(left.x5 - right.x5), (byte)(left.x6 - right.x6), (byte)(left.x7 - right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte8 left, byte8 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (byte8)((ushort8)left * (ushort8)right);
            }
            else
            {
                return new byte8((byte)(left.x0 * right.x0), (byte)(left.x1 * right.x1), (byte)(left.x2 * right.x2), (byte)(left.x3 * right.x3), (byte)(left.x4 * right.x4), (byte)(left.x5 * right.x5), (byte)(left.x6 * right.x6), (byte)(left.x7 * right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 left, byte8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdiv_byte(left, right);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                return Operator.vdiv_byte_SSE_FALLBACK(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new byte8(Operator.vdiv_byte(left.v4_0, right.v4_0), Operator.vdiv_byte(left.v4_4, right.v4_4));
            }
            else
            {
                return new byte8((byte)(left.x0 / right.x0), (byte)(left.x1 / right.x1), (byte)(left.x2 / right.x2), (byte)(left.x3 / right.x3), (byte)(left.x4 / right.x4), (byte)(left.x5 / right.x5), (byte)(left.x6 / right.x6), (byte)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 left, byte8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vrem_byte(left, right);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                return Operator.vrem_byte_SSE_FALLBACK(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new byte8(Operator.vrem_byte(left.v4_0, right.v4_0), Operator.vrem_byte(left.v4_4, right.v4_4));
            }
            else
            {
                return new byte8((byte)(left.x0 % right.x0), (byte)(left.x1 % right.x1), (byte)(left.x2 % right.x2), (byte)(left.x3 % right.x3), (byte)(left.x4 % right.x4), (byte)(left.x5 % right.x5), (byte)(left.x6 % right.x6), (byte)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte left, byte8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte8 left, byte right) => new byte8((byte)(left.x0 * right), (byte)(left.x1 * right), (byte)(left.x2 * right), (byte)(left.x3 * right), (byte)(left.x4 * right), (byte)(left.x5 * right), (byte)(left.x6 * right), (byte)(left.x7 * right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 left, byte right) => new byte8((byte)(left.x0 / right), (byte)(left.x1 / right), (byte)(left.x2 / right), (byte)(left.x3 / right), (byte)(left.x4 / right), (byte)(left.x5 / right), (byte)(left.x6 / right), (byte)(left.x7 / right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 left, byte right) => new byte8((byte)(left.x0 % right), (byte)(left.x1 % right), (byte)(left.x2 % right), (byte)(left.x3 % right), (byte)(left.x4 % right), (byte)(left.x5 % right), (byte)(left.x6 % right), (byte)(left.x7 % right));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator & (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 & right.x0), (byte)(left.x1 & right.x1), (byte)(left.x2 & right.x2), (byte)(left.x3 & right.x3), (byte)(left.x4 & right.x4), (byte)(left.x5 & right.x5), (byte)(left.x6 & right.x6), (byte)(left.x7 & right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator | (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 | right.x0), (byte)(left.x1 | right.x1), (byte)(left.x2 | right.x2), (byte)(left.x3 | right.x3), (byte)(left.x4 | right.x4), (byte)(left.x5 | right.x5), (byte)(left.x6 | right.x6), (byte)(left.x7 | right.x7));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ^ (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 ^ right.x0), (byte)(left.x1 ^ right.x1), (byte)(left.x2 ^ right.x2), (byte)(left.x3 ^ right.x3), (byte)(left.x4 ^ right.x4), (byte)(left.x5 ^ right.x5), (byte)(left.x6 ^ right.x6), (byte)(left.x7 ^ right.x7));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ++ (byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, new byte8(1));
            }
            else
            {
                return new byte8((byte)(x.x0 + 1), (byte)(x.x1 + 1), (byte)(x.x2 + 1), (byte)(x.x3 + 1), (byte)(x.x4 + 1), (byte)(x.x5 + 1), (byte)(x.x6 + 1), (byte)(x.x7 + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator -- (byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, new byte8(1));
            }
            else
            {
                return new byte8((byte)(x.x0 - 1), (byte)(x.x1 - 1), (byte)(x.x2 - 1), (byte)(x.x3 - 1), (byte)(x.x4 - 1), (byte)(x.x5 - 1), (byte)(x.x6 - 1), (byte)(x.x7 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ~ (byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(x, new sbyte8(-1));
            }
            else
            {
                return new byte8((byte)(~x.x0), (byte)(~x.x1), (byte)(~x.x2), (byte)(~x.x3), (byte)(~x.x4), (byte)(~x.x5), (byte)(~x.x6), (byte)(~x.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator << (byte8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new byte8((byte)(x.x0 << n), (byte)(x.x1 << n), (byte)(x.x2 << n), (byte)(x.x3 << n), (byte)(x.x4 << n), (byte)(x.x5 << n), (byte)(x.x6 << n), (byte)(x.x7 << n));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator >> (byte8 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_byte(x, n);
            }
            else
            {
                return new byte8((byte)(x.x0 >> n), (byte)(x.x1 >> n), (byte)(x.x2 >> n), (byte)(x.x3 >> n), (byte)(x.x4 >> n), (byte)(x.x5 >> n), (byte)(x.x6 >> n), (byte)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(right, left));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(left, right));
            }
            else
            {
                return new bool8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.min_epu8(left, right), left));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.max_epu8(left, right), left));
            }
            else
            {
                return new bool8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsTrue(v128 input) 
        {
            return (v128)(-((sbyte16)input));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool8 TestIsFalse(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(input, new byte8(1));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte8 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return ulong.MaxValue == Sse2.cmpeq_epi8(this, other).ULong0;
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override readonly bool Equals(object obj) => Equals((byte8)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v64(this);
            }
            else
            {
                byte8 temp = this;

                return (*(ulong*)&temp).GetHashCode();
            }
        }


        public override readonly string ToString() => $"byte8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}