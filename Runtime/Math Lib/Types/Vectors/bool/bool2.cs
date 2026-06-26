using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class bool2DebuggerProxy
    {
        public bool x;
        public bool y;

        public bool2DebuggerProxy(bool2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(bool2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool2 : IEquatable<bool2>, IEquatable<Unity.Mathematics.bool2>
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.bool2 __x0;
        
        public ref bool x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool2* ptr = &this) { return ref *((bool*)ptr +  0); } } }
        public ref bool y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool2* ptr = &this) { return ref *((bool*)ptr +  1); } } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(bool x, bool y)
        {
            __x0 = new Unity.Mathematics.bool2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(bool2 xy)
        {
            __x0 = xy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(bool v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(mask8x2 v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(mask16x2 v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(mask32x2 v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(mask64x2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(byte v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(byte2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(sbyte v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(sbyte2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(ushort v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(ushort2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(short v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(short2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(uint v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(uint2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(int v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(int2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(ulong v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(ulong2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(long v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(long2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(UInt128 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Int128 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(quarter v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(quarter2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(half v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(half2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(float v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(float2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(double v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(double2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(quadruple v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.bool2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.uint2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.int2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.half v)
        {
            this = (bool2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.half2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.float2 v)
        {
            this = (bool2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool2(Unity.Mathematics.double2 v)
        {
            this = (bool2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2(v128 v) => ((byte2)v).Reinterpret<byte2, bool2>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool2 v) => v.Reinterpret<bool2, byte2>();
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2(Unity.Mathematics.bool2 v) => new bool2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool2(bool2 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool2(bool v) => (Unity.Mathematics.bool2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(quadruple v) => math.andnot(v != 0, math.isnan(v));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Unity.Mathematics.half v) => (bool2)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Unity.Mathematics.half2 v) => (bool2)(half2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Unity.Mathematics.float2 v) => (bool2)(float2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Unity.Mathematics.double2 v) => (bool2)(double2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Unity.Mathematics.uint2 v) => (bool2)(uint2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(Unity.Mathematics.int2 v) => (bool2)(int2)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(bool2 v) => (half2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2(bool2 v) => (float2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2(bool2 v) => (double2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(bool2 v) => (uint2)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(bool2 v) => (int2)v;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (bool2 lhs, bool2 rhs) => math.tobyte(lhs) == math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (bool2 lhs, bool rhs) => math.tobyte(lhs) == math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (bool lhs, bool2 rhs) => math.tobyte(lhs) == math.tobyte(rhs);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (bool2 lhs, bool2 rhs) => math.tobyte(lhs) != math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (bool2 lhs, bool rhs) => math.tobyte(lhs) != math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (bool lhs, bool2 rhs) => math.tobyte(lhs) != math.tobyte(rhs);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator ! (bool2 v) => !v.__x0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator & (bool2 lhs, bool2 rhs) => lhs.__x0 & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator & (bool2 lhs, bool rhs) => lhs.__x0 & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator & (bool lhs, bool2 rhs) => lhs & rhs.__x0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator | (bool2 lhs, bool2 rhs) => lhs.__x0 | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator | (bool2 lhs, bool rhs) => lhs.__x0 | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator | (bool lhs, bool2 rhs) => lhs | rhs.__x0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator ^ (bool2 lhs, bool2 rhs) => lhs.__x0 ^ rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator ^ (bool2 lhs, bool rhs) => lhs.__x0 ^ rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator ^ (bool lhs, bool2 rhs) => lhs ^ rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (Unity.Mathematics.bool2 lhs, bool2 rhs) => (bool2)lhs == rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (Unity.Mathematics.bool2 lhs, bool2 rhs) => (bool2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator & (Unity.Mathematics.bool2 lhs, bool2 rhs) => (bool2)lhs & rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator | (Unity.Mathematics.bool2 lhs, bool2 rhs) => (bool2)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator ^ (Unity.Mathematics.bool2 lhs, bool2 rhs) => (bool2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator == (bool2 lhs, Unity.Mathematics.bool2 rhs) => lhs == (bool2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 operator != (bool2 lhs, Unity.Mathematics.bool2 rhs) => lhs != (bool2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator & (bool2 lhs, Unity.Mathematics.bool2 rhs) => lhs & (bool2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator | (bool2 lhs, Unity.Mathematics.bool2 rhs) => lhs | (bool2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator ^ (bool2 lhs, Unity.Mathematics.bool2 rhs) => lhs ^ (bool2)rhs;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }


        public bool this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return __x0[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                __x0[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(bool2 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool2 other) => __x0.Equals(other);

        public override readonly bool Equals(object o) => __x0.Equals(o);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        
        /// <summary>       Returns a <see cref="bool2"/> from the first 2 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 FromBitmask(int bitmask)
        {
            bool2 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.broadcastmask_epi8(bitmask, MaskType.One, 2);
            }
            else
            {
                bitmask &= 0b0011;

                int result32 = 0x0101 & (bitmask | (bitmask << 7));

                result = *(bool2*)&result32;
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b0011));
            return result;
        }
    }
}
