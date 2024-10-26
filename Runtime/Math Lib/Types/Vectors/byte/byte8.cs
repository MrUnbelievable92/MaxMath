using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 8 * sizeof(byte))]
    [DebuggerTypeProxy(typeof(byte8.DebuggerProxy))]
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
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(x0) && constexpr.IS_CONST(x1) && constexpr.IS_CONST(x2) && constexpr.IS_CONST(x3) && constexpr.IS_CONST(x4) && constexpr.IS_CONST(x5) && constexpr.IS_CONST(x6) && constexpr.IS_CONST(x7))
                {
					this = Xse.cvtsi64x_si128(maxmath.bitfield(x0, x1, x2, x3, x4, x5, x6, x7));
                }
				else
				{
                    this = Xse.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, (sbyte)x7, (sbyte)x6, (sbyte)x5, (sbyte)x4, (sbyte)x3, (sbyte)x2, (sbyte)x1, (sbyte)x0);
				}
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
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(x0x8))
                {
					this = Xse.cvtsi64x_si128(maxmath.bitfield(x0x8, x0x8, x0x8, x0x8, x0x8, x0x8, x0x8, x0x8));
                }
				else
				{
					this = Xse.set1_epi8(x0x8, 8);
				}
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
            {
                v128 mid = Xse.bslli_si128(x234, 2 * sizeof(byte));
                v128 hi  = Xse.bslli_si128(x567, 5 * sizeof(byte));

                hi = Xse.blendv_si128(mid, hi, new byte8(0, 0, 0, 0, 0, 255, 255, 255));

                this = Xse.blend_epi16(x01, hi, 0b1110);
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
            if (Architecture.IsSIMDSupported)
            {
                v128 hi = Xse.bslli_si128(x567, 2 * sizeof(byte));
                hi = Xse.blend_epi16(x34, hi, 0b0110);
                hi = Xse.bslli_si128(hi, 3 * sizeof(byte));

                this = Xse.blendv_si128(x012, hi, new byte8(0, 0, 0, 255, 255, 255, 255, 255));
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
            if (Architecture.IsSIMDSupported)
            {
                v128 mid = Xse.bslli_si128(x345, 3 * sizeof(byte));
                v128 hi  = Xse.bslli_si128(x67,  6 * sizeof(byte));

                mid = Xse.blendv_si128(x012, mid, new byte8(0, 0, 0, 255, 255, 255, 0, 0));

                this = Xse.blend_epi16(mid, hi, 0b1000);
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
            {
                this = new byte8((byte4)Xse.unpacklo_epi16(x01, x2345),
                                 (byte4)Xse.unpacklo_epi16(Xse.bsrli_si128(x2345, 2 * sizeof(byte)), x67));
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
            {
                this = Xse.unpacklo_epi32(x0123, x4567);
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
                if (Architecture.IsSIMDSupported)
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
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value, 0b0011);
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 1 * sizeof(byte)), new byte8(0, 255, 255, 255, 255, 0, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 2 * sizeof(byte)), 0b0110);
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 3 * sizeof(byte));
                }
                else
                {
                    return new byte4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 3 * sizeof(byte)), new byte8(0, 0, 0, 255, 255, 255, 255, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.unpacklo_epi32(this, value);
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
                if (Architecture.IsSIMDSupported)
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
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, value, new byte8(255, 255, 255, 0, 0, 0, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 1 * sizeof(byte)), new byte8(0, 255, 255, 255, 0, 0, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 2 * sizeof(byte)), new byte8(0, 0, 255, 255, 255, 0, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 3 * sizeof(byte));
                }
                else
                {
                    return new byte3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 3 * sizeof(byte)), new byte8(0, 0, 0, 255, 255, 255, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 4 * sizeof(byte)), new byte8(0, 0, 0, 0, 255, 255, 255, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 5 * sizeof(byte));
                }
                else
                {
                    return new byte3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 5 * sizeof(byte)), new byte8(0, 0, 0, 0, 0, 255, 255, 255));
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
                if (Architecture.IsSIMDSupported)
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
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value, 0b0001);
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 1 * sizeof(byte));
                }
                else
                {
                    return new byte2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 1 * sizeof(byte)), new byte8(0, 255, 255, 0, 0, 0, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 2 * sizeof(byte));
                }
                else
                {
                    return new byte2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 1);
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 3 * sizeof(byte));
                }
                else
                {
                    return new byte2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 3 * sizeof(byte)), new byte8(0, 0, 0, 255, 255, 0, 0, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 4 * sizeof(byte));
                }
                else
                {
                    return new byte2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 2);
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 5 * sizeof(byte));
                }
                else
                {
                    return new byte2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.blendv_si128(this, Xse.bslli_si128(value, 5 * sizeof(byte)), new byte8(0, 0, 0, 0, 0, 255, 255, 0));
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
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 6 * sizeof(byte));
                }
                else
                {
                    return new byte2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.insert_epi16(this, *(ushort*)&value, 3);
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
        public static implicit operator v128(byte8 input)
        {
            v128 result;

            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = default(v128);
            }

            result.Byte0 = input.x0;
            result.Byte1 = input.x1;
            result.Byte2 = input.x2;
            result.Byte3 = input.x3;
            result.Byte4 = input.x4;
            result.Byte5 = input.x5;
            result.Byte6 = input.x6;
            result.Byte7 = input.x7;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte8(v128 input)
        {
            byte8 result;

            result.x0 = input.Byte0;
            result.x1 = input.Byte1;
            result.x2 = input.Byte2;
            result.x3 = input.Byte3;
            result.x4 = input.Byte4;
            result.x5 = input.Byte5;
            result.x6 = input.Byte6;
            result.x7 = input.Byte7;

            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte8(byte input) => new byte8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(sbyte8 input) => *(byte8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(ushort8 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(input);
            }
            else
            {
                return new byte8((byte)input.x0, (byte)input.x1, (byte)input.x2, (byte)input.x3, (byte)input.x4, (byte)input.x5, (byte)input.x6, (byte)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(short8 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(input);
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
                return Xse.mm256_cvtepi32_epi8(input);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return Cast.Int8To_S_Byte8_SSE2(RegisterConversion.ToV128(input._v4_0), RegisterConversion.ToV128(input._v4_4));
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
                return Xse.mm256_cvtepi32_epi8(input);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return Cast.Int8To_S_Byte8_SSE2(RegisterConversion.ToV128(input._v4_0), RegisterConversion.ToV128(input._v4_4));
            }
            else
            {
                return new byte8((byte4)input._v4_0, (byte4)input._v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(half8 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(input);
            }
            else
            {
                return new byte8((byte)maxmath.BASE_cvtf16i32(input.x0, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x1, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x2, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x3, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x4, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x5, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x6, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.x7, signed: false, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte8(float8 input) => (byte8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(byte8 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi16(input);
            }
            else
            {
                return new ushort8((ushort)input.x0, (ushort)input.x1, (ushort)input.x2, (ushort)input.x3, (ushort)input.x4, (ushort)input.x5, (ushort)input.x6, (ushort)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short8(byte8 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi16(input);
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
        public static implicit operator float8(byte8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                ;
            }
            else if (Architecture.IsSIMDSupported)
            {
                v128 lo = Xse.cvtepu8_ps(input);
                v128 hi = Xse.cvtepu8_ps(Xse.bsrli_si128(input, 4 * sizeof(byte)));

                return new float8(*(float4*)&lo, *(float4*)&hi);
            }

            return (float8)(int8)input;
        }


        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Architecture.IsSIMDSupported)
                {
                    return Xse.extract_epi8(this, (byte)index);
                }
                else
                {
                    return this.GetField<byte8, byte>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                if (Architecture.IsSIMDSupported)
                {
                    this = Xse.insert_epi8(this, value, (byte)index);
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator + (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.add_epi8(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 + right.x0), (byte)(left.x1 + right.x1), (byte)(left.x2 + right.x2), (byte)(left.x3 + right.x3), (byte)(left.x4 + right.x4), (byte)(left.x5 + right.x5), (byte)(left.x6 + right.x6), (byte)(left.x7 + right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator - (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.sub_epi8(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 - right.x0), (byte)(left.x1 - right.x1), (byte)(left.x2 - right.x2), (byte)(left.x3 - right.x3), (byte)(left.x4 - right.x4), (byte)(left.x5 - right.x5), (byte)(left.x6 - right.x6), (byte)(left.x7 - right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.mullo_epi8(left, right, 8);
            }
            else
            {
                return new byte8((byte)(left.x0 * right.x0), (byte)(left.x1 * right.x1), (byte)(left.x2 * right.x2), (byte)(left.x3 * right.x3), (byte)(left.x4 * right.x4), (byte)(left.x5 * right.x5), (byte)(left.x6 * right.x6), (byte)(left.x7 * right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.div_epu8(left, right, 8);
            }
            else
            {
                return new byte8((byte)(left.x0 / right.x0), (byte)(left.x1 / right.x1), (byte)(left.x2 / right.x2), (byte)(left.x3 / right.x3), (byte)(left.x4 / right.x4), (byte)(left.x5 / right.x5), (byte)(left.x6 / right.x6), (byte)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.rem_epu8(left, right, 8);
            }
            else
            {
                return new byte8((byte)(left.x0 % right.x0), (byte)(left.x1 % right.x1), (byte)(left.x2 % right.x2), (byte)(left.x3 % right.x3), (byte)(left.x4 % right.x4), (byte)(left.x5 % right.x5), (byte)(left.x6 % right.x6), (byte)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte left, byte8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator * (byte8 left, byte right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epu8(left, right, 8);
                }
            }

            return left * (byte8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator / (byte8 left, byte right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constdiv_epu8(left, right, 8);
                }
            }

            return left / (byte8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator % (byte8 left, byte right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constrem_epu8(left, right, 8);
                }
            }

            return left % (byte8)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator & (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 & right.x0), (byte)(left.x1 & right.x1), (byte)(left.x2 & right.x2), (byte)(left.x3 & right.x3), (byte)(left.x4 & right.x4), (byte)(left.x5 & right.x5), (byte)(left.x6 & right.x6), (byte)(left.x7 & right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator | (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 | right.x0), (byte)(left.x1 | right.x1), (byte)(left.x2 | right.x2), (byte)(left.x3 | right.x3), (byte)(left.x4 | right.x4), (byte)(left.x5 | right.x5), (byte)(left.x6 | right.x6), (byte)(left.x7 | right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ^ (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new byte8((byte)(left.x0 ^ right.x0), (byte)(left.x1 ^ right.x1), (byte)(left.x2 ^ right.x2), (byte)(left.x3 ^ right.x3), (byte)(left.x4 ^ right.x4), (byte)(left.x5 ^ right.x5), (byte)(left.x6 ^ right.x6), (byte)(left.x7 ^ right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ++ (byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new byte8((byte)(x.x0 + 1), (byte)(x.x1 + 1), (byte)(x.x2 + 1), (byte)(x.x3 + 1), (byte)(x.x4 + 1), (byte)(x.x5 + 1), (byte)(x.x6 + 1), (byte)(x.x7 + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator -- (byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new byte8((byte)(x.x0 - 1), (byte)(x.x1 - 1), (byte)(x.x2 - 1), (byte)(x.x3 - 1), (byte)(x.x4 - 1), (byte)(x.x5 - 1), (byte)(x.x6 - 1), (byte)(x.x7 - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator ~ (byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new byte8((byte)(~x.x0), (byte)(~x.x1), (byte)(~x.x2), (byte)(~x.x3), (byte)(~x.x4), (byte)(~x.x5), (byte)(~x.x6), (byte)(~x.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator << (byte8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.slli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte8((byte)(x.x0 << n), (byte)(x.x1 << n), (byte)(x.x2 << n), (byte)(x.x3 << n), (byte)(x.x4 << n), (byte)(x.x5 << n), (byte)(x.x6 << n), (byte)(x.x7 << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 operator >> (byte8 x, int n)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.srli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte8((byte)(x.x0 >> n), (byte)(x.x1 >> n), (byte)(x.x2 >> n), (byte)(x.x3 >> n), (byte)(x.x4 >> n), (byte)(x.x5 >> n), (byte)(x.x6 >> n), (byte)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator == (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator < (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmplt_epu8(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator > (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpgt_epu8(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator != (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsFalse8(Xse.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator <= (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmple_epu8(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 operator >= (byte8 left, byte8 right)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Xse.cmpge_epu8(left, right, 8));
            }
            else
            {
                return new bool8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte8 other)
        {
            if (Architecture.IsSIMDSupported)
            {
                return ulong.MaxValue == Xse.cmpeq_epi8(this, other).ULong0;
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override readonly bool Equals(object obj) => obj is byte8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Architecture.IsSIMDSupported)
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