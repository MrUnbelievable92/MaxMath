using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class quarter2DebuggerProxy
    {
        public quarter x;
        public quarter y;

        public quarter2DebuggerProxy(quarter2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(quarter2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct quarter2 : IEquatable<quarter2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x0;
        
        public ref quarter x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter2* ptr = &this) { return ref *((quarter*)ptr +  0); } } }
        public ref quarter y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter2* ptr = &this) { return ref *((quarter*)ptr +  1); } } }


        public static quarter2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter x, quarter y)
        {
            this = asquarter(new byte2(x.value, y.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter xy)
        {
            this = asquarter(new byte2(xy.value));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(bool v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(bool2 v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(mask8x2 v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(mask16x2 v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(mask32x2 v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(mask64x2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(byte v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(byte2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(sbyte v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(sbyte2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(ushort v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(ushort2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(short v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(short2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(uint v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(uint2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(int v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(int2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(ulong v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(ulong2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(long v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(long2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(UInt128 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Int128 v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quarter2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(half v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(half2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(float v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(float2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(double v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(double2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(quadruple v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.bool2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.uint2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.int2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.half v)
        {
            this = (quarter2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.half2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.float2 v)
        {
            this = (quarter2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter2(Unity.Mathematics.double2 v)
        {
            this = (quarter2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyy); }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyy); }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter2 input) => asbyte(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(v128 input) => asquarter((byte2)input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(bool x) => (quarter2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(bool2 x) => (quarter2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.bool2 x) => (quarter2)(mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return (quarter2)(*(byte2*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter2)(mask8x2)x;
            }
            else
            {
                return (quarter2)(*(byte2*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter2)(mask8x2)x;
            }
            else
            {
                return (quarter2)(*(byte2*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter2)(mask8x2)x;
            }
            else
            {
                return *(quarter2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(quarter2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(quarter2 x) => (bool2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(quarter2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(quarter2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(quarter2 x) => (mask8x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(quarter2 x) => (mask8x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(byte x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(sbyte x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ushort x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(short x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(uint x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(int x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ulong x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(long x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(UInt128 x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Int128 x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(quadruple x) => (quarter)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.half x) => (quarter2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.half2 x) => (quarter2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.float2 x) => (quarter2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.double2 x) => (quarter2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.uint2 x) => (quarter2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(Unity.Mathematics.int2 x) => (quarter2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(quarter2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(quarter2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(quarter2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(quarter2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(quarter2 x) => (int2)x;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter2(quarter input) => new quarter2(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(input, MaxMath.quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(input, MaxMath.quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(input, MaxMath.quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(input, MaxMath.quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(int2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(input, MaxMath.quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(uint2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(input, MaxMath.quarter.PositiveInfinity, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_pq(input, MaxMath.quarter.PositiveInfinity);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu64_pq(input, MaxMath.quarter.PositiveInfinity);
            }
            else
            {
                return new quarter2((quarter)input.x,
                                    (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(input, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(float2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_pq(input, elements: 2);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter2(double2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_pq(input);
            }
            else
            {
                return new quarter2((quarter)input.x, (quarter)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(input, 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(input, 2);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(input, 2);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi32(input, 2);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu32(input, 2);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ph(input, elements: 2);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ps(input);
            }
            else
            {
                return new float2(input.x, input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(quarter2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_pd(input);
            }
            else
            {
                return new double2((double)input.x, (double)input.y);
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return asquarter(asbyte(this)[index]);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte2 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 operator - (quarter2 value)
        {
            return asquarter(asbyte(value) ^ new byte2(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_pq(left, right, elements: 2);
            }
            else
            {
                return new mask8x2(left.x == right.x, left.y == right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, quarter right) => left == (quarter2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter left, quarter2 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left == right;
            }
            else
            {
                return (half2)left == right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (half left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left == (float2)right;
            }
            else
            {
                return left == (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, half2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left == right;
            }
            else
            {
                return (half2)left == right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (half2 left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left == (float2)right;
            }
            else
            {
                return left == (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, Unity.Mathematics.half2 right) => left == (half2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.half2 left, quarter2 right) => (half2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, Unity.Mathematics.float2 right) => left == (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.float2 left, quarter2 right) => (float2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, Unity.Mathematics.double2 right) => left == (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.double2 left, quarter2 right) => (double2)left == right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_pq(left, right, elements: 2);
            }
            else
            {
                return new mask8x2(left.x != right.x, left.y != right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, quarter right) => left != (quarter2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter left, quarter2 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left != right;
            }
            else
            {
                return (half2)left != right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (half left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left != (float2)right;
            }
            else
            {
                return left != (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, half2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left != right;
            }
            else
            {
                return (half2)left != right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (half2 left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left != (float2)right;
            }
            else
            {
                return left != (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, Unity.Mathematics.half2 right) => left != (half2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.half2 left, quarter2 right) => (half2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, Unity.Mathematics.float2 right) => left != (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.float2 left, quarter2 right) => (float2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, Unity.Mathematics.double2 right) => left != (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.double2 left, quarter2 right) => (double2)left != right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_pq(left, right, elements: 2);
            }
            else
            {
                return new mask8x2(left.x < right.x, left.y < right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, quarter right) => left < (quarter2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter left, quarter2 right) => (quarter2)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left < right;
            }
            else
            {
                return (half2)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (half left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left < (float2)right;
            }
            else
            {
                return left < (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, half2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left < right;
            }
            else
            {
                return (half2)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (half2 left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left < (float2)right;
            }
            else
            {
                return left < (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, Unity.Mathematics.half2 right) => left < (half2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.half2 left, quarter2 right) => (half2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, Unity.Mathematics.float2 right) => left < (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.float2 left, quarter2 right) => (float2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, Unity.Mathematics.double2 right) => left < (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.double2 left, quarter2 right) => (double2)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_pq(left, right, elements: 2);
            }
            else
            {
                return new mask8x2(left.x > right.x, left.y > right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, quarter right) => left > (quarter2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter left, quarter2 right) => (quarter2)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left > right;
            }
            else
            {
                return (half2)left > right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (half left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left > (float2)right;
            }
            else
            {
                return left > (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, half2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left > right;
            }
            else
            {
                return (half2)left > right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (half2 left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left > (float2)right;
            }
            else
            {
                return left > (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, Unity.Mathematics.half2 right) => left > (half2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.half2 left, quarter2 right) => (half2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, Unity.Mathematics.float2 right) => left > (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.float2 left, quarter2 right) => (float2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, Unity.Mathematics.double2 right) => left > (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.double2 left, quarter2 right) => (double2)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_pq(left, right, elements: 2);
            }
            else
            {
                return new mask8x2(left.x <= right.x, left.y <= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, quarter right) => left <= (quarter2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter left, quarter2 right) => (quarter2)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left <= right;
            }
            else
            {
                return (half2)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (half left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left <= (float2)right;
            }
            else
            {
                return left <= (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, half2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left <= right;
            }
            else
            {
                return (half2)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (half2 left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left <= (float2)right;
            }
            else
            {
                return left <= (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, Unity.Mathematics.half2 right) => left <= (half2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.half2 left, quarter2 right) => (half2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, Unity.Mathematics.float2 right) => left <= (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.float2 left, quarter2 right) => (float2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, Unity.Mathematics.double2 right) => left <= (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.double2 left, quarter2 right) => (double2)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, quarter2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_pq(left, right, elements: 2);
            }
            else
            {
                return new mask8x2(left.x >= right.x, left.y >= right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, quarter right) => left >= (quarter2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter left, quarter2 right) => (quarter2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left >= right;
            }
            else
            {
                return (half2)left >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (half left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left >= (float2)right;
            }
            else
            {
                return left >= (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, half2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)left >= right;
            }
            else
            {
                return (half2)left >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (half2 left, quarter2 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left >= (float2)right;
            }
            else
            {
                return left >= (half2)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, Unity.Mathematics.half2 right) => left >= (half2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.half2 left, quarter2 right) => (half2)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, Unity.Mathematics.float2 right) => left >= (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.float2 left, quarter2 right) => (float2)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, Unity.Mathematics.double2 right) => left >= (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.double2 left, quarter2 right) => (double2)left >= right;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (half2)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }

            return (half2)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }

            return (half2)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }

            return (half2)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }

            return (half2)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }

            return (half2)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.half left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }

            return left == (half2)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.half left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }

            return left != (half2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (Unity.Mathematics.half left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }

            return left < (half2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (Unity.Mathematics.half left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }

            return left > (half2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (Unity.Mathematics.half left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }

            return left <= (half2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (Unity.Mathematics.half left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }

            return left >= (half2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (float2)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }

            return (float2)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }

            return (float2)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }

            return (float2)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }

            return (float2)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }

            return (float2)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (float left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }

            return left == (float2)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (float left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }

            return left != (float2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (float left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }

            return left < (float2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (float left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }

            return left > (float2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (float left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }

            return left <= (float2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (float left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }

            return left >= (float2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (quarter2 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (double2)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (quarter2 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }
            
            return (double2)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (quarter2 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }
            
            return (double2)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (quarter2 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }
            
            return (double2)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (quarter2 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }
            
            return (double2)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (quarter2 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }
            
            return (double2)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (double left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }
            
            return left == (double2)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (double left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }
            
            return left != (double2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator < (double left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }
            
            return left < (double2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator > (double left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }
            
            return left > (double2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator <= (double left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }
            
            return left <= (double2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator >= (double left, quarter2 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }
            
            return left >= (double2)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter2 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vcmpeq_pq(this, other, elements: 2);
            }
            else
            {
                return this.x == other.x && this.y == other.y;
            }
        }

        public override bool Equals(object obj) => obj is quarter2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"quarter2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}