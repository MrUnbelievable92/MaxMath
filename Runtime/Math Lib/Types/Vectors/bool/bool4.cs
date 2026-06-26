using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class bool4DebuggerProxy
    {
	    public bool x;
	    public bool y;
	    public bool z;
	    public bool w;
        
	    public bool4DebuggerProxy(bool4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(bool4DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct bool4 : IEquatable<bool4>, IEquatable<Unity.Mathematics.bool4>
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.bool4 __x0;
        
        public ref bool x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool4* ptr = &this) { return ref *((bool*)ptr +  0); } } }
        public ref bool y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool4* ptr = &this) { return ref *((bool*)ptr +  1); } } }
        public ref bool z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool4* ptr = &this) { return ref *((bool*)ptr +  2); } } }
        public ref bool w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(bool4* ptr = &this) { return ref *((bool*)ptr +  3); } } }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool x, bool y, bool z, bool w)
        {
            __x0 = new Unity.Mathematics.bool4(x, y, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool x, bool y, bool2 zw)
        {
            __x0 = new Unity.Mathematics.bool4(x, y, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool x, bool2 yz, bool w)
        {
            __x0 = new Unity.Mathematics.bool4(x, yz, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool x, bool3 yzw)
        {
            __x0 = new Unity.Mathematics.bool4(x, yzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool2 xy, bool z, bool w)
        {
            __x0 = new Unity.Mathematics.bool4(xy, z, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool2 xy, bool2 zw)
        {
            __x0 = new Unity.Mathematics.bool4(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool3 xyz, bool w)
        {
            __x0 = new Unity.Mathematics.bool4(xyz, w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(bool4 v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(mask8x4 v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(mask16x4 v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(mask32x4 v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(mask64x4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(byte v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(byte4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(sbyte v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(sbyte4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(ushort v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(ushort4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(short v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(short4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(uint v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(uint4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(int v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(int4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(ulong v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(ulong4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(long v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(long4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(UInt128 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Int128 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(quarter v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(quarter4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(half v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(half4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(float v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(float4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(double v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(double4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(quadruple v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.bool4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.uint4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.int4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.half v)
        {
            this = (bool4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.half4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.float4 v)
        {
            this = (bool4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool4(Unity.Mathematics.double4 v)
        {
            this = (bool4)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4(v128 v) => ((byte4)v).Reinterpret<byte4, bool4>();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(bool4 v) => v.Reinterpret<bool4, byte4>();
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4(Unity.Mathematics.bool4 v) => new bool4 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.bool4(bool4 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool4(bool v) => (Unity.Mathematics.bool4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(byte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(ushort v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(uint v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(ulong v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(UInt128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(sbyte v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(short v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(int v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(long v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Int128 v) => v != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(quarter v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(half v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(float v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(double v) => math.andnot(v != 0, math.isnan(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(quadruple v) => math.andnot(v != 0, math.isnan(v));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Unity.Mathematics.half v) => (bool4)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Unity.Mathematics.half4 v) => (bool4)(half4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Unity.Mathematics.float4 v) => (bool4)(float4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Unity.Mathematics.double4 v) => (bool4)(double4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Unity.Mathematics.uint4 v) => (bool4)(uint4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(Unity.Mathematics.int4 v) => (bool4)(int4)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(bool4 v) => (half4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4(bool4 v) => (float4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4(bool4 v) => (double4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(bool4 v) => (uint4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(bool4 v) => (int4)v;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (bool4 lhs, bool4 rhs) => math.tobyte(lhs) == math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (bool4 lhs, bool rhs) => math.tobyte(lhs) == math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (bool lhs, bool4 rhs) => math.tobyte(lhs) == math.tobyte(rhs);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (bool4 lhs, bool4 rhs) => math.tobyte(lhs) != math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (bool4 lhs, bool rhs) => math.tobyte(lhs) != math.tobyte(rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (bool lhs, bool4 rhs) => math.tobyte(lhs) != math.tobyte(rhs);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ! (bool4 v) => !v.__x0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator & (bool4 lhs, bool4 rhs) => lhs.__x0 & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator & (bool4 lhs, bool rhs) => lhs.__x0 & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator & (bool lhs, bool4 rhs) => lhs & rhs.__x0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator | (bool4 lhs, bool4 rhs) => lhs.__x0 | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator | (bool4 lhs, bool rhs) => lhs.__x0 | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator | (bool lhs, bool4 rhs) => lhs | rhs.__x0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ^ (bool4 lhs, bool4 rhs) => lhs.__x0 ^ rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ^ (bool4 lhs, bool rhs) => lhs.__x0 ^ rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ^ (bool lhs, bool4 rhs) => lhs ^ rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.bool4 lhs, bool4 rhs) => (bool4)lhs == rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.bool4 lhs, bool4 rhs) => (bool4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator & (Unity.Mathematics.bool4 lhs, bool4 rhs) => (bool4)lhs & rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator | (Unity.Mathematics.bool4 lhs, bool4 rhs) => (bool4)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ^ (Unity.Mathematics.bool4 lhs, bool4 rhs) => (bool4)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (bool4 lhs, Unity.Mathematics.bool4 rhs) => lhs == (bool4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (bool4 lhs, Unity.Mathematics.bool4 rhs) => lhs != (bool4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator & (bool4 lhs, Unity.Mathematics.bool4 rhs) => lhs & (bool4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator | (bool4 lhs, Unity.Mathematics.bool4 rhs) => lhs | (bool4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator ^ (bool4 lhs, Unity.Mathematics.bool4 rhs) => lhs ^ (bool4)rhs;


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
        public readonly bool4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxw; }
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
        public readonly bool4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxww; }
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
        public readonly bool4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxw; }
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
        public readonly bool4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 xyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 xywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xywz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xywz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 xzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 xzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 xwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 xwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 xwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwww; }
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
        public readonly bool4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxw; }
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
        public readonly bool4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 yxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 yxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxwz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxwz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxww; }
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
        public readonly bool4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxw; }
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
        public readonly bool4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 yzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 yzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzwx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzwx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 yzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 ywxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 ywzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 ywww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 zxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 zxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 zyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 zywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zywx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zywx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 zwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 zwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 zwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 wxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 wxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 wyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 wyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wywz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 wzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool4 wzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool4 wwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwww; }
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
        public readonly bool3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxw; }
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
        public bool3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 xyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 xzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 xwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 xwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xwz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xwz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 xww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xww; }
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
        public bool3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 yxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxw = value; }
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
        public readonly bool3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 yzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 ywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 ywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ywy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 ywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.ywz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.ywz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 yww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 zxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 zyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 zwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 zwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zwy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zwy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 zww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zww; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 wxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 wxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wxw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 wyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 wyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wyw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 wzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool3 wzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wzw; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 wwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.wwz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool3 www
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.www; }
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
        public bool2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 xw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xw = value; }
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 yw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 zw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zw; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zw = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 wx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 wy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public bool2 wz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.wz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.wz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly bool2 ww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.ww; }
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
        public readonly bool Equals(bool4 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.bool4 other) => __x0.Equals(other);

        public override readonly bool Equals(object o) => __x0.Equals(o);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        
        /// <summary>       Returns a <see cref="bool4"/> from the first 4 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 FromBitmask(int bitmask)
        {
            bool4 result;
            if (BurstArchitecture.IsSIMDSupported)
            {
                result = Xse.broadcastmask_epi8(bitmask, MaskType.One, 4);
            }
            else
            {
                result = math.tobool(1 & new byte4((byte)bitmask, (byte)(bitmask >> 1), (byte)(bitmask >> 2), (byte)(bitmask >> 3)));
            }

            constexpr.ASSUME(math.bitmask(result) == (bitmask & 0b1111));
            return result;
        }
    }
}
