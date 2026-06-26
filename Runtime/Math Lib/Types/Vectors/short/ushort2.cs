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
    internal sealed class ushort2DebuggerProxy
    {
        public ushort x;
        public ushort y;

        public ushort2DebuggerProxy(ushort2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(ushort2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ushort2 : IEquatable<ushort2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
        
        public ref ushort x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort2* ptr = &this) { return ref *((ushort*)ptr +  0); } } }
        public ref ushort y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ushort2* ptr = &this) { return ref *((ushort*)ptr +  1); } } }


        public static ushort2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort x, ushort y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
                {
                    this = Xse.cvtsi32_si128(bitfield(x, y));
                }
                else
                {
				    this = Xse.insert_epi16(Xse.cvtsi32_si128(x), y, 1);
                }
            }
            else
            {
                __x0 = Uninitialized<uint>.Create();

                this.x = x;
                this.y = y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort xy)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(xy))
                {
                    this = Xse.cvtsi32_si128(bitfield(xy, xy));
                }
                else
                {
				    this = Xse.shufflelo_epi16(Xse.cvtsi32_si128(xy), Sse.SHUFFLE(0, 0, 0, 0));
                }
            }
            else
            {
                __x0 = Uninitialized<uint>.Create();

                this.x = xy;
                this.y = xy;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(bool v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(bool2 v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(mask8x2 v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(mask16x2 v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(mask32x2 v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(mask64x2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(byte v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(byte2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(sbyte v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(sbyte2 v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ushort2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(short v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(short2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(uint v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(uint2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(int v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(int2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ulong v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(ulong2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(long v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(long2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(UInt128 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Int128 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(quarter v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(quarter2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(half v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(half2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(float v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(float2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(double v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(double2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(quadruple v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.bool2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.uint2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.int2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.half v)
        {
            this = (ushort2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.half2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.float2 v)
        {
            this = (ushort2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort2(Unity.Mathematics.double2 v)
        {
            this = (ushort2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, y);
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
                }
                else
                {
                    return new ushort3(y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ushort3(x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
                }
                else
                {
                    return new ushort3(y, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
                }
                else
                {
                    return new ushort3(x, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, y);
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new ushort2(x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return this;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value;
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
                }
                else
                {
                    return new ushort2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yx;
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ushort2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
                }
                else
                {
                    return new ushort2(y, y);
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort2 input)
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

            result.UInt0 = input.__x0;
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(v128 input) => new ushort2 { __x0 = input.UInt0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(bool2 x) => (ushort2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.bool2 x) => (ushort2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ushort2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(ushort2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(ushort2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(ushort2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(ushort2 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(ushort2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(ushort2 x) => (mask16x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ushort2(byte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(sbyte x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(short x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(uint x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(int x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(ulong x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(long x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(UInt128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Int128 x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(quarter x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(half x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(float x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(double x) => (ushort)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(quadruple x) => (ushort)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.half x) => (ushort2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.half2 x) => (ushort2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.float2 x) => (ushort2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.double2 x) => (ushort2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.uint2 x) => (ushort2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(Unity.Mathematics.int2 x) => (ushort2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(ushort2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(ushort2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(ushort2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint2(ushort2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2(ushort2 x) => (int2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort2(ushort input) => new ushort2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(short2 input) => *(ushort2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(int2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(input, 2);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(uint2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(input, 2);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_epi16(input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_epi16(input);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(float2 input) => (ushort2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(double2 input) => (ushort2)(int2)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_epi32(input);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return  Xse.cvtepu16_epi32(input);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ps(input);
            }
            else
            {
                return (float2)(int2)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ushort2 input) => (int2)input;

        
        public ushort this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
					    return Xse.extract_epi16(this, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort2* ptr = &this)
                    {
                        return ((ushort*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<ushort2, ushort>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						this = Xse.insert_epi16(this, value, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort2* ptr = &this)
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
        public static ushort2 operator + (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi16(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x + right.x), (ushort)(left.y + right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (ushort left, ushort2 right) => (ushort2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (ushort2 left, ushort right) => left + (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi16(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x - right.x), (ushort)(left.y - right.y));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort left, ushort2 right) => (ushort2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort2 left, ushort right) => left - (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi16(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x * right.x), (ushort)(left.y * right.y));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort left, ushort2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, ushort right)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return (v128)((ushort8)((v128)left) * right);
				}
			}

			return left * (ushort2)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu16(left, right, 2);
            }
            else
            {
                return new ushort2((ushort)(left.x / right.x), (ushort)(left.y / right.y));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort left, ushort2 right) => (ushort2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, right, 2);
                }
            }

            return left / (ushort2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu16(left, right, 2);
            }
            else
            {
                return new ushort2((ushort)(left.x % right.x), (ushort)(left.y % right.y));
            }
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort left, ushort2 right) => (ushort2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, right, 2);
                }
            }

            return left % (ushort2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (ushort2 left, byte2 right) => left + (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (byte2 left, ushort2 right) => (ushort2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort2 left, byte2 right) => left - (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (byte2 left, ushort2 right) => (ushort2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, byte2 right) => left * (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (byte2 left, ushort2 right) => (ushort2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, Xse.cvtepu8_epi16(right), 2);
                }

                v128 left22 = Xse.cvtepu16_ps(left);
                v128 right22 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    return Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    return Xse.cvttps_epu16(quotient);
                }
            }
            else
            {
                return new ushort2((ushort)(left.x / right.x), (ushort)(left.y / right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (byte2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(Xse.cvtepu8_epi16(left), right, 2);
                }

                v128 left22 = Xse.cvtepu8_ps(left);
                v128 right22 = Xse.cvtepu16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    return Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    return Xse.cvttps_epu16(quotient);
                }
            }
            else
            {
                return new ushort2((ushort)(left.x / right.x), (ushort)(left.y / right.y));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, Xse.cvtepu8_epi16(right), 2);
                }

                v128 left22 = Xse.cvtepu16_ps(left);
                v128 right22 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    quotient = Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    quotient = Xse.cvttps_epu16(quotient);
                }

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient, Xse.cvtepu8_epi16(right)));
            }
            else
            {
                return new ushort2((ushort)(left.x % right.x), (ushort)(left.y % right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (byte2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(Xse.cvtepu8_epi16(left), right, 2);
                }

                v128 left22 = Xse.cvtepu8_ps(left);
                v128 right22 = Xse.cvtepu16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left22, right22);

                if (Sse4_1.IsSse41Supported)
                {
                    v128 toInt = Xse.cvttps_epi32(quotient);
                    quotient = Xse.packus_epi32(toInt, toInt);
                }
                else
                {
                    quotient = Xse.cvttps_epu16(quotient);
                }

                return Xse.sub_epi16(Xse.cvtepu8_epi16(left), Xse.mullo_epi16(quotient, right));
            }
            else
            {
                return new ushort2((ushort)(left.x % right.x), (ushort)(left.y % right.y));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (ushort2 left, byte right) => left + (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator + (byte left, ushort2 right) => (ushort)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (ushort2 left, byte right) => left - (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator - (byte left, ushort2 right) => (ushort)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (ushort2 left, byte right) => left * (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator * (byte left, ushort2 right) => (ushort)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (ushort2 left, byte right) => left / (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator / (byte left, ushort2 right) => (ushort)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (ushort2 left, byte right) => left % (ushort)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator % (byte left, ushort2 right) => (ushort)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (ushort2 left, Unity.Mathematics.int2 right) => left + (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (Unity.Mathematics.int2 left, ushort2 right) => (int2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (ushort2 left, Unity.Mathematics.int2 right) => left - (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (Unity.Mathematics.int2 left, ushort2 right) => (int2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (ushort2 left, Unity.Mathematics.int2 right) => left * (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (Unity.Mathematics.int2 left, ushort2 right) => (int2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (ushort2 left, Unity.Mathematics.int2 right) => left / (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (Unity.Mathematics.int2 left, ushort2 right) => (int2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (ushort2 left, Unity.Mathematics.int2 right) => left % (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (Unity.Mathematics.int2 left, ushort2 right) => (int2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (ushort2 left, Unity.Mathematics.uint2 right) => left + (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (ushort2 left, Unity.Mathematics.uint2 right) => left - (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (ushort2 left, Unity.Mathematics.uint2 right) => left * (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (ushort2 left, Unity.Mathematics.uint2 right) => left / (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (ushort2 left, Unity.Mathematics.uint2 right) => left % (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (ushort2 left, Unity.Mathematics.float2 right) => left + (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 left, ushort2 right) => (float2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (ushort2 left, Unity.Mathematics.float2 right) => left - (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 left, ushort2 right) => (float2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (ushort2 left, Unity.Mathematics.float2 right) => left * (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 left, ushort2 right) => (float2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (ushort2 left, Unity.Mathematics.float2 right) => left / (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 left, ushort2 right) => (float2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (ushort2 left, Unity.Mathematics.float2 right) => left % (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 left, ushort2 right) => (float2)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (ushort2 left, Unity.Mathematics.double2 right) => left + (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 left, ushort2 right) => (double2)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (ushort2 left, Unity.Mathematics.double2 right) => left - (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 left, ushort2 right) => (double2)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (ushort2 left, Unity.Mathematics.double2 right) => left * (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 left, ushort2 right) => (double2)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (ushort2 left, Unity.Mathematics.double2 right) => left / (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 left, ushort2 right) => (double2)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (ushort2 left, Unity.Mathematics.double2 right) => left % (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 left, ushort2 right) => (double2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x & right.x), (ushort)(left.y & right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x | right.x), (ushort)(left.y | right.y));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new ushort2((ushort)(left.x ^ right.x), (ushort)(left.y ^ right.y));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 left, byte right) => left & (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (byte left, ushort2 right) => (ushort)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 left, byte right) => left | (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (byte left, ushort2 right) => (ushort)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 left, byte right) => left ^ (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (byte left, ushort2 right) => (ushort)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 left, ushort right) => left & (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort left, ushort2 right) => (ushort2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 left, ushort right) => left | (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort left, ushort2 right) => (ushort2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 left, ushort right) => left ^ (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort left, ushort2 right) => (ushort2)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (ushort2 left, byte2 right) => left & (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator & (byte2 left, ushort2 right) => (ushort2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (ushort2 left, byte2 right) => left | (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator | (byte2 left, ushort2 right) => (ushort2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (ushort2 left, byte2 right) => left ^ (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ^ (byte2 left, ushort2 right) => (ushort2)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (ushort2 left, Unity.Mathematics.int2 right) => left & (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (Unity.Mathematics.int2 left, ushort2 right) => (int2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (ushort2 left, Unity.Mathematics.int2 right) => left | (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (Unity.Mathematics.int2 left, ushort2 right) => (int2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (ushort2 left, Unity.Mathematics.int2 right) => left ^ (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (Unity.Mathematics.int2 left, ushort2 right) => (int2)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (ushort2 left, Unity.Mathematics.uint2 right) => left & (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (ushort2 left, Unity.Mathematics.uint2 right) => left | (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (ushort2 left, Unity.Mathematics.uint2 right) => left ^ (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ++ (ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new ushort2((ushort)(x.x + 1), (ushort)(x.y + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator -- (ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new ushort2((ushort)(x.x - 1), (ushort)(x.y - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator ~ (ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new ushort2((ushort)~x.x, (ushort)~x.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator << (ushort2 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort2((ushort)(x.x << n), (ushort)(x.y << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 operator >> (ushort2 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort2((ushort)(x.x >> n), (ushort)(x.y >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpeq_epi16(left, right);
            }
            else
            {
                return new mask16x2(left.x == right.x, left.y == right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmplt_epu16(left, right, 2);
            }
            else
            {
                return new mask16x2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpgt_epu16(left, right, 2);
            }
            else
            {
                return new mask16x2(left.x > right.x, left.y > right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmpeq_epi16(left, right));
            }
            else
            {
                return new mask16x2(left.x != right.x, left.y != right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmple_epu16(left, right, 2);
            }
            else
            {
                return new mask16x2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpge_epu16(left, right, 2);
            }
            else
            {
                return new mask16x2(left.x >= right.x, left.y >= right.y);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, byte right) => left == (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (byte left, ushort2 right) => (ushort)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, byte right) => left != (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (byte left, ushort2 right) => (ushort)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, byte right) => left < (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (byte left, ushort2 right) => (ushort)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, byte right) => left > (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (byte left, ushort2 right) => (ushort)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, byte right) => left <= (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (byte left, ushort2 right) => (ushort)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, byte right) => left >= (ushort)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (byte left, ushort2 right) => (ushort)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, ushort right) => left == (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort left, ushort2 right) => (ushort2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, ushort right) => left != (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort left, ushort2 right) => (ushort2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, ushort right) => left < (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort left, ushort2 right) => (ushort2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, ushort right) => left > (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort left, ushort2 right) => (ushort2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, ushort right) => left <= (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort left, ushort2 right) => (ushort2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, ushort right) => left >= (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort left, ushort2 right) => (ushort2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, byte2 right) => left == (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (byte2 left, ushort2 right) => (ushort2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, byte2 right) => left != (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (byte2 left, ushort2 right) => (ushort2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, byte2 right) => left < (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (byte2 left, ushort2 right) => (ushort2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, byte2 right) => left > (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (byte2 left, ushort2 right) => (ushort2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, byte2 right) => left <= (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (byte2 left, ushort2 right) => (ushort2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, byte2 right) => left >= (ushort2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (byte2 left, ushort2 right) => (ushort2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, Unity.Mathematics.int2 right) => left == (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.int2 left, ushort2 right) => (int2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, Unity.Mathematics.int2 right) => left != (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.int2 left, ushort2 right) => (int2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, Unity.Mathematics.int2 right) => left < (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.int2 left, ushort2 right) => (int2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, Unity.Mathematics.int2 right) => left > (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.int2 left, ushort2 right) => (int2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, Unity.Mathematics.int2 right) => left <= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.int2 left, ushort2 right) => (int2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, Unity.Mathematics.int2 right) => left >= (int2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.int2 left, ushort2 right) => (int2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, Unity.Mathematics.uint2 right) => left == (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, Unity.Mathematics.uint2 right) => left != (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, Unity.Mathematics.uint2 right) => left < (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, Unity.Mathematics.uint2 right) => left > (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, Unity.Mathematics.uint2 right) => left <= (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, Unity.Mathematics.uint2 right) => left >= (uint2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.uint2 left, ushort2 right) => (uint2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, Unity.Mathematics.float2 right) => left == (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.float2 left, ushort2 right) => (float2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, Unity.Mathematics.float2 right) => left != (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.float2 left, ushort2 right) => (float2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, Unity.Mathematics.float2 right) => left < (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.float2 left, ushort2 right) => (float2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, Unity.Mathematics.float2 right) => left > (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.float2 left, ushort2 right) => (float2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, Unity.Mathematics.float2 right) => left <= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.float2 left, ushort2 right) => (float2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, Unity.Mathematics.float2 right) => left >= (float2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.float2 left, ushort2 right) => (float2)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (ushort2 left, Unity.Mathematics.double2 right) => left == (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.double2 left, ushort2 right) => (double2)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (ushort2 left, Unity.Mathematics.double2 right) => left != (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.double2 left, ushort2 right) => (double2)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (ushort2 left, Unity.Mathematics.double2 right) => left < (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.double2 left, ushort2 right) => (double2)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (ushort2 left, Unity.Mathematics.double2 right) => left > (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.double2 left, ushort2 right) => (double2)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (ushort2 left, Unity.Mathematics.double2 right) => left <= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.double2 left, ushort2 right) => (double2)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (ushort2 left, Unity.Mathematics.double2 right) => left >= (double2)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.double2 left, ushort2 right) => (double2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort2 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return uint.MaxValue == Xse.cmpeq_epi8(this, other).UInt0;
            }
            else
            {
                return this.x == other.x & this.y == other.y;
            }
        }

        public override bool Equals(object obj) => obj is ushort2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"ushort2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}