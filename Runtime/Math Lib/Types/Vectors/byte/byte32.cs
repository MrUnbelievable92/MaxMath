using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class byte32DebuggerProxy
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
        
        public byte32DebuggerProxy(byte32 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(byte32DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct byte32 : IEquatable<byte32>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal byte16 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal byte16 __x16;

        public ref byte x0  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  0); } } }
        public ref byte x1  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  1); } } }
        public ref byte x2  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  2); } } }
        public ref byte x3  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  3); } } }
        public ref byte x4  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  4); } } }
        public ref byte x5  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  5); } } }
        public ref byte x6  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  6); } } }
        public ref byte x7  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  7); } } }
        public ref byte x8  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  8); } } }
        public ref byte x9  { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr +  9); } } }
        public ref byte x10 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 10); } } }
        public ref byte x11 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 11); } } }
        public ref byte x12 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 12); } } }
        public ref byte x13 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 13); } } }
        public ref byte x14 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 14); } } }
        public ref byte x15 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 15); } } }
        public ref byte x16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 16); } } }
        public ref byte x17 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 17); } } }
        public ref byte x18 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 18); } } }
        public ref byte x19 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 19); } } }
        public ref byte x20 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 20); } } }
        public ref byte x21 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 21); } } }
        public ref byte x22 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 22); } } }
        public ref byte x23 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 23); } } }
        public ref byte x24 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 24); } } }
        public ref byte x25 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 25); } } }
        public ref byte x26 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 26); } } }
        public ref byte x27 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 27); } } }
        public ref byte x28 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 28); } } }
        public ref byte x29 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 29); } } }
        public ref byte x30 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 30); } } }
        public ref byte x31 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte32* ptr = &this) { return ref *((byte*)ptr + 31); } } }


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
                    __x0 = new byte16(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15),
                    __x16 = new byte16(x16, x17, x18, x19, x20, x21, x22, x23, x24, x25, x26, x27, x28, x29, x30, x31)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte x0x32)
        {
            if (Avx.IsAvxSupported)
            {
                this = Xse.mm256_set1_epi8(x0x32);
            }
            else
            {
                this = new byte32
                {
                    __x0 = new byte16(x0x32),
                    __x16 = new byte16(x0x32)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte4 x0_3, byte4 x4_7, byte4 x8_11, byte4 x12_15, byte4 x16_19, byte4 x20_23, byte4 x24_27, byte4 x28_31)
        {
            this = new byte32(new byte16(x0_3, x4_7, x8_11, x12_15), new byte16(x16_19, x20_23, x24_27, x28_31));
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
            this = new byte32(new byte16(v8_0, v16_8.v8_0), new byte16(v16_8.v8_8, v8_24));
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
                    __x0 = v16_0,
                    __x16 = v16_16
                };
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(bool v)
        {
            this = (byte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(bool32 v)
        {
            this = (byte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(mask8x32 v)
        {
            this = (byte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(byte32 v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(sbyte v)
        {
            this = (byte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(sbyte32 v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(ushort v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(short v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(uint v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(int v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(ulong v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(long v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(UInt128 v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(Int128 v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(quarter v)
        {
            this = (byte32)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(quarter32 v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(half v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(float v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(double v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(quadruple v)
        {
            this = (byte32)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte32(Unity.Mathematics.half v)
        {
            this = (byte32)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_0
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return __x0;
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
                    this.__x0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_1
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 1 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(__x0,  sizeof(byte)),
                                            Xse.bslli_si128(__x16, 15 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, sizeof(byte)), Xse.bsrli_si128(value, 15 * sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value,      sizeof(byte)), new v128(0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value, 15 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_2
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 2 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 2 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(__x0,   2 * sizeof(byte)),
                                           Xse.bslli_si128(__x16, 14 * sizeof(byte)),
                                           0b1000_0000);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 2 * sizeof(byte)), Xse.bsrli_si128(value, 14 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value,  2 * sizeof(byte)), 0b1111_1110);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value, 14 * sizeof(byte)), 0b0000_0001);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_3
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 3 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(v16_0,   3 * sizeof(byte)),
                                            Xse.bslli_si128(v16_16, 13 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 3 * sizeof(byte)), Xse.bsrli_si128(value, 13 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value,  3 * sizeof(byte)), new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value, 13 * sizeof(byte)), new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_4
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 4 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 4 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(__x0,   4 * sizeof(byte)),
                                           Xse.bslli_si128(__x16, 12 * sizeof(byte)),
                                           0b1100_0000);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 4 * sizeof(byte)), Xse.bsrli_si128(value, 12 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0001_1110);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value,  4 * sizeof(byte)), 0b1111_1100);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value, 12 * sizeof(byte)), 0b0000_0011);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_5
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 5 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 5 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(v16_0,   5 * sizeof(byte)),
                                            Xse.bslli_si128(v16_16, 11 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 5 * sizeof(byte)), Xse.bsrli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value,  5 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value, 11 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_6
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 6 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 6 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(v16_0,   6 * sizeof(byte)),
                                           Xse.bslli_si128(v16_16, 10 * sizeof(byte)),
                                           0b1110_0000);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 6 * sizeof(byte)), Xse.bsrli_si128(value, 10 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value,  6 * sizeof(byte)), 0b1111_1000);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value, 10 * sizeof(byte)), 0b0000_0111);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_7
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 7 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 7 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(v16_0,  7 * sizeof(byte)),
                                            Xse.bslli_si128(v16_16, 9 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 7 * sizeof(byte)), Xse.bsrli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value,  7 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value,  9 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_8
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 1)));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 8 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.unpacklo_epi64(Xse.bsrli_si128(__x0,  8 * sizeof(byte)), __x16);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 8 * sizeof(byte)), Xse.bsrli_si128(value, 8 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0011_1100);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value,  8 * sizeof(byte)), 0b1111_0000);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value,  8 * sizeof(byte)), 0b0000_1111);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_9
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 9 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 9 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(v16_0,  9 * sizeof(byte)),
                                       Xse.bslli_si128(v16_16, 7 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 9 * sizeof(byte)), Xse.bsrli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value,  9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value,  7 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_10
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 10 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 10 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(v16_0, 10 * sizeof(byte)),
                                           Xse.bslli_si128(v16_16, 6 * sizeof(byte)),
                                           0b1111_1000);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 10 * sizeof(byte)), Xse.bsrli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value, 10 * sizeof(byte)), 0b1110_0000);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value,  6 * sizeof(byte)), 0b0001_1111);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_11
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 11 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 11 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(v16_0,  11 * sizeof(byte)),
                                       Xse.bslli_si128(v16_16, 5 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 11 * sizeof(byte)), Xse.bsrli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value,  5 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_12
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 12 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 12 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(__x0, 12 * sizeof(byte)),
                                                Xse.bslli_si128(__x16, 4 * sizeof(byte)),
                                                0b1111_1100);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 12 * sizeof(byte)), Xse.bsrli_si128(value, 4 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0111_1000);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value, 12 * sizeof(byte)), 0b1100_0000);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value,  4 * sizeof(byte)), 0b0011_1111);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_13
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 13 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 13 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(v16_0,  13 * sizeof(byte)),
                                            Xse.bslli_si128(v16_16, 3 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 13 * sizeof(byte)), Xse.bsrli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value,  3 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_14
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(__x0, 14 * sizeof(byte)),
                                           Xse.bslli_si128(__x16, 2 * sizeof(byte)),
                                           0b1111_1110);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 14 * sizeof(byte)), Xse.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blend_epi16(__x0,  Xse.bslli_si128(value, 14 * sizeof(byte)), 0b1000_0000);
                    this.__x16 = Xse.blend_epi16(__x16, Xse.bsrli_si128(value,  2 * sizeof(byte)), 0b0111_1111);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_15
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(__x0,  15 * sizeof(byte)),
                                            Xse.bslli_si128(__x16, sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 15 * sizeof(byte)), Xse.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(__x0,  Xse.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this.__x16 = Xse.blendv_si128(__x16, Xse.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte16 v16_16
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return __x16;
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
                    this.__x16 = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_0
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_0;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(value), 0b0000_0011);
                }
                else
                {
                    this.__x0.v8_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_1
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v8_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_2
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v8_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_3
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v8_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_4
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_4;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 4 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0000_0110);
                }
                else
                {
                    this.__x0.v8_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_5
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v8_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_6
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_6;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v8_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_7
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v8_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_8
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v8_8;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 8 * sizeof(byte))), 0b0000_1100);
                }
                else
                {
                    this.__x0.v8_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_9
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 9 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 9 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(__x0,  9 * sizeof(byte)),
                                            Xse.bslli_si128(__x16, 7 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 9 * sizeof(byte)), Xse.bsrli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 9 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value, 7 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_10
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 10 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 10 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blend_epi16(Xse.bsrli_si128(__x0, 10 * sizeof(byte)),
                                           Xse.bslli_si128(__x16, 6 * sizeof(byte)),
                                           0b1111_1000);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 10 * sizeof(byte)), Xse.bsrli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 10 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  6 * sizeof(byte)), new v128(255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_11
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 11 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 11 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
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
                    v256 blend = new v256(Xse.bslli_si128(value, 11 * sizeof(byte)), Xse.bsrli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 11 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  5 * sizeof(byte)), new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_12
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 12 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 12 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.unpacklo_epi32(Xse.bsrli_si128(__x0, 12 * sizeof(byte)), __x16);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 12 * sizeof(byte)), Xse.bsrli_si128(value, 4 * sizeof(byte)));

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0001_1000);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 12 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  4 * sizeof(byte)), new v128(255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_13
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 13 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 13 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
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
                    v256 blend = new v256(Xse.bslli_si128(value, 13 * sizeof(byte)), Xse.bsrli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  3 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_14
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
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
                    v256 blend = new v256(Xse.bslli_si128(value, 14 * sizeof(byte)), Xse.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  2 * sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_15
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
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
                    v256 blend = new v256(Xse.bslli_si128(value, 15 * sizeof(byte)), Xse.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_16
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v8_0;
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
                    this.__x16.v8_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_17
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Xse.bsrli_si128(perm, sizeof(byte));
                }
                else
                {
                    return v16_16.v8_1;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v8_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_18
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Xse.bsrli_si128(perm, 2 * sizeof(byte));
                }
                else
                {
                    return v16_16.v8_2;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 2 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v8_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_19
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Xse.bsrli_si128(perm, 3 * sizeof(byte));
                }
                else
                {
                    return v16_16.v8_3;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v8_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_20
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 4 * sizeof(byte));
                }
                else
                {
                    return v16_16.v8_4;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 4 * sizeof(byte)), 1);

                    this = Avx2.mm256_blend_epi32(this, blend, 0b0110_0000);
                }
                else
                {
                    this.__x16.v8_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_21
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Xse.bsrli_si128(perm, 5 * sizeof(byte));
                }
                else
                {
                    return v16_16.v8_5;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v8_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_22
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Xse.bsrli_si128(perm, 6 * sizeof(byte));
                }
                else
                {
                    return v16_16.v8_6;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 6 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v8_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_23
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    v128 perm = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)));

                    return Xse.bsrli_si128(perm, 7 * sizeof(byte));
                }
                else
                {
                    return v16_16.v8_7;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v8_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte8 v8_24
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return v16_16.v8_8;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 3);
                }
                else
                {
                    this.__x16.v8_8 = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_0
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_0;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(value), 0b0000_0001);
                }
                else
                {
                    this.__x0.v4_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_1
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_2
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_3
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_4
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_4;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 4 * sizeof(byte))), 0b0000_0010);
                }
                else
                {
                    this.__x0.v4_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_5
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_6
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_6;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_7
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_8
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_8;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 8 * sizeof(byte))), 0b0000_0100);
                }
                else
                {
                    this.__x0.v4_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_9
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_9;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_9 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_10
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_10;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 10 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_10 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_11
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_11;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v4_11 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_12
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v4_12;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 12 * sizeof(byte))), 0b0000_1000);
                }
                else
                {
                    this.__x0.v4_12 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_13
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 13 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 13 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(__x0,  13 * sizeof(byte)),
                                            Xse.bslli_si128(__x16, 3 * sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 13 * sizeof(byte)), Xse.bsrli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 13 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  3 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_14
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.unpacklo_epi16(Xse.bsrli_si128(__x0,  14 * sizeof(byte)), __x16);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 14 * sizeof(byte)), Xse.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  2 * sizeof(byte)), new v128(255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_15
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(__x0,  15 * sizeof(byte)),
                                            Xse.bslli_si128(__x16, sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 15 * sizeof(byte)), Xse.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_16
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return v16_16.v4_0;
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
                    this.__x16.v4_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_17
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_18
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 2 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_19
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_20
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 5);

                    return *(byte4*)&temp;
                }
                else
                {
                    return v16_16.v4_4;
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
                    this.__x16.v4_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_21
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_22
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_6;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 6 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_23
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_24
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return v16_16.v4_8;
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
                    this.__x16.v4_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_25
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_9;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 9 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_9 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_26
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_10;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 10 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_10 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_27
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v4_11;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 11 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v4_11 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 v4_28
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 7);

                    return *(byte4*)&temp;
                }
                else
                {
                    return v16_16.v4_12;
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
                    this.__x16.v4_12 = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_0
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_0;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(value);
                    v256 mask = new v256(255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_1
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_2
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_3
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_4
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_4;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 4 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_5
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_6
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_6;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 6 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_7
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_8
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_8;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 8 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_9
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_9;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_9 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_10
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_10;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 10 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_10 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_11
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_11;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_11 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_12
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_12;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 12 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_12 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_13
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v3_13;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 13 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v3_13 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_14
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 14 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.unpacklo_epi16(Xse.bsrli_si128(__x0,  14 * sizeof(byte)), __x16);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 14 * sizeof(byte)), Xse.bsrli_si128(value, 2 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 14 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,  2 * sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x14 = value.x;
                    this.x15 = value.y;
                    this.x16 = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_15
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.blendv_si128(Xse.bsrli_si128(__x0,  15 * sizeof(byte)),
                                            Xse.bslli_si128(__x16, sizeof(byte)),
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
                    v256 blend = new v256(Xse.bslli_si128(value, 15 * sizeof(byte)), Xse.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,      sizeof(byte)), new v128(255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x15 = value.x;
                    this.x16 = value.y;
                    this.x17 = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_16
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return v16_16.v3_0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), value, 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_17
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 1 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_18
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 2 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_19
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_20
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 5);

                    return *(byte3*)&temp;
                }
                else
                {
                    return v16_16.v3_4;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 4 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_21
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_22
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_6;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 6 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_23
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_24
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return v16_16.v3_8;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 8 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_25
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_9;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 9 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_9 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_26
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_10;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 10 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_10 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_27
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_11;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 11 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_11 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_28
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx.IsAvxSupported)
                {
                    int temp = Avx.mm256_extract_epi32(this, 7);

                    return *(byte3*)&temp;
                }
                else
                {
                    return v16_16.v3_12;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 12 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_12 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 v3_29
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v3_13;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(Avx.mm256_setzero_si256(), Xse.bslli_si128(value, 13 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v3_13 = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_0
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_0;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 0);
                }
                else
                {
                    this.__x0.v2_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_1
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_2
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_2;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 1);
                }
                else
                {
                    this.__x0.v2_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_3
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 3 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_4
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_4;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 2);
                }
                else
                {
                    this.__x0.v2_4 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_5
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 5 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_6
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_6;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 3);
                }
                else
                {
                    this.__x0.v2_6 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_7
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 7 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_8
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_8;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 4);
                }
                else
                {
                    this.__x0.v2_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_9
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_9;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 9 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_9 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_10
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_10;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 5);
                }
                else
                {
                    this.__x0.v2_10 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_11
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_11;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 11 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_11 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_12
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_12;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 6);
                }
                else
                {
                    this.__x0.v2_12 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_13
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_13;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx.mm256_castsi128_si256(Xse.bslli_si128(value, 13 * sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x0.v2_13 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_14
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_0.v2_14;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 7);
                }
                else
                {
                    this.__x0.v2_14 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_15
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    return Xse.alignr_epi8(this.__x0, this.__x16, 15 * sizeof(byte));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.unpacklo_epi8(Xse.bsrli_si128(__x0, 15 * sizeof(byte)), __x16);
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
                    v256 blend = new v256(Xse.bslli_si128(value, 15 * sizeof(byte)), Xse.bsrli_si128(value, sizeof(byte)));
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x0  = Xse.blendv_si128(this.__x0,  Xse.bslli_si128(value, 15 * sizeof(byte)), new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255));
                    this.__x16 = Xse.blendv_si128(this.__x16, Xse.bsrli_si128(value,      sizeof(byte)), new v128(255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                }
                else
                {
                    this.x15 = value.x;
                    this.x16 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_16
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return v16_16.v2_0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 8);
                }
                else
                {
                    this.__x16.v2_0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_17
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v2_1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_1 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_18
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 9);

                    return *(byte2*)&temp;
                }
                else
                {
                    return v16_16.v2_2;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 9);
                }
                else
                {
                    this.__x16.v2_2 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_19
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v2_3;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, 3 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_3 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_20
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 10);

                    return *(byte2*)&temp;
                }
                else
                {
                    return v16_16.v2_4;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 10);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x16 = Xse.insert_epi16(this.__x16, *(ushort*)&value, 2);
                }
                else
                {
                    this.x20 = value.x;
                    this.x21 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_21
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v2_5;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, 5 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_5 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_22
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 11);

                    return *(byte2*)&temp;
                }
                else
                {
                    return v16_16.v2_6;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 11);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    this.__x16 = Xse.insert_epi16(this.__x16, *(ushort*)&value, 3);
                }
                else
                {
                    this.x22 = value.x;
                    this.x23 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_23
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v2_7;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, 7 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_7 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_24
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return v16_16.v2_8;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 12);
                }
                else
                {
                    this.__x16.v2_8 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_25
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v2_9;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, 9 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_9 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_26
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 13);

                    return *(byte2*)&temp;
                }
                else
                {
                    return v16_16.v2_10;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 13);
                }
                else
                {
                    this.__x16.v2_10 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_27
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
            {
                return v16_16.v2_11;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, 11 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0, 0, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_11 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_28
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 14);

                    return *(byte2*)&temp;
                }
                else
                {
                    return v16_16.v2_12;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 14);
                }
                else
                {
                    this.__x16.v2_12 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_29
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                return v16_16.v2_13;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 blend = Avx2.mm256_inserti128_si256(default, Xse.bslli_si128(value, 13 * sizeof(byte)), 1);
                    v256 mask = new v256(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 0);

                    this = Xse.mm256_blendv_si256(this, blend, mask);
                }
                else
                {
                    this.__x16.v2_13 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 v2_30
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Avx2.IsAvx2Supported)
                {
                    int temp = Avx2.mm256_extract_epi16(this, 15);

                    return *(byte2*)&temp;
                }
                else
                {
                    return v16_16.v2_14;
                }
			}

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Xse.mm256_insert_epi16(this, *(ushort*)&value, 15);
                }
                else
                {
                    this.__x16.v2_14 = value;
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(byte32 input)
        {
            v256 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.mm256_undefined_si256();
            }
            else
            {
                result = Uninitialized<v256>.Create();
            }

            result.ULong0 = input.__x0.__x0;
            result.ULong1 = input.__x0.__x8;
            result.ULong2 = input.__x16.__x0;
            result.ULong3 = input.__x16.__x8;

            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte32(v256 input) => new byte32 { __x0 = new byte16 { __x0 = input.ULong0, __x8 = input.ULong1 }, __x16 = new byte16 { __x0 = input.ULong2, __x8 = input.ULong3 } };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(bool32 x) => (byte32)(mask8x32)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(mask8x32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi8(x);
            }
            else
            {
                return new byte32((byte16)x.v16_0, (byte16)x.v16_16);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool32(byte32 x) => (mask8x32)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x32(byte32 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(sbyte x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(ushort x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(short x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(uint x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(int x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(ulong x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(long x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(UInt128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(Int128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(quarter x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(half x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(float x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(double x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(quadruple x) => (byte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(Unity.Mathematics.half x) => (byte32)(half)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte32(byte input) => new byte32(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte32(sbyte32 input) => *(byte32*)&input;


        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 32);

                if (constexpr.IS_CONST(index))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_extract_epi8(this, (byte)index);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (index < 16)
                        {
                            return Xse.extract_epi8(__x0, (byte)index);
                        }
                        else
                        {
                            return Xse.extract_epi8(__x16, (byte)(index - 16));
                        }
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte32* ptr = &this)
                    {
                        return ((byte*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<byte32, byte>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 32);

                if (constexpr.IS_CONST(index))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        this = Xse.mm256_insert_epi8(this, value, (byte)index);

                        return;
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (index < 16)
                        {
                            __x0 = Xse.insert_epi8(__x0, value, (byte)index);
                        }
                        else
                        {
                            __x16 = Xse.insert_epi8(__x16, value, (byte)(index - 16));
                        }

                        return;
                    }
                }


                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte32* ptr = &this)
                    {
                        ((byte*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
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
                return new byte32(left.__x0 + right.__x0, left.__x16 + right.__x16);
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
                return new byte32(left.__x0 - right.__x0, left.__x16 - right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (all_eq(right))
                    {
                        return left * right.x0;
                    }
                    else if (all(ispow2(right)))
                    {
                        return shl(left, tzcnt(right));
                    }
                }
                if (constexpr.IS_CONST(left))
                {
                    if (all_eq(left))
                    {
                        return right * left.x0;
                    }
                    else if (all(ispow2(left)))
                    {
                        return shl(right, tzcnt(left));
                    }
                }

                return Xse.mm256_mullo_epi8(left, right);
            }
            else
            {
                return new byte32(left.__x0 * right.__x0, left.__x16 * right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epu8(left, right);
            }
            else
            {
                return new byte32(left.__x0 / right.__x0, left.__x16 / right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epu8(left, right);
            }
            else
            {
                return new byte32(left.__x0 % right.__x0, left.__x16 % right.__x16);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator + (byte32 left, byte right) => left + (byte32)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator + (byte left, byte32 right) => (byte32)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator - (byte32 left, byte right) => left - (byte32)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator - (byte left, byte32 right) => (byte32)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte left, byte32 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator * (byte32 left, byte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constmullo_epu8(left, right);
                }
                else
                {
                    return Xse.mm256_mullo_epi8(left, Xse.mm256_set1_epi8(right));
                }
            }

            return new byte32(left.v16_0 * right, left.v16_16 * right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte32 left, byte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.mm256_constdiv_epu8(left, right);
                }
                else
                {
                    return Xse.mm256_div_epu8(left, Xse.mm256_set1_epi8(right));
                }
            }

            return new byte32(left.v16_0 / right, left.v16_16 / right);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator / (byte left, byte32 right) => (byte32)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte32 left, byte right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.mm256_constrem_epu8(left, right);
                }
                else
                {
                    return Xse.mm256_rem_epu8(left, Xse.mm256_set1_epi8(right));
                }
            }

            return new byte32(left.v16_0 % right, left.v16_16 % right);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator % (byte left, byte32 right) => (byte32)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator & (byte32 left, byte32 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(left, right);
            }
            else
            {
                return new byte32(left.__x0 & right.__x0, left.__x16 & right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator | (byte32 left, byte32 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_or_ps(left, right);
            }
            else
            {
                return new byte32(left.__x0 | right.__x0, left.__x16 | right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ^ (byte32 left, byte32 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_xor_ps(left, right);
            }
            else
            {
                return new byte32(left.__x0 ^ right.__x0, left.__x16 ^ right.__x16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ++ (byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi8(x);
            }
            else
            {
                return new byte32(x.__x0 + 1, x.__x16 + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator -- (byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi8(x);
            }
            else
            {
                return new byte32(x.__x0 - 1, x.__x16 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator ~ (byte32 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_not_si256(x);
            }
            else
            {
                return new byte32(~x.__x0, ~x.__x16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator << (byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_slli_epi8(x, n);
            }
            else
            {
                return new byte32(x.__x0 << n, x.__x16 << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 operator >> (byte32 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi8(x, n);
            }
            else
            {
                return new byte32(x.__x0 >> n, x.__x16 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator == (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cmpeq_epi8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 == right.__x0, left.__x16 == right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator < (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmplt_epu8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 < right.__x0, left.__x16 < right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator > (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmpgt_epu8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 > right.__x0, left.__x16 > right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator != (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi8(left, right));
            }
            else
            {
                return new mask8x32(left.__x0 != right.__x0, left.__x16 != right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator <= (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmple_epu8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 <= right.__x0, left.__x16 <= right.__x16);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 operator >= (byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmpge_epu8(left, right);
            }
            else
            {
                return new mask8x32(left.__x0 >= right.__x0, left.__x16 >= right.__x16);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte32 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<byte>(Avx2.mm256_cmpeq_epi8(this, other));
            }
            else
            {
                return this.__x0.Equals(other.__x0) & this.__x16.Equals(other.__x16);
            }
        }

        public override readonly bool Equals(object obj) => obj is byte32 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() =>  $"byte32({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7},    {x8}, {x9}, {x10}, {x11},    {x12}, {x13}, {x14}, {x15},    {x16}, {x17}, {x18}, {x19},    {x20}, {x21}, {x22}, {x23},    {x24}, {x25}, {x26}, {x27},    {x28}, {x29}, {x30}, {x31})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte32({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)},    {x8.ToString(format, formatProvider)}, {x9.ToString(format, formatProvider)}, {x10.ToString(format, formatProvider)}, {x11.ToString(format, formatProvider)},    {x12.ToString(format, formatProvider)}, {x13.ToString(format, formatProvider)}, {x14.ToString(format, formatProvider)}, {x15.ToString(format, formatProvider)},    {x16.ToString(format, formatProvider)}, {x17.ToString(format, formatProvider)}, {x18.ToString(format, formatProvider)}, {x19.ToString(format, formatProvider)},    {x20.ToString(format, formatProvider)}, {x21.ToString(format, formatProvider)}, {x22.ToString(format, formatProvider)}, {x23.ToString(format, formatProvider)},    {x24.ToString(format, formatProvider)}, {x25.ToString(format, formatProvider)}, {x26.ToString(format, formatProvider)}, {x27.ToString(format, formatProvider)},    {x28.ToString(format, formatProvider)}, {x29.ToString(format, formatProvider)}, {x30.ToString(format, formatProvider)}, {x31.ToString(format, formatProvider)})";
    }
}