using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class ushort8DebuggerProxy
    {
        public ushort x0;
        public ushort x1;
        public ushort x2;
        public ushort x3;
        public ushort x4;
        public ushort x5;
        public ushort x6;
        public ushort x7;
        
        public ushort8DebuggerProxy(ushort8 v)
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

    [System.Diagnostics.DebuggerTypeProxy(typeof(ushort8DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ushort8 : IEquatable<ushort8>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x4;
        
        public ref ushort x0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 0); } } }
        public ref ushort x1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 1); } } }
        public ref ushort x2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 2); } } }
        public ref ushort x3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 3); } } }
        public ref ushort x4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 4); } } }
        public ref ushort x5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 5); } } }
        public ref ushort x6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 6); } } }
        public ref ushort x7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort8* ptr = &this) { return ref *((ushort*)ptr + 7); } } }


        public static ushort8 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort x0, ushort x1, ushort x2, ushort x3, ushort x4, ushort x5, ushort x6, ushort x7)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set_epi16((short)x7, (short)x6, (short)x5, (short)x4, (short)x3, (short)x2, (short)x1, (short)x0);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set1_epi16(x0x8);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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
            this = new ushort8(new ushort4(x01, x23), new ushort4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort3 x234, ushort3 x567)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Join.v2v3v3_epi16(x01, x234, x567);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Join.v3v2v3_epi16(x012, x34, x567);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Join.v3v3v2_epi16(x012, x345, x67);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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
            this = new ushort8(x0123, new ushort4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort2 x01, ushort4 x2345, ushort2 x67)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Join.v2v4v2_epi16(x01, x2345, x67);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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
            this = new ushort8(new ushort4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort4 x0123, ushort4 x4567)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Join.v4v4_epi16(x0123, x4567);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x4 = Uninitialized<ulong>.Create();

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(bool v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(bool8 v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(mask8x8 v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(mask16x8 v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(mask32x8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(byte v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(byte8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(sbyte v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(sbyte8 v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ushort8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(short v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(short8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(uint v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(uint8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(int v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(int8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(ulong v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(long v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(UInt128 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(Int128 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(quarter v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(quarter8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(half v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(half8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(float v)
        {
            this = (ushort8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(float8 v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(double v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(quadruple v)
        {
            this = (ushort8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort8(Unity.Mathematics.half v)
        {
            this = (ushort8)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 1 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x1, x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 1 * sizeof(ushort)), 0b0001_1110);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 2 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x2, x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 2 * sizeof(ushort)), 0b0011_1100);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 3 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x3, x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 3 * sizeof(ushort)), 0b0111_1000);
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 4 * sizeof(ushort));
                }
                else
                {
                    return new ushort4(x4, x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 4 * sizeof(ushort)), 0b1111_0000);
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


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 v3_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 1 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x1, x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_1110);
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                    this.x3 = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 2 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x2, x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 2 * sizeof(ushort)), 0b0001_1100);
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                    this.x4 = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 3 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x3, x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 3 * sizeof(ushort)), 0b0011_1000);
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                    this.x5 = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 4 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x4, x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 4 * sizeof(ushort)), 0b0111_0000);
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                    this.x6 = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 5 * sizeof(ushort));
                }
                else
                {
                    return new ushort3(x5, x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 5 * sizeof(ushort)), 0b1110_0000);
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                    this.x7 = value.z;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 1 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x1, x2);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 1 * sizeof(ushort)), 0b0000_0110);
                }
                else
                {
                    this.x1 = value.x;
                    this.x2 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 2 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x2, x3);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 2 * sizeof(ushort)), 0b0000_1100);
                }
                else
                {
                    this.x2 = value.x;
                    this.x3 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 3 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x3, x4);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 3 * sizeof(ushort)), 0b0001_1000);
                }
                else
                {
                    this.x3 = value.x;
                    this.x4 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 4 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x4, x5);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 4 * sizeof(ushort)), 0b0011_0000);
                }
                else
                {
                    this.x4 = value.x;
                    this.x5 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 5 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x5, x6);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 5 * sizeof(ushort)), 0b0110_0000);
                }
                else
                {
                    this.x5 = value.x;
                    this.x6 = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, 6 * sizeof(ushort));
                }
                else
                {
                    return new ushort2(x6, x7);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, 6 * sizeof(ushort)), 0b1100_0000);
                }
                else
                {
                    this.x6 = value.x;
                    this.x7 = value.y;
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort8 input)
        {
            v128 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = Uninitialized<v128>.Create();
            }

            result.ULong0 = input.__x0;
            result.ULong1 = input.__x4;

            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(v128 input) => new ushort8{ __x0 = input.ULong0, __x4 = input.ULong1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(bool8 x) => (ushort8)(mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort8)(mask16x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(mask32x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort8)(mask16x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(ushort8 x) => (mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(ushort8 x) => (mask16x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x8(ushort8 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(ushort8 x) => (mask16x8)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ushort8(byte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(sbyte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(short x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(uint x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(int x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(ulong x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(long x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(UInt128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(Int128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(quarter x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(half x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(float x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(double x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(quadruple x) => (ushort)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(Unity.Mathematics.half x) => (ushort8)(half)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort8(ushort input) => new ushort8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(short8 input) => *(ushort8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Cast.Int8To_U_Short8_SSE2(input.__x0, input.__x4);
            }
            else
            {
                return new ushort8((ushort4)input.__x0, (ushort4)input.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(int8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Cast.Int8To_U_Short8_SSE2(input.__x0, input.__x4);
            }
            else
            {
                return new ushort8((ushort4)input.__x0, (ushort4)input.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(half8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(input);
            }
            else
            {
                return new ushort8((ushort)input.x0,
                                   (ushort)input.x1,
                                   (ushort)input.x2,
                                   (ushort)input.x3,
                                   (ushort)input.x4,
                                   (ushort)input.x5,
                                   (ushort)input.x6,
                                   (ushort)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort8(float8 input) => (ushort8)(int8)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(ushort8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Cast.UShort8ToInt8(input);
            }
            else
            {
                return new int8((int4)input.v4_0, (int4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half8(ushort8 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ph(input, (half)float.PositiveInfinity);
            }
            else
            {
                return new half8((half)input.x0, (half)input.x1, (half)input.x2, (half)input.x3, (half)input.x4, (half)input.x5, (half)input.x6, (half)input.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(ushort8 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cvtepu16_ps(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = Xse.cvt2x2epu16_ps(input, out v128 hi);

                return new float8(*(float4*)&lo, *(float4*)&hi);
            }
            else
            {
                return (float8)(int8)input;
            }
        }

        
        public ushort this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (constexpr.IS_CONST(index))
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Xse.extract_epi16(this, (byte)index);
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort8* ptr = &this)
                    {
                        return ((ushort*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<ushort8, ushort>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                if (constexpr.IS_CONST(index))
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        this = Xse.insert_epi16(this, value, (byte)index);
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort8* ptr = &this)
                    {
                        ((ushort*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 + right.x0), (ushort)(left.x1 + right.x1), (ushort)(left.x2 + right.x2), (ushort)(left.x3 + right.x3), (ushort)(left.x4 + right.x4), (ushort)(left.x5 + right.x5), (ushort)(left.x6 + right.x6), (ushort)(left.x7 + right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort left, ushort8 right) => (ushort8)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort8 left, ushort right) => left + (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 - right.x0), (ushort)(left.x1 - right.x1), (ushort)(left.x2 - right.x2), (ushort)(left.x3 - right.x3), (ushort)(left.x4 - right.x4), (ushort)(left.x5 - right.x5), (ushort)(left.x6 - right.x6), (ushort)(left.x7 - right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort left, ushort8 right) => (ushort8)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 left, ushort right) => left - (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi16(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 * right.x0), (ushort)(left.x1 * right.x1), (ushort)(left.x2 * right.x2), (ushort)(left.x3 * right.x3), (ushort)(left.x4 * right.x4), (ushort)(left.x5 * right.x5), (ushort)(left.x6 * right.x6), (ushort)(left.x7 * right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort left, ushort8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new ushort8((ushort)(left.x0 * right), (ushort)(left.x1 * right), (ushort)(left.x2 * right), (ushort)(left.x3 * right), (ushort)(left.x4 * right), (ushort)(left.x5 * right), (ushort)(left.x6 * right), (ushort)(left.x7 * right));
                }
            }

            return left * (ushort8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu16(left, right, 8);
            }
            else
            {
                return new ushort8((ushort)(left.x0 / right.x0), (ushort)(left.x1 / right.x1), (ushort)(left.x2 / right.x2), (ushort)(left.x3 / right.x3), (ushort)(left.x4 / right.x4), (ushort)(left.x5 / right.x5), (ushort)(left.x6 / right.x6), (ushort)(left.x7 / right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, right, 8);
                }
            }

            return left / (ushort8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort left, ushort8 right) => (ushort8)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu16(left, right, 8);
            }
            else
            {
                return new ushort8((ushort)(left.x0 % right.x0), (ushort)(left.x1 % right.x1), (ushort)(left.x2 % right.x2), (ushort)(left.x3 % right.x3), (ushort)(left.x4 % right.x4), (ushort)(left.x5 % right.x5), (ushort)(left.x6 % right.x6), (ushort)(left.x7 % right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, right, 8);
                }
            }

            return left % (ushort8)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort left, ushort8 right) => (ushort8)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort8 left, byte8 right) => left + (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (byte8 left, ushort8 right) => (ushort8)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 left, byte8 right) => left - (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (byte8 left, ushort8 right) => (ushort8)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, byte8 right) => left * (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (byte8 left, ushort8 right) => (ushort8)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, byte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left32lo = Xse.cvt2x2epu16_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epu8_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                if (Sse4_1.IsSse41Supported)
                {
                    v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                    v128 toInthi = Xse.cvttps_epi32(quotienthi);
                    return Xse.packus_epi32(toIntlo, toInthi);
                }
                else
                {
                    return Xse.cvtt2x2ps_epu16(quotientlo, quotienthi);
                }
            }
            else
            {
                return new ushort8((ushort)(left.x0 / right.x0), (ushort)(left.x1 / right.x1), (ushort)(left.x2 / right.x2), (ushort)(left.x3 / right.x3), (ushort)(left.x4 / right.x4), (ushort)(left.x5 / right.x5), (ushort)(left.x6 / right.x6), (ushort)(left.x7 / right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (byte8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left32lo = Xse.cvt2x2epu8_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epu16_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                if (Sse4_1.IsSse41Supported)
                {
                    v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                    v128 toInthi = Xse.cvttps_epi32(quotienthi);
                    return Xse.packus_epi32(toIntlo, toInthi);
                }
                else
                {
                    return Xse.cvtt2x2ps_epu16(quotientlo, quotienthi);
                }
            }
            else
            {
                return new ushort8((ushort)(left.x0 / right.x0), (ushort)(left.x1 / right.x1), (ushort)(left.x2 / right.x2), (ushort)(left.x3 / right.x3), (ushort)(left.x4 / right.x4), (ushort)(left.x5 / right.x5), (ushort)(left.x6 / right.x6), (ushort)(left.x7 / right.x7));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, byte8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left32lo = Xse.cvt2x2epu16_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epu8_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 quotient;
                if (Sse4_1.IsSse41Supported)
                {
                    v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                    v128 toInthi = Xse.cvttps_epi32(quotienthi);
                    quotient = Xse.packus_epi32(toIntlo, toInthi);
                }
                else
                {
                    quotient = Xse.cvtt2x2ps_epu16(quotientlo, quotienthi);
                }

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient, Xse.cvtepu8_epi16(right)));
            }
            else
            {
                return new ushort8((ushort)(left.x0 % right.x0), (ushort)(left.x1 % right.x1), (ushort)(left.x2 % right.x2), (ushort)(left.x3 % right.x3), (ushort)(left.x4 % right.x4), (ushort)(left.x5 % right.x5), (ushort)(left.x6 % right.x6), (ushort)(left.x7 % right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (byte8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left32lo = Xse.cvt2x2epu8_ps(left, out v128 left32hi);
                v128 right32lo = Xse.cvt2x2epu16_ps(right, out v128 right32hi);
                v128 quotientlo = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32lo, right32lo);
                v128 quotienthi = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32hi, right32hi);
                
                v128 quotient;
                if (Sse4_1.IsSse41Supported)
                {
                    v128 toIntlo = Xse.cvttps_epi32(quotientlo);
                    v128 toInthi = Xse.cvttps_epi32(quotienthi);
                    quotient = Xse.packus_epi32(toIntlo, toInthi);
                }
                else
                {
                    quotient = Xse.cvtt2x2ps_epu16(quotientlo, quotienthi);
                }

                return Xse.sub_epi16(Xse.cvtepu8_epi16(left), Xse.mullo_epi16(quotient, right));
            }
            else
            {
                return new ushort8((ushort)(left.x0 % right.x0), (ushort)(left.x1 % right.x1), (ushort)(left.x2 % right.x2), (ushort)(left.x3 % right.x3), (ushort)(left.x4 % right.x4), (ushort)(left.x5 % right.x5), (ushort)(left.x6 % right.x6), (ushort)(left.x7 % right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (ushort8 left, byte right) => left + (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator + (byte left, ushort8 right) => (ushort)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (ushort8 left, byte right) => left - (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator - (byte left, ushort8 right) => (ushort)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (ushort8 left, byte right) => left * (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator * (byte left, ushort8 right) => (ushort)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (ushort8 left, byte right) => left / (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator / (byte left, ushort8 right) => (ushort)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (ushort8 left, byte right) => left % (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator % (byte left, ushort8 right) => (ushort)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 & right.x0), (ushort)(left.x1 & right.x1), (ushort)(left.x2 & right.x2), (ushort)(left.x3 & right.x3), (ushort)(left.x4 & right.x4), (ushort)(left.x5 & right.x5), (ushort)(left.x6 & right.x6), (ushort)(left.x7 & right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 | right.x0), (ushort)(left.x1 | right.x1), (ushort)(left.x2 | right.x2), (ushort)(left.x3 | right.x3), (ushort)(left.x4 | right.x4), (ushort)(left.x5 | right.x5), (ushort)(left.x6 | right.x6), (ushort)(left.x7 | right.x7));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new ushort8((ushort)(left.x0 ^ right.x0), (ushort)(left.x1 ^ right.x1), (ushort)(left.x2 ^ right.x2), (ushort)(left.x3 ^ right.x3), (ushort)(left.x4 ^ right.x4), (ushort)(left.x5 ^ right.x5), (ushort)(left.x6 ^ right.x6), (ushort)(left.x7 ^ right.x7));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 left, ushort right) => left & (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort left, ushort8 right) => (ushort8)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 left, ushort right) => left | (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort left, ushort8 right) => (ushort8)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 left, ushort right) => left ^ (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort left, ushort8 right) => (ushort8)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (ushort8 left, byte right) => left & (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator & (byte left, ushort8 right) => (ushort8)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (ushort8 left, byte right) => left | (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator | (byte left, ushort8 right) => (ushort8)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (ushort8 left, byte right) => left ^ (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ^ (byte left, ushort8 right) => (ushort8)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator ++ (ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort8((ushort)(x.x0 << n), (ushort)(x.x1 << n), (ushort)(x.x2 << n), (ushort)(x.x3 << n), (ushort)(x.x4 << n), (ushort)(x.x5 << n), (ushort)(x.x6 << n), (ushort)(x.x7 << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 operator >> (ushort8 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort8((ushort)(x.x0 >> n), (ushort)(x.x1 >> n), (ushort)(x.x2 >> n), (ushort)(x.x3 >> n), (ushort)(x.x4 >> n), (ushort)(x.x5 >> n), (ushort)(x.x6 >> n), (ushort)(x.x7 >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_epi16(left, right);
            }
            else
            {
                return new mask16x8(left.x0 == right.x0, left.x1 == right.x1, left.x2 == right.x2, left.x3 == right.x3, left.x4 == right.x4, left.x5 == right.x5, left.x6 == right.x6, left.x7 == right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epu16(left, right, 8);
            }
            else
            {
                return new mask16x8(left.x0 < right.x0, left.x1 < right.x1, left.x2 < right.x2, left.x3 < right.x3, left.x4 < right.x4, left.x5 < right.x5, left.x6 < right.x6, left.x7 < right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epu16(left, right, 8);
            }
            else
            {
                return new mask16x8(left.x0 > right.x0, left.x1 > right.x1, left.x2 > right.x2, left.x3 > right.x3, left.x4 > right.x4, left.x5 > right.x5, left.x6 > right.x6, left.x7 > right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpeq_epi16(left, right));
            }
            else
            {
                return new mask16x8(left.x0 != right.x0, left.x1 != right.x1, left.x2 != right.x2, left.x3 != right.x3, left.x4 != right.x4, left.x5 != right.x5, left.x6 != right.x6, left.x7 != right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_epu16(left, right, 8);
            }
            else
            {
                return new mask16x8(left.x0 <= right.x0, left.x1 <= right.x1, left.x2 <= right.x2, left.x3 <= right.x3, left.x4 <= right.x4, left.x5 <= right.x5, left.x6 <= right.x6, left.x7 <= right.x7);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (ushort8 left, ushort8 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_epu16(left, right, 8);
            }
            else
            {
                return new mask16x8(left.x0 >= right.x0, left.x1 >= right.x1, left.x2 >= right.x2, left.x3 >= right.x3, left.x4 >= right.x4, left.x5 >= right.x5, left.x6 >= right.x6, left.x7 >= right.x7);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (ushort8 left, ushort right) => left == (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (ushort left, ushort8 right) => (ushort8)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (ushort8 left, ushort right) => left != (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (ushort left, ushort8 right) => (ushort8)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (ushort8 left, ushort right) => left < (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (ushort left, ushort8 right) => (ushort8)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (ushort8 left, ushort right) => left > (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (ushort left, ushort8 right) => (ushort8)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (ushort8 left, ushort right) => left <= (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (ushort left, ushort8 right) => (ushort8)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (ushort8 left, ushort right) => left >= (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (ushort left, ushort8 right) => (ushort8)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (ushort8 left, byte right) => left == (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator == (byte left, ushort8 right) => (ushort8)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (ushort8 left, byte right) => left != (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator != (byte left, ushort8 right) => (ushort8)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (ushort8 left, byte right) => left < (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator < (byte left, ushort8 right) => (ushort8)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (ushort8 left, byte right) => left > (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator > (byte left, ushort8 right) => (ushort8)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (ushort8 left, byte right) => left <= (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator <= (byte left, ushort8 right) => (ushort8)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (ushort8 left, byte right) => left >= (ushort8)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 operator >= (byte left, ushort8 right) => (ushort8)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort8 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ushort>(Xse.cmpeq_epi16(this, other));
            }
            else
            {
                return ((this.x0 == other.x0 & this.x1 == other.x1) & (this.x2 == other.x2 & this.x3 == other.x3)) & ((this.x4 == other.x4 & this.x5 == other.x5) & (this.x6 == other.x6 & this.x7 == other.x7));
            }
        }

        public override bool Equals(object obj) => obj is ushort8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"ushort8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}